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
            this.SuspendLayout();
            // 
            // checkBoxOther
            // 
            this.checkBoxOther.AutoSize = true;
            this.checkBoxOther.Location = new System.Drawing.Point(3, 3);
            this.checkBoxOther.Name = "checkBoxOther";
            this.checkBoxOther.Size = new System.Drawing.Size(312, 28);
            this.checkBoxOther.TabIndex = 0;
            this.checkBoxOther.Text = "Use other atmosphere than at shot";
            this.checkBoxOther.UseVisualStyleBackColor = true;
            this.checkBoxOther.CheckedChanged += new System.EventHandler(this.checkBoxOther_CheckedChanged);
            // 
            // atmosphereControl
            // 
            this.atmosphereControl.Location = new System.Drawing.Point(0, 37);
            this.atmosphereControl.Name = "atmosphereControl";
            this.atmosphereControl.Size = new System.Drawing.Size(435, 218);
            this.atmosphereControl.TabIndex = 1;
            // 
            // ZeroAtmosphereControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.atmosphereControl);
            this.Controls.Add(this.checkBoxOther);
            this.Name = "ZeroAtmosphereControl";
            this.Size = new System.Drawing.Size(435, 255);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxOther;
        private AtmosphereControl atmosphereControl;
    }
}
