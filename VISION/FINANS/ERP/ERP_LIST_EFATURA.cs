using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services.Protocols;
using System.Xml.Xsl;
using System.Xml;
using System.Diagnostics;
using Ionic.Zip;
using DevExpress.XtraBars.Alerter;
using UnityObjects;
namespace VISION.FINANS.ERP
{
    public partial class ERP_LIST_EFATURA : DevExpress.XtraEditors.XtraForm
    {
        string _FATURA_TYPE;
        string appPath = _GLOBAL_PARAMETERS._FILE_PATH;  
        WebBrowser wbh = new WebBrowser();
        string RECEIVER_VKN, RECEIVER_ALIALS;
        DataRow Cfg = null;
        DataRow dr = null;
        AlertInfo info = new AlertInfo("Fatura İndirme Bilgisi", "");
        string xmlfl = "", xsltfl = "";


        bool Sonuc;
        string Mesaj = "";
        string SESSIONID = "";
        WebService.IziBizSrv.REQUEST_HEADERType htype { get; set; }
        WebService.IzibizSrvEFaturaArchive.REQUEST_HEADERType RequestHeader;
        WebService.IzibizSrvEFaturaArchive.INVOICE ıNVOICE { get; set; }




        public ERP_LIST_EFATURA(string FATURA_TYPE)
        {
            InitializeComponent(); 
            _FATURA_TYPE = FATURA_TYPE;
            this.Tag = "MDIFORM";

            BTM_FIRMA_KODU.Caption = _GLOBAL_PARAMETERS._SIRKET_NO;
            BTM_FIRMA_NAME.Caption = _GLOBAL_PARAMETERS._SIRKET_KODU;

            FINANS.UBL.IZIBIZ_CLASS.Config();
            Cfg = FINANS.UBL.IZIBIZ_CLASS.Cfg;
            DATA_LOAD();
        }


