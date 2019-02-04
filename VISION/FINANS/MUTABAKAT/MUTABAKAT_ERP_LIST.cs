using System;
using System.Collections;
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
    public partial class MUTABAKAT_ERP_LIST : Form
    {
        public ArrayList rows;
        public MUTABAKAT_ERP_LIST()
        {
            InitializeComponent();

            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            DATA_LOAD();

        }

        private void DATA_LOAD()
        {
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString()))
            {
                string SQL = @"SELECT CL.CODE CARI_KODU,CL.DEFINITION_ CARI_ADI,CL.EMAILADDR EMAIL ,CL.TAXNR VKN,CL.TCKNO TCK,
                             SUM(CASE WHEN INV.FROMKASA=1 AND C.SIGN=1 THEN C.AMOUNT WHEN C.SIGN=0 THEN C.AMOUNT ELSE 0 END) BORC,
                             SUM(CASE WHEN INV.FROMKASA=1 AND C.SIGN=0 THEN C.AMOUNT WHEN C.SIGN=1 THEN C.AMOUNT ELSE 0 END) ALACAK,
                             SUM(CASE WHEN INV.FROMKASA=1  THEN 0 WHEN C.SIGN=0 THEN C.AMOUNT WHEN C.SIGN=1  THEN -C.AMOUNT END) BAKIYE,COUNT(*) AS ADET
                             FROM LG_{0}_01_CLFLINE C INNER JOIN LG_{0}_CLCARD CL ON CL.LOGICALREF=C.CLIENTREF LEFT JOIN LG_{0}_01_INVOICE INV ON C.MODULENR=4 AND INV.LOGICALREF=C.SOURCEFREF AND INV.FROMKASA=1
                             WHERE C.CANCELLED=0
                             GROUP BY CL.CODE  ,CL.DEFINITION_  ,CL.EMAILADDR ,CL.TAXNR,CL.TCKNO ";
                SQL = string.Format(SQL, _GLOBAL_PARAMETERS._SIRKET_NO.ToString());
                SqlDataAdapter da = new SqlDataAdapter(SQL, myConnection);
                DataSet MyDataSet = new DataSet();
                da.Fill(MyDataSet, "dbo_USER");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                gridCntrl_LIST.DataSource = dv;
            }

        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rows = new ArrayList();
            // Add the selected rows to the list.
            for (int i = 0; i < gridView_MUTABAKAT_LISTESI.SelectedRowsCount; i++)
            {
                if (gridView_MUTABAKAT_LISTESI.GetSelectedRows()[i] >= 0)
                    rows.Add(gridView_MUTABAKAT_LISTESI.GetDataRow(gridView_MUTABAKAT_LISTESI.GetSelectedRows()[i]));
            }


            Close();
        }
    }
}
