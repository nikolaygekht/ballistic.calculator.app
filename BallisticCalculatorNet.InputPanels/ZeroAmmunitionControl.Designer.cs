namespace BallisticCalculatorNet.InputPanels
{
    partial class ZeroAmmunitionControl
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
            BallisticCalculatorNet.InputPanels.WinFormsFileNamePromptFactory winFormsFileNamePromptFactory1 = new BallisticCalculatorNet.InputPanels.WinFormsFileNamePromptFactory();
            this.checkBoxOther = new System.Windows.Forms.CheckBox();
            this.ammoControl = new BallisticCalculatorNet.InputPanels.AmmoControl();
            this.buttonLoad = new System.Windows.Forms.Button();
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
            this.checkBoxOther.Size = new System.Drawing.Size(315, 29);
            this.checkBoxOther.TabIndex = 0;
            this.checkBoxOther.Text = "Use other ammunition than at shot";
            this.checkBoxOther.UseVisualStyleBackColor = true;
            this.checkBoxOther.CheckedChanged += new System.EventHandler(this.checkBoxOther_CheckedChanged);
            // 
            // ammoControl
            // 
            this.ammoControl.AutoScroll = true;
            this.ammoControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ammoControl.Location = new System.Drawing.Point(4, 84);
            this.ammoControl.Margin = new System.Windows.Forms.Padding(4);
            this.ammoControl.Name = "ammoControl";
            this.ammoControl.PromptFactory = winFormsFileNamePromptFactory1;
            this.ammoControl.Size = new System.Drawing.Size(601, 363);
            this.ammoControl.TabIndex = 2;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(3, 38);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(112, 35);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ammoControl, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(609, 451);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxOther);
            this.panel1.Controls.Add(this.buttonLoad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 74);
            this.panel1.TabIndex = 0;
            // 
            // ZeroAmmunitionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ZeroAmmunitionControl";
            this.Size = new System.Drawing.Size(609, 451);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxOther;
        private AmmoControl ammoControl;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}
