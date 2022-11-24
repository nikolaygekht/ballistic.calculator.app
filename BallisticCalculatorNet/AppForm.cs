using BallisticCalculator.Serialization;
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
using System.IO;
using BallisticCalculatorNet.Api;

namespace BallisticCalculatorNet
{
    public partial class AppForm : Form, IExtensionHost
    {
        public AppForm()
        {
            InitializeComponent();
            SetupMenu();
            UpdateMenus();
            this.LoadFormState(Program.Configuration, "main", true);
        }

        private readonly TrajectoryForm safetyForm = new TrajectoryForm();

        private void SetupMenu()
        {
            menuMain.MdiWindowListItem = menuWindows;

            menuFile.DropDownOpening += (_, _) => UpdateMenus();
            menuView.DropDownOpening += (_, _) => UpdateMenus();

            menuFileNewImperial.Click += (_, _) => openNewTrajectory(MeasurementSystem.Imperial);
            menuFileNewMetric.Click += (_, _) => openNewTrajectory(MeasurementSystem.Metric);
            menuFileOpen.Click += (_, _) => Open();
            menuFileSave.Click += (_, _) => Save();
            menuFileSaveAs.Click += (_, _) => SaveAs();
            menuFileExportCsv.Click += (_, _) => ExportCsv();
            menuFileExit.Click += (_, _) => this.Close();

            menuViewEditParameters.Click += (_, _) => EditParams();
            
            menuViewSystemImperial.Click += (_, _) => (ActiveMdiChild as ITrajectoryDisplayForm ?? safetyForm).MeasurementSystem = MeasurementSystem.Imperial;
            menuViewSystemMetric.Click += (_, _) => (ActiveMdiChild as ITrajectoryDisplayForm ?? safetyForm).MeasurementSystem = MeasurementSystem.Metric;
            
            menuViewAngularMOA.Click += (_, _) => (ActiveMdiChild as ITrajectoryDisplayForm ?? safetyForm).AngularUnits = AngularUnit.MOA;
            menuViewAngularMils.Click += (_, _) => (ActiveMdiChild as ITrajectoryDisplayForm ?? safetyForm).AngularUnits = AngularUnit.Mil;
            menuViewAngularThousands.Click += (_, _) => (ActiveMdiChild as ITrajectoryDisplayForm ?? safetyForm).AngularUnits = AngularUnit.Thousand;
            menuViewAngularMRads.Click += (_, _) => (ActiveMdiChild as ITrajectoryDisplayForm ?? safetyForm).AngularUnits = AngularUnit.MRad;
            menuViewAngularInches.Click += (_, _) => (ActiveMdiChild as ITrajectoryDisplayForm ?? safetyForm).AngularUnits = AngularUnit.InchesPer100Yards;
            menuViewAngularCentimeters.Click += (_, _) => (ActiveMdiChild as ITrajectoryDisplayForm ?? safetyForm).AngularUnits = AngularUnit.CmPer100Meters;

            menuViewChartVelocity.Click += (_, _) => (ActiveMdiChild as IChartDisplayForm ?? safetyForm).ChartMode = TrajectoryChartMode.Velocity;
            menuViewChartMach.Click += (_, _) => (ActiveMdiChild as IChartDisplayForm ?? safetyForm).ChartMode = TrajectoryChartMode.Mach;
            menuViewChartDrop.Click += (_, _) => (ActiveMdiChild as IChartDisplayForm ?? safetyForm).ChartMode = TrajectoryChartMode.Drop;
            menuViewChartWindage.Click += (_, _) => (ActiveMdiChild as IChartDisplayForm ?? safetyForm).ChartMode = TrajectoryChartMode.Windage;
            menuViewChartEnergy.Click += (_, _) => (ActiveMdiChild as IChartDisplayForm ?? safetyForm).ChartMode = TrajectoryChartMode.Energy;

            menuViewShowTable.Click += (_, _) => (ActiveMdiChild as TrajectoryForm)?.ShowTable();
            menuViewShowChart.Click += (_, _) => (ActiveMdiChild as TrajectoryForm)?.ShowChart();
            menuViewShowReticle.Click += (_, _) => (ActiveMdiChild as TrajectoryForm)?.ShowReticle();

            menuViewChartZoomY.Click += (_, _) => (ActiveMdiChild as IChartDisplayForm)?.UpdateYToVisibleArea();

            menuViewCompareAdd.Click += (_, _) => AddToCompare();
            menuViewCompareRemoveLast.Click += (_, _) => RemoveLastCompare();

            menuWindowsTile.Click += (_, _) => this.LayoutMdi(MdiLayout.TileHorizontal);
            menuWindowsCascade.Click += (_, _) => this.LayoutMdi(MdiLayout.Cascade);

            menuHelpAbout.Click += (_, _) => About();

            if (Program.ExtensionsManager.Commands.Count == 0)
                menuMain.Items.Remove(menuExtensions);
            else
            {
                menuExtensions.DropDownItems.Clear();
                for (int i = 0; i < Program.ExtensionsManager.Commands.Count; i++)
                {
                    var command = Program.ExtensionsManager.Commands[i];
                    var item = new ToolStripMenuItem()
                    {
                        Name = $"extension{i}",
                        Text = command.DisplayName,
                        Size = new System.Drawing.Size(227, 34)
                    };

                    item.Click += (_, _) =>
                    {
                        using var executor = command.Create();
                        executor.Execute(this);
                    };
                    
                    menuExtensions.DropDownItems.Add(item);
                }
            }
        }

