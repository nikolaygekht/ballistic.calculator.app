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
    public partial class EditCircleForm : Form
    {
        internal ReticleCircle Circle { get; }

        public EditCircleForm(ReticleCircle circle)
        {
            Circle = circle;
            InitializeComponent();

            measurementX.Value = circle.Center?.X;
            measurementY.Value = circle.Center?.Y;

            measurementR.Value = circle.Radius;

            if (circle.LineWidth != null)
                measurementWidth.Value = circle.LineWidth.Value;

            comboBoxColor.FillByColors();
            comboBoxColor.Text = circle.Color;

            if (circle.Fill ?? false)
                checkBoxFill.Checked = true;
        }

        internal void Save()
        {
            Circle.Center.X = measurementX.ValueAsMeasurement<AngularUnit>();
            Circle.Center.Y = measurementY.ValueAsMeasurement<AngularUnit>();
            Circle.Radius = measurementR.ValueAsMeasurement<AngularUnit>();
            if (!measurementWidth.IsEmpty)
                Circle.LineWidth = measurementWidth.ValueAsMeasurement<AngularUnit>();
            Circle.Color = comboBoxColor.Text;
            Circle.Fill = checkBoxFill.Checked;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
