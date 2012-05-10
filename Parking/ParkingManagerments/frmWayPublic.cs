using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Hugate.DataHelper;
using Hugate.ComportConnections;
using System.IO;

namespace Hugate.Parking
{
    public partial class frmWayPublic : XtraForm
    {
        string value1, value2;
        pk_Price[] price;
        object imgIn, imgOut;

        public frmWayPublic()
        {
            InitializeComponent();
            SetFormatString(txtPriceOut, DevExpress.Utils.FormatType.Numeric, true);
            SetFormatString(txtPriceIn, DevExpress.Utils.FormatType.Numeric, true);
        }

        private void OpenCamera(bool position, string username, string password, string ipAddress, string port)
        {
            try
            {
                if (!position)
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

        public void LoadDataToCombo()
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

        private void LoadDataToGrid()
        {
            PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
            pk_In_Out[] ParkingIn = new Execute(pkdata).GetAllPKIn(0, 20);
            grcIn.BeginUpdate();
            grcIn.DataSource = ParkingIn;
            grcIn.EndUpdate();

            pk_In_Out[] ParkingOut = new Execute(pkdata).GetAllPKOut(0, 20);
            grcOut.BeginUpdate();
            grcOut.DataSource = ParkingOut;
            grcOut.EndUpdate();
        }

        private void CaptureImage()
        {
            object info1, info2;
            axVitaminCtrl2.GetSnapshot(VITAMINDECODERLib.EPictureFormat.ePicFmtJpeg, out imgIn, out info1);
            //axVitaminCtrl1.GetSnapshot(VITAMINDECODERLib.EPictureFormat.ePicFmtJpeg, out imgOut, out info2);
        }

        private void Save()
        {
            PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
            if (txtRFIDIn.EditValue != null && cbbVehicleType.EditValue != null)
            {

                if (new Execute(pkdata).HasObject(txtRFIDIn.Text))
                {
                    MessageBox.Show("Thẻ này chưa ra ngoài", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Guid ID = new Execute(pkdata).SavePKIn(txtRFIDIn.Text, txtNumberIn.Text, DateTime.Now, Convert.ToInt32(cbbVehicleType.EditValue));
                if (imgIn != null)
                {
                    new Execute(pkdata).setImage(ID, (byte[])imgIn, false);

                    MemoryStream ms = new MemoryStream((byte[])imgIn);
                    Image returnImage = Image.FromStream(ms);
                    picIn.Image = returnImage;
                }
                LoadDataToGrid();
            }
        }

        private void Check()
        {
            PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
            byte[] arrImgFront = null;
            picOut.EditValue = null;
            ImageConverter con = new ImageConverter();
            var pk = new Execute(pkdata).GetSinglePKIn(txtRFIDOut.Text);
            if (pk != null)
            {
                new Execute(pkdata).getImage(pk.ID, ref arrImgFront, false);
                if (arrImgFront != null)
                {
                    Image tmp = (Image)con.ConvertFrom(arrImgFront);
                    picOut.Image = tmp;
                    arrImgFront = null;
                }
                txtNumberOut.Text = pk.Number.ToString();
                txtPriceOut.Text = String.Format("{0:##,##00}", pk.Price);
                teTimeIn.EditValue = pk.TimeIn;
                teTimeOut.EditValue = DateTime.Now;
            }
        }

        private byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            if (imageIn == null)
            {
                return new byte[0];
            }
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private string ConvertImage(Bitmap sBit)
        {
            MemoryStream imageStream = new MemoryStream();
            sBit.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);

            return Convert.ToBase64String(imageStream.ToArray());
        }

        private void UpdateData1(object sender, EventArgs e)
        {
            txtRFIDIn.EditValue = value1;
            txtNumberIn.EditValue = "";
            btnCapture.Focus();
        }

        private void UpdateData2(object sender, EventArgs e)
        {
            txtRFIDOut.EditValue = value2;
            if (txtRFIDOut.EditValue != null)
            {
                Check();
                btnOkOut.Focus();
            }
        }

        #region Events Method
        private void eventComPort1_LfDataReceived(object sender, LfEventArgs e)
        {
            value1 = e.value.ToString();
            this.Invoke(new EventHandler(UpdateData1));
        }

        private void eventComPort2_LfDataReceived(object sender, LfEventArgs e)
        {
            value2 = e.value.ToString();
            this.Invoke(new EventHandler(UpdateData2));
        }

        private void frmLinePublic_Activated(object sender, EventArgs e)
        {
            clsDeclare.eventComPort1.LfDataReceived += new LfDataReceivedEventHandler(eventComPort1_LfDataReceived);
            clsDeclare.eventComPort2.LfDataReceived += new LfDataReceivedEventHandler(eventComPort2_LfDataReceived);
            LoadDataToGrid();
            LoadDataToCombo();
            PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
            pk_Camera[] cams = new Execute(pkdata).GetAllCameras();
            foreach (pk_Camera cam in cams)
            {
                if (cam.areaId == 3)
                {
                    string[] sourceIP = cam.source.Split(':');
                    OpenCamera(cam.position, cam.login, cam.password, sourceIP[0], sourceIP[1]);
                }
                if (cam.areaId == 4)
                {
                    string[] sourceIP = cam.source.Split(':');
                    OpenCamera(cam.position, cam.login, cam.password, sourceIP[0], sourceIP[1]);
                }
            }
        }

        private void frmLinePublic_Deactivate(object sender, EventArgs e)
        {
            clsDeclare.eventComPort1.LfDataReceived -= eventComPort1_LfDataReceived;
            clsDeclare.eventComPort2.LfDataReceived -= eventComPort2_LfDataReceived;
        }

        private void btnCaptureIn_Click(object sender, EventArgs e)
        {
            if (txtRFIDIn.EditValue != null)
            {
                CaptureImage();
                Save();
            }
        }

        private void cbbVehicleType_EditValueChanged(object sender, EventArgs e)
        {
            if (cbbVehicleType.EditValue != null)
            {
                foreach (pk_Price item in price)
                {
                    if (item.ID == Convert.ToInt32(cbbVehicleType.EditValue))
                    {
                        txtPriceIn.EditValue = String.Format("{0:##,##00}", item.Price);
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch();
            search.ShowDialog();
        }

        private void btnOkOut_Click(object sender, EventArgs e)
        {
            PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
            var pkOut = new Execute(pkdata).GetSinglePKIn(txtRFIDOut.Text);
            if (pkOut != null)
            {
                new Execute(pkdata).SavePKOut(pkOut.ID, DateTime.Now);
                LoadDataToGrid();
            }
        }
        #endregion

        public void SetFormatString(DevExpress.XtraEditors.TextEdit pControl, DevExpress.Utils.FormatType pFormatType, bool pIsFC)
        {
            if (pFormatType == DevExpress.Utils.FormatType.DateTime)
            {
                pControl.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                pControl.Properties.DisplayFormat.FormatString = clsDeclare.glbFormatStringDate;
                pControl.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                pControl.Properties.EditFormat.FormatString = clsDeclare.glbFormatStringDate;
                pControl.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            }
            else if (pFormatType == DevExpress.Utils.FormatType.Numeric)
            {
                if (pIsFC)
                {
                    pControl.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    pControl.Properties.DisplayFormat.FormatString = clsDeclare.glbFormatStringNumberFC;
                    pControl.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    pControl.Properties.EditFormat.FormatString = clsDeclare.glbFormatStringNumberFC;

                }
                else
                {
                    pControl.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    pControl.Properties.DisplayFormat.FormatString = clsDeclare.glbFormatStringNumber;
                    pControl.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    pControl.Properties.EditFormat.FormatString = clsDeclare.glbFormatStringNumber;
                }
                pControl.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                //pControl.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            }
        }

    }
}