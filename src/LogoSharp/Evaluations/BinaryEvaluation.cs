using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.Evaluations
{
    internal sealed class BinaryEvaluation : Evaluation
    {
        private readonly Evaluation left;
        private readonly Evaluation right;

        private readonly BinaryOperation oper;

        public BinaryEvaluation(Evaluation left, Evaluation right, BinaryOperation oper)
        {
            this.left = left;
            this.right = right;
            this.oper = oper;
        }

        public override float Value
        {
            get
            {
                switch (oper)
                {
                    case BinaryOperation.Add:
                        return this.left.Value + this.right.Value;
                    case BinaryOperation.Sub:
                        return this.left.Value - this.right.Value;
                    case BinaryOperation.Mul:
                        return this.left.Value * this.right.Value;
                    case BinaryOperation.Div:
                        return this.left.Value / this.right.Value;
                    default:
                        break;
                }

                throw new InvalidOperationException("Invalid binary operation.");
            }
        }

        public override string ToString() => $"{this.left?.ToString()} {oper} {this.right?.ToString()}";
    }
}
