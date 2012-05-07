using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SZLibrary
{
    public partial class frmExport : Form
    {
        public DevExpress.XtraGrid.GridControl pubGridControl;
        public DevExpress.XtraGrid.Views.Grid.GridView pubGridView;

        DataTable dtSelect;
        DataView dvSelect;

        public frmExport()
        {
            InitializeComponent();
        }

        private void frmExport_Load(object sender, EventArgs e)
        {
            dtSelect = new DataTable();
            DataColumn col1 = new DataColumn("Selected", System.Type.GetType("System.Boolean"));
            DataColumn col2 = new DataColumn("ColumnName", System.Type.GetType("System.String"));
            DataColumn col3 = new DataColumn("FieldName", System.Type.GetType("System.String"));
            DataColumn col4 = new DataColumn("Index", System.Type.GetType("System.Int32"));
            DataColumn col5 = new DataColumn("IsDate", System.Type.GetType("System.Boolean"));
            DataColumn col6 = new DataColumn("FormatString", System.Type.GetType("System.String"));
            DataColumn col7 = new DataColumn("Order", System.Type.GetType("System.Int32"));
            DataColumn col8 = new DataColumn("SortOrder", System.Type.GetType("System.String"));
            DataColumn col9 = new DataColumn("MaxLength", System.Type.GetType("System.Int32"));

            col8.DefaultValue = "None";

            dtSelect.Columns.Add(col1);
            dtSelect.Columns.Add(col2);
            dtSelect.Columns.Add(col3);
            dtSelect.Columns.Add(col4);
            dtSelect.Columns.Add(col5);
            dtSelect.Columns.Add(col6);
            dtSelect.Columns.Add(col7);
            dtSelect.Columns.Add(col8);
            dtSelect.Columns.Add(col9);

            if (pubGridControl != null && pubGridView != null)
            {
                DataRow rowAdd;
                int i = 0;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in pubGridView.Columns)
                {
                    rowAdd = dtSelect.NewRow();
                    rowAdd["Selected"] = true;
                    rowAdd["ColumnName"] = col.Caption;
                    rowAdd["FieldName"] = col.FieldName;
                    rowAdd["Index"] = col.VisibleIndex;
                    if (col.DisplayFormat.FormatType == DevExpress.Utils.FormatType.DateTime)
                    {
                        rowAdd["IsDate"] = true;
                        rowAdd["FormatString"] = col.DisplayFormat.FormatString;
                    }
                    else
                    {
                        rowAdd["IsDate"] = false;
                        rowAdd["FormatString"] = "";
                    }
                    dtSelect.Rows.Add(rowAdd);
                    rowAdd["Order"] = i;
                    i++;
                }
            }
            dvSelect = new DataView(dtSelect);

            gridControl1.BeginUpdate();
            gridControl1.DataSource = dvSelect;
            gridControl1.EndUpdate();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataRow[] rows = dtSelect.Select("Selected = 1");
            DataView dvSelect = new DataView(dtSelect);
            dvSelect.RowFilter = "Selected = 1";
            dvSelect.Sort = "Order";
            if (rows.Length != 0)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel files (*.xls)|*.xls|Text files (*.txt)|*.txt";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog1.FilterIndex == 1)
                    {
                        foreach (DataRow row in dtSelect.Rows)
                        {
                            if (!Convert.ToBoolean(row["Selected"]))
                            {
                                pubGridView.Columns[row["FieldName"].ToString()].VisibleIndex = -1;
                            }
                            else
                            {
                                pubGridView.Columns[row["FieldName"].ToString()].VisibleIndex = Convert.ToInt32(row["Order"]);

                                if (row["SortOrder"].ToString() == "Ascending")
                                {
                                    pubGridView.Columns[row["FieldName"].ToString()].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                                }
                                else if (row["SortOrder"].ToString() == "Descending")
                                {
                                    pubGridView.Columns[row["FieldName"].ToString()].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                                }
                            }
                        }
                        pubGridView.ExportToExcelOld(saveFileDialog1.FileName);

                        foreach (DataRow row in dtSelect.Rows)
                        {
                            if (!Convert.ToBoolean(row["Selected"]))
                            {
                                pubGridView.Columns[row["FieldName"].ToString()].VisibleIndex = Convert.ToInt32(row["Index"]);
                            }
                        }
                    }
                    else if (saveFileDialog1.FilterIndex == 2)
                    {
                        if (System.IO.File.Exists(saveFileDialog1.FileName))
                        {
                            MessageBox.Show(saveFileDialog1.FileName + " has existed !");
                            return;
                        }

                        DataView dvSource = (DataView)pubGridView.DataSource;
                        if (dvSource == null)
                        {
                            return;
                        }
                        object values;
                        foreach (DataRow rowCol in dtSelect.Rows)
                        {
                            //pubGridView.GetDisplayTextByColumnValue(pubGridView.Columns[rowV["FieldName"].ToString()], rowSource[rowV["FieldName"].ToString()])
                            //pubGridView.Columns[rowV["FieldName"].ToString()].
                            //values = dvSource.Table.Compute("Max(" + rowCol["FieldName"].ToString() + ")", "");
                            //if (values == null)
                            //{
                            //    rowCol["MaxLength"] = 10;
                            //}
                            //else
                            //{
                            //    rowCol["MaxLength"] = values.ToString().Length;
                            //}
                            rowCol["MaxLength"] = 30;
                        }

                        string sSortOrder = "";
                        for (int k = 0; k < rows.Length; k++)
                        {
                            if (sSortOrder.Contains(rows[k]["FieldName"].ToString()))
                            {
                                continue;
                            }
                            if (rows[k]["SortOrder"].ToString() == "Ascending")
                            {
                                sSortOrder += rows[k]["FieldName"].ToString() + " Asc,";
                            }
                            else if (rows[k]["SortOrder"].ToString() == "Descending")
                            {
                                sSortOrder += rows[k]["FieldName"].ToString() + " Desc,";
                            }
                        }
                        if (sSortOrder.Length > 0)
                        {
                            sSortOrder = sSortOrder.Substring(0, sSortOrder.Length - 1);
                        }
                        dvSource.Sort = sSortOrder;

                        string sDate = "";
                        int i = 0;
                        System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFileDialog1.FileName);
                        StringBuilder sb = new StringBuilder();
                        sb.Append("\t");
                        string value = "";
                        string space = " ";
                        int MaxLength = 0;
                        int DeltaLength = 0;
                        foreach (DataRowView rowSource in dvSource)
                        {
                            i = 0;
                            foreach (DataRowView rowV in dvSelect)
                            {
                                MaxLength = Convert.ToInt32(rowV["MaxLength"]);
                                if (i != 0)
                                {
                                    sw.Write(sb.ToString());
                                    //sw.Write(sb.ToString());
                                    //sw.Write(sb.ToString());
                                    //sw.Write(sb.ToString());
                                    //sw.Write(sb.ToString());
                                    //sw.Write(sb.ToString());
                                }
                                i++;
                                if (rowSource[rowV["FieldName"].ToString()] == DBNull.Value)
                                {
                                    for (int y = 0; y < MaxLength; y++)
                                    {
                                        sw.Write(space);
                                    }
                                    continue;
                                }
                                if (Convert.ToBoolean(rowV["IsDate"]))
                                {
                                    if (Convert.ToString(rowV["FormatString"]) != "")
                                    {
                                        if (rowSource[rowV["FieldName"].ToString()] != DBNull.Value)
                                        {
                                            sDate = Convert.ToDateTime(rowSource[rowV["FieldName"].ToString()]).ToString(Convert.ToString(rowV["FormatString"]));
                                            sw.Write(sDate);
                                            DeltaLength = MaxLength - sDate.Length;
                                            for (int y = 0; y < DeltaLength; y++)
                                            {
                                                sw.Write(space);
                                            }
                                        }
                                        else
                                        {
                                            for (int y = 0; y < MaxLength; y++)
                                            {
                                                sw.Write(space);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        sw.Write(rowSource[rowV["FieldName"].ToString()].ToString());
                                        DeltaLength = MaxLength - rowSource[rowV["FieldName"].ToString()].ToString().Length;
                                        for (int y = 0; y < DeltaLength; y++)
                                        {
                                            sw.Write(space);
                                        }
                                    }
                                }
                                else
                                {
                                    value = pubGridView.GetDisplayTextByColumnValue(pubGridView.Columns[rowV["FieldName"].ToString()], rowSource[rowV["FieldName"].ToString()]);
                                    sw.Write(value);
                                    DeltaLength = MaxLength - value.Length;
                                    for (int y = 0; y < DeltaLength; y++)
                                    {
                                        sw.Write(space);
                                    }
                                }
                            }
                            sw.WriteLine();
                        }
                        sw.Close();
                    }

                    this.Close();
                }
            }
        }
    }
}