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
    public partial class EditLineForm : Form
    {
        internal ReticleLine Line { get; }

        public EditLineForm(ReticleLine line)
        {
            Line = line;
            InitializeComponent();

            measurementX1.Value = line.Start?.X;
            measurementY1.Value = line.Start?.Y;
            measurementX2.Value = line.End?.X;
            measurementY2.Value = line.End?.Y;

            if (line.LineWidth != null)
                measurementWidth.Value = line.LineWidth.Value;

            comboBoxColor.FillByColors();
            comboBoxColor.Text = line.Color;
        }

        internal void Save()
        {
            Line.Start.X = measurementX1.ValueAs<AngularUnit>();
            Line.Start.Y = measurementY1.ValueAs<AngularUnit>();
            Line.End.X = measurementX2.ValueAs<AngularUnit>();
            Line.End.Y = measurementY2.ValueAs<AngularUnit>();
            if (!measurementWidth.IsEmpty)
                Line.LineWidth = measurementWidth.ValueAs<AngularUnit>();
            Line.Color = comboBoxColor.Text;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
