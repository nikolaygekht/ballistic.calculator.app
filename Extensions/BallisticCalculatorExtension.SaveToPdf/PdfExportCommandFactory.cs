using BallisticCalculatorNet.Api;

namespace BallisticCalculatorNet.SaveToPdf
{
    public sealed class PdfExportCommandFactory : IExtensionFactory
    {
        public void Dispose()
        {
            //nothing to dispose
        }

        public IExtensionCommandMetadata[] GetCommands()
        {
            return new IExtensionCommandMetadata[] { new PdfExportCommandMetadata() };
        }
    }
}
