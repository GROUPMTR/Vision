using System; 
using System.Data; 
using System.Windows.Forms; 
using System.Data.SqlClient; 
using System.DirectoryServices; 
namespace VISION
{
    public partial class LOGIN : DevExpress.XtraEditors.XtraForm
    {
        DataSet dtSt;
       public  string BTN_SELECT = "VAZGEC";
       SqlConnection sqlConn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB); 
        public LOGIN()
        {
            InitializeComponent();  
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent; 

            CHK_SIFREYI_GEC.Visible = false;
            CHK_SIFREYI_GEC.Checked = false; 

            CHK_ERP_USER.Visible = false;
            CHK_ERP_USER.Checked = false;

            sqlConn.Open();

            using (SqlDataAdapter sqlDt = new SqlDataAdapter("SELECT * from dbo.ADM_SIRKET where AKTIF='true'", sqlConn))
            { 
                dtSt = new DataSet();
                sqlDt.Fill(dtSt, "ADM_SIRKET");
                DataViewManager dvManager = new DataViewManager(dtSt);
                DataView PlndtBUDGETView = dvManager.CreateDataView(dtSt.Tables[0]); 
                gridLook_FIRMA_LIST.Properties.DataSource = PlndtBUDGETView;
                gridLook_FIRMA_LIST.Properties.DisplayMember = "SIRKET_KODU";
                gridLook_FIRMA_LIST.Properties.ValueMember = "SIRKET_KODU";  
                gridLook_FIRMA_LIST.EditValue = PlndtBUDGETView;
                gridLook_FIRMA_LIST.Properties.PopupFormWidth = 350;                  
           }

            using (SqlDataAdapter sqlDt = new SqlDataAdapter("SELECT * from dbo.ADM_KULLANICI order by MAIL_ADRESI", sqlConn))
            { 
           
                DataSet DtSet = new DataSet();
                sqlDt.Fill(DtSet, "dbo_ADM_KULLANICI");
                DataViewManager dvManager = new DataViewManager(DtSet);
                DataView PlndtBUDGETView = dvManager.CreateDataView(DtSet.Tables[0]);
                gridLook_KULLANICI_LIST.Properties.DataSource = PlndtBUDGETView;
                gridLook_KULLANICI_LIST.Properties.DisplayMember = "MAIL_ADRESI";
                gridLook_KULLANICI_LIST.Properties.ValueMember = "MAIL_ADRESI";
                gridLook_KULLANICI_LIST.EditValue = PlndtBUDGETView;
                gridLook_KULLANICI_LIST.Properties.PopupFormWidth = 350;
            }
            

            using (SqlDataAdapter sqlDt = new SqlDataAdapter("SELECT * from dbo.ADM_SIRKET_DONEMLERI", sqlConn))
            {  
                DataSet DtSet = new DataSet();
                sqlDt.Fill(DtSet, "ADM_SIRKET_DONEMLERI");
                DataViewManager dvManager = new DataViewManager(DtSet);
                DataView PlndtBUDGETView = dvManager.CreateDataView(DtSet.Tables[0]);
                gridLook_FIRMA_DONEMI.Properties.DataSource = PlndtBUDGETView;
                gridLook_FIRMA_DONEMI.Properties.DisplayMember = "LOGIN_NAME";
                gridLook_FIRMA_DONEMI.Properties.ValueMember = "LOGIN_NAME";
                gridLook_FIRMA_DONEMI.EditValue = PlndtBUDGETView;
                gridLook_FIRMA_DONEMI.Properties.PopupFormWidth = 350;
            }
            //string USEER_TEST = "Buket.arslan";
            //USEER_TEST = USEER_TEST.ToString().Replace("I", "i").Replace("İ", "i").ToLower().Replace("ı", "i").ToLower();
            //KULLANICI_SECIMI("KODU", USEER_TEST);
            ////KULLANICI_SECIMI("KODU", Environment.UserName.ToString().Replace("I", "i").Replace("İ", "i").ToLower().Replace("ı", "i").ToLower()); 


            string KULLANICI_ADI = Environment.UserName.ToString().Replace("I", "i").Replace("İ", "i").Replace("ı", "i").Replace(@"AD\", "").ToLower();
            KULLANICI_SECIMI("KODU", KULLANICI_ADI);

            if (_GLOBAL_PARAMETERS._ERP_USER)
            {
       
                //  _GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP = "Password=nabuKad_07;Persist Security Info=True;User ID=grm_sa;Initial Catalog=LOGODB;Data Source=10.219.168.92";
                _GLOBAL_PARAMETERS._DBONAME = "LOGODB";
                FINANS.UBL.IZIBIZ_CLASS.Config();
            }
        }

        private void gridLook_KULLANICI_LIST_EditValueChanged(object sender, EventArgs e)
        {
            _GLOBAL_PARAMETERS._KULLANICI_MAIL = gridLook_KULLANICI_LIST.EditValue.ToString();
            _GLOBAL_PARAMETERS._SIRKET_KODU = gridLook_FIRMA_LIST.EditValue.ToString();
            KULLANICI_SECIMI("MAIL", _GLOBAL_PARAMETERS._KULLANICI_MAIL);
         
        } 
        private void KULLANICI_SECIMI(string TIPI,string _KULLANICI) 
        {
            CHK_ERP_USER.Visible = false;
            CHK_ERP_USER.Checked = false;

            CHK_SIFREYI_GEC.Visible = false;
            CHK_SIFREYI_GEC.Checked = false; 

                
               gridLook_FIRMA_LIST.EditValueChanged -= new System.EventHandler(this.gridLook_FIRMA_LIST_EditValueChanged);
               gridLook_KULLANICI_LIST.EditValueChanged -= new System.EventHandler(this.gridLook_KULLANICI_LIST_EditValueChanged);
               gridLook_FIRMA_DONEMI.EditValueChanged -= new System.EventHandler(this.gridLook_FIRMA_DONEMI_EditValueChanged);
            
                   using (SqlCommand myCommands = new SqlCommand())
                   {
                       myCommands.Connection = sqlConn;
                       if (TIPI == "KODU")
                       {
                           myCommands.CommandText = " SELECT    top 1 *,  dbo.ADM_SIRKET.SIRKET_NO FROM  dbo.ADM_KULLANICI INNER JOIN dbo.ADM_SIRKET ON dbo.ADM_KULLANICI.SIRKET_KODU = dbo.ADM_SIRKET.SIRKET_KODU  where dbo.ADM_KULLANICI.AKTIF='True' and (dbo.ADM_KULLANICI.KODU=@KODU)";
                           myCommands.Parameters.AddWithValue("@KODU", _KULLANICI);
                       }
                       if (TIPI == "MAIL")
                       {
                           myCommands.CommandText = " SELECT    top 1 *,  dbo.ADM_SIRKET.SIRKET_NO FROM  dbo.ADM_KULLANICI INNER JOIN dbo.ADM_SIRKET ON dbo.ADM_KULLANICI.SIRKET_KODU = dbo.ADM_SIRKET.SIRKET_KODU  where dbo.ADM_KULLANICI.AKTIF='True' and (dbo.ADM_KULLANICI.MAIL_ADRESI=@MAIL_ADRESI)";
                           myCommands.Parameters.AddWithValue("@MAIL_ADRESI", _KULLANICI);
                       }
                       SqlDataReader rdr = myCommands.ExecuteReader();
                       while (rdr.Read())
                       {
                           _GLOBAL_PARAMETERS._KULLANICI_ADI_SOYADI = string.Format("{0}.{1}", rdr["ADI"], rdr["SOYADI"]);
                           _GLOBAL_PARAMETERS._SIRKET_NO = rdr["SIRKET_NO"].ToString();
                           _GLOBAL_PARAMETERS._SIRKET_KODU = rdr["SIRKET_KODU"].ToString();
                           _GLOBAL_PARAMETERS._KULLANICI_KODU = rdr["KODU"].ToString();
                           _GLOBAL_PARAMETERS._ERP_USER = (bool)rdr["ERP_USER"];
                           CHK_ERP_USER.Checked = (bool)rdr["ERP_USER"];
                           if ((bool)rdr["ERP_USER"]) CHK_ERP_USER.Visible = true;
                        //   _GLOBAL_PARAMETERS._FILE_PATH = rdr["FILE_PATH"].ToString();
                           _GLOBAL_PARAMETERS._KULLANICI_DEPARTMANI = rdr["DEPARTMANI"].ToString();
                           if (rdr["MUSTERI_KISITLAMASI"] != DBNull.Value) _GLOBAL_PARAMETERS._MUSTERI_KISITLAMASI = (bool)rdr["MUSTERI_KISITLAMASI"]; else _GLOBAL_PARAMETERS._MUSTERI_KISITLAMASI = true;
                           _GLOBAL_PARAMETERS._KULLANICI_MAIL = rdr["MAIL_ADRESI"].ToString();
                           _GLOBAL_PARAMETERS._KULLANICI_GRUBU = rdr["KULLANICI_GRUBU"].ToString();
                           _GLOBAL_PARAMETERS._TELEFON = rdr["TELEFON"].ToString();
                           _GLOBAL_PARAMETERS._FAKS = rdr["FAX"].ToString();
                           _GLOBAL_PARAMETERS._ADRES = rdr["ADRESI"].ToString();

                           gridLook_FIRMA_LIST.EditValue = _GLOBAL_PARAMETERS._SIRKET_KODU;
                           gridLook_KULLANICI_LIST.EditValue = _GLOBAL_PARAMETERS._KULLANICI_MAIL;
                       }
                       rdr.Close();
                } 
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * from dbo.ADM_SIRKET_DONEMLERI where SIRKET_KODU=@SIRKET_KODU ORDER BY ID DESC ", sqlConn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    DataSet DtSet = new DataSet();
                    da.Fill(DtSet, "ADM_SIRKET_DONEMLERI");
                    DataViewManager dvManager = new DataViewManager(DtSet);
                    DataView PlndtBUDGETView = dvManager.CreateDataView(DtSet.Tables[0]);
                    gridLook_FIRMA_DONEMI.Properties.DataSource = PlndtBUDGETView;
                    gridLook_FIRMA_DONEMI.Properties.DisplayMember = "LOGIN_NAME";
                    gridLook_FIRMA_DONEMI.Properties.ValueMember = "LOGIN_NAME";
                    gridLook_FIRMA_DONEMI.EditValue = PlndtBUDGETView;
                    gridLook_FIRMA_DONEMI.Properties.PopupFormWidth = 350;
                }
                using (SqlCommand myCommands = new SqlCommand())
                {
                    myCommands.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    myCommands.Connection = sqlConn;
                    myCommands.CommandText = "SELECT  *  from dbo.ADM_SIRKET_DONEMLERI where  SIRKET_KODU=@SIRKET_KODU AND DEFAULT_=1";
                    SqlDataReader sqlreaders = myCommands.ExecuteReader();
                    while (sqlreaders.Read())
                    {
                        gridLook_FIRMA_DONEMI.EditValue = sqlreaders["LOGIN_NAME"];
                        _GLOBAL_PARAMETERS._SIRKET_NO = sqlreaders["SIRKET_NO"].ToString();
                    }
                    sqlreaders.Close();
                }

                if (_GLOBAL_PARAMETERS._KULLANICI_GRUBU == "MASTER")
                {
                    CHK_SIFREYI_GEC.Visible = true ;
                }


                gridLook_KULLANICI_LIST.EditValueChanged += new System.EventHandler(this.gridLook_KULLANICI_LIST_EditValueChanged);
                gridLook_FIRMA_LIST.EditValueChanged += new System.EventHandler(this.gridLook_FIRMA_LIST_EditValueChanged);
                this.gridLook_FIRMA_DONEMI.EditValueChanged += new System.EventHandler(this.gridLook_FIRMA_DONEMI_EditValueChanged);
        }
   
