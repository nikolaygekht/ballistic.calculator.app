namespace BallisticCalculatorNet.InputPanels
{
    partial class AtmosphereControl
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
            this.measurementAltitude = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.label1 = new System.Windows.Forms.Label();
            this.measurementPressure = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.label2 = new System.Windows.Forms.Label();
            this.measurementTemperature = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxHumidity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // measurementAltitude
            // 
            this.measurementAltitude.DecimalPoints = null;
            this.measurementAltitude.Increment = 1D;
            this.measurementAltitude.Location = new System.Drawing.Point(170, 4);
            this.measurementAltitude.Margin = new System.Windows.Forms.Padding(4);
            this.measurementAltitude.Maximum = 10000D;
            this.measurementAltitude.MaximumSize = new System.Drawing.Size(5120, 34);
            this.measurementAltitude.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Distance;
            this.measurementAltitude.Minimum = -10000D;
            this.measurementAltitude.MinimumSize = new System.Drawing.Size(150, 34);
            this.measurementAltitude.Name = "measurementAltitude";
            this.measurementAltitude.Size = new System.Drawing.Size(261, 34);
            this.measurementAltitude.TabIndex = 0;
            this.measurementAltitude.TextValue = "m";
            this.measurementAltitude.Unit = Gehtsoft.Measurements.DistanceUnit.Meter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Altitude";
            // 
            // measurementPressure
            // 
            this.measurementPressure.DecimalPoints = null;
            this.measurementPressure.Increment = 1D;
            this.measurementPressure.Location = new System.Drawing.Point(170, 46);
            this.measurementPressure.Margin = new System.Windows.Forms.Padding(4);
            this.measurementPressure.Maximum = 10000D;
            this.measurementPressure.MaximumSize = new System.Drawing.Size(5120, 34);
            this.measurementPressure.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Pressure;
            this.measurementPressure.Minimum = -10000D;
            this.measurementPressure.MinimumSize = new System.Drawing.Size(150, 34);
            this.measurementPressure.Name = "measurementPressure";
            this.measurementPressure.Size = new System.Drawing.Size(261, 34);
            this.measurementPressure.TabIndex = 2;
            this.measurementPressure.TextValue = "bar";
            this.measurementPressure.Unit = Gehtsoft.Measurements.PressureUnit.Bar;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pressure";
            // 
            // measurementTemperature
            // 
            this.measurementTemperature.DecimalPoints = null;
            this.measurementTemperature.Increment = 1D;
            this.measurementTemperature.Location = new System.Drawing.Point(170, 88);
            this.measurementTemperature.Margin = new System.Windows.Forms.Padding(4);
            this.measurementTemperature.Maximum = 10000D;
            this.measurementTemperature.MaximumSize = new System.Drawing.Size(5120, 34);
            this.measurementTemperature.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Temperature;
            this.measurementTemperature.Minimum = -10000D;
            this.measurementTemperature.MinimumSize = new System.Drawing.Size(150, 34);
            this.measurementTemperature.Name = "measurementTemperature";
            this.measurementTemperature.Size = new System.Drawing.Size(261, 34);
            this.measurementTemperature.TabIndex = 4;
            this.measurementTemperature.TextValue = "°C";
            this.measurementTemperature.Unit = Gehtsoft.Measurements.TemperatureUnit.Celsius;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Temperature";
            // 
            // textBoxHumidity
            // 
            this.textBoxHumidity.Location = new System.Drawing.Point(170, 129);
            this.textBoxHumidity.Name = "textBoxHumidity";
            this.textBoxHumidity.Size = new System.Drawing.Size(237, 31);
            this.textBoxHumidity.TabIndex = 6;
            this.textBoxHumidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxHumidity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxHumidity_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Humidity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(410, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "%";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(161, 166);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(112, 34);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // AtmosphereControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxHumidity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.measurementTemperature);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.measurementPressure);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.measurementAltitude);
            this.Name = "AtmosphereControl";
            this.Size = new System.Drawing.Size(435, 207);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MeasurementControl.MeasurementControl measurementAltitude;
        private System.Windows.Forms.Label label1;
        private MeasurementControl.MeasurementControl measurementPressure;
        private System.Windows.Forms.Label label2;
        private MeasurementControl.MeasurementControl measurementTemperature;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxHumidity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonReset;
    }
}
