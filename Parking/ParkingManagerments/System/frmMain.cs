using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;
using DevExpress.Skins;

namespace Hugate.Parking
{
    public partial class frmMain : XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DevExpress.UserSkins.BonusSkins.Register();
        }

        private bool isActived(XtraForm frm)
        {
            if (MdiManager.Pages.Count > 0)
            {
                foreach (XtraMdiTabPage item in MdiManager.Pages)
                {
                    if (item.MdiChild.Name == frm.Name)
                    {
                        item.MdiChild.Select();
                        return true;
                    }
                }
                return false;
            }
            else return false;
        }

        private void bbtnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialogResult = XtraMessageBox.Show(defaultLookAndFeelMain.LookAndFeel, "Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void bbtnOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmWayOut pk = new frmWayOut();
            if (!isActived(pk))
            {
                pk.MdiParent = this;
                pk.Show();
            }
        }

        private void bbtnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmWayIn pk = new frmWayIn();
            if (!isActived(pk))
            {
                pk.MdiParent = this;
                pk.Show();
            }
        }

        private void bbtnSystem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSetting pk = new frmSetting();
            if (!isActived(pk))
            {
                pk.MdiParent = this;
                pk.Show();
            }
        }

        private void bbtnReports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportsMain pk = new frmReportsMain();
            if (!isActived(pk))
            {
                pk.MdiParent = this;
                pk.Show();
            }
        }

        private void bbtnPublic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmWayPublic pk = new frmWayPublic();
            if (!isActived(pk))
            {
                pk.MdiParent = this;
                pk.Show();
            }
        }

        private void bbtnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSearch pk = new frmSearch();
            if (!isActived(pk))
            {
                pk.MdiParent = this;
                pk.Show();
            }
        }

        private void MdiManager_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            clsDeclare.activedForm = (XtraForm)e.Page.MdiChild;
        }

        private void MdiManager_SelectedPageChanged(object sender, EventArgs e)
        {
            if (MdiManager.SelectedPage != null)
            {
                clsDeclare.activedForm = (XtraForm)MdiManager.SelectedPage.MdiChild;
            }
        }

        private void bbtnVehiclesType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmVehiclesPrice pk = new frmVehiclesPrice();
            if (!isActived(pk))
            {
                pk.MdiParent = this;
                pk.Show();
            }
        }

        private void btbnDeleteCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDelete delete = new frmDelete();
            delete.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void bbtnDatabaseOptions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDatabaseOption dbOptions = new frmDatabaseOption();
            dbOptions.ShowDialog();
        }
    }
}