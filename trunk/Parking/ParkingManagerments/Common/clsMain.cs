using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Security.Cryptography;

namespace Hugate.Parking
{
    class clsMain
    {

    }
    public class Security
    {
        public static Boolean CheckUserDatabase(string pUserName, string pPassword, string pDatabase, string pServer)
        {
            OleDbConnection mConnection;
            String mConnectString;
            mConnectString = clsDeclare.clsDatabase.CreateConnectString(pUserName, pPassword, pDatabase, pServer);
            try
            {
                mConnection = new OleDbConnection(mConnectString);
                if (mConnection.State != System.Data.ConnectionState.Open)
                    mConnection.Open();
                mConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean CheckUserDatabase(string pUserName, string pPassword, string pPathFile)
        {
            OleDbConnection mConnection;
            String mConnectString;
            mConnectString = clsDeclare.clsDatabase.CreateConnectString(pPathFile, pUserName, pPassword);
            try
            {
                mConnection = new OleDbConnection(mConnectString);
                if (mConnection.State != System.Data.ConnectionState.Open)
                    mConnection.Open();
                mConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean CheckUserAccount(string pUserName, string pPassword)
        {
            try
            {
                DataView dv = new DataView(clsDeclare.glbDataSet.Tables["SYS_User"]);
                dv.Sort = "UserName";
                int index = dv.Find(pUserName);
                if (index < 0)
                {
                    return false;
                }
                if (Security.Encrypte(pPassword) != dv[index]["Password"].ToString())
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean CheckUserAccount(string pUserName, string pPassword, string pDatabase, string pServer)
        {
            OleDbConnection mConnection;
            String mConnectString;
            mConnectString = @"Data Source='" + pServer + "';Initial Catalog=" + pDatabase + ";Persist Security Info=True;User ID=" + pUserName + ";Password=" + pPassword;
            try
            {
                mConnection = new OleDbConnection(mConnectString);
                if (mConnection.State != System.Data.ConnectionState.Open)
                    mConnection.Open();
                mConnection.Close();
                //Check co quyen xem thong tin,edit,update data ko
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean CheckUserPermission(string pUserName, string pFormName, string pPermissionType)
        {
            Boolean mReturn = false;
            try
            {
                DataRow[] mArrRow;
                mArrRow = clsDeclare.glbDataSet.Tables["SYS_UserPermission"].Select("FormName = '" + pFormName + "' and UserName = '" + pUserName + "'");
                if (mArrRow.Length == 1)
                {
                    if (Convert.ToBoolean(mArrRow[0][pPermissionType]))
                    {
                        mReturn = true;
                    }
                }
            }
            catch
            {
            }
            return mReturn;
        }

        public static void SetMenuPermission(frmMain pfrmMain, string pUserName)
        {
            if (pUserName == null)
            {
                return;
            }
            DevExpress.XtraBars.BarItem btnTemp;
            DevExpress.XtraNavBar.NavBarItem NBI;

            //set hien het
            for (int i = 0; i < clsDeclare.objFormMain.barManagerMain.Items.Count; i++)
            {
                clsDeclare.objFormMain.barManagerMain.Items[i].Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

            DataView dvUserPermission = new DataView(clsDeclare.glbDataSet.Tables["SYS_UserPermission"]);
            dvUserPermission.RowFilter = "UserName = '" + pUserName + "'";
            DataRow rowForm;
            foreach (DataRowView row in dvUserPermission)
            {
                DataRow[] rowForms = clsDeclare.glbDataSet.Tables["SYS_Form"].Select("FormName = '" + row["FormName"].ToString() + "'");
                if (rowForms.Length != 1)
                {
                    continue;
                }
                rowForm = rowForms[0];
                btnTemp = null;
                NBI = null;
                if (rowForm["MenuName"] != DBNull.Value)
                {
                    btnTemp = (DevExpress.XtraBars.BarItem)pfrmMain.barManagerMain.Items[rowForm["MenuName"].ToString()];
                }
                if (Convert.ToBoolean(row["VIW"]) == false && Convert.ToBoolean(row["ADD"]) == false && Convert.ToBoolean(row["DEL"]) == false && Convert.ToBoolean(row["EDT"]) == false && Convert.ToBoolean(row["PRN"]) == false && Convert.ToBoolean(row["EXP"]) == false)
                {
                    if (btnTemp != null)
                    {
                        btnTemp.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    if (rowForm["MenuName1"] != DBNull.Value)
                    {
                        btnTemp = (DevExpress.XtraBars.BarItem)pfrmMain.barManagerMain.Items[rowForm["MenuName1"].ToString()];
                        if (btnTemp != null)
                        {
                            btnTemp.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        }
                        else
                        {
                            //NBI = (DevExpress.XtraNavBar.NavBarItem)pfrmMain.navBarControl1.Items[rowForm["MenuName1"].ToString()];
                            //if (NBI != null)
                            //{
                            //    NBI.Visible = false;
                            //}
                        }
                    }
                }
                else
                {
                    if (btnTemp != null)
                    {
                        btnTemp.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    if (rowForm["MenuName1"] != DBNull.Value)
                    {
                        btnTemp = (DevExpress.XtraBars.BarItem)pfrmMain.barManagerMain.Items[rowForm["MenuName1"].ToString()];
                        if (btnTemp != null)
                        {
                            btnTemp.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        }
                        else
                        {
                            //NBI = (DevExpress.XtraNavBar.NavBarItem)pfrmMain.navBarControl1.Items[rowForm["MenuName1"].ToString()];
                            //if (NBI != null)
                            //{
                            //    NBI.Visible = true;
                            //}
                        }
                    }
                }
            }
            //Set barSub
            int m = pfrmMain.barManagerMain.Bars.Count;
            foreach (object obj in pfrmMain.barManagerMain.Items)
            {
                if (obj.GetType().Name == "BarSubItem")
                {
                    DevExpress.XtraBars.BarSubItem pBarSubItem = (DevExpress.XtraBars.BarSubItem)obj;
                    SetBarSub(pBarSubItem, pUserName);
                }
            }
        }

        private static Boolean CheckMenuPermission(string pMenuName, string pUserName)
        {
            int mIndex;
            try
            {
                DataView dvUserPermission = new DataView(clsDeclare.glbDataSet.Tables["SYS_UserPermission"]);
                dvUserPermission.RowFilter = "MenuName <> '' and UserName = '" + pUserName + "'";
                dvUserPermission.Sort = "MenuName";
                for (int i = 0; i < dvUserPermission.Count; i++)
                {
                    mIndex = dvUserPermission.Find(pMenuName);
                    if (mIndex >= 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {
            }
            return false;
        }

        private static bool SetBarSub(DevExpress.XtraBars.BarSubItem pBarSub, string pUserName)
        {
            int mCount = pBarSub.LinksPersistInfo.Count;
            int mCountVisible = 0;
            if (mCount == 0)
            {
                pBarSub.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                return false;
            }

            for (int i = 0; i < mCount; i++)
            {
                if (pBarSub.LinksPersistInfo[i].Item.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
                {
                    if (pBarSub.LinksPersistInfo[i].Item.GetType().ToString() == "DevExpress.XtraBars.BarSubItem")
                    {
                        DevExpress.XtraBars.BarSubItem barTemp = (DevExpress.XtraBars.BarSubItem)pBarSub.LinksPersistInfo[i].Item;
                        if (barTemp != null)
                        {
                            if (SetBarSub(barTemp, pUserName))
                            {
                                mCountVisible = mCountVisible + 1;
                            }
                        }
                    }
                    else
                    {
                        mCountVisible = mCountVisible + 1;
                    }
                }
            }
            if (mCount != 0 && mCountVisible != 0)
            {
                pBarSub.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                return true;
            }
            else
            {
                pBarSub.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                return false;
            }
        }

        public static string GetUserLanguage(string pUserName)
        {
            string ret = clsDeclare.con_Lang_VietNamese;
            if (clsDeclare.glbDataSet.Tables.Contains("SYS_User"))
            {
                DataView dv = new DataView(clsDeclare.glbDataSet.Tables["SYS_User"]);
                if (dv != null)
                {
                    dv.Sort = "UserName";
                    int index = dv.Find(pUserName);
                    if (index >= 0)
                    {
                        if (dv[index]["Language"] != DBNull.Value)
                        {
                            ret = dv[index]["Language"].ToString();
                        }
                    }
                }

            }
            return ret;
        }

        public static string Encrypte(string pString)
        {
            UTF32Encoding u = new UTF32Encoding();
            byte[] bytes = u.GetBytes(pString); //get original string
            MD5 md = new MD5CryptoServiceProvider(); // using md5 algorithm
            byte[] result = md.ComputeHash(bytes); // encrypted input bytes into encrypted bytes
            return Convert.ToBase64String(result); //return encrypted string
        }
    }
}
