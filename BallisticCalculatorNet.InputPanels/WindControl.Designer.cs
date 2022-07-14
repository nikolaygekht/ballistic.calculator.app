namespace BallisticCalculatorNet.InputPanels
{
    partial class WindControl
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
            this.checkBoxDistance = new System.Windows.Forms.CheckBox();
            this.measurementDirection = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.measurementVelocity = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // measurementDistance
            // 
            this.measurementDistance.DecimalPoints = 1;
            this.measurementDistance.Increment = 1D;
            this.measurementDistance.Location = new System.Drawing.Point(135, 1);
            this.measurementDistance.Maximum = 10000D;
            this.measurementDistance.MaximumSize = new System.Drawing.Size(4096, 28);
            this.measurementDistance.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Distance;
            this.measurementDistance.Minimum = 0D;
            this.measurementDistance.MinimumSize = new System.Drawing.Size(135, 28);
            this.measurementDistance.Name = "measurementDistance";
            this.measurementDistance.Size = new System.Drawing.Size(190, 28);
            this.measurementDistance.TabIndex = 2;
            this.measurementDistance.TextValue = "m";
            this.measurementDistance.Unit = Gehtsoft.Measurements.DistanceUnit.Meter;
            // 
            // checkBoxDistance
            // 
            this.checkBoxDistance.AutoSize = true;
            this.checkBoxDistance.Location = new System.Drawing.Point(2, 2);
            this.checkBoxDistance.Name = "checkBoxDistance";
            this.checkBoxDistance.Size = new System.Drawing.Size(88, 24);
            this.checkBoxDistance.TabIndex = 1;
            this.checkBoxDistance.Text = "Distance";
            this.checkBoxDistance.UseVisualStyleBackColor = true;
            this.checkBoxDistance.CheckedChanged += new System.EventHandler(this.checkBoxDistance_CheckedChanged);
            // 
            // measurementDirection
            // 
            this.measurementDirection.DecimalPoints = 0;
            this.measurementDirection.Increment = 1D;
            this.measurementDirection.Location = new System.Drawing.Point(135, 36);
            this.measurementDirection.Maximum = 180D;
            this.measurementDirection.MaximumSize = new System.Drawing.Size(4096, 28);
            this.measurementDirection.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Angular;
            this.measurementDirection.Minimum = -180D;
            this.measurementDirection.MinimumSize = new System.Drawing.Size(120, 28);
            this.measurementDirection.Name = "measurementDirection";
            this.measurementDirection.Size = new System.Drawing.Size(190, 28);
            this.measurementDirection.TabIndex = 3;
            this.measurementDirection.TextValue = "0°";
            this.measurementDirection.Unit = Gehtsoft.Measurements.AngularUnit.Degree;
            this.measurementDirection.Changed += new System.EventHandler(this.measurementDirection_Changed);
            // 
            // measurementVelocity
            // 
            this.measurementVelocity.DecimalPoints = 1;
            this.measurementVelocity.Increment = 1D;
            this.measurementVelocity.Location = new System.Drawing.Point(135, 71);
            this.measurementVelocity.Maximum = 10000D;
            this.measurementVelocity.MaximumSize = new System.Drawing.Size(4096, 28);
            this.measurementVelocity.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Velocity;
            this.measurementVelocity.Minimum = 0D;
            this.measurementVelocity.MinimumSize = new System.Drawing.Size(120, 28);
            this.measurementVelocity.Name = "measurementVelocity";
            this.measurementVelocity.Size = new System.Drawing.Size(190, 28);
            this.measurementVelocity.TabIndex = 4;
            this.measurementVelocity.TextValue = "m/s";
            this.measurementVelocity.Unit = Gehtsoft.Measurements.VelocityUnit.MetersPerSecond;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Direction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Velocity";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(331, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 97);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // WindControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.measurementVelocity);
            this.Controls.Add(this.measurementDirection);
            this.Controls.Add(this.checkBoxDistance);
            this.Controls.Add(this.measurementDistance);
            this.Name = "WindControl";
            this.Size = new System.Drawing.Size(464, 105);
            this.Enter += new System.EventHandler(this.WindControl_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MeasurementControl.MeasurementControl measurementDistance;
        private System.Windows.Forms.CheckBox checkBoxDistance;
        private MeasurementControl.MeasurementControl measurementDirection;
        private MeasurementControl.MeasurementControl measurementVelocity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
