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
    public partial class EditMoveToForm : Form
    {
        internal ReticlePathElementMoveTo Element { get; }

        public EditMoveToForm(ReticlePathElementMoveTo el)
        {
            Element = el;
            InitializeComponent();

            measurementX1.Value = Element.Position?.X;
            measurementY1.Value = Element.Position?.Y;
        }

        internal void Save()
        {
            Element.Position.X = measurementX1.ValueAs<AngularUnit>();
            Element.Position.Y = measurementY1.ValueAs<AngularUnit>();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
