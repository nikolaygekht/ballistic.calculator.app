using BallisticCalculator;
using BallisticCalculatorNet.Api;
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

    public partial class ZeroAmmunitionControl : UserControl, IZeroAmmunitionControl
    {
        public ZeroAmmunitionControl()
        {
            InitializeComponent();
            checkBoxOther.Checked = false;
            buttonLoad.Enabled = ammoControl.Enabled = false;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Ammunition Ammunition
        {
            get => checkBoxOther.Checked ? ammoControl.Ammunition : null;
            set
            {
                if (value == null)
                {
                    checkBoxOther.Checked = false;
                    ammoControl.Enabled = false;
                    buttonLoad.Enabled = false;
                }
                else
                {
                    checkBoxOther.Checked = true;
                    ammoControl.Enabled = true;
                    ammoControl.Ammunition = value;
                    buttonLoad.Enabled = true;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MeasurementSystem MeasurementSystem
        {
            get => ammoControl.MeasurementSystem;
            set => ammoControl.MeasurementSystem = value;
        }

        private void checkBoxOther_CheckedChanged(object sender, EventArgs e)
        {
            buttonLoad.Enabled = ammoControl.Enabled = checkBoxOther.Checked;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IFileNamePromptFactory PromptFactory { get; set; } = new WinFormsFileNamePromptFactory();

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            var ammo = AmmunitionControlUtils.Load(this, PromptFactory, out _);
            if (ammo != null)
                ammoControl.Ammunition = ammo.Ammunition;
        }
    }
}
