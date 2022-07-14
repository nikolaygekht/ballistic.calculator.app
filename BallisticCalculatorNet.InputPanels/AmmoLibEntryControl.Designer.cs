
namespace BallisticCalculatorNet.InputPanels
{
    partial class AmmoLibEntryControl
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
            BallisticCalculator.Ammunition ammunition2 = new BallisticCalculator.Ammunition();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.ammoControl1 = new BallisticCalculatorNet.InputPanels.AmmoControl();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCaliber = new System.Windows.Forms.ComboBox();
            this.comboBoxAmmoType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.measurementBarrelLength = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(133, 182);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(194, 27);
            this.textBoxName.TabIndex = 2;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(133, 215);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(94, 29);
            this.buttonLoad.TabIndex = 3;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(233, 215);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 29);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // ammoControl1
            // 
            this.ammoControl1.Ammunition = ammunition2;
            this.ammoControl1.Location = new System.Drawing.Point(0, 0);
            this.ammoControl1.MeasurementSystem = BallisticCalculatorNet.InputPanels.MeasurementSystem.Metric;
            this.ammoControl1.Name = "ammoControl1";
            this.ammoControl1.Size = new System.Drawing.Size(416, 176);
            this.ammoControl1.TabIndex = 1;
            this.ammoControl1.Enter += new System.EventHandler(this.ammoControl1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // comboBoxCaliber
            // 
            this.comboBoxCaliber.FormattingEnabled = true;
            this.comboBoxCaliber.Location = new System.Drawing.Point(133, 251);
            this.comboBoxCaliber.Name = "comboBoxCaliber";
            this.comboBoxCaliber.Size = new System.Drawing.Size(194, 28);
            this.comboBoxCaliber.TabIndex = 6;
            // 
            // comboBoxAmmoType
            // 
            this.comboBoxAmmoType.FormattingEnabled = true;
            this.comboBoxAmmoType.Location = new System.Drawing.Point(133, 286);
            this.comboBoxAmmoType.Name = "comboBoxAmmoType";
            this.comboBoxAmmoType.Size = new System.Drawing.Size(194, 28);
            this.comboBoxAmmoType.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ammo Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "BulletType";
            // 
            // measurementBarrelLength
            // 
            this.measurementBarrelLength.DecimalPoints = null;
            this.measurementBarrelLength.Increment = 1D;
            this.measurementBarrelLength.Location = new System.Drawing.Point(133, 321);
            this.measurementBarrelLength.Maximum = 10000D;
            this.measurementBarrelLength.MaximumSize = new System.Drawing.Size(4096, 28);
            this.measurementBarrelLength.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Distance;
            this.measurementBarrelLength.Minimum = 0D;
            this.measurementBarrelLength.MinimumSize = new System.Drawing.Size(120, 28);
            this.measurementBarrelLength.Name = "measurementBarrelLength";
            this.measurementBarrelLength.Size = new System.Drawing.Size(194, 28);
            this.measurementBarrelLength.TabIndex = 10;
            this.measurementBarrelLength.TextValue = "mm";
            this.measurementBarrelLength.Unit = Gehtsoft.Measurements.DistanceUnit.Millimeter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Barrel Length";
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(133, 356);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size(194, 27);
            this.textBoxSource.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 356);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Source";
            // 
            // AmmoLibEntryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxSource);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.measurementBarrelLength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxAmmoType);
            this.Controls.Add(this.comboBoxCaliber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ammoControl1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.textBoxName);
            this.Name = "AmmoLibEntryControl";
            this.Size = new System.Drawing.Size(347, 401);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
        private AmmoControl ammoControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCaliber;
        private System.Windows.Forms.ComboBox comboBoxAmmoType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MeasurementControl.MeasurementControl measurementBarrelLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Label label5;
    }
}
