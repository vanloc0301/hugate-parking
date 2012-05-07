using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using Hugate.ComportConnections;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Data.OleDb;
namespace Hugate.Parking
{
    class clsDeclare
    {
        public static XtraForm activedForm = new XtraForm();
        public static EventsComPorts eventComPort1 = new EventsComPorts();
        public static EventsComPorts eventComPort2 = new EventsComPorts();
        public static bool isConnect = false;

        public static frmMain objFormMain;

        public static void FullScreen(Form pubForm, bool full)
        {
            if (full)
            {
                pubForm.FormBorderStyle = FormBorderStyle.None;
                pubForm.WindowState = FormWindowState.Maximized;
            }
            else
            {
                pubForm.FormBorderStyle = FormBorderStyle.Sizable;
            }
            pubForm.TopMost = full;
        }

        public bool Compare2Image(Bitmap img1, Bitmap img2)
        {
            bool flag = false;
            int count1 = 0;
            int count2 = 0;
            string img1_ref, img2_ref;
            img1 = new Bitmap(img1);
            img2 = new Bitmap(img2);
            if (img1.Width == img2.Width && img1.Height == img2.Height)
            {
                for (int i = 0; i < img1.Width; i++)
                {
                    for (int j = 0; j < img1.Height; j++)
                    {
                        img1_ref = img1.GetPixel(i, j).ToString();
                        img2_ref = img2.GetPixel(i, j).ToString();
                        if (img1_ref != img2_ref)
                        {
                            count2++;
                            flag = false;
                            break;
                        }
                        flag = true;
                        count1++;
                    }
                }
                if (flag)
                    return flag;
                //MessageBox.Show("Hình ảnh không giống ," + count1 + " điểm ảnh giống " + count2 + " điểm ảnh không giống!");
                else
                    return flag;
                //MessageBox.Show("Hình ảnh giống , " + count1 + " điểm ảnh giống " + count2 + " điểm ảnh không giống");
            }
            else
                return flag;
            //MessageBox.Show("Không thể so sánh!");
        }

        public static DataTable ObtainDataTableFromIEnumerable(IEnumerable ien)
        {
            DataTable dt = new DataTable();
            foreach (object obj in ien)
            {
                Type t = obj.GetType();
                PropertyInfo[] pis = t.GetProperties();
                if (dt.Columns.Count == 0)
                {
                    foreach (PropertyInfo pi in pis)
                    {
                        Type propType = pi.PropertyType;
                        if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            propType = Nullable.GetUnderlyingType(propType);
                        }
                        dt.Columns.Add(pi.Name, propType);
                    }
                }
                DataRow dr = dt.NewRow();
                foreach (PropertyInfo pi in pis)
                {
                    object value = pi.GetValue(obj, null);
                    dr[pi.Name] = value == null ? DBNull.Value : value;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static string glbFormatStringNumber = "#,##0";
        public static string glbFormatStringNumberFC = "#,##0.#";
        public static string glbFormatStringDate = "dd/MM/yyyy";
        public static string glbFormatStringDateNotYear = "MM-dd";
        public static string glbFormatStringDateTimeNotSecond = "dd/MM/yyyy HH:mm";
        public static string glbFormatStringDateTime = "dd/MM/yyyy HH:mm:ss";
        public static string glbFormatStringTime = "HH:mm:ss";
        public static string glbFormatStringTimeNotSecond = "HH:mm";

        public static SZLibrary.Database clsDatabase = new SZLibrary.Database();

        public static string gblConnectString;
        public static string gblConnectStringLinQ;
        public static OleDbConnection glbConnection = new OleDbConnection();
        public static SZLibrary.Message glbMessage;
        public static SZLibrary.WaitDialog glbWaitDialog;

        public static string PathServerFile;
        public static string glbUserNameData;
        public static string glbUserName;
        public static string glbDatabase;
        public static string glbHost;
        public static string glbPassword;
        public static string glbPasswordData;
        public static string PassKeys = "STEVENZERO";
        public static DataSet glbDataSet;

        public static string con_Lang_VietNamese;
    }
}
