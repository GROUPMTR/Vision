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

namespace VISION._LOCAL_ADMIN.KULLANICI
{
    public partial class KULLANICI_GIRIS : DevExpress.XtraEditors.XtraForm
    {
        public KULLANICI_GIRIS()
        {
            InitializeComponent();
        }

        private void BTN_LISTE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KULLANICI_LISTESI frm = new KULLANICI_LISTESI();
            frm.ShowDialog();
            DATA_LOAD(frm._KULLANICI_ID);
        }

        private void BTN_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void DATA_LOAD(int ID)
        {
            using (SqlConnection conControl = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string myInsertQueryKontrol = " SELECT * FROM dbo.ADM_KULLANICI WHERE (ID=@ID)";
                SqlCommand myCmds = new SqlCommand(myInsertQueryKontrol);
                myCmds.Parameters.Add("@ID", ID);
                myCmds.Connection = conControl;
                conControl.Open();
                SqlDataReader myReader = myCmds.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    TXT_KULLANICI_KODU.Text = myReader["KODU"].ToString();
                    CHK_ERP_USER.Checked = (bool)myReader["ERP_USER"];
                    CMB_KULLANICI_GRUBU.Text = myReader["KULLANICI_GRUBU"].ToString();
                    TXT_MAIL.Text = myReader["MAIL_ADRESI"].ToString();
                    TXT_ADI.Text = myReader["ADI"].ToString();
                    TXT_SOYADI.Text = myReader["SOYADI"].ToString();
                    DT_ISE_GIRIS_TARIHI.EditValue = myReader["ISE_GIRIS_TARIHI"].ToString();
                    CHK_TIME_SHEET_KULLANICISI.Checked = (bool)myReader["TIMESHEET_KULLANICISI"];
                    CHK_AYRILDI.Checked = (bool)myReader["AKTIF"]; 
                    lbID.Caption = myReader["ID"].ToString();
                }
            } 
        }
        private void BTN_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lbID.Caption == "")
            {
                KAYDET();
            }
            else
            {
                GUNCELLE();
            }
        }


        private void KAYDET()
        {
            SqlConnection conControl = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            string myInsertQueryKontrol = " SELECT * FROM dbo.ADM_KULLANICI WHERE (KODU = @KODU)";
            SqlCommand myCmds = new SqlCommand(myInsertQueryKontrol);            
            myCmds.Parameters.AddWithValue("@KODU",TXT_KULLANICI_KODU.Text);
            myCmds.Connection = conControl;
            conControl.Open();
            SqlDataReader myReaderKontrol = myCmds.ExecuteReader(CommandBehavior.CloseConnection);
            if (myReaderKontrol.HasRows == false)
            {
                SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                myConnectionTable.Open();
                SqlCommand myCmd = new SqlCommand();
                myCmd.CommandText = " INSERT INTO dbo.ADM_KULLANICI (SIRKET_KODU, AKTIF, KULLANICI_GRUBU, KODU, MAIL_ADRESI, ADI, SOYADI, TC_KIKLIK_NO, ISE_GIRIS_TARIHI, TIMESHEET_KULLANICISI) " +
                                                        " Values (@SIRKET_KODU, @AKTIF, @KULLANICI_GRUBU, @KODU, @MAIL_ADRESI,@ADI,@SOYADI,@TC_KIKLIK_NO,@ISE_GIRIS_TARIHI,@TIMESHEET_KULLANICISI)  SELECT  ID=@@IDENTITY  ";
                myCmds.Parameters.Add("@SIRKET_KODU", SqlDbType.NVarChar, 20, TXT_KULLANICI_KODU.Text);
                myCmds.Parameters.Add("@AKTIF", SqlDbType.Bit,1,CHK_ERP_USER.Checked.ToString ());
                myCmds.Parameters.Add("@KULLANICI_GRUBU", SqlDbType.NVarChar, 20, CMB_KULLANICI_GRUBU.Text);
                myCmds.Parameters.Add("@MAIL_ADRESI", SqlDbType.NVarChar, 20, TXT_MAIL.Text);
                myCmds.Parameters.Add("@ADI", SqlDbType.NVarChar, 20, TXT_ADI.Text);
                myCmds.Parameters.Add("@SOYADI", SqlDbType.NVarChar, 20, TXT_SOYADI.Text);
                myCmds.Parameters.Add("@TC_KIKLIK_NO", SqlDbType.NVarChar, 20, TXT_TC_KIMLIK_NO.Text);
                myCmds.Parameters.Add("@ISE_GIRIS_TARIHI", SqlDbType.NVarChar, 20, DT_ISE_GIRIS_TARIHI.EditValue.ToString ());
                myCmds.Parameters.Add("@TIMESHEET_KULLANICISI", SqlDbType.Bit, 20, CHK_TIME_SHEET_KULLANICISI.Checked.ToString());  
                myCmd.Connection = myConnectionTable;
                SqlDataReader myReader = myCmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                { 
                    lbID.Caption = myReader["ID"].ToString();
                }
                myReader.Close();
                myCmd.Connection.Close();
            }
            else
            {
                MessageBox.Show(TXT_KULLANICI_KODU.Text.ToString() + " Bu kod daha önce kullanılmış." + (char)13 + " Lütfen farklı bir kod kullanın.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            myCmds.Connection.Close();
        }
        private void GUNCELLE()
        {

            SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            myConnectionTable.Open();
            SqlCommand myCmd = new SqlCommand(); 
            myCmd.CommandText = " UPDATE   dbo.ADM_KULLANICI SET   AKTIF=@AKTIF, KULLANICI_GRUBU=@KULLANICI_GRUBU, KODU=@KODU, MAIL_ADRESI=@MAIL_ADRESI, ADI=@ADI, SOYADI=@SOYADI, TC_KIKLIK_NO=@TC_KIKLIK_NO, ISE_GIRIS_TARIHI=@ISE_GIRIS_TARIHI, TIMESHEET_KULLANICISI=@TIMESHEET_KULLANICISI WHERE  SIRKET_KODU=@SIRKET_KODU and  ID=@ID ";
            myCmd.Parameters.AddWithValue("@ID", lbID.Caption);
            myCmd.Parameters.AddWithValue("@KODU",  TXT_KULLANICI_KODU.Text);
            myCmd.Parameters.AddWithValue("@SIRKET_KODU", TXT_KULLANICI_KODU.Text);
            myCmd.Parameters.AddWithValue("@AKTIF", CHK_AYRILDI.Checked.ToString());
            myCmd.Parameters.AddWithValue("@KULLANICI_GRUBU", CMB_KULLANICI_GRUBU.Text);
            myCmd.Parameters.AddWithValue("@MAIL_ADRESI", TXT_MAIL.Text);
            myCmd.Parameters.AddWithValue("@ADI", TXT_ADI.Text);
            myCmd.Parameters.AddWithValue("@SOYADI",  TXT_SOYADI.Text);
            myCmd.Parameters.AddWithValue("@TC_KIKLIK_NO",  TXT_TC_KIMLIK_NO.Text);
            myCmd.Parameters.AddWithValue("@ISE_GIRIS_TARIHI",  DT_ISE_GIRIS_TARIHI.EditValue.ToString());
            myCmd.Parameters.AddWithValue("@TIMESHEET_KULLANICISI",  CHK_TIME_SHEET_KULLANICISI.Checked.ToString());  
            myCmd.Connection = myConnectionTable;
            myCmd.ExecuteNonQuery();
            myCmd.Connection.Close();
        }
    }
}