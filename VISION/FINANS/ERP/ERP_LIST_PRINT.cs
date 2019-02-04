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
using System.IO;
using System.Xml.Xsl;
using System.Xml;
using System.Diagnostics;
using DevExpress.XtraBars.Alerter;

namespace VISION.FINANS.ERP
{
    public partial class ERP_LIST_PRINT : DevExpress.XtraEditors.XtraForm
    {
        string _FATURA_TYPE;
        string RECEIVER_VKN;
        string RECEIVER_ALIALS;
        DataRow Cfg = null;
        DataRow dr = null; 
        string appPath = _GLOBAL_PARAMETERS._FILE_PATH;  
        WebBrowser wbh = new WebBrowser(); 
        AlertInfo info = new AlertInfo("Fatura İndirme Bilgisi", "");
        public ERP_LIST_PRINT(string FATURA_TYPE)
        {
            InitializeComponent(); 
            _FATURA_TYPE = FATURA_TYPE;
            this.Tag = "MDIFORM"; 
            DATA_LOAD();
        } 
        private void DATA_LOAD()
        {
        
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString()))
            {
                _ERP_CLASS sql = new _ERP_CLASS();
                string INVOICE_TABLE_SQL = string.Format(sql.INVOICE_TABLE_SQL_PRINT, _GLOBAL_PARAMETERS._DBONAME, _GLOBAL_PARAMETERS._SIRKET_NO.ToString(), "01");    
                SqlCommand cmd = myConnection.CreateCommand();
                cmd.CommandText = INVOICE_TABLE_SQL + " AND (fat.TRCODE IN (" + _FATURA_TYPE + ")) ";
                SqlDataAdapter deMaster = new SqlDataAdapter(cmd);                                
                DataSet ds = new DataSet();
                deMaster.Fill(ds, "Header");                
                ds.Relations.Clear();
                //ds.Relations.Add("Rapor", ds.Tables["Header"].Columns["LOGICALREF"], ds.Tables["Detail"].Columns["INVOICEREF"], false);     
                //gridCntrl_LIST.LevelTree.Nodes.Add(ds.Relations["Rapor"].RelationName, gridView_DETAYLAR);
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
            if (dr != null)
            {
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
 

        private void BTN_FATURA_OLUSTUR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] selectedRows = gridView_LIST.GetSelectedRows();
            for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
            {
                dr = gridView_LIST.GetDataRow(selectedRows[ix]);  
                //e_master.SmartInv.UBL.LOGO_CREATEXML_PRINT createxml = new UBL.LOGO_CREATEXML_PRINT();
                UBL.ERP_CREATE_XML_PRINT createxml = new UBL.ERP_CREATE_XML_PRINT();
                createxml.Create(_GLOBAL_PARAMETERS._SIRKET_KODU, Cfg, dr, "_OUTBOX_PRINT"); 
            } 
            DATA_LOAD();
            // Show a sample alert window. 
           // info.Text += "Son İndirme : " + DateTime.Now.ToShortTimeString() + Environment.NewLine;
            info.Text += "Oluşturulan Fatura Sayısı : " + selectedRows.Length + Environment.NewLine;
            alertControls.Show(this, info); 
          // MessageBox.Show("Dosyalar Oluşturuldu");
        }

