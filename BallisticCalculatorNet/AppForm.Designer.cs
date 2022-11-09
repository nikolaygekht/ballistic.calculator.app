
namespace BallisticCalculatorNet
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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindowsTile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindowsCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileNewImperial = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileNewMetric = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuWindows,
            this.menuHelp});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuMain.Size = new System.Drawing.Size(1552, 33);
            this.menuMain.TabIndex = 1;
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNew,
            this.toolStripSeparator1,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(54, 29);
            this.menuFile.Text = "&File";
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(149, 34);
            this.menuFileExit.Text = "&Exit";
            // 
            // menuWindows
            // 
            this.menuWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuWindowsTile,
            this.menuWindowsCascade});
            this.menuWindows.Name = "menuWindows";
            this.menuWindows.Size = new System.Drawing.Size(102, 29);
            this.menuWindows.Text = "&Windows";
            // 
            // menuWindowsTile
            // 
            this.menuWindowsTile.Name = "menuWindowsTile";
            this.menuWindowsTile.Size = new System.Drawing.Size(179, 34);
            this.menuWindowsTile.Text = "&Tile";
            // 
            // menuWindowsCascade
            // 
            this.menuWindowsCascade.Name = "menuWindowsCascade";
            this.menuWindowsCascade.Size = new System.Drawing.Size(179, 34);
            this.menuWindowsCascade.Text = "&Cascade";
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(65, 29);
            this.menuHelp.Text = "&Help";
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Name = "menuHelpAbout";
            this.menuHelpAbout.Size = new System.Drawing.Size(164, 34);
            this.menuHelpAbout.Text = "&About";
            // 
            // menuFileNew
            // 
            this.menuFileNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNewImperial,
            this.menuFileNewMetric});
            this.menuFileNew.Name = "menuFileNew";
            this.menuFileNew.Size = new System.Drawing.Size(149, 34);
            this.menuFileNew.Text = "New";
            // 
            // menuFileNewImperial
            // 
            this.menuFileNewImperial.Name = "menuFileNewImperial";
            this.menuFileNewImperial.Size = new System.Drawing.Size(270, 34);
            this.menuFileNewImperial.Text = "Imperial";
            // 
            // menuFileNewMetric
            // 
            this.menuFileNewMetric.Name = "menuFileNewMetric";
            this.menuFileNewMetric.Size = new System.Drawing.Size(270, 34);
            this.menuFileNewMetric.Text = "Metric";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1552, 762);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMain;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AppForm";
            this.Text = "Ballistic Calculator.NET";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppForm_FormClosing);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuWindows;
        private System.Windows.Forms.ToolStripMenuItem menuWindowsTile;
        private System.Windows.Forms.ToolStripMenuItem menuWindowsCascade;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem menuFileNew;
        private System.Windows.Forms.ToolStripMenuItem menuFileNewImperial;
        private System.Windows.Forms.ToolStripMenuItem menuFileNewMetric;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

