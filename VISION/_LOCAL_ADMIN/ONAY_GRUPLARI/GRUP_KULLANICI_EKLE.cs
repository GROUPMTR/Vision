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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace VISION._LOCAL_ADMIN.ONAY_GRUPLARI
{
    public partial class GRUP_KULLANICI_EKLE : DevExpress.XtraEditors.XtraForm
    {
        DataView dv_DAHIL_KULLANICILAR;
        public GRUP_KULLANICI_EKLE()
        {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;


            CMB_ONAY_GRUBU.Properties.Items.Clear();
            CMB_ONAY_GRUBU_TURU.Properties.Items.Clear();
            SqlConnection SqlCon = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            SqlCon.Open();
            using (SqlCommand myCommand = new SqlCommand("SELECT * FROM  ADM_GENEL_LISTELER WHERE ERISIM_TURU='ONAY_GRUBU_TURU'", SqlCon))
            {
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    CMB_ONAY_GRUBU_TURU.Properties.Items.Add(myReader["DEFAULT_ACIKLAMA"].ToString());
                }
                myReader.Close();
            }


            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlCommand myCommand = new SqlCommand("SELECT * FROM  dbo.ADM_SIRKET", myConnection);
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    CMB_FIRMA_SELECT.Properties.Items.Add(myReader["SIRKET_KODU"].ToString());
                    CMB_FIRMA_NAME.Properties.Items.Add(myReader["SIRKET_KODU"].ToString());
                }
                myConnection.Close();
            }

            KULLANICI_LISTESI(); 
        }


        private void KULLANICI_LISTESI()
        {
            using (SqlConnection conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                DataSet ds = new DataSet();
                string SQL = " SELECT  * FROM    dbo.ADM_KULLANICI where  SIRKET_KODU='" + _GLOBAL_PARAMETERS._SIRKET_KODU + "' and AKTIF='True'";
                SqlDataAdapter adapter = new SqlDataAdapter() { SelectCommand = new SqlCommand(SQL, conn) };
                adapter.Fill(ds, "ADM_KULLANICILAR");
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
             ONAYLAYACAK_KULLANICILAR();
        }

        private void ONAYLAYACAK_KULLANICILAR()
        {
            if (CMB_ONAY_GRUBU.EditValue== null) return;
            using (SqlConnection conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                DataSet ds = new DataSet();
                string SQL = string.Format(" SELECT  * FROM   dbo.ADM_ONAY_GRUBU_KULLANICILARI  WHERE  SIRKET_KODU='{0}' and ONAY_GRUBU='{1}'", _GLOBAL_PARAMETERS._SIRKET_KODU, CMB_ONAY_GRUBU.EditValue);
                SqlDataAdapter adapter = new SqlDataAdapter() { SelectCommand = new SqlCommand(SQL, conn) };
                adapter.Fill(ds, "ADM_GRUP_DAHIL_KULLANICILAR");
                DataViewManager dvManager = new DataViewManager(ds);
                dv_DAHIL_KULLANICILAR = dvManager.CreateDataView(ds.Tables[0]);
                grdCntrl_HAKLARI.DataSource = dv_DAHIL_KULLANICILAR;
                GRDW_HAKLARI.Columns["SIRA_NO"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                GRDW_HAKLARI.OptionsCustomization.AllowSort = false ;
                GRDW_HAKLARI.OptionsView.ShowGroupPanel = false;
                grdCntrl_HAKLARI.AllowDrop = true;
            } 
        }

        private void MN_EKLE_Click(object sender, EventArgs e)
        {
            if (CMB_ONAY_GRUBU.Text != "")
            {
                string Kontrol = null;
                int[] ROW = GRDW_GENEL_KULLANICI_LISTE.GetSelectedRows();
                for (int i = 0; i < ROW.Length; i++)
                {
                    DataRow dr = GRDW_GENEL_KULLANICI_LISTE.GetDataRow(Convert.ToUInt16(ROW[i]));
                    for (int iX = 0; iX <= GRDW_HAKLARI.RowCount - 1; iX++)
                    {
                        DataRow rows = GRDW_HAKLARI.GetDataRow(iX);
                        if (rows["ONAYLAYAN"].ToString() == dr["MAIL_ADRESI"].ToString())
                        {
                            MessageBox.Show(dr["MAIL_ADRESI"].ToString() + "   daha önceden seçilmiş!", "Uyarı.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Kontrol = "var";
                            break;
                        }
                    }
                    if (Kontrol == null)
                    {
                        GRDW_HAKLARI.Columns["SIRA_NO"].SortOrder = DevExpress.Data.ColumnSortOrder.None;
                        GRDW_HAKLARI.AddNewRow();
                        GRDW_HAKLARI.RefreshData();
                        DataRow row = GRDW_HAKLARI.GetDataRow(GRDW_HAKLARI.RowCount - 1);
                        row["ONAY_GRUBU"] = CMB_ONAY_GRUBU.Text.ToString();
                        row["SIRA_NO"] = GRDW_HAKLARI.RowCount;
                        row["ONAYLAYAN"] = dr["MAIL_ADRESI"].ToString();
                        row["UNVANI"] = dr["UNVANI"].ToString();
                        GRDW_HAKLARI.Columns["SIRA_NO"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen kullanıcı seçiniz?", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MN_SIL_Click(object sender, EventArgs e)
        {
            int[] GETROW = GRDW_HAKLARI.GetSelectedRows();
            for (int i = GETROW.Length - 1; i >= 0; i--)
            {
                dv_DAHIL_KULLANICILAR.Delete(Convert.ToUInt16(GETROW[i]));
            } 
        }
        private void grdCntrl_HAKLARI_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(GridHitInfo)))
            {
                GridHitInfo downHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
                if (downHitInfo == null)
                    return;

                GridControl grid = sender as GridControl;
                GridView view = grid.MainView as GridView;
                GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
                if (hitInfo.InRow && hitInfo.RowHandle != downHitInfo.RowHandle && hitInfo.RowHandle != GridControl.NewItemRowHandle)
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void grdCntrl_HAKLARI_DragDrop(object sender, DragEventArgs e)
        {
            GridControl grid = sender as GridControl;
            GridView view = grid.MainView as GridView;
            GridHitInfo srcHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
            GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
            int sourceRow = srcHitInfo.RowHandle;
            int targetRow = hitInfo.RowHandle;
            MoveRow(sourceRow, targetRow);
        }

        private void MoveRow(int sourceRow, int targetRow)
        {
            if (sourceRow == targetRow || sourceRow == targetRow + 1)
                return;

            GridView view = GRDW_HAKLARI;
            DataRow row1 = view.GetDataRow(targetRow);
            DataRow row2 = view.GetDataRow(targetRow + 1);
            DataRow dragRow = view.GetDataRow(sourceRow);
            decimal val1 = (decimal)row1["SIRA_NO"];
            if (row2 == null)
                dragRow["SIRA_NO"] = val1 + 1;
            else
            {
                decimal val2 = (decimal)row2["SIRA_NO"];
                dragRow["SIRA_NO"] = (val1 + val2) / 2;
            }
        }

        GridHitInfo downHitInfo = null;
        private void GRDW_ONAY_LISTE_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,
                    downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    view.GridControl.DoDragDrop(downHitInfo, DragDropEffects.All);
                    downHitInfo = null;
                }
            }
        }
        private void GRDW_ONAY_LISTE_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            downHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None)
                return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.RowHandle != GridControl.NewItemRowHandle)
                downHitInfo = hitInfo;

        }

        private void BTN_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            SqlConnection SQLCON = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            SQLCON.Open();

            //// Satır Sil
            dv_DAHIL_KULLANICILAR.RowStateFilter = DataViewRowState.Deleted;
            if (dv_DAHIL_KULLANICILAR.Count != 0)
            {
                for (int i = 0; i <= dv_DAHIL_KULLANICILAR.Count - 1; i++)
                {
                    DataView DW = dv_DAHIL_KULLANICILAR;
                    DELETE_ROW(DW, SQLCON, i);
                }
            }

            //// Yeni eklenmiş Satırları kaydet
            dv_DAHIL_KULLANICILAR.RowStateFilter = DataViewRowState.Added;
            if (dv_DAHIL_KULLANICILAR.Count != 0)
            {

                for (int i = 0; i <= dv_DAHIL_KULLANICILAR.Count - 1; i++)
                {
                    DataRow DR = dv_DAHIL_KULLANICILAR[i].Row;
                    INSERT_ROW(DR, SQLCON);
                }
            }
            // Satır Değiştir 
            dv_DAHIL_KULLANICILAR.RowStateFilter = DataViewRowState.ModifiedCurrent;
            if (dv_DAHIL_KULLANICILAR.Count != 0)
            {


                for (int i = 0; i <= dv_DAHIL_KULLANICILAR.Count - 1; i++)
                {
                    if (dv_DAHIL_KULLANICILAR[i]["ONAYLAYAN"].ToString() != "")
                    {
                        if (dv_DAHIL_KULLANICILAR[i]["ID"] == DBNull.Value)
                        {
                            DataRow DR = dv_DAHIL_KULLANICILAR[i].Row;
                            INSERT_ROW(DR, SQLCON);
                        }
                        if (dv_DAHIL_KULLANICILAR[i]["ID"] != DBNull.Value)
                        {
                            DataRow DR = dv_DAHIL_KULLANICILAR[i].Row;
                            UPDATE_ROW(DR, SQLCON);
                        }
                    }
                }
            }
            //SetWaitDialogCaption("Plan Giriş verileri güncelleniyor.");
            dv_DAHIL_KULLANICILAR.RowStateFilter = DataViewRowState.CurrentRows;
            dv_DAHIL_KULLANICILAR.Table.AcceptChanges();
        }
        private void INSERT_ROW(DataRow DR, SqlConnection myConnection)
        {
            string myInsertQuery = " INSERT INTO dbo.ADM_ONAY_GRUBU_KULLANICILARI    (SIRKET_KODU, ONAY_GRUBU, SIRA_NO, UNVANI, ONAYLAYAN) VALUES( @SIRKET_KODU, @ONAY_GRUBU, @SIRA_NO, @UNVANI, @ONAYLAYAN) ";
            SqlCommand myCommand = new SqlCommand(myInsertQuery);
            myCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
            myCommand.Parameters.AddWithValue("@ONAY_GRUBU", DR["ONAY_GRUBU"]);
            myCommand.Parameters.AddWithValue("@SIRA_NO", DR["SIRA_NO"]);
            myCommand.Parameters.AddWithValue("@UNVANI", DR["UNVANI"]);
            myCommand.Parameters.AddWithValue("@ONAYLAYAN", DR["ONAYLAYAN"]);
            myCommand.Connection = myConnection;
            myCommand.ExecuteNonQuery();
        }

        private void UPDATE_ROW(DataRow DR, SqlConnection myConnection)
        {
            string myInsertQuery = "Update dbo.ADM_ONAY_GRUBU_KULLANICILARI    Set  SIRA_NO=@SIRA_NO   Where   SIRKET_KODU=@SIRKET_KODU and ID=@ID  ";
            SqlCommand myCommand = new SqlCommand(myInsertQuery);
            myCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
            myCommand.Parameters.AddWithValue("@SIRA_NO", DR["SIRA_NO"]);
            myCommand.Parameters.AddWithValue("@ID", DR["ID"]);
            myCommand.Connection = myConnection;
            myCommand.ExecuteNonQuery();
        }


        private void DELETE_ROW(DataView DW, SqlConnection myConnection, int i)
        {
            string myInsertQuery = "delete dbo.ADM_ONAY_GRUBU_KULLANICILARI    Where  SIRKET_KODU=@SIRKET_KODU and ID=@ID ";
            SqlCommand myCommand = new SqlCommand(myInsertQuery);
            myCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
            myCommand.Parameters.AddWithValue("@ONAY_GRUBU", DW[i]["ONAY_GRUBU"]);
            myCommand.Parameters.AddWithValue("@SIRA_NO", DW[i]["SIRA_NO"]);
            myCommand.Parameters.AddWithValue("@ID", DW[i]["ID"]);
            myCommand.Connection = myConnection;
            myCommand.ExecuteNonQuery();
        }

        private void CMB_ONAY_GRUBU_TURU_SelectedIndexChanged(object sender, EventArgs e)
        {
            CMB_ONAY_GRUBU.Properties.Items.Clear();
            SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            string SQL = string.Format(" select *  from  dbo.ADM_ONAY_GRUBU WHERE SIRKET_KODU='{0}' AND ONAY_GRUBU_TURU='{1}'", _GLOBAL_PARAMETERS._SIRKET_KODU, CMB_ONAY_GRUBU_TURU.EditValue);
            SqlCommand myCommand = new SqlCommand(SQL, myConnection);
            myCommand.CommandText = SQL.ToString();
            myConnection.Open();
            SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (myReader.Read())
            {
                CMB_ONAY_GRUBU.Properties.Items.Add(myReader["ONAY_GRUBU"].ToString());
            } 
        }

       
    }    
}