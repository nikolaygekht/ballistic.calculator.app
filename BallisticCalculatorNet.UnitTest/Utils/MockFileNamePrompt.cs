using BallisticCalculatorNet.InputPanels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallisticCalculatorNet.UnitTest.Utils
{
    internal class MockFileNamePrompt : IFileNamePrompt
    {
        public bool SavePrompt { get ; set ; }
        public bool CheckFileExists { get ; set ; }
        public bool CheckDirectoryExist { get ; set ; }
        public bool OverwritePrompt { get ; set ; }
        public string Title { get ; set ; }
        public string InitialDirectory { get ; set ; }
        public string FileName { get ; set ; }
        public string DefaultExtension { get ; set ; }

        public List<Tuple<string, string>> Filters { get; } = new List<Tuple<string, string>>();

        public void AddFilter(string extension, string name)
            => Filters.Add(new Tuple<string, string>(extension, name));

        public bool AskName(IWin32Window parent) => true;
    }
}
