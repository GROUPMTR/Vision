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
//using EvernoteIFLib;
//using JOBUTILITYLib.;

namespace VISION.FINANS.FATURA._SCAN
{
    public partial class SATIS_FATURASI : DevExpress.XtraEditors.XtraForm
    {
        int id = 0;
        public string SELECT_BUTTON = "CANCEL";
        public SATIS_FATURASI(int ID)
        {
            InitializeComponent(); 
            ControlBox = false; 

            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent; 
        
            DATE_FATURA_TARIHI.Text = DateTime.Now.ToShortDateString(); 

            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string mySelectQuery = "  SELECT  * from dbo.ADM_SIRKET  ";
                SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
                myCommand.CommandText = mySelectQuery.ToString();
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    CMB_SIRKET_KODU.Properties.Items.Add(myReader["SIRKET_KODU"].ToString());
                } 
            }  
    
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string mySelectQuery = "  SELECT  * from dbo.ADM_MUSTERI WHERE SIRKET_KODU='" + _GLOBAL_PARAMETERS._SIRKET_KODU + "'";
                SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
                myCommand.CommandText = mySelectQuery.ToString();
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    COM_BX_MUSTERI_UNVANI.Properties.Items.Add(myReader["MUSTERI_KODU"].ToString());
                } 
            } 


            if (ID != 0) { id = ID; _DATA_LOAD(ID); }          
        }


        private void CMB_SIRKET_KODU_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMB_SIRKET_KODU.EditValue != null)
            {

                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                {
                    string mySelectQuery = "  SELECT  * from  dbo.ADM_SIRKET WHERE SIRKET_KODU='" + CMB_SIRKET_KODU.EditValue.ToString() + "' ";
                    SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);

                    myCommand.CommandText = mySelectQuery.ToString();
                    myConnection.Open();
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                    myConnections.Open();
                    while (myReader.Read())
                    {
                        //TXT_SIRKET_ADI.Text = myReader["ADI"].ToString();
                        //TXT_SIRKET_ADRESI.Text = myReader["ADRESI"].ToString();
                        //TXT_SIRKET_IL.Text = myReader["IL"].ToString();
                        //TXT_SIRKET_VKN.Text = myReader["VERGI_NO"].ToString();
                        //TXT_SIRKET_VD.Text = myReader["VERGI_DAIRESI"].ToString();
                    }
                }
            }
        }


        private void CMB_SIRKET_UNVANI_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }


        private void COM_BX_MUSTERI_UNVANI_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (CMB_SIRKET_UNVANI.EditValue != null)
            //{

            //    using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            //    {
            //        string mySelectQuery = "  SELECT  * from  dbo.ADM_MUSTERI  WHERE ADI='" + CMB_SIRKET_UNVANI.EditValue.ToString() + "' ";
            //        SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);

            //        myCommand.CommandText = mySelectQuery.ToString();
            //        myConnection.Open();
            //        SqlDataReader myReader = myCommand.ExecuteReader();
            //        SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            //        myConnections.Open();
            //        while (myReader.Read())
            //        {
            //            TXT_MUSTERI_KODU.Text = myReader["MUSTERI_KODU"].ToString();
            //        }
            //    }
            //}
        }

        private void _DATA_LOAD(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string mySelectQuery = "  SELECT  * from  dbo.FTR_GIB_TRANSFER WHERE SIRKET_KODU= " + _GLOBAL_PARAMETERS._SIRKET_KODU.ToString() + " AND   ID=" + ID;
                SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);

                myCommand.CommandText = mySelectQuery.ToString();
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                myConnections.Open();
                while (myReader.Read())
                {
                    DATE_FATURA_TARIHI.Text = myReader["FATURATARIH"].ToString(); 
                    TXT_FATURANO.Text = myReader["DOKUMAN_NO"].ToString();
                    CMB_MECRA_TURU.Text = myReader["MECRA_TURU"].ToString();
                    COM_BX_MUSTERI_UNVANI.Text = myReader["MUSTERI"].ToString();
                    TXT_FATURATUTARI.Text = myReader["GENELTOPLAM"].ToString();
                    TXT_NOTU.Text = myReader["ACIKLAMA"].ToString();
                } 
            }
        }
        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barBTN_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (id == 0)
            {
                __Kaydet(); 
                Close();
            }
            else
            {
                __Guncelle(id);

            }
            SELECT_BUTTON = "OK";
        }
        private void __Kaydet()
        {
            SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            myConnectionTable.Open();
            SqlCommand myCmd = new SqlCommand(); 
             Guid g = Guid.NewGuid();
            using (SqlCommand cmd = new SqlCommand())
            {
                string HEADER_TABLE_SQL = @" INSERT INTO dbo.FTR_GIB_TRANSFER (SIRKET_KODU,FATURA_TIPI,ID,GUID,  FATURATARIH,ACIKLAMA,PARA_BIRIMI,HESAPLANANKDV,TOPLAMTUTAR,MUSTERI_KODU,MUSTERI,PLAN_KODU,FATURA_TURU,MECRA_TURU,MECRA_KODU )   
                                                           Values 
                                                           (
                                                            @SIRKET_KODU,@FATURA_TIPI,@ID,@GUID,  @FATURATARIH,@ACIKLAMA,@PARA_BIRIMI,@HESAPLANANKDV,@TOPLAMTUTAR,@MUSTERI_KODU,@MUSTERI,@PLAN_KODU,@FATURA_TURU,@MECRA_TURU,@MECRA_KODU
                                                            )  SELECT @@IDENTITY AS ID   ";        
  

               DateTime dt = DateTime.Parse(DATE_FATURA_TARIHI.Text);

                                                       
                cmd.CommandText = HEADER_TABLE_SQL;
                cmd.Parameters.AddWithValue("@SIRKET_KODU", CMB_SIRKET_KODU.Text.ToString());
                cmd.Parameters.AddWithValue("@FATURA_TIPI", 'P');                
                cmd.Parameters.AddWithValue("@ID", TXT_FATURANO.Text);
                cmd.Parameters.AddWithValue("@GUID", g);
                cmd.Parameters.AddWithValue("@FATURATARIH", dt.ToString("yyyy.MM.dd").ToString());
                cmd.Parameters.AddWithValue("@ACIKLAMA", TXT_NOTU.Text);
                cmd.Parameters.AddWithValue("@PARA_BIRIMI", COM_BX_PB.Text);
                cmd.Parameters.AddWithValue("@HESAPLANANKDV", float.Parse(TXT_KDVTUTARI.Text));
                cmd.Parameters.AddWithValue("@TOPLAMTUTAR", float.Parse(TXT_FATURATUTARI.Text)); 
                cmd.Parameters.AddWithValue("@MUSTERI_KODU", TXT_MUSTERI_KODU.Text);
                cmd.Parameters.AddWithValue("@MUSTERI", COM_BX_MUSTERI_UNVANI.Text);
                cmd.Parameters.AddWithValue("@PLAN_KODU", TXT_MEDPLANKODU.Text);
                cmd.Parameters.AddWithValue("@FATURA_TURU", CMB_FATURA_TURU.Text);
                cmd.Parameters.AddWithValue("@MECRA_TURU", CMB_MECRA_TURU.Text);
                cmd.Parameters.AddWithValue("@MECRA_KODU", CMB_MECRA_KODU.Text);
                //cmd.Parameters.AddWithValue("@FATURA_YENI", '1');
                //cmd.Parameters.AddWithValue("@PLAN_KODU", PLAN_KODU);
                cmd.Connection = myConnectionTable;
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
       }
 
      
        private void __Guncelle(int ID)
        {
            SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            myConnectionTable.Open();
            SqlCommand myCmd = new SqlCommand();
            myCmd.CommandText =
            " UPDATE    dbo.PRNGELEN_" + _GLOBAL_PARAMETERS._SIRKET_KODU.ToString() + "_01   " +
                     " SET GELIS_TARIHI=@GELIS_TARIHI,DOKUMAN_TARIHI=@DOKUMAN_TARIHI,PAZARLAMA_SIRKETI=@PAZARLAMA_SIRKETI,DOKUMAN_NO=@DOKUMAN_NO,MECRA_TURU=@MECRA_TURU,MUSTERI_KODU=@MUSTERI_KODU,MUSTERI_ADI=@MUSTERI_ADI," +
                     " FATURA_TOPLAMI=@FATURA_TOPLAMI,KDV_TUTARI=@KDV_TUTARI,GENEL_TOPLAM=@GENEL_TOPLAM, PB=@PB,KUR=@KUR,DIREKTOR=@DIREKTOR, DOKUMAN_NOTU=@DOKUMAN_NOTU,PB=@PB,KUR=@KUR WHERE (ID = '" + ID + "')";



 
            myCmd.Parameters.Add("@DOKUMAN_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@DOKUMAN_TARIHI"].Value = DATE_FATURA_TARIHI.Text;
    
            myCmd.Parameters.Add("@DOKUMAN_NO", SqlDbType.NVarChar); myCmd.Parameters["@DOKUMAN_NO"].Value = TXT_FATURANO.Text;
            myCmd.Parameters.Add("@MECRA_TURU", SqlDbType.NVarChar); myCmd.Parameters["@MECRA_TURU"].Value = CMB_MECRA_TURU.Text;
            myCmd.Parameters.Add("@MUSTERI_KODU", SqlDbType.NVarChar); myCmd.Parameters["@MUSTERI_KODU"].Value = TXT_MUSTERI_KODU.Text;
            myCmd.Parameters.Add("@MUSTERI_ADI", SqlDbType.NVarChar); myCmd.Parameters["@MUSTERI_ADI"].Value = COM_BX_MUSTERI_UNVANI.Text;
            //myCmd.Parameters.Add("@DOKUMAN_TUTARI", SqlDbType.Float); myCmd.Parameters["@DOKUMAN_TUTARI"].Value = TXT_FATURATUTARI.Text.Replace(",", ".");
            myCmd.Parameters.Add("@FATURA_TOPLAMI", SqlDbType.Float); myCmd.Parameters["@FATURA_TOPLAMI"].Value = TXT_FATURATUTARI.Text.Replace(",", ".");
            myCmd.Parameters.Add("@KDV_TUTARI", SqlDbType.Float); myCmd.Parameters["@KDV_TUTARI"].Value = TXT_KDVTUTARI.Text.Replace(",", ".");
            myCmd.Parameters.Add("@GENEL_TOPLAM", SqlDbType.Float); myCmd.Parameters["@GENEL_TOPLAM"].Value = TXT_GENELTUTARI.Text.Replace(",", ".");
   
            myCmd.Parameters.Add("@DOKUMAN_NOTU", SqlDbType.NVarChar); myCmd.Parameters["@DOKUMAN_NOTU"].Value = TXT_NOTU.Text;
            myCmd.Parameters.Add("@PB", SqlDbType.NVarChar); myCmd.Parameters["@PB"].Value = COM_BX_PB.Text;
            myCmd.Parameters.Add("@KUR", SqlDbType.Float); myCmd.Parameters["@KUR"].Value = TXT_KUR.Text;
            myCmd.Connection = myConnectionTable;
            myCmd.ExecuteNonQuery();
            myCmd.Connection.Close();

           MessageBox.Show("Güncelleme işlemi yapıldı", "UYARI");

        }

        private void BTN_REFRESH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

 

             

        }


      

      
    }
}