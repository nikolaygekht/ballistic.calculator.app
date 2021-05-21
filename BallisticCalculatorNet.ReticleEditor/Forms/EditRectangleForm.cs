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
    public partial class EditRectangleForm : Form
    {
        internal ReticleRectangle Rectangle { get; }

        public EditRectangleForm(ReticleRectangle rectangle)
        {
            Rectangle = rectangle;
            InitializeComponent();

            measurementX1.Value = rectangle.TopLeft?.X;
            measurementY1.Value = rectangle.TopLeft?.Y;
            measurementX2.Value = rectangle.Size?.X;
            measurementY2.Value = rectangle.Size?.Y;

            if (rectangle.LineWidth != null)
                measurementWidth.Value = rectangle.LineWidth.Value;

            comboBoxColor.FillByColors();
            comboBoxColor.Text = rectangle.Color;

            checkBoxFill.Checked = rectangle.Fill ?? false;
        }

        internal void Save()
        {
            Rectangle.TopLeft.X = measurementX1.ValueAs<AngularUnit>();
            Rectangle.TopLeft.Y = measurementY1.ValueAs<AngularUnit>();
            Rectangle.Size.X = measurementX2.ValueAs<AngularUnit>();
            Rectangle.Size.Y = measurementY2.ValueAs<AngularUnit>();
            if (!measurementWidth.IsEmpty)
                Rectangle.LineWidth = measurementWidth.ValueAs<AngularUnit>();
            Rectangle.Color = comboBoxColor.Text;
            Rectangle.Fill = checkBoxFill.Checked;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
