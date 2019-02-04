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

namespace VISION._LOCAL_ADMIN._TEMP
{
    public partial class INVTRNASFER : DevExpress.XtraEditors.XtraForm
    {
        public INVTRNASFER()
        {
            InitializeComponent();
            this.Tag = "MDIFORM";
        }
        DataSet ds;

        private void BTN_REFRESH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
 
         //   string con = "Password=nabuKad_07;Persist Security Info=True;User ID=grm_sa;Initial Catalog=WeSOURCE;Data Source=10.219.168.92";
            
            using (SqlConnection MySqlConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP))//_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString()
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * from INVTRNS where FIRMA_KODU='"+BTN_FIRMA.EditValue+"'", MySqlConnection);
                ds = new DataSet();
                da.Fill(ds, "Header");
                DataViewManager dvManager = new DataViewManager(ds);
                DataView dv = dvManager.CreateDataView(ds.Tables[0]);
                GRD_LISTE.DataSource = dv;
            }
        }

        private void BTN_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

      

        private void BTN_LOGO_SECILENLERI_AKATAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
               SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                    myConnectionTable.Open();
                    re_PROGRESS_BAR.Maximum = ds.Tables["Header"].Rows.Count;
                    int OIID = 0;
                   // var GUID = "";
                    for (int index = 0; index < ds.Tables["Header"].Rows.Count; index++)
                    {
                        BR_PROGRESS_BAR.EditValue = index;
                        BR_PROGRESS_BAR.Refresh();
                        OIID = 0;// GUID = Guid.NewGuid().ToString();
                        Guid GUID = Guid.NewGuid();
                        DataRow dr = ds.Tables["Header"].Rows[index];
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            string HEADER_TABLE_SQL = " INSERT INTO dbo.FTR_GIB_TRANSFER ( SIRKET_KODU,GUID, ID, INVID, GID, SESSIONID, SONUC, TXN_ID, [FILE], FIRMA, DONEM, KONTROL, DURUM_KODU, MESAJ, Tarih, FRM, VKN, SICILNO, MUSTERI, ACIKLAMA, FATURATARIH, PROFILID, TIP, TOPLAMTUTAR, HESAPLANANKDV, TOPLAMINDIRIM, GENELTOPLAM, SENDMAIL, GIB_STATUS_CODE, GIB_STATUS_DESCRIPTION, RESPONSE_CODE, RESPONSE_DESCRIPTION, STATUS, STATUS_DESCRIPTION, FIRMA_KODU,FATURA_TIPI)  " +
                                                                    " Values (@SIRKET_KODU,@GUID, @ID, @INVID, @GID, @SESSIONID, @SONUC, @TXN_ID, @FILE, @FIRMA, @DONEM, @KONTROL, @DURUM_KODU, @MESAJ, @Tarih, @FRM, @VKN, @SICILNO, @MUSTERI, @ACIKLAMA, @FATURATARIH, @PROFILID,@TIP, @TOPLAMTUTAR, @HESAPLANANKDV, @TOPLAMINDIRIM, @GENELTOPLAM, @SENDMAIL, @GIB_STATUS_CODE, @GIB_STATUS_DESCRIPTION, @RESPONSE_CODE, @RESPONSE_DESCRIPTION, @STATUS, @STATUS_DESCRIPTION, @FIRMA_KODU,@FATURA_TIPI)" +
                                                                    "  SELECT @@IDENTITY AS ID   ";
                            cmd.CommandText = HEADER_TABLE_SQL;
                            cmd.Parameters.AddWithValue("@SIRKET_KODU", BTN_FIRMA.EditValue);
                            cmd.Parameters.AddWithValue("@GUID", GUID); 
                            cmd.Parameters.AddWithValue("@ID", dr["ID"]);
                            cmd.Parameters.AddWithValue("@INVID", dr["INVID"]);
                            cmd.Parameters.AddWithValue("@GID", dr["GID"]);
                            cmd.Parameters.AddWithValue("@SESSIONID", dr["SESSIONID"]);
                            cmd.Parameters.AddWithValue("@SONUC", dr["SONUC"]);
                            cmd.Parameters.AddWithValue("@TXN_ID", dr["TXN_ID"]);
                            cmd.Parameters.AddWithValue("@FILE", dr["FILE"]);
                            cmd.Parameters.AddWithValue("@FIRMA", dr["FIRMA"]);
                            cmd.Parameters.AddWithValue("@DONEM", dr["DONEM"]);
                            cmd.Parameters.AddWithValue("@KONTROL", dr["KONTROL"]);
                            cmd.Parameters.AddWithValue("@DURUM_KODU", dr["DURUM_KODU"]);
                            cmd.Parameters.AddWithValue("@MESAJ", dr["MESAJ"]);
                            cmd.Parameters.AddWithValue("@Tarih", dr["Tarih"]);
                            cmd.Parameters.AddWithValue("@FRM", dr["FRM"]);
                            cmd.Parameters.AddWithValue("@VKN", dr["VKN"]);
                            cmd.Parameters.AddWithValue("@SICILNO", dr["SICILNO"]);
                            cmd.Parameters.AddWithValue("@MUSTERI", dr["MUSTERI"]);
                            cmd.Parameters.AddWithValue("@ACIKLAMA", dr["ACIKLAMA"]);
                            cmd.Parameters.AddWithValue("@FATURATARIH", dr["FATURATARIH"]);
                            cmd.Parameters.AddWithValue("@PROFILID", dr["PROFILID"]);
                            cmd.Parameters.AddWithValue("@TIP", dr["TIP"]);
                            cmd.Parameters.AddWithValue("@TOPLAMTUTAR", dr["TOPLAMTUTAR"]);
                            cmd.Parameters.AddWithValue("@HESAPLANANKDV", dr["HESAPLANANKDV"]);
                            cmd.Parameters.AddWithValue("@TOPLAMINDIRIM", dr["TOPLAMINDIRIM"]);
                            cmd.Parameters.AddWithValue("@GENELTOPLAM", dr["GENELTOPLAM"]);
                            cmd.Parameters.AddWithValue("@SENDMAIL", dr["SENDMAIL"]);
                            cmd.Parameters.AddWithValue("@GIB_STATUS_CODE", dr["GIB_STATUS_CODE"]);
                            cmd.Parameters.AddWithValue("@GIB_STATUS_DESCRIPTION", dr["GIB_STATUS_DESCRIPTION"]);
                            cmd.Parameters.AddWithValue("@RESPONSE_CODE", dr["RESPONSE_CODE"]);
                            cmd.Parameters.AddWithValue("@RESPONSE_DESCRIPTION", dr["RESPONSE_DESCRIPTION"]);
                            cmd.Parameters.AddWithValue("@STATUS", dr["STATUS"]);
                            cmd.Parameters.AddWithValue("@STATUS_DESCRIPTION", dr["STATUS_DESCRIPTION"]);
                            cmd.Parameters.AddWithValue("@FIRMA_KODU", dr["FIRMA_KODU"]);
                            cmd.Parameters.AddWithValue("@FATURA_TIPI", "E");
                            cmd.Connection = myConnectionTable;
                            SqlDataReader myReader = cmd.ExecuteReader();
                            while (myReader.Read())
                            {
                                //OIID = Convert.ToInt32(myReader["ID"].ToString());
                            }
                            myReader.Close();
                        }
                    }
        }
    }
}