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
    public partial class GIB_READ : DevExpress.XtraEditors.XtraForm
    {
        public GIB_READ()
        {
            InitializeComponent();
            this.Tag = "MDIFORM";
        }
        DataSet ds;
        private void BTN_ONAY_REFRESH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //string con = "Password=nabuKad_07;Persist Security Info=True;User ID=grm_sa;Initial Catalog=WeSOURCE;Data Source=10.219.168.92";
            using (SqlConnection MySqlConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP))//_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString()
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * from GIBGELEN_" + BTN_FIRMA.EditValue+"_01 ", MySqlConnection); 
                ds = new DataSet();
                da.Fill(ds, "Header");
                DataViewManager dvManager = new DataViewManager(ds);
                DataView dv = dvManager.CreateDataView(ds.Tables[0]);
                GRD_LISTE.DataSource = dv;
            }
        }

        private void BTN_GIB_FATURA_INDIR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
         

                    SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                    myConnectionTable.Open();
                  //  string con = "Password=nabuKad_07;Persist Security Info=True;User ID=grm_sa;Initial Catalog=WeSOURCE;Data Source=10.219.168.92";
                    SqlConnection MySqlConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP) ;
                    MySqlConnection.Open();
                    re_PROGRESS_BAR.Maximum = ds.Tables["Header"].Rows.Count;
                    int OIID = 0;
                    var GUID = "";
                    for (int index = 0; index < ds.Tables["Header"].Rows.Count; index++)
                    {
                        BR_PROGRESS_BAR.EditValue = index;
                        BR_PROGRESS_BAR.Refresh();
                        OIID = 0; GUID = Guid.NewGuid().ToString();
                        DataRow dr = ds.Tables["Header"].Rows[index];

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            string HEADER_TABLE_SQL = " INSERT INTO dbo.FTR_GELEN_FATURALAR ( FATURA_TIPI,SIRKET_KODU,UBLVersionID, CustomizationID, ProfileID, ID, CopyIndicator, UUID, IssueDate, InvoiceTypeCode, Note, DocumentCurrencyCode, LineCountNumeric, DespatchDocumentID, DespatchDocumentIssueDate, OrderReferenceID, OrderReferenceIssueDate, AdditionalDocumentID, AdditionalDocumentIssueDate, AdditionalDocumentEncode, AdditionalDocumentCharacterSetCode, AdditionalDocumentFileName, SignatureSchemeID, SignatureSignatoryPartyIdentificationSchemeID, SignatureSignatoryPartyPostalAddressRoom, SignatureSignatoryPartyPostalAddressStreetName, SignatureSignatoryPartyPostalAddressBuildingName, SignatureSignatoryPartyPostalAddressBuildingNumber, SignatureSignatoryPartyPostalAddressCitySubdivisionName, SignatureSignatoryPartyPostalAddressCityName, SignatureSignatoryPartyPostalAddressPostalZone, SignatureSignatoryPartyPostalAddressRegion, SignatureSignatoryPartyPostalAddressCountryName, SignatureDigitalSignatureAttachmentURI, AccSupplierPartyWebsiteURI, AccSupplierPartyIdentificationSchemeID, AccSupplierPartyName, AccSupplierPartyPostalAddressRoom, AccSupplierPartyPostalAddressStreetName, AccSupplierPartyPostalAddressBuildingName, AccSupplierPartyPostalAddressBuildingNumber, AccSupplierPartyPostalAddressCitySubdivisionName, AccSupplierPartyPostalAddressCityName, AccSupplierPartyPostalAddressRegion, AccSupplierPartyPostalAddressPostalZone, AccSupplierPartyPostalAddressCountryName, AccSupplierPartyTaxSchemeName, AccSupplierPartyTaxSchemeCode, AccSupplierPartyContactTelephone, AccSupplierPartyContactTelefax, AccSupplierPartyContactElectronicMail, AccCustomerPartyWebsiteURI, AccCustomerPartyIdentificationSchemeID, AccCustomerPartyName, AccCustomerPartyPostalAddressRoom, AccCustomerPartyPostalAddressBuildingName, AccCustomerPartyPostalAddressStreetName, AccCustomerPartyPostalAddressRegion, AccCustomerPartyPostalAddressBuildingNumber, AccCustomerPartyPostalAddressCitySubdivisionName, AccCustomerPartyPostalAddressCityName, AccCustomerPartyPostalAddressPostalZone, AccCustomerPartyPostalAddressCountryName, AccCustomerPartyTaxSchemeName, AccCustomerPartyTaxSchemeCode, AccCustomerPartyContactTelephone, AccCustomerPartyContactTelefax, AccCustomerPartyContactElectronicMail, PaymentMeansCode, PaymentMeansDueDate, PaymentMeansPayeeFinancialAccountID, PaymentMeansPayeeFinancialAccountCurrencyCode, PaymentMeansPayeeFinancialAccountPaymentNote, PaymentTermsNote, AllowanceChargeChargeIndicator, AllowanceChargeMultiplierFactorNumeric, AllowanceChargeAmountCurrencyID, AllowanceChargeAmount, TaxTotalTaxAmountCurrencyID, TaxTotalTaxAmount, TaxSubtotalTaxableAmountCurrencyID, TaxSubtotalTaxableAmount, TaxSubtotalTaxAmountCurrencyID, TaxSubtotalTaxAmount, TaxSubtotalPercent, TaxSubtotalTaxCategoryTaxSchemeName, TaxSubtotalTaxCategoryTaxSchemeCode, LegalMonetaryLineExtensionAmount, LegalMonetaryTaxExclusiveAmount, LegalMonetaryTaxInclusiveAmount, LegalMonetaryAllowanceTotalAmount, LegalMonetaryPayableAmount, UBLExtensionObjectSigningTime, PCount, FATURA_TXT,MUSTERI_KODU,MUSTERI_GRUBU,FATURA_TURU,MECRA_TURU,MECRA_ADI,FATURA_YENI,PLAN_KODU)  " +
                                                                    " Values (@FATURA_TIPI,@SIRKET_KODU,@UBLVersionID,@CustomizationID,@ProfileID,@ID,@CopyIndicator,@UUID,@IssueDate,@InvoiceTypeCode,@Note,@DocumentCurrencyCode,@LineCountNumeric,@DespatchDocumentID,@DespatchDocumentIssueDate,@OrderReferenceID,@OrderReferenceIssueDate,@AdditionalDocumentID,@AdditionalDocumentIssueDate,@AdditionalDocumentEncode,@AdditionalDocumentCharacterSetCode,@AdditionalDocumentFileName,@SignatureSchemeID,@SignatureSignatoryPartyIdentificationSchemeID,@SignatureSignatoryPartyPostalAddressRoom,@SignatureSignatoryPartyPostalAddressStreetName,@SignatureSignatoryPartyPostalAddressBuildingName,@SignatureSignatoryPartyPostalAddressBuildingNumber,@SignatureSignatoryPartyPostalAddressCitySubdivisionName,@SignatureSignatoryPartyPostalAddressCityName,@SignatureSignatoryPartyPostalAddressPostalZone,@SignatureSignatoryPartyPostalAddressRegion,@SignatureSignatoryPartyPostalAddressCountryName,@SignatureDigitalSignatureAttachmentURI,@AccSupplierPartyWebsiteURI,@AccSupplierPartyIdentificationSchemeID,@AccSupplierPartyName,@AccSupplierPartyPostalAddressRoom,@AccSupplierPartyPostalAddressStreetName,@AccSupplierPartyPostalAddressBuildingName,@AccSupplierPartyPostalAddressBuildingNumber,@AccSupplierPartyPostalAddressCitySubdivisionName,@AccSupplierPartyPostalAddressCityName,@AccSupplierPartyPostalAddressRegion,@AccSupplierPartyPostalAddressPostalZone,@AccSupplierPartyPostalAddressCountryName,@AccSupplierPartyTaxSchemeName,@AccSupplierPartyTaxSchemeCode,@AccSupplierPartyContactTelephone,@AccSupplierPartyContactTelefax,@AccSupplierPartyContactElectronicMail,@AccCustomerPartyWebsiteURI,@AccCustomerPartyIdentificationSchemeID,@AccCustomerPartyName,@AccCustomerPartyPostalAddressRoom,@AccCustomerPartyPostalAddressBuildingName,@AccCustomerPartyPostalAddressStreetName,@AccCustomerPartyPostalAddressRegion,@AccCustomerPartyPostalAddressBuildingNumber,@AccCustomerPartyPostalAddressCitySubdivisionName,@AccCustomerPartyPostalAddressCityName,@AccCustomerPartyPostalAddressPostalZone,@AccCustomerPartyPostalAddressCountryName,@AccCustomerPartyTaxSchemeName,@AccCustomerPartyTaxSchemeCode,@AccCustomerPartyContactTelephone,@AccCustomerPartyContactTelefax,@AccCustomerPartyContactElectronicMail,@PaymentMeansCode,@PaymentMeansDueDate,@PaymentMeansPayeeFinancialAccountID,@PaymentMeansPayeeFinancialAccountCurrencyCode,@PaymentMeansPayeeFinancialAccountPaymentNote,@PaymentTermsNote,@AllowanceChargeChargeIndicator,@AllowanceChargeMultiplierFactorNumeric,@AllowanceChargeAmountCurrencyID,@AllowanceChargeAmount,@TaxTotalTaxAmountCurrencyID,@TaxTotalTaxAmount,@TaxSubtotalTaxableAmountCurrencyID,@TaxSubtotalTaxableAmount,@TaxSubtotalTaxAmountCurrencyID,@TaxSubtotalTaxAmount,@TaxSubtotalPercent,@TaxSubtotalTaxCategoryTaxSchemeName,@TaxSubtotalTaxCategoryTaxSchemeCode,@LegalMonetaryLineExtensionAmount,@LegalMonetaryTaxExclusiveAmount,@LegalMonetaryTaxInclusiveAmount,@LegalMonetaryAllowanceTotalAmount,@LegalMonetaryPayableAmount,@UBLExtensionObjectSigningTime,@PCount, @FATURA_TXT,@MUSTERI_KODU,@MUSTERI_GRUBU,@FATURA_TURU,@MECRA_TURU,@MECRA_ADI,@FATURA_YENI,@PLAN_KODU)" +
                                                                    "  SELECT @@IDENTITY AS ID   ";
                            cmd.CommandText = HEADER_TABLE_SQL;
                            cmd.Parameters.AddWithValue("@FATURA_TIPI", 'E');
                            cmd.Parameters.AddWithValue("@SIRKET_KODU",  BTN_FIRMA.EditValue);
                            cmd.Parameters.AddWithValue("@GUID",GUID);
                            cmd.Parameters.AddWithValue("@UBLVersionID", dr["UBLVersionID"]);
                            cmd.Parameters.AddWithValue("@CustomizationID", dr["CustomizationID"]);
                            cmd.Parameters.AddWithValue("@ProfileID", dr["ProfileID"]);
                            cmd.Parameters.AddWithValue("@ID", dr["ID"]);
                            cmd.Parameters.AddWithValue("@CopyIndicator", dr["CopyIndicator"]);
                            cmd.Parameters.AddWithValue("@UUID", dr["UUID"]);
                            cmd.Parameters.AddWithValue("@IssueDate", dr["IssueDate"]);
                            cmd.Parameters.AddWithValue("@InvoiceTypeCode", dr["InvoiceTypeCode"]);
                            cmd.Parameters.AddWithValue("@Note", dr["Note"]);
                            cmd.Parameters.AddWithValue("@DocumentCurrencyCode", dr["DocumentCurrencyCode"]);
                            cmd.Parameters.AddWithValue("@LineCountNumeric", dr["LineCountNumeric"]);
                            cmd.Parameters.AddWithValue("@DespatchDocumentID", dr["DespatchDocumentID"]);
                            cmd.Parameters.AddWithValue("@DespatchDocumentIssueDate", dr["DespatchDocumentIssueDate"]);
                            cmd.Parameters.AddWithValue("@OrderReferenceID", dr["OrderReferenceID"]);
                            cmd.Parameters.AddWithValue("@OrderReferenceIssueDate", dr["OrderReferenceIssueDate"]);
                            cmd.Parameters.AddWithValue("@AdditionalDocumentID", dr["AdditionalDocumentID"]);
                            cmd.Parameters.AddWithValue("@AdditionalDocumentIssueDate", dr["AdditionalDocumentIssueDate"]);
                            cmd.Parameters.AddWithValue("@AdditionalDocumentEncode", dr["AdditionalDocumentEncode"]);
                            cmd.Parameters.AddWithValue("@AdditionalDocumentCharacterSetCode", dr["AdditionalDocumentCharacterSetCode"]);
                            cmd.Parameters.AddWithValue("@AdditionalDocumentFileName", dr["AdditionalDocumentFileName"]);
                            cmd.Parameters.AddWithValue("@SignatureSchemeID", dr["SignatureSchemeID"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyIdentificationSchemeID", dr["SignatureSignatoryPartyIdentificationSchemeID"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressRoom", dr["SignatureSignatoryPartyPostalAddressRoom"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressStreetName", dr["SignatureSignatoryPartyPostalAddressStreetName"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressBuildingName", dr["SignatureSignatoryPartyPostalAddressBuildingName"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressBuildingNumber", dr["SignatureSignatoryPartyPostalAddressBuildingNumber"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressCitySubdivisionName", dr["SignatureSignatoryPartyPostalAddressCitySubdivisionName"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressCityName", dr["SignatureSignatoryPartyPostalAddressCityName"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressPostalZone", dr["SignatureSignatoryPartyPostalAddressPostalZone"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressRegion", dr["SignatureSignatoryPartyPostalAddressRegion"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressCountryName", dr["SignatureSignatoryPartyPostalAddressCountryName"]);
                            cmd.Parameters.AddWithValue("@SignatureDigitalSignatureAttachmentURI", dr["SignatureDigitalSignatureAttachmentURI"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyWebsiteURI", dr["AccSupplierPartyWebsiteURI"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyIdentificationSchemeID", dr["AccSupplierPartyIdentificationSchemeID"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyName", dr["AccSupplierPartyName"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressRoom", dr["AccSupplierPartyPostalAddressRoom"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressStreetName", dr["AccSupplierPartyPostalAddressStreetName"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressBuildingName", dr["AccSupplierPartyPostalAddressBuildingName"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressBuildingNumber", dr["AccSupplierPartyPostalAddressBuildingNumber"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressCitySubdivisionName", dr["AccSupplierPartyPostalAddressCitySubdivisionName"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressCityName", dr["AccSupplierPartyPostalAddressCityName"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressRegion", dr["AccSupplierPartyPostalAddressRegion"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressPostalZone", dr["AccSupplierPartyPostalAddressPostalZone"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressCountryName", dr["AccSupplierPartyPostalAddressCountryName"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyTaxSchemeName", dr["AccSupplierPartyTaxSchemeName"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyTaxSchemeCode", dr["AccSupplierPartyTaxSchemeCode"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyContactTelephone", dr["AccSupplierPartyContactTelephone"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyContactTelefax", dr["AccSupplierPartyContactTelefax"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyContactElectronicMail", dr["AccSupplierPartyContactElectronicMail"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyWebsiteURI", dr["AccCustomerPartyWebsiteURI"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyIdentificationSchemeID", dr["AccCustomerPartyIdentificationSchemeID"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyName", dr["AccCustomerPartyName"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressRoom", dr["AccCustomerPartyPostalAddressRoom"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressBuildingName", dr["AccCustomerPartyPostalAddressBuildingName"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressStreetName", dr["AccCustomerPartyPostalAddressStreetName"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressRegion", dr["AccCustomerPartyPostalAddressRegion"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressBuildingNumber", dr["AccCustomerPartyPostalAddressBuildingNumber"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressCitySubdivisionName", dr["AccCustomerPartyPostalAddressCitySubdivisionName"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressCityName", dr["AccCustomerPartyPostalAddressCityName"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressPostalZone", dr["AccCustomerPartyPostalAddressPostalZone"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressCountryName", dr["AccCustomerPartyPostalAddressCountryName"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyTaxSchemeName", dr["AccCustomerPartyTaxSchemeName"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyTaxSchemeCode", dr["AccCustomerPartyTaxSchemeCode"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyContactTelephone", dr["AccCustomerPartyContactTelephone"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyContactTelefax", dr["AccCustomerPartyContactTelefax"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyContactElectronicMail", dr["AccCustomerPartyContactElectronicMail"]);
                            cmd.Parameters.AddWithValue("@PaymentMeansCode", dr["PaymentMeansCode"]);
                            cmd.Parameters.AddWithValue("@PaymentMeansDueDate", dr["PaymentMeansDueDate"]);
                            cmd.Parameters.AddWithValue("@PaymentMeansPayeeFinancialAccountID", dr["PaymentMeansPayeeFinancialAccountID"]);
                            cmd.Parameters.AddWithValue("@PaymentMeansPayeeFinancialAccountCurrencyCode", dr["PaymentMeansPayeeFinancialAccountCurrencyCode"]);
                            cmd.Parameters.AddWithValue("@PaymentMeansPayeeFinancialAccountPaymentNote", dr["PaymentMeansPayeeFinancialAccountPaymentNote"]);
                            cmd.Parameters.AddWithValue("@PaymentTermsNote", dr["PaymentTermsNote"]);
                            cmd.Parameters.AddWithValue("@AllowanceChargeChargeIndicator", dr["AllowanceChargeChargeIndicator"]);
                            cmd.Parameters.AddWithValue("@AllowanceChargeMultiplierFactorNumeric", dr["AllowanceChargeMultiplierFactorNumeric"]);
                            cmd.Parameters.AddWithValue("@AllowanceChargeAmountCurrencyID", dr["AllowanceChargeAmountCurrencyID"]);
                            cmd.Parameters.AddWithValue("@AllowanceChargeAmount", dr["AllowanceChargeAmount"]);
                            cmd.Parameters.AddWithValue("@TaxTotalTaxAmountCurrencyID", dr["TaxTotalTaxAmountCurrencyID"]);
                            cmd.Parameters.AddWithValue("@TaxTotalTaxAmount", dr["TaxTotalTaxAmount"]);
                            cmd.Parameters.AddWithValue("@TaxSubtotalTaxableAmountCurrencyID", dr["TaxSubtotalTaxableAmountCurrencyID"]);
                            cmd.Parameters.AddWithValue("@TaxSubtotalTaxableAmount", dr["TaxSubtotalTaxableAmount"]);
                            cmd.Parameters.AddWithValue("@TaxSubtotalTaxAmountCurrencyID", dr["TaxSubtotalTaxAmountCurrencyID"]);
                            cmd.Parameters.AddWithValue("@TaxSubtotalTaxAmount", dr["TaxSubtotalTaxAmount"]);
                            cmd.Parameters.AddWithValue("@TaxSubtotalPercent", dr["TaxSubtotalPercent"]);
                            cmd.Parameters.AddWithValue("@TaxSubtotalTaxCategoryTaxSchemeName", dr["TaxSubtotalTaxCategoryTaxSchemeName"]);
                            cmd.Parameters.AddWithValue("@TaxSubtotalTaxCategoryTaxSchemeCode", dr["TaxSubtotalTaxCategoryTaxSchemeCode"]);
                            cmd.Parameters.AddWithValue("@LegalMonetaryLineExtensionAmount", dr["LegalMonetaryLineExtensionAmount"]);
                            cmd.Parameters.AddWithValue("@LegalMonetaryTaxExclusiveAmount", dr["LegalMonetaryTaxExclusiveAmount"]);
                            cmd.Parameters.AddWithValue("@LegalMonetaryTaxInclusiveAmount", dr["LegalMonetaryTaxInclusiveAmount"]);
                            cmd.Parameters.AddWithValue("@LegalMonetaryAllowanceTotalAmount", dr["LegalMonetaryAllowanceTotalAmount"]);
                            cmd.Parameters.AddWithValue("@LegalMonetaryPayableAmount", dr["LegalMonetaryPayableAmount"]);
                            cmd.Parameters.AddWithValue("@UBLExtensionObjectSigningTime", dr["UBLExtensionObjectSigningTime"]);
                            cmd.Parameters.AddWithValue("@PCount", dr["PCount"]);
                            cmd.Parameters.AddWithValue("@FATURA_TXT", dr["FATURA_TXT"]);
                            cmd.Parameters.AddWithValue("@MUSTERI_KODU",dr["MUSTERI_KODU"]  );
                            cmd.Parameters.AddWithValue("@MUSTERI_GRUBU", dr["MUSTERI_GRUBU"]);
                            cmd.Parameters.AddWithValue("@FATURA_TURU", dr["FATURA_TURU"]);
                            cmd.Parameters.AddWithValue("@MECRA_TURU", dr["MECRA_TURU"]);
                            cmd.Parameters.AddWithValue("@MECRA_ADI", dr["MECRA_ADI"]);
                            cmd.Parameters.AddWithValue("@FATURA_YENI", '1');
                            cmd.Parameters.AddWithValue("@PLAN_KODU",dr["PLAN_KODU"]  );
                            cmd.Connection = myConnectionTable;
                            SqlDataReader myReader = cmd.ExecuteReader();
                            while (myReader.Read())
                            {
                                OIID = Convert.ToInt32(myReader["ID"].ToString()); 
                            } 
                            myReader.Close();  
                        }

                        DataSet dsln = new DataSet();  
                        SqlDataAdapter da = new SqlDataAdapter("SELECT * from GIBGELENDETAY_" + BTN_FIRMA.EditValue + "_01 where GIBGELEN=" + dr["OID"], MySqlConnection); 
                        da.Fill(dsln, "LINE");
                        DataViewManager dvManager = new DataViewManager(dsln);
                        DataView dv = dvManager.CreateDataView(dsln.Tables["LINE"]);
                        GRD_LISTE.DataSource = dv; 

           
                        for (int inde = 0; inde < dsln.Tables["LINE"].Rows.Count; inde++)
                        {
                            DataRow drx = dsln.Tables["LINE"].Rows[inde];
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                string LINE_SQL = @" INSERT INTO dbo.FTR_GELEN_FATURALAR_DETAYI ( FATURA_TIPI, SIRKET_KODU,INVOICE_REF,GUID, InvoiceLineID, InvoiceLineInvoicedQuantityUnitCode, InvoiceLineInvoicedQuantity, InvoiceLineLineExtensionAmountCurrencyID, InvoiceLineLineExtensionAmount, InvoiceLineAllowanceChargeChargeIndicator, InvoiceLineAllowanceChargeMultiplierFactorNumeric, InvoiceLineAllowanceChargeAmountCurrencyID, InvoiceLineAllowanceChargeAmount, InvoiceLineTaxTotalTaxAmountCurrencyID, InvoiceLineTaxTotalTaxAmount, InvoiceLineTaxAmountCurrencyID, InvoiceLineTaxAmount, InvoiceLineTaxSubtotalTaxAmountCurrencyID, InvoiceLineTaxSubtotalPercent, InvoiceLineTaxSubtotalTaxCategoryTaxSchemeName, InvoiceLineTaxSubtotalTaxCategoryTaxSchemeCode, InvoiceLineItemName, InvoiceLinePriceAmountCurrencyID, InvoiceLinePriceAmountPrice)  
                                                     Values (@FATURA_TIPI,@SIRKET_KODU,@INVOICE_REF,@GUID, @InvoiceLineID, @InvoiceLineInvoicedQuantityUnitCode, @InvoiceLineInvoicedQuantity, @InvoiceLineLineExtensionAmountCurrencyID, @InvoiceLineLineExtensionAmount, @InvoiceLineAllowanceChargeChargeIndicator, @InvoiceLineAllowanceChargeMultiplierFactorNumeric, @InvoiceLineAllowanceChargeAmountCurrencyID, @InvoiceLineAllowanceChargeAmount, @InvoiceLineTaxTotalTaxAmountCurrencyID, @InvoiceLineTaxTotalTaxAmount, @InvoiceLineTaxAmountCurrencyID, @InvoiceLineTaxAmount, @InvoiceLineTaxSubtotalTaxAmountCurrencyID, @InvoiceLineTaxSubtotalPercent, @InvoiceLineTaxSubtotalTaxCategoryTaxSchemeName, @InvoiceLineTaxSubtotalTaxCategoryTaxSchemeCode, @InvoiceLineItemName, @InvoiceLinePriceAmountCurrencyID, @InvoiceLinePriceAmountPrice)";
                                cmd.CommandText = LINE_SQL;
                                cmd.Parameters.AddWithValue("@FATURA_TIPI", 'E');
                                cmd.Parameters.AddWithValue("@SIRKET_KODU", BTN_FIRMA.EditValue);
                                cmd.Parameters.AddWithValue("@INVOICE_REF", OIID);
                                cmd.Parameters.AddWithValue("@GUID", GUID);
                                cmd.Parameters.AddWithValue("@InvoiceLineID", drx["InvoiceLineID"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineInvoicedQuantityUnitCode", drx["InvoiceLineInvoicedQuantityUnitCode"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineInvoicedQuantity", drx["InvoiceLineInvoicedQuantity"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineLineExtensionAmountCurrencyID", drx["InvoiceLineLineExtensionAmountCurrencyID"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineLineExtensionAmount", drx["InvoiceLineLineExtensionAmount"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineAllowanceChargeChargeIndicator", drx["InvoiceLineAllowanceChargeChargeIndicator"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineAllowanceChargeMultiplierFactorNumeric", drx["InvoiceLineAllowanceChargeMultiplierFactorNumeric"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineAllowanceChargeAmountCurrencyID", drx["InvoiceLineAllowanceChargeAmountCurrencyID"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineAllowanceChargeAmount", drx["InvoiceLineAllowanceChargeAmount"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineTaxTotalTaxAmountCurrencyID", drx["InvoiceLineTaxTotalTaxAmountCurrencyID"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineTaxTotalTaxAmount", drx["InvoiceLineTaxTotalTaxAmount"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineTaxAmountCurrencyID", drx["InvoiceLineTaxAmountCurrencyID"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineTaxAmount", drx["InvoiceLineTaxAmount"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineTaxSubtotalTaxAmountCurrencyID", drx["InvoiceLineTaxSubtotalTaxAmountCurrencyID"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineTaxSubtotalPercent", drx["InvoiceLineTaxSubtotalPercent"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineTaxSubtotalTaxCategoryTaxSchemeName", drx["InvoiceLineTaxSubtotalTaxCategoryTaxSchemeName"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineTaxSubtotalTaxCategoryTaxSchemeCode", drx["InvoiceLineTaxSubtotalTaxCategoryTaxSchemeCode"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineItemName", drx["InvoiceLineItemName"]);
                                cmd.Parameters.AddWithValue("@InvoiceLinePriceAmountCurrencyID", drx["InvoiceLinePriceAmountCurrencyID"]);
                                cmd.Parameters.AddWithValue("@InvoiceLinePriceAmountPrice", drx["InvoiceLinePriceAmountPrice"]);
                                cmd.Connection = myConnectionTable;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                  //  myConnectionTable.Close();
                }
    }
}