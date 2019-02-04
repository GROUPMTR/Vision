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
    public partial class ALIM_FATURASI_EDIT : DevExpress.XtraEditors.XtraForm
    {
        public ALIM_FATURASI_EDIT(string GUID ,string ID)
        {
            InitializeComponent();

            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            if (GUID != "" && ID != "")
            { 

                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                {
                    myConnection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string HEADER_TABLE_SQL = "  SELECT CASE WHEN TYPE = 1 THEN 'ALIM' WHEN TYPE = 6 THEN 'ALIM İADE'  END AS TIPI ,* FROM   dbo.FTR_LG_INVOICE  where  (SIRKET_KODU=@SIRKET_KODU AND ID=ID AND GUID=@GUID)";
 
                        cmd.CommandText = HEADER_TABLE_SQL;
                        cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@GUID", GUID);
                        cmd.Connection = myConnection;
                        SqlDataReader myReader = cmd.ExecuteReader();
                        while (myReader.Read())
                        {
                            BR_ID.Caption = myReader["ID"].ToString();
                            DateTime dt = Convert.ToDateTime(myReader["DATE"]);
                            TXT_PLAN_KODU.Text = myReader["DEFNFLD_PLAN_KODU"].ToString();
                            TXT_MECRA_TURU.Text = myReader["DEFNFLD_MECRA_TURU"].ToString();
                            TXT_FATURA_NO.Text = myReader["NUMBER"].ToString();
                            TXT_FATURA_TARIHI.Text = dt.ToString("dd.MM.yyyy").ToString();
                            TXT_MUSTERI_KODU.Text = myReader["DEFNFLD_MUSTERI_KODU"].ToString();
                            TXT_MUSTERI_HESAP_KODU.Text = myReader["CODE"].ToString();
                            TXT_VERGI_DAIRESI.Text = myReader["TAX_OFFICE"].ToString();
                            TXT_VERGINO.Text = myReader["TAX_ID"].ToString();

                            TXT_PO_DETAILS.Text = myReader["DEFNFLD_PO_DETAILS"].ToString();
                            TXT_TRACK_NR.Text = myReader["DOC_TRACK_NR"].ToString(); 
                            TXT_NOTES1.Text = myReader["NOTES1"].ToString();
                            TXT_NOTES2.Text = myReader["NOTES2"].ToString();
                            TXT_NOTES3.Text = myReader["NOTES3"].ToString();
                            TXT_NOTES4.Text = myReader["NOTES4"].ToString();


                        
                            //txtSaticiVergiNo.Text = myReader["AccSupplierPartyIdentificationSchemeID"].ToString();
                            //txtSaticiAd.Text = myReader["AccSupplierPartyName"].ToString();
                            //txtID.Text = myReader["ID"].ToString();
                            //txtTip.Text = myReader["InvoiceTypeCode"].ToString();
                            //txtUUID.Text = myReader["UUID"].ToString();
                            //txtIssueDate.Text = dt.ToString("dd.MM.yyyy").ToString();
                            //txtNote.Text = myReader["Note"].ToString();

                            //txtLogoBelgeNo.Text = myReader["ID"].ToString();
                            //txtLogoFNO.Text = myReader["ID"].ToString();
                            //txtLogoTarih.Text = dt.ToString("dd.MM.yyyy").ToString();
                            //txtLogoBelgeTarih.Text = dt.ToString("dd.MM.yyyy").ToString();
                        }
                        myReader.Close();
                    }
                } 
            }

            if (GUID != "" && ID != "")
            {
                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                {
                    string mySelectQuery = " SELECT   * FROM  dbo.FTR_LG_STLINE  WHERE  INVOICE_REF=@INVOICE_REF and GUID=@GUID AND SIRKET_KODU=@SIRKET_KODU";
                    SqlDataAdapter da = new SqlDataAdapter(mySelectQuery, myConnection);
                    da.SelectCommand.Parameters.AddWithValue("@INVOICE_REF", ID);
                    da.SelectCommand.Parameters.AddWithValue("@GUID", GUID);
                    da.SelectCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    DataSet MyDataSet = new DataSet();
                    da.Fill(MyDataSet, "FTR_LG_STLINE");
                    DataViewManager dvManager = new DataViewManager(MyDataSet);
                    DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                    gridCntrl_LINE.DataSource = dv;
                    myConnection.Close();
                }
            }

        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

 
        private void BTN_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult c = MessageBox.Show("Güncellemek istediğinizden eminmisiniz.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (c == DialogResult.Yes)
        {
            using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                myConnections.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@ID", BR_ID.Caption.ToString());
                cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                cmd.Parameters.AddWithValue("@DEFNFLD_MECRA_TURU", TXT_MECRA_TURU.Text);
                cmd.Parameters.AddWithValue("@DEFNFLD_PO_DETAILS", TXT_PO_DETAILS.Text);

             


                cmd.Parameters.AddWithValue("@DOC_TRACK_NR", TXT_TRACK_NR.Text);
                cmd.Parameters.AddWithValue("@NOTES1", TXT_NOTES1.Text);
                cmd.Parameters.AddWithValue("@NOTES2", TXT_NOTES2.Text);
                cmd.Parameters.AddWithValue("@NOTES3", TXT_NOTES3.Text);
                cmd.Parameters.AddWithValue("@NOTES4", TXT_NOTES4.Text);
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
    }
}