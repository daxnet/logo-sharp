using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.Evaluations.Functions
{
    [Function("COS")]
    internal sealed class MathCosFunction : FunctionEvaluation
    {
        public MathCosFunction(IEnumerable<float> parameterValues) : base(parameterValues)
        {
        }

        public override float Value => Convert.ToSingle(Math.Cos(parameterValues.First()));

        public override bool ValidateParameters()
        {
            return this.parameterValues.Count() == 1;
        }
    }
}
