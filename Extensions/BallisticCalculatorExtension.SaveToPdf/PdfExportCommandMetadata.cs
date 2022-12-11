using BallisticCalculatorNet.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallisticCalculatorNet.SaveToPdf
{
    internal class PdfExportCommandMetadata : IExtensionCommandMetadata
    {
        public string Name => "PdfExport";

        public string DisplayName => "Save Trajectory To Pdf";

        public IExtensionCommand Create()
        {
            return new PdfExportCommand();
        }
    }
}
