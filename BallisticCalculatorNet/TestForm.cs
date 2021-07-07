using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallisticCalculatorNet.InputPanels;

namespace BallisticCalculatorNet
{
    public partial class MyTestForm : Form
    {
        public MyTestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var field in this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
            {
                var v = field.GetValue(this);
                if (v is IMeasurementSystemControl msi)
                {
                    if (msi.MeasurementSystem == MeasurementSystem.Imperial)
                        msi.MeasurementSystem = MeasurementSystem.Metric;
                    else
                        msi.MeasurementSystem = MeasurementSystem.Imperial;
                }
            }
        }
    }
}
