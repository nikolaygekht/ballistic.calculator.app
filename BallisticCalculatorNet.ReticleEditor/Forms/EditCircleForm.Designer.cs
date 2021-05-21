
namespace BallisticCalculatorNet.ReticleEditor.Forms
{
    partial class EditCircleForm
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
            this.measurementX = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.measurementY = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.measurementR = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.checkBoxFill = new System.Windows.Forms.CheckBox();
            this.measurementWidth = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(216, 186);
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
            this.buttonCancel.Location = new System.Drawing.Point(316, 186);
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
            // measurementR
            // 
            this.measurementR.Increment = 1D;
            this.measurementR.Location = new System.Drawing.Point(156, 46);
            this.measurementR.Maximum = 10000D;
            this.measurementR.MaximumSize = new System.Drawing.Size(4096, 28);
            this.measurementR.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Angular;
            this.measurementR.Minimum = -10000D;
            this.measurementR.MinimumSize = new System.Drawing.Size(120, 28);
            this.measurementR.Name = "measurementR";
            this.measurementR.Size = new System.Drawing.Size(209, 28);
            this.measurementR.TabIndex = 3;
            this.measurementR.Unit = Gehtsoft.Measurements.AngularUnit.Radian;
            // 
            // comboBoxColor
            // 
            this.comboBoxColor.FormattingEnabled = true;
            this.comboBoxColor.Location = new System.Drawing.Point(156, 114);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(209, 28);
            this.comboBoxColor.TabIndex = 5;
            // 
            // checkBoxFill
            // 
            this.checkBoxFill.AutoSize = true;
            this.checkBoxFill.Location = new System.Drawing.Point(156, 149);
            this.checkBoxFill.Name = "checkBoxFill";
            this.checkBoxFill.Size = new System.Drawing.Size(50, 24);
            this.checkBoxFill.TabIndex = 6;
            this.checkBoxFill.Text = "Fill";
            this.checkBoxFill.UseVisualStyleBackColor = true;
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
            this.measurementWidth.TabIndex = 4;
            this.measurementWidth.Unit = Gehtsoft.Measurements.AngularUnit.Radian;
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
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 103;
            this.label2.Text = "Radius";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 82);
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
            // EditCircleForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(626, 240);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.measurementWidth);
            this.Controls.Add(this.checkBoxFill);
            this.Controls.Add(this.comboBoxColor);
            this.Controls.Add(this.measurementR);
            this.Controls.Add(this.measurementY);
            this.Controls.Add(this.measurementX);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCircleForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Circle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private MeasurementControl.MeasurementControl measurementX;
        private MeasurementControl.MeasurementControl measurementY;
        private MeasurementControl.MeasurementControl measurementR;
        private System.Windows.Forms.ComboBox comboBoxColor;
        private System.Windows.Forms.CheckBox checkBoxFill;
        private MeasurementControl.MeasurementControl measurementWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}