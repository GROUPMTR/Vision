using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace VISION
{
    public partial class _MASTER : RibbonForm
    {
        int childCount = 0;
        private static string MYKEY = "456as4d6a73a2fghHJS4865a87932d(d4586qzxxiwopdGKQPGT712lsa4d4sadas8";
        public _MASTER()
        {
            InitializeComponent();

           _GLOBAL_PARAMETERS._KULLANICI_ADI_SOYADI = "";
           _GLOBAL_PARAMETERS._KULLANICI_DEPARTMANI = "";
           _GLOBAL_PARAMETERS._TOPLANTI_KISITLAMASI = false;
           _GLOBAL_PARAMETERS._MENU_KISITLAMASI = false;
           _GLOBAL_PARAMETERS._TRADING_ADMIN = false;
           _GLOBAL_PARAMETERS._ENVANTER_ADMIN = false;
           _GLOBAL_PARAMETERS._FILE_PATH = @"\\10.219.168.92\efatura$\";   
           _GLOBAL_PARAMETERS._KULLANICI_MAKINASI = Environment.MachineName.ToString();
           _GLOBAL_PARAMETERS._YEREL_PARA_BIRIMI = "TRL";

            _GLOBAL_PARAMETERS._SERVERNAME = "10.219.168.94";
            _GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB = "Password=tr1net784;Persist Security Info=True;User ID=login;Initial Catalog=VISION;Data Source=10.219.168.94";
            _GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP = "Password=nabuKad_07;Persist Security Info=True;User ID=grm_sa;Initial Catalog=LOGODB;Data Source=10.219.168.92";


            string palettesPath = @"c:\temp\_PRINT";
           try
           {
               if (!Directory.Exists(palettesPath))
               {
                   Directory.CreateDirectory(palettesPath);
               }
           }
           catch (Exception)
           {
               // Fail silently
           }
            //try
            //{
            //    string f = string.Format(@"{0}\VISIONSRVCNNT.DAT", Application.StartupPath);
            //    List<string> lines = new List<string>();
            //    using (StreamReader r = new StreamReader(f))
            //    {
            //        string line;
            //        while ((line = r.ReadLine()) != null)
            //        {
            //            lines.Add(line);
            //        }
            //    }
            //    //_GLOBAL_PARAMETERS._SERVERNAME = ".";//decrypt(lines[0].ToString());
            //    _GLOBAL_PARAMETERS._SERVERNAME = decrypt(lines[0].ToString());
            //    _GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB = string.Format("Password={0};Persist Security Info=True;User ID={1};Initial Catalog={2};Data Source={3}", decrypt(lines[3].ToString()), decrypt(lines[2].ToString()), decrypt(lines[1].ToString()), _GLOBAL_PARAMETERS._SERVERNAME);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Input was not valid. " + ex.Message);
            //}




            //_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB = "Password=tr1net784;Persist Security Info=True;User ID=login;Initial Catalog=VISION;Data Source=BLACKMAC"; 
            //_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP = "Password=nabuKad_07;Persist Security Info=True;User ID=grm_sa;Initial Catalog=LOGODB;Data Source=BLACKMAC";
   
            //    _GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB = "Password=tr1net784;Persist Security Info=True;User ID=login;Initial Catalog=VISION;Data Source=BLACKMAC";


            //_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB = System.Configuration.ConfigurationManager.ConnectionStrings["_CONNECTIONSTRING_MDB"].ToString();

            //NameValueCollection myParamsCollection = (NameValueCollection)ConfigurationManager.GetSection("Application_Parameters");
            //string palettesPath = @"" + myParamsCollection["User_Temp"];
            //_GLOBAL_PARAMETERS._FILE_PATH  = @""+myParamsCollection["Efatura_Path"];        
            //_GLOBAL_PARAMETERS._YEREL_PARA_BIRIMI = myParamsCollection["YEREL_PARA_BIRIMI"];


            // try
            // {
            //     if (!Directory.Exists(palettesPath))
            //     {
            //         Directory.CreateDirectory(palettesPath);
            //     }
            // }
            // catch (Exception)
            // {
            //     // Fail silently
            // }

            FORM_LOAD();
        }


        private void FORM_LOAD()
        {
            LOGIN _LOGIN = new LOGIN();
            _LOGIN.ShowDialog();

            if (_LOGIN.BTN_SELECT != "VAZGEC")
            {
                if (_GLOBAL_PARAMETERS._KULLANICI_GRUBU != "MASTER")
                {
                    BAR_USER_NAME.Caption = _GLOBAL_PARAMETERS._KULLANICI_MAIL;
                    BAR_SIRKET_KODU.Caption = _GLOBAL_PARAMETERS._SIRKET_KODU;
                    BAR_SERVER_NAME.Caption = _GLOBAL_PARAMETERS._SERVERNAME;  
                    for (int i = 0; i <= MASTER_RibbonCntrl.Items.Count - 1; i++)
                    {
                        MASTER_RibbonCntrl.Items[i].Enabled = false ;
                        MASTER_RibbonCntrl.Items[i].Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    } 
                    for (int i = 0; i <= MASTER_RibbonCntrl.Pages.Count - 1; i++)
                    {
                       
                        for (int X = 0; X <= MASTER_RibbonCntrl.Pages[i].Groups.Count - 1; X++)
                        {
                            MASTER_RibbonCntrl.Pages[i].Groups[X].Visible = false;
                        }
                        MASTER_RibbonCntrl.Pages[i].Visible = false;
                    } 
                    for (int i = 0; i <= MASTER_RibbonCntrl.PageCategories.Count - 1; i++)
                    {
                        for (int x = 0; x <= MASTER_RibbonCntrl.PageCategories[i].Pages.Count - 1; x++)
                        {
                            for (int xc = 0; xc <= MASTER_RibbonCntrl.PageCategories[i].Pages[x].Groups.Count - 1; xc++)
                            {
                                MASTER_RibbonCntrl.PageCategories[i].Pages[x].Groups[xc].Visible = false;
                            }

                            MASTER_RibbonCntrl.PageCategories[i].Pages[x].Visible = false;
                        }
                        MASTER_RibbonCntrl.PageCategories[i].Visible = false;
                    } 
                    BAR_USER_NAME.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    BAR_SIRKET_KODU.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    BAR_SERVER_NAME.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    BAR_DEVELOPER.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                    SqlConnection conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                    conn.Open();

                    using (SqlCommand myCommand = new SqlCommand("SELECT * from dbo.ADM_MENU WHERE   TIPI='BUTTON'", conn))
                    {

                      //  myCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {
                            while (myReader.Read())
                            {


                                for (int i = 0; i <= MASTER_RibbonCntrl.Items.Count - 1; i++)
                                {
                                    if (MASTER_RibbonCntrl.Items[i].Name == myReader["NAME"].ToString())
                                    {
                                        //MASTER_RibbonCntrl.Items[i].Enabled = true;
                                        //MASTER_RibbonCntrl.Items[i].Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                                        MASTER_RibbonCntrl.Items[i].Caption = myReader["BASLIK"].ToString();
                                        if (myReader["PARAMETRELER"] != DBNull.Value) MASTER_RibbonCntrl.Items[i].Tag = string.Format("{0}|{1}", myReader["LINK"], myReader["PARAMETRELER"]);
                                        else
                                            MASTER_RibbonCntrl.Items[i].Tag = string.Format("{0},{1}", myReader["LINK"], myReader["PARAMETRELER"]);

                                    }
                                }
                            } myReader.Close();
                        }
                    }
                    conn.Close(); 

                    TreeView TreeView_Sabitler = new TreeView();
                    using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                    {
                        DataSet ds = new DataSet();
                        string query = @" SELECT  dbo.ADM_MENU.ID, dbo.ADM_MENU.PARENTID, dbo.ADM_MENU.BASLIK, dbo.ADM_MENU.SUB_IDX, dbo.ADM_MENU.NAME, dbo.ADM_MENU.LINK, dbo.ADM_MENU.PARAMETRELER, 
                                        dbo.ADM_MENU.ZORUNLU, dbo.ADM_MENU.GUI, dbo.ADM_MENU.TIPI, dbo.ADM_MENU.SIRKET_KODU, dbo.ADM_KULLANICI_MENU.MAIL_ADRESI
                                        FROM  dbo.ADM_MENU INNER JOIN
                                              dbo.ADM_KULLANICI_MENU ON dbo.ADM_MENU.GUI = dbo.ADM_KULLANICI_MENU.GUI
                                        WHERE  (dbo.ADM_KULLANICI_MENU.MAIL_ADRESI = @MAIL_ADRESI)  AND (dbo.ADM_KULLANICI_MENU.SIRKET_KODU=@SIRKET_KODU)
                                        ORDER BY dbo.ADM_MENU.PARENTID, dbo.ADM_MENU.SUB_IDX ";
                        SqlDataAdapter adapter = new SqlDataAdapter() { SelectCommand = new SqlCommand(query, conn) };  
                        adapter.SelectCommand.Parameters.AddWithValue("@MAIL_ADRESI", _GLOBAL_PARAMETERS._KULLANICI_MAIL);
                        adapter.SelectCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU); 
                        adapter.Fill(ds, "ADM_MENU");
                        DataViewManager dvManager = new DataViewManager(ds);
                        DataView dvLIST_KIRILIMLAR = dvManager.CreateDataView(ds.Tables[0]);
                        TreeView_Sabitler.BeginUpdate();
                        TreeView_Sabitler.Nodes.Clear();
                        PopulateTreeView(TreeView_Sabitler.Nodes, 0, ds.Tables[0]);
                        TreeView_Sabitler.Select();
                        TreeView_Sabitler.EndUpdate();

                        if (_GLOBAL_PARAMETERS._KULLANICI_GRUBU != "MASTER")
                        {
                            if (TreeView_Sabitler.Nodes.Count == 0) MessageBox.Show("Programı kullanma yetkiniz yok menü hakları isteyiniz.");
                        }
                    } 
            }
            else
            {
                //_LOGIN.Close();
                _LOGIN.Dispose();
                //  Application.Restart ExitThread();  
                Application.Exit();
                //  return; 
                System.Windows.Forms.Application.Exit();
            } 
        }
        protected void PopulateTreeView(TreeNodeCollection parentNodes, int parentID, DataTable table)
        {
            foreach (DataRow rows in table.Rows)
            {
                if (Convert.ToInt32(rows["PARENTID"]) == parentID)
                { 
                    if (rows["TIPI"].ToString() == "PAGE")
                    {
                        if (MASTER_RibbonCntrl.Pages[rows["BASLIK"].ToString()] != null)
                        {
                            MASTER_RibbonCntrl.Pages[rows["BASLIK"].ToString()].Visible = true;
                        }
                    } 
                    if (rows["TIPI"].ToString() == "BUTTON")
                    {

                        for (int i = 0; i <= MASTER_RibbonCntrl.Items.Count - 1; i++)
                        {
                            if (MASTER_RibbonCntrl.Items[i].Name == rows["NAME"].ToString())
                            {
                                MASTER_RibbonCntrl.Items[i].Enabled = true;
                                MASTER_RibbonCntrl.Items[i].Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            }
                        }
                    }
                   
                    TreeNodeCollection newParentNode = parentNodes.Add(rows["NAME"].ToString(), rows["BASLIK"].ToString()).Nodes;
                    foreach (TreeNode n in parentNodes)
                    {

                        if (rows["TIPI"].ToString() == "PAGE_GROUP")
                        {
                            if (MASTER_RibbonCntrl.Pages[n.Parent.Text] != null)
                            {
                                if (MASTER_RibbonCntrl.Pages[n.Parent.Text].Groups[rows["NAME"].ToString()] != null) MASTER_RibbonCntrl.Pages[n.Parent.Text].Groups[rows["NAME"].ToString()].Visible = true;
                            }
                        } 
                        if (n.Tag == null) { n.Tag = rows["TIPI"]; }//MessageBox.Show(rows["GUI"].ToString()); 
                    }
                    PopulateTreeView(newParentNode, Convert.ToInt32(rows["ID"]), table);
                }
            }
        }  
        private static string encrypt(string value)
        {
            try
            {
                TripleDESCryptoServiceProvider objDESCrypto =
                    new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();
                byte[] byteHash, byteBuff;
                string strTempKey = MYKEY;
                byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objHashMD5 = null;
                objDESCrypto.Key = byteHash;
                objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB
                byteBuff = ASCIIEncoding.ASCII.GetBytes(value);
                return Convert.ToBase64String(objDESCrypto.CreateEncryptor().
                    TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            }
            catch (Exception ex)
            {
                return "Input was not valid. " + ex.Message;
            }
        } 
        private static string decrypt(string value)
        {
            try
            {
                TripleDESCryptoServiceProvider objDESCrypto =
                    new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();
                byte[] byteHash, byteBuff;
                string strTempKey = MYKEY;
                byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objHashMD5 = null;
                objDESCrypto.Key = byteHash;
                objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB
                byteBuff = Convert.FromBase64String(value);
                string strDecrypted = ASCIIEncoding.ASCII.GetString
                (objDESCrypto.CreateDecryptor().TransformFinalBlock
                (byteBuff, 0, byteBuff.Length));
                objDESCrypto = null;
                return strDecrypted;
            }
            catch (Exception ex)
            {
                return "Wrong Input. " + ex.Message;
            }
        }        

        private void MASTER_RibbonCntrl_ItemClick(object sender, ItemClickEventArgs e)
        {

            switch (e.Item.Name)
            {
                case "BTN_GIRIS_KAPAT":
                        Application.Exit(); 
                    break;

                case "BTN_GIRIS_KULLANCI_DEGISTIR":
                    _GLOBAL_PARAMETERS.Global.UnityApp.Disconnect();
                    FORM_LOAD();
                    break;

                default :

                    if (e.Item.Tag == null) break;
                      childCount++; 
                        int Kontrol = 1;
                        string[] Ones = e.Item.Tag.ToString().Split('|');
                       if (Ones.Length > 1) if ( Ones[1] != null && Ones[1] != "") Kontrol ++; 

                        if (Kontrol > 1) 
                        {
                            if (Ones[0] == "") return;
                            Type type = Type.GetType("VISION." + Ones[0].ToString());
                            object obj = Activator.CreateInstance(type, Ones[1].ToString());
                            if ((obj as Form).Tag != null) (obj as Form).MdiParent = this;
                            (obj as Form).StartPosition = FormStartPosition.CenterScreen;
                            (obj as Form).Text = e.Item.Caption + " (" + childCount.ToString() + ")";
                            (obj as Form).Show();
                        }
                        else
                        {  // VISION.FINANS.GIB.ALIS_FATURASI_LIST 
                            if (Ones[0] == "") return;
                            Type type = Type.GetType("VISION." + Ones[0].ToString() );
                            object obj = Activator.CreateInstance(type);
                            if ((obj as Form).Tag != null) (obj as Form).MdiParent = this;
                            (obj as Form).StartPosition = FormStartPosition.CenterScreen;
                            (obj as Form).Text = e.Item.Caption + " (" + childCount.ToString() + ")";
                            (obj as Form).Show();

                        } 
                    break; 
            }

 
                //if (e.Item.Name == "GIRIS_RADYAL_MENU")
                //{
                //    if (radialMenus.Visible)
                //    {
                //        radialMenus.Collapse(false);
                //    }
                //    else
                //    {
                //        Point pt = this.Location;
                //        pt.Offset(this.Width / 2, this.Height / 2);
                 
                //        radialMenus.ShowPopup(pt);//Cursor.Position
                //        radialMenus.Expand();
                //    }
                //}
                //else
                //{
                //    if (radialMenus.Visible)
                //    {
                //        radialMenus.Collapse(false);
                //    }
                    //try
                    //{
                       
                        //Form newForm = formMapping[e.Item.Name]();
                        //if (newForm.Tag != null)
                        //{
                        //    newForm.Text = e.Item.Caption + " (" + childCount.ToString()+")";
                        //    newForm.MdiParent = this;
                        //    newForm.StartPosition = FormStartPosition.CenterScreen;
                        //    newForm.Show();
                        //}
                        //else
                        //{
                        //    newForm.Text = e.Item.Caption + " (" + childCount.ToString() + ")";
                        //    newForm.StartPosition = FormStartPosition.CenterScreen;
                        //    newForm.ShowDialog();
                        //}
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.ToString());
                    //}
                //}
            
        }

        private void GIRIS_KAPAT_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void TITLE_CONTROL_MENU_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private void GIB_EDIT_ItemClick(object sender, ItemClickEventArgs e)
        {
            _LOCAL_ADMIN._TEMP.GIB_FIRMA_EDIT FR = new _LOCAL_ADMIN._TEMP.GIB_FIRMA_EDIT();

            FR.Text = e.Item.Caption + " (" + childCount.ToString() + ")";
            FR.MdiParent = this;
            FR.StartPosition = FormStartPosition.CenterScreen;
            FR.Show();
        }

        private void PLANLAMA_TELEVIZYON_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void PLANLAMA_P4_ItemClick(object sender, ItemClickEventArgs e)
        {
            //PLANLAMA.BUDGET.P4 P4 = new PLANLAMA.BUDGET.P4();            
            //P4.Text = e.Item.Caption + " (" + childCount.ToString() + ")";
            //P4.MdiParent = this;
            //P4.StartPosition = FormStartPosition.CenterScreen;
            //P4.Show();
        }

        private void PLANLAMA_BUDGET_ItemClick(object sender, ItemClickEventArgs e)
        {
            //    PLANLAMA.BUDGET.BUDGET_PLANI Ps = new PLANLAMA.BUDGET.BUDGET_PLANI();



            //Ps.Text = e.Item.Caption + " (" + childCount.ToString() + ")";
            //Ps.MdiParent = this;
            //Ps.StartPosition = FormStartPosition.CenterScreen;
            //Ps.Show();
        }

        private void BTN_GIRIS_TIME_SHEET_RAPOR_FAKE_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            //    TIMESHEET.TIME_SHEET_RAPORS P4 = new TIMESHEET.TIME_SHEET_RAPORS(); 
            //P4.Text = e.Item.Caption + " (" + childCount.ToString() + ")";
            //P4.MdiParent = this;
            //P4.StartPosition = FormStartPosition.CenterScreen;
            //P4.Show();



            TIMESHEET.TIME_SHEET_RAPOR_FK P4 = new TIMESHEET.TIME_SHEET_RAPOR_FK();  
            P4.Text = e.Item.Caption + " (" + childCount.ToString() + ")";
            P4.MdiParent = this;
            P4.StartPosition = FormStartPosition.CenterScreen;
            P4.Show();

        }

        private void BTN_FATURA_ALIS_FATURASI_GIRIS_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void BTN_FATURA_MUTABAKAT_MEKTUBU_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void BTN_FATURA_ERP_FATURA_ItemClick(object sender, ItemClickEventArgs e)
        {
 
        }

        private void PLANLAMA_PURCHASE_ORDER_LIST_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
