using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
//using EvernoteIFLib;
//using JOBUTILITYLib.;

namespace VISION.FINANS.FATURA._SCAN
{
    public partial class ALIS_FATURASI : DevExpress.XtraEditors.XtraForm
    {
        int id = 0;
        public string SELECT_BUTTON = "CANCEL";
        public ALIS_FATURASI(int ID)
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
                string mySelectQuery = "  SELECT  UNVANI from dbo.ADM_PAZARLAMA_SIRKETI";
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
                string mySelectQuery = "  SELECT  MUSTERI_KODU from dbo.ADM_MUSTERI WHERE SIRKET_KODU='" + _GLOBAL_PARAMETERS._SIRKET_KODU + "'";
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
                    string mySelectQuery = "  SELECT  ADI,ADRESI,IL,VERGI_NO,VERGI_DAIRESI  from  dbo.ADM_SIRKET WHERE SIRKET_KODU='" + CMB_SIRKET_KODU.EditValue.ToString() + "' ";
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
                    string mySelectQuery = "  SELECT  KODU,UNVANI,TC_KIMLIK_NO,VERGI_NO,SAHIS_SIRKETI,VERGI_DAIRESI from  dbo.ADM_PAZARLAMA_SIRKETI WHERE UNVANI='" + CMB_PAZARLAMA_SIRKETI.EditValue.ToString() + "' ";
                    SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);

                    myCommand.CommandText = mySelectQuery.ToString();
                    myConnection.Open();
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                    myConnections.Open();
                    while (myReader.Read())
                    {
                        TXT_PAZARLAMA_SIRKETI_KODU.Text = myReader["KODU"].ToString();
                        //  TXT_PAZARLAMA_SIRKETI_VKN.Text = myReader["VERGI_NO"].ToString();
                        if (myReader["SAHIS_SIRKETI"].ToString() == "SAHIS") TXT_PAZARLAMA_SIRKETI_VKN.Text = myReader["TC_KIMLIK_NO"].ToString();
                        if (myReader["SAHIS_SIRKETI"].ToString() == "TUZEL") TXT_PAZARLAMA_SIRKETI_VKN.Text = myReader["VERGI_NO"].ToString();

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
                string mySelectQuery = "  SELECT  * from  dbo.FTR_GELEN_FATURALAR WHERE  OID=" + ID;
                SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);

