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
using DevExpress.XtraEditors.DXErrorProvider;


namespace VISION
{
    public partial class REGISTER : DevExpress.XtraEditors.XtraForm
    {
        int SIRKETREF = 0;
        public REGISTER()
        {
            InitializeComponent();

            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            InitFields();

            txt_MAIL.Text = Environment.UserName.ToString().ToLower();
            SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
            string SQL = "  SELECT   * FROM   dbo.ADM_SIRKET   ";
            SqlCommand myCommand = new SqlCommand(SQL, myConnection); 
            myCommand.CommandText = SQL.ToString();
            myConnection.Open();
            SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (myReader.Read())
            {
                CMB_FIRMA.Properties.Items.Add(myReader["SIRKET_KODU"].ToString()); 
            }
            myReader.Close();
            myCommand.Connection.Close();
        }


        private void InitFields()
        {

            CMB_FIRMA.Text = null;
            TXT_ADI.Text = null;
            TXT_SOYADI.Text = null;
            txt_MAIL.Text = null;
            dt_ISE_GIRIS_TARIHI.Text = null;
            txt_DAHILI.Text = null;

        }
        private void ValidateFields()
        {
            Validate_EmptyStringRule(CMB_FIRMA);
            Validate_EmptyStringRule(TXT_ADI);
            Validate_EmptyStringRule(TXT_SOYADI);
            Validate_EmptyStringRule(txt_MAIL);

        }
        private void Validate_EmptyStringRule(BaseEdit control)
        {
            if (control.Text == null || control.Text.Trim().Length == 0) dxErrorProviderS.SetError(control, "Bu alan boş BırakİLamaz.", ErrorType.Critical);
            else dxErrorProviderS.SetError(control, "");
        }

        private void BR_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dxErrorProviderS.HasErrors != true)
            {
                DateTime myDT = Convert.ToDateTime(dt_ISE_GIRIS_TARIHI.EditValue);
                SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
                string myInsertQuery = "INSERT INTO dbo.ADM_KULLANICI  (SIRKETREF,SIRKET_KODU,ADI,SOYADI,MAIL_ADRESI,GIRIS_TARIHI,DAHILI) VALUES (@SIRKETREF,@SIRKET_KODU,@ADI,@SOYADI,@MAIL_ADRESI,@GIRIS_TARIHI,@DAHILI)";
                SqlCommand myCommand = new SqlCommand(myInsertQuery);
                myCommand.Parameters.AddWithValue("@SIRKETREF", SIRKETREF);
                myCommand.Parameters.AddWithValue("@SIRKET_KODU", CMB_FIRMA.Text);
                myCommand.Parameters.AddWithValue("@ADI", TXT_ADI.Text);
                myCommand.Parameters.AddWithValue("@SOYADI", TXT_SOYADI.Text);
                myCommand.Parameters.AddWithValue("@MAIL_ADRESI", txt_MAIL.Text);
                myCommand.Parameters.AddWithValue("@GIRIS_TARIHI", myDT.ToString("yyyy-MM-dd"));
                myCommand.Parameters.AddWithValue("@DAHILI", txt_DAHILI.Text);
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();

                Close();
            }
            else
            { MessageBox.Show("ilgili alanları doldurunuz.", "Uyarı"); }

        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void CMB_FIRMA_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
            string SQL = " SELECT   * FROM   dbo.ADM_SIRKET where SIRKET_KODU=@SIRKET_KODU ";
            SqlCommand myCommand = new SqlCommand(SQL, myConnection);
            myCommand.Parameters.AddWithValue("@SIRKET_KODU", CMB_FIRMA.Text);
            myCommand.CommandText = SQL.ToString();
            myConnection.Open();
            SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (myReader.Read())
            {
                SIRKETREF = (int)myReader["ID"];
            }
            myReader.Close();
            myCommand.Connection.Close();
        }

        private void GENEL_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}