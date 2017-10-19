using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.Evaluations.Functions
{
    [Function("PI")]
    internal sealed class MathPiFunction : FunctionEvaluation
    {
        public MathPiFunction(IEnumerable<float> parameterValues) : base(parameterValues)
        {
        }

        public override float Value => Convert.ToSingle(Math.PI);

        public override bool ValidateParameters() => this.parameterValues.Count() == 0;
    }
}
