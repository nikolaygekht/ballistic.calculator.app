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

        private AngularUnit mAngularUnits;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AngularUnit AngularUnits
        {
            get => mAngularUnits;
            set
            {
                mAngularUnits = value;
                listView.Invalidate();
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
                listView.Invalidate();
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
                listView.Invalidate();
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
                listView.Invalidate();
                listView.Update();
            }
        }

        public TrajectoryControl()
        {
            InitializeComponent();
            if (ControlConfiguration.Configuration != null)
            {
                for (int i = 0; i < listView.Columns.Count; i++)
                {
                    var column = listView.Columns[i];
                    var _width = ControlConfiguration.Configuration[$"state:trajectory:column:{i}"];
                    if (int.TryParse(_width, NumberStyles.Integer, CultureInfo.InvariantCulture, out var width))
                        column.Width = width;
                } 
            }
        }

        public void OnClose()
        {
            if (ControlConfiguration.Configuration != null)
            {
                for (int i = 0; i < listView.Columns.Count; i++)
                {
                    var column = listView.Columns[i];
                    ControlConfiguration.Configuration[$"state:trajectory:column:{i}"] = column.Width.ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        public void Clear()
        {
            Trajectory = null;
        }

        public DistanceUnit RangeUnit => mMeasurementSystem == MeasurementSystem.Metric ? DistanceUnit.Meter : DistanceUnit.Yard;
        public DistanceUnit AdjustmentUnit => mMeasurementSystem == MeasurementSystem.Metric ? DistanceUnit.Centimeter : DistanceUnit.Inch;
        public VelocityUnit VelocityUnit => mMeasurementSystem == MeasurementSystem.Metric ? VelocityUnit.MetersPerSecond : VelocityUnit.FeetPerSecond;
        public EnergyUnit EnergyUnit => mMeasurementSystem == MeasurementSystem.Metric ? EnergyUnit.Joule : EnergyUnit.FootPound;
        public WeightUnit WeightUnit => mMeasurementSystem == MeasurementSystem.Metric ? WeightUnit.Kilogram : WeightUnit.Pound;

        private void listView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (mTrajectory == null || e.ItemIndex < 0 || e.ItemIndex >= mTrajectory.Length)
                return;

            var item = mTrajectory[e.ItemIndex];

            e.Item ??= new ListViewItem("");

            e.Item.SubItems.Clear();

            //range
            e.Item.SubItems
                .Add(item.Distance.To(RangeUnit).ToString("N0", Culture));
            //velocity
            e.Item.SubItems
                .Add(item.Velocity.To(VelocityUnit).ToString("N0", Culture));
            //mach
            e.Item.SubItems
                .Add(item.Mach.ToString("N2", CultureInfo.CurrentCulture));
            //path
            AddAngularValue(item.Distance, item.Drop, item.DropAdjustment, mSight?.VerticalClick, e.Item);

            //windage
            AddAngularValue(item.Distance, item.Windage, item.WindageAdjustment, mSight?.HorizontalClick, e.Item);

            //time
            e.Item.SubItems.Add(item.Time.ToString("mm\\:ss\\.fff"));
            //energy
            e.Item.SubItems
                .Add(item.Energy.To(EnergyUnit).ToString("N0", Culture));
            //ogw
            e.Item.SubItems
                .Add(item.OptimalGameWeight.To(WeightUnit).ToString("N1", Culture));
        }

        private void AddAngularValue(Measurement<DistanceUnit> distance,
                                     Measurement<DistanceUnit> value,
                                     Measurement<AngularUnit> valueAdjustiment,
                                     Measurement<AngularUnit>? scopeStep,
                                     ListViewItem lvi)
        {
            //value
            lvi.SubItems
                .Add(value.To(AdjustmentUnit).ToString("N2", Culture));

            //adjustment
            if (distance.Value < 1e-8)
            {
                lvi.SubItems.Add("n/a");
                lvi.SubItems.Add("n/a");
            }
            else
            {
                lvi.SubItems
                    .Add(valueAdjustiment.To(mAngularUnits).ToString("N2", Culture));

                
                //clicks
                if (scopeStep == null || scopeStep.Value.Value <= 0)
                    lvi.SubItems.Add("n/a");
                else
                    lvi.SubItems.Add((valueAdjustiment / scopeStep.Value).ToString("N0"));
            }
        }
    }
}
