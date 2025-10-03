
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
            menuMain = new System.Windows.Forms.MenuStrip();
            menuFile = new System.Windows.Forms.ToolStripMenuItem();
            menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            menuFileNewImperial = new System.Windows.Forms.ToolStripMenuItem();
            menuFileNewMetric = new System.Windows.Forms.ToolStripMenuItem();
            menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            menuFileExportCsv = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            menuView = new System.Windows.Forms.ToolStripMenuItem();
            menuViewEditParameters = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            menuViewSystem = new System.Windows.Forms.ToolStripMenuItem();
            menuViewSystemImperial = new System.Windows.Forms.ToolStripMenuItem();
            menuViewSystemMetric = new System.Windows.Forms.ToolStripMenuItem();
            menuViewAngular = new System.Windows.Forms.ToolStripMenuItem();
            menuViewAngularMOA = new System.Windows.Forms.ToolStripMenuItem();
            menuViewAngularMils = new System.Windows.Forms.ToolStripMenuItem();
            menuViewAngularThousands = new System.Windows.Forms.ToolStripMenuItem();
            menuViewAngularMRads = new System.Windows.Forms.ToolStripMenuItem();
            menuViewAngularInches = new System.Windows.Forms.ToolStripMenuItem();
            menuViewAngularCentimeters = new System.Windows.Forms.ToolStripMenuItem();
            menuViewChart = new System.Windows.Forms.ToolStripMenuItem();
            menuViewChartVelocity = new System.Windows.Forms.ToolStripMenuItem();
            menuViewChartMach = new System.Windows.Forms.ToolStripMenuItem();
            menuViewChartDrop = new System.Windows.Forms.ToolStripMenuItem();
            menuViewChartWindage = new System.Windows.Forms.ToolStripMenuItem();
            menuViewChartEnergy = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            menuViewChartZoomY = new System.Windows.Forms.ToolStripMenuItem();
            menuViewShow = new System.Windows.Forms.ToolStripMenuItem();
            menuViewShowTable = new System.Windows.Forms.ToolStripMenuItem();
            menuViewShowChart = new System.Windows.Forms.ToolStripMenuItem();
            menuViewShowReticle = new System.Windows.Forms.ToolStripMenuItem();
            menuViewCompare = new System.Windows.Forms.ToolStripMenuItem();
            menuViewCompareAdd = new System.Windows.Forms.ToolStripMenuItem();
            menuViewCompareRemoveLast = new System.Windows.Forms.ToolStripMenuItem();
            menuViewDrop = new System.Windows.Forms.ToolStripMenuItem();
            menuViewDropLineOfSight = new System.Windows.Forms.ToolStripMenuItem();
            menuViewDropMuzzleLevel = new System.Windows.Forms.ToolStripMenuItem();
            menuExtensions = new System.Windows.Forms.ToolStripMenuItem();
            menuWindows = new System.Windows.Forms.ToolStripMenuItem();
            menuWindowsTile = new System.Windows.Forms.ToolStripMenuItem();
            menuWindowsCascade = new System.Windows.Forms.ToolStripMenuItem();
            windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            menuMain.SuspendLayout();
            SuspendLayout();
            // 
            // menuMain
            // 
            menuMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            menuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { menuFile, menuView, menuExtensions, menuWindows, menuHelp });
            menuMain.Location = new System.Drawing.Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            menuMain.Size = new System.Drawing.Size(1862, 38);
            menuMain.TabIndex = 1;
            // 
            // menuFile
            // 
            menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuFileNew, menuFileOpen, menuFileSave, menuFileSaveAs, menuFileExportCsv, toolStripSeparator1, menuFileExit });
            menuFile.Name = "menuFile";
            menuFile.Size = new System.Drawing.Size(120, 34);
            menuFile.Text = "&Trajectory";
            // 
            // menuFileNew
            // 
            menuFileNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuFileNewImperial, menuFileNewMetric });
            menuFileNew.Name = "menuFileNew";
            menuFileNew.Size = new System.Drawing.Size(262, 40);
            menuFileNew.Text = "&New";
            // 
            // menuFileNewImperial
            // 
            menuFileNewImperial.Name = "menuFileNewImperial";
            menuFileNewImperial.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I;
            menuFileNewImperial.Size = new System.Drawing.Size(271, 40);
            menuFileNewImperial.Text = "Imperial";
            // 
            // menuFileNewMetric
            // 
            menuFileNewMetric.Name = "menuFileNewMetric";
            menuFileNewMetric.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M;
            menuFileNewMetric.Size = new System.Drawing.Size(271, 40);
            menuFileNewMetric.Text = "Metric";
            // 
            // menuFileOpen
            // 
            menuFileOpen.Name = "menuFileOpen";
            menuFileOpen.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O;
            menuFileOpen.Size = new System.Drawing.Size(262, 40);
            menuFileOpen.Text = "&Open";
            // 
            // menuFileSave
            // 
            menuFileSave.Name = "menuFileSave";
            menuFileSave.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            menuFileSave.Size = new System.Drawing.Size(262, 40);
            menuFileSave.Text = "&Save";
            // 
            // menuFileSaveAs
            // 
            menuFileSaveAs.Name = "menuFileSaveAs";
            menuFileSaveAs.Size = new System.Drawing.Size(262, 40);
            menuFileSaveAs.Text = "Save As";
            // 
            // menuFileExportCsv
            // 
            menuFileExportCsv.Name = "menuFileExportCsv";
            menuFileExportCsv.Size = new System.Drawing.Size(262, 40);
            menuFileExportCsv.Text = "Export As &CSV";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(259, 6);
            // 
            // menuFileExit
            // 
            menuFileExit.Name = "menuFileExit";
            menuFileExit.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X;
            menuFileExit.Size = new System.Drawing.Size(262, 40);
            menuFileExit.Text = "&Exit";
            // 
            // menuView
            // 
            menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuViewEditParameters, toolStripSeparator2, menuViewSystem, menuViewAngular, menuViewDrop, menuViewChart, menuViewShow, menuViewCompare });
            menuView.Name = "menuView";
            menuView.Size = new System.Drawing.Size(75, 34);
            menuView.Text = "&View";
            // 
            // menuViewEditParameters
            // 
            menuViewEditParameters.Name = "menuViewEditParameters";
            menuViewEditParameters.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E;
            menuViewEditParameters.Size = new System.Drawing.Size(345, 40);
            menuViewEditParameters.Text = "&Edit Parameters";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(342, 6);
            // 
            // menuViewSystem
            // 
            menuViewSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuViewSystemImperial, menuViewSystemMetric });
            menuViewSystem.Name = "menuViewSystem";
            menuViewSystem.Size = new System.Drawing.Size(345, 40);
            menuViewSystem.Text = "&Measurement System";
            // 
            // menuViewSystemImperial
            // 
            menuViewSystemImperial.Name = "menuViewSystemImperial";
            menuViewSystemImperial.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.I;
            menuViewSystemImperial.Size = new System.Drawing.Size(327, 40);
            menuViewSystemImperial.Text = "Imperial";
            // 
            // menuViewSystemMetric
            // 
            menuViewSystemMetric.Name = "menuViewSystemMetric";
            menuViewSystemMetric.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.M;
            menuViewSystemMetric.Size = new System.Drawing.Size(327, 40);
            menuViewSystemMetric.Text = "Metric";
            // 
            // menuViewAngular
            // 
            menuViewAngular.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuViewAngularMOA, menuViewAngularMils, menuViewAngularThousands, menuViewAngularMRads, menuViewAngularInches, menuViewAngularCentimeters });
            menuViewAngular.Name = "menuViewAngular";
            menuViewAngular.Size = new System.Drawing.Size(345, 40);
            menuViewAngular.Text = "&Angular Units";
            // 
            // menuViewAngularMOA
            // 
            menuViewAngularMOA.Name = "menuViewAngularMOA";
            menuViewAngularMOA.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A;
            menuViewAngularMOA.Size = new System.Drawing.Size(404, 40);
            menuViewAngularMOA.Text = "Minutes of Angle";
            // 
            // menuViewAngularMils
            // 
            menuViewAngularMils.Name = "menuViewAngularMils";
            menuViewAngularMils.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M;
            menuViewAngularMils.Size = new System.Drawing.Size(404, 40);
            menuViewAngularMils.Text = "Mils";
            // 
            // menuViewAngularThousands
            // 
            menuViewAngularThousands.Name = "menuViewAngularThousands";
            menuViewAngularThousands.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T;
            menuViewAngularThousands.Size = new System.Drawing.Size(404, 40);
            menuViewAngularThousands.Text = "Thousdands";
            // 
            // menuViewAngularMRads
            // 
            menuViewAngularMRads.Name = "menuViewAngularMRads";
            menuViewAngularMRads.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R;
            menuViewAngularMRads.Size = new System.Drawing.Size(404, 40);
            menuViewAngularMRads.Text = "Milliradians";
            // 
            // menuViewAngularInches
            // 
            menuViewAngularInches.Name = "menuViewAngularInches";
            menuViewAngularInches.Size = new System.Drawing.Size(404, 40);
            menuViewAngularInches.Text = "Inches/100 yards";
            // 
            // menuViewAngularCentimeters
            // 
            menuViewAngularCentimeters.Name = "menuViewAngularCentimeters";
            menuViewAngularCentimeters.Size = new System.Drawing.Size(404, 40);
            menuViewAngularCentimeters.Text = "Centimeters/100 meters";
            // 
            // menuViewChart
            // 
            menuViewChart.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuViewChartVelocity, menuViewChartMach, menuViewChartDrop, menuViewChartWindage, menuViewChartEnergy, toolStripSeparator3, menuViewChartZoomY });
            menuViewChart.Name = "menuViewChart";
            menuViewChart.Size = new System.Drawing.Size(345, 40);
            menuViewChart.Text = "&Chart";
            // 
            // menuViewChartVelocity
            // 
            menuViewChartVelocity.Name = "menuViewChartVelocity";
            menuViewChartVelocity.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V;
            menuViewChartVelocity.Size = new System.Drawing.Size(530, 40);
            menuViewChartVelocity.Text = "Velocity";
            // 
            // menuViewChartMach
            // 
            menuViewChartMach.Name = "menuViewChartMach";
            menuViewChartMach.Size = new System.Drawing.Size(530, 40);
            menuViewChartMach.Text = "Mach";
            // 
            // menuViewChartDrop
            // 
            menuViewChartDrop.Name = "menuViewChartDrop";
            menuViewChartDrop.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D;
            menuViewChartDrop.Size = new System.Drawing.Size(530, 40);
            menuViewChartDrop.Text = "Drop";
            // 
            // menuViewChartWindage
            // 
            menuViewChartWindage.Name = "menuViewChartWindage";
            menuViewChartWindage.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.W;
            menuViewChartWindage.Size = new System.Drawing.Size(530, 40);
            menuViewChartWindage.Text = "Windage";
            // 
            // menuViewChartEnergy
            // 
            menuViewChartEnergy.Name = "menuViewChartEnergy";
            menuViewChartEnergy.Size = new System.Drawing.Size(530, 40);
            menuViewChartEnergy.Text = "Energy";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(527, 6);
            // 
            // menuViewChartZoomY
            // 
            menuViewChartZoomY.Name = "menuViewChartZoomY";
            menuViewChartZoomY.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Z;
            menuViewChartZoomY.Size = new System.Drawing.Size(530, 40);
            menuViewChartZoomY.Text = "Zoom Y Axis to Visible Range";
            // 
            // menuViewShow
            // 
            menuViewShow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuViewShowTable, menuViewShowChart, menuViewShowReticle });
            menuViewShow.Name = "menuViewShow";
            menuViewShow.Size = new System.Drawing.Size(345, 40);
            menuViewShow.Text = "Show";
            // 
            // menuViewShowTable
            // 
            menuViewShowTable.Name = "menuViewShowTable";
            menuViewShowTable.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T;
            menuViewShowTable.Size = new System.Drawing.Size(264, 40);
            menuViewShowTable.Text = "Table";
            // 
            // menuViewShowChart
            // 
            menuViewShowChart.Name = "menuViewShowChart";
            menuViewShowChart.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C;
            menuViewShowChart.Size = new System.Drawing.Size(264, 40);
            menuViewShowChart.Text = "Chart";
            // 
            // menuViewShowReticle
            // 
            menuViewShowReticle.Name = "menuViewShowReticle";
            menuViewShowReticle.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R;
            menuViewShowReticle.Size = new System.Drawing.Size(264, 40);
            menuViewShowReticle.Text = "Reticle";
            // 
            // menuViewCompare
            // 
            menuViewCompare.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuViewCompareAdd, menuViewCompareRemoveLast });
            menuViewCompare.Name = "menuViewCompare";
            menuViewCompare.Size = new System.Drawing.Size(345, 40);
            menuViewCompare.Text = "Compare";
            // 
            // menuViewCompareAdd
            // 
            menuViewCompareAdd.Name = "menuViewCompareAdd";
            menuViewCompareAdd.Size = new System.Drawing.Size(315, 40);
            menuViewCompareAdd.Text = "Add";
            // 
            // menuViewCompareRemoveLast
            // 
            menuViewCompareRemoveLast.Name = "menuViewCompareRemoveLast";
            menuViewCompareRemoveLast.Size = new System.Drawing.Size(315, 40);
            menuViewCompareRemoveLast.Text = "Remove Last Added";
            // 
            // menuViewDrop
            // 
            menuViewDrop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuViewDropLineOfSight, menuViewDropMuzzleLevel });
            menuViewDrop.Name = "menuViewDrop";
            menuViewDrop.Size = new System.Drawing.Size(345, 40);
            menuViewDrop.Text = "Drop";
            // 
            // menuViewDropLineOfSight
            // 
            menuViewDropLineOfSight.Name = "menuViewDropLineOfSight";
            menuViewDropLineOfSight.Size = new System.Drawing.Size(315, 40);
            menuViewDropLineOfSight.Text = "Over Line of Sight";
            // 
            // menuViewDropMuzzleLevel
            // 
            menuViewDropMuzzleLevel.Name = "menuViewDropMuzzleLevel";
            menuViewDropMuzzleLevel.Size = new System.Drawing.Size(315, 40);
            menuViewDropMuzzleLevel.Text = "Over Muzzle Level";
            // 
            // menuExtensions
            // 
            menuExtensions.Name = "menuExtensions";
            menuExtensions.Size = new System.Drawing.Size(129, 34);
            menuExtensions.Text = "Extensions";
            // 
            // menuWindows
            // 
            menuWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuWindowsTile, menuWindowsCascade, windowsToolStripMenuItem });
            menuWindows.Name = "menuWindows";
            menuWindows.Size = new System.Drawing.Size(116, 34);
            menuWindows.Text = "&Windows";
            // 
            // menuWindowsTile
            // 
            menuWindowsTile.Name = "menuWindowsTile";
            menuWindowsTile.Size = new System.Drawing.Size(216, 40);
            menuWindowsTile.Text = "&Tile";
            // 
            // menuWindowsCascade
            // 
            menuWindowsCascade.Name = "menuWindowsCascade";
            menuWindowsCascade.Size = new System.Drawing.Size(216, 40);
            menuWindowsCascade.Text = "&Cascade";
            // 
            // windowsToolStripMenuItem
            // 
            windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            windowsToolStripMenuItem.Size = new System.Drawing.Size(216, 40);
            windowsToolStripMenuItem.Text = "&Windows";
            // 
            // menuHelp
            // 
            menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuHelpAbout });
            menuHelp.Name = "menuHelp";
            menuHelp.Size = new System.Drawing.Size(74, 34);
            menuHelp.Text = "&Help";
            // 
            // menuHelpAbout
            // 
            menuHelpAbout.Name = "menuHelpAbout";
            menuHelpAbout.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1;
            menuHelpAbout.Size = new System.Drawing.Size(268, 40);
            menuHelpAbout.Text = "&About";
            // 
            // AppForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1862, 914);
            Controls.Add(menuMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuMain;
            Margin = new System.Windows.Forms.Padding(5);
            Name = "AppForm";
            Text = "Ballistic Calculator.NET";
            FormClosing += AppForm_FormClosing;
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.ToolStripMenuItem menuViewCompare;
        private System.Windows.Forms.ToolStripMenuItem menuViewCompareAdd;
        private System.Windows.Forms.ToolStripMenuItem menuViewCompareRemoveLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuViewChartZoomY;
        private System.Windows.Forms.ToolStripMenuItem menuExtensions;
        private System.Windows.Forms.ToolStripMenuItem menuViewDrop;
        private System.Windows.Forms.ToolStripMenuItem menuViewDropLineOfSight;
        private System.Windows.Forms.ToolStripMenuItem menuViewDropMuzzleLevel;
    }
}

