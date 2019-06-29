using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogoSharp.Scopes;

namespace LogoSharp.Functions
{
    internal sealed class RandomFunction : Function
    {
        private static readonly Random rnd = new Random(DateTime.Now.Millisecond);

        public override string Name => "RANDOM";

        public override List<string> Arguments => new List<string> { "p" };

        protected override float Execute(ProcedureScope procedureScope)
        {
            var iVal = Convert.ToInt32(procedureScope["p"]);
            return rnd.Next(iVal);
        }
    }
}
