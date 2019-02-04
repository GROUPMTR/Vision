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
    public partial class AKTARILAN_FATURALAR : DevExpress.XtraEditors.XtraForm
    {
        public AKTARILAN_FATURALAR()
        {
            InitializeComponent();
            this.Tag = "MDIFORM";
        }


        DataSet ds;
     

        private void BTN_REFRESH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //string con = "Password=nabuKad_07;Persist Security Info=True;User ID=grm_sa;Initial Catalog=WeSOURCE;Data Source=10.219.168.92";
            using (SqlConnection MySqlConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP))//_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString()
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * from LG_INVOICE_"+BTN_FIRMA.EditValue+"_01 ", MySqlConnection);
                ds = new DataSet();
                da.Fill(ds, "INVOICE");
                DataViewManager dvManager = new DataViewManager(ds);
                DataView dv = dvManager.CreateDataView(ds.Tables[0]);
                gridCntrl_LIST.DataSource = dv;
            }
        }

        private void BTN_LOGO_SECILENLERI_AKATAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            myConnectionTable.Open();

           // string con = "Password=nabuKad_07;Persist Security Info=True;User ID=grm_sa;Initial Catalog=WeSOURCE;Data Source=10.219.168.92";
            SqlConnection MySqlConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP);
            MySqlConnection.Open();

            string OIID ="";
            var GUID = "";
                DataTable dtINVOICE = ds.Tables["INVOICE"];
              for (int index = 0; index < dtINVOICE.Rows.Count; index++)
             {
                OIID = ""; GUID = Guid.NewGuid().ToString();
                using (SqlCommand myCommand = new SqlCommand())
                { 
                   
                    string myInsertQuery = string.Empty, InsertFIELD = string.Empty, InsertPARAMETER = string.Empty;

                    for (int i = 1; i < dtINVOICE.Rows[index].Table.Columns.Count - 1; i++)
                    {
                        string FIELD = dtINVOICE.Rows[index].Table.Columns[i].ColumnName;
                        InsertFIELD += FIELD + ",";
                        InsertPARAMETER += String.Format("@{0},", FIELD);
                        myCommand.Parameters.AddWithValue("@" + FIELD, dtINVOICE.Rows[index][FIELD]);
                    }

                    if (InsertFIELD != "") InsertFIELD = InsertFIELD.Substring(0, InsertFIELD.Length - 1);
                    if (InsertPARAMETER != "") InsertPARAMETER = InsertPARAMETER.Substring(0, InsertPARAMETER.Length - 1);
                    myInsertQuery = "INSERT INTO dbo.FTR_LG_INVOICE (GUID,SIRKET_KODU," + InsertFIELD + ") VALUES (@GUID,@SIRKET_KODU," + InsertPARAMETER + " ) SELECT @@IDENTITY AS ID ";
                    myCommand.Connection = myConnectionTable;
                    myCommand.CommandText = myInsertQuery;
                    myCommand.Parameters.AddWithValue("@GUID", GUID);
                    myCommand.Parameters.AddWithValue("@SIRKET_KODU", BTN_FIRMA.EditValue );
                    SqlDataReader sqlreader = myCommand.ExecuteReader();
                    while (sqlreader.Read())
                    {
                        OIID = sqlreader["ID"].ToString();

                    } 
                    sqlreader.Close();
                }



             
              DataSet dsln = new DataSet();
              
                  SqlDataAdapter da = new SqlDataAdapter("SELECT * from LG_STLINE_" + BTN_FIRMA.EditValue + "_01 where INVOICE_REF=" + dtINVOICE.Rows[index]["ID"], MySqlConnection);

                  da.Fill(dsln, "INVOICE_LINE");
                  DataViewManager dvManager = new DataViewManager(dsln);
                  DataView dv = dvManager.CreateDataView(dsln.Tables["INVOICE_LINE"]);
                  gridCntrl_LINE.DataSource = dv;
             


              DataTable dtINVOICE_LINE = dsln.Tables["INVOICE_LINE"];


              for (int indx = 0; indx < dtINVOICE_LINE.Rows.Count  ; indx++)
              {
                using (SqlCommand myCommand = new SqlCommand())
                {

                    string myInsertQuery = string.Empty, InsertFIELD = string.Empty, InsertPARAMETER = string.Empty;

                    for (int i = 1; i < dtINVOICE_LINE.Rows[indx].Table.Columns.Count - 1; i++)
                    {
                        if (dtINVOICE_LINE.Rows[indx].Table.Columns[i].ColumnName != "INVOICE_REF")
                        {
                            string FIELD = dtINVOICE_LINE.Rows[indx].Table.Columns[i].ColumnName;
                            InsertFIELD += FIELD + ",";
                            InsertPARAMETER += String.Format("@{0},", FIELD);
                            myCommand.Parameters.AddWithValue("@" + FIELD, dtINVOICE_LINE.Rows[indx][FIELD]);
                        }
                    }

                    if (InsertFIELD != "") InsertFIELD = InsertFIELD.Substring(0, InsertFIELD.Length - 1);
                    if (InsertPARAMETER != "") InsertPARAMETER = InsertPARAMETER.Substring(0, InsertPARAMETER.Length - 1);
                    myInsertQuery = "INSERT INTO dbo.FTR_LG_STLINE (GUID,SIRKET_KODU,INVOICE_REF," + InsertFIELD + ") VALUES (@GUID,@SIRKET_KODU,@INVOICE_REF," + InsertPARAMETER + " ) SELECT @@IDENTITY AS ID ";
                    myCommand.Connection = myConnectionTable;
                    myCommand.CommandText = myInsertQuery;
                    myCommand.Parameters.AddWithValue("@INVOICE_REF", OIID);
                    myCommand.Parameters.AddWithValue("@GUID", GUID);
                    myCommand.Parameters.AddWithValue("@SIRKET_KODU", BTN_FIRMA.EditValue);
                    SqlDataReader sqlreader = myCommand.ExecuteReader();
                    while (sqlreader.Read())
                    {
                     //   OIID = sqlreader["ID"].ToString();

                    }
                    sqlreader.Close();
                }
              }

               //  myCommand.Connection.Close(); 


            }  // 
             
            
          //  myConnectionTable.Close();
        }
    }
}