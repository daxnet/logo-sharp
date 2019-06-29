using LogoSharp.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.Functions
{
    internal abstract class Function : IProcedure
    {

        public abstract string Name { get; }

        public abstract List<string> Arguments { get; }

        public void Invoke(Logo logo, out object result)
        {
            result = Execute(logo.CurrentProcedureScope);
        }

        protected abstract float Execute(ProcedureScope procedureScope);
    }
}
