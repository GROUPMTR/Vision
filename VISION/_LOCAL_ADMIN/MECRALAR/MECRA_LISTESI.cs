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
    public partial class MECRA_LISTESI : DevExpress.XtraEditors.XtraForm
    {
        public string _MECRA_KODU;

        DataRow dr;
        DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi;
        public MECRA_LISTESI(string MECRA_TURU)
        {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            DATA_LIST_LOAD(MECRA_TURU);
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void DATA_LIST_LOAD(string MECRA_TURU)
        {

            using (SqlConnection MySqlConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string SQL = "SELECT * from ADM_MECRA where MECRA_TURU='" + MECRA_TURU+"'";
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(SQL, MySqlConnection);
                DataSet MyDataSet = new DataSet();
                MySqlDataAdapter.Fill(MyDataSet, "dbo_USER");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                GRD_LISTE.DataSource = dv;
            }
        }

        private void GRD_LISTE_Click(object sender, EventArgs e)
        {

             hi = GRD_VIEW_LISTE.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));
            dr = GRD_VIEW_LISTE.GetDataRow(hi.RowHandle);
            if (dr != null)
            {
               _MECRA_KODU=dr["MECRA_KODU"].ToString ();
            }  


            
        }
    }
}