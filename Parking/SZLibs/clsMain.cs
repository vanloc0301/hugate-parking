using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.IO;
using System.Security.Cryptography;
using System.Net;
using System.Net.Mail;

namespace SZLibrary
{
    public class Common
    {
    }

    public class WaitDialog
    {
        private bool bisShow;
        private bool bisStart;
        private WaitDialogForm dialogForm;
        private Size size;
        private string strCaption;
        private string strMainCaption;
        private Thread thread;

        public WaitDialog()
            : this("Loading data. Please wait.", "", new Size(260, 50))
        {

        }

        public WaitDialog(string caption)
            : this("Loading data. Please wait.", caption, new Size(260, 50))
        {

        }

        public WaitDialog(string maincaption, string caption)
            : this(maincaption, caption, new Size(260, 50))
        {

        }

        public WaitDialog(string maincaption, string caption, Size size)
        {
            this.dialogForm = null;
            //this.dialogForm = new WaitDialogForm(maincaption, caption, size);
            this.strMainCaption = maincaption;
            this.strCaption = caption;
            this.size = size;
            this.bisShow = true;
            this.thread = new Thread(new ThreadStart(this.OnThreadStart));
            this.thread.Start();
        }

        public void Close()
        {
            this.thread.Abort();
            this.bisStart = false;
        }

        public void Dispose()
        {
            this.thread.Abort();
            this.bisStart = false;
        }

        public void Hide()
        {
            if (this.dialogForm.InvokeRequired)
            {
                SetEvent method = new SetEvent(this.pHide);
                this.dialogForm.Invoke(method);
            }
        }

        private void OnThreadStart()
        {
            this.dialogForm = new WaitDialogForm(this.strMainCaption, this.strCaption, this.size);
            this.dialogForm.Show();
            this.bisShow = true;
            this.bisStart = true;
            try
            {
                while (this.bisStart)
                {
                    Application.DoEvents();
                    Thread.Sleep(100);
                }
            }
            finally
            {
                this.dialogForm.Dispose();
                this.dialogForm = null;
            }
        }

        private void pHide()
        {
            this.dialogForm.Hide();
        }

        private void pShow()
        {
            this.dialogForm.Show();
        }

        public void Show()
        {
            if (this.dialogForm.InvokeRequired)
            {
                SetEvent method = new SetEvent(this.pShow);
                this.dialogForm.Invoke(method);
            }
        }

        public void Show(string caption)
        {
            if (this.dialogForm.InvokeRequired)
            {
                SetEvent method = new SetEvent(this.pShow);
                this.dialogForm.Invoke(method);
            }
            this.Caption = caption;
        }

        public void Show(string caption, string maincaption)
        {
            if (this.dialogForm.InvokeRequired)
            {
                SetEvent method = new SetEvent(this.pShow);
                this.dialogForm.Invoke(method);
            }
            this.MainCaption = maincaption;
            this.Caption = caption;
        }

        public string Caption
        {
            get
            {
                while (Information.IsNothing(this.dialogForm))
                {
                }
                return this.dialogForm.Caption;
            }
            set
            {
                while (Information.IsNothing(this.dialogForm))
                {
                }
                this.dialogForm.Caption = value;
                this.strCaption = value;
            }
        }

        public bool IsShow
        {
            get
            {
                return this.bisShow;
            }
            set
            {
                this.bisShow = value;
            }
        }

        public bool IsStart
        {
            get
            {
                return this.bisStart;
            }
            set
            {
                this.bisStart = value;
            }
        }

        public string MainCaption
        {
            get
            {
                while (Information.IsNothing(this.dialogForm))
                {
                }
                return this.strMainCaption;
            }
            set
            {
                while (Information.IsNothing(this.dialogForm))
                {
                }
                this.dialogForm.MainCaption = value;
                this.strMainCaption = value;
            }
        }

        public delegate void SetEvent();
    }

    public class WaitDialogForm : Form
    {
        private PictureBox pic;
        private string strCaption;
        private string strMainCaption;

        public WaitDialogForm()
            : this("Loading data. Please wait.", "", new Size(260, 50))
        {
        }

        public WaitDialogForm(string caption)
            : this("Loading data. Please wait.", caption, new Size(260, 50))
        {
        }

        public WaitDialogForm(string maincaption, string caption)
            : this(maincaption, caption, new Size(260, 50))
        {

        }

        public WaitDialogForm(string maincaption, string caption, Size size)
        {
            base.Paint += new PaintEventHandler(this.WaitDialogForm_Paint);
            this.strCaption = "";
            this.strMainCaption = "";
            this.strMainCaption = maincaption;
            this.strCaption = caption;
            this.pic = new PictureBox();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = size;
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            Size size2 = new Size(0x10, 0x10);
            this.pic.Size = size2;
            Point point = new Point(8, (int)Math.Round((double)((((double)this.ClientSize.Height) / 2.0) - 16.0)));
            this.pic.Location = point;
            //this.pic.Image = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(Application.StartupPath + @"\wait.gif"));
            //this.pic.Image = Image.FromFile(Application.StartupPath + @"\wait.gif");
            this.pic.Image = Properties.Resources.wait;
            this.Controls.Add(this.pic);
            this.Show();
            this.Refresh();
        }

        private void SetCaption(string Caption)
        {
            this.Caption = Caption;
        }

        private void SetMainCaption(string Caption)
        {
            this.MainCaption = Caption;
        }

