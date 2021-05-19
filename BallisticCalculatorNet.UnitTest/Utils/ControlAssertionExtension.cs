using System;
using System.Windows.Forms;

namespace BallisticCalculatorNet.UnitTest.Utils
{
    public static class ControlAssertionExtension
    {
        public static ControlAssertions Should(this Control control) => new ControlAssertions(control);

        public static TextBoxAssertions Should(this TextBox control) => new TextBoxAssertions(control);

        public static ListBoxAssertions Should(this ListBox control) => new ListBoxAssertions(control);

        public static ComboBoxAssertions Should(this ComboBox control) => new ComboBoxAssertions(control);

        public static MeasurementControlAssertions Should(this MeasurementControl.MeasurementControl control) => new MeasurementControlAssertions(control);

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

        public static MeasurementControl.MeasurementControl MeasurementControl(this Control parent, string name) => Control<MeasurementControl.MeasurementControl>(parent, name);
    }
}
