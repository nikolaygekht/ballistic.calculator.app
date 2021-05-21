
namespace BallisticCalculatorNet.MeasurementControl
{
    partial class MeasurementControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.UnitPart = new System.Windows.Forms.ComboBox();
            this.NumericPart = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.UnitPart, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.NumericPart, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(239, 28);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // UnitPart
            // 
            this.UnitPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnitPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UnitPart.FormattingEnabled = true;
            this.UnitPart.Location = new System.Drawing.Point(159, 0);
            this.UnitPart.Margin = new System.Windows.Forms.Padding(0);
            this.UnitPart.Name = "UnitPart";
            this.UnitPart.Size = new System.Drawing.Size(80, 28);
            this.UnitPart.TabIndex = 2;
            this.UnitPart.SelectedIndexChanged += new System.EventHandler(this.UnitPart_SelectedIndexChanged);
            // 
            // NumericPart
            // 
            this.NumericPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NumericPart.Location = new System.Drawing.Point(0, 0);
            this.NumericPart.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.NumericPart.Name = "NumericPart";
            this.NumericPart.Size = new System.Drawing.Size(156, 27);
            this.NumericPart.TabIndex = 1;
            this.NumericPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumericPart.TextChanged += new System.EventHandler(this.NumericPart_TextChanged);
            this.NumericPart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumericPart_KeyDown);
            this.NumericPart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericPart_KeyPress);
            // 
            // MeasurementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(4096, 28);
            this.MinimumSize = new System.Drawing.Size(120, 28);
            this.Name = "MeasurementControl";
            this.Size = new System.Drawing.Size(239, 28);
            this.Enter += new System.EventHandler(this.MeasurementControl_Enter);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox UnitPart;
        private System.Windows.Forms.TextBox NumericPart;
    }
}
