// ==============================================================================
//  _      ____   _____  ____     _____ _    _          _____  _____
// | |    / __ \ / ____|/ __ \   / ____| |  | |   /\   |  __ \|  __ \
// | |   | |  | | |  __| |  | | | (___ | |__| |  /  \  | |__) | |__) |
// | |   | |  | | | |_ | |  | |  \___ \|  __  | / /\ \ |  _  /|  ___/
// | |___| |__| | |__| | |__| |  ____) | |  | |/ ____ \| | \ \| |
// |______\____/ \_____|\____/  |_____/|_|  |_/_/    \_\_|  \_\_|
//
// Logo Sharp, Logo programming language for managed world.
// Licensed under MIT license.
// By daxnet, https://github.com/daxnet/logo-sharp
// https://sunnycoding.cn
// ==============================================================================

using Irony.Parsing;
using System.Collections.Generic;

namespace LogoSharp
{
    /// <summary>
    /// Represents a procedure in the Logo programming language.
    /// </summary>
    internal sealed class Procedure : IProcedureOrFunction
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

        public IEnumerable<string> Arguments { get; }
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