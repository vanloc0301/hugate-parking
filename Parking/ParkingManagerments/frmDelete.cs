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

namespace Hugate.Parking
{
    public partial class frmDelete : DevExpress.XtraEditors.XtraForm
    {
        public frmDelete()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
            var pkOut = new Execute(pkdata).GetSinglePKIn(txtRFID.Text);
            if (pkOut != null)
            {
                new Execute(pkdata).DeleteCard(txtRFID.Text);
                this.Close();
            }
        }

        private void btnCheckIDCard_Click(object sender, EventArgs e)
        {
            try
            {
                PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
                //Kiem tra xem thẻ này là thế nào
                //pk_In_Out pkIn = new pk_In_Out();
                var pkIn = new Execute(pkdata).GetSinglePKIn(txtRFID.Text);

                //pk_In_Out pkOut = new pk_In_Out();
                var pkOut = new Execute(pkdata).GetSinglePKOut(txtRFID.Text);
                if (pkIn != null)
                {
                    if (pkIn.IsOut == false)
                    {
                        decimal price = new Execute(pkdata).GetPriceByID(pkIn.VehicleTypeID ?? 0);
                        txtPrice.Text = string.Format("{0}", price);
                        txtNumber.Text = pkIn.Number;
                        teTimeIn.EditValue = pkIn.TimeIn;
                        labelControl1.Enabled = true;
                        labelControl1.Text = "Xe này chưa ra khỏi bãi";
                        btnOK.Enabled = true;
                    }
                }
                if (pkOut != null)
                {
                    if (pkOut.IsOut == true)
                    {
                        //Lấy hết dữ liệu ra --- mới vào chưa ra
                        //Nếu tồn tại ID này đã ra -- có trong danh sách xe đã ra
                        pk_Price pkPice = new pk_Price();
                        decimal price = new Execute(pkdata).GetPriceByID(pkOut.VehicleTypeID ?? 0);
                        txtPrice.Text = string.Format("{0}", price);
                        txtNumber.Text = pkOut.Number;
                        teTimeIn.EditValue = pkOut.TimeIn;
                        teTimeOut.EditValue = pkOut.TimeOut; //xe nay da ra khỏi bãi
                        labelControl1.Enabled = true;
                        labelControl1.Text = "Xe này đã ra khỏi bãi";
                        btnOK.Enabled = false;
                    }
                }

            }

            catch
            {
                MessageBox.Show("Co loi ne");
            }
        }

        private void frmDelete_Load(object sender, EventArgs e)
        {
            labelControl1.Enabled = false;
            //btnOK.Enabled = false;
        }
    }
}