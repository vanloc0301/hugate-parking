using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Hugate.DataHelper;

namespace Hugate.Parking
{
    public partial class frmReportsMain : DevExpress.XtraEditors.XtraForm
    {
        public frmReportsMain()
        {
            InitializeComponent();
        }

        private void navBarControl_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DataTable dt = new DataTable();
            frmReportsFilter filter = new frmReportsFilter();
            DataColumn col1 = new DataColumn("fromDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn("toDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add(col2);

            DataRow row = dt.NewRow();
            row["fromDate"] = filter.pubFromDate;
            row["toDate"] = filter.pubToDate;
            dt.Rows.Add(row);

            if (e.Link.Item == navItemIn)
            {
                DialogResult dialog = filter.ShowDialog();
                if (dialog == DialogResult.OK)
                {
                    PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
                    rptIn rpt = new rptIn();
                    string fromDate = String.Format("Ngày {0:dd/MM/yyyy}", filter.pubFromDate);
                    string toDate = String.Format("Ngày {0:dd/MM/yyyy}", filter.pubToDate);
                    string fromTime = String.Format("Từ {0:HH:mm}", filter.pubFromTime);
                    string toTime = String.Format("Đến {0:HH:mm}", filter.pubToTime);
                    rpt.xlbFromDate.Text = fromDate;
                    rpt.xlbToDate.Text = toDate;
                    rpt.xlbFromTime.Text = fromTime;
                    rpt.xlbToTime.Text = toTime;
                    rpt.DataSource = new Execute(pkdata).GetAll(filter.pubFromDate, filter.pubToDate);
                    printControl.PrintingSystem = rpt.PrintingSystem;
                    rpt.CreateDocument();
                }
            }
            else if (e.Link.Item == navItemTotal)
            {
                DialogResult dialog = filter.ShowDialog();
                if (dialog == DialogResult.OK)
                {
                    PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
                    rptTotalRevenua rpt = new rptTotalRevenua();
                    string fromDate = String.Format("Ngày {0:dd/MM/yyyy}", filter.pubFromDate);
                    string toDate = String.Format("Ngày {0:dd/MM/yyyy}", filter.pubToDate);
                    string fromTime = String.Format("Từ {0:HH:mm}", filter.pubFromTime);
                    string toTime = String.Format("Đến {0:HH:mm}", filter.pubToTime);
                    rpt.xlbFromDate.Text = fromDate;
                    rpt.xlbToDate.Text = toDate;
                    rpt.xlbFromTime.Text = fromTime;
                    rpt.xlbToTime.Text = toTime;
                    rpt.DataSource = new Execute(pkdata).TotalAmount(filter.pubFromDate, filter.pubToDate);
                    printControl.PrintingSystem = rpt.PrintingSystem;
                    rpt.CreateDocument();
                }
            }
        }
    }
}