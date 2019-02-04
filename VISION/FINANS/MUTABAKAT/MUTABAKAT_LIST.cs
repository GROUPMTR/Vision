using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VISION.FINANS.MUTABAKAT
{
    public partial class MUTABAKAT_LIST : Form
    {
        public string _MUTABAKAT_KODU, _MUTABAKAT_BAS_TARIHI, _MUTABAKAT_BITIS_TARIHI, _MUTABAKAT_ACIKLAMASI, _MUTABAKAT_DONEMI, _MUTABAKAT_FORM_TURU;  
        DataRow dr;
        DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi;
        public MUTABAKAT_LIST()
        {
            InitializeComponent();

            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            DATA_LOAD();

        }
       private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
        private void DATA_LOAD()
        {
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string SQL = @"SELECT  * FROM FTR_FATURA_MUTABAKAT_LISTESI  WHERE SIRKET_KODU=@SIRKET_KODU ";      
                SqlDataAdapter da = new SqlDataAdapter(SQL, myConnection);
                da.SelectCommand.Parameters.AddWithValue("@SIRKET_KODU",_GLOBAL_PARAMETERS._SIRKET_KODU.ToString()); 
                DataSet MyDataSet = new DataSet();
                da.Fill(MyDataSet, "dbo_USER");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                GRD_LISTE.DataSource = dv;
            }

        }

        private void GRD_LISTE_DoubleClick(object sender, EventArgs e)
        {
            hi = GRD_VIEW_LISTE.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));
            dr = GRD_VIEW_LISTE.GetDataRow(hi.RowHandle);
            if (dr != null)
            {
                _MUTABAKAT_FORM_TURU = dr["FORM_TURU"].ToString();
                _MUTABAKAT_KODU = dr["MUTABAKAT_KODU"].ToString();
                _MUTABAKAT_BAS_TARIHI = dr["BAS_TARIHI"].ToString();
                _MUTABAKAT_BITIS_TARIHI = dr["BIT_TARIHI"].ToString();
                _MUTABAKAT_ACIKLAMASI = dr["ACIKLAMASI"].ToString();
                _MUTABAKAT_DONEMI = dr["DONEMI"].ToString(); 

            }
            Close();
        }

        private void GRD_LISTE_Click(object sender, EventArgs e)
        {

        }



     
    }
}
