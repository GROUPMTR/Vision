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

namespace VISION._LOCAL_ADMIN.MUSTERI
{ 
    public partial class MUSTERI_LISTESI : DevExpress.XtraEditors.XtraForm
    {
        public  int _MUSTERI_ID = 0;
        public string _MUSTERI_KODU, _MUSTERI_ADI;
        public MUSTERI_LISTESI()
        {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent; 
        }

        private void MUSTERI_LISTESI_Load(object sender, EventArgs e)
        {
            using (SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string Sql = " SELECT * FROM dbo.ADM_MUSTERI  WHERE    (SIRKET_KODU=@SIRKET_KODU) ORDER BY SIRKET_KODU,MUSTERI_KODU";
                using (SqlDataAdapter da = new SqlDataAdapter(Sql, Conn)) 
                {
                    da.SelectCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    using (DataSet dtSet = new DataSet())
                    {
                        da.Fill(dtSet, "ADM_MUSTERI");
                        using (DataViewManager dvManager = new DataViewManager(dtSet))
                        {
                            DataView dv = dvManager.CreateDataView(dtSet.Tables[0]);
                            GRD_LISTE.DataSource = dv;
                        }
                    }
                }
            }
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
        DataRow dr;
        private void GRD_LISTE_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi =
                        GRD_VIEW_LISTE.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));
            dr = GRD_VIEW_LISTE.GetDataRow(hi.RowHandle);
            if (dr != null)
            {
                _MUSTERI_ID = (int)dr["ID"];
                _MUSTERI_KODU = (string)dr["MUSTERI_KODU"];
                _MUSTERI_ADI = (string)dr["ADI"];
            }
            Close();
        }
    }
}