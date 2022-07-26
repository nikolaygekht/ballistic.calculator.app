using System.Windows.Forms;

namespace BallisticCalculatorNet.InputPanels
{
    internal class WindowsMessageFactory : IMessageFactory
    {
        public DialogResult ShowMessage(IWin32Window parent, string text, string title) 
            => ShowMessage(parent, text, title, MessageBoxButtons.OK);
        
        public DialogResult ShowMessage(IWin32Window parent, string text, string title, MessageBoxButtons buttons)
            => ShowMessage(parent, text, title, buttons, MessageBoxIcon.None);
        
        public DialogResult ShowMessage(IWin32Window parent, string text, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
            => MessageBox.Show(parent, text, title, buttons, icon);
    }
}


