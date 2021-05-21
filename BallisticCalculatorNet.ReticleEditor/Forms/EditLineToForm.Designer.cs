
namespace BallisticCalculatorNet.ReticleEditor.Forms
{
    partial class EditLineToForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(216, 53);
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
            this.buttonCancel.Location = new System.Drawing.Point(316, 53);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 102;
            this.label1.Text = "Position (X, Y)";
            // 
            // EditLineToForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(626, 100);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.measurementY1);
            this.Controls.Add(this.measurementX1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditLineToForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Line To";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private MeasurementControl.MeasurementControl measurementX1;
        private MeasurementControl.MeasurementControl measurementY1;
        private System.Windows.Forms.Label label1;
    }
}