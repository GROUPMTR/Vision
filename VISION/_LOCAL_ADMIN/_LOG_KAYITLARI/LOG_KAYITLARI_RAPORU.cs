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
using System.Data.SqlClient;

namespace VISION._LOCAL_ADMIN._LOG_KAYITLARI
{
    public partial class LOG_KAYITLARI_RAPORU : DevExpress.XtraEditors.XtraForm
    {
        public LOG_KAYITLARI_RAPORU()
        {
            InitializeComponent();
            this.Tag = "MDIFORM";
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            DATA_LOAD();
        }


        private void DATA_LOAD()
        {

            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string SQL = " SELECT  ISLEM_TARIHI AS [TARIH],  COUNT(*) AS [Toplam Kayıt]  ,  CASE WHEN KAYIT_IPTAL='KAYIT'   THEN  COUNT(*)  END as [Aktarılan Kayıt Sayısı],CASE WHEN KAYIT_IPTAL='KAYIT-HATALI' OR KAYIT_IPTAL='SİL' or KAYIT_IPTAL='' THEN  COUNT(*)  END as [Hatalı Kayıt Sayısı] , ISLEMI_YAPAN AS [Kullanıcı],SIRKET_KODU as [Firma Adı], YAPILAN_ISLEM as [Tür]    FROM            dbo.XLG_FATURA_HAREKETLERI GROUP BY ISLEM_TARIHI,ISLEMI_YAPAN,SIRKET_KODU, YAPILAN_ISLEM, KAYIT_IPTAL ORDER BY SIRKET_KODU";
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(SQL, myConnection);
                DataSet MyDataSet = new DataSet();
                MySqlDataAdapter.Fill(MyDataSet, "dbo_USER");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                gridCntrl_LIST.DataSource = dv;
            }

        }

        private void BTN_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void BTN_EXPORT_EXCEL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = ".xlsx (*.xlsx)|*.xlsx";
            sfd.FileName = "ALIM_BEKLEMEDE.xlsx";
            DialogResult res = sfd.ShowDialog();
            if (res == DialogResult.OK)
            {
                gridView_LIST.ExportToXlsx(sfd.FileName);
            } 
        }
    }
}