                myCommand.CommandText = mySelectQuery.ToString();
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                myConnections.Open();
                while (myReader.Read())
                {
                    BR_GUID.Caption = myReader["GUID"].ToString();    

                    CMB_SIRKET_KODU.Text = myReader["SIRKET_KODU"].ToString();
                    CMB_SIRKET_KODU.Text = myReader["SIRKET_KODU"].ToString();

                    TXT_FATURANO.Text = myReader["ID"].ToString();
                    TXT_NOTU.Text = myReader["Note"].ToString();

                     

                    DATE_FATURA_TARIHI.Text  = myReader["IssueDate"].ToString();
                    DATE_GELISTARIHI.Text = myReader["UBLExtensionObjectSigningTime"].ToString();
        
                    //IssueDate", dt.ToString("yyyy.MM.dd").ToString());
                    //UBLExtensionObjectSigningTime", dtGelis.ToString("yyyy.MM.dd").ToString());
                    // AdditionalDocumentIssueDate", dt.ToString("yyyy.MM.dd").ToString());

                    COM_BX_PB.Text = myReader["DocumentCurrencyCode"].ToString();
                
                   TXT_PAZARLAMA_SIRKETI_VKN.Text = myReader["SignatureSchemeID"].ToString();

                    TXT_PAZARLAMA_SIRKETI_VKN.Text = myReader["SignatureSignatoryPartyIdentificationSchemeID"].ToString();
               
                   TXT_KAT.Text = myReader["SignatureSignatoryPartyPostalAddressRoom"].ToString();
                   TXT_ADRESI.Text = myReader["SignatureSignatoryPartyPostalAddressStreetName"].ToString();
   
                   TXT_BINA_ADI.Text = myReader["SignatureSignatoryPartyPostalAddressBuildingName"].ToString();
              

                      TXT_BINA_NO.Text = myReader["SignatureSignatoryPartyPostalAddressBuildingNumber"].ToString();
                      CMB_ILCE.Text = myReader["SignatureSignatoryPartyPostalAddressCitySubdivisionName"].ToString();
                      CMB_IL.Text = myReader["SignatureSignatoryPartyPostalAddressCityName"].ToString();
                      TXT_PK.Text = myReader["SignatureSignatoryPartyPostalAddressPostalZone"].ToString();
                      CMB_ULKE.Text = myReader["SignatureSignatoryPartyPostalAddressCountryName"].ToString();
                      CMB_PAZARLAMA_SIRKETI.Text = myReader["AccSupplierPartyName"].ToString();
                      TXT_KAT.Text = myReader["AccSupplierPartyPostalAddressRoom"].ToString();
                      TXT_ADRESI.Text = myReader["AccSupplierPartyPostalAddressStreetName"].ToString();
                      TXT_BINA_ADI.Text = myReader["AccSupplierPartyPostalAddressBuildingName"].ToString();

                 

                         TXT_BINA_NO.Text = myReader["AccSupplierPartyPostalAddressBuildingNumber"].ToString();
                         CMB_ILCE.Text = myReader["AccSupplierPartyPostalAddressCitySubdivisionName"].ToString();
                         CMB_IL.Text = myReader["AccSupplierPartyPostalAddressCityName"].ToString();
                         TXT_PK.Text = myReader["AccSupplierPartyPostalAddressPostalZone"].ToString();
                         CMB_ULKE.Text = myReader["AccSupplierPartyPostalAddressCountryName"].ToString();
                         TXT_PAZARLAMA_SIRKETI_VERGI_DAIRESI.Text = myReader["AccSupplierPartyTaxSchemeName"].ToString();
                         TXT_PAZARLAMA_SIRKETI_VKN.Text = myReader["AccSupplierPartyTaxSchemeCode"].ToString();
                         TXT_PAZARLAMA_SIRKETI_VKN.Text = myReader["AccSupplierPartyIdentificationSchemeID"].ToString();
                         TXT_TELEFON.Text = myReader["AccSupplierPartyContactTelephone"].ToString();
                         TXT_FAX.Text = myReader["AccSupplierPartyContactTelefax"].ToString();
                         TXT_EMAIL.Text = myReader["AccSupplierPartyContactElectronicMail"].ToString();
                         TXT_SIRKET_VKN.Text = myReader["AccCustomerPartyIdentificationSchemeID"].ToString();
                         TXT_SIRKET_ADI.Text = myReader["AccCustomerPartyName"].ToString();
          
                         TXT_SIRKET_BINANO.Text = myReader["AccCustomerPartyPostalAddressRoom"].ToString();
                         TXT_SIRKET_BINAADI.Text = myReader["AccCustomerPartyPostalAddressBuildingName"].ToString();
                         TXT_SIRKET_ADRESI.Text = myReader["AccCustomerPartyPostalAddressStreetName"].ToString();
                         TXT_SIRKET_BINANO.Text = myReader["AccCustomerPartyPostalAddressBuildingNumber"].ToString();
                         TXT_SIRKET_ILCE.Text = myReader["AccCustomerPartyPostalAddressCitySubdivisionName"].ToString();
                         TXT_SIRKET_IL.Text = myReader["AccCustomerPartyPostalAddressCityName"].ToString();
                         TXT_SIRKET_PK.Text = myReader["AccCustomerPartyPostalAddressPostalZone"].ToString();
                         TXT_SIRKET_ULKE.Text = myReader["AccCustomerPartyPostalAddressCountryName"].ToString();
                         TXT_SIRKET_VD.Text = myReader["AccCustomerPartyTaxSchemeName"].ToString();
                         TXT_SIRKET_VKN.Text = myReader["AccCustomerPartyTaxSchemeCode"].ToString();
                         COM_BX_PB.Text = myReader["TaxTotalTaxAmountCurrencyID"].ToString();
                         TXT_KDVTUTARI.Text = myReader["TaxTotalTaxAmount"].ToString();
                      
  

                     TXT_FATURATUTARI.Text = myReader["TaxSubtotalTaxableAmount"].ToString();
                     COM_BX_PB.Text = myReader["TaxSubtotalTaxAmountCurrencyID"].ToString();
                     TXT_KDVTUTARI.Text = myReader["TaxSubtotalTaxAmount"].ToString();
                     TXT_KDV_ORANI.Text = myReader["TaxSubtotalPercent"].ToString();
                    
                       TXT_GENELTUTARI.Text = myReader["LegalMonetaryPayableAmount"].ToString();

                       CMB_MECRA_TURU.Text = myReader["MECRA_TURU"].ToString(); 
                       TXT_MUSTERI_KODU.Text = myReader["MUSTERI_KODU"].ToString();
                       TXT_MUSTERI_GRUBU.Text = myReader["MUSTERI_GRUBU"].ToString();
                       CMB_FATURA_TURU.Text = myReader["FATURA_TURU"].ToString();
                       CMB_ISLEM_TURU.Text = myReader["ISLEM_TURU"].ToString();

                

                      // CMB_MECRA_KODU.Text = myReader["MECRA_ADI"].ToString();
                      // CMB_MECRA_KODU.Text = myReader["MECRA_ADI"].ToString();

                    //CMB_MECRA_KODU.Text = myReader["MECRA_ADI"].ToString();


                }

            }
        }
        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SELECT_BUTTON = "CANCEL";
            Close();
        }

        private void barBTN_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (id == 0)
            {
                __Kaydet(); 
        
                DateTime dt = DateTime.Parse(DATE_FATURA_TARIHI.Text);
                string FILE_NAME = @"" + _GLOBAL_PARAMETERS._FILE_PATH + "_INBOX_PRINT\\" + CMB_SIRKET_KODU.Text.ToString() + "\\" + CMB_SIRKET_KODU.Text.ToString() + "_" + dt.Year.ToString() + "_" + BR_GUID.Caption  + ".pdf";
                if (!File.Exists(FILE_NAME))
                {
                    File.Move("c:\\TEMP\\" + TXT_FATURANO.Text +".pdf", FILE_NAME);
                    MessageBox.Show("Kayıt işlemi yapıldı", "UYARI");
                }
                else
                { 
                    DialogResult c = MessageBox.Show("Bu kod ile dosya mevcut Silmek istediğinizden eminmisiniz.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (c == DialogResult.Yes)
                    {

                        if (File.Exists(FILE_NAME))
                        { 
                            File.Delete(FILE_NAME);
                            File.Move("c:\\TEMP\\" + TXT_FATURANO.Text + ".pdf", FILE_NAME);
                            MessageBox.Show("Kayıt işlemi yapıldı", "UYARI");
                        }
                    } 
                }

                TXT_PAZARLAMA_SIRKETI_VKN.Text = "";
                TXT_FATURANO.Text = "";
                CMB_MECRA_TURU.Text = "";
                TXT_FATURATUTARI.Text = "0";
                TXT_KDVTUTARI.Text = "0";
                TXT_GENELTUTARI.Text = "0";
                TXT_FATURANO.Text = "";
                DATE_FATURA_TARIHI.EditValue = "";
                DATE_FATURA_TARIHI.Text = "";
                CMB_PAZARLAMA_SIRKETI.Text = "";
                TXT_PAZARLAMA_SIRKETI_KODU.Text ="";
                TXT_PAZARLAMA_SIRKETI_VKN.Text = "";
                TXT_PAZARLAMA_SIRKETI_VERGI_DAIRESI.Text ="";


                //Close();
            }
            else
            {
                __Guncelle(id);


                DateTime dt = DateTime.Parse(DATE_FATURA_TARIHI.Text);
                string FILE_NAME = @"" + _GLOBAL_PARAMETERS._FILE_PATH + "_INBOX_PRINT\\" + CMB_SIRKET_KODU.Text.ToString() + "\\" + CMB_SIRKET_KODU.Text.ToString() + "_" + dt.Year.ToString() + "_" + BR_GUID.Caption + ".pdf";
                if (!File.Exists(FILE_NAME))
                {
                    File.Move("c:\\TEMP\\" + TXT_FATURANO.Text, FILE_NAME);
                    MessageBox.Show("Kayıt işlemi yapıldı", "UYARI");
                }
                //else
                //{
                //    DialogResult c = MessageBox.Show("Bu kod ile dosya mevcut Silmek istediğinizden eminmisiniz.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //    if (c == DialogResult.Yes)
                //    {

                //        if (File.Exists(FILE_NAME))
                //        {
                //            File.Delete(FILE_NAME);
                //            File.Move("c:\\TEMP\\" + TXT_FATURANO.Text, FILE_NAME);
                //            MessageBox.Show("Kayıt işlemi yapıldı", "UYARI");
                //        }
                //    }
                //} 

                //TXT_PAZARLAMA_SIRKETI_VKN.Text = "";
                //TXT_FATURANO.Text = "";
                //CMB_MECRA_TURU.Text = "";
                //TXT_FATURATUTARI.Text = "0";
                //TXT_KDVTUTARI.Text = "0";
                //TXT_GENELTUTARI.Text = "0";
                //TXT_FATURANO.Text = "";
                //DATE_FATURA_TARIHI.EditValue = "";
                //DATE_FATURA_TARIHI.Text = "";
                //CMB_PAZARLAMA_SIRKETI.Text = "";
                //TXT_PAZARLAMA_SIRKETI_KODU.Text = "";
                //TXT_PAZARLAMA_SIRKETI_VKN.Text = "";
                //TXT_PAZARLAMA_SIRKETI_VERGI_DAIRESI.Text = "";
                Close();
            }
            SELECT_BUTTON = "OK";
        }
        private void __Kaydet()
        {
            SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            myConnectionTable.Open();
            SqlCommand myCmd = new SqlCommand(); 
             Guid g = Guid.NewGuid();
             BR_GUID.Caption = g.ToString ();
            using (SqlCommand cmd = new SqlCommand())
            {
                string HEADER_TABLE_SQL = @" INSERT INTO dbo.FTR_GELEN_FATURALAR (SIRKET_KODU,FATURA_TIPI,ID,GUID,UUID,IssueDate,UBLExtensionObjectSigningTime,Note,DocumentCurrencyCode,AdditionalDocumentID,AdditionalDocumentIssueDate,SignatureSchemeID,
                                                            SignatureSignatoryPartyIdentificationSchemeID,SignatureSignatoryPartyPostalAddressRoom,SignatureSignatoryPartyPostalAddressStreetName,
                                                            SignatureSignatoryPartyPostalAddressBuildingName, SignatureSignatoryPartyPostalAddressBuildingNumber,
                                                            SignatureSignatoryPartyPostalAddressCitySubdivisionName, SignatureSignatoryPartyPostalAddressCityName,
                                                            SignatureSignatoryPartyPostalAddressPostalZone,  
                                                            SignatureSignatoryPartyPostalAddressCountryName,AccSupplierPartyName,
                                                            AccSupplierPartyPostalAddressRoom,AccSupplierPartyPostalAddressStreetName,AccSupplierPartyPostalAddressBuildingName,
                                                            AccSupplierPartyPostalAddressBuildingNumber,AccSupplierPartyPostalAddressCitySubdivisionName ,AccSupplierPartyPostalAddressCityName,
                                                            AccSupplierPartyPostalAddressPostalZone,AccSupplierPartyPostalAddressCountryName,AccSupplierPartyTaxSchemeName,AccSupplierPartyTaxSchemeCode, AccSupplierPartyIdentificationSchemeID,
                                                            AccSupplierPartyContactTelephone , AccSupplierPartyContactTelefax , AccSupplierPartyContactElectronicMail ,  AccCustomerPartyIdentificationSchemeID,
                                                            AccCustomerPartyName, AccCustomerPartyPostalAddressRoom, AccCustomerPartyPostalAddressBuildingName,AccCustomerPartyPostalAddressStreetName,
                                                            AccCustomerPartyPostalAddressBuildingNumber, AccCustomerPartyPostalAddressCitySubdivisionName,AccCustomerPartyPostalAddressCityName,
                                                            AccCustomerPartyPostalAddressPostalZone, AccCustomerPartyPostalAddressCountryName,AccCustomerPartyTaxSchemeName,
                                                            AccCustomerPartyTaxSchemeCode, TaxTotalTaxAmountCurrencyID,TaxTotalTaxAmount,TaxSubtotalTaxableAmountCurrencyID,
                                                            TaxSubtotalTaxableAmount, TaxSubtotalTaxAmountCurrencyID,TaxSubtotalTaxAmount,TaxSubtotalPercent,TaxSubtotalTaxCategoryTaxSchemeName,
                                                            TaxSubtotalTaxCategoryTaxSchemeCode,LegalMonetaryLineExtensionAmount,LegalMonetaryTaxExclusiveAmount,LegalMonetaryTaxInclusiveAmount,
                                                            LegalMonetaryPayableAmount,InvoiceTypeCode,ProfileID,MUSTERI_KODU,MUSTERI_GRUBU,FATURA_TURU,MECRA_TURU,MECRA_ADI,FATURA_YENI,ISLEM_TURU )   
                                                           Values 
                                                           (
                                                            @SIRKET_KODU,@FATURA_TIPI,@ID,@GUID,@UUID,@IssueDate,@UBLExtensionObjectSigningTime,@Note,@DocumentCurrencyCode,@AdditionalDocumentID,@AdditionalDocumentIssueDate,@SignatureSchemeID,
                                                            @SignatureSignatoryPartyIdentificationSchemeID,@SignatureSignatoryPartyPostalAddressRoom,@SignatureSignatoryPartyPostalAddressStreetName,
                                                            @SignatureSignatoryPartyPostalAddressBuildingName,@SignatureSignatoryPartyPostalAddressBuildingNumber,
                                                            @SignatureSignatoryPartyPostalAddressCitySubdivisionName,@SignatureSignatoryPartyPostalAddressCityName,
                                                            @SignatureSignatoryPartyPostalAddressPostalZone, 
                                                            @SignatureSignatoryPartyPostalAddressCountryName,@AccSupplierPartyName,
                                                            @AccSupplierPartyPostalAddressRoom,@AccSupplierPartyPostalAddressStreetName,@AccSupplierPartyPostalAddressBuildingName,
                                                            @AccSupplierPartyPostalAddressBuildingNumber,@AccSupplierPartyPostalAddressCitySubdivisionName,@AccSupplierPartyPostalAddressCityName,
                                                            @AccSupplierPartyPostalAddressPostalZone,@AccSupplierPartyPostalAddressCountryName,@AccSupplierPartyTaxSchemeName,@AccSupplierPartyTaxSchemeCode,@AccSupplierPartyIdentificationSchemeID,
                                                            @AccSupplierPartyContactTelephone,@AccSupplierPartyContactTelefax,@AccSupplierPartyContactElectronicMail,@AccCustomerPartyIdentificationSchemeID,
                                                            @AccCustomerPartyName,@AccCustomerPartyPostalAddressRoom,@AccCustomerPartyPostalAddressBuildingName,@AccCustomerPartyPostalAddressStreetName,
                                                            @AccCustomerPartyPostalAddressBuildingNumber,@AccCustomerPartyPostalAddressCitySubdivisionName,@AccCustomerPartyPostalAddressCityName,
                                                            @AccCustomerPartyPostalAddressPostalZone,@AccCustomerPartyPostalAddressCountryName,@AccCustomerPartyTaxSchemeName,
                                                            @AccCustomerPartyTaxSchemeCode,@TaxTotalTaxAmountCurrencyID,@TaxTotalTaxAmount,@TaxSubtotalTaxableAmountCurrencyID,
                                                            @TaxSubtotalTaxableAmount,@TaxSubtotalTaxAmountCurrencyID,@TaxSubtotalTaxAmount,@TaxSubtotalPercent,@TaxSubtotalTaxCategoryTaxSchemeName,
                                                            @TaxSubtotalTaxCategoryTaxSchemeCode,@LegalMonetaryLineExtensionAmount,@LegalMonetaryTaxExclusiveAmount,@LegalMonetaryTaxInclusiveAmount,
                                                            @LegalMonetaryPayableAmount,@InvoiceTypeCode,@ProfileID,@MUSTERI_KODU,@MUSTERI_GRUBU,@FATURA_TURU,@MECRA_TURU,@MECRA_ADI,@FATURA_YENI,@ISLEM_TURU
                                                            )  SELECT @@IDENTITY AS ID   ";        
  

               DateTime dt = DateTime.Parse(DATE_FATURA_TARIHI.Text);
               DateTime dtGelis = DateTime.Parse(DATE_GELISTARIHI.Text);
                                                       
                cmd.CommandText = HEADER_TABLE_SQL;
                cmd.Parameters.AddWithValue("@SIRKET_KODU", CMB_SIRKET_KODU.Text);
                cmd.Parameters.AddWithValue("@FATURA_TIPI", 'P');                
                cmd.Parameters.AddWithValue("@ID", TXT_FATURANO.Text);
                cmd.Parameters.AddWithValue("@GUID", g);
                cmd.Parameters.AddWithValue("@UUID", g);
                cmd.Parameters.AddWithValue("@IssueDate", dt.ToString("yyyy.MM.dd").ToString());
                cmd.Parameters.AddWithValue("@UBLExtensionObjectSigningTime", dtGelis.ToString("yyyy.MM.dd").ToString());

                cmd.Parameters.AddWithValue("@InvoiceTypeCode", CMB_FATURA_TURU.Text);
                cmd.Parameters.AddWithValue("@ProfileID", CMB_FATURA_TIPI.Text);
        
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
                cmd.Parameters.AddWithValue("@AccSupplierPartyIdentificationSchemeID", TXT_PAZARLAMA_SIRKETI_VKN.Text);
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
                cmd.Parameters.AddWithValue("@MECRA_TURU", CMB_MECRA_TURU.Text);
                cmd.Parameters.AddWithValue("@MECRA_ADI", CMB_MECRA_KODU.Text);
                cmd.Parameters.AddWithValue("@FATURA_YENI", '1');
                cmd.Parameters.AddWithValue("@ISLEM_TURU", CMB_ISLEM_TURU.Text );
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
            Guid g = Guid.NewGuid();
            using (SqlCommand cmd = new SqlCommand())
            {
                string HEADER_TABLE_SQL = @" UPDATE dbo.FTR_GELEN_FATURALAR 
                                                         SET  SIRKET_KODU=@SIRKET_KODU,ID=@ID,InvoiceTypeCode=@InvoiceTypeCode,ProfileID=@ProfileID,IssueDate=@IssueDate,UBLExtensionObjectSigningTime=@UBLExtensionObjectSigningTime,Note=@Note,DocumentCurrencyCode=@DocumentCurrencyCode,AdditionalDocumentID=@AdditionalDocumentID,AdditionalDocumentIssueDate=@AdditionalDocumentIssueDate,SignatureSchemeID=@SignatureSchemeID,
                                                            SignatureSignatoryPartyIdentificationSchemeID=@SignatureSignatoryPartyIdentificationSchemeID,SignatureSignatoryPartyPostalAddressRoom=@SignatureSignatoryPartyPostalAddressRoom,SignatureSignatoryPartyPostalAddressStreetName=@SignatureSignatoryPartyPostalAddressStreetName,
                                                            SignatureSignatoryPartyPostalAddressBuildingName=@SignatureSignatoryPartyPostalAddressBuildingName,SignatureSignatoryPartyPostalAddressBuildingNumber=@SignatureSignatoryPartyPostalAddressBuildingNumber,
                                                            SignatureSignatoryPartyPostalAddressCitySubdivisionName=@SignatureSignatoryPartyPostalAddressCitySubdivisionName,SignatureSignatoryPartyPostalAddressCityName=@SignatureSignatoryPartyPostalAddressCityName,
                                                            SignatureSignatoryPartyPostalAddressPostalZone=@SignatureSignatoryPartyPostalAddressPostalZone, 
                                                            SignatureSignatoryPartyPostalAddressCountryName=@SignatureSignatoryPartyPostalAddressCountryName,AccSupplierPartyName=@AccSupplierPartyName,
                                                            AccSupplierPartyPostalAddressRoom=@AccSupplierPartyPostalAddressRoom,AccSupplierPartyPostalAddressStreetName=@AccSupplierPartyPostalAddressStreetName,AccSupplierPartyPostalAddressBuildingName=@AccSupplierPartyPostalAddressBuildingName,
                                                            AccSupplierPartyPostalAddressBuildingNumber=@AccSupplierPartyPostalAddressBuildingNumber,AccSupplierPartyPostalAddressCitySubdivisionName=@AccSupplierPartyPostalAddressCitySubdivisionName,AccSupplierPartyPostalAddressCityName=@AccSupplierPartyPostalAddressCityName,
                                                            AccSupplierPartyPostalAddressPostalZone=@AccSupplierPartyPostalAddressPostalZone,AccSupplierPartyPostalAddressCountryName=@AccSupplierPartyPostalAddressCountryName,AccSupplierPartyTaxSchemeName=@AccSupplierPartyTaxSchemeName,AccSupplierPartyTaxSchemeCode=@AccSupplierPartyTaxSchemeCode,AccSupplierPartyIdentificationSchemeID=@AccSupplierPartyIdentificationSchemeID,
                                                            AccSupplierPartyContactTelephone=@AccSupplierPartyContactTelephone,AccSupplierPartyContactTelefax=@AccSupplierPartyContactTelefax,AccSupplierPartyContactElectronicMail=@AccSupplierPartyContactElectronicMail,AccCustomerPartyIdentificationSchemeID=@AccCustomerPartyIdentificationSchemeID,
                                                            AccCustomerPartyName=@AccCustomerPartyName,AccCustomerPartyPostalAddressRoom=@AccCustomerPartyPostalAddressRoom,AccCustomerPartyPostalAddressBuildingName=@AccCustomerPartyPostalAddressBuildingName,AccCustomerPartyPostalAddressStreetName=@AccCustomerPartyPostalAddressStreetName,
                                                            AccCustomerPartyPostalAddressBuildingNumber=@AccCustomerPartyPostalAddressBuildingNumber,AccCustomerPartyPostalAddressCitySubdivisionName=@AccCustomerPartyPostalAddressCitySubdivisionName,AccCustomerPartyPostalAddressCityName=@AccCustomerPartyPostalAddressCityName,
                                                            AccCustomerPartyPostalAddressPostalZone=@AccCustomerPartyPostalAddressPostalZone,AccCustomerPartyPostalAddressCountryName=@AccCustomerPartyPostalAddressCountryName,AccCustomerPartyTaxSchemeName=@AccCustomerPartyTaxSchemeName,
                                                            AccCustomerPartyTaxSchemeCode=@AccCustomerPartyTaxSchemeCode,TaxTotalTaxAmountCurrencyID=@TaxTotalTaxAmountCurrencyID,TaxTotalTaxAmount=@TaxTotalTaxAmount,TaxSubtotalTaxableAmountCurrencyID=@TaxSubtotalTaxableAmountCurrencyID,
                                                            TaxSubtotalTaxableAmount=@TaxSubtotalTaxableAmount,TaxSubtotalTaxAmountCurrencyID=@TaxSubtotalTaxAmountCurrencyID,TaxSubtotalTaxAmount=@TaxSubtotalTaxAmount,TaxSubtotalPercent=@TaxSubtotalPercent,TaxSubtotalTaxCategoryTaxSchemeName=@TaxSubtotalTaxCategoryTaxSchemeName,
                                                            TaxSubtotalTaxCategoryTaxSchemeCode=@TaxSubtotalTaxCategoryTaxSchemeCode,LegalMonetaryLineExtensionAmount=@LegalMonetaryLineExtensionAmount,LegalMonetaryTaxExclusiveAmount=@LegalMonetaryTaxExclusiveAmount,LegalMonetaryTaxInclusiveAmount=@LegalMonetaryTaxInclusiveAmount,
                                                            LegalMonetaryPayableAmount=@LegalMonetaryPayableAmount,MUSTERI_KODU=@MUSTERI_KODU,MUSTERI_GRUBU=@MUSTERI_GRUBU,FATURA_TURU=@FATURA_TURU,MECRA_TURU=@MECRA_TURU,MECRA_ADI=@MECRA_ADI,FATURA_YENI=@FATURA_YENI   WHERE (OID =" + ID +")";  
                                                           


                DateTime dt = DateTime.Parse(DATE_FATURA_TARIHI.Text);
                DateTime dtGelis = DateTime.Parse(DATE_GELISTARIHI.Text);

                cmd.CommandText = HEADER_TABLE_SQL;
                cmd.Parameters.AddWithValue("@SIRKET_KODU", CMB_SIRKET_KODU.Text); 
                cmd.Parameters.AddWithValue("@ID", TXT_FATURANO.Text); 
                cmd.Parameters.AddWithValue("@IssueDate", dt.ToString("yyyy.MM.dd").ToString());
                cmd.Parameters.AddWithValue("@UBLExtensionObjectSigningTime", dtGelis.ToString("yyyy.MM.dd").ToString());

                cmd.Parameters.AddWithValue("@InvoiceTypeCode", CMB_FATURA_TURU.Text);
                cmd.Parameters.AddWithValue("@ProfileID", CMB_FATURA_TIPI.Text);


                cmd.Parameters.AddWithValue("@Note", TXT_NOTU.Text);
                cmd.Parameters.AddWithValue("@DocumentCurrencyCode", COM_BX_PB.Text);
                cmd.Parameters.AddWithValue("@AdditionalDocumentID", TXT_FATURANO.Text); 
                cmd.Parameters.AddWithValue("@AdditionalDocumentIssueDate", dt.ToString("yyyy.MM.dd").ToString()); 
                cmd.Parameters.AddWithValue("@SignatureSchemeID", TXT_PAZARLAMA_SIRKETI_VKN.Text);
                cmd.Parameters.AddWithValue("@SignatureSignatoryPartyIdentificationSchemeID", TXT_PAZARLAMA_SIRKETI_VKN.Text);
                cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressRoom", TXT_KAT.Text);
                cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressStreetName", TXT_ADRESI.Text);
                cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressBuildingName", TXT_BINA_ADI.Text);
                cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressBuildingNumber", TXT_BINA_NO.Text);
                cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressCitySubdivisionName", CMB_ILCE.Text);
                cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressCityName", CMB_IL.Text);
                cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressPostalZone", TXT_PK.Text); 
                cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressCountryName", CMB_ULKE.Text);
                cmd.Parameters.AddWithValue("@AccSupplierPartyName", CMB_PAZARLAMA_SIRKETI.Text);
                cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressRoom", TXT_KAT.Text);
                cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressStreetName", TXT_ADRESI.Text);
                cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressBuildingName", TXT_BINA_ADI.Text);
                cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressBuildingNumber", TXT_BINA_NO.Text);
                cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressCitySubdivisionName", CMB_ILCE.Text);
                cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressCityName", CMB_IL.Text); 
                cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressPostalZone", TXT_PK.Text);
                cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressCountryName", CMB_ULKE.Text);
                cmd.Parameters.AddWithValue("@AccSupplierPartyTaxSchemeName", TXT_PAZARLAMA_SIRKETI_VERGI_DAIRESI.Text);
                cmd.Parameters.AddWithValue("@AccSupplierPartyTaxSchemeCode", TXT_PAZARLAMA_SIRKETI_VKN.Text);
                cmd.Parameters.AddWithValue("@AccSupplierPartyIdentificationSchemeID", TXT_PAZARLAMA_SIRKETI_VKN.Text);
                cmd.Parameters.AddWithValue("@AccSupplierPartyContactTelephone", TXT_TELEFON.Text);
                cmd.Parameters.AddWithValue("@AccSupplierPartyContactTelefax", TXT_FAX.Text);
                cmd.Parameters.AddWithValue("@AccSupplierPartyContactElectronicMail", TXT_EMAIL.Text); 
                cmd.Parameters.AddWithValue("@AccCustomerPartyIdentificationSchemeID", TXT_SIRKET_VKN.Text);
                cmd.Parameters.AddWithValue("@AccCustomerPartyName", TXT_SIRKET_ADI.Text);
                cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressRoom", TXT_SIRKET_BINANO.Text);
                cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressBuildingName", TXT_SIRKET_BINAADI.Text);
                cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressStreetName", TXT_SIRKET_ADRESI.Text);
                cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressBuildingNumber", TXT_SIRKET_BINANO.Text);
                cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressCitySubdivisionName", TXT_SIRKET_ILCE.Text);
                cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressCityName", TXT_SIRKET_IL.Text);
                cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressPostalZone", TXT_SIRKET_PK.Text);
                cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressCountryName", TXT_SIRKET_ULKE.Text);
                cmd.Parameters.AddWithValue("@AccCustomerPartyTaxSchemeName", TXT_SIRKET_VD.Text);
                cmd.Parameters.AddWithValue("@AccCustomerPartyTaxSchemeCode", TXT_SIRKET_VKN.Text);
                cmd.Parameters.AddWithValue("@TaxTotalTaxAmountCurrencyID", COM_BX_PB.Text);
                cmd.Parameters.AddWithValue("@TaxTotalTaxAmount", float.Parse(TXT_KDVTUTARI.Text));
                cmd.Parameters.AddWithValue("@TaxSubtotalTaxableAmountCurrencyID", COM_BX_PB.Text);
                cmd.Parameters.AddWithValue("@TaxSubtotalTaxableAmount", float.Parse(TXT_FATURATUTARI.Text));
                cmd.Parameters.AddWithValue("@TaxSubtotalTaxAmountCurrencyID", COM_BX_PB.Text);
                cmd.Parameters.AddWithValue("@TaxSubtotalTaxAmount", float.Parse(TXT_KDVTUTARI.Text));
                cmd.Parameters.AddWithValue("@TaxSubtotalPercent", float.Parse(TXT_KDV_ORANI.Text));
                cmd.Parameters.AddWithValue("@TaxSubtotalTaxCategoryTaxSchemeName", "KDV");
                cmd.Parameters.AddWithValue("@TaxSubtotalTaxCategoryTaxSchemeCode", "0015");
                cmd.Parameters.AddWithValue("@LegalMonetaryLineExtensionAmount", float.Parse(TXT_FATURATUTARI.Text));
                cmd.Parameters.AddWithValue("@LegalMonetaryTaxExclusiveAmount", float.Parse(TXT_FATURATUTARI.Text));
                cmd.Parameters.AddWithValue("@LegalMonetaryTaxInclusiveAmount", float.Parse(TXT_GENELTUTARI.Text)); 
                cmd.Parameters.AddWithValue("@LegalMonetaryPayableAmount", float.Parse(TXT_GENELTUTARI.Text));
                cmd.Parameters.AddWithValue("@MUSTERI_KODU", TXT_MUSTERI_KODU.Text);
                cmd.Parameters.AddWithValue("@MUSTERI_GRUBU", TXT_MUSTERI_GRUBU.Text);
                cmd.Parameters.AddWithValue("@FATURA_TURU", CMB_FATURA_TURU.Text);
                cmd.Parameters.AddWithValue("@MECRA_TURU", CMB_MECRA_TURU.Text);
                cmd.Parameters.AddWithValue("@MECRA_ADI", CMB_MECRA_KODU.Text);
                cmd.Parameters.AddWithValue("@FATURA_YENI", '1'); 
                cmd.Connection = myConnectionTable;
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }




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

        private void ALIS_FATURASI_Load(object sender, EventArgs e)
        {

        }

        private void TXT_FATURATUTARI_EditValueChanged(object sender, EventArgs e)
        {
             TXT_KDVTUTARI.Text =  Convert.ToDouble(Convert.ToDouble(TXT_FATURATUTARI.Text.ToString ()) * Convert.ToDouble(TXT_KDV_ORANI.Text.ToString ()) / 100).ToString (); 
             TXT_GENELTUTARI.Text = Convert.ToDouble(Convert.ToDouble(TXT_KDVTUTARI.Text.ToString ()) +Convert.ToDouble(TXT_FATURATUTARI.Text.ToString ())).ToString () ;
        }

        private void TXT_PAZARLAMA_SIRKETI_VKN_EditValueChanged(object sender, EventArgs e)
        {
          
        }

        private void TXT_PAZARLAMA_SIRKETI_VKN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13 || (e.KeyChar==(char)Keys.Tab))    
            {
                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                {
                    string mySelectQuery = "  SELECT  UNVANI,KODU,SAHIS_SIRKETI,TC_KIMLIK_NO,VERGI_NO,VERGI_DAIRESI from  dbo.ADM_PAZARLAMA_SIRKETI WHERE VERGI_NO='" + TXT_PAZARLAMA_SIRKETI_VKN.EditValue.ToString() + "' OR TC_KIMLIK_NO='" + TXT_PAZARLAMA_SIRKETI_VKN.EditValue.ToString() + "'   ";
                    SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);

                    myCommand.CommandText = mySelectQuery.ToString();
                    myConnection.Open();
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                    myConnections.Open();
                    while (myReader.Read())
                    {
                        CMB_PAZARLAMA_SIRKETI.Text = myReader["UNVANI"].ToString();
                        TXT_PAZARLAMA_SIRKETI_KODU.Text = myReader["KODU"].ToString();
                         
                            if (myReader["SAHIS_SIRKETI"].ToString() == "SAHIS")   TXT_PAZARLAMA_SIRKETI_VKN.Text = myReader["TC_KIMLIK_NO"].ToString();
                            if (myReader["SAHIS_SIRKETI"].ToString() == "TUZEL") TXT_PAZARLAMA_SIRKETI_VKN.Text = myReader["VERGI_NO"].ToString();

                        //TXT_PAZARLAMA_SIRKETI_VKN.Text = myReader["VERGI_NO"].ToString();
                        TXT_PAZARLAMA_SIRKETI_VERGI_DAIRESI.Text = myReader["VERGI_DAIRESI"].ToString();
                    }
                }
            }
        }


      

      
    }
}