        private void UpdateMenus()
        {
            var active = this.ActiveMdiChild;
            var isTrajectoryForm = active is TrajectoryForm;
            var isTrajectoryDisplayForm = active is ITrajectoryDisplayForm;
            var trajectoryDisplayForm = active as ITrajectoryDisplayForm;
            var hasCompareForm = GetCompareForm() != null;

            var isChartContainter = active is IChartDisplayForm;
            var chartContainter = active as IChartDisplayForm;

            menuFileSave.Enabled = isTrajectoryForm;
            menuFileSaveAs.Enabled = isTrajectoryForm;
            menuFileExportCsv.Enabled = isTrajectoryForm;

            menuViewEditParameters.Enabled = isTrajectoryForm;

            menuViewSystemImperial.Enabled = isTrajectoryDisplayForm;
            menuViewSystemImperial.Checked = isTrajectoryDisplayForm && trajectoryDisplayForm.MeasurementSystem == MeasurementSystem.Imperial;
            menuViewSystemMetric.Enabled = isTrajectoryDisplayForm;
            menuViewSystemMetric.Checked = isTrajectoryDisplayForm && trajectoryDisplayForm.MeasurementSystem == MeasurementSystem.Metric;

            menuViewAngularMils.Enabled = isTrajectoryDisplayForm;
            menuViewAngularMils.Checked = isTrajectoryDisplayForm && trajectoryDisplayForm.AngularUnits == AngularUnit.Mil;
            menuViewAngularMOA.Enabled = isTrajectoryDisplayForm;
            menuViewAngularMOA.Checked = isTrajectoryDisplayForm && trajectoryDisplayForm.AngularUnits == AngularUnit.MOA;
            menuViewAngularThousands.Enabled = isTrajectoryDisplayForm;
            menuViewAngularThousands.Checked = isTrajectoryDisplayForm && trajectoryDisplayForm.AngularUnits == AngularUnit.Thousand;
            menuViewAngularMRads.Enabled = isTrajectoryDisplayForm;
            menuViewAngularMRads.Checked = isTrajectoryDisplayForm && trajectoryDisplayForm.AngularUnits == AngularUnit.MRad;
            menuViewAngularInches.Enabled = isTrajectoryDisplayForm;
            menuViewAngularInches.Checked = isTrajectoryDisplayForm && trajectoryDisplayForm.AngularUnits == AngularUnit.InchesPer100Yards;
            menuViewAngularCentimeters.Enabled = isTrajectoryDisplayForm;
            menuViewAngularCentimeters.Checked = isTrajectoryDisplayForm && trajectoryDisplayForm.AngularUnits == AngularUnit.CmPer100Meters;

            menuViewChartVelocity.Enabled = isChartContainter;
            menuViewChartMach.Enabled = isChartContainter;
            menuViewChartDrop.Enabled = isChartContainter;
            menuViewChartWindage.Enabled = isChartContainter;
            menuViewChartEnergy.Enabled = isChartContainter;

            menuViewChartZoomY.Enabled = isChartContainter;

            menuViewChartVelocity.Checked = isChartContainter && chartContainter.ChartMode == TrajectoryChartMode.Velocity;
            menuViewChartMach.Checked = isChartContainter && chartContainter.ChartMode == TrajectoryChartMode.Mach;
            menuViewChartDrop.Checked = isChartContainter && chartContainter.ChartMode == TrajectoryChartMode.Drop;
            menuViewChartWindage.Checked = isChartContainter && chartContainter.ChartMode == TrajectoryChartMode.Windage;
            menuViewChartEnergy.Checked = isChartContainter && chartContainter.ChartMode == TrajectoryChartMode.Energy;

            menuViewShowChart.Enabled = isTrajectoryForm;
            menuViewShowTable.Enabled = isTrajectoryForm;
            menuViewShowReticle.Enabled = isTrajectoryForm;

            menuViewCompareAdd.Enabled = isTrajectoryForm;
            menuViewCompareRemoveLast.Enabled = hasCompareForm;
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
                UpdateMenus();
            }
        }

