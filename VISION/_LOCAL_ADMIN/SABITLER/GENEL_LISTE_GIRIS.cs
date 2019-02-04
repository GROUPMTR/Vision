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

namespace VISION._LOCAL_ADMIN.SABITLER
{
    public partial class GENEL_LISTE_GIRIS : DevExpress.XtraEditors.XtraForm
    {
        DataView DW_LIST;
        string _ERISIM_TURU = "";
        public GENEL_LISTE_GIRIS(string TIPI)
        {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            _ERISIM_TURU = TIPI;
            DATA_LOAD();

            for (int i = 0; i <= 5; i++)
            {
                DW_LIST.AddNew();
                DataRow dr = DW_LIST[GRD_VIEW_LISTE.RowCount - 1].Row;
                dr["SIRA_INDEX"] = GRD_VIEW_LISTE.RowCount;
            }
            GRD_VIEW_LISTE.RefreshData();
        }
        private void DATA_LOAD()
        {
            using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM  dbo.ADM_GENEL_LISTELER where ERISIM_TURU=@ERISIM_TURU ", con);
                da.SelectCommand.Parameters.AddWithValue("@ERISIM_TURU", _ERISIM_TURU);
                DataSet MyDataSet = new DataSet();
                da.Fill(MyDataSet, "ADM_GENEL_LISTELER");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                DW_LIST = dvManager.CreateDataView(MyDataSet.Tables[0]);
                GRD_LISTE.DataSource = DW_LIST;
            }  
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void BR_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        { 
            SqlConnection SQLCON = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            SQLCON.Open(); 
            //// Satır Sil
            DW_LIST.RowStateFilter = DataViewRowState.Deleted;
            if (DW_LIST.Count != 0)
            { 
                //  SetWaitDialogCaption("Spotlar siliniyor...");
                for (int i = 0; i <= DW_LIST.Count - 1; i++)
                {
                  
                        if (DW_LIST[i]["ID"] != DBNull.Value)
                        {
                            string myInsertQuery = " DELETE  dbo.ADM_GENEL_LISTELER WHERE  (ERISIM_TURU=@ERISIM_TURU) and (DEFAULT_ACIKLAMA=@DEFAULT_ACIKLAMA) and (ID=@ID)";
                            SqlCommand myCmd = new SqlCommand(myInsertQuery); 
                            myCmd.Parameters.AddWithValue("@ERISIM_TURU", _ERISIM_TURU);
                            myCmd.Parameters.AddWithValue("@DEFAULT_ACIKLAMA", DW_LIST[i]["DEFAULT_ACIKLAMA"].ToString());
                            myCmd.Parameters.AddWithValue("@ID", DW_LIST[i]["ID"].ToString()); 
                            myCmd.Connection = SQLCON;
                            myCmd.ExecuteNonQuery();
                        }
                  
                }
            }

            // Yeni eklenmiş Satırları kaydet
            DW_LIST.RowStateFilter = DataViewRowState.Added;
            if (DW_LIST.Count != 0)
            {         
                for (int i = 0; i <= DW_LIST.Count - 1; i++)
                {

                    if (DW_LIST[i]["ID"] == DBNull.Value)
                    {
                        if (DW_LIST[i]["DEFAULT_ACIKLAMA"].ToString() != "")
                        {
                            string InsertQuery = "INSERT INTO dbo.ADM_GENEL_LISTELER(ERISIM_TURU, DEFAULT_ACIKLAMA, SIRA_INDEX) Values (@ERISIM_TURU,@DEFAULT_ACIKLAMA,@SIRA_INDEX)";
                            SqlCommand myCommand = new SqlCommand(InsertQuery);
                            myCommand.Parameters.AddWithValue("@ERISIM_TURU", _ERISIM_TURU);
                            myCommand.Parameters.AddWithValue("@DEFAULT_ACIKLAMA", DW_LIST[i]["DEFAULT_ACIKLAMA"].ToString());
                            myCommand.Parameters.AddWithValue("@SIRA_INDEX", DW_LIST[i]["SIRA_INDEX"].ToString());
                            myCommand.Connection = SQLCON;
                            myCommand.ExecuteNonQuery();
                            
                        }
                    }
                }
            }
            // Satır Değiştir 
            DW_LIST.RowStateFilter = DataViewRowState.ModifiedCurrent;
            if (DW_LIST.Count != 0)
            {
                for (int i = 0; i <= DW_LIST.Count - 1; i++)
                {  

                    if (DW_LIST[i]["DEFAULT_ACIKLAMA"].ToString() != "")
                    {
                      
                        if (DW_LIST[i]["ID"] == DBNull.Value)
                        {
                            string InsertQuery = "INSERT INTO dbo.ADM_GENEL_LISTELER(ERISIM_TURU, DEFAULT_ACIKLAMA, SIRA_INDEX)  Values(@ERISIM_TURU,@DEFAULT_ACIKLAMA,@SIRA_INDEX)";
                            SqlCommand myCommand = new SqlCommand(InsertQuery);
                            myCommand.Parameters.AddWithValue("@ERISIM_TURU", _ERISIM_TURU);
                            myCommand.Parameters.AddWithValue("@DEFAULT_ACIKLAMA", DW_LIST[i]["DEFAULT_ACIKLAMA"].ToString());
                            myCommand.Parameters.AddWithValue("@SIRA_INDEX", DW_LIST[i]["SIRA_INDEX"].ToString());
                            myCommand.Connection = SQLCON;
                            myCommand.ExecuteNonQuery();
                        

                        }
                        if (DW_LIST[i]["ID"] != DBNull.Value)
                        {

                            string InsertQuery = "UPDATE dbo.ADM_GENEL_LISTELER SET  DEFAULT_ACIKLAMA=@DEFAULT_ACIKLAMA, SIRA_INDEX=@SIRA_INDEX  WHERE ERISIM_TURU=@ERISIM_TURU AND ID=@ID";
                            SqlCommand myCommand = new SqlCommand(InsertQuery);
                            myCommand.Parameters.AddWithValue("@ERISIM_TURU", _ERISIM_TURU);
                            myCommand.Parameters.AddWithValue("@DEFAULT_ACIKLAMA", DW_LIST[i]["DEFAULT_ACIKLAMA"].ToString());
                            myCommand.Parameters.AddWithValue("@SIRA_INDEX", DW_LIST[i]["SIRA_INDEX"].ToString());
                            myCommand.Parameters.AddWithValue("@ID", DW_LIST[i]["ID"].ToString());
                            myCommand.Connection = SQLCON;
                            myCommand.ExecuteNonQuery();
                        
                        }
                    }
                }
             }
           

            DW_LIST.RowStateFilter = DataViewRowState.CurrentRows;
            //for (int i = -1; i < 6; i++)
            //{
            //    DW_LIST.AddNew();
            //}
            GRD_VIEW_LISTE.RefreshData();
            DW_LIST.Table.AcceptChanges();

            SQLCON.Close();
              
        } 
        private void BR_EKLE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i <= 5; i++)
            {
                DW_LIST.AddNew();
                DataRow dr = DW_LIST[GRD_VIEW_LISTE.RowCount - 1].Row;
                dr["SIRA_INDEX"] = GRD_VIEW_LISTE.RowCount;
            }  
        }

        private void BR_DELETE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SlctDr.Delete();
        }

        DataRow SlctDr;
        private void GRD_LISTE_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = GRD_VIEW_LISTE.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));
            SlctDr = GRD_VIEW_LISTE.GetDataRow(hi.RowHandle);
        }

        private void GRD_VIEW_LISTE_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = String.Format("{0}", e.RowHandle + 1);
                //DataRow RWS = GRD_VIEW_LISTE.GetDataRow(e.RowHandle);
                //RWS["SIRA_INDEX"] = e.RowHandle + 1;

                //for (int i = 0; i <= GRDVIEW_GRD_MECRAKRILIMI.RowCount - 1; i++)
                //{
                //    DataRow RWS = GRDVIEW_GRD_MECRAKRILIMI.GetDataRow(i);
                //    RWS["SIRA_INDEX"] = e.RowHandle + 1;

                //}


                //  if (row_chart_select != null) row_chart_select["SIRA_INDEX"] = e.RowHandle + 1;
                // if (!icon) e.Info.ImageIndex = -1;
            }
        } 
    }
}