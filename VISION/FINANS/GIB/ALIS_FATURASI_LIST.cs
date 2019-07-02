using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Xsl;
using System.Xml;
using System.Diagnostics;
using DevExpress.XtraBars.Alerter;
using UnityObjects;
using DevExpress.XtraGrid.Views.Grid;

namespace VISION.FINANS.GIB
{
    public partial class ALIS_FATURASI_LIST : DevExpress.XtraEditors.XtraForm
    {
        string appPath = _GLOBAL_PARAMETERS._FILE_PATH;// Path.GetDirectoryName(Application.ExecutablePath);
        DataRow dr;
        AlertInfo info = new AlertInfo("Fatura İndirme Bilgisi", "");
        int INEN_FATURA_SAYISI = 0;


        public ALIS_FATURASI_LIST()
        {
            InitializeComponent();
            this.Tag = "MDIFORM";


            //WebResponse objResponse;
            //WebRequest objRequest = System.Net.HttpWebRequest.Create("http://10.219.168.91/SALES_INVOICES.asmx");
            //objResponse = objRequest.GetResponse(); 

            //// Create a regular custom button.
            //AlertButton btn1 = new AlertButton(Image.FromFile(@"c:\folder-16x16.png"));
            //btn1.Hint = "Open file";
            //btn1.Name = "buttonOpen";
            //// Create a check custom button.
            //AlertButton btn2 = new AlertButton(Image.FromFile(@"c:\clock-16x16.png"));
            //btn2.Style = AlertButtonStyle.CheckButton;
            //btn2.Down = true;
            //btn2.Hint = "Alert On";
            //btn2.Name = "buttonAlert";
            //// Add buttons to the AlertControl and subscribe to the events to process button clicks
            //alertControl1.Buttons.Add(btn1);
            //alertControl1.Buttons.Add(btn2);
            //alertControl1.ButtonClick += new AlertButtonClickEventHandler(alertControl1_ButtonClick);
            //alertControl1.ButtonDownChanged +=
            //    new AlertButtonDownChangedEventHandler(alertControl1_ButtonDownChanged);

            //// Show a sample alert window.
            //AlertInfo info = new AlertInfo("New Window", "Text");
            //alertControl1.Show(this, info);

        }
        private void ALIS_FATURASI_LIST_Load(object sender, EventArgs e)
        {
            BTM_FIRMA_KODU.Caption = _GLOBAL_PARAMETERS._SIRKET_NO;
            BTM_FIRMA_NAME.Caption = _GLOBAL_PARAMETERS._SIRKET_KODU;
            DateTime _IVDATE = DateTime.Now;
            DateTime dt = DateTime.Now;
            BTN_START_DATE.EditValue = _IVDATE.AddDays(-10).ToString("dd.MM.yyyy").ToString();// DateTime.Parse(myReader["UBLExtensionObjectSigningTime"].ToString ()).GetDateTimeFormats('d',  _GLOBAL_PARAMETERS.cultures);
            BTN_BITIS_TARIHI.EditValue = _IVDATE.ToString("dd.MM.yyyy").ToString();//DateTime.Parse(myReader["UBLExtensionObjectSigningTime"].ToString ()).GetDateTimeFormats('d',  _GLOBAL_PARAMETERS.cultures); 


            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                myConnection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    string HEADER_TABLE_SQL = "select MAX(UBLExtensionObjectSigningTime) as UBLExtensionObjectSigningTime from dbo.FTR_GELEN_FATURALAR  where SIRKET_KODU=@SIRKET_KODU";
                    cmd.CommandText = HEADER_TABLE_SQL;
                    cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    cmd.Connection = myConnection;
                    SqlDataReader myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        if (myReader["UBLExtensionObjectSigningTime"] != DBNull.Value) { dt = DateTime.Parse(myReader["UBLExtensionObjectSigningTime"].ToString()); }

                        // DateTime dt = DateTime.Parse(_IVDATE.ToString("dd.MM.yyyy").ToString());
                        BTN_START_DATE.EditValue = dt.AddDays(-10).ToString("dd.MM.yyyy").ToString();// DateTime.Parse(myReader["UBLExtensionObjectSigningTime"].ToString ()).GetDateTimeFormats('d',  _GLOBAL_PARAMETERS.cultures);
                        BTN_BITIS_TARIHI.EditValue = _IVDATE.ToString("dd.MM.yyyy").ToString();//DateTime.Parse(myReader["UBLExtensionObjectSigningTime"].ToString ()).GetDateTimeFormats('d',  _GLOBAL_PARAMETERS.cultures); 
                    }
                    myReader.Close();
                }
            }

            DATA_LOAD(CMB_DURUM.EditValue.ToString());
        }
        void alertControl1_ButtonDownChanged(object sender,
        AlertButtonDownChangedEventArgs e)
        {
            if (e.ButtonName == "buttonOpen")
            {
                //...
            }
        }

        void alertControl1_ButtonClick(object sender, AlertButtonClickEventArgs e)
        {
            if (e.ButtonName == "buttonAlert")
            {
                //...
            }
        }

        WebService.IziBizSrv.REQUEST_HEADERType htype { get; set; }
        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
        private void BTN_GUNCELLE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DATA_LOAD(CMB_DURUM.EditValue.ToString());
        }


        private void DATA_LOAD(string FATURA_DURUMU)
        {

            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {


                string SQL = "";
                if (BTN_YIL.EditValue.ToString() == "TÜMÜ")
                { SQL = " Select  * , ISNULL(ONAY_COUNT/NULLIF(ONAY_STEP,0),0) * 100 AS ONAY_PROG From dbo.FTR_GELEN_FATURALAR where SIRKET_KODU=@SIRKET_KODU AND FATURA_TIPI='E'  "; }
                else
                { SQL = " Select  * , ISNULL(ONAY_COUNT/NULLIF(ONAY_STEP,0),0) * 100 AS ONAY_PROG From dbo.FTR_GELEN_FATURALAR where SIRKET_KODU=@SIRKET_KODU AND FATURA_TIPI='E'  AND (YEAR(IssueDate) = '" + BTN_YIL.EditValue.ToString() + "') "; }


                //if (CMB_DURUM.EditValue.ToString() == "Tümü") ;
                if (CMB_DURUM.EditValue.ToString() == "Cevaplanmayan Faturalar") SQL += " and FATURA_DURUMU IS NULL  ";
                if (CMB_DURUM.EditValue.ToString() == "Kabul Edilenler") SQL += " and FATURA_DURUMU='KABUL' ";
                if (CMB_DURUM.EditValue.ToString() == "Red Edilenler") SQL += " and FATURA_DURUMU='RED' ";



                //  string SQL = " Select  * , ISNULL(ONAY_COUNT/NULLIF(ONAY_STEP,0),0) * 100 AS ONAY_PROG From dbo.FTR_GELEN_FATURALAR where SIRKET_KODU=@SIRKET_KODU AND FATURA_TIPI='E' ";// cast((ONAY_COUNT /ONAY_STEP) *100 as float) as ONAY_PROG, 
                //                if (CMB_DURUM.EditValue.SelectedIndex == 0)
                //                {
                //                    SQL = @" Select  * , ISNULL(ONAY_COUNT/NULLIF(ONAY_STEP,0),0) * 100 AS ONAY_PROG From GIBGELEN_{0}_{1} 
                //                                      Where OID not in 
                //                                        (SELECT GIBID FROM [dbo].[LOGO_FATURA_{0}_{1}] Where LOGOREF>0) ORDER BY dbo.GIBGELEN_{0}_{1}.UBLExtensionObjectSigningTime Desc";
                //                }
                //                else if (cmbFatDrm.SelectedIndex == 1)
                //                {

                //                    SQL = @" Select * From GIBGELEN_{0}_{1} 
                //                                      Where OID not in 
                //                                        (SELECT GIBID FROM [dbo].[LOGO_FATURA_{0}_{1}] Where LOGOREF>0) and 
                //                                            GIBGELEN_{0}_{1}.OID  in (select GIBID from HAREKET_{0}_{1}  Where  HAREKETTIP=" + '0' + " and PARAMETRELER='KABUL' )";
                //                }
                //                else if (cmbFatDrm.SelectedIndex == 2)
                //                {
                //                    SQL = @" Select * From GIBGELEN_{0}_{1} 
                //                                      Where OID not in 
                //                                        (SELECT GIBID FROM [dbo].[LOGO_FATURA_{0}_{1}] Where LOGOREF>0) and 
                //                                            GIBGELEN_{0}_{1}.OID  in (select GIBID from HAREKET_{0}_{1}  Where  HAREKETTIP=" + '0' + " and PARAMETRELER='RED' )";
                //                }
                //                else
                //                {
                //                    SQL = @" Select * From GIBGELEN_{0}_{1} 
                //                                      Where OID not in 
                //                                        (SELECT GIBID FROM [dbo].[LOGO_FATURA_{0}_{1}] Where LOGOREF>0)";
                //                }

                //  string INVOICE_TABLE_SQL = string.Format(SQL, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), "01");
                SqlCommand cmd1 = myConnection.CreateCommand();
                cmd1.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                // cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = SQL;
                SqlDataAdapter deMaster = new SqlDataAdapter(cmd1);
                DataSet ds = new DataSet();
                deMaster.Fill(ds, "FTR_ALIM_FATURALARI");
                gridCntrl_LISTS.DataSource = ds.Tables["FTR_ALIM_FATURALARI"];
                myConnection.Close();
            }
        }

        int FATURA_SAYACI = 0;
        private void BTN_GIB_FATURA_INDIR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime dt = new DateTime();
            DateTime Nv = DateTime.Now;

            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                myConnection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    string HEADER_TABLE_SQL = "select LastDownInvDate from dbo.ADM_SIRKET_DONEMLERI WHERE SIRKET_KODU=@SIRKET_KODU and SIRKET_NO=@SIRKET_NO ";
                    cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    cmd.Parameters.AddWithValue("@SIRKET_NO", _GLOBAL_PARAMETERS._SIRKET_NO.ToString());
                    cmd.CommandText = HEADER_TABLE_SQL;
                    cmd.Connection = myConnection;
                    SqlDataReader myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        dt = Convert.ToDateTime(myReader["LastDownInvDate"]);
                    }
                    myReader.Close();
                }
            }

            BTM_SON_INDIRME_SAATI.Caption = dt.ToShortTimeString();


            if (dt.Date < Nv.Date)
            {
                FATURA_SAYACI = 0;
                for (int ix = 0; ix <= 100; ix++)
                {
                    if (INEN_FATURA_SAYISI != -1)
                    {
                        BR_PROGRESS_BAR.EditValue = 0;
                        re_PROGRESS_BAR.Maximum = 100;
                        BR_PROGRESS_BAR.Refresh();
                        BR_PROGRESS_BAR.Reset();
                        GIB_FATURA_INDIR();
                    }
                }
            }

            if (dt.Date == Nv.Date)
            {
                if (dt.Hour + 1 <= Nv.Hour)
                {
                    FATURA_SAYACI = 0;
                    for (int ix = 0; ix <= 100; ix++)
                    {
                        if (INEN_FATURA_SAYISI != -1)
                        {
                            BR_PROGRESS_BAR.EditValue = 0;
                            re_PROGRESS_BAR.Maximum = 100;
                            BR_PROGRESS_BAR.Refresh();
                            BR_PROGRESS_BAR.Reset();
                            GIB_FATURA_INDIR();
                        }
                    }
                }
                else
                {
                    int KalanSure = dt.Hour + 3 - Nv.Hour;
                    MessageBox.Show("Fatura indirme süresi henüz dolmadı Kalan süre :(" + KalanSure.ToString() + ") Saat");
                }
            }

        }


        private void GIB_FATURA_INDIR()
        {
            if (VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID == "" || VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID == null) VISION.FINANS.UBL.IZIBIZ_CLASS.izibiz_login();
            if (VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID != "")
            {
                VISION.FINANS.UBL.IZIBIZ_CLASS.Config();
                FATURALARI_GIBDEN_AL();
                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                {
                    myConnection.Open();
                    //using (SqlCommand cmd = new SqlCommand())
                    //{
                    //string HEADER_TABLE_SQL = "select MAX(UBLExtensionObjectSigningTime) as UBLExtensionObjectSigningTime from dbo.FTR_GELEN_FATURALAR WHERE SIRKET_KODU=@SIRKET_KODU ";
                    //cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    //cmd.CommandText = HEADER_TABLE_SQL;
                    //cmd.Connection = myConnection;
                    //SqlDataReader myReader = cmd.ExecuteReader();
                    //while (myReader.Read())
                    //{
                    using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                    {
                        SqlCommand myCommand = new SqlCommand();
                        myCommand.Parameters.AddWithValue("@LastDownInvDate", DateTime.Now);
                        myCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                        myCommand.Parameters.AddWithValue("@SIRKET_NO", _GLOBAL_PARAMETERS._SIRKET_NO.ToString());
                        myCommand.Connection = con;
                        myCommand.CommandText = "  Update dbo.ADM_SIRKET_DONEMLERI   Set LastDownInvDate=@LastDownInvDate  Where SIRKET_KODU=@SIRKET_KODU and SIRKET_NO=@SIRKET_NO";
                        con.Open();
                        myCommand.ExecuteNonQuery();
                        myCommand.Connection.Close();
                    }
                    //}
                    //myReader.Close();
                    //}
                }
                DATA_LOAD(CMB_DURUM.EditValue.ToString());
            }
        }
        public void FATURALARI_GIBDEN_AL()
        {

            using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string YENIFATURA = "Update   dbo.FTR_GELEN_FATURALAR  set   FATURA_YENI=0 WHERE SIRKET_KODU=@SIRKET_KODU and FATURA_YENI=1";
                SqlCommand myCommand = new SqlCommand();
                myCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                myCommand.Connection = con;
                myCommand.CommandText = YENIFATURA;
                con.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();
            }

            // WebService.IziBizSrv.GetInvoiceRequest  
            VISION.FINANS.UBL.Parameters prm = new VISION.FINANS.UBL.Parameters();
            DateTime _INVDATE = DateTime.Now;
            WebService.IziBizSrv.GetInvoiceRequestINVOICE_SEARCH_KEY keys = new WebService.IziBizSrv.GetInvoiceRequestINVOICE_SEARCH_KEY();
            //if (OkunmuslardaGelsin)
            //{
            //    keys.START_DATE = BasT;
            //    keys.END_DATE = BitT;
            //}
            //else
            //{

            int SURE_GUN = Convert.ToInt16(BR_SURE.EditValue.ToString());
            //keys.START_DATE = DateTime.Parse(VISION.FINANS.UBL.IZIBIZ_CLASS.Cfg["LastDownInvDate"].ToString()).AddDays(-30);
            //keys.END_DATE = DateTime.Parse(VISION.FINANS.UBL.IZIBIZ_CLASS.Cfg["LastDownInvDate"].ToString()).AddDays(250);

            keys.START_DATE = DateTime.Parse(BTN_BITIS_TARIHI.EditValue.ToString()).AddDays(-SURE_GUN);   // DateTime.Parse("2014-04-30");
            keys.END_DATE = DateTime.Parse(BTN_BITIS_TARIHI.EditValue.ToString());// DateTime.Parse("2030-01-01");
            //}


            keys.LIMIT = (byte)255;//Limit;
            keys.RECEIVER = VISION.FINANS.UBL.IZIBIZ_CLASS.Cfg["VKN"].ToString();//"1234567808";

            if (BR_FATURA_DURUMU.EditValue.ToString() == "Okunmadı") { keys.READ_INCLUDED = false; keys.READ_INCLUDEDSpecified = false; }
            if (BR_FATURA_DURUMU.EditValue.ToString() == "Okundu") { keys.READ_INCLUDED = true; keys.READ_INCLUDEDSpecified = true; }




            //keys.READ_INCLUDED = false;
            //keys.READ_INCLUDEDSpecified = false;
            keys.START_DATESpecified = true;
            keys.END_DATESpecified = true;
            keys.LIMITSpecified = true;
            keys.DIRECTION = "IN";
            prm.keys = keys;
            //prm.Mark = true; 


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
            WebService.IziBizSrv.GetInvoiceRequest girq = new WebService.IziBizSrv.GetInvoiceRequest();

            //   TimeSpan ts = (Tools.Gnl.GetDate - Data.CFG.Cfg.SonGetInv);
            //if (Math.Abs(ts.TotalMinutes) <= 5)
            //    throw new Exception(" Faturaları  sorgulama 5 dk da bir yapılabilmektedir. ");

            //if (!IsLogin)
            //    if (!login().Sonuc)
            //        return rs;

            //htype.CHANGE_INFO = new IziBizSrv.CHANGE_INFOType();
            //htype.CHANGE_INFO.CDATE = DateTime.Now;
            //htype.CHANGE_INFO.UDATE = DateTime.Now;

            girq.REQUEST_HEADER = htype;
            girq.INVOICE_SEARCH_KEY = keys;

            VISION.FINANS.UBL.Response rs = new VISION.FINANS.UBL.Response();
            rs.Invs = VISION.FINANS.UBL.IZIBIZ_CLASS.I2IEInv.GetInvoice(girq);

            WebService.IziBizSrv.MarkInvoiceRequest req = new WebService.IziBizSrv.MarkInvoiceRequest();
            req.REQUEST_HEADER = htype;
            req.MARK = new WebService.IziBizSrv.MarkInvoiceRequestMARK();
            List<WebService.IziBizSrv.INVOICE> lst = new List<WebService.IziBizSrv.INVOICE>();
            //string appPath = Path.GetDirectoryName(Application.ExecutablePath);

            string appPath = _GLOBAL_PARAMETERS._FILE_PATH;
            string pKok = appPath + @"_INBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU;
            //if (!Directory.Exists(pKok))
            //    Directory.CreateDirectory(pKok); 
            re_PROGRESS_BAR.Maximum = rs.Invs.Length;
            if (rs.Invs.Length == 0)
                INEN_FATURA_SAYISI = -1;
            else
                INEN_FATURA_SAYISI = rs.Invs.Length;

            FATURA_SAYACI += INEN_FATURA_SAYISI;
            foreach (WebService.IziBizSrv.INVOICE inv in rs.Invs)
            {

                BR_PROGRESS_BAR.EditValue = Convert.ToInt32(BR_PROGRESS_BAR.EditValue) + re_PROGRESS_BAR.Step;
                BR_PROGRESS_BAR.Refresh();
                lst.Add(new WebService.IziBizSrv.INVOICE()
                {
                    ID = inv.ID,
                    UUID = inv.UUID
                });

                string fl = pKok + "\\" + inv.ID + "_" + inv.UUID + ".xml";
                if (File.Exists(fl))
                    File.Delete(fl);
                File.WriteAllBytes(fl, inv.CONTENT.Value);

                string KONTROL = "";
                using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string HEADER_TABLE_SQL = " Select * From dbo.FTR_GELEN_FATURALAR Where SIRKET_KODU=@SIRKET_KODU and  ID=@ID and UUID=@UUID";
                        cmd.CommandText = HEADER_TABLE_SQL;
                        cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                        cmd.Parameters.AddWithValue("@ID", inv.ID);
                        cmd.Parameters.AddWithValue("@UUID", inv.UUID);
                        cmd.Connection = con;
                        SqlDataReader myReader = cmd.ExecuteReader();
                        while (myReader.Read())
                        {
                            KONTROL = "VAR";

                            req.MARK.INVOICE = lst.ToArray();
                            req.MARK.value = new WebService.IziBizSrv.MarkInvoiceRequestMARKValue();
                            req.MARK.value = WebService.IziBizSrv.MarkInvoiceRequestMARKValue.READ;
                            WebService.IziBizSrv.MarkInvoiceResponse rrsp = VISION.FINANS.UBL.IZIBIZ_CLASS.I2IEInv.MarkInvoice(req);
                        }
                        myReader.Close();
                    }
                }

                if (KONTROL == "")
                {
                    //string fl = pKok + "\\" + inv.ID + "_" + inv.UUID + ".xml";
                    //if (File.Exists(fl))
                    //    File.Delete(fl);
                    //File.WriteAllBytes(fl, inv.CONTENT.Value);

                    SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                    string HEADER_TABLE_EMPTY_SQL = @" Select top 0 * From dbo.FTR_GELEN_FATURALAR ";
                    string LINE_TABLE_SQL = @" Select top 0 * From dbo.FTR_GELEN_FATURALAR_DETAYI ";
                    HEADER_TABLE_EMPTY_SQL = string.Format(HEADER_TABLE_EMPTY_SQL, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), "01");
                    LINE_TABLE_SQL = string.Format(LINE_TABLE_SQL, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), "01");
                    SqlCommand cmd1 = myConnection.CreateCommand();
                    SqlCommand cmd2 = myConnection.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd2.CommandType = CommandType.Text;
                    cmd1.CommandText = HEADER_TABLE_EMPTY_SQL;
                    cmd2.CommandText = LINE_TABLE_SQL;// "Select AnalysisID as ID, Name, Level, Error From ElementResults Order By Name";

                    //define sql adapters
                    SqlDataAdapter deMaster = new SqlDataAdapter(cmd1);
                    SqlDataAdapter daDetails = new SqlDataAdapter(cmd2);
                    DataSet ds = new DataSet();
                    deMaster.Fill(ds, "Header");
                    daDetails.Fill(ds, "LINE");
                    #region xmlToObj
                    UBL.InvoiceType invx = new UBL.InvoiceType();

                    String strFile = File.ReadAllText(fl);
                    strFile = strFile.Replace("applicationxml", "application/xml");
                    File.WriteAllText(fl, strFile);


                    System.IO.StreamReader file = new System.IO.StreamReader(fl);

                    System.Xml.Serialization.XmlSerializer srlz = new System.Xml.Serialization.XmlSerializer(typeof(UBL.InvoiceType));
                    invx = (UBL.InvoiceType)srlz.Deserialize(file);
                    file.Close();
                    file.Dispose();
                    file = null;
                    DataRow newHeaderRow = ds.Tables["Header"].NewRow();
                    newHeaderRow["UBLVersionID"] = invx.UBLVersionID.Value;
                    newHeaderRow["CustomizationID"] = invx.CustomizationID.Value;
                    newHeaderRow["ProfileID"] = invx.ProfileID.Value;
                    newHeaderRow["ID"] = invx.ID.Value;
                    newHeaderRow["CopyIndicator"] = invx.CopyIndicator.Value;
                    newHeaderRow["UUID"] = invx.UUID.Value;
                    newHeaderRow["IssueDate"] = invx.IssueDate.Value.Date.ToString("yyyy.MM.dd");
                    newHeaderRow["InvoiceTypeCode"] = invx.InvoiceTypeCode.Value;
                    if (invx.Note != null && invx.Note.Length > 0)
                    {
                        newHeaderRow["Note"] = invx.Note[0] == null ? "" : invx.Note[0].Value;

                        for (int x = 0; x <= invx.Note.Length - 1; x++)
                            newHeaderRow["FATURA_TXT"] += " " + invx.Note[x].Value;
                    }

                    newHeaderRow["LineCountNumeric"] = invx.LineCountNumeric.Value;
                    newHeaderRow["DocumentCurrencyCode"] = invx.DocumentCurrencyCode.Value;
                    #endregion

                    #region UBLExtensions
                    if (invx.UBLExtensions != null)
                    {
                        foreach (UBL.UBLExtensionsType ue in invx.UBLExtensions)
                        {
                            if (ue.UBLExtension != null && ue.UBLExtension.ExtensionContent != null && ue.UBLExtension.ExtensionContent.Signature != null)
                            {
                                UBL.SignatureType1 sig = ue.UBLExtension.ExtensionContent.Signature;

                                if (sig.Object != null)
                                {
                                    foreach (UBL.ObjectType sobj in sig.Object)
                                    {
                                        foreach (System.Xml.XmlNode nod in sobj.Any)
                                        {
                                            string xNod = nod.InnerXml.Replace("xades:", "");

                                            try
                                            {
                                                int st = xNod.IndexOf("<SigningTime>");
                                                if (st > -1)
                                                {
                                                    int end = xNod.IndexOf("</SigningTime>");

                                                    string trh = xNod.Substring(st, end - st);
                                                    trh = trh.Replace("<SigningTime>", "").Replace("</SigningTime>", "");
                                                    newHeaderRow["UBLExtensionObjectSigningTime"] = DateTime.Parse(trh);
                                                }
                                                //  else
                                                // Tools.LogYaz("imza tarihi nod : " + nod.InnerXml);
                                            }
                                            catch (Exception ee)
                                            {
                                                //  Tools.LogYaz(ee + "\n" + xNod);
                                            }

                                        }

                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region xslt
                    if (invx.AdditionalDocumentReference != null)
                    {
                        foreach (UBL.DocumentReferenceType docr in invx.AdditionalDocumentReference)
                        {
                            if (docr.Attachment != null && docr.Attachment.EmbeddedDocumentBinaryObject != null)
                            {
                                UBL.EmbeddedDocumentBinaryObjectType BOBJ = docr.Attachment.EmbeddedDocumentBinaryObject;

                                if (BOBJ.filename.IndexOf(".xslt") > -1 || (docr.DocumentType != null && docr.DocumentType.Value.ToUpper().IndexOf("XSLT") > -1))
                                {
                                    //  appPath = Path.GetDirectoryName(Application.ExecutablePath);
                                    appPath = _GLOBAL_PARAMETERS._FILE_PATH;
                                    string mov = appPath + @"_INBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU;
                                    if (BOBJ.Value != null)
                                    {
                                        string ss = System.Convert.ToBase64String(BOBJ.Value);
                                        byte[] by = System.Convert.FromBase64String(ss);
                                        File.WriteAllBytes(mov + "\\" + invx.ID.Value + "_" + invx.UUID.Value + ".xslt", by);
                                        //BOBJ.Value
                                    }
                                }

                            }
                        }
                    }
                    #endregion

                    #region ekbelgeler
                    if (invx.AdditionalDocumentReference != null)
                    {
                        foreach (UBL.DocumentReferenceType doc in invx.AdditionalDocumentReference)
                        {
                            newHeaderRow["AdditionalDocumentID"] = doc.ID.Value;
                            newHeaderRow["AdditionalDocumentIssueDate"] = doc.IssueDate.Value;
                            //gl.AdditionalDocumentObj = doc.Attachment.EmbeddedDocumentBinaryObject.Value;
                        }
                    }
                    #endregion

                    #region signatür
                    foreach (UBL.SignatureType sg in invx.Signature)
                    {
                        newHeaderRow["SignatureSchemeID"] = sg.ID.Value;

                        foreach (UBL.PartyIdentificationType pid in sg.SignatoryParty.PartyIdentification)
                            newHeaderRow["SignatureSignatoryPartyIdentificationSchemeID"] = pid.ID.Value;

                        UBL.AddressType ad = sg.SignatoryParty.PostalAddress;
                        newHeaderRow["SignatureSignatoryPartyPostalAddressRoom"] = ad.Room == null ? "" : ad.Room.Value;
                        newHeaderRow["SignatureSignatoryPartyPostalAddressStreetName"] = ad.StreetName == null ? "" : ad.StreetName.Value;
                        newHeaderRow["SignatureSignatoryPartyPostalAddressBuildingName"] = ad.BuildingName == null ? "" : ad.BuildingName.Value;
                        newHeaderRow["SignatureSignatoryPartyPostalAddressBuildingNumber"] = ad.BuildingNumber == null ? "" : ad.BuildingNumber.Value;
                        newHeaderRow["SignatureSignatoryPartyPostalAddressCitySubdivisionName"] = ad.CitySubdivisionName == null ? "" : ad.CitySubdivisionName.Value;
                        newHeaderRow["SignatureSignatoryPartyPostalAddressCityName"] = ad.CityName == null ? "" : ad.CityName.Value;
                        newHeaderRow["SignatureSignatoryPartyPostalAddressPostalZone"] = ad.PostalZone == null ? "" : ad.PostalZone.Value;
                        newHeaderRow["SignatureSignatoryPartyPostalAddressRegion"] = ad.Region == null ? "" : ad.Region.Value;
                        newHeaderRow["SignatureSignatoryPartyPostalAddressCountryName"] = ad.Country == null ? "" : ad.Country.Name.Value;
                        newHeaderRow["SignatureDigitalSignatureAttachmentURI"] = sg.DigitalSignatureAttachment == null ? "" : (sg.DigitalSignatureAttachment.ExternalReference == null ? "" : sg.DigitalSignatureAttachment.ExternalReference.URI.Value);

                    }
                    #endregion

                    #region satıcı bilgileri
                    UBL.PartyType prt = invx.AccountingSupplierParty.Party;

                    newHeaderRow["AccSupplierPartyWebsiteURI"] = prt.WebsiteURI == null ? "" : prt.WebsiteURI.Value;
                 //   newHeaderRow["AccSupplierPartyName"] = prt.PartyName.Name.Value == null ? "" : prt.PartyName.Name.Value; //= prt.PartyName.Name.Value;

                    foreach (UBL.PartyIdentificationType pi in prt.PartyIdentification)
                    {
                        if (pi.ID.schemeID.IndexOf("VKN") > -1)
                            newHeaderRow["AccSupplierPartyIdentificationSchemeID"] = pi.ID.Value;
                    }


                    //if (invx.Note != null && invx.Note.Length > 0)
                    //    newHeaderRow["Note"] = invx.Note[0] == null ? "" : invx.Note[0].Value;


                    if (prt.PartyName == null)
                        DevExpress.XtraEditors.XtraMessageBox.Show("  Satıcı bilgilerinden FirmaAdı alanı eksik (PartyName)\nFNO :" + newHeaderRow["ID"], "Dikkat..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Dlg.Bilgi(" Satıcı bilgilerinden FirmaAdı alanı eksik (PartyName)\nFNO :" + newHeaderRow["ID"]);
                    else
                        newHeaderRow["AccSupplierPartyName"] = prt.PartyName.Name.Value;

                    if (prt.PartyTaxScheme == null || prt.PartyTaxScheme.TaxScheme == null)
                        DevExpress.XtraEditors.XtraMessageBox.Show(" Satıcı bilgilerinden VergiNo alanı eksik (TaxScheme)\nFNO :" + newHeaderRow["ID"], "Dikkat..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //  Dlg.Bilgi(" Satıcı bilgilerinden VergiNo alanı eksik (TaxScheme)\nFNO :" + newHeaderRow["ID"]);                       
                    else
                        newHeaderRow["AccSupplierPartyTaxSchemeName"] = prt.PartyTaxScheme.TaxScheme.Name.Value;
                    //gl.AccSupplierPartyTaxSchemeCode = prt.PartyTaxScheme.TaxScheme.TaxTypeCode.Value;

                    if (prt.Contact != null)
                    {
                        newHeaderRow["AccSupplierPartyContactTelephone"] = prt.Contact.Telephone == null ? "" : prt.Contact.Telephone.Value;
                        newHeaderRow["AccSupplierPartyContactTelefax"] = prt.Contact.Telefax == null ? "" : prt.Contact.Telefax.Value;
                        newHeaderRow["AccSupplierPartyContactElectronicMail"] = prt.Contact.ElectronicMail == null ? "" : prt.Contact.ElectronicMail.Value;
                    }

                    if (prt.PostalAddress != null)
                    {
                        UBL.AddressType add = prt.PostalAddress;
                        newHeaderRow["AccSupplierPartyPostalAddressRoom"] = add.Room == null ? "" : add.Room.Value;
                        newHeaderRow["AccSupplierPartyPostalAddressStreetName"] = add.StreetName == null ? "" : add.StreetName.Value;
                        newHeaderRow["AccSupplierPartyPostalAddressBuildingName"] = add.BuildingName == null ? "" : add.BuildingName.Value;
                        newHeaderRow["AccSupplierPartyPostalAddressBuildingNumber"] = add.BuildingNumber == null ? "" : add.BuildingNumber.Value;
                        newHeaderRow["AccSupplierPartyPostalAddressCitySubdivisionName"] = add.CitySubdivisionName == null ? "" : add.CitySubdivisionName.Value;
                        newHeaderRow["AccSupplierPartyPostalAddressCityName"] = add.CityName == null ? "" : add.CityName.Value;
                        newHeaderRow["AccSupplierPartyPostalAddressPostalZone"] = add.PostalZone == null ? "" : add.PostalZone.Value;
                        newHeaderRow["AccSupplierPartyPostalAddressRegion"] = add.Region == null ? "" : add.Region.Value;
                        newHeaderRow["AccSupplierPartyPostalAddressCountryName"] = add.Country == null ? "" : (add.Country.Name == null ? "" : add.Country.Name.Value);
                    }

                    #endregion

                    #region Alıcı bilgileri
                    UBL.PartyType pp = invx.AccountingCustomerParty.Party;

                    newHeaderRow["AccCustomerPartyWebsiteURI"] = (pp.WebsiteURI == null || pp.WebsiteURI.Value == null) ? "" : pp.WebsiteURI.Value;

                    foreach (UBL.PartyIdentificationType pii in pp.PartyIdentification)
                    {
                        if (pii.ID.schemeID.IndexOf("VKN") > -1)
                            newHeaderRow["AccCustomerPartyIdentificationSchemeID"] = pii.ID.Value;
                    }

                    //if (pp.PartyName == null)
                    //    DevExpress.XtraEditors.XtraMessageBox.Show("  Satıcı bilgilerinden FirmaAdı alanı eksik (PartyName)\nFNO :" + newHeaderRow["ID"], "Dikkat..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ////Dlg.Bilgi("Alıcı bilgilerinden FirmaAdı bilgisi eksik...(PartyName)\nFNO : " + newHeaderRow["ID"]);
                    //else
                    newHeaderRow["AccCustomerPartyName"] = pp.PartyName == null ? "" : pp.PartyName.Name.Value; /// pp.PartyName.Name.Value;


                    //if (pp.PartyTaxScheme == null || pp.PartyTaxScheme.TaxScheme == null)
                    //{
                    //    DevExpress.XtraEditors.XtraMessageBox.Show("  Satıcı bilgilerinden FirmaAdı alanı eksik (TaxScheme)\nFNO :" + newHeaderRow["ID"], "Dikkat..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    //Dlg.Bilgi("Alıcı bilgilerinde FirmaVergiNo bilgisi eksik ....(TaxScheme)\nFNO : " + newHeaderRow["ID"]);
                    //}
                    //else
                    //{
                    if (pp.PartyTaxScheme != null)
                    {

                        newHeaderRow["AccCustomerPartyTaxSchemeName"] = pp.PartyTaxScheme.TaxScheme.Name == null ? "" : pp.PartyTaxScheme.TaxScheme.Name.Value;
                    }
                    else
                    {
                        newHeaderRow["AccCustomerPartyTaxSchemeName"] = "";
                    }


                    //gl.AccCustomerPartyTaxSchemeCode = prt.PartyTaxScheme.TaxScheme.TaxTypeCode.Value;

                    if (pp.Contact != null)
                    {
                        newHeaderRow["AccCustomerPartyContactTelephone"] = pp.Contact.Telephone == null ? "" : pp.Contact.Telephone.Value;
                        newHeaderRow["AccCustomerPartyContactTelefax"] = pp.Contact.Telefax == null ? "" : pp.Contact.Telefax.Value;
                        newHeaderRow["AccCustomerPartyContactElectronicMail"] = pp.Contact.ElectronicMail == null ? "" : pp.Contact.ElectronicMail.Value;
                    }

                    if (pp.PostalAddress != null)
                    {
                        UBL.AddressType adr = pp.PostalAddress;
                        newHeaderRow["AccCustomerPartyPostalAddressRoom"] = adr.Room == null ? "" : adr.Room.Value;
                        newHeaderRow["AccCustomerPartyPostalAddressStreetName"] = adr.StreetName == null ? "" : adr.StreetName.Value;
                        newHeaderRow["AccCustomerPartyPostalAddressBuildingName"] = adr.BuildingName == null ? "" : adr.BuildingName.Value;
                        newHeaderRow["AccCustomerPartyPostalAddressBuildingNumber"] = adr.BuildingNumber == null ? "" : adr.BuildingNumber.Value;
                        newHeaderRow["AccCustomerPartyPostalAddressCitySubdivisionName"] = adr.CitySubdivisionName == null ? "" : adr.CitySubdivisionName.Value;
                        newHeaderRow["AccCustomerPartyPostalAddressCityName"] = adr.CityName == null ? "" : adr.CityName.Value;
                        newHeaderRow["AccCustomerPartyPostalAddressPostalZone"] = adr.PostalZone == null ? "" : adr.PostalZone.Value;
                        newHeaderRow["AccCustomerPartyPostalAddressRegion"] = adr.Region == null ? "" : adr.Region.Value;
                        newHeaderRow["AccCustomerPartyPostalAddressCountryName"] = adr.Country == null ? "" : (adr.Country.Name == null ? "" : adr.Country.Name.Value);
                    }

                    #endregion

                    newHeaderRow["FATURA_TXT"] += " " + newHeaderRow["AccCustomerPartyPostalAddressBuildingName"].ToString();
                    newHeaderRow["FATURA_TXT"] += " " + newHeaderRow["AccCustomerPartyPostalAddressStreetName"].ToString();

                    #region payment

                    if (invx.PaymentMeans != null)
                    {
                        foreach (UBL.PaymentMeansType pay in invx.PaymentMeans)
                        {
                            newHeaderRow["PaymentMeansCode"] = pay.PaymentMeansCode.Value;
                        }
                    }

                    if (invx.PaymentTerms != null && invx.PaymentTerms.Note != null)
                        newHeaderRow["PaymentTermsNote"] = invx.PaymentTerms.Note.Value;

                    #endregion
                    #region indirim

                    if (invx.AllowanceCharge != null)
                    {
                        if (invx.AllowanceCharge.ChargeIndicator != null)
                            newHeaderRow["AllowanceChargeChargeIndicator"] = invx.AllowanceCharge.ChargeIndicator.Value;

                        if (invx.AllowanceCharge.Amount != null)
                        {
                            newHeaderRow["AllowanceChargeAmount"] = invx.AllowanceCharge.Amount.Value;
                            newHeaderRow["AllowanceChargeAmountCurrencyID"] = invx.AllowanceCharge.Amount.currencyID.ToString();
                        }

                        if (invx.AllowanceCharge.MultiplierFactorNumeric != null)
                            newHeaderRow["AllowanceChargeMultiplierFactorNumeric"] = invx.AllowanceCharge.MultiplierFactorNumeric.Value;
                    }
                    #endregion

                    #region vergiler
                    foreach (UBL.TaxTotalType tax in invx.TaxTotal)
                    {
                        newHeaderRow["TaxTotalTaxAmount"] = tax.TaxAmount.Value;
                        newHeaderRow["TaxTotalTaxAmountCurrencyID"] = tax.TaxAmount.currencyID.ToString();

                        foreach (UBL.TaxSubtotalType taxsub in tax.TaxSubtotal)
                        {
                            newHeaderRow["TaxSubtotalPercent"] = taxsub.Percent == null ? 0 : taxsub.Percent.Value;
                            if (taxsub.TaxableAmount != null)
                            {
                                UBL.TaxableAmountType tbla = taxsub.TaxableAmount;
                                newHeaderRow["TaxSubtotalTaxableAmount"] = tbla.Value;
                                newHeaderRow["TaxSubtotalTaxableAmountCurrencyID"] = tbla.currencyID.ToString();
                            }

                            //if (taxsub.TaxAmount == null)
                            //    throw new Exception("TaxSubTotal -> TaxAmount boş olamaz zorunlu alan.");

                            newHeaderRow["TaxSubtotalTaxAmount"] = taxsub.TaxAmount == null ? 0 : taxsub.TaxAmount.Value;
                            newHeaderRow["TaxSubtotalTaxAmountCurrencyID"] = taxsub.TaxAmount == null ? "" : taxsub.TaxAmount.currencyID.ToString();


                            if (taxsub.TaxCategory != null)
                            {
                                if (taxsub.TaxCategory.TaxScheme != null)
                                {
                                    newHeaderRow["TaxSubtotalTaxCategoryTaxSchemeCode"] = taxsub.TaxCategory.TaxScheme.TaxTypeCode == null ? "" : taxsub.TaxCategory.TaxScheme.TaxTypeCode.Value;
                                    newHeaderRow["TaxSubtotalTaxCategoryTaxSchemeName"] = taxsub.TaxCategory.TaxScheme.Name == null ? "" : taxsub.TaxCategory.TaxScheme.Name.Value;
                                }
                            }
                        }
                    }
                    #endregion

                    #region tutarlar
                    if (invx.LegalMonetaryTotal.AllowanceTotalAmount != null)
                        newHeaderRow["LegalMonetaryAllowanceTotalAmount"] = invx.LegalMonetaryTotal.AllowanceTotalAmount.Value;

                    newHeaderRow["LegalMonetaryPayableAmount"] = invx.LegalMonetaryTotal.PayableAmount.Value;
                    newHeaderRow["LegalMonetaryTaxExclusiveAmount"] = invx.LegalMonetaryTotal.TaxExclusiveAmount.Value;
                    newHeaderRow["LegalMonetaryTaxInclusiveAmount"] = invx.LegalMonetaryTotal.TaxInclusiveAmount.Value;
                    newHeaderRow["LegalMonetaryLineExtensionAmount"] = invx.LegalMonetaryTotal.LineExtensionAmount.Value;
                    #endregion

                    ds.Tables["Header"].Rows.Add(newHeaderRow);

                    #region Satırlar
                    foreach (UBL.InvoiceLineType ln in invx.InvoiceLine)
                    {


                        DataRow newLineRow = ds.Tables["LINE"].NewRow();

                        newLineRow["InvoiceLineID"] = ln.ID.Value;
                        newLineRow["InvoiceLineInvoicedQuantity"] = ln.InvoicedQuantity.Value;
                        newLineRow["InvoiceLineInvoicedQuantityUnitCode"] = ln.InvoicedQuantity.unitCode.ToString();
                        newLineRow["InvoiceLineLineExtensionAmountCurrencyID"] = ln.LineExtensionAmount.currencyID.ToString();
                        newLineRow["InvoiceLineLineExtensionAmount"] = ln.LineExtensionAmount.Value;
                        newLineRow["InvoiceLineItemName"] = ln.Item.Name.Value;
                        newHeaderRow["FATURA_TXT"] += " " + ln.Item.Name.Value;
                        newLineRow["InvoiceLinePriceAmountCurrencyID"] = ln.Price.PriceAmount.currencyID.ToString();
                        newLineRow["InvoiceLinePriceAmountPrice"] = ln.Price.PriceAmount.Value;

                        #region vergiler

                        if (ln.TaxTotal != null)
                        {
                            if (ln.TaxTotal.TaxAmount != null)
                            {
                                newLineRow["InvoiceLineTaxAmountCurrencyID"] = ln.TaxTotal.TaxAmount.currencyID.ToString();
                                newLineRow["InvoiceLineTaxAmount"] = ln.TaxTotal.TaxAmount.Value;
                            }

                            foreach (UBL.TaxSubtotalType taxsb in ln.TaxTotal.TaxSubtotal)
                            {
                                newLineRow["InvoiceLineTaxAmountCurrencyID"] = taxsb.TaxAmount.currencyID.ToString();
                                newLineRow["InvoiceLineTaxAmount"] = taxsb.TaxAmount.Value;

                                if (taxsb.Percent != null)
                                    newLineRow["InvoiceLineTaxSubtotalPercent"] = taxsb.Percent.Value;

                                if (taxsb.TaxCategory != null && taxsb.TaxCategory.TaxScheme != null)
                                {
                                    newLineRow["InvoiceLineTaxSubtotalTaxCategoryTaxSchemeName"] = taxsb.TaxCategory.TaxScheme.Name == null ? "" : taxsb.TaxCategory.TaxScheme.Name.Value;
                                    newLineRow["InvoiceLineTaxSubtotalTaxCategoryTaxSchemeCode"] = taxsb.TaxCategory.TaxScheme.TaxTypeCode == null ? "" : taxsb.TaxCategory.TaxScheme.TaxTypeCode.Value;
                                }
                            }
                        }

                        #endregion

                        #region indirim
                        if (ln.AllowanceCharge != null)
                        {
                            UBL.AllowanceChargeType ind = ln.AllowanceCharge;
                            newLineRow["InvoiceLineAllowanceChargeChargeIndicator"] = ind.ChargeIndicator == null ? false : ind.ChargeIndicator.Value;
                            newLineRow["InvoiceLineAllowanceChargeMultiplierFactorNumeric"] = ind.MultiplierFactorNumeric == null ? decimal.Parse("0") : ind.MultiplierFactorNumeric.Value;

                            if (ind.Amount != null)
                            {
                                newLineRow["InvoiceLineAllowanceChargeAmountCurrencyID"] = ind.Amount.currencyID.ToString();
                                newLineRow["InvoiceLineAllowanceChargeAmount"] = ind.Amount.Value;
                            }
                        }
                        #endregion
                        ds.Tables["LINE"].Rows.Add(newLineRow);
                    }
                    #endregion

                    //string FATURA_HABER = _FATURA_TURU_KONTROL(newHeaderRow["SignatureSchemeID"].ToString(), newHeaderRow["InvoiceTypeCode"].ToString());

                    //string[] OitemCode = FATURA_HABER.ToString().Split('|');
                    //newHeaderRow["FATURA_TURU"] = OitemCode[0].ToString();
                    //newHeaderRow["TO_MAIL_ADRESS"] = OitemCode[1].ToString();

                    //newHeaderRow["MUSTERI_KODU"] = "";
                    //using (SqlConnection myConnections = new SqlConnection(Masters._CONNECTIONSTRING_MDB))
                    //{
                    //    myConnections.Open();
                    //    SqlCommand myCommands = new SqlCommand();
                    //    myCommands.Connection = myConnections;
                    //    myCommands.CommandText = "SELECT  *  from dbo.ADM_FATURA_YONLENDIRME where  FIRMA='" + Masters._SIRKET_NO.ToString() + "'";
                    //    SqlDataReader sqlreaders = myCommands.ExecuteReader(CommandBehavior.CloseConnection);
                    //    while (sqlreaders.Read())
                    //    {
                    //        int sonuc = newHeaderRow["FATURA_TXT"].ToString().IndexOf(sqlreaders["ARAMA_KODU"].ToString());
                    //        if (sonuc != -1)
                    //        {
                    //            newHeaderRow["MUSTERI_KODU"] = sqlreaders["MUSTERI_KODU"].ToString();
                    //            newHeaderRow["MUSTERI_GRUBU"] = sqlreaders["MUSTERI_GRUBU"].ToString();
                    //            break;
                    //        }
                    //    }
                    //    sqlreaders.Close();
                    //    myCommands.Connection.Close();
                    //    myConnections.Close();
                    //} 


                    //DataView dtview = new DataView(ds.Tables["Header"]);
                    //dtview.Sort = " IssueDate DESC ";//, FIELD2 DESC ";
                    //DataTable dtsorted = dtview.ToTable();
                    //_INVDATE = DateTime.Parse(dtsorted.Rows[0]["IssueDate"].ToString());

                    string PLAN_KODU_KONTROL = "";
                    string PLAN_KODU = "";
                    string MUSTERI_KODU = "";
                    //if (invx.Note != null && invx.Note.Length > 0)
                    //{
                    //    for (int x = 0; x <= invx.Note.Length - 1; x++)
                    //    {

                    //        if (invx.Note[x].Value == null) break;

                    //        int kontrol = invx.Note[x].Value.ToString().IndexOf("MEDPLAN KODU");
                    //        if (kontrol != -1)
                    //        {
                    //            PLAN_KODU_KONTROL = invx.Note[x].Value.ToString();  //newHeaderRow["FATURA_TXT"].ToString().Substring(kontrol, 50);


                    //            string[] Ones = PLAN_KODU_KONTROL.ToString().Split(':');
                    //            PLAN_KODU = Ones[1].ToString().Trim() ;

                    //               //for (int X = 0; X <= Ones.Length - 1; X++)
                    //               //{
                    //               //    char[] karakterler = Ones[X].Trim().ToString().ToCharArray();

                    //               //    for (int i = 1; i <= karakterler.Length - 1; i++)
                    //               //    {
                    //               //        if (karakterler[i].ToString() != ")")
                    //               //        { PLAN_KODU += karakterler[i].ToString(); }
                    //               //        else
                    //               //        { break; }
                    //               //    }
                    //               //} 

                    //           // break;
                    //        }


                    //    }

                    //}  



                    //int kontrol = newHeaderRow["FATURA_TXT"].ToString().IndexOf("Plan Kodu");
                    //if (kontrol != -1)
                    //{
                    //        int kontro = newHeaderRow["FATURA_TXT"].ToString().IndexOf("Plan Kodu");
                    //        if (kontro != -1)
                    //        {

                    //        }

                    //    PLAN_KODU = newHeaderRow["FATURA_TXT"].ToString().Substring(kontrol, 50);
                    //    break;
                    //}






                    using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                    {

                        string SQL = " SELECT  CASE  WHEN  SUBSTRING ( SUBSTRING ( PLAN_KODU ,0 , CHARINDEX('.', PLAN_KODU)) ,0 , CHARINDEX('_', PLAN_KODU))='' " +
                          "       THEN SUBSTRING ( PLAN_KODU ,0 , CHARINDEX('.', PLAN_KODU)) ELSE SUBSTRING ( SUBSTRING ( PLAN_KODU ,0 , CHARINDEX('.', PLAN_KODU)) ,0 , CHARINDEX('_', PLAN_KODU)) end as MUSTERI_KODU ," +
                          "       PLAN_KODU " +
                          " FROM dbo.FTR_LG_STLINE  where PLAN_KODU IS not null  group by PLAN_KODU order by PLAN_KODU desc ";
                        myConnections.Open();
                        SqlCommand myCommands = new SqlCommand();
                        myCommands.Connection = myConnections;
                        myCommands.CommandText = SQL;
                        SqlDataReader sqlreaders = myCommands.ExecuteReader(CommandBehavior.CloseConnection);
                        while (sqlreaders.Read())
                        {
                            int sonuc = newHeaderRow["FATURA_TXT"].ToString().IndexOf(sqlreaders["PLAN_KODU"].ToString());
                            if (sonuc != -1)
                            {
                                MUSTERI_KODU = sqlreaders["MUSTERI_KODU"].ToString();
                                //  newHeaderRow["MUSTERI_GRUBU"] = sqlreaders["MUSTERI_GRUBU"].ToString();
                                PLAN_KODU = sqlreaders["PLAN_KODU"].ToString();
                                break;
                            }
                        }
                        sqlreaders.Close();
                        myCommands.Connection.Close();
                        myConnections.Close();
                    }





                    SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                    myConnectionTable.Open();
                    int OIID = 0;
                    Guid g = Guid.NewGuid();



                    var GUID = "";
                    for (int index = 0; index < ds.Tables["Header"].Rows.Count; index++)
                    {
                        OIID = 0; GUID = "";
                        dr = ds.Tables["Header"].Rows[index];



                        using (SqlCommand cmd = new SqlCommand())
                        {
                            string HEADER_TABLE_SQL = " INSERT INTO dbo.FTR_GELEN_FATURALAR (GUID, FATURA_TIPI,SIRKET_KODU,UBLVersionID, CustomizationID, ProfileID, ID, CopyIndicator, UUID, IssueDate, InvoiceTypeCode, Note, DocumentCurrencyCode, LineCountNumeric, DespatchDocumentID, DespatchDocumentIssueDate, OrderReferenceID, OrderReferenceIssueDate, AdditionalDocumentID, AdditionalDocumentIssueDate, AdditionalDocumentEncode, AdditionalDocumentCharacterSetCode, AdditionalDocumentFileName, SignatureSchemeID, SignatureSignatoryPartyIdentificationSchemeID, SignatureSignatoryPartyPostalAddressRoom, SignatureSignatoryPartyPostalAddressStreetName, SignatureSignatoryPartyPostalAddressBuildingName, SignatureSignatoryPartyPostalAddressBuildingNumber, SignatureSignatoryPartyPostalAddressCitySubdivisionName, SignatureSignatoryPartyPostalAddressCityName, SignatureSignatoryPartyPostalAddressPostalZone, SignatureSignatoryPartyPostalAddressRegion, SignatureSignatoryPartyPostalAddressCountryName, SignatureDigitalSignatureAttachmentURI, AccSupplierPartyWebsiteURI, AccSupplierPartyIdentificationSchemeID, AccSupplierPartyName, AccSupplierPartyPostalAddressRoom, AccSupplierPartyPostalAddressStreetName, AccSupplierPartyPostalAddressBuildingName, AccSupplierPartyPostalAddressBuildingNumber, AccSupplierPartyPostalAddressCitySubdivisionName, AccSupplierPartyPostalAddressCityName, AccSupplierPartyPostalAddressRegion, AccSupplierPartyPostalAddressPostalZone, AccSupplierPartyPostalAddressCountryName, AccSupplierPartyTaxSchemeName, AccSupplierPartyTaxSchemeCode, AccSupplierPartyContactTelephone, AccSupplierPartyContactTelefax, AccSupplierPartyContactElectronicMail, AccCustomerPartyWebsiteURI, AccCustomerPartyIdentificationSchemeID, AccCustomerPartyName, AccCustomerPartyPostalAddressRoom, AccCustomerPartyPostalAddressBuildingName, AccCustomerPartyPostalAddressStreetName, AccCustomerPartyPostalAddressRegion, AccCustomerPartyPostalAddressBuildingNumber, AccCustomerPartyPostalAddressCitySubdivisionName, AccCustomerPartyPostalAddressCityName, AccCustomerPartyPostalAddressPostalZone, AccCustomerPartyPostalAddressCountryName, AccCustomerPartyTaxSchemeName, AccCustomerPartyTaxSchemeCode, AccCustomerPartyContactTelephone, AccCustomerPartyContactTelefax, AccCustomerPartyContactElectronicMail, PaymentMeansCode, PaymentMeansDueDate, PaymentMeansPayeeFinancialAccountID, PaymentMeansPayeeFinancialAccountCurrencyCode, PaymentMeansPayeeFinancialAccountPaymentNote, PaymentTermsNote, AllowanceChargeChargeIndicator, AllowanceChargeMultiplierFactorNumeric, AllowanceChargeAmountCurrencyID, AllowanceChargeAmount, TaxTotalTaxAmountCurrencyID, TaxTotalTaxAmount, TaxSubtotalTaxableAmountCurrencyID, TaxSubtotalTaxableAmount, TaxSubtotalTaxAmountCurrencyID, TaxSubtotalTaxAmount, TaxSubtotalPercent, TaxSubtotalTaxCategoryTaxSchemeName, TaxSubtotalTaxCategoryTaxSchemeCode, LegalMonetaryLineExtensionAmount, LegalMonetaryTaxExclusiveAmount, LegalMonetaryTaxInclusiveAmount, LegalMonetaryAllowanceTotalAmount, LegalMonetaryPayableAmount, UBLExtensionObjectSigningTime, PCount, FATURA_TXT,MUSTERI_KODU,MUSTERI_GRUBU,FATURA_TURU,MECRA_TURU,MECRA_ADI,FATURA_YENI,PLAN_KODU)  " +
                                                                    " Values (@GUID,@FATURA_TIPI,@SIRKET_KODU,@UBLVersionID,@CustomizationID,@ProfileID,@ID,@CopyIndicator,@UUID,@IssueDate,@InvoiceTypeCode,@Note,@DocumentCurrencyCode,@LineCountNumeric,@DespatchDocumentID,@DespatchDocumentIssueDate,@OrderReferenceID,@OrderReferenceIssueDate,@AdditionalDocumentID,@AdditionalDocumentIssueDate,@AdditionalDocumentEncode,@AdditionalDocumentCharacterSetCode,@AdditionalDocumentFileName,@SignatureSchemeID,@SignatureSignatoryPartyIdentificationSchemeID,@SignatureSignatoryPartyPostalAddressRoom,@SignatureSignatoryPartyPostalAddressStreetName,@SignatureSignatoryPartyPostalAddressBuildingName,@SignatureSignatoryPartyPostalAddressBuildingNumber,@SignatureSignatoryPartyPostalAddressCitySubdivisionName,@SignatureSignatoryPartyPostalAddressCityName,@SignatureSignatoryPartyPostalAddressPostalZone,@SignatureSignatoryPartyPostalAddressRegion,@SignatureSignatoryPartyPostalAddressCountryName,@SignatureDigitalSignatureAttachmentURI,@AccSupplierPartyWebsiteURI,@AccSupplierPartyIdentificationSchemeID,@AccSupplierPartyName,@AccSupplierPartyPostalAddressRoom,@AccSupplierPartyPostalAddressStreetName,@AccSupplierPartyPostalAddressBuildingName,@AccSupplierPartyPostalAddressBuildingNumber,@AccSupplierPartyPostalAddressCitySubdivisionName,@AccSupplierPartyPostalAddressCityName,@AccSupplierPartyPostalAddressRegion,@AccSupplierPartyPostalAddressPostalZone,@AccSupplierPartyPostalAddressCountryName,@AccSupplierPartyTaxSchemeName,@AccSupplierPartyTaxSchemeCode,@AccSupplierPartyContactTelephone,@AccSupplierPartyContactTelefax,@AccSupplierPartyContactElectronicMail,@AccCustomerPartyWebsiteURI,@AccCustomerPartyIdentificationSchemeID,@AccCustomerPartyName,@AccCustomerPartyPostalAddressRoom,@AccCustomerPartyPostalAddressBuildingName,@AccCustomerPartyPostalAddressStreetName,@AccCustomerPartyPostalAddressRegion,@AccCustomerPartyPostalAddressBuildingNumber,@AccCustomerPartyPostalAddressCitySubdivisionName,@AccCustomerPartyPostalAddressCityName,@AccCustomerPartyPostalAddressPostalZone,@AccCustomerPartyPostalAddressCountryName,@AccCustomerPartyTaxSchemeName,@AccCustomerPartyTaxSchemeCode,@AccCustomerPartyContactTelephone,@AccCustomerPartyContactTelefax,@AccCustomerPartyContactElectronicMail,@PaymentMeansCode,@PaymentMeansDueDate,@PaymentMeansPayeeFinancialAccountID,@PaymentMeansPayeeFinancialAccountCurrencyCode,@PaymentMeansPayeeFinancialAccountPaymentNote,@PaymentTermsNote,@AllowanceChargeChargeIndicator,@AllowanceChargeMultiplierFactorNumeric,@AllowanceChargeAmountCurrencyID,@AllowanceChargeAmount,@TaxTotalTaxAmountCurrencyID,@TaxTotalTaxAmount,@TaxSubtotalTaxableAmountCurrencyID,@TaxSubtotalTaxableAmount,@TaxSubtotalTaxAmountCurrencyID,@TaxSubtotalTaxAmount,@TaxSubtotalPercent,@TaxSubtotalTaxCategoryTaxSchemeName,@TaxSubtotalTaxCategoryTaxSchemeCode,@LegalMonetaryLineExtensionAmount,@LegalMonetaryTaxExclusiveAmount,@LegalMonetaryTaxInclusiveAmount,@LegalMonetaryAllowanceTotalAmount,@LegalMonetaryPayableAmount,@UBLExtensionObjectSigningTime,@PCount, @FATURA_TXT,@MUSTERI_KODU,@MUSTERI_GRUBU,@FATURA_TURU,@MECRA_TURU,@MECRA_ADI,@FATURA_YENI,@PLAN_KODU)" +
                                                                    "  SELECT @@IDENTITY AS ID   ";
                            cmd.CommandText = HEADER_TABLE_SQL;
                            cmd.Parameters.AddWithValue("@GUID", g);
                            cmd.Parameters.AddWithValue("@FATURA_TIPI", 'E');
                            cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                            cmd.Parameters.AddWithValue("@UBLVersionID", dr["UBLVersionID"]);
                            cmd.Parameters.AddWithValue("@CustomizationID", dr["CustomizationID"]);
                            cmd.Parameters.AddWithValue("@ProfileID", dr["ProfileID"]);
                            cmd.Parameters.AddWithValue("@ID", dr["ID"]);
                            cmd.Parameters.AddWithValue("@CopyIndicator", dr["CopyIndicator"]);
                            cmd.Parameters.AddWithValue("@UUID", dr["UUID"]);
                            cmd.Parameters.AddWithValue("@IssueDate", dr["IssueDate"]);
                            cmd.Parameters.AddWithValue("@InvoiceTypeCode", dr["InvoiceTypeCode"]);
                            cmd.Parameters.AddWithValue("@Note", dr["Note"]);
                            cmd.Parameters.AddWithValue("@DocumentCurrencyCode", dr["DocumentCurrencyCode"]);
                            cmd.Parameters.AddWithValue("@LineCountNumeric", dr["LineCountNumeric"]);
                            cmd.Parameters.AddWithValue("@DespatchDocumentID", dr["DespatchDocumentID"]);
                            cmd.Parameters.AddWithValue("@DespatchDocumentIssueDate", dr["DespatchDocumentIssueDate"]);
                            cmd.Parameters.AddWithValue("@OrderReferenceID", dr["OrderReferenceID"]);
                            cmd.Parameters.AddWithValue("@OrderReferenceIssueDate", dr["OrderReferenceIssueDate"]);
                            cmd.Parameters.AddWithValue("@AdditionalDocumentID", dr["ID"]);// dr["AdditionalDocumentID"]);
                            cmd.Parameters.AddWithValue("@AdditionalDocumentIssueDate", dr["AdditionalDocumentIssueDate"]);
                            cmd.Parameters.AddWithValue("@AdditionalDocumentEncode", dr["AdditionalDocumentEncode"]);
                            cmd.Parameters.AddWithValue("@AdditionalDocumentCharacterSetCode", dr["AdditionalDocumentCharacterSetCode"]);
                            cmd.Parameters.AddWithValue("@AdditionalDocumentFileName", dr["AdditionalDocumentFileName"]);
                            cmd.Parameters.AddWithValue("@SignatureSchemeID", dr["SignatureSchemeID"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyIdentificationSchemeID", dr["SignatureSignatoryPartyIdentificationSchemeID"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressRoom", dr["SignatureSignatoryPartyPostalAddressRoom"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressStreetName", dr["SignatureSignatoryPartyPostalAddressStreetName"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressBuildingName", dr["SignatureSignatoryPartyPostalAddressBuildingName"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressBuildingNumber", dr["SignatureSignatoryPartyPostalAddressBuildingNumber"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressCitySubdivisionName", dr["SignatureSignatoryPartyPostalAddressCitySubdivisionName"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressCityName", dr["SignatureSignatoryPartyPostalAddressCityName"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressPostalZone", dr["SignatureSignatoryPartyPostalAddressPostalZone"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressRegion", dr["SignatureSignatoryPartyPostalAddressRegion"]);
                            cmd.Parameters.AddWithValue("@SignatureSignatoryPartyPostalAddressCountryName", dr["SignatureSignatoryPartyPostalAddressCountryName"]);
                            cmd.Parameters.AddWithValue("@SignatureDigitalSignatureAttachmentURI", dr["SignatureDigitalSignatureAttachmentURI"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyWebsiteURI", dr["AccSupplierPartyWebsiteURI"]);

                            if (dr["AccSupplierPartyIdentificationSchemeID"] == DBNull.Value || dr["AccSupplierPartyIdentificationSchemeID"].ToString() == "")
                            {
                                cmd.Parameters.AddWithValue("@AccSupplierPartyIdentificationSchemeID", dr["SignatureSchemeID"]);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@AccSupplierPartyIdentificationSchemeID", dr["AccSupplierPartyIdentificationSchemeID"]);
                            }

                            //cmd.Parameters.AddWithValue("@AccSupplierPartyIdentificationSchemeID", dr["AccSupplierPartyIdentificationSchemeID"] == null ? dr["SignatureSchemeID"] : dr["AccSupplierPartyIdentificationSchemeID"]);


                            cmd.Parameters.AddWithValue("@AccSupplierPartyName", dr["AccSupplierPartyName"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressRoom", dr["AccSupplierPartyPostalAddressRoom"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressStreetName", dr["AccSupplierPartyPostalAddressStreetName"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressBuildingName", dr["AccSupplierPartyPostalAddressBuildingName"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressBuildingNumber", dr["AccSupplierPartyPostalAddressBuildingNumber"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressCitySubdivisionName", dr["AccSupplierPartyPostalAddressCitySubdivisionName"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressCityName", dr["AccSupplierPartyPostalAddressCityName"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressRegion", dr["AccSupplierPartyPostalAddressRegion"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressPostalZone", dr["AccSupplierPartyPostalAddressPostalZone"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyPostalAddressCountryName", dr["AccSupplierPartyPostalAddressCountryName"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyTaxSchemeName", dr["AccSupplierPartyTaxSchemeName"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyTaxSchemeCode", dr["AccSupplierPartyTaxSchemeCode"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyContactTelephone", dr["AccSupplierPartyContactTelephone"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyContactTelefax", dr["AccSupplierPartyContactTelefax"]);
                            cmd.Parameters.AddWithValue("@AccSupplierPartyContactElectronicMail", dr["AccSupplierPartyContactElectronicMail"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyWebsiteURI", dr["AccCustomerPartyWebsiteURI"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyIdentificationSchemeID", dr["AccCustomerPartyIdentificationSchemeID"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyName", dr["AccCustomerPartyName"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressRoom", dr["AccCustomerPartyPostalAddressRoom"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressBuildingName", dr["AccCustomerPartyPostalAddressBuildingName"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressStreetName", dr["AccCustomerPartyPostalAddressStreetName"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressRegion", dr["AccCustomerPartyPostalAddressRegion"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressBuildingNumber", dr["AccCustomerPartyPostalAddressBuildingNumber"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressCitySubdivisionName", dr["AccCustomerPartyPostalAddressCitySubdivisionName"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressCityName", dr["AccCustomerPartyPostalAddressCityName"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressPostalZone", dr["AccCustomerPartyPostalAddressPostalZone"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyPostalAddressCountryName", dr["AccCustomerPartyPostalAddressCountryName"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyTaxSchemeName", dr["AccCustomerPartyTaxSchemeName"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyTaxSchemeCode", dr["AccCustomerPartyTaxSchemeCode"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyContactTelephone", dr["AccCustomerPartyContactTelephone"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyContactTelefax", dr["AccCustomerPartyContactTelefax"]);
                            cmd.Parameters.AddWithValue("@AccCustomerPartyContactElectronicMail", dr["AccCustomerPartyContactElectronicMail"]);
                            cmd.Parameters.AddWithValue("@PaymentMeansCode", dr["PaymentMeansCode"]);
                            cmd.Parameters.AddWithValue("@PaymentMeansDueDate", dr["PaymentMeansDueDate"]);
                            cmd.Parameters.AddWithValue("@PaymentMeansPayeeFinancialAccountID", dr["PaymentMeansPayeeFinancialAccountID"]);
                            cmd.Parameters.AddWithValue("@PaymentMeansPayeeFinancialAccountCurrencyCode", dr["PaymentMeansPayeeFinancialAccountCurrencyCode"]);
                            cmd.Parameters.AddWithValue("@PaymentMeansPayeeFinancialAccountPaymentNote", dr["PaymentMeansPayeeFinancialAccountPaymentNote"]);
                            cmd.Parameters.AddWithValue("@PaymentTermsNote", dr["PaymentTermsNote"]);
                            cmd.Parameters.AddWithValue("@AllowanceChargeChargeIndicator", dr["AllowanceChargeChargeIndicator"]);
                            cmd.Parameters.AddWithValue("@AllowanceChargeMultiplierFactorNumeric", dr["AllowanceChargeMultiplierFactorNumeric"]);
                            cmd.Parameters.AddWithValue("@AllowanceChargeAmountCurrencyID", dr["AllowanceChargeAmountCurrencyID"]);
                            cmd.Parameters.AddWithValue("@AllowanceChargeAmount", dr["AllowanceChargeAmount"]);
                            cmd.Parameters.AddWithValue("@TaxTotalTaxAmountCurrencyID", dr["TaxTotalTaxAmountCurrencyID"]);
                            cmd.Parameters.AddWithValue("@TaxTotalTaxAmount", dr["TaxTotalTaxAmount"]);
                            cmd.Parameters.AddWithValue("@TaxSubtotalTaxableAmountCurrencyID", dr["TaxSubtotalTaxableAmountCurrencyID"]);
                            cmd.Parameters.AddWithValue("@TaxSubtotalTaxableAmount", dr["TaxSubtotalTaxableAmount"]);
                            cmd.Parameters.AddWithValue("@TaxSubtotalTaxAmountCurrencyID", dr["TaxSubtotalTaxAmountCurrencyID"]);
                            cmd.Parameters.AddWithValue("@TaxSubtotalTaxAmount", dr["TaxSubtotalTaxAmount"]);
                            cmd.Parameters.AddWithValue("@TaxSubtotalPercent", dr["TaxSubtotalPercent"]);
                            cmd.Parameters.AddWithValue("@TaxSubtotalTaxCategoryTaxSchemeName", dr["TaxSubtotalTaxCategoryTaxSchemeName"]);
                            cmd.Parameters.AddWithValue("@TaxSubtotalTaxCategoryTaxSchemeCode", dr["TaxSubtotalTaxCategoryTaxSchemeCode"]);
                            cmd.Parameters.AddWithValue("@LegalMonetaryLineExtensionAmount", dr["LegalMonetaryLineExtensionAmount"]);
                            cmd.Parameters.AddWithValue("@LegalMonetaryTaxExclusiveAmount", dr["LegalMonetaryTaxExclusiveAmount"]);
                            cmd.Parameters.AddWithValue("@LegalMonetaryTaxInclusiveAmount", dr["LegalMonetaryTaxInclusiveAmount"]);
                            cmd.Parameters.AddWithValue("@LegalMonetaryAllowanceTotalAmount", dr["LegalMonetaryAllowanceTotalAmount"]);
                            cmd.Parameters.AddWithValue("@LegalMonetaryPayableAmount", dr["LegalMonetaryPayableAmount"]);
                            cmd.Parameters.AddWithValue("@UBLExtensionObjectSigningTime", dr["UBLExtensionObjectSigningTime"]);
                            cmd.Parameters.AddWithValue("@PCount", '0');
                            cmd.Parameters.AddWithValue("@FATURA_TXT", dr["FATURA_TXT"]);
                            cmd.Parameters.AddWithValue("@MUSTERI_KODU", MUSTERI_KODU);
                            cmd.Parameters.AddWithValue("@MUSTERI_GRUBU", dr["MUSTERI_GRUBU"]);
                            cmd.Parameters.AddWithValue("@FATURA_TURU", dr["FATURA_TURU"]);
                            cmd.Parameters.AddWithValue("@MECRA_TURU", dr["MECRA_TURU"]);
                            cmd.Parameters.AddWithValue("@MECRA_ADI", dr["MECRA_ADI"]);
                            cmd.Parameters.AddWithValue("@FATURA_YENI", '1');
                            cmd.Parameters.AddWithValue("@PLAN_KODU", PLAN_KODU);
                            cmd.Connection = myConnectionTable;
                            SqlDataReader myReader = cmd.ExecuteReader();
                            while (myReader.Read())
                            {
                                OIID = Convert.ToInt32(myReader["ID"].ToString());
                            }

                            myReader.Close();


                            //SendMail("to", "name", dr["ID"].ToString() + " Nolu fatura onayı ", dr["AccSupplierPartyName"].ToString(), dr["SignatureSchemeID"].ToString(), dr["IssueDate"].ToString(), dr["ID"].ToString(), dr["MUSTERI_KODU"].ToString(), dr["MUSTERI_GRUBU"].ToString(), dr["MECRA_TURU"].ToString(), dr["MECRA_ADI"].ToString(),
                            //    dr["TaxTotalTaxAmount"].ToString(), OIID.ToString(), dr["UUID"].ToString(), "teste", dr["UUID"].ToString());
                        }

                        //myConnectionTable.Open();
                        for (int inde = 0; inde < ds.Tables["LINE"].Rows.Count; inde++)
                        {
                            DataRow drx = ds.Tables["LINE"].Rows[inde];
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                string LINE_SQL = @" INSERT INTO dbo.FTR_GELEN_FATURALAR_DETAYI ( GUID,FATURA_TIPI, SIRKET_KODU,INVOICE_REF,  InvoiceLineID, InvoiceLineInvoicedQuantityUnitCode, InvoiceLineInvoicedQuantity, InvoiceLineLineExtensionAmountCurrencyID, InvoiceLineLineExtensionAmount, InvoiceLineAllowanceChargeChargeIndicator, InvoiceLineAllowanceChargeMultiplierFactorNumeric, InvoiceLineAllowanceChargeAmountCurrencyID, InvoiceLineAllowanceChargeAmount, InvoiceLineTaxTotalTaxAmountCurrencyID, InvoiceLineTaxTotalTaxAmount, InvoiceLineTaxAmountCurrencyID, InvoiceLineTaxAmount, InvoiceLineTaxSubtotalTaxAmountCurrencyID, InvoiceLineTaxSubtotalPercent, InvoiceLineTaxSubtotalTaxCategoryTaxSchemeName, InvoiceLineTaxSubtotalTaxCategoryTaxSchemeCode, InvoiceLineItemName, InvoiceLinePriceAmountCurrencyID, InvoiceLinePriceAmountPrice)  
                                                                             Values (@GUID,@FATURA_TIPI,@SIRKET_KODU,@INVOICE_REF,  @InvoiceLineID, @InvoiceLineInvoicedQuantityUnitCode, @InvoiceLineInvoicedQuantity, @InvoiceLineLineExtensionAmountCurrencyID, @InvoiceLineLineExtensionAmount, @InvoiceLineAllowanceChargeChargeIndicator, @InvoiceLineAllowanceChargeMultiplierFactorNumeric, @InvoiceLineAllowanceChargeAmountCurrencyID, @InvoiceLineAllowanceChargeAmount, @InvoiceLineTaxTotalTaxAmountCurrencyID, @InvoiceLineTaxTotalTaxAmount, @InvoiceLineTaxAmountCurrencyID, @InvoiceLineTaxAmount, @InvoiceLineTaxSubtotalTaxAmountCurrencyID, @InvoiceLineTaxSubtotalPercent, @InvoiceLineTaxSubtotalTaxCategoryTaxSchemeName, @InvoiceLineTaxSubtotalTaxCategoryTaxSchemeCode, @InvoiceLineItemName, @InvoiceLinePriceAmountCurrencyID, @InvoiceLinePriceAmountPrice)";


                                cmd.CommandText = LINE_SQL;
                                cmd.Parameters.AddWithValue("@GUID", g);
                                cmd.Parameters.AddWithValue("@FATURA_TIPI", 'E');
                                cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                                cmd.Parameters.AddWithValue("@INVOICE_REF", OIID);

                                cmd.Parameters.AddWithValue("@InvoiceLineID", drx["InvoiceLineID"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineInvoicedQuantityUnitCode", drx["InvoiceLineInvoicedQuantityUnitCode"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineInvoicedQuantity", drx["InvoiceLineInvoicedQuantity"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineLineExtensionAmountCurrencyID", drx["InvoiceLineLineExtensionAmountCurrencyID"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineLineExtensionAmount", drx["InvoiceLineLineExtensionAmount"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineAllowanceChargeChargeIndicator", drx["InvoiceLineAllowanceChargeChargeIndicator"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineAllowanceChargeMultiplierFactorNumeric", drx["InvoiceLineAllowanceChargeMultiplierFactorNumeric"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineAllowanceChargeAmountCurrencyID", drx["InvoiceLineAllowanceChargeAmountCurrencyID"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineAllowanceChargeAmount", drx["InvoiceLineAllowanceChargeAmount"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineTaxTotalTaxAmountCurrencyID", drx["InvoiceLineTaxTotalTaxAmountCurrencyID"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineTaxTotalTaxAmount", drx["InvoiceLineTaxTotalTaxAmount"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineTaxAmountCurrencyID", drx["InvoiceLineTaxAmountCurrencyID"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineTaxAmount", drx["InvoiceLineTaxAmount"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineTaxSubtotalTaxAmountCurrencyID", drx["InvoiceLineTaxSubtotalTaxAmountCurrencyID"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineTaxSubtotalPercent", drx["InvoiceLineTaxSubtotalPercent"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineTaxSubtotalTaxCategoryTaxSchemeName", drx["InvoiceLineTaxSubtotalTaxCategoryTaxSchemeName"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineTaxSubtotalTaxCategoryTaxSchemeCode", drx["InvoiceLineTaxSubtotalTaxCategoryTaxSchemeCode"]);
                                cmd.Parameters.AddWithValue("@InvoiceLineItemName", drx["InvoiceLineItemName"]);
                                cmd.Parameters.AddWithValue("@InvoiceLinePriceAmountCurrencyID", drx["InvoiceLinePriceAmountCurrencyID"]);
                                cmd.Parameters.AddWithValue("@InvoiceLinePriceAmountPrice", drx["InvoiceLinePriceAmountPrice"]);
                                cmd.Connection = myConnectionTable;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    myConnectionTable.Close();

                    req.MARK.INVOICE = lst.ToArray();
                    req.MARK.value = new WebService.IziBizSrv.MarkInvoiceRequestMARKValue();
                    req.MARK.value = WebService.IziBizSrv.MarkInvoiceRequestMARKValue.READ;
                    WebService.IziBizSrv.MarkInvoiceResponse rrsp = VISION.FINANS.UBL.IZIBIZ_CLASS.I2IEInv.MarkInvoice(req);
                }
            }

            //MessageBox.Show("( " + FATURA_SAY + " ) Adet Fatura indirildi.");
            BR_UPDATE_TIME.Caption = FATURA_SAYACI.ToString() + " Adet indirildi.";
            BTM_SON_INDIRME_SAATI.Caption = DateTime.Now.ToShortTimeString();
        }




        private void BTN_GIB_KABUL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FINANS.UBL.IZIBIZ_CLASS.SESSIONID == "" || FINANS.UBL.IZIBIZ_CLASS.SESSIONID == null) FINANS.UBL.IZIBIZ_CLASS.izibiz_login();
            if (FINANS.UBL.IZIBIZ_CLASS.SESSIONID != "")
            {
                DataRow dr = gridView_MASTERS.GetFocusedDataRow();

                if (dr == null) return;

                WebService.IziBizSrv.PrepareInvoiceResponseRequest req = new WebService.IziBizSrv.PrepareInvoiceResponseRequest();
                req.INVOICE = new WebService.IziBizSrv.INVOICE[1];
                req.INVOICE[0] = new WebService.IziBizSrv.INVOICE();
                req.INVOICE[0].UUID = dr["UUID"].ToString();
                req.STATUS = "KABUL";
                req.REQUEST_HEADER = FINANS.UBL.IZIBIZ_CLASS.htype;
                //hrk.SESSIONID = htype.SESSION_ID;
                //hrk.PARAMETRELER = prm.Texts[0]; 
                //hrk.HAREKETTIP = Data.PROGRAMISLEM.CevapGonder; 
                //hrk.GIBID = dr["ID"].ToString(); 
                WebService.IziBizSrv.base64Binary[] resp = FINANS.UBL.IZIBIZ_CLASS.I2IEInv.PrepareInvoiceResponse(req);
                if (resp == null || resp.Length < 1)
                {
                    //rs.Sonuc = false;
                    //rs.Mesaj = "herhangi bir sonuç dönmedi.";
                    //hrk.ACIKLAMA = rs.Mesaj;
                }

                WebService.IziBizSrv.SendInvoiceResponseRequest req1 = new WebService.IziBizSrv.SendInvoiceResponseRequest();
                req1.REQUEST_HEADER = FINANS.UBL.IZIBIZ_CLASS.htype;
                //req1.APPRESPONSE = new IziBizSrv.base64Binary[1];
                //req1.APPRESPONSE[0] = new IziBizSrv.base64Binary();
                //req1.APPRESPONSE[0].Value
                req1.APPRESPONSE = resp;
                WebService.IziBizSrv.SendInvoiceResponseResponse rrsp = FINANS.UBL.IZIBIZ_CLASS.I2IEInv.SendInvoiceResponse(req1);
                dr["FATURA_DURUMU"] = "KABUL";


                using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string _SQL = @" Update dbo.FTR_GELEN_FATURALAR set FATURA_DURUMU=@FATURA_DURUMU  where SIRKET_KODU=@SIRKET_KODU AND OID=@OID and UUID=@UUID";
                        cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                        cmd.Parameters.AddWithValue("@UUID", dr["UUID"].ToString());
                        cmd.Parameters.AddWithValue("@FATURA_DURUMU", "KABUL");
                        cmd.Parameters.AddWithValue("@OID", dr["OID"].ToString());
                        cmd.CommandText = _SQL;
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                    }
                }
                // gLib.Tools.Dlg.Bilgi("Sonuç : " + rs.Sonuc.ToString() + "\nMesaj : " + rs.Mesaj + "\nSESSIONID : " + rs.SESSIONID);
            }
        }

        private void BTN_GIB_RED_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dr = gridView_MASTERS.GetFocusedDataRow();
            if (dr == null) return;

            if (FINANS.UBL.IZIBIZ_CLASS.SESSIONID == "" || FINANS.UBL.IZIBIZ_CLASS.SESSIONID == null) FINANS.UBL.IZIBIZ_CLASS.izibiz_login();
            if (FINANS.UBL.IZIBIZ_CLASS.SESSIONID != "")
            {
                WebService.IziBizSrv.PrepareInvoiceResponseRequest req = new WebService.IziBizSrv.PrepareInvoiceResponseRequest();
                req.INVOICE = new WebService.IziBizSrv.INVOICE[1];
                req.INVOICE[0] = new WebService.IziBizSrv.INVOICE();
                req.INVOICE[0].UUID = dr["UUID"].ToString();
                req.STATUS = "RED";
                req.REQUEST_HEADER = FINANS.UBL.IZIBIZ_CLASS.htype;
                //hrk.SESSIONID = htype.SESSION_ID;
                //hrk.PARAMETRELER = prm.Texts[0]; 
                //hrk.HAREKETTIP = Data.PROGRAMISLEM.CevapGonder; 
                //hrk.GIBID = dr["ID"].ToString(); 
                WebService.IziBizSrv.base64Binary[] resp = FINANS.UBL.IZIBIZ_CLASS.I2IEInv.PrepareInvoiceResponse(req);

                if (resp == null || resp.Length < 1)
                {
                    //rs.Sonuc = false;
                    //rs.Mesaj = "herhangi bir sonuç dönmedi.";
                    //hrk.ACIKLAMA = rs.Mesaj;
                }
                WebService.IziBizSrv.SendInvoiceResponseRequest req1
                      = new WebService.IziBizSrv.SendInvoiceResponseRequest();
                req1.REQUEST_HEADER = FINANS.UBL.IZIBIZ_CLASS.htype;
                //req1.APPRESPONSE = new IziBizSrv.base64Binary[1];
                //req1.APPRESPONSE[0] = new IziBizSrv.base64Binary();
                //req1.APPRESPONSE[0].Value
                req1.APPRESPONSE = resp;
                WebService.IziBizSrv.SendInvoiceResponseResponse rrsp = FINANS.UBL.IZIBIZ_CLASS.I2IEInv.SendInvoiceResponse(req1);

                dr["FATURA_DURUMU"] = "RED";

                using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string _SQL = @" Update dbo.FTR_GELEN_FATURALAR set FATURA_DURUMU=@FATURA_DURUMU  where SIRKET_KODU=@SIRKET_KODU AND OID=@OID and UUID=@UUID";
                        cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                        cmd.Parameters.AddWithValue("@UUID", dr["UUID"].ToString());
                        cmd.Parameters.AddWithValue("@FATURA_DURUMU", "RED");
                        cmd.Parameters.AddWithValue("@OID", dr["OID"].ToString());
                        cmd.CommandText = _SQL;
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                    }
                }

                // gLib.Tools.Dlg.Bilgi("Sonuç : " + rs.Sonuc.ToString() + "\nMesaj : " + rs.Mesaj + "\nSESSIONID : " + rs.SESSIONID);
            }
        }

        private void BTN_REFRESH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FINANS.UBL.IZIBIZ_CLASS.SESSIONID == "" || FINANS.UBL.IZIBIZ_CLASS.SESSIONID == null) FINANS.UBL.IZIBIZ_CLASS.izibiz_login();
            if (FINANS.UBL.IZIBIZ_CLASS.SESSIONID != "")
            {
                FINANS.UBL.IZIBIZ_CLASS.Config();
                int[] selectedRows = gridView_MASTERS.GetSelectedRows();
                for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
                //for (int i = 0; i <= gridView_LIST.RowCount; i++)
                {
                    DataRow dr = gridView_MASTERS.GetDataRow(selectedRows[ix]);

                    if (dr == null) break;
                    try
                    {
                        WebService.IziBizSrv.GetInvoiceStatusRequest req = new WebService.IziBizSrv.GetInvoiceStatusRequest();
                        req.INVOICE = new WebService.IziBizSrv.INVOICE();
                        req.INVOICE.ID = dr["ID"].ToString();
                        req.INVOICE.UUID = dr["UUID"].ToString();


                        htype = new WebService.IziBizSrv.REQUEST_HEADERType();
                        htype.SESSION_ID = FINANS.UBL.IZIBIZ_CLASS.SESSIONID;
                        htype.CHANNEL_NAME = FINANS.UBL.IZIBIZ_CLASS.Cfg["ENTCHANNEL_NAME"].ToString();
                        htype.REASON = FINANS.UBL.IZIBIZ_CLASS.Cfg["ENTREASON"].ToString();
                        htype.HOSTNAME = System.Environment.MachineName;
                        htype.APPLICATION_NAME = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                        htype.COMPRESSED = "N";
                        htype.CLIENT_TXN_ID = FINANS.UBL.IZIBIZ_CLASS.Cfg["VKN"].ToString();
                        htype.ACTION_DATE = DateTime.Now;
                        htype.SIMULATION_FLAG = "";

                        req.REQUEST_HEADER = htype;//VISION.FINANS.UBL.IZIBIZ_CLASS.htype; 
                        var InvStatu = FINANS.UBL.IZIBIZ_CLASS.I2IEInv.GetInvoiceStatus(req);

                        if (InvStatu == null || InvStatu.INVOICE_STATUS == null) return;


                        string MESAJIM = "";
                        switch (InvStatu.INVOICE_STATUS.STATUS.ToString())
                        {

                            case "RECEIVE - SUCCEED":
                                MESAJIM = "Fatura Alımı - Başarıyla işlendi";
                                break;
                            case "RECEIVE - WAIT_APPLICATION_RESPONSE":
                                MESAJIM = "Fatura Alımı - Fatura Onayı Bekleniyor";
                                break;
                            case "ACCEPT - PROCESSING":
                                MESAJIM = "Gelen Ticari Fatura Kabul – İşleniyor";
                                break;
                            case "ACCEPT - WAIT_GIB_RESPONSE":
                                MESAJIM = "Gelen Ticari Fatura Kabul – GIB'e Gönderildi";
                                break;
                            case "ACCEPT - WAIT_SYSTEM_RESPONSE":
                                MESAJIM = "Gelen Ticari Fatura Kabul – Sistem Yanıtı Bekleniyor";
                                break;
                            case "ACCEPT - FAILED":
                                MESAJIM = "Gelen Ticari Fatura Kabul - Başarısız oldu";
                                break;
                            case "ACCEPT - SUCCEED":
                                MESAJIM = "Gelen Ticari Fatura Kabul - Başarıyla işlendi";
                                break;
                            case "REJECT - PROCESSING":
                                MESAJIM = "Gelen Ticari Fatura Red – İşleniyor";
                                break;
                            case "REJECT - WAIT_GIB_RESPONSE":
                                MESAJIM = "Gelen Ticari Fatura Red – GIB'e Gönderildi";
                                break;
                            case "REJECT - WAIT_SYSTEM_RESPONSE":
                                MESAJIM = "Gelen Ticari Fatura Red – Sistem Yanıtı Bekleniyor";
                                break;
                            case "REJECT - SUCCEED":
                                MESAJIM = "Gelen Ticari Fatura Red - Başarıyla işlendi";
                                break;
                            case "REJECT - FAILED":
                                MESAJIM = "Gelen Ticari Fatura Red - Başarısız oldu";
                                break;
                        }
                        if (InvStatu.INVOICE_STATUS.RESPONSE_CODE != null)
                        {

                            //    PARAMETRELER, ACIKLAMA, INVID, GIBID, LOGOID, ITEMID, TRNSID, SESSIONID, HAREKETTIP, ID, KULID, TARIH, FRM, BFAKISID, AFAKISID, GIBGID
                            using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                            {
                                con.Open();
                                DateTime myDTStart = Convert.ToDateTime(DateTime.Now);
                                string SQLINSERT = @" INSERT INTO  dbo.FTR_GIB_TRANSFER_DURUMU ( SIRKET_KODU,PARAMETRELER, MESAJ, ID, GID, TARIH) values ('{0}','{1}','{2}','{3}','{4}','{5}') ";
                                SQLINSERT = string.Format(SQLINSERT, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), InvStatu.INVOICE_STATUS.RESPONSE_CODE, InvStatu.INVOICE_STATUS.RESPONSE_DESCRIPTION, dr["ID"].ToString(), dr["UUID"].ToString(), myDTStart.ToString("yyyy-MM-dd").ToString());
                                using (SqlCommand cmd = new SqlCommand())
                                {
                                    cmd.CommandText = SQLINSERT;
                                    cmd.Connection = con;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        if (InvStatu.INVOICE_STATUS.GIB_STATUS_CODE != null)
                        {

                            using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                            {
                                con.Open();
                                DateTime myDTStart = Convert.ToDateTime(DateTime.Now);
                                string SQLINSERT = @" INSERT INTO   dbo.FTR_GIB_TRANSFER_DURUMU(SIRKET_KODU, PARAMETRELER, MESAJ, ID, GID, TARIH) values ('{0}','{1}','{2}','{3}','{4}','{5}') ";
                                SQLINSERT = string.Format(SQLINSERT, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), InvStatu.INVOICE_STATUS.GIB_STATUS_CODE, InvStatu.INVOICE_STATUS.GIB_STATUS_DESCRIPTION, dr["ID"].ToString(), dr["UUID"].ToString(), myDTStart.ToString("yyyy-MM-dd").ToString());
                                using (SqlCommand cmd = new SqlCommand())
                                {
                                    cmd.CommandText = SQLINSERT;
                                    cmd.Connection = con;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        if (InvStatu.INVOICE_STATUS.STATUS != null)
                        {

                            using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                            {
                                con.Open();
                                DateTime myDTStart = Convert.ToDateTime(DateTime.Now);
                                string SQLINSERT = @" INSERT INTO   dbo.FTR_GIB_TRANSFER_DURUMU (SIRKET_KODU, PARAMETRELER, MESAJ, ID, GID, TARIH) values ('{0}','{1}','{2}','{3}','{4}','{5}') ";
                                SQLINSERT = string.Format(SQLINSERT, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), InvStatu.INVOICE_STATUS.STATUS, InvStatu.INVOICE_STATUS.STATUS_DESCRIPTION, dr["ID"].ToString(), dr["UUID"].ToString(), myDTStart.ToString("yyyy-MM-dd").ToString());
                                using (SqlCommand cmd = new SqlCommand())
                                {
                                    cmd.CommandText = SQLINSERT;
                                    cmd.Connection = con;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }



                        using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                        {
                            con.Open();

                            using (SqlCommand cmd = new SqlCommand())
                            {
                                string LINE_SQL = @" Update dbo.FTR_GELEN_FATURALAR set FATURA_DURUMU=@FATURA_DURUMU  where SIRKET_KODU=@SIRKET_KODU AND ID=@ID and UUID=@UUID";
                                cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                                cmd.Parameters.AddWithValue("@UUID", dr["UUID"].ToString());
                                cmd.Parameters.AddWithValue("@FATURA_DURUMU", MESAJIM);
                                cmd.Parameters.AddWithValue("@ID", dr["ID"].ToString());
                                cmd.CommandText = LINE_SQL;
                                cmd.Connection = con;
                                cmd.ExecuteNonQuery();
                            }
                        }

                    }
                    catch (System.Web.Services.Protocols.SoapException ee)
                    {
                        string SQL = @" UPDATE FTR_GIB_TRANSFER SET ='{0}' Where SIRKET_KODU='{1}' and  ID='{2}' AND GID='{3}' ";
                        SQL = string.Format(SQL, ee.Message, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), dr["ID"].ToString(), dr["GID"].ToString());
                        using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                        {
                            myConnections.Open();
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.CommandText = SQL;
                                cmd.Connection = myConnections;
                                cmd.ExecuteNonQuery();
                            }
                        }

                    }
                }
            }
            DATA_LOAD(CMB_DURUM.EditValue.ToString());
        }

        private void BTN_YAZDIR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            YAZDIR();
        }

        private void YAZDIR()
        {
            int[] selectedRows = gridView_MASTERS.GetSelectedRows();
            for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
            {
                System.Threading.Thread.Sleep(400);
                string USERNAME = _GLOBAL_PARAMETERS._KULLANICI_ADI_SOYADI.Replace(".", "");
                if (File.Exists(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html")) File.Delete(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html");

                DataRow dr = gridView_MASTERS.GetDataRow(selectedRows[ix]);
                pnlControl_INVVIEW.Controls.Clear();
                string xmlfl = "", xsltfl = "";
                if (dr != null)
                {
                    BR_FILE.Caption = appPath + @"_INBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + "_" + dr["UUID"] + ".xml";
                    xmlfl = appPath + @"_INBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + "_" + dr["UUID"] + ".xml";
                    xsltfl = appPath + @"_INBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + "_" + dr["UUID"] + ".xslt";
                }

                if (xsltfl != "")
                {
                    if (File.Exists(xmlfl))
                    {
                        if (!File.Exists(xsltfl))
                        {
                            #region xmlToObj
                            UBL.InvoiceType invx = new UBL.InvoiceType();
                            System.IO.StreamReader file =
                               new System.IO.StreamReader(xmlfl);
                            System.Xml.Serialization.XmlSerializer srlz =
                               new System.Xml.Serialization.XmlSerializer(typeof(UBL.InvoiceType));
                            invx = (UBL.InvoiceType)srlz.Deserialize(file);
                            #endregion
                            #region xslt
                            if (invx.AdditionalDocumentReference != null)
                            {
                                foreach (UBL.DocumentReferenceType docr in invx.AdditionalDocumentReference)
                                {
                                    if (docr.Attachment != null && docr.Attachment.EmbeddedDocumentBinaryObject != null)
                                    {
                                        UBL.EmbeddedDocumentBinaryObjectType BOBJ = docr.Attachment.EmbeddedDocumentBinaryObject;
                                        //if (BOBJ.filename.IndexOf(".xslt") > -1 || (docr.DocumentType != null && docr.DocumentType.Value.ToUpper().IndexOf("XSLT") > -1))
                                        //{
                                        // string pKok = Gnl.WorkDirectory + "GELEN";
                                        // string mov = "\\TMP"; 
                                        if (BOBJ.Value != null)
                                        {
                                            string ss = System.Convert.ToBase64String(BOBJ.Value);
                                            byte[] by = System.Convert.FromBase64String(ss);
                                            File.WriteAllBytes(xsltfl, by);
                                        }
                                        //BOBJ.Value
                                        //}
                                    }
                                }
                            }
                            #endregion
                        }

                        try
                        {
                            System.Threading.Thread.Sleep(900);
                            //wbh.Url = null;
                            //wbh.Refresh();  
                            //XslCompiledTransform XSLT = new XslCompiledTransform();
                            //XsltSettings settings = new XsltSettings();
                            //settings.EnableScript = true;
                            //XSLT.Load(xsltfl, settings, new XmlUrlResolver());


                            XslCompiledTransform XSLT = new XslCompiledTransform(true);
                            XSLT.Load(
                                XmlReader.Create(xsltfl,
                                new XmlReaderSettings()
                                {
                                    DtdProcessing = DtdProcessing.Parse
                                }),
                                new XsltSettings(true, false),
                                new XmlUrlResolver()
                            );


                            XSLT.Transform(xmlfl, @"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html");
                            String appdir = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                            String myfile = Path.Combine(appdir, @"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html");
                            WaitPrint vv = new WaitPrint(myfile, ix);
                            vv.ShowDialog();
                            vv.Dispose();
                        }
                        catch
                        {

                            System.Threading.Thread.Sleep(900);
                            XslCompiledTransform XSLT = new XslCompiledTransform();
                            XsltSettings settings = new XsltSettings();
                            settings.EnableScript = true;
                            //XSLT.Load(appPath + xsltfl, settings, new XmlUrlResolver());
                            XSLT.Load(appPath + @"_XSLT\" + _GLOBAL_PARAMETERS._SIRKET_KODU + "\\GENERIC_TEMPLATE.xslt", settings, new XmlUrlResolver());
                            //XSLT.Load(appPath + @"_XSLT\template.xslt", settings, new XmlUrlResolver());
                            XSLT.Transform(xmlfl, @"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html");
                            String appdir = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
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

                        using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                        {
                            SqlCommand myCommand = new SqlCommand();
                            myCommand.Parameters.AddWithValue("@UUID", dr["UUID"]);
                            myCommand.Parameters.AddWithValue("@ID", dr["ID"]);
                            myCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                            myCommand.Connection = con;
                            myCommand.CommandText = "  Update dbo.FTR_GELEN_FATURALAR  Set YAZDIR='OK',OKUNDU='OK'  Where SIRKET_KODU=@SIRKET_KODU and ID=@ID and UUID=@UUID ";
                            con.Open();
                            myCommand.ExecuteNonQuery();
                            myCommand.Connection.Close();
                        }

                        dr["OKUNDU"] = "OK";
                        dr["YAZDIR"] = "OK";
                    }
                }
            }
        }
        string FILE_NAME_ADRESS = "";
        private void BTN_EPOSTA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FILE_NAME_ADRESS = "";
            int[] selectedRows = gridView_MASTERS.GetSelectedRows();
            for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
            {
                string USERNAME = _GLOBAL_PARAMETERS._KULLANICI_ADI_SOYADI.Replace(".", "");
                if (File.Exists(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html")) File.Delete(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html");

                //System.Threading.Thread.Sleep(1000); 
                DataRow dr = gridView_MASTERS.GetDataRow(selectedRows[ix]);
                pnlControl_INVVIEW.Controls.Clear();
                string xmlfl = "", xsltfl = "";
                if (dr != null)
                {
                    BR_FILE.Caption = appPath + @"_INBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + "_" + dr["UUID"] + ".xml";
                    xmlfl = appPath + @"_INBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + "_" + dr["UUID"] + ".xml";
                    xsltfl = appPath + @"_INBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + "_" + dr["UUID"] + ".xslt";
                }

                if (xsltfl != "")
                {
                    if (File.Exists(xmlfl))
                    {
                        if (!File.Exists(xsltfl))
                        {
                            #region xmlToObj
                            UBL.InvoiceType invx = new UBL.InvoiceType();
                            System.IO.StreamReader file =
                               new System.IO.StreamReader(xmlfl);
                            System.Xml.Serialization.XmlSerializer srlz =
                               new System.Xml.Serialization.XmlSerializer(typeof(UBL.InvoiceType));
                            invx = (UBL.InvoiceType)srlz.Deserialize(file);
                            #endregion
                            #region xslt
                            if (invx.AdditionalDocumentReference != null)
                            {
                                foreach (UBL.DocumentReferenceType docr in invx.AdditionalDocumentReference)
                                {
                                    if (docr.Attachment != null && docr.Attachment.EmbeddedDocumentBinaryObject != null)
                                    {
                                        UBL.EmbeddedDocumentBinaryObjectType BOBJ = docr.Attachment.EmbeddedDocumentBinaryObject;
                                        //if (BOBJ.filename.IndexOf(".xslt") > -1 || (docr.DocumentType != null && docr.DocumentType.Value.ToUpper().IndexOf("XSLT") > -1))
                                        //{
                                        // string pKok = Gnl.WorkDirectory + "GELEN";
                                        // string mov = "\\TMP"; 
                                        if (BOBJ.Value != null)
                                        {
                                            string ss = System.Convert.ToBase64String(BOBJ.Value);
                                            byte[] by = System.Convert.FromBase64String(ss);
                                            File.WriteAllBytes(xsltfl, by);
                                        }
                                        //BOBJ.Value
                                        //}
                                    }
                                }
                            }
                            #endregion
                        }

                        System.Threading.Thread.Sleep(700);
                        //wbh.Url = null;
                        //wbh.Refresh();  



                        //XmlReaderSettings sett = new XmlReaderSettings();
                        //sett.DtdProcessing = DtdProcessing.Ignore;
                        //XmlReader reader = XmlReader.Create(xmlfl, sett);
                        //XmlDocument document = new XmlDocument();
                        //document.Load(reader);



                        //XslCompiledTransform XSLT = new XslCompiledTransform();
                        //XsltSettings settings = new XsltSettings();
                        ////settings.EnableDocumentFunction = false;
                        //settings.EnableScript = true;




                        XslCompiledTransform XSLT = new XslCompiledTransform(true);
                        XSLT.Load(
                            XmlReader.Create(xsltfl,
                            new XmlReaderSettings()
                            {
                                DtdProcessing = DtdProcessing.Parse
                            }),
                            new XsltSettings(true, false),
                            new XmlUrlResolver()
                        );



                //        XSLT.Load(xsltfl, settings, new XmlUrlResolver());
                        XSLT.Transform(xmlfl, @"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html");

                        WKHtmlToPdf(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html", @"c:\temp\_PRINT\", dr["ID"] + ".pdf");
                        System.Threading.Thread.Sleep(200);

                        string sFile = @"c:\temp\_PRINT\" + dr["ID"] + ".pdf";
                        FileStream objfilestream = new FileStream(sFile, FileMode.Open, FileAccess.Read);
                        int len = (int)objfilestream.Length;
                        Byte[] mybytearray = new Byte[len];
                        objfilestream.Read(mybytearray, 0, len);
                        System.Threading.Thread.Sleep(200);
                        WebServices.SALES_INVOICES savedocument = new WebServices.SALES_INVOICES();
                        savedocument.SaveDocument(mybytearray, sFile.Remove(0, sFile.LastIndexOf("\\") + 1));
                        objfilestream.Close();

                        FILE_NAME_ADRESS += (dr["ID"] + ".pdf") + ";";
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
            //MessageBox.Show("Mail Gönderildi");  
        }

        private void BTN_EPDF_SAVE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FolderBrowserDialog brwsr = new FolderBrowserDialog();
            if (brwsr.ShowDialog() == DialogResult.Cancel)
                return;
            else
            { 
                int[] selectedRows = gridView_MASTERS.GetSelectedRows();
                for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
                {
                    string USERNAME = _GLOBAL_PARAMETERS._KULLANICI_ADI_SOYADI.Replace(".", "");
                    if (File.Exists(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html")) File.Delete(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html");

                    DataRow dr = gridView_MASTERS.GetDataRow(selectedRows[ix]);
                    pnlControl_INVVIEW.Controls.Clear();
                    string xmlfl = "", xsltfl = "";
                    if (dr != null)
                    {
                        BR_FILE.Caption = appPath + @"_INBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + "_" + dr["UUID"] + ".xml";
                        xmlfl = appPath + @"_INBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + "_" + dr["UUID"] + ".xml";
                        xsltfl = appPath + @"_INBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + "_" + dr["UUID"] + ".xslt";
                    }

                    if (xsltfl != "")
                    {
                        if (File.Exists(xmlfl))
                        {
                            if (!File.Exists(xsltfl))
                            {
                                #region xmlToObj
                                UBL.InvoiceType invx = new UBL.InvoiceType();
                                System.IO.StreamReader file =
                                   new System.IO.StreamReader(xmlfl);
                                System.Xml.Serialization.XmlSerializer srlz =
                                   new System.Xml.Serialization.XmlSerializer(typeof(UBL.InvoiceType));
                                invx = (UBL.InvoiceType)srlz.Deserialize(file);
                                #endregion
                                #region xslt
                                if (invx.AdditionalDocumentReference != null)
                                {
                                    foreach (UBL.DocumentReferenceType docr in invx.AdditionalDocumentReference)
                                    {
                                        if (docr.Attachment != null && docr.Attachment.EmbeddedDocumentBinaryObject != null)
                                        {
                                            UBL.EmbeddedDocumentBinaryObjectType BOBJ = docr.Attachment.EmbeddedDocumentBinaryObject;
                                            //if (BOBJ.filename.IndexOf(".xslt") > -1 || (docr.DocumentType != null && docr.DocumentType.Value.ToUpper().IndexOf("XSLT") > -1))
                                            //{
                                            // string pKok = Gnl.WorkDirectory + "GELEN";
                                            // string mov = "\\TMP"; 
                                            if (BOBJ.Value != null)
                                            {
                                                string ss = System.Convert.ToBase64String(BOBJ.Value);
                                                byte[] by = System.Convert.FromBase64String(ss);
                                                File.WriteAllBytes(xsltfl, by);
                                            }
                                            //BOBJ.Value
                                            //}
                                        }
                                    }
                                }
                                #endregion
                            }

                            System.Threading.Thread.Sleep(700);
                            //wbh.Url = null;
                            //wbh.Refresh();  

                            XslCompiledTransform XSLT = new XslCompiledTransform(true);
                            XSLT.Load(
                                XmlReader.Create(xsltfl,
                                new XmlReaderSettings()
                                {
                                    DtdProcessing = DtdProcessing.Parse
                                }),
                                new XsltSettings(true, false),
                                new XmlUrlResolver()
                            );



                            //XslCompiledTransform XSLT = new XslCompiledTransform();
                            //XsltSettings settings = new XsltSettings();
                            //settings.EnableScript = true;
                          

                            ////XmlReaderSettings xrs = new XmlReaderSettings();
                            ////xrs.ProhibitDtd = false;

                            //XSLT.Load(xsltfl, XsltSettings.Default, new XmlUrlResolver());
                           // XSLT.Load(xsltfl, settings, new XmlUrlResolver());
                            XSLT.Transform(xmlfl, @"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html");

                            WKHtmlToPdf(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html", brwsr.SelectedPath, dr["ID"] + ".pdf");

                        }
                    }
                }
                MessageBox.Show(selectedRows.Length + " Adet Dosya Kaydedildi");
            }
        }

        private void BTN_EXCEL_EXPORT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = ".xlsx (*.xlsx)|*.xlsx";
            sfd.FileName = "EXPORT_FATURA.xlsx";
            DialogResult res = sfd.ShowDialog();
            if (res == DialogResult.OK)
            {
                gridView_MASTERS.ExportToXlsx(sfd.FileName);
            }

        }

        private void BTN_EDIT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dr = gridView_MASTERS.GetFocusedDataRow();
            if (dr != null)
            {
                ALIS_FATURASI_EDIT frmedt = new ALIS_FATURASI_EDIT(Convert.ToInt32(dr["OID"].ToString()));
                frmedt.ShowDialog();
            }
        }

        private void gridCntrl_LISTS_Click(object sender, EventArgs e)
        {

            dr = gridView_MASTERS.GetFocusedDataRow();
            if (dr == null) return;

            BR_SELECT_ROW_FATURA_NO.Caption = dr["ID"].ToString();

            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string INVOICE_TABLE_SQL = "select * from FTR_GELEN_FATURALAR_DETAYI WHERE SIRKET_KODU=@SIRKET_KODU AND INVOICE_REF=@INVOICE_REF ";
                SqlCommand cmd = myConnection.CreateCommand();
                cmd.Parameters.AddWithValue("@INVOICE_REF", dr["OID"]);
                cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = INVOICE_TABLE_SQL;
                SqlDataAdapter deMaster = new SqlDataAdapter(cmd);
                //define dataset
                DataSet ds = new DataSet();
                deMaster.Fill(ds, "LINE");
                gridCntrl_LINE.DataSource = ds.Tables["LINE"]; // Grid Control'e bir datasource verelim. 
                myConnection.Close();
            }

            HTML_VIEW();
        }

        private void gridCntrl_LISTS_DoubleClick(object sender, EventArgs e)
        {
            dr = gridView_MASTERS.GetFocusedDataRow();
            if (dr == null) return;


            //using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            //{
            //    string INVOICE_TABLE_SQL = "select * from FTR_GELEN_FATURALAR_DETAYI WHERE SIRKET_KODU=@SIRKET_KODU AND INVOICE_REF=@INVOICE_REF ";
            //    SqlCommand cmd = myConnection.CreateCommand();
            //    cmd.Parameters.AddWithValue("@INVOICE_REF", dr["OID"]);
            //    cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = INVOICE_TABLE_SQL;
            //    SqlDataAdapter deMaster = new SqlDataAdapter(cmd);
            //    //define dataset
            //    DataSet ds = new DataSet();
            //    deMaster.Fill(ds, "LINE");
            //    gridCntrl_LINE.DataSource = ds.Tables["LINE"]; // Grid Control'e bir datasource verelim. 
            //    myConnection.Close();
            //}

            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string INVOICE_TABLE_SQL = string.Format("select * from FTR_GELEN_FATURALARI_ONAYLAYACAKLAR WHERE SIRKET_KODU='{0}' AND  FATURAREF='{1}' ", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), dr["OID"].ToString());
                SqlCommand cmd1 = myConnection.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = INVOICE_TABLE_SQL;
                SqlDataAdapter deMaster = new SqlDataAdapter(cmd1);
                //define dataset
                DataSet ds = new DataSet();
                deMaster.Fill(ds, "ONAY_BILGISI");
                gridCntrl_ONAYLIST.DataSource = ds.Tables["ONAY_BILGISI"];
                myConnection.Close();
            }


            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string INVOICE_TABLE_SQL = string.Format("select * from FTR_DURUM_BILGISI WHERE SIRKET_KODU='{0}' AND  FATURAREF='{1}' ", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), dr["OID"].ToString());
                SqlCommand cmd1 = myConnection.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = INVOICE_TABLE_SQL;
                SqlDataAdapter deMaster = new SqlDataAdapter(cmd1);
                //define dataset
                DataSet ds = new DataSet();
                deMaster.Fill(ds, "DURUM_BILGISI");
                gridCntrl_DURUM_BILGISI.DataSource = ds.Tables["DURUM_BILGISI"];
                myConnection.Close();
            }

            using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                SqlCommand myCommand = new SqlCommand();
                myCommand.Parameters.AddWithValue("@UUID", dr["UUID"]);
                myCommand.Parameters.AddWithValue("@ID", dr["ID"]);
                myCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                myCommand.Connection = con;
                myCommand.CommandText = "  Update dbo.FTR_GELEN_FATURALAR  Set  OKUNDU='OK'  Where  SIRKET_KODU=@SIRKET_KODU AND ID=@ID and UUID=@UUID ";
                con.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();
            }
            dr["OKUNDU"] = "OK";
        }

        private void HTML_VIEW()
        {
            string USERNAME = _GLOBAL_PARAMETERS._KULLANICI_ADI_SOYADI.Replace(".", "");
            if (File.Exists(@"c:\temp\_PRINT\" + USERNAME + "TMP.html")) File.Delete(@"c:\temp\_PRINT\" + USERNAME + "TMP.html");
            string xmlfl = "", xsltfl = "";
            if (dr != null)
            {
                xmlfl = appPath + @"_INBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + "_" + dr["UUID"] + ".xml";
                xsltfl = appPath + @"_INBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + "_" + dr["UUID"] + ".xslt";
            }
            if (xsltfl != "")
            {
                WebBrowser wbh = new WebBrowser();
                wbh.Url = null;
                if (File.Exists(xmlfl))//&& File.Exists(xsltfl)
                {

                    if (!File.Exists(xsltfl))
                    {
                        #region xmlToObj
                        UBL.InvoiceType invx = new UBL.InvoiceType();
                        System.IO.StreamReader file = new System.IO.StreamReader(xmlfl);
                        System.Xml.Serialization.XmlSerializer srlz = new System.Xml.Serialization.XmlSerializer(typeof(UBL.InvoiceType));
                        invx = (UBL.InvoiceType)srlz.Deserialize(file);
                        #endregion
                        #region xslt
                        if (invx.AdditionalDocumentReference != null)
                        {
                            foreach (UBL.DocumentReferenceType docr in invx.AdditionalDocumentReference)
                            {
                                if (docr.Attachment != null && docr.Attachment.EmbeddedDocumentBinaryObject != null)
                                {
                                    UBL.EmbeddedDocumentBinaryObjectType BOBJ = docr.Attachment.EmbeddedDocumentBinaryObject;
                                    //if (BOBJ.filename.IndexOf(".xslt") > -1 || (docr.DocumentType != null && docr.DocumentType.Value.ToUpper().IndexOf("XSLT") > -1))
                                    //{
                                    // string pKok = Gnl.WorkDirectory + "GELEN";
                                    // string mov = "\\TMP";

                                    if (BOBJ.Value != null)
                                    {
                                        string ss = System.Convert.ToBase64String(BOBJ.Value);
                                        byte[] by = System.Convert.FromBase64String(ss);
                                        File.WriteAllBytes(xsltfl, by);
                                    }
                                    //BOBJ.Value
                                    //}
                                }
                            }
                        }
                        #endregion
                    }

                    try
                    {

                        XslCompiledTransform XSLT = new XslCompiledTransform(true);
                        XSLT.Load(
                            XmlReader.Create(xsltfl,
                            new XmlReaderSettings()
                            {
                                DtdProcessing = DtdProcessing.Parse
                            }),
                            new XsltSettings(true, false),
                            new XmlUrlResolver()
                        );



                        //XslCompiledTransform XSLT = new XslCompiledTransform();
                        //XsltSettings settings = new XsltSettings();
                        //settings.EnableScript = true;
                        //XSLT.Load(xsltfl, settings, new XmlUrlResolver());



                        XSLT.Transform(xmlfl, @"c:\temp\_PRINT\" + USERNAME + "TMP.html");
                        //UBL_VIEWER vv = new UBL_VIEWER();
                        String appdir = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                        String myfile = Path.Combine(appdir, @"c:\temp\_PRINT\" + USERNAME + "TMP.html");
                        //vv.wbh.Url = new Uri("file:///" + myfile);
                        //vv.Show();                 
                        wbh.Url = new Uri("file:///" + myfile);
                    }
                    catch
                    {
                        //   xsltfl = appPath + @"_XSLT\template.xslt";
                        xsltfl = appPath + @"_XSLT\EFATURA\TMP\GENERIC_TEMPLATE.xslt";
                        XslCompiledTransform XSLT = new XslCompiledTransform();
                        XsltSettings settings = new XsltSettings();
                        settings.EnableScript = true;
                        XSLT.Load(xsltfl, settings, new XmlUrlResolver());
                        XSLT.Transform(xmlfl, @"c:\temp\_PRINT\" + USERNAME + "TMP.html");
                        //UBL_VIEWER vv = new UBL_VIEWER();
                        String appdir = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                        String myfile = Path.Combine(appdir, @"c:\temp\_PRINT\" + USERNAME + "TMP.html");
                        wbh.Url = new Uri("file:///" + myfile);
                    }
                }
                Show();
                wbh.ScrollBarsEnabled = true;
                wbh.ScriptErrorsSuppressed = true;
                pnlControl_INVVIEW.Controls.Add(wbh);
                wbh.Dock = DockStyle.Fill;
                wbh.BringToFront();
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

        private void fr_SendMailCompleted(object sender, WebServices.SendMailCompletedEventArgs e)
        {

            System.Threading.Thread.Sleep(400);
            WebServices.SALES_INVOICES fr = new WebServices.SALES_INVOICES();
            fr.DeleteDocumentAsync(FILE_NAME_ADRESS);
            fr.DeleteDocumentCompleted += fr_DeleteDocumentCompleted;


            //  throw new NotImplementedException();
        }

        private void fr_DeleteDocumentCompleted(object sender, WebServices.DeleteDocumentCompletedEventArgs e)
        {
            //  throw new NotImplementedException();
            MessageBox.Show("Mail Gönderildi.");
        }

        private void BTN_LOGO_ISARETLE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);

            myConnections.Open();
            int[] selectedRows = gridView_MASTERS.GetSelectedRows();

            for (int ix = selectedRows.Length - 1; ix >= 0; ix--)
            {
                DataRow drx = gridView_MASTERS.GetDataRow(selectedRows[ix]);
                if (drx == null) return;
                string DURUM_BILGISI = string.Empty;
                int _LOGICALREF = 0;
                Query Querys = _GLOBAL_PARAMETERS.Global.UnityApp.NewQuery();
                string Query_String = "SELECT CRD.LOGICALREF , CRD.TAXNR,FTR.FICHENO  FROM  dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_CLCARD CRD LEFT JOIN dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_01_INVOICE FTR ON  CRD.LOGICALREF=FTR.CLIENTREF   WHERE  (CRD.TAXNR='" + drx["AccSupplierPartyIdentificationSchemeID"].ToString() + "' or  CRD.TCKNO='" + drx["AccSupplierPartyIdentificationSchemeID"].ToString() + "' ) AND  (FTR.FICHENO='" + drx["ID"].ToString() + "'  or  FTR.DOCODE='" + drx["ID"].ToString() + "')";
                //= "   select  LOGICALREF FROM LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_01_INVOICE  WHERE   FICHENO='" + drx["ID"].ToString() + "'";
                Querys.Statement = Query_String;
                if (Querys.OpenDirect())
                {
                    bool eof = Querys.First();
                    if (eof)
                    {
                        while (eof)
                        {
                            _LOGICALREF = Querys.QueryFields[0].Value;
                            string SQL_ROW = @" UPDATE dbo.FTR_GELEN_FATURALAR SET ERP_AKTARILDI='True' Where SIRKET_KODU='{0}'  and ID='{1}' and OID='{2}'  ";
                            SQL_ROW = string.Format(SQL_ROW, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), drx["ID"].ToString(), drx["OID"].ToString());
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.CommandText = SQL_ROW;
                                cmd.Connection = myConnections;
                                cmd.ExecuteNonQuery();
                            }
                            drx["ERP_AKTARILDI"] = true;
                            eof = Querys.Next();
                        }
                    }
                    else
                    {
                        string SQL_ROW = @" UPDATE dbo.FTR_GELEN_FATURALAR SET ERP_AKTARILDI='False' Where SIRKET_KODU='{0}'  and ID='{1}' and OID='{2}'  ";
                        SQL_ROW = string.Format(SQL_ROW, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), drx["ID"].ToString(), drx["OID"].ToString());
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = SQL_ROW;
                            cmd.Connection = myConnections;
                            cmd.ExecuteNonQuery();
                        }
                        drx["ERP_AKTARILDI"] = false;
                    }
                }

            }
        }

        private void timers_Tick(object sender, EventArgs e)
        {
            GIB_FATURA_INDIR();

            // Show a sample alert window. 

            info.Text += "Son İndirme : " + DateTime.Now.ToShortTimeString() + Environment.NewLine;
            info.Text += "Fatura Sayısı : " + INEN_FATURA_SAYISI.ToString() + Environment.NewLine;
            alertControls.Show(this, info);
        }

        private void ALIS_FATURASI_LIST_Deactivate(object sender, EventArgs e)
        {

        }

        private void ALIS_FATURASI_LIST_Activated(object sender, EventArgs e)
        {
            //  timers.Start();
        }

        private void ALIS_FATURASI_LIST_FormClosing(object sender, FormClosingEventArgs e)
        {
            // timers.Stop();
        }

        private void CNT_MENU_YAZDIRMA_Click(object sender, EventArgs e)
        {
            YAZDIR();
        }

        private void gridView_MASTERS_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {

            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["FATURA_YENI"]);
                if (category == "Checked")
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.SeaShell;
                }
            }

        }

        private void re_DURUM_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void CMB_DURUM_EditValueChanged(object sender, EventArgs e)
        {
            DATA_LOAD(CMB_DURUM.EditValue.ToString());
        }


    }
}