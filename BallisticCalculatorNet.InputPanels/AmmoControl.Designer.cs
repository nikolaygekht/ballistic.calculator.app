
namespace BallisticCalculatorNet.InputPanels
{
    partial class AmmoControl
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
            this.measurementBulletWeight = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.measurementMuzzleVelocity = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxDimensions = new System.Windows.Forms.CheckBox();
            this.measurementDiameter = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.measurementLength = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.measurementControl1 = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.SuspendLayout();
            // 
            // measurementBulletWeight
            // 
            this.measurementBulletWeight.DecimalPoints = null;
            this.measurementBulletWeight.Increment = 1D;
            this.measurementBulletWeight.Location = new System.Drawing.Point(134, 4);
            this.measurementBulletWeight.Maximum = 1000D;
            this.measurementBulletWeight.MaximumSize = new System.Drawing.Size(4096, 28);
            this.measurementBulletWeight.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Weight;
            this.measurementBulletWeight.Minimum = 0D;
            this.measurementBulletWeight.MinimumSize = new System.Drawing.Size(120, 28);
            this.measurementBulletWeight.Name = "measurementBulletWeight";
            this.measurementBulletWeight.Size = new System.Drawing.Size(189, 28);
            this.measurementBulletWeight.TabIndex = 0;
            this.measurementBulletWeight.TextValue = "0gr";
            this.measurementBulletWeight.Unit = Gehtsoft.Measurements.WeightUnit.Grain;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Weight";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "BC";
            // 
            // measurementMuzzleVelocity
            // 
            this.measurementMuzzleVelocity.DecimalPoints = null;
            this.measurementMuzzleVelocity.Increment = 1D;
            this.measurementMuzzleVelocity.Location = new System.Drawing.Point(134, 72);
            this.measurementMuzzleVelocity.Maximum = 10000D;
            this.measurementMuzzleVelocity.MaximumSize = new System.Drawing.Size(4096, 28);
            this.measurementMuzzleVelocity.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Velocity;
            this.measurementMuzzleVelocity.Minimum = 0D;
            this.measurementMuzzleVelocity.MinimumSize = new System.Drawing.Size(120, 28);
            this.measurementMuzzleVelocity.Name = "measurementMuzzleVelocity";
            this.measurementMuzzleVelocity.Size = new System.Drawing.Size(189, 28);
            this.measurementMuzzleVelocity.TabIndex = 5;
            this.measurementMuzzleVelocity.TextValue = "m/s";
            this.measurementMuzzleVelocity.Unit = Gehtsoft.Measurements.VelocityUnit.MetersPerSecond;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Muzzle Velocity";
            // 
            // checkBoxDimensions
            // 
            this.checkBoxDimensions.AutoSize = true;
            this.checkBoxDimensions.Location = new System.Drawing.Point(4, 106);
            this.checkBoxDimensions.Name = "checkBoxDimensions";
            this.checkBoxDimensions.Size = new System.Drawing.Size(150, 24);
            this.checkBoxDimensions.TabIndex = 7;
            this.checkBoxDimensions.Text = "Bullet Dimensions";
            this.checkBoxDimensions.UseVisualStyleBackColor = true;
            this.checkBoxDimensions.CheckedChanged += new System.EventHandler(this.checkBoxDimensions_CheckedChanged);
            // 
            // measurementDiameter
            // 
            this.measurementDiameter.DecimalPoints = null;
            this.measurementDiameter.Increment = 1D;
            this.measurementDiameter.Location = new System.Drawing.Point(134, 133);
            this.measurementDiameter.Maximum = 10000D;
            this.measurementDiameter.MaximumSize = new System.Drawing.Size(4096, 28);
            this.measurementDiameter.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Distance;
            this.measurementDiameter.Minimum = -10000D;
            this.measurementDiameter.MinimumSize = new System.Drawing.Size(120, 28);
            this.measurementDiameter.Name = "measurementDiameter";
            this.measurementDiameter.Size = new System.Drawing.Size(189, 28);
            this.measurementDiameter.TabIndex = 8;
            this.measurementDiameter.TextValue = "m";
            this.measurementDiameter.Unit = Gehtsoft.Measurements.DistanceUnit.Meter;
            // 
            // measurementLength
            // 
            this.measurementLength.DecimalPoints = null;
            this.measurementLength.Increment = 1D;
            this.measurementLength.Location = new System.Drawing.Point(134, 167);
            this.measurementLength.Maximum = 10000D;
            this.measurementLength.MaximumSize = new System.Drawing.Size(4096, 28);
            this.measurementLength.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Distance;
            this.measurementLength.Minimum = -10000D;
            this.measurementLength.MinimumSize = new System.Drawing.Size(120, 28);
            this.measurementLength.Name = "measurementLength";
            this.measurementLength.Size = new System.Drawing.Size(189, 28);
            this.measurementLength.TabIndex = 9;
            this.measurementLength.TextValue = "m";
            this.measurementLength.Unit = Gehtsoft.Measurements.DistanceUnit.Meter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Bullet Diameter";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Bullet Length";
            // 
            // measurementControl1
            // 
            this.measurementControl1.DecimalPoints = null;
            this.measurementControl1.Increment = 0.001D;
            this.measurementControl1.Location = new System.Drawing.Point(134, 38);
            this.measurementControl1.Maximum = 2D;
            this.measurementControl1.MaximumSize = new System.Drawing.Size(4096, 28);
            this.measurementControl1.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.BallisticCoefficient;
            this.measurementControl1.Minimum = 0D;
            this.measurementControl1.MinimumSize = new System.Drawing.Size(120, 28);
            this.measurementControl1.Name = "measurementControl1";
            this.measurementControl1.Size = new System.Drawing.Size(189, 28);
            this.measurementControl1.TabIndex = 2;
            this.measurementControl1.TextValue = "0.5G1";
            this.measurementControl1.Unit = BallisticCalculator.DragTableId.G1;
            // 
            // AmmoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.measurementControl1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.measurementLength);
            this.Controls.Add(this.measurementDiameter);
            this.Controls.Add(this.checkBoxDimensions);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.measurementMuzzleVelocity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.measurementBulletWeight);
            this.Name = "AmmoControl";
            this.Size = new System.Drawing.Size(333, 204);
            this.Enter += new System.EventHandler(this.AmmoControl_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MeasurementControl.MeasurementControl measurementBulletWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MeasurementControl.MeasurementControl measurementMuzzleVelocity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxDimensions;
        private MeasurementControl.MeasurementControl measurementDiameter;
        private MeasurementControl.MeasurementControl measurementLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private MeasurementControl.MeasurementControl measurementControl1;
    }
}
