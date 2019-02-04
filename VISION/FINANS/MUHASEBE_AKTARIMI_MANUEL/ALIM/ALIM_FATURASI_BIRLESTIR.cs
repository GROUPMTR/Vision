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

namespace VISION.FINANS.MUHASEBE_AKTARIMI_MANUEL.ALIM
{
    public partial class ALIM_FATURASI_BIRLESTIR : DevExpress.XtraEditors.XtraForm
    {
        public ALIM_FATURASI_BIRLESTIR(string GUID ,string ID)
        {
            InitializeComponent(); 
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string mySelectQuery = " SELECT  top 0 * FROM  dbo.FTR_LG_STLINE ";// WHERE  INVOICE_REF=@INVOICE_REF and GUID=@GUID AND SIRKET_KODU=@SIRKET_KODU";
                SqlDataAdapter da = new SqlDataAdapter(mySelectQuery, myConnection);
                //da.SelectCommand.Parameters.AddWithValue("@INVOICE_REF", ID);
                //da.SelectCommand.Parameters.AddWithValue("@GUID", GUID);
                //da.SelectCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                DataSet MyDataSet = new DataSet();
                da.Fill(MyDataSet, "FTR_LG_STLINE");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                DW_GENERIC = dvManager.CreateDataView(MyDataSet.Tables[0]);
                gridCntrl_LINE.DataSource = DW_GENERIC;
                myConnection.Close();
            }
        }


     

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

 
        private void BTN_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        { 
                DateTime myDT = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                {
                    myConnection.Open();
                    Guid GU = Guid.NewGuid();
                    string myInsertQuery = " INSERT INTO dbo.FTR_LG_INVOICE ( GUID,SIRKET_KODU,FIRMA_KODU,TYPE, TASLAK_FATURA_NO, NUMBER,EINVOICE,ACCOUNT_TYPE,CODE,TITLE,ADDRESS1,ADDRESS2,CITY,POSTAL_CODE,TELEPHONE1,FAX,TAX_OFFICE,TAX_ID,DATE,DOC_DATE,DOC_NUMBER,ARP_CODE,GL_CODE,VAT_RATE,TOTAL_VAT,TOTAL_GROSS,TOTAL_NET,TC_NET,RC_XRATE,RC_NET,CURRSEL_TOTALS,CURRSEL_DETAILS,DEFNFLD_PAZARLAMA_SIRKETI_KODU,DEFNFLD_LEVEL_,DEFNFLD_MODULENR,DEFNFLD_MECRA_TURU,DEFNFLD_FATURA_BASKI_SEKLI,PAYMENT_DATE,PAYMENT_MODULENR,PAYMENT_TRCODE,PAYMENT_TOTAL,PAYMENT_PROCDATE,PAYMENT_DISCOUNT_DUEDATE,PAYMENT_MODIFIED,PAYMENT_PAY_NO) "+
                                            "  Values(@GUID,SIRKET_KODU,FIRMA_KODU,TYPE, TASLAK_FATURA_NO, NUMBER,EINVOICE,ACCOUNT_TYPE,CODE,TITLE,ADDRESS1,ADDRESS2,CITY,POSTAL_CODE,TELEPHONE1,FAX,TAX_OFFICE,TAX_ID,DATE,DOC_DATE,DOC_NUMBER,ARP_CODE,GL_CODE,VAT_RATE,TOTAL_VAT,TOTAL_GROSS,TOTAL_NET,TC_NET,RC_XRATE,RC_NET,CURRSEL_TOTALS,CURRSEL_DETAILS,DEFNFLD_PAZARLAMA_SIRKETI_KODU,DEFNFLD_LEVEL_,DEFNFLD_MODULENR,DEFNFLD_MECRA_TURU,DEFNFLD_FATURA_BASKI_SEKLI,PAYMENT_DATE,PAYMENT_MODULENR,PAYMENT_TRCODE,PAYMENT_TOTAL,PAYMENT_PROCDATE,PAYMENT_DISCOUNT_DUEDATE,PAYMENT_MODIFIED,PAYMENT_PAY_NO) SELECT @@IDENTITY AS ID";
                    SqlCommand cmd = new SqlCommand(); 
                    cmd.Parameters.AddWithValue("@GUID", GU);
                    cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                    cmd.Parameters.AddWithValue("@FIRMA_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                    cmd.Parameters.AddWithValue("@TYPE", '1');
                    cmd.Parameters.AddWithValue("@TASLAK_FATURA_NO", TXT_FATURA_NO.Text);
                    cmd.Parameters.AddWithValue("@NUMBER", TXT_FATURA_NO.Text);
                    cmd.Parameters.AddWithValue("@EINVOICE", '0');
                    cmd.Parameters.AddWithValue("@ACCOUNT_TYPE", '3'); 
                    cmd.Parameters.AddWithValue("@CODE", TXT_CODE.Text);



                    cmd.Parameters.AddWithValue("@TITLE", TXT_FATURA_NO.Text);
                    cmd.Parameters.AddWithValue("@ADDRESS1", TXT_FATURA_NO.Text);
                    cmd.Parameters.AddWithValue("@ADDRESS2", TXT_FATURA_NO.Text);
                    cmd.Parameters.AddWithValue("@CITY", TXT_FATURA_NO.Text);
                    cmd.Parameters.AddWithValue("@POSTAL_CODE", TXT_FATURA_NO.Text);
                    cmd.Parameters.AddWithValue("@TELEPHONE1", TXT_FATURA_NO.Text);
                    cmd.Parameters.AddWithValue("@FAX", TXT_FATURA_NO.Text);
                    cmd.Parameters.AddWithValue("@TAX_OFFICE", TXT_FATURA_NO.Text);



                    cmd.Parameters.AddWithValue("@TAX_ID", TXT_VERGINO.Text); 


                    cmd.Parameters.AddWithValue("@DATE", myDT.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@DOC_DATE", myDT.ToString("yyyy-MM-dd"));

                    cmd.Parameters.AddWithValue("@DOC_NUMBER", TXT_FATURA_NO.Text);
                    cmd.Parameters.AddWithValue("@ARP_CODE", TXT_CODE.Text);
                    cmd.Parameters.AddWithValue("@GL_CODE", TXT_CODE.Text);


                    cmd.Parameters.AddWithValue("@VAT_RATE", TXT_FATURA_NO.Text);
                    cmd.Parameters.AddWithValue("@TOTAL_VAT", TXT_TOTAL_VAT.Text);
                    cmd.Parameters.AddWithValue("@TOTAL_GROSS", TXT_TOTAL_GROSS.Text);
                    cmd.Parameters.AddWithValue("@TOTAL_NET", TXT_TOTAL_GROSS.Text); 
                    cmd.Parameters.AddWithValue("@TC_NET", TXT_TOTAL_GROSS.Text);
                    cmd.Parameters.AddWithValue("@RC_XRATE", '1');
                    cmd.Parameters.AddWithValue("@RC_NET", TXT_TOTAL_GROSS.Text);


                    cmd.Parameters.AddWithValue("@CURRSEL_TOTALS", '2');
                    cmd.Parameters.AddWithValue("@CURRSEL_DETAILS", '0');
                    cmd.Parameters.AddWithValue("@DEFNFLD_PAZARLAMA_SIRKETI_KODU", TXT_PAZARLAMASTI_KODU.Text);
                    cmd.Parameters.AddWithValue("@DEFNFLD_LEVEL_", '1');
                    cmd.Parameters.AddWithValue("@DEFNFLD_MODULENR", '4');
                    cmd.Parameters.AddWithValue("@DEFNFLD_MECRA_TURU", TXT_MECRA_TURU.Text);
                    cmd.Parameters.AddWithValue("@DEFNFLD_FATURA_BASKI_SEKLI", 'D');
                    cmd.Parameters.AddWithValue("@PAYMENT_DATE", TXT_FATURA_NO.Text);
                    cmd.Parameters.AddWithValue("@PAYMENT_MODULENR", TXT_FATURA_NO.Text);
                    cmd.Parameters.AddWithValue("@PAYMENT_TRCODE", TXT_FATURA_NO.Text);
                    cmd.Parameters.AddWithValue("@PAYMENT_PROCDATE", TXT_FATURA_NO.Text);
                    cmd.Parameters.AddWithValue("@PAYMENT_DISCOUNT_DUEDATE", TXT_FATURA_NO.Text);
                    cmd.Parameters.AddWithValue("@PAYMENT_MODIFIED", TXT_FATURA_NO.Text);
                    cmd.Parameters.AddWithValue("@PAYMENT_PAY_NO", TXT_FATURA_NO.Text);   
                       
                    cmd.Connection = myConnection;  
                    SqlDataReader myReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    string SIRANO = "0";
                    while (myReader.Read())
                    {
                        SIRANO = myReader["ID"].ToString();
                    }
                    myReader.Close();
                   cmd.Connection.Close();
           } 

            DialogResult c = MessageBox.Show("Güncellemek istediğinizden eminmisiniz.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (c == DialogResult.Yes)
                {
                    using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                    {
                        myConnections.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Parameters.AddWithValue("@GUID", "");
                        cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                        cmd.Parameters.AddWithValue("@INVOICE_REF", "");
                        cmd.Parameters.AddWithValue("@INVOICE_NUMBER", TXT_FATURA_NO.Text);
                        cmd.Parameters.AddWithValue("@TYPE", '0');
                        cmd.Parameters.AddWithValue("@MASTER_CODE", "");
                        cmd.Parameters.AddWithValue("@NAME", "");
                        cmd.Parameters.AddWithValue("@AUXIL_CODE", "");
                        cmd.Parameters.AddWithValue("@QUANTITY", '1');
                        cmd.Parameters.AddWithValue("@PRICE", "");
                        cmd.Parameters.AddWithValue("@TOTAL", "");
                        cmd.Parameters.AddWithValue("@DESCRIPTION", "");
                        cmd.Parameters.AddWithValue("@UNIT_CODE", "ADET");
                        cmd.Parameters.AddWithValue("@UNIT_CONV1", "1");
                        cmd.Parameters.AddWithValue("@UNIT_CONV2", "1");
                        cmd.Parameters.AddWithValue("@VAT_AMOUNT", "");
                        cmd.Parameters.AddWithValue("@EDT_PRICE", "");
                        cmd.Parameters.AddWithValue("@MODULENR", '4');
                        cmd.Parameters.AddWithValue("@LEVEL_", '1');                     
                        cmd.Parameters.AddWithValue("@PLAN_KODU", '2');
                        cmd.Parameters.AddWithValue("@XML_ATTRIBUTE", '2');
                        cmd.CommandText = " UPDATE  dbo.FTR_LG_INVOICE SET  DEFNFLD_MECRA_TURU=@DEFNFLD_MECRA_TURU ,DEFNFLD_PO_DETAILS=@DEFNFLD_PO_DETAILS,DOC_TRACK_NR=@DOC_TRACK_NR ,NOTES1=@NOTES1,NOTES2=@NOTES2,NOTES3=@NOTES3,NOTES4=@NOTES4 WHERE  ID=@ID AND SIRKET_KODU=@SIRKET_KODU ";
                        cmd.Connection = myConnections;
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                        myConnections.Close();
                    }
                    STLINE_ROW_UPDATE();
                  }
        }


        private void STLINE_ROW_UPDATE()
        {
           
                for (int ix = 0; ix <= gridView_LINE.RowCount - 1; ix++)
                {
                    
                    DataRow dr = gridView_LINE.GetDataRow(ix);
                    using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                    {
                        myConnections.Open();
                        SqlCommand cmd = new SqlCommand();  
                        cmd.Parameters.AddWithValue("@ID", dr["ID"].ToString());
                        cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                        cmd.Parameters.AddWithValue("@PO_CODE", dr["PO_CODE"].ToString());
                        cmd.Parameters.AddWithValue("@LINE_CODE", dr["LINE_CODE"].ToString());
                        cmd.Parameters.AddWithValue("@DESCRIPTION", dr["DESCRIPTION"].ToString());
                        cmd.Parameters.AddWithValue("@TARIH", dr["TARIH"].ToString());
                        cmd.Parameters.AddWithValue("@MASTER_CODE", dr["MASTER_CODE"].ToString());
                        cmd.CommandText = " UPDATE  dbo.FTR_LG_STLINE SET  MASTER_CODE=@MASTER_CODE,PO_CODE=@PO_CODE ,LINE_CODE=@LINE_CODE,DESCRIPTION=@DESCRIPTION ,TARIH=@TARIH  WHERE  ID=@ID AND SIRKET_KODU=@SIRKET_KODU ";
                        cmd.Connection = myConnections;
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                        myConnections.Close();
                    }
                }
            
        }

        private void gridView_LINE_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {  // DataRow row = gridView_LINE.GetDataRow(Convert.ToInt32(e.RowHandle));
           
                //row.BeginEdit();
                //if (row != null)
                //{
                //  //  row[e.Column.FieldName] = e.Value;
                //}
                //row.EndEdit(); 
            
        }
        string ClipboardData
        {
            get
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (iData == null) return "";

                if (iData.GetDataPresent(DataFormats.Text))
                    return (string)iData.GetData(DataFormats.Text);
                return "";
            }
            set { Clipboard.SetDataObject(value); }
        }
        DataTable tbl;
        DataView DW_GENERIC;
        private void CLIPBOARD_DATA_READ()
        {
            tbl = null;
            tbl = new DataTable();
            tbl.TableName = "ImportedTable";
            List<string> data = new List<string>(ClipboardData.Split('\n'));
            bool firstRow = true;

            if (data.Count > 0 && string.IsNullOrWhiteSpace(data[data.Count - 1]))
            {
                data.RemoveAt(data.Count - 1);
            }

            foreach (string iterationRow in data)
            {
                string row = iterationRow;
                if (row.EndsWith("\r"))
                {
                    row = row.Substring(0, row.Length - "\r".Length);
                }

                string[] rowData = row.Split(new char[] { '\r', '\x09' });
                DataRow newRow = tbl.NewRow();
                if (firstRow)
                {
                    int colNumber = 0;
                    foreach (string value in rowData)
                    {
                        if (string.IsNullOrWhiteSpace(value))
                        {
                            tbl.Columns.Add(string.Format("[BLANK{0}]", colNumber));
                        }
                        else if (!tbl.Columns.Contains(value))
                        {
                            tbl.Columns.Add(value);
                        }
                        else
                        {
                            tbl.Columns.Add(string.Format("Column {0}", colNumber));
                        }
                        colNumber++;
                    }
                    firstRow = false;
                }
                else
                {
                    for (int i = 0; i < rowData.Length; i++)
                    {
                        if (i >= tbl.Columns.Count) break;
                        newRow[i] = rowData[i];
                    }
                    tbl.Rows.Add(newRow);
                }
            }

        }
        private void CNT_YAPISTIR_Click(object sender, EventArgs e)
        {
            CLIPBOARD_DATA_READ();
            for (int x = 0; x <= tbl.Rows.Count - 1; x++)
            {
                DataRow rowm = tbl.Rows[x];
                DataRow rows = DW_GENERIC.Table.NewRow();

                for (int XZ = 0; XZ <= tbl.Columns.Count - 1; XZ++)
                {
                    switch (tbl.Columns[XZ].ColumnName)
                    {
                        //case "S.N":
                        //    if (rowm["KANAL"].ToString() != string.Empty) rows["MECRA_KODU"] = rowm["KANAL"];
                        //    break;
                        //case "Tür":
                        //    if (rowm["Spot Tipi"].ToString() != string.Empty) rows["SPOT_TIPI_DETAY"] = rowm["Spot Tipi"];
                        //    break;
                        case "Kodu":
                            if (rowm["Kodu"].ToString() != string.Empty) rows["MASTER_CODE"] = rowm["Kodu"].ToString();
                            break;
                        case "Tanım":
                            if (rowm["Tanım"].ToString() != string.Empty) rows["NAME"] = rowm["Tanım"];
                            break;
                        case "Hareket Özel Kodu":
                            if (rowm["Hareket Özel Kodu"].ToString() != string.Empty) rows["AUXIL_CODE"] = rowm["Hareket Özel Kodu"];
                            break;
                        case "Miktar":
                            if (rowm["Miktar"].ToString() != string.Empty) rows["QUANTITY"] = rowm["Miktar"];
                            break;
                        case "Birim Fiyat":
                            if (rowm["Birim Fiyat"].ToString() != string.Empty) rows["PRICE"] = rowm["Birim Fiyat"];
                            break;
                        case "Tutarı":
                            if (rowm["Tutarı"].ToString() != string.Empty) rows["TOTAL"] = rowm["Tutarı"];
                            break;
                        case "KDV %":
                            if (rowm["KDV %"].ToString() != string.Empty) rows["VAT_RATE"] = rowm["KDV %"];  
                            break;
                        case "KDV":
                            if (rowm["KDV"].ToString() != string.Empty) rows["VAT_AMOUNT"] = rowm["KDV"];  
                            break;
                        case "Plan Kodu":
                            if (rowm["Plan Kodu"].ToString() != string.Empty) rows["PLAN_KODU"] = rowm["Plan Kodu"];  
                            break;
                        case "Açıklama":
                            if (rowm["Açıklama"].ToString() != string.Empty) rows["DESCRIPTION"] = rowm["Açıklama"];  
                            break;
                    }
                }
                DW_GENERIC.Table.Rows.Add(rows);
            }
        }
    }
}