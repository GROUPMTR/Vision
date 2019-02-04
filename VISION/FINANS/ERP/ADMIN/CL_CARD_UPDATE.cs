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

namespace VISION.FINANS.ERP.ADMIN
{
    public partial class CL_CARD_UPDATE : DevExpress.XtraEditors.XtraForm
    {
        DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hiRow;
        DataRow TbSlctrow;
        public string _LREF, _CODE;
        public CL_CARD_UPDATE()
        {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            CLLIST();
        }
        private void CLLIST()
        {
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string mySelectQuery = "Select * From ADM_PAZARLAMA_SIRKETI ";
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(mySelectQuery, myConnection);
                DataSet MyDataSet = new DataSet();
                MySqlDataAdapter.Fill(MyDataSet, "dbo_MecraList");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                gridCntrl_LIST.DataSource = dv;
            }
        }

        private void BTN_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void BTN_GONDER_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void gridView_LIST_DoubleClick(object sender, EventArgs e)
        {
            hiRow = gridView_LIST.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));
            TbSlctrow = gridView_LIST.GetDataRow(hiRow.RowHandle);
            if (TbSlctrow != null)
            {
                _LREF = TbSlctrow["LOGICALREF"].ToString();
                _CODE = TbSlctrow["Cari Kod"].ToString();
                if (_LREF != null || _LREF != "")
                {
                    //int itemRef = Convert.ToInt16(_LREF);
                    //try
                    //{
                    //    UnityObjects.Data Itm = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doAccountsRP);
                    //    if (Itm.Read(itemRef))
                    //    {
                    //        CARI_GL_CODE = Itm.DataFields.FieldByName("GL_CODE").Value;
                    //    }
                    //}
                    //catch
                    //{
                    //    string aaa = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doAccountsRP).ErrorCode.ToString();
                    //    //UnityObjects.IValidateError
                    //    MessageBox.Show(aaa, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //}

                }
            }
            Close();
        }
    }
}