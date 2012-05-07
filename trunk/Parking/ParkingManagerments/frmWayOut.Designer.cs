namespace Hugate.Parking
{
    partial class frmWayOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWayOut));
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.grFront = new DevExpress.XtraEditors.GroupControl();
            this.axVitaminCtrl1 = new AxVITAMINDECODERLib.AxVitaminCtrl();
            this.frontPic = new DevExpress.XtraEditors.PictureEdit();
            this.txtRFID = new DevExpress.XtraEditors.TextEdit();
            this.txtNumber = new DevExpress.XtraEditors.TextEdit();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grbBack = new DevExpress.XtraEditors.GroupControl();
            this.axVitaminCtrl2 = new AxVITAMINDECODERLib.AxVitaminCtrl();
            this.backPic = new DevExpress.XtraEditors.PictureEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gteTimeIn = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.grcOut = new DevExpress.XtraGrid.GridControl();
            this.grvOut = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRFID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblNumber = new DevExpress.XtraEditors.LabelControl();
            this.grbGrid = new DevExpress.XtraEditors.GroupControl();
            this.lblPrice = new DevExpress.XtraEditors.LabelControl();
            this.lblRFID = new DevExpress.XtraEditors.LabelControl();
            this.grbInfo = new DevExpress.XtraEditors.GroupControl();
            this.teTimeOut = new DevExpress.XtraEditors.TimeEdit();
            this.teTimeIn = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblTimeIn = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grFront)).BeginInit();
            this.grFront.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axVitaminCtrl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontPic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbBack)).BeginInit();
            this.grbBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axVitaminCtrl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backPic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gteTimeIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbGrid)).BeginInit();
            this.grbGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbInfo)).BeginInit();
            this.grbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teTimeOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTimeIn.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(93, 51);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(221, 20);
            this.txtPrice.TabIndex = 1;
            // 
            // grFront
            // 
            this.grFront.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grFront.AppearanceCaption.Options.UseFont = true;
            this.grFront.AppearanceCaption.Options.UseTextOptions = true;
            this.grFront.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grFront.Controls.Add(this.axVitaminCtrl1);
            this.grFront.Controls.Add(this.frontPic);
            this.grFront.Location = new System.Drawing.Point(0, 1);
            this.grFront.MaximumSize = new System.Drawing.Size(660, 270);
            this.grFront.MinimumSize = new System.Drawing.Size(660, 270);
            this.grFront.Name = "grFront";
            this.grFront.Size = new System.Drawing.Size(660, 270);
            this.grFront.TabIndex = 5;
            this.grFront.Text = "Hình ảnh phía trước";
            // 
            // axVitaminCtrl1
            // 
            this.axVitaminCtrl1.Enabled = true;
            this.axVitaminCtrl1.Location = new System.Drawing.Point(331, 25);
            this.axVitaminCtrl1.Name = "axVitaminCtrl1";
            this.axVitaminCtrl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVitaminCtrl1.OcxState")));
            this.axVitaminCtrl1.Size = new System.Drawing.Size(320, 240);
            this.axVitaminCtrl1.TabIndex = 2;
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
            // txtRFID
            // 
            this.txtRFID.Enabled = false;
            this.txtRFID.Location = new System.Drawing.Point(93, 25);
            this.txtRFID.Name = "txtRFID";
            this.txtRFID.Size = new System.Drawing.Size(221, 20);
            this.txtRFID.TabIndex = 0;
            // 
            // txtNumber
            // 
            this.txtNumber.Enabled = false;
            this.txtNumber.Location = new System.Drawing.Point(93, 77);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(221, 20);
            this.txtNumber.TabIndex = 2;
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
            this.grbBack.Name = "grbBack";
            this.grbBack.Size = new System.Drawing.Size(660, 270);
            this.grbBack.TabIndex = 4;
            this.grbBack.Text = "Hình ảnh phía sau";
            // 
            // axVitaminCtrl2
            // 
            this.axVitaminCtrl2.Enabled = true;
            this.axVitaminCtrl2.Location = new System.Drawing.Point(331, 25);
            this.axVitaminCtrl2.Name = "axVitaminCtrl2";
            this.axVitaminCtrl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVitaminCtrl2.OcxState")));
            this.axVitaminCtrl2.Size = new System.Drawing.Size(320, 240);
            this.axVitaminCtrl2.TabIndex = 2;
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
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(142, 170);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Đồng ý thoát";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // colTime
            // 
            this.colTime.Caption = "Thời gian";
            this.colTime.ColumnEdit = this.gteTimeIn;
            this.colTime.FieldName = "TimeOut";
            this.colTime.Name = "colTime";
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 2;
            this.colTime.Width = 160;
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
            // grcOut
            // 
            this.grcOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcOut.Location = new System.Drawing.Point(2, 22);
            this.grcOut.MainView = this.grvOut;
            this.grcOut.Name = "grcOut";
            this.grcOut.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gteTimeIn});
            this.grcOut.Size = new System.Drawing.Size(336, 246);
            this.grcOut.TabIndex = 1;
            this.grcOut.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvOut});
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
            this.colTime});
            this.grvOut.GridControl = this.grcOut;
            this.grvOut.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.grvOut.Name = "grvOut";
            this.grvOut.OptionsBehavior.Editable = false;
            this.grvOut.OptionsView.ShowGroupPanel = false;
            // 
            // colRFID
            // 
            this.colRFID.Caption = "Số thẻ";
            this.colRFID.FieldName = "RFID";
            this.colRFID.Name = "colRFID";
            this.colRFID.OptionsColumn.AllowEdit = false;
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
            // lblNumber
            // 
            this.lblNumber.Location = new System.Drawing.Point(23, 81);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(56, 13);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "Biển số xe :";
            // 
            // grbGrid
            // 
            this.grbGrid.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbGrid.AppearanceCaption.Options.UseFont = true;
            this.grbGrid.AppearanceCaption.Options.UseTextOptions = true;
            this.grbGrid.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grbGrid.Controls.Add(this.grcOut);
            this.grbGrid.Location = new System.Drawing.Point(668, 1);
            this.grbGrid.Name = "grbGrid";
            this.grbGrid.Size = new System.Drawing.Size(340, 270);
            this.grbGrid.TabIndex = 6;
            this.grbGrid.Text = "Danh sách xe vừa ra";
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(23, 55);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(37, 13);
            this.lblPrice.TabIndex = 1;
            this.lblPrice.Text = "Giá xe :";
            // 
            // lblRFID
            // 
            this.lblRFID.Location = new System.Drawing.Point(23, 29);
            this.lblRFID.Name = "lblRFID";
            this.lblRFID.Size = new System.Drawing.Size(38, 13);
            this.lblRFID.TabIndex = 2;
            this.lblRFID.Text = "Số thẻ :";
            // 
            // grbInfo
            // 
            this.grbInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbInfo.AppearanceCaption.Options.UseFont = true;
            this.grbInfo.AppearanceCaption.Options.UseTextOptions = true;
            this.grbInfo.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grbInfo.Controls.Add(this.teTimeOut);
            this.grbInfo.Controls.Add(this.teTimeIn);
            this.grbInfo.Controls.Add(this.btnOK);
            this.grbInfo.Controls.Add(this.txtRFID);
            this.grbInfo.Controls.Add(this.txtPrice);
            this.grbInfo.Controls.Add(this.txtNumber);
            this.grbInfo.Controls.Add(this.lblPrice);
            this.grbInfo.Controls.Add(this.labelControl1);
            this.grbInfo.Controls.Add(this.lblNumber);
            this.grbInfo.Controls.Add(this.lblTimeIn);
            this.grbInfo.Controls.Add(this.lblRFID);
            this.grbInfo.Location = new System.Drawing.Point(668, 277);
            this.grbInfo.Name = "grbInfo";
            this.grbInfo.Size = new System.Drawing.Size(340, 270);
            this.grbInfo.TabIndex = 7;
            this.grbInfo.Text = "Thông tin";
            // 
            // teTimeOut
            // 
            this.teTimeOut.EditValue = new System.DateTime(2011, 10, 20, 0, 0, 0, 0);
            this.teTimeOut.Enabled = false;
            this.teTimeOut.Location = new System.Drawing.Point(94, 129);
            this.teTimeOut.Name = "teTimeOut";
            this.teTimeOut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teTimeOut.Properties.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.teTimeOut.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teTimeOut.Properties.EditFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.teTimeOut.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teTimeOut.Properties.Mask.EditMask = "dd-MM-yyyy HH:mm";
            this.teTimeOut.Size = new System.Drawing.Size(220, 20);
            this.teTimeOut.TabIndex = 4;
            // 
            // teTimeIn
            // 
            this.teTimeIn.EditValue = new System.DateTime(2011, 10, 20, 0, 0, 0, 0);
            this.teTimeIn.Enabled = false;
            this.teTimeIn.Location = new System.Drawing.Point(94, 103);
            this.teTimeIn.Name = "teTimeIn";
            this.teTimeIn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teTimeIn.Properties.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.teTimeIn.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teTimeIn.Properties.EditFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.teTimeIn.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teTimeIn.Properties.Mask.EditMask = "dd-MM-yyyy HH:mm";
            this.teTimeIn.Size = new System.Drawing.Size(220, 20);
            this.teTimeIn.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 132);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Thời gian ra";
            // 
            // lblTimeIn
            // 
            this.lblTimeIn.Location = new System.Drawing.Point(23, 106);
            this.lblTimeIn.Name = "lblTimeIn";
            this.lblTimeIn.Size = new System.Drawing.Size(64, 13);
            this.lblTimeIn.TabIndex = 2;
            this.lblTimeIn.Text = "Thời gian vào";
            // 
            // frmWayOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.grFront);
            this.Controls.Add(this.grbBack);
            this.Controls.Add(this.grbGrid);
            this.Controls.Add(this.grbInfo);
            this.Name = "frmWayOut";
            this.Text = "Lối ra";
            this.Activated += new System.EventHandler(this.frmLineOut_Activated);
            this.Deactivate += new System.EventHandler(this.frmLineOut_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grFront)).EndInit();
            this.grFront.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axVitaminCtrl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontPic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbBack)).EndInit();
            this.grbBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axVitaminCtrl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backPic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gteTimeIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbGrid)).EndInit();
            this.grbGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grbInfo)).EndInit();
            this.grbInfo.ResumeLayout(false);
            this.grbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teTimeOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTimeIn.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraEditors.GroupControl grFront;
        private DevExpress.XtraEditors.PictureEdit frontPic;
        private DevExpress.XtraEditors.TextEdit txtRFID;
        private DevExpress.XtraEditors.TextEdit txtNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.GroupControl grbBack;
        private DevExpress.XtraEditors.PictureEdit backPic;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.GridControl grcOut;
        private DevExpress.XtraGrid.Views.Grid.GridView grvOut;
        private DevExpress.XtraGrid.Columns.GridColumn colRFID;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraEditors.LabelControl lblNumber;
        private DevExpress.XtraEditors.GroupControl grbGrid;
        private DevExpress.XtraEditors.LabelControl lblPrice;
        private DevExpress.XtraEditors.LabelControl lblRFID;
        private DevExpress.XtraEditors.GroupControl grbInfo;
        private DevExpress.XtraEditors.LabelControl lblTimeIn;
        private DevExpress.XtraEditors.TimeEdit teTimeIn;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit gteTimeIn;
        private DevExpress.XtraEditors.TimeEdit teTimeOut;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private AxVITAMINDECODERLib.AxVitaminCtrl axVitaminCtrl1;
        private AxVITAMINDECODERLib.AxVitaminCtrl axVitaminCtrl2;
    }
}