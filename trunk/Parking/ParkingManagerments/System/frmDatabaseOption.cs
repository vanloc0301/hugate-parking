using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SZLibrary;

namespace Hugate.Parking
{
    public partial class frmDatabaseOption : frmBaseAdd
    {
        string strConnectionString;
        string sDatabase = "";
        OleDbConnection myConn;

        public frmDatabaseOption()
        {
            InitializeComponent();
        }

        #region Private Method

        private Boolean OpenConnect()
        {
            if (cbbSQLServerName.Text == "")
            {
                return false;
            }
            sDatabase = cbbDatabaseServer.Text;
            if (sDatabase == "")
            {
                return false;
            }
            if (radWindow.Checked)
            {
                strConnectionString = "Provider=SQLOLEDB.1;Persist Security Info=False;Data Source=" + cbbSQLServerName.EditValue.ToString() + ";Initial Catalog=" + cbbDatabaseServer.Text + ";Integrated Security=SSPI";
            }
            else
            {
                if (!CheckNullControl(txtSQLUsername, lblUserSQL.Text))
                {
                    return false;
                }
                if (!CheckNullControl(txtSQLPassword, lblPassSQL.Text))
                {
                    return false;
                }
                strConnectionString = "Provider=SQLOLEDB.1;Password=" + txtSQLPassword.EditValue.ToString() + ";Persist Security Info=True;Data Source=" + cbbSQLServerName.EditValue.ToString() + ";Initial Catalog=" + sDatabase + ";User ID=" + txtSQLUsername.EditValue.ToString() + "";
            }
            myConn = new OleDbConnection(strConnectionString);
            try
            {
                myConn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private Boolean CloseConnect()
        {
            try
            {
                myConn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Event method

        private void frmDatabaseOption_Load(object sender, EventArgs e)
        {
            clsDeclare.glbMessage = new SZLibrary.Message(this);
            System.Data.Sql.SqlDataSourceEnumerator Instance = System.Data.Sql.SqlDataSourceEnumerator.Instance;
            DataTable dt = Instance.GetDataSources();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DevExpress.XtraEditors.Controls.ComboBoxItem item = new DevExpress.XtraEditors.Controls.ComboBoxItem(row["ServerName"].ToString() + @"\" + row["InstanceName"].ToString());
                    cbbSQLServerName.Properties.Items.Add(item);
                }
            }
            ///---------------------------------------------
            if (clsDeclare.glbConnection.ConnectionString != "")
            {
                txtSQLUsername.Enabled = false;
                txtSQLPassword.Enabled = false;

                chkSQLBlankPassword.Enabled = false;
                chkSQLAlowSavingPassword.Enabled = false;

                cbbSQLServerName.Text = clsDeclare.glbConnection.DataSource;
                radSpecific.Checked = true;
                txtSQLUsername.Text = clsDeclare.glbUserNameData;
                txtSQLPassword.Text = clsDeclare.glbPasswordData;
                cbbDatabaseServer.Text = clsDeclare.glbConnection.Database;
            }
        }

        private void frmDatabaseOption_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (OpenConnect())
                {
                    //DataTable dt = new DataTable();
                    //clsDeclare.clsDatabase.LoadDataTable("Select top 1 * from SYS_Form", ref dt, myConn);
                    //if (dt == null)
                    // {
                    //clsDeclare.glbMessage.MSInform("Not correct database AttPro. Please select database again.");
                    //    e.Cancel = true;
                    //    return;
                    //}
                    //if (dt.Columns.Count == 0)
                    //{
                    //    //clsDeclare.glbMessage.MSInform("This database not correct. Please select another database.");
                    //    e.Cancel = true;
                    //    return;
                    //}

                    Ini.WriteValue(clsDeclare.PathServerFile, "D", "D2", "1");
                    Ini.WriteValue(clsDeclare.PathServerFile, "A", "A1", EncDec.Encrypt(cbbSQLServerName.Text, clsDeclare.PassKeys));
                    Ini.WriteValue(clsDeclare.PathServerFile, "A", "A2", EncDec.Encrypt(cbbDatabaseServer.Text, clsDeclare.PassKeys));
                    Ini.WriteValue(clsDeclare.PathServerFile, "B", "B1", EncDec.Encrypt(txtSQLUsername.Text, clsDeclare.PassKeys));
                    Ini.WriteValue(clsDeclare.PathServerFile, "B", "B2", EncDec.Encrypt(txtSQLPassword.Text, clsDeclare.PassKeys));
                    //delete file
                    if (System.IO.File.Exists(Application.StartupPath + @"\In.ini"))
                    {
                        System.IO.File.Delete(Application.StartupPath + @"\In.ini");
                        EncDec.Encrypt(Application.StartupPath + @"\Out.ini", Application.StartupPath + @"\In.ini", clsDeclare.PassKeys);
                    }
                    CloseConnect();

                    clsDeclare.glbUserNameData = txtSQLUsername.Text;
                    clsDeclare.glbPasswordData = txtSQLPassword.Text;
                    clsDeclare.glbDatabase = cbbDatabaseServer.Text;
                    clsDeclare.glbHost = cbbSQLServerName.Text;

                    clsDeclare.gblConnectString = clsDeclare.clsDatabase.CreateConnectString(clsDeclare.glbUserNameData, clsDeclare.glbPasswordData, clsDeclare.glbDatabase, clsDeclare.glbHost);
                    clsDeclare.gblConnectStringLinQ = clsDeclare.clsDatabase.CreateConnectStringLinQ(clsDeclare.glbUserNameData, clsDeclare.glbPasswordData, clsDeclare.glbDatabase, clsDeclare.glbHost);
                    //clsDeclare.glbConnection = clsDeclare.clsDatabase.CreateConnect(clsDeclare.gblConnectString);
                    //clsDeclare.clsDatabase = new SZLibrary.Database(clsDeclare.glbConnection);

                    if (clsDeclare.objFormMain != null)
                    {
                        //clsDeclare.objFormMain.barStaticUser.Caption = "User: " + clsDeclare.glbUserName + " | Server: " + clsDeclare.glbHost + " | Database: " + clsDeclare.glbDatabase;
                    }
                    goto ABC;
                }
                else
                {
                    e.Cancel = true;
                    return;
                }

            ABC:
                {
                    //clsProgram.LoadData();
                    //clsDeclare.objFormMain.lbtnLanguage.EditValue = clsDeclare.glbCurrentLanguage;
                    //clsDeclare.clsCaption.SetCaption(clsDeclare.objFormMain, clsDeclare.glbCurrentLanguage);
                    //Security.SetMenuPermission(clsDeclare.objFormMain, clsDeclare.glbUserName);
                }
            }
        }

        private void cbbDatabaseServer_DropDown(object sender, EventArgs e)
        {
            if (cbbDatabaseServer.Text == null)
            {
                sDatabase = "Master";
            }
            if (cbbDatabaseServer.Text == "")
            {
                sDatabase = "Master";
            }
            else
            {
                sDatabase = cbbDatabaseServer.Text;
            }
            if (OpenConnect())
            {
                OleDbDataAdapter ad = new OleDbDataAdapter("sp_databases", myConn);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                cbbDatabaseServer.DataSource = dt;
                cbbDatabaseServer.DisplayMember = "DATABASE_NAME";
                cbbDatabaseServer.ValueMember = "DATABASE_NAME";
                CloseConnect();
                sDatabase = cbbDatabaseServer.Text;
            }
        }

        private void cbbDatabaseServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            sDatabase = cbbDatabaseServer.Text;
        }

        private void radWindow_CheckedChanged(object sender, EventArgs e)
        {
            if (radWindow.Checked)
            {
                txtSQLUsername.Enabled = false;
                txtSQLPassword.Enabled = false;
                chkSQLBlankPassword.Enabled = false;
                chkSQLAlowSavingPassword.Enabled = false;
                txtSQLUsername.EditValue = "";
                txtSQLPassword.EditValue = "";
            }
        }

        private void radSpecific_CheckedChanged(object sender, EventArgs e)
        {
            if (radSpecific.Checked)
            {
                txtSQLUsername.Enabled = true;
                txtSQLPassword.Enabled = true;
                chkSQLBlankPassword.Enabled = true;
                chkSQLAlowSavingPassword.Enabled = true;
            }
            if (chkSQLBlankPassword.Checked)
            {
                txtSQLPassword.Enabled = false;
            }
            else
            {
                txtSQLPassword.Enabled = true;
            }
        }

        private void btnSQLTestConnection_Click(object sender, EventArgs e)
        {
            if (OpenConnect())
            {
                clsDeclare.glbMessage.MSInform("Connect sucessfull.");
            }
            else
            {
                clsDeclare.glbMessage.MSInform("Connect fail.");
            }
        }

        #endregion
    }
}

