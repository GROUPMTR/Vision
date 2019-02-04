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

namespace VISION.FINANS.FATURA.ALIS_FATURASI
{
    public partial class ALIS_FATURASI_GIRIS_ON : DevExpress.XtraEditors.XtraForm
    {
        int id = 0;
        public string SELECT_BUTTON = "CANCEL";
        public ALIS_FATURASI_GIRIS_ON(int ID)
        {
            InitializeComponent(); 
            ControlBox = false; 

            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent; 
            DATE_GELISTARIHI.Text = DateTime.Now.ToShortDateString();
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
                string mySelectQuery = "  SELECT  * from dbo.ADM_PAZARLAMA_SIRKETI";
                SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
                myCommand.CommandText = mySelectQuery.ToString();
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    CMB_PAZARLAMA_SIRKETI.Properties.Items.Add(myReader["UNVANI"].ToString());
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

            CMB_PAZARLAMA_SIRKETI.SelectedIndexChanged += new System.EventHandler(COM_BX_PAZARLAMASIRKETI_SelectedIndexChanged);


   


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
                        TXT_SIRKET_ADI.Text = myReader["ADI"].ToString();
                        TXT_SIRKET_ADRESI.Text = myReader["ADRESI"].ToString();
                        TXT_SIRKET_IL.Text = myReader["IL"].ToString();
                        TXT_SIRKET_VKN.Text = myReader["VERGI_NO"].ToString();
                        TXT_SIRKET_VD.Text = myReader["VERGI_DAIRESI"].ToString();
                    }
                }
            }
        }


        private void CMB_SIRKET_UNVANI_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }
        private void COM_BX_PAZARLAMASIRKETI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMB_PAZARLAMA_SIRKETI.EditValue != null)
            {

                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                {
                    string mySelectQuery = "  SELECT  * from  dbo.ADM_PAZARLAMA_SIRKETI WHERE UNVANI='" + CMB_PAZARLAMA_SIRKETI.EditValue.ToString() + "' ";
                    SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);

                    myCommand.CommandText = mySelectQuery.ToString();
                    myConnection.Open();
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                    myConnections.Open();
                    while (myReader.Read())
                    {
                        TXT_PAZARLAMA_SIRKETI_KODU.Text = myReader["KODU"].ToString();
                        TXT_PAZARLAMA_SIRKETI_VKN.Text = myReader["VERGI_NO"].ToString();
                        TXT_PAZARLAMA_SIRKETI_VERGI_DAIRESI.Text = myReader["VERGI_DAIRESI"].ToString(); 
                    }
                }
            }
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
                string mySelectQuery = "  SELECT  * from  dbo.FTR_GELEN_FATURALAR WHERE SIRKET_KODU= " + _GLOBAL_PARAMETERS._SIRKET_KODU.ToString() + " AND   ID=" + ID;
                SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);

                myCommand.CommandText = mySelectQuery.ToString();
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                myConnections.Open();
                while (myReader.Read())
                {
                    DATE_GELISTARIHI.Text = myReader["GELIS_TARIHI"].ToString();
                    DATE_FATURA_TARIHI.Text = myReader["DOKUMAN_TARIHI"].ToString();
                    CMB_PAZARLAMA_SIRKETI.Text = myReader["PAZARLAMA_SIRKETI"].ToString();
                    TXT_FATURANO.Text = myReader["DOKUMAN_NO"].ToString();
                    CMB_MECRA_TURU.Text = myReader["MECRA_TURU"].ToString();
                    COM_BX_MUSTERI_UNVANI.Text = myReader["MUSTERI_KODU"].ToString();
                    TXT_FATURATUTARI.Text = myReader["DOKUMAN_TUTARI"].ToString();
                    COM_BX_DIREKTOR.Text = myReader["DIREKTOR"].ToString();
                    TXT_NOTU.Text = myReader["DOKUMAN_NOTU"].ToString();
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
                string HEADER_TABLE_SQL = @" INSERT INTO dbo.FTR_GELEN_FATURALAR (SIRKET_KODU,FATURA_TIPI,ID,GUID,IssueDate,Note,DocumentCurrencyCode,AdditionalDocumentID,AdditionalDocumentIssueDate,SignatureSchemeID,
                                                            SignatureSignatoryPartyIdentificationSchemeID,SignatureSignatoryPartyPostalAddressRoom,SignatureSignatoryPartyPostalAddressStreetName,
                                                            SignatureSignatoryPartyPostalAddressBuildingName, SignatureSignatoryPartyPostalAddressBuildingNumber,
                                                            SignatureSignatoryPartyPostalAddressCitySubdivisionName, SignatureSignatoryPartyPostalAddressCityName,
                                                            SignatureSignatoryPartyPostalAddressPostalZone,  
                                                            SignatureSignatoryPartyPostalAddressCountryName,AccSupplierPartyName,
                                                            AccSupplierPartyPostalAddressRoom,AccSupplierPartyPostalAddressStreetName,AccSupplierPartyPostalAddressBuildingName,
                                                            AccSupplierPartyPostalAddressBuildingNumber,AccSupplierPartyPostalAddressCitySubdivisionName ,AccSupplierPartyPostalAddressCityName,
                                                            AccSupplierPartyPostalAddressPostalZone,AccSupplierPartyPostalAddressCountryName,AccSupplierPartyTaxSchemeName,AccSupplierPartyTaxSchemeCode, 
                                                            AccSupplierPartyContactTelephone , AccSupplierPartyContactTelefax , AccSupplierPartyContactElectronicMail ,  AccCustomerPartyIdentificationSchemeID,
                                                            AccCustomerPartyName, AccCustomerPartyPostalAddressRoom, AccCustomerPartyPostalAddressBuildingName,AccCustomerPartyPostalAddressStreetName,
                                                            AccCustomerPartyPostalAddressBuildingNumber, AccCustomerPartyPostalAddressCitySubdivisionName,AccCustomerPartyPostalAddressCityName,
                                                            AccCustomerPartyPostalAddressPostalZone, AccCustomerPartyPostalAddressCountryName,AccCustomerPartyTaxSchemeName,
                                                            AccCustomerPartyTaxSchemeCode, TaxTotalTaxAmountCurrencyID,TaxTotalTaxAmount,TaxSubtotalTaxableAmountCurrencyID,
                                                            TaxSubtotalTaxableAmount, TaxSubtotalTaxAmountCurrencyID,TaxSubtotalTaxAmount,TaxSubtotalPercent,TaxSubtotalTaxCategoryTaxSchemeName,
                                                            TaxSubtotalTaxCategoryTaxSchemeCode,LegalMonetaryLineExtensionAmount,LegalMonetaryTaxExclusiveAmount,LegalMonetaryTaxInclusiveAmount,
                                                            LegalMonetaryPayableAmount,MUSTERI_KODU,MUSTERI_GRUBU,FATURA_TURU,MECRA_TURU,MECRA_ADI,FATURA_YENI )   
                                                           Values 
                                                           (
                                                            @SIRKET_KODU,@FATURA_TIPI,@ID,@GUID,@IssueDate,@Note,@DocumentCurrencyCode,@AdditionalDocumentID,@AdditionalDocumentIssueDate,@SignatureSchemeID,
                                                            @SignatureSignatoryPartyIdentificationSchemeID,@SignatureSignatoryPartyPostalAddressRoom,@SignatureSignatoryPartyPostalAddressStreetName,
                                                            @SignatureSignatoryPartyPostalAddressBuildingName,@SignatureSignatoryPartyPostalAddressBuildingNumber,
                                                            @SignatureSignatoryPartyPostalAddressCitySubdivisionName,@SignatureSignatoryPartyPostalAddressCityName,
                                                            @SignatureSignatoryPartyPostalAddressPostalZone, 
                                                            @SignatureSignatoryPartyPostalAddressCountryName,@AccSupplierPartyName,
                                                            @AccSupplierPartyPostalAddressRoom,@AccSupplierPartyPostalAddressStreetName,@AccSupplierPartyPostalAddressBuildingName,
                                                            @AccSupplierPartyPostalAddressBuildingNumber,@AccSupplierPartyPostalAddressCitySubdivisionName,@AccSupplierPartyPostalAddressCityName,
                                                            @AccSupplierPartyPostalAddressPostalZone,@AccSupplierPartyPostalAddressCountryName,@AccSupplierPartyTaxSchemeName,@AccSupplierPartyTaxSchemeCode,
                                                            @AccSupplierPartyContactTelephone,@AccSupplierPartyContactTelefax,@AccSupplierPartyContactElectronicMail,@AccCustomerPartyIdentificationSchemeID,
                                                            @AccCustomerPartyName,@AccCustomerPartyPostalAddressRoom,@AccCustomerPartyPostalAddressBuildingName,@AccCustomerPartyPostalAddressStreetName,
                                                            @AccCustomerPartyPostalAddressBuildingNumber,@AccCustomerPartyPostalAddressCitySubdivisionName,@AccCustomerPartyPostalAddressCityName,
                                                            @AccCustomerPartyPostalAddressPostalZone,@AccCustomerPartyPostalAddressCountryName,@AccCustomerPartyTaxSchemeName,
                                                            @AccCustomerPartyTaxSchemeCode,@TaxTotalTaxAmountCurrencyID,@TaxTotalTaxAmount,@TaxSubtotalTaxableAmountCurrencyID,
                                                            @TaxSubtotalTaxableAmount,@TaxSubtotalTaxAmountCurrencyID,@TaxSubtotalTaxAmount,@TaxSubtotalPercent,@TaxSubtotalTaxCategoryTaxSchemeName,
                                                            @TaxSubtotalTaxCategoryTaxSchemeCode,@LegalMonetaryLineExtensionAmount,@LegalMonetaryTaxExclusiveAmount,@LegalMonetaryTaxInclusiveAmount,
                                                            @LegalMonetaryPayableAmount,@MUSTERI_KODU,@MUSTERI_GRUBU,@FATURA_TURU,@MECRA_TURU,@MECRA_ADI,@FATURA_YENI  
                                                            )  SELECT @@IDENTITY AS ID   ";        
  

               DateTime dt = DateTime.Parse(DATE_FATURA_TARIHI.Text);

                                                       
                cmd.CommandText = HEADER_TABLE_SQL;
                cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                cmd.Parameters.AddWithValue("@FATURA_TIPI", 'P');                
                cmd.Parameters.AddWithValue("@ID", TXT_FATURANO.Text);
                cmd.Parameters.AddWithValue("@GUID", g);
                cmd.Parameters.AddWithValue("@IssueDate", dt.ToString("yyyy.MM.dd").ToString());
                //cmd.Parameters.AddWithValue("@InvoiceTypeCode", dr["InvoiceTypeCode"]);
                cmd.Parameters.AddWithValue("@Note", TXT_NOTU.Text);
                cmd.Parameters.AddWithValue("@DocumentCurrencyCode", COM_BX_PB.Text); 
                cmd.Parameters.AddWithValue("@AdditionalDocumentID", TXT_FATURANO.Text); 

                cmd.Parameters.AddWithValue("@AdditionalDocumentIssueDate", dt.ToString("yyyy.MM.dd").ToString());
                //cmd.Parameters.AddWithValue("@AdditionalDocumentEncode", dr["AdditionalDocumentEncode"]);
                //cmd.Parameters.AddWithValue("@AdditionalDocumentCharacterSetCode", dr["AdditionalDocumentCharacterSetCode"]);
                //cmd.Parameters.AddWithValue("@AdditionalDocumentFileName", dr["AdditionalDocumentFileName"]);
                cmd.Parameters.AddWithValue("@SignatureSchemeID", TXT_PAZARLAMA_SIRKETI_VKN.Text);
                cmd.Parameters.AddWithValue("@SignatureSignatoryPartyIdentificationSchemeID", TXT_PAZARLAMA_SIRKETI_VKN.Text); 
                cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressRoom",TXT_KAT.Text );
                cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressStreetName", TXT_ADRESI.Text );
                cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressBuildingName",TXT_BINA_ADI.Text );
                cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressBuildingNumber", TXT_BINA_NO.Text );
                cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressCitySubdivisionName",CMB_ILCE.Text );
                cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressCityName",CMB_IL.Text);
                cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressPostalZone",TXT_PK.Text);
                //cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressRegion", dr["SignatureSignatoryPartyPostalAddressRegion"]);
                cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressCountryName", CMB_ULKE.Text);  
                cmd.Parameters.AddWithValue("@AccSupplierPartyName",CMB_PAZARLAMA_SIRKETI.Text );
                cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressRoom", TXT_KAT.Text);
                cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressStreetName", TXT_ADRESI.Text );
                cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressBuildingName", TXT_BINA_ADI.Text );
                cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressBuildingNumber", TXT_BINA_NO.Text );
                cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressCitySubdivisionName",CMB_ILCE.Text );
                cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressCityName", CMB_IL.Text);
                //cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressRegion", dr["AccSupplierPartyPostalAddressRegion"]);
                cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressPostalZone",TXT_PK.Text );
                cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressCountryName", CMB_ULKE.Text );
                cmd.Parameters.AddWithValue("@AccSupplierPartyTaxSchemeName", TXT_PAZARLAMA_SIRKETI_VERGI_DAIRESI.Text );
                cmd.Parameters.AddWithValue("@AccSupplierPartyTaxSchemeCode", TXT_PAZARLAMA_SIRKETI_VKN.Text);
                cmd.Parameters.AddWithValue("@AccSupplierPartyContactTelephone", TXT_TELEFON.Text);
                cmd.Parameters.AddWithValue("@AccSupplierPartyContactTelefax", TXT_FAX.Text);
                cmd.Parameters.AddWithValue("@AccSupplierPartyContactElectronicMail", TXT_EMAIL.Text); 
 
                cmd.Parameters.AddWithValue("@AccCustomerPartyIdentificationSchemeID",TXT_SIRKET_VKN.Text );
                cmd.Parameters.AddWithValue("@AccCustomerPartyName", TXT_SIRKET_ADI.Text);
                cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressRoom",TXT_SIRKET_BINANO.Text );
                cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressBuildingName", TXT_SIRKET_BINAADI.Text );
                cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressStreetName", TXT_SIRKET_ADRESI.Text ); 
                cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressBuildingNumber",  TXT_SIRKET_BINANO.Text );
                cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressCitySubdivisionName",TXT_SIRKET_ILCE.Text );
                cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressCityName", TXT_SIRKET_IL.Text );
                cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressPostalZone", TXT_SIRKET_PK.Text);
                cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressCountryName", TXT_SIRKET_ULKE.Text);
                cmd.Parameters.AddWithValue("@AccCustomerPartyTaxSchemeName", TXT_SIRKET_VD.Text);
                cmd.Parameters.AddWithValue("@AccCustomerPartyTaxSchemeCode", TXT_SIRKET_VKN.Text ); 
                cmd.Parameters.AddWithValue("@TaxTotalTaxAmountCurrencyID", COM_BX_PB.Text ); 
                cmd.Parameters.AddWithValue("@TaxTotalTaxAmount", float.Parse(TXT_KDVTUTARI.Text));
                cmd.Parameters.AddWithValue("@TaxSubtotalTaxableAmountCurrencyID", COM_BX_PB.Text);
                cmd.Parameters.AddWithValue("@TaxSubtotalTaxableAmount", float.Parse(TXT_FATURATUTARI.Text));
                cmd.Parameters.AddWithValue("@TaxSubtotalTaxAmountCurrencyID", COM_BX_PB.Text);
                cmd.Parameters.AddWithValue("@TaxSubtotalTaxAmount", float.Parse(TXT_KDVTUTARI.Text));
                cmd.Parameters.AddWithValue("@TaxSubtotalPercent", float.Parse(TXT_KDV_ORANI.Text));
                cmd.Parameters.AddWithValue("@TaxSubtotalTaxCategoryTaxSchemeName","KDV"  );
                cmd.Parameters.AddWithValue("@TaxSubtotalTaxCategoryTaxSchemeCode", "0015" );
                cmd.Parameters.AddWithValue("@LegalMonetaryLineExtensionAmount",float.Parse(TXT_FATURATUTARI.Text));
                cmd.Parameters.AddWithValue("@LegalMonetaryTaxExclusiveAmount",float.Parse(TXT_FATURATUTARI.Text));
                cmd.Parameters.AddWithValue("@LegalMonetaryTaxInclusiveAmount",float.Parse(TXT_GENELTUTARI.Text));
                //cmd.Parameters.AddWithValue("@LegalMonetaryAllowanceTotalAmount", dr["LegalMonetaryAllowanceTotalAmount"]);
                cmd.Parameters.AddWithValue("@LegalMonetaryPayableAmount",  float.Parse(TXT_GENELTUTARI.Text));
                cmd.Parameters.AddWithValue("@MUSTERI_KODU", TXT_MUSTERI_KODU.Text);
                cmd.Parameters.AddWithValue("@MUSTERI_GRUBU", TXT_MUSTERI_GRUBU.Text);
                cmd.Parameters.AddWithValue("@FATURA_TURU", CMB_FATURA_TURU.Text);
                cmd.Parameters.AddWithValue("@MECRA_TURU", CMB_FATURA_TURU.Text);
                cmd.Parameters.AddWithValue("@MECRA_ADI", CMB_MECRA_KODU.Text);
                cmd.Parameters.AddWithValue("@FATURA_YENI", '1');
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



            myCmd.Parameters.Add("@GELIS_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@GELIS_TARIHI"].Value = DATE_GELISTARIHI.Text;
            myCmd.Parameters.Add("@DOKUMAN_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@DOKUMAN_TARIHI"].Value = DATE_FATURA_TARIHI.Text;
            myCmd.Parameters.Add("@PAZARLAMA_SIRKETI", SqlDbType.NVarChar); myCmd.Parameters["@PAZARLAMA_SIRKETI"].Value = CMB_PAZARLAMA_SIRKETI.Text;
            myCmd.Parameters.Add("@DOKUMAN_NO", SqlDbType.NVarChar); myCmd.Parameters["@DOKUMAN_NO"].Value = TXT_FATURANO.Text;
            myCmd.Parameters.Add("@MECRA_TURU", SqlDbType.NVarChar); myCmd.Parameters["@MECRA_TURU"].Value = CMB_MECRA_TURU.Text;
            myCmd.Parameters.Add("@MUSTERI_KODU", SqlDbType.NVarChar); myCmd.Parameters["@MUSTERI_KODU"].Value = TXT_MUSTERI_KODU.Text;
            myCmd.Parameters.Add("@MUSTERI_ADI", SqlDbType.NVarChar); myCmd.Parameters["@MUSTERI_ADI"].Value = COM_BX_MUSTERI_UNVANI.Text;
            //myCmd.Parameters.Add("@DOKUMAN_TUTARI", SqlDbType.Float); myCmd.Parameters["@DOKUMAN_TUTARI"].Value = TXT_FATURATUTARI.Text.Replace(",", ".");
            myCmd.Parameters.Add("@FATURA_TOPLAMI", SqlDbType.Float); myCmd.Parameters["@FATURA_TOPLAMI"].Value = TXT_FATURATUTARI.Text.Replace(",", ".");
            myCmd.Parameters.Add("@KDV_TUTARI", SqlDbType.Float); myCmd.Parameters["@KDV_TUTARI"].Value = TXT_KDVTUTARI.Text.Replace(",", ".");
            myCmd.Parameters.Add("@GENEL_TOPLAM", SqlDbType.Float); myCmd.Parameters["@GENEL_TOPLAM"].Value = TXT_GENELTUTARI.Text.Replace(",", ".");
            myCmd.Parameters.Add("@DIREKTOR", SqlDbType.NVarChar); myCmd.Parameters["@DIREKTOR"].Value = COM_BX_DIREKTOR.Text;
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


            //EvernoteIFLib.ICOTPlugin bd;
            
            //bd=new ICOTPlugin;
            //bd.Connect();

            //bd.CreateID(Guid.NewGuid ());

            //JOBUTILITYLib.Jobs ahsd = new JOBUTILITYLib.Jobs ();
            //ahsd.AllDelete();

            //JOBUTILITYLib.Job cds = new JOBUTILITYLib.Job();
            //ahsd.Job[0].HelpOfFileTypeIDEnum(JOBUTILITYLib.FILETYPE_ID.PDF);

            //ahsd.Job[0].HelpOfFunctionIDEnum(JOBUTILITYLib.FUNCTION_ID.SCANNER_START);
            //ahsd.Job[0].HelpOfOCRLanguageIDEnum(JOBUTILITYLib.OCRLANGUAGE_ID.ENGLISH);
            //ahsd.Job[0].HelpOfPrintSizeIDEnum(JOBUTILITYLib.PRINTSIZE_ID.ACTUALSIZE);
            //ahsd.Job[0].read();

            //ahsd.Job.HelpOfFileTypeIDEnum(JOBUTILITYLib.FILETYPE_ID.PDF);
            //ahsd.Job.HelpOfFunctionIDEnum(JOBUTILITYLib.FUNCTION_ID.SCANNER_START); 
            //ahsd.Job.HelpOfOCRLanguageIDEnum(JOBUTILITYLib.OCRLANGUAGE_ID.ENGLISH);             
            //ahsd.Job.HelpOfPrintSizeIDEnum(JOBUTILITYLib.PRINTSIZE_ID.ACTUALSIZE);   


            //JOBUTILITYLib.Job asd = new JOBUTILITYLib.Job();

           
            //asd.HelpOfFileTypeIDEnum(JOBUTILITYLib.FILETYPE_ID.PDF);
            //asd.HelpOfFunctionIDEnum(JOBUTILITYLib.FUNCTION_ID.SCANNER_START); 
            //asd.HelpOfOCRLanguageIDEnum(JOBUTILITYLib.OCRLANGUAGE_ID.ENGLISH);             
            //asd.HelpOfPrintSizeIDEnum(JOBUTILITYLib.PRINTSIZE_ID.ACTUALSIZE);            
            
            //asd.JobNo = 10;
            ////asd.get_data("DOSYA");            
            //asd.read();
            //asd.write();
            //asd.HelpOfFunctionIDEnum(JOBUTILITYLib.FUNCTION_ID.SCANNER_STOP);

            //JOBUTILITYLib.FILETYPE_ID.PDF;  
           

            //JOBUTILITYLib.FILETYPE_ID.PDF ;
            //JOBUTILITYLib.FUNCTION_ID.SCANNER_START;
 
            

            //Guid d = Guid.NewGuid();

            //EvernoteIFLib.COTPlugin a = new COTPlugin();
            //a.CreateID(Guid.NewGuid ()); 
            //a.Connect();
            //a.ShowCommonSetting(50);
            //a.ShowSetting(d, 50);
            //bool bt= a.ShowSettingButton;
            //a.Execute(d, @"c:\Temp\deneme.pfd", true, 120);
            //a.ShowCommonSetting(10);
        

            //Guid d = Guid.NewGuid();
            //a.Execute(d, "c:\\temp", false, 10);
            
 

          // var i = Scan2PaperPortLib.ScanToPaperPortPlugin.ReferenceEquals()   
          //  var i = IScanToPaperPortPlugin.ReferenceEquals();
            

             // Scan2PaperPortLib
       //     string a = "";

             

        }


      

      
    }
}