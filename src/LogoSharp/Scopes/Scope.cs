using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.Scopes
{
    internal abstract class Scope
    {
        public Scope(string name) => Name = name;

        public string Name { get; }

        public override string ToString() => Name;
    }
}
