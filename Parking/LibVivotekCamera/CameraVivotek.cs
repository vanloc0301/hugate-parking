using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibVivotekCamera
{
    public partial class CameraVivotek : Panel
    {
        public CameraVivotek()
        {
            InitializeComponent();
        }
        private string ipAddress;
        private string userName;
        private string port;
        private string password;
        private bool connect;

        public string IPAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Port
        {
            get { return port; }
            set { port = value; }
        }

        public bool isConnect
        {
            get { return connect; }
        }

        public void Start()
        {
            if (axVitaminCtrl1.ControlStatus == VITAMINDECODERLib.EControlStatus.ctrlConnecting ||
                axVitaminCtrl1.ControlStatus == VITAMINDECODERLib.EControlStatus.ctrlRunning)
            {
                axVitaminCtrl1.Disconnect();
                return;
            }
            axVitaminCtrl1.UserName = userName;
            axVitaminCtrl1.Password = password;
            axVitaminCtrl1.Url = "";
            axVitaminCtrl1.RemoteIPAddr = ipAddress;
            long lPort = System.Convert.ToInt32(port);
            if (lPort <= 0 || lPort > 65535)
                lPort = 80;
            axVitaminCtrl1.HttpPort = (int)lPort;
            axVitaminCtrl1.ForceNonYUV = true;
            axVitaminCtrl1.IgnoreCaption = true;
            axVitaminCtrl1.DisplayPeriod = 1;
            axVitaminCtrl1.DisplayTimeFormat = 0;
            axVitaminCtrl1.IgnoreBorder = true;
            axVitaminCtrl1.IgnoreCaption = true;
            axVitaminCtrl1.ViewStream = VITAMINDECODERLib.EDualStreamOption.eStream1;
            axVitaminCtrl1.Connect();
            connect = true;
        }

        public bool getImageCapture(ref object img)
        {
            object size = null;
            int result = axVitaminCtrl1.GetSnapshot(VITAMINDECODERLib.EPictureFormat.ePicFmtJpeg, out img, out size);
            if (result != 0)
            {
                return false;
            }
            return true;
        }

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.axVitaminCtrl1 = new AxVITAMINDECODERLib.AxVitaminCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.axVitaminCtrl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axVitaminCtrl1
            // 
            this.axVitaminCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axVitaminCtrl1.Enabled = true;
            this.axVitaminCtrl1.Location = new System.Drawing.Point(0, 0);
            this.axVitaminCtrl1.Name = "axVitaminCtrl1";
            this.axVitaminCtrl1.Size = new System.Drawing.Size(200, 100);
            this.axVitaminCtrl1.TabIndex = 0;
            // 
            // CameraVivotek
            // 
            this.Controls.Add(this.axVitaminCtrl1);
            this.Text = "CameraVivotek";
            ((System.ComponentModel.ISupportInitialize)(this.axVitaminCtrl1)).EndInit();
            this.ResumeLayout(false);

        }

        private AxVITAMINDECODERLib.AxVitaminCtrl axVitaminCtrl1;
    }
}
