using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace VISION._ADMIN
{
    public partial class SIRKET_LISTESI : DevExpress.XtraEditors.XtraForm
    {
        public string SELECT_ID = "";
        public SIRKET_LISTESI()
        {
            InitializeComponent();
            this.Tag = "MDIFORM";

            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            DATA_LOAD();
        }
        private void DATA_LOAD()
        {

            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter("SELECT * FROM  dbo.ADM_SIRKET ", myConnection);
                DataSet MyDataSet = new DataSet();
                MySqlDataAdapter.Fill(MyDataSet, "ADM_SIRKET");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                gridCntrl_LIST.DataSource = dv;
            }


        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridCntrl_LIST_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView_LIST.GetFocusedDataRow();
            SELECT_ID = dr["ID"].ToString();
            Close();
        }

        private void gridCntrl_LIST_Click(object sender, EventArgs e)
        {

        }
    }
}