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

namespace VISION.TIMESHEET
{ 
    public partial class MUSTERI_LISTESI : DevExpress.XtraEditors.XtraForm
    {
        public string _SLCT_MUSTERI_KODU;
        public MUSTERI_LISTESI()
        {
            InitializeComponent();

            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;


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

        private void GRD_LISTE_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = GRD_VIEW_LISTE.GetFocusedDataRow();
            _SLCT_MUSTERI_KODU = dr["MUSTERI_KODU"].ToString();
            Close();
        }
    }
}