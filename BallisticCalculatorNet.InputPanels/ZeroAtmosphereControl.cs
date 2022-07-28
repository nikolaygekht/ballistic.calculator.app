using BallisticCalculator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallisticCalculatorNet.InputPanels
{

    public partial class ZeroAtmosphereControl : UserControl, IZeroAtmosphereControl
    {
        public ZeroAtmosphereControl()
        {
            InitializeComponent();
            checkBoxOther.Checked = false;
            atmosphereControl.Enabled = false;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Atmosphere Atmosphere
        {
            get => checkBoxOther.Checked ? atmosphereControl.Atmosphere : null;
            set
            {
                if (value == null)
                {
                    checkBoxOther.Checked = false;
                    atmosphereControl.Enabled = false;
                }
                else
                {
                    checkBoxOther.Checked = true;
                    atmosphereControl.Enabled = true;
                    atmosphereControl.Atmosphere = value;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MeasurementSystem MeasurementSystem
        {
            get => atmosphereControl.MeasurementSystem;
            set => atmosphereControl.MeasurementSystem = value;
        }

        private void checkBoxOther_CheckedChanged(object sender, EventArgs e)
        {
            atmosphereControl.Enabled = checkBoxOther.Checked;
        }
    }
}
