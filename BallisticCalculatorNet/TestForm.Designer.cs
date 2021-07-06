
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
            this.windControl1 = new BallisticCalculatorNet.InputPanels.WindControl();
            this.SuspendLayout();
            // 
            // windControl1
            // 
            this.windControl1.Location = new System.Drawing.Point(13, 13);
            this.windControl1.Name = "windControl1";
            this.windControl1.Size = new System.Drawing.Size(432, 111);
            this.windControl1.TabIndex = 0;
            // 
            // MyTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.windControl1);
            this.Name = "MyTestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private WindControl windControl1;
    }
}