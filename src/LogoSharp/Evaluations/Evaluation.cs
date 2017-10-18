using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.Evaluations
{
    internal abstract class Evaluation
    {
        public abstract float Value { get; }

        public override string ToString() => Value.ToString();
    }
}
