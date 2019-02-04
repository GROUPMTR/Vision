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

namespace VISION._LOCAL_ADMIN.KULLANICI
{
    public partial class KULLANICI_GRUP_LISTESI : DevExpress.XtraEditors.XtraForm
    {
        public string _GRUP_KODU;
        DataView dv;
        public KULLANICI_GRUP_LISTESI()
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
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter("SELECT * FROM  dbo.ADM_KULLANICI ", myConnection);
                DataSet MyDataSet = new DataSet();
                MySqlDataAdapter.Fill(MyDataSet, "dbo_USER");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                gridCntrl_LIST.DataSource = dv;
            }
        }
    }
}