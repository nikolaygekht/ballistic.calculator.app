
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
            this.measurementDiameter = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.measurementLength = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.measurementBC = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCustomBallistic = new System.Windows.Forms.TextBox();
            this.buttonCustomBallisticLoad = new System.Windows.Forms.Button();
            this.checkBoxFormFactor = new System.Windows.Forms.CheckBox();
            this.buttonSDasBC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // measurementBulletWeight
            // 
            this.measurementBulletWeight.DecimalPoints = null;
            this.measurementBulletWeight.Increment = 1D;
            this.measurementBulletWeight.Location = new System.Drawing.Point(169, 5);
            this.measurementBulletWeight.Margin = new System.Windows.Forms.Padding(5);
            this.measurementBulletWeight.Maximum = 1000D;
            this.measurementBulletWeight.MaximumSize = new System.Drawing.Size(5120, 34);
            this.measurementBulletWeight.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Weight;
            this.measurementBulletWeight.Minimum = 0D;
            this.measurementBulletWeight.MinimumSize = new System.Drawing.Size(150, 34);
            this.measurementBulletWeight.Name = "measurementBulletWeight";
            this.measurementBulletWeight.Size = new System.Drawing.Size(238, 34);
            this.measurementBulletWeight.TabIndex = 1;
            this.measurementBulletWeight.TextValue = "0gr";
            this.measurementBulletWeight.Unit = Gehtsoft.Measurements.WeightUnit.Grain;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Weight";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(4, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "BC";
            // 
            // measurementMuzzleVelocity
            // 
            this.measurementMuzzleVelocity.DecimalPoints = null;
            this.measurementMuzzleVelocity.Increment = 1D;
            this.measurementMuzzleVelocity.Location = new System.Drawing.Point(170, 155);
            this.measurementMuzzleVelocity.Margin = new System.Windows.Forms.Padding(5);
            this.measurementMuzzleVelocity.Maximum = 10000D;
            this.measurementMuzzleVelocity.MaximumSize = new System.Drawing.Size(5120, 34);
            this.measurementMuzzleVelocity.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Velocity;
            this.measurementMuzzleVelocity.Minimum = 0D;
            this.measurementMuzzleVelocity.MinimumSize = new System.Drawing.Size(150, 34);
            this.measurementMuzzleVelocity.Name = "measurementMuzzleVelocity";
            this.measurementMuzzleVelocity.Size = new System.Drawing.Size(238, 34);
            this.measurementMuzzleVelocity.TabIndex = 9;
            this.measurementMuzzleVelocity.TextValue = "m/s";
            this.measurementMuzzleVelocity.Unit = Gehtsoft.Measurements.VelocityUnit.MetersPerSecond;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 159);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Muzzle Velocity";
            // 
            // measurementDiameter
            // 
            this.measurementDiameter.DecimalPoints = null;
            this.measurementDiameter.Increment = 1D;
            this.measurementDiameter.Location = new System.Drawing.Point(170, 195);
            this.measurementDiameter.Margin = new System.Windows.Forms.Padding(5);
            this.measurementDiameter.Maximum = 10000D;
            this.measurementDiameter.MaximumSize = new System.Drawing.Size(5120, 34);
            this.measurementDiameter.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Distance;
            this.measurementDiameter.Minimum = 0D;
            this.measurementDiameter.MinimumSize = new System.Drawing.Size(150, 34);
            this.measurementDiameter.Name = "measurementDiameter";
            this.measurementDiameter.Size = new System.Drawing.Size(238, 34);
            this.measurementDiameter.TabIndex = 11;
            this.measurementDiameter.TextValue = "m";
            this.measurementDiameter.Unit = Gehtsoft.Measurements.DistanceUnit.Meter;
            // 
            // measurementLength
            // 
            this.measurementLength.DecimalPoints = null;
            this.measurementLength.Increment = 1D;
            this.measurementLength.Location = new System.Drawing.Point(170, 236);
            this.measurementLength.Margin = new System.Windows.Forms.Padding(5);
            this.measurementLength.Maximum = 10000D;
            this.measurementLength.MaximumSize = new System.Drawing.Size(5120, 34);
            this.measurementLength.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Distance;
            this.measurementLength.Minimum = 0D;
            this.measurementLength.MinimumSize = new System.Drawing.Size(150, 34);
            this.measurementLength.Name = "measurementLength";
            this.measurementLength.Size = new System.Drawing.Size(238, 34);
            this.measurementLength.TabIndex = 13;
            this.measurementLength.TextValue = "m";
            this.measurementLength.Unit = Gehtsoft.Measurements.DistanceUnit.Meter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 199);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Bullet Diameter";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 239);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Bullet Length";
            // 
            // measurementBC
            // 
            this.measurementBC.DecimalPoints = null;
            this.measurementBC.Increment = 0.001D;
            this.measurementBC.Location = new System.Drawing.Point(169, 46);
            this.measurementBC.Margin = new System.Windows.Forms.Padding(5);
            this.measurementBC.Maximum = 2D;
            this.measurementBC.MaximumSize = new System.Drawing.Size(5120, 34);
            this.measurementBC.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.BallisticCoefficient;
            this.measurementBC.Minimum = 0D;
            this.measurementBC.MinimumSize = new System.Drawing.Size(150, 34);
            this.measurementBC.Name = "measurementBC";
            this.measurementBC.Size = new System.Drawing.Size(238, 34);
            this.measurementBC.TabIndex = 3;
            this.measurementBC.TextValue = "0.5G1";
            this.measurementBC.Unit = BallisticCalculator.DragTableId.G1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Custom table";
            // 
            // textBoxCustomBallistic
            // 
            this.textBoxCustomBallistic.Location = new System.Drawing.Point(168, 116);
            this.textBoxCustomBallistic.Name = "textBoxCustomBallistic";
            this.textBoxCustomBallistic.Size = new System.Drawing.Size(198, 31);
            this.textBoxCustomBallistic.TabIndex = 6;
            // 
            // buttonCustomBallisticLoad
            // 
            this.buttonCustomBallisticLoad.Location = new System.Drawing.Point(372, 116);
            this.buttonCustomBallisticLoad.Name = "buttonCustomBallisticLoad";
            this.buttonCustomBallisticLoad.Size = new System.Drawing.Size(34, 31);
            this.buttonCustomBallisticLoad.TabIndex = 7;
            this.buttonCustomBallisticLoad.Text = "...";
            this.buttonCustomBallisticLoad.UseVisualStyleBackColor = true;
            this.buttonCustomBallisticLoad.Click += new System.EventHandler(this.buttonCustomBallisticLoad_Click);
            // 
            // checkBoxFormFactor
            // 
            this.checkBoxFormFactor.AutoSize = true;
            this.checkBoxFormFactor.Location = new System.Drawing.Point(169, 82);
            this.checkBoxFormFactor.Name = "checkBoxFormFactor";
            this.checkBoxFormFactor.Size = new System.Drawing.Size(174, 28);
            this.checkBoxFormFactor.TabIndex = 4;
            this.checkBoxFormFactor.Text = "BC is Form Factor";
            this.checkBoxFormFactor.UseVisualStyleBackColor = true;
            // 
            // buttonSDasBC
            // 
            this.buttonSDasBC.Location = new System.Drawing.Point(170, 278);
            this.buttonSDasBC.Name = "buttonSDasBC";
            this.buttonSDasBC.Size = new System.Drawing.Size(112, 34);
            this.buttonSDasBC.TabIndex = 14;
            this.buttonSDasBC.Text = "SD as BC";
            this.buttonSDasBC.UseVisualStyleBackColor = true;
            this.buttonSDasBC.Click += new System.EventHandler(this.buttonSDasBC_Click);
            // 
            // AmmoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSDasBC);
            this.Controls.Add(this.checkBoxFormFactor);
            this.Controls.Add(this.buttonCustomBallisticLoad);
            this.Controls.Add(this.textBoxCustomBallistic);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.measurementBC);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.measurementLength);
            this.Controls.Add(this.measurementDiameter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.measurementMuzzleVelocity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.measurementBulletWeight);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AmmoControl";
            this.Size = new System.Drawing.Size(416, 324);
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
        private MeasurementControl.MeasurementControl measurementDiameter;
        private MeasurementControl.MeasurementControl measurementLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private MeasurementControl.MeasurementControl measurementBC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxCustomBallistic;
        private System.Windows.Forms.Button buttonCustomBallisticLoad;
        private System.Windows.Forms.CheckBox checkBoxFormFactor;
        private System.Windows.Forms.Button buttonSDasBC;
    }
}
