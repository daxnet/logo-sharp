using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.EventArguments
{
    public sealed class ForwardEventArgs : EventArgs
    {
        public ForwardEventArgs(float steps)
        {
            this.Steps = steps;
        }

        public float Steps { get; }
    }
}
