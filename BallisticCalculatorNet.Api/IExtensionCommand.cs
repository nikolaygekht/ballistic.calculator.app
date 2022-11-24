using System;

namespace BallisticCalculatorNet.Api
{
    /// <summary>
    /// The implementation of the command action.
    /// </summary>
    public interface IExtensionCommand : IDisposable
    {
        /// <summary>
        /// Executes the extension
        /// </summary>
        /// <param name="host"></param>
        void Execute(IExtensionHost host);
    }
}
