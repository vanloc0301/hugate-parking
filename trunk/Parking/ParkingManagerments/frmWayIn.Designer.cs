namespace Hugate.Parking
{
    partial class frmWayIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWayIn));
            this.grFront = new DevExpress.XtraEditors.GroupControl();
            this.axVitaminCtrl1 = new AxVITAMINDECODERLib.AxVitaminCtrl();
            this.frontPic = new DevExpress.XtraEditors.PictureEdit();
            this.grbGrid = new DevExpress.XtraEditors.GroupControl();
            this.grcIn = new DevExpress.XtraGrid.GridControl();
            this.grvIn = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRFID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timeEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btnCapture = new DevExpress.XtraEditors.SimpleButton();
            this.txtNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtRFID = new DevExpress.XtraEditors.TextEdit();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grbBack = new DevExpress.XtraEditors.GroupControl();
            this.axVitaminCtrl2 = new AxVITAMINDECODERLib.AxVitaminCtrl();
            this.backPic = new DevExpress.XtraEditors.PictureEdit();
            this.grbInfo = new DevExpress.XtraEditors.GroupControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cbbVehicleType = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grFront)).BeginInit();
            this.grFront.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axVitaminCtrl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontPic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbGrid)).BeginInit();
            this.grbGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbBack)).BeginInit();
            this.grbBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axVitaminCtrl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backPic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbInfo)).BeginInit();
            this.grbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbVehicleType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grFront
            // 
            this.grFront.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grFront.AppearanceCaption.Options.UseFont = true;
            this.grFront.AppearanceCaption.Options.UseTextOptions = true;
            this.grFront.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grFront.Controls.Add(this.axVitaminCtrl1);
            this.grFront.Controls.Add(this.frontPic);
            this.grFront.Location = new System.Drawing.Point(0, 0);
            this.grFront.MaximumSize = new System.Drawing.Size(660, 270);
            this.grFront.MinimumSize = new System.Drawing.Size(660, 270);
            this.grFront.Name = "grFront";
            this.grFront.Size = new System.Drawing.Size(660, 270);
            this.grFront.TabIndex = 0;
            this.grFront.Text = "Hình ảnh phía trước";
            // 
            // axVitaminCtrl1
            // 
            this.axVitaminCtrl1.Enabled = true;
            this.axVitaminCtrl1.Location = new System.Drawing.Point(5, 22);
            this.axVitaminCtrl1.Name = "axVitaminCtrl1";
            this.axVitaminCtrl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVitaminCtrl1.OcxState")));
            this.axVitaminCtrl1.Size = new System.Drawing.Size(320, 240);
            this.axVitaminCtrl1.TabIndex = 1;
            // 
            // frontPic
            // 
            this.frontPic.Location = new System.Drawing.Point(331, 25);
            this.frontPic.MaximumSize = new System.Drawing.Size(320, 240);
            this.frontPic.MinimumSize = new System.Drawing.Size(320, 240);
            this.frontPic.Name = "frontPic";
            this.frontPic.Size = new System.Drawing.Size(320, 240);
            this.frontPic.TabIndex = 0;
            // 
            // grbGrid
            // 
            this.grbGrid.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbGrid.AppearanceCaption.Options.UseFont = true;
            this.grbGrid.AppearanceCaption.Options.UseTextOptions = true;
            this.grbGrid.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grbGrid.Controls.Add(this.grcIn);
            this.grbGrid.Location = new System.Drawing.Point(668, 0);
            this.grbGrid.Name = "grbGrid";
            this.grbGrid.Size = new System.Drawing.Size(340, 270);
            this.grbGrid.TabIndex = 2;
            this.grbGrid.Text = "Danh sách xe vừa vào";
            // 
            // grcIn
            // 
            this.grcIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcIn.Location = new System.Drawing.Point(2, 22);
            this.grcIn.MainView = this.grvIn;
            this.grcIn.Name = "grcIn";
            this.grcIn.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.timeEdit});
            this.grcIn.Size = new System.Drawing.Size(336, 246);
            this.grcIn.TabIndex = 1;
            this.grcIn.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvIn});
            // 
            // grvIn
            // 
            this.grvIn.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvIn.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvIn.Appearance.Row.Options.UseTextOptions = true;
            this.grvIn.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvIn.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRFID,
            this.colNumber,
            this.colTime});
            this.grvIn.GridControl = this.grcIn;
            this.grvIn.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.grvIn.Name = "grvIn";
            this.grvIn.OptionsBehavior.Editable = false;
            this.grvIn.OptionsView.ShowGroupPanel = false;
            // 
            // colRFID
            // 
            this.colRFID.Caption = "Số thẻ";
            this.colRFID.FieldName = "RFID";
            this.colRFID.Name = "colRFID";
            this.colRFID.Visible = true;
            this.colRFID.VisibleIndex = 0;
            this.colRFID.Width = 80;
            // 
            // colNumber
            // 
            this.colNumber.Caption = "Biển số xe";
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.OptionsColumn.AllowEdit = false;
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 1;
            this.colNumber.Width = 80;
            // 
            // colTime
            // 
            this.colTime.Caption = "Thời gian";
            this.colTime.ColumnEdit = this.timeEdit;
            this.colTime.FieldName = "TimeIn";
            this.colTime.Name = "colTime";
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 2;
            this.colTime.Width = 158;
            // 
            // timeEdit
            // 
            this.timeEdit.AutoHeight = false;
            this.timeEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEdit.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.timeEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEdit.EditFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.timeEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEdit.Mask.EditMask = "dd-MM-yyyy HH:mm";
            this.timeEdit.Name = "timeEdit";
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(133, 144);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(100, 23);
            this.btnCapture.TabIndex = 3;
            this.btnCapture.Text = "Chụp hình và Lưu";
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(84, 104);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(229, 20);
            this.txtNumber.TabIndex = 2;
            // 
            // txtRFID
            // 
            this.txtRFID.Location = new System.Drawing.Point(84, 52);
            this.txtRFID.Name = "txtRFID";
            this.txtRFID.Size = new System.Drawing.Size(229, 20);
            this.txtRFID.TabIndex = 0;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(84, 78);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(229, 20);
            this.txtPrice.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(22, 108);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(56, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Biển số xe :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 56);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Số thẻ :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 82);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Giá xe :";
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
            this.grbBack.Controls.Add(this.axVitaminCtrl2);
            this.grbBack.Controls.Add(this.backPic);
            this.grbBack.Location = new System.Drawing.Point(0, 277);
            this.grbBack.MaximumSize = new System.Drawing.Size(660, 270);
            this.grbBack.MinimumSize = new System.Drawing.Size(660, 270);
            this.grbBack.Name = "grbBack";
            this.grbBack.Size = new System.Drawing.Size(660, 270);
            this.grbBack.TabIndex = 0;
            this.grbBack.Text = "Hình ảnh phía sau";
            // 
            // axVitaminCtrl2
            // 
            this.axVitaminCtrl2.Enabled = true;
            this.axVitaminCtrl2.Location = new System.Drawing.Point(5, 25);
            this.axVitaminCtrl2.Name = "axVitaminCtrl2";
            this.axVitaminCtrl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVitaminCtrl2.OcxState")));
            this.axVitaminCtrl2.Size = new System.Drawing.Size(320, 240);
            this.axVitaminCtrl2.TabIndex = 1;
            // 
            // backPic
            // 
            this.backPic.Location = new System.Drawing.Point(331, 25);
            this.backPic.MaximumSize = new System.Drawing.Size(320, 240);
            this.backPic.MinimumSize = new System.Drawing.Size(320, 240);
            this.backPic.Name = "backPic";
            this.backPic.Size = new System.Drawing.Size(320, 240);
            this.backPic.TabIndex = 0;
            // 
            // grbInfo
            // 
            this.grbInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbInfo.AppearanceCaption.Options.UseFont = true;
            this.grbInfo.AppearanceCaption.Options.UseTextOptions = true;
            this.grbInfo.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grbInfo.Controls.Add(this.btnSearch);
            this.grbInfo.Controls.Add(this.btnCapture);
            this.grbInfo.Controls.Add(this.txtRFID);
            this.grbInfo.Controls.Add(this.txtPrice);
            this.grbInfo.Controls.Add(this.txtNumber);
            this.grbInfo.Controls.Add(this.labelControl1);
            this.grbInfo.Controls.Add(this.labelControl3);
            this.grbInfo.Controls.Add(this.labelControl4);
            this.grbInfo.Controls.Add(this.labelControl2);
            this.grbInfo.Controls.Add(this.cbbVehicleType);
            this.grbInfo.Location = new System.Drawing.Point(668, 277);
            this.grbInfo.Name = "grbInfo";
            this.grbInfo.Size = new System.Drawing.Size(340, 270);
            this.grbInfo.TabIndex = 3;
            this.grbInfo.Text = "Thông tin";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(52, 144);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(22, 30);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Loại xe";
            // 
            // cbbVehicleType
            // 
            this.cbbVehicleType.Location = new System.Drawing.Point(84, 26);
            this.cbbVehicleType.Name = "cbbVehicleType";
            this.cbbVehicleType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbVehicleType.Properties.NullText = "";
            this.cbbVehicleType.Properties.PopupSizeable = false;
            this.cbbVehicleType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbbVehicleType.Size = new System.Drawing.Size(229, 20);
            this.cbbVehicleType.TabIndex = 4;
            this.cbbVehicleType.EditValueChanged += new System.EventHandler(this.cbbVehicleType_EditValueChanged);
            // 
            // frmWayIn
            // 
            this.AcceptButton = this.btnCapture;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.grbInfo);
            this.Controls.Add(this.grbGrid);
            this.Controls.Add(this.grbBack);
            this.Controls.Add(this.grFront);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "frmWayIn";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lối vào";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmLineIn_Activated);
            this.Deactivate += new System.EventHandler(this.frmLineIn_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.grFront)).EndInit();
            this.grFront.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axVitaminCtrl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontPic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbGrid)).EndInit();
            this.grbGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbBack)).EndInit();
            this.grbBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axVitaminCtrl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backPic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbInfo)).EndInit();
            this.grbInfo.ResumeLayout(false);
            this.grbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbVehicleType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grFront;
        private DevExpress.XtraGrid.GridControl grcIn;
        private DevExpress.XtraGrid.Views.Grid.GridView grvIn;
        private DevExpress.XtraEditors.GroupControl grbGrid;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraEditors.TextEdit txtNumber;
        private DevExpress.XtraEditors.TextEdit txtRFID;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraEditors.SimpleButton btnCapture;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraEditors.GroupControl grbBack;
        private DevExpress.XtraEditors.PictureEdit backPic;
        private DevExpress.XtraEditors.PictureEdit frontPic;
        private DevExpress.XtraEditors.GroupControl grbInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colRFID;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit timeEdit;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit cbbVehicleType;
        private AxVITAMINDECODERLib.AxVitaminCtrl axVitaminCtrl1;
        private AxVITAMINDECODERLib.AxVitaminCtrl axVitaminCtrl2;
    }
}