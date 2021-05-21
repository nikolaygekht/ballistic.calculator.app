
namespace BallisticCalculatorNet.ReticleEditor.Forms
{
    partial class EditTextForm
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
            System.Windows.Forms.Label label3;
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.measurementX = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.measurementY = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.measurementH = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(216, 151);
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
            this.buttonCancel.Location = new System.Drawing.Point(316, 151);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 29);
            this.buttonCancel.TabIndex = 101;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // measurementX
            // 
            this.measurementX.Increment = 1D;
            this.measurementX.Location = new System.Drawing.Point(156, 12);
            this.measurementX.Maximum = 10000D;
            this.measurementX.MaximumSize = new System.Drawing.Size(4096, 28);
            this.measurementX.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Angular;
            this.measurementX.Minimum = -10000D;
            this.measurementX.MinimumSize = new System.Drawing.Size(120, 28);
            this.measurementX.Name = "measurementX";
            this.measurementX.Size = new System.Drawing.Size(209, 28);
            this.measurementX.TabIndex = 1;
            this.measurementX.Unit = Gehtsoft.Measurements.AngularUnit.Radian;
            // 
            // measurementY
            // 
            this.measurementY.Increment = 1D;
            this.measurementY.Location = new System.Drawing.Point(371, 12);
            this.measurementY.Maximum = 10000D;
            this.measurementY.MaximumSize = new System.Drawing.Size(4096, 28);
            this.measurementY.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Angular;
            this.measurementY.Minimum = -10000D;
            this.measurementY.MinimumSize = new System.Drawing.Size(120, 28);
            this.measurementY.Name = "measurementY";
            this.measurementY.Size = new System.Drawing.Size(209, 28);
            this.measurementY.TabIndex = 2;
            this.measurementY.Unit = Gehtsoft.Measurements.AngularUnit.Radian;
            // 
            // measurementH
            // 
            this.measurementH.Increment = 1D;
            this.measurementH.Location = new System.Drawing.Point(156, 46);
            this.measurementH.Maximum = 10000D;
            this.measurementH.MaximumSize = new System.Drawing.Size(4096, 28);
            this.measurementH.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Angular;
            this.measurementH.Minimum = -10000D;
            this.measurementH.MinimumSize = new System.Drawing.Size(120, 28);
            this.measurementH.Name = "measurementH";
            this.measurementH.Size = new System.Drawing.Size(209, 28);
            this.measurementH.TabIndex = 3;
            this.measurementH.Unit = Gehtsoft.Measurements.AngularUnit.Radian;
            // 
            // comboBoxColor
            // 
            this.comboBoxColor.FormattingEnabled = true;
            this.comboBoxColor.Location = new System.Drawing.Point(156, 114);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(209, 28);
            this.comboBoxColor.TabIndex = 5;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 103;
            this.label2.Text = "Text Height";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(13, 82);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(36, 20);
            label3.TabIndex = 104;
            label3.Text = "Text";
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
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(156, 81);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(424, 27);
            this.textBox.TabIndex = 4;
            // 
            // EditTextForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(626, 193);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxColor);
            this.Controls.Add(this.measurementH);
            this.Controls.Add(this.measurementY);
            this.Controls.Add(this.measurementX);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditTextForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Text";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private MeasurementControl.MeasurementControl measurementX;
        private MeasurementControl.MeasurementControl measurementY;
        private MeasurementControl.MeasurementControl measurementH;
        private System.Windows.Forms.ComboBox comboBoxColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox;
    }
}