        private void gridCntrl_LIST_DoubleClick(object sender, EventArgs e)
        {
            //dr = gridView_LIST.GetFocusedDataRow();  
            //RECEIVER_VKN = null;
            //RECEIVER_ALIALS = null;
            //dr = gridView_LIST.GetFocusedDataRow(); 
            //HTML_VIEW(); 
        }
        //WebBrowser wbh;
        private void HTML_VIEW()
        {
            string USERNAME = _GLOBAL_PARAMETERS._KULLANICI_ADI_SOYADI.Replace(".", "");
            //  if (File.Exists(appPath + @"_PRINT\" + USERNAME + "TMP.html")) File.Delete(appPath + @"_PRINT\" +  USERNAME + "TMP.html");

            DataRow dr = gridView_LIST.GetFocusedDataRow();
            string xmlfl = "", xsltfl = "";
            if (dr != null)
            {
                DateTime FILEYEAR_ = Convert.ToDateTime(dr["DATE_"].ToString());
                string GIBFILE = _GLOBAL_PARAMETERS._SIRKET_KODU + FILEYEAR_.ToString("yyyy") + "_" + dr["FICHENO"].ToString();
                BR_FILE.Caption = appPath + @"_OUTBOX_PRINT\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + GIBFILE + ".xml";
                xmlfl = appPath + @"_OUTBOX_PRINT\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + GIBFILE + ".xml";
                xsltfl = appPath + @"_XSLT\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt"; 
                if (!File.Exists(xmlfl))
                {
                    UBL.ERP_CREATE_XML_PRINT createxml = new UBL.ERP_CREATE_XML_PRINT();
                    createxml.Create(_GLOBAL_PARAMETERS._SIRKET_KODU, Cfg, dr, "_OUTBOX_PRINT");
                    //e_master.SmartInv.UBL.LOGO_CREATEXML_PRINT createxml = new UBL.LOGO_CREATEXML_PRINT();
                    //xmlfl = createxml.Create(Masters._firmaKodu, Cfg, dr, "_OUTBOX_PRINT");
                }
                if (xsltfl != "")
                {
                    if (File.Exists(xmlfl))
                    {
                        wbh = null;
                        wbh = new WebBrowser();
                        XslCompiledTransform XSLT = new XslCompiledTransform();
                        XsltSettings settings = new XsltSettings();
                        settings.EnableScript = true;
                        XSLT.Load(xsltfl, settings, new XmlUrlResolver());
                        XSLT.Transform(xmlfl, @"c:\temp\_PRINT\" + USERNAME + "TMP.html");
                        //UBL_VIEWER vv = new UBL_VIEWER();
                        String appdir = Path.GetDirectoryName(Application.ExecutablePath);
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
                        //wbh.Print(); 
                    }
                    else
                    {
                        MessageBox.Show("xml file erişilemedi.");
                    }
                }
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
                        xsltfl = appPath + @"_XSLT\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";/// +dr["FICHENO"] + "_" + dr["GUID"] + ".xslt";
                    }
                    if (!File.Exists(xmlfl))
                    {
                       // e_master.SmartInv.UBL.LOGO_CreateXML createxml = new UBL.LOGO_CreateXML();
                        UBL.ERP_CREATE_XML_PRINT createxml = new UBL.ERP_CREATE_XML_PRINT();
                        string FILE_NAME = createxml.Create(_GLOBAL_PARAMETERS._SIRKET_KODU, Cfg, dr, "_OUTBOX_PRINT");
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
                    xsltfl = appPath + @"_XSLT\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";
                    if (!File.Exists(xmlfl))
                    {
                        UBL.ERP_CREATE_XML_PRINT createxml = new UBL.ERP_CREATE_XML_PRINT();
                        string FILE_NAME = createxml.Create(_GLOBAL_PARAMETERS._SIRKET_KODU, Cfg, dr, "_OUTBOX_PRINT");
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

                                    // System.Threading.Thread.Sleep(100);
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
                fr.SendMailAsync("noreply." + _GLOBAL_PARAMETERS._SIRKET_KODU  + "@groupm.com", snd.to.ToString(), snd.subject.ToString(), snd.aciklama.ToString(), FILE_NAME_ADRESS);
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
                    BR_FILE.Caption = appPath + @"_OUTBOX_PRINT\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["FICHENO"] + ".xml";
                    xmlfl = appPath + @"_OUTBOX_PRINT\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["FICHENO"] + ".xml";
                    xsltfl = appPath + @"_XSLT\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";/// +dr["FICHENO"] + "_" + dr["GUID"] + ".xslt";
                    if (!File.Exists(xmlfl))
                    {
                        UBL.ERP_CREATE_XML_PRINT createxml = new UBL.ERP_CREATE_XML_PRINT();
                        string FILE_NAME = createxml.Create(_GLOBAL_PARAMETERS._SIRKET_KODU, Cfg, dr, "_OUTBOX_PRINT");
                    } 

                    if (xsltfl != "")
                    {
                        if (File.Exists(xmlfl))
                        {
                            if (File.Exists(xsltfl))
                            {
                                wbh = null;
                                wbh = new WebBrowser();
                                System.Threading.Thread.Sleep(700);
                                XslCompiledTransform XSLT = new XslCompiledTransform();
                                XsltSettings settings = new XsltSettings();
                                settings.EnableScript = true;
                                XSLT.Load(xsltfl, settings, new XmlUrlResolver());
                                XSLT.Transform(xmlfl, @"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html");

                                String appdir = Path.GetDirectoryName(Application.ExecutablePath);
                                String myfile = Path.Combine(appdir, @"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html");
                                WaitPrint vv = new WaitPrint(myfile, ix);
                                vv.ShowDialog();
                                vv.Dispose();
                            }
                            //  wbh.Url = new Uri("file:///" + myfile);
                            //  wbh.Refresh();

                            // // wbh.Show();
                            //  //// Show();
                            //  //wbh.ScrollBarsEnabled = true;
                            //  //wbh.ScriptErrorsSuppressed = true;
                            //  //pnlControl_INVVIEW.Controls.Add(wbh);
                            //  //wbh.Dock = DockStyle.Fill;
                            //  //wbh.BringToFront();
                            ////  wbh.Refresh();
                            //  wbh.Print();
                        }
                    }
                }
            }
        }

    }
}