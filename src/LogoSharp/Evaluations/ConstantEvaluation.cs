using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.Evaluations
{
    internal sealed class ConstantEvaluation : Evaluation
    {
        private readonly float value;

        public ConstantEvaluation(float value)
        {
            this.value = value;
        }

        public override float Value => this.value;
    }
}
