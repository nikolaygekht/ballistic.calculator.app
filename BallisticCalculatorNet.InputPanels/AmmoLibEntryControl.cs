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
            comboBoxAmmoType.Items.Add("FMJ");
            comboBoxAmmoType.Items.Add("HP");
            comboBoxAmmoType.Items.Add("AP");
            comboBoxAmmoType.Items.Add("HPBT");
            comboBoxAmmoType.Items.Add("SP");
            comboBoxAmmoType.Items.Add("API");
            comboBoxAmmoType.Items.Add("LRN");
            comboBoxAmmoType.Items.Add("WC");

            //rimfire
            comboBoxCaliber.Items.Add(".17 Hornet");
            comboBoxCaliber.Items.Add(".17 WMR");
            comboBoxCaliber.Items.Add(".22 LR");
            comboBoxCaliber.Items.Add(".22 WMR");

            //pistol/revolver
            comboBoxCaliber.Items.Add("25 ACP");
            comboBoxCaliber.Items.Add("32 ACP");
            comboBoxCaliber.Items.Add("380 ACP");
            comboBoxCaliber.Items.Add("45 ACP");
            comboBoxCaliber.Items.Add(".38 SPL");
            comboBoxCaliber.Items.Add("9x19mm");
            comboBoxCaliber.Items.Add("9x18mm");
            comboBoxCaliber.Items.Add(".357 Magnum");
            comboBoxCaliber.Items.Add("50 AE");
            comboBoxCaliber.Items.Add(".327 Magnum");
            comboBoxCaliber.Items.Add(".44 Magnum");
            comboBoxCaliber.Items.Add(".32 LC");
            comboBoxCaliber.Items.Add(".38 Super");
            comboBoxCaliber.Items.Add(".45 LC");
            comboBoxCaliber.Items.Add("4.6x30mm");
            comboBoxCaliber.Items.Add("5.7x28mm");
            comboBoxCaliber.Items.Add("7.62×25mm");
            comboBoxCaliber.Items.Add("7.62×38mmR");


            //rifle
            comboBoxCaliber.Items.Add("5.45×39mm");
            comboBoxCaliber.Items.Add("6.5mm Creedmoor");
            comboBoxCaliber.Items.Add("6.5mm Grendel");
            comboBoxCaliber.Items.Add("6.5×47mm Lapua");
            comboBoxCaliber.Items.Add("6.5×55mm Swedish");
            comboBoxCaliber.Items.Add("6.5×57mm Mauser");
            comboBoxCaliber.Items.Add("6×45mm");
            comboBoxCaliber.Items.Add("5.56×45mm NATO");
            comboBoxCaliber.Items.Add(".223 Remington");
            comboBoxCaliber.Items.Add("7.5×55mm Swiss");
            comboBoxCaliber.Items.Add("7.62×51mm NATO");
            comboBoxCaliber.Items.Add(".308 Winchester");
            comboBoxCaliber.Items.Add("7.62×54mmR");
            comboBoxCaliber.Items.Add("7.92×57mm Mauser");
            comboBoxCaliber.Items.Add("9.3×64mm Brenneke");
            comboBoxCaliber.Items.Add("9.3×57mm Mauser");
            comboBoxCaliber.Items.Add(".338 Lapua Magnum");
            comboBoxCaliber.Items.Add(".50 BMG");
        }

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

        public AmmunitionLibraryEntry LibraryEntry
        {
            get
            {
                AmmunitionLibraryEntry ale = new AmmunitionLibraryEntry()
                {
                    Ammunition = ammoControl.Ammunition,
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
                    ammoControl.Ammunition = value.Ammunition;
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
            ammoControl.Clear();
            textBoxName.Text = "";
            textBoxSource.Text = "";
            comboBoxAmmoType.Text = "";
            comboBoxCaliber.Text = "";
        }

        private void ammoControl_CustomTableChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text) &&
                ammoControl.CustomBallistic != null)
                textBoxName.Text = ammoControl.CustomBallistic.Ammunition.Name;
        }
    }
}
