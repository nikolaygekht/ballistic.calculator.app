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
            this.numericVerticalCorrection = new System.Windows.Forms.NumericUpDown();
            this.numericHorizontalCorrection = new System.Windows.Forms.NumericUpDown();
            this.labelMaximumRange = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelVerticalCorrection = new System.Windows.Forms.Label();
            this.labelHorizontalCorrection = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericVerticalCorrection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHorizontalCorrection)).BeginInit();
            this.SuspendLayout();
            // 
            // measurementDistance
            // 
            this.measurementDistance.DecimalPoints = null;
            this.measurementDistance.Increment = 1D;
            this.measurementDistance.Location = new System.Drawing.Point(170, 4);
            this.measurementDistance.Margin = new System.Windows.Forms.Padding(4);
            this.measurementDistance.Maximum = 10000D;
            this.measurementDistance.MaximumSize = new System.Drawing.Size(5120, 35);
            this.measurementDistance.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Distance;
            this.measurementDistance.Minimum = -10000D;
            this.measurementDistance.MinimumSize = new System.Drawing.Size(150, 35);
            this.measurementDistance.Name = "measurementDistance";
            this.measurementDistance.Size = new System.Drawing.Size(261, 35);
            this.measurementDistance.TabIndex = 0;
            this.measurementDistance.TextValue = "m";
            this.measurementDistance.Unit = Gehtsoft.Measurements.DistanceUnit.Meter;
            // 
            // measurementStep
            // 
            this.measurementStep.DecimalPoints = null;
            this.measurementStep.Increment = 1D;
            this.measurementStep.Location = new System.Drawing.Point(170, 48);
            this.measurementStep.Margin = new System.Windows.Forms.Padding(4);
            this.measurementStep.Maximum = 10000D;
            this.measurementStep.MaximumSize = new System.Drawing.Size(5120, 35);
            this.measurementStep.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Distance;
            this.measurementStep.Minimum = -10000D;
            this.measurementStep.MinimumSize = new System.Drawing.Size(150, 35);
            this.measurementStep.Name = "measurementStep";
            this.measurementStep.Size = new System.Drawing.Size(261, 35);
            this.measurementStep.TabIndex = 1;
            this.measurementStep.TextValue = "m";
            this.measurementStep.Unit = Gehtsoft.Measurements.DistanceUnit.Meter;
            // 
            // measurementShotAngle
            // 
            this.measurementShotAngle.DecimalPoints = null;
            this.measurementShotAngle.Increment = 1D;
            this.measurementShotAngle.Location = new System.Drawing.Point(170, 92);
            this.measurementShotAngle.Margin = new System.Windows.Forms.Padding(4);
            this.measurementShotAngle.Maximum = 10000D;
            this.measurementShotAngle.MaximumSize = new System.Drawing.Size(5120, 35);
            this.measurementShotAngle.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Angular;
            this.measurementShotAngle.Minimum = -10000D;
            this.measurementShotAngle.MinimumSize = new System.Drawing.Size(150, 35);
            this.measurementShotAngle.Name = "measurementShotAngle";
            this.measurementShotAngle.Size = new System.Drawing.Size(261, 35);
            this.measurementShotAngle.TabIndex = 2;
            this.measurementShotAngle.TextValue = "mil";
            this.measurementShotAngle.Unit = Gehtsoft.Measurements.AngularUnit.Mil;
            //
            // numericVerticalCorrection
            //
            this.numericVerticalCorrection.Location = new System.Drawing.Point(170, 134);
            this.numericVerticalCorrection.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericVerticalCorrection.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericVerticalCorrection.Name = "numericVerticalCorrection";
            this.numericVerticalCorrection.Size = new System.Drawing.Size(261, 31);
            this.numericVerticalCorrection.TabIndex = 3;
            this.numericVerticalCorrection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // numericHorizontalCorrection
            //
            this.numericHorizontalCorrection.Location = new System.Drawing.Point(170, 176);
            this.numericHorizontalCorrection.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericHorizontalCorrection.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericHorizontalCorrection.Name = "numericHorizontalCorrection";
            this.numericHorizontalCorrection.Size = new System.Drawing.Size(261, 31);
            this.numericHorizontalCorrection.TabIndex = 4;
            this.numericHorizontalCorrection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelMaximumRange
            // 
            this.labelMaximumRange.AutoSize = true;
            this.labelMaximumRange.Location = new System.Drawing.Point(3, 11);
            this.labelMaximumRange.Name = "labelMaximumRange";
            this.labelMaximumRange.Size = new System.Drawing.Size(146, 25);
            this.labelMaximumRange.TabIndex = 5;
            this.labelMaximumRange.Text = "Maximum Range";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Step";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Angle";
            //
            // labelVerticalCorrection
            //
            this.labelVerticalCorrection.AutoSize = true;
            this.labelVerticalCorrection.Location = new System.Drawing.Point(3, 141);
            this.labelVerticalCorrection.Name = "labelVerticalCorrection";
            this.labelVerticalCorrection.Size = new System.Drawing.Size(126, 25);
            this.labelVerticalCorrection.TabIndex = 8;
            this.labelVerticalCorrection.Text = "V-clicks";
            //
            // labelHorizontalCorrection
            //
            this.labelHorizontalCorrection.AutoSize = true;
            this.labelHorizontalCorrection.Location = new System.Drawing.Point(3, 183);
            this.labelHorizontalCorrection.Name = "labelHorizontalCorrection";
            this.labelHorizontalCorrection.Size = new System.Drawing.Size(126, 25);
            this.labelHorizontalCorrection.TabIndex = 9;
            this.labelHorizontalCorrection.Text = "H-clicks";
            // 
            // ParametersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.labelHorizontalCorrection);
            this.Controls.Add(this.labelVerticalCorrection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMaximumRange);
            this.Controls.Add(this.numericHorizontalCorrection);
            this.Controls.Add(this.numericVerticalCorrection);
            this.Controls.Add(this.measurementShotAngle);
            this.Controls.Add(this.measurementStep);
            this.Controls.Add(this.measurementDistance);
            this.Name = "ParametersControl";
            this.Size = new System.Drawing.Size(435, 268);
            ((System.ComponentModel.ISupportInitialize)(this.numericVerticalCorrection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHorizontalCorrection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MeasurementControl.MeasurementControl measurementDistance;
        private MeasurementControl.MeasurementControl measurementStep;
        private MeasurementControl.MeasurementControl measurementShotAngle;
        private System.Windows.Forms.NumericUpDown numericVerticalCorrection;
        private System.Windows.Forms.NumericUpDown numericHorizontalCorrection;
        private System.Windows.Forms.Label labelMaximumRange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelVerticalCorrection;
        private System.Windows.Forms.Label labelHorizontalCorrection;
    }
}
