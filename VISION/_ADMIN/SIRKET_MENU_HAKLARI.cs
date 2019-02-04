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

namespace VISION._ADMIN
{
    public partial class SIRKET_MENU_HAKLARI : DevExpress.XtraEditors.XtraForm
    {
        public SIRKET_MENU_HAKLARI()
        {
            InitializeComponent();
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
   



        private void TreeView_Sabitler_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                DoDragDrop(e.Item, DragDropEffects.Move);  
        }

        private void TreeView_Sabitler_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move; 
        }

        private void BTN_EKLE_Click(object sender, EventArgs e)
        {
            if (CMB_FIRMA_SELECT.EditValue != null)
            {
                if (TXT_BASLIK.Text != "")
                {
                    TreeNode newNode = new TreeNode(TXT_BASLIK.Text);
                    TreeView_Sabitler.Nodes.Add(newNode);
                    KIRILIMLI_RAPOR_SAVE_UPDATA(TreeView_Sabitler);
                }
                MENU_LISTESI();
            }
            else { MessageBox.Show("Lütfen Firma seçiniz."); }
            TXT_BASLIK.Text = null;   
        }
        private void KIRILIMLI_RAPOR_SAVE_UPDATA(TreeView treeView)
        {
            // Print each node recursively.
            TreeNodeCollection nodes = treeView.Nodes;
            foreach (TreeNode n in nodes)
            {
                Recursive(n);
            }
        } 

        private void MENU_LISTESI()
        {


            using (SqlConnection conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                DataSet ds = new DataSet();
                string query = " SELECT ID ,PARENTID, BASLIK, SUB_IDX,NAME,GUI FROM   dbo.ADM_MENU    order by PARENTID,SUB_IDX  ";
                SqlDataAdapter adapter = new SqlDataAdapter() { SelectCommand = new SqlCommand(query, conn) };
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


        private void Recursive(TreeNode treeNode)
        {
            //MessageBox.Show(treeNode.Text +";"+ treeNode.Tag +";"+ treeNode.Index);  
            SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            myConnection.Open();
            if (treeNode.Tag == null)
            {
                SqlCommand myCmd = new SqlCommand();
                myCmd.CommandText = "INSERT INTO dbo.ADM_MENU(SIRKET_KODU, PARENTID,SUB_IDX,BASLIK) VALUES ( @SIRKET_KODU, @PARENTID,@SUB_IDX,@BASLIK)";
                myCmd.Parameters.Add("@SIRKET_KODU", SqlDbType.NVarChar); myCmd.Parameters["@SIRKET_KODU"].Value = CMB_FIRMA_SELECT.Text;
             
                if (treeNode.Parent != null)
                {
                    if (treeNode.Parent.Name != "" && treeNode.Parent.Name != null) { myCmd.Parameters.Add("@PARENTID", SqlDbType.Int); myCmd.Parameters["@PARENTID"].Value = treeNode.Parent.Name; }
                    else { myCmd.Parameters.Add("@PARENTID", SqlDbType.Int); myCmd.Parameters["@PARENTID"].Value = "0"; }
                }
                else
                { myCmd.Parameters.Add("@PARENTID", SqlDbType.Int); myCmd.Parameters["@PARENTID"].Value = "0"; }
                myCmd.Parameters.Add("@SUB_IDX", SqlDbType.NVarChar); myCmd.Parameters["@SUB_IDX"].Value = treeNode.Index;
                myCmd.Parameters.Add("@BASLIK", SqlDbType.NVarChar); myCmd.Parameters["@BASLIK"].Value = treeNode.Text;
                myCmd.Connection = myConnection;
                myCmd.ExecuteNonQuery();
            }
            if (treeNode.Tag != null)
            {
                SqlCommand myCmd = new SqlCommand();
                myCmd.CommandText = "UPDATE  dbo.ADM_MENU SET    PARENTID=@PARENTID,SUB_IDX=@SUB_IDX  where  GUI=@GUI ";
                if (treeNode.Parent != null)
                {
                    if (treeNode.Parent.Name != "" && treeNode.Parent.Name != null) { myCmd.Parameters.Add("@PARENTID", SqlDbType.Int); myCmd.Parameters["@PARENTID"].Value = treeNode.Parent.Name; }
                    else { myCmd.Parameters.Add("@PARENTID", SqlDbType.Int); myCmd.Parameters["@PARENTID"].Value = "0"; }
                }
                else
                { myCmd.Parameters.Add("@PARENTID", SqlDbType.Int); myCmd.Parameters["@PARENTID"].Value = "0"; }
                myCmd.Parameters.Add("@SUB_IDX", SqlDbType.NVarChar); myCmd.Parameters["@SUB_IDX"].Value = treeNode.Index;
                myCmd.Parameters.Add("@GUI", SqlDbType.UniqueIdentifier); myCmd.Parameters["@GUI"].Value = treeNode.Tag;
                myCmd.Connection = myConnection;
                myCmd.ExecuteNonQuery();
            }
            myConnection.Close();
            // Print each node recursively.
            foreach (TreeNode tn in treeNode.Nodes)
            {
                Recursive(tn);
            }
        }

        private void TreeView_Sabitler_DragDrop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt = TreeView_Sabitler.PointToClient(new Point(e.X, e.Y));
                TreeNode hedefDugum = TreeView_Sabitler.GetNodeAt(pt);
                TreeNode yeniDugum = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                if (hedefDugum != null)
                {
                    if (!hedefDugum.Equals(yeniDugum))
                    {
                        //Taşınan TreeNode kontrolü yeni yerine ekleniyor.
                        hedefDugum.Nodes.Add((TreeNode)yeniDugum.Clone());

                        hedefDugum.Expand();
                        //Taşınan TreeNode kontrolü eski yerinden siliniyor.
                        yeniDugum.Remove();
                    }
                }

                KIRILIMLI_RAPOR_SAVE_UPDATA(TreeView_Sabitler);
            }
        }

        private void TreeView_Sabitler_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            //Paint text of selected node in red color
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                e.Graphics.DrawString(e.Node.Text, e.Node.TreeView.Font, Brushes.Red, e.Bounds);
            }
            //Paint text of other nodes in default color
            else
            {
                e.DrawDefault = true;
            }
        }

    }
}