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

namespace VISION.FINANS.MUHASEBE_AKTARIMI_MANUEL.ALIM
{
    public partial class AKTARIM_PARAMETRESI : DevExpress.XtraEditors.XtraForm
    {
        public string _DATE, BTN_TYPE, FATURA_SERISI, FATURANIN_TURU;
 
        public int FATURA_TEMEL_TICARI = 1;

 
        public AKTARIM_PARAMETRESI()
        {
            InitializeComponent();

            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          
         

        }


        private void AKTARIM_PARAMETRESI_Load(object sender, EventArgs e)
        {
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string SQL = "";
                if (FATURANIN_TURU == "e-arşiv") SQL = "  SELECT * FROM   dbo.FTR_ERP_FATURA_SERISI where  FIRMA_CODE=@FIRMA_CODE  and FATURA_TYPE='A'   ";
                if (FATURANIN_TURU == "e-fatura") SQL = "  SELECT * FROM   dbo.FTR_ERP_FATURA_SERISI where  FIRMA_CODE=@FIRMA_CODE  and FATURA_TYPE='E'   ";
                SqlCommand myCommand = new SqlCommand(SQL, myConnection);
                myCommand.Parameters.AddWithValue("@FIRMA_CODE", _GLOBAL_PARAMETERS._SIRKET_NO);
                myCommand.CommandText = SQL.ToString();
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    CMB_E_FATURA_SERISI.Properties.Items.Add(myReader["FATURA_SERISI"].ToString());

                    if (myReader["DEFAULT_"] != DBNull.Value && myReader["DEFAULT_"].ToString() == "True") CMB_E_FATURA_SERISI.Text = myReader["FATURA_SERISI"].ToString();

                }
                myReader.Close();
                myCommand.Connection.Close();
            }
        }


        private void BTN_TAMAM_Click(object sender, EventArgs e)
        {
            if (dtEdit_TARIH.EditValue != null) _DATE = dtEdit_TARIH.EditValue.ToString(); 
            
            if (rd_TICARI.Checked) FATURA_TEMEL_TICARI = 2;
            if (rd_TEMEL.Checked) FATURA_TEMEL_TICARI = 1;
            if (CMB_E_FATURA_SERISI.Text != "") FATURA_SERISI = CMB_E_FATURA_SERISI.Text; else FATURA_SERISI = null;

            BTN_TYPE = "TAMAM";
            Close();
        }

        private void BTN_VAZGEC_Click(object sender, EventArgs e)
        {
            _DATE = null;
            BTN_TYPE = "VAZGEC";
            Close();
        }


        //private void DATE_CONTROL()
        //{
        //    dtEdit_TARIH.Properties.MinValue = DateTime.Now.AddDays(-7);
        //    using (SqlConnection myConnection = new SqlConnection(Masters._CONNECTIONSTRING_ERP.ToString()))
        //    {
        //        string SQL = " SELECT MAX(DATE_) as DATE_ from dbo.LG_" + Masters._firmNo + "_01_INVOICE WHERE FICHENO LIKE'" + CMB_E_FATURA_SERISI.Text + "%'   ";
        //        SqlCommand myCommand = new SqlCommand(SQL, myConnection);
        //        myCommand.CommandText = SQL.ToString();
        //        myConnection.Open();
        //        SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
        //        while (myReader.Read())
        //        {
        //            if (myReader["DATE_"] != DBNull.Value) dtEdit_TARIH.Properties.MinValue = Convert.ToDateTime(myReader["DATE_"].ToString());
        //        }
        //        myReader.Close();
        //        myCommand.Connection.Close();
        //        dtEdit_TARIH.Properties.MaxValue = DateTime.Now;
        //    }
        //}
    }
}