using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp
{
    internal interface IProcedure
    {
        string Name { get; }

        List<string> Arguments { get; }

        void Invoke(Logo logo, out object result);
    }
}
