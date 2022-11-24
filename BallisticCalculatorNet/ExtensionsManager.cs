using BallisticCalculatorNet.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BallisticCalculatorNet
{
    internal sealed class ExtensionsManager : IDisposable
    {
        private readonly List<IExtensionFactory> mFactories = new();
        private readonly List<IExtensionCommandMetadata> mCommands = new();

        public IReadOnlyList<IExtensionCommandMetadata> Commands => mCommands;

        public ExtensionsManager()
        {
            var path = new FileInfo(Assembly.GetExecutingAssembly().Location);
            var dir = path.DirectoryName;
            var extensionsRoot = Path.Combine(dir, "extensions");
            if (Directory.Exists(extensionsRoot))
            {
                var extenionsDirectories = Directory.GetDirectories(extensionsRoot);
                foreach (var extensionDirectory in extenionsDirectories)
                {
                    var di = new DirectoryInfo(extensionDirectory);
                    var dllPath = Path.Combine(di.FullName, di.Name + ".dll");
                    try
                    {
                        if (File.Exists(dllPath))
                        {
                            var assembly = Assembly.Load(dllPath);
                            var types = assembly.GetTypes();
                            foreach (var type in types.Where(t => typeof(IExtensionFactory).IsAssignableFrom(t)))
                            {
                                var factory = (IExtensionFactory)Activator.CreateInstance(type);
                                mFactories.Add(factory);
                                var commands = factory.GetCommands();
                                mCommands.AddRange(commands);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Program.Logger.Error(e, "Can't load extension {extension}", dllPath);
                    }
                }
            }
        }

        public void Dispose()
        {
            for (int i = 0; i < mFactories.Count; i++)
                mFactories[i].Dispose();
        }
    }
}
