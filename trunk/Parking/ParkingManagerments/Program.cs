using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using SZLibrary;

namespace Hugate.Parking
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);

                if (!File.Exists(Application.StartupPath + @"\In.ini"))
                {
                    MessageBox.Show("Not found file Server. Please check again.", "Error");
                    Application.Exit();
                    return;
                }
            ABC:
                {
                }
                //SZLibrary.EncDec.Encrypt(Application.StartupPath + @"\Server.ini", Application.StartupPath + @"\In.ini",clsDeclare.PassKeys);
                SZLibrary.EncDec.Decrypt(Application.StartupPath + @"\In.ini", Application.StartupPath + @"\Out.ini", clsDeclare.PassKeys);
                clsDeclare.PathServerFile = Application.StartupPath + @"\Out.ini";


                clsDeclare.glbHost = SZLibrary.EncDec.Decrypt(SZLibrary.Ini.ReadValue(clsDeclare.PathServerFile, "A", "A1"), clsDeclare.PassKeys);
                clsDeclare.glbDatabase = SZLibrary.EncDec.Decrypt(SZLibrary.Ini.ReadValue(clsDeclare.PathServerFile, "A", "A2"), clsDeclare.PassKeys);
                clsDeclare.glbUserNameData = SZLibrary.EncDec.Decrypt(SZLibrary.Ini.ReadValue(clsDeclare.PathServerFile, "B", "B1"), clsDeclare.PassKeys);
                clsDeclare.glbPasswordData = SZLibrary.EncDec.Decrypt(SZLibrary.Ini.ReadValue(clsDeclare.PathServerFile, "B", "B2"), clsDeclare.PassKeys);

                clsDeclare.objFormMain = new frmMain();


                if (!Security.CheckUserDatabase(clsDeclare.glbUserNameData, clsDeclare.glbPasswordData, clsDeclare.glbDatabase, clsDeclare.glbHost))
                {
                    frmDatabaseOption frmDBO = new frmDatabaseOption();
                    if (frmDBO.ShowDialog() == DialogResult.OK)
                    {
                        goto ABC;
                    }
                    else
                    {
                        MessageBox.Show("Don't connect to server. Please check inform server again.");
                        Application.Exit();
                        return;
                    }
                }
                clsDeclare.gblConnectString = clsDeclare.clsDatabase.CreateConnectString(clsDeclare.glbUserNameData, clsDeclare.glbPasswordData, clsDeclare.glbDatabase, clsDeclare.glbHost);
                clsDeclare.gblConnectStringLinQ = clsDeclare.clsDatabase.CreateConnectStringLinQ(clsDeclare.glbUserNameData, clsDeclare.glbPasswordData, clsDeclare.glbDatabase, clsDeclare.glbHost);
                Application.Run(new frmMain());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (clsDeclare.glbWaitDialog != null)
                {
                    if (clsDeclare.glbWaitDialog.IsStart)
                    {
                        clsDeclare.glbWaitDialog.Close();
                    }
                }
            }
        }
    }
}
