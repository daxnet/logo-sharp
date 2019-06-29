using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp
{
    /// <summary>
    /// Represents a procedure in the Logo programming language.
    /// </summary>
    internal sealed class Procedure : IProcedure
    {

        #region Public Constructors

        public Procedure(string name, IEnumerable<string> arguments, ParseTreeNode body)
        {
            this.Name = name;
            this.Body = body;
            this.Arguments = new List<string>(arguments);
        }

        #endregion Public Constructors

        #region Public Properties

        public List<string> Arguments { get; }
        public string Name { get; }

        #endregion Public Properties

        #region Private Properties

        private ParseTreeNode Body { get; }

        #endregion Private Properties

        #region Public Methods

        public override bool Equals(object obj)
        {
            return obj is Procedure procedure &&
                   Name == procedure.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        public void Invoke(Logo logo, out object result)
        {
            logo.ParseTree(this.Body);
            result = null;
        }

        public override string ToString() => Name;

        #endregion Public Methods

    }
}
