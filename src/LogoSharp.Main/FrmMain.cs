﻿using System;
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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            var l1 = new LayeredControl();
            l1.DrawCircles();

            var l2 = new LayeredControl();
            l2.DrawRectangle();

            this.panel1.Controls.Add(l1);
            this.panel1.Controls.Add(l2);
        }
    }
}
