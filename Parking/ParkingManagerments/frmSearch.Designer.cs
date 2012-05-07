namespace Hugate.Parking
{
    partial class frmSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch));
            this.grFront = new DevExpress.XtraEditors.GroupControl();
            this.frontPic = new DevExpress.XtraEditors.PictureEdit();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRFID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvOut = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTimeIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gteTimeIn = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.colTimeOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gteTimeOut = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.grcOut = new DevExpress.XtraGrid.GridControl();
            this.grbGrid = new DevExpress.XtraEditors.GroupControl();
            this.grbInfo = new DevExpress.XtraEditors.GroupControl();
            this.rdbSearch = new DevExpress.XtraEditors.RadioGroup();
            this.chkTime = new DevExpress.XtraEditors.CheckEdit();
            this.chkNumber = new DevExpress.XtraEditors.CheckEdit();
            this.chkRFID = new DevExpress.XtraEditors.CheckEdit();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtRFID = new DevExpress.XtraEditors.TextEdit();
            this.txtNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblNumber = new DevExpress.XtraEditors.LabelControl();
            this.lblTimeIn = new DevExpress.XtraEditors.LabelControl();
            this.lblRFID = new DevExpress.XtraEditors.LabelControl();
            this.fromDate = new DevExpress.XtraEditors.DateEdit();
            this.toDate = new DevExpress.XtraEditors.DateEdit();
            this.fromTime = new DevExpress.XtraEditors.TimeEdit();
            this.toTime = new DevExpress.XtraEditors.TimeEdit();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grbBack = new DevExpress.XtraEditors.GroupControl();
            this.backPic = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grFront)).BeginInit();
            this.grFront.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frontPic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gteTimeIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gteTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbGrid)).BeginInit();
            this.grbGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbInfo)).BeginInit();
            this.grbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdbSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRFID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbBack)).BeginInit();
            this.grbBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backPic.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grFront
            // 
            this.grFront.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grFront.AppearanceCaption.Options.UseFont = true;
            this.grFront.AppearanceCaption.Options.UseTextOptions = true;
            this.grFront.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grFront.Controls.Add(this.frontPic);
            this.grFront.Location = new System.Drawing.Point(0, 8);
            this.grFront.Name = "grFront";
            this.grFront.Size = new System.Drawing.Size(332, 270);
            this.grFront.TabIndex = 2;
            this.grFront.Text = "Hình ảnh phía trước";
            // 
            // frontPic
            // 
            this.frontPic.Location = new System.Drawing.Point(5, 25);
            this.frontPic.MaximumSize = new System.Drawing.Size(320, 240);
            this.frontPic.MinimumSize = new System.Drawing.Size(320, 240);
            this.frontPic.Name = "frontPic";
            this.frontPic.Size = new System.Drawing.Size(320, 240);
            this.frontPic.TabIndex = 0;
            // 
            // colNumber
            // 
            this.colNumber.Caption = "Biển số xe";
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.OptionsColumn.AllowEdit = false;
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 1;
            this.colNumber.Width = 131;
            // 
            // colRFID
            // 
            this.colRFID.Caption = "Số thẻ";
            this.colRFID.FieldName = "RFID";
            this.colRFID.Name = "colRFID";
            this.colRFID.OptionsColumn.AllowEdit = false;
            this.colRFID.Visible = true;
            this.colRFID.VisibleIndex = 0;
            this.colRFID.Width = 131;
            // 
            // grvOut
            // 
            this.grvOut.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvOut.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvOut.Appearance.Row.Options.UseTextOptions = true;
            this.grvOut.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvOut.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRFID,
            this.colNumber,
            this.colTimeIn,
            this.colTimeOut});
            this.grvOut.GridControl = this.grcOut;
            this.grvOut.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.grvOut.Name = "grvOut";
            this.grvOut.OptionsBehavior.Editable = false;
            this.grvOut.OptionsView.ShowGroupPanel = false;
            this.grvOut.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvOut_FocusedRowChanged);
            // 
            // colTimeIn
            // 
            this.colTimeIn.Caption = "Thời gian vào";
            this.colTimeIn.ColumnEdit = this.gteTimeIn;
            this.colTimeIn.FieldName = "TimeIn";
            this.colTimeIn.Name = "colTimeIn";
            this.colTimeIn.Visible = true;
            this.colTimeIn.VisibleIndex = 2;
            this.colTimeIn.Width = 200;
            // 
            // gteTimeIn
            // 
            this.gteTimeIn.AutoHeight = false;
            this.gteTimeIn.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.gteTimeIn.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.gteTimeIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gteTimeIn.EditFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.gteTimeIn.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gteTimeIn.Mask.EditMask = "dd-MM-yyyy HH:mm";
            this.gteTimeIn.Name = "gteTimeIn";
            // 
            // colTimeOut
            // 
            this.colTimeOut.Caption = "Thời gian ra";
            this.colTimeOut.ColumnEdit = this.gteTimeOut;
            this.colTimeOut.FieldName = "TimeOut";
            this.colTimeOut.Name = "colTimeOut";
            this.colTimeOut.Visible = true;
            this.colTimeOut.VisibleIndex = 3;
            this.colTimeOut.Width = 184;
            // 
            // gteTimeOut
            // 
            this.gteTimeOut.AutoHeight = false;
            this.gteTimeOut.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.gteTimeOut.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.gteTimeOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gteTimeOut.EditFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.gteTimeOut.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gteTimeOut.Mask.EditMask = "dd-MM-yyyy HH:mm";
            this.gteTimeOut.Name = "gteTimeOut";
            // 
            // grcOut
            // 
            this.grcOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcOut.Location = new System.Drawing.Point(2, 22);
            this.grcOut.MainView = this.grvOut;
            this.grcOut.Name = "grcOut";
            this.grcOut.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gteTimeIn,
            this.gteTimeOut});
            this.grcOut.Size = new System.Drawing.Size(664, 295);
            this.grcOut.TabIndex = 0;
            this.grcOut.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvOut});
            // 
            // grbGrid
            // 
            this.grbGrid.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbGrid.AppearanceCaption.Options.UseFont = true;
            this.grbGrid.AppearanceCaption.Options.UseTextOptions = true;
            this.grbGrid.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grbGrid.Controls.Add(this.grcOut);
            this.grbGrid.Location = new System.Drawing.Point(340, 235);
            this.grbGrid.Name = "grbGrid";
            this.grbGrid.Size = new System.Drawing.Size(668, 319);
            this.grbGrid.TabIndex = 1;
            this.grbGrid.Text = "Danh sách kết quả";
            // 
            // grbInfo
            // 
            this.grbInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbInfo.AppearanceCaption.Options.UseFont = true;
            this.grbInfo.AppearanceCaption.Options.UseTextOptions = true;
            this.grbInfo.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grbInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.grbInfo.Controls.Add(this.rdbSearch);
            this.grbInfo.Controls.Add(this.chkTime);
            this.grbInfo.Controls.Add(this.chkNumber);
            this.grbInfo.Controls.Add(this.chkRFID);
            this.grbInfo.Controls.Add(this.btnClear);
            this.grbInfo.Controls.Add(this.btnSearch);
            this.grbInfo.Controls.Add(this.txtRFID);
            this.grbInfo.Controls.Add(this.txtNumber);
            this.grbInfo.Controls.Add(this.labelControl1);
            this.grbInfo.Controls.Add(this.lblNumber);
            this.grbInfo.Controls.Add(this.lblTimeIn);
            this.grbInfo.Controls.Add(this.lblRFID);
            this.grbInfo.Controls.Add(this.fromDate);
            this.grbInfo.Controls.Add(this.toDate);
            this.grbInfo.Controls.Add(this.fromTime);
            this.grbInfo.Controls.Add(this.toTime);
            this.grbInfo.Location = new System.Drawing.Point(340, 8);
            this.grbInfo.Name = "grbInfo";
            this.grbInfo.Size = new System.Drawing.Size(668, 221);
            this.grbInfo.TabIndex = 0;
            this.grbInfo.Text = "Thông tin tìm kiếm";
            // 
            // rdbSearch
            // 
            this.rdbSearch.EditValue = true;
            this.rdbSearch.Location = new System.Drawing.Point(16, 32);
            this.rdbSearch.Name = "rdbSearch";
            this.rdbSearch.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Thông tin xe vào"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Thông tin xe ra")});
            this.rdbSearch.Size = new System.Drawing.Size(269, 23);
            this.rdbSearch.TabIndex = 0;
            this.rdbSearch.SelectedIndexChanged += new System.EventHandler(this.rdbSearch_SelectedIndexChanged);
            // 
            // chkTime
            // 
            this.chkTime.Location = new System.Drawing.Point(14, 149);
            this.chkTime.Name = "chkTime";
            this.chkTime.Properties.Caption = "Theo thời gian";
            this.chkTime.Size = new System.Drawing.Size(96, 19);
            this.chkTime.TabIndex = 5;
            this.chkTime.CheckedChanged += new System.EventHandler(this.chkTime_CheckedChanged);
            // 
            // chkNumber
            // 
            this.chkNumber.Location = new System.Drawing.Point(14, 105);
            this.chkNumber.Name = "chkNumber";
            this.chkNumber.Properties.Caption = "Theo biển số";
            this.chkNumber.Size = new System.Drawing.Size(96, 19);
            this.chkNumber.TabIndex = 3;
            this.chkNumber.CheckedChanged += new System.EventHandler(this.chkNumber_CheckedChanged);
            // 
            // chkRFID
            // 
            this.chkRFID.Location = new System.Drawing.Point(14, 61);
            this.chkRFID.Name = "chkRFID";
            this.chkRFID.Properties.Caption = "Theo số thẻ";
            this.chkRFID.Size = new System.Drawing.Size(96, 19);
            this.chkRFID.TabIndex = 1;
            this.chkRFID.CheckedChanged += new System.EventHandler(this.chkRFID_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.Location = new System.Drawing.Point(482, 86);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 46);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Huỷ";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(386, 86);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 46);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtRFID
            // 
            this.txtRFID.Location = new System.Drawing.Point(123, 82);
            this.txtRFID.Name = "txtRFID";
            this.txtRFID.Size = new System.Drawing.Size(162, 20);
            this.txtRFID.TabIndex = 2;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(123, 126);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(162, 20);
            this.txtNumber.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(47, 200);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Đến ngày";
            // 
            // lblNumber
            // 
            this.lblNumber.Location = new System.Drawing.Point(47, 130);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(56, 13);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "Biển số xe :";
            // 
            // lblTimeIn
            // 
            this.lblTimeIn.Location = new System.Drawing.Point(47, 174);
            this.lblTimeIn.Name = "lblTimeIn";
            this.lblTimeIn.Size = new System.Drawing.Size(40, 13);
            this.lblTimeIn.TabIndex = 2;
            this.lblTimeIn.Text = "Từ ngày";
            // 
            // lblRFID
            // 
            this.lblRFID.Location = new System.Drawing.Point(47, 86);
            this.lblRFID.Name = "lblRFID";
            this.lblRFID.Size = new System.Drawing.Size(38, 13);
            this.lblRFID.TabIndex = 2;
            this.lblRFID.Text = "Số thẻ :";
            // 
            // fromDate
            // 
            this.fromDate.EditValue = new System.DateTime(2011, 10, 20, 0, 0, 0, 0);
            this.fromDate.Location = new System.Drawing.Point(123, 170);
            this.fromDate.Name = "fromDate";
            this.fromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.fromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.fromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fromDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.fromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.fromDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.fromDate.Size = new System.Drawing.Size(86, 20);
            this.fromDate.TabIndex = 6;
            // 
            // toDate
            // 
            this.toDate.EditValue = new System.DateTime(2011, 10, 20, 0, 0, 0, 0);
            this.toDate.Location = new System.Drawing.Point(123, 196);
            this.toDate.Name = "toDate";
            this.toDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.toDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.toDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.toDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.toDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.toDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.toDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.toDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.toDate.Size = new System.Drawing.Size(86, 20);
            this.toDate.TabIndex = 8;
            // 
            // fromTime
            // 
            this.fromTime.EditValue = new System.DateTime(2011, 11, 30, 0, 0, 0, 0);
            this.fromTime.Location = new System.Drawing.Point(215, 170);
            this.fromTime.Name = "fromTime";
            this.fromTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.fromTime.Properties.DisplayFormat.FormatString = "HH:mm";
            this.fromTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fromTime.Properties.EditFormat.FormatString = "t";
            this.fromTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fromTime.Properties.Mask.EditMask = "HH:mm";
            this.fromTime.Size = new System.Drawing.Size(70, 20);
            this.fromTime.TabIndex = 7;
            // 
            // toTime
            // 
            this.toTime.EditValue = new System.DateTime(2011, 11, 30, 0, 0, 0, 0);
            this.toTime.Location = new System.Drawing.Point(215, 196);
            this.toTime.Name = "toTime";
            this.toTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.toTime.Properties.DisplayFormat.FormatString = "HH:mm";
            this.toTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.toTime.Properties.EditFormat.FormatString = "HH:mm";
            this.toTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.toTime.Properties.Mask.EditMask = "HH:mm";
            this.toTime.Size = new System.Drawing.Size(70, 20);
            this.toTime.TabIndex = 9;
            // 
            // colName
            // 
            this.colName.Caption = "Loại xe";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            // 
            // grbBack
            // 
            this.grbBack.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBack.AppearanceCaption.Options.UseFont = true;
            this.grbBack.AppearanceCaption.Options.UseTextOptions = true;
            this.grbBack.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grbBack.Controls.Add(this.backPic);
            this.grbBack.Location = new System.Drawing.Point(0, 284);
            this.grbBack.Name = "grbBack";
            this.grbBack.Size = new System.Drawing.Size(332, 270);
            this.grbBack.TabIndex = 3;
            this.grbBack.Text = "Hình ảnh phía sau";
            // 
            // backPic
            // 
            this.backPic.Location = new System.Drawing.Point(5, 25);
            this.backPic.MaximumSize = new System.Drawing.Size(320, 240);
            this.backPic.MinimumSize = new System.Drawing.Size(320, 240);
            this.backPic.Name = "backPic";
            this.backPic.Size = new System.Drawing.Size(320, 240);
            this.backPic.TabIndex = 0;
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.grFront);
            this.Controls.Add(this.grbGrid);
            this.Controls.Add(this.grbInfo);
            this.Controls.Add(this.grbBack);
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "frmSearch";
            this.Text = "Tìm kiếm";
            this.Activated += new System.EventHandler(this.frmSearch_Activated);
            this.Deactivate += new System.EventHandler(this.frmSearch_Deactivate);
            this.Load += new System.EventHandler(this.frmSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grFront)).EndInit();
            this.grFront.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.frontPic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gteTimeIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gteTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbGrid)).EndInit();
            this.grbGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grbInfo)).EndInit();
            this.grbInfo.ResumeLayout(false);
            this.grbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdbSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRFID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbBack)).EndInit();
            this.grbBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.backPic.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grFront;
        private DevExpress.XtraEditors.PictureEdit frontPic;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colRFID;
        private DevExpress.XtraGrid.Views.Grid.GridView grvOut;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeIn;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit gteTimeIn;
        private DevExpress.XtraGrid.GridControl grcOut;
        private DevExpress.XtraEditors.GroupControl grbGrid;
        private DevExpress.XtraEditors.GroupControl grbInfo;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TextEdit txtRFID;
        private DevExpress.XtraEditors.TextEdit txtNumber;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblNumber;
        private DevExpress.XtraEditors.LabelControl lblTimeIn;
        private DevExpress.XtraEditors.LabelControl lblRFID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.GroupControl grbBack;
        private DevExpress.XtraEditors.PictureEdit backPic;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeOut;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit gteTimeOut;
        private DevExpress.XtraEditors.DateEdit fromDate;
        private DevExpress.XtraEditors.DateEdit toDate;
        private DevExpress.XtraEditors.TimeEdit fromTime;
        private DevExpress.XtraEditors.TimeEdit toTime;
        private DevExpress.XtraEditors.CheckEdit chkTime;
        private DevExpress.XtraEditors.CheckEdit chkNumber;
        private DevExpress.XtraEditors.CheckEdit chkRFID;
        private DevExpress.XtraEditors.RadioGroup rdbSearch;
        private DevExpress.XtraEditors.SimpleButton btnClear;
    }
}