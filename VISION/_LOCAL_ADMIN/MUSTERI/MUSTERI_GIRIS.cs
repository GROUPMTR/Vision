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

namespace VISION._LOCAL_ADMIN.MUSTERI
{
    public partial class MUSTERI_GIRIS : DevExpress.XtraEditors.XtraForm
    {
        public MUSTERI_GIRIS()
        {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent; 
        }

        private void BR_YENI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lbID.Caption = null;
            CMBOX_ARSIV.Text = null;
            CMBOX_FIRMATIPI.Text = null;
            CMBOX_CREATIVE_AJANS.Text = null;
            CMBOX_TC_KIMLIK_NO.Text = null;
            CMBOX_SATIN_ALMA_SIRKETI.Text = null;
            CMBOX_MUSTERI_GRUBU.Text = null;
            TXT_MUSTERI_KODU.Text = null;
            TXT_MUSTERI_ADI.Text = null; 
            CMBOX_SEHIR.Text = null;
            CMBOX_ILCE.Text = null;
            CMBOX_SOZLESMESI.Text = null;
            CMBOX_MECRA_FATURASI.Text = null;
        }

        private void BR_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lbID.Caption !=null)
            {
                GUNCELLE();
            } 
            else 
            {
                if (TXT_MUSTERI_KODU.Text == null)  
                    KAYDET(); 
                else
                    MessageBox.Show("Müşteri Kodu Giriniz.");
            } 
        }
        private void GUNCELLE()
        {
            SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            myConnectionTable.Open();
            SqlCommand myCmd = new SqlCommand();
            myCmd.CommandText = " Update dbo.ADM_MUSTERI SET    MUSTERI_GRUBU=@MUSTERI_GRUBU,    MUSTERI_KODU=@MUSTERI_KODU,  ADI=@ADI,  IL=@IL, ILCE=@ILCE   WHERE (ID = '" + lbID.Caption + "')";

    
            myCmd.Parameters.Add("@MUSTERI_GRUBU", SqlDbType.NVarChar); myCmd.Parameters["@MUSTERI_GRUBU"].Value = CMBOX_MUSTERI_GRUBU.Text; 
            myCmd.Parameters.Add("@MUSTERI_KODU", SqlDbType.NVarChar); myCmd.Parameters["@MUSTERI_KODU"].Value = TXT_MUSTERI_KODU.Text; 
            myCmd.Parameters.Add("@ADI", SqlDbType.NVarChar); myCmd.Parameters["@ADI"].Value = TXT_MUSTERI_ADI.Text; 
            myCmd.Parameters.Add("@TC_KIMLIK_NO", SqlDbType.NVarChar); myCmd.Parameters["@TC_KIMLIK_NO"].Value = CMBOX_TC_KIMLIK_NO.Text;
            myCmd.Parameters.Add("@IL", SqlDbType.NVarChar); myCmd.Parameters["@IL"].Value = CMBOX_SEHIR.Text;
            myCmd.Parameters.Add("@ILCE", SqlDbType.NVarChar); myCmd.Parameters["@ILCE"].Value = CMBOX_ILCE.Text;
 
            myCmd.Connection = myConnectionTable;
            myCmd.ExecuteNonQuery();
            myCmd.Connection.Close();

        }
        private void KAYDET()
        {
            SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            myConnectionTable.Open();
            SqlCommand myCmd = new SqlCommand();
            myCmd.CommandText = " INSERT INTO  dbo.ADM_MUSTERI ( SIRKET_KODU,SAHIS_SIRKET , CREATIVE_AJANS_KODU, SATINALMA_SIRKETI_KODU, AKTIF_PASIF, MUSTERI_GRUBU,   MUSTERI_KODU,  ADI,  TC_KIMLIK_NO, IL, ILCE  )" +
                                                     " Values  (@SIRKET_KODU, @SAHIS_SIRKET, @CREATIVE_AJANS_KODU, @SATINALMA_SIRKETI_KODU, @AKTIF_PASIF, @MUSTERI_GRUBU,  @MUSTERI_KODU,   @ADI, @TC_KIMLIK_NO, @IL, @ILCE)  SELECT @@IDENTITY AS ID    ";
            myCmd.Parameters.Add("@SIRKET_KODU", SqlDbType.NVarChar); myCmd.Parameters["@SIRKET_KODU"].Value = _GLOBAL_PARAMETERS._MUSTERI_KODU.ToString();
            myCmd.Parameters.Add("@SAHIS_SIRKET", SqlDbType.NVarChar); myCmd.Parameters["@SAHIS_SIRKET"].Value = CMBOX_CREATIVEAJANS.Text.ToString();
            myCmd.Parameters.Add("@CREATIVE_AJANS_KODU", SqlDbType.NVarChar); myCmd.Parameters["@CREATIVE_AJANS_KODU"].Value = CMBOX_CREATIVEAJANS.Text.ToString();
            myCmd.Parameters.Add("@SATINALMA_SIRKETI_KODU", SqlDbType.NVarChar); myCmd.Parameters["@SATINALMA_SIRKETI_KODU"].Value = CMBOX_SATIN_ALMA_SIRKETI.Text.ToString();
            myCmd.Parameters.Add("@AKTIF_PASIF", SqlDbType.NVarChar); myCmd.Parameters["@AKTIF_PASIF"].Value = CMBOX_ARSIV.Text;
            myCmd.Parameters.Add("@MUSTERI_GRUBU", SqlDbType.NVarChar); myCmd.Parameters["@MUSTERI_GRUBU"].Value = CMBOX_MUSTERI_GRUBU.Text;
 
            myCmd.Parameters.Add("@MUSTERI_KODU", SqlDbType.NVarChar); myCmd.Parameters["@MUSTERI_KODU"].Value = TXT_MUSTERI_KODU.Text;
 
            myCmd.Parameters.Add("@ADI", SqlDbType.NVarChar); myCmd.Parameters["@ADI"].Value = TXT_MUSTERI_ADI.Text;

            myCmd.Parameters.Add("@TC_KIMLIK_NO", SqlDbType.NVarChar); myCmd.Parameters["@TC_KIMLIK_NO"].Value = CMBOX_TC_KIMLIK_NO.Text;
            myCmd.Parameters.Add("@IL", SqlDbType.NVarChar); myCmd.Parameters["@IL"].Value = CMBOX_SEHIR.Text;
            myCmd.Parameters.Add("@ILCE", SqlDbType.NVarChar); myCmd.Parameters["@ILCE"].Value = CMBOX_ILCE.Text;
            myCmd.Parameters.Add("@MECRA_FATURASI_KIME", SqlDbType.NVarChar); myCmd.Parameters["@MECRA_FATURASI_KIME"].Value = CMBOX_MECRA_FATURASI.Text;
            myCmd.Connection = myConnectionTable;
            SqlDataReader myReader = myCmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (myReader.Read())
            {
                lbID.Caption = myReader["ID"].ToString();
            }
            myReader.Close();
            myCmd.Connection.Close();
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}