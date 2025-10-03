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
    public partial class MultiChartControl : UserControl
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

        private DropBase mDropBase;

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

        public MultiChartControl()
        {
            InitializeComponent();
        }

        private readonly List<Tuple<string, TrajectoryPoint[]>> mTrajectories = new();

        public void AddTrajectory(string name, TrajectoryPoint[] trajectory)
        {
            mTrajectories.Add(new Tuple<string, TrajectoryPoint[]>(name, trajectory));
            UpdateChart();
        }

        public void RemoveLast()
        {
            if (mTrajectories.Count > 0)
                mTrajectories.RemoveAt(mTrajectories.Count - 1);
            UpdateChart();
        }

        private void UpdateChart()
        {
            formsPlot1.Plot.YAxis?.LockLimits(false);
            formsPlot1.Plot.Clear();
            if (mTrajectories.Count > 0)
            {
                for (int i = 0; i < mTrajectories.Count; i++)
                {
                    var trajectory = mTrajectories[i];
                    var controller = new ChartController(mMeasurementSystem, mAngularUnits, mChartMode, mDropBase, trajectory.Item2);
                    formsPlot1.Plot.AddScatter(controller.GetXAxis(), controller.GetYAxis(), label:trajectory.Item1);
                    
                    if (i == 0)
                    {
                        formsPlot1.Plot.XAxis.Label(controller.XAxisTitle);
                        formsPlot1.Plot.YAxis.Label(controller.YAxisTitle);
                    }
                }
                formsPlot1.Plot.Legend();
                formsPlot1.Plot.AxisAuto();
                formsPlot1.Plot.YAxis.LockLimits();
            }
            formsPlot1.Refresh();
        }

        public void UpdateYAxis()
        {
            if (mTrajectories.Count == 0)
                return;

            formsPlot1.Plot.YAxis?.LockLimits(false);

            var yMin = Double.MaxValue;
            var yMax = Double.MinValue;
            var limits = formsPlot1.Plot.GetAxisLimits();

            for (int j = 0; j < mTrajectories.Count; j++)
            {
                var trajectory = mTrajectories[j].Item2;
                
                var controller = new ChartController(mMeasurementSystem, mAngularUnits, mChartMode, mDropBase, trajectory);
                var i1 = -1;
                var i2 = trajectory.Length - 1;
                
                for (int i = 1; i < trajectory.Length - 1; i++)
                {
                    var x = controller.GetXAxisPoint(i);
                    if (x >= limits.XMin && i1 == -1)
                    {
                        i1 = i - 1;
                    }
                    if (x >= limits.XMax)
                    {
                        i2 = i + 1;
                        break;
                    }
                }
                if (i1 < 0)
                    i1 = 0;
                if (i2 >= trajectory.Length)
                    i2 = trajectory.Length - 1;

                for (int i = i1; i <= i2; i++)
                {
                    var y = controller.GetYAXisPoint(i);
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
