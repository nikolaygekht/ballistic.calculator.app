namespace BallisticCalculatorNet.InputPanels
{
    partial class WeaponControl
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
            this.measurementSightHeight = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.measurementZeroDistance = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.comboBoxRiflingDirection = new System.Windows.Forms.ComboBox();
            this.measurementRifling = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.measurementHClick = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.measurementVClick = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Rifling = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // measurementSightHeight
            // 
            this.measurementSightHeight.DecimalPoints = null;
            this.measurementSightHeight.Increment = 1D;
            this.measurementSightHeight.Location = new System.Drawing.Point(170, 4);
            this.measurementSightHeight.Margin = new System.Windows.Forms.Padding(4);
            this.measurementSightHeight.Maximum = 10000D;
            this.measurementSightHeight.MaximumSize = new System.Drawing.Size(5120, 34);
            this.measurementSightHeight.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Distance;
            this.measurementSightHeight.Minimum = -10000D;
            this.measurementSightHeight.MinimumSize = new System.Drawing.Size(150, 34);
            this.measurementSightHeight.Name = "measurementSightHeight";
            this.measurementSightHeight.Size = new System.Drawing.Size(261, 34);
            this.measurementSightHeight.TabIndex = 0;
            this.measurementSightHeight.TextValue = "m";
            this.measurementSightHeight.Unit = Gehtsoft.Measurements.DistanceUnit.Meter;
            // 
            // measurementZeroDistance
            // 
            this.measurementZeroDistance.DecimalPoints = null;
            this.measurementZeroDistance.Increment = 1D;
            this.measurementZeroDistance.Location = new System.Drawing.Point(170, 46);
            this.measurementZeroDistance.Margin = new System.Windows.Forms.Padding(4);
            this.measurementZeroDistance.Maximum = 10000D;
            this.measurementZeroDistance.MaximumSize = new System.Drawing.Size(5120, 34);
            this.measurementZeroDistance.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Distance;
            this.measurementZeroDistance.Minimum = -10000D;
            this.measurementZeroDistance.MinimumSize = new System.Drawing.Size(150, 34);
            this.measurementZeroDistance.Name = "measurementZeroDistance";
            this.measurementZeroDistance.Size = new System.Drawing.Size(261, 34);
            this.measurementZeroDistance.TabIndex = 1;
            this.measurementZeroDistance.TextValue = "m";
            this.measurementZeroDistance.Unit = Gehtsoft.Measurements.DistanceUnit.Meter;
            // 
            // comboBoxRiflingDirection
            // 
            this.comboBoxRiflingDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRiflingDirection.FormattingEnabled = true;
            this.comboBoxRiflingDirection.Items.AddRange(new object[] {
            "Not Set",
            "Left",
            "Right"});
            this.comboBoxRiflingDirection.Location = new System.Drawing.Point(170, 87);
            this.comboBoxRiflingDirection.Name = "comboBoxRiflingDirection";
            this.comboBoxRiflingDirection.Size = new System.Drawing.Size(261, 32);
            this.comboBoxRiflingDirection.TabIndex = 2;
            this.comboBoxRiflingDirection.SelectedIndexChanged += new System.EventHandler(this.comboBoxRiflingDirection_SelectedIndexChanged);
            // 
            // measurementRifling
            // 
            this.measurementRifling.DecimalPoints = null;
            this.measurementRifling.Increment = 1D;
            this.measurementRifling.Location = new System.Drawing.Point(170, 126);
            this.measurementRifling.Margin = new System.Windows.Forms.Padding(4);
            this.measurementRifling.Maximum = 10000D;
            this.measurementRifling.MaximumSize = new System.Drawing.Size(5120, 34);
            this.measurementRifling.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Distance;
            this.measurementRifling.Minimum = -10000D;
            this.measurementRifling.MinimumSize = new System.Drawing.Size(150, 34);
            this.measurementRifling.Name = "measurementRifling";
            this.measurementRifling.Size = new System.Drawing.Size(261, 34);
            this.measurementRifling.TabIndex = 3;
            this.measurementRifling.TextValue = "m";
            this.measurementRifling.Unit = Gehtsoft.Measurements.DistanceUnit.Meter;
            // 
            // measurementHClick
            // 
            this.measurementHClick.DecimalPoints = null;
            this.measurementHClick.Increment = 1D;
            this.measurementHClick.Location = new System.Drawing.Point(170, 168);
            this.measurementHClick.Margin = new System.Windows.Forms.Padding(4);
            this.measurementHClick.Maximum = 10000D;
            this.measurementHClick.MaximumSize = new System.Drawing.Size(5120, 34);
            this.measurementHClick.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Angular;
            this.measurementHClick.Minimum = -10000D;
            this.measurementHClick.MinimumSize = new System.Drawing.Size(150, 34);
            this.measurementHClick.Name = "measurementHClick";
            this.measurementHClick.Size = new System.Drawing.Size(261, 34);
            this.measurementHClick.TabIndex = 4;
            this.measurementHClick.TextValue = "mil";
            this.measurementHClick.Unit = Gehtsoft.Measurements.AngularUnit.Mil;
            // 
            // measurementVClick
            // 
            this.measurementVClick.DecimalPoints = null;
            this.measurementVClick.Increment = 1D;
            this.measurementVClick.Location = new System.Drawing.Point(170, 210);
            this.measurementVClick.Margin = new System.Windows.Forms.Padding(4);
            this.measurementVClick.Maximum = 10000D;
            this.measurementVClick.MaximumSize = new System.Drawing.Size(5120, 34);
            this.measurementVClick.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Angular;
            this.measurementVClick.Minimum = -10000D;
            this.measurementVClick.MinimumSize = new System.Drawing.Size(150, 34);
            this.measurementVClick.Name = "measurementVClick";
            this.measurementVClick.Size = new System.Drawing.Size(261, 34);
            this.measurementVClick.TabIndex = 5;
            this.measurementVClick.TextValue = "mil";
            this.measurementVClick.Unit = Gehtsoft.Measurements.AngularUnit.Mil;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sight Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Zero Distance";
            // 
            // Rifling
            // 
            this.Rifling.AutoSize = true;
            this.Rifling.Location = new System.Drawing.Point(3, 92);
            this.Rifling.Name = "Rifling";
            this.Rifling.Size = new System.Drawing.Size(60, 24);
            this.Rifling.TabIndex = 8;
            this.Rifling.Text = "Rifling";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Rifling Step";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Horizontal Click";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Vertical Click";
            // 
            // WeaponControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Rifling);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.measurementVClick);
            this.Controls.Add(this.measurementHClick);
            this.Controls.Add(this.measurementRifling);
            this.Controls.Add(this.comboBoxRiflingDirection);
            this.Controls.Add(this.measurementZeroDistance);
            this.Controls.Add(this.measurementSightHeight);
            this.Name = "WeaponControl";
            this.Size = new System.Drawing.Size(435, 255);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MeasurementControl.MeasurementControl measurementSightHeight;
        private MeasurementControl.MeasurementControl measurementZeroDistance;
        private System.Windows.Forms.ComboBox comboBoxRiflingDirection;
        private MeasurementControl.MeasurementControl measurementRifling;
        private MeasurementControl.MeasurementControl measurementHClick;
        private MeasurementControl.MeasurementControl measurementVClick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Rifling;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
