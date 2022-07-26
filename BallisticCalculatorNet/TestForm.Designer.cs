
using BallisticCalculatorNet.InputPanels;

namespace BallisticCalculatorNet
{
    partial class MyTestForm
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
            this.ammoLibEntryControl1 = new BallisticCalculatorNet.InputPanels.AmmoLibEntryControl();
            this.SuspendLayout();
            // 
            // ammoLibEntryControl1
            // 
            this.ammoLibEntryControl1.Location = new System.Drawing.Point(13, 13);
            this.ammoLibEntryControl1.Margin = new System.Windows.Forms.Padding(4);
            this.ammoLibEntryControl1.MeasurementSystem = BallisticCalculatorNet.InputPanels.MeasurementSystem.Metric;
            this.ammoLibEntryControl1.Name = "ammoLibEntryControl1";
            this.ammoLibEntryControl1.Size = new System.Drawing.Size(450, 613);
            this.ammoLibEntryControl1.TabIndex = 0;
            // 
            // MyTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 654);
            this.Controls.Add(this.ammoLibEntryControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MyTestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private AmmoLibEntryControl ammoLibEntryControl1;
    }
}