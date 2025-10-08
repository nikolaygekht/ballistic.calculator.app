using BallisticCalculator;
using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.Types;
using Gehtsoft.Measurements;
using ScottPlot;
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

    public partial class ChartControl : UserControl
    {
        private MeasurementSystem mMeasurementSystem = MeasurementSystem.Metric;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MeasurementSystem MeasurementSystem
        {
            get => mMeasurementSystem;
            set
            {
                mMeasurementSystem = value;
                UpdateChart();
            }
        }

        private AngularUnit mAngularUnits = AngularUnit.MOA;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AngularUnit AngularUnits
        {
            get => mAngularUnits;
            set
            {
                mAngularUnits = value;
                UpdateChart();
            }
        }

        private DropBase mDropBase = DropBase.SightLine;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DropBase DropBase
        {
            get => mDropBase;
            set
            {
                mDropBase = value;
                UpdateChart();
            }
        }

        private TrajectoryPoint[] mTrajectory = null;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TrajectoryPoint[] Trajectory
        {
            get => mTrajectory;
            set
            {
                mTrajectory = value;
                UpdateChart();
            }
        }

        private TrajectoryChartMode mChartMode = TrajectoryChartMode.Drop;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TrajectoryChartMode ChartMode
        {
            get => mChartMode;
            set
            {
                mChartMode = value;
                UpdateChart();
            }
        }

        public ChartControl()
        {
            InitializeComponent();
        }

        private void UpdateChart()
        {
            formsPlot1.Plot.YAxis?.LockLimits(false);
            formsPlot1.Plot.Clear();
            if (mTrajectory != null)
            {
                var controller = new ChartController(mMeasurementSystem, mAngularUnits, mChartMode, mDropBase, mTrajectory);
                var x = controller.GetXAxis();
                var ySeries = controller.GetYAxis();

                for (int i = 0; i < ySeries.Count; i++)
                {
                    var label = controller.SeriesCount > 1 ? controller.GetSeriesTitle(i) : null;
                    formsPlot1.Plot.AddScatter(x, ySeries[i], label: label);
                }

                if (controller.SeriesCount > 1)
                    formsPlot1.Plot.Legend();

                formsPlot1.Plot.XAxis.Label(controller.XAxisTitle);
                formsPlot1.Plot.YAxis.Label(controller.YAxisTitle);
                formsPlot1.Plot.AxisAuto();
                formsPlot1.Plot.YAxis.LockLimits();
            }
            formsPlot1.Refresh();
        }

        public void UpdateYAxis()
        {
            if (mTrajectory == null)
                return;

            formsPlot1.Plot.YAxis?.LockLimits(false);

            var limits = formsPlot1.Plot.GetAxisLimits();
            var controller = new ChartController(mMeasurementSystem, mAngularUnits, mChartMode, mDropBase, mTrajectory);
            var yMin = Double.MaxValue;
            var yMax = Double.MinValue;
            var i1 = -1;
            var i2 = mTrajectory.Length - 1;

            for (int i = 1; i < mTrajectory.Length - 1; i++)
            {
                var x = controller.GetXAxisPoint(i);
                if (x >= limits.XMin && i1 == -1)
                {
                    i1 = i - 1;
                }
                if (x>= limits.XMax)
                {
                    i2 = i + 1;
                    break;
                }
            }
            if (i1 < 0)
                i1 = 0;
            if (i2 >= mTrajectory.Length)
                i2 = mTrajectory.Length - 1;

            for (int series = 0; series < controller.SeriesCount; series++)
            {
                for (int i = i1; i <= i2; i++)
                {
                    var y = controller.GetYAXisPoint(i, series);
                    if (y < yMin)
                        yMin = y;
                    if (y > yMax)
                        yMax = y;
                }
            }

            var delta = yMax - yMin;
            formsPlot1.Plot.SetAxisLimitsY(yMin - delta * 0.05, yMax + delta * 0.05);
            formsPlot1.Plot.YAxis.LockLimits();
            formsPlot1.Refresh();
        }
    }
}
