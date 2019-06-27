using LogoSharp.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogoSharp.Main
{
    public partial class FrmTesting : Form
    {
        private readonly Turtle turtle;
        private readonly Logo logo = new Logo();

        public FrmTesting()
        {
            InitializeComponent();
            this.turtle = new Turtle(this.pnlMain);
            this.turtle.SetPenWidth(2.0F);
            this.turtle.Reset();
            this.lblColor.BackColor = this.turtle.PenColor;

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
                  lblColor.BackColor = Color.FromArgb(e.R, e.G, e.B);
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

            logo.GoHome += (s, e) =>
              {
                  this.turtle.Reset();
              };

            logo.ShowTurtle += (s, e) =>
              {
                  this.turtle.ShowTurtle();
              };

            logo.HideTurtle += (s, e) =>
              {
                  this.turtle.HideTurtle();
              };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = this.turtle.ToString();
        }

        private void btnTurnLeft_Click(object sender, EventArgs e)
        {
            this.turtle.Left((float)numAngle.Value);
        }

        private void btnTurnRight_Click(object sender, EventArgs e)
        {
            this.turtle.Right((float)numAngle.Value);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.turtle.Reset();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            this.turtle.MoveForward((int)numSteps.Value);
        }

        private void btnBackward_Click(object sender, EventArgs e)
        {
            this.turtle.MoveBackward((int)numSteps.Value);
        }

        private void btnPenUp_Click(object sender, EventArgs e)
        {
            this.turtle.PenStatus = PenStatus.Up;
        }

        private void btnPenDown_Click(object sender, EventArgs e)
        {
            this.turtle.PenStatus = PenStatus.Down;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.turtle.ShowTurtle();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.turtle.HideTurtle();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.turtle.Clear();
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                lblColor.BackColor = colorDialog1.Color;
                this.turtle.SetPenColor(colorDialog1.Color);
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            var sourceCode = txtSourceCode.Text;

            try
            {
                this.logo.Execute(sourceCode);
                txtError.Text = string.Empty;
            }
            catch(ParsingException pex)
            {
                txtError.Text = string.Join(Environment.NewLine, pex.ParsingErrors.Select(x => x.ToString()));
            }
            catch(RuntimeException rex)
            {
                txtError.Text = rex.Message;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.turtle.Save(saveFileDialog1.FileName);
            }
        }
    }
}
