using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using FluentAssertions;

namespace Gehtsoft.Winforms.FluentAssertions
{
    public static class ControlAssertionExtension
    {
        public static ControlAssertions Should(this Control control) => new ControlAssertions(control);

        public static TextBoxAssertions Should(this TextBox control) => new TextBoxAssertions(control);

        public static ListBoxAssertions Should(this ListBox control) => new ListBoxAssertions(control);

        public static ComboBoxAssertions Should(this ComboBox control) => new ComboBoxAssertions(control);

        public static CheckBoxAssertions Should(this CheckBox control) => new CheckBoxAssertions(control);

        public static RadioButtonAssertions Should(this RadioButton control) => new RadioButtonAssertions(control);

        public static ListViewAssertions Should(this ListView control) => new ListViewAssertions(control);
        
        public static ListViewItemAssertions Should(this ListViewItem item) => new ListViewItemAssertions(item);

        public static Control Control(this Control parent, string name, Type type)
        {
            var control = parent.Controls.Find(name, true);
            if (control == null || control.Length == 0)
                return null;
            if (type.IsInstanceOfType(control[0]))
                return control[0];
            return null;
        }

        public static Control Control(this Control parent, string name) => Control(parent, name, typeof(Control));

        public static T Control<T>(this Control parent, string name) where T : Control
            => Control(parent, name, typeof(T)) as T;

        public static TextBox TextBox(this Control parent, string name) => Control<TextBox>(parent, name);

        public static ListBox ListBox(this Control parent, string name) => Control<ListBox>(parent, name);

        public static ComboBox ComboBox(this Control parent, string name) => Control<ComboBox>(parent, name);

        public static CheckBox CheckBox(this Control parent, string name) => Control<CheckBox>(parent, name);

        public static RadioButton RadioButton(this Control parent, string name) => Control<RadioButton>(parent, name);

        public static ListView ListView(this Control parent, string name) => Control<ListView>(parent, name);

        public static void InvokeEventHandler(this Control control, string method, EventArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            MethodInfo mi = null;
            var methods = control.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance);
            for (int i = 0; i < methods.Length; i++)
            {
                if (methods[i].Name.Contains(method))
                {
                    var parameters = methods[i].GetParameters();
                    if (parameters.Length == 2 &&
                        parameters[0].ParameterType == typeof(object) &&
                        parameters[1].ParameterType.IsInstanceOfType(args))
                    {
                        if (mi != null)
                            throw new ArgumentException($"More than one method is found matching the name {method} and expected signature (found: {mi.Name}, {methods[i].Name})", nameof(method));
                        mi = methods[i];
                    }
                }
            }

            if (mi == null)
                throw new ArgumentException($"No methods is found matching the name {method} and expected signature", nameof(method));

            mi.Invoke(control, new object[] { control, args });
        }
    }
}
