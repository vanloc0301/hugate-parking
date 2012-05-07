namespace Hugate.Parking
{
    partial class frmSetting
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
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisconnect = new DevExpress.XtraEditors.SimpleButton();
            this.txtCameraName = new DevExpress.XtraEditors.TextEdit();
            this.lblUser = new DevExpress.XtraEditors.LabelControl();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.lblIP = new DevExpress.XtraEditors.LabelControl();
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.txtIP = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.lblPort = new DevExpress.XtraEditors.LabelControl();
            this.txtPort = new DevExpress.XtraEditors.TextEdit();
            this.lblConnectIn = new DevExpress.XtraEditors.LabelControl();
            this.lblConnectOut = new DevExpress.XtraEditors.LabelControl();
            this.grbDevice = new DevExpress.XtraEditors.GroupControl();
            this.cbbConnectOut = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbbConnectIn = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbbRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.lblCameraName = new DevExpress.XtraEditors.LabelControl();
            this.grbCamera = new DevExpress.XtraEditors.GroupControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.cbbSize = new DevExpress.XtraEditors.ComboBoxEdit();
            this.grcCameras = new DevExpress.XtraGrid.GridControl();
            this.grvCameras = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbbgArea = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbbgPosition = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colCameraName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIPAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPassword = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.lblCameraType = new DevExpress.XtraEditors.LabelControl();
            this.lblInterval = new DevExpress.XtraEditors.LabelControl();
            this.lblQuality = new DevExpress.XtraEditors.LabelControl();
            this.lblPosition = new DevExpress.XtraEditors.LabelControl();
            this.lblArea = new DevExpress.XtraEditors.LabelControl();
            this.txtInterval = new DevExpress.XtraEditors.TextEdit();
            this.lblType = new DevExpress.XtraEditors.LabelControl();
            this.lblSize = new DevExpress.XtraEditors.LabelControl();
            this.lblDescription = new DevExpress.XtraEditors.LabelControl();
            this.cbbProvider = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.cbbQuality = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.cbbType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.cbbPosition = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.cbbArea = new DevExpress.XtraEditors.ImageComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCameraName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbDevice)).BeginInit();
            this.grbDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbConnectOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbConnectIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbCamera)).BeginInit();
            this.grbCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcCameras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCameras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbgArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbProvider.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbQuality.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbArea.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(352, 62);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Kết nối";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(436, 62);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "Ngắt kết nối";
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // txtCameraName
            // 
            this.txtCameraName.Location = new System.Drawing.Point(83, 25);
            this.txtCameraName.Name = "txtCameraName";
            this.txtCameraName.Size = new System.Drawing.Size(139, 20);
            this.txtCameraName.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(19, 55);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(22, 13);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "User";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(83, 51);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(139, 20);
            this.txtUser.TabIndex = 4;
            // 
            // lblIP
            // 
            this.lblIP.Location = new System.Drawing.Point(443, 29);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(10, 13);
            this.lblIP.TabIndex = 1;
            this.lblIP.Text = "IP";
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(228, 55);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(46, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(502, 25);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(139, 20);
            this.txtIP.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(293, 51);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(139, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(647, 29);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(20, 13);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(688, 25);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(77, 20);
            this.txtPort.TabIndex = 3;
            // 
            // lblConnectIn
            // 
            this.lblConnectIn.Location = new System.Drawing.Point(19, 30);
            this.lblConnectIn.Name = "lblConnectIn";
            this.lblConnectIn.Size = new System.Drawing.Size(46, 13);
            this.lblConnectIn.TabIndex = 0;
            this.lblConnectIn.Text = "Cổng vào";
            // 
            // lblConnectOut
            // 
            this.lblConnectOut.Location = new System.Drawing.Point(260, 30);
            this.lblConnectOut.Name = "lblConnectOut";
            this.lblConnectOut.Size = new System.Drawing.Size(38, 13);
            this.lblConnectOut.TabIndex = 1;
            this.lblConnectOut.Text = "Cổng ra";
            // 
            // grbDevice
            // 
            this.grbDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDevice.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDevice.AppearanceCaption.Options.UseFont = true;
            this.grbDevice.AppearanceCaption.Options.UseTextOptions = true;
            this.grbDevice.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grbDevice.Controls.Add(this.cbbConnectOut);
            this.grbDevice.Controls.Add(this.cbbConnectIn);
            this.grbDevice.Controls.Add(this.btnDisconnect);
            this.grbDevice.Controls.Add(this.cbbRefresh);
            this.grbDevice.Controls.Add(this.btnConnect);
            this.grbDevice.Controls.Add(this.lblConnectIn);
            this.grbDevice.Controls.Add(this.lblConnectOut);
            this.grbDevice.Location = new System.Drawing.Point(0, 0);
            this.grbDevice.Name = "grbDevice";
            this.grbDevice.Size = new System.Drawing.Size(779, 92);
            this.grbDevice.TabIndex = 0;
            this.grbDevice.Text = "Thiết bị đọc thẻ";
            // 
            // cbbConnectOut
            // 
            this.cbbConnectOut.Location = new System.Drawing.Point(343, 26);
            this.cbbConnectOut.Name = "cbbConnectOut";
            this.cbbConnectOut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbConnectOut.Size = new System.Drawing.Size(139, 20);
            this.cbbConnectOut.TabIndex = 4;
            this.cbbConnectOut.SelectedIndexChanged += new System.EventHandler(this.cbbConnectOut_SelectedIndexChanged);
            // 
            // cbbConnectIn
            // 
            this.cbbConnectIn.Location = new System.Drawing.Point(103, 26);
            this.cbbConnectIn.Name = "cbbConnectIn";
            this.cbbConnectIn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbConnectIn.Size = new System.Drawing.Size(139, 20);
            this.cbbConnectIn.TabIndex = 4;
            this.cbbConnectIn.SelectedIndexChanged += new System.EventHandler(this.cbbConnectIn_SelectedIndexChanged);
            // 
            // cbbRefresh
            // 
            this.cbbRefresh.Location = new System.Drawing.Point(268, 62);
            this.cbbRefresh.Name = "cbbRefresh";
            this.cbbRefresh.Size = new System.Drawing.Size(75, 23);
            this.cbbRefresh.TabIndex = 2;
            this.cbbRefresh.Text = "Làm mới";
            this.cbbRefresh.Click += new System.EventHandler(this.cbbRefresh_Click);
            // 
            // lblCameraName
            // 
            this.lblCameraName.Location = new System.Drawing.Point(19, 29);
            this.lblCameraName.Name = "lblCameraName";
            this.lblCameraName.Size = new System.Drawing.Size(58, 13);
            this.lblCameraName.TabIndex = 1;
            this.lblCameraName.Text = "Tên Camera";
            // 
            // grbCamera
            // 
            this.grbCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbCamera.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbCamera.AppearanceCaption.Options.UseFont = true;
            this.grbCamera.AppearanceCaption.Options.UseTextOptions = true;
            this.grbCamera.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grbCamera.Controls.Add(this.btnClear);
            this.grbCamera.Controls.Add(this.btnAdd);
            this.grbCamera.Controls.Add(this.btnEdit);
            this.grbCamera.Controls.Add(this.btnSave);
            this.grbCamera.Controls.Add(this.cbbSize);
            this.grbCamera.Controls.Add(this.grcCameras);
            this.grbCamera.Controls.Add(this.txtUser);
            this.grbCamera.Controls.Add(this.txtDescription);
            this.grbCamera.Controls.Add(this.txtCameraName);
            this.grbCamera.Controls.Add(this.txtPassword);
            this.grbCamera.Controls.Add(this.txtPort);
            this.grbCamera.Controls.Add(this.lblCameraType);
            this.grbCamera.Controls.Add(this.lblInterval);
            this.grbCamera.Controls.Add(this.lblQuality);
            this.grbCamera.Controls.Add(this.lblPosition);
            this.grbCamera.Controls.Add(this.lblArea);
            this.grbCamera.Controls.Add(this.txtInterval);
            this.grbCamera.Controls.Add(this.lblType);
            this.grbCamera.Controls.Add(this.txtIP);
            this.grbCamera.Controls.Add(this.lblSize);
            this.grbCamera.Controls.Add(this.lblUser);
            this.grbCamera.Controls.Add(this.lblIP);
            this.grbCamera.Controls.Add(this.lblPassword);
            this.grbCamera.Controls.Add(this.lblDescription);
            this.grbCamera.Controls.Add(this.lblPort);
            this.grbCamera.Controls.Add(this.lblCameraName);
            this.grbCamera.Controls.Add(this.cbbProvider);
            this.grbCamera.Controls.Add(this.cbbQuality);
            this.grbCamera.Controls.Add(this.cbbType);
            this.grbCamera.Controls.Add(this.cbbPosition);
            this.grbCamera.Controls.Add(this.cbbArea);
            this.grbCamera.Location = new System.Drawing.Point(0, 98);
            this.grbCamera.Name = "grbCamera";
            this.grbCamera.Size = new System.Drawing.Size(779, 452);
            this.grbCamera.TabIndex = 1;
            this.grbCamera.Text = "Camera";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(480, 129);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Xoá";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(222, 129);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(308, 129);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(394, 129);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbbSize
            // 
            this.cbbSize.Location = new System.Drawing.Point(688, 51);
            this.cbbSize.Name = "cbbSize";
            this.cbbSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbSize.Properties.Items.AddRange(new object[] {
            "192x144",
            "320x240",
            "640x480"});
            this.cbbSize.Size = new System.Drawing.Size(77, 20);
            this.cbbSize.TabIndex = 7;
            // 
            // grcCameras
            // 
            this.grcCameras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grcCameras.Location = new System.Drawing.Point(2, 158);
            this.grcCameras.MainView = this.grvCameras;
            this.grcCameras.Name = "grcCameras";
            this.grcCameras.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbbgPosition,
            this.cbbgArea});
            this.grcCameras.Size = new System.Drawing.Size(775, 292);
            this.grcCameras.TabIndex = 16;
            this.grcCameras.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCameras});
            // 
            // grvCameras
            // 
            this.grvCameras.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvCameras.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCameras.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvCameras.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCameras.Appearance.Row.Options.UseTextOptions = true;
            this.grvCameras.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCameras.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colArea,
            this.colPosition,
            this.colCameraName,
            this.colIPAddress,
            this.colUser,
            this.colPassword,
            this.colSize});
            this.grvCameras.GridControl = this.grcCameras;
            this.grvCameras.GroupCount = 1;
            this.grvCameras.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.grvCameras.Name = "grvCameras";
            this.grvCameras.OptionsBehavior.Editable = false;
            this.grvCameras.OptionsView.ColumnAutoWidth = false;
            this.grvCameras.OptionsView.ShowGroupPanel = false;
            this.grvCameras.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colArea, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvCameras.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvCameras_FocusedRowChanged);
            // 
            // colArea
            // 
            this.colArea.Caption = "Khu vực  ";
            this.colArea.ColumnEdit = this.cbbgArea;
            this.colArea.FieldName = "areaId";
            this.colArea.Name = "colArea";
            // 
            // cbbgArea
            // 
            this.cbbgArea.AutoHeight = false;
            this.cbbgArea.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbgArea.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cổng vào ô tô", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cổng ra ô tô", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cổng vào ra xe máy", 3, -1)});
            this.cbbgArea.Name = "cbbgArea";
            // 
            // colPosition
            // 
            this.colPosition.Caption = "Vị trí";
            this.colPosition.ColumnEdit = this.cbbgPosition;
            this.colPosition.FieldName = "position";
            this.colPosition.Name = "colPosition";
            this.colPosition.Visible = true;
            this.colPosition.VisibleIndex = 1;
            this.colPosition.Width = 100;
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
            // colCameraName
            // 
            this.colCameraName.Caption = "Camera";
            this.colCameraName.FieldName = "Name";
            this.colCameraName.Name = "colCameraName";
            this.colCameraName.OptionsColumn.AllowEdit = false;
            this.colCameraName.Visible = true;
            this.colCameraName.VisibleIndex = 0;
            this.colCameraName.Width = 200;
            // 
            // colIPAddress
            // 
            this.colIPAddress.Caption = "Địa chỉ IP";
            this.colIPAddress.FieldName = "source";
            this.colIPAddress.Name = "colIPAddress";
            this.colIPAddress.Visible = true;
            this.colIPAddress.VisibleIndex = 2;
            this.colIPAddress.Width = 200;
            // 
            // colUser
            // 
            this.colUser.Caption = "User";
            this.colUser.FieldName = "login";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 3;
            this.colUser.Width = 100;
            // 
            // colPassword
            // 
            this.colPassword.Caption = "Password";
            this.colPassword.FieldName = "password";
            this.colPassword.Name = "colPassword";
            this.colPassword.Visible = true;
            this.colPassword.VisibleIndex = 4;
            this.colPassword.Width = 100;
            // 
            // colSize
            // 
            this.colSize.Caption = "Size";
            this.colSize.FieldName = "size";
            this.colSize.Name = "colSize";
            this.colSize.Visible = true;
            this.colSize.VisibleIndex = 5;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(83, 103);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(684, 20);
            this.txtDescription.TabIndex = 12;
            // 
            // lblCameraType
            // 
            this.lblCameraType.Location = new System.Drawing.Point(228, 29);
            this.lblCameraType.Name = "lblCameraType";
            this.lblCameraType.Size = new System.Drawing.Size(59, 13);
            this.lblCameraType.TabIndex = 1;
            this.lblCameraType.Text = "Loại Camera";
            // 
            // lblInterval
            // 
            this.lblInterval.Location = new System.Drawing.Point(443, 55);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(39, 13);
            this.lblInterval.TabIndex = 1;
            this.lblInterval.Text = "Frame/s";
            // 
            // lblQuality
            // 
            this.lblQuality.Location = new System.Drawing.Point(443, 81);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(53, 13);
            this.lblQuality.TabIndex = 1;
            this.lblQuality.Text = "Chất lượng";
            // 
            // lblPosition
            // 
            this.lblPosition.Location = new System.Drawing.Point(228, 81);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(21, 13);
            this.lblPosition.TabIndex = 1;
            this.lblPosition.Text = "Vị trí";
            // 
            // lblArea
            // 
            this.lblArea.Location = new System.Drawing.Point(19, 81);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(39, 13);
            this.lblArea.TabIndex = 1;
            this.lblArea.Text = "Khu vực";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(502, 51);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(139, 20);
            this.txtInterval.TabIndex = 6;
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(647, 81);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(24, 13);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Type";
            // 
            // lblSize
            // 
            this.lblSize.Location = new System.Drawing.Point(647, 55);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(19, 13);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "Size";
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(19, 107);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(27, 13);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Mô tả";
            // 
            // cbbProvider
            // 
            this.cbbProvider.Location = new System.Drawing.Point(293, 25);
            this.cbbProvider.Name = "cbbProvider";
            this.cbbProvider.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbProvider.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Vivotek", "Hugate.Camera.VivotekCameraDescription", -1)});
            this.cbbProvider.Properties.NullText = "[EditValue is null]";
            this.cbbProvider.Size = new System.Drawing.Size(139, 20);
            this.cbbProvider.TabIndex = 1;
            // 
            // cbbQuality
            // 
            this.cbbQuality.Location = new System.Drawing.Point(502, 77);
            this.cbbQuality.Name = "cbbQuality";
            this.cbbQuality.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbQuality.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Standard", "Standard", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Well", "Well", -1)});
            this.cbbQuality.Properties.NullText = "[EditValue is null]";
            this.cbbQuality.Size = new System.Drawing.Size(139, 20);
            this.cbbQuality.TabIndex = 10;
            // 
            // cbbType
            // 
            this.cbbType.Location = new System.Drawing.Point(688, 77);
            this.cbbType.Name = "cbbType";
            this.cbbType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("MPEG-4", true, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("MJPEG", false, -1)});
            this.cbbType.Properties.NullText = "[EditValue is null]";
            this.cbbType.Size = new System.Drawing.Size(77, 20);
            this.cbbType.TabIndex = 11;
            // 
            // cbbPosition
            // 
            this.cbbPosition.Location = new System.Drawing.Point(293, 77);
            this.cbbPosition.Name = "cbbPosition";
            this.cbbPosition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbPosition.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Phía trước", true, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Phía sau", false, -1)});
            this.cbbPosition.Properties.NullText = "[EditValue is null]";
            this.cbbPosition.Size = new System.Drawing.Size(139, 20);
            this.cbbPosition.TabIndex = 9;
            // 
            // cbbArea
            // 
            this.cbbArea.Location = new System.Drawing.Point(83, 77);
            this.cbbArea.Name = "cbbArea";
            this.cbbArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbArea.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cổng vào ô tô", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cổng ra ô tô", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cổng vào ra xe máy", 3, -1)});
            this.cbbArea.Properties.NullText = "[EditValue is null]";
            this.cbbArea.Size = new System.Drawing.Size(139, 20);
            this.cbbArea.TabIndex = 8;
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 562);
            this.Controls.Add(this.grbCamera);
            this.Controls.Add(this.grbDevice);
            this.Name = "frmSetting";
            this.Text = "Hệ thống";
            this.Activated += new System.EventHandler(this.frmSetting_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.txtCameraName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbDevice)).EndInit();
            this.grbDevice.ResumeLayout(false);
            this.grbDevice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbConnectOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbConnectIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbCamera)).EndInit();
            this.grbCamera.ResumeLayout(false);
            this.grbCamera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcCameras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCameras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbgArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbProvider.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbQuality.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbArea.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private DevExpress.XtraEditors.SimpleButton btnDisconnect;
        private DevExpress.XtraEditors.TextEdit txtCameraName;
        private DevExpress.XtraEditors.LabelControl lblUser;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.LabelControl lblIP;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.TextEdit txtIP;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl lblPort;
        private DevExpress.XtraEditors.TextEdit txtPort;
        private DevExpress.XtraEditors.LabelControl lblConnectIn;
        private DevExpress.XtraEditors.LabelControl lblConnectOut;
        private DevExpress.XtraEditors.GroupControl grbDevice;
        private DevExpress.XtraEditors.LabelControl lblCameraName;
        private DevExpress.XtraEditors.GroupControl grbCamera;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl lblSize;
        private DevExpress.XtraEditors.ComboBoxEdit cbbSize;
        private DevExpress.XtraGrid.GridControl grcCameras;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCameras;
        private DevExpress.XtraGrid.Columns.GridColumn colCameraName;
        private DevExpress.XtraGrid.Columns.GridColumn colIPAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colPassword;
        private DevExpress.XtraGrid.Columns.GridColumn colSize;
        private DevExpress.XtraEditors.LabelControl lblArea;
        private DevExpress.XtraGrid.Columns.GridColumn colArea;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbbArea;
        private DevExpress.XtraEditors.LabelControl lblPosition;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbbPosition;
        private DevExpress.XtraGrid.Columns.GridColumn colPosition;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cbbgPosition;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cbbgArea;
        private DevExpress.XtraEditors.LabelControl lblCameraType;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbbProvider;
        private DevExpress.XtraEditors.LabelControl lblQuality;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbbQuality;
        private DevExpress.XtraEditors.LabelControl lblInterval;
        private DevExpress.XtraEditors.TextEdit txtInterval;
        private DevExpress.XtraEditors.LabelControl lblType;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.LabelControl lblDescription;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbbType;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton cbbRefresh;
        private DevExpress.XtraEditors.ComboBoxEdit cbbConnectOut;
        private DevExpress.XtraEditors.ComboBoxEdit cbbConnectIn;
    }
}