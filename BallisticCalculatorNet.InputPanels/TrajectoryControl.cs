using BallisticCalculator;
using Gehtsoft.Measurements;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallisticCalculatorNet.InputPanels
{
    public partial class TrajectoryControl : UserControl
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public CultureInfo Culture { get; set; } = CultureInfo.CurrentCulture;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IConfiguration Configuration { get; set; }

        private AngularUnit mAngularUnits;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AngularUnit AngularUnits
        {
            get => mAngularUnits;
            set
            {
                mAngularUnits = value;
                listView.Update();
            }
        }


        private Sight mSight;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Sight Sight
        {
            get => mSight;
            set
            {
                mSight = value;
                listView.Update();
            }
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
                listView.Update();
            }
        }

        private TrajectoryPoint[] mTrajectory;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TrajectoryPoint[] Trajectory
        {
            get => mTrajectory;
            set
            {
                mTrajectory = value;
                listView.VirtualListSize = mTrajectory?.Length ?? 0;
                listView.Update();
            }
        }

        public TrajectoryControl()
        {
            InitializeComponent();
            if (Configuration != null)
            {
                for (int i = 0; i < listView.Columns.Count; i++)
                {
                    var column = listView.Columns[i];
                    var _width = Configuration[$"state:trajectory:{column.Name}"];
                    if (int.TryParse(_width, NumberStyles.Integer, CultureInfo.InvariantCulture, out var width))
                        column.Width = width;
                } 
            }
        }

        public void OnClose()
        {
            if (Configuration != null)
            {
                for (int i = 0; i < listView.Columns.Count; i++)
                {
                    var column = listView.Columns[i];
                    Configuration[$"state:trajectory:{column.Name}"] = column.Width.ToString(CultureInfo.InvariantCulture);
                }
            }
        }


        private void listView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (mTrajectory == null || e.ItemIndex < 0 || e.ItemIndex >= mTrajectory.Length)
                return;

            var item = mTrajectory[e.ItemIndex];

            e.Item.Text = "";
            e.Item.SubItems.Clear();
            //range
            e.Item.SubItems
                .Add(item.Distance.To(mMeasurementSystem == MeasurementSystem.Metric ? DistanceUnit.Meter : DistanceUnit.Yard).ToString("N0", Culture));
            //velocity
            e.Item.SubItems
                .Add(item.Velocity.To(mMeasurementSystem == MeasurementSystem.Metric ? VelocityUnit.MetersPerSecond : VelocityUnit.FeetPerSecond).ToString("N0", Culture));
            //mach
            e.Item.SubItems
                .Add(item.Mach.ToString("N2", CultureInfo.CurrentCulture));
            //path
            e.Item.SubItems
                .Add(item.Drop.To(mMeasurementSystem == MeasurementSystem.Metric ? DistanceUnit.Centimeter : DistanceUnit.Inch).ToString("N2", Culture));
            //hold
            e.Item.SubItems
                .Add(item.DropAdjustment.To(mAngularUnits).ToString("N2", Culture));
            //clicks
            if (mSight == null || mSight.VerticalClick == null || mSight.VerticalClick.Value.Value <= 0)
                e.Item.SubItems.Add("n/a");
            else
                e.Item.SubItems.Add((item.DropAdjustment / mSight.VerticalClick.Value).ToString("N0", Culture));
            //windage
            e.Item.SubItems
                .Add(item.Windage.To(mMeasurementSystem == MeasurementSystem.Metric ? DistanceUnit.Centimeter : DistanceUnit.Inch).ToString("N2", Culture));
            //adj
            e.Item.SubItems
                .Add(item.WindageAdjustment.To(mAngularUnits).ToString("N2", Culture));
            //clicks
            if (mSight == null || mSight.HorizontalClick == null || mSight.HorizontalClick.Value.Value <= 0)
                e.Item.SubItems.Add("n/a");
            else
                e.Item.SubItems.Add((item.WindageAdjustment / mSight.HorizontalClick.Value).ToString("N0"));
            //time
            e.Item.SubItems.Add(item.Time.ToString("mm\\:ss\\.fff"));
            //energy
            e.Item.SubItems
                .Add(item.Energy.To(mMeasurementSystem == MeasurementSystem.Metric ? EnergyUnit.Joule : EnergyUnit.FootPound).ToString("N0", Culture));
            //ogw
            e.Item.SubItems
                .Add(item.OptimalGameWeight.To(mMeasurementSystem == MeasurementSystem.Metric ? WeightUnit.Kilogram : WeightUnit.Pound).ToString("N1", Culture));
        }
    }
}
