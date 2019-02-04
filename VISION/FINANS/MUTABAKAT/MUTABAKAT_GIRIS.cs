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
    public partial class MUTABAKAT_GIRIS : Form
    {
        public MUTABAKAT_GIRIS()
        {
            InitializeComponent();

            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void BR_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lbID.Caption != "")
            {
                TXT_MUTABAKAT_KODU.Enabled = false;
                GUNCELLE();
            }
            else
            {
                TXT_MUTABAKAT_KODU.Enabled = false;
                KAYDET();
            }//MUTABAKAT_SAYACI
        }

        private void PLAN_GET(string _PLAN_KODU)
        {
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string mySelectQuery = "SELECT  * FROM dbo.FTR_FATURA_MUTABAKAT_LISTESI   WHERE      (SIRKET_KODU=@SIRKET_KODU) AND (MUTABAKAT_KODU =@MUTABAKAT_KODU)";
                using (SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection) { CommandText = mySelectQuery.ToString() })
                {
                    myCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    myCommand.Parameters.AddWithValue("@PLAN_KODU", _PLAN_KODU);
                    myConnection.Open();
                    SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    while (myReader.Read())
                    {
                        CMB_FORM_TURU.Text = myReader["FORM_TURU"].ToString();
                        DTM_BASLANGIC_TARIHI.Text = Convert.ToDateTime(myReader["BAS_TARIHI"]).ToString("dd.MM.yyyy");
                        DTM_BITIS_TARIHI.Text = Convert.ToDateTime(myReader["BIT_TARIHI"]).ToString("dd.MM.yyyy");
                        TXT_MUTABAKAT_KODU.Text = myReader["MUTABAKAT_KODU"].ToString();
                        TXT_DONEMI.Text = myReader["DONEMI"].ToString();
                        TXT_NOTUM.Text = myReader["NOTUM"].ToString();
                    }
                }
            }

        }


        private void PLAN_KODU_URET()
        {
            string mySelectQuery =    " SELECT   *  FROM dbo.ADM_SIRKET  WHERE    (SIRKET_KODU=@SIRKET_KODU)  ";
            using (SqlConnection myConnectionSub = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                using (SqlCommand myCommandSub = new SqlCommand(mySelectQuery, myConnectionSub))
                {
                    myCommandSub.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    myConnectionSub.Open();
                    SqlDataReader myReaderSub = myCommandSub.ExecuteReader(CommandBehavior.CloseConnection);
                    while (myReaderSub.Read())
                    {
                        int SAYACI = 0;
                        SAYACI = Convert.ToInt16(myReaderSub["MUTABAKAT_SAYACI"].ToString()) + 1;
                        TXT_MUTABAKAT_KODU.Text = String.Format("{0}-{1}", _GLOBAL_PARAMETERS._SIRKET_KODU, Convert.ToString(SAYACI));
                        TXT_MUTABAKAT_KODU.Refresh();
                        using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                        {

                            string myInsertQuery = " Update dbo.ADM_SIRKET Set MUTABAKAT_SAYACI=@PLAN_SAYACI WHERE (SIRKET_KODU =@SIRKET_KODU) ";
                            using (SqlCommand myCommand = new SqlCommand(myInsertQuery) { Connection = myConnection })
                            {
                                myCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                                myCommand.Parameters.AddWithValue("@PLAN_SAYACI", SAYACI);
                                myConnection.Open();
                                myCommand.ExecuteNonQuery();
                                myCommand.Connection.Close();
                            }
                        }
                    }
                    myReaderSub.Close();
                }
            }
        }
        private void KAYDET()
        {
            using (SqlConnection myConnectionKontrol = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string myInsertQueryKontrol = String.Format(" SELECT * FROM  dbo.FTR_FATURA_MUTABAKAT_LISTESI WHERE (MUTABAKAT_KODU = '{0}')", TXT_MUTABAKAT_KODU.Text);
                using (SqlCommand myCommandKontrol = new SqlCommand(myInsertQueryKontrol))
                {
                    myCommandKontrol.Connection = myConnectionKontrol;
                    myConnectionKontrol.Open();
                    SqlDataReader myReaderKontrol = myCommandKontrol.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReaderKontrol.HasRows == false)
                    {
                        PLAN_KODU_URET();
                        using (SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                        {
                            myConnectionTable.Open();
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.CommandText = " INSERT INTO dbo.FTR_FATURA_MUTABAKAT_LISTESI (SIRKET_KODU,FORM_TURU,BAS_TARIHI,BIT_TARIHI,MUTABAKAT_KODU,DONEMI,ACIKLAMASI)  " +
                                                                           " Values (@SIRKET_KODU,@FORM_TURU,@BAS_TARIHI,@BIT_TARIHI,@MUTABAKAT_KODU,@DONEMI,@ACIKLAMASI)" +
                                                                           " SELECT @@IDENTITY AS ID   ";  
                                cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                                cmd.Parameters.AddWithValue("@FORM_TURU", CMB_FORM_TURU.Text);
                                cmd.Parameters.AddWithValue("@BAS_TARIHI", Convert.ToDateTime(DTM_BASLANGIC_TARIHI.Text).ToString("yyyy.MM.dd"));
                                cmd.Parameters.AddWithValue("@BIT_TARIHI", Convert.ToDateTime(DTM_BITIS_TARIHI.Text).ToString("yyyy.MM.dd"));
                                cmd.Parameters.AddWithValue("@MUTABAKAT_KODU", TXT_MUTABAKAT_KODU.Text);
                                cmd.Parameters.AddWithValue("@DONEMI", TXT_DONEMI.Text);
                                cmd.Parameters.AddWithValue("@ACIKLAMASI", TXT_NOTUM.Text);                        
                                cmd.Connection = myConnectionTable;
                                SqlDataReader myReader = cmd.ExecuteReader();
                                while (myReader.Read())
                                {
                                    lbID.Caption = myReader["ID"].ToString();
                                }
                            }
                        }
                    }
                    else
                    { MessageBox.Show("plan kodu sorunlu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    myCommandKontrol.Connection.Close();
                }
            }
        }
        private void GUNCELLE()
        {

            using (SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                myConnectionTable.Open();
                using (SqlCommand cmd = new SqlCommand { CommandText = String.Format(" UPDATE dbo.FTR_FATURA_MUTABAKAT_LISTESI SET FORM_TURU=@FORM_TURU,BAS_TARIHI=@BAS_TARIHI,BIT_TARIHI=@BIT_TARIHI,  DONEMI=@DONEMI,ACIKLAMASI=@ACIKLAMASI WHERE (ID = '{0}' AND SIRKET_KODU=@SIRKET_KODU )", lbID.Caption) })
                {
                    cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                    cmd.Parameters.AddWithValue("@FORM_TURU", CMB_FORM_TURU.Text);
                    cmd.Parameters.AddWithValue("@BAS_TARIHI", Convert.ToDateTime(DTM_BASLANGIC_TARIHI.Text).ToString("yyyy.MM.dd"));
                    cmd.Parameters.AddWithValue("@BIT_TARIHI", Convert.ToDateTime(DTM_BITIS_TARIHI.Text).ToString("yyyy.MM.dd"));
                    cmd.Parameters.AddWithValue("@MUTABAKAT_KODU", TXT_MUTABAKAT_KODU.Text);
                    cmd.Parameters.AddWithValue("@DONEMI", TXT_DONEMI.Text);
                    cmd.Parameters.AddWithValue("@ACIKLAMASI", TXT_NOTUM.Text);
                    cmd.Connection = myConnectionTable;
                    cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    cmd.Connection.Close();
                }
            }
        }

        private void BR_LIST_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BR_YENI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
