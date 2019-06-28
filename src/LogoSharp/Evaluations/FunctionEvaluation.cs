using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.Evaluations
{
    internal abstract class FunctionEvaluation : Evaluation
    {
        protected readonly IEnumerable<float> parameterValues;

        protected FunctionEvaluation(IEnumerable<float> parameterValues)
        {
            this.parameterValues = parameterValues;
        }
    }
}
