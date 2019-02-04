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

namespace VISION.FINANS.GIB
{
    public partial class ALIS_FATURASI_EDIT : DevExpress.XtraEditors.XtraForm
    {
        public ALIS_FATURASI_EDIT(int _OID)
        {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            DATA_LOAD(_OID);
        }

        DataView dw_ITEM;
        DataView DW_LIST;
        private void DATA_LOAD(int _OID)
        {

            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                myConnection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    string HEADER_TABLE_SQL = "select * from FTR_GELEN_FATURALAR WHERE SIRKET_KODU=@SIRKET_KODU AND OID=@OID";
                    cmd.CommandText = HEADER_TABLE_SQL;
                    cmd.Parameters.AddWithValue ("@SIRKET_KODU",_GLOBAL_PARAMETERS._SIRKET_KODU);
                    cmd.Parameters.AddWithValue("@OID", _OID);
                    cmd.Connection = myConnection;
                    SqlDataReader myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        TXT_OID.Text = myReader["OID"].ToString();
                        DateTime dt = Convert.ToDateTime(myReader["IssueDate"]);
                        txtSaticiVergiNo.Text = myReader["AccSupplierPartyIdentificationSchemeID"].ToString();
                        txtSaticiAd.Text = myReader["AccSupplierPartyName"].ToString();
                        txtID.Text = myReader["ID"].ToString();
                        txtTip.Text = myReader["InvoiceTypeCode"].ToString();
                        txtUUID.Text = myReader["UUID"].ToString();
                        txtIssueDate.Text = dt.ToString("dd.MM.yyyy").ToString();
                        txtNote.Text = myReader["Note"].ToString();

                        txtLogoBelgeNo.Text = myReader["ID"].ToString();
                        txtLogoFNO.Text = myReader["ID"].ToString();
                        txtLogoTarih.Text = dt.ToString("dd.MM.yyyy").ToString();
                        txtLogoBelgeTarih.Text = dt.ToString("dd.MM.yyyy").ToString();
                    }
                    myReader.Close();
                }

               
                CMB_LOGO_CARI.Properties.Items.Add("");
                using (SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString()))
                {
                    string Querys = "  SELECT CODE, DEFINITION_, TAXOFFICE, ADDR1, ADDR2, CITY  FROM  dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_CLCARD WHERE (TAXNR='" + txtSaticiVergiNo.Text + "'  OR TCKNO='" + txtSaticiVergiNo.Text + "'  ) ";
                    SqlCommand myCommandSub = new SqlCommand(Querys, Conn);
                    Conn.Open();
                    SqlDataReader doSl = myCommandSub.ExecuteReader();
                    int count = 0; 
                    while (doSl.Read())
                    {
                        count++;
                        if (count == 1)
                        {
                            CMB_LOGO_CARI.Properties.Items.Add(doSl["CODE"].ToString());
                            CMB_LOGO_CARI.Text = doSl["CODE"].ToString();
                            txtLogoCariAd.Text = doSl["DEFINITION_"].ToString();
                            txtLogoCariAcıklama.Text = doSl["ADDR1"].ToString() + Environment.NewLine + doSl["ADDR2"].ToString() + Environment.NewLine + doSl["CITY"].ToString();
                        }
                        else
                        {
                            CMB_LOGO_CARI.Properties.Items.Add(doSl["CODE"].ToString());
                            CMB_LOGO_CARI.Text = null;
                            txtLogoCariAd.Text = null;
                            txtLogoCariAcıklama.Text = null;
                        } 
                    } 
                } 
            }
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                myConnection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from FTR_GELEN_FATURALAR_DETAYI  WHERE SIRKET_KODU=@SIRKET_KODU and  INVOICE_REF=@INVOICE_REF", myConnection))
                {
                    cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    cmd.Parameters.AddWithValue("@INVOICE_REF", _OID);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter deMaster = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    deMaster.Fill(ds, "FTR_GIBGELENDETAY");
                    gridCntrl_LINE_LIST.DataSource = ds.Tables["FTR_GIBGELENDETAY"];

                }

                using (SqlCommand cmd = new SqlCommand("select * from FTR_GELEN_FATURALAR_DETAY_EDIT   WHERE SIRKET_KODU=@SIRKET_KODU and  INVOICE_REF=@INVOICE_REF", myConnection))
                {
                    cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    cmd.Parameters.AddWithValue("@INVOICE_REF", _OID);
                    SqlDataAdapter deMaster = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    deMaster.Fill(ds, "FTR_GIBGELENDETAY_EDIT");
                    DataViewManager dvManager = new DataViewManager(ds);
                    DW_LIST = dvManager.CreateDataView(ds.Tables["FTR_GIBGELENDETAY_EDIT"]);
                    for (int i = 0; i < 10; i++)
                    {
                        DataRowView DR = DW_LIST.AddNew();
                        //Guid g = Guid.NewGuid();
                        //DR["GUID"] = g;
                        //DR["SIRA_INDEX"] = DW_LIST.Count;
                        //DR["PB"] = "TL";
                        //DR["NZ"] = "N";
                        //DR["RENK"] = "R";
                        //DR["Birimi"] = "St/Cm";
                        //DR.EndEdit();
                    }
                    gridCntrl_LINE_EDIT.DataSource = DW_LIST;
                }
            }

                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString()))
                {
                    string sql = @" select  cast('ITEMS' AS nvarchar) as TYPES,CODE,NAME   from LG_{0}_ITEMS  WHERE (CARDTYPE <> 22 AND CARDTYPE <> 4 and CARDTYPE <> 20  )
                                   UNION ALL 
                                   select cast('EMUHACC' AS nvarchar) as TYPES, CODE,DEFINITION_ as NAME  from dbo.LG_{0}_EMUHACC";
                    string INVOICE_TABLE_SQL = string.Format(sql, _GLOBAL_PARAMETERS._SIRKET_NO.ToString());
                    SqlCommand cmd1 = myConnection.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = INVOICE_TABLE_SQL;
                    SqlDataAdapter deMaster = new SqlDataAdapter(cmd1);


                    DataSet ds = new DataSet();
                    deMaster.Fill(ds, "dbo_FIRMALAR");
                    DataViewManager dvManager = new DataViewManager(ds);
                    dw_ITEM = dvManager.CreateDataView(ds.Tables[0]);
                    dw_ITEM.RowFilter = "TYPES = 'ITEMS'";
                    re_ItemGridLookUpEdit.DataSource = dw_ITEM;
                    re_ItemGridLookUpEdit.PopulateViewColumns();
                }
           
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void BTN_EPOSTA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

    }
}