using BallisticCalculator;
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
            var controller = new ChartController(mMeasurementSystem, mAngularUnits, mChartMode, mTrajectory);
            formsPlot1.Plot.YAxis?.LockLimits(false);
            formsPlot1.Plot.Clear();
            if (mTrajectory != null)
            {
                formsPlot1.Plot.AddScatter(controller.GetXAxis(), controller.GetYAxis());
                formsPlot1.Plot.XAxis.Label(controller.XAxisTitle);
                formsPlot1.Plot.YAxis.Label(controller.YAxisTitle);
                formsPlot1.Plot.AxisAuto();
                formsPlot1.Plot.YAxis.LockLimits();
            }
            formsPlot1.Refresh();
        }
    }
}
