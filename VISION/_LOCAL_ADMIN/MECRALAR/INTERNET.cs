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

namespace VISION._LOCAL_ADMIN.MECRALAR
{
    public partial class INTERNET : DevExpress.XtraEditors.XtraForm
    {
        public INTERNET()
        {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            PAZARLAMA_SIRKETI_LISTESI();
        }
        private void PAZARLAMA_SIRKETI_LISTESI()
        {
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string mySelectQuery = "SELECT * FROM dbo.ADM_PAZARLAMA_SIRKETI order by KODU";
                SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
                myCommand.CommandText = mySelectQuery.ToString();
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    TX_CMB_PAZARLAMA_STI_KODU.Properties.Items.Add(myReader["KODU"].ToString());
                }
            }
        }

        private void BR_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}