namespace BallisticCalculatorNet.InputPanels
{
    partial class TrajectoryControl
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
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeaderDistance = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderVelocity = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderMach = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderPath = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderHold = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderVClicks = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderWindage = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderWindageAdjustment = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderHClicks = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTime = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderEnergy = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderOGW = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderHidden = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderHidden,
            this.columnHeaderDistance,
            this.columnHeaderVelocity,
            this.columnHeaderMach,
            this.columnHeaderPath,
            this.columnHeaderHold,
            this.columnHeaderVClicks,
            this.columnHeaderWindage,
            this.columnHeaderWindageAdjustment,
            this.columnHeaderHClicks,
            this.columnHeaderTime,
            this.columnHeaderEnergy,
            this.columnHeaderOGW});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.LabelWrap = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(1058, 435);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            // 
            // columnHeaderDistance
            // 
            this.columnHeaderDistance.Text = "Range";
            this.columnHeaderDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderDistance.Width = 75;
            // 
            // columnHeaderVelocity
            // 
            this.columnHeaderVelocity.Text = "Velocity";
            this.columnHeaderVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderVelocity.Width = 75;
            // 
            // columnHeaderMach
            // 
            this.columnHeaderMach.Text = "Mach";
            this.columnHeaderMach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeaderPath
            // 
            this.columnHeaderPath.Text = "Path";
            this.columnHeaderPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderPath.Width = 75;
            // 
            // columnHeaderHold
            // 
            this.columnHeaderHold.Text = "Hold";
            this.columnHeaderHold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderHold.Width = 75;
            // 
            // columnHeaderVClicks
            // 
            this.columnHeaderVClicks.Text = "Clicks";
            this.columnHeaderVClicks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeaderWindage
            // 
            this.columnHeaderWindage.Text = "Windage";
            this.columnHeaderWindage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderWindage.Width = 75;
            // 
            // columnHeaderWindageAdjustment
            // 
            this.columnHeaderWindageAdjustment.Text = "Wnd. Adj.";
            this.columnHeaderWindageAdjustment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderWindageAdjustment.Width = 75;
            // 
            // columnHeaderHClicks
            // 
            this.columnHeaderHClicks.Text = "Clicks";
            this.columnHeaderHClicks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "Flight Time";
            this.columnHeaderTime.Width = 75;
            // 
            // columnHeaderEnergy
            // 
            this.columnHeaderEnergy.Text = "Energy";
            this.columnHeaderEnergy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderEnergy.Width = 75;
            // 
            // columnHeaderOGW
            // 
            this.columnHeaderOGW.Text = "O.G.W.";
            this.columnHeaderOGW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderOGW.Width = 75;
            // 
            // columnHeaderHidden
            // 
            this.columnHeaderHidden.Text = "Hidden";
            this.columnHeaderHidden.Width = 0;
            // 
            // TrajectoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Name = "TrajectoryControl";
            this.Size = new System.Drawing.Size(1058, 435);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeaderDistance;
        private System.Windows.Forms.ColumnHeader columnHeaderVelocity;
        private System.Windows.Forms.ColumnHeader columnHeaderMach;
        private System.Windows.Forms.ColumnHeader columnHeaderPath;
        private System.Windows.Forms.ColumnHeader columnHeaderHold;
        private System.Windows.Forms.ColumnHeader columnHeaderVClicks;
        private System.Windows.Forms.ColumnHeader columnHeaderWindage;
        private System.Windows.Forms.ColumnHeader columnHeaderWindageAdjustment;
        private System.Windows.Forms.ColumnHeader columnHeaderHClicks;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.ColumnHeader columnHeaderEnergy;
        private System.Windows.Forms.ColumnHeader columnHeaderOGW;
        private System.Windows.Forms.ColumnHeader columnHeaderHidden;
    }
}
