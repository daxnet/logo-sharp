using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.EventArguments
{
    public sealed class TurnRightEventArgs : EventArgs
    {
        public TurnRightEventArgs(float angle)
        {
            this.Angle = angle;
        }

        public float Angle { get; }
    }
}
