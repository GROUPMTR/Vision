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

namespace VISION._LOCAL_ADMIN.MECRALAR
{
    public partial class INTERNET_LISTESI : DevExpress.XtraEditors.XtraForm
    {
        public INTERNET_LISTESI()
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
            using (SqlConnection MySqlConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTION_STRING.ToString()))
            {
                string SQL = "SELECT * from ADM_MECRA_INTERNET";

                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(SQL, MySqlConnection);
                DataSet MyDataSet = new DataSet();
                MySqlDataAdapter.Fill(MyDataSet, "dbo_USER");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                GRD_LISTE.DataSource = dv;
            }
        }
    }
}