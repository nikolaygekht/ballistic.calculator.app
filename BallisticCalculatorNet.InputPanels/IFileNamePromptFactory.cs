namespace BallisticCalculatorNet.InputPanels
{
    public interface IFileNamePromptFactory
    {
        IFileNamePrompt CreateFileNamePrompt(bool savePrompt);
        IFileNamePrompt CreateOpenFileNamePrompt() => CreateFileNamePrompt(false);
        IFileNamePrompt CreateSaveFileNamePrompt() => CreateFileNamePrompt(true);
    }
}
