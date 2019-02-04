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

namespace VISION._LOCAL_ADMIN.KULLANICI_HAKLARI
{
    public partial class MUSTERI_HAKLARI : DevExpress.XtraEditors.XtraForm
    {
        int _SIRKET_ID;
        string _SIRKET_KODU, _SECILEN_MUSTERI_KODU;
        public MUSTERI_HAKLARI()
        {
            InitializeComponent();
            this.Tag = "MDIFORM";

            SIRKET_LISTESI();
        }

        private void SIRKET_LISTESI()
        {
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlCommand myCommand = new SqlCommand("SELECT * FROM  dbo.ADM_SIRKET", myConnection);
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                    CMB_FIRMA_SELECT.Properties.Items.Add(myReader["SIRKET_KODU"].ToString());
                myConnection.Close();
            }

            MUSTERI_LISTESI();
        }
        private void CMB_FIRMA_SELECT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mySelectQuery = String.Format("SELECT   * FROM dbo.ADM_SIRKET where (SIRKET_KODU = N'{0}')", CMB_FIRMA_SELECT.Text);
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    _SIRKET_ID = Convert.ToInt16(myReader["ID"]);
                    _SIRKET_KODU = myReader["SIRKET_KODU"].ToString();
                }
                myConnection.Close();
            }
            lbID.Caption = null;        
            lbKodu.Caption = null;
            GENEL_KULLANICI_LISTESI();
            MUSTERI_LISTESI();
        }
        private void GENEL_KULLANICI_LISTESI()
        {
            using (SqlConnection MySqlConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(String.Format(" SELECT * FROM  dbo.ADM_KULLANICI WHERE  (SOFT_DELETE = N'#') AND (SIRKETREF = '{0}')", _SIRKET_ID), MySqlConnection);
                using (DataSet MyDataSet = new DataSet())
                {
                    MySqlDataAdapter.Fill(MyDataSet, "dbo_USER");
                    DataViewManager dvManager = new DataViewManager(MyDataSet);
                    DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                    GRD_KULLANICI_LISTE.DataSource = dv;
                }
            }
        }
        private void MUSTERI_LISTESI()
        {
            using (SqlConnection MySqlConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(String.Format("SELECT  *  FROM    dbo.ADM_MUSTERI WHERE     (SOFT_DELETE = N'#') AND (SIRKETREF = '{0}')", _SIRKET_ID), MySqlConnection);
                using (DataSet MyDataSet = new DataSet())
                {
                    MySqlDataAdapter.Fill(MyDataSet, "dbo_USER");
                    DataViewManager dvManager = new DataViewManager(MyDataSet);
                    DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                    GRD_GENEL_MUSTERI_LISTE.DataSource = dv;
                }
            }
        }

        private void DataHakUpdate(DataRow dr, string fs)
        {
            string myInsertQuery = "";
            SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            if (dr != null)
            {
                SqlConnection myConnectionUp = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                myInsertQuery = String.Format(" SELECT     dbo.ADM_KULLANICI_MUSTERILERI.SIRKETREF, dbo.ADM_KULLANICI_MUSTERILERI.KULLANICIREF, dbo.ADM_KULLANICI_MUSTERILERI.MUSTERI_KODU, dbo.ADM_KULLANICI.MAIL_ADRESI, dbo.ADM_KULLANICI.SOFT_DELETE FROM         dbo.ADM_KULLANICI_MUSTERILERI INNER JOIN  dbo.ADM_KULLANICI ON dbo.ADM_KULLANICI_MUSTERILERI.KULLANICIREF = dbo.ADM_KULLANICI.ID WHERE     (dbo.ADM_KULLANICI.SOFT_DELETE = N'#')  AND (dbo.ADM_KULLANICI.MAIL_ADRESI = N'{0}') AND  (dbo.ADM_KULLANICI_MUSTERILERI.SIRKETREF = '{1}') AND (dbo.ADM_KULLANICI_MUSTERILERI.MUSTERI_KODU = N'{2}')", lbKodu.Caption, _SIRKET_ID, dr["MUSTERI_KODU"]);

                using (SqlCommand myCommandUp = new SqlCommand(myInsertQuery))
                {
                    myCommandUp.Connection = myConnectionUp;
                    myConnectionUp.Open();
                    SqlDataReader myReaderUp = myCommandUp.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReaderUp.HasRows == false)
                    {
                        SqlParameter SIRKETREF = new SqlParameter("@SIRKETREF", SqlDbType.Int);
                        SqlParameter KULLANICIREF = new SqlParameter("@KULLANICIREF", SqlDbType.Int);
                        SqlParameter MUSTERI_KODU = new SqlParameter("@MUSTERI_KODU", SqlDbType.VarChar);                     
                        myInsertQuery = "INSERT INTO dbo.ADM_KULLANICI_MUSTERILERI(SIRKETREF, KULLANICIREF, MUSTERI_KODU)  Values(@SIRKETREF,@KULLANICIREF,@MUSTERI_KODU)";
                        SqlCommand myCommand = new SqlCommand(myInsertQuery);
                        myCommand.Parameters.Add(SIRKETREF);
                        myCommand.Parameters.Add(KULLANICIREF);
                        myCommand.Parameters.Add(MUSTERI_KODU); 
                        SIRKETREF.Value = _SIRKET_ID.ToString();
                        KULLANICIREF.Value = lbID.Caption;
                        MUSTERI_KODU.Value = dr["MUSTERI_KODU"].ToString(); 
                        myCommand.Connection = myConnection;
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myCommand.Connection.Close();
                    }
                    myCommandUp.Connection.Close();
                }
            }
        }
        private void DataHakDelete(DataRow dr, string fs)
        {
            if (dr != null)
            {
                SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                DateTime myDT = DateTime.Now;
                string myInsertQuery = String.Format(" delete dbo.ADM_KULLANICI_MUSTERILERI WHERE MUSTERI_KODU='{0}' AND KULLANICIREF='{1}'", dr["MUSTERI_KODU"], lbID.Caption);
                SqlCommand myCommand = new SqlCommand(myInsertQuery);
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();
            }
        } 

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void GRD_KULLANICI_LISTE_Click(object sender, EventArgs e)
        {

            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi =
                             GRDW_KULLANICI_LISTE.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));
            DataRow dr = GRDW_KULLANICI_LISTE.GetDataRow(hi.RowHandle);
            if (dr != null)
            {
                lbID.Caption = dr["ID"].ToString();            
                lbKodu.Caption = dr["MAIL_ADRESI"].ToString();
            }
            KULLANICI_LISTESI();
        }

        private void KULLANICI_LISTESI()
        {
            using (SqlConnection MySqlConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(String.Format("SELECT   dbo.ADM_KULLANICI_MUSTERILERI.SIRKETREF,dbo.ADM_KULLANICI_MUSTERILERI.KULLANICIREF ,dbo.ADM_SIRKET.SIRKET_KODU, dbo.ADM_KULLANICI.MAIL_ADRESI, dbo.ADM_MUSTERI.MUSTERI_GRUBU, dbo.ADM_MUSTERI.MUSTERI_KODU,  dbo.ADM_MUSTERI.ADI FROM   dbo.ADM_SIRKET INNER JOIN   dbo.ADM_KULLANICI ON dbo.ADM_SIRKET.ID = dbo.ADM_KULLANICI.SIRKETREF INNER JOIN  dbo.ADM_KULLANICI_MUSTERILERI ON dbo.ADM_KULLANICI.SIRKETREF = dbo.ADM_KULLANICI_MUSTERILERI.SIRKETREF AND    dbo.ADM_KULLANICI.ID = dbo.ADM_KULLANICI_MUSTERILERI.KULLANICIREF INNER JOIN  dbo.ADM_MUSTERI ON dbo.ADM_KULLANICI_MUSTERILERI.MUSTERI_KODU = dbo.ADM_MUSTERI.MUSTERI_KODU  WHERE  (dbo.ADM_KULLANICI.SOFT_DELETE = N'#') AND (dbo.ADM_KULLANICI.MAIL_ADRESI = '{0}') AND (dbo.ADM_SIRKET.SIRKET_KODU  = '{1}')", lbKodu.Caption, CMB_FIRMA_SELECT.Text), MySqlConnection);
                using (DataSet MyDataSet = new DataSet())
                {
                    MySqlDataAdapter.Fill(MyDataSet, "dbo_USER");
                    DataViewManager dvManager = new DataViewManager(MyDataSet);
                    DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                    GRD_KULLANICI_MUSTERI_LISTE.DataSource = dv;
                }
            }
        }

        private void BR_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i <= GRDW_KULLANICI_MUSTERI_LISTE.RowCount; i++)
                DataHakUpdate(GRDW_KULLANICI_MUSTERI_LISTE.GetDataRow(i), "");
            MessageBox.Show("Kullanıcı hakları güncellendi.", "Uyari",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MN_MUSTERI_EKLE_Click(object sender, EventArgs e)
        {
            if (lbKodu.Caption != "")
            {
                string Kontrol = null;
               
                      int[] ROW = GRDW_GENEL_MUSTERI_LISTE.GetSelectedRows();
                      for (int i = 0; i < ROW.Length; i++)
                      {
                        DataRow dr = GRDW_GENEL_MUSTERI_LISTE.GetDataRow(Convert.ToUInt16(ROW[i]));
                        for (int iX = 0; iX <= GRDW_KULLANICI_MUSTERI_LISTE.RowCount - 1; iX++)
                        {
                            DataRow rows = GRDW_KULLANICI_MUSTERI_LISTE.GetDataRow(iX);
                            if (rows["MUSTERI_KODU"].ToString() == dr["MUSTERI_KODU"].ToString())
                            {
                                MessageBox.Show(dr["MUSTERI_KODU"].ToString() + "   daha önceden seçilmiş!", "Uyarı.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Kontrol = "var";
                                break;
                            }
                        }
                        if (Kontrol == null)
                        {
                            GRDW_KULLANICI_MUSTERI_LISTE.AddNewRow();
                            GRDW_KULLANICI_MUSTERI_LISTE.RefreshData();
                            DataRow row = GRDW_KULLANICI_MUSTERI_LISTE.GetDataRow(GRDW_KULLANICI_MUSTERI_LISTE.RowCount - 1); 
                            row["SIRKET_KODU"] = _GLOBAL_PARAMETERS._SIRKET_KODU.ToString();
                            row["KULLANICIREF"] = lbID.Caption;
                            //row["MUSTERI_GRUBU_KODU"] = dr["MUSTERI_GRUBU_KODU"].ToString();
                            row["MUSTERI_KODU"] = dr["MUSTERI_KODU"].ToString();
                            //row["ADI"] = dr["ADI"].ToString();
                        }
                    } 
            }
            else
            {
                MessageBox.Show("Lütfen kullanıcı seçiniz?", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MN_MUSTERI_SIL_Click(object sender, EventArgs e)
        {
            int[] ROW = GRDW_KULLANICI_MUSTERI_LISTE.GetSelectedRows();
        for (int i = 0; i < ROW.Length; i++)
        {
            DataRow dr = GRDW_GENEL_MUSTERI_LISTE.GetDataRow(Convert.ToUInt16(ROW[i]));
            if (dr != null)
            {
                SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                DateTime myDT = DateTime.Now;
                string myInsertQuery = String.Format(" delete dbo.ADM_KULLANICI_MUSTERILERI WHERE MUSTERI_KODU='{0}' AND KULLANICIREF='{1}'", dr["MUSTERI_KODU"], lbID.Caption);
                SqlCommand myCommand = new SqlCommand(myInsertQuery);
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();
            }
          }
        } 
    }
}