        private void DATA_LOAD()
        {
             
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString()))
            {
                _ERP_CLASS sql = new _ERP_CLASS();
                string INVOICE_TABLE_SQL = string.Format(sql.INVOICE_TABLE_SQL_EFATURA, _GLOBAL_PARAMETERS._DBONAME, _GLOBAL_PARAMETERS._SIRKET_NO.ToString(), "01");
                string INVOICE_TABLE_SQL_PRINT = string.Format(sql.INVOICE_TABLE_SQL_PRINT, _GLOBAL_PARAMETERS._DBONAME, _GLOBAL_PARAMETERS._SIRKET_NO.ToString(), "01");
            
                //create  sql commands
                SqlCommand cmd1 = myConnection.CreateCommand();

                cmd1.CommandText = INVOICE_TABLE_SQL + " AND (fat.TRCODE IN (" + _FATURA_TYPE + "))  UNION ALL "+ INVOICE_TABLE_SQL_PRINT + " AND (fat.TRCODE IN (" + _FATURA_TYPE + "))  ";
               

        //        cmd1.CommandText = INVOICE_TABLE_SQL + " AND (fat.TRCODE IN (" + _FATURA_TYPE + "))  ";   
                //define sql adapters
                SqlDataAdapter deMaster = new SqlDataAdapter(cmd1); 
                DataSet ds = new DataSet();
                deMaster.Fill(ds, "Header"); 
                ds.Relations.Clear(); 
                gridCntrl_LIST.DataSource = ds.Tables["Header"]; 
                gridCntrl_LIST.Refresh();
                gridCntrl_LIST.RefreshDataSource();
                myConnection.Close();
            } 
        }
 
        private void gridCntrl_LIST_Click(object sender, EventArgs e)
        {

            RECEIVER_VKN = null;
            RECEIVER_ALIALS = null;
            dr = gridView_LIST.GetFocusedDataRow();
            //e_master.SmartInv.UBL.LOGO_CreateXML createxml = new UBL.LOGO_CreateXML();
            //string FILE_NAME = createxml.Create(Cfg, dr, "_OUTBOX"); 
            if (dr != null)
            { 

                using (SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                { Conn.Open();

                    string SQLSELECT = @" select * from FTR_GIB_TRANSFER_DURUMU  where  SIRKET_KODU='" + _GLOBAL_PARAMETERS._SIRKET_KODU.ToString() + "' and  ID='" + dr["FICHENO"].ToString() + "' and GID='" + dr["GUID"].ToString() + "'";

                    SqlCommand myCommand = new SqlCommand(SQLSELECT, Conn); 
                   
                    SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    while (myReader.Read())
                    {
                        BR_BUG.Caption = myReader["MESAJ"].ToString();
                    }
                    myReader.Close();
                    myCommand.Connection.Close();
                }



        

                BR_SELECT_ROW_FATURA_NO.Caption = "";
                BR_SELECT_ROW_FATURA_NO.Caption = dr["FICHENO"].ToString();
                STLINE(BR_SELECT_ROW_FATURA_NO.Caption, dr["LOGICALREF"].ToString()); 
                HTML_VIEW();
            }
        }

        private void STLINE(string BR_SELECT_ROW_FATURA_NO, string ID)
        {
            if (BR_SELECT_ROW_FATURA_NO != "" && ID != "")
            {
                _ERP_CLASS sql = new _ERP_CLASS();
                string LINE_TABLE_SQL = string.Format(sql.LINE_TABLE_SQL, _GLOBAL_PARAMETERS._DBONAME, _GLOBAL_PARAMETERS._SIRKET_NO.ToString(), "01");
                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString()))
                {
                    SqlDataAdapter da = new SqlDataAdapter(LINE_TABLE_SQL + " AND (ln.INVOICEREF=" + ID + ")", myConnection);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "dbo_MecraList");
                    DataViewManager dvManager = new DataViewManager(ds);
                    DataView dv = dvManager.CreateDataView(ds.Tables[0]);
                    gridCntrl_LINE.DataSource = dv;
                    myConnection.Close();
                }
            }
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridCntrl_LIST_DoubleClick(object sender, EventArgs e)
        { 
        }
 
        private void HTML_VIEW()
        {
            string USERNAME = _GLOBAL_PARAMETERS._KULLANICI_ADI_SOYADI.Replace(".", "");
            if (File.Exists(@"c:\temp\_PRINT\" + USERNAME + "TMP.html")) File.Delete(@"c:\temp\_PRINT\" + USERNAME + "TMP.html"); 
            DataRow dr = gridView_LIST.GetFocusedDataRow();
            xmlfl = ""; xsltfl = "";
            if (dr != null)
            { 
                BR_FILE.Caption = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["FICHENO"] + ".xml";
                xmlfl = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["FICHENO"] + ".xml";
              //  xsltfl = appPath + @"_XSLT\1.xslt";
           //     xsltfl = appPath + @"_XSLT\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";


                if (dr["FATURANIN_TURU"].ToString() == "e-arşiv")
                {
                    xsltfl = appPath + @"_XSLT\EARSIVE\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";
                }
                if (dr["FATURANIN_TURU"].ToString() == "e-fatura")
                {
                    xsltfl = appPath + @"_XSLT\EFATURA\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";
                }


                if (!File.Exists(xmlfl))
                {
                    UBL.ERP_CREATE_XML createxml = new UBL.ERP_CREATE_XML();
                    //e_master.SmartInv.UBL.LOGO_CreateXML createxml = new UBL.LOGO_CreateXML();
                    xmlfl = createxml.Create(_GLOBAL_PARAMETERS._SIRKET_KODU, Cfg, dr, "_OUTBOX", dr["FATURANIN_TURU"].ToString());
                }
                 
      
                    wbh = null;
                    wbh = new WebBrowser(); 
                    XslCompiledTransform XSLT = new XslCompiledTransform();
                    XsltSettings settings = new XsltSettings();
                    settings.EnableScript = true;
                    try
                    {
                        XSLT.Load(xsltfl, settings, new XmlUrlResolver());
                        XSLT.Transform(xmlfl, @"c:\temp\_PRINT\" + USERNAME + "TMP.html");
                    }
                    catch
                    {
                        MessageBox.Show("Netwok Erşim Hatası");
                    }
                  
                    //UBL_VIEWER vv = new UBL_VIEWER();
                    String appdir = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                    String myfile = Path.Combine(appdir, @"c:\temp\_PRINT\" + USERNAME + "TMP.html");
                    wbh.Url = new Uri("file:///" + myfile);
                    Show();
                    wbh.ScrollBarsEnabled = true;
                    wbh.ScriptErrorsSuppressed = true;
                    // wbh.Document.Body.Style = "zoom:75%;";
                    // wbh.Document.Body.Style += ";zoom:" + 75;  
                    pnlControl_INVVIEW.Controls.Add(wbh);
                    wbh.Dock = DockStyle.Fill;
                    wbh.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wbh_DocumentCompleted);
                    wbh.Refresh();
                    //  wbh.Document.Body.Style += ";zoom:95%;"; 
                    wbh.BringToFront();

            }
        }

        private void wbh_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            wbh.Document.Body.Style = "zoom:80%;";
            wbh.Refresh();
        }

        private void BTN_EXCEL_EXPORT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = ".xlsx (*.xlsx)|*.xlsx";
            sfd.FileName = "EXPORT_FATURA.xlsx";
            DialogResult res = sfd.ShowDialog();
            if (res == DialogResult.OK)
            {
                gridView_LIST.ExportToXlsx(sfd.FileName);
            }
        }

        private void BTN_PDF_SAVE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FolderBrowserDialog brwsr = new FolderBrowserDialog();
            if (brwsr.ShowDialog() == DialogResult.Cancel)
                return;
            else
            {

                int[] selectedRows = gridView_LIST.GetSelectedRows();
                for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
                {
                    string USERNAME = _GLOBAL_PARAMETERS._KULLANICI_ADI_SOYADI.Replace(".", "");
                    DataRow dr = gridView_LIST.GetDataRow(selectedRows[ix]);
                    pnlControl_INVVIEW.Controls.Clear();
                    string xmlfl = "", xsltfl = "";

                    if (dr != null)
                    {
                        BR_FILE.Caption = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["FICHENO"] + ".xml";
                        xmlfl = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["FICHENO"] + ".xml";


                        if (dr["FATURANIN_TURU"].ToString() == "e-arşiv")
                        {
                            xsltfl = appPath + @"_XSLT\EARSIVE\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";
                        }
                        if (dr["FATURANIN_TURU"].ToString() == "e-fatura")
                        {
                            xsltfl = appPath + @"_XSLT\EFATURA\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";
                        }


                      //  xsltfl = appPath + @"_XSLT\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";/// +dr["FICHENO"] + "_" + dr["GUID"] + ".xslt";
                    }

                    //if (File.Exists(xmlfl)) File.Delete(xmlfl);

                    if (!File.Exists(xmlfl))
                    {
                        UBL.ERP_CREATE_XML createxml = new UBL.ERP_CREATE_XML();
                        string FILE_NAME = createxml.Create(_GLOBAL_PARAMETERS._SIRKET_KODU, Cfg, dr, "_OUTBOX", dr["FATURANIN_TURU"].ToString ());
                    }


                    if (xsltfl != "")
                    {
                        if (File.Exists(xmlfl))
                        {
                            if (xsltfl != "")
                            {
                                if (File.Exists(xmlfl))
                                {

                                    wbh = null;
                                    wbh = new WebBrowser();
                                    System.Threading.Thread.Sleep(100);
                                    if (File.Exists(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html")) File.Delete(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html");
                                    XslCompiledTransform XSLT = new XslCompiledTransform();
                                    XsltSettings settings = new XsltSettings();
                                    settings.EnableScript = true;
                                    XSLT.Load(xsltfl, settings, new XmlUrlResolver());
                                    XSLT.Transform(xmlfl, @"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html");
                                    //String appdir = Path.GetDirectoryName(Application.ExecutablePath);
                                    //String myfile = Path.Combine(appdir, appPath + @"_PRINT\" + ix + USERNAME + "TMP.html");
                                    //WaitPrint vv = new WaitPrint(myfile, ix);
                                    //vv.ShowDialog();
                                    //vv.Dispose(); 



                                    WKHtmlToPdf(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html", brwsr.SelectedPath, dr["FICHENO"] + ".pdf");
                                }
                                else
                                {
                                    MessageBox.Show("xml file erişilemedi.");
                                }
                            }
                        }
                    }
                }
                MessageBox.Show(selectedRows.Length + " Adet Dosya Kaydedildi");
            }

        }
        string FILE_NAME_ADRESS = "";
        private void BTN_PDF_MAIL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            FILE_NAME_ADRESS = "";

            int[] selectedRows = gridView_LIST.GetSelectedRows();
            for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
            {
                string USERNAME = _GLOBAL_PARAMETERS._KULLANICI_ADI_SOYADI.Replace(".", "");
                DataRow dr = gridView_LIST.GetDataRow(selectedRows[ix]);
                pnlControl_INVVIEW.Controls.Clear();
                string xmlfl = "", xsltfl = "";

                if (dr != null)
                {
                    BR_FILE.Caption = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["FICHENO"] + ".xml";
                    xmlfl = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["FICHENO"] + ".xml";
                //    xsltfl = appPath + @"_XSLT\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";/// +dr["FICHENO"] + "_" + dr["GUID"] + ".xslt";  



                    if (dr["FATURANIN_TURU"].ToString() == "e-arşiv")
                    {
                        xsltfl = appPath + @"_XSLT\EARSIVE\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";
                    }
                    if (dr["FATURANIN_TURU"].ToString() == "e-fatura")
                    {
                        xsltfl = appPath + @"_XSLT\EFATURA\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";
                    }


                    if (!File.Exists(xmlfl))
                    {
                        UBL.ERP_CREATE_XML createxml = new UBL.ERP_CREATE_XML();
                        string FILE_NAME = createxml.Create(_GLOBAL_PARAMETERS._SIRKET_KODU, Cfg, dr, "_OUTBOX",dr["FATURANIN_TURU"].ToString());
                    } 
                    if (xsltfl != "")
                    {
                        if (File.Exists(xmlfl))
                        {
                            if (xsltfl != "")
                            {
                                if (File.Exists(xmlfl))
                                {

                                    wbh = null;
                                    wbh = new WebBrowser();
                                    System.Threading.Thread.Sleep(10);
                                    if (File.Exists(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html")) File.Delete(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html"); 
                                    XslCompiledTransform XSLT = new XslCompiledTransform();
                                    XsltSettings settings = new XsltSettings();
                                    settings.EnableScript = true;
                                    XSLT.Load(xsltfl, settings, new XmlUrlResolver());
                                    XSLT.Transform(xmlfl, @"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html");
                                    WKHtmlToPdf(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html", @"c:\temp\_PRINT\", dr["FICHENO"] + ".pdf");
                                    string sFile = @"c:\temp\_PRINT\" + dr["FICHENO"] + ".pdf";
                                    FileStream objfilestream = new FileStream(sFile, FileMode.Open, FileAccess.Read);
                                    int len = (int)objfilestream.Length;
                                    Byte[] mybytearray = new Byte[len];
                                    objfilestream.Read(mybytearray, 0, len);
                                    WebServices.SALES_INVOICES savedocument = new WebServices.SALES_INVOICES();
                                    savedocument.SaveDocument(mybytearray, sFile.Remove(0, sFile.LastIndexOf("\\") + 1));
                                    objfilestream.Close();
                                    FILE_NAME_ADRESS += (dr["FICHENO"] + ".pdf") + ";"; 
                                }
                                else
                                {
                                    MessageBox.Show("xml file erişilemedi.");
                                }
                            }
                        }
                    }
                }
            }

            MAIL_TO_SEND snd = new MAIL_TO_SEND();
            snd.ShowDialog();
            if (snd._Button != "CANCEL")
            {
                WebServices.SALES_INVOICES fr = new WebServices.SALES_INVOICES();
                fr.SendMailAsync("noreply." + _GLOBAL_PARAMETERS._SIRKET_KODU + "@groupm.com", snd.to.ToString(), snd.subject.ToString(), snd.aciklama.ToString(), FILE_NAME_ADRESS);
                fr.SendMailCompleted += fr_SendMailCompleted;
            }

        }

        private void fr_SendMailCompleted(object sender, WebServices.SendMailCompletedEventArgs e)
        {
            System.Threading.Thread.Sleep(700);
            WebServices.SALES_INVOICES fr = new WebServices.SALES_INVOICES();
            fr.DeleteDocumentAsync(FILE_NAME_ADRESS);
            fr.DeleteDocumentCompleted += fr_DeleteDocumentCompleted;
        }

        private void fr_DeleteDocumentCompleted(object sender, WebServices.DeleteDocumentCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void BTN_GORUNTULE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RECEIVER_VKN = null;
            RECEIVER_ALIALS = null;
            dr = gridView_LIST.GetFocusedDataRow();
            //e_master.SmartInv.UBL.LOGO_CreateXML createxml = new UBL.LOGO_CreateXML();
            //string FILE_NAME = createxml.Create(Cfg, dr, "_OUTBOX");

            HTML_VIEW();
        }

        private void BTN_REFRESH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DATA_LOAD();
        }


        private WebService.IzibizSrvEFaturaArchive.EFaturaArchive ArchiveClient = new WebService.IzibizSrvEFaturaArchive.EFaturaArchive(); 

        //private WebService. ArchiveClient = new EArsivWS_Izibiz.EFaturaArchivePortClient(); 
        //private EArsivWS_Izibiz.EFaturaArchivePortClient ArchiveClient = new EArsivWS_Izibiz.EFaturaArchivePortClient(); 

        private void BTN_AKTARIM_BASLA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        { 
            // 
            //
            // EFATURA AKTARIM KODU 
            //  
            int[] selectedRows = gridView_LIST.GetSelectedRows();  
            for (int iz = 0; iz <= selectedRows.Length - 1; iz++)
            {
                dr = gridView_LIST.GetDataRow(selectedRows[iz]); 
                /// 
                /// E Fatura
                /// 
                if (dr["FATURANIN_TURU"].ToString()  == "e-fatura")
                {  
                    if (FINANS.UBL.IZIBIZ_CLASS.SESSIONID == "" || FINANS.UBL.IZIBIZ_CLASS.SESSIONID == null) FINANS.UBL.IZIBIZ_CLASS.izibiz_login();
                    if (FINANS.UBL.IZIBIZ_CLASS.SESSIONID != "")
                    {
                        //  int[] selectedRows = gridView_LIST.GetSelectedRows(); 
                        for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
                        {
                            dr = gridView_LIST.GetDataRow(selectedRows[ix]);
                            //string FATURA_DURUMU = "YOK";    EDA 29-09-2015- saat 15:06 kontrol kaldır dedi.   
                            //using (SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                            //{
                            //    string SQL = " SELECT   * FROM   dbo.FTR_GIB_TRANSFER_DURUMU where   ID=@ID   ";
                            //    SqlCommand myCommand = new SqlCommand(SQL, Conn);
                            //    myCommand.Parameters.AddWithValue("@ID", dr["FICHENO"]);
                            //    myCommand.CommandText = SQL.ToString();
                            //    Conn.Open();
                            //    SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                            //    while (myReader.Read())
                            //    {
                            //        FATURA_DURUMU = "VAR";
                            //    }
                            //    myReader.Close();
                            //    myCommand.Connection.Close();
                            //} 
                            //if (FATURA_DURUMU == "YOK")
                            //{ 
                            htype = new WebService.IziBizSrv.REQUEST_HEADERType();
                            htype.CHANNEL_NAME = VISION.FINANS.UBL.IZIBIZ_CLASS.Cfg["ENTCHANNEL_NAME"].ToString();
                            htype.REASON = VISION.FINANS.UBL.IZIBIZ_CLASS.Cfg["ENTREASON"].ToString();
                            htype.HOSTNAME = System.Environment.MachineName;
                            htype.APPLICATION_NAME = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                            htype.SESSION_ID = VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID;

                            WebService.IziBizSrv.LoginRequest lcont = new WebService.IziBizSrv.LoginRequest();
                            lcont.REQUEST_HEADER = htype;
                            lcont.USER_NAME = VISION.FINANS.UBL.IZIBIZ_CLASS.Cfg["ENTUSERNAME"].ToString();//"goknil1";
                            lcont.PASSWORD = VISION.FINANS.UBL.IZIBIZ_CLASS.Cfg["ENTPASS"].ToString();//"123456";  

                            siCnt = new WebService.IziBizSrv.SendInvoiceRequest();
                            siCnt.SENDER = new WebService.IziBizSrv.SendInvoiceRequestSENDER();
                            siCnt.SENDER.alias = VISION.FINANS.UBL.IZIBIZ_CLASS.Cfg["ElectronicMail"].ToString(); //"urn:mail:goknil1gb@izibiz-goknil.com.tr";// Cfg["ElectronicMail"].ToString ();
                            siCnt.SENDER.vkn = VISION.FINANS.UBL.IZIBIZ_CLASS.Cfg["VKN"].ToString();// "1234567808";// Cfg["VKN"].ToString();
                            siCnt.REQUEST_HEADER = htype;
                            htype.COMPRESSED = "Y";
                            siCnt.INVOICE = new WebService.IziBizSrv.INVOICE[selectedRows.Length];    //prm.SendListInv.Count  

                            siCnt.RECEIVER = new WebService.IziBizSrv.SendInvoiceRequestRECEIVER();
                            RECEIVER_VKN = dr["TAXNR"].ToString();
                            RECEIVER_ALIALS = dr["POSTLABELCODE"].ToString(); 

                            UBL.ERP_CREATE_XML createxml = new UBL.ERP_CREATE_XML();
                            string FILE_NAME = createxml.Create(_GLOBAL_PARAMETERS._SIRKET_KODU, Cfg, dr, "_OUTBOX",dr["FATURANIN_TURU"].ToString()); 

                            string pk_durumu = "YOK";
                            using (SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                            {
                                string SQL = " SELECT   * FROM   dbo.FTR_GIB_FIRMA_LISTESI where   IDENTIFIER=@IDENTIFIER   ";
                                SqlCommand myCommand = new SqlCommand(SQL, Conn);
                                myCommand.Parameters.AddWithValue("@IDENTIFIER", dr["TAXNR"]);
                                myCommand.CommandText = SQL.ToString();
                                Conn.Open();
                                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                                while (myReader.Read())
                                {
                                    int pk = myReader["ALIAS"].ToString().IndexOf("pk@");
                                    if (pk > 0)
                                    {
                                        RECEIVER_VKN = myReader["IDENTIFIER"].ToString();
                                        RECEIVER_ALIALS = myReader["ALIAS"].ToString();
                                        pk_durumu = "VAR";
                                    }
                                }
                                myReader.Close();
                                myCommand.Connection.Close();
                            }
                            // ALIALS = CMB_PK.Text;

                            if (pk_durumu == "YOK")
                            {
                                POSTA_KUTUSU pk = new POSTA_KUTUSU(dr["POSTLABELCODE"].ToString());
                                pk.VKN = RECEIVER_VKN;
                                pk.ALIALS = RECEIVER_ALIALS;
                                pk.ShowDialog();
                                RECEIVER_VKN = pk.VKN;
                                RECEIVER_ALIALS = pk.ALIALS;
                            }
                            //createxml.UUID 
                            siCnt.RECEIVER.alias = RECEIVER_ALIALS;
                            siCnt.RECEIVER.vkn = RECEIVER_VKN; 

                            SendInv(FILE_NAME, dr, ix);
                            WebService.IziBizSrv.SendInvoiceResponse returnTyp = I2IEInv.SendInvoice(siCnt); 
                            int j = ix; 
                            if (returnTyp == null || returnTyp.REQUEST_RETURN == null || returnTyp.REQUEST_RETURN.INTL_TXN_ID < 1)
                            { throw new Exception("Gönderilen ID alınamadı result GIB.."); }
                            else
                            {
                                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                                {
                                    using (SqlCommand myCommand = new SqlCommand())
                                    {
                                        myCommand.Parameters.AddWithValue("@ERP_AKTARILDI", 1);
                                        myCommand.Parameters.AddWithValue("@SESSIONID", htype.SESSION_ID);
                                        myCommand.Parameters.AddWithValue("@INVID", dr["LOGICALREF"]);
                                        myCommand.Parameters.AddWithValue("@FILE", FILE_NAME);
                                        myCommand.Parameters.AddWithValue("@GID", siCnt.INVOICE[j].UUID);
                                        myCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                                        myCommand.Parameters.AddWithValue("@Tarih", dr["DATE_"]);
                                        myCommand.Parameters.AddWithValue("@ID", siCnt.INVOICE[j].ID);
                                        myCommand.Parameters.AddWithValue("@FRM", _GLOBAL_PARAMETERS._SIRKET_NO);
                                        myCommand.Parameters.AddWithValue("@VKN", dr["TAXNR"].ToString());
                                        myCommand.Parameters.AddWithValue("@SICILNO", dr["SPECODE"].ToString());
                                        myCommand.Parameters.AddWithValue("@MUSTERI", dr["DEFINITION_"].ToString());
                                        myCommand.Parameters.AddWithValue("@ACIKLAMA", dr["GENEXP1"].ToString());
                                        myCommand.Parameters.AddWithValue("@FATURATARIH", dr["DATE_"]);
                                        myCommand.Parameters.AddWithValue("@PROFILID", dr["TRCODE_"].ToString());
                                        myCommand.Parameters.AddWithValue("@TIP", dr["GRPCODE_"].ToString());

                                        float NETTOTAL = float.Parse(dr["GROSSTOTAL"].ToString(), System.Globalization.CultureInfo.CurrentCulture);//CreateSpecificCulture("en-US")
                                        float TOTALVAT = float.Parse(dr["TOTALVAT"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
                                        float TOTALDISCOUNTS = float.Parse(dr["TOTALDISCOUNTS"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
                                        float GENELTOPLAM = float.Parse(dr["NETTOTAL"].ToString(), System.Globalization.CultureInfo.CurrentCulture);

                                        myCommand.Parameters.AddWithValue("@TOPLAMTUTAR", NETTOTAL);
                                        myCommand.Parameters.AddWithValue("@HESAPLANANKDV", TOTALVAT);
                                        myCommand.Parameters.AddWithValue("@TOPLAMINDIRIM", TOTALDISCOUNTS);
                                        myCommand.Parameters.AddWithValue("@GENELTOPLAM", GENELTOPLAM);
                                        myCommand.Parameters.AddWithValue("@FATURA_TIPI", 'E');

                                        myCommand.Connection = myConnection;
                                        myCommand.CommandText = " INSERT INTO  dbo.FTR_GIB_TRANSFER (ERP_AKTARILDI,SESSIONID,INVID,[FILE],GID,SIRKET_KODU,Tarih,ID,FRM,VKN,SICILNO,MUSTERI,ACIKLAMA,FATURATARIH,PROFILID,TIP,TOPLAMTUTAR,HESAPLANANKDV,TOPLAMINDIRIM,GENELTOPLAM,FATURA_TIPI,GUID)  VALUES  (@ERP_AKTARILDI,@SESSIONID,@INVID,@FILE,@GID,@SIRKET_KODU,@Tarih,@ID,@FRM,@VKN,@SICILNO,@MUSTERI,@ACIKLAMA,@FATURATARIH,@PROFILID,@TIP,@TOPLAMTUTAR,@HESAPLANANKDV,@TOPLAMINDIRIM,@GENELTOPLAM,@FATURA_TIPI,NEWID())";
                                        myConnection.Open();
                                        myCommand.ExecuteNonQuery();
                                        myCommand.Connection.Close();
                                    }
                                }
                                _FATURA_DURUM_UPDATE(siCnt.INVOICE[j].ID.ToString(), dr["FATURANIN_TURU"].ToString());
                                GIB_DURUM_KONTROL(dr);

                                //if (VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID == "" || VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID == null) VISION.FINANS.UBL.IZIBIZ_CLASS.izibiz_login();
                                //if (VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID != "")
                                //{
                                //    VISION.FINANS.UBL.IZIBIZ_CLASS.Config();
                                //    int[] selectedRows = gridView_LIST.GetSelectedRows();
                                //    for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
                                //    {
                                //DataRow dr = gridView_LIST.GetDataRow(selectedRows[ix]);
                                //if (dr == null) break;
                                //    }
                                //}
                                //DATA_LOAD();
                            }
                            //}
                            //else
                            //{
                            //    MessageBox.Show(dr["FICHENO"] + " Nolu farua daha önceden gönderilmiş. ");
                            //}
                            // Show a sample alert window. 
                            // info.Text += "Son İndirme : " + DateTime.Now.ToShortTimeString() + Environment.NewLine;

                            info.Text += "Gönderilen Fatura Sayısı : " + selectedRows.Length + Environment.NewLine;
                            alertControls.Show(this, info);
                        }
                    } 
                }  

                /// 
                /// E Arşiv
                ///

                if (dr["FATURANIN_TURU"].ToString() == "e-arşiv")
                { 
                    if (FINANS.UBL.IZIBIZ_CLASS.SESSIONID == "" || FINANS.UBL.IZIBIZ_CLASS.SESSIONID == null) FINANS.UBL.IZIBIZ_CLASS.izibiz_login();
                    if (FINANS.UBL.IZIBIZ_CLASS.SESSIONID != "")
                    {
                        RequestHeader = new WebService.IzibizSrvEFaturaArchive.REQUEST_HEADERType();
                        RequestHeader.CLIENT_TXN_ID = System.Guid.NewGuid().ToString();
                        RequestHeader.APPLICATION_NAME = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                        RequestHeader.CHANNEL_NAME = VISION.FINANS.UBL.IZIBIZ_CLASS.Cfg["ENTCHANNEL_NAME"].ToString();
                        RequestHeader.REASON = VISION.FINANS.UBL.IZIBIZ_CLASS.Cfg["ENTREASON"].ToString();
                        RequestHeader.HOSTNAME = System.Environment.MachineName;
                        RequestHeader.SESSION_ID = VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID;
                        RequestHeader.COMPRESSED = "Y";

                        //WebService.IziBizSrv.LoginRequest lcont = new WebService.IziBizSrv.LoginRequest();
                        //lcont.REQUEST_HEADER = htype;
                        //lcont.USER_NAME = VISION.FINANS.UBL.IZIBIZ_CLASS.Cfg["ENTUSERNAME"].ToString();
                        //lcont.PASSWORD = VISION.FINANS.UBL.IZIBIZ_CLASS.Cfg["ENTPASS"].ToString();  

                        UBL.ERP_CREATE_XML createxml = new UBL.ERP_CREATE_XML();
                        string FILE_NAME = createxml.Create(_GLOBAL_PARAMETERS._SIRKET_KODU, Cfg, dr, "_OUTBOX", dr["FATURANIN_TURU"].ToString());

                        WebService.IzibizSrvEFaturaArchive.ArchiveInvoiceExtendedRequest sendArchieveInvoiceRequest = new WebService.IzibizSrvEFaturaArchive.ArchiveInvoiceExtendedRequest();
                        WebService.IzibizSrvEFaturaArchive.ArchiveInvoiceExtendedContentINVOICE_PROPERTIES[] Arr_ContentProps = new WebService.IzibizSrvEFaturaArchive.ArchiveInvoiceExtendedContentINVOICE_PROPERTIES[1];
                        WebService.IzibizSrvEFaturaArchive.ArchiveInvoiceExtendedContentINVOICE_PROPERTIES ContentProps = new WebService.IzibizSrvEFaturaArchive.ArchiveInvoiceExtendedContentINVOICE_PROPERTIES();
                        sendArchieveInvoiceRequest.REQUEST_HEADER = RequestHeader;
                        ContentProps.EARSIV_FLAG = WebService.IzibizSrvEFaturaArchive.FLAG_VALUE.Y;
                        WebService.IzibizSrvEFaturaArchive.EARSIV_PROPERTIES ContentDetails = new WebService.IzibizSrvEFaturaArchive.EARSIV_PROPERTIES();
                        ContentDetails.EARSIV_TYPE = WebService.IzibizSrvEFaturaArchive.EARSIV_TYPE_VALUE.NORMAL;
                        ContentDetails.SUB_STATUS = WebService.IzibizSrvEFaturaArchive.SUB_STATUS_VALUE.NEW;


                        if (dr["EARCEMAILADDR1"].ToString() != "")
                        {
                            ContentDetails.EARSIV_EMAIL_FLAG = WebService.IzibizSrvEFaturaArchive.FLAG_VALUE.Y;
                        }
                        else
                        {
                            ContentDetails.EARSIV_EMAIL_FLAG = WebService.IzibizSrvEFaturaArchive.FLAG_VALUE.N;
                        }

                        if (ContentDetails.EARSIV_EMAIL_FLAG == WebService.IzibizSrvEFaturaArchive.FLAG_VALUE.Y)
                                ContentDetails.EARSIV_EMAIL = new string[] { dr["EARCEMAILADDR1"].ToString() };
                      
                        ContentProps.EARSIV_PROPERTIES = ContentDetails;

                        WebService.IzibizSrvEFaturaArchive.base64Binary content = new WebService.IzibizSrvEFaturaArchive.base64Binary();
                        byte[] zipFileBinaryDataArray = null;
                        using (MemoryStream memoryStreamOutput = new MemoryStream())
                        {
                            using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
                            {
                                zip.AddFile(FILE_NAME, string.Empty);
                                zip.Save(memoryStreamOutput);
                            }
                            zipFileBinaryDataArray = memoryStreamOutput.ToArray();
                        }
                        content.Value = zipFileBinaryDataArray;
                        ContentProps.INVOICE_CONTENT = content;
                        Arr_ContentProps[0] = ContentProps;
                        ContentProps.INVOICE_CONTENT.Value = content.Value;
                        sendArchieveInvoiceRequest.ArchiveInvoiceExtendedContent = Arr_ContentProps;
                        WebService.IzibizSrvEFaturaArchive.ArchiveInvoiceExtendedResponse sendInvoiceResponse = ArchiveClient.WriteToArchiveExtended(sendArchieveInvoiceRequest);
                        if (sendInvoiceResponse.ERROR_TYPE != null)
                        {
                          //  Console.WriteLine(sendInvoiceResponse.ERROR_TYPE.ERROR_SHORT_DES); 

                            using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                            {
                                myConnections.Open();

                                string HATA = sendInvoiceResponse.ERROR_TYPE.ERROR_SHORT_DES.Replace("'", "").Replace("(", "").Replace("=", "").Replace(")", "").Replace("/*[", "").Replace("]", "").Replace("@schemeID", "").Replace("]/*[", "");
                                if (HATA.Length > 600) HATA = HATA.Substring(0, 600);


                                string SQLSELECT = @"IF EXISTS (select * from FTR_GIB_TRANSFER_DURUMU where DURUM_KODU='{0}' and MESAJ='{1}' and  SIRKET_KODU='{2}' and DONEM='{3}' and ID='{4}' and GID='{5}')
                                                        select * from FTR_GIB_TRANSFER_DURUMU where DURUM_KODU='{0}' and MESAJ='{1}' and  SIRKET_KODU='{2}' and DONEM='{3}' and ID='{4}' and GID='{5}' 
                                                    else ";
                                SQLSELECT = string.Format(SQLSELECT, sendInvoiceResponse.ERROR_TYPE, HATA, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), "01", dr["FICHENO"].ToString(), dr["GUID"].ToString());
                                DateTime myDTStart = Convert.ToDateTime(DateTime.Now); 

                                string SQLINSERT = @" INSERT INTO FTR_GIB_TRANSFER_DURUMU  (DURUM_KODU,MESAJ,SIRKET_KODU,DONEM,ID,GID,TARIH,SERVER) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}') ";

                                SQLINSERT = string.Format(SQLINSERT, sendInvoiceResponse.ERROR_TYPE, HATA, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), "01", dr["FICHENO"].ToString(), dr["GUID"].ToString(), myDTStart.ToString("yyyy-MM-dd").ToString(), "RESPONSE");
                                using (SqlCommand cmd = new SqlCommand())
                                {
                                    cmd.CommandText = SQLSELECT + SQLINSERT;
                                    cmd.Connection = myConnections;
                                    cmd.ExecuteNonQuery();
                                }
                            } 
                        }
                        else
                        {
                            //Console.WriteLine("Yükleme Başarılı");


                            //WebService.IziBizSrv.SendInvoiceResponse returnTyp = I2IEInv.SendInvoice(siCnt); 
                            //int j = iz;
                            if (sendInvoiceResponse.ERROR_TYPE != null)
                            { throw new Exception("Gönderilen ID alınamadı result GIB.."); }
                            else
                            {
                                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                                {
                                    using (SqlCommand myCommand = new SqlCommand())
                                    {
                                        myCommand.Parameters.AddWithValue("@ERP_AKTARILDI", 1);
                                        myCommand.Parameters.AddWithValue("@SESSIONID", RequestHeader.SESSION_ID);
                                        myCommand.Parameters.AddWithValue("@INVID", dr["LOGICALREF"]);
                                        myCommand.Parameters.AddWithValue("@FILE", FILE_NAME);
                                        myCommand.Parameters.AddWithValue("@GID", dr["GUID"]);
                                        myCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                                        myCommand.Parameters.AddWithValue("@Tarih", dr["DATE_"]);
                                        myCommand.Parameters.AddWithValue("@ID", dr["FICHENO"]);
                                        myCommand.Parameters.AddWithValue("@FRM", _GLOBAL_PARAMETERS._SIRKET_NO);
                                        myCommand.Parameters.AddWithValue("@VKN", dr["TAXNR"].ToString());
                                        myCommand.Parameters.AddWithValue("@SICILNO", dr["SPECODE"].ToString());
                                        myCommand.Parameters.AddWithValue("@MUSTERI", dr["DEFINITION_"].ToString());
                                        myCommand.Parameters.AddWithValue("@ACIKLAMA", dr["GENEXP1"].ToString());
                                        myCommand.Parameters.AddWithValue("@FATURATARIH", dr["DATE_"]);
                                        myCommand.Parameters.AddWithValue("@PROFILID", dr["TRCODE_"].ToString());
                                        myCommand.Parameters.AddWithValue("@TIP", dr["GRPCODE_"].ToString()); 
                                        float NETTOTAL = float.Parse(dr["GROSSTOTAL"].ToString(), System.Globalization.CultureInfo.CurrentCulture);//CreateSpecificCulture("en-US")
                                        float TOTALVAT = float.Parse(dr["TOTALVAT"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
                                        float TOTALDISCOUNTS = float.Parse(dr["TOTALDISCOUNTS"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
                                        float GENELTOPLAM = float.Parse(dr["NETTOTAL"].ToString(), System.Globalization.CultureInfo.CurrentCulture); 
                                        myCommand.Parameters.AddWithValue("@TOPLAMTUTAR", NETTOTAL);
                                        myCommand.Parameters.AddWithValue("@HESAPLANANKDV", TOTALVAT);
                                        myCommand.Parameters.AddWithValue("@TOPLAMINDIRIM", TOTALDISCOUNTS);
                                        myCommand.Parameters.AddWithValue("@GENELTOPLAM", GENELTOPLAM);
                                        myCommand.Parameters.AddWithValue("@FATURA_TIPI", 'A'); 
                                        myCommand.Connection = myConnection;
                                        myCommand.CommandText = " INSERT INTO  dbo.FTR_GIB_TRANSFER (ERP_AKTARILDI,SESSIONID,INVID,[FILE],GID,SIRKET_KODU,Tarih,ID,FRM,VKN,SICILNO,MUSTERI,ACIKLAMA,FATURATARIH,PROFILID,TIP,TOPLAMTUTAR,HESAPLANANKDV,TOPLAMINDIRIM,GENELTOPLAM,FATURA_TIPI,GUID)  VALUES  (@ERP_AKTARILDI,@SESSIONID,@INVID,@FILE,@GID,@SIRKET_KODU,@Tarih,@ID,@FRM,@VKN,@SICILNO,@MUSTERI,@ACIKLAMA,@FATURATARIH,@PROFILID,@TIP,@TOPLAMTUTAR,@HESAPLANANKDV,@TOPLAMINDIRIM,@GENELTOPLAM,@FATURA_TIPI,NEWID())";
                                        myConnection.Open();
                                        myCommand.ExecuteNonQuery();
                                        myCommand.Connection.Close();
                                    }
                                }
                                _FATURA_DURUM_UPDATE(dr["FICHENO"].ToString(), dr["FATURANIN_TURU"].ToString());
                                eArchiveStatus(dr["GUID"].ToString());

                               // GIB_DURUM_KONTROL(dr);

                            

                                //if (VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID == "" || VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID == null) VISION.FINANS.UBL.IZIBIZ_CLASS.izibiz_login();
                                //if (VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID != "")
                                //{
                                //    VISION.FINANS.UBL.IZIBIZ_CLASS.Config();
                                //    int[] selectedRows = gridView_LIST.GetSelectedRows();
                                //    for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
                                //    {
                                //DataRow dr = gridView_LIST.GetDataRow(selectedRows[ix]);
                                //if (dr == null) break;
                                //    }
                                //}
                                //DATA_LOAD();
                            }
                            //}
                            //else
                            //{
                            //    MessageBox.Show(dr["FICHENO"] + " Nolu farua daha önceden gönderilmiş. ");
                            //}
                            // Show a sample alert window. 
                            // info.Text += "Son İndirme : " + DateTime.Now.ToShortTimeString() + Environment.NewLine;

                            //info.Text += "Gönderilen Fatura Sayısı : " + selectedRows.Length + Environment.NewLine;
                            //alertControls.Show(this, info);
                        }
                    }
                }  
            }   
            DATA_LOAD(); 
            MessageBox.Show("İşlem Tamamlandı");
        }




        public Boolean eArchiveStatus(string uuid)
        {
            string[] invoiceUUID = new string[] { uuid };

            WebService.IzibizSrvEFaturaArchive.GetEArchiveInvoiceStatusRequest eArchiveStatus = new WebService.IzibizSrvEFaturaArchive.GetEArchiveInvoiceStatusRequest();
            eArchiveStatus.REQUEST_HEADER = RequestHeader;
            eArchiveStatus.UUID = invoiceUUID;
            WebService.IzibizSrvEFaturaArchive.GetEArchiveInvoiceStatusResponse resp = ArchiveClient.GetEArchiveInvoiceStatus(eArchiveStatus);
            if (resp.INVOICE[0].HEADER.REPORT_ID != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [Flags]
        public enum Married
        {
            Y,
            N
        }


        static WebService.IziBizSrv.EFaturaOIB _EFaturaOIB = null;
        WebService.IziBizSrv.SendInvoiceRequest siCnt = null;
        public static WebService.IziBizSrv.EFaturaOIB I2IEInv
        {
            get
            {
                if (_EFaturaOIB == null)
                {
                    _EFaturaOIB = new WebService.IziBizSrv.EFaturaOIB();
                    _EFaturaOIB.Url =  FINANS.UBL.IZIBIZ_CLASS.Cfg["SRVAdress"].ToString();// "https://ari3.i2i-systems.com:2443/EFaturaOIB?wsdl";//;Data.CFG.Cfg.SRVAdress;
                    _EFaturaOIB.Timeout = (60 * 1000) * 40;
                    //if (Data.CFG.Cfg.IsProxy)
                    //{
                    //    //_EFaturaOIB.Credentials = new System.Net.NetworkCredential(Tools.Gnl.Cfg.ProxyUser,Data.CFG.Cfg.ProxyPass,Data.CFG.Cfg.ProxyDomain);
                    //    _EFaturaOIB.Proxy = new System.Net.WebProxy(Data.CFG.Cfg.ProxyUrl, Data.CFG.Cfg.ProxyPort);
                    //    _EFaturaOIB.Proxy.Credentials = new System.Net.NetworkCredential(Data.CFG.Cfg.ProxyUser, Data.CFG.Cfg.ProxyPass, Data.CFG.Cfg.ProxyDomain);
                    //}
                }
                return _EFaturaOIB;
            }
        }


        private void SendInv(string FILE_NAME, DataRow DRW, int j)
        {

            //ıNVOICE.HEADER.
            //  string rs = "";
            try
            { 

                ZipFile Uzip = new ZipFile();
                string appPath = _GLOBAL_PARAMETERS._FILE_PATH; //Path.GetDirectoryName(Application.ExecutablePath); 

                FileInfo fl = new FileInfo(FILE_NAME.Replace(".xml", ".zip"));
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddFile(FILE_NAME, @"\");
                    string xmlF = fl.FullName.Replace(fl.Name, fl.Name.Replace(".zip", ".xslt"));
                    string xslt="";//= appPath + "_XSLT\\" + _GLOBAL_PARAMETERS._SIRKET_KODU + "\\GENERIC_TEMPLATE.xslt";



                    if (dr["FATURANIN_TURU"].ToString() == "e-arşiv")
                    {
                        xslt = appPath + @"_XSLT\EARSIVE\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";
                    }
                    if (dr["FATURANIN_TURU"].ToString() == "e-fatura")
                    {
                        xslt = appPath + @"_XSLT\EFATURA\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";
                    }



                    File.Copy(xslt, xmlF, true);
                    zip.AddFile(fl.FullName.Replace(".zip", ".xslt"), @"\");
                    zip.Save(fl.FullName);
                }
                byte[] binarydata = File.ReadAllBytes(fl.FullName);
                siCnt.INVOICE[j] = new WebService.IziBizSrv.INVOICE();
                siCnt.INVOICE[j].CONTENT = new WebService.IziBizSrv.base64Binary();
                siCnt.INVOICE[j].CONTENT.Value = binarydata;
                siCnt.INVOICE[j].ID = DRW["FICHENO"].ToString();
                siCnt.INVOICE[j].UUID = DRW["GUID"].ToString();
                              

                //}





                //for (int i = 0; i < logs.Count; i++)
                //    logs[i].TXN_ID = returnTyp.REQUEST_RETURN.INTL_TXN_ID;

                //if (returnTyp.REQUEST_RETURN.WARNINGS != null && returnTyp.REQUEST_RETURN.WARNINGS.Length > 1)
                //{
                //    for (int i = 0; i < logs.Count; i++)
                //    {
                //        if (returnTyp.REQUEST_RETURN.WARNINGS.Length > i)
                //            logs[i].MESAJ = returnTyp.REQUEST_RETURN.WARNINGS[i];
                //    }
                //}


                //foreach (Data.INVTRNS lg in logs)
                //    lg.Save();

                //rs.Sonuc = true;
                //rs.Mesaj = "Gönderildi";
                //rs.SESSIONID = returnTyp.REQUEST_RETURN.INTL_TXN_ID.ToString();


                //if (Tools.Gnl.PRTIPS == Data.PROGRAMTIPS.UBL_FOLDER)
                //{
                //    string pKok = Tools.Gnl.WorkDirectory + "GONDERILECEK";

                //    //if (Iade)
                //    //    pKok += "\\IADE";
                //    //else
                //    pKok += "\\SATIS";

                //    string MOV = pKok + "\\TMP";

                //    if (!Directory.Exists(pKok))
                //        Directory.CreateDirectory(pKok);

                //    if (!Directory.Exists(MOV))
                //        Directory.CreateDirectory(MOV);

                //    foreach (FileInfo f in new DirectoryInfo(pKok).GetFiles("*.xml"))
                //    {
                //        if (prm.SendListInv.Where(c => f.Name.IndexOf(c.NO) < 0).Count() > 0)
                //            continue;

                //        int snc = new DirectoryInfo(MOV).GetFiles(f.Name.Replace(".xml", "") + "*.xml").Count();

                //        string fn = f.Name;

                //        if (snc > 0)
                //            fn = f.Name.Replace(".xml", "") + "_(" + snc.ToString() + ").xml";

                //        f.MoveTo(MOV + "\\" + fn);
                //    }
                //}

                // return rs="as";
            }
            catch (SoapException ee)
            {
                // rs = false;
                //string Mesaj = ee.Message;
                //rs.Mesaj += "\nGönderme işleminde hata..";
                //rs.Mesaj += "\nDetaylar : " + ee.Detail.InnerText;
                //rs.Mesaj += "\nAlıcı :" + prm.ALIALS + " " + prm.VKN + " " + "Gönderici :" + Tools.Gnl.PARAMS.ElectronicMail + " " + Tools.Gnl.PARAMS.VKN;

                //return rs;
            }
        }
         

        public string _FATURA_DURUM_UPDATE(string NUMBER,string FATURA_TYPE)
        {
            string DURUM_BILGISI = string.Empty;
            int _LOGICALREF = 0;
            Query Querys = _GLOBAL_PARAMETERS.Global.UnityApp.NewQuery();
            string Query_String = "   select  LOGICALREF FROM LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_01_INVOICE  WHERE   FICHENO='" + NUMBER + "'";
            Querys.Statement = Query_String;
            if (Querys.OpenDirect())
            {
                bool eof = Querys.First();
                if (eof)
                {
                    while (eof)
                    {
                        _LOGICALREF = Querys.QueryFields[0].Value;
                        eof = Querys.Next();
                    }
                }
            }

            if (FATURA_TYPE == "e-fatura")
            {
                Query Queryf = _GLOBAL_PARAMETERS.Global.UnityApp.NewQuery();
                string QueryString = " UPDATE  dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_01_INVOICE  SET ESTATUS='4' WHERE LOGICALREF=" + _LOGICALREF + "";
                Queryf.Statement = QueryString;
                Boolean res = Queryf.Execute();
                if (res)
                {
                    DURUM_BILGISI = "OK";
                }
                else
                {
                    DURUM_BILGISI = Queryf.Error.ToString();
                }
            }

            if (FATURA_TYPE == "e-arşiv")
            { 
                Query Queryf = _GLOBAL_PARAMETERS.Global.UnityApp.NewQuery();
                string QueryString = " UPDATE  dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_01_EARCHIVEDET  SET EARCHIVESTATUS='4' WHERE INVOICEREF=" + _LOGICALREF + "";
                Queryf.Statement = QueryString;
                Boolean res = Queryf.Execute();
                if (res)
                {
                    DURUM_BILGISI = "OK";
                }
                else
                {
                    DURUM_BILGISI = Queryf.Error.ToString();
                }
            }

            //if (Order.Post())
            //    return 0;
            //else
            //    if (Queryf.ErrorCode != 0)
            //        return Queryf.ErrorCode;
            //    else
            //        return Queryf.ValidateErrors[0].ID;


            return DURUM_BILGISI;

        }




   
  

        private void GIB_DURUM_KONTROL(DataRow dr)
        {

            try
            {
                WebService.IziBizSrv.GetInvoiceStatusRequest req = new WebService.IziBizSrv.GetInvoiceStatusRequest();
                req.INVOICE = new WebService.IziBizSrv.INVOICE();
                req.INVOICE.ID = dr["FICHENO"].ToString();
                req.INVOICE.UUID = dr["GUID"].ToString();
                htype = new WebService.IziBizSrv.REQUEST_HEADERType();
                htype.SESSION_ID = VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID;
                htype.CHANNEL_NAME = VISION.FINANS.UBL.IZIBIZ_CLASS.Cfg["ENTCHANNEL_NAME"].ToString();
                htype.REASON = VISION.FINANS.UBL.IZIBIZ_CLASS.Cfg["ENTREASON"].ToString();
                htype.HOSTNAME = System.Environment.MachineName;
                htype.APPLICATION_NAME = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                htype.COMPRESSED = "N";
                htype.CLIENT_TXN_ID = VISION.FINANS.UBL.IZIBIZ_CLASS.Cfg["VKN"].ToString();
                htype.ACTION_DATE = DateTime.Now;
                htype.SIMULATION_FLAG = "";
                req.REQUEST_HEADER = htype;//IZIBIZ_CLASS.htype; 
                var InvStatu = VISION.FINANS.UBL.IZIBIZ_CLASS.I2IEInv.GetInvoiceStatus(req);
                if (InvStatu == null || InvStatu.INVOICE_STATUS == null) return;

                string MESAJIM = "";
                switch (InvStatu.INVOICE_STATUS.STATUS.ToString())
                {
                    case "REJECTED - SUCCEED":
                        MESAJIM = "Giden Ticari Fatura Red - Başarıyla işlendi";
                        break;
                    case "ACCEPTED - SUCCEED":
                        MESAJIM = "Giden Ticari Fatura Kabul - Başarıyla işlendi";
                        break;
                    case "SEND - WAIT_APPLICATION_RESPONSE":
                        MESAJIM = "Fatura Gönderimi - Fatura Onayı Bekleniyor";
                        break;
                    case "SEND - WAIT_SYSTEM_RESPONSE":
                        MESAJIM = "Fatura Gönderimi - Sistem Yanıtı Bekleniyor";
                        break;
                    case "SEND - WAIT_GIB_RESPONSE":
                        MESAJIM = "Fatura Gönderimi - GIB'e Gönderildi";
                        break;
                    case "SEND - FAILED":
                        MESAJIM = "Fatura Gönderimi – Başarısız Oldu";
                        break;
                    case "SEND - SUCCEED":
                        MESAJIM = "Fatura Gönderimi - Başarıyla işlendi";
                        break;
                    case "SEND - PROCESSING":
                        MESAJIM = "Fatura Gönderimi - İşleniyor";
                        break;
                    case "PACKAGE - SUCCEED":
                        MESAJIM = "Fatura Paketleme - Başarıyla işlendi";
                        break;
                    case "PACKAGE - FAILED":
                        MESAJIM = "Fatura Paketleme - Başarısız oldu";
                        break;
                    case "LOAD - FAILED":
                        MESAJIM = "Fatura Yükleme - Başarısız Oldu";
                        break;
                    case "LOAD - SUCCEED":
                        MESAJIM = "Fatura Yükleme - Başarılı";
                        break;
                }

                if (InvStatu.INVOICE_STATUS.RESPONSE_CODE != null)
                {
                    using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                    {
                        myConnections.Open();
                        string SQLSELECT = @"IF EXISTS (select * from FTR_GIB_TRANSFER_DURUMU where DURUM_KODU='{0}' and MESAJ='{1}' and  SIRKET_KODU='{2}' and DONEM='{3}' and ID='{4}' and GID='{5}')
                                                        select * from FTR_GIB_TRANSFER_DURUMU where DURUM_KODU='{0}' and MESAJ='{1}' and  SIRKET_KODU='{2}' and DONEM='{3}' and ID='{4}' and GID='{5}' 
                                                    else ";
                        SQLSELECT = string.Format(SQLSELECT, InvStatu.INVOICE_STATUS.RESPONSE_CODE, InvStatu.INVOICE_STATUS.RESPONSE_DESCRIPTION, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), "01", dr["FICHENO"].ToString(), dr["GUID"].ToString());
                        DateTime myDTStart = Convert.ToDateTime(DateTime.Now);
                        
                        string SQLINSERT = @" INSERT INTO FTR_GIB_TRANSFER_DURUMU  (DURUM_KODU,MESAJ,SIRKET_KODU,DONEM,ID,GID,TARIH,SERVER) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}') ";
                        SQLINSERT = string.Format(SQLINSERT, InvStatu.INVOICE_STATUS.RESPONSE_CODE, InvStatu.INVOICE_STATUS.RESPONSE_DESCRIPTION, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), "01", dr["FICHENO"].ToString(), dr["GUID"].ToString(), myDTStart.ToString("yyyy-MM-dd").ToString(), "RESPONSE");
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = SQLSELECT + SQLINSERT;
                            cmd.Connection = myConnections;
                            cmd.ExecuteNonQuery();
                        }
                    }

                }

                if (InvStatu.INVOICE_STATUS.GIB_STATUS_CODE != null)
                {
                    using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                    {
                        myConnections.Open();
                        string SQLSELECT = @"IF EXISTS (select * from FTR_GIB_TRANSFER_DURUMU where DURUM_KODU='{0}' and MESAJ='{1}' and  SIRKET_KODU='{2}' and DONEM='{3}' and ID='{4}' and GID='{5}')  
                                                    select * from  FTR_GIB_TRANSFER_DURUMU where DURUM_KODU='{0}' and MESAJ='{1}' and  SIRKET_KODU ='{2}' and DONEM='{3}' and ID='{4}' and GID='{5}' 
                                                        else ";
                        SQLSELECT = string.Format(SQLSELECT, InvStatu.INVOICE_STATUS.GIB_STATUS_CODE, InvStatu.INVOICE_STATUS.GIB_STATUS_DESCRIPTION, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), "01", dr["FICHENO"].ToString(), dr["GUID"].ToString());

                        DateTime myDTStart = Convert.ToDateTime(DateTime.Now);
                        string SQLINSERT = @" INSERT INTO FTR_GIB_TRANSFER_DURUMU  (DURUM_KODU,MESAJ,SIRKET_KODU,DONEM,ID,GID,TARIH,SERVER) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}') ";
                        SQLINSERT = string.Format(SQLINSERT, "", MESAJIM.Replace("'", ""), _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), "01", dr["FICHENO"].ToString(), dr["GUID"].ToString(), myDTStart.ToString("yyyy-MM-dd").ToString(), "GİB");
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = SQLSELECT + SQLINSERT;
                            cmd.Connection = myConnections;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                if (InvStatu.INVOICE_STATUS.STATUS != null)
                {

                    using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                    {
                        myConnections.Open();
                        string SQLSELECT = @"IF EXISTS (select * from  FTR_GIB_TRANSFER_DURUMU where DURUM_KODU='{0}' and MESAJ='{1}' and  SIRKET_KODU ='{2}' and DONEM='{3}' and ID='{4}' and GID='{5}') 
                                                               select * from  FTR_GIB_TRANSFER_DURUMU where DURUM_KODU='{0}' and MESAJ='{1}' and  SIRKET_KODU ='{2}' and DONEM='{3}' and ID='{4}' and GID='{5}' else ";
                        SQLSELECT = string.Format(SQLSELECT, InvStatu.INVOICE_STATUS.STATUS, InvStatu.INVOICE_STATUS.STATUS_DESCRIPTION, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), "01", dr["FICHENO"].ToString(), dr["GUID"].ToString());
                        DateTime myDTStart = Convert.ToDateTime(DateTime.Now);
                        string SQLINSERT = @" INSERT INTO FTR_GIB_TRANSFER_DURUMU  (DURUM_KODU,MESAJ,SIRKET_KODU,DONEM,ID,GID,TARIH,SERVER) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}') ";
                        SQLINSERT = string.Format(SQLINSERT, "", MESAJIM.Replace("'", ""), _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), "01", dr["FICHENO"].ToString(), dr["GUID"].ToString(), myDTStart.ToString("yyyy-MM-dd").ToString(), "İZİBİZ");

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = SQLSELECT + SQLINSERT;
                            cmd.Connection = myConnections;
                            cmd.ExecuteNonQuery();
                        }
                    }

                }

                using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                {
                    myConnections.Open();
                    string SQL_ROW = @" UPDATE FTR_GIB_TRANSFER SET DURUM_KODU='{0}',MESAJ='{1}' ,GIB_STATUS_CODE='{0}',GIB_STATUS_DESCRIPTION ='{1}'  Where SIRKET_KODU='{2}'  AND ID='{3}' AND GID='{4}' ";
                    SQL_ROW = string.Format(SQL_ROW, "", MESAJIM.Replace("'", ""), _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), dr["FICHENO"].ToString(), dr["GUID"].ToString());

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = SQL_ROW;
                        cmd.Connection = myConnections;
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (System.Web.Services.Protocols.SoapException ee)
            {
                using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                {
                    myConnections.Open();
                    string SQL_ROW = @" UPDATE dbo.FTR_GIB_TRANSFER SET DURUM_KODU='HATA',MESAJ='" + ee.Message.Replace(",", "") + "',STATUS='HATA',STATUS_DESCRIPTION ='" + ee.Message.Replace(",", "") + "' Where SIRKET_KODU='{0}' and DONEM='{1}' AND ID='{2}' AND GID='{3}' ";
                    SQL_ROW = string.Format(SQL_ROW, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), "01", dr["FICHENO"].ToString(), dr["GUID"].ToString());
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = SQL_ROW;
                        cmd.Connection = myConnections;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        
        }


        public void WKHtmlToPdf(string urlFile, string ExportFolder, string ExportFile)
        {
            var fileName = ExportFile;
            var wkhtmlDir = appPath;//"C:\\temp\\";
            var wkhtml = appPath + "wkhtmltopdf.exe";
            var p = new Process();

            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = wkhtml;
            p.StartInfo.WorkingDirectory = wkhtmlDir;

            string switches = "";
            switches += "--print-media-type ";
            switches += "--margin-top 10mm --margin-bottom 10mm --margin-right 10mm --margin-left 10mm ";
            switches += "--page-size Letter ";
            p.StartInfo.Arguments = switches + " " + urlFile + " " + ExportFolder + "\\" + fileName;
            p.Start();

            p.WaitForExit(61000);
            // read the exit code, close process
            int returnCode = p.ExitCode;
            p.Close();

            // return returnCode == 0 ? 1 : null;
        }

        private void BTN_YAZDIR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YAZDIR();
        }

        private void YAZDIR()
        {  
            int[] selectedRows = gridView_LIST.GetSelectedRows();
            for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
            {
                string USERNAME = _GLOBAL_PARAMETERS._KULLANICI_ADI_SOYADI.Replace(".", "");  
                if (File.Exists(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html")) File.Delete(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html");  
                DataRow dr = gridView_LIST.GetDataRow(selectedRows[ix]);
                pnlControl_INVVIEW.Controls.Clear();
                string xmlfl = "", xsltfl = ""; 
                if (dr != null)
                {
                    BR_FILE.Caption = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["FICHENO"] + ".xml";
                    xmlfl = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["FICHENO"] + ".xml";
                   // xsltfl = appPath + @"_XSLT\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt"; 

                    if (dr["FATURANIN_TURU"].ToString() == "e-fatura")
                    { 
                        xsltfl = appPath + @"_XSLT\EFATURA\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt"; 
                    } 
                    if (dr["FATURANIN_TURU"].ToString() == "e-arşiv")
                    { 
                        xsltfl = appPath + @"_XSLT\EARSIVE\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt"; 
                    } 

                    if (!File.Exists(xmlfl))
                    {
                        UBL.ERP_CREATE_XML createxml = new UBL.ERP_CREATE_XML();
                        string FILE_NAME = createxml.Create(_GLOBAL_PARAMETERS._SIRKET_KODU, Cfg, dr, "_OUTBOX", dr["FATURANIN_TURU"].ToString());
                    } 
                    if (xsltfl != "")
                    {
                        if (File.Exists(xmlfl))
                        { 
                            if (File.Exists(xsltfl))
                            {
                                wbh = null;
                                wbh = new WebBrowser();
                                System.Threading.Thread.Sleep(800);
                                XslCompiledTransform XSLT = new XslCompiledTransform();
                                XsltSettings settings = new XsltSettings();
                                settings.EnableScript = true;
                                XSLT.Load(xsltfl, settings, new XmlUrlResolver());
                                XSLT.Transform(xmlfl, @"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html");

                                String appdir = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                                String myfile = Path.Combine(appdir, @"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html");
                                WaitPrint vv = new WaitPrint(myfile, ix);
                                vv.ShowDialog();
                                vv.Dispose();
                            } 
                        }
                    }
                }
            }
        }

        private void BTN_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            FolderBrowserDialog brwsr = new FolderBrowserDialog();
            if (brwsr.ShowDialog() == DialogResult.Cancel)
                return;
            else
            {

                int[] selectedRows = gridView_LIST.GetSelectedRows();
                for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
                {
                    string USERNAME = _GLOBAL_PARAMETERS._KULLANICI_ADI_SOYADI.Replace(".", "");
                    DataRow dr = gridView_LIST.GetDataRow(selectedRows[ix]);
                    pnlControl_INVVIEW.Controls.Clear();
                    string xmlfl = "", xsltfl = "";

                    if (dr != null)
                    {
                        BR_FILE.Caption = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["FICHENO"] + ".xml";
                        xmlfl = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["FICHENO"] + ".xml";
                       // xsltfl = appPath + @"_XSLT\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";  
                        if (dr["FATURANIN_TURU"].ToString() == "e-fatura")
                        {
                            xsltfl = appPath + @"_XSLT\EFATURA\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";
                        }
                        if (dr["FATURANIN_TURU"].ToString() == "e-arşiv")
                        {
                            xsltfl = appPath + @"_XSLT\EARSIVE\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";
                        } 
                    }

                    //if (File.Exists(xmlfl)) File.Delete(xmlfl);

                    if (!File.Exists(xmlfl))
                    {
                        UBL.ERP_CREATE_XML createxml = new UBL.ERP_CREATE_XML();
                        string FILE_NAME = createxml.Create(_GLOBAL_PARAMETERS._SIRKET_KODU, Cfg, dr, "_OUTBOX", dr["FATURANIN_TURU"].ToString());
                    }


                    if (xsltfl != "")
                    {
                        if (File.Exists(xmlfl))
                        {
                            if (xsltfl != "")
                            {
                                if (File.Exists(xmlfl))
                                {

                                    ZipFile Uzip = new ZipFile();
                                    FileInfo fl = new FileInfo(xmlfl.Replace(".xml", ".zip"));
                                    using (ZipFile zip = new ZipFile())
                                    {
                                        zip.AddFile(xmlfl, @"\");
                                        string xmlF = fl.FullName.Replace(fl.Name, fl.Name.Replace(".zip", ".xslt"));
                                        string xslt = "";// appPath + @"_XSLT\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";



                                        if (dr["FATURANIN_TURU"].ToString() == "e-fatura")
                                        {
                                            xslt = appPath + @"_XSLT\EFATURA\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";
                                        }
                                        if (dr["FATURANIN_TURU"].ToString() == "e-arşiv")
                                        {
                                            xslt = appPath + @"_XSLT\EARSIVE\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";
                                        }


                                        File.Copy(xslt, xmlF, true);
                                        zip.AddFile(fl.FullName.Replace(".zip", ".xslt"), @"\");
                                        zip.Save(fl.FullName);
                                        File.Copy(fl.FullName, brwsr.SelectedPath +@"\"+ fl.Name, true);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("xml file erişilemedi.");
                                }
                            }
                        }
                    }
                }
                MessageBox.Show(selectedRows.Length + " Adet Dosya Kaydedildi");
            }








        


        }

        private void CNT_MENU_LISTEDEN_CIKART_Click(object sender, EventArgs e)
        {
             
            int[] selectedRows = gridView_LIST.GetSelectedRows();
            for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
            {
                DataRow DRW = gridView_LIST.GetDataRow(selectedRows[ix]);
                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                {
                    using (SqlCommand myCommand = new SqlCommand())
                    { 
                        myCommand.Parameters.AddWithValue("@INVID", DRW["LOGICALREF"]);
                        myCommand.Parameters.AddWithValue("@FIRMA", _GLOBAL_PARAMETERS._SIRKET_NO);
                        myCommand.Parameters.AddWithValue("@DONEM", "01");
                        myCommand.Parameters.AddWithValue("@FILE", xmlfl.ToString());
                        myCommand.Parameters.AddWithValue("@Tarih", DRW["DATE_"]);
                        myCommand.Parameters.AddWithValue("@ID", DRW["FICHENO"]);
                        myCommand.Parameters.AddWithValue("@FRM", _GLOBAL_PARAMETERS._SIRKET_NO);
                        myCommand.Parameters.AddWithValue("@VKN", DRW["TAXNR"].ToString());
                        myCommand.Parameters.AddWithValue("@SICILNO", DRW["SPECODE"].ToString());
                        myCommand.Parameters.AddWithValue("@MUSTERI", DRW["DEFINITION_"].ToString());
                        myCommand.Parameters.AddWithValue("@ACIKLAMA", DRW["GENEXP1"].ToString());
                        myCommand.Parameters.AddWithValue("@FATURATARIH", DRW["DATE_"]);
                        myCommand.Parameters.AddWithValue("@PROFILID", DRW["TRCODE_"].ToString());
                        myCommand.Parameters.AddWithValue("@TIP", DRW["GRPCODE_"].ToString());

                        float NETTOTAL = float.Parse(DRW["GROSSTOTAL"].ToString(), System.Globalization.CultureInfo.CurrentCulture);//CreateSpecificCulture("en-US")
                        float TOTALVAT = float.Parse(DRW["TOTALVAT"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
                        float TOTALDISCOUNTS = float.Parse(DRW["TOTALDISCOUNTS"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
                        float GENELTOPLAM = float.Parse(DRW["NETTOTAL"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
                        myCommand.Parameters.AddWithValue("@TOPLAMTUTAR", NETTOTAL);
                        myCommand.Parameters.AddWithValue("@HESAPLANANKDV", TOTALVAT);
                        myCommand.Parameters.AddWithValue("@TOPLAMINDIRIM", TOTALDISCOUNTS);
                        myCommand.Parameters.AddWithValue("@GENELTOPLAM", GENELTOPLAM);
                        myCommand.Parameters.AddWithValue("@FIRMA_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                        myCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);

                        myCommand.Connection = myConnection;
                        myCommand.CommandText = " INSERT INTO  dbo.FTR_GIB_TRANSFER (SIRKET_KODU,INVID,[FILE],FIRMA,DONEM,Tarih,ID,FRM,VKN,SICILNO,MUSTERI,ACIKLAMA,FATURATARIH,PROFILID,TIP,TOPLAMTUTAR,HESAPLANANKDV,TOPLAMINDIRIM,GENELTOPLAM,FIRMA_KODU)  VALUES  (@SIRKET_KODU,@INVID,@FILE,@FIRMA,@DONEM,@Tarih,@ID,@FRM,@VKN,@SICILNO,@MUSTERI,@ACIKLAMA,@FATURATARIH,@PROFILID,@TIP,@TOPLAMTUTAR,@HESAPLANANKDV,@TOPLAMINDIRIM,@GENELTOPLAM,@FIRMA_KODU)";
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myCommand.Connection.Close();


                        _FATURA_DURUM_UPDATE(DRW["FICHENO"].ToString (), dr["FATURANIN_TURU"].ToString());
                    }
                }
            }
        }

        private void CNT_MENU_XML_OLUSTUR_Click(object sender, EventArgs e)
        {
            int[] selectedRows = gridView_LIST.GetSelectedRows();
            for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
            {
                DataRow dr = gridView_LIST.GetDataRow(selectedRows[ix]);
                pnlControl_INVVIEW.Controls.Clear();
                string xmlfl = "", xsltfl = "";

                if (dr != null)
                {

                    if (dr["FATURANIN_TURU"].ToString() == "e-fatura")
                    {
                        BR_FILE.Caption = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["FICHENO"] + ".xml";
                        xmlfl = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["FICHENO"] + ".xml";
                        xsltfl = appPath + @"_XSLT\EFATURA\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";/// +dr["FICHENO"] + "_" + dr["GUID"] + ".xslt";
                    }

                    if (dr["FATURANIN_TURU"].ToString() == "e-arşiv")
                    {
                        BR_FILE.Caption = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["FICHENO"] + ".xml";
                        xmlfl = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["FICHENO"] + ".xml";
                        xsltfl = appPath + @"_XSLT\EARSIVE\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";/// +dr["FICHENO"] + "_" + dr["GUID"] + ".xslt";
                    }
                

                        //e_master.SmartInv.UBL.LOGO_CreateXML createxml = new UBL.LOGO_CreateXML();
                        //string FILE_NAME = createxml.Create(_GLOBAL_PARAMETERS._SIRKET_KODU, Cfg, dr, "_OUTBOX"); 

                        UBL.ERP_CREATE_XML createxml = new UBL.ERP_CREATE_XML(); 
                        xmlfl = createxml.Create(_GLOBAL_PARAMETERS._SIRKET_KODU, Cfg, dr, "_OUTBOX", dr["FATURANIN_TURU"].ToString()); 

                        ZipFile Uzip = new ZipFile();
                        FileInfo fl = new FileInfo(xmlfl.Replace(".xml", ".zip"));
                        using (ZipFile zip = new ZipFile())
                        {
                            zip.AddFile(xmlfl, @"\");
                            string xmlF = fl.FullName.Replace(fl.Name, fl.Name.Replace(".zip", ".xslt"));
                            string xslt = "";

                            if (dr["FATURANIN_TURU"].ToString() == "e-fatura")
                            {
                                  xslt = appPath + @"_XSLT\EFATURA\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";
                            }
                            if (dr["FATURANIN_TURU"].ToString() == "e-arşiv")
                            {
                                  xslt = appPath + @"_XSLT\EARSIVE\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";
                            }
                                File.Copy(xslt, xmlF, true);
                            zip.AddFile(fl.FullName.Replace(".zip", ".xslt"), @"\");
                            zip.Save(fl.FullName);
                        }
               }
            }
        }
 
    }
}