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
    public partial class frmVehiclesPrice : DevExpress.XtraEditors.XtraForm
    {
        int ID;
        bool isAddNew = true;

        public frmVehiclesPrice()
        {
            InitializeComponent();
        }

        private void LoadDataToGrid()
        {
            PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
            IEnumerable<pk_Price> price = new Execute(pkdata).IEPrice();
            if (price != null)
            {
                DataTable dt = new DataTable();
                dt = clsDeclare.ObtainDataTableFromIEnumerable(price);
                if (dt.Rows.Count > 0)
                {
                    DataView dv = new DataView(dt);
                    if (dv != null)
                    {
                        grcVehicles.BeginUpdate();
                        grcVehicles.DataSource = dv;
                        grcVehicles.EndUpdate();
                    }
                }
            }
        }

        private void Save()
        {
            PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
            if (txtTypeVehicles.EditValue == null || txtPrice.EditValue == null)
            {
                return;
            }
            if (isAddNew)
            {
                new Execute(pkdata).SavePrice(txtTypeVehicles.EditValue.ToString(), Convert.ToDecimal(txtPrice.EditValue), Convert.ToString(txtNote.EditValue));
                LoadDataToGrid();
            }
            else
            {
                if (ID > 0)
                {
                    
                    new Execute(pkdata).EditPrice(ID, txtTypeVehicles.EditValue.ToString(), Convert.ToDecimal(txtPrice.EditValue), txtNote.EditValue.ToString());
                    LoadDataToGrid();
                }
            }
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
            btnClear.Enabled = true;
        }

        private void frmVehiclesPrice_Activated(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            LoadDataToGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAddNew = true;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnClear.Enabled = false;
            btnAdd.Enabled = false;
            txtTypeVehicles.EditValue = null;
            txtPrice.EditValue = null;
            txtNote.EditValue = null;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            isAddNew = false;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            btnClear.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                if (ID > 0)
                {
                    PKDataContext pkdata = new PKDataContext(clsDeclare.gblConnectStringLinQ);
                    new Execute(pkdata).DeletePrice(ID);
                    LoadDataToGrid();
                }
            }
        }

        private void grvVehicles_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow row = grvVehicles.GetDataRow(grvVehicles.FocusedRowHandle);
            if (row != null)
            {
                ID = Convert.ToInt32(row["ID"]);
                txtTypeVehicles.Text = row["VehicleType"].ToString();
                txtPrice.Text = row["Price"].ToString();
                txtNote.Text = row["Note"].ToString();
            }
        }

        private void frmVehiclesPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                isAddNew = false;
                btnSave.Enabled = false;
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnClear.Enabled = true;
            }
        }
    }
}