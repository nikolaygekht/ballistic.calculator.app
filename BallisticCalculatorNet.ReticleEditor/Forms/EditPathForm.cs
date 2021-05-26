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
    public partial class EditPathForm : Form
    {
        internal ReticleCircle Circle { get; }

        public EditPathForm(ReticleCircle circle)
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
            Circle.Center.X = measurementX.ValueAs<AngularUnit>();
            Circle.Center.Y = measurementY.ValueAs<AngularUnit>();
            Circle.Radius = measurementR.ValueAs<AngularUnit>();
            if (!measurementWidth.IsEmpty)
                Circle.LineWidth = measurementWidth.ValueAs<AngularUnit>();
            Circle.Color = comboBoxColor.Text;
            Circle.Fill = checkBoxFill.Checked;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
