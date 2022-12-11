using BallisticCalculatorNet.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static BallisticCalculatorNet.ExtensionsManager;

namespace BallisticCalculatorNet
{
    internal sealed class ExtensionsManager : IDisposable
    {
        public class ExtensionCommand
        {
            public string ID { get; init; }
            public string DisplayName { get; init; }
            public string ExecutablePath { get; init; }
        }

        private readonly List<ExtensionCommand> mCommands = new();

        public IReadOnlyList<ExtensionCommand> Commands => mCommands;

        public ExtensionsManager()
        {
            var path = new FileInfo(Assembly.GetExecutingAssembly().Location);
            var extensionDirectory = Path.Combine(path.DirectoryName, "extensions");

            if (!Directory.Exists(extensionDirectory))
                return;

            foreach (var dir in Directory.GetDirectories(extensionDirectory))
            {
                var configPath = Path.Combine(dir, "extension.json");
                if (File.Exists(configPath))
                {
                    try
                    {
                        var config = JsonSerializer.Deserialize<ExtensionConfig>(File.ReadAllText(configPath));
                        if (config == null)
                            throw new ArgumentNullException("Configuration isn't parsed");
                        var executablePath = Path.Combine(dir, config.ExecutableName);
                        if (!File.Exists(executablePath))
                            throw new FileNotFoundException($"File {executablePath} is not found");
                        foreach (var command in config.Commands)
                        {
                            mCommands.Add(new ExtensionCommand
                            {
                                ID = command.ID,
                                DisplayName = command.DisplayName,
                                ExecutablePath = executablePath
                            });
                        }
                    }
                    catch (Exception e)
                    {
                        Program.Logger?.Error(e, "Can't load extension specification {0}", configPath);
                    }
                }
            }
        }

        public void Dispose()
        {
            //nothing to dispose in this implementation
        }
    }
}
