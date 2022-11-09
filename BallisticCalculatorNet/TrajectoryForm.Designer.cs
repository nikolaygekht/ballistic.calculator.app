namespace BallisticCalculatorNet
{
    partial class TrajectoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrajectoryForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTable = new System.Windows.Forms.TabPage();
            this.trajectoryControl = new BallisticCalculatorNet.InputPanels.TrajectoryControl();
            this.tabChart = new System.Windows.Forms.TabPage();
            this.tabReticle = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl.Controls.Add(this.tabTable);
            this.tabControl.Controls.Add(this.tabChart);
            this.tabControl.Controls.Add(this.tabReticle);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1447, 410);
            this.tabControl.TabIndex = 0;
            // 
            // tabTable
            // 
            this.tabTable.Controls.Add(this.trajectoryControl);
            this.tabTable.Location = new System.Drawing.Point(4, 4);
            this.tabTable.Name = "tabTable";
            this.tabTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabTable.Size = new System.Drawing.Size(1439, 372);
            this.tabTable.TabIndex = 0;
            this.tabTable.Text = "Table";
            this.tabTable.UseVisualStyleBackColor = true;
            // 
            // trajectoryControl
            // 
            this.trajectoryControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trajectoryControl.Location = new System.Drawing.Point(3, 3);
            this.trajectoryControl.Name = "trajectoryControl";
            this.trajectoryControl.Size = new System.Drawing.Size(1433, 366);
            this.trajectoryControl.TabIndex = 0;
            // 
            // tabChart
            // 
            this.tabChart.Location = new System.Drawing.Point(4, 4);
            this.tabChart.Name = "tabChart";
            this.tabChart.Padding = new System.Windows.Forms.Padding(3);
            this.tabChart.Size = new System.Drawing.Size(1439, 372);
            this.tabChart.TabIndex = 1;
            this.tabChart.Text = "Chart";
            this.tabChart.UseVisualStyleBackColor = true;
            // 
            // tabReticle
            // 
            this.tabReticle.Location = new System.Drawing.Point(4, 4);
            this.tabReticle.Name = "tabReticle";
            this.tabReticle.Size = new System.Drawing.Size(1439, 372);
            this.tabReticle.TabIndex = 2;
            this.tabReticle.Text = "Reticle";
            this.tabReticle.UseVisualStyleBackColor = true;
            // 
            // TrajectoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 410);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrajectoryForm";
            this.ShowInTaskbar = false;
            this.Text = "New Trajectory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrajectoryForm_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTable;
        private InputPanels.TrajectoryControl trajectoryControl;
        private System.Windows.Forms.TabPage tabChart;
        private System.Windows.Forms.TabPage tabReticle;
    }
}