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
                mMeasurementSystemController.AngularUnit = value;
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

        private readonly MeasurementSystemController mMeasurementSystemController = new MeasurementSystemController(MeasurementSystem.Metric);
        private MeasurementSystem mMeasurementSystem = MeasurementSystem.Metric;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MeasurementSystem MeasurementSystem
        {
            get => mMeasurementSystem;
            set
            {
                mMeasurementSystem = value;
                mMeasurementSystemController.MeasurementSystem = value;
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

        private void listView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (mTrajectory == null || e.ItemIndex < 0 || e.ItemIndex >= mTrajectory.Length)
                return;

            var item = mTrajectory[e.ItemIndex];

            e.Item ??= new ListViewItem("");

            e.Item.SubItems.Clear();

            //range
            e.Item.SubItems
                .Add(item.Distance.To(mMeasurementSystemController.RangeUnit)
                                  .ToString(mMeasurementSystemController.RangeFormatString, Culture));
            //velocity
            e.Item.SubItems
                .Add(item.Velocity.To(mMeasurementSystemController.VelocityUnit)
                                  .ToString(mMeasurementSystemController.VelocityFormatString, Culture));
            //mach
            e.Item.SubItems
                .Add(item.Mach.ToString(mMeasurementSystemController.MachFormatString, CultureInfo.CurrentCulture));
            //path
            AddAngularValue(item.Distance, item.Drop, item.DropAdjustment, mSight?.VerticalClick, e.Item);

            //windage
            AddAngularValue(item.Distance, item.Windage, item.WindageAdjustment, mSight?.HorizontalClick, e.Item);

            //time
            e.Item.SubItems.Add(item.Time.ToString(mMeasurementSystemController.TimeFormatString));
            //energy
            e.Item.SubItems
                .Add(item.Energy.To(mMeasurementSystemController.EnergyUnit)
                                .ToString(mMeasurementSystemController.EnergyFormatString, Culture));
            //ogw
            e.Item.SubItems
                .Add(item.OptimalGameWeight.To(mMeasurementSystemController.WeightUnit)
                                            .ToString(mMeasurementSystemController.WeightFormatString, Culture));
        }

        private void AddAngularValue(Measurement<DistanceUnit> distance,
                                     Measurement<DistanceUnit> value,
                                     Measurement<AngularUnit> valueAdjustiment,
                                     Measurement<AngularUnit>? scopeStep,
                                     ListViewItem lvi)
        {
            //value
            lvi.SubItems
                .Add(value.To(mMeasurementSystemController.AdjustmentUnit)
                .ToString(mMeasurementSystemController.AdjustmentFormatString, Culture));

            //adjustment
            if (distance.Value < 1e-8)
            {
                lvi.SubItems.Add("n/a");
                lvi.SubItems.Add("n/a");
            }
            else
            {
                lvi.SubItems
                    .Add(valueAdjustiment.To(mAngularUnits).ToString(mMeasurementSystemController.AngularFormatString, Culture));

                
                //clicks
                if (scopeStep == null || scopeStep.Value.Value <= 0)
                    lvi.SubItems.Add("n/a");
                else
                    lvi.SubItems.Add((valueAdjustiment / scopeStep.Value).ToString(mMeasurementSystemController.ClickFormatString, Culture));
            }
        }
    }
}
