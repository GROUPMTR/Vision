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
    public partial class MENU_HAKLARI : DevExpress.XtraEditors.XtraForm
    { int _FIRMAID;
        string _FirmaCode, _AnaMenuID, _AnaMenuAutoID, _AltMenuID;


  
      


        public MENU_HAKLARI()
        {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
                {
                    CMB_FIRMA_SELECT.Properties.Items.Add(myReader["SIRKET_KODU"].ToString());
                    CMB_FIRMA_NAME.Properties.Items.Add(myReader["SIRKET_KODU"].ToString());
                }
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
            grdCntrlUserView.ShowFindPanel();
       }
 
        private void MENU_LISTESI()
        {
       

            using (SqlConnection conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                DataSet ds = new DataSet();
                //string query = " SELECT ID ,PARENTID, BASLIK, SUB_IDX,NAME,GUI, SIRKET_KODU FROM   dbo.ADM_MENU where SIRKET_KODU=@SIRKET_KODU  order by PARENTID,SUB_IDX  ";
                string query = " SELECT ID ,PARENTID, BASLIK, SUB_IDX,NAME,GUI, SIRKET_KODU FROM   dbo.ADM_MENU  order by PARENTID,SUB_IDX  ";
                SqlDataAdapter adapter = new SqlDataAdapter() { SelectCommand = new SqlCommand(query, conn) };
               // adapter.SelectCommand.Parameters.AddWithValue("@SIRKET_KODU", CMB_FIRMA_SELECT.Text);
                adapter.Fill(ds, "ADM_MENU");
                DataViewManager dvManager = new DataViewManager(ds);
                DataView dvLIST_KIRILIMLAR = dvManager.CreateDataView(ds.Tables[0]);
                TreeView_Sabitler.BeginUpdate();
                TreeView_Sabitler.Nodes.Clear();
                PopulateTreeView(TreeView_Sabitler.Nodes, 0, ds.Tables[0]);
                TreeView_Sabitler.Select();
                TreeView_Sabitler.EndUpdate();
            }
            TreeView_Sabitler.ExpandAll();
             
         
        }


        protected void PopulateTreeView(TreeNodeCollection parentNodes, int parentID, DataTable table)
        {
            foreach (DataRow rows in table.Rows)
            {
                if (Convert.ToInt32(rows["PARENTID"]) == parentID)
                {
                    TreeNodeCollection newParentNode = parentNodes.Add(rows["ID"].ToString(), rows["BASLIK"].ToString()).Nodes;
                    foreach (TreeNode n in parentNodes)
                    {
                        if (n.Tag == null) { n.Tag = rows["GUI"]; }//MessageBox.Show(rows["GUI"].ToString()); 
                    }
                    PopulateTreeView(newParentNode, Convert.ToInt32(rows["ID"]), table);
                }
            }
        }  
        private void MENU_LISTESIM()
        {
       
        }

        private void ALT_MENU(string _MENU_KODU)
        {
         
        }

        private void KULLANICI_MENU_LISTESI(string _MAIL_ADRESI)
        { 
            string mySelectQuery = String.Format("SELECT SIRKET_KODU, MAIL_ADRESI, GUI FROM  dbo.ADM_KULLANICI_MENU WHERE   (SIRKET_KODU = N'{0}')AND (MAIL_ADRESI = N'{1}') ", CMB_FIRMA_SELECT.Text, _MAIL_ADRESI);
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {

                    TreeNodeCollection nodes = this.TreeView_Sabitler.Nodes;
                    foreach (TreeNode n in nodes)
                    {
                        GetNodeChek_TRUE(n, myReader["GUI"].ToString());
                    } 
                }
                myConnection.Close();
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

            MENU_LISTESI();
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
         
        }

        private void BR_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeNodeCollection nodes = TreeView_Sabitler.Nodes;
            foreach (TreeNode n in nodes)
            {
                Recursive(n);
            }

            MessageBox.Show("Kullanıcı hakları güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);  
        }


        private void Recursive(TreeNode treeNode)
        {

            SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
             myConnection.Open();

            if (treeNode.Checked)
            {   
                using (SqlCommand myCommand = new SqlCommand("SELECT SIRKET_KODU, MAIL_ADRESI, GUI FROM  dbo.ADM_KULLANICI_MENU WHERE  SIRKET_KODU=@SIRKET_KODU and MAIL_ADRESI=@MAIL_ADRESI and GUI=@GUI", myConnection))
                {
                    myCommand.Parameters.AddWithValue("@SIRKET_KODU", CMB_FIRMA_NAME.Text);
                    myCommand.Parameters.AddWithValue("@MAIL_ADRESI", lbKodu.Caption.ToString());
                    myCommand.Parameters.Add("@GUI", SqlDbType.UniqueIdentifier); myCommand.Parameters["@GUI"].Value = treeNode.Tag;
                    SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (!myReader.HasRows)
                    {
                        SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                        con.Open();
                        SqlCommand myCmd = new SqlCommand();
                        myCmd.CommandText = "INSERT INTO dbo.ADM_KULLANICI_MENU (SIRKET_KODU, MAIL_ADRESI, GUI) VALUES ( @SIRKET_KODU, @MAIL_ADRESI, @GUI)   ";
                        myCmd.Parameters.AddWithValue("@SIRKET_KODU", CMB_FIRMA_NAME.Text);
                        myCmd.Parameters.AddWithValue("@MAIL_ADRESI", lbKodu.Caption.ToString());
                        myCmd.Parameters.Add("@GUI", SqlDbType.UniqueIdentifier); myCmd.Parameters["@GUI"].Value = treeNode.Tag;
                        myCmd.Connection = con;
                        myCmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            myConnection.Close();

            //if (!treeNode.Checked)
            //{
            //    SqlCommand myCmd = new SqlCommand();
            //    myCmd.CommandText = "DELETE  dbo.ADM_KULLANICI_MENU  where  GUI=@GUI ";
            //    myCmd.Parameters.Add("@GUI", SqlDbType.UniqueIdentifier); myCmd.Parameters["@GUI"].Value = treeNode.Tag;
            //    myCmd.Connection = myConnection;
            //    myCmd.ExecuteNonQuery();
            //}
          
            foreach (TreeNode tn in treeNode.Nodes)
            {
                Recursive(tn);
            }
        } 
         
        private void MN_ANAMENU_EKLE_Click(object sender, EventArgs e)
        {
          
        }

        private void MN_ALTMENU_EKLE_Click(object sender, EventArgs e)
        {
             
        }

        private void GRD_KULLANICI_ANAMENU_LISTE_Click(object sender, EventArgs e)
        {
           
        }

        private void cnt_M_AnaMenu_Sil_Click(object sender, EventArgs e)
        {

        }


        private void GetNodeChek_TRUE(TreeNode treeNode, string selectNames)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Tag.ToString()  == selectNames)
                {
                    tn.Checked = true;
                }
                GetNodeChek_TRUE(tn, selectNames);
            }
        }
    }
}
 