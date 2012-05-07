namespace Hugate.Parking
{
    partial class frmVehiclesPrice
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
            this.grcVehicles = new DevExpress.XtraGrid.GridControl();
            this.grvVehicles = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVehiclesType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbbgPosition = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.cbbgArea = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.grbDevice = new DevExpress.XtraEditors.GroupControl();
            this.txtNote = new DevExpress.XtraEditors.TextEdit();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.txtTypeVehicles = new DevExpress.XtraEditors.TextEdit();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblConnectIn = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblConnectOut = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grcVehicles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVehicles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbgArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbDevice)).BeginInit();
            this.grbDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypeVehicles.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grcVehicles
            // 
            this.grcVehicles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grcVehicles.Location = new System.Drawing.Point(0, 121);
            this.grcVehicles.MainView = this.grvVehicles;
            this.grcVehicles.Name = "grcVehicles";
            this.grcVehicles.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbbgPosition,
            this.cbbgArea});
            this.grcVehicles.Size = new System.Drawing.Size(747, 292);
            this.grcVehicles.TabIndex = 1;
            this.grcVehicles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVehicles});
            // 
            // grvVehicles
            // 
            this.grvVehicles.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvVehicles.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVehicles.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvVehicles.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvVehicles.Appearance.Row.Options.UseTextOptions = true;
            this.grvVehicles.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvVehicles.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVehiclesType,
            this.colPrice,
            this.colNote});
            this.grvVehicles.GridControl = this.grcVehicles;
            this.grvVehicles.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.grvVehicles.Name = "grvVehicles";
            this.grvVehicles.OptionsBehavior.Editable = false;
            this.grvVehicles.OptionsView.ColumnAutoWidth = false;
            this.grvVehicles.OptionsView.ShowGroupPanel = false;
            this.grvVehicles.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvVehicles_FocusedRowChanged);
            // 
            // colVehiclesType
            // 
            this.colVehiclesType.Caption = "Loại xe";
            this.colVehiclesType.FieldName = "VehicleType";
            this.colVehiclesType.Name = "colVehiclesType";
            this.colVehiclesType.Visible = true;
            this.colVehiclesType.VisibleIndex = 0;
            this.colVehiclesType.Width = 236;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "Giá";
            this.colPrice.DisplayFormat.FormatString = "##,##";
            this.colPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 1;
            this.colPrice.Width = 93;
            // 
            // colNote
            // 
            this.colNote.Caption = "Ghi chú";
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 2;
            this.colNote.Width = 370;
            // 
            // cbbgPosition
            // 
            this.cbbgPosition.AutoHeight = false;
            this.cbbgPosition.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbgPosition.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Phía trước", true, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Phía sau", false, -1)});
            this.cbbgPosition.Name = "cbbgPosition";
            // 
            // cbbgArea
            // 
            this.cbbgArea.AutoHeight = false;
            this.cbbgArea.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbgArea.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cổng vào ô tô", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cổng ra ô tô", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cổng vào xe máy", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cổng ra xe máy", 4, -1)});
            this.cbbgArea.Name = "cbbgArea";
            // 
            // grbDevice
            // 
            this.grbDevice.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDevice.AppearanceCaption.Options.UseFont = true;
            this.grbDevice.AppearanceCaption.Options.UseTextOptions = true;
            this.grbDevice.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grbDevice.Controls.Add(this.txtNote);
            this.grbDevice.Controls.Add(this.txtPrice);
            this.grbDevice.Controls.Add(this.txtTypeVehicles);
            this.grbDevice.Controls.Add(this.btnClear);
            this.grbDevice.Controls.Add(this.btnAdd);
            this.grbDevice.Controls.Add(this.btnEdit);
            this.grbDevice.Controls.Add(this.btnSave);
            this.grbDevice.Controls.Add(this.lblConnectIn);
            this.grbDevice.Controls.Add(this.labelControl1);
            this.grbDevice.Controls.Add(this.lblConnectOut);
            this.grbDevice.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbDevice.Location = new System.Drawing.Point(0, 0);
            this.grbDevice.Name = "grbDevice";
            this.grbDevice.Size = new System.Drawing.Size(747, 115);
            this.grbDevice.TabIndex = 0;
            this.grbDevice.Text = "Thiết bị đọc thẻ";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(460, 29);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(270, 20);
            this.txtNote.TabIndex = 2;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(291, 29);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.Mask.EditMask = "##,##00";
            this.txtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrice.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 1;
            // 
            // txtTypeVehicles
            // 
            this.txtTypeVehicles.Location = new System.Drawing.Point(63, 29);
            this.txtTypeVehicles.Name = "txtTypeVehicles";
            this.txtTypeVehicles.Size = new System.Drawing.Size(179, 20);
            this.txtTypeVehicles.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(459, 78);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Xoá";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(201, 78);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(287, 78);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(373, 78);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblConnectIn
            // 
            this.lblConnectIn.Location = new System.Drawing.Point(12, 33);
            this.lblConnectIn.Name = "lblConnectIn";
            this.lblConnectIn.Size = new System.Drawing.Size(34, 13);
            this.lblConnectIn.TabIndex = 0;
            this.lblConnectIn.Text = "Loại xe";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(397, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Ghi chú";
            // 
            // lblConnectOut
            // 
            this.lblConnectOut.Location = new System.Drawing.Point(248, 33);
            this.lblConnectOut.Name = "lblConnectOut";
            this.lblConnectOut.Size = new System.Drawing.Size(15, 13);
            this.lblConnectOut.TabIndex = 1;
            this.lblConnectOut.Text = "Giá";
            // 
            // frmVehiclesPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 413);
            this.Controls.Add(this.grbDevice);
            this.Controls.Add(this.grcVehicles);
            this.Name = "frmVehiclesPrice";
            this.Text = "Loại xe và giá";
            this.Activated += new System.EventHandler(this.frmVehiclesPrice_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVehiclesPrice_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grcVehicles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVehicles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbgArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbDevice)).EndInit();
            this.grbDevice.ResumeLayout(false);
            this.grbDevice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypeVehicles.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcVehicles;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVehicles;
        private DevExpress.XtraGrid.Columns.GridColumn colVehiclesType;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cbbgPosition;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cbbgArea;
        private DevExpress.XtraEditors.GroupControl grbDevice;
        private DevExpress.XtraEditors.LabelControl lblConnectIn;
        private DevExpress.XtraEditors.LabelControl lblConnectOut;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtNote;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraEditors.TextEdit txtTypeVehicles;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}