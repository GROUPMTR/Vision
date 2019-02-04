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

namespace VISION.FINANS.ERP
{
    public partial class POSTA_KUTUSU : Form
    {
        public string ALIALS;
        public string VKN;
        public string BTN_TAMAM;
        public POSTA_KUTUSU(string ALIAS)
        {
            InitializeComponent();

            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            using (SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string Querys = "  SELECT * FROM  dbo.FTR_GIB_FIRMA_LISTESI  ";
                SqlCommand myCommandSub = new SqlCommand(Querys, Conn);
                Conn.Open();
                SqlDataReader doSl = myCommandSub.ExecuteReader(CommandBehavior.CloseConnection);
                while (doSl.Read())
                {
                    CMB_PK.Properties.Items.Add(doSl["ALIAS"].ToString());
                }
                CMB_PK.Text = ALIAS;
            } 
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BTN_TAMAM = "CANCEL";
            Close();
        }

        private void BTN_BASLA_Click(object sender, EventArgs e)
        {
            BTN_TAMAM = "OK";
            Close();
        }

        private void CMB_PK_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {

                string SQL = " SELECT   * FROM   dbo.FTR_GIB_FIRMA_LISTESI where   ALIAS=@ALIAS   ";
                SqlCommand myCommand = new SqlCommand(SQL, Conn);
                myCommand.Parameters.AddWithValue("@ALIAS", CMB_PK.Text);
                myCommand.CommandText = SQL.ToString();
                Conn.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    VKN = myReader["IDENTIFIER"].ToString();
                }
                myReader.Close();
                myCommand.Connection.Close();

            }
            ALIALS = CMB_PK.Text;
        }
    }
}
