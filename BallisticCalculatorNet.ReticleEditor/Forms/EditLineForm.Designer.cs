
namespace BallisticCalculatorNet.ReticleEditor.Forms
{
    partial class EditLineForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.measurementX1 = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.measurementY1 = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.measurementWidth = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.measurementY2 = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.measurementX2 = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(216, 148);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(94, 29);
            this.buttonOK.TabIndex = 100;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(316, 148);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 29);
            this.buttonCancel.TabIndex = 101;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // measurementX1
            // 
            this.measurementX1.Increment = 1D;
            this.measurementX1.Location = new System.Drawing.Point(156, 12);
            this.measurementX1.Maximum = 10000D;
            this.measurementX1.MaximumSize = new System.Drawing.Size(4096, 28);
            this.measurementX1.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Angular;
            this.measurementX1.Minimum = -10000D;
            this.measurementX1.MinimumSize = new System.Drawing.Size(120, 28);
            this.measurementX1.Name = "measurementX1";
            this.measurementX1.Size = new System.Drawing.Size(209, 28);
            this.measurementX1.TabIndex = 1;
            this.measurementX1.Unit = Gehtsoft.Measurements.AngularUnit.Radian;
            // 
            // measurementY1
            // 
            this.measurementY1.Increment = 1D;
            this.measurementY1.Location = new System.Drawing.Point(371, 12);
            this.measurementY1.Maximum = 10000D;
            this.measurementY1.MaximumSize = new System.Drawing.Size(4096, 28);
            this.measurementY1.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Angular;
            this.measurementY1.Minimum = -10000D;
            this.measurementY1.MinimumSize = new System.Drawing.Size(120, 28);
            this.measurementY1.Name = "measurementY1";
            this.measurementY1.Size = new System.Drawing.Size(209, 28);
            this.measurementY1.TabIndex = 2;
            this.measurementY1.Unit = Gehtsoft.Measurements.AngularUnit.Radian;
            // 
            // comboBoxColor
            // 
            this.comboBoxColor.FormattingEnabled = true;
            this.comboBoxColor.Location = new System.Drawing.Point(156, 114);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(209, 28);
            this.comboBoxColor.TabIndex = 6;
            // 
            // measurementWidth
            // 
            this.measurementWidth.Increment = 1D;
            this.measurementWidth.Location = new System.Drawing.Point(156, 80);
            this.measurementWidth.Maximum = 10000D;
            this.measurementWidth.MaximumSize = new System.Drawing.Size(4096, 28);
            this.measurementWidth.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Angular;
            this.measurementWidth.Minimum = -10000D;
            this.measurementWidth.MinimumSize = new System.Drawing.Size(120, 28);
            this.measurementWidth.Name = "measurementWidth";
            this.measurementWidth.Size = new System.Drawing.Size(209, 28);
            this.measurementWidth.TabIndex = 5;
            this.measurementWidth.Unit = Gehtsoft.Measurements.AngularUnit.Radian;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 102;
            this.label1.Text = "Start (X, Y)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 104;
            this.label3.Text = "Line Width";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 105;
            this.label4.Text = "Color";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 108;
            this.label2.Text = "End (X, Y)";
            // 
            // measurementY2
            // 
            this.measurementY2.Increment = 1D;
            this.measurementY2.Location = new System.Drawing.Point(371, 46);
            this.measurementY2.Maximum = 10000D;
            this.measurementY2.MaximumSize = new System.Drawing.Size(4096, 28);
            this.measurementY2.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Angular;
            this.measurementY2.Minimum = -10000D;
            this.measurementY2.MinimumSize = new System.Drawing.Size(120, 28);
            this.measurementY2.Name = "measurementY2";
            this.measurementY2.Size = new System.Drawing.Size(209, 28);
            this.measurementY2.TabIndex = 4;
            this.measurementY2.Unit = Gehtsoft.Measurements.AngularUnit.Radian;
            // 
            // measurementX2
            // 
            this.measurementX2.Increment = 1D;
            this.measurementX2.Location = new System.Drawing.Point(156, 46);
            this.measurementX2.Maximum = 10000D;
            this.measurementX2.MaximumSize = new System.Drawing.Size(4096, 28);
            this.measurementX2.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Angular;
            this.measurementX2.Minimum = -10000D;
            this.measurementX2.MinimumSize = new System.Drawing.Size(120, 28);
            this.measurementX2.Name = "measurementX2";
            this.measurementX2.Size = new System.Drawing.Size(209, 28);
            this.measurementX2.TabIndex = 3;
            this.measurementX2.Unit = Gehtsoft.Measurements.AngularUnit.Radian;
            // 
            // EditLineForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(626, 194);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.measurementY2);
            this.Controls.Add(this.measurementX2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.measurementWidth);
            this.Controls.Add(this.comboBoxColor);
            this.Controls.Add(this.measurementY1);
            this.Controls.Add(this.measurementX1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditLineForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Line";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private MeasurementControl.MeasurementControl measurementX1;
        private MeasurementControl.MeasurementControl measurementY1;
        private System.Windows.Forms.ComboBox comboBoxColor;
        private MeasurementControl.MeasurementControl measurementWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private MeasurementControl.MeasurementControl measurementY2;
        private MeasurementControl.MeasurementControl measurementX2;
    }
}