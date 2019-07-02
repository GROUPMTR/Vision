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

namespace VISION.DOKUMAN
{
    public partial class EVRAK_LISTESI : DevExpress.XtraEditors.XtraForm
    {
        public string SELECT_BUTTON = "CANCEL";
        public EVRAK_LISTESI()
        {
            InitializeComponent();

            this.Tag = "MDIFORM";

            dtTmPckrBasTar.EditValue = DateTime.Now.AddDays(-30).ToShortDateString();
            dtTmPckrBitTar.EditValue = DateTime.Now.ToShortDateString();
            DATA_LOAD();
        }

        private void DATA_LOAD()
        {
            using (SqlConnection MySqlConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(String.Format("SELECT  * from dbo.EVR_EVRAK_TAKIBI where SIRKET_KODU=@SIRKET_KODU "), MySqlConnection);
                MySqlDataAdapter.SelectCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU); 
                using (DataSet MyDataSet = new DataSet())
                {
                    MySqlDataAdapter.Fill(MyDataSet, "dbo_USER");
                    DataViewManager dvManager = new DataViewManager(MyDataSet);
                    DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                    gridCtrl_Masters.DataSource = dv;
                }
            }
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void BTN_YENI_FATURA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EVRAK_GIRIS ftr = new EVRAK_GIRIS(0);
            ftr.ShowDialog();

            if (ftr.SELECT_BUTTON == "OK") DATA_LOAD();
        }
        DataRow dr;
        private void gridCtrl_Masters_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi =
                      gridView_Masters.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));
            dr = gridView_Masters.GetDataRow(hi.RowHandle);
            if (dr != null)
            {
                EVRAK_GIRIS ftr = new EVRAK_GIRIS((int)dr["ID"]);
                ftr.ShowDialog();

                if (ftr.SELECT_BUTTON == "OK") DATA_LOAD();
            } 
        }
    }
}