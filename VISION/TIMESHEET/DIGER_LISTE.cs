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
    public partial class DIGER_LISTE : DevExpress.XtraEditors.XtraForm
    {
        public string _DIGER_SECENEKLER;
        public bool _TAKVIM_SOR;
        public DIGER_LISTE()
        {
            InitializeComponent();

            //ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            using (SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string Sql = " SELECT * FROM dbo.TODO_TIME_SHEET_DIGER  ORDER BY DIGER_SECENEKLER";
                using (SqlDataAdapter da = new SqlDataAdapter(Sql, Conn))
                {
                    using (DataSet dtSet = new DataSet())
                    {
                        da.Fill(dtSet, "TIME_SHEET_DIGER");
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
            _DIGER_SECENEKLER = dr["DIGER_SECENEKLER"].ToString();
            _TAKVIM_SOR = (bool)dr["TAKVIM_SOR"];
            Close();
        }
    }
}