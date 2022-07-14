namespace BallisticCalculatorNet.InputPanels
{
    public class WinFormsFileNamePromptFactory : IFileNamePromptFactory
    {
        public IFileNamePrompt CreateFileNamePrompt(bool savePrompt)
        {
            return new WinFormsFileNamePrompt() { SavePrompt = savePrompt };
        }
    }
}
