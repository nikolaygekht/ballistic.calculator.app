namespace BallisticCalculatorNet.InputPanels
{
    partial class ShotDataControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.panelShotAmmo = new BallisticCalculatorNet.InputPanels.AmmoLibEntryControl();
            this.panelShotWeather = new BallisticCalculatorNet.InputPanels.AtmosphereControl();
            this.panelWinds = new BallisticCalculatorNet.InputPanels.MultiWindControl();
            this.panelWeapon = new BallisticCalculatorNet.InputPanels.WeaponControl();
            this.panelZeroAmmo = new BallisticCalculatorNet.InputPanels.ZeroAmmunitionControl();
            this.panelZeroWeather = new BallisticCalculatorNet.InputPanels.ZeroAtmosphereControl();
            this.panelParameters = new BallisticCalculatorNet.InputPanels.ParametersControl();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Controls.Add(this.tabPage6);
            this.tabControl.Controls.Add(this.tabPage7);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(611, 609);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelShotAmmo);
            this.tabPage1.Location = new System.Drawing.Point(4, 62);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(603, 543);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ammunition";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panelShotWeather);
            this.tabPage2.Location = new System.Drawing.Point(4, 62);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(603, 543);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Weather";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panelWinds);
            this.tabPage3.Location = new System.Drawing.Point(4, 62);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(603, 543);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Wind(s)";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panelWeapon);
            this.tabPage4.Location = new System.Drawing.Point(4, 62);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(603, 543);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Rifle";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.panelZeroAmmo);
            this.tabPage5.Location = new System.Drawing.Point(4, 62);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(603, 543);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Zeroing Ammo";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panelZeroWeather);
            this.tabPage6.Location = new System.Drawing.Point(4, 62);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(603, 543);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Zeroing Weather";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.panelParameters);
            this.tabPage7.Location = new System.Drawing.Point(4, 62);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(603, 543);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Parameters";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // panelShotAmmo
            // 
            this.panelShotAmmo.AutoScroll = true;
            this.panelShotAmmo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShotAmmo.Location = new System.Drawing.Point(3, 3);
            this.panelShotAmmo.Margin = new System.Windows.Forms.Padding(4);
            this.panelShotAmmo.MeasurementSystem = BallisticCalculatorNet.InputPanels.MeasurementSystem.Metric;
            this.panelShotAmmo.Name = "panelShotAmmo";
            this.panelShotAmmo.Size = new System.Drawing.Size(597, 537);
            this.panelShotAmmo.TabIndex = 0;
            // 
            // panelShotWeather
            // 
            this.panelShotWeather.AutoScroll = true;
            this.panelShotWeather.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShotWeather.Location = new System.Drawing.Point(3, 3);
            this.panelShotWeather.Name = "panelShotWeather";
            this.panelShotWeather.Size = new System.Drawing.Size(597, 537);
            this.panelShotWeather.TabIndex = 0;
            // 
            // panelWinds
            // 
            this.panelWinds.AutoScroll = true;
            this.panelWinds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWinds.Location = new System.Drawing.Point(0, 0);
            this.panelWinds.Name = "panelWinds";
            this.panelWinds.Size = new System.Drawing.Size(603, 543);
            this.panelWinds.TabIndex = 0;
            this.panelWinds.Winds = null;
            // 
            // panelWeapon
            // 
            this.panelWeapon.AutoScroll = true;
            this.panelWeapon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWeapon.Location = new System.Drawing.Point(0, 0);
            this.panelWeapon.Name = "panelWeapon";
            this.panelWeapon.Size = new System.Drawing.Size(603, 543);
            this.panelWeapon.TabIndex = 0;
            // 
            // panelZeroAmmo
            // 
            this.panelZeroAmmo.AutoScroll = true;
            this.panelZeroAmmo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelZeroAmmo.Location = new System.Drawing.Point(0, 0);
            this.panelZeroAmmo.Name = "panelZeroAmmo";
            this.panelZeroAmmo.Size = new System.Drawing.Size(603, 543);
            this.panelZeroAmmo.TabIndex = 0;
            // 
            // panelZeroWeather
            // 
            this.panelZeroWeather.AutoScroll = true;
            this.panelZeroWeather.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelZeroWeather.Location = new System.Drawing.Point(0, 0);
            this.panelZeroWeather.Name = "panelZeroWeather";
            this.panelZeroWeather.Size = new System.Drawing.Size(603, 543);
            this.panelZeroWeather.TabIndex = 0;
            // 
            // panelParameters
            // 
            this.panelParameters.AutoScroll = true;
            this.panelParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParameters.Location = new System.Drawing.Point(0, 0);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(603, 543);
            this.panelParameters.TabIndex = 0;
            this.panelParameters.CalculateRequested += new System.EventHandler(this.panelParameters_CalculateRequested);
            // 
            // ShotDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "ShotDataControl";
            this.Size = new System.Drawing.Size(611, 609);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private AmmoLibEntryControl panelShotAmmo;
        private AtmosphereControl panelShotWeather;
        private MultiWindControl panelWinds;
        private WeaponControl panelWeapon;
        private ZeroAmmunitionControl panelZeroAmmo;
        private ZeroAtmosphereControl panelZeroWeather;
        private ParametersControl panelParameters;
    }
}
