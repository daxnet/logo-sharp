using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.Evaluations.Functions
{
    [Function("RANDOM")]
    internal sealed class RandomFunction : FunctionEvaluation
    {
        private static readonly Random rnd = new Random(DateTime.UtcNow.Millisecond);

        public RandomFunction(IEnumerable<float> parameterValues) : base(parameterValues)
        {
        }

        public override float Value
        {
            get
            {
                var maximum = Convert.ToInt32(this.parameterValues.First());
                return rnd.Next(maximum);
            }
        }

        public override bool ValidateParameters() => parameterValues.Count() == 1 && parameterValues.First() > 0;
    }
}
