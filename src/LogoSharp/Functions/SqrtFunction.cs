using LogoSharp.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.Functions
{
    internal sealed class SqrtFunction : Function
    {
        public override string Name => "SQRT";

        public override List<string> Arguments => new List<string> { "p" };

        protected override float Execute(ProcedureScope procedureScope) => Convert.ToSingle(Math.Sqrt(Convert.ToDouble(procedureScope["p"])));
    }
}
