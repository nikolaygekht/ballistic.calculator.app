
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
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            UnitPart = new System.Windows.Forms.ComboBox();
            NumericPart = new System.Windows.Forms.TextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            tableLayoutPanel1.Controls.Add(UnitPart, 1, 0);
            tableLayoutPanel1.Controls.Add(NumericPart, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            tableLayoutPanel1.Size = new System.Drawing.Size(359, 42);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // UnitPart
            // 
            UnitPart.Dock = System.Windows.Forms.DockStyle.Fill;
            UnitPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            UnitPart.FormattingEnabled = true;
            UnitPart.Location = new System.Drawing.Point(239, 0);
            UnitPart.Margin = new System.Windows.Forms.Padding(0);
            UnitPart.Name = "UnitPart";
            UnitPart.Size = new System.Drawing.Size(120, 38);
            UnitPart.TabIndex = 2;
            UnitPart.SelectedIndexChanged += UnitPart_SelectedIndexChanged;
            // 
            // NumericPart
            // 
            NumericPart.Dock = System.Windows.Forms.DockStyle.Fill;
            NumericPart.Location = new System.Drawing.Point(0, 0);
            NumericPart.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            NumericPart.Name = "NumericPart";
            NumericPart.Size = new System.Drawing.Size(234, 35);
            NumericPart.TabIndex = 1;
            NumericPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            NumericPart.TextChanged += NumericPart_TextChanged;
            NumericPart.KeyDown += NumericPart_KeyDown;
            NumericPart.KeyPress += NumericPart_KeyPress;
            // 
            // MeasurementControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new System.Windows.Forms.Padding(5);
            MaximumSize = new System.Drawing.Size(6144, 42);
            MinimumSize = new System.Drawing.Size(180, 42);
            Name = "MeasurementControl";
            Size = new System.Drawing.Size(359, 42);
            Enter += MeasurementControl_Enter;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox UnitPart;
        private System.Windows.Forms.TextBox NumericPart;
    }
}
