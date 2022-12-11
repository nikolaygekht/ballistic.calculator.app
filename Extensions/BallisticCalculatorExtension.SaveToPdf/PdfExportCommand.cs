using BallisticCalculatorNet.Api;
using Gehtsoft.PDFFlow.Builder;
using System.Windows.Forms;

namespace BallisticCalculatorNet.SaveToPdf
{
    internal sealed class PdfExportCommand : IExtensionCommand
    {
        public void Dispose()
        {
            //nothing to dispose
        }

        public void Execute(IExtensionHost host)
        {
            if (host.ActiveForm() is not IShotForm shotForm)
                return;

            var dlg = new SaveFileDialog
            {
                OverwritePrompt = true,
                Filter = "PDF Files|*.pdf|All Files|*.*",
                CheckPathExists = true,
                Title = "Save PDF"
            };

            if (dlg.ShowDialog(host.ActiveForm() as IWin32Window) != DialogResult.OK)
                return;

            var documentBuilder = DocumentBuilder.New();
            var sectionBuilder = documentBuilder.AddSection();
            var paragraph = sectionBuilder.AddParagraph();
            
            var title = shotForm.ShotData.Ammunition.Name;
            if (string.IsNullOrEmpty(title))
                title = "New Trajectory";
         
            paragraph
                .SetFontName("Arial")
                .SetBold()
                .SetFontSize(14)
                .AddText("Trajectory:")
                .ToParagraph().AddText(title);

            documentBuilder.Build(dlg.FileName);
        }
    }
}
