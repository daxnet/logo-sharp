using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.EventArguments
{
    public sealed class TurnLeftEventArgs : EventArgs
    {
        public TurnLeftEventArgs(float angle)
        {
            this.Angle = angle;
        }

        public float Angle { get; }
    }
}
