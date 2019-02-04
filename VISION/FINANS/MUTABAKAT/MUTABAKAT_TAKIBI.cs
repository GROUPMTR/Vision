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
using System.IO;

namespace VISION.FINANS.MUTABAKAT
{
    public partial class MUTABAKAT_TAKIBI : DevExpress.XtraEditors.XtraForm
    {

        string _MUTABAKAT_KODU, _MUTABAKAT_BAS_TARIHI, _MUTABAKAT_BITIS_TARIHI, _MUTABAKAT_ACIKLAMASI, _MUTABAKAT_DONEMI, _MUTABAKAT_FORM_TURU;
        DataSet MyDataSet;
        SqlConnection SqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["_CONNECTIONSTRING_WEB"].ToString()); 
      

        public MUTABAKAT_TAKIBI()
        {
            InitializeComponent(); 
            this.Tag = "MDIFORM"; 
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent; 
        }

 

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
        DataRow SelectDrRow;
        int[] selectedRows;
        private void BTN_MAIL_GONDER_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
               selectrowcount = -1;
               selectedRows = gridView_MUTABAKAT_LISTESI.GetSelectedRows();
               for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
               { 
                   string MUTABAKAT_FORMU_TMP = "";
                   using (StreamReader sr = new StreamReader(@"" + Application.StartupPath.ToString() + @"\_TEMPLATE\_FORMAT\MUTABAKAT_FORMU.TMP"))
                   {
                       MUTABAKAT_FORMU_TMP = sr.ReadToEnd();
                   }
                   SelectDrRow = gridView_MUTABAKAT_LISTESI.GetDataRow(selectedRows[ix]);

                   string EMAIL_ONAY_LINKI = String.Format("http://213.144.108.220:8014/_Mutabakat/Mutabakat_Email_Onayi.aspx?GUID={0} ", SelectDrRow["GUID"].ToString().ToUpper());
                   string WEB_ONAY_LINKI = String.Format("http://213.144.108.220:8014/_Mutabakat/Mutabakat_Onayi.aspx?GUID={0} ", SelectDrRow["GUID"].ToString().ToUpper());

                    
                   MUTABAKAT_FORMU_TMP = MUTABAKAT_FORMU_TMP.ToString()
                  .Replace("FORM_TURU", "Form " + _MUTABAKAT_FORM_TURU + " Mutabakat")
                  .Replace("FIRMA_UNVANI", SelectDrRow["CARI_ADI"].ToString())
                  .Replace("UNVANI", SelectDrRow["CARI_ADI"].ToString())
                  .Replace("METNI", _MUTABAKAT_BAS_TARIHI.Replace(" 00:00:00", "") + "/" + _MUTABAKAT_BITIS_TARIHI.Replace(" 00:00:00", "") + " Kayıtlarımızda firmanız ile ilgili Form " + _MUTABAKAT_FORM_TURU + " Bilgileri aşağıdadır.<br> Mutabık olup olmadığınızı yanıtlamanızı rica ederiz.")

                  .Replace("VERGI_NO", SelectDrRow["VKN"].ToString())
                  .Replace("DONEMI", "2015-01-01")
                  .Replace("EVRAK_SAYISI", SelectDrRow["ADET"].ToString())
                  .Replace("TOPLAM_TUTAR", SelectDrRow["BAKIYE"].ToString())
                  .Replace("DOKUMANLAR", "MX20150000001444")
                  .Replace("TELEFON", _GLOBAL_PARAMETERS._TELEFON)
                  .Replace("FAX", _GLOBAL_PARAMETERS._FAKS)
                  .Replace("ADRES", _GLOBAL_PARAMETERS._ADRES)
                  .Replace("ACIKLAMA", _MUTABAKAT_ACIKLAMASI)
                  .Replace("MUTABAKAT_SORUMLUSU", _GLOBAL_PARAMETERS._KULLANICI_ADI_SOYADI)
                  .Replace("EMAIL_ONAY_LINKI", EMAIL_ONAY_LINKI)
                  .Replace("WEB_ONAY_LINKI", WEB_ONAY_LINKI);

                   StringBuilder mesaj = new StringBuilder();//dr["EMAIL"].ToString() 
                   mesaj.Append(MUTABAKAT_FORMU_TMP);
                   WebServices.SALES_INVOICES mail = new WebServices.SALES_INVOICES();
                   mail.SendMailAsync(_GLOBAL_PARAMETERS._KULLANICI_MAIL, "hasan.yogurtcu@groupm.com" , _MUTABAKAT_DONEMI+" Mutabakat onay/bilgilendirme mailidir. ", mesaj.ToString(), "");
                   mail.SendMailCompleted += fr_SendMailCompleted;
               }
        }

        int selectrowcount = -1;
        private void fr_SendMailCompleted(object sender, WebServices.SendMailCompletedEventArgs e)
        {
                selectrowcount++;
                SelectDrRow = gridView_MUTABAKAT_LISTESI.GetDataRow(selectedRows[selectrowcount]);
                DateTime dtm = DateTime.Now;
                if (e.Result)
                {
                   /// GATE_DB VERİ YAZILDI 
                   using (SqlConnection qcon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["_CONNECTIONSTRING_WEB"].ConnectionString))
                   {
                       qcon.Open();
                       using (SqlCommand cmd = new SqlCommand())
                       {
                           string LINE_SQL = @" INSERT INTO dbo.FTR_MUTABAKAT (SIRKET_KODU, GUID, FORM_TURU, UNVANI, DONEM_BILGISI, VERGI_NO, TUTAR    )  
                                                                             Values  (@SIRKET_KODU,@GUID, @FORM_TURU, @UNVANI, @DONEM_BILGISI, @VERGI_NO, @TUTAR )";

                           cmd.CommandText = LINE_SQL;
                           cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                           cmd.Parameters.AddWithValue("@MUTABAKAT_KODU", _MUTABAKAT_KODU);
                           cmd.Parameters.AddWithValue("@GUID", SelectDrRow["GUID"].ToString().ToUpper());
                           cmd.Parameters.AddWithValue("@FORM_TURU", _MUTABAKAT_FORM_TURU);
                           cmd.Parameters.AddWithValue("@DONEM_BILGISI", _MUTABAKAT_DONEMI);
                           cmd.Parameters.AddWithValue("@UNVANI", SelectDrRow["CARI_ADI"]);
                           cmd.Parameters.AddWithValue("@VERGI_NO", SelectDrRow["VKN"]);
                           cmd.Parameters.AddWithValue("@TUTAR", SelectDrRow["BAKIYE"]);
                           cmd.Parameters.AddWithValue("@ADET", SelectDrRow["ADET"]);
                           cmd.Connection = qcon;
                           cmd.ExecuteNonQuery();
                       }
                   }
                    
                   using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                   {
                       myConnections.Open();
                       string SQL_ROW = @" UPDATE FTR_FATURA_MUTABAKAT SET ILETISIM_DURUMU=@ILETISIM_DURUMU,MAIL_TARIH=@MAIL_TARIH,MAIL_SAAT=@MAIL_SAAT  Where SIRKET_KODU=@SIRKET_KODU AND GUID=@GUID ";
                       using (SqlCommand cmd = new SqlCommand())
                       {
                           cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                           cmd.Parameters.AddWithValue("@ILETISIM_DURUMU", "TRUE");
                           cmd.Parameters.AddWithValue("@MAIL_TARIH", dtm.ToString("yyyy-MM-dd"));
                           cmd.Parameters.AddWithValue("@MAIL_SAAT", dtm.ToString("hh:mm:ss"));
                           cmd.Parameters.AddWithValue("@GUID", SelectDrRow["GUID"]);
                           cmd.CommandText = SQL_ROW;
                           cmd.Connection = myConnections;
                           cmd.ExecuteNonQuery();
                           SelectDrRow["ILETISIM_DURUMU"] = "TRUE";

                       }
                   }

               }
               else
               {
                   using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                   {
                       myConnections.Open();
                       string SQL_ROW = @" UPDATE FTR_FATURA_MUTABAKAT SET ILETISIM_DURUMU=@ILETISIM_DURUMU,MAIL_TARIH=@MAIL_TARIH,MAIL_SAAT=@MAIL_SAAT  Where SIRKET_KODU=@SIRKET_KODU AND GUID=@GUID ";
                       using (SqlCommand cmd = new SqlCommand())
                       {
                           cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                           cmd.Parameters.AddWithValue("@ILETISIM_DURUMU", "FALSE");
                           cmd.Parameters.AddWithValue("@MAIL_TARIH", dtm.ToString("yyyy-MM-dd"));
                           cmd.Parameters.AddWithValue("@MAIL_SAAT", dtm.ToString("hh:mm:ss"));
                           cmd.Parameters.AddWithValue("@GUID", SelectDrRow["GUID"]);
                           cmd.CommandText = SQL_ROW;
                           cmd.Connection = myConnections;
                           cmd.ExecuteNonQuery();
                           SelectDrRow["ILETISIM_DURUMU"] = "FALSE";

                       }
                   }

               }
             
        }

        private void BR_YENI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MUTABAKAT_GIRIS frm = new MUTABAKAT_GIRIS();
            frm.ShowDialog();
        }

        private void BR_OPEN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MUTABAKAT_LIST frmlst = new MUTABAKAT_LIST();
            frmlst.ShowDialog();
            if (frmlst._MUTABAKAT_KODU != null)
            {
               BR_MUTABAKAT_KODU.Caption = _MUTABAKAT_KODU = frmlst._MUTABAKAT_KODU;
               BR_SIRKET_KODU.Caption =_GLOBAL_PARAMETERS._SIRKET_KODU.ToString();
               _MUTABAKAT_FORM_TURU = frmlst._MUTABAKAT_FORM_TURU;
               _MUTABAKAT_BAS_TARIHI = frmlst._MUTABAKAT_BAS_TARIHI;
               _MUTABAKAT_BITIS_TARIHI = frmlst._MUTABAKAT_BITIS_TARIHI;
               _MUTABAKAT_ACIKLAMASI = frmlst._MUTABAKAT_ACIKLAMASI;
               _MUTABAKAT_DONEMI = frmlst._MUTABAKAT_DONEMI; 

                DATA_LOAD();
            } 
        }

        private void BR_ERP_ROW_SELECT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (BR_MUTABAKAT_KODU.Caption == "") { MessageBox.Show("Mutabakat Planı Açınız."); }
            else
            {

                MUTABAKAT_ERP_LIST erpfrp = new MUTABAKAT_ERP_LIST();
                erpfrp.ShowDialog(); 

                try
                {
                    SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                    myConnection.Open();
                    gridView_MUTABAKAT_LISTESI.BeginUpdate();
                    for (int i = 0; i < erpfrp.rows.Count; i++)
                    {
                        Guid gx = Guid.NewGuid();
                        Guid gy = Guid.NewGuid();
                        Guid gz = Guid.NewGuid();
                        Guid gw = Guid.NewGuid(); 
                        string GUID = gx.ToString() + gy.ToString() + gz.ToString() + gw.ToString(); 

                        DataRow row = erpfrp.rows[i] as DataRow;
                        // Change the field value.
                        DataRow rows = MyDataSet.Tables[0].NewRow();
                        rows["GUID"] = GUID.ToString();
                        rows["CARI_KODU"] = row["CARI_KODU"];
                        rows["CARI_ADI"] = row["CARI_ADI"];
                        rows["EMAIL"] = row["EMAIL"];
                        rows["VKN"] = row["VKN"];
                        rows["TCK"] = row["TCK"];
                        rows["BORC"] = row["BORC"];
                        rows["ALACAK"] = row["ALACAK"];
                        rows["BAKIYE"] = row["BAKIYE"];
                        rows["ADET"] = row["ADET"]; 
                        MyDataSet.Tables[0].Rows.Add(rows);  
                        
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            string LINE_SQL = @" INSERT INTO dbo.FTR_FATURA_MUTABAKAT (SIRKET_KODU, MUTABAKAT_KODU,GUID,CARI_KODU,CARI_ADI, EMAIL,VKN,  TCK, BORC, ALACAK, BAKIYE ,ADET     )  
                                                                             Values (@SIRKET_KODU,@MUTABAKAT_KODU,@GUID,@CARI_KODU,@CARI_ADI,@EMAIL,@VKN,  @TCK, @BORC, @ALACAK, @BAKIYE, @ADET  )";


                            cmd.CommandText = LINE_SQL;
                            //cmd.Parameters.AddWithValue("@GUID", g);
                            //cmd.Parameters.AddWithValue("@FATURA_TIPI", 'E'); 
                            cmd.Parameters.AddWithValue("@MUTABAKAT_KODU", _MUTABAKAT_KODU);
                            cmd.Parameters.AddWithValue("@GUID", GUID.ToString().ToUpper()); 
                            cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString()); 
                            cmd.Parameters.AddWithValue("@CARI_KODU", rows["CARI_KODU"]);
                            cmd.Parameters.AddWithValue("@CARI_ADI", rows["CARI_ADI"]);
                            cmd.Parameters.AddWithValue("@EMAIL", rows["EMAIL"]);
                            cmd.Parameters.AddWithValue("@VKN", rows["VKN"]);
                            cmd.Parameters.AddWithValue("@TCK", rows["TCK"]);
                            cmd.Parameters.AddWithValue("@BORC", rows["BORC"]);
                            cmd.Parameters.AddWithValue("@ALACAK", rows["ALACAK"]);
                            cmd.Parameters.AddWithValue("@BAKIYE", rows["BAKIYE"]);
                            cmd.Parameters.AddWithValue("@ADET", rows["ADET"]); 
                            cmd.Connection = myConnection;
                            cmd.ExecuteNonQuery();
                        } 
                    }
                }
                finally
                {
                    gridView_MUTABAKAT_LISTESI.EndUpdate();
                }
            }
         
        }



        private void DATA_LOAD()
        {
    
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string SQL = @"SELECT  * FROM FTR_FATURA_MUTABAKAT  WHERE SIRKET_KODU=@SIRKET_KODU AND MUTABAKAT_KODU=@MUTABAKAT_KODU ";      
                SqlDataAdapter da = new SqlDataAdapter(SQL, myConnection);
                da.SelectCommand.Parameters.AddWithValue("@SIRKET_KODU",_GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                da.SelectCommand.Parameters.AddWithValue("@MUTABAKAT_KODU", _MUTABAKAT_KODU); 
                MyDataSet = new DataSet();
                da.Fill(MyDataSet, "dbo_USER");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                GRD_LISTE.DataSource = dv;
            }

        }

        private void BTN_DURUM_GUNCELLE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (SqlCon.State.ToString() == "Closed") SqlCon.Open();
       
            int[] selectedRows = gridView_MUTABAKAT_LISTESI.GetSelectedRows();
            for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
            {
                DataRow dr = gridView_MUTABAKAT_LISTESI.GetDataRow(selectedRows[ix]);
                if (dr == null) break;
                GIB_DURUM_KONTROL(dr);
            }

            
        }
        private void GIB_DURUM_KONTROL(DataRow dr)
        {
            using (SqlCommand myCommand = new SqlCommand("SELECT * FROM  FTR_MUTABAKAT  Where SIRKET_KODU=@SIRKET_KODU AND GUID=@GUID  ", SqlCon))
            {
                myCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                myCommand.Parameters.AddWithValue("@GUID",dr["GUID"]);
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                    {
                        myConnections.Open();
                        string SQL_ROW = @" UPDATE FTR_FATURA_MUTABAKAT SET DURUM=@DURUM,ONAYLAYAN_TARIH=@ONAYLAYAN_TARIH,ONAYLAYAN_SAAT=@ONAYLAYAN_SAAT,ONAYLAYAN_IP=@ONAYLAYAN_IP  Where SIRKET_KODU=@SIRKET_KODU AND GUID=@GUID ";
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                            cmd.Parameters.AddWithValue("@DURUM", myReader["DURUM"]);
                            cmd.Parameters.AddWithValue("@GUID", dr["GUID"]);
                            cmd.Parameters.AddWithValue("@ONAYLAYAN_TARIH", myReader["ONAYLAYAN_TARIH"]);
                            cmd.Parameters.AddWithValue("@ONAYLAYAN_SAAT", myReader["ONAYLAYAN_SAAT"]);
                            cmd.Parameters.AddWithValue("@ONAYLAYAN_IP", myReader["ONAYLAYAN_IP"]);
                            cmd.CommandText = SQL_ROW;
                            cmd.Connection = myConnections;
                            cmd.ExecuteNonQuery();
                            dr["DURUM"] = myReader["DURUM"];
                            dr["GUID"] = myReader["GUID"];
                            dr["ONAYLAYAN_TARIH"] = myReader["ONAYLAYAN_TARIH"];
                            dr["ONAYLAYAN_SAAT"] = myReader["ONAYLAYAN_SAAT"];
                            dr["ONAYLAYAN_IP"] = myReader["ONAYLAYAN_IP"];  

                        }
                    }
                }
                myReader.Close();
            } 
         }

        private void GRD_LISTE_Click(object sender, EventArgs e)
        {

        }

        private void BR_GRID_EXCEL_EXPORT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

       
    }
}