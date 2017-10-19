using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.Evaluations.Functions
{
    internal static class FunctionRegistry
    {
        private static readonly Lazy<IEnumerable<KeyValuePair<string, Type>>> cachedFunctions = new Lazy<IEnumerable<KeyValuePair<string, Type>>>(() =>
        {
            var functionDefs = from type in typeof(FunctionRegistry).Assembly.GetTypes()
                               where type.IsSubclassOf(typeof(FunctionEvaluation)) &&
                               type.IsDefined(typeof(FunctionAttribute), false)
                               let t = type
                               let n = (type.GetCustomAttributes(typeof(FunctionAttribute), false).First() as FunctionAttribute).Name
                               select new { n, t };

            var ret = new Dictionary<string, Type>();
            foreach (var fd in functionDefs)
            {
                ret.Add(fd.n, fd.t);
            }

            return ret;
        });

        public static Evaluation Call(ParseTreeNode node, string functionName, IEnumerable<float> parameters)
        {
            var function = (from cf in cachedFunctions.Value
                            where cf.Key.Equals(functionName, StringComparison.InvariantCultureIgnoreCase)
                            select (FunctionEvaluation)Activator.CreateInstance(cf.Value, parameters.ToArray())).FirstOrDefault();

            if (function == null)
            {
                throw new ParsingException($"Function call '{functionName}' as unsuccessful.",
                    new[] {
                        ParsingError.FromParseTreeNode(node, $"Can't initiate the function '{functionName}', the function is either undefined or failed during activation.")
                    });
            }

            if (!function.ValidateParameters())
            {
                throw new ParsingException($"Function call '{functionName}' as unsuccessful.",
                    new[] {
                        ParsingError.FromParseTreeNode(node, "The given parameters don't match the function definition.")
                    });
            }

            return new ConstantEvaluation(function.Value);
        }
    }
}
