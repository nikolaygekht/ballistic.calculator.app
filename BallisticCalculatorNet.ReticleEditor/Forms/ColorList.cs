using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallisticCalculatorNet.ReticleEditor.Forms
{
    internal static class ColorList
    {
        internal static void FillByColors(this ComboBox combo)
        {
            combo.Items.Add("black");
            combo.Items.Add("blue");
            combo.Items.Add("brown");
            combo.Items.Add("cyan");
            combo.Items.Add("darkblue");
            combo.Items.Add("darkcyan");
            combo.Items.Add("darkgray");
            combo.Items.Add("darkgreen");
            combo.Items.Add("darkmagenta");
            combo.Items.Add("darkorange");
            combo.Items.Add("darkred");
            combo.Items.Add("darkviolet");
            combo.Items.Add("gold");
            combo.Items.Add("goldenrod");
            combo.Items.Add("grey");
            combo.Items.Add("green");
            combo.Items.Add("greenyellow");
            combo.Items.Add("lightgray");
            combo.Items.Add("magenta");
            combo.Items.Add("mediumblue");
            combo.Items.Add("mediumpurple");
            combo.Items.Add("orange");
            combo.Items.Add("pink");
            combo.Items.Add("purple");
            combo.Items.Add("red");
            combo.Items.Add("teal");
            combo.Items.Add("violet");
            combo.Items.Add("white");
        }
    }
}
