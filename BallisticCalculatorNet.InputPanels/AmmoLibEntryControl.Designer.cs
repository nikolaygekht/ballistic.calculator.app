
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
            BallisticCalculator.Ammunition ammunition1 = new BallisticCalculator.Ammunition();
            BallisticCalculatorNet.InputPanels.WinFormsFileNamePromptFactory winFormsFileNamePromptFactory1 = new BallisticCalculatorNet.InputPanels.WinFormsFileNamePromptFactory();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.ammoControl = new BallisticCalculatorNet.InputPanels.AmmoControl();
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
            this.textBoxName.Location = new System.Drawing.Point(178, 11);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(242, 31);
            this.textBoxName.TabIndex = 1;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(178, 50);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(118, 35);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(301, 50);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(118, 35);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // ammoControl
            // 
            this.ammoControl.Ammunition = ammunition1;
            this.ammoControl.CustomBallisticFile = "";
            this.ammoControl.Location = new System.Drawing.Point(8, 94);
            this.ammoControl.Margin = new System.Windows.Forms.Padding(5);
            this.ammoControl.MeasurementSystem = BallisticCalculatorNet.InputPanels.MeasurementSystem.Metric;
            this.ammoControl.Name = "ammoControl";
            this.ammoControl.PromptFactory = winFormsFileNamePromptFactory1;
            this.ammoControl.Size = new System.Drawing.Size(445, 318);
            this.ammoControl.TabIndex = 4;
            this.ammoControl.CustomTableChanged += new System.EventHandler(this.ammoControl_CustomTableChanged);
            this.ammoControl.Enter += new System.EventHandler(this.ammoControl1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // comboBoxCaliber
            // 
            this.comboBoxCaliber.FormattingEnabled = true;
            this.comboBoxCaliber.Location = new System.Drawing.Point(180, 417);
            this.comboBoxCaliber.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCaliber.Name = "comboBoxCaliber";
            this.comboBoxCaliber.Size = new System.Drawing.Size(242, 32);
            this.comboBoxCaliber.Sorted = true;
            this.comboBoxCaliber.TabIndex = 7;
            // 
            // comboBoxAmmoType
            // 
            this.comboBoxAmmoType.FormattingEnabled = true;
            this.comboBoxAmmoType.Location = new System.Drawing.Point(180, 459);
            this.comboBoxAmmoType.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAmmoType.Name = "comboBoxAmmoType";
            this.comboBoxAmmoType.Size = new System.Drawing.Size(242, 32);
            this.comboBoxAmmoType.Sorted = true;
            this.comboBoxAmmoType.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 421);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ammo Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 463);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Bullet Type";
            // 
            // measurementBarrelLength
            // 
            this.measurementBarrelLength.DecimalPoints = null;
            this.measurementBarrelLength.Increment = 1D;
            this.measurementBarrelLength.Location = new System.Drawing.Point(180, 501);
            this.measurementBarrelLength.Margin = new System.Windows.Forms.Padding(5);
            this.measurementBarrelLength.Maximum = 10000D;
            this.measurementBarrelLength.MaximumSize = new System.Drawing.Size(5120, 34);
            this.measurementBarrelLength.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Distance;
            this.measurementBarrelLength.Minimum = 0D;
            this.measurementBarrelLength.MinimumSize = new System.Drawing.Size(150, 34);
            this.measurementBarrelLength.Name = "measurementBarrelLength";
            this.measurementBarrelLength.Size = new System.Drawing.Size(242, 34);
            this.measurementBarrelLength.TabIndex = 11;
            this.measurementBarrelLength.TextValue = "mm";
            this.measurementBarrelLength.Unit = Gehtsoft.Measurements.DistanceUnit.Millimeter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 505);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Barrel Length";
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(180, 543);
            this.textBoxSource.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size(242, 31);
            this.textBoxSource.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 543);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Source";
            // 
            // AmmoLibEntryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
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
            this.Controls.Add(this.ammoControl);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.textBoxName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AmmoLibEntryControl";
            this.Size = new System.Drawing.Size(446, 597);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
        private AmmoControl ammoControl;
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
