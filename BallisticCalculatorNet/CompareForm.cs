using BallisticCalculator;
using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.InputPanels;
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

namespace BallisticCalculatorNet
{
    public partial class CompareForm : Form, ITrajectoryDisplayForm, IChartDisplayForm
    {
        private MeasurementSystem mMeasurementSystem = MeasurementSystem.Imperial;
        private AngularUnit mAngularUnits = AngularUnit.Mil;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MeasurementSystem MeasurementSystem
        {
            get => mMeasurementSystem;
            set
            {
                mMeasurementSystem = value;
                multiChartControl.MeasurementSystem = value;

            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AngularUnit AngularUnits
        {
            get => mAngularUnits;
            set
            {
                mAngularUnits = value;
                multiChartControl.AngularUnits = mAngularUnits;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TrajectoryChartMode ChartMode
        {
            get => multiChartControl.ChartMode;
            set => multiChartControl.ChartMode = value;
        }

        public CompareForm()
        {
            InitializeComponent();
        }

        public void AddTrajectory(string name, TrajectoryPoint[] trajectory)
        {
            multiChartControl.AddTrajectory(name, trajectory);
        }

        public void RemoveLast()
        {
            multiChartControl.RemoveLast();
        }

        public void UpdateYToVisibleArea()
        {
            multiChartControl.UpdateYAxis();
        }
    }
}
