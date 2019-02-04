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
    public partial class GRUP_MUSTERI_TANIMLA : DevExpress.XtraEditors.XtraForm
    {
        DataView dv_DAHIL_FIRMALAR;
        public GRUP_MUSTERI_TANIMLA()
        {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

           
            CMB_ONAY_GRUBU.Properties.Items.Clear();

            SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            string SQL = "  select *  from  FTR_FATURA_ONAY_GRUBU WHERE SIRKET_KODU='" + _GLOBAL_PARAMETERS._SIRKET_KODU + "' and (MUSTERI_KISITI = 1)    ";
            SqlCommand myCommand = new SqlCommand(SQL, myConnection);
            myCommand.CommandText = SQL.ToString();
            myConnection.Open();
            SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (myReader.Read())
            {
                CMB_ONAY_GRUBU.Properties.Items.Add(myReader["ONAY_GRUBU"].ToString());

            }
            MUSTERI_LISTESI();
        }
        private void MUSTERI_LISTESI()
        {
            using (SqlConnection conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                DataSet ds = new DataSet();
                string SQL = " SELECT  * FROM  dbo.ADM_MUSTERI where SIRKET_KODU='" + _GLOBAL_PARAMETERS._SIRKET_KODU + "' ";
                SqlDataAdapter adapter = new SqlDataAdapter() { SelectCommand = new SqlCommand(SQL, conn) };
                adapter.Fill(ds, "ADM_TRF_LISTE_MUSTERI");
                DataViewManager dvManager = new DataViewManager(ds);
                DataView dv_ADM_KULLANICILAR = dvManager.CreateDataView(ds.Tables[0]);
                grdCntrl_GENEL.DataSource = dv_ADM_KULLANICILAR;
            }
        }

        private void BTN_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void CMB_ONAY_GRUBU_SelectedIndexChanged(object sender, EventArgs e)
        {

            ONAY_GURUBU_FIRMALARI();
        }

        private void ONAY_GURUBU_FIRMALARI()
        {
            if (CMB_ONAY_GRUBU.EditValue == null) return;

            using (SqlConnection conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                DataSet ds = new DataSet();
                string SQL = " SELECT  * FROM   dbo.FTR_FATURA_ONAY_GRUBU_MUSTERILERI  WHERE  SIRKET_KODU='" + _GLOBAL_PARAMETERS._SIRKET_KODU + "' and ONAY_GRUBU='" + CMB_ONAY_GRUBU.EditValue + "'";
                SqlDataAdapter adapter = new SqlDataAdapter() { SelectCommand = new SqlCommand(SQL, conn) };
                adapter.Fill(ds, "ADM_TRF_FATURA_ONAY_GRUBU_MUSTERILERI");
                DataViewManager dvManager = new DataViewManager(ds);
                dv_DAHIL_FIRMALAR = dvManager.CreateDataView(ds.Tables[0]);
                grdCntrl_GRUP_LIST.DataSource = dv_DAHIL_FIRMALAR;
                GRDW_ONAY_LISTE.Columns["SIRA_NO"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                GRDW_ONAY_LISTE.OptionsCustomization.AllowSort = false;
                GRDW_ONAY_LISTE.OptionsView.ShowGroupPanel = false;
            }
        }

        private void MN_EKLE_Click(object sender, EventArgs e)
        {
            if (CMB_ONAY_GRUBU.Text != "")
            {
                string Kontrol = null;

                int[] ROW = GRDW_GENEL_MUSTERI_LISTE.GetSelectedRows();
                for (int i = 0; i < ROW.Length; i++)
                {
                    DataRow dr = GRDW_GENEL_MUSTERI_LISTE.GetDataRow(Convert.ToUInt16(ROW[i]));
                    for (int iX = 0; iX <= GRDW_ONAY_LISTE.RowCount - 1; iX++)
                    {
                        DataRow rows = GRDW_ONAY_LISTE.GetDataRow(iX);
                        if (rows["MUSTERI_GRUBU"].ToString() == dr["MUSTERI_GRUBU"].ToString())
                        {
                            MessageBox.Show(dr["MUSTERI_GRUBU"].ToString() + "   daha önceden seçilmiş!", "Uyarı.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Kontrol = "var";
                            break;
                        }
                    }
                    if (Kontrol == null)
                    {
                        GRDW_ONAY_LISTE.Columns["SIRA_NO"].SortOrder = DevExpress.Data.ColumnSortOrder.None;
                        GRDW_ONAY_LISTE.AddNewRow();
                        GRDW_ONAY_LISTE.RefreshData();
                        DataRow row = GRDW_ONAY_LISTE.GetDataRow(GRDW_ONAY_LISTE.RowCount - 1);
                        row["SIRKET_KODU"] = _GLOBAL_PARAMETERS._SIRKET_KODU;
                        row["ONAY_GRUBU"] = CMB_ONAY_GRUBU.Text.ToString();
                        row["MUSTERI_GRUBU"] = dr["MUSTERI_GRUBU"].ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen kullanıcı seçiniz?", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BTN_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            SqlConnection SQLCON = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            SQLCON.Open();

            //// Satır Sil
            dv_DAHIL_FIRMALAR.RowStateFilter = DataViewRowState.Deleted;
            if (dv_DAHIL_FIRMALAR.Count != 0)
            {
                for (int i = 0; i <= dv_DAHIL_FIRMALAR.Count - 1; i++)
                {
                    DataView DW = dv_DAHIL_FIRMALAR;
                    DELETE_ROW(DW, SQLCON, i);
                }
            }

            //// Yeni eklenmiş Satırları kaydet
            dv_DAHIL_FIRMALAR.RowStateFilter = DataViewRowState.Added;
            if (dv_DAHIL_FIRMALAR.Count != 0)
            {

                for (int i = 0; i <= dv_DAHIL_FIRMALAR.Count - 1; i++)
                {
                    DataRow DR = dv_DAHIL_FIRMALAR[i].Row;
                    INSERT_ROW(DR, SQLCON);
                }
            }
            // Satır Değiştir 
            dv_DAHIL_FIRMALAR.RowStateFilter = DataViewRowState.ModifiedCurrent;
            if (dv_DAHIL_FIRMALAR.Count != 0)
            { 
                for (int i = 0; i <= dv_DAHIL_FIRMALAR.Count - 1; i++)
                {
                    if (dv_DAHIL_FIRMALAR[i]["ONAYLAYAN"].ToString() != "")
                    {
                        if (dv_DAHIL_FIRMALAR[i]["ID"] == DBNull.Value)
                        {
                            DataRow DR = dv_DAHIL_FIRMALAR[i].Row;
                            INSERT_ROW(DR, SQLCON);
                        }
                        if (dv_DAHIL_FIRMALAR[i]["ID"] != DBNull.Value)
                        {
                            DataRow DR = dv_DAHIL_FIRMALAR[i].Row;
                            UPDATE_ROW(DR, SQLCON);
                        }
                    }
                }
            }
            //SetWaitDialogCaption("Plan Giriş verileri güncelleniyor.");
            dv_DAHIL_FIRMALAR.RowStateFilter = DataViewRowState.CurrentRows;
            dv_DAHIL_FIRMALAR.Table.AcceptChanges(); 
        } 

        private void INSERT_ROW(DataRow DR, SqlConnection myConnection)
        {

            string myInsertQuery = " INSERT INTO  dbo.FTR_FATURA_ONAY_GRUBU_MUSTERILERI  (SIRKET_KODU,ONAY_GRUBU,MUSTERI_GRUBU) VALUES(@SIRKET_KODU, @ONAY_GRUBU,@MUSTERI_GRUBU) ";
            SqlCommand myCommand = new SqlCommand(myInsertQuery);
            myCommand.Parameters.AddWithValue("@SIRKET_KODU", DR["SIRKET_KODU"]);
            myCommand.Parameters.AddWithValue("@ONAY_GRUBU", DR["ONAY_GRUBU"]);
            myCommand.Parameters.AddWithValue("@MUSTERI_GRUBU", DR["MUSTERI_GRUBU"]);
            myCommand.Connection = myConnection;
            myCommand.ExecuteNonQuery();

        }

        private void UPDATE_ROW(DataRow DR, SqlConnection myConnection)
        {
            string myInsertQuery = "Update dbo.FTR_FATURA_ONAY_GRUBU_MUSTERILERI  Set  MUSTERI_GRUBU=@MUSTERI_GRUBU   Where ID=@ID and SIRKET_KODU=@SIRKET_KODU and ONAY_GRUBU=@ONAY_GRUBU";
            SqlCommand myCommand = new SqlCommand(myInsertQuery);
            myCommand.Parameters.AddWithValue("@SIRKET_KODU", DR["SIRKET_KODU"]);
            myCommand.Parameters.AddWithValue("@MUSTERI_GRUBU", DR["MUSTERI_GRUBU"]);
            myCommand.Parameters.AddWithValue("@ONAY_GRUBU", DR["ONAY_GRUBU"]);
            myCommand.Parameters.AddWithValue("@ID", DR["OID"]);
            myCommand.Connection = myConnection;
            myCommand.ExecuteNonQuery();
        }

        private void DELETE_ROW(DataView DW, SqlConnection myConnection, int i)
        {
            string myInsertQuery = "delete dbo.FTR_FATURA_ONAY_GRUBU_MUSTERILERI   Where ID=@ID AND  MUSTERI_GRUBU=@MUSTERI_GRUBU and SIRKET_KODU=@SIRKET_KODU  and ONAY_GRUBU=@ONAY_GRUBU";
            SqlCommand myCommand = new SqlCommand(myInsertQuery);
            myCommand.Parameters.AddWithValue("@SIRKET_KODU", DW[i]["SIRKET_KODU"]);
            myCommand.Parameters.AddWithValue("@MUSTERI_GRUBU", DW[i]["MUSTERI_GRUBU"]);
            myCommand.Parameters.AddWithValue("@ONAY_GRUBU", DW[i]["ONAY_GRUBU"]);
            myCommand.Parameters.AddWithValue("@ID", DW[i]["OID"]);
            myCommand.Connection = myConnection;
            myCommand.ExecuteNonQuery();
        }

        private void MN_SIL_Click(object sender, EventArgs e)
        {
            int[] GETROW = GRDW_ONAY_LISTE.GetSelectedRows();
            for (int i = GETROW.Length - 1; i >= 0; i--)
            {
                dv_DAHIL_FIRMALAR.Delete(Convert.ToUInt16(GETROW[i]));
            }  
        }
    }
}