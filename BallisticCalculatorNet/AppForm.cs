using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallisticCalculatorNet.Common;
using BallisticCalculatorNet.InputPanels;

namespace BallisticCalculatorNet
{
    public partial class AppForm : Form
    {
        public AppForm()
        {
            InitializeComponent();
            SetupMenu();
            this.LoadFormState(Program.Configuration, "main", true);
        }

        private void SetupMenu()
        {
            menuMain.MdiWindowListItem = menuWindows;

            menuFileNewImperial.Click += (_, _) => openNewTrajectory(MeasurementSystem.Imperial);
            menuFileNewMetric.Click += (_, _) => openNewTrajectory(MeasurementSystem.Metric);
            menuFileExit.Click += (_, _) => this.Close();

            menuWindowsTile.Click += (_, _) => this.LayoutMdi(MdiLayout.TileHorizontal);
            menuWindowsCascade.Click += (_, _) => this.LayoutMdi(MdiLayout.Cascade);
        }

        private void AppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveFormState(Program.Configuration, "main");
        }

        private void openNewTrajectory(MeasurementSystem measurementSystem)
        {
            var shotParamsForm = new ShotParametersForm(measurementSystem);
            if (shotParamsForm.ShowDialog(this) == DialogResult.OK)
            {
                var shotParams = shotParamsForm.ShotParameters;
                var trajectoryWindow = new TrajectoryForm()
                {
                    MeasurementSystem = measurementSystem,
                    ShotData = shotParams,
                    MdiParent = this,
                };
                trajectoryWindow.Show();
            }
        }
    }
}
