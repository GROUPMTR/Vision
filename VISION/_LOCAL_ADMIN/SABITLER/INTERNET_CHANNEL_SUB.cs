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

namespace VISION._LOCAL_ADMIN.SABITLER
{
    public partial class INTERNET_CHANNEL_SUB : DevExpress.XtraEditors.XtraForm
    {
        public INTERNET_CHANNEL_SUB()
        {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            DATA_LIST_LOAD();
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void DATA_LIST_LOAD()
        {
            using (SqlConnection SqlCon = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlCon.Open();
                using (SqlCommand myCommand = new SqlCommand("SELECT * FROM  ADM_INTERNET_CHANNEL ", SqlCon))
                {
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        re_CHANNEL.Items.Add(myReader["CHANNEL"].ToString());
                    }
                    myReader.Close();
                }
            }
        }



        private void DATA_LIST_LOAD(string _CHANNEL)
        {
            using (SqlConnection MySqlConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string SQL = "SELECT * from ADM_INTERNET_CHANNEL_SUB";
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(SQL, MySqlConnection);
                DataSet MyDataSet = new DataSet();
                MySqlDataAdapter.Fill(MyDataSet, "dbo_USER");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                GRD_LISTE.DataSource = dv;
            }
        }

        private void BR_YENI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BR_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}