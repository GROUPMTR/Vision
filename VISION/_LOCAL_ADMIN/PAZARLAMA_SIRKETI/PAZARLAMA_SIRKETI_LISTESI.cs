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

namespace VISION._LOCAL_ADMIN.PAZARLAMA_SIRKETI
{
    public partial class PAZARLAMA_SIRKETI_LISTESI : DevExpress.XtraEditors.XtraForm
    {
        public string _SLCT_PAZARLAMA_SIRKETII_KODU;
        public PAZARLAMA_SIRKETI_LISTESI()
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
            using (SqlConnection MySqlConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string SQL = "SELECT * from ADM_PAZARLAMA_SIRKETI";
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(SQL, MySqlConnection);
                DataSet MyDataSet = new DataSet();
                MySqlDataAdapter.Fill(MyDataSet, "dbo_USER");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                GRD_LISTE.DataSource = dv;
            }
        }

        private void GRD_LISTE_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = GRD_VIEW_LISTE.GetFocusedDataRow();
            if (dr != null)
            {
                _SLCT_PAZARLAMA_SIRKETII_KODU = dr["KODU"].ToString();
                Close();
            }
        }
    }
}