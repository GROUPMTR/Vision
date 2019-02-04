using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Globalization;
using System.Data.SqlClient;

namespace VISION.TIMESHEET
{
    public partial class TIME_SHEET_RAPORX : DevExpress.XtraEditors.XtraForm
    {
        string Date_One, Date_Two;
        SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
        public TIME_SHEET_RAPORX()
        {
            InitializeComponent();
            this.Tag = "MDIFORM";

            Conn.Open();

            DateTime dtOne = Convert.ToDateTime(DateTime.Now.AddDays(-45));//DateTime.Now;TIMESHEET_KULLANICISI='True' and
            dtTmPckrBasTar.EditValue = dtOne.ToString("dd.MM.yyyy", DateTimeFormatInfo.InvariantInfo);
            DateTime dtTwo = Convert.ToDateTime(DateTime.Now);//DateTime.Now;
            dtTmPckrBitTar.EditValue = dtTwo.ToString("dd.MM.yyyy", DateTimeFormatInfo.InvariantInfo);
             
           
        }
        private void BR_LIST_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DATA_LOAD();
        }
        private void DATA_LOAD()
        {


            //string SQL = @" SELECT dbo.TODO_TIME_SHEET.SIRKET_KODU,  dbo.TODO_TIME_SHEET.MAIL_ADRESI ,dbo.TODO_TIME_SHEET.Description as MUSTERI_KODU , dbo.ADM_KULLANICI.UNVAN_DETAYI , dbo.ADM_KULLANICI.AKTIF,
            //                DATEDIFF(hour, dbo.TODO_TIME_SHEET.StartDate, dbo.TODO_TIME_SHEET.EndDate) AS Hours, CONVERT(date, dbo.TODO_TIME_SHEET.StartDate, 102) AS  TARIH    
            //                FROM    dbo.TODO_TIME_SHEET INNER JOIN  dbo.ADM_KULLANICI ON dbo.TODO_TIME_SHEET.MAIL_ADRESI = dbo.ADM_KULLANICI.MAIL_ADRESI
            //                WHERE  (dbo.TODO_TIME_SHEET.SIRKET_KODU=@SIRKET_KODU) AND (dbo.TODO_TIME_SHEET.StartDate >= CONVERT(DATETIME, @StartDate, 102)) AND (dbo.TODO_TIME_SHEET.EndDate <= CONVERT(DATETIME, @EndDate, 102)) 
                            
            //              ";


            string SQL = @" SELECT SIRKET_KODU,  MAIL_ADRESI ,Description as MUSTERI_KODU ,  
                            DATEDIFF(hour, dbo.TODO_TIME_SHEET.StartDate, dbo.TODO_TIME_SHEET.EndDate) AS Hours, CONVERT(date, dbo.TODO_TIME_SHEET.StartDate, 102) AS  TARIH    
                            FROM    dbo.TODO_TIME_SHEET        WHERE  (SIRKET_KODU=@SIRKET_KODU) AND (StartDate >= CONVERT(DATETIME, @StartDate, 102)) AND (EndDate <= CONVERT(DATETIME, @EndDate, 102)) 
                            
                          ";


            DateTime dtOne = Convert.ToDateTime(dtTmPckrBasTar.EditValue); Date_One = dtOne.ToString("yyyy-MM-dd 00:00:00", DateTimeFormatInfo.InvariantInfo);            
            DateTime dtTwo = Convert.ToDateTime(dtTmPckrBitTar.EditValue); Date_Two = dtTwo.ToString("yyyy-MM-dd 00:00:00", DateTimeFormatInfo.InvariantInfo);
            using (SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString())) // and  (dbo.TODO_TIME_SHEET.MAIL_ADRESI=@MAIL_ADRESI)
            {
                using (SqlDataAdapter da = new SqlDataAdapter(SQL, Conn))
                {
                    
                    da.SelectCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU );
                    da.SelectCommand.Parameters.AddWithValue("@MAIL_ADRESI", _GLOBAL_PARAMETERS._KULLANICI_MAIL);
                    da.SelectCommand.Parameters.AddWithValue("@StartDate", Date_One);
                    da.SelectCommand.Parameters.AddWithValue("@EndDate", Date_Two);
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