        private void Open()
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "Ballistic Calculator files (*.trajectory)|*.trajectory|All files (*.*)|*.*",
                FilterIndex = 1,
                CheckFileExists = true,
            };

            if (Program.Configuration["datafolder"] != null)
                dialog.InitialDirectory = Program.Configuration["datafolder"];
            else
                dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
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
                    UpdateMenus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Can't save the file {dialog.FileName}\r\nError: {ex.Message}\r\nTo log the error details enable the warning log level and try operation again");
                    ControlConfiguration.Logger?.Warning(ex, $"Saving file '{dialog.FileName}' failed");
                }

            }
        }

        private void Save()
        {
            if (this.ActiveMdiChild is not TrajectoryForm active)
                return;

            if (active == null)
                return;
            
            if (string.IsNullOrEmpty(active.FileName))
                SaveAs();
            else
                DoSave();           
        }

        private void SaveAs()
        {
            if (this.ActiveMdiChild is not TrajectoryForm active)
                return;

            var dialog = new SaveFileDialog()
            {
                Filter = "Ballistic Calculator files (*.trajectory)|*.trajectory|All files (*.*)|*.*",
                FilterIndex = 1,
                FileName = active.FileName,
                OverwritePrompt = true,
                CheckPathExists = true,
            };

            if (Program.Configuration["datafolder"] != null)
                dialog.InitialDirectory = Program.Configuration["datafolder"];
            else
                dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                active.FileName = dialog.FileName;
                DoSave();
            }
        }

        private void DoSave()
        {
            if (this.ActiveMdiChild is not TrajectoryForm active)
                return;

            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show($"Can't save the file {active.FileName}\r\nError: {ex.Message}\r\nTo log the error details enable the warning log level and try operation again");
                ControlConfiguration.Logger?.Warning(ex, $"Saving file '{active.FileName}' failed");
            }
        }

        private void EditParams()
        {
            if (this.ActiveMdiChild is not TrajectoryForm active)
                return;

            var shotParamsForm = new ShotParametersForm(active.MeasurementSystem, active.ShotData);
            if (shotParamsForm.ShowDialog(this) == DialogResult.OK)
                active.ShotData = shotParamsForm.ShotParameters;
        }

        private void About()
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog(this);
        }

        private void ExportCsv()
        {
            if (this.ActiveMdiChild is not TrajectoryForm active)
                return;

            var dialog = new SaveFileDialog()
            {
                Filter = "CSV files(*.csv)|*.csv|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                OverwritePrompt = true,
                CheckPathExists = true,
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using var fs = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                    using var stream = new StreamWriter(fs);
                    var controllers = new CvsExportController(active.Trajectory, active.MeasurementSystem, active.ShotData.Weapon.Sight, active.AngularUnits);
                    foreach (var s in controllers.Prepare())
                        stream.WriteLine(s);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Can't save the file {active.FileName}\r\nError: {ex.Message}\r\nTo log the error details enable the warning log level and try operation again");
                    ControlConfiguration.Logger?.Warning(ex, $"Saving file '{active.FileName}' failed");
                }
            }
        }

        private CompareForm GetCompareForm()
        {
            foreach (var form in this.MdiChildren)
            {
                if (form is CompareForm compareForm)
                    return compareForm;
            }
            return null;
        }

        private void AddToCompare()
        {
            if (this.ActiveMdiChild is not TrajectoryForm active)
                return;

            if (active == null || active.Trajectory == null)
                return;

            var compareForm = GetCompareForm() ?? 
                new CompareForm()
                {
                    MdiParent = this,
                    MeasurementSystem = active.MeasurementSystem,
                    AngularUnits = active.AngularUnits,
                    ChartMode = active.ChartMode,
                };
            
            var name = active.ShotData.Ammunition.Name;
            if (string.IsNullOrEmpty(name))
                name = "no name";
            compareForm.AddTrajectory(name, active.Trajectory);
            compareForm.Show();
        }

        private void RemoveLastCompare()
        {
            var compareForm = GetCompareForm();
            compareForm?.RemoveLast();
        }

        object IExtensionHost.ActiveForm()
        {
            return this.ActiveMdiChild;
        }

        object[] IExtensionHost.AllForms()
        {
            return MdiChildren.ToArray();
        }
    }
}
