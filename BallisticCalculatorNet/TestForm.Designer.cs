
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
            this.shotDataControl1 = new BallisticCalculatorNet.InputPanels.ShotDataControl();
            this.SuspendLayout();
            // 
            // shotDataControl1
            // 
            this.shotDataControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shotDataControl1.Location = new System.Drawing.Point(0, 0);
            this.shotDataControl1.Name = "shotDataControl1";
            this.shotDataControl1.Size = new System.Drawing.Size(1429, 654);
            this.shotDataControl1.TabIndex = 0;
            // 
            // MyTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 654);
            this.Controls.Add(this.shotDataControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MyTestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ShotDataControl shotDataControl1;
    }
}