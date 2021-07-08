using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallisticCalculator.Reticle.Data;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.ReticleEditor.Forms
{
    public partial class EditBdcForm : Form
    {
        internal ReticleBulletDropCompensatorPoint Bdc { get; }

        public EditBdcForm(ReticleBulletDropCompensatorPoint bdc)
        {
            Bdc = bdc;
            InitializeComponent();

            measurementX.Value = bdc.Position?.X;
            measurementY.Value = bdc.Position?.Y;

            measurementO.Value = bdc.TextOffset;
            measurementH.Value = bdc.TextHeight;
        }

        internal void Save()
        {
            Bdc.Position.X = measurementX.ValueAsMeasurement<AngularUnit>();
            Bdc.Position.Y = measurementY.ValueAsMeasurement<AngularUnit>();
            Bdc.TextOffset = measurementO.ValueAsMeasurement<AngularUnit>();
            Bdc.TextHeight = measurementH.ValueAsMeasurement<AngularUnit>();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
