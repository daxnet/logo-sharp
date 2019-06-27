using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.Scopes
{
    internal sealed class RepeatScope : Scope
    {
        public RepeatScope(string name) : base(name)
        {
        }

        public int RepCount { get; set; }
    }
}
