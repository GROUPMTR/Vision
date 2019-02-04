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
    public partial class GENEL_LISTE : DevExpress.XtraEditors.XtraForm
    { 
        string _ERISIM_TURU = "";
        public string _SELECT_KODU;
        public GENEL_LISTE(string TIPI)
        {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            _ERISIM_TURU = TIPI;
            DATA_LOAD(); 
        }
        private void DATA_LOAD()
        {
            using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM  dbo.ADM_GENEL_LISTELER where ERISIM_TURU=@ERISIM_TURU ", con);
                da.SelectCommand.Parameters.AddWithValue("@ERISIM_TURU", _ERISIM_TURU);
                DataSet MyDataSet = new DataSet();
                da.Fill(MyDataSet, "ADM_GENEL_LISTELER");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                DataView    DW_LIST = dvManager.CreateDataView(MyDataSet.Tables[0]);
                GRD_LISTE.DataSource = DW_LIST;
            }  
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        } 
 
        private void GRD_LISTE_Click(object sender, EventArgs e)
        { 
            DataRow dr = GRD_VIEW_LISTE.GetFocusedDataRow();
            if (dr != null)
            {
                _SELECT_KODU = dr["DEFAULT_ACIKLAMA"].ToString();
             
            } 
        }

        private void GRD_VIEW_LISTE_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = String.Format("{0}", e.RowHandle + 1); 
            }
        }

        private void GRD_LISTE_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = GRD_VIEW_LISTE.GetFocusedDataRow();
            if (dr != null)
            {
                _SELECT_KODU = dr["DEFAULT_ACIKLAMA"].ToString();
                Close();
            } 
        } 
    }
}