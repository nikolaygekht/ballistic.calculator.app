using System.Windows.Forms;

namespace BallisticCalculatorNet.InputPanels
{
    public interface IFileNamePrompt
    {
        bool SavePrompt { get; set; } 
        bool CheckFileExists { get; set; }
        bool CheckDirectlyExists { get; set; }
        bool OverwritePrompt { get; set; }
        string Title { get; set; }
        string InitialDirectory { get; set; }
        string FileName { get; set; }
        string DefaultExtension { get; set; }
        bool AskName(IWin32Window parent);
        void AddFilter(string extension, string name);
    }
}
