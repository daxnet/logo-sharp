using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.Evaluations.Functions
{
    [Function("SIN", 1)]
    internal sealed class MathSinFunction : FunctionEvaluation
    {
        public MathSinFunction(IEnumerable<float> parameterValues) : base(parameterValues)
        {
        }

        public override float Value => Convert.ToSingle(Math.Sin(parameterValues.First()));
    }
}
