namespace BallisticCalculatorNet.InputPanels
{
    partial class ReticleControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureReticle = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.measurementTargetDistance = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxTargetSizeUnits = new System.Windows.Forms.ComboBox();
            this.numericTargetHeight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericTargetWidth = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxShowTarget = new System.Windows.Forms.CheckBox();
            this.radioBDCFar = new System.Windows.Forms.RadioButton();
            this.radioBDCNear = new System.Windows.Forms.RadioButton();
            this.radioBDCNone = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.numericMaxZoom = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericCurrentZoom = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonMilDot = new System.Windows.Forms.Button();
            this.buttonLoadReticle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureReticle)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTargetHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTargetWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCurrentZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureReticle);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(694, 383);
            this.splitContainer1.SplitterDistance = 322;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            this.splitContainer1.SizeChanged += new System.EventHandler(this.splitContainer1_SizeChanged);
            // 
            // pictureReticle
            // 
            this.pictureReticle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureReticle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureReticle.Location = new System.Drawing.Point(0, 0);
            this.pictureReticle.Name = "pictureReticle";
            this.pictureReticle.Size = new System.Drawing.Size(318, 379);
            this.pictureReticle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureReticle.TabIndex = 0;
            this.pictureReticle.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.measurementTargetDistance);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBoxTargetSizeUnits);
            this.panel1.Controls.Add(this.numericTargetHeight);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.numericTargetWidth);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.checkBoxShowTarget);
            this.panel1.Controls.Add(this.radioBDCFar);
            this.panel1.Controls.Add(this.radioBDCNear);
            this.panel1.Controls.Add(this.radioBDCNone);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numericMaxZoom);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numericCurrentZoom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonMilDot);
            this.panel1.Controls.Add(this.buttonLoadReticle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 379);
            this.panel1.TabIndex = 0;
            // 
            // measurementTargetDistance
            // 
            this.measurementTargetDistance.DecimalPoints = null;
            this.measurementTargetDistance.Increment = 1D;
            this.measurementTargetDistance.Location = new System.Drawing.Point(72, 256);
            this.measurementTargetDistance.Margin = new System.Windows.Forms.Padding(4);
            this.measurementTargetDistance.Maximum = 10000D;
            this.measurementTargetDistance.MaximumSize = new System.Drawing.Size(5120, 35);
            this.measurementTargetDistance.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Distance;
            this.measurementTargetDistance.Minimum = -10000D;
            this.measurementTargetDistance.MinimumSize = new System.Drawing.Size(150, 35);
            this.measurementTargetDistance.Name = "measurementTargetDistance";
            this.measurementTargetDistance.Size = new System.Drawing.Size(239, 35);
            this.measurementTargetDistance.TabIndex = 17;
            this.measurementTargetDistance.TextValue = "m";
            this.measurementTargetDistance.Unit = Gehtsoft.Measurements.DistanceUnit.Meter;
            this.measurementTargetDistance.Changed += new System.EventHandler(this.measurementTargetDistance_Changed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "At";
            // 
            // comboBoxTargetSizeUnits
            // 
            this.comboBoxTargetSizeUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTargetSizeUnits.FormattingEnabled = true;
            this.comboBoxTargetSizeUnits.Items.AddRange(new object[] {
            "in",
            "cm"});
            this.comboBoxTargetSizeUnits.Location = new System.Drawing.Point(244, 216);
            this.comboBoxTargetSizeUnits.Name = "comboBoxTargetSizeUnits";
            this.comboBoxTargetSizeUnits.Size = new System.Drawing.Size(67, 33);
            this.comboBoxTargetSizeUnits.TabIndex = 15;
            this.comboBoxTargetSizeUnits.SelectedValueChanged += new System.EventHandler(this.comboBoxTargetSizeUnits_SelectedValueChanged);
            // 
            // numericTargetHeight
            // 
            this.numericTargetHeight.Location = new System.Drawing.Point(175, 216);
            this.numericTargetHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTargetHeight.Name = "numericTargetHeight";
            this.numericTargetHeight.Size = new System.Drawing.Size(63, 31);
            this.numericTargetHeight.TabIndex = 14;
            this.numericTargetHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericTargetHeight.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericTargetHeight.ValueChanged += new System.EventHandler(this.numericTargetHeight_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "x";
            // 
            // numericTargetWidth
            // 
            this.numericTargetWidth.Location = new System.Drawing.Point(72, 216);
            this.numericTargetWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTargetWidth.Name = "numericTargetWidth";
            this.numericTargetWidth.Size = new System.Drawing.Size(63, 31);
            this.numericTargetWidth.TabIndex = 12;
            this.numericTargetWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericTargetWidth.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericTargetWidth.ValueChanged += new System.EventHandler(this.numericTargetWidth_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Size";
            // 
            // checkBoxShowTarget
            // 
            this.checkBoxShowTarget.AutoSize = true;
            this.checkBoxShowTarget.Location = new System.Drawing.Point(6, 181);
            this.checkBoxShowTarget.Name = "checkBoxShowTarget";
            this.checkBoxShowTarget.Size = new System.Drawing.Size(135, 29);
            this.checkBoxShowTarget.TabIndex = 10;
            this.checkBoxShowTarget.Text = "Show Target";
            this.checkBoxShowTarget.UseVisualStyleBackColor = true;
            this.checkBoxShowTarget.CheckedChanged += new System.EventHandler(this.checkBoxShowTarget_CheckedChanged);
            // 
            // radioBDCFar
            // 
            this.radioBDCFar.AutoSize = true;
            this.radioBDCFar.Location = new System.Drawing.Point(141, 154);
            this.radioBDCFar.Name = "radioBDCFar";
            this.radioBDCFar.Size = new System.Drawing.Size(60, 29);
            this.radioBDCFar.TabIndex = 9;
            this.radioBDCFar.TabStop = true;
            this.radioBDCFar.Text = "Far";
            this.radioBDCFar.UseVisualStyleBackColor = true;
            this.radioBDCFar.CheckedChanged += new System.EventHandler(this.radioBDCFar_CheckedChanged);
            // 
            // radioBDCNear
            // 
            this.radioBDCNear.AutoSize = true;
            this.radioBDCNear.Location = new System.Drawing.Point(140, 119);
            this.radioBDCNear.Name = "radioBDCNear";
            this.radioBDCNear.Size = new System.Drawing.Size(74, 29);
            this.radioBDCNear.TabIndex = 8;
            this.radioBDCNear.TabStop = true;
            this.radioBDCNear.Text = "Near";
            this.radioBDCNear.UseVisualStyleBackColor = true;
            this.radioBDCNear.CheckedChanged += new System.EventHandler(this.radioBDCNear_CheckedChanged);
            // 
            // radioBDCNone
            // 
            this.radioBDCNone.AutoSize = true;
            this.radioBDCNone.Checked = true;
            this.radioBDCNone.Location = new System.Drawing.Point(140, 84);
            this.radioBDCNone.Name = "radioBDCNone";
            this.radioBDCNone.Size = new System.Drawing.Size(80, 29);
            this.radioBDCNone.TabIndex = 7;
            this.radioBDCNone.TabStop = true;
            this.radioBDCNone.Text = "None";
            this.radioBDCNone.UseVisualStyleBackColor = true;
            this.radioBDCNone.CheckedChanged += new System.EventHandler(this.radioBDCNone_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "BDC Distances:";
            // 
            // numericMaxZoom
            // 
            this.numericMaxZoom.Location = new System.Drawing.Point(175, 43);
            this.numericMaxZoom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMaxZoom.Name = "numericMaxZoom";
            this.numericMaxZoom.Size = new System.Drawing.Size(63, 31);
            this.numericMaxZoom.TabIndex = 5;
            this.numericMaxZoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericMaxZoom.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericMaxZoom.ValueChanged += new System.EventHandler(this.numericMaxZoom_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "of";
            // 
            // numericCurrentZoom
            // 
            this.numericCurrentZoom.Location = new System.Drawing.Point(72, 43);
            this.numericCurrentZoom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericCurrentZoom.Name = "numericCurrentZoom";
            this.numericCurrentZoom.Size = new System.Drawing.Size(63, 31);
            this.numericCurrentZoom.TabIndex = 3;
            this.numericCurrentZoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericCurrentZoom.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericCurrentZoom.ValueChanged += new System.EventHandler(this.numericCurrentZoom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Zoom";
            // 
            // buttonMilDot
            // 
            this.buttonMilDot.Location = new System.Drawing.Point(121, 3);
            this.buttonMilDot.Name = "buttonMilDot";
            this.buttonMilDot.Size = new System.Drawing.Size(112, 34);
            this.buttonMilDot.TabIndex = 1;
            this.buttonMilDot.Text = "MilDot";
            this.buttonMilDot.UseVisualStyleBackColor = true;
            this.buttonMilDot.Click += new System.EventHandler(this.buttonMilDot_Click);
            // 
            // buttonLoadReticle
            // 
            this.buttonLoadReticle.Location = new System.Drawing.Point(3, 3);
            this.buttonLoadReticle.Name = "buttonLoadReticle";
            this.buttonLoadReticle.Size = new System.Drawing.Size(112, 34);
            this.buttonLoadReticle.TabIndex = 0;
            this.buttonLoadReticle.Text = "Load Reticle";
            this.buttonLoadReticle.UseVisualStyleBackColor = true;
            this.buttonLoadReticle.Click += new System.EventHandler(this.buttonLoadReticle_Click);
            // 
            // ReticleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ReticleControl";
            this.Size = new System.Drawing.Size(694, 383);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureReticle)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTargetHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTargetWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCurrentZoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureReticle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxTargetSizeUnits;
        private System.Windows.Forms.NumericUpDown numericTargetHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericTargetWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxShowTarget;
        private System.Windows.Forms.RadioButton radioBDCFar;
        private System.Windows.Forms.RadioButton radioBDCNear;
        private System.Windows.Forms.RadioButton radioBDCNone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericMaxZoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericCurrentZoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonMilDot;
        private System.Windows.Forms.Button buttonLoadReticle;
        private MeasurementControl.MeasurementControl measurementTargetDistance;
        private System.Windows.Forms.Label label6;
    }
}
