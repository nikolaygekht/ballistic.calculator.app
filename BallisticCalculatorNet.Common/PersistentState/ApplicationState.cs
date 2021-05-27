using System;
using System.Reflection;
using System.Text.Json.Serialization;

namespace BallisticCalculatorNet.Common.PersistentState
{

    public class ApplicationState
    {
        [JsonPropertyName("main-window-state")]
        [JsonInclude]
        [JsonAssignDefaultIfNull]
        public WindowState MainWindowState { get; init; }

        internal protected virtual void AfterLoad()
        {
            var props = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            foreach (var prop in props)
            {
                if (prop.GetCustomAttribute<JsonAssignDefaultIfNullAttribute>() != null &&
                    prop.GetValue(this) == null)
                {
                    prop.SetValue(this, Activator.CreateInstance(prop.PropertyType));
                }
            }
            
            var fields = this.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            foreach (var field in fields)
            {
                if (field.GetCustomAttribute<JsonAssignDefaultIfNullAttribute>() != null &&
                    field.GetValue(this) == null)
                {
                    field.SetValue(this, Activator.CreateInstance(field.FieldType));
                }
            }
        }

        internal protected virtual void BeforeSave()
        {
            //reserved for custom functionality in derived class
        }
    }
}
