using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.EventArguments
{
    public sealed class PenColorEventArgs : EventArgs
    {
        public PenColorEventArgs(int r, int g, int b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }

        public int R { get; set; }

        public int G { get; set; }

        public int B { get; set; }
    }
}
