namespace BallisticCalculatorNet.InputPanels
{
    partial class ParametersControl
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
            this.measurementDistance = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.measurementStep = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.measurementShotAngle = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.textBoxClicks = new System.Windows.Forms.TextBox();
            this.buttonClicksSet = new System.Windows.Forms.Button();
            this.labelMaximumRange = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // measurementDistance
            // 
            this.measurementDistance.DecimalPoints = null;
            this.measurementDistance.Increment = 1D;
            this.measurementDistance.Location = new System.Drawing.Point(170, 4);
            this.measurementDistance.Margin = new System.Windows.Forms.Padding(4);
            this.measurementDistance.Maximum = 10000D;
            this.measurementDistance.MaximumSize = new System.Drawing.Size(5120, 34);
            this.measurementDistance.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Distance;
            this.measurementDistance.Minimum = -10000D;
            this.measurementDistance.MinimumSize = new System.Drawing.Size(150, 34);
            this.measurementDistance.Name = "measurementDistance";
            this.measurementDistance.Size = new System.Drawing.Size(261, 34);
            this.measurementDistance.TabIndex = 0;
            this.measurementDistance.TextValue = "m";
            this.measurementDistance.Unit = Gehtsoft.Measurements.DistanceUnit.Meter;
            // 
            // measurementStep
            // 
            this.measurementStep.DecimalPoints = null;
            this.measurementStep.Increment = 1D;
            this.measurementStep.Location = new System.Drawing.Point(170, 46);
            this.measurementStep.Margin = new System.Windows.Forms.Padding(4);
            this.measurementStep.Maximum = 10000D;
            this.measurementStep.MaximumSize = new System.Drawing.Size(5120, 34);
            this.measurementStep.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Distance;
            this.measurementStep.Minimum = -10000D;
            this.measurementStep.MinimumSize = new System.Drawing.Size(150, 34);
            this.measurementStep.Name = "measurementStep";
            this.measurementStep.Size = new System.Drawing.Size(261, 34);
            this.measurementStep.TabIndex = 1;
            this.measurementStep.TextValue = "m";
            this.measurementStep.Unit = Gehtsoft.Measurements.DistanceUnit.Meter;
            // 
            // measurementShotAngle
            // 
            this.measurementShotAngle.DecimalPoints = null;
            this.measurementShotAngle.Increment = 1D;
            this.measurementShotAngle.Location = new System.Drawing.Point(170, 88);
            this.measurementShotAngle.Margin = new System.Windows.Forms.Padding(4);
            this.measurementShotAngle.Maximum = 10000D;
            this.measurementShotAngle.MaximumSize = new System.Drawing.Size(5120, 34);
            this.measurementShotAngle.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Angular;
            this.measurementShotAngle.Minimum = -10000D;
            this.measurementShotAngle.MinimumSize = new System.Drawing.Size(150, 34);
            this.measurementShotAngle.Name = "measurementShotAngle";
            this.measurementShotAngle.Size = new System.Drawing.Size(261, 34);
            this.measurementShotAngle.TabIndex = 2;
            this.measurementShotAngle.TextValue = "mil";
            this.measurementShotAngle.Unit = Gehtsoft.Measurements.AngularUnit.Mil;
            // 
            // textBoxClicks
            // 
            this.textBoxClicks.Location = new System.Drawing.Point(170, 129);
            this.textBoxClicks.Name = "textBoxClicks";
            this.textBoxClicks.Size = new System.Drawing.Size(157, 31);
            this.textBoxClicks.TabIndex = 3;
            this.textBoxClicks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonClicksSet
            // 
            this.buttonClicksSet.Location = new System.Drawing.Point(333, 129);
            this.buttonClicksSet.Name = "buttonClicksSet";
            this.buttonClicksSet.Size = new System.Drawing.Size(98, 31);
            this.buttonClicksSet.TabIndex = 4;
            this.buttonClicksSet.Text = "Set";
            this.buttonClicksSet.UseVisualStyleBackColor = true;
            this.buttonClicksSet.Click += new System.EventHandler(this.buttonClicksSet_Click);
            // 
            // labelMaximumRange
            // 
            this.labelMaximumRange.AutoSize = true;
            this.labelMaximumRange.Location = new System.Drawing.Point(3, 11);
            this.labelMaximumRange.Name = "labelMaximumRange";
            this.labelMaximumRange.Size = new System.Drawing.Size(144, 24);
            this.labelMaximumRange.TabIndex = 5;
            this.labelMaximumRange.Text = "Maximum Range";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Step";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Angle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Angle as clicks";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(170, 166);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(112, 34);
            this.buttonCalculate.TabIndex = 9;
            this.buttonCalculate.Text = "Calculate!";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // ParametersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMaximumRange);
            this.Controls.Add(this.buttonClicksSet);
            this.Controls.Add(this.textBoxClicks);
            this.Controls.Add(this.measurementShotAngle);
            this.Controls.Add(this.measurementStep);
            this.Controls.Add(this.measurementDistance);
            this.Name = "ParametersControl";
            this.Size = new System.Drawing.Size(435, 217);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MeasurementControl.MeasurementControl measurementDistance;
        private MeasurementControl.MeasurementControl measurementStep;
        private MeasurementControl.MeasurementControl measurementShotAngle;
        private System.Windows.Forms.TextBox textBoxClicks;
        private System.Windows.Forms.Button buttonClicksSet;
        private System.Windows.Forms.Label labelMaximumRange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCalculate;
    }
}
