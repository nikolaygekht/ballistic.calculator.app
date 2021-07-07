namespace BallisticCalculatorNet.InputPanels
{
    public class WinFormsFileNamePromptFactory : IFileNamePromptyFactory
    {
        public IFileNamePrompt CreateFileNamePrompt(bool savePrompt)
        {
            return new WinFormsFileNamePrompt() { SavePrompt = savePrompt };
        }
    }
}
