namespace BallisticCalculatorNet
{
    partial class CompareForm
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
            this.multiChartControl = new BallisticCalculatorNet.InputPanels.MultiChartControl();
            this.SuspendLayout();
            // 
            // multiChartControl
            // 
            this.multiChartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiChartControl.Location = new System.Drawing.Point(0, 0);
            this.multiChartControl.Name = "multiChartControl";
            this.multiChartControl.Size = new System.Drawing.Size(800, 450);
            this.multiChartControl.TabIndex = 0;
            // 
            // CompareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.multiChartControl);
            this.Name = "CompareForm";
            this.Text = "Compare Trajectories";
            this.ResumeLayout(false);

        }

        #endregion

        private InputPanels.MultiChartControl multiChartControl;
    }
}