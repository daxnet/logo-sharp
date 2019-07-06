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

using LogoSharp.Scopes;
using System.Collections.Generic;

namespace LogoSharp.Functions
{
    /// <summary>
    /// Represents that the implemented classes are functions.
    /// </summary>
    /// <remarks>
    /// In Logo Sharp, functions are the built-in constructs that bridge the method
    /// invocation between Logo Sharp and .NET. For example, by defining a SIN function,
    /// Logo Sharp will be able to use the SIN function which corresponds to the Math.Sin()
    /// method in .NET. Function invocation in Logo Sharp should be surrounded by braces, e.g.,
    /// {SQRT 2} for Math.Sqrt(2).
    /// </remarks>
    internal abstract class Function : IProcedureOrFunction
    {
        #region Public Properties

        /// <summary>
        /// Gets a list of arguments.
        /// </summary>
        public abstract IEnumerable<string> Arguments { get; }

        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public abstract string Name { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Invokes the function and returns results.
        /// </summary>
        /// <param name="logo">The <see cref="Logo"/> instance which provides execution contexts.</param>
        /// <param name="result">The execution result.</param>
        public void Invoke(Logo logo, out object result)
        {
            result = Execute(logo.CurrentProcedureScope);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Executes the function invocation.
        /// </summary>
        /// <param name="procedureScope">The <see cref="ProcedureScope"/> which provides the variables
        /// in the calling procedure.</param>
        /// <returns>The execution return value.</returns>
        protected abstract float Execute(ProcedureScope procedureScope);

        #endregion Protected Methods
    }
}