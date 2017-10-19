using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.Evaluations.Functions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    internal sealed class FunctionAttribute : Attribute
    {
        public FunctionAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
