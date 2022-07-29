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
            this.SuspendLayout();
            // 
            // checkBoxOther
            // 
            this.checkBoxOther.AutoSize = true;
            this.checkBoxOther.Location = new System.Drawing.Point(3, 3);
            this.checkBoxOther.Name = "checkBoxOther";
            this.checkBoxOther.Size = new System.Drawing.Size(313, 28);
            this.checkBoxOther.TabIndex = 0;
            this.checkBoxOther.Text = "Use other ammunition than at shot";
            this.checkBoxOther.UseVisualStyleBackColor = true;
            this.checkBoxOther.CheckedChanged += new System.EventHandler(this.checkBoxOther_CheckedChanged);
            // 
            // ammoControl
            // 
            this.ammoControl.Location = new System.Drawing.Point(0, 76);
            this.ammoControl.Margin = new System.Windows.Forms.Padding(4);
            this.ammoControl.Name = "ammoControl";
            this.ammoControl.PromptFactory = winFormsFileNamePromptFactory1;
            this.ammoControl.Size = new System.Drawing.Size(435, 319);
            this.ammoControl.TabIndex = 2;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(161, 37);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(112, 34);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // ZeroAmmunitionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.ammoControl);
            this.Controls.Add(this.checkBoxOther);
            this.Name = "ZeroAmmunitionControl";
            this.Size = new System.Drawing.Size(435, 407);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxOther;
        private AmmoControl ammoControl;
        private System.Windows.Forms.Button buttonLoad;
    }
}
