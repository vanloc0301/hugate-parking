using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Xml;
using System.Threading;
using Hugate.ComportConnections;
using Hugate.DataHelper;
using System.Linq;

namespace Hugate.Parking
{
    public partial class frmWayIn : XtraForm
    {
        private string value;
        pk_Price[] price;
        object imgIn, imgOut;

        public frmWayIn()
        {
            InitializeComponent();
        }

        public void LoadDataToCombo()
        {
            try
            {
                PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
                price = new Execute(pkdata).GetAllPrice();
                if (price.Length > 0)
                {
                    cbbVehicleType.Properties.DataSource = price;
                    cbbVehicleType.Properties.ValueMember = "ID";
                    cbbVehicleType.Properties.DisplayMember = "VehicleType";
                }
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void OpenCamera(bool position, string username, string password, string ipAddress, string port)
        {
            try
            {
                if (position)
                {
                    axVitaminCtrl1.UserName = username;
                    axVitaminCtrl1.Password = password;
                    axVitaminCtrl1.RemoteIPAddr = ipAddress;
                    long lPort = System.Convert.ToInt32(port);
                    if (lPort <= 0 || lPort > 65535)
                        lPort = 80;
                    axVitaminCtrl1.HttpPort = (int)lPort;
                    axVitaminCtrl1.IgnoreBorder = true;
                    axVitaminCtrl1.IgnoreCaption = true;
                    axVitaminCtrl1.IgnoreSSLCertificate = true;
                    axVitaminCtrl1.ViewStream = VITAMINDECODERLib.EDualStreamOption.eStream1;
                    if (axVitaminCtrl1.ControlStatus == VITAMINDECODERLib.EControlStatus.ctrlConnecting ||
                    axVitaminCtrl1.ControlStatus == VITAMINDECODERLib.EControlStatus.ctrlRunning)
                    {
                        return;
                    }
                    else
                        axVitaminCtrl1.Connect();
                }
                else
                {
                    axVitaminCtrl2.UserName = username;
                    axVitaminCtrl2.Password = password;
                    axVitaminCtrl2.RemoteIPAddr = ipAddress;
                    long lPort = System.Convert.ToInt32(port);
                    if (lPort <= 0 || lPort > 65535)
                        lPort = 80;
                    axVitaminCtrl2.HttpPort = (int)lPort;
                    axVitaminCtrl2.IgnoreBorder = true;
                    axVitaminCtrl2.IgnoreCaption = true;
                    axVitaminCtrl2.IgnoreSSLCertificate = true;
                    axVitaminCtrl2.ViewStream = VITAMINDECODERLib.EDualStreamOption.eStream1;
                    if (axVitaminCtrl2.ControlStatus == VITAMINDECODERLib.EControlStatus.ctrlConnecting ||
                    axVitaminCtrl2.ControlStatus == VITAMINDECODERLib.EControlStatus.ctrlRunning)
                    {
                        return;
                    }
                    else
                        axVitaminCtrl2.Connect();
                }
            }
            catch
            {
                throw new Exception("Không thể kết nối camera vui lòng kiểm tra thiết bị");
            }

        }

        private void LoadDataToGrid()
        {
            try
            {
                PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
                pk_In_Out[] PakingIn = new Execute(pkdata).GetAllPKIn(0, 20);
                grcIn.BeginUpdate();
                grcIn.DataSource = PakingIn;
                grcIn.EndUpdate();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void CaptureImage()
        {
            object info1, info2;
            axVitaminCtrl1.GetSnapshot(VITAMINDECODERLib.EPictureFormat.ePicFmtJpeg, out imgIn, out info1);
            axVitaminCtrl2.GetSnapshot(VITAMINDECODERLib.EPictureFormat.ePicFmtJpeg, out imgOut, out info2);
        }

        private Bitmap ConvertToBitmap(byte[] byteArray)
        {
            Bitmap bitmapOut = null;
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
            return bitmapOut = (Bitmap)tc.ConvertFrom(byteArray);
        }

        private void Save()
        {
            try
            {
                if (txtRFID.EditValue != null && cbbVehicleType.EditValue != null)
                {
                    PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
                    if (new Execute(pkdata).HasObject(txtRFID.Text))
                    {
                        MessageBox.Show("Thẻ này chưa ra ngoài", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Guid ID = new Execute(pkdata).SavePKIn(txtRFID.Text, txtNumber.Text, DateTime.Now, Convert.ToInt32(cbbVehicleType.EditValue));

                    if (imgIn != null)
                    {
                        new Execute(pkdata).setImage(ID, (byte[])imgIn, true);
                        frontPic.EditValue = ConvertToBitmap((byte[])imgIn);
                        imgIn = null;
                    }
                    if (imgOut != null)
                    {
                        new Execute(pkdata).setImage(ID, (byte[])imgOut, false);
                        backPic.EditValue = ConvertToBitmap((byte[])imgOut);
                        imgOut = null;
                    }
                    LoadDataToGrid();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        #region Events Method
        private void eventComPort1_LfDataReceived(object sender, LfEventArgs e)
        {
            value = e.value.ToString();
            this.Invoke(new EventHandler(UpdateData));
        }

        private void UpdateData(object sender, EventArgs e)
        {
            txtRFID.Text = value;
            txtNumber.EditValue = "";
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (txtRFID.EditValue != null)
            {
                CaptureImage();
                Save();
            }
        }

        private void frmLineIn_Activated(object sender, EventArgs e)
        {
            try
            {
                PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
                clsDeclare.eventComPort1.LfDataReceived += new LfDataReceivedEventHandler(eventComPort1_LfDataReceived);
                LoadDataToGrid();
                LoadDataToCombo();
                pk_Camera[] cams = new Execute(pkdata).GetAllCameras();
                foreach (pk_Camera cam in cams)
                {
                    if (cam.areaId == 1)
                    {
                        string[] sourceIP = cam.source.Split(':');
                        OpenCamera(cam.position, cam.login, cam.password, sourceIP[0], sourceIP[1]);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLineIn_Deactivate(object sender, EventArgs e)
        {
            clsDeclare.eventComPort1.LfDataReceived -= eventComPort1_LfDataReceived;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch();
            search.ShowDialog();
        }

        private void cbbVehicleType_EditValueChanged(object sender, EventArgs e)
        {
            if (cbbVehicleType.EditValue != null)
            {
                foreach (pk_Price item in price)
                {
                    if (item.ID == Convert.ToInt32(cbbVehicleType.EditValue))
                    {
                        txtPrice.EditValue = String.Format("{0:##,##00}", item.Price);
                    }
                }
            }
        }
        #endregion
    }
}