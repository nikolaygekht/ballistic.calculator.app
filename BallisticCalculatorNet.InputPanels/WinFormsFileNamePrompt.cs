using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallisticCalculatorNet.InputPanels
{
    class WinFormsFileNamePrompt : IFileNamePrompt
    {
        public bool SavePrompt { get; set; }
        public bool CheckFileExists { get; set; }
        public bool CheckDirectoryExist { get; set; }
        public bool OverwritePrompt { get; set; }
        public string Title { get; set; }
        public string InitialDirectory { get; set; }
        public string FileName { get; set; }
        public string DefaultExtension { get; set; }

        readonly List<Tuple<string, string>> mFilters = new List<Tuple<string, string>>();

        public void AddFilter(string extension, string name) => mFilters.Add(new Tuple<string, string>(extension, name));

        private void Init(FileDialog fileDialog)
        {
            fileDialog.Title = Title;
            fileDialog.InitialDirectory = InitialDirectory;
            fileDialog.DefaultExt = DefaultExtension;
            fileDialog.FileName = FileName;

            StringBuilder filters = new StringBuilder();
            foreach (var filter in mFilters)
                filters.Append(filter.Item2).Append('|').Append("*.").Append(filter.Item1).Append('|');
            filters.Append("All files|*.*");

            fileDialog.Filter = filters.ToString();
        }

        public bool AskName(IWin32Window parent)
        {
            FileDialog dlg;
            if (SavePrompt)
            {
                dlg = new SaveFileDialog()
                {
                    OverwritePrompt = OverwritePrompt,
                    CheckPathExists = CheckDirectoryExist,
                };
            }
            else
            {
                dlg = new OpenFileDialog()
                {
                    CheckFileExists = CheckFileExists
                };
            }

            Init(dlg);

            bool rc = dlg.ShowDialog(parent) == DialogResult.OK;
            if (rc)
                FileName = dlg.FileName;
            return rc;
        }
    }
}
