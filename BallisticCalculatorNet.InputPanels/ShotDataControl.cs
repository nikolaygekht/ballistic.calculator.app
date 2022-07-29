using BallisticCalculator;
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
    public partial class ShotDataControl : UserControl
    {
        public ShotDataControl()
        {
            InitializeComponent();
            
            //panel weapon will populate and gather data to zero panels
            panelWeapon.ZeroAmmunition = panelZeroAmmo;
            panelWeapon.ZeroAtmosphere = panelZeroWeather;

            panelParameters.WeaponControl = panelWeapon;
            UpdateSystem();
        }

        private MeasurementSystem mMeasurementSystem = MeasurementSystem.Metric;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MeasurementSystem MeasurementSystem
        {
            get => mMeasurementSystem;
            set
            {
                mMeasurementSystem = value;
                UpdateSystem();
            }
        }

        private void UpdateSystem()
        {
            panelShotAmmo.MeasurementSystem = mMeasurementSystem;
            panelShotWeather.MeasurementSystem = mMeasurementSystem;
            panelWinds.MeasurementSystem = mMeasurementSystem;
            panelWeapon.MeasurementSystem = mMeasurementSystem; 
            panelParameters.MeasurementSystem = mMeasurementSystem;
            
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ShotData ShotData
        {
            get
            {
                return new ShotData()
                {
                    Ammunition = panelShotAmmo.LibraryEntry,
                    Atmosphere = panelShotWeather.Atmosphere,
                    Wind = panelWinds.Winds,
                    Weapon = panelWeapon.Rifle,
                    Parameters = panelParameters.Parameters,
                    
                };
            }
            set
            {

                panelShotAmmo.LibraryEntry = value.Ammunition;
                panelShotWeather.Atmosphere = value.Atmosphere;
                panelWinds.Winds = value.Wind;
                panelWeapon.Rifle = value.Weapon;
                panelParameters.Parameters = value.Parameters;
            }
        }

        public event EventHandler CalculateRequested;

        private void panelParameters_CalculateRequested(object sender, EventArgs e)
        {
            CalculateRequested?.Invoke(this, e);
        }
    }
}
