using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.Evaluations.Functions
{
    [Function("ABS")]
    internal sealed class MathAbsFunction : FunctionEvaluation
    {
        public MathAbsFunction(IEnumerable<float> parameterValues) : base(parameterValues)
        {
        }

        public override float Value => Math.Abs(this.parameterValues.First());

        public override bool ValidateParameters()
        {
            return this.parameterValues.Count() == 1;
        }
    }
}
