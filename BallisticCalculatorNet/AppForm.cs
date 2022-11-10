﻿using BallisticCalculator.Serialization;
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
using BallisticCalculatorNet.Utils;
using Gehtsoft.Measurements;
using System.Xml;

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

            menuFile.DropDownOpening += (_, _) => SetupMenus();
            menuView.DropDownOpening += (_, _) => SetupMenus();

            menuFileNewImperial.Click += (_, _) => openNewTrajectory(MeasurementSystem.Imperial);
            menuFileNewMetric.Click += (_, _) => openNewTrajectory(MeasurementSystem.Metric);
            menuFileOpen.Click += (_, _) => Open();
            menuFileSave.Click += (_, _) => Save();
            menuFileSaveAs.Click += (_, _) => SaveAs();
            menuFileExit.Click += (_, _) => this.Close();

            menuViewEditParameters.Click += (_, _) => EditParams();
            menuViewSystemImperial.Click += (_, _) => (ActiveMdiChild as TrajectoryForm).MeasurementSystem = MeasurementSystem.Imperial;
            menuViewSystemMetric.Click += (_, _) => (ActiveMdiChild as TrajectoryForm).MeasurementSystem = MeasurementSystem.Metric;
            menuViewAngularMOA.Click += (_, _) => (ActiveMdiChild as TrajectoryForm).AngularUnits = AngularUnit.MOA;
            menuViewAngularMils.Click += (_, _) => (ActiveMdiChild as TrajectoryForm).AngularUnits = AngularUnit.Mil;
            menuViewAngularThousands.Click += (_, _) => (ActiveMdiChild as TrajectoryForm).AngularUnits = AngularUnit.Thousand;
            menuViewAngularMRads.Click += (_, _) => (ActiveMdiChild as TrajectoryForm).AngularUnits = AngularUnit.MRad;
            menuViewAngularInches.Click += (_, _) => (ActiveMdiChild as TrajectoryForm).AngularUnits = AngularUnit.InchesPer100Yards;
            menuViewAngularCentimeters.Click += (_, _) => (ActiveMdiChild as TrajectoryForm).AngularUnits = AngularUnit.CmPer100Meters;

            menuWindowsTile.Click += (_, _) => this.LayoutMdi(MdiLayout.TileHorizontal);
            menuWindowsCascade.Click += (_, _) => this.LayoutMdi(MdiLayout.Cascade);
        }

        private void SetupMenus()
        {
            var active = this.ActiveMdiChild;
            var isTrajectory = active is TrajectoryForm;
            var trajectoryForm = active as TrajectoryForm;

            menuFileSave.Enabled = isTrajectory;
            menuFileSaveAs.Enabled = isTrajectory;
            menuFileExportCsv.Enabled = isTrajectory;

            menuViewEditParameters.Enabled = isTrajectory;

            menuViewSystemImperial.Enabled = isTrajectory;
            menuViewSystemImperial.Checked = isTrajectory && trajectoryForm.MeasurementSystem == MeasurementSystem.Imperial;
            menuViewSystemMetric.Enabled = isTrajectory;
            menuViewSystemMetric.Checked = isTrajectory && trajectoryForm.MeasurementSystem == MeasurementSystem.Metric;

            menuViewAngularMils.Enabled = isTrajectory;
            menuViewAngularMils.Checked = isTrajectory && trajectoryForm.AngularUnits == AngularUnit.Mil;
            menuViewAngularMOA.Enabled = isTrajectory;
            menuViewAngularMOA.Checked = isTrajectory && trajectoryForm.AngularUnits == AngularUnit.MOA;
            menuViewAngularThousands.Enabled = isTrajectory;
            menuViewAngularThousands.Checked = isTrajectory && trajectoryForm.AngularUnits == AngularUnit.Thousand;
            menuViewAngularMRads.Enabled = isTrajectory;
            menuViewAngularMRads.Checked = isTrajectory && trajectoryForm.AngularUnits == AngularUnit.MRad;
            menuViewAngularInches.Enabled = isTrajectory;
            menuViewAngularInches.Checked = isTrajectory && trajectoryForm.AngularUnits == AngularUnit.InchesPer100Yards;
            menuViewAngularCentimeters.Enabled = isTrajectory;
            menuViewAngularCentimeters.Checked = isTrajectory && trajectoryForm.AngularUnits == AngularUnit.CmPer100Meters;
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

        private void Open()
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "Ballistic Calculator files (*.trajectory)|*.trajectory|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                CheckFileExists = true,
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                XmlDocument document = new XmlDocument();
                document.Load(dialog.FileName);
                var serializer = new BallisticXmlDeserializer();
                var data = serializer.Deserialize<TrajectoryFormState>(document.DocumentElement);
                var trajectoryWindow = new TrajectoryForm()
                {
                    AngularUnits = data.AngularUnits,
                    MeasurementSystem = data.MeasurementSystem,
                    ShotData = data.ShotData,
                    MdiParent = this,
                    FileName = dialog.FileName,
                };
                trajectoryWindow.Show();
            }
        }

        private void Save()
        {
            var active = this.ActiveMdiChild as TrajectoryForm;
            if (string.IsNullOrEmpty(active.FileName))
                SaveAs();
            else
                DoSave();           
        }

        private void SaveAs()
        {
            var active = this.ActiveMdiChild as TrajectoryForm;

            var dialog = new SaveFileDialog()
            {
                Filter = "Ballistic Calculator files (*.trajectory)|*.trajectory|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                FileName = active.FileName,
                OverwritePrompt = true,
                CheckPathExists = true,
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                active.FileName = dialog.FileName;
                DoSave();
            }
        }

        private void DoSave()
        {
            var active = this.ActiveMdiChild as TrajectoryForm;
            var state = new TrajectoryFormState()
            {
                ShotData = active.ShotData,
                AngularUnits = active.AngularUnits,
                MeasurementSystem = active.MeasurementSystem,
            };
            var serializer = new BallisticXmlSerializer();
            var root = serializer.Serialize(state);
            var document = root.OwnerDocument;
            document.AppendChild(root);
            document.Save(active.FileName);
        }

        private void EditParams()
        {
            var active = this.ActiveMdiChild as TrajectoryForm;
            var shotParamsForm = new ShotParametersForm(active.MeasurementSystem, active.ShotData);
            if (shotParamsForm.ShowDialog(this) == DialogResult.OK)
                active.ShotData = shotParamsForm.ShotParameters;
        }
    }
}
