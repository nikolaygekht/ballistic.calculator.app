using BallisticCalculator.Serialization;
using System;
using System.IO;

namespace BallisticCalculatorNet.InputPanels.DataList
{
    public static class DataItemDictonaryFactory
    {
        private static DataItemDictionary gDictionary;
        private static DateTime gLastUpdate = new DateTime();

        private static string Name => Path.Combine(ControlConfiguration.Configuration["datafolder"], "dictionaries.xml");
        
        private static bool CheckUpdate()
        {
            var name = Name;
            var fi = new FileInfo(name);
            if (!fi.Exists)
                return false;
            if (fi.LastWriteTimeUtc > gLastUpdate)
                return true;
            return false;
        }
        
        private static void Load()
        {
            var name = Name;
            var fi = new FileInfo(name);
            if (!fi.Exists)
            {
                ControlConfiguration.Logger.Warning($"Dictionary file {name} does not exist");
                return;
            }
            gLastUpdate = fi.LastWriteTimeUtc;

            using var fs = new FileStream(name, FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                gDictionary = fs.BallisticXmlDeserialize<DataItemDictionary>();
                if (gDictionary == null)
                    ControlConfiguration.Logger.Error($"Dictionary file {name} reading failed (null returned)");
            }
            catch (Exception e)
            {
                ControlConfiguration.Logger.Error(e, $"Dictionary file {name} reading failed");
            }
        }

        public static DataItemDictionary Get()
        {
            if (gDictionary == null || CheckUpdate())
                Load();
            return gDictionary;
        }
    }
}
