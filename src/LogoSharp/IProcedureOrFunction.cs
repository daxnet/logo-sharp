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

using System.Collections.Generic;

namespace LogoSharp
{
    /// <summary>
    /// Represents that the implemented classes are procedures or functions
    /// that take specific arguments and execute commands when they are called.
    /// </summary>
    internal interface IProcedureOrFunction
    {

        #region Public Properties

        /// <summary>
        /// Gets a list of arguments.
        /// </summary>
        IEnumerable<string> Arguments { get; }

        /// <summary>
        /// Gets the name of the procedure or function.
        /// </summary>
        string Name { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Invokes the procedure or function and returns results.
        /// </summary>
        /// <param name="logo">The <see cref="Logo"/> instance which provides execution contexts.</param>
        /// <param name="result">The execution result.</param>
        void Invoke(Logo logo, out object result);

        #endregion Public Methods

    }
}