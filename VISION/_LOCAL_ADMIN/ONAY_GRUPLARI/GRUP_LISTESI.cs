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

namespace VISION._LOCAL_ADMIN.ONAY_GRUPLARI
{
    public partial class GRUP_LISTESI : DevExpress.XtraEditors.XtraForm
    {
        public string _ONAY_GRUBU = "";
        public GRUP_LISTESI()
        {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            DATA_LOAD();
        }


        private void DATA_LOAD()
        {

            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string SQL = string.Format("  select *  from  dbo.ADM_ONAY_GRUBU WHERE SIRKET_KODU='{0}'", _GLOBAL_PARAMETERS._SIRKET_KODU);
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(SQL, myConnection);
                DataSet MyDataSet = new DataSet();
                MySqlDataAdapter.Fill(MyDataSet, "dbo_USER");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                gridCntrl_LIST.DataSource = dv;
            }

        }


        private void BTN_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}