        private DirectoryEntry GetDirectoryObject()
        {
            DirectoryEntry oDE;
            oDE = new DirectoryEntry("LDAP://ISTADCP01101", "" + _GLOBAL_PARAMETERS._KULLANICI_MAIL + "", "" + TxtBx_PASSWORD.Text + "", AuthenticationTypes.Secure);
           // oDE = new DirectoryEntry("LDAP://ISTADCP01101/OU=ist,OU=emea,DC=ad,DC=insidemedia,DC=net", "" + _GLOBAL_PARAMETERS._KULLANICI_MAIL + "", "" + TxtBx_PASSWORD.Text + "", AuthenticationTypes.Secure);
            return oDE;
        }

        private void bttn_TAMAM_Click(object sender, EventArgs e)
        {
            BTN_SELECT = "TAMAM";

            if (CHK_SIFREYI_GEC.Checked) { Close(); return; }
           
            if (CHK_ERP_USER.Checked)
            {
                ERP_LOGINS();
            }
            else
            {  
          
                if (TxtBx_PASSWORD.Text != "")
                {
                    _GLOBAL_PARAMETERS._KULLANICI_PASSWORD = TxtBx_PASSWORD.Text;



                    //using (SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                    //{
                    //    Conn.Open();
                    //    using (SqlCommand myCommand = new SqlCommand("SELECT  top 1 *  from dbo.ADM_KULLANICI  WHERE (KODU=@KODU) and AKTIF='True'  ", Conn))
                    //    {
                    //        myCommand.Parameters.AddWithValue("@KODU", _KULLANICI_ADI_SOYADI);
                    //        SqlDataReader sqlreaders = myCommand.ExecuteReader();
                    //        while (sqlreaders.Read())
                    //        {
                    //            _GLOBAL_PARAMETRELER._KULLANICI_ADI = sqlreaders["ADI"].ToString() + "." + sqlreaders["SOYADI"].ToString();
                    //            _GLOBAL_PARAMETRELER._KULLANICI_MAIL = sqlreaders["MAIL_ADRESI"].ToString();
                    //            _GLOBAL_PARAMETRELER._KULLANICI_REF = sqlreaders["ID"].ToString();
                    //            _GLOBAL_PARAMETRELER._SIRKET_KODU = sqlreaders["SIRKET_KODU"].ToString();
                    //            _GLOBAL_PARAMETRELER._TIMESHEET_USER = sqlreaders["TIMESHEET_KULLANICISI"].ToString();
                    //            _GLOBAL_PARAMETRELER._TIMESHEET_ADMIN = sqlreaders["TIMESHEET_ADMIN"].ToString();
                    //            _GLOBAL_PARAMETRELER._ISE_GIRIS_TARIHI = sqlreaders["ISE_GIRIS_TARIHI"].ToString();
                    //            _GLOBAL_PARAMETRELER._EGITIM_ALSIN = sqlreaders["EGITIM_ALSIN"].ToString();
                    //            _GLOBAL_PARAMETRELER._ABC_EGITIMI = sqlreaders["ABC_EGITIMI"].ToString();
                    //            _GLOBAL_PARAMETRELER._ISG_EGITIMI = sqlreaders["ISG_EGITIMI"].ToString();

                    //        }
                    //        sqlreaders.Close();
                    //    }
                    //}
                    //SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()); 
                    //SqlCommand myCommand = new SqlCommand("select *  from   dbo.ADM_KULLANICI   WHERE     (MAIL_ADRESI=@MAIL_ADRESI)", myConnection);
                    //myCommand.Parameters.AddWithValue("@MAIL_ADRESI", _GLOBAL_PARAMETERS._KULLANICI_MAIL); 
                    //myConnection.Open();
                    //SqlDataReader rdr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    //while (rdr.Read())
                    //{
                    //    Rowx = 1;
                    //    _GLOBAL_PARAMETERS._KULLANICI_GROUP = rdr["DEPARTMANI"].ToString();  
                    //    _GLOBAL_PARAMETERS._MUSTERI_KISITLAMASI = (bool)rdr["MUSTERI_KISITLAMASI"]; 


                    //// DirectoryEntry src = new DirectoryEntry("LDAP://ISTADCP01101", "" + TxtBx_KULLANICI.Text + "", "" + TxtBx_PASSWORD.Text + "", AuthenticationTypes.Secure);
                    //// DirectorySearcher ds = new DirectorySearcher(src);


                    ////// ds.Filter = "(|(&(objectclass=user)(objectcategory=person))(objectcategory=group))";//"(&(objectCategory=Group))"; 
                    //// ds.Filter = "(&(|(|(&(objectclass=user)(objectcategory=person))(objectcategory=group))(objectclass=contact))(!(extensionAttribute9=*)))";


                    //// ds.PropertiesToLoad.Add("cn");
                    //// ds.PropertiesToLoad.Add("sAMAccountName");


                    //// // Full Name
                    //// ds.PropertiesToLoad.Add("name");
                    //// // Email Address
                    //// ds.PropertiesToLoad.Add("mail");
                    //// // First Name
                    //// ds.PropertiesToLoad.Add("givenname");
                    //// // Last Name (Surname)
                    //// ds.PropertiesToLoad.Add("sn");
                    //// // Login Name
                    //// ds.PropertiesToLoad.Add("userPrincipalName");
                    //// // Distinguished Name
                    //// ds.PropertiesToLoad.Add("distinguishedName");



                    //// SearchResultCollection searchResultCollection = ds.FindAll();
                    //// string text2 = "";

                    //// foreach (SearchResult searchResult in searchResultCollection)
                    //// {

                    ////     if (searchResult.Properties["cn"].Count > 0 )///&& searchResult.Properties["sAMAccountName"].Count > 0
                    ////     {
                    ////         string text3 = text2;
                    ////         text2 = string.Concat(new string[]
                    ////       {
                    ////          text3, " ", searchResult.Properties["cn"][0].ToString(), " - ",
                    ////           searchResult.Properties["name"][0].ToString(), " - ",


                    ////          "<br />"
                    ////       });
                    ////     }
                    //// }   


                    //searchResult.Properties["mail"][0] .ToString(),, searchResult.Properties["sAMAccountName"][0].ToString()searchResult.Properties["givenname"][0].ToString(), " - ", searchResult.Properties["sn"][0].ToString(),
                    // searchResult.Properties["userPrincipalName"][0].ToString(), " - ", searchResult.Properties["distinguishedName"][0].ToString(),




                    //  string filter = "(&(ObjectClass=person)(OU=users,ou=ist,ou=emea,DC=ad,DC=insidemedia,DC=net))";


                    //DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://ISTADCP01101/OU=ist,OU=emea,DC=ad,DC=insidemedia,DC=net", "" + TxtBx_KULLANICI.Text + "", "" + TxtBx_PASSWORD.Text + "", AuthenticationTypes.Secure);

                    //DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry);
                    //directorySearcher.Filter = "(objectCategory=user)";
                    //foreach (SearchResult item in directorySearcher.FindAll())
                    //{
                    //    DirectoryEntry directoryEntryItem = item.GetDirectoryEntry();
                    //    var cn = directoryEntryItem.Properties["cn"].Value;
                    //    var aasAMAccountName = directoryEntryItem.Properties["sAMAccountName"].Value;
                    //    var name = directoryEntryItem.Properties["name"].Value;
                    //    var mail = directoryEntryItem.Properties["mail"].Value;
                    //    var userPrincipalName = directoryEntryItem.Properties["userPrincipalName"].Value;
                    //    var usergroup = directoryEntryItem.Properties["usergroup"].Value;
                    //    var Description = directoryEntryItem.Properties["Description"].Value;
                    //    var LastLogon = directoryEntryItem.Properties["LastLogon"].Value; 
                    //    var givenname = directoryEntryItem.Properties["givenname"].Value;
                    //    var sn = directoryEntryItem.Properties["sn"].Value;
                    //    var distinguishedName = directoryEntryItem.Properties["distinguishedName"].Value; 
                    //} 

                    DirectoryEntry de = GetDirectoryObject();
                    DirectorySearcher deSearch = new DirectorySearcher();
                    deSearch.SearchRoot = de;
                    deSearch.Filter = "(&(objectClass=user)(SAMAccountName=" + _GLOBAL_PARAMETERS._KULLANICI_KODU + "))";  //GLOBAL_PARAMETERS._KULLANICI_MAIL.ToLower() 
                    deSearch.PropertiesToLoad.Add("mail");
                    deSearch.PropertiesToLoad.Add("userPrincipalName");
                    SortOption Srt;
                    Srt = new SortOption("mail", System.DirectoryServices.SortDirection.Ascending);
                    deSearch.Sort = Srt;
                    //Sonuçları bir değişkene atalım.
                    try
                    {
                        SearchResultCollection Results = deSearch.FindAll();
                        if (Results != null)
                        {
                            foreach (SearchResult Result in Results)
                            {
                                ResultPropertyCollection Rpc = Result.Properties;
                                _GLOBAL_PARAMETERS._KULLANICI_MAIL = Rpc["userPrincipalName"][0].ToString();
                            }
                        }
                        Close(); 
                    }
                    catch (Exception EX) { MessageBox.Show(EX.Data.ToString()); }  //"Kullanıcı adı veya Password geçersiz."); }
                }
            } 
        }
        private void ERP_LOGINS()
        { 
            int _SIRKET_NO= Convert.ToInt16(_GLOBAL_PARAMETERS._SIRKET_NO.ToString());
            _GLOBAL_PARAMETERS._KULLANICI_PASSWORD= TxtBx_PASSWORD.Text;
          

           string girilenyazi = _GLOBAL_PARAMETERS._KULLANICI_KODU.Trim();
           string[] kelimeler;
           kelimeler = girilenyazi.Split('.');
           string sonuc = "";
           for (int i = 0; i <= kelimeler.Length - 1; i++)
           {
               string ilkharf = kelimeler[i].Substring(0, 1);
               string sonrakiharfler = kelimeler[i].Substring(1);
               string düzgün = ilkharf.ToUpper() + sonrakiharfler.ToLower();
               sonuc += düzgün + " ";
           }
         //  sonuc = sonuc.TrimEnd().Replace("İ","I").Replace(" ",".")  ;
           sonuc = sonuc.TrimEnd().Replace(" ", ".");

           if (_GLOBAL_PARAMETERS.Global.UnityApp.Login(sonuc, _GLOBAL_PARAMETERS._KULLANICI_PASSWORD, _SIRKET_NO, 1))
            {    
                Close();
            }
            else
            {
                switch (_GLOBAL_PARAMETERS.Global.UnityApp.GetLastError().ToString())
                {
                    case "-2":
                        MessageBox.Show("Veri Kullanıcı Adı girdiniz!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //  TxtBx_KULLANICI.SelectAll();
                        break;
                    case "-3":
                        MessageBox.Show("Yanlış Kullanıcı Adı girdiniz!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //   TxtBx_KULLANICI.SelectAll();
                        break;
                    case "-5":
                        MessageBox.Show("Yanlış Şifre girdiniz!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtBx_PASSWORD.SelectAll();
                        break;
                    case "-7":
                        MessageBox.Show("Yanlış Firma Numarası!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtBx_PASSWORD.SelectAll();
                        break;
                    case "-24":
                        MessageBox.Show("Yanlış Firma Numarası!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtBx_PASSWORD.SelectAll();
                        break;
                    default:
                        MessageBox.Show("Yanlış bir uygulama!!! Hata Kodu: " + _GLOBAL_PARAMETERS.Global.UnityApp.GetLastError().ToString() + " Hata Açıklaması : ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                 _GLOBAL_PARAMETERS.Global.UnityApp.Disconnect();
            }
        }

        private void bttn_VAZGEC_Click(object sender, EventArgs e)
        {
            BTN_SELECT = "VAZGEC";
            Close();
        }

        private void LOGIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BTN_SELECT == "VAZGEC") {System.Windows.Forms.Application.Exit(); }
        }

        private void gridLook_FIRMA_LIST_EditValueChanged(object sender, EventArgs e)
        {
                this.gridLook_FIRMA_DONEMI.EditValueChanged -= new System.EventHandler(this.gridLook_FIRMA_DONEMI_EditValueChanged);
          
               _GLOBAL_PARAMETERS._SIRKET_KODU = gridLook_FIRMA_LIST.EditValue.ToString();
               SqlConnection sqlCon = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
               using (SqlDataAdapter da = new SqlDataAdapter("SELECT * from dbo.ADM_SIRKET_DONEMLERI where SIRKET_KODU=@SIRKET_KODU ORDER BY ID DESC ", sqlCon))
               {
                    da.SelectCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    DataSet DtSet = new DataSet();
                    da.Fill(DtSet, "ADM_SIRKET_DONEMLERI");
                    DataViewManager dvManager = new DataViewManager(DtSet);
                    DataView PlndtBUDGETView = dvManager.CreateDataView(DtSet.Tables[0]);
                    gridLook_FIRMA_DONEMI.Properties.DataSource = PlndtBUDGETView;
                    gridLook_FIRMA_DONEMI.Properties.DisplayMember = "LOGIN_NAME";
                    gridLook_FIRMA_DONEMI.Properties.ValueMember = "LOGIN_NAME";
                    gridLook_FIRMA_DONEMI.EditValue = PlndtBUDGETView;
                    gridLook_FIRMA_DONEMI.Properties.PopupFormWidth = 350;
               }
                using (SqlCommand myCommands = new SqlCommand())
                {
                    myCommands.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    myCommands.Connection = sqlConn;
                    myCommands.CommandText = "SELECT  *  from dbo.ADM_SIRKET_DONEMLERI where  SIRKET_KODU=@SIRKET_KODU AND DEFAULT_=1";
                    SqlDataReader sqlreaders = myCommands.ExecuteReader();                
                    while (sqlreaders.Read())
                    {
                        gridLook_FIRMA_DONEMI.EditValue = sqlreaders["LOGIN_NAME"]; 
                        _GLOBAL_PARAMETERS._SIRKET_NO = sqlreaders["SIRKET_NO"].ToString(); 
                    }
                    sqlreaders.Close ();
                } 
                this.gridLook_FIRMA_DONEMI.EditValueChanged += new System.EventHandler(this.gridLook_FIRMA_DONEMI_EditValueChanged); 
         }

        private void gridLook_FIRMA_DONEMI_EditValueChanged(object sender, EventArgs e)
        { 
            using (SqlCommand myCommands = new SqlCommand())
            {
                myCommands.Parameters.AddWithValue("@SIRKET_KODU", gridLook_FIRMA_LIST.EditValue.ToString ());
                myCommands.Parameters.AddWithValue("@LOGIN_NAME", gridLook_FIRMA_DONEMI.EditValue.ToString());
                myCommands.Connection = sqlConn;
                myCommands.CommandText = "SELECT  *  from dbo.ADM_SIRKET_DONEMLERI where  SIRKET_KODU=@SIRKET_KODU AND LOGIN_NAME=@LOGIN_NAME";
                SqlDataReader sqlreaders = myCommands.ExecuteReader();
                while (sqlreaders.Read())
                { 
                    _GLOBAL_PARAMETERS._SIRKET_NO = sqlreaders["SIRKET_NO"].ToString();
                }
                sqlreaders.Close();
            } 
        } 
    }
}