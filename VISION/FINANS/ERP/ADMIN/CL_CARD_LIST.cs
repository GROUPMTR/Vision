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
    public partial class CL_CARD_LIST : DevExpress.XtraEditors.XtraForm
    {
        DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hiRow;
        DataRow TbSlctrow;
        public string CARI_CODE, CARI_LOGICALREF, CARI_GL_CODE, CARI_UNVAN;
        UnityObjects.IData clientObj = default(UnityObjects.IData); 
        public CL_CARD_LIST()
        {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            CLLIST();
        }
        private void CLLIST()
        {
            using (SqlConnection myConnection = new SqlConnection( _GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString()))
            {
                string mySelectQuery = "Select LOGICALREF,CODE as  [Cari Kod],DEFINITION_ as [Cari Açıklaması]  From LG_" + _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD";
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(mySelectQuery, myConnection);
                DataSet MyDataSet = new DataSet();
                MySqlDataAdapter.Fill(MyDataSet, "dbo_MecraList");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                gridCntrl_LIST.DataSource = dv;
            }
        }
        private void gridCntrl_LIST_DoubleClick(object sender, EventArgs e)
        {
            hiRow = gridView_LIST.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));
            TbSlctrow = gridView_LIST.GetDataRow(hiRow.RowHandle);
            if (TbSlctrow != null)
            {
                CARI_LOGICALREF = TbSlctrow["LOGICALREF"].ToString();
                CARI_CODE = TbSlctrow["Cari Kod"].ToString();
                CARI_UNVAN = TbSlctrow["Cari Açıklaması"].ToString();
                if (CARI_LOGICALREF != null || CARI_LOGICALREF != "")
                {
                    Int32 itemRef = Convert.ToInt32(CARI_LOGICALREF);
                    try
                    {
                        UnityObjects.Data Itm = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doAccountsRP);
                        if (Itm.Read(itemRef))
                        {
                            CARI_GL_CODE = Itm.DataFields.FieldByName("GL_CODE").Value;
                        }
                    }
                    catch
                    {
                        string aaa = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doAccountsRP).ErrorCode.ToString();
                        //UnityObjects.IValidateError
                        MessageBox.Show(aaa, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
            }
            Close();
        }
        private void BTN_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}