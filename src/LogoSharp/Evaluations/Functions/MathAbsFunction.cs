using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.Evaluations.Functions
{
    [Function("ABS", 1)]
    internal sealed class MathAbsFunction : FunctionEvaluation
    {
        public MathAbsFunction(IEnumerable<float> parameterValues) : base(parameterValues)
        {
        }

        public override float Value => Math.Abs(this.parameterValues.First());
    }
}
