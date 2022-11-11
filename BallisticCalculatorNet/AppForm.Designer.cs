
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
            this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileNewImperial = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileNewMetric = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExportCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewEditParameters = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuViewSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewSystemImperial = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewSystemMetric = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewAngular = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewAngularMOA = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewAngularMils = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewAngularThousands = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewAngularMRads = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewAngularInches = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewAngularCentimeters = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewChart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewChartVelocity = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewChartMach = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewChartDrop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewChartWindage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewChartEnergy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewShow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewShowTable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewShowChart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewShowReticle = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindowsTile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindowsCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuView,
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
            this.menuFileOpen,
            this.menuFileSave,
            this.menuFileSaveAs,
            this.menuFileExportCsv,
            this.toolStripSeparator1,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(103, 29);
            this.menuFile.Text = "&Trajectory";
            // 
            // menuFileNew
            // 
            this.menuFileNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNewImperial,
            this.menuFileNewMetric});
            this.menuFileNew.Name = "menuFileNew";
            this.menuFileNew.Size = new System.Drawing.Size(270, 34);
            this.menuFileNew.Text = "&New";
            // 
            // menuFileNewImperial
            // 
            this.menuFileNewImperial.Name = "menuFileNewImperial";
            this.menuFileNewImperial.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.menuFileNewImperial.Size = new System.Drawing.Size(234, 34);
            this.menuFileNewImperial.Text = "Imperial";
            // 
            // menuFileNewMetric
            // 
            this.menuFileNewMetric.Name = "menuFileNewMetric";
            this.menuFileNewMetric.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.menuFileNewMetric.Size = new System.Drawing.Size(234, 34);
            this.menuFileNewMetric.Text = "Metric";
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Name = "menuFileOpen";
            this.menuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuFileOpen.Size = new System.Drawing.Size(270, 34);
            this.menuFileOpen.Text = "&Open";
            // 
            // menuFileSave
            // 
            this.menuFileSave.Name = "menuFileSave";
            this.menuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuFileSave.Size = new System.Drawing.Size(270, 34);
            this.menuFileSave.Text = "&Save";
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Name = "menuFileSaveAs";
            this.menuFileSaveAs.Size = new System.Drawing.Size(270, 34);
            this.menuFileSaveAs.Text = "Save As";
            // 
            // menuFileExportCsv
            // 
            this.menuFileExportCsv.Name = "menuFileExportCsv";
            this.menuFileExportCsv.Size = new System.Drawing.Size(270, 34);
            this.menuFileExportCsv.Text = "Export As &CSV";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(267, 6);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menuFileExit.Size = new System.Drawing.Size(270, 34);
            this.menuFileExit.Text = "&Exit";
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewEditParameters,
            this.toolStripSeparator2,
            this.menuViewSystem,
            this.menuViewAngular,
            this.menuViewChart,
            this.menuViewShow});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(65, 29);
            this.menuView.Text = "&View";
            // 
            // menuViewEditParameters
            // 
            this.menuViewEditParameters.Name = "menuViewEditParameters";
            this.menuViewEditParameters.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.menuViewEditParameters.Size = new System.Drawing.Size(296, 34);
            this.menuViewEditParameters.Text = "&Edit Parameters";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(293, 6);
            // 
            // menuViewSystem
            // 
            this.menuViewSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewSystemImperial,
            this.menuViewSystemMetric});
            this.menuViewSystem.Name = "menuViewSystem";
            this.menuViewSystem.Size = new System.Drawing.Size(296, 34);
            this.menuViewSystem.Text = "&Measurement System";
            // 
            // menuViewSystemImperial
            // 
            this.menuViewSystemImperial.Name = "menuViewSystemImperial";
            this.menuViewSystemImperial.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.I)));
            this.menuViewSystemImperial.Size = new System.Drawing.Size(282, 34);
            this.menuViewSystemImperial.Text = "Imperial";
            // 
            // menuViewSystemMetric
            // 
            this.menuViewSystemMetric.Name = "menuViewSystemMetric";
            this.menuViewSystemMetric.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.menuViewSystemMetric.Size = new System.Drawing.Size(282, 34);
            this.menuViewSystemMetric.Text = "Metric";
            // 
            // menuViewAngular
            // 
            this.menuViewAngular.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewAngularMOA,
            this.menuViewAngularMils,
            this.menuViewAngularThousands,
            this.menuViewAngularMRads,
            this.menuViewAngularInches,
            this.menuViewAngularCentimeters});
            this.menuViewAngular.Name = "menuViewAngular";
            this.menuViewAngular.Size = new System.Drawing.Size(296, 34);
            this.menuViewAngular.Text = "&Angular Units";
            // 
            // menuViewAngularMOA
            // 
            this.menuViewAngularMOA.Name = "menuViewAngularMOA";
            this.menuViewAngularMOA.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.A)));
            this.menuViewAngularMOA.Size = new System.Drawing.Size(347, 34);
            this.menuViewAngularMOA.Text = "Minutes of Angle";
            // 
            // menuViewAngularMils
            // 
            this.menuViewAngularMils.Name = "menuViewAngularMils";
            this.menuViewAngularMils.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.M)));
            this.menuViewAngularMils.Size = new System.Drawing.Size(347, 34);
            this.menuViewAngularMils.Text = "Mils";
            // 
            // menuViewAngularThousands
            // 
            this.menuViewAngularThousands.Name = "menuViewAngularThousands";
            this.menuViewAngularThousands.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.T)));
            this.menuViewAngularThousands.Size = new System.Drawing.Size(347, 34);
            this.menuViewAngularThousands.Text = "Thousdands";
            // 
            // menuViewAngularMRads
            // 
            this.menuViewAngularMRads.Name = "menuViewAngularMRads";
            this.menuViewAngularMRads.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.R)));
            this.menuViewAngularMRads.Size = new System.Drawing.Size(347, 34);
            this.menuViewAngularMRads.Text = "Milliradians";
            // 
            // menuViewAngularInches
            // 
            this.menuViewAngularInches.Name = "menuViewAngularInches";
            this.menuViewAngularInches.Size = new System.Drawing.Size(347, 34);
            this.menuViewAngularInches.Text = "Inches/100 yards";
            // 
            // menuViewAngularCentimeters
            // 
            this.menuViewAngularCentimeters.Name = "menuViewAngularCentimeters";
            this.menuViewAngularCentimeters.Size = new System.Drawing.Size(347, 34);
            this.menuViewAngularCentimeters.Text = "Centimeters/100 meters";
            // 
            // menuViewChart
            // 
            this.menuViewChart.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewChartVelocity,
            this.menuViewChartMach,
            this.menuViewChartDrop,
            this.menuViewChartWindage,
            this.menuViewChartEnergy});
            this.menuViewChart.Name = "menuViewChart";
            this.menuViewChart.Size = new System.Drawing.Size(296, 34);
            this.menuViewChart.Text = "&Chart";
            // 
            // menuViewChartVelocity
            // 
            this.menuViewChartVelocity.Name = "menuViewChartVelocity";
            this.menuViewChartVelocity.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.V)));
            this.menuViewChartVelocity.Size = new System.Drawing.Size(287, 34);
            this.menuViewChartVelocity.Text = "Velocity";
            // 
            // menuViewChartMach
            // 
            this.menuViewChartMach.Name = "menuViewChartMach";
            this.menuViewChartMach.Size = new System.Drawing.Size(287, 34);
            this.menuViewChartMach.Text = "Mach";
            // 
            // menuViewChartDrop
            // 
            this.menuViewChartDrop.Name = "menuViewChartDrop";
            this.menuViewChartDrop.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.D)));
            this.menuViewChartDrop.Size = new System.Drawing.Size(287, 34);
            this.menuViewChartDrop.Text = "Drop";
            // 
            // menuViewChartWindage
            // 
            this.menuViewChartWindage.Name = "menuViewChartWindage";
            this.menuViewChartWindage.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.W)));
            this.menuViewChartWindage.Size = new System.Drawing.Size(287, 34);
            this.menuViewChartWindage.Text = "Windage";
            // 
            // menuViewChartEnergy
            // 
            this.menuViewChartEnergy.Name = "menuViewChartEnergy";
            this.menuViewChartEnergy.Size = new System.Drawing.Size(287, 34);
            this.menuViewChartEnergy.Text = "Energy";
            // 
            // menuViewShow
            // 
            this.menuViewShow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewShowTable,
            this.menuViewShowChart,
            this.menuViewShowReticle});
            this.menuViewShow.Name = "menuViewShow";
            this.menuViewShow.Size = new System.Drawing.Size(296, 34);
            this.menuViewShow.Text = "Show";
            // 
            // menuViewShowTable
            // 
            this.menuViewShowTable.Name = "menuViewShowTable";
            this.menuViewShowTable.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.menuViewShowTable.Size = new System.Drawing.Size(226, 34);
            this.menuViewShowTable.Text = "Table";
            // 
            // menuViewShowChart
            // 
            this.menuViewShowChart.Name = "menuViewShowChart";
            this.menuViewShowChart.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.menuViewShowChart.Size = new System.Drawing.Size(226, 34);
            this.menuViewShowChart.Text = "Chart";
            // 
            // menuViewShowReticle
            // 
            this.menuViewShowReticle.Name = "menuViewShowReticle";
            this.menuViewShowReticle.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.menuViewShowReticle.Size = new System.Drawing.Size(226, 34);
            this.menuViewShowReticle.Text = "Reticle";
            // 
            // menuWindows
            // 
            this.menuWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuWindowsTile,
            this.menuWindowsCascade,
            this.windowsToolStripMenuItem});
            this.menuWindows.Name = "menuWindows";
            this.menuWindows.Size = new System.Drawing.Size(102, 29);
            this.menuWindows.Text = "&Windows";
            // 
            // menuWindowsTile
            // 
            this.menuWindowsTile.Name = "menuWindowsTile";
            this.menuWindowsTile.Size = new System.Drawing.Size(270, 34);
            this.menuWindowsTile.Text = "&Tile";
            // 
            // menuWindowsCascade
            // 
            this.menuWindowsCascade.Name = "menuWindowsCascade";
            this.menuWindowsCascade.Size = new System.Drawing.Size(270, 34);
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
            this.menuHelpAbout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.menuHelpAbout.Size = new System.Drawing.Size(270, 34);
            this.menuHelpAbout.Text = "&About";
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.windowsToolStripMenuItem.Text = "&Windows";
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
        private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem menuFileSave;
        private System.Windows.Forms.ToolStripMenuItem menuFileExportCsv;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem menuViewSystem;
        private System.Windows.Forms.ToolStripMenuItem menuViewSystemImperial;
        private System.Windows.Forms.ToolStripMenuItem menuViewSystemMetric;
        private System.Windows.Forms.ToolStripMenuItem menuViewAngular;
        private System.Windows.Forms.ToolStripMenuItem menuViewAngularMOA;
        private System.Windows.Forms.ToolStripMenuItem menuViewAngularMils;
        private System.Windows.Forms.ToolStripMenuItem menuViewAngularThousands;
        private System.Windows.Forms.ToolStripMenuItem menuViewAngularMRads;
        private System.Windows.Forms.ToolStripMenuItem menuViewAngularInches;
        private System.Windows.Forms.ToolStripMenuItem menuViewAngularCentimeters;
        private System.Windows.Forms.ToolStripMenuItem menuFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuViewEditParameters;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuViewChart;
        private System.Windows.Forms.ToolStripMenuItem menuViewChartVelocity;
        private System.Windows.Forms.ToolStripMenuItem menuViewChartMach;
        private System.Windows.Forms.ToolStripMenuItem menuViewChartDrop;
        private System.Windows.Forms.ToolStripMenuItem menuViewChartWindage;
        private System.Windows.Forms.ToolStripMenuItem menuViewChartEnergy;
        private System.Windows.Forms.ToolStripMenuItem menuViewShow;
        private System.Windows.Forms.ToolStripMenuItem menuViewShowTable;
        private System.Windows.Forms.ToolStripMenuItem menuViewShowChart;
        private System.Windows.Forms.ToolStripMenuItem menuViewShowReticle;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
    }
}

