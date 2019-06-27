using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.Scopes
{
    internal sealed class ProcedureScope : Scope
    {
        private readonly Dictionary<string, object> variables = new Dictionary<string, object>();

        public ProcedureScope(string name) : base(name)
        {
        }

        public bool Exists(string variableName) => variables.Any(v => string.Equals(v.Key, variableName, StringComparison.InvariantCultureIgnoreCase));

        public object this[string variableName]
        {
            get => Exists(variableName) ? variables[variableName] : null;
            set
            {
                if (!Exists(variableName))
                {
                    variables.Add(variableName, value);
                }
                else
                {
                    var existingKey = variables
                        .First(kvp => string.Equals(kvp.Key, variableName, StringComparison.InvariantCultureIgnoreCase))
                        .Key;
                    variables[existingKey] = value;
                }
            }
        }
    }
}
