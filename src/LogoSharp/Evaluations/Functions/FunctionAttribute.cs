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
        public FunctionAttribute(string name, int numberOfParameters, string parameterNames = "")
        {
            this.Name = name;
            this.NumberOfParameters = numberOfParameters;
            this.ParameterNames = parameterNames;
        }

        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the number of parameters used by the function.
        /// </summary>
        public int NumberOfParameters { get; }

        /// <summary>
        /// Gets the name of the function parameters, separated by comma.
        /// E.g., firstName,lastName.
        /// </summary>
        public string ParameterNames { get; }
    }
}