        private void WaitDialogForm_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                RectangleF ef = new RectangleF();
                Rectangle clipRectangle = e.ClipRectangle;
                ef.X = e.ClipRectangle.X;
                ef.Y = e.ClipRectangle.Y;
                ef.Width = e.ClipRectangle.Width;
                ef.Height = e.ClipRectangle.Height;
                clipRectangle.Inflate(-1, -1);
                ef.Inflate(-1f, -1f);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                ControlPaint.DrawBorder3D(e.Graphics, clipRectangle, Border3DStyle.Flat);
                ef.X += 20f;
                ef.Width -= 20f;
                ef.Height /= 3f;
                ef.Y += ef.Height / 2f;
                e.Graphics.DrawString(this.strMainCaption, new Font("Arial", 9f, FontStyle.Bold), SystemBrushes.WindowText, ef, format);
                ef.Y += ef.Height;
                e.Graphics.DrawString(this.strCaption, new Font("Arial", 9f), SystemBrushes.WindowText, ef, format);
            }
            catch
            {
            }
        }

        public string Caption
        {
            get
            {
                return this.strCaption;
            }
            set
            {
                this.strCaption = value;
                if (this.InvokeRequired)
                {
                    SetCaptionCallback callback = new SetCaptionCallback(this.SetCaption);
                    this.Invoke(callback, new object[] { this.strCaption });
                }
                else
                {
                    this.Refresh();
                }
            }
        }

        public string MainCaption
        {
            get
            {
                return this.strMainCaption;
            }
            set
            {
                this.strMainCaption = value;
                if (this.InvokeRequired)
                {
                    SetCaptionCallback callback = new SetCaptionCallback(this.SetMainCaption);
                    this.Invoke(callback, new object[] { this.strMainCaption });
                }
                else
                {
                    this.Refresh();
                }
            }
        }

        public delegate void SetCaptionCallback(string Caption);
    }

    public class Caption
    {
        string NameSpace;
        DataSet glbDataset;
        OleDbConnection glbCon;

        string strControlNotSave = "LookUpEdit;DateEdit;MemoEdit;CalcEdit;TextEdit;BarStaticItem;ComboBoxEdit;PictureEdit;SpinEdit;TimeEdit;PopupContainerEdit;TextBox";

        public Caption(string pNameSpace, DataSet pDataset, OleDbConnection pCon)
        {
            NameSpace = pNameSpace;
            glbDataset = pDataset;
            glbCon = pCon;
        }

        #region Method SaveCaption

        public bool SaveCaption(string pLanguage)
        {
            if (glbDataset.Tables.Contains("SYS_Form"))
            {
                DataView dv = new DataView(glbDataset.Tables["SYS_Form"]);
                //dv.RowFilter = "FormType in (1,2,3)";

                string strTemp;
                Form frmTemp = new Form();
                Object objectTemp;
                string pFormName = "";
                foreach (DataRowView row in dv)
                {
                    pFormName = row["FormName"].ToString();
                    strTemp = System.Reflection.Assembly.Load(NameSpace).CodeBase;
                    Assembly assembly = System.Reflection.Assembly.LoadFrom(strTemp);
                    if (pFormName.Substring(0, 3) == "frm")
                    {
                        strTemp = NameSpace + "." + pFormName;
                    }
                    else
                    {
                        continue;
                    }
                    if (pFormName.Substring(0, 7) == "frmRepo")
                    {
                        continue;
                    }
                    objectTemp = assembly.CreateInstance(strTemp);
                    if (objectTemp != null)
                    {
                        frmTemp = (Form)objectTemp;
                        SaveCaption(frmTemp, pLanguage);
                    }
                }
            }
            return true;
        }

        public bool SaveCaption(string pFormName, string pLanguage)
        {
            string strTemp = System.Reflection.Assembly.Load(NameSpace).CodeBase;
            Assembly assembly = System.Reflection.Assembly.LoadFrom(strTemp);
            Form frmTemp = new Form();
            if (pFormName.Substring(0, 3) == "frm")
            {
                strTemp = NameSpace + "." + pFormName;
            }
            else
            {
                return false;
            }

            Object objectTemp = assembly.CreateInstance(strTemp);
            if (objectTemp != null)
            {
                frmTemp = (Form)objectTemp;
                return SaveCaption(frmTemp, pLanguage);
            }
            else
            {
                return false;
            }
        }

        public bool SaveCaption(Form pForm, string pLanguage)
        {
            if (pForm == null)
            {
                return false;
            }
            if (pLanguage == "")
            {
                return false;
            }

            InsertControl(pForm.Name, pForm.GetType().FullName, pForm.Name, pForm.Text, pLanguage, "");

            //if (pForm.Name == "frmMain")
            //{
            foreach (Control ctr in pForm.Controls)
            {
                if (ctr.GetType().Name == "BarDockControl")
                {
                    DevExpress.XtraBars.BarDockControl bar = (DevExpress.XtraBars.BarDockControl)ctr;
                    for (int i = 0; i < bar.Manager.Items.Count; i++)
                    {
                        InsertControl(pForm.Name, bar.Manager.Items[i].GetType().FullName, bar.Manager.Items[i].Name, bar.Manager.Items[i].Caption, pLanguage, bar.Manager.Items[i].Hint);
                    }
                }
            }
            //return true;

            foreach (Control ctr in pForm.Controls)
            {
                if (strControlNotSave.Contains(ctr.GetType().Name))
                {
                    continue;
                }
                else
                {
                    CallSaveCaption(ctr.GetType().Name, ctr, pForm, pLanguage);
                }
            }
            return true;
        }

        private void CallSaveCaption(string pControlName, Control ctr, Form pForm, string pLanguage)
        {
            switch (pControlName)
            {
                case "Panel":
                    System.Windows.Forms.Panel panel = (System.Windows.Forms.Panel)ctr;
                    SaveCaption(panel, pForm, pLanguage);
                    break;
                case "GroupBox":
                    System.Windows.Forms.GroupBox groupbox = (System.Windows.Forms.GroupBox)ctr;
                    SaveCaption(groupbox, pForm, pLanguage);
                    break;
                case "GroupControl":
                    DevExpress.XtraEditors.GroupControl myGroupControl = (DevExpress.XtraEditors.GroupControl)ctr;
                    SaveCaption(myGroupControl, pForm, pLanguage);
                    break;
                case "GridControl":
                    DevExpress.XtraGrid.GridControl ctrGrid = (DevExpress.XtraGrid.GridControl)ctr;
                    SaveCaption(ctrGrid, pForm, pLanguage);
                    break;
                case "TreeList":
                    DevExpress.XtraTreeList.TreeList ctrTree = (DevExpress.XtraTreeList.TreeList)ctr;
                    foreach (DevExpress.XtraTreeList.Columns.TreeListColumn col in ctrTree.Columns)
                    {
                        InsertControl(pForm.Name, col.GetType().FullName, col.Name, col.Caption, pLanguage, "");
                    }
                    break;
                case "XtraTabControl":
                    DevExpress.XtraTab.XtraTabControl ctrTab = (DevExpress.XtraTab.XtraTabControl)ctr;
                    SaveCaption(ctrTab, pForm, pLanguage);
                    break;
                case "SplitContainerControl":
                    DevExpress.XtraEditors.SplitContainerControl ctrSplitContainer = (DevExpress.XtraEditors.SplitContainerControl)ctr;
                    SaveCaption(ctrSplitContainer, pForm, pLanguage);
                    break;
                case "RadioGroup":
                    DevExpress.XtraEditors.RadioGroup myRadioGroup = (DevExpress.XtraEditors.RadioGroup)ctr;
                    SaveCaption(myRadioGroup, pForm, pLanguage);
                    break;
                case "XtraTabPage":
                    DevExpress.XtraTab.XtraTabPage ctrPage = (DevExpress.XtraTab.XtraTabPage)ctr;
                    SaveCaption(ctrPage, pForm, pLanguage);
                    break;
                case "ImageListBoxControl":
                    DevExpress.XtraEditors.ImageListBoxControl ctrImageListBoxControl = (DevExpress.XtraEditors.ImageListBoxControl)ctr;
                    SaveCaption(ctrImageListBoxControl, pForm, pLanguage);
                    break;
                case "ImageComboBoxEdit":
                    DevExpress.XtraEditors.ImageComboBoxEdit ctrImageComboBoxEdit = (DevExpress.XtraEditors.ImageComboBoxEdit)ctr;
                    SaveCaption(ctrImageComboBoxEdit, pForm, pLanguage);
                    break;

                default:
                    InsertControl(pForm.Name, ctr.GetType().FullName, ctr.Name, ctr.Text, pLanguage, "");
                    break;
            }
        }

        private void SaveCaption(DevExpress.XtraEditors.ImageComboBoxEdit ctrImageComboBoxEdit, Form pForm, string pLanguage)
        {
            for (int i = 0; i < ctrImageComboBoxEdit.Properties.Items.Count; i++)
            {
                InsertControl(pForm.Name, ctrImageComboBoxEdit.Properties.Items.GetType().FullName, ctrImageComboBoxEdit.Name + ctrImageComboBoxEdit.Properties.Items[i].Value.ToString(), ctrImageComboBoxEdit.Properties.Items[i].Description, pLanguage, "");
            }
        }

        private void SaveCaption(DevExpress.XtraEditors.ImageListBoxControl ctrImageListBoxControl, Form pForm, string pLanguage)
        {
            foreach (Control ctr in ctrImageListBoxControl.Controls)
            {
                if (strControlNotSave.Contains(ctr.GetType().Name))
                {
                    continue;
                }
            }
            for (int i = 0; i < ctrImageListBoxControl.Items.Count; i++)
            {
                InsertControl(pForm.Name, ctrImageListBoxControl.Items[i].Value.GetType().FullName, ctrImageListBoxControl.Items[i].Value.ToString(), ctrImageListBoxControl.Items[i].Value.ToString(), pLanguage, "");
            }
        }

        private void SaveCaption(DevExpress.XtraTab.XtraTabControl ctrTab, Form pForm, string pLanguage)
        {
            foreach (Control ctr in ctrTab.Controls)
            {
                if (strControlNotSave.Contains(ctr.GetType().Name))
                {
                    continue;
                }
                else
                {
                    CallSaveCaption(ctr.GetType().Name, ctr, pForm, pLanguage);
                }
            }
        }

        private void SaveCaption(System.Windows.Forms.Panel panel, Form pForm, string pLanguage)
        {
            foreach (Control ctr in panel.Controls)
            {
                if (strControlNotSave.Contains(ctr.GetType().Name))
                {
                    continue;
                }
                else
                {
                    CallSaveCaption(ctr.GetType().Name, ctr, pForm, pLanguage);
                }
            }
        }

        private void SaveCaption(System.Windows.Forms.GroupBox pGroupBox, Form pForm, string pLanguage)
        {
            InsertControl(pForm.Name, pGroupBox.GetType().FullName, pGroupBox.Name, pGroupBox.Text, pLanguage, "");
            foreach (Control ctr in pGroupBox.Controls)
            {
                if (strControlNotSave.Contains(ctr.GetType().Name))
                {
                    continue;
                }
                else
                {
                    CallSaveCaption(ctr.GetType().Name, ctr, pForm, pLanguage);
                }
            }
        }

        private void SaveCaption(DevExpress.XtraEditors.GroupControl pGroupControl, Form pForm, string pLanguage)
        {
            InsertControl(pForm.Name, pGroupControl.GetType().FullName, pGroupControl.Name, pGroupControl.Text, pLanguage, "");
            foreach (Control ctr in pGroupControl.Controls)
            {
                if (strControlNotSave.Contains(ctr.GetType().Name))
                {
                    continue;
                }
                else
                {
                    CallSaveCaption(ctr.GetType().Name, ctr, pForm, pLanguage);
                }
            }
        }

        private void SaveCaption(DevExpress.XtraTab.XtraTabPage ctrPage, Form pForm, string pLanguage)
        {
            InsertControl(pForm.Name, ctrPage.GetType().FullName, ctrPage.Name, ctrPage.Text, pLanguage, "");
            foreach (Control ctr in ctrPage.Controls)
            {
                if (strControlNotSave.Contains(ctr.GetType().Name))
                {
                    continue;
                }
                else
                {
                    CallSaveCaption(ctr.GetType().Name, ctr, pForm, pLanguage);
                }
            }
        }

        private void SaveCaption(DevExpress.XtraGrid.GridControl pGridControl, Form pForm, string pLanguage)
        {
            foreach (DevExpress.XtraEditors.Repository.RepositoryItem crtRepositoryItem in pGridControl.RepositoryItems)
            {
                if (crtRepositoryItem.GetType().Name == "RepositoryItemImageComboBox")
                {
                    DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox ctrRepositoryItemImageComboBox = (DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox)crtRepositoryItem;
                    foreach (DevExpress.XtraEditors.Controls.ImageComboBoxItem ctrImageComboBoxItem in ctrRepositoryItemImageComboBox.Items)
                    {
                        InsertControl(pForm.Name, ctrImageComboBoxItem.GetType().FullName, ctrImageComboBoxItem.Description, ctrImageComboBoxItem.Description, pLanguage, "");
                    }
                }
            }

            if (pGridControl.MainView.GetType().Name == "GridView")
            {
                DevExpress.XtraGrid.Views.Grid.GridView ctrGridView = (DevExpress.XtraGrid.Views.Grid.GridView)pGridControl.MainView;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in ctrGridView.Columns)
                {
                    InsertControl(pForm.Name, col.GetType().FullName, col.Name, col.Caption, pLanguage, "");
                }
            }
        }

        private void SaveCaption(DevExpress.XtraEditors.SplitContainerControl pctrSplitContainer, Form pForm, string pLanguage)
        {
            foreach (Control ctrSplit in pctrSplitContainer.Controls)
            {
                if (ctrSplit.GetType().Name == "SplitGroupPanel")
                {
                    DevExpress.XtraEditors.SplitGroupPanel ctrSplitGroupPanel = (DevExpress.XtraEditors.SplitGroupPanel)ctrSplit;

                    foreach (Control ctrSplitGroupPanel_ in ctrSplitGroupPanel.Controls)
                    {
                        if (ctrSplitGroupPanel_.GetType().Name == "NavBarControl")
                        {
                            DevExpress.XtraNavBar.NavBarControl ctrNavBar = (DevExpress.XtraNavBar.NavBarControl)ctrSplitGroupPanel_;
                            foreach (DevExpress.XtraNavBar.NavBarGroup group in ctrNavBar.Groups)
                            {
                                InsertControl(pForm.Name, group.GetType().FullName, group.Name, group.Caption, pLanguage, group.Hint);
                            }
                            foreach (DevExpress.XtraNavBar.NavBarItem item in ctrNavBar.Items)
                            {
                                InsertControl(pForm.Name, item.GetType().FullName, item.Name, item.Caption, pLanguage, item.Hint);
                            }
                        }
                        else
                        {
                            CallSaveCaption(ctrSplitGroupPanel_.GetType().Name, ctrSplitGroupPanel_, pForm, pLanguage);
                        }
                    }

                }
            }
        }

        private void SaveCaption(DevExpress.XtraEditors.RadioGroup pRadioGroup, Form pForm, string pLanguage)
        {
            foreach (DevExpress.XtraEditors.Controls.RadioGroupItem ctr in pRadioGroup.Properties.Items)
            {
                InsertControl(pForm.Name, ctr.GetType().FullName, ctr.Description, ctr.Description, pLanguage, "");
            }
        }

        #endregion

        #region Method SetCaption

        public bool SetCaption(Form pForm, string pLanguage)
        {
            if (pForm == null)
            {
                return false;
            }
            if (pLanguage == null)
            {
                return false;
            }
            if (pLanguage == "")
            {
                return false;
            }
            if (!glbDataset.Tables.Contains("SYS_Caption"))
            {
                return false;
            }
            DataView dv = new DataView(glbDataset.Tables["SYS_Caption"]);
            if (dv == null)
            {
                return false;
            }
            dv.Sort = "FormName,ControlName,Language";
            int index;
            DataRowView row;
            object[] keys = new object[3];

            //Form Text
            keys[0] = pForm.Name;
            keys[1] = pForm.Name;
            keys[2] = pLanguage;
            index = dv.Find(keys);
            if (index >= 0)
            {
                row = dv[index];
                pForm.Text = row["Text"].ToString();
            }

            //if (pForm.Name == "frmMain")
            //{
            foreach (Control ctr in pForm.Controls)
            {
                if (ctr.GetType().Name == "BarDockControl")
                {
                    DevExpress.XtraBars.BarDockControl bar = (DevExpress.XtraBars.BarDockControl)ctr;
                    for (int i = 0; i < bar.Manager.Items.Count; i++)
                    {
                        if (bar.Manager.Items[i].GetType().Name == "BarStaticItem")
                        {
                            continue;
                        }
                        keys[0] = pForm.Name;
                        keys[1] = bar.Manager.Items[i].Name;
                        keys[2] = pLanguage;
                        index = dv.Find(keys);
                        if (index >= 0)
                        {
                            row = dv[index];
                            bar.Manager.Items[i].Caption = row["Text"].ToString();
                            bar.Manager.Items[i].Hint = row["Hint"].ToString();
                        }
                    }
                }
            }
            //return true;

            foreach (Control ctr in pForm.Controls)
            {
                if (strControlNotSave.Contains(ctr.GetType().Name))
                {
                    continue;
                }
                CallSetCaption(ctr.GetType().Name, ctr, pForm, pLanguage, dv);
            }

            return true;
        }

        private void CallSetCaption(string pControlName, Control ctr, Form pForm, string pLanguage, DataView dv)
        {
            switch (pControlName)
            {
                case "Panel":
                    System.Windows.Forms.Panel panel = (System.Windows.Forms.Panel)ctr;
                    SetCaption(panel, pForm, pLanguage, dv);
                    break;
                case "GroupBox":
                    System.Windows.Forms.GroupBox groupbox = (System.Windows.Forms.GroupBox)ctr;
                    SetCaption(groupbox, pForm, pLanguage, dv);
                    break;
                case "GroupControl":
                    DevExpress.XtraEditors.GroupControl myGroupControl = (DevExpress.XtraEditors.GroupControl)ctr;
                    SetCaption(myGroupControl, pForm, pLanguage, dv);
                    break;
                case "GridControl":
                    DevExpress.XtraGrid.GridControl ctrGrid = (DevExpress.XtraGrid.GridControl)ctr;
                    SetCaption(ctrGrid, pForm, pLanguage, dv);
                    break;
                case "TreeList":
                    DevExpress.XtraTreeList.TreeList ctrTree = (DevExpress.XtraTreeList.TreeList)ctr;
                    SetCaption(ctrTree, pForm, pLanguage, dv);
                    break;
                case "XtraTabControl":
                    DevExpress.XtraTab.XtraTabControl ctrTab = (DevExpress.XtraTab.XtraTabControl)ctr;
                    SetCaption(ctrTab, pForm, pLanguage, dv);
                    break;
                case "SplitContainerControl":
                    DevExpress.XtraEditors.SplitContainerControl ctrSplitContainer = (DevExpress.XtraEditors.SplitContainerControl)ctr;
                    SetCaption(ctrSplitContainer, pForm, pLanguage, dv);
                    break;
                case "RadioGroup":
                    DevExpress.XtraEditors.RadioGroup myRadioGroup = (DevExpress.XtraEditors.RadioGroup)ctr;
                    SetCaption(myRadioGroup, pForm, pLanguage, dv);
                    break;
                case "XtraTabPage":
                    DevExpress.XtraTab.XtraTabPage ctrPage = (DevExpress.XtraTab.XtraTabPage)ctr;
                    SetCaption(ctrPage, pForm, pLanguage, dv);
                    break;
                case "ImageListBoxControl":
                    DevExpress.XtraEditors.ImageListBoxControl ctrImageListBoxControl = (DevExpress.XtraEditors.ImageListBoxControl)ctr;
                    SetCaption(ctrImageListBoxControl, pForm, pLanguage, dv);
                    break;
                case "ImageComboBoxEdit":
                    DevExpress.XtraEditors.ImageComboBoxEdit ctrImageComboBoxEdit = (DevExpress.XtraEditors.ImageComboBoxEdit)ctr;
                    SetCaption(ctrImageComboBoxEdit, pForm, pLanguage, dv);
                    break;
                default:
                    SetCaptionDefault(ctr, pForm, pLanguage, dv);
                    break;
            }
        }

        private void SetCaption(DevExpress.XtraEditors.ImageComboBoxEdit ctrImageComboBoxEdit, Form pForm, string pLanguage, DataView dv)
        {
            dv.Sort = "FormName,ControlName,Language";
            int index;
            DataRowView row;
            object[] keys = new object[3];
            for (int i = 0; i < ctrImageComboBoxEdit.Properties.Items.Count; i++)
            {
                keys[0] = pForm.Name;
                keys[1] = ctrImageComboBoxEdit.Name + ctrImageComboBoxEdit.Properties.Items[i].Value.ToString();
                keys[2] = pLanguage;
                index = dv.Find(keys);
                if (index >= 0)
                {
                    row = dv[index];
                    ctrImageComboBoxEdit.Properties.Items[i].Description = row["Text"].ToString();
                }
            }
        }

        private void SetCaption(DevExpress.XtraEditors.ImageListBoxControl ctrImageListBoxControl, Form pForm, string pLanguage, DataView dv)
        {
            dv.Sort = "FormName,ControlName,Language";
            int index;
            DataRowView row;
            object[] keys = new object[3];
            for (int i = 0; i < ctrImageListBoxControl.Items.Count; i++)
            {
                keys[0] = pForm.Name;
                keys[1] = ctrImageListBoxControl.Items[i].Value.ToString();
                keys[2] = pLanguage;
                index = dv.Find(keys);
                if (index >= 0)
                {
                    row = dv[index];
                    ctrImageListBoxControl.Items[i].Value = row["Text"].ToString();
                    //ctrImageListBoxControl.Items[i].Hint = row["Hint"].ToString();
                }
                // InsertControl(pForm.Name, ctrImageListBoxControl.Items[i].Value.GetType().FullName, ctrImageListBoxControl.Items[i].Value.ToString(), ctrImageListBoxControl.Items[i].Value.ToString(), pLanguage, "");
            }
        }

        private void SetCaption(DevExpress.XtraTab.XtraTabControl ctrTab, Form pForm, string pLanguage, DataView dv)
        {
            foreach (Control ctr in ctrTab.Controls)
            {
                CallSetCaption(ctr.GetType().Name, ctr, pForm, pLanguage, dv);
            }
        }

        private void SetCaption(System.Windows.Forms.Panel panel, Form pForm, string pLanguage, DataView dv)
        {
            foreach (Control ctr in panel.Controls)
            {
                CallSetCaption(ctr.GetType().Name, ctr, pForm, pLanguage, dv);
            }
        }

        private void SetCaption(System.Windows.Forms.GroupBox groupbox, Form pForm, string pLanguage, DataView dv)
        {
            dv.Sort = "FormName,ControlName,Language";
            int index;
            DataRowView row;
            object[] keys = new object[3];
            keys[0] = pForm.Name;
            keys[1] = groupbox.Name;
            keys[2] = pLanguage;
            index = dv.Find(keys);
            if (index >= 0)
            {
                row = dv[index];
                groupbox.Text = row["Text"].ToString();
            }

            foreach (Control ctr in groupbox.Controls)
            {
                CallSetCaption(ctr.GetType().Name, ctr, pForm, pLanguage, dv);
            }
        }

        private void SetCaption(DevExpress.XtraEditors.GroupControl pGroupControl, Form pForm, string pLanguage, DataView dv)
        {
            dv.Sort = "FormName,ControlName,Language";
            int index;
            DataRowView row;
            object[] keys = new object[3];
            keys[0] = pForm.Name;
            keys[1] = pGroupControl.Name;
            keys[2] = pLanguage;
            index = dv.Find(keys);
            if (index >= 0)
            {
                row = dv[index];
                pGroupControl.Text = row["Text"].ToString();
            }

            foreach (Control ctr in pGroupControl.Controls)
            {
                CallSetCaption(ctr.GetType().Name, ctr, pForm, pLanguage, dv);
            }
        }

        private void SetCaption(DevExpress.XtraTab.XtraTabPage ctrPage, Form pForm, string pLanguage, DataView dv)
        {
            dv.Sort = "FormName,ControlName,Language";
            int index;
            DataRowView row;
            object[] keys = new object[3];
            keys[0] = pForm.Name;
            keys[1] = ctrPage.Name;
            keys[2] = pLanguage;
            index = dv.Find(keys);
            if (index >= 0)
            {
                row = dv[index];
                ctrPage.Text = row["Text"].ToString();
            }
            foreach (Control ctr in ctrPage.Controls)
            {
                CallSetCaption(ctr.GetType().Name, ctr, pForm, pLanguage, dv);
            }
        }

        private void SetCaption(DevExpress.XtraGrid.GridControl ctrGrid, Form pForm, string pLanguage, DataView dv)
        {
            dv.Sort = "FormName,ControlName,Language";
            int index;
            DataRowView row;
            object[] keys = new object[3];

            foreach (DevExpress.XtraEditors.Repository.RepositoryItem crtRepositoryItem in ctrGrid.RepositoryItems)
            {
                if (crtRepositoryItem.GetType().Name == "RepositoryItemImageComboBox")
                {
                    DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox ctrRepositoryItemImageComboBox = (DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox)crtRepositoryItem;
                    foreach (DevExpress.XtraEditors.Controls.ImageComboBoxItem ctrImageComboBoxItem in ctrRepositoryItemImageComboBox.Items)
                    {
                        keys[0] = pForm.Name;
                        keys[1] = ctrImageComboBoxItem.Description;
                        keys[2] = pLanguage;
                        index = dv.Find(keys);
                        if (index >= 0)
                        {
                            row = dv[index];
                            ctrImageComboBoxItem.Description = row["Text"].ToString();
                        }
                        //InsertControl(pForm.Name, ctrImageComboBoxItem.GetType().FullName, ctrImageComboBoxItem.Description, ctrImageComboBoxItem.Description, pLanguage, "");
                    }
                }
            }

            if (ctrGrid.MainView.GetType().Name == "GridView")
            {
                DevExpress.XtraGrid.Views.Grid.GridView ctrGridView = (DevExpress.XtraGrid.Views.Grid.GridView)ctrGrid.MainView;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in ctrGridView.Columns)
                {
                    keys[0] = pForm.Name;
                    keys[1] = col.Name;
                    keys[2] = pLanguage;
                    index = dv.Find(keys);
                    if (index >= 0)
                    {
                        row = dv[index];
                        col.Caption = row["Text"].ToString();
                    }
                }
            }
        }

        private void SetCaption(DevExpress.XtraEditors.SplitContainerControl pctrSplitContainer, Form pForm, string pLanguage, DataView dv)
        {
            dv.Sort = "FormName,ControlName,Language";
            int index;
            DataRowView row;
            object[] keys = new object[3];

            foreach (Control ctrSplit in pctrSplitContainer.Controls)
            {
                if (ctrSplit.GetType().Name == "SplitGroupPanel")
                {
                    DevExpress.XtraEditors.SplitGroupPanel ctrSplitGroupPanel = (DevExpress.XtraEditors.SplitGroupPanel)ctrSplit;

                    foreach (Control ctrSplitGroupPanel_ in ctrSplitGroupPanel.Controls)
                    {
                        if (ctrSplitGroupPanel_.GetType().Name == "NavBarControl")
                        {
                            DevExpress.XtraNavBar.NavBarControl ctrNavBar = (DevExpress.XtraNavBar.NavBarControl)ctrSplitGroupPanel_;
                            foreach (DevExpress.XtraNavBar.NavBarGroup group in ctrNavBar.Groups)
                            {
                                keys[0] = pForm.Name;
                                keys[1] = group.Name;
                                keys[2] = pLanguage;
                                index = dv.Find(keys);
                                if (index >= 0)
                                {
                                    row = dv[index];
                                    group.Caption = row["Text"].ToString();
                                    group.Hint = row["Hint"].ToString();
                                }
                            }
                            foreach (DevExpress.XtraNavBar.NavBarItem item in ctrNavBar.Items)
                            {
                                keys[0] = pForm.Name;
                                keys[1] = item.Name;
                                keys[2] = pLanguage;
                                index = dv.Find(keys);
                                if (index >= 0)
                                {
                                    row = dv[index];
                                    item.Caption = row["Text"].ToString();
                                    item.Hint = row["Hint"].ToString();
                                }
                            }
                        }
                        else
                        {
                            CallSetCaption(ctrSplitGroupPanel_.GetType().Name, ctrSplitGroupPanel_, pForm, pLanguage, dv);
                        }
                    }

                }
            }
        }

        private void SetCaption(DevExpress.XtraEditors.RadioGroup pRadioGroup, Form pForm, string pLanguage, DataView dv)
        {
            dv.Sort = "FormName,ControlName,Language";
            int index;
            DataRowView row;
            object[] keys = new object[3];
            foreach (DevExpress.XtraEditors.Controls.RadioGroupItem ctr in pRadioGroup.Properties.Items)
            {
                keys[0] = pForm.Name;
                keys[1] = ctr.Description;
                keys[2] = pLanguage;
                index = dv.Find(keys);
                if (index >= 0)
                {
                    row = dv[index];
                    ctr.Description = row["Text"].ToString();
                }
            }
        }

        private void SetCaption(DevExpress.XtraTreeList.TreeList ctrTree, Form pForm, string pLanguage, DataView dv)
        {
            dv.Sort = "FormName,ControlName,Language";
            int index;
            DataRowView row;
            object[] keys = new object[3];
            foreach (DevExpress.XtraTreeList.Columns.TreeListColumn col in ctrTree.Columns)
            {
                keys[0] = pForm.Name;
                keys[1] = col.Name;
                keys[2] = pLanguage;
                index = dv.Find(keys);
                if (index >= 0)
                {
                    row = dv[index];
                    col.Caption = row["Text"].ToString();
                }
            }
        }

        private void SetCaptionDefault(Control ctr, Form pForm, string pLanguage, DataView dv)
        {
            dv.Sort = "FormName,ControlName,Language";
            int index;
            DataRowView row;
            object[] keys = new object[3];
            keys[0] = pForm.Name;
            keys[1] = ctr.Name;
            keys[2] = pLanguage;
            index = dv.Find(keys);
            if (index >= 0)
            {
                row = dv[index];
                ctr.Text = row["Text"].ToString();
            }
        }

        #endregion

        #region Method Update

        private bool DeleteControl(string pFormName)
        {
            string SQL = "Delete from SYS_Caption where FormName = '" + pFormName + "'";
            glbCon.Open();
            OleDbCommand cmd = new OleDbCommand(SQL, glbCon);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                glbCon.Close();
            }
        }

        private bool DeleteControl(string pFormName, string pLanguage)
        {
            string SQL = "Delete from SYS_Caption where FormName = '" + pFormName + "' and Language = '" + pLanguage + "'";
            glbCon.Open();
            OleDbCommand cmd = new OleDbCommand(SQL, glbCon);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                glbCon.Close();
            }
        }

        private bool InsertControl(string pFormName, string pControlType, string pControlName, string pText, string pLanguage, string pHint)
        {
            string SQL = "";
            SQL = "INSERT INTO [SYS_Caption] ([FormName],[ControlType],[ControlName],[OriginalText],[Text],[Language],[OriginalHint],[Hint])VALUES(N'" + pFormName + "',N'" + pControlType + "',N'" + pControlName + "',N'" + pText + "',N'" + pText + "',N'" + pLanguage + "',N'" + pHint + "',N'" + pHint + "')";
            glbCon.Open();
            OleDbCommand cmd = new OleDbCommand(SQL, glbCon);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                glbCon.Close();
            }

        }

        #endregion
    }

    public class EncDec
    {
        // Encrypt a byte array into a byte array using a key and an IV

        public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            // Create a MemoryStream to accept the encrypted bytes

            MemoryStream ms = new MemoryStream();

            // Create a symmetric algorithm.

            // We are going to use Rijndael because it is strong and

            // available on all platforms.

            // You can use other algorithms, to do so substitute the

            // next line with something like

            //      TripleDES alg = TripleDES.Create();

            Rijndael alg = Rijndael.Create();

            // Now set the key and the IV.

            // We need the IV (Initialization Vector) because

            // the algorithm is operating in its default

            // mode called CBC (Cipher Block Chaining).

            // The IV is XORed with the first block (8 byte)

            // of the data before it is encrypted, and then each

            // encrypted block is XORed with the

            // following block of plaintext.

            // This is done to make encryption more secure.


            // There is also a mode called ECB which does not need an IV,

            // but it is much less secure.

            alg.Key = Key;
            alg.IV = IV;

            // Create a CryptoStream through which we are going to be

            // pumping our data.

            // CryptoStreamMode.Write means that we are going to be

            // writing data to the stream and the output will be written

            // in the MemoryStream we have provided.

            CryptoStream cs = new CryptoStream(ms,
               alg.CreateEncryptor(), CryptoStreamMode.Write);

            // Write the data and make it do the encryption

            cs.Write(clearData, 0, clearData.Length);

            // Close the crypto stream (or do FlushFinalBlock).

            // This will tell it that we have done our encryption and

            // there is no more data coming in,

            // and it is now a good time to apply the padding and

            // finalize the encryption process.

            cs.Close();

            // Now get the encrypted data from the MemoryStream.

            // Some people make a mistake of using GetBuffer() here,

            // which is not the right way.

            byte[] encryptedData = ms.ToArray();

            return encryptedData;
        }

        // Encrypt a string into a string using a password

        //    Uses Encrypt(byte[], byte[], byte[])


        public static string Encrypt(string clearText, string Password)
        {
            // First we need to turn the input string into a byte array.
            if (clearText.Trim() == "")
            {
                return "";
            }
            byte[] clearBytes =
              System.Text.Encoding.Unicode.GetBytes(clearText);

            // Then, we need to turn the password into Key and IV

            // We are using salt to make it harder to guess our key

            // using a dictionary attack -

            // trying to guess a password by enumerating all possible words.

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
           0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            // Now get the key/IV and do the encryption using the

            // function that accepts byte arrays.

            // Using PasswordDeriveBytes object we are first getting

            // 32 bytes for the Key

            // (the default Rijndael key length is 256bit = 32bytes)

            // and then 16 bytes for the IV.

            // IV should always be the block size, which is by default

            // 16 bytes (128 bit) for Rijndael.

            // If you are using DES/TripleDES/RC2 the block size is

            // 8 bytes and so should be the IV size.

            // You can also read KeySize/BlockSize properties off

            // the algorithm to find out the sizes.

            byte[] encryptedData = Encrypt(clearBytes,
                     pdb.GetBytes(32), pdb.GetBytes(16));

            // Now we need to turn the resulting byte array into a string.

            // A common mistake would be to use an Encoding class for that.

            //It does not work because not all byte values can be

            // represented by characters.

            // We are going to be using Base64 encoding that is designed

            //exactly for what we are trying to do.

            return Convert.ToBase64String(encryptedData);

        }

        // Encrypt bytes into bytes using a password

        //    Uses Encrypt(byte[], byte[], byte[])


        public static byte[] Encrypt(byte[] clearData, string Password)
        {
            // We need to turn the password into Key and IV.

            // We are using salt to make it harder to guess our key

            // using a dictionary attack -

            // trying to guess a password by enumerating all possible words.

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
           0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            // Now get the key/IV and do the encryption using the function

            // that accepts byte arrays.

            // Using PasswordDeriveBytes object we are first getting

            // 32 bytes for the Key

            // (the default Rijndael key length is 256bit = 32bytes)

            // and then 16 bytes for the IV.

            // IV should always be the block size, which is by default

            // 16 bytes (128 bit) for Rijndael.

            // If you are using DES/TripleDES/RC2 the block size is 8

            // bytes and so should be the IV size.

            // You can also read KeySize/BlockSize properties off the

            // algorithm to find out the sizes.

            return Encrypt(clearData, pdb.GetBytes(32), pdb.GetBytes(16));

        }

        // Encrypt a file into another file using a password

        public static void Encrypt(string fileIn,
                    string fileOut, string Password)
        {

            // First we are going to open the file streams

            FileStream fsIn = new FileStream(fileIn,
                FileMode.Open, FileAccess.Read);
            FileStream fsOut = new FileStream(fileOut,
                FileMode.OpenOrCreate, FileAccess.Write);

            // Then we are going to derive a Key and an IV from the

            // Password and create an algorithm

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
           0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            Rijndael alg = Rijndael.Create();
            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);

            // Now create a crypto stream through which we are going

            // to be pumping data.

            // Our fileOut is going to be receiving the encrypted bytes.

            CryptoStream cs = new CryptoStream(fsOut,
                alg.CreateEncryptor(), CryptoStreamMode.Write);

            // Now will will initialize a buffer and will be processing

            // the input file in chunks.

            // This is done to avoid reading the whole file (which can

            // be huge) into memory.

            int bufferLen = 4096;
            byte[] buffer = new byte[bufferLen];
            int bytesRead;

            do
            {
                // read a chunk of data from the input file

                bytesRead = fsIn.Read(buffer, 0, bufferLen);

                // encrypt it

                cs.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);

            // close everything


            // this will also close the unrelying fsOut stream

            cs.Close();
            fsIn.Close();
        }

        // Decrypt a byte array into a byte array using a key and an IV

        public static byte[] Decrypt(byte[] cipherData,
                                    byte[] Key, byte[] IV)
        {
            // Create a MemoryStream that is going to accept the

            // decrypted bytes

            MemoryStream ms = new MemoryStream();

            // Create a symmetric algorithm.

            // We are going to use Rijndael because it is strong and

            // available on all platforms.

            // You can use other algorithms, to do so substitute the next

            // line with something like

            //     TripleDES alg = TripleDES.Create();

            Rijndael alg = Rijndael.Create();

            // Now set the key and the IV.

            // We need the IV (Initialization Vector) because the algorithm

            // is operating in its default

            // mode called CBC (Cipher Block Chaining). The IV is XORed with

            // the first block (8 byte)

            // of the data after it is decrypted, and then each decrypted

            // block is XORed with the previous

            // cipher block. This is done to make encryption more secure.

            // There is also a mode called ECB which does not need an IV,

            // but it is much less secure.

            alg.Key = Key;
            alg.IV = IV;

            // Create a CryptoStream through which we are going to be

            // pumping our data.

            // CryptoStreamMode.Write means that we are going to be

            // writing data to the stream

            // and the output will be written in the MemoryStream

            // we have provided.

            CryptoStream cs = new CryptoStream(ms,
                alg.CreateDecryptor(), CryptoStreamMode.Write);

            // Write the data and make it do the decryption

            cs.Write(cipherData, 0, cipherData.Length);

            // Close the crypto stream (or do FlushFinalBlock).

            // This will tell it that we have done our decryption

            // and there is no more data coming in,

            // and it is now a good time to remove the padding

            // and finalize the decryption process.

            cs.Close();

            // Now get the decrypted data from the MemoryStream.

            // Some people make a mistake of using GetBuffer() here,

            // which is not the right way.

            byte[] decryptedData = ms.ToArray();

            return decryptedData;
        }

        // Decrypt a string into a string using a password

        //    Uses Decrypt(byte[], byte[], byte[])


        public static string Decrypt(string cipherText, string Password)
        {
            try
            {
                // First we need to turn the input string into a byte array.

                // We presume that Base64 encoding was used

                if (cipherText == "")
                {
                    return "";
                }
                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                // Then, we need to turn the password into Key and IV

                // We are using salt to make it harder to guess our key

                // using a dictionary attack -

                // trying to guess a password by enumerating all possible words.

                PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                    new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65,
           0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

                // Now get the key/IV and do the decryption using

                // the function that accepts byte arrays.

                // Using PasswordDeriveBytes object we are first

                // getting 32 bytes for the Key

                // (the default Rijndael key length is 256bit = 32bytes)

                // and then 16 bytes for the IV.

                // IV should always be the block size, which is by

                // default 16 bytes (128 bit) for Rijndael.

                // If you are using DES/TripleDES/RC2 the block size is

                // 8 bytes and so should be the IV size.

                // You can also read KeySize/BlockSize properties off

                // the algorithm to find out the sizes.

                byte[] decryptedData = Decrypt(cipherBytes,
                    pdb.GetBytes(32), pdb.GetBytes(16));

                // Now we need to turn the resulting byte array into a string.

                // A common mistake would be to use an Encoding class for that.

                // It does not work

                // because not all byte values can be represented by characters.

                // We are going to be using Base64 encoding that is

                // designed exactly for what we are trying to do.

                return System.Text.Encoding.Unicode.GetString(decryptedData);
            }
            catch
            {
                return "";
            }
        }

        // Decrypt bytes into bytes using a password

        //    Uses Decrypt(byte[], byte[], byte[])


        public static byte[] Decrypt(byte[] cipherData, string Password)
        {
            // We need to turn the password into Key and IV.

            // We are using salt to make it harder to guess our key

            // using a dictionary attack -

            // trying to guess a password by enumerating all possible words.

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
           0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            // Now get the key/IV and do the Decryption using the

            //function that accepts byte arrays.

            // Using PasswordDeriveBytes object we are first getting

            // 32 bytes for the Key

            // (the default Rijndael key length is 256bit = 32bytes)

            // and then 16 bytes for the IV.

            // IV should always be the block size, which is by default

            // 16 bytes (128 bit) for Rijndael.

            // If you are using DES/TripleDES/RC2 the block size is

            // 8 bytes and so should be the IV size.


            // You can also read KeySize/BlockSize properties off the

            // algorithm to find out the sizes.

            return Decrypt(cipherData, pdb.GetBytes(32), pdb.GetBytes(16));
        }

        // Decrypt a file into another file using a password

        public static void Decrypt(string fileIn, string fileOut, string Password)
        {
            // First we are going to open the file streams
            FileStream fsIn = new FileStream(fileIn,
                        FileMode.Open, FileAccess.Read);
            FileStream fsOut = new FileStream(fileOut,
                        FileMode.OpenOrCreate, FileAccess.Write);
            // Then we are going to derive a Key and an IV from
            // the Password and create an algorithm
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
           0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
            Rijndael alg = Rijndael.Create();

            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);

            // Now create a crypto stream through which we are going

            // to be pumping data.

            // Our fileOut is going to be receiving the Decrypted bytes.

            CryptoStream cs = new CryptoStream(fsOut,
                alg.CreateDecryptor(), CryptoStreamMode.Write);

            // Now will will initialize a buffer and will be

            // processing the input file in chunks.

            // This is done to avoid reading the whole file (which can be

            // huge) into memory.

            int bufferLen = 4096;
            byte[] buffer = new byte[bufferLen];
            int bytesRead;
            do
            {
                // read a chunk of data from the input file
                bytesRead = fsIn.Read(buffer, 0, bufferLen);
                // Decrypt it
                cs.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);
            // close everything
            cs.Close();
            fsIn.Close();
        }
    }

    public class Email
    {
        public static Boolean SendEMail(string from, string to, string bbc, string subject, string messages, string user, string smtp, string password)
        {
            try
            {
                MailMessage mail = new MailMessage();
                MailAddress address = new MailAddress(from);
                mail.To.Add(to);
                if (bbc != "")
                {
                    mail.CC.Add(bbc);
                }
                mail.From = address;
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = Encoding.GetEncoding("utf-8");
                mail.Body = messages;
                if (smtp == "")
                {
                    smtp = "smtp.gmail.com";
                }

                SmtpClient objSmtpClient = new SmtpClient();
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.Credentials = new NetworkCredential(user, password);
                objSmtpClient.Host = smtp;
                objSmtpClient.Port = 25;
                objSmtpClient.EnableSsl = true;
                objSmtpClient.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean CheckConnectInternet()
        {
            try
            {
                System.Net.IPHostEntry objIPHE = System.Net.Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch
            {
                return false; // host not reachable.
            }
        }
    }

    public class Utils
    {
        public static Boolean CheckTwoNext(DateTime pDateOld, DateTime pDateNow, int pMinutesNext)
        {
            TimeSpan t = pDateNow - pDateOld;
            if (t.TotalMinutes > 0 && t.TotalMinutes < pMinutesNext)
            {
                return true;
            }
            return false;
        }

        public static string ConvertTimeToString(object pDateTime)
        {
            string s = "";
            if (pDateTime == null)
            {
                return s;
            }
            DateTime dt = Convert.ToDateTime(pDateTime);
            s = dt.Hour.ToString() + ":" + dt.Minute.ToString() + ":" + dt.Second.ToString();
            return s;
        }

        public static string getOptionValue(string pOptionID, DataTable pDatTable)
        {
            string OptionValue = "";
            DataView dv = new DataView(pDatTable);
            int i;
            try
            {
                dv.Sort = "OptionID";
                i = dv.Find(pOptionID);
                if (i >= 0)
                {
                    OptionValue = Convert.ToString(dv[i]["Value"]);
                }
            }
            catch
            {
            }
            return OptionValue;
        }

        public static Boolean isInt(object pValue)
        {
            try
            {
                Convert.ToInt32(pValue);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static Boolean isDouble(object pValue)
        {
            try
            {
                Convert.ToDouble(pValue);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static Boolean isDate(object pValue)
        {
            try
            {
                Convert.ToDateTime(pValue);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static Boolean isMoney(object pValue)
        {
            double tmp = 0;
            try
            {
                tmp = Convert.ToDouble(pValue);
                if (tmp > 922337203685477.5807 || tmp < -922337203685477.5808)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static DateTime StringToDate(string pSTDate, string pStyle)
        {
            DateTime maxValue;
            try
            {
                int num = 0;
                int num2 = 0;
                int num3 = 0;
                switch (pStyle)
                {
                    case "dd/MM/yyyy":
                        num = Conversions.ToInteger(pSTDate.Substring(0, pSTDate.IndexOf("/", 0)));
                        num2 = Conversions.ToInteger(pSTDate.Substring(pSTDate.IndexOf("/", 0) + 1, (pSTDate.IndexOf("/", (int)(pSTDate.IndexOf("/", 0) + 1)) - pSTDate.IndexOf("/", 0)) - 1));
                        num3 = Conversions.ToInteger(pSTDate.Substring(pSTDate.IndexOf("/", (int)(pSTDate.IndexOf("/", 0) + 1)) + 1));
                        break;

                    case "MM/dd/yyyy":
                        num = Conversions.ToInteger(pSTDate.Substring(0, pSTDate.IndexOf("/", 0)));
                        num2 = Conversions.ToInteger(pSTDate.Substring(pSTDate.IndexOf("/", 0) + 1, (pSTDate.IndexOf("/", (int)(pSTDate.IndexOf("/", 0) + 1)) - pSTDate.IndexOf("/", 0)) - 1));
                        num3 = Conversions.ToInteger(pSTDate.Substring(pSTDate.IndexOf("/", (int)(pSTDate.IndexOf("/", 0) + 1)) + 1));
                        break;
                }
                DateTime time = new DateTime();
                maxValue = time.AddYears(num3 - 1).AddMonths(num2 - 1).AddDays((double)(num - 1));
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                maxValue = DateTime.MaxValue;
                ProjectData.ClearProjectError();
            }
            return maxValue;
        }

        public static DevExpress.XtraTreeList.Nodes.TreeListNode GetNode(DevExpress.XtraTreeList.TreeList pTreeList, Point pPoint)
        {
            DevExpress.XtraTreeList.TreeListHitInfo hi = pTreeList.GetHitInfo(pPoint);
            if (hi.HitInfoType == DevExpress.XtraTreeList.HitInfoType.Cell)
            {
                return hi.Node;
            }
            return null;
        }

        public static string ConvertHourToString(object pDate)
        {
            if (pDate == null)
            {
                return "";
            }
            if (pDate == DBNull.Value)
            {
                return "";
            }
            DateTime ddate = Convert.ToDateTime(pDate);
            string s = "";
            if (ddate.Hour > 9)
            {
                s = ddate.Hour.ToString() + ":";
            }
            else
            {
                s = "0" + ddate.Hour.ToString() + ":";
            }

            if (ddate.Minute > 9)
            {
                s += ddate.Minute.ToString() + ":";
            }
            else
            {
                s += "0" + ddate.Minute.ToString() + ":";
            }

            if (ddate.Second > 9)
            {
                s += ddate.Second.ToString() + ".";
            }
            else
            {
                s += "0" + ddate.Second.ToString() + ".";
            }

            if (ddate.Millisecond > 99)
            {
                s += ddate.Millisecond.ToString();
            }
            else if (ddate.Millisecond > 9)
            {
                s += "0" + ddate.Millisecond.ToString();
            }
            else
            {
                s += "00" + ddate.Millisecond.ToString();
            }
            return s;
        }

        public static string ConvertHourToStringNotSecond(object pDate)
        {
            if (pDate == null)
            {
                return "";
            }
            if (pDate == DBNull.Value)
            {
                return "";
            }
            DateTime ddate = Convert.ToDateTime(pDate);
            string s = "";
            if (ddate.Hour > 9)
            {
                s = ddate.Hour.ToString() + ":";
            }
            else
            {
                s = "0" + ddate.Hour.ToString() + ":";
            }

            if (ddate.Minute > 9)
            {
                s += ddate.Minute.ToString();
            }
            else
            {
                s += "0" + ddate.Minute.ToString();
            }
            return s;
        }

        public static string ConvertHourToStringNotSecondHN(object pDate)
        {
            if (pDate == null)
            {
                return "00:00";
            }
            if (pDate == DBNull.Value)
            {
                return "00:00";
            }
            DateTime ddate = Convert.ToDateTime(pDate);
            string s = "";
            if (ddate.Hour > 9)
            {
                s = ddate.Hour.ToString() + ":";
            }
            else
            {
                s = "0" + ddate.Hour.ToString() + ":";
            }

            if (ddate.Minute > 9)
            {
                s += ddate.Minute.ToString();
            }
            else
            {
                s += "0" + ddate.Minute.ToString();
            }
            return s;
        }

        public static string ConvertHourMinutesToString(int pHours, int pMinutes)
        {
            pHours = pHours + pMinutes / 60;
            pMinutes = pMinutes % 60;

            string s = "";
            if (pHours > 9)
            {
                s = pHours + ":";
            }
            else
            {
                s = "0" + pHours + ":";
            }

            if (pMinutes > 9)
            {
                s += pMinutes;
            }
            else
            {
                s += "0" + pMinutes;
            }
            return s;

        }

        public static int ConvertTimeToMinutes(object pDate)
        {
            if (pDate == null)
            {
                return 0;
            }
            if (pDate == DBNull.Value)
            {
                return 0;
            }
            DateTime d = Convert.ToDateTime(pDate);
            return d.Hour * 60 + d.Minute;
        }

        public static double ConvertTimeToHours(object pDate)
        {
            if (pDate == null)
            {
                return 0;
            }
            if (pDate == DBNull.Value)
            {
                return 0;
            }
            DateTime d = Convert.ToDateTime(pDate);
            double Mi = d.Minute / 60;
            return d.Hour + Math.Round(Mi, 2);
        }

        public static DateTime ConvertToDate(object pDate)
        {
            DateTime d = Convert.ToDateTime(pDate);
            DateTime day = new DateTime(d.Year, d.Month, d.Day);
            return day;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDate1"></param>
        /// <param name="pDate2"></param>
        /// <returns>0: False | 1: = | 2: < | 3: > </returns>
        public static Int32 CompareDate(object pDate1, object pDate2)
        {
            if (pDate1 == null || pDate2 == null)
            {
                return 0;
            }
            if (pDate1 == DBNull.Value || pDate2 == DBNull.Value)
            {
                return 0;
            }
            DateTime t1 = Convert.ToDateTime(pDate1);
            DateTime t2 = Convert.ToDateTime(pDate2);
            TimeSpan t = t1 - t2;
            if (t.TotalMilliseconds == 0)
            {
                return 1;
            }
            else if (t.TotalMilliseconds < 0)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        public static Int32 CompareDate(object pDate1, object pDate2, Boolean pNotTime)
        {
            if (pDate1 == null || pDate2 == null)
            {
                return 0;
            }
            if (pDate1 == DBNull.Value || pDate2 == DBNull.Value)
            {
                return 0;
            }
            DateTime t1 = Convert.ToDateTime(pDate1);
            DateTime t2 = Convert.ToDateTime(pDate2);
            if (pNotTime)
            {
                TimeSpan t = new DateTime(t1.Year, t1.Month, t1.Day) - new DateTime(t2.Year, t2.Month, t2.Day);
                if (t.TotalDays == 0)
                {
                    return 1;
                }
                else if (t.TotalDays < 0)
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                return CompareDate(pDate1, pDate2);
            }
        }

        public static Int32 CompareDateTimeSameDay(object pDate1, object pDate2)
        {
            if (pDate1 == null || pDate2 == null)
            {
                return 0;
            }
            if (pDate1 == DBNull.Value || pDate2 == DBNull.Value)
            {
                return 0;
            }
            DateTime t1 = Convert.ToDateTime(pDate1);
            DateTime t2 = Convert.ToDateTime(pDate2);

            DateTime fdate = new DateTime(2000, 1, 1, t1.Hour, t1.Minute, t1.Millisecond);
            DateTime tdate = new DateTime(2000, 1, 1, t2.Hour, t2.Minute, t2.Millisecond);

            TimeSpan t = t1 - t2;
            if (t.TotalMilliseconds == 0)
            {
                return 1;
            }
            else if (t.TotalMilliseconds < 0)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDate1"></param>
        /// <param name="pDate2"></param>
        /// <returns>0: False | 1: = | 2: < | 3: > </returns>
        public static Int32 CompareTime(object pDate1, object pDate2)
        {
            if (pDate1 == null || pDate2 == null)
            {
                return 0;
            }
            if (pDate1 == DBNull.Value || pDate2 == DBNull.Value)
            {
                return 0;
            }
            DateTime d1 = Convert.ToDateTime(pDate1);
            DateTime d2 = Convert.ToDateTime(pDate2);
            d1 = new DateTime(2000, 1, 1, d1.Hour, d1.Minute, d1.Second, d1.Millisecond);
            d2 = new DateTime(2000, 1, 1, d2.Hour, d2.Minute, d2.Second, d2.Millisecond);
            if (d1 == d2)
            {
                return 1;
            }
            else if (d1 < d2)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        public static Boolean CompareTwoDate(object pDate1, object pDate2)
        {
            if (pDate1 == null || pDate2 == null)
            {
                return false;
            }
            if (pDate1 == DBNull.Value || pDate2 == DBNull.Value)
            {
                return false;
            }
            //so sanh co qua ngay hay ko?
            TimeSpan t;
            DateTime t1 = Convert.ToDateTime(pDate1);
            DateTime t2 = Convert.ToDateTime(pDate2);
            t = new DateTime(t1.Year, t1.Month, t1.Day) - new DateTime(t2.Year, t2.Month, t2.Day);
            if (t.TotalDays >= 1)
            {
                return true;
            }
            return false;
        }

        public static Boolean CheckRepeatTime(object pShiftID1, object pShiftID2, DataTable pDataTable)
        {
            string myShiftID1 = Convert.ToString(pShiftID1);
            string myShiftID2 = Convert.ToString(pShiftID2);

            DataRow[] row1 = pDataTable.Select("ShiftCode = '" + myShiftID1 + "'");
            DataRow[] row2 = pDataTable.Select("ShiftCode = '" + myShiftID2 + "'");

            DateTime myStartTime1 = Convert.ToDateTime(row1[0]["StartTime"]);
            DateTime myEndTime1 = Convert.ToDateTime(row1[0]["EndTime"]);

            DateTime myStartTime2 = Convert.ToDateTime(row2[0]["StartTime"]);
            DateTime myEndTime2 = Convert.ToDateTime(row2[0]["EndTime"]);

            if (myStartTime2.CompareTo(myEndTime1) > 0)
            {
                return true;
            }
            if (myEndTime2.CompareTo(myStartTime1) < 0)
            {
                return true;
            }
            return false;
        }

        public static Boolean DateBetweenFromTo(object pDate, object pFromDate, object pToDate)
        {
            if (pDate == null || pFromDate == null || pToDate == null)
            {
                return false;
            }
            if (pDate == DBNull.Value || pFromDate == DBNull.Value || pToDate == DBNull.Value)
            {
                return false;
            }
            int i = 0;
            if (CompareDate(Convert.ToDateTime(pDate), Convert.ToDateTime(pFromDate), true) == 1 || CompareDate(Convert.ToDateTime(pDate), Convert.ToDateTime(pFromDate), true) == 3)
            {
                i = i + 1;
            }
            if (CompareDate(Convert.ToDateTime(pDate), Convert.ToDateTime(pToDate), true) == 1 || CompareDate(Convert.ToDateTime(pDate), Convert.ToDateTime(pToDate), true) == 2)
            {
                i = i + 1;
            }
            if (i == 2)
            {
                return true;
            }
            return false;
        }

        public static Boolean DateBetweenFromTo(object pDate, object pFromDate, object pToDate, Boolean pIsFixYear)
        {
            if (pDate == null || pFromDate == null || pToDate == null)
            {
                return false;
            }
            if (pDate == DBNull.Value || pFromDate == DBNull.Value || pToDate == DBNull.Value)
            {
                return false;
            }
            int i = 0;
            if (pIsFixYear)
            {
                if (CompareDate(Convert.ToDateTime(pDate), Convert.ToDateTime(pFromDate), true) == 1 || CompareDate(Convert.ToDateTime(pDate), Convert.ToDateTime(pFromDate), true) == 3)
                {
                    i = i + 1;
                }
                if (CompareDate(Convert.ToDateTime(pDate), Convert.ToDateTime(pToDate), true) == 1 || CompareDate(Convert.ToDateTime(pDate), Convert.ToDateTime(pToDate), true) == 2)
                {
                    i = i + 1;
                }
                if (i == 2)
                {
                    return true;
                }
            }
            else
            {
                DateTime date = new DateTime(2000, Convert.ToDateTime(pDate).Month, Convert.ToDateTime(pDate).Day);
                DateTime fdate = new DateTime(2000, Convert.ToDateTime(pFromDate).Month, Convert.ToDateTime(pFromDate).Day);
                DateTime tdate = new DateTime(2000, Convert.ToDateTime(pToDate).Month, Convert.ToDateTime(pToDate).Day);

                if (CompareDate(Convert.ToDateTime(date), Convert.ToDateTime(fdate), true) == 1 || CompareDate(Convert.ToDateTime(date), Convert.ToDateTime(fdate), true) == 3)
                {
                    i = i + 1;
                }
                if (CompareDate(Convert.ToDateTime(date), Convert.ToDateTime(tdate), true) == 1 || CompareDate(Convert.ToDateTime(date), Convert.ToDateTime(tdate), true) == 2)
                {
                    i = i + 1;
                }
                if (i == 2)
                {
                    return true;
                }
            }
            return false;
        }

        public static Boolean DateBetweenFromToWithTime(object pDate, object pFromDate, object pToDate)
        {
            if (pDate == null || pFromDate == null || pToDate == null)
            {
                return false;
            }
            if (pDate == DBNull.Value || pFromDate == DBNull.Value || pToDate == DBNull.Value)
            {
                return false;
            }
            DateTime d1 = Convert.ToDateTime(pDate);
            DateTime d2 = Convert.ToDateTime(pFromDate);
            DateTime d3 = Convert.ToDateTime(pToDate);

            DateTime dDate = new DateTime(d2.Year, d2.Month, d2.Day, d1.Hour, d1.Minute, d1.Second);
            DateTime fDate = Convert.ToDateTime(pFromDate);
            DateTime tDate = Convert.ToDateTime(pToDate);
            int i = 0;
            if (CompareDate(dDate, fDate) == 1 || CompareDate(dDate, fDate) == 3)
            {
                i = i + 1;
            }
            if (CompareDate(dDate, tDate) == 1 || CompareDate(dDate, tDate) == 2)
            {
                i = i + 1;
            }
            if (i == 2)
            {
                return true;
            }
            else
            {
                dDate = new DateTime(d3.Year, d3.Month, d3.Day, d1.Hour, d1.Minute, d1.Second);
                int k = 0;
                if (CompareDate(dDate, fDate) == 1 || CompareDate(dDate, fDate) == 3)
                {
                    k = k + 1;
                }
                if (CompareDate(dDate, tDate) == 1 || CompareDate(dDate, tDate) == 2)
                {
                    k = k + 1;
                }
                if (k == 2)
                {
                    return true;
                }
            }
            return false;
        }

        public static Boolean DateTimeBetweenFromToSameDay(object pDate, object pFromDate, object pToDate)
        {
            if (pDate == null || pFromDate == null || pToDate == null)
            {
                return false;
            }
            if (pDate == DBNull.Value || pFromDate == DBNull.Value || pToDate == DBNull.Value)
            {
                return false;
            }
            DateTime d1 = Convert.ToDateTime(pDate);
            DateTime d2 = Convert.ToDateTime(pFromDate);
            DateTime d3 = Convert.ToDateTime(pToDate);

            DateTime dDate = new DateTime(2000, 1, 1, d1.Hour, d1.Minute, d1.Second);
            DateTime fDate = new DateTime(2000, 1, 1, d2.Hour, d2.Minute, d2.Second);
            DateTime tDate = new DateTime(2000, 1, 1, d3.Hour, d3.Minute, d3.Second);

            int i = 0;
            if (CompareDate(dDate, fDate) == 1 || CompareDate(dDate, fDate) == 3)
            {
                i = i + 1;
            }
            if (CompareDate(dDate, tDate) == 1 || CompareDate(dDate, tDate) == 2)
            {
                i = i + 1;
            }
            if (i == 2)
            {
                return true;
            }
            return false;
        }

        public static Boolean CompareTwoCoupleDateTime(object pFDate1, object pTDate1, object pFDate2, object pTDate2)
        {
            if (pFDate1 == null || pFDate2 == null || pTDate1 == null || pTDate2 == null)
            {
                return false;
            }
            if (pFDate1 == DBNull.Value || pFDate2 == DBNull.Value || pTDate1 == DBNull.Value || pTDate2 == DBNull.Value)
            {
                return false;
            }
            if (DateBetweenFromToWithTime(pFDate1, pFDate2, pTDate2) == true && DateBetweenFromToWithTime(pTDate1, pFDate2, pTDate2) == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Convert datetime to string
        /// </summary>
        /// <param name="pDate">Datetime</param>
        /// <param name="pFormatType">1: 'dd/MM/yyyy'; 2: 'MM/dd/yyyy'; 3: 'yyyy/MM/dd'</param>
        /// <returns>string date</returns>
        public static string DateToString(object pDate, int pFormatType)
        {
            try
            {
                string Date = "";
                DateTime DateTemp = (DateTime)pDate;
                int month = DateTemp.Month;
                int year = DateTemp.Year;
                int day = DateTemp.Day;
                if (pFormatType == 1)
                {
                    if (day < 10)
                    {
                        Date += "0" + day.ToString();
                    }
                    else
                    {
                        Date += day.ToString();
                    }
                    if (month < 10)
                    {
                        Date += "/0" + month.ToString();
                    }
                    else
                    {
                        Date += "/" + month.ToString();
                    }
                    Date += "/" + year.ToString();
                }
                else if (pFormatType == 2)
                {
                    if (month < 10)
                    {
                        Date += "0" + month.ToString();
                    }
                    else
                    {
                        Date += month.ToString();
                    }
                    if (day < 10)
                    {
                        Date += "/0" + day.ToString();
                    }
                    else
                    {
                        Date += "/" + day.ToString();
                    }
                    Date += "/" + year.ToString();
                }
                else if (pFormatType == 3)
                {
                    Date += year.ToString();
                    if (month < 10)
                    {
                        Date += "/0" + month.ToString();
                    }
                    else
                    {
                        Date += "/" + month.ToString();
                    }
                    if (day < 10)
                    {
                        Date += "/0" + day.ToString();
                    }
                    else
                    {
                        Date += "/" + day.ToString();
                    }
                }

                return Date;
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// Phep nhan
        /// </summary>
        /// <param name="pA"></param>
        /// <param name="pB"></param>
        /// <returns>decimal</returns>
        public static decimal Multiplication(object pA, object pB)
        {
            try
            {
                if (pA == null)
                {
                    pA = 0;
                }
                else if (pA.ToString() == "")
                {
                    pA = 0;
                }
                if (pB == null)
                {
                    pB = 0;
                }
                else if (pB.ToString() == "")
                {
                    pB = 0;
                }
                return Math.Round(Convert.ToDecimal(pA) * Convert.ToDecimal(pB), 2);
            }
            catch
            {
                return 0;
            }
        }

        public static decimal Multiplication(object pA, object pB, int pDecimals)
        {
            try
            {
                if (pA == null)
                {
                    pA = 0;
                }
                else if (pA.ToString() == "")
                {
                    pA = 0;
                }
                if (pB == null)
                {
                    pB = 0;
                }
                else if (pB.ToString() == "")
                {
                    pB = 0;
                }
                return Math.Round(Convert.ToDecimal(pA) * Convert.ToDecimal(pB), pDecimals);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Phep chia
        /// </summary>
        /// <param name="pA"></param>
        /// <param name="pB"></param>
        /// <returns></returns>
        public static decimal Division(object pA, object pB)
        {
            try
            {
                if (pA == null)
                {
                    pA = 0;
                }
                else if (pA.ToString() == "")
                {
                    pA = 0;
                }
                if (pB == null)
                {
                    pB = 0;
                }
                else if (pB.ToString() == "")
                {
                    pB = 0;
                }
                return Math.Round(Convert.ToDecimal(pA) / Convert.ToDecimal(pB), 2);
            }
            catch
            {
                return 0;
            }
        }

        public static decimal Division(object pA, object pB, int pDecimals)
        {
            try
            {
                if (pA == null)
                {
                    pA = 0;
                }
                else if (pA.ToString() == "")
                {
                    pA = 0;
                }
                if (pB == null)
                {
                    pB = 0;
                }
                else if (pB.ToString() == "")
                {
                    pB = 0;
                }
                return Math.Round(Convert.ToDecimal(pA) / Convert.ToDecimal(pB), pDecimals);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Phep cong
        /// </summary>
        /// <param name="pA"></param>
        /// <param name="pB"></param>
        /// <returns></returns>
        public static decimal Plus(object pA, object pB)
        {
            try
            {
                if (pA == null)
                {
                    pA = 0;
                }
                else if (pA.ToString() == "")
                {
                    pA = 0;
                }
                if (pB == null)
                {
                    pB = 0;
                }
                else if (pB.ToString() == "")
                {
                    pB = 0;
                }
                return Convert.ToDecimal(pA) + Convert.ToDecimal(pB);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Phep tru
        /// </summary>
        /// <param name="pA"></param>
        /// <param name="pB"></param>
        /// <returns></returns>
        public static decimal Subtraction(object pA, object pB)
        {
            try
            {
                if (pA == null)
                {
                    pA = 0;
                }
                else if (pA.ToString() == "")
                {
                    pA = 0;
                }
                if (pB == null)
                {
                    pB = 0;
                }
                else if (pB.ToString() == "")
                {
                    pB = 0;
                }
                return Convert.ToDecimal(pA) - Convert.ToDecimal(pB);
            }
            catch
            {
                return 0;
            }
        }

        public static int SubtractionDateTime(object pDate1, object pDate2)
        {
            if (pDate1 == null || pDate2 == null)
            {
                return 0;
            }
            if (pDate1 == DBNull.Value || pDate2 == DBNull.Value)
            {
                return 0;
            }
            DateTime d1 = Convert.ToDateTime(pDate1);
            DateTime d2 = Convert.ToDateTime(pDate2);
            DateTime dd1 = new DateTime(2000, 1, 1, d1.Hour, d1.Minute, d1.Second, d1.Millisecond);
            DateTime dd2 = new DateTime(2000, 1, 1, d2.Hour, d2.Minute, d2.Second, d2.Millisecond);
            TimeSpan t = dd2 - dd1;
            int TotalMinutes = (int)Math.Round(t.TotalMinutes, 0);
            if (TotalMinutes < 0)
            {
                dd2 = new DateTime(2000, 1, 2, d2.Hour, d2.Minute, d2.Second, d2.Millisecond);
                t = dd2 - dd1;
            }
            return (int)Math.Round(t.TotalMinutes, 0);
        }

        public static int SubtractionDateTime(object pDate1, object pDate2, int pAddDays)
        {
            if (pDate1 == null || pDate2 == null)
            {
                return 0;
            }
            DateTime d1 = Convert.ToDateTime(pDate1);
            DateTime d2 = Convert.ToDateTime(pDate2);
            DateTime dd1 = new DateTime(2000, 1, 1, d1.Hour, d1.Minute, d1.Second, d1.Millisecond);
            DateTime dd2 = new DateTime(2000, 1, 1, d2.Hour, d2.Minute, d2.Second, d2.Millisecond);
            dd2 = dd2.AddDays(pAddDays);
            TimeSpan t = dd2 - dd1;
            int TotalMinutes = (int)Math.Round(t.TotalMinutes, 0);
            return (int)Math.Round(t.TotalMinutes, 0);
        }

        public static DateTime CreateDateWithMinutes(int pMinutes)
        {
            if (pMinutes < 0)
            {
                return new DateTime(2000, 1, 1, 0, 0, 0);
            }
            int hour = 0;
            while (pMinutes >= 60)
            {
                pMinutes = pMinutes - 60;
                hour += 1;
            }
            if (hour >= 24)
            {
                return new DateTime(2000, 1, 1, 23, 59, 59);
            }
            //else
            //{
            //    return new DateTime(2000, 1, 1, 23, 59, 59);
            //}

            return new DateTime(2000, 1, 1, hour, pMinutes, 0);
        }

        public static byte[] LoadImageFile(string pFileName)
        {
            byte[] imagebytes = null;
            FileStream fs = new FileStream(pFileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imagebytes = br.ReadBytes(10000);
            return imagebytes;
        }

        public static byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            if (imageIn == null)
            {
                return new byte[0];
            }
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static Boolean CompareSameDay(object pDate1, Object pDate2)
        {
            DateTime date1 = Convert.ToDateTime(pDate1);
            DateTime date2 = Convert.ToDateTime(pDate2);

            DateTime day1 = new DateTime(date1.Year, date1.Month, date1.Day, 0, 0, 0);
            DateTime day2 = new DateTime(date2.Year, date2.Month, date2.Day, 0, 0, 0);

            TimeSpan t = day1 - day2;
            if (t.TotalDays == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string CreateStringFromTo(DevExpress.XtraEditors.DateEdit pFDate, DevExpress.XtraEditors.DateEdit pTDate, string pLanguage)
        {
            string ret = "";
            if (pFDate.EditValue != null && pTDate.EditValue != null)
            {
                DateTime FDate, TDate;
                FDate = Convert.ToDateTime(pFDate.EditValue);
                TDate = Convert.ToDateTime(pTDate.EditValue);
                if (pLanguage.ToUpper() == "VIETNAMESE")
                {
                    ret = "Từ ";
                    if (FDate.Day < 10)
                    {
                        ret += "0" + FDate.Day.ToString();
                    }
                    else
                    {
                        ret += FDate.Day.ToString();
                    }
                    if (FDate.Month < 10)
                    {
                        ret += "/0" + FDate.Month.ToString();
                    }
                    else
                    {
                        ret += "/" + FDate.Month.ToString();
                    }
                    ret += "/" + FDate.Year.ToString();

                    if (TDate.Day < 10)
                    {
                        ret += " - đến 0" + TDate.Day.ToString();
                    }
                    else
                    {
                        ret += " - đến " + TDate.Day.ToString();
                    }
                    if (TDate.Month < 10)
                    {
                        ret += "/0" + TDate.Month.ToString();
                    }
                    else
                    {
                        ret += "/" + TDate.Month.ToString();
                    }
                    ret += "/" + TDate.Year.ToString();
                }
                else
                {
                    ret = "From ";
                    if (FDate.Day < 10)
                    {
                        ret += "0" + FDate.Day.ToString();
                    }
                    else
                    {
                        ret += FDate.Day.ToString();
                    }
                    if (FDate.Month < 10)
                    {
                        ret += "/0" + FDate.Month.ToString();
                    }
                    else
                    {
                        ret += "/" + FDate.Month.ToString();
                    }
                    ret += "/" + FDate.Year.ToString();

                    if (TDate.Day < 10)
                    {
                        ret += " - to 0" + TDate.Day.ToString();
                    }
                    else
                    {
                        ret += " - to " + TDate.Day.ToString();
                    }
                    if (TDate.Month < 10)
                    {
                        ret += "/0" + TDate.Month.ToString();
                    }
                    else
                    {
                        ret += "/" + TDate.Month.ToString();
                    }
                    ret += "/" + TDate.Year.ToString();
                }
            }
            return ret;
        }

        public static int WeekNumber(DateTime fromDate)
        {
            // Get jan 1st of the year
            DateTime startOfYear = fromDate.AddDays(-fromDate.Day + 1).AddMonths(-fromDate.Month + 1);
            // Get dec 31st of the year
            DateTime endOfYear = startOfYear.AddYears(1).AddDays(-1);
            // ISO 8601 weeks start with Monday
            // The first week of a year includes the first Thursday
            // DayOfWeek returns 0 for sunday up to 6 for saterday
            int[] iso8601Correction = { 6, 7, 8, 9, 10, 4, 5 };
            int nds = fromDate.Subtract(startOfYear).Days + iso8601Correction[(int)startOfYear.DayOfWeek];
            int wk = nds / 7;
            switch (wk)
            {
                case 0:
                    // Return weeknumber of dec 31st of the previous year
                    return WeekNumber(startOfYear.AddDays(-1));
                case 53:
                    // If dec 31st falls before thursday it is week 01 of next year
                    if (endOfYear.DayOfWeek < DayOfWeek.Thursday)
                        return 1;
                    else
                        return wk;
                default: return wk;
            }
        }

        private static string Convert3Digit(int pNumber, bool pIsVND)
        {
            string str4;
            string[] strArray = new string[10];
            string str = Strings.Format(pNumber, "00#");
            int length = str.Length;
            byte index = (byte)Math.Round(Conversion.Val(Strings.Mid(str, 1, 1)));
            byte num2 = (byte)Math.Round(Conversion.Val(Strings.Mid(str, 2, 1)));
            byte num3 = (byte)Math.Round(Conversion.Val(Strings.Mid(str, 3, 1)));
            if (!pIsVND)
            {
                str4 = "";
                strArray[0] = "ten ";
                strArray[1] = "one ";
                strArray[2] = "two ";
                strArray[3] = "three ";
                strArray[4] = "four ";
                strArray[5] = "five ";
                strArray[6] = "six ";
                strArray[7] = "seven ";
                strArray[8] = "eight ";
                strArray[9] = "nine ";
                switch (num2)
                {
                    case 1:
                        switch (num3)
                        {
                            case 0:
                                str4 = "ten ";
                                goto Label_0438;

                            case 1:
                                str4 = "eleven ";
                                goto Label_0438;

                            case 2:
                                str4 = "twelve ";
                                goto Label_0438;

                            case 3:
                                str4 = "thirteen ";
                                goto Label_0438;

                            case 4:
                                str4 = "fourteen ";
                                goto Label_0438;

                            case 5:
                                str4 = "fifteen ";
                                goto Label_0438;

                            case 6:
                                str4 = "sixteen ";
                                goto Label_0438;

                            case 7:
                                str4 = "seventeen ";
                                goto Label_0438;

                            case 8:
                                str4 = "eighteen ";
                                goto Label_0438;

                            case 9:
                                str4 = "nineteen ";
                                goto Label_0438;
                        }
                        goto Label_0438;

                    case 2:
                        str4 = Convert.ToString(Operators.ConcatenateObject("twenty", Interaction.IIf(num3 == 0, " ", "-" + strArray[num3])));
                        goto Label_0438;

                    case 3:
                        str4 = Convert.ToString(Operators.ConcatenateObject("thirty", Interaction.IIf(num3 == 0, " ", "-" + strArray[num3])));
                        goto Label_0438;

                    case 4:
                        str4 = Convert.ToString(Operators.ConcatenateObject("fourty", Interaction.IIf(num3 == 0, " ", "-" + strArray[num3])));
                        goto Label_0438;

                    case 5:
                        str4 = Convert.ToString(Operators.ConcatenateObject("fifty", Interaction.IIf(num3 == 0, " ", "-" + strArray[num3])));
                        goto Label_0438;

                    case 6:
                        str4 = Convert.ToString(Operators.ConcatenateObject("sixty", Interaction.IIf(num3 == 0, " ", "-" + strArray[num3])));
                        goto Label_0438;

                    case 7:
                        str4 = Convert.ToString(Operators.ConcatenateObject("seventy", Interaction.IIf(num3 == 0, " ", "-" + strArray[num3])));
                        goto Label_0438;

                    case 8:
                        str4 = Convert.ToString(Operators.ConcatenateObject("eighty", Interaction.IIf(num3 == 0, " ", "-" + strArray[num3])));
                        goto Label_0438;

                    case 9:
                        str4 = Convert.ToString(Operators.ConcatenateObject("ninety", Interaction.IIf(num3 == 0, " ", "-" + strArray[num3])));
                        goto Label_0438;
                }
                str4 = Convert.ToString(Interaction.IIf(num3 == 0, " ", strArray[num3]));
            }
            else
            {
                strArray[0] = "kh\x00f4ng ";
                strArray[1] = "một ";
                strArray[2] = "hai ";
                strArray[3] = "ba ";
                strArray[4] = "bốn ";
                strArray[5] = "năm ";
                strArray[6] = "s\x00e1u ";
                strArray[7] = "bảy ";
                strArray[8] = "t\x00e1m ";
                strArray[9] = "ch\x00edn ";
                string str3 = strArray[index] + "trăm ";
                switch (num2)
                {
                    case 0:
                        if (num3 != 0)
                        {
                            str3 = str3 + "linh " + strArray[num3];
                        }
                        return str3;

                    case 1:
                        str3 = str3 + "mười ";
                        break;

                    default:
                        str3 = str3 + strArray[num2] + "mươi ";
                        break;
                }
                if ((num3 == 1) & (num2 > 1))
                {
                    return (str3 + "mốt ");
                }
                switch (num3)
                {
                    case 5:
                        return (str3 + "lăm ");

                    case 0:
                        return str3;

                    default:
                        return (str3 + strArray[num3]);
                }
            }
        Label_0438:
            if (index != 0)
            {
                return (strArray[index] + "hundred " + str4);
            }
            return str4;
        }

        public static string MoneyToString(double pCurrency, bool pIsVND)
        {
            string str = "";
            int num7 = 0;
            try
            {
                int num6 = 2;
                string[] strArray = new string[6];
                int[] numArray = new int[6];
                double number = pCurrency;
                double num2 = pCurrency;
                strArray[1] = "";
                strArray[2] = Convert.ToString(Interaction.IIf(pIsVND, "ngh\x00ecn ", "thousand "));
                strArray[3] = Convert.ToString(Interaction.IIf(pIsVND, "triệu ", "million "));
                strArray[4] = Convert.ToString(Interaction.IIf(pIsVND, "tỷ ", "billion "));
                strArray[5] = Convert.ToString(Interaction.IIf(pIsVND, "ngh\x00ecn ", "thousand "));
                if (pCurrency == 0.0)
                {
                    str = Convert.ToString(Interaction.IIf(pIsVND, "kh\x00f4ng đồng ", " Zero dolla"));
                }
                else
                {
                    numArray[0] = (int)Math.Round((double)(Conversion.Fix((double)(number * 100.0)) - (Conversion.Fix(number) * 100.0)));
                    number = Conversion.Fix(number);
                    int index = 1;
                    while (number >= 1000.0)
                    {
                        num2 = Conversion.Fix((double)(number / 1000.0));
                        numArray[index] = (int)Math.Round((double)(number - (num2 * 1000.0)));
                        index++;
                        number = num2;
                    }
                    if (number < 1000.0)
                    {
                        numArray[index] = (int)Math.Round(number);
                    }
                    string left = "";
                    int num5 = index;
                    for (int i = 1; i <= num5; i++)
                    {
                        if (numArray[i] != 0)
                        {
                            left = Convert3Digit(numArray[i], pIsVND) + strArray[i] + left;
                        }
                    }
                    if (left.IndexOf("kh\x00f4ng trăm ") == 0)
                    {
                        left = left.Remove(0, "kh\x00f4ng ".Length + "trăm ".Length);
                    }
                    if (left.IndexOf("linh ") == 0)
                    {
                        left = left.Remove(0, "linh ".Length);
                    }
                    left = Convert.ToString(Operators.AddObject(left, Interaction.IIf(pIsVND, "đồng ", RuntimeHelpers.GetObjectValue(Interaction.IIf(pCurrency > 1.0, "dollars", "dollar")))));
                    if ((numArray[0] != 0) & !pIsVND)
                    {
                        string str2 = Convert.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(Interaction.IIf(pIsVND, " v\x00e0 ", " and "), Convert.ToString(numArray[0])), "/100 "), Interaction.IIf(pIsVND, "đồng ", "")));
                        left = left + str2;
                    }
                    str = left.Substring(0, 1).ToUpper() + left.Substring(1);
                }
                goto Label_02D0;
            Label_0278:
                str = "";
                goto Label_02D0;
            Label_028B:
                num7 = -1;
                switch (num6)
                {
                    case 0:
                    case 1:
                        goto Label_02C5;

                    case 2:
                        goto Label_0278;
                }
            }
            catch
            {
                //goto Label_028B;
            }
        Label_02C5:
        Label_02D0:
            if (num7 != 0)
            {
            }
            return str;
        }
    }

    public class Message
    {
        Form frmMain;
        string glbLanguage;
        DataTable glbDataTable;

        public enum MessageType : int
        {
            MSQuestion = 1,
            MSQuestionYNC = 2,
            MSInform = 3,
            MSError = 4,
            MSStop = 5
        }

        public Message(Form pFormMain, string pLanguage, DataTable pDataTable)
        {
            frmMain = pFormMain;
            glbLanguage = pLanguage;
            glbDataTable = pDataTable;
        }

        public Message(Form pFormMain)
        {
            frmMain = pFormMain;
        }

        public DialogResult MSQuestion(string MSCode)
        {
            if (MSCode.Trim().Length == 10)
            {
                return ShowMessage(MSCode, Convert.ToInt32(MessageType.MSQuestion), glbLanguage);
            }
            else
            {
                return MessageBox.Show(frmMain, MSCode, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }
        }

        public DialogResult MSQuestionYNC(string MSCode)
        {
            if (MSCode.Trim().Length == 10)
            {
                return ShowMessage(MSCode, Convert.ToInt32(MessageType.MSQuestionYNC), glbLanguage);
            }
            else
            {
                return MessageBox.Show(frmMain, MSCode, "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }
        }

        public void MSInform(string MSCode)
        {
            if (MSCode.Trim().Length == 10)
            {
                ShowMessage(MSCode, Convert.ToInt32(MessageType.MSInform), glbLanguage);
            }
            else
            {
                MessageBox.Show(frmMain, MSCode, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        public void MSError(string MSCode)
        {
            if (MSCode.Trim().Length == 10)
            {
                ShowMessage(MSCode, Convert.ToInt32(MessageType.MSError), glbLanguage);
            }
            else
            {
                MessageBox.Show(frmMain, MSCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public void MSStop(string MSCode)
        {
            if (MSCode.Trim().Length == 10)
            {
                ShowMessage(MSCode, Convert.ToInt32(MessageType.MSStop), glbLanguage);
            }
            else
            {
                MessageBox.Show(frmMain, MSCode, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
            }
        }

        public void MSFieldNotNull(string pFieldName)
        {
            if (glbLanguage.ToUpper() == "VIETNAMESE")
            {
                MessageBox.Show(frmMain, pFieldName + " không được rỗng.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show(frmMain, pFieldName + " is not null.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private DialogResult ShowMessage(string pMessageCode, int pMessageType, string pLanguage)
        {
            if (glbDataTable != null)
            {
                DataView dv = new DataView(glbDataTable);
                dv.Sort = "MessageCode";
                int index = dv.Find(pMessageCode);
                if (index < 0)
                {
                    index = dv.Find("AT_SY_0000");
                    if (index < 0)
                    {
                        return MessageBox.Show("Not found message code " + pMessageCode);
                    }
                    else
                    {
                        return ShowMessage("AT_SY_0000", Convert.ToInt32(MessageType.MSInform), pLanguage);
                    }
                }
                else
                {
                    string MS = "";
                    if (pLanguage.ToUpper() == "VIETNAMESE")
                    {
                        MS = dv[index]["MessageVN"] == DBNull.Value ? "" : dv[index]["MessageVN"].ToString();
                    }
                    else
                    {
                        MS = dv[index]["MessageEN"] == DBNull.Value ? "" : dv[index]["MessageEN"].ToString();
                    }

                    if (pMessageType == 1)
                    {
                        return MessageBox.Show(frmMain, MS, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                    else if (pMessageType == 2)
                    {
                        return MessageBox.Show(frmMain, MS, "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    }
                    else if (pMessageType == 3)
                    {
                        return MessageBox.Show(frmMain, MS, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else if (pMessageType == 4)
                    {
                        return MessageBox.Show(frmMain, MS, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else if (pMessageType == 5)
                    {
                        return MessageBox.Show(frmMain, MS, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        return MessageBox.Show(frmMain, MS, pMessageCode, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
            {
                return MessageBox.Show("Not found table SYS_Message");
            }
        }
    }

    public class Database
    {
        OleDbConnection glbConnection;
        OleDbCommand glbCommand;
        OleDbTransaction glbTransaction;

        public Database()
        {
        }

        public Database(OleDbConnection pCon)
        {
            glbConnection = pCon;
            glbCommand = new OleDbCommand();
        }

        public void OpenConnect()
        {
            try
            {
                if (glbConnection.State != ConnectionState.Open)
                {
                    glbConnection.Open();
                }
            }
            catch
            {

            }
        }

        public void CloseConnect()
        {
            try
            {
                if (glbConnection.State != ConnectionState.Closed)
                {
                    glbConnection.Close();
                }
            }
            catch
            {

            }
        }

        public void OpenConnect(OleDbConnection pCon)
        {
            try
            {
                if (pCon.State != ConnectionState.Open)
                {
                    pCon.Open();
                }
            }
            catch
            {

            }
        }

        public void CloseConnect(OleDbConnection pCon)
        {
            try
            {
                if (pCon.State != ConnectionState.Closed)
                {
                    pCon.Close();
                }
            }
            catch
            {

            }
        }

        public bool ExecuteNonQuery(string pSQL)
        {
            OpenConnect();
            OleDbCommand cmd = new OleDbCommand(pSQL, glbConnection);
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                CloseConnect();
                return true;
            }
            catch
            {
                CloseConnect();
                return false;
            }
        }

        public bool ExecuteNonQuery(string pSQL, OleDbConnection pConn, OleDbTransaction pTran)
        {
            OleDbCommand cmd = new OleDbCommand(pSQL, pConn, pTran);
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ExecuteNonQuery(string pSQL, OleDbConnection pConn, string[] pPara, object[] pValues)
        {
            OpenConnect(pConn);
            OleDbCommand cmd = new OleDbCommand(pSQL, pConn);
            cmd.CommandType = CommandType.Text;
            try
            {
                for (int i = 0; i < pPara.Length; i++)
                {
                    cmd.Parameters.AddWithValue(pPara[i], pValues[i]);
                }
                cmd.ExecuteNonQuery();
                CloseConnect(pConn);
                return true;
            }
            catch
            {
                CloseConnect(pConn);
                return false;
            }
        }

        public bool ExecuteNonQuery(string pSQL, OleDbConnection pConn, OleDbTransaction pTran, string[] pPara, object[] pValues)
        {
            OleDbCommand cmd = new OleDbCommand(pSQL, pConn, pTran);
            cmd.CommandType = CommandType.Text;
            try
            {
                for (int i = 0; i < pPara.Length; i++)
                {
                    cmd.Parameters.AddWithValue(pPara[i], pValues[i]);
                }
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public object ExecuteScalar(string pSQL)
        {
            OpenConnect();
            OleDbCommand cmd = new OleDbCommand(pSQL, glbConnection);
            cmd.CommandType = CommandType.Text;
            try
            {
                object value = cmd.ExecuteScalar();
                CloseConnect();
                return value;
            }
            catch
            {
                CloseConnect();
                return null;
            }
        }

        public object ExecuteScalar(string pSQL, string[] pPara, object[] pValues)
        {
            OpenConnect();
            OleDbCommand cmd = new OleDbCommand(pSQL, glbConnection);
            cmd.CommandType = CommandType.Text;
            for (int i = 0; i < pPara.Length; i++)
            {
                cmd.Parameters.AddWithValue(pPara[i], pValues[i]);
            }
            try
            {
                object value = cmd.ExecuteScalar();
                CloseConnect();
                return value;
            }
            catch
            {
                CloseConnect();
                return null;
            }
        }

        public object ExecuteScalar(string pSQL, System.Data.CommandType pCommandType, string[] pPara, object[] pValues, int pPositionOutput)
        {
            OpenConnect();
            OleDbCommand cmd = new OleDbCommand(pSQL, glbConnection);
            cmd.CommandType = pCommandType;
            for (int i = 0; i < pPara.Length; i++)
            {
                cmd.Parameters.AddWithValue(pPara[i], pValues[i] == null ? DBNull.Value : pValues[i]);
                if (i == pPositionOutput)
                {
                    cmd.Parameters[i].Direction = ParameterDirection.Output;
                }
            }
            try
            {
                cmd.ExecuteNonQuery();
                CloseConnect();
                return cmd.Parameters[pPositionOutput].Value;
            }
            catch
            {
                CloseConnect();
                return null;
            }
        }

        public object ExecuteScalar(string pSQL, System.Data.CommandType pCommandType, string[] pPara, object[] pValues, int pPositionOutput, OleDbConnection pConn, OleDbTransaction pTran)
        {
            OleDbCommand cmd = new OleDbCommand(pSQL, pConn, pTran);
            cmd.CommandType = pCommandType;
            for (int i = 0; i < pPara.Length; i++)
            {
                cmd.Parameters.AddWithValue(pPara[i], pValues[i] == null ? DBNull.Value : pValues[i]);
                if (i == pPositionOutput)
                {
                    cmd.Parameters[i].Direction = ParameterDirection.Output;
                }
            }
            try
            {
                cmd.ExecuteNonQuery();
                return cmd.Parameters[pPositionOutput].Value;
            }
            catch
            {
                return null;
            }
        }

        public void LoadDataTable(string pCommandText, ref DataTable pDataTable, OleDbConnection pSQLConnection)
        {
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter(pCommandText, pSQLConnection);
                da.Fill(pDataTable);
                da.Dispose();
            }
            catch
            {
            }
        }

        public void LoadDataTable(string pCommandText, ref DataTable pDataTable, OleDbConnection pSQLConnection, OleDbTransaction pTran)
        {
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter(pCommandText, pSQLConnection);
                da.SelectCommand.Transaction = pTran;
                da.Fill(pDataTable);
                da.Dispose();
            }
            catch
            {
            }
        }

        public void LoadDataTable(string pCommandText, ref DataTable pDataTable, OleDbConnection pSQLConnection, string[] pPara, object[] pValues)
        {
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter(pCommandText, pSQLConnection);
                for (int i = 0; i < pPara.Length; i++)
                {
                    da.SelectCommand.Parameters.AddWithValue(pPara[i], pValues[i]);
                }
                da.Fill(pDataTable);
                da.Dispose();
            }
            catch
            {
            }
        }

        public void LoadDataTable(string pCommandText, CommandType pCommandType, ref DataTable pDataTable, OleDbConnection pSQLConnection, string[] pPara, object[] pValues)
        {
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter(pCommandText, pSQLConnection);
                da.SelectCommand.CommandType = pCommandType;
                for (int i = 0; i < pPara.Length; i++)
                {
                    da.SelectCommand.Parameters.AddWithValue(pPara[i], pValues[i]);
                }
                if (pDataTable != null)
                {
                    pDataTable.Clear();
                }
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count == 1)
                {
                    pDataTable = ds.Tables[0].Copy();
                }
                da.Dispose();
            }
            catch
            {
            }
        }

        public void LoadDataTable(string pCommandText, CommandType pCommandType, ref DataSet pDataSet, OleDbConnection pSQLConnection, string[] pPara, object[] pValues)
        {
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter(pCommandText, pSQLConnection);
                da.SelectCommand.CommandType = pCommandType;
                for (int i = 0; i < pPara.Length; i++)
                {
                    da.SelectCommand.Parameters.AddWithValue(pPara[i], pValues[i]);
                }
                da.Fill(pDataSet);
                da.Dispose();
            }
            catch
            {
            }
        }

        public void LoadDataTableFromXLS(string pCommandText, ref DataTable pDataTable, string pPathFileXls)
        {
            string ExcelConnStr = @"provider=Microsoft.Jet.OLEDB.4.0; data source= " + pPathFileXls + "; Extended Properties=Excel 8.0;";
            OleDbConnection ExcelConn = new OleDbConnection(ExcelConnStr);
            LoadDataTable(pCommandText, ref pDataTable, ExcelConn);
        }

        public void LoadDataToDataset(string pCommandText, ref DataSet pDataSet, string pTableName)
        {
            try
            {
                string sTableName = "SYS_Caption;SYS_Language;SYS_Message;SYS_Form";
                string PathFileXls = System.Windows.Forms.Application.StartupPath + @"\Language.xls";
                if (sTableName.Contains(pTableName) && System.IO.File.Exists(PathFileXls))
                {
                    if (pDataSet.Tables.Contains(pTableName))
                    {
                        pDataSet.Tables.Remove(pTableName);
                    }
                    pCommandText = "Select * from [" + pTableName + "$]";
                    DataTable dtTemp = new DataTable(pTableName);
                    LoadDataTableFromXLS(pCommandText, ref dtTemp, PathFileXls);
                    pDataSet.Tables.Add(dtTemp);
                    return;
                }
                if (!pDataSet.Tables.Contains(pTableName))
                {
                    pDataSet.Tables.Add(pTableName);
                }
                pDataSet.Tables[pTableName].Clear();
                OleDbDataAdapter da = new OleDbDataAdapter(pCommandText, glbConnection);
                da.Fill(pDataSet.Tables[pTableName]);
                da.Dispose();
            }
            catch
            {
            }
        }

        public void LoadDataToDataset(string pCommandText, ref DataSet pDataSet, string pTableName, OleDbConnection pSQLConnection, OleDbTransaction pTran)
        {
            try
            {
                if (!pDataSet.Tables.Contains(pTableName))
                {
                    pDataSet.Tables.Add(pTableName);
                }
                pDataSet.Tables[pTableName].Clear();
                OleDbDataAdapter da = new OleDbDataAdapter(pCommandText, glbConnection);
                da.SelectCommand.Transaction = pTran;
                da.Fill(pDataSet.Tables[pTableName]);
                da.Dispose();
            }
            catch
            {
            }
        }

        public Boolean CheckPrimaryKey(string pTableName, string pListColumn, object[] pOldValues, object[] pNewValues, Boolean pIsAddNew)
        {
            Boolean flag = false;
            string sql = "";
            string[] ListColumn = pListColumn.Split(';');
            if (pIsAddNew)
            {
                try
                {
                    for (int i = 0; i < ListColumn.Length; i++)
                    {
                        sql += "[" + ListColumn[i] + "] = ? and ";
                    }
                    sql = sql.Substring(0, sql.Length - 4);
                    OpenConnect();
                    glbCommand.Connection = glbConnection;
                    sql = "Select Count(*) from " + pTableName + " where " + sql;
                    glbCommand.CommandType = CommandType.Text;
                    glbCommand.CommandText = sql;
                    glbCommand.Parameters.Clear();
                    for (int i = 0; i < pNewValues.Length; i++)
                    {
                        glbCommand.Parameters.AddWithValue("@Par0" + i.ToString(), pNewValues[i]);
                    }
                    if ((int)glbCommand.ExecuteScalar() > 0)
                        flag = true;
                }
                catch
                {
                    CloseConnect();
                }
                CloseConnect();
                return flag;
            }
            else
            {
                try
                {
                    for (int i = 0; i < ListColumn.Length; i++)
                    {
                        sql += "[" + ListColumn[i] + "] = ? and ";
                    }
                    for (int i = 0; i < ListColumn.Length; i++)
                    {
                        sql += "[" + ListColumn[i] + "] <> ? and ";
                    }
                    sql = sql.Substring(0, sql.Length - 4);
                    OpenConnect();
                    glbCommand.Connection = glbConnection;
                    sql = "Select Count(*) from " + pTableName + " where " + sql;
                    glbCommand.CommandType = CommandType.Text;
                    glbCommand.CommandText = sql;
                    glbCommand.Parameters.Clear();
                    for (int i = 0; i < pNewValues.Length; i++)
                    {
                        glbCommand.Parameters.AddWithValue("@Par0" + i.ToString(), pNewValues[i]);
                    }
                    for (int i = 0; i < pOldValues.Length; i++)
                    {
                        glbCommand.Parameters.AddWithValue("@Par00" + i.ToString(), pOldValues[i]);
                    }
                    if ((int)glbCommand.ExecuteScalar() > 0)
                        flag = true;
                }
                catch
                {
                    CloseConnect();
                }
                CloseConnect();
                return flag;
            }
        }

        public Boolean CheckKey(string pTable, string pColumn, object pValueKey)
        {
            Boolean flag = false;
            try
            {
                OpenConnect();
                glbCommand.Connection = glbConnection;
                string sql = "Select Count(*) from " + pTable + " where " + pColumn + " = ?";
                glbCommand.CommandType = CommandType.Text;
                glbCommand.CommandText = sql;
                glbCommand.Parameters.Clear();
                glbCommand.Parameters.AddWithValue("@Par01", pValueKey);
                if ((int)glbCommand.ExecuteScalar() > 0)
                    flag = true;
            }
            catch
            {
                CloseConnect();
            }
            CloseConnect();
            return flag;
        }

        public Boolean CheckKey(string pTable, string[] pColumns, object[] pValues, OleDbConnection pConn, OleDbTransaction pTran)
        {
            OleDbCommand cmd = new OleDbCommand("", pConn, pTran);
            string Where = "";
            for (int i = 0; i < pColumns.Length; i++)
            {
                Where += pColumns[i] + " = ? and ";
            }
            Where = Where.Substring(0, Where.Length - 4);
            string sql = "Select Count(*) from " + pTable + " where " + Where;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            for (int i = 0; i < pColumns.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + pColumns[i], pValues[i]);
            }
            object tmp = cmd.ExecuteScalar();
            if (tmp == null)
            {
                return false;
            }
            if (!Utils.isDouble(tmp))
            {
                return false;
            }
            if ((int)cmd.ExecuteScalar() > 0)
                return true;
            else
                return false;
        }

        public Boolean CheckKeyOnGlb(string pTable, string pSort, object[] pValues, DataSet pDataset)
        {
            DataView dv = new DataView(pDataset.Tables[pTable]);
            dv.Sort = pSort;
            int index = dv.Find(pValues);
            if (index >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean InsertTable(string pTable, DataRow pRow)
        {
            Boolean flag = false;
            string mColumn = "";
            string Parameter = "";
            string sql;
            int i, count;
            if (pRow != null)
            {
                count = pRow.Table.Columns.Count;
                for (i = 0; i < count - 1; i++)
                {
                    mColumn = mColumn + "[" + pRow.Table.Columns[i].ColumnName + "],";
                    Parameter = Parameter + "?,";
                }
                mColumn = mColumn + "[" + pRow.Table.Columns[i].ColumnName + "]";
                Parameter = Parameter + "?";

                sql = "Insert into " + pTable + " (" + mColumn + ") values (" + Parameter + ")";
                try
                {
                    OpenConnect();
                    glbTransaction = glbConnection.BeginTransaction();
                    glbCommand.Transaction = glbTransaction;
                    glbCommand.Connection = glbConnection;
                    glbCommand.CommandType = CommandType.Text;
                    glbCommand.CommandText = sql;
                    glbCommand.Parameters.Clear();
                    for (i = 0; i < count; i++)
                    {
                        glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), pRow[i]);
                    }
                    glbCommand.ExecuteNonQuery();
                    glbTransaction.Commit();
                    CloseConnect();
                    flag = true;
                }
                catch
                {
                    glbTransaction.Rollback();
                    CloseConnect();
                }
            }
            return flag;
        }

        public Boolean InsertTable(string pTable, DataRow pRow, string pIdentityColumn)
        {
            Boolean flag = false;
            string mColumn = "";
            string Parameter = "";
            string sql;
            int i, count;
            if (pRow != null)
            {
                count = pRow.Table.Columns.Count;
                for (i = 0; i < count - 1; i++)
                {
                    if (pIdentityColumn.ToUpper() != pRow.Table.Columns[i].ColumnName.ToUpper())
                    {
                        mColumn = mColumn + "[" + pRow.Table.Columns[i].ColumnName + "],";
                        Parameter = Parameter + "?,";
                    }
                }
                mColumn = mColumn + "[" + pRow.Table.Columns[i].ColumnName + "]";
                Parameter = Parameter + "?";

                sql = "Insert into " + pTable + " (" + mColumn + ") values (" + Parameter + ")";
                try
                {
                    OpenConnect();
                    glbTransaction = glbConnection.BeginTransaction();
                    glbCommand.Transaction = glbTransaction;
                    glbCommand.Connection = glbConnection;
                    glbCommand.CommandType = CommandType.Text;
                    glbCommand.CommandText = sql;
                    glbCommand.Parameters.Clear();
                    for (i = 0; i < count; i++)
                    {
                        if (pIdentityColumn.ToUpper() != pRow.Table.Columns[i].ColumnName.ToUpper())
                        {
                            glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), pRow[i]);
                        }
                    }
                    glbCommand.ExecuteNonQuery();
                    glbTransaction.Commit();
                    CloseConnect();
                    flag = true;
                }
                catch
                {
                    glbTransaction.Rollback();
                    CloseConnect();
                }
            }
            return flag;
        }

        public Boolean InsertTable(string pTable, DataRow pRow, string pIdentityColumn, OleDbConnection pConn, OleDbTransaction pTran)
        {
            Boolean flag = false;
            string mColumn = "";
            string Parameter = "";
            string sql;
            int i, count;
            if (pRow != null)
            {
                count = pRow.Table.Columns.Count;
                for (i = 0; i < count - 1; i++)
                {
                    if (pIdentityColumn.ToUpper() != pRow.Table.Columns[i].ColumnName.ToUpper())
                    {
                        mColumn = mColumn + "[" + pRow.Table.Columns[i].ColumnName + "],";
                        Parameter = Parameter + "?,";
                    }
                }
                mColumn = mColumn + "[" + pRow.Table.Columns[i].ColumnName + "]";
                Parameter = Parameter + "?";

                sql = "Insert into " + pTable + " (" + mColumn + ") values (" + Parameter + ")";
                try
                {
                    glbCommand.Transaction = pTran;
                    glbCommand.Connection = pConn;
                    glbCommand.CommandType = CommandType.Text;
                    glbCommand.CommandText = sql;
                    glbCommand.Parameters.Clear();
                    for (i = 0; i < count; i++)
                    {
                        if (pIdentityColumn.ToUpper() != pRow.Table.Columns[i].ColumnName.ToUpper())
                        {
                            if (pRow.Table.Columns[i].ColumnName.ToUpper() == "PHOTO")
                            {
                                if (pRow[i] == DBNull.Value)
                                {
                                    //glbCommand.Parameters.Add("@Par" + i.ToString(), OleDbType.Binary);
                                    //glbCommand.Parameters["@Par" + i.ToString()].Value = new byte[0];
                                    glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), new byte[0]);
                                }
                                else
                                {
                                    glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), pRow[i]);
                                    //glbCommand.Parameters.Add("@Par" + i.ToString(), OleDbType.Binary);
                                    //glbCommand.Parameters["@Par" + i.ToString()].Value = pRow[i];
                                }
                            }
                            else
                            {
                                glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), pRow[i]);
                            }
                        }
                    }
                    glbCommand.ExecuteNonQuery();
                    flag = true;
                }
                catch (OleDbException ex)
                {
                    ex.ToString();
                }
            }
            return flag;
        }

        public Boolean InsertTable(string pTable, DataRowView pRow, string pIdentityColumn, OleDbConnection pConn, OleDbTransaction pTran)
        {
            Boolean flag = false;
            string mColumn = "";
            string Parameter = "";
            string sql;
            int i, count;
            if (pRow != null)
            {
                count = pRow.DataView.Table.Columns.Count;
                for (i = 0; i < count - 1; i++)
                {
                    if (pIdentityColumn.ToUpper() != pRow.DataView.Table.Columns[i].ColumnName.ToUpper())
                    {
                        mColumn = mColumn + "[" + pRow.DataView.Table.Columns[i].ColumnName + "],";
                        Parameter = Parameter + "?,";
                    }
                }
                mColumn = mColumn + "[" + pRow.DataView.Table.Columns[i].ColumnName + "]";
                Parameter = Parameter + "?";

                sql = "Insert into " + pTable + " (" + mColumn + ") values (" + Parameter + ")";
                try
                {
                    glbCommand.Transaction = pTran;
                    glbCommand.Connection = pConn;
                    glbCommand.CommandType = CommandType.Text;
                    glbCommand.CommandText = sql;
                    glbCommand.Parameters.Clear();
                    for (i = 0; i < count; i++)
                    {
                        if (pIdentityColumn.ToUpper() != pRow.DataView.Table.Columns[i].ColumnName.ToUpper())
                        {
                            if (pRow.DataView.Table.Columns[i].ColumnName.ToUpper() == "PHOTO")
                            {
                                if (pRow[i] == DBNull.Value)
                                {
                                    //glbCommand.Parameters.Add("@Par" + i.ToString(), OleDbType.Binary);
                                    //glbCommand.Parameters["@Par" + i.ToString()].Value = new byte[0];
                                    glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), new byte[0]);
                                }
                                else
                                {
                                    glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), pRow[i]);
                                    //glbCommand.Parameters.Add("@Par" + i.ToString(), OleDbType.Binary);
                                    //glbCommand.Parameters["@Par" + i.ToString()].Value = pRow[i];
                                }
                            }
                            else
                            {
                                glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), pRow[i]);
                            }
                        }
                    }
                    glbCommand.ExecuteNonQuery();
                    flag = true;
                }
                catch (OleDbException ex)
                {
                    ex.ToString();
                }
            }
            return flag;
        }

        public Boolean UpdateTable(string pTable, DataRow pRow, string pColumn, object pValueKey)
        {
            Boolean flag = false;
            string Parameter = "";
            string sql;
            int i, count;
            if (pRow != null)
            {
                count = pRow.Table.Columns.Count;
                for (i = 0; i < count - 1; i++)
                {
                    Parameter = Parameter + "[" + pRow.Table.Columns[i].ColumnName + "] = ?,";
                }
                Parameter = Parameter + "[" + pRow.Table.Columns[i].ColumnName + "] = ?";

                sql = "Update " + pTable + " Set " + Parameter + " Where [" + pColumn + "] = ?";
                try
                {
                    OpenConnect();
                    glbTransaction = glbConnection.BeginTransaction();
                    glbCommand.Transaction = glbTransaction;
                    glbCommand.Connection = glbConnection;
                    glbCommand.CommandType = CommandType.Text;
                    glbCommand.CommandText = sql;
                    glbCommand.Parameters.Clear();
                    for (i = 0; i < count; i++)
                    {
                        glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), pRow[i]);
                    }
                    glbCommand.Parameters.AddWithValue("@ValueKey", pValueKey);
                    glbCommand.ExecuteNonQuery();
                    glbTransaction.Commit();
                    CloseConnect();
                    flag = true;
                }
                catch
                {
                    glbTransaction.Rollback();
                    CloseConnect();
                }
            }
            return flag;
        }

        public Boolean UpdateTable(string pTable, DataRow pRow, string pColumn, object pValueKey, bool pIsUpdateKey)
        {
            Boolean flag = false;
            string Parameter = "";
            string sql;
            int i, count;
            if (pRow != null)
            {
                count = pRow.Table.Columns.Count;
                for (i = 0; i < count - 1; i++)
                {
                    if (pIsUpdateKey == true)
                    {
                        Parameter = Parameter + "[" + pRow.Table.Columns[i].ColumnName + "] = ?,";
                    }
                    else
                    {
                        if (pColumn.ToUpper() != pRow.Table.Columns[i].ColumnName.ToUpper())
                        {
                            Parameter = Parameter + "[" + pRow.Table.Columns[i].ColumnName + "] = ?,";
                        }
                    }
                }
                Parameter = Parameter + pRow.Table.Columns[i].ColumnName + " = ?";

                sql = "Update " + pTable + " Set " + Parameter + " Where [" + pColumn + "] = ?";
                try
                {
                    OpenConnect();
                    glbTransaction = glbConnection.BeginTransaction();
                    glbCommand.Transaction = glbTransaction;
                    glbCommand.Connection = glbConnection;
                    glbCommand.CommandType = CommandType.Text;
                    glbCommand.CommandText = sql;
                    glbCommand.Parameters.Clear();
                    for (i = 0; i < count; i++)
                    {
                        if (pIsUpdateKey == true)
                        {
                            glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), pRow[i]);
                        }
                        else
                        {
                            if (pColumn.ToUpper() != pRow.Table.Columns[i].ColumnName.ToUpper())
                            {
                                glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), pRow[i]);
                            }
                        }
                    }
                    glbCommand.Parameters.AddWithValue("@ValueKey", pValueKey);
                    glbCommand.ExecuteNonQuery();
                    glbTransaction.Commit();
                    CloseConnect();
                    flag = true;
                }
                catch
                {
                    glbTransaction.Rollback();
                    CloseConnect();
                }
            }
            return flag;
        }

        public Boolean UpdateTable(string pTable, DataRow pRow, string pColumn, object pValueKey, bool pIsUpdateKey, OleDbConnection pConn, OleDbTransaction pTran)
        {
            Boolean flag = false;
            string Parameter = "";
            string sql;
            int i, count;
            if (pRow != null)
            {
                count = pRow.Table.Columns.Count;
                for (i = 0; i < count - 1; i++)
                {
                    if (pIsUpdateKey == true)
                    {
                        Parameter = Parameter + "[" + pRow.Table.Columns[i].ColumnName + "] = ?,";
                    }
                    else
                    {
                        if (pColumn.ToUpper() != pRow.Table.Columns[i].ColumnName.ToUpper())
                        {
                            Parameter = Parameter + "[" + pRow.Table.Columns[i].ColumnName + "] = ?,";
                        }
                    }
                }
                Parameter = Parameter + pRow.Table.Columns[i].ColumnName + " = ?";

                sql = "Update " + pTable + " Set " + Parameter + " Where [" + pColumn + "] = ?";
                try
                {
                    glbCommand.Transaction = pTran;
                    glbCommand.Connection = pConn;
                    glbCommand.CommandType = CommandType.Text;
                    glbCommand.CommandText = sql;
                    glbCommand.Parameters.Clear();
                    for (i = 0; i < count; i++)
                    {
                        if (pIsUpdateKey == true)
                        {
                            glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), pRow[i]);
                        }
                        else
                        {
                            if (pColumn.ToUpper() != pRow.Table.Columns[i].ColumnName.ToUpper())
                            {
                                if (pRow.Table.Columns[i].ColumnName.ToUpper() == "PHOTO")
                                {
                                    if (pRow[i] == DBNull.Value)
                                    {
                                        glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), new byte[0]);
                                    }
                                    else
                                    {
                                        glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), pRow[i]);
                                    }
                                }
                                else
                                {
                                    glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), pRow[i]);
                                }
                            }
                        }
                    }
                    glbCommand.Parameters.AddWithValue("@ValueKey", pValueKey);
                    glbCommand.ExecuteNonQuery();
                    flag = true;
                }
                catch (OleDbException ex)
                {
                }
            }
            return flag;
        }

        public Boolean UpdateTable(string pTable, DataRow pRow, string pColumn, object[] pValueKey, bool pIsUpdateKey, OleDbConnection pConn, OleDbTransaction pTran)
        {
            Boolean flag = false;
            string Parameter = "";
            string sql;
            int i, count;
            if (pRow != null)
            {
                count = pRow.Table.Columns.Count;
                for (i = 0; i < count - 1; i++)
                {
                    if (pIsUpdateKey == true)
                    {
                        Parameter = Parameter + "[" + pRow.Table.Columns[i].ColumnName + "] = ?,";
                    }
                    else
                    {
                        if (pColumn.ToUpper() != pRow.Table.Columns[i].ColumnName.ToUpper())
                        {
                            Parameter = Parameter + "[" + pRow.Table.Columns[i].ColumnName + "] = ?,";
                        }
                    }
                }
                Parameter = Parameter + pRow.Table.Columns[i].ColumnName + " = ?";

                string[] sColumsWhere = pColumn.Split(';');
                string sWhere = "";
                for (i = 0; i < sColumsWhere.Length - 1; i++)
                {
                    sWhere = sWhere + "[" + sColumsWhere[i] + "] = ? and ";
                }
                sWhere = sWhere + "[" + sColumsWhere[i] + "] = ?";
                sql = "Update " + pTable + " Set " + Parameter + " Where " + sWhere;
                try
                {
                    glbCommand.Transaction = pTran;
                    glbCommand.Connection = pConn;
                    glbCommand.CommandType = CommandType.Text;
                    glbCommand.CommandText = sql;
                    glbCommand.Parameters.Clear();
                    for (i = 0; i < count; i++)
                    {
                        if (pIsUpdateKey == true)
                        {
                            glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), pRow[i]);
                        }
                        else
                        {
                            if (pColumn.ToUpper() != pRow.Table.Columns[i].ColumnName.ToUpper())
                            {
                                if (pRow.Table.Columns[i].ColumnName.ToUpper() == "PHOTO")
                                {
                                    if (pRow[i] == DBNull.Value)
                                    {
                                        glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), new byte[0]);
                                    }
                                    else
                                    {
                                        glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), pRow[i]);
                                    }
                                }
                                else
                                {
                                    glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), pRow[i]);
                                }
                            }
                        }
                    }
                    for (i = 0; i < pValueKey.Length; i++)
                    {
                        glbCommand.Parameters.AddWithValue("@ValueKey0" + i.ToString(), pValueKey[i]);
                    }
                    glbCommand.ExecuteNonQuery();
                    flag = true;
                }
                catch (OleDbException ex)
                {
                }
            }
            return flag;
        }

        public Boolean UpdateTable(String pSql, OleDbConnection pConn, OleDbTransaction pTran)
        {
            Boolean flag = false;
            try
            {
                glbCommand.Transaction = pTran;
                glbCommand.Connection = pConn;
                glbCommand.CommandType = CommandType.Text;
                glbCommand.CommandText = pSql;
                glbCommand.ExecuteNonQuery();
                flag = true;
            }
            catch
            {
            }
            return flag;
        }

        public Boolean UpdateTable(string pTable, DataRow pRow, string pListColumn, object[] pValueKey)
        {
            Boolean flag = false;
            string Parameter = "";
            string sql;
            int i, count;
            string[] ListColumn = pListColumn.Split(';');
            if (pRow != null)
            {
                count = pRow.Table.Columns.Count;
                for (i = 0; i < count - 1; i++)
                {
                    Parameter = Parameter + "[" + pRow.Table.Columns[i].ColumnName + "] = ?,";
                }
                Parameter = Parameter + pRow.Table.Columns[i].ColumnName + " = ?";
                string sWhere = "";
                for (i = 0; i < ListColumn.Length; i++)
                {
                    sWhere += "[" + ListColumn[i] + "] = ? and ";
                }
                sWhere = sWhere.Substring(0, sWhere.Length - 4);
                sql = "Update " + pTable + " Set " + Parameter + " Where " + sWhere;
                try
                {
                    OpenConnect();
                    glbTransaction = glbConnection.BeginTransaction();
                    glbCommand.Transaction = glbTransaction;
                    glbCommand.Connection = glbConnection;
                    glbCommand.CommandType = CommandType.Text;
                    glbCommand.CommandText = sql;
                    glbCommand.Parameters.Clear();
                    for (i = 0; i < count; i++)
                    {
                        glbCommand.Parameters.AddWithValue("@Par" + i.ToString(), pRow[i]);
                    }
                    for (i = 0; i < pValueKey.Length; i++)
                    {
                        glbCommand.Parameters.AddWithValue("@ValueKey0" + i.ToString(), pValueKey[i]);
                    }
                    glbCommand.ExecuteNonQuery();
                    glbTransaction.Commit();
                    CloseConnect();
                    flag = true;
                }
                catch
                {
                    glbTransaction.Rollback();
                    CloseConnect();
                }
            }
            return flag;
        }

        public Boolean DeleteTable(string pTable, string pColumn, object pValueKey, ref string ErrorCode)
        {
            Boolean flag = false;
            string sql;
            try
            {
                sql = "Delete From [" + pTable + "] where [" + pColumn + "] = ?";
                OpenConnect();
                glbTransaction = glbConnection.BeginTransaction();
                glbCommand.Transaction = glbTransaction;
                glbCommand.Connection = glbConnection;
                glbCommand.CommandType = CommandType.Text;
                glbCommand.CommandText = sql;
                glbCommand.Parameters.Clear();
                glbCommand.Parameters.AddWithValue("@Par01", pValueKey);
                glbCommand.ExecuteNonQuery();
                glbTransaction.Commit();
                CloseConnect();
                flag = true;
            }
            catch (OleDbException ex)
            {
                ErrorCode = ex.ErrorCode.ToString();
                glbTransaction.Rollback();
                CloseConnect();
            }
            return flag;
        }

        public Boolean DeleteTable(string pTable, string pColumn, object pValueKey, OleDbConnection pConn, OleDbTransaction pTran, ref string ErrorCode)
        {
            Boolean flag = false;
            string sql;
            try
            {
                sql = "Delete From [" + pTable + "] where [" + pColumn + "] = ?";
                glbCommand.Transaction = pTran;
                glbCommand.Connection = pConn;
                glbCommand.CommandType = CommandType.Text;
                glbCommand.CommandText = sql;
                glbCommand.Parameters.Clear();
                glbCommand.Parameters.AddWithValue("@Par01", pValueKey);
                glbCommand.ExecuteNonQuery();
                flag = true;
            }
            catch (OleDbException ex)
            {
                ErrorCode = ex.ErrorCode.ToString();
            }
            return flag;
        }

        public Boolean DeleteTable(string pTable, string pColumn, object FromDate, object ToDate, OleDbConnection pConn, OleDbTransaction pTran, ref string ErrorCode)
        {
            Boolean flag = false;
            string sql;
            try
            {
                sql = "Delete From [" + pTable + "] where [" + pColumn + "] between ? and ? ";
                glbCommand.Transaction = pTran;
                glbCommand.Connection = pConn;
                glbCommand.CommandType = CommandType.Text;
                glbCommand.CommandText = sql;
                glbCommand.Parameters.Clear();
                glbCommand.Parameters.AddWithValue("@Par01", FromDate);
                glbCommand.Parameters.AddWithValue("@Par02", ToDate);
                glbCommand.ExecuteNonQuery();
                flag = true;
            }
            catch (OleDbException ex)
            {
                ErrorCode = ex.ErrorCode.ToString();
            }
            return flag;
        }

        public Boolean DeleteTable(string pTable, string pListColumn, object[] pValues, ref string ErrorCode)
        {
            Boolean flag = false;
            string sql = "";
            try
            {
                string[] ListColumn = pListColumn.Split(';');
                for (int i = 0; i < pValues.Length; i++)
                {
                    sql += "[" + ListColumn[i] + "] = ? and ";
                }
                sql = sql.Substring(0, sql.Length - 4);

                sql = "Delete From [" + pTable + "] where " + sql;
                OpenConnect();
                glbTransaction = glbConnection.BeginTransaction();
                glbCommand.Transaction = glbTransaction;
                glbCommand.Connection = glbConnection;
                glbCommand.CommandType = CommandType.Text;
                glbCommand.CommandText = sql;
                glbCommand.Parameters.Clear();
                for (int i = 0; i < pValues.Length; i++)
                {
                    glbCommand.Parameters.AddWithValue("@Par0" + i.ToString(), pValues[i]);
                }
                glbCommand.ExecuteNonQuery();
                glbTransaction.Commit();
                CloseConnect();
                flag = true;
            }
            catch (OleDbException ex)
            {
                ErrorCode = ex.ErrorCode.ToString();
                glbTransaction.Rollback();
                CloseConnect();
            }
            return flag;
        }

        public Boolean DeleteTable(string pTable, string pListColumn, object[] pValues, OleDbConnection pConn, OleDbTransaction pTran, ref string ErrorCode)
        {
            Boolean flag = false;
            string sql = "";
            try
            {
                string[] ListColumn = pListColumn.Split(';');
                for (int i = 0; i < pValues.Length; i++)
                {
                    sql += "[" + ListColumn[i] + "] = ? and ";
                }
                sql = sql.Substring(0, sql.Length - 4);

                sql = "Delete From [" + pTable + "] where " + sql;
                glbCommand.Transaction = pTran;
                glbCommand.Connection = pConn;
                glbCommand.CommandType = CommandType.Text;
                glbCommand.CommandText = sql;
                glbCommand.Parameters.Clear();
                for (int i = 0; i < pValues.Length; i++)
                {
                    glbCommand.Parameters.AddWithValue("@Par0" + i.ToString(), pValues[i]);
                }
                glbCommand.ExecuteNonQuery();
                flag = true;
            }
            catch (OleDbException ex)
            {
                ErrorCode = ex.ErrorCode.ToString();
            }
            return flag;
        }

        public object GetIdentity(string pTableName)
        {
            object mReturn = new object();
            try
            {
                if (glbConnection.State != ConnectionState.Open)
                    glbConnection.Open();
                glbCommand.Connection = glbConnection;
                string sql = "Select IDENT_CURRENT('" + pTableName + "')";
                glbCommand.CommandType = CommandType.Text;
                glbCommand.CommandText = sql;
                glbCommand.Parameters.Clear();
                mReturn = glbCommand.ExecuteScalar();
            }
            catch
            {
                glbConnection.Close();
            }
            glbConnection.Close();
            return mReturn;
        }

        public object GetIdentity(string pTableName, OleDbConnection pCon, OleDbTransaction pTran)
        {
            object mReturn = new object();
            try
            {
                OleDbCommand cmd = new OleDbCommand("", pCon, pTran);
                string sql = "";
                sql = "Select IDENT_CURRENT('" + pTableName + "')";
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                mReturn = cmd.ExecuteScalar();
            }
            catch
            {
            }
            return mReturn;
        }

        public object GetIdentity(string pTableName, OleDbConnection pCon, OleDbTransaction pTran, int pConnectType)
        {
            object mReturn = new object();
            try
            {
                OleDbCommand cmd = new OleDbCommand("", pCon, pTran);
                string sql = "";
                if (pConnectType == 1)//SQL
                {
                    sql = "Select IDENT_CURRENT('" + pTableName + "')";
                }
                else//Access
                {
                    sql = "SELECT @@Identity";
                }
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                mReturn = cmd.ExecuteScalar();
            }
            catch
            {
            }
            return mReturn;
        }

        #region Load Data

        public void LoadMaxLengthColumn(ref DataSet pDataset)
        {
            string SQL = "";
            SQL = "select A.[Name] as TableName,B.[Name] ColumnName,C.Name as Type,B.prec as Length ";
            SQL += " from sysobjects A";
            SQL += " inner join syscolumns B";
            SQL += " on A.[id]=B.[id]";
            SQL += " inner join systypes C";
            SQL += " on  B.xtype=C.xtype";
            SQL += " where A.xtype='u' and C.Name <> 'sysname'";
            LoadDataToDataset(SQL, ref pDataset, "MaxLengthColumn");
        }

        public void LoadDataToGlbDataset(String pListTable, ref DataSet pDataset)
        {
            String[] MyListTable = pListTable.Split(';');
            for (int i = 0; i < MyListTable.Length; i++)
            {
                LoadDataToDataset("Select * from " + MyListTable[i], ref pDataset, MyListTable[i]);
            }
        }

        #endregion

        #region Load Data To Combo
        public void LoadDataToCbo(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit pCbo, string pTableName, string pRowFilter, string pDisplayMember, string pValueMember, string[] pColumns, DataTable pDataTable)
        {
            if (pDataTable != null)
            {
                DataView dv = new DataView(pDataTable);
                dv.RowFilter = pRowFilter;
                pCbo.DataSource = dv;
                pCbo.Columns.Clear();
                pCbo.PopupWidth = 200;
                for (int i = 0; i < pColumns.Length; i++)
                {
                    pCbo.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(pColumns[i]));
                }
                pCbo.DisplayMember = pDisplayMember;
                pCbo.ValueMember = pValueMember;
                pCbo.ShowHeader = false;
                pCbo.NullText = "";
            }
        }

        public void LoadDataToCbo(DevExpress.XtraEditors.LookUpEdit pCbo, string pTableName, string pRowFilter, string pDisplayMember, string pValueMember, string[] pColumns, DataTable pDataTable)
        {
            if (pDataTable != null)
            {
                DataView dv = new DataView(pDataTable);
                dv.RowFilter = pRowFilter;

                pCbo.Properties.DataSource = dv;
                pCbo.Properties.Columns.Clear();
                pCbo.Properties.PopupWidth = Convert.ToInt32(pCbo.Width * 1.5);
                for (int i = 0; i < pColumns.Length; i++)
                {
                    pCbo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(pColumns[i]));
                }
                pCbo.Properties.DisplayMember = pDisplayMember;
                pCbo.Properties.ValueMember = pValueMember;
                pCbo.Properties.ShowHeader = false;
                pCbo.Properties.NullText = "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCbo"></param>
        /// <param name="pRowFilter"></param>
        /// <param name="pDisplayMember"></param>
        /// <param name="pValueMember"></param>
        /// <param name="pColumns"></param>
        /// <param name="pDataTable"></param>
        /// <param name="pColumnAdd">0: NONE | -1: ALL | -2:ADDNEW </param>
        public void LoadDataToCbo(DevExpress.XtraEditors.LookUpEdit pCbo, string pTableName, string pRowFilter, string pDisplayMember, string pValueMember, string[] pColumns, DataTable pDataTable, int pColumnAdd)
        {
            if (pDataTable != null)
            {
                DataTable dt = new DataTable(pTableName);
                dt = pDataTable.Copy();
                DataRow row = dt.NewRow();
                if (pColumnAdd == 0)
                {
                    row[pDisplayMember] = "<<NONE>>";
                    row[pValueMember] = DBNull.Value;
                    dt.Rows.InsertAt(row, 0);
                }
                else if (pColumnAdd == -1)
                {
                    row[pDisplayMember] = "<<ALL>>";
                    if (pDataTable.Columns[pValueMember].DataType.Name == "String")
                    {
                        row[pValueMember] = "ALL";
                    }
                    else
                    {
                        row[pValueMember] = pColumnAdd;
                    }
                    dt.Rows.InsertAt(row, 0);
                }
                else if (pColumnAdd == -2)
                {
                    row[pDisplayMember] = "<<ADD NEW>>";
                    if (pDataTable.Columns[pValueMember].DataType.Name == "String")
                    {
                        row[pValueMember] = "";
                    }
                    else
                    {
                        row[pValueMember] = pColumnAdd;
                    }
                    dt.Rows.InsertAt(row, 0);
                }
                DataView dv = new DataView(dt);
                dv.RowFilter = pRowFilter;

                pCbo.Properties.DataSource = dv;
                pCbo.Properties.Columns.Clear();
                pCbo.Properties.PopupWidth = Convert.ToInt32(pCbo.Width * 1.5);
                for (int i = 0; i < pColumns.Length; i++)
                {
                    pCbo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(pColumns[i]));
                }
                pCbo.Properties.DisplayMember = pDisplayMember;
                pCbo.Properties.ValueMember = pValueMember;
                pCbo.Properties.ShowHeader = false;
                pCbo.Properties.NullText = "";
            }
        }
        #endregion

        #region Get Data
        public int GetMaxLength(string pTableName, string pColumnName, DataTable pDataTable)
        {
            try
            {
                if (pDataTable == null)
                {
                    return 0;
                }
                DataView dv = new DataView(pDataTable);
                dv.RowFilter = "TableName = '" + pTableName + "'";
                dv.Sort = "ColumnName";
                int i = dv.Find(pColumnName);
                if (i >= 0)
                {
                    return Convert.ToInt32(dv[i]["CharacterMaxLength"]);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Boolean GetValueOfglbDataset(string pTable, string pSort, object[] pValues, string pColumn, ref object pReturn, DataSet pDataset)
        {
            pReturn = null;
            if (!pDataset.Tables.Contains(pTable))
            {
                return false;
            }
            DataView dv = new DataView(pDataset.Tables[pTable]);
            dv.Sort = pSort;

            int index = dv.Find(pValues);
            if (index >= 0)
            {
                pReturn = dv[index][pColumn];
                if (pReturn == null)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean GetValueOfglbDataset(string pTable, string pSort, object pValues, string pColumn, ref object pReturn, DataSet pDataset)
        {
            pReturn = null;
            if (!pDataset.Tables.Contains(pTable))
            {
                return false;
            }
            DataView dv = new DataView(pDataset.Tables[pTable]);
            dv.Sort = pSort;

            int index = dv.Find(pValues);
            if (index >= 0)
            {
                pReturn = dv[index][pColumn];
                if (pReturn == null)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataRow GetRowByKey(string pTable, string pSort, object pValues, DataSet pDataset)
        {
            if (!pDataset.Tables.Contains(pTable))
            {
                return null;
            }
            DataView dv = new DataView(pDataset.Tables[pTable]);
            dv.Sort = pSort;

            int index = dv.Find(pValues);
            if (index >= 0)
            {
                return pDataset.Tables[pTable].Rows[index];
            }
            return null;
        }
        #endregion

        public OleDbConnection CreateConnect(string pUserName, string pPassword, string pDatabase, string pServer)
        {
            OleDbConnection mConnection;
            String mConnectString;
            mConnectString = @"Data Source='" + pServer + "';Initial Catalog=" + pDatabase + ";Persist Security Info=True;User ID=" + pUserName + ";Password=" + pPassword;
            mConnection = new OleDbConnection(mConnectString);
            try
            {
                if (mConnection.State != System.Data.ConnectionState.Open)
                    mConnection.Open();
                mConnection.Close();
            }
            catch
            {

            }
            return mConnection;
        }

        public OleDbConnection CreateConnect(string pSQLConnectString)
        {
            OleDbConnection mConnection;
            mConnection = new OleDbConnection(pSQLConnectString);
            try
            {
                if (mConnection.State != System.Data.ConnectionState.Open)
                    mConnection.Open();
                mConnection.Close();
            }
            catch
            {

            }
            return mConnection;

        }

        public string CreateConnectString(string pUserName, string pPassword, string pDatabase, string pServer)
        {
            String mConnectString;
            mConnectString = @"Provider=sqloledb; Data Source=" + pServer + "; Initial Catalog=" + pDatabase + "; User Id=" + pUserName + "; Password=" + pPassword + "";
            return mConnectString;
        }

        public string CreateConnectStringLinQ(string pUserName, string pPassword, string pDatabase, string pServer)
        {
            String mConnectString;
            mConnectString = @"Data Source=" + pServer + "; Initial Catalog=" + pDatabase + "; User Id=" + pUserName + "; Password=" + pPassword + "";
            return mConnectString;
        }

        public string CreateConnectString(string pUserName, string pPassword, string pDatabase, string pServer, int pTimeOut)
        {
            String mConnectString;
            mConnectString = @"Provider=sqloledb; Data Source=" + pServer + "; Initial Catalog=" + pDatabase + "; User Id=" + pUserName + "; Password=" + pPassword + "; Connect Timeout=" + pTimeOut.ToString();
            return mConnectString;
        }

        public string CreateConnectString(string pPathFile, string pUserName, string pPassword)
        {
            String mConnectString;
            if (pUserName.Trim() == "")
            {
                mConnectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pPathFile + ";User Id=admin;Password=;";
            }
            else
            {
                mConnectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pPathFile + ";User Id=" + pUserName + ";Password=" + pPassword + ";";
            }

            return mConnectString;
        }
    }

    public class Ini
    {
        private string path;
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        private Ini() { }

        public Ini(string path_ini)
        {
            path = path_ini;
        }

        public static string ReadValue(string pPath, string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, pPath);
            return temp.ToString();
        }

        public static void WriteValue(string pPath, string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, pPath);
        }
    }

    public class WinForm
    {
        static string strControlEdit = "LookUpEdit;DateEdit;MemoEdit;CalcEdit;ImageComboBoxEdit;TextEdit;ComboBoxEdit;PictureEdit;SpinEdit;TimeEdit;CheckEdit;ColorEdit";

        public static ArrayList GetArrayControl(Form pForm)
        {
            ArrayList arrControlList = new ArrayList();
            foreach (Control ctr in pForm.Controls)
            {
                if (ctr.GetType().Name == "GroupBox")
                {
                    System.Windows.Forms.GroupBox pGroupBox = (System.Windows.Forms.GroupBox)ctr;
                    GetArrayControl(pGroupBox, ref arrControlList);
                }
                else if (ctr.GetType().Name == "Panel")
                {
                    System.Windows.Forms.Panel pPanel = (System.Windows.Forms.Panel)ctr;
                    GetArrayControl(pPanel, ref arrControlList);
                }
                else if (ctr.GetType().Name == "SplitContainerControl")
                {
                    DevExpress.XtraEditors.SplitContainerControl pctrSplitContainer = (DevExpress.XtraEditors.SplitContainerControl)ctr;
                    foreach (Control ctrSplit in pctrSplitContainer.Controls)
                    {
                        if (ctrSplit.GetType().Name == "SplitGroupPanel")
                        {
                            DevExpress.XtraEditors.SplitGroupPanel ctrSplitGroupPanel = (DevExpress.XtraEditors.SplitGroupPanel)ctrSplit;

                            foreach (Control ctrSplitGroupPanel_ in ctrSplitGroupPanel.Controls)
                            {
                                if (ctrSplitGroupPanel_.GetType().Name == "GroupBox")
                                {
                                    System.Windows.Forms.GroupBox pGroupBox = (System.Windows.Forms.GroupBox)ctrSplitGroupPanel_;
                                    GetArrayControl(pGroupBox, ref arrControlList);
                                }
                            }

                        }
                    }
                }
            }

            return arrControlList;
        }

        public static object GetValueControl(object obj)
        {
            switch (obj.GetType().Name)
            {
                case "LookUpEdit":
                    {
                        DevExpress.XtraEditors.LookUpEdit ctr = (DevExpress.XtraEditors.LookUpEdit)obj;
                        return ctr.EditValue;
                    }
                case "DateEdit":
                    {
                        DevExpress.XtraEditors.DateEdit ctr = (DevExpress.XtraEditors.DateEdit)obj;
                        return ctr.EditValue;
                    }
                case "MemoEdit":
                    {
                        DevExpress.XtraEditors.MemoEdit ctr = (DevExpress.XtraEditors.MemoEdit)obj;
                        return ctr.EditValue;
                    }
                case "CalcEdit":
                    {
                        DevExpress.XtraEditors.CalcEdit ctr = (DevExpress.XtraEditors.CalcEdit)obj;
                        return ctr.EditValue;
                    }
                case "ImageComboBoxEdit":
                    {
                        DevExpress.XtraEditors.ImageComboBoxEdit ctr = (DevExpress.XtraEditors.ImageComboBoxEdit)obj;
                        return ctr.EditValue;
                    }
                case "TextEdit":
                    {
                        DevExpress.XtraEditors.TextEdit ctr = (DevExpress.XtraEditors.TextEdit)obj;
                        return ctr.EditValue;
                    }
                case "ComboBoxEdit":
                    {
                        DevExpress.XtraEditors.ComboBoxEdit ctr = (DevExpress.XtraEditors.ComboBoxEdit)obj;
                        return ctr.EditValue;
                    }
                case "PictureEdit":
                    {
                        DevExpress.XtraEditors.PictureEdit ctr = (DevExpress.XtraEditors.PictureEdit)obj;
                        return ctr.EditValue;
                    }
                case "SpinEdit":
                    {
                        DevExpress.XtraEditors.SpinEdit ctr = (DevExpress.XtraEditors.SpinEdit)obj;
                        return ctr.EditValue;
                    }
                case "TimeEdit":
                    {
                        DevExpress.XtraEditors.TimeEdit ctr = (DevExpress.XtraEditors.TimeEdit)obj;
                        return ctr.EditValue;
                    }
                case "CheckEdit":
                    {
                        DevExpress.XtraEditors.CheckEdit ctr = (DevExpress.XtraEditors.CheckEdit)obj;
                        return ctr.EditValue;
                    }
                case "ColorEdit":
                    {
                        DevExpress.XtraEditors.ColorEdit ctr = (DevExpress.XtraEditors.ColorEdit)obj;
                        return ctr.EditValue;
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        private static void GetArrayControl(System.Windows.Forms.GroupBox pGroupBox, ref ArrayList pArrControlList)
        {
            foreach (Control ctr_ in pGroupBox.Controls)
            {
                if (strControlEdit.Contains(ctr_.GetType().Name))
                {
                    pArrControlList.Add(ctr_);
                }
            }
        }

        private static void GetArrayControl(System.Windows.Forms.Panel pPanel, ref ArrayList pArrControlList)
        {
            foreach (Control ctr in pPanel.Controls)
            {
                if (strControlEdit.Contains(ctr.GetType().Name))
                {
                    pArrControlList.Add(ctr);
                }
                else if (ctr.GetType().Name == "GroupBox")
                {
                    System.Windows.Forms.GroupBox pGroupBox = (System.Windows.Forms.GroupBox)ctr;
                    GetArrayControl(pGroupBox, ref pArrControlList);
                }
                else if (ctr.GetType().Name == "SplitContainerControl")
                {
                    DevExpress.XtraEditors.SplitContainerControl pctrSplitContainer = (DevExpress.XtraEditors.SplitContainerControl)ctr;
                    foreach (Control ctrSplit in pctrSplitContainer.Controls)
                    {
                        if (ctrSplit.GetType().Name == "SplitGroupPanel")
                        {
                            DevExpress.XtraEditors.SplitGroupPanel ctrSplitGroupPanel = (DevExpress.XtraEditors.SplitGroupPanel)ctrSplit;

                            foreach (Control ctrSplitGroupPanel_ in ctrSplitGroupPanel.Controls)
                            {
                                if (ctrSplitGroupPanel_.GetType().Name == "GroupBox")
                                {
                                    System.Windows.Forms.GroupBox pGroupBox = (System.Windows.Forms.GroupBox)ctrSplitGroupPanel_;
                                    GetArrayControl(pGroupBox, ref pArrControlList);
                                }
                                else if (ctrSplitGroupPanel_.GetType().Name == "SplitContainerControl")
                                {
                                    DevExpress.XtraEditors.SplitContainerControl pctrSplitContainer1 = (DevExpress.XtraEditors.SplitContainerControl)ctrSplitGroupPanel_;
                                    foreach (Control ctrSplit1 in pctrSplitContainer1.Controls)
                                    {
                                        if (ctrSplit1.GetType().Name == "SplitGroupPanel")
                                        {
                                            DevExpress.XtraEditors.SplitGroupPanel ctrSplitGroupPanel2 = (DevExpress.XtraEditors.SplitGroupPanel)ctrSplit1;

                                            foreach (Control ctrSplitGroupPanel__ in ctrSplitGroupPanel2.Controls)
                                            {
                                                if (ctrSplitGroupPanel__.GetType().Name == "GroupBox")
                                                {
                                                    System.Windows.Forms.GroupBox pGroupBox1 = (System.Windows.Forms.GroupBox)ctrSplitGroupPanel__;
                                                    GetArrayControl(pGroupBox1, ref pArrControlList);
                                                }
                                            }

                                        }

                                    }
                                }
                            }

                        }

                    }
                }
            }
        }
    }

    public class SystemInfo
    {
        public static string GetComputerName()
        {
            return SystemInformation.ComputerName;
        }

        [DllImport("kernel32.dll")]
        private static extern long GetVolumeInformation(string PathName, StringBuilder VolumeNameBuffer, UInt32 VolumeNameSize, ref UInt32 VolumeSerialNumber, ref UInt32 MaximumComponentLength, ref UInt32 FileSystemFlags, StringBuilder FileSystemNameBuffer, UInt32 FileSystemNameSize);

        public static string GetVolumeSerial(string strDriveLetter)
        {
            uint serNum = 0;
            uint maxCompLen = 0;
            StringBuilder VolLabel = new StringBuilder(256); // Label
            UInt32 VolFlags = new UInt32();
            StringBuilder FSName = new StringBuilder(256); // File System Name
            strDriveLetter += ":\\"; // fix up the passed-in drive letter for the API call
            long Ret = GetVolumeInformation(strDriveLetter, VolLabel, (UInt32)VolLabel.Capacity, ref serNum, ref maxCompLen, ref VolFlags, FSName, (UInt32)FSName.Capacity);
            return Convert.ToString(serNum);
        }
    }
}
