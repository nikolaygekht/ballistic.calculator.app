using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallisticCalculator;
using BallisticCalculator.Data.Dictionary;
using BallisticCalculator.Serialization;
using BallisticCalculatorNet.Api;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.InputPanels
{
    public partial class AmmoLibEntryControl : UserControl
    {
        private readonly static AmmunitionTypeDictionary gAmmoTypes = AmmunitionTypeFactory.Create();

        public AmmoLibEntryControl()
        {
            InitializeComponent();

            foreach (var type in gAmmoTypes)
                comboBoxAmmoType.Items.Add(type.Abbreviation);
        }

        [Browsable(false)] 
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IFileNamePromptFactory PromptFactory { get; set; } = new WinFormsFileNamePromptFactory();

        public MeasurementSystem MeasurementSystem
        {
            get => ammoControl.MeasurementSystem;
            set
            {
                ammoControl.MeasurementSystem = value;
                if (value == MeasurementSystem.Metric)
                    measurementBarrelLength.ChangeUnit(DistanceUnit.Millimeter);
                else
                    measurementBarrelLength.ChangeUnit(DistanceUnit.Inch);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AmmunitionLibraryEntry LibraryEntry
        {
            get
            {
                AmmunitionLibraryEntry ale = new AmmunitionLibraryEntry()
                {
                    Ammunition = ammoControl.Ammunition,
                    Name = textBoxName.Text,
                    Source = textBoxSource.Text,
                    Caliber = textBoxCaliber.Text,
                    AmmunitionType = comboBoxAmmoType.Text,
                    BarrelLength = !measurementBarrelLength.IsEmpty ? measurementBarrelLength.ValueAsMeasurement<DistanceUnit>() : null
                };
                return ale;
            }
            set
            {
                if (value == null)
                    Clear();
                else
                {
                    ammoControl.Ammunition = value.Ammunition;
                    textBoxName.Text = value.Name ?? "";
                    textBoxSource.Text = value.Source ?? "";
                    comboBoxAmmoType.Text = value.AmmunitionType ?? "";
                    textBoxCaliber.Text = value.Caliber ?? "";
                    measurementBarrelLength.Value = value.BarrelLength;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Ammunition Ammunition
        {
            get => ammoControl.Ammunition;
            set => ammoControl.Ammunition = value;
        }

        private void ammoControl1_Enter(object sender, EventArgs e)
        {
            ammoControl.Focus();
        }

        private string mFileName = null;

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string fileName = null;
            try
            {
                var ammo = AmmunitionControlUtils.Load(this, PromptFactory, out fileName);
                if (ammo != null)
                {
                    mFileName = fileName;
                    LibraryEntry = ammo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Can't open the file {fileName}\r\nError: {ex.Message}\r\nTo log the error details enable the warning log level and try operation again");
                ControlConfiguration.Logger?.Warning(ex, $"Loading file '{fileName}' failed");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var dlg = PromptFactory.CreateSaveFileNamePrompt();
            dlg.Title = "Save ammunition";
            dlg.AddFilter("ammox", "Ammunition Library Entry");
            dlg.OverwritePrompt = true;
            dlg.CheckDirectoryExist = true;
            dlg.DefaultExtension = "ammox";
            if (!string.IsNullOrEmpty(mFileName))
                dlg.FileName = mFileName;
            if (dlg.AskName(this))
            {
                try
                {
                    BallisticXmlSerializer.SerializeToFile(LibraryEntry, dlg.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Can't save the file {dlg.FileName}\r\nError: {ex.Message}\r\nTo log the error details enable the warning log level and try operation again");
                    ControlConfiguration.Logger?.Warning(ex, $"Saving file '{dlg.FileName}' failed");
                }
            }
        }

        public void Clear()
        {
            ammoControl.Clear();
            textBoxName.Text = "";
            textBoxSource.Text = "";
            comboBoxAmmoType.Text = "";
            textBoxCaliber.Text = "";
        }

        private void ammoControl_CustomTableChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text) &&
                ammoControl.CustomBallistic != null)
                textBoxName.Text = ammoControl.CustomBallistic.Ammunition.Name;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ICaliberSelectorFactory CaliberSelectorFactory { get; set; } = new CaliberSelectorFactory();

        private void buttonCaliberSelect_Click(object sender, EventArgs e)
        {
            var selector = CaliberSelectorFactory.Create();
            if (selector.Select(this))
            {
                var ammo = selector.Caliber;
                textBoxCaliber.Text = ammo.Name;
                ammoControl.SetBulletDiameter(ammo.BulletDiameter);
            }
        }
    }
}
