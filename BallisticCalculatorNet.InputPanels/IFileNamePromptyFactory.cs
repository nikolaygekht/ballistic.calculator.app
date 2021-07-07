namespace BallisticCalculatorNet.InputPanels
{
    public interface IFileNamePromptyFactory
    {
        IFileNamePrompt CreateFileNamePrompt(bool savePrompt);
        IFileNamePrompt CreateOpenFileNamePrompt() => CreateFileNamePrompt(false);
        IFileNamePrompt CreateSaveFileNamePrompt() => CreateFileNamePrompt(true);
    }
}
