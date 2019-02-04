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

namespace VISION._LOCAL_ADMIN.ONAY_GRUPLARI
{
    public partial class GRUP_TANIMLA : DevExpress.XtraEditors.XtraForm
    {
        public GRUP_TANIMLA()
        {
            InitializeComponent();

            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;


            SqlConnection SqlCon = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            SqlCon.Open(); 
            using (SqlCommand myCommand = new SqlCommand("SELECT * FROM  ADM_GENEL_LISTELER WHERE ERISIM_TURU='ONAY_GRUBU_TURU'", SqlCon))
            {
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    CMB_ONAY_GRUBU.Properties.Items.Add(myReader["DEFAULT_ACIKLAMA"].ToString());
                }
                myReader.Close();
            }

        }

        private void BTN_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void BTN_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TXT_GROUP_KODU.Text.Length > 0)
            {

                if (lbID.Caption.Length == 0)
                {

                    using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                    {
                        string SQL = string.Format(" SELECT * FROM  dbo.ADM_ONAY_GRUBU where  SIRKET_KODU='{0}' and  ONAY_GRUBU='{1}'", _GLOBAL_PARAMETERS._SIRKET_KODU, TXT_GROUP_KODU.Text);
                        SqlCommand myCommand = new SqlCommand(SQL, myConnection) { CommandText = SQL.ToString() };
                        myConnection.Open();
                        SqlDataReader myReader = myCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                        if (!myReader.HasRows)
                        {
                            using (SqlConnection conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                            {
                                conn.Open();                                
                                SqlCommand myCmd = new SqlCommand("INSERT INTO dbo.ADM_ONAY_GRUBU  (SIRKET_KODU,ONAY_GRUBU_TURU,ONAY_GRUBU, ONAYLAMA_SISTEMI,  LIMIT) VALUES (@SIRKET_KODU,@ONAY_GRUBU_TURU,@ONAY_GRUBU, @ONAYLAMA_SISTEMI,@LIMIT)");
                                myCmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                                myCmd.Parameters.AddWithValue("@ONAY_GRUBU_TURU", CMB_ONAY_GRUBU.Text);
                                myCmd.Parameters.AddWithValue("@ONAY_GRUBU", TXT_GROUP_KODU.Text);
                                myCmd.Parameters.AddWithValue("@ONAYLAMA_SISTEMI", CMB_ONAYLAMA_SISTEMI.Text);
                                myCmd.Parameters.AddWithValue("@LIMIT", TXT_LIMIT.Text);  
                                myCmd.Connection = conn;
                                myCmd.ExecuteNonQuery();
                                conn.Close();
                            }
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("BU KOD DAHA KULLANILMIŞ LÜTFEN FARKLI BİR KOD VERİNİZ.");
                        }
                    }
                }


                if (lbID.Caption.Length > 0)
                {


                    using (SqlConnection conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                    {
                        conn.Open();
                        string myInsertQuery = "update  dbo.ADM_ONAY_GRUBU  set  ONAY_GRUBU_TURU=@ONAY_GRUBU_TURU ,ONAY_GRUBU=@ONAY_GRUBU,  ONAYLAMA_SISTEMI=@ONAYLAMA_SISTEMI, LIMIT=@LIMIT  where  SIRKET_KODU=@SIRKET_KODU  and ID=@ID    ";
                        SqlCommand myCmd = new SqlCommand(myInsertQuery);
                        myCmd.Parameters.AddWithValue("@ID", lbID.Caption);
                        myCmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                        myCmd.Parameters.AddWithValue("@ONAY_GRUBU_TURU", CMB_ONAY_GRUBU.Text);
                        myCmd.Parameters.AddWithValue("@ONAY_GRUBU", TXT_GROUP_KODU.Text);
                        myCmd.Parameters.AddWithValue("@ONAYLAMA_SISTEMI", CMB_ONAYLAMA_SISTEMI.Text);
                        myCmd.Parameters.AddWithValue("@LIMIT", TXT_LIMIT.Text);  
                        myCmd.Connection = conn;
                        myCmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            } 
        }

        private void BTN_ONAY_GRUBU_LISTESI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GRUP_LISTESI frm = new GRUP_LISTESI();
            frm.TopMost = true;
            frm.ShowDialog();
            DATA_LOAD(frm._ONAY_GRUBU);
        }

        private void DATA_LOAD(string ONAY_GRUBU)
        {
            using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                myConnections.Open();
                SqlCommand myCommands = new SqlCommand();
                myCommands.Connection = myConnections;
                myCommands.CommandText = "SELECT  *  from dbo.ADM_ONAY_GRUBU where ONAY_GRUBU=@ONAY_GRUBU and  SIRKET_KODU=@SIRKET_KODU";
                myCommands.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                myCommands.Parameters.AddWithValue("@ONAY_GRUBU", ONAY_GRUBU);
                SqlDataReader sqlreaders = myCommands.ExecuteReader(CommandBehavior.CloseConnection);
                while (sqlreaders.Read())
                {
                    lbID.Caption = sqlreaders["ID"].ToString();
                    CMB_ONAY_GRUBU.Text = sqlreaders["ONAY_GRUBU_TURU"].ToString();
                    TXT_GROUP_KODU.Text = sqlreaders["ONAY_GRUBU"].ToString();
                    CMB_ONAYLAMA_SISTEMI.Text = sqlreaders["ONAYLAMA_SISTEMI"].ToString();
                    TXT_LIMIT.Text = sqlreaders["LIMIT"].ToString();  
                }
                sqlreaders.Close();
                myCommands.Connection.Close();
                myConnections.Close();
            }
        }

        private void CHK_GENEL_GIDER_CheckedChanged(object sender, EventArgs e)
        {
            if (CHK_GENEL_GIDER.Checked)
            {
                CHK_GAZETE.Checked = false;
                CHK_DERGI.Checked = false;
                CHK_SINEMA.Checked = false;
                CHK_RADYO.Checked = false;
                CHK_OUTDOOR.Checked = false;
                CHK_SPONSORLUK.Checked = false;
                CHK_INTERNET.Checked = false;
                CHK_TELEVIZYON.Checked = false;

                CHK_GAZETE.Enabled = false;
                CHK_DERGI.Enabled = false;
                CHK_SINEMA.Enabled = false;
                CHK_RADYO.Enabled = false;
                CHK_OUTDOOR.Enabled = false;
                CHK_SPONSORLUK.Enabled = false;
                CHK_INTERNET.Enabled = false;
                CHK_TELEVIZYON.Enabled = false;
            }

            if (!CHK_GENEL_GIDER.Checked)
            {
                CHK_GAZETE.Checked = true;
                CHK_DERGI.Checked = true;
                CHK_SINEMA.Checked = true;
                CHK_RADYO.Checked = true;
                CHK_OUTDOOR.Checked = true;
                CHK_SPONSORLUK.Checked = true;
                CHK_INTERNET.Checked = true;
                CHK_TELEVIZYON.Checked = true;

                CHK_GAZETE.Enabled = true;
                CHK_DERGI.Enabled = true;
                CHK_SINEMA.Enabled = true;
                CHK_RADYO.Enabled = true;
                CHK_OUTDOOR.Enabled = true;
                CHK_SPONSORLUK.Enabled = true;
                CHK_INTERNET.Enabled = true;
                CHK_TELEVIZYON.Enabled = true;
            }
        }
    }
}