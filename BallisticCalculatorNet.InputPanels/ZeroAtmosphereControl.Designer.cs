namespace BallisticCalculatorNet.InputPanels
{
    partial class ZeroAtmosphereControl
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
            this.checkBoxOther = new System.Windows.Forms.CheckBox();
            this.atmosphereControl = new BallisticCalculatorNet.InputPanels.AtmosphereControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxOther
            // 
            this.checkBoxOther.AutoSize = true;
            this.checkBoxOther.Location = new System.Drawing.Point(3, 3);
            this.checkBoxOther.Name = "checkBoxOther";
            this.checkBoxOther.Size = new System.Drawing.Size(314, 29);
            this.checkBoxOther.TabIndex = 0;
            this.checkBoxOther.Text = "Use other atmosphere than at shot";
            this.checkBoxOther.UseVisualStyleBackColor = true;
            this.checkBoxOther.CheckedChanged += new System.EventHandler(this.checkBoxOther_CheckedChanged);
            // 
            // atmosphereControl
            // 
            this.atmosphereControl.AutoScroll = true;
            this.atmosphereControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.atmosphereControl.Location = new System.Drawing.Point(3, 43);
            this.atmosphereControl.Name = "atmosphereControl";
            this.atmosphereControl.Size = new System.Drawing.Size(515, 464);
            this.atmosphereControl.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.atmosphereControl, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(521, 510);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxOther);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 34);
            this.panel1.TabIndex = 0;
            // 
            // ZeroAtmosphereControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ZeroAtmosphereControl";
            this.Size = new System.Drawing.Size(521, 510);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxOther;
        private AtmosphereControl atmosphereControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}
