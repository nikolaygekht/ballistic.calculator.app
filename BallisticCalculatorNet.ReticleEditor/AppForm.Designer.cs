
namespace BallisticCalculatorNet.ReticleEditor
{
    partial class AppForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureReticle = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSet = new System.Windows.Forms.Button();
            this.buttonSaveAs = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.zeroOffsetY = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.zeroOffsetX = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.reticleHeight = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.reticleWidth = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.reticleName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ReticleItems = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureReticle)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.splitContainer1.Panel1.SizeChanged += new System.EventHandler(this.splitContainer1_Panel1_SizeChanged);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1529, 718);
            this.splitContainer1.SplitterDistance = 509;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureReticle
            // 
            this.pictureReticle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureReticle.Location = new System.Drawing.Point(0, 0);
            this.pictureReticle.Name = "pictureReticle";
            this.pictureReticle.Size = new System.Drawing.Size(505, 714);
            this.pictureReticle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureReticle.TabIndex = 0;
            this.pictureReticle.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ReticleItems, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1012, 714);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSet);
            this.panel1.Controls.Add(this.buttonSaveAs);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Controls.Add(this.buttonLoad);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.zeroOffsetY);
            this.panel1.Controls.Add(this.zeroOffsetX);
            this.panel1.Controls.Add(this.reticleHeight);
            this.panel1.Controls.Add(this.reticleWidth);
            this.panel1.Controls.Add(this.reticleName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1006, 193);
            this.panel1.TabIndex = 0;
            // 
            // buttonSet
            // 
            this.buttonSet.Location = new System.Drawing.Point(111, 131);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(94, 29);
            this.buttonSet.TabIndex = 12;
            this.buttonSet.Text = "Set";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.Location = new System.Drawing.Point(411, 130);
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(94, 29);
            this.buttonSaveAs.TabIndex = 11;
            this.buttonSaveAs.Text = "Save As";
            this.buttonSaveAs.UseVisualStyleBackColor = true;
            this.buttonSaveAs.Click += new System.EventHandler(this.buttonSaveAs_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(311, 130);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 29);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(211, 131);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(94, 29);
            this.buttonLoad.TabIndex = 9;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Zero (X, Y)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Size (WxH)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            // 
            // zeroOffsetY
            // 
            this.zeroOffsetY.Increment = 1D;
            this.zeroOffsetY.Location = new System.Drawing.Point(454, 97);
            this.zeroOffsetY.Maximum = 10000D;
            this.zeroOffsetY.MaximumSize = new System.Drawing.Size(4096, 28);
            this.zeroOffsetY.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Angular;
            this.zeroOffsetY.Minimum = -10000D;
            this.zeroOffsetY.MinimumSize = new System.Drawing.Size(120, 28);
            this.zeroOffsetY.Name = "zeroOffsetY";
            this.zeroOffsetY.Size = new System.Drawing.Size(299, 28);
            this.zeroOffsetY.TabIndex = 5;
            this.zeroOffsetY.Unit = Gehtsoft.Measurements.AngularUnit.Radian;
            // 
            // zeroOffsetX
            // 
            this.zeroOffsetX.Increment = 1D;
            this.zeroOffsetX.Location = new System.Drawing.Point(116, 97);
            this.zeroOffsetX.Maximum = 10000D;
            this.zeroOffsetX.MaximumSize = new System.Drawing.Size(4096, 28);
            this.zeroOffsetX.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Angular;
            this.zeroOffsetX.Minimum = -10000D;
            this.zeroOffsetX.MinimumSize = new System.Drawing.Size(120, 28);
            this.zeroOffsetX.Name = "zeroOffsetX";
            this.zeroOffsetX.Size = new System.Drawing.Size(299, 28);
            this.zeroOffsetX.TabIndex = 4;
            this.zeroOffsetX.Unit = Gehtsoft.Measurements.AngularUnit.Radian;
            // 
            // reticleHeight
            // 
            this.reticleHeight.Increment = 1D;
            this.reticleHeight.Location = new System.Drawing.Point(454, 63);
            this.reticleHeight.Maximum = 10000D;
            this.reticleHeight.MaximumSize = new System.Drawing.Size(4096, 28);
            this.reticleHeight.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Angular;
            this.reticleHeight.Minimum = -10000D;
            this.reticleHeight.MinimumSize = new System.Drawing.Size(120, 28);
            this.reticleHeight.Name = "reticleHeight";
            this.reticleHeight.Size = new System.Drawing.Size(299, 28);
            this.reticleHeight.TabIndex = 3;
            this.reticleHeight.Unit = Gehtsoft.Measurements.AngularUnit.Radian;
            // 
            // reticleWidth
            // 
            this.reticleWidth.Increment = 1D;
            this.reticleWidth.Location = new System.Drawing.Point(116, 63);
            this.reticleWidth.Maximum = 10000D;
            this.reticleWidth.MaximumSize = new System.Drawing.Size(4096, 28);
            this.reticleWidth.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Angular;
            this.reticleWidth.Minimum = -10000D;
            this.reticleWidth.MinimumSize = new System.Drawing.Size(120, 28);
            this.reticleWidth.Name = "reticleWidth";
            this.reticleWidth.Size = new System.Drawing.Size(299, 28);
            this.reticleWidth.TabIndex = 2;
            this.reticleWidth.Unit = Gehtsoft.Measurements.AngularUnit.Radian;
            // 
            // reticleName
            // 
            this.reticleName.Location = new System.Drawing.Point(116, 29);
            this.reticleName.Name = "reticleName";
            this.reticleName.Size = new System.Drawing.Size(637, 27);
            this.reticleName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reticle Parameteters";
            // 
            // ReticleItems
            // 
            this.ReticleItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReticleItems.FormattingEnabled = true;
            this.ReticleItems.ItemHeight = 20;
            this.ReticleItems.Location = new System.Drawing.Point(3, 202);
            this.ReticleItems.Name = "ReticleItems";
            this.ReticleItems.Size = new System.Drawing.Size(1006, 458);
            this.ReticleItems.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 666);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1006, 45);
            this.panel2.TabIndex = 2;
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1529, 718);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AppForm";
            this.Text = "Reticle Editor";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureReticle)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox ReticleItems;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox reticleName;
        private MeasurementControl.MeasurementControl zeroOffsetY;
        private MeasurementControl.MeasurementControl zeroOffsetX;
        private MeasurementControl.MeasurementControl reticleHeight;
        private MeasurementControl.MeasurementControl reticleWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSaveAs;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.PictureBox pictureReticle;
    }
}

