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
using Hugate.ComportConnections;
using System.Threading;
using Hugate.DataHelper;

namespace Hugate.Parking
{
    public partial class frmWayOut : DevExpress.XtraEditors.XtraForm
    {
        private string value;
        object imgOut;

        public frmWayOut()
        {
            InitializeComponent();
        }

        private void CaptureImage()
        {
            object info;
            axVitaminCtrl1.GetSnapshot(VITAMINDECODERLib.EPictureFormat.ePicFmtJpeg, out imgOut, out info);
        }

        private void Check()
        {
            PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
            byte[] arrImgFront = null;
            byte[] arrImgBack = null;
            frontPic.EditValue = null;
            backPic.EditValue = null;
            ImageConverter converter = new ImageConverter();
            var pk = new Execute(pkdata).GetSinglePKIn(txtRFID.Text);
            if (pk != null)
            {
                new Execute(pkdata).getImage(pk.ID, ref arrImgFront, true);
                if (arrImgFront != null)
                {
                    Image tmp = (Image)converter.ConvertFrom(arrImgFront);
                    frontPic.Image = tmp;
                    arrImgFront = null;
                }
                new Execute(pkdata).getImage(pk.ID, ref arrImgBack, false);
                if (arrImgBack != null)
                {
                    Image tmp = (Image)converter.ConvertFrom(arrImgBack);
                    backPic.Image = tmp;
                    arrImgBack = null;
                }
                LoadDataToControl(pk);
                btnOK.Focus();
            }

        }

        private void LoadDataToGrid()
        {
            PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
            pk_In_Out[] PakingIn = new Execute(pkdata).GetAllPKOut(0, 20);
            grcOut.BeginUpdate();
            grcOut.DataSource = PakingIn;
            grcOut.EndUpdate();
        }

        private void LoadDataToControl(vw_Pk_All pkOut)
        {
            txtNumber.Text = pkOut.Number;
            txtPrice.Text = String.Format("{0:##,##00}", pkOut.Price);
            teTimeIn.EditValue = pkOut.TimeIn;
            teTimeOut.EditValue = pkOut.TimeOut;
        }

        #region Camera
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

        private static MemoryStream ConvertImageToMemoryStream(System.Drawing.Image img)
        {
            var ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms;
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
        #endregion

        #region Event Method
        private void eventComPort1_LfDataReceived(object sender, LfEventArgs e)
        {
            value = e.value.ToString();
            this.Invoke(new EventHandler(UpdateData));
        }

        private void UpdateData(object sender, EventArgs e)
        {
            txtRFID.Text = value;
            Check();
        }

        private void frmLineOut_Activated(object sender, EventArgs e)
        {
            clsDeclare.eventComPort1.LfDataReceived += new LfDataReceivedEventHandler(eventComPort1_LfDataReceived);
            LoadDataToGrid();
            PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
            pk_Camera[] cams = new Execute(pkdata).GetAllCameras();
            foreach (pk_Camera cam in cams)
            {
                if (cam.areaId == 2)
                {
                    string[] sourceIP = cam.source.Split(':');
                    OpenCamera(cam.position, cam.login, cam.password, sourceIP[0], sourceIP[1]);
                }
            }
        }

        private void frmLineOut_Deactivate(object sender, EventArgs e)
        {
            clsDeclare.eventComPort1.LfDataReceived -= eventComPort1_LfDataReceived;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //pk_In_Out pkOut = new pk_In_Out();
            PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
            var pkOut = new Execute(pkdata).GetSinglePKIn(txtRFID.Text);
            if (pkOut != null)
            {
                //LoadDataToControl(pkOut);
                new Execute(pkdata).SavePKOut(pkOut.ID, DateTime.Now);
                LoadDataToGrid();
            }
        }
        #endregion
    }
}