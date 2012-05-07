namespace Hugate.Parking
{
    partial class frmDatabaseOption : frmBaseAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatabaseOption));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbDatabaseServer = new System.Windows.Forms.ComboBox();
            this.chkSQLAlowSavingPassword = new DevExpress.XtraEditors.CheckEdit();
            this.btnSQLTestConnection = new DevExpress.XtraEditors.SimpleButton();
            this.chkSQLBlankPassword = new DevExpress.XtraEditors.CheckEdit();
            this.txtSQLPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtSQLUsername = new DevExpress.XtraEditors.TextEdit();
            this.lblPassSQL = new DevExpress.XtraEditors.LabelControl();
            this.lblUserSQL = new DevExpress.XtraEditors.LabelControl();
            this.radSpecific = new System.Windows.Forms.RadioButton();
            this.radWindow = new System.Windows.Forms.RadioButton();
            this.cbbSQLServerName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblSerSQL = new DevExpress.XtraEditors.LabelControl();
            this.lblDatabaseSQL = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSQLAlowSavingPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSQLBlankPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQLPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQLUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSQLServerName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbDatabaseServer);
            this.groupBox1.Controls.Add(this.chkSQLAlowSavingPassword);
            this.groupBox1.Controls.Add(this.btnSQLTestConnection);
            this.groupBox1.Controls.Add(this.chkSQLBlankPassword);
            this.groupBox1.Controls.Add(this.txtSQLPassword);
            this.groupBox1.Controls.Add(this.txtSQLUsername);
            this.groupBox1.Controls.Add(this.lblPassSQL);
            this.groupBox1.Controls.Add(this.lblUserSQL);
            this.groupBox1.Controls.Add(this.radSpecific);
            this.groupBox1.Controls.Add(this.radWindow);
            this.groupBox1.Controls.Add(this.cbbSQLServerName);
            this.groupBox1.Controls.Add(this.lblSerSQL);
            this.groupBox1.Controls.Add(this.lblDatabaseSQL);
            this.groupBox1.Controls.Add(this.labelControl6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 307);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cbbDatabaseServer
            // 
            this.cbbDatabaseServer.FormattingEnabled = true;
            this.cbbDatabaseServer.Location = new System.Drawing.Point(36, 241);
            this.cbbDatabaseServer.Name = "cbbDatabaseServer";
            this.cbbDatabaseServer.Size = new System.Drawing.Size(337, 21);
            this.cbbDatabaseServer.TabIndex = 7;
            this.cbbDatabaseServer.DropDown += new System.EventHandler(this.cbbDatabaseServer_DropDown);
            this.cbbDatabaseServer.SelectedIndexChanged += new System.EventHandler(this.cbbDatabaseServer_SelectedIndexChanged);
            // 
            // chkSQLAlowSavingPassword
            // 
            this.chkSQLAlowSavingPassword.Location = new System.Drawing.Point(242, 188);
            this.chkSQLAlowSavingPassword.Name = "chkSQLAlowSavingPassword";
            this.chkSQLAlowSavingPassword.Properties.Caption = "Alow saving password";
            this.chkSQLAlowSavingPassword.Size = new System.Drawing.Size(142, 19);
            this.chkSQLAlowSavingPassword.TabIndex = 6;
            // 
            // btnSQLTestConnection
            // 
            this.btnSQLTestConnection.Location = new System.Drawing.Point(269, 269);
            this.btnSQLTestConnection.Name = "btnSQLTestConnection";
            this.btnSQLTestConnection.Size = new System.Drawing.Size(104, 23);
            this.btnSQLTestConnection.TabIndex = 8;
            this.btnSQLTestConnection.Text = "Test Connection";
            this.btnSQLTestConnection.Click += new System.EventHandler(this.btnSQLTestConnection_Click);
            // 
            // chkSQLBlankPassword
            // 
            this.chkSQLBlankPassword.Location = new System.Drawing.Point(108, 188);
            this.chkSQLBlankPassword.Name = "chkSQLBlankPassword";
            this.chkSQLBlankPassword.Properties.Caption = "Blank password";
            this.chkSQLBlankPassword.Size = new System.Drawing.Size(132, 19);
            this.chkSQLBlankPassword.TabIndex = 5;
            // 
            // txtSQLPassword
            // 
            this.txtSQLPassword.Location = new System.Drawing.Point(108, 164);
            this.txtSQLPassword.Name = "txtSQLPassword";
            this.txtSQLPassword.Properties.PasswordChar = '*';
            this.txtSQLPassword.Size = new System.Drawing.Size(265, 20);
            this.txtSQLPassword.TabIndex = 4;
            // 
            // txtSQLUsername
            // 
            this.txtSQLUsername.Location = new System.Drawing.Point(108, 134);
            this.txtSQLUsername.Name = "txtSQLUsername";
            this.txtSQLUsername.Size = new System.Drawing.Size(265, 20);
            this.txtSQLUsername.TabIndex = 3;
            // 
            // lblPassSQL
            // 
            this.lblPassSQL.Location = new System.Drawing.Point(36, 168);
            this.lblPassSQL.Name = "lblPassSQL";
            this.lblPassSQL.Size = new System.Drawing.Size(46, 13);
            this.lblPassSQL.TabIndex = 17;
            this.lblPassSQL.Text = "Password";
            // 
            // lblUserSQL
            // 
            this.lblUserSQL.Location = new System.Drawing.Point(36, 138);
            this.lblUserSQL.Name = "lblUserSQL";
            this.lblUserSQL.Size = new System.Drawing.Size(51, 13);
            this.lblUserSQL.TabIndex = 19;
            this.lblUserSQL.Text = "User name";
            // 
            // radSpecific
            // 
            this.radSpecific.AutoSize = true;
            this.radSpecific.Location = new System.Drawing.Point(36, 111);
            this.radSpecific.Name = "radSpecific";
            this.radSpecific.Size = new System.Drawing.Size(213, 17);
            this.radSpecific.TabIndex = 2;
            this.radSpecific.Text = "Use a specific user name and password";
            this.radSpecific.UseVisualStyleBackColor = true;
            this.radSpecific.CheckedChanged += new System.EventHandler(this.radSpecific_CheckedChanged);
            // 
            // radWindow
            // 
            this.radWindow.AutoSize = true;
            this.radWindow.Checked = true;
            this.radWindow.Location = new System.Drawing.Point(36, 88);
            this.radWindow.Name = "radWindow";
            this.radWindow.Size = new System.Drawing.Size(199, 17);
            this.radWindow.TabIndex = 1;
            this.radWindow.TabStop = true;
            this.radWindow.Text = "Use Windows NT Integrated security";
            this.radWindow.UseVisualStyleBackColor = true;
            this.radWindow.CheckedChanged += new System.EventHandler(this.radWindow_CheckedChanged);
            // 
            // cbbSQLServerName
            // 
            this.cbbSQLServerName.Location = new System.Drawing.Point(36, 43);
            this.cbbSQLServerName.Name = "cbbSQLServerName";
            this.cbbSQLServerName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbSQLServerName.Size = new System.Drawing.Size(337, 20);
            this.cbbSQLServerName.TabIndex = 0;
            // 
            // lblSerSQL
            // 
            this.lblSerSQL.Location = new System.Drawing.Point(15, 24);
            this.lblSerSQL.Name = "lblSerSQL";
            this.lblSerSQL.Size = new System.Drawing.Size(156, 13);
            this.lblSerSQL.TabIndex = 9;
            this.lblSerSQL.Text = "1. Select or enter a server name";
            // 
            // lblDatabaseSQL
            // 
            this.lblDatabaseSQL.Location = new System.Drawing.Point(15, 222);
            this.lblDatabaseSQL.Name = "lblDatabaseSQL";
            this.lblDatabaseSQL.Size = new System.Drawing.Size(177, 13);
            this.lblDatabaseSQL.TabIndex = 11;
            this.lblDatabaseSQL.Text = "3. Select the database on the server";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(15, 69);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(207, 13);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "2. Enter information to log on to the server";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(202, 313);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(98, 313);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            // 
            // frmDatabaseOption
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(399, 348);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDatabaseOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Option";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDatabaseOption_FormClosing);
            this.Load += new System.EventHandler(this.frmDatabaseOption_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSQLAlowSavingPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSQLBlankPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQLPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQLUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSQLServerName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.ComboBox cbbDatabaseServer;
        private DevExpress.XtraEditors.CheckEdit chkSQLAlowSavingPassword;
        private DevExpress.XtraEditors.SimpleButton btnSQLTestConnection;
        private DevExpress.XtraEditors.CheckEdit chkSQLBlankPassword;
        private DevExpress.XtraEditors.TextEdit txtSQLPassword;
        private DevExpress.XtraEditors.TextEdit txtSQLUsername;
        private DevExpress.XtraEditors.LabelControl lblPassSQL;
        private DevExpress.XtraEditors.LabelControl lblUserSQL;
        private System.Windows.Forms.RadioButton radSpecific;
        private System.Windows.Forms.RadioButton radWindow;
        private DevExpress.XtraEditors.ComboBoxEdit cbbSQLServerName;
        private DevExpress.XtraEditors.LabelControl lblSerSQL;
        private DevExpress.XtraEditors.LabelControl lblDatabaseSQL;
        private DevExpress.XtraEditors.LabelControl labelControl6;

    }
}
