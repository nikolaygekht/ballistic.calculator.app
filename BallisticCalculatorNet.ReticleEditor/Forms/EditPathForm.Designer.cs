
namespace BallisticCalculatorNet.ReticleEditor.Forms
{
    partial class EditPathForm
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.checkBoxFill = new System.Windows.Forms.CheckBox();
            this.measurementWidth = new BallisticCalculatorNet.MeasurementControl.MeasurementControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxElements = new System.Windows.Forms.ListBox();
            this.picturePreview = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.buttonPreview = new System.Windows.Forms.Button();
            this.buttonMove = new System.Windows.Forms.Button();
            this.buttonLine = new System.Windows.Forms.Button();
            this.buttonArc = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).BeginInit();
            this.SuspendLayout();
            //
            // buttonOK
            //
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(207, 442);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(94, 29);
            this.buttonOK.TabIndex = 100;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            //
            // buttonCancel
            //
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(307, 442);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 29);
            this.buttonCancel.TabIndex = 101;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            //
            // comboBoxColor
            //
            this.comboBoxColor.FormattingEnabled = true;
            this.comboBoxColor.Location = new System.Drawing.Point(156, 45);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(209, 28);
            this.comboBoxColor.TabIndex = 5;
            //
            // checkBoxFill
            //
            this.checkBoxFill.AutoSize = true;
            this.checkBoxFill.Location = new System.Drawing.Point(156, 80);
            this.checkBoxFill.Name = "checkBoxFill";
            this.checkBoxFill.Size = new System.Drawing.Size(50, 24);
            this.checkBoxFill.TabIndex = 6;
            this.checkBoxFill.Text = "Fill";
            this.checkBoxFill.UseVisualStyleBackColor = true;
            //
            // measurementWidth
            //
            this.measurementWidth.Increment = 1D;
            this.measurementWidth.Location = new System.Drawing.Point(156, 11);
            this.measurementWidth.Maximum = 10000D;
            this.measurementWidth.MaximumSize = new System.Drawing.Size(4096, 28);
            this.measurementWidth.MeasurementType = BallisticCalculatorNet.MeasurementControl.MeasurementType.Angular;
            this.measurementWidth.Minimum = -10000D;
            this.measurementWidth.MinimumSize = new System.Drawing.Size(120, 28);
            this.measurementWidth.Name = "measurementWidth";
            this.measurementWidth.Size = new System.Drawing.Size(209, 28);
            this.measurementWidth.TabIndex = 4;
            this.measurementWidth.Unit = Gehtsoft.Measurements.AngularUnit.Mil;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 104;
            this.label3.Text = "Line Width";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 105;
            this.label4.Text = "Color";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 106;
            this.label1.Text = "Elements";
            //
            // listBoxElements
            //
            this.listBoxElements.FormattingEnabled = true;
            this.listBoxElements.ItemHeight = 20;
            this.listBoxElements.Location = new System.Drawing.Point(13, 174);
            this.listBoxElements.Name = "listBoxElements";
            this.listBoxElements.Size = new System.Drawing.Size(394, 224);
            this.listBoxElements.TabIndex = 8;
            //
            // picturePreview
            //
            this.picturePreview.Location = new System.Drawing.Point(431, 174);
            this.picturePreview.Name = "picturePreview";
            this.picturePreview.Size = new System.Drawing.Size(254, 224);
            this.picturePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picturePreview.TabIndex = 107;
            this.picturePreview.TabStop = false;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(431, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 108;
            this.label2.Text = "Preview";
            //
            // buttonUndo
            //
            this.buttonUndo.Location = new System.Drawing.Point(407, 442);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(94, 29);
            this.buttonUndo.TabIndex = 109;
            this.buttonUndo.Text = "Revert";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            //
            // buttonPreview
            //
            this.buttonPreview.Location = new System.Drawing.Point(156, 111);
            this.buttonPreview.Name = "buttonPreview";
            this.buttonPreview.Size = new System.Drawing.Size(94, 29);
            this.buttonPreview.TabIndex = 7;
            this.buttonPreview.Text = "Preview";
            this.buttonPreview.UseVisualStyleBackColor = true;
            this.buttonPreview.Click += new System.EventHandler(this.buttonPreview_Click);
            //
            // buttonMove
            //
            this.buttonMove.Location = new System.Drawing.Point(13, 405);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(94, 29);
            this.buttonMove.TabIndex = 9;
            this.buttonMove.Text = "Move To";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            //
            // buttonLine
            //
            this.buttonLine.Location = new System.Drawing.Point(114, 404);
            this.buttonLine.Name = "buttonLine";
            this.buttonLine.Size = new System.Drawing.Size(94, 29);
            this.buttonLine.TabIndex = 9;
            this.buttonLine.Text = "Line To";
            this.buttonLine.UseVisualStyleBackColor = true;
            this.buttonLine.Click += new System.EventHandler(this.buttonLine_Click);
            //
            // buttonArc
            //
            this.buttonArc.Location = new System.Drawing.Point(215, 404);
            this.buttonArc.Name = "buttonArc";
            this.buttonArc.Size = new System.Drawing.Size(94, 29);
            this.buttonArc.TabIndex = 10;
            this.buttonArc.Text = "Arc";
            this.buttonArc.UseVisualStyleBackColor = true;
            this.buttonArc.Click += new System.EventHandler(this.buttonArc_Click);
            //
            // buttonEdit
            //
            this.buttonEdit.Location = new System.Drawing.Point(313, 404);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(94, 29);
            this.buttonEdit.TabIndex = 11;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            //
            // buttonDelete
            //
            this.buttonDelete.Location = new System.Drawing.Point(413, 404);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(94, 29);
            this.buttonDelete.TabIndex = 12;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            //
            // EditPathForm
            //
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(707, 483);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonArc);
            this.Controls.Add(this.buttonLine);
            this.Controls.Add(this.buttonMove);
            this.Controls.Add(this.buttonPreview);
            this.Controls.Add(this.buttonUndo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picturePreview);
            this.Controls.Add(this.listBoxElements);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.measurementWidth);
            this.Controls.Add(this.checkBoxFill);
            this.Controls.Add(this.comboBoxColor);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditPathForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Path";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditPathForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxColor;
        private System.Windows.Forms.CheckBox checkBoxFill;
        private MeasurementControl.MeasurementControl measurementWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxElements;
        private System.Windows.Forms.PictureBox picturePreview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Button buttonPreview;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.Button buttonLine;
        private System.Windows.Forms.Button buttonArc;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
    }
}