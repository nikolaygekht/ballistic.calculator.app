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

            switch (text.Anchor)
            {
                case null:
                    comboBoxAlignment.SelectedIndex = 0;
                    break;
                case TextAnchor.Left:
                    comboBoxAlignment.SelectedIndex = 1;
                    break;
                case TextAnchor.Center:
                    comboBoxAlignment.SelectedIndex = 2;
                    break;
                case TextAnchor.Right:
                    comboBoxAlignment.SelectedIndex = 3;
                    break;
            }
        }

        internal void Save()
        {
            ReticleText.Position.X = measurementX.ValueAsMeasurement<AngularUnit>();
            ReticleText.Position.Y = measurementY.ValueAsMeasurement<AngularUnit>();
            ReticleText.TextHeight = measurementH.ValueAsMeasurement<AngularUnit>();
            ReticleText.Text = textBox.Text;
            ReticleText.Color = comboBoxColor.Text;
            switch (comboBoxAlignment.SelectedIndex)
            {
                case 1:
                    ReticleText.Anchor = TextAnchor.Left;
                    break;
                case 2:
                    ReticleText.Anchor = TextAnchor.Center;
                    break;
                case 3:
                    ReticleText.Anchor = TextAnchor.Right;
                    break;
                default:
                    ReticleText.Anchor = null;
                    break;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
