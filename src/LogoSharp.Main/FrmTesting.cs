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
        private float angle = 30F;

        public FrmTesting()
        {
            InitializeComponent();
            this.turtle = new Turtle(this.pnlMain);
            this.turtle.Reset();
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
    }
}
