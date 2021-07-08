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
    public partial class EditArcForm : Form
    {
        internal ReticlePathElementArc Element { get; }

        public EditArcForm(ReticlePathElementArc el)
        {
            Element = el;
            InitializeComponent();

            measurementX1.Value = Element.Position?.X;
            measurementY1.Value = Element.Position?.Y;
            measurementR.Value = Element.Radius;
            checkBoxMajorArc.Checked = Element.MajorArc;
            checkBoxClockwise.Checked = Element.ClockwiseDirection;
        }

        internal void Save()
        {
            Element.Position.X = measurementX1.ValueAsMeasurement<AngularUnit>();
            Element.Position.Y = measurementY1.ValueAsMeasurement<AngularUnit>();
            Element.Radius = measurementR.ValueAsMeasurement<AngularUnit>();
            Element.MajorArc = checkBoxMajorArc.Checked;
            Element.ClockwiseDirection = checkBoxClockwise.Checked;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
