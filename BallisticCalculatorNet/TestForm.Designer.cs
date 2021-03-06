
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
            BallisticCalculator.Ammunition ammunition1 = new BallisticCalculator.Ammunition();
            this.windControl1 = new BallisticCalculatorNet.InputPanels.WindControl();
            this.button1 = new System.Windows.Forms.Button();
            this.ammoControl1 = new BallisticCalculatorNet.InputPanels.AmmoControl();
            this.SuspendLayout();
            // 
            // windControl1
            // 
            this.windControl1.Location = new System.Drawing.Point(15, 73);
            this.windControl1.Margin = new System.Windows.Forms.Padding(5);
            this.windControl1.MeasurementSystem = BallisticCalculatorNet.InputPanels.MeasurementSystem.Metric;
            this.windControl1.Name = "windControl1";
            this.windControl1.Size = new System.Drawing.Size(565, 133);
            this.windControl1.TabIndex = 2;
            this.windControl1.Wind = null;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 16);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ammoControl1
            // 
            this.ammoControl1.Ammunition = ammunition1;
            this.ammoControl1.CustomBallisticFile = "";
            this.ammoControl1.Location = new System.Drawing.Point(14, 216);
            this.ammoControl1.Margin = new System.Windows.Forms.Padding(5);
            this.ammoControl1.MeasurementSystem = BallisticCalculatorNet.InputPanels.MeasurementSystem.Metric;
            this.ammoControl1.Name = "ammoControl1";
            this.ammoControl1.Size = new System.Drawing.Size(565, 367);
            this.ammoControl1.TabIndex = 3;
            // 
            // MyTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 654);
            this.Controls.Add(this.ammoControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.windControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MyTestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private WindControl windControl1;
        private System.Windows.Forms.Button button1;
        private AmmoControl ammoControl1;
    }
}