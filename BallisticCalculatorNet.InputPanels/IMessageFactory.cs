using System.Windows.Forms;

namespace BallisticCalculatorNet.InputPanels
{
    public interface IMessageFactory
    {
        DialogResult ShowMessage(IWin32Window parent, string text, string title);
        DialogResult ShowMessage(IWin32Window parent, string text, string title, MessageBoxButtons buttons);
        DialogResult ShowMessage(IWin32Window parent, string text, string title, MessageBoxButtons buttons, MessageBoxIcon icon);
    }
}


