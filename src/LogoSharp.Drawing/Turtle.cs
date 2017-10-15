using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogoSharp.Drawing
{
    public sealed class Turtle : IDisposable
    {
        private readonly Panel control;
        private readonly PictureBox turtlePicture = new PictureBox();
        private readonly Image turtleImage;
        private readonly Image drawingImage;
        private readonly Graphics drawingGraphics;
        private float angle = 90F;

        ~Turtle()
        {
            this.Dispose(false);
        }

        public Turtle(Panel panel)
            : this(panel, Properties.Resources.tortoise32)
        { }

        public Turtle(Panel control, Image turtleImage)
        {
            this.control = control;
            this.control.Paint += (s, e) =>
            {
                if (this.control != null)
                {
                    e.Graphics.DrawImage(this.drawingImage, 0, 0);
                }
            };

            this.turtleImage = turtleImage;

            SetDoubleBuffered(this.control);

            turtlePicture.BorderStyle = BorderStyle.None;
            turtlePicture.Image = turtleImage;
            turtlePicture.BackColor = Color.Transparent;
            this.control.Controls.Add(turtlePicture);
        
            this.drawingImage = new Bitmap(this.control.ClientSize.Width, this.control.ClientSize.Height);
            this.drawingGraphics = Graphics.FromImage(this.drawingImage);
            this.drawingGraphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        public float Angle
        {
            get { return this.angle; }
            set
            {
                this.angle = value % 360;
                if (this.angle < 0)
                {
                    angle += 360;
                }
            }
        }

        public void ShowTurtle() => this.ShowHideTurtle(true);

        public void HideTurtle() => this.ShowHideTurtle(false);

        public Point Position
        {
            get
            {
                var centerPoint = new Point(this.turtlePicture.Left + this.turtlePicture.Width / 2, this.turtlePicture.Top + this.turtlePicture.Height / 2);
                return ControlPositionToWorld(this.control, centerPoint);
            }
            set
            {
                var centerInControl = WorldPositionToControl(this.control, value);

                var left = centerInControl.X - this.turtlePicture.Width / 2;
                var top = centerInControl.Y - this.turtlePicture.Height / 2;

                this.turtlePicture.Left = left;
                this.turtlePicture.Top = top;
            }
        }

        public void Reset()
        {
            this.Angle = 90F;
            this.Rotate();
            this.Position = new Point(0, 0);
        }

        public void Right(float degree)
        {
            this.Angle -= degree;
            this.Rotate();
        }

        public void Left(float degree)
        {
            this.Angle += degree;
            this.Rotate();
        }

        public void MoveForward(int steps)
        {
            var fromX = this.Position.X;
            var fromY = this.Position.Y;

            var toX = (int)(this.Position.X + steps * Math.Cos(this.Angle * Math.PI / 180));
            var toY = (int)(this.Position.Y + steps * Math.Sin(this.Angle * Math.PI / 180));

            this.drawingGraphics.DrawLine(Pens.Black, WorldPositionToControl(this.control, new Point(fromX, fromY)),
                WorldPositionToControl(this.control, new Point(toX, toY)));

            this.Position = new Point(toX, toY);
        }

        public void MoveBackward(int steps) => this.MoveForward(-steps);

        public override string ToString()
        {
            return $"Position: {this.Position}, Angle: {this.Angle}";
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public PenStatus PenStatus { get; set; } = PenStatus.Down;

        public Color PenColor { get; set; } = Color.Black;

        private void Rotate()
        {
            this.turtlePicture.Image = RotateImage(this.turtleImage, this.angle);
            this.turtlePicture.Width = this.turtlePicture.Image.Width;
            this.turtlePicture.Height = this.turtlePicture.Image.Height;
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.drawingGraphics != null)
                {
                    this.drawingGraphics.Dispose();
                }

                if (this.drawingImage != null)
                {
                    this.drawingImage.Dispose();
                }
            }
        }

        private void ShowHideTurtle(bool show)
        {
            this.turtlePicture.Visible = show;
        }

        private static Point WorldPositionToControl(Control control, Point original)
        {
            var w = control.ClientSize.Width;
            var h = control.ClientSize.Height;

            var translatedX = original.X > w ? original.X % w : original.X;
            var translatedY = original.Y > h ? original.Y % h : original.Y;

            return new Point(w / 2 + translatedX, h / 2 - translatedY);
        }

        private static Point ControlPositionToWorld(Control control, Point original)
        {
            return new Point(original.X - control.ClientSize.Width / 2,
                control.ClientSize.Height / 2 - original.Y);
        }

        private static Bitmap RotateImage(Image bmp, float angleDegrees)
        {
            var rotatedImage = new Bitmap(bmp.Width, bmp.Height);
            using (var g = Graphics.FromImage(rotatedImage))
            {
                // Set the rotation point as the center into the matrix
                g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);

                // Rotate
                g.RotateTransform(90 - angleDegrees);

                // Restore the rotation point into the matrix
                g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);

                // Draw the image on the new bitmap
                g.DrawImage(bmp, new Point(0, 0));
            }

            return rotatedImage;
        }

        private static void SetDoubleBuffered(Control control)
        {
            // set instance non-public property with name "DoubleBuffered" to true
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        
    }
}
