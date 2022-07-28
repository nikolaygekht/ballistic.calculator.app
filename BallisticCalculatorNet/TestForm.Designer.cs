
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
            this.multiWindControl1 = new BallisticCalculatorNet.InputPanels.MultiWindControl();
            this.SuspendLayout();
            // 
            // multiWindControl1
            // 
            this.multiWindControl1.AutoScroll = true;
            this.multiWindControl1.Location = new System.Drawing.Point(12, 12);
            this.multiWindControl1.Name = "multiWindControl1";
            this.multiWindControl1.Size = new System.Drawing.Size(605, 528);
            this.multiWindControl1.TabIndex = 0;
            this.multiWindControl1.Winds = null;
            // 
            // MyTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 654);
            this.Controls.Add(this.multiWindControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MyTestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private MultiWindControl multiWindControl1;
    }
}