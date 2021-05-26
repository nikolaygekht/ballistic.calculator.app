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
    public partial class EditTextForm : Form
    {
        internal ReticleText ReticleText { get; }

        public EditTextForm(ReticleText text)
        {
            ReticleText = text;
            InitializeComponent();

            measurementX.Value = text.Position?.X;
            measurementY.Value = text.Position?.Y;
            measurementH.Value = text.TextHeight;
            textBox.Text = text.Text;

            comboBoxColor.FillByColors();
            comboBoxColor.Text = text.Color;
        }

        internal void Save()
        {
            ReticleText.Position.X = measurementX.ValueAs<AngularUnit>();
            ReticleText.Position.Y = measurementY.ValueAs<AngularUnit>();
            ReticleText.TextHeight = measurementH.ValueAs<AngularUnit>();
            ReticleText.Text = textBox.Text;
            ReticleText.Color = comboBoxColor.Text;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
