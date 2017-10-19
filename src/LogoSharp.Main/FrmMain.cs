using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using LogoSharp.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LogoSharp.Main
{
    public partial class FrmMain : Form
    {
        private readonly Turtle turtle;
        private readonly Logo logo = new Logo();

        public FrmMain()
        {
            InitializeComponent();

            this.turtle = new Turtle(this.pnlCanvas);
            this.turtle.SetPenWidth(2.0F);
            this.turtle.Reset();

            this.BindLogoEvents();

            using (var stream = this.GetType().Assembly.GetManifestResourceStream("LogoSharp.Main.LogoSharp.xshd"))
            {
                using (var xmlTextReader = new XmlTextReader(stream))
                {
                    this.TextEditorInstance.SyntaxHighlighting = HighlightingLoader.Load(xmlTextReader, HighlightingManager.Instance);
                }
            }
        }

        private void BindLogoEvents()
        {
            logo.TurnLeft += (s, e) =>
            {
                this.turtle.Left(e.Angle);
            };

            logo.TurnRight += (s, e) =>
            {
                this.turtle.Right(e.Angle);
            };

            logo.Forward += (s, e) =>
            {
                this.turtle.MoveForward(e.Steps);
            };

            logo.Backward += (s, e) =>
            {
                this.turtle.MoveBackward(e.Steps);
            };

            logo.PenUp += (s, e) =>
            {
                this.turtle.PenStatus = PenStatus.Up;
            };

            logo.PenDown += (s, e) =>
            {
                this.turtle.PenStatus = PenStatus.Down;
            };

            logo.SetPenColor += (s, e) =>
            {
                this.turtle.SetPenColor(e.R, e.G, e.B);
            };

            logo.Delay += (s, e) =>
            {
                this.turtle.SetDelayMilliseconds(e.Milliseconds);
            };

            logo.ClearScreen += (s, e) =>
            {
                this.turtle.Clear();
            };
        }

        private string SourceCode
        {
            get { return TextEditorInstance.Text; }
            set
            {
                TextEditorInstance.Text = value;
            }
        }

        private ICSharpCode.AvalonEdit.TextEditor TextEditorInstance => (this.elementHost1.Child as TextEditor).avalonTextEditor;

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            this.TextEditorInstance.Focus();
        }
    }
}
