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
    internal sealed class Procedure
    {
        #region Public Constructors

        public Procedure(string name, ParseTreeNode body)
        {
            this.Name = name;
            this.Body = body;
        }

        #endregion Public Constructors

        #region Public Properties

        public ParseTreeNode Body { get; }
        public string Name { get; }

        #endregion Public Properties

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

        public override string ToString() => Name;

        #endregion Public Methods


    }
}
