namespace Hugate.Parking
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.barManagerMain = new DevExpress.XtraBars.BarManager(this.components);
            this.TopBar = new DevExpress.XtraBars.Bar();
            this.bbtnSystem = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbtnIn = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbtnOut = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbtnPublic = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbtnVehiclesType = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbtnSearch = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btbnDeleteCard = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbtnReports = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbtnHelp = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbtnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.MdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.defaultLookAndFeelMain = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.bbtnDatabaseOptions = new DevExpress.XtraBars.BarLargeButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MdiManager)).BeginInit();
            this.SuspendLayout();
            // 
            // barManagerMain
            // 
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.TopBar});
            this.barManagerMain.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("TopMenuBar", new System.Guid("0551a6f2-ea3e-4c96-8da2-0fcaa762ba52"))});
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbtnIn,
            this.bbtnOut,
            this.bbtnExit,
            this.bbtnHelp,
            this.bbtnSystem,
            this.bbtnReports,
            this.bbtnPublic,
            this.bbtnSearch,
            this.bbtnVehiclesType,
            this.btbnDeleteCard,
            this.bbtnDatabaseOptions});
            this.barManagerMain.MaxItemId = 17;
            // 
            // TopBar
            // 
            this.TopBar.BarName = "Tools";
            this.TopBar.DockCol = 0;
            this.TopBar.DockRow = 0;
            this.TopBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.TopBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnSystem, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbtnDatabaseOptions, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnIn, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnOut),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnPublic),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnVehiclesType, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnSearch, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btbnDeleteCard),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnReports),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnHelp, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnExit)});
            this.TopBar.OptionsBar.DisableClose = true;
            this.TopBar.OptionsBar.DisableCustomization = true;
            this.TopBar.OptionsBar.DrawDragBorder = false;
            this.TopBar.Text = "Tools";
            // 
            // bbtnSystem
            // 
            this.bbtnSystem.Caption = "Hệ thống";
            this.bbtnSystem.CategoryGuid = new System.Guid("0551a6f2-ea3e-4c96-8da2-0fcaa762ba52");
            this.bbtnSystem.Id = 10;
            this.bbtnSystem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbtnSystem.LargeGlyph")));
            this.bbtnSystem.Name = "bbtnSystem";
            this.bbtnSystem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnSystem_ItemClick);
            // 
            // bbtnIn
            // 
            this.bbtnIn.Caption = "Lối vào";
            this.bbtnIn.CategoryGuid = new System.Guid("0551a6f2-ea3e-4c96-8da2-0fcaa762ba52");
            this.bbtnIn.Id = 5;
            this.bbtnIn.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbtnIn.LargeGlyph")));
            this.bbtnIn.Name = "bbtnIn";
            this.bbtnIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnIn_ItemClick);
            // 
            // bbtnOut
            // 
            this.bbtnOut.Caption = "Lối ra";
            this.bbtnOut.CategoryGuid = new System.Guid("0551a6f2-ea3e-4c96-8da2-0fcaa762ba52");
            this.bbtnOut.Id = 6;
            this.bbtnOut.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbtnOut.LargeGlyph")));
            this.bbtnOut.Name = "bbtnOut";
            this.bbtnOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnOut_ItemClick);
            // 
            // bbtnPublic
            // 
            this.bbtnPublic.Caption = "Lối chung";
            this.bbtnPublic.Id = 12;
            this.bbtnPublic.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbtnPublic.LargeGlyph")));
            this.bbtnPublic.Name = "bbtnPublic";
            this.bbtnPublic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnPublic_ItemClick);
            // 
            // bbtnVehiclesType
            // 
            this.bbtnVehiclesType.Caption = "Loại xe và giá";
            this.bbtnVehiclesType.Id = 14;
            this.bbtnVehiclesType.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbtnVehiclesType.LargeGlyph")));
            this.bbtnVehiclesType.Name = "bbtnVehiclesType";
            this.bbtnVehiclesType.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnVehiclesType_ItemClick);
            // 
            // bbtnSearch
            // 
            this.bbtnSearch.Caption = "Tìm kiếm";
            this.bbtnSearch.Id = 13;
            this.bbtnSearch.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbtnSearch.LargeGlyph")));
            this.bbtnSearch.Name = "bbtnSearch";
            this.bbtnSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnSearch_ItemClick);
            // 
            // btbnDeleteCard
            // 
            this.btbnDeleteCard.Caption = "Xóa thẻ lỗi";
            this.btbnDeleteCard.Id = 15;
            this.btbnDeleteCard.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btbnDeleteCard.LargeGlyph")));
            this.btbnDeleteCard.Name = "btbnDeleteCard";
            this.btbnDeleteCard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btbnDeleteCard_ItemClick);
            // 
            // bbtnReports
            // 
            this.bbtnReports.Caption = "Báo cáo";
            this.bbtnReports.Id = 11;
            this.bbtnReports.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbtnReports.LargeGlyph")));
            this.bbtnReports.Name = "bbtnReports";
            this.bbtnReports.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnReports_ItemClick);
            // 
            // bbtnHelp
            // 
            this.bbtnHelp.Caption = "Hỗ trợ";
            this.bbtnHelp.CategoryGuid = new System.Guid("0551a6f2-ea3e-4c96-8da2-0fcaa762ba52");
            this.bbtnHelp.Id = 8;
            this.bbtnHelp.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbtnHelp.LargeGlyph")));
            this.bbtnHelp.Name = "bbtnHelp";
            // 
            // bbtnExit
            // 
            this.bbtnExit.Caption = "Thoát";
            this.bbtnExit.CategoryGuid = new System.Guid("0551a6f2-ea3e-4c96-8da2-0fcaa762ba52");
            this.bbtnExit.Id = 7;
            this.bbtnExit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbtnExit.LargeGlyph")));
            this.bbtnExit.Name = "bbtnExit";
            this.bbtnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnExit_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1008, 61);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 742);
            this.barDockControlBottom.Size = new System.Drawing.Size(1008, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 61);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 681);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1008, 61);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 681);
            // 
            // MdiManager
            // 
            this.MdiManager.AllowDragDrop = DevExpress.Utils.DefaultBoolean.True;
            this.MdiManager.AppearancePage.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MdiManager.AppearancePage.Header.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MdiManager.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MdiManager.AppearancePage.Header.Options.UseBackColor = true;
            this.MdiManager.AppearancePage.Header.Options.UseFont = true;
            this.MdiManager.AppearancePage.Header.Options.UseForeColor = true;
            this.MdiManager.AppearancePage.Header.Options.UseTextOptions = true;
            this.MdiManager.AppearancePage.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MdiManager.AppearancePage.Header.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.MdiManager.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.MdiManager.FloatOnDrag = DevExpress.Utils.DefaultBoolean.True;
            this.MdiManager.FloatPageDragMode = DevExpress.XtraTabbedMdi.FloatPageDragMode.Preview;
            this.MdiManager.HeaderButtons = DevExpress.XtraTab.TabButtons.Close;
            this.MdiManager.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.Always;
            this.MdiManager.MdiParent = this;
            this.MdiManager.SetNextMdiChildMode = DevExpress.XtraTabbedMdi.SetNextMdiChildMode.Windows;
            this.MdiManager.ShowFloatingDropHint = DevExpress.Utils.DefaultBoolean.False;
            this.MdiManager.ShowToolTips = DevExpress.Utils.DefaultBoolean.True;
            this.MdiManager.SelectedPageChanged += new System.EventHandler(this.MdiManager_SelectedPageChanged);
            this.MdiManager.PageAdded += new DevExpress.XtraTabbedMdi.MdiTabPageEventHandler(this.MdiManager_PageAdded);
            // 
            // defaultLookAndFeelMain
            // 
            this.defaultLookAndFeelMain.LookAndFeel.SkinName = "Blue";
            // 
            // bbtnDatabaseOptions
            // 
            this.bbtnDatabaseOptions.Caption = "Dữ liệu";
            this.bbtnDatabaseOptions.Id = 16;
            this.bbtnDatabaseOptions.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbtnDatabaseOptions.LargeGlyph")));
            this.bbtnDatabaseOptions.Name = "bbtnDatabaseOptions";
            this.bbtnDatabaseOptions.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnDatabaseOptions_ItemClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 742);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý phương tiện ra vào  - Giải pháp Hugate";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MdiManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Bar TopBar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem bbtnIn;
        private DevExpress.XtraBars.BarLargeButtonItem bbtnOut;
        private DevExpress.XtraBars.BarLargeButtonItem bbtnExit;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager MdiManager;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeelMain;
        private DevExpress.XtraBars.BarLargeButtonItem bbtnHelp;
        private DevExpress.XtraBars.BarLargeButtonItem bbtnSystem;
        private DevExpress.XtraBars.BarLargeButtonItem bbtnReports;
        private DevExpress.XtraBars.BarLargeButtonItem bbtnPublic;
        private DevExpress.XtraBars.BarLargeButtonItem bbtnSearch;
        private DevExpress.XtraBars.BarLargeButtonItem bbtnVehiclesType;
        private DevExpress.XtraBars.BarLargeButtonItem btbnDeleteCard;
        public DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.BarLargeButtonItem bbtnDatabaseOptions;
    }
}