using BallisticCalculator;
using BallisticCalculator.Serialization;
using System.Windows.Forms;

namespace BallisticCalculatorNet.InputPanels
{
    public static class AmmunitionControlUtils
    {
        public static AmmunitionLibraryEntry Load(IWin32Window parent, IFileNamePromptFactory factory, out string fileName)
        {
            fileName = null;
            var dlg = factory.CreateOpenFileNamePrompt();
            dlg.Title = "Open ammunition";
            dlg.AddFilter("ammo?", "Ammunition Library Entry (Any Version)");
            dlg.AddFilter("ammox", "Ammunition Library Entry");
            dlg.AddFilter("ammo", "Legacy Ammunition Library Entry");
            dlg.CheckFileExists = true;
            dlg.DefaultExtension = "ammox";
            if (dlg.AskName(parent))
            {
                fileName = dlg.FileName;
                if (dlg.FileName.EndsWith(".ammo"))
                    return BallisticXmlDeserializer.ReadLegacyAmmunitionLibraryEntryFromFile(dlg.FileName);
                else
                    return BallisticXmlDeserializer.ReadFromFile<AmmunitionLibraryEntry>(dlg.FileName);
            }
            return null;
        }
    }
}
