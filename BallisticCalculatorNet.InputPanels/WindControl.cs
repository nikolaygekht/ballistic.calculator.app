using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallisticCalculator;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.InputPanels
{
    public partial class WindControl : UserControl, IMeasurementSystemControl
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Wind Wind
        {
            get
            {
                if (!checkBoxDistance.Checked &&
                    measurementVelocity.ValueAsMeasurement<VelocityUnit>().Value < 1e-5 &&
                    measurementDirection.ValueAsMeasurement<AngularUnit>().Value < 1e-5)
                    return null;

                return new Wind(measurementVelocity.ValueAsMeasurement<VelocityUnit>(), measurementDirection.ValueAsMeasurement<AngularUnit>(),
                    checkBoxDistance.Checked ? measurementDistance.ValueAsMeasurement<DistanceUnit>() : null);
            }
            set
            {
                if (value == null)
                {
                    checkBoxDistance.Checked = false;
                    measurementDistance.Value = new Measurement<DistanceUnit>(0, measurementDistance.UnitAs<DistanceUnit>());
                    measurementDirection.Value = new Measurement<AngularUnit>(0, measurementDirection.UnitAs<AngularUnit>());
                    measurementVelocity.Value = new Measurement<VelocityUnit>(0, measurementVelocity.UnitAs<VelocityUnit>());
                    return;
                }

                measurementVelocity.Value = value.Velocity;
                measurementDirection.Value = value.Direction;
                if (value.MaximumRange != null)
                {
                    checkBoxDistance.Checked = true;
                    measurementDistance.Value = value.MaximumRange;
                }
                else
                {
                    checkBoxDistance.Checked = false;
                    measurementDistance.Value = new Measurement<DistanceUnit>(0, measurementDistance.UnitAs<DistanceUnit>());
                }
            }
        }

        public WindControl()
        {
            InitializeComponent();
            checkBoxDistance_CheckedChanged(this, EventArgs.Empty);
        }

        private static void DrawRay(Graphics g, Pen p, float cx, float cy, float r, double direction)
        {
            float y = cy - r * (float)Math.Cos(direction);
            float x = cx + r * (float)Math.Sin(direction);
            g.DrawLine(p, x, y, cx, cy);
        }

        internal void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var background = new SolidBrush(pictureBox1.BackColor);
            e.Graphics.FillRectangle(background, new Rectangle(0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height));
            var pen = new Pen(this.ForeColor, 2);
            var cy = pictureBox1.Height / 2;
            var cx = pictureBox1.Width / 2;
            var r = Math.Min(cx, cy);
            e.Graphics.DrawEllipse(pen, cx - r, cy - r, r * 2, cy * 2);
            DrawRay(e.Graphics, pen, cx, cy, r, measurementDirection.ValueAsMeasurement<AngularUnit>().In(AngularUnit.Radian));
            DrawRay(e.Graphics, pen, cx, cy, r / 5f, measurementDirection.ValueAsMeasurement<AngularUnit>().In(AngularUnit.Radian) - AngularUnit.Degree.New(30).In(AngularUnit.Radian));
            DrawRay(e.Graphics, pen, cx, cy, r / 5f, measurementDirection.ValueAsMeasurement<AngularUnit>().In(AngularUnit.Radian) + AngularUnit.Degree.New(30).In(AngularUnit.Radian));
        }

        internal void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            var cy = pictureBox1.Height / 2;
            var cx = pictureBox1.Width / 2;
            var dx = Math.Abs(e.X - cx);
            var dy = Math.Abs(e.Y - cy);
            var a = Math.Atan2(dy, dx);
            if (e.X <= cx && e.Y <= cy)
                a = -Math.PI / 2 + a;
            else if (e.X <= cx && e.Y > cy)
                a = -Math.PI / 2 - a;
            else if (e.X > cx && e.Y <= cy)
                a = Math.PI / 2 - a;
            else if (e.X > cx && e.Y > cy)
                a = Math.PI / 2 + a;
            var d = Math.Round(AngularUnit.Radian.New(a).In(AngularUnit.Degree));
            measurementDirection.Value = AngularUnit.Degree.New(d);
        }

        private void measurementDirection_Changed(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void checkBoxDistance_CheckedChanged(object sender, EventArgs e)
        {
            measurementDistance.Enabled = checkBoxDistance.Checked;
        }

        private MeasurementSystem mMeasurementSystem = MeasurementSystem.Metric;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MeasurementSystem MeasurementSystem
        {
            get => mMeasurementSystem;
            set
            {
                mMeasurementSystem = value;
                UpdateSystem();
            }
        }

        private void UpdateSystem()
        {
            switch (mMeasurementSystem)
            {
                case MeasurementSystem.Metric:
                    measurementDistance.ChangeUnit(DistanceUnit.Meter);
                    measurementVelocity.ChangeUnit(VelocityUnit.MetersPerSecond);
                    break;
                case MeasurementSystem.Imperial:
                    measurementDistance.ChangeUnit(DistanceUnit.Foot);
                    measurementVelocity.ChangeUnit(VelocityUnit.FeetPerSecond);
                    break;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                pictureBox1_MouseClick(sender, e);
        }

        private void WindControl_Enter(object sender, EventArgs e)
        {
            checkBoxDistance.Focus();
        }
    }
}
