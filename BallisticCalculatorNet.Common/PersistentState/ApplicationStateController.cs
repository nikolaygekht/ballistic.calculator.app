using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace BallisticCalculatorNet.Common.PersistentState
{
    public sealed class ApplicationStateController<T>
        where T : ApplicationState, new()
    {
        private readonly string mJsonFile;

        public T State { get; private set; }

        public ApplicationStateController(string applicationPath, string applicationName)
        {
            mJsonFile = Path.Combine(applicationPath, $"{applicationName}.state.json");
            if (File.Exists(mJsonFile))
            {
                try
                {
                    string json = File.ReadAllText(mJsonFile, Encoding.UTF8);
                    State = JsonSerializer.Deserialize<T>(json);
                    if (State == null)
                        State = new T();
                    State.AfterLoad();
                }
                catch (Exception)
                {
                    State = new T();
                    throw;
                }
            }
            else
                State = new T();
        }

        public void Save()
        {
            State.BeforeSave();
            string json = JsonSerializer.Serialize<T>(State);
            File.WriteAllText(mJsonFile, json, Encoding.UTF8);
        }
    }
}
