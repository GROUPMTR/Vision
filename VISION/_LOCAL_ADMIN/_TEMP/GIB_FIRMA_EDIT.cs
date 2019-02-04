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
    public partial class GIB_FIRMA_EDIT : DevExpress.XtraEditors.XtraForm
    {
        public GIB_FIRMA_EDIT()
        {
            InitializeComponent();
            this.Tag = "MDIFORM";


            using (SqlConnection MySqlConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))//_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString()
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT   AccCustomerPartyName , SIRKET_KODU  FROM            dbo.FTR_GELEN_FATURALAR GROUP BY AccCustomerPartyName,SIRKET_KODU ORDER BY AccCustomerPartyName", MySqlConnection);
                ds = new DataSet();
                da.Fill(ds, "Header");
                DataViewManager dvManager = new DataViewManager(ds);
                DataView dv = dvManager.CreateDataView(ds.Tables[0]);
                GRD_LISTE.DataSource = dv;
            }


        }
        DataSet ds;
        private void BTN_ONAY_REFRESH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            using (SqlConnection MySqlConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB ))//_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString()
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT   AccCustomerPartyName , SIRKET_KODU  FROM            dbo.FTR_GELEN_FATURALAR GROUP BY AccCustomerPartyName,SIRKET_KODU ORDER BY AccCustomerPartyName", MySqlConnection);
                ds = new DataSet();
                da.Fill(ds, "Header");
                DataViewManager dvManager = new DataViewManager(ds);
                DataView dv = dvManager.CreateDataView(ds.Tables[0]);
                GRD_LISTE.DataSource = dv;
            }
        }

        private void BTN_LOGO_SECILENLERI_AKATAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            myConnectionTable.Open();
            re_PROGRESS_BAR.Maximum = gridView_LIST.RowCount -1;

            int[] selectedRows = gridView_LIST.GetSelectedRows();
           for (int index = 0; index <= selectedRows.Length - 1; index++) 
           {
         
                BR_PROGRESS_BAR.EditValue = index;
                BR_PROGRESS_BAR.Refresh(); 
                DataRow dr = gridView_LIST.GetDataRow(selectedRows[index]); 

                using (SqlCommand cmd = new SqlCommand())
                {
                    string HEADER_TABLE_SQL = "  UPDATE [dbo].[FTR_GELEN_FATURALAR]  SET [SIRKET_KODU]=@SIRKET_KODU WHERE AccCustomerPartyName=@AccCustomerPartyName ";

                    cmd.CommandText = HEADER_TABLE_SQL;
                    cmd.Parameters.AddWithValue("@AccCustomerPartyName", dr["AccCustomerPartyName"]);
                    cmd.Parameters.AddWithValue("@SIRKET_KODU", BTN_FIRMA.EditValue.ToString ());
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