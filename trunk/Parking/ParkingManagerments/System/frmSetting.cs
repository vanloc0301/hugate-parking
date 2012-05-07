using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using Hugate.DataHelper;
using System.Reflection;
using System.Collections;

namespace Hugate.Parking
{
    public partial class frmSetting : XtraForm
    {
        private int cameraId = 0;
        private bool isAddNew = false;

        public frmSetting()
        {
            InitializeComponent();
        }

        private bool Connect()
        {
            if (!clsDeclare.eventComPort1.IsOpen() || !clsDeclare.eventComPort2.IsOpen())
            {
                if (!clsDeclare.eventComPort1.IsOpen())
                {
                    if (clsDeclare.eventComPort1.Connect(cbbConnectIn.Text, 9600))
                    {
                        clsDeclare.isConnect = true;
                    }
                }
                if (!clsDeclare.eventComPort2.IsOpen())
                {
                    if (clsDeclare.eventComPort2.Connect(cbbConnectOut.Text, 9600))
                    {
                        clsDeclare.isConnect = true;
                    }
                }
                if (clsDeclare.isConnect)
                {
                    btnDisconnect.Enabled = true;
                    btnConnect.Enabled = false;
                    cbbConnectIn.Enabled = false;
                    cbbConnectOut.Enabled = false;
                    return clsDeclare.isConnect;
                }
            }
            return clsDeclare.isConnect;
        }

        private void LoadCombobox()
        {
            if (clsDeclare.isConnect)
            {
                cbbConnectIn.Enabled = false;
                cbbConnectOut.Enabled = false;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
            }
            else
            {
                string[] listComPorts = clsDeclare.eventComPort1.LoadDataAllComPorts();
                cbbConnectIn.Properties.Items.Clear();
                cbbConnectOut.Properties.Items.Clear();
                if (File.Exists(@"config_devices.txt"))
                {
                    string[] value = File.ReadAllLines(@"config_devices.txt");
                    if (listComPorts.Length > 0 && value.Length > 0)
                    {
                        foreach (string tmp in listComPorts)
                        {
                            cbbConnectIn.Properties.Items.Add(tmp);
                            cbbConnectOut.Properties.Items.Add(tmp);

                            foreach (string value_ in value)
                            {
                                if (value_ == tmp)
                                {
                                    cbbConnectIn.SelectedItem = tmp;
                                    cbbConnectOut.SelectedItem = tmp;
                                }
                            }
                        }
                        if (listComPorts.Length == 1)
                        {
                            cbbConnectIn.SelectedItem = listComPorts[0];
                            cbbConnectOut.SelectedItem = DBNull.Value;
                        }
                        if (listComPorts.Length > 1)
                        {
                            cbbConnectIn.SelectedItem = listComPorts[0];
                            cbbConnectOut.SelectedItem = listComPorts[1];
                        }
                    }
                }
                else
                {
                    cbbConnectIn.Properties.Items.AddRange(listComPorts);
                    cbbConnectOut.Properties.Items.AddRange(listComPorts);
                    if (listComPorts.Length > 1)
                    {
                        cbbConnectIn.SelectedItem = listComPorts[0];
                        cbbConnectOut.SelectedItem = listComPorts[1];
                    }
                }
            }
        }

        private void LoadDataToGrid()
        {
            PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
            IEnumerable<pk_Camera> cam_ = new Execute(pkdata).IECamera();
            DataTable dt = new DataTable();
            dt = clsDeclare.ObtainDataTableFromIEnumerable(cam_);
            if (dt.Rows.Count > 0)
            {
                DataView dv = new DataView(dt);
                if (dv != null)
                {
                    grcCameras.BeginUpdate();
                    grcCameras.DataSource = dv;
                    grcCameras.EndUpdate();
                }
                grvCameras.ExpandAllGroups();
            }
            else
            {
                grcCameras.BeginUpdate();
                grcCameras.DataSource = null;
                grcCameras.EndUpdate();

                cbbSize.SelectedIndex = 0;
                cbbArea.SelectedIndex = 0;
                cbbPosition.SelectedIndex = 0;
                cbbProvider.SelectedIndex = 0;
                cbbQuality.SelectedIndex = 0;
                cbbType.SelectedIndex = 0;
            }
        }

