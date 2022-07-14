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
using BallisticCalculator.Serialization;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.InputPanels
{
    public partial class AmmoLibEntryControl : UserControl
    {
        public AmmoLibEntryControl()
        {
            InitializeComponent();
        }

        public IFileNamePromptFactory PromptFactory { get; set; } = new WinFormsFileNamePromptFactory();

        public MeasurementSystem MeasurementSystem
        {
            get => ammoControl1.MeasurementSystem;
            set
            {
                ammoControl1.MeasurementSystem = value;
                if (value == MeasurementSystem.Metric)
                    measurementBarrelLength.ChangeUnit(DistanceUnit.Millimeter);
                else
                    measurementBarrelLength.ChangeUnit(DistanceUnit.Inch);
            }
        }

        public AmmunitionLibraryEntry LibraryEntry
        {
            get
            {
                AmmunitionLibraryEntry ale = new AmmunitionLibraryEntry()
                {
                    Ammunition = ammoControl1.Ammunition,
                    Name = textBoxName.Text,
                    Source = textBoxSource.Text,
                    Caliber = comboBoxCaliber.Text,
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
                    ammoControl1.Ammunition = value.Ammunition;
                    textBoxName.Text = value.Name ?? "";
                    textBoxSource.Text = value.Source ?? "";
                    comboBoxAmmoType.Text = value.AmmunitionType ?? "";
                    comboBoxCaliber.Text = value.Caliber ?? "";
                    measurementBarrelLength.Value = value.BarrelLength;
                }
            }
        }

        public Ammunition Ammunition
        {
            get => ammoControl1.Ammunition;
            set => ammoControl1.Ammunition = value;
        }

        private void ammoControl1_Enter(object sender, EventArgs e)
        {
            ammoControl1.Focus();
        }

        private string mFileName = null;

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            var dlg = PromptFactory.CreateOpenFileNamePrompt();
            dlg.Title = "Open ammunition";
            dlg.AddFilter("ammox", "Ammunition Library Entry");
            dlg.AddFilter("ammo", "Legacy Ammunition Library Entry");
            dlg.CheckFileExists = true;
            dlg.DefaultExtension = "ammox";
            if (dlg.AskName(this))
            {
                Clear();
                mFileName = dlg.FileName;
                if (mFileName.EndsWith(".ammo"))
                    LibraryEntry = BallisticXmlDeserializer.ReadLegacyAmmunitionLibraryEntryFromFile(dlg.FileName);
                else
                    LibraryEntry = BallisticXmlDeserializer.ReadFromFile<AmmunitionLibraryEntry>(dlg.FileName);
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
            dlg.FileName = mFileName;
            if (dlg.AskName(this))
                BallisticXmlSerializer.SerializeToFile(LibraryEntry, dlg.FileName);
        }

        public void Clear()
        {
            ammoControl1.Clear();
            textBoxName.Text = "";
            textBoxSource.Text = "";
            comboBoxAmmoType.Text = "";
            comboBoxCaliber.Text = "";
        }


    }
}
