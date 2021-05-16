
namespace BallisticCalculatorNet.ReticleEditor
{
    partial class MeasurementControl
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
            this.numericPart = new System.Windows.Forms.NumericUpDown();
            this.unitPart = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericPart)).BeginInit();
            this.SuspendLayout();
            // 
            // numericPart
            // 
            this.numericPart.DecimalPlaces = 3;
            this.numericPart.Location = new System.Drawing.Point(0, 1);
            this.numericPart.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericPart.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericPart.Name = "numericPart";
            this.numericPart.Size = new System.Drawing.Size(156, 22);
            this.numericPart.TabIndex = 0;
            this.numericPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericPart.ThousandsSeparator = true;
            // 
            // unitPart
            // 
            this.unitPart.FormattingEnabled = true;
            this.unitPart.Location = new System.Drawing.Point(156, 0);
            this.unitPart.Name = "unitPart";
            this.unitPart.Size = new System.Drawing.Size(74, 24);
            this.unitPart.TabIndex = 1;
            // 
            // MeasurementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.unitPart);
            this.Controls.Add(this.numericPart);
            this.Name = "MeasurementControl";
            this.Size = new System.Drawing.Size(230, 24);
            this.Enter += new System.EventHandler(this.MeasurementControl_Enter);
            this.Resize += new System.EventHandler(this.MeasurementControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numericPart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericPart;
        private System.Windows.Forms.ComboBox unitPart;
    }
}
