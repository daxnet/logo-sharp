using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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
        private Color penColor = Color.Black;
        private float penWidth = 1.0F;

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
            this.control.Paint += this.OnControlPaint;

            this.turtleImage = turtleImage;

            SetDoubleBuffered(this.control);

            turtlePicture.BorderStyle = BorderStyle.None;
            turtlePicture.Image = turtleImage;
            turtlePicture.BackColor = Color.Transparent;
            this.control.Controls.Add(turtlePicture);
        
            this.drawingImage = new Bitmap(this.control.ClientSize.Width, this.control.ClientSize.Height);
            this.drawingGraphics = Graphics.FromImage(this.drawingImage);
            this.drawingGraphics.Clear(Color.White);
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

        public PointF Position
        {
            get
            {
                var centerPoint = new PointF(this.turtlePicture.Left + this.turtlePicture.Width / 2.0F, 
                    this.turtlePicture.Top + this.turtlePicture.Height / 2.0F);

                return ControlPositionToWorld(this.control, centerPoint);
            }
            set
            {
                var centerInControl = WorldPositionToControl(this.control, value);

                var left = centerInControl.X - this.turtlePicture.Width / 2.0F;
                var top = centerInControl.Y - this.turtlePicture.Height / 2.0F;

                this.turtlePicture.Left = Convert.ToInt32(left);
                this.turtlePicture.Top = Convert.ToInt32(top);
            }
        }

        public void Reset()
        {
            this.Angle = 90F;
            this.Rotate();
            this.Position = new Point(0, 0);
        }

        public void Clear()
        {
            this.drawingGraphics.Clear(Color.White);
            this.Reset();
            this.control.Invalidate();
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

        public void MoveForward(float steps)
        {
            var fromX = this.Position.X;
            var fromY = this.Position.Y;

            var toX = Convert.ToSingle(this.Position.X + steps * Math.Cos(this.Angle * Math.PI / 180));
            var toY = Convert.ToSingle(this.Position.Y + steps * Math.Sin(this.Angle * Math.PI / 180));

            if (this.PenStatus == PenStatus.Down)
            {
                this.DrawLine(this.Position, new PointF(toX, toY));
            }

            this.Position = new PointF(toX, toY);
        }

        public void MoveBackward(float steps) => this.MoveForward(-steps);

        public void SetPenColor(Color color) => this.penColor = color;

        public void SetPenColor(int r, int g, int b) => this.penColor = Color.FromArgb(r, g, b);

        public void SetPenWidth(float width) => this.penWidth = width;

        public override string ToString()
        {
            return $"Position: {this.Position}, Angle: {this.Angle}, PenStatus: {this.PenStatus}";
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public PenStatus PenStatus { get; set; } = PenStatus.Down;

        public Color PenColor => this.penColor;

        public float PenWidth => this.penWidth;

        private void Rotate()
        {
            this.turtlePicture.Image = RotateImage(this.turtleImage, this.angle);
            this.turtlePicture.Width = this.turtlePicture.Image.Width;
            this.turtlePicture.Height = this.turtlePicture.Image.Height;
        }

        private void DrawLine(PointF from, PointF to)
        {
            using (var pen = new Pen(this.penColor, this.penWidth) { StartCap = LineCap.Round, EndCap = LineCap.Round })
            {
                var fromPoint = WorldPositionToControl(this.control, from);
                var toPoint = WorldPositionToControl(this.control, to);

                this.drawingGraphics.DrawLine(pen, fromPoint, toPoint);

                this.control.Invalidate();
            }
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.control.Paint -= this.OnControlPaint;

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

        private void OnControlPaint(object sender, PaintEventArgs e)
        {
            if (this.control != null)
            {
                e.Graphics.DrawImage(this.drawingImage, 0, 0);
            }
        }

        private static PointF WorldPositionToControl(Control control, PointF original)
        {
            var w = control.ClientSize.Width;
            var h = control.ClientSize.Height;

            //var translatedX = original.X > w ? original.X % w : original.X;
            //var translatedY = original.Y > h ? original.Y % h : original.Y;

            return new PointF(w / 2.0F + original.X, h / 2.0F - original.Y);
        }

        private static PointF ControlPositionToWorld(Control control, PointF original)
        {
            return new PointF(original.X - control.ClientSize.Width / 2.0F,
                control.ClientSize.Height / 2.0F - original.Y);
        }

        private static Bitmap RotateImage(Image bmp, float angleDegrees)
        {
            var rotatedImage = new Bitmap(bmp.Width, bmp.Height);
            using (var g = Graphics.FromImage(rotatedImage))
            {
                // Set the rotation point as the center into the matrix
                g.TranslateTransform(bmp.Width / 2.0F, bmp.Height / 2.0F);

                // Rotate
                g.RotateTransform(90 - angleDegrees);

                // Restore the rotation point into the matrix
                g.TranslateTransform(-bmp.Width / 2.0F, -bmp.Height / 2.0F);

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
