using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.Api.Interop;
using Gehtsoft.PDFFlow.Builder;
using Gehtsoft.PDFFlow.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallisticCalculatorExtension.SaveToPdf
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Program.Client.TrajectoryReceived += TrajectorReceived;
            buttonSave.Enabled = false;
            Program.Client.RequestTrajectory();
        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog()
            {
                Filter = "PDF Files|*.pdf|All Files|*.*",
                CheckPathExists = true,
                AddExtension = true,
                DefaultExt = "pdf",
                OverwritePrompt = true,
                Title = "Save Trajectory to PDF",
                RestoreDirectory = true,
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                textBoxFileName.Text = dlg.FileName;
                buttonSave.Enabled = CanEnableSave;
            }
        }

        private InteropGetTrajectoryResponse mResponse;

        private bool CanEnableSave => !string.IsNullOrEmpty(textBoxFileName.Text) && mResponse != null;

        private void TrajectorReceived(object sender, InteropGetTrajectoryEventArgs e)
        {
            mResponse = e.Response;
            buttonSave.Enabled = CanEnableSave;
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            var documentBuilder = DocumentBuilder.New();
            var sectionBuilder = documentBuilder.AddSection();
            var paragraph = sectionBuilder.AddParagraph();

            var title = mResponse.ShotData.Ammunition.Name;
            if (string.IsNullOrEmpty(title))
                title = "New Trajectory";

            paragraph
                .SetFont(Fonts.Helvetica(14))
                .AddText("Trajectory:")
                .ToParagraph().AddText(title);

            documentBuilder.Build(textBoxFileName.Text);

            var psi = new ProcessStartInfo(textBoxFileName.Text)
            {
                UseShellExecute = true
            };
            Process.Start(psi);
            this.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
