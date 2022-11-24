namespace BallisticCalculatorNet.Api
{
    /// <summary>
    /// The interface to an extension.
    /// </summary>
    public interface IExtensionCommandMetadata 
    {
        /// <summary>
        /// The name of the extension.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The display name of the extension.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Creates the extension command action.
        /// </summary>
        /// <returns></returns>
        IExtensionCommand Create();
    }
}
