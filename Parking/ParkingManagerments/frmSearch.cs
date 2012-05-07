using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Hugate.DataHelper;
using System.Text.RegularExpressions;
using System.Collections;
using System.Reflection;
using Hugate.ComportConnections;

namespace Hugate.Parking
{
    public partial class frmSearch : XtraForm
    {
        List<pk_In_Out> list = new List<pk_In_Out>();
        bool isOut; bool isRFID = true; bool isNumber; bool isDate;
        string value = String.Empty;

        public frmSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (isRFID && txtRFID.EditValue == null)
            {
                MessageBox.Show("Mã thẻ không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (isNumber && txtNumber.EditValue == null)
            {
                MessageBox.Show("Biển số không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string from = String.Format("{0:MM/dd/yyyy} {1:HH:mm}", fromDate.EditValue, fromTime.EditValue);
            DateTime fromDateTime = Convert.ToDateTime(from);
            string to = String.Format("{0:MM/dd/yyyy} {1:HH:mm}", toDate.EditValue, toTime.EditValue);
            DateTime toDateTime = Convert.ToDateTime(to);
            Finder(txtRFID.Text, txtNumber.Text, fromDateTime, toDateTime);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rdbSearch.SelectedIndex = 0;
            txtRFID.EditValue = null;
            txtNumber.EditValue = null;
            chkRFID.Checked = true;
            chkNumber.Checked = false;
            chkTime.Checked = false;
        }

        private void LoadDataToGrid(IEnumerable<pk_In_Out> result)
        {
            DataTable dt = new DataTable();
            dt = clsDeclare.ObtainDataTableFromIEnumerable(result);
            if (dt.Rows.Count > 0)
            {
                DataView dv = new DataView(dt);
                if (dv != null)
                {
                    grcOut.BeginUpdate();
                    grcOut.DataSource = dv;
                    grcOut.EndUpdate();
                }
            }
            else
            {
                grcOut.BeginUpdate();
                grcOut.DataSource = null;
                grcOut.EndUpdate();
            }
        }

        private void Finder(string RFID, string Number, DateTime fromDate, DateTime toDate)
        {
            PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
            var result = new Execute(pkdata).Search(RFID, Number, fromDate, toDate, isOut, isRFID, isNumber, isDate);
            grcOut.DataSource = null;
            frontPic.Image = null;
            backPic.Image = null;

            if (result != null)
            {
                LoadDataToGrid(result);
            }
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
            list = new Execute(pkdata).GetAll().ToList();
            chkRFID.Checked = true;
            txtNumber.Enabled = false;
            fromDate.Enabled = false;
            fromTime.Enabled = false;
            toDate.Enabled = false;
            toTime.Enabled = false;
            fromDate.EditValue = DateTime.Now;
            toDate.EditValue = DateTime.Now;
            fromTime.EditValue = DateTime.Now;
            toTime.EditValue = DateTime.Now;
        }

        private void grvOut_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
            DataRow row = grvOut.GetDataRow(grvOut.FocusedRowHandle);
            byte[] arrImgFront = null;
            byte[] arrIgmBack = null;
            ImageConverter converter = new ImageConverter();
            if (row != null)
            {
                new Execute(pkdata).getImage((Guid)row["ID"], ref arrImgFront, true);
                new Execute(pkdata).getImage((Guid)row["ID"], ref arrIgmBack, false);
                if (arrImgFront != null)
                {
                    Image tmp = (Image)converter.ConvertFrom(arrImgFront);
                    frontPic.Image = tmp;
                    arrImgFront = null;
                }
                else
                {
                    frontPic.Image = null;
                }
                if (arrIgmBack != null)
                {
                    Image tmp = (Image)converter.ConvertFrom(arrIgmBack);
                    backPic.Image = tmp;
                    arrIgmBack = null;
                }
                else
                    backPic.Image = null;
            }
        }

        private void rdbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbSearch.SelectedIndex == 0)
            {
                isOut = false;
            }
            else
            {
                isOut = true;
            }
        }

        private void chkRFID_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRFID.Checked)
            {
                isRFID = true;
                txtRFID.Enabled = true;
            }
            else
            {
                isRFID = false;
                txtRFID.Enabled = false;
            }
        }

        private void chkNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNumber.Checked)
            {
                isNumber = true;
                txtNumber.Enabled = true;
            }
            else
            {
                isNumber = false;
                txtNumber.Enabled = false;
            }

        }

        private void chkTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTime.Checked)
            {
                isDate = true;
                fromDate.Enabled = true;
                fromTime.Enabled = true;
                toDate.Enabled = true;
                toTime.Enabled = true;
            }
            else
            {
                isDate = false;
                fromDate.Enabled = false;
                fromTime.Enabled = false;
                toDate.Enabled = false;
                toTime.Enabled = false;
            }
        }

        private void frmSearch_Activated(object sender, EventArgs e)
        {
            clsDeclare.eventComPort1.LfDataReceived += new LfDataReceivedEventHandler(eventComPort1_LfDataReceived);
        }

        private void frmSearch_Deactivate(object sender, EventArgs e)
        {
            clsDeclare.eventComPort1.LfDataReceived -= eventComPort1_LfDataReceived;
        }

        void eventComPort1_LfDataReceived(object sender, LfEventArgs e)
        {
            value = e.value.ToString();
            this.Invoke(new EventHandler(UpdateData));
        }

        private void UpdateData(object sender, EventArgs e)
        {
            if (chkRFID.Checked)
            {
                txtRFID.EditValue = value;
            }
        }
    }
}