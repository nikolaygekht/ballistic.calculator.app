using BallisticCalculator;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace BallisticCalculatorNet.Common
{
    public static class ConfigurationStateSaver
    {
        private static void CopyConfigToJsonObject(JsonObject target, IConfigurationSection section)
        {
            foreach (var child in section.GetChildren())
            {
                var key = child.Key;
                if (child.Value != null)
                    target.Add(key, child.Value);
                else
                {
                    var sectionObject = new JsonObject();
                    CopyConfigToJsonObject(sectionObject, child);
                    target.Add(key, sectionObject);
                }
            }
        }

        public static void SaveStateToFile(this IConfiguration configuration, string configurationFileName, string stateSection)
        {
            var stateObject = new JsonObject();
            
            var key = configuration.GetSection(stateSection);
            CopyConfigToJsonObject(stateObject, key);

            JsonObject configFile;

            try
            {
                if (File.Exists(configurationFileName))
                {
                    var source = File.ReadAllText(configurationFileName);
                    configFile = JsonSerializer.Deserialize<JsonObject>(source);
                    if (configFile.TryGetPropertyValue(stateSection, out _))
                        configFile.Remove(stateSection);
                }
                else
                    configFile = new JsonObject();
            }
            catch
            {
                configFile = new JsonObject();
            }

            configFile.Add(stateSection, stateObject);
            var json = JsonSerializer.Serialize(configFile);
            File.WriteAllText(configurationFileName, json);
        }

        public static void LoadFormState(this Form form, IConfiguration configuration, string name, bool sizeOnly)
        {
            string _left, _top, _width, _height, _state;

            _left = configuration[$"state:{name}:left"];
            _top = configuration[$"state:{name}:top"];
            _width = configuration[$"state:{name}:width"];
            _height = configuration[$"state:{name}:height"];
            _state = configuration[$"state:{name}:state"];


            if (!int.TryParse(_left, out int left) ||
                !int.TryParse(_top, out int top) ||
                !int.TryParse(_width, out int width) ||
                !int.TryParse(_height, out int height) ||
                !Enum.TryParse<FormWindowState>(_state, out FormWindowState state))
                return;

            if (!sizeOnly)
                form.Location = new Point(left, top);

            form.Size = new Size(width, height);

            if (form.WindowState != state)
                form.WindowState = state;
        }

        public static void SaveFormState(this Form form, IConfiguration configuration, string name)
        {
            configuration[$"state:{name}:left"] = form.Location.X.ToString();
            configuration[$"state:{name}:top"] = form.Location.Y.ToString();
            configuration[$"state:{name}:width"] = form.Size.Width.ToString();
            configuration[$"state:{name}:height"] = form.Size.Height.ToString();
            configuration[$"state:{name}:state"] = form.WindowState.ToString();
        }
    }
}
