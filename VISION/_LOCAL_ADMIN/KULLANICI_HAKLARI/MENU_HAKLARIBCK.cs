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
    public partial class MENU_HAKLARIBCK : DevExpress.XtraEditors.XtraForm
    { int _FIRMAID;
        string _FirmaCode, _AnaMenuID, _AnaMenuAutoID, _AltMenuID;
        public MENU_HAKLARIBCK()
        {
            InitializeComponent();
            this.Tag = "MDIFORM";
            SIRKET_LISTESI();
            MENU_LISTESI();
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
        } 
   
        private void KULLANICI_LISTESI()
        {
            using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlDataAdapter dt = new SqlDataAdapter(String.Format(" SELECT ID, SIRKET_KODU, MAIL_ADRESI, ADI, SOYADI FROM  dbo.ADM_KULLANICI WHERE  (AKTIF = 'True') AND (SIRKET_KODU = '{0}')", CMB_FIRMA_SELECT.Text ), con);
                using (DataSet dts = new DataSet())
                {
                    dt.Fill(dts, "ADM_KULLANICI");
                    DataViewManager dvManager = new DataViewManager(dts);
                    DataView dv = dvManager.CreateDataView(dts.Tables[0]);
                    GRD_KULLANICI_LISTE.DataSource = dv;
                }
            }   
       }
        private void MENU_LISTESI()
        {
            using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlDataAdapter dt = new SqlDataAdapter(" SELECT  * FROM  dbo.ADM_MENU_LISTESI WHERE     (MENU_GROUP = 'PAGE' or MENU_GROUP='GROUP')", con);
                using (DataSet dts = new DataSet())
                {
                    dt.Fill(dts, "dbo_USER");
                    DataViewManager dvManager = new DataViewManager(dts);
                    DataView dv = dvManager.CreateDataView(dts.Tables[0]);
                    GRD_GENEL_ANAMENU_LISTE.DataSource = dv;
                }
            } 
        }

        private void ALT_MENU(string _MENU_KODU)
        {
            using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT * FROM  dbo.ADM_MENU_LISTESI WHERE     (MENU_GROUP = '{0}') ", _MENU_KODU), con); 
                using (DataSet MyDataSet = new DataSet())
                {
                    da.Fill(MyDataSet, "ADM_MENU_LISTESI");
                    DataViewManager dvManager = new DataViewManager(MyDataSet);
                    DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                    GRD_GENEL_ALTMENU_LISTE.DataSource = dv;
                }
            }
        }

        private void KULLANICI_MENU_LISTESI(string _MAIL_ADRESI)
        {        
            using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT * FROM  dbo.ADM_KULLANICI_MENU_LISTESI WHERE     (MAIL_ADRESI = '{0}') and (MENU_GROUP = 'PAGE' )", _MAIL_ADRESI), con); 

           
        
                using (DataSet dts = new DataSet())
                {
                    da.Fill(dts, "dbo_USER");
                    DataViewManager dvManager = new DataViewManager(dts);
                    DataView dv = dvManager.CreateDataView(dts.Tables[0]);
                    GRD_KULLANICI_ANAMENU_LISTE.DataSource = dv;
                }
            }          
        } 
         
    
        private static void MENU_SIL(DataRow dr)
        {
            if (dr != null)
            {
                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                {
                    DateTime myDT = DateTime.Now;
                    string myInsertQuery = String.Format(" Update dbo.ADM_KULLANICI_MENU_LISTESI  Set SoftDelete='?'  ,SoftDeleteYapan='{0}' ,SoftDeleteYapanMakinaIP='{1}' ,SoftDeleteYapanMakinaName='{2}' ,SoftDeleteTarihi='{3:yyyy-MM-dd HH:mm:ss}' WHERE (AnaMenuID = '{4}') AND (SIRKETREF = '{5}') AND (KullaniciID='{6}')", System.Security.Principal.WindowsIdentity.GetCurrent().Name, _GLOBAL_PARAMETERS._IP, _GLOBAL_PARAMETERS._DNS, myDT, dr["AnaMenuID"], dr["SIRKETREF"], dr["KullaniciID"]);
                    using (SqlCommand myCommand = new SqlCommand(myInsertQuery) { Connection = myConnection })
                    {
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myCommand.Connection.Close();
                    }
                    SqlConnection myConnectionSub = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                    string myInsertQuerySub = String.Format(" Update dbo.Kullanici_AltMenu_Haklari Set SoftDelete='?'  ,SoftDeleteYapan='{0}' ,SoftDeleteYapanMakinaIP='{1}' ,SoftDeleteYapanMakinaName='{2}' ,SoftDeleteTarihi='{3:yyyy-MM-dd HH:mm:ss}' WHERE (AnaMenuID = '{4}') AND (SIRKETREF = '{5}') AND (KullaniciID='{6}')", System.Security.Principal.WindowsIdentity.GetCurrent().Name, _GLOBAL_PARAMETERS._IP, _GLOBAL_PARAMETERS._DNS, myDT, dr["AnaMenuID"], dr["SIRKETREF"], dr["KullaniciID"]);
                    using (SqlCommand myCommandSub = new SqlCommand(myInsertQuerySub) { Connection = myConnectionSub })
                    {
                        myConnectionSub.Open();
                        myCommandSub.ExecuteNonQuery();
                        myCommandSub.Connection.Close();
                    }
                } 
            } 
        }
 

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
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
                    _FIRMAID = Convert.ToInt16(myReader["ID"]);
                    _FirmaCode = myReader["SIRKET_KODU"].ToString();
                }
                myConnection.Close();
            }
            lbID.Caption = null;         
            lbKodu.Caption = null;
            KULLANICI_LISTESI();
        }

        private void GRD_KULLANICI_LISTE_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = grdCntrlUserView.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));
            DataRow dr = grdCntrlUserView.GetDataRow(hi.RowHandle);
            if (dr != null)
            {
                lbKodu.Caption = dr["MAIL_ADRESI"].ToString();
                KULLANICI_MENU_LISTESI(dr["MAIL_ADRESI"].ToString()); 
            }
        }

        private void GRD_GENEL_ANAMENU_LISTE_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = gridView_ANAMENU.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));
            DataRow dr = gridView_ANAMENU.GetDataRow(hi.RowHandle);
            if (dr != null)
            {
                ALT_MENU(dr["MENU_KODU"].ToString());
            }
        }

        private void BR_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i <= gridView_KULLANICI_ANAMENU.RowCount; i++)
                _Kullanici_AnaMenu(gridView_KULLANICI_ANAMENU.GetDataRow(i));


            for (int ix = 0; ix <= gridView_KULLANICI_ALTMENU.RowCount; ix++)
                _Kullanici_AltMenu(gridView_KULLANICI_ALTMENU.GetDataRow(ix));
          

            MessageBox.Show("Kullanıcı hakları güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);  
        }

        private void _Kullanici_AnaMenu(DataRow dr)
        {
            string myInsertQuery = "";
            SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            if (dr != null)
            {

                using (SqlConnection myConnectionUp = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                {
                    myInsertQuery = String.Format(" SELECT  * FROM  dbo.ADM_KULLANICI_MENU_LISTESI    WHERE (SIRKET_KODU=@SIRKET_KODU) AND  (MAIL_ADRESI = N'{0}') AND (MENU_KODU  = N'{1}')", lbKodu.Caption, dr["MENU_KODU"]);
                    using (SqlCommand myCommandUp = new SqlCommand(myInsertQuery) { Connection = myConnectionUp })
                    {
                        myCommandUp.Parameters.AddWithValue("@SIRKET_KODU", CMB_FIRMA_SELECT.Text);
                        myConnectionUp.Open();
                        SqlDataReader myReaderUp = myCommandUp.ExecuteReader(CommandBehavior.CloseConnection);
                        if (myReaderUp.HasRows == false)
                        {
                            myInsertQuery = "INSERT INTO dbo.ADM_KULLANICI_MENU_LISTESI (SIRKET_KODU,MAIL_ADRESI, MENU_GROUP, MENU_KODU,MENU_PARAMETRE,MENU_ADI,MENU_LINK,TIPI)  Values(@SIRKET_KODU,@MAIL_ADRESI, @MENU_GROUP, @MENU_KODU,@MENU_PARAMETRE,@MENU_ADI,@MENU_LINK,@TIPI)";
                            using (SqlCommand cmd = new SqlCommand(myInsertQuery))
                            {
                                cmd.Parameters.AddWithValue("@SIRKET_KODU", CMB_FIRMA_SELECT.Text);
                                cmd.Parameters.AddWithValue("@MAIL_ADRESI", lbKodu.Caption);
                                cmd.Parameters.AddWithValue("@MENU_GROUP", dr["MENU_GROUP"]);
                                cmd.Parameters.AddWithValue("@MENU_KODU", dr["MENU_KODU"]);
                                cmd.Parameters.AddWithValue("@MENU_PARAMETRE", dr["MENU_PARAMETRE"]);
                                cmd.Parameters.AddWithValue("@MENU_ADI", dr["MENU_ADI"]);
                                cmd.Parameters.AddWithValue("@MENU_LINK", dr["MENU_LINK"]);
                                //cmd.Parameters.AddWithValue("@MENU_PICTURE", dr["MENU_PICTURE"]);
                                cmd.Parameters.AddWithValue("@TIPI", dr["TIPI"]);
                                cmd.Connection = myConnection;
                                myConnection.Open();
                                cmd.ExecuteNonQuery();
                                cmd.Connection.Close();
                            }
                        }
                        myCommandUp.Connection.Close();
                    }
                }
            }
        }



        private void _Kullanici_AltMenu(DataRow dr)
        {
            string myInsertQuery = "";
            SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            if (dr != null)
            {

                using (SqlConnection myConnectionUp = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                {
                 //   myInsertQuery = String.Format(" SELECT    *  FROM  dbo.ADM_KULLANICI_ALTMENU    WHERE      (KULLANICI_KODU = N'{0}') AND (KODU = N'{1}')", lbKodu.Caption, dr["KODU"]);
                    myInsertQuery = String.Format(" SELECT  * FROM  dbo.ADM_KULLANICI_MENU_LISTESI    WHERE  (MAIL_ADRESI = N'{0}') AND (MENU_KODU  = N'{1}')", lbKodu.Caption, dr["MENU_KODU"]);
                    using (SqlCommand myCommandUp = new SqlCommand(myInsertQuery) { Connection = myConnectionUp })
                    {
                        myCommandUp.Parameters.AddWithValue("@SIRKET_KODU", CMB_FIRMA_SELECT.Text);
                        myConnectionUp.Open();
                        SqlDataReader myReaderUp = myCommandUp.ExecuteReader(CommandBehavior.CloseConnection);
                        if (myReaderUp.HasRows == false)
                        {
                            myInsertQuery = "INSERT INTO dbo.ADM_KULLANICI_MENU_LISTESI (SIRKET_KODU,MAIL_ADRESI, MENU_GROUP, MENU_KODU,MENU_PARAMETRE,MENU_ADI,MENU_LINK,TIPI)  Values(@SIRKET_KODU,@MAIL_ADRESI, @MENU_GROUP, @MENU_KODU,@MENU_PARAMETRE,@MENU_ADI,@MENU_LINK,@TIPI)";
                            using (SqlCommand cmd = new SqlCommand(myInsertQuery))
                            {
                                cmd.Parameters.AddWithValue("@SIRKET_KODU", CMB_FIRMA_SELECT.Text);
                                cmd.Parameters.AddWithValue("@MAIL_ADRESI", lbKodu.Caption);
                                cmd.Parameters.AddWithValue("@MENU_GROUP", dr["MENU_GROUP"]);
                                cmd.Parameters.AddWithValue("@MENU_KODU", dr["MENU_KODU"]);
                                cmd.Parameters.AddWithValue("@MENU_PARAMETRE", dr["MENU_PARAMETRE"]);
                                cmd.Parameters.AddWithValue("@MENU_ADI", dr["MENU_ADI"]);
                                cmd.Parameters.AddWithValue("@MENU_LINK", dr["MENU_LINK"]);
                                //cmd.Parameters.AddWithValue("@MENU_PICTURE", dr["MENU_PICTURE"]);
                                cmd.Parameters.AddWithValue("@TIPI", dr["TIPI"]);
                                cmd.Connection = myConnection;
                                myConnection.Open();
                                cmd.ExecuteNonQuery();
                                cmd.Connection.Close();
                            }
                        }
                        myCommandUp.Connection.Close();
                    }
                }
            }
        }

        private void MN_ANAMENU_EKLE_Click(object sender, EventArgs e)
        {
            int[] ROW = gridView_ANAMENU.GetSelectedRows();
            for (int i = 0; i < ROW.Length; i++)
            {
                DataRow row = gridView_ANAMENU.GetDataRow(ROW[i]);
                gridView_KULLANICI_ANAMENU.AddNewRow();
                gridView_KULLANICI_ANAMENU.RefreshData();
                DataRow rows = gridView_KULLANICI_ANAMENU.GetDataRow(gridView_KULLANICI_ANAMENU.RowCount - 1);
                rows["MAIL_ADRESI"] = lbKodu.Caption;
                rows["MENU_GROUP"] = row["MENU_GROUP"];
                rows["MENU_KODU"] = row["MENU_KODU"];
                rows["MENU_PARAMETRE"] = row["MENU_PARAMETRE"];
                rows["MENU_ADI"] = row["MENU_ADI"];
                rows["MENU_LINK"] = row["MENU_LINK"];
                rows["MENU_PICTURE"] = row["MENU_PICTURE"];
                rows["TIPI"] = row["TIPI"];
                
            }
        }

        private void MN_ALTMENU_EKLE_Click(object sender, EventArgs e)
        {
            int[] ROW = gridView_ALTMENU.GetSelectedRows();
            for (int i = 0; i < ROW.Length; i++)
            {
                DataRow row = gridView_ALTMENU.GetDataRow(ROW[i]);
                gridView_KULLANICI_ALTMENU.AddNewRow();
                gridView_KULLANICI_ALTMENU.RefreshData();
                DataRow rows = gridView_KULLANICI_ALTMENU.GetDataRow(gridView_KULLANICI_ALTMENU.RowCount - 1);

                rows["MAIL_ADRESI"] = lbKodu.Caption;
                rows["MENU_GROUP"] = row["MENU_GROUP"];
                rows["MENU_KODU"] = row["MENU_KODU"];
                rows["MENU_PARAMETRE"] = row["MENU_PARAMETRE"];
                rows["MENU_ADI"] = row["MENU_ADI"];
                rows["MENU_LINK"] = row["MENU_LINK"];
                rows["MENU_PICTURE"] = row["MENU_PICTURE"];
                rows["TIPI"] = row["TIPI"];
            }
        }

        private void GRD_KULLANICI_ANAMENU_LISTE_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = gridView_KULLANICI_ANAMENU.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));                    
            DataRow dr = gridView_KULLANICI_ANAMENU.GetDataRow(hi.RowHandle);
            if (dr != null)
            {
                _AnaMenuID = dr["MENU_KODU"].ToString();
                using (SqlConnection MySqlConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                {
                    SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(String.Format("  SELECT   * FROM  ADM_KULLANICI_MENU_LISTESI  WHERE  (MAIL_ADRESI =  '{0}' and MENU_GROUP='{1}')", dr["MAIL_ADRESI"], dr["MENU_KODU"]), MySqlConnection);
                    using (DataSet MyDataSet = new DataSet())
                    {
                        MySqlDataAdapter.Fill(MyDataSet, "dbo_USER");
                        DataViewManager dvManager = new DataViewManager(MyDataSet);
                        DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                        GRD_KULLANICI_ALTMENU_LISTE.DataSource = dv;
                    }
                } 
            }
        }

        private void cnt_M_AnaMenu_Sil_Click(object sender, EventArgs e)
        {

        }  
    }
}
 