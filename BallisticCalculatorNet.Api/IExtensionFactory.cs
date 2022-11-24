using System;

namespace BallisticCalculatorNet.Api
{
    /// <summary>
    /// The factory of extensions in the module.
    /// 
    /// Each module should have one class implementing this interface. 
    /// 
    /// The modules must be located in the subfolder of ballistic calculator application <code>extensions/extensionName/extensionName.dll</code>
    /// </summary>
    public interface IExtensionFactory : IDisposable
    {
        /// <summary>
        /// Returns all commands implemented by the extension
        /// </summary>
        /// <returns></returns>
        IExtensionCommandMetadata[] GetCommands();
    }
}
