using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VISION.TIMESHEET
{
    public partial class TIME_SHEET_RAPOR_FK : Form
    {
        string Date_One, Date_Two;
        SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());

        public TIME_SHEET_RAPOR_FK()
        {
            InitializeComponent();

            this.Tag = "MDIFORM";

            Conn.Open(); 

        }
        private void BR_LIST_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DATA_LOAD();
        }
        private void DATA_LOAD()
        {
             

            string SQL = @" SELECT  SIRKET_KODU, KULLANICI, ACIKLAMA, AY, SURE   
                          
                            FROM    dbo.TODO_TIME_SHEET_FKUL  WHERE  (SIRKET_KODU=@SIRKET_KODU) AND  (ACIKLAMA=@ACIKLAMA) AND  (YIL >=@StartDate) AND (YIL <=@EndDate  ) 
                            
                          ";

 
            using (SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString())) // and  (dbo.TODO_TIME_SHEET.MAIL_ADRESI=@MAIL_ADRESI)
            {
                using (SqlDataAdapter da = new SqlDataAdapter(SQL, Conn))
                { 
                    da.SelectCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    da.SelectCommand.Parameters.AddWithValue("@ACIKLAMA", dtMusteri.EditValue.ToString()); 
                    da.SelectCommand.Parameters.AddWithValue("@StartDate", BR_YIL.EditValue.ToString());
                    da.SelectCommand.Parameters.AddWithValue("@EndDate", BR_YIL.EditValue.ToString());
                 
                    using (DataSet dtSet = new DataSet())
                    {
                        da.Fill(dtSet, "ADM_MUSTERI");
                        using (DataViewManager dvManager = new DataViewManager(dtSet))
                        {
                            DataView dv = dvManager.CreateDataView(dtSet.Tables[0]);
                            TIME_SHEET_PIVOT.DataSource = dv;
                        }
                    }
                }
            }
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void BR_EXCEL_EXPORT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string fileName = ShowSaveFileDialog("Microsoft Excel Document", "Microsoft Excel|*.xlsx");
            if (fileName != "")
            {
                TIME_SHEET_PIVOT.ExportToXlsx(fileName);
                OpenFile(fileName);
            }
        }


        private string ShowSaveFileDialog(string title, string filter)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                string name = Application.ProductName;
                int n = name.LastIndexOf(".") + 1;
                if (n > 0)
                    name = name.Substring(n, name.Length - n);
                dlg.Title = String.Format("Export To {0}", title);
                dlg.FileName = name;
                dlg.Filter = filter;
                if (dlg.ShowDialog() == DialogResult.OK)
                    return dlg.FileName;
            }
            return "";
        }

        private void OpenFile(string fileName)
        {
            if (XtraMessageBox.Show("Do you want to open this file?", "Export To...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (System.Diagnostics.Process process = new System.Diagnostics.Process())
                    {
                        process.StartInfo.FileName = fileName;
                        process.StartInfo.Verb = "Open";
                        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                        process.Start();
                    }
                }
                catch
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(this, "Cannot find an application on your system suitable for openning the file with exported data.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}