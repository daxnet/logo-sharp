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

using System;
using System.Collections.Generic;
using System.Linq;

namespace LogoSharp.Scopes
{
    /// <summary>
    /// Represents the scope for procedure invocation.
    /// </summary>
    internal sealed class ProcedureScope : Scope
    {
        #region Private Fields

        private readonly Dictionary<string, object> variables = new Dictionary<string, object>();

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <c>ProcedureScope</c> class.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        public ProcedureScope(string name) : base(name) { }

        #endregion Public Constructors

        #region Public Indexers

        /// <summary>
        /// Gets or sets the variable value by variable name.
        /// </summary>
        /// <param name="variableName">The name of the variable.</param>
        /// <returns>The variable value.</returns>
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

        #endregion Public Indexers

        #region Public Methods

        /// <summary>
        /// Gets a <see cref="bool"/> value which indicates whether the variable exists in the scope.
        /// </summary>
        /// <param name="variableName">The name of the variable to check.</param>
        /// <returns><c>true</c> if exists, otherwise, false.</returns>
        public bool Exists(string variableName) => variables.Any(v => string.Equals(v.Key, variableName, StringComparison.InvariantCultureIgnoreCase));

        #endregion Public Methods
    }
}