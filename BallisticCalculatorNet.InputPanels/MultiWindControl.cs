using BallisticCalculator;
using BallisticCalculatorNet.Api;
using Gehtsoft.Measurements;
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

    public partial class MultiWindControl : UserControl
    {
        private readonly List<WindControl> mWindControls = new List<WindControl>();

        public MultiWindControl()
        {
            InitializeComponent();
            windControl1.EnableDistance();
        }

        public WindCollection Winds
        {
            get
            {
                if (windControl1.IsEmpty() && mWindControls.Count == 0)
                    return null;
                WindCollection r = new WindCollection
                {
                    windControl1.Wind
                };
                for (int i = 0; i < mWindControls.Count; i++)
                    r.Add(mWindControls[i].Wind);
                return r;
            }
            set
            {
                if (value == null || value.Count == 0)
                {
                    Clear();
                    windControl1.Clear();
                    windControl1.EnableDistance();
                }
                else
                {
                    Clear();
                    for (int i = 0; i < value.Count; i++)
                    {
                        var ctrl = i == 0 ? windControl1 : AddControl();
                        ctrl.Wind = value[i];
                    }
                }
            }
        }

        private WindControl AddControl()
        {
            var windControl = new WindControl
            {
                Location = new Point(1, windControl1.Location.Y + (windControl1.Size.Height + 4) * (mWindControls.Count + 1)),
                Margin = new Padding(4),
                Name = "windControl" + (mWindControls.Count + 2),
                Size = windControl1.Size,
                TabIndex = mWindControls.Count + 3,
                Parent = this,
            };
            windControl.EnableDistance();
            mWindControls.Add(windControl);
            Controls.Add(windControl);
            return windControl;
        }

        private void Clear()
        {
            foreach (var control in mWindControls)
                Controls.Remove(control);
            mWindControls.Clear();
            windControl1.Clear();
            windControl1.EnableDistance();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MeasurementSystem MeasurementSystem
        {
            get => windControl1.MeasurementSystem;
            set
            {
                windControl1.MeasurementSystem = value;
                foreach (var control in mWindControls)
                    control.MeasurementSystem = value;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var lastControl = mWindControls.Count > 0 ? mWindControls[^1] : windControl1;
            var lastWind = lastControl.Wind ?? new Wind(0.As(windControl1.MeasurementSystem == MeasurementSystem.Metric ? VelocityUnit.MetersPerSecond : VelocityUnit.FeetPerSecond), 0.As(AngularUnit.Degree));
            var start = lastWind.MaximumRange ?? 0.As(windControl1.MeasurementSystem == MeasurementSystem.Metric ? DistanceUnit.Meter : DistanceUnit.Yard);
            lastWind.MaximumRange = start + 100.As(start.Unit);
            var control = AddControl();
            control.Wind = lastWind;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
