using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace LogoSharp.Main
{
    public partial class LayeredControl : UserControl
    {
        private Image image;
        private Graphics graphics;

        public LayeredControl()
        {
            InitializeComponent();
            image = new Bitmap(this.Width, this.Height);
            graphics = Graphics.FromImage(image);

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var bitMap = new Bitmap(image);
            // by default the background color for bitmap is white
            // you can modify this to follow your image background 
            // or create a new Property so it can dynamically assigned
            bitMap.MakeTransparent(Color.White);

            image = bitMap;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.GammaCorrected;

            float[][] mtxItens = {
            new float[] {1,0,0,0,0},
            new float[] {0,1,0,0,0},
            new float[] {0,0,1,0,0},
            new float[] {0,0,0,1,0},
            new float[] {0,0,0,0,1}};

            ColorMatrix colorMatrix = new ColorMatrix(mtxItens);

            ImageAttributes imgAtb = new ImageAttributes();
            imgAtb.SetColorMatrix(
                colorMatrix,
                ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);

            g.DrawImage(image,
                        ClientRectangle,
                        0.0f,
                        0.0f,
                        image.Width,
                        image.Height,
                        GraphicsUnit.Pixel,
                        imgAtb);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Graphics g = e.Graphics;

            if (Parent != null)
            {
                BackColor = Color.Transparent;
                int index = Parent.Controls.GetChildIndex(this);

                for (int i = Parent.Controls.Count - 1; i > index; i--)
                {
                    Control c = Parent.Controls[i];
                    if (c.Bounds.IntersectsWith(Bounds) && c.Visible)
                    {
                        Bitmap bmp = new Bitmap(c.Width, c.Height, g);
                        c.DrawToBitmap(bmp, c.ClientRectangle);

                        g.TranslateTransform(c.Left - Left, c.Top - Top);
                        g.DrawImageUnscaled(bmp, Point.Empty);
                        g.TranslateTransform(Left - c.Left, Top - c.Top);
                        bmp.Dispose();
                    }
                }
            }
            else
            {
                g.Clear(Parent.BackColor);
                g.FillRectangle(new SolidBrush(Color.FromArgb(255, Color.Transparent)), this.ClientRectangle);
            }
        }

        // simple drawing circle function
        public void DrawCircles()
        {
            using (Brush b = new SolidBrush(Color.Red))
            {
                using (Pen p = new Pen(Color.Green, 3))
                {
                    this.graphics.DrawEllipse(p, 25, 25, 20, 20);
                }
            }
        }

        // simple drawing rectable function
        public void DrawRectangle()
        {
            using (Brush b = new SolidBrush(Color.Red))
            {
                using (Pen p = new Pen(Color.Red, 3))
                {
                    this.graphics.DrawRectangle(p, 30, 30, 40, 40);
                }
            }
        }

        // Layer control image property
        public Image Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                // this will make the control to be redrawn
                this.Invalidate();
            }
        }
    }
}
