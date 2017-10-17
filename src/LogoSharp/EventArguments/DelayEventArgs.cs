using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.EventArguments
{
    public sealed class DelayEventArgs : EventArgs
    {
        public DelayEventArgs(int milliseconds)
        {
            this.Milliseconds = milliseconds;
        }
        public int Milliseconds { get; }
    }
}
