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
    public partial class frmBaseList : DevExpress.XtraEditors.XtraForm
    {
        public frmBaseList()
        {
            InitializeComponent();
        }

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
                pControl.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            }
        }


        public bool CheckNullControl(DevExpress.XtraEditors.TextEdit pControl, string pLabelText)
        {
            pLabelText = pLabelText.Replace("(*)", "");

            if (pControl.EditValue == null || pControl.EditValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(this, "Vui lòng nhập " + pLabelText + "'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pControl.Focus();
                return false;
            }
            return true;
        }

        public bool CheckNullControl(DevExpress.XtraEditors.DateEdit pControl, string pLabelText)
        {
            pLabelText = pLabelText.Replace("(*)", "");

            if (pControl.EditValue == null || pControl.EditValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(this, "Vui lòng nhập " + pLabelText + "'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pControl.Focus();
                return false;
            }
            return true;
        }

        public bool CheckNullControl(DevExpress.XtraEditors.LookUpEdit pControl, string pLabelText)
        {
            pLabelText = pLabelText.Replace("(*)", "");

            if (pControl.EditValue == null || pControl.EditValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(this, "Vui lòng nhập " + pLabelText + "'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pControl.Focus();
                return false;
            }
            return true;
        }

        public bool CheckNullControl(DevExpress.XtraBars.BarEditItem pControl, string pLabelText)
        {
            pLabelText = pLabelText.Replace("(*)", "");

            if (pControl.EditValue == null || pControl.EditValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(this, "Vui lòng nhập " + pLabelText + "'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool CheckNullControl(System.Windows.Forms.ComboBox pControl, string pLabelText)
        {
            pLabelText = pLabelText.Replace("(*)", "");

            if (pControl.Text == null || pControl.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "Vui lòng nhập " + pLabelText + "'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }



        public virtual void New()
        {
      
        }

        public virtual void Save()
        {
       
        }

        public virtual void Edit()
        {

        }

        public virtual void Delete()
        {

        }

        public virtual void Cancel()
        {
        
        }

        private void frmBaseList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Cancel();
            }
        }
    }
}