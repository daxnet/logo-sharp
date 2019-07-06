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

namespace LogoSharp.Scopes
{
    /// <summary>
    /// Represents the scope of a procedure or function invocation.
    /// </summary>
    internal abstract class Scope
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <c>Scope</c> class.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        protected Scope(string name) => Name = name;

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        public string Name { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Gets the string representation of the scope.
        /// </summary>
        /// <returns>The string representation of the scope.</returns>
        public override string ToString() => Name;

        #endregion Public Methods
    }
}