using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Hugate.Parking
{
    public partial class frmReportsFilter : DevExpress.XtraEditors.XtraForm
    {
        public DateTime pubFromDate, pubToDate, pubFromTime, pubToTime;

        public frmReportsFilter()
        {
            InitializeComponent();
        }

        private void frmReportsFilter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                string from = String.Format("{0:MM/dd/yyyy} {1:HH:mm}", fromDate.EditValue, fromTime.EditValue);
                pubFromDate = Convert.ToDateTime(from);
                string to = String.Format("{0:MM/dd/yyyy} {1:HH:mm}", toDate.EditValue, toTime.EditValue);
                pubToDate = Convert.ToDateTime(to);

                string fromt = String.Format("{0:HH:mm}", toTime.EditValue);
                pubFromTime = Convert.ToDateTime(fromt);

                string tot = String.Format("{0:HH:mm}", toTime.EditValue);
                pubToTime = Convert.ToDateTime(tot);
            }
        }

        private void frmReportsFilter_Load(object sender, EventArgs e)
        {
            fromDate.EditValue = DateTime.Now;
            toDate.EditValue = DateTime.Now;
            fromTime.EditValue = DateTime.Now;
            toTime.EditValue = DateTime.Now;
        }
    }
}