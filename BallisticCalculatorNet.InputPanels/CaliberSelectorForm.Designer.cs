namespace BallisticCalculatorNet.InputPanels
{
    partial class CaliberSelectorForm
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
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.listViewCalibers = new System.Windows.Forms.ListView();
            this.columnHeaderType = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderDiameter = new System.Windows.Forms.ColumnHeader();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxFind
            // 
            this.textBoxFind.Location = new System.Drawing.Point(12, 12);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(930, 31);
            this.textBoxFind.TabIndex = 0;
            // 
            // buttonFind
            // 
            this.buttonFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonFind.Location = new System.Drawing.Point(948, 12);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(69, 31);
            this.buttonFind.TabIndex = 2;
            this.buttonFind.Text = "Find";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // listViewCalibers
            // 
            this.listViewCalibers.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listViewCalibers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderType,
            this.columnHeaderName,
            this.columnHeaderDiameter});
            this.listViewCalibers.FullRowSelect = true;
            this.listViewCalibers.GridLines = true;
            this.listViewCalibers.Location = new System.Drawing.Point(12, 49);
            this.listViewCalibers.MultiSelect = false;
            this.listViewCalibers.Name = "listViewCalibers";
            this.listViewCalibers.Size = new System.Drawing.Size(1005, 286);
            this.listViewCalibers.TabIndex = 3;
            this.listViewCalibers.UseCompatibleStateImageBehavior = false;
            this.listViewCalibers.View = System.Windows.Forms.View.Details;
            this.listViewCalibers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewCalibers_ColumnClick);
            this.listViewCalibers.SelectedIndexChanged += new System.EventHandler(this.listViewCalibers_SelectedIndexChanged);
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            this.columnHeaderType.Width = 120;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name(s)";
            this.columnHeaderName.Width = 600;
            // 
            // columnHeaderDiameter
            // 
            this.columnHeaderDiameter.Text = "Caliber";
            this.columnHeaderDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderDiameter.Width = 120;
            // 
            // buttonSelect
            // 
            this.buttonSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSelect.Location = new System.Drawing.Point(386, 341);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(112, 34);
            this.buttonSelect.TabIndex = 4;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(504, 341);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 34);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Close";
            this.buttonCancel.UseVisualStyleBackColor = false;
            // 
            // CaliberSelectorForm
            // 
            this.AcceptButton = this.buttonSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(1029, 382);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.listViewCalibers);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.textBoxFind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MdiChildrenMinimizedAnchorBottom = false;
            this.MinimizeBox = false;
            this.Name = "CaliberSelectorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Select Ammunition";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.ListView listViewCalibers;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderDiameter;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonCancel;
    }
}