        private void Save()
        {
            PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
            if (isAddNew)
            {
                string source = String.Format("{0}:{1}", txtIP.Text, txtPort.Text);
                int type = Convert.ToInt32(cbbType.EditValue);
                new Execute(pkdata).SaveCamera(txtCameraName.Text, cbbProvider.EditValue.ToString(), txtDescription.Text, source, txtUser.Text, txtPassword.Text, cbbSize.EditValue.ToString(), type.ToString(), cbbQuality.EditValue.ToString(), txtInterval.Text, Convert.ToBoolean(cbbArea.EditValue), Convert.ToBoolean(cbbPosition.EditValue), Convert.ToInt32(cbbArea.EditValue.ToString()));
                LoadDataToGrid();
            }
            else
            {
                string source = String.Format("{0}:{1}", txtIP.Text, txtPort.Text);
                int type = Convert.ToInt32(cbbType.EditValue);
                new Execute(pkdata).EditCamera(cameraId, txtCameraName.Text, cbbProvider.EditValue.ToString(), txtDescription.Text, source, txtUser.Text, txtPassword.Text, cbbSize.EditValue.ToString(), type.ToString(), cbbQuality.EditValue.ToString(), txtInterval.Text, Convert.ToBoolean(cbbArea.EditValue), Convert.ToBoolean(cbbPosition.EditValue), Convert.ToInt32(cbbArea.EditValue));
                LoadDataToGrid();
            }
            XtraMessageBox.Show("Thành công", "Thông báo");
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
            btnClear.Enabled = true;
        }

        private void frmSetting_Activated(object sender, EventArgs e)
        {
            LoadCombobox();
            LoadDataToGrid();
            btnSave.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
            if (File.Exists(@"config_devices.txt"))
            {
                File.Delete(@"config_devices.txt");
            }
            File.Create(@"config_devices.txt").Close();
            string[] lines = { cbbConnectIn.Text, cbbConnectOut.Text };
            File.WriteAllLines(@"config_devices.txt", lines);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (clsDeclare.eventComPort1.IsOpen() || clsDeclare.eventComPort2.IsOpen())
            {
                if (clsDeclare.eventComPort2.IsOpen())
                {
                    if (clsDeclare.eventComPort2.Disconnect())
                    {
                        clsDeclare.isConnect = false;
                    }
                }

                if (clsDeclare.eventComPort1.Disconnect())
                {
                    clsDeclare.isConnect = false;
                }
                if (!clsDeclare.isConnect)
                {
                    btnDisconnect.Enabled = false;
                    btnConnect.Enabled = true;
                    cbbConnectIn.Enabled = true;
                    cbbConnectOut.Enabled = true;
                }
            }
        }

        private void cbbRefresh_Click(object sender, EventArgs e)
        {
            LoadCombobox();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            btnClear.Enabled = false;
            isAddNew = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                if (cameraId > 0)
                {
                    PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
                    new Execute(pkdata).DeleteCamera(cameraId);
                    LoadDataToGrid();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAddNew = true;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnClear.Enabled = false;
            btnAdd.Enabled = false;

            txtCameraName.Text = "";
            txtIP.Text = "";
            txtPort.Text = "";
            txtUser.Text = "";
            txtPassword.Text = "";
            txtDescription.Text = "";
            txtInterval.Text = "";

            cbbSize.SelectedIndex = 0;
            cbbArea.SelectedIndex = 0;
            cbbPosition.SelectedIndex = 0;
            cbbProvider.SelectedIndex = 0;
            cbbQuality.SelectedIndex = 0;
            cbbType.SelectedIndex = 0;
        }

        private void grvCameras_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow row = grvCameras.GetDataRow(grvCameras.FocusedRowHandle);
            if (row != null)
            {
                cameraId = Convert.ToInt32(row["cameraId"]);
                txtCameraName.EditValue = row["Name"].ToString();
                string[] port = row["source"].ToString().Split(':');
                txtIP.EditValue = port[0];
                txtPort.EditValue = port[1];
                txtUser.EditValue = row["login"].ToString();
                txtPassword.EditValue = row["password"].ToString();
                cbbSize.Text = row["size"].ToString();
                cbbArea.EditValue = Convert.ToBoolean(row["isIn"]);
                cbbPosition.EditValue = Convert.ToBoolean(row["position"]);
                cbbType.EditValue = Convert.ToBoolean(Convert.ToInt32(row["type"]));
                cbbQuality.EditValue = row["quality"].ToString();
                txtInterval.EditValue = row["interval"].ToString();
                cbbProvider.EditValue = row["provider"];
                txtDescription.Text = row["desc"].ToString();
                cbbArea.EditValue = Convert.ToInt32(row["areaId"]);
            }
        }

        private void cbbConnectIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbConnectIn.Text == cbbConnectOut.Text)
            {
                cbbConnectOut.SelectedItem = null;
            }
        }

        private void cbbConnectOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbConnectIn.Text == cbbConnectOut.Text)
            {
                cbbConnectIn.SelectedItem = null;
            }
        }
    }
}