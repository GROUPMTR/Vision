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
using System.Xml.Xsl;
using System.Xml;
using System.IO;
using System.Diagnostics;
using UnityObjects;
using DevExpress.XtraBars.Alerter;
namespace VISION.FINANS.GIB
{
    public partial class SATIS_FATURASI_LIST : DevExpress.XtraEditors.XtraForm
    {
        string appPath = _GLOBAL_PARAMETERS._FILE_PATH;//  Path.GetDirectoryName(Application.ExecutablePath);
        WebBrowser wbh = new WebBrowser();
        DataRow Cfg = null;
        DataRow dr = null;
        AlertInfo info = new AlertInfo("Fatura İndirme Bilgisi", "");
        public SATIS_FATURASI_LIST()
        {
            InitializeComponent();
            this.Tag = "MDIFORM";
            BTM_FIRMA_KODU.Caption = _GLOBAL_PARAMETERS._SIRKET_NO;
            BTM_FIRMA_NAME.Caption = _GLOBAL_PARAMETERS._SIRKET_KODU;
            CMB_DURUM.EditValue = "TÜMÜ";
            DATA_LOAD();
        }
        private void BTN_GUNCELLE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CMB_DURUM.EditValue.ToString() != "") DATA_LOAD();
        }

        private void DATA_LOAD()
        {
            if (CMB_DURUM.EditValue.ToString() != "TÜMÜ")
            {
                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                {
                    //  string SQL = @" Select * From dbo.FTR_GIB_TRANSFER Where SIRKET_KODU='{0}'   and STATUS_DESCRIPTION='" + CMB_DURUM.EditValue + "' order by Tarih desc ";



                    string SQL = "";
                    if (BTN_YIL.EditValue.ToString() == "TÜMÜ")
                    { SQL = "  Select CASE WHEN FATURA_TIPI = 'E' THEN 'e-fatura' else 'e-arşiv' END AS FATURANIN_TURU,* From dbo.FTR_GIB_TRANSFER Where SIRKET_KODU='{0}' and FATURA_TIPI='E'  and STATUS_DESCRIPTION='" + CMB_DURUM.EditValue + "' order by Tarih desc "; }

                    else

                    { SQL = " Select CASE WHEN FATURA_TIPI = 'E' THEN 'e-fatura' else 'e-arşiv' END AS FATURANIN_TURU, * From dbo.FTR_GIB_TRANSFER Where SIRKET_KODU='{0}'  and FATURA_TIPI='E' and STATUS_DESCRIPTION='" + CMB_DURUM.EditValue + "' order by Tarih desc   AND (YEAR(Tarih) = '" + BTN_YIL.EditValue.ToString() + "') "; }



                    SQL = string.Format(SQL, _GLOBAL_PARAMETERS._SIRKET_NO.ToString());
                    SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(SQL, myConnection);
                    DataSet dataSet = new DataSet();
                    MySqlDataAdapter.Fill(dataSet, "FTR_GIB_TRANSFER");
                    DataViewManager dvManager = new DataViewManager(dataSet);
                    DataView dv = dvManager.CreateDataView(dataSet.Tables[0]);
                    gridCntrl_LIST.DataSource = dv;
                    myConnection.Close();
                }
            }
            else
            {
                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                {


                    string SQL = "";
                    if (BTN_YIL.EditValue.ToString() == "TÜMÜ")
                    { SQL = "  Select CASE WHEN FATURA_TIPI = 'E' THEN 'e-fatura' else 'e-arşiv' END AS FATURANIN_TURU,* From dbo.FTR_GIB_TRANSFER Where SIRKET_KODU='{0}'    order by Tarih desc "; }

                    else

                    { SQL = " Select CASE WHEN FATURA_TIPI = 'E' THEN 'e-fatura' else 'e-arşiv' END AS FATURANIN_TURU,* From dbo.FTR_GIB_TRANSFER Where SIRKET_KODU='{0}' and (YEAR(Tarih) = '" + BTN_YIL.EditValue.ToString() + "')  order by Tarih desc  "; }



                    // string SQL = @" Select * From dbo.FTR_GIB_TRANSFER Where SIRKET_KODU='{0}'   order by Tarih desc ";
                    SQL = string.Format(SQL, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                    SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(SQL, myConnection);
                    DataSet dataSet = new DataSet();
                    MySqlDataAdapter.Fill(dataSet, "FTR_GIB_TRANSFER");
                    DataViewManager dvManager = new DataViewManager(dataSet);
                    DataView dv = dvManager.CreateDataView(dataSet.Tables[0]);
                    gridCntrl_LIST.DataSource = dv;
                    myConnection.Close();
                }
            }


        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridCntrl_LIST_Click(object sender, EventArgs e)
        {

            dr = gridView_LIST.GetFocusedDataRow();
            if (dr == null) return;
            BR_SELECT_ROW_FATURA_NO.Caption = dr["ID"].ToString();
            HTML_VIEW();
        }

        private void BTN_GORUNTULE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HTML_VIEW();
        }





        private void HTML_VIEW()
        {
            DataRow dr = gridView_LIST.GetFocusedDataRow();
            if (dr == null) return;
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string INVOICE_TABLE_SQL = string.Format("select * from FTR_GIB_TRANSFER_DURUMU WHERE SIRKET_KODU='{0}' and ID='{1}' ", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), dr["ID"].ToString());
                SqlCommand cmd = myConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = INVOICE_TABLE_SQL;
                SqlDataAdapter deMaster = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                deMaster.Fill(ds, "FTR_INVOICE_GIB_TRANSFER_DURUMU");
                gridCntrl_ONAYLIST.DataSource = ds.Tables[0]; // Grid Control'e bir datasource verelim. 
                myConnection.Close();
            }

            _FATURA_DURUM_UPDATE(dr["ID"].ToString(), true, dr["FATURANIN_TURU"].ToString());
            string xmlfl = "", xsltfl = "";
            if (dr != null)
            {
                xmlfl = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU.ToString() + @"\" + dr["ID"] + ".xml";

                //     xsltfl = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU.ToString() + @"\" + dr["ID"] + ".xslt";



                if (dr["FATURANIN_TURU"].ToString()  == "e-fatura")
                {

                    xsltfl = appPath + "\\_XSLT\\EFATURA\\" + _GLOBAL_PARAMETERS._SIRKET_KODU.ToString() + "\\GENERIC_TEMPLATE.xslt";
                }

                if (dr["FATURANIN_TURU"].ToString() == "e-arşiv")
                {
                    xsltfl = appPath + "\\_XSLT\\EARSIVE\\" + _GLOBAL_PARAMETERS._SIRKET_KODU.ToString() + "\\GENERIC_TEMPLATE.xslt";
 
                }


              

            }
            string USERNAME = _GLOBAL_PARAMETERS._KULLANICI_ADI_SOYADI.Replace(".", "");
            if (File.Exists(@"c:\temp\_PRINT\" + USERNAME + "TMP.html")) File.Delete(@"c:\temp\_PRINT\" + USERNAME + "TMP.html");
            if (xsltfl != "")
            {
                if (File.Exists(xmlfl) && File.Exists(xsltfl))
                {

                    XslCompiledTransform XSLT = new XslCompiledTransform();
                    XsltSettings settings = new XsltSettings();
                    settings.EnableScript = true;
                    XSLT.Load(xsltfl, settings, new XmlUrlResolver());
                    XSLT.Transform(xmlfl, @"c:\temp\_PRINT\" + USERNAME + "TMP.html");
                    String appdir = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                    String myfile = Path.Combine(appdir, @"c:\temp\_PRINT\" + USERNAME + "TMP.html");
                    wbh.Url = new Uri("file:///" + myfile);
                    Show();
                    wbh.ScrollBarsEnabled = true;
                    wbh.ScriptErrorsSuppressed = true;
                    pnlControl_INVVIEW.Controls.Add(wbh);
                    wbh.Dock = DockStyle.Fill;
                    wbh.BringToFront();
                }
            }
        }




        public string _FATURA_DURUM_UPDATE(string NUMBER, bool STATUS,string FATURANIN_TURU)
        { 
            string DURUM_BILGISI = string.Empty;
            int _LOGICALREF = 0;

            if (STATUS)
            {
                Query Querys = _GLOBAL_PARAMETERS.Global.UnityApp.NewQuery();
                string Query_String = "   select  LOGICALREF FROM LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_01_INVOICE  WHERE   (FICHENO='" + NUMBER + "'  or DOCODE='" + NUMBER + "')";
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
                 
                if (FATURANIN_TURU == "e-fatura")
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

                if (FATURANIN_TURU == "e-arşiv")
                {  
                    Query Queryf = _GLOBAL_PARAMETERS.Global.UnityApp.NewQuery();
                    string QueryString = " UPDATE  dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_01_EARCHIVEDET SET EARCHIVESTATUS='4' WHERE LOGICALREF=" + _LOGICALREF + "";
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
            }
            else
            {
                Query Querys = _GLOBAL_PARAMETERS.Global.UnityApp.NewQuery();
                string Query_String = "   select  LOGICALREF FROM LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_01_INVOICE  WHERE  (FICHENO='" + NUMBER + "'  or DOCODE='" + NUMBER + "')";
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

                if (FATURANIN_TURU == "e-fatura")
                { 
                    Query Queryf = _GLOBAL_PARAMETERS.Global.UnityApp.NewQuery();
                    string QueryString = " UPDATE  dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_01_INVOICE  SET ESTATUS='0' WHERE LOGICALREF=" + _LOGICALREF + "";
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

                if (FATURANIN_TURU == "e-arşiv") 
                {

                    Query Queryf = _GLOBAL_PARAMETERS.Global.UnityApp.NewQuery();
                    string QueryString = " UPDATE  dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_01_EARCHIVEDET  SET EARCHIVESTATUS='0' WHERE LOGICALREF=" + _LOGICALREF + "";
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
            }
            return DURUM_BILGISI;
        }

        WebService.IziBizSrv.REQUEST_HEADERType htype { get; set; }
        private void BTN_REFRESH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID == "" || VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID == null) VISION.FINANS.UBL.IZIBIZ_CLASS.izibiz_login();

            if (VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID != "")
            {
                VISION.FINANS.UBL.IZIBIZ_CLASS.Config();
                int[] selectedRows = gridView_LIST.GetSelectedRows();
                for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
                {
                    DataRow dr = gridView_LIST.GetDataRow(selectedRows[ix]);
                    if (dr == null) break;
                    GIB_DURUM_KONTROL(dr);
                }
            }
            DATA_LOAD();
        }

        private void GIB_DURUM_KONTROL(DataRow dr)
        {

            try
            {
                WebService.IziBizSrv.GetInvoiceStatusRequest req = new WebService.IziBizSrv.GetInvoiceStatusRequest();
                req.INVOICE = new WebService.IziBizSrv.INVOICE();
                req.INVOICE.ID = dr["ID"].ToString();
                req.INVOICE.UUID = dr["GID"].ToString();
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
                        SQLSELECT = string.Format(SQLSELECT, InvStatu.INVOICE_STATUS.RESPONSE_CODE, InvStatu.INVOICE_STATUS.RESPONSE_DESCRIPTION, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), "01", dr["ID"].ToString(), dr["GID"].ToString());
                        DateTime myDTStart = Convert.ToDateTime(DateTime.Now);

                        string SQLINSERT = @" INSERT INTO FTR_GIB_TRANSFER_DURUMU  (DURUM_KODU,MESAJ,SIRKET_KODU,DONEM,ID,GID,TARIH,SERVER) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}') ";
                        SQLINSERT = string.Format(SQLINSERT, InvStatu.INVOICE_STATUS.RESPONSE_CODE, InvStatu.INVOICE_STATUS.RESPONSE_DESCRIPTION, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), "01", dr["ID"].ToString(), dr["GID"].ToString(), myDTStart.ToString("yyyy-MM-dd").ToString(), "RESPONSE");
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
                        SQLSELECT = string.Format(SQLSELECT, InvStatu.INVOICE_STATUS.GIB_STATUS_CODE, InvStatu.INVOICE_STATUS.GIB_STATUS_DESCRIPTION, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), "01", dr["ID"].ToString(), dr["GID"].ToString());

                        DateTime myDTStart = Convert.ToDateTime(DateTime.Now);
                        string SQLINSERT = @" INSERT INTO FTR_GIB_TRANSFER_DURUMU  (DURUM_KODU,MESAJ,SIRKET_KODU,DONEM,ID,GID,TARIH,SERVER) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}') ";
                        SQLINSERT = string.Format(SQLINSERT, "", MESAJIM.Replace("'", ""), _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), "01", dr["ID"].ToString(), dr["GID"].ToString(), myDTStart.ToString("yyyy-MM-dd").ToString(), "GİB");
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
                        SQLSELECT = string.Format(SQLSELECT, InvStatu.INVOICE_STATUS.STATUS, InvStatu.INVOICE_STATUS.STATUS_DESCRIPTION.Replace("'", ""), _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), "01", dr["ID"].ToString(), dr["GID"].ToString());
                        DateTime myDTStart = Convert.ToDateTime(DateTime.Now);
                        string SQLINSERT = @" INSERT INTO FTR_GIB_TRANSFER_DURUMU  (DURUM_KODU,MESAJ,SIRKET_KODU,DONEM,ID,GID,TARIH,SERVER) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}') ";
                        SQLINSERT = string.Format(SQLINSERT, "", MESAJIM.Replace("'", ""), _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), "01", dr["ID"].ToString(), dr["GID"].ToString(), myDTStart.ToString("yyyy-MM-dd").ToString(), "İZİBİZ");

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
                    SQL_ROW = string.Format(SQL_ROW, "", MESAJIM.Replace("'", ""), _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), dr["ID"].ToString(), dr["GID"].ToString());

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
                    SQL_ROW = string.Format(SQL_ROW, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), "01", dr["ID"].ToString(), dr["GID"].ToString());
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = SQL_ROW;
                        cmd.Connection = myConnections;
                        cmd.ExecuteNonQuery();
                    }
                }
            }

        }
        private void gridCntrl_LIST_DoubleClick(object sender, EventArgs e)
        {



        }
        string FILE_NAME_ADRESS = "";
        private void BTN_EPOSTA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                    BR_FILE.Caption = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + ".xml";
                    xmlfl = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + ".xml";
              ///      xsltfl = appPath + @"_XSLT\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";/// +dr["FICHENO"] + "_" + dr["GUID"] + ".xslt";



                    if (dr["FATURANIN_TURU"].ToString() == "e-fatura")
                    {

                        xsltfl = appPath + "\\_XSLT\\EFATURA\\" + _GLOBAL_PARAMETERS._SIRKET_KODU.ToString() + "\\GENERIC_TEMPLATE.xslt";
                    }

                    if (dr["FATURANIN_TURU"].ToString() == "e-arşiv")
                    {
                        xsltfl = appPath + "\\_XSLT\\EARSIVE\\" + _GLOBAL_PARAMETERS._SIRKET_KODU.ToString() + "\\GENERIC_TEMPLATE.xslt";

                    }


                    //if (File.Exists(xmlfl)) File.Delete(xmlfl);

                    if (!File.Exists(xmlfl))
                    {
                        //e_master.SmartInv.UBL.LOGO_CreateXML createxml = new UBL.LOGO_CreateXML();
                        UBL.ERP_CREATE_XML createxml = new UBL.ERP_CREATE_XML();

                        xmlfl = createxml.Create(_GLOBAL_PARAMETERS._SIRKET_KODU, Cfg, dr, "_OUTBOX", dr["FATURANIN_TURU"].ToString ());
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

                                    WKHtmlToPdf(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html", @"c:\temp\_PRINT\", dr["ID"] + ".pdf");
                                    string sFile = @"c:\temp\_PRINT\" + dr["ID"] + ".pdf";
                                    FileStream objfilestream = new FileStream(sFile, FileMode.Open, FileAccess.Read);
                                    int len = (int)objfilestream.Length;
                                    Byte[] mybytearray = new Byte[len];
                                    objfilestream.Read(mybytearray, 0, len);
                                    WebServices.SALES_INVOICES savedocument = new WebServices.SALES_INVOICES();
                                    savedocument.SaveDocument(mybytearray, sFile.Remove(0, sFile.LastIndexOf("\\") + 1));
                                    objfilestream.Close();

                                    FILE_NAME_ADRESS += (dr["ID"] + ".pdf") + ";";

                                    // File.Delete(sFile);

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
                //   fr.SendMailAsync("noreply." + _GLOBAL_PARAMETERS._ENTUSERNAME + "@groupm.com", "hasan.yogurtcu@groupm.com", snd.subject.ToString(), snd.aciklama.ToString(), FILE_NAME_ADRESS);
                fr.SendMailCompleted += fr_SendMailCompleted;
            }
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
            // throw new NotImplementedException();
            MessageBox.Show("Mail Gönderildi.");
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
        private void BTN_YAZDIR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            YAZDIR();
        }
        private void YAZDIR()
        {

            int[] selectedRows = gridView_LIST.GetSelectedRows();
            for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
            {
                //System.Threading.Thread.Sleep(1000);
                DataRow dr = gridView_LIST.GetDataRow(selectedRows[ix]);
                pnlControl_INVVIEW.Controls.Clear();
                string xmlfl = "", xsltfl = "";
                if (dr != null)
                {
                    BR_FILE.Caption = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + ".xml";
                    xmlfl = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + ".xml";




                    if (dr["FATURANIN_TURU"].ToString() == "e-fatura")
                    {

                        xsltfl = appPath + "\\_XSLT\\EFATURA\\" + _GLOBAL_PARAMETERS._SIRKET_KODU.ToString() + "\\GENERIC_TEMPLATE.xslt";
                    }

                    if (dr["FATURANIN_TURU"].ToString() == "e-arşiv")
                    {
                        xsltfl = appPath + "\\_XSLT\\EARSIVE\\" + _GLOBAL_PARAMETERS._SIRKET_KODU.ToString() + "\\GENERIC_TEMPLATE.xslt";

                    }



             //       xsltfl = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + ".xslt";
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

                        System.Threading.Thread.Sleep(800);
                        string USERNAME = _GLOBAL_PARAMETERS._KULLANICI_ADI_SOYADI.Replace(".", "");
                        if (File.Exists(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html")) File.Delete(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html");
                        //wbh.Url = null;
                        //wbh.Refresh();
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
                      //  BR_FILE.Caption = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + ".xml";
                      //  xmlfl = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + ".xml";
                      ////  xsltfl = appPath + @"_XSLT\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\GENERIC_TEMPLATE.xslt";/// +dr["FICHENO"] + "_" + dr["GUID"] + ".xslt";



                      //  if (dr["FATURANIN_TURU"].ToString() == "e-fatura")
                      //  {

                      //      xsltfl = appPath + "\\_XSLT\\EFATURA\\" + _GLOBAL_PARAMETERS._SIRKET_KODU.ToString() + "\\GENERIC_TEMPLATE.xslt";
                      //  }

                      //  if (dr["FATURANIN_TURU"].ToString() == "e-arşiv")
                      //  {
                      //      xsltfl = appPath + "\\_XSLT\\EARSIVE\\" + _GLOBAL_PARAMETERS._SIRKET_KODU.ToString() + "\\GENERIC_TEMPLATE.xslt";

                      //  }


                        BR_FILE.Caption = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + ".xml";
                        xmlfl = appPath + @"_OUTBOX\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + dr["ID"] + ".xml";




                        if (dr["FATURANIN_TURU"].ToString() == "e-fatura")
                        {

                            xsltfl = appPath + "\\_XSLT\\EFATURA\\" + _GLOBAL_PARAMETERS._SIRKET_KODU.ToString() + "\\GENERIC_TEMPLATE.xslt";
                        }

                        if (dr["FATURANIN_TURU"].ToString() == "e-arşiv")
                        {
                            xsltfl = appPath + "\\_XSLT\\EARSIVE\\" + _GLOBAL_PARAMETERS._SIRKET_KODU.ToString() + "\\GENERIC_TEMPLATE.xslt";

                        }

                    }

                    //if (File.Exists(xmlfl)) File.Delete(xmlfl);

                    if (!File.Exists(xmlfl))
                    {
                        // e_master.SmartInv.UBL.LOGO_CreateXML createxml = new UBL.LOGO_CreateXML();
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

                                    wbh = null;
                                    wbh = new WebBrowser();
                                    System.Threading.Thread.Sleep(100);
                                    if (File.Exists(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html")) File.Delete(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html");
                                    XslCompiledTransform XSLT = new XslCompiledTransform();
                                    XsltSettings settings = new XsltSettings();
                                    settings.EnableScript = true;
                                    XSLT.Load(xsltfl, settings, new XmlUrlResolver());
                                    XSLT.Transform(xmlfl, @"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html");

                                    WKHtmlToPdf(@"c:\temp\_PRINT\" + ix + USERNAME + "TMP.html", brwsr.SelectedPath, dr["ID"] + ".pdf");
                                }
                                else
                                {
                                    MessageBox.Show("xml file erişilemedi.");
                                }
                            }
                        }
                    }
                    MessageBox.Show(selectedRows.Length + " Adet Dosya Kaydedildi");
                }
            }
        }

        private void BTN_LOGO_ISARETLE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB); 
            //myConnections.Open();
            //  int[] selectedRows = gridView_LIST.GetSelectedRows();
            //  for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
            //  {
            //      DataRow drx = gridView_LIST.GetDataRow(selectedRows[ix]);
            //      _FATURA_DURUM_UPDATE(drx["ID"].ToString(), false); 

            //          string SQL_ROW = @" UPDATE dbo.FTR_GIB_TRANSFER SET ERP_AKTARILDI='True' Where SIRKET_KODU='{0}'  and ID='{1}'  ";
            //          SQL_ROW = string.Format(SQL_ROW, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), drx["ID"].ToString());
            //          using (SqlCommand cmd = new SqlCommand())
            //          {
            //              cmd.CommandText = SQL_ROW;
            //              cmd.Connection = myConnections;
            //              cmd.ExecuteNonQuery();
            //          }
            // }

            if (barEditItem1.EditValue != null)
            {
                _FATURA_DURUM_UPDATE(barEditItem1.EditValue.ToString(), false, dr["FATURANIN_TURU"].ToString());
            }


        }

        private void timers_Tick(object sender, EventArgs e)
        {
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string SQL = " Select * From dbo.FTR_GIB_TRANSFER Where SIRKET_KODU='{0}'  and STATUS_DESCRIPTION IS null AND (YEAR(Tarih) = '" + BTN_YIL.EditValue.ToString() + "') ";
                SQL = string.Format(SQL, _GLOBAL_PARAMETERS._SIRKET_NO.ToString());
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(SQL, myConnection);
                DataSet dataSet = new DataSet();
                MySqlDataAdapter.Fill(dataSet, "FTR_GIB_TRANSFER");
                DataViewManager dvManager = new DataViewManager(dataSet);
                DataView dv = dvManager.CreateDataView(dataSet.Tables[0]);
                gridCntrl_LIST.DataSource = dv;
                myConnection.Close();
            }

            gridView_LIST.SelectAll();
            if (VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID == "" || VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID == null) VISION.FINANS.UBL.IZIBIZ_CLASS.izibiz_login();

            if (VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID != "")
            {
                VISION.FINANS.UBL.IZIBIZ_CLASS.Config();
                int[] selectedRows = gridView_LIST.GetSelectedRows();
                for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
                {
                    DataRow dr = gridView_LIST.GetDataRow(selectedRows[ix]);
                    if (dr == null) break;
                    GIB_DURUM_KONTROL(dr);
                }
            }





            BR_UPDATE_TIME.Caption = "Son Güncelleme " + DateTime.Now.ToShortTimeString();

            // Show a sample alert window. 
            info.Text += "Son İndirme : " + DateTime.Now.ToShortTimeString() + Environment.NewLine;
            info.Text += "Fatura Sayısı : " + re_PROGRESS_BAR.Maximum + Environment.NewLine;
            alertControls.Show(this, info);


            DATA_LOAD();
        }

        private void SATIS_FATURASI_LIST_Activated(object sender, EventArgs e)
        {
            timers.Stop();
        }

        private void SATIS_FATURASI_LIST_FormClosing(object sender, FormClosingEventArgs e)
        {
            timers.Stop();
        }

        private void SATIS_FATURASI_LIST_Deactivate(object sender, EventArgs e)
        {
            timers.Start();
        }

        private void CNT_MN_FATURA_CIKART_Click(object sender, EventArgs e)
        {
            DialogResult c = MessageBox.Show("Silmek istediğinizden eminmisiniz.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (c == DialogResult.Yes)
            {
                int[] selectedRows = gridView_LIST.GetSelectedRows();
                for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
                {
                    DataRow dr = gridView_LIST.GetDataRow(selectedRows[ix]);
                    using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                    {
                        myConnections.Open();
                        SqlCommand myCmd = new SqlCommand();
                        string INVOICE_TABLE_SQL = string.Format("DELETE FTR_GIB_TRANSFER WHERE SIRKET_KODU='{0}' and OID='{1}' ", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), dr["OID"].ToString());
                        myCmd.CommandText += INVOICE_TABLE_SQL;
                        myCmd.Connection = myConnections;
                        myCmd.ExecuteNonQuery();
                        myCmd.Connection.Close();
                        myConnections.Close();
                    }


                    //string FATURA_TIPI = "";
                    //if (dr["TIP"].ToString() == "1") FATURA_TIPI = "ALIM";
                    //if (dr["TIP"].ToString() == "6") FATURA_TIPI = "ALIM İADE";

                    //if (dr["TYPE"].ToString() == "3") FATURA_TIPI = "SATIŞ İADE";
                    //if (dr["TYPE"].ToString() == "8") FATURA_TIPI = "SATIŞ";

                 

                    _FATURA_DURUM_UPDATE(dr["ID"].ToString(), false, dr["FATURANIN_TURU"].ToString() );


                    _GLOBAL_PARAMETERS.LOG_ISLEMLERI LF = new _GLOBAL_PARAMETERS.LOG_ISLEMLERI();
                    LF.LOG_AKTARIMI(dr["TIP"].ToString(), dr["ID"].ToString(), "SİL", dr["TOPLAMTUTAR"].ToString(), dr["MUSTERI"].ToString(), "", "", dr["MESAJ"].ToString(), "");

                }
                DATA_LOAD();
            }
        }

        private void CNT_MN_EFATURA_ISARETLE_Click(object sender, EventArgs e)
        {
            DialogResult c = MessageBox.Show("Faturayı Gib'e Gönderildi olarak işaretlemek istediğinize eminmisiniz.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (c == DialogResult.Yes)
            {
                SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
                myConnections.Open();
                int[] selectedRows = gridView_LIST.GetSelectedRows();
                for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
                {
                    DataRow drx = gridView_LIST.GetDataRow(selectedRows[ix]);
                    _FATURA_DURUM_UPDATE(drx["ID"].ToString(), true, drx["FATURANIN_TURU"].ToString() );

                    string SQL_ROW = @" UPDATE dbo.FTR_GIB_TRANSFER SET ERP_AKTARILDI='True' Where SIRKET_KODU='{0}'  and ID='{1}'  ";
                    SQL_ROW = string.Format(SQL_ROW, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), drx["ID"].ToString());
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = SQL_ROW;
                        cmd.Connection = myConnections;
                        cmd.ExecuteNonQuery();
                    }
                }
                DATA_LOAD();
            }
        }

        private void CNT_MN_EFATURA_ISARETINI_KALDIR_Click(object sender, EventArgs e)
        {
            DialogResult c = MessageBox.Show("Faturayı Gib'e Gönderilmedi olarak işaretlemek istediğinize eminmisiniz.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (c == DialogResult.Yes)
            {
                SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
                myConnections.Open();
                int[] selectedRows = gridView_LIST.GetSelectedRows();
                for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
                {
                    DataRow drx = gridView_LIST.GetDataRow(selectedRows[ix]);
                    _FATURA_DURUM_UPDATE(drx["ID"].ToString(), false, drx["FATURANIN_TURU"].ToString());




                    string SQL_ROW = @" UPDATE dbo.FTR_GIB_TRANSFER SET ERP_AKTARILDI='False' Where SIRKET_KODU='{0}'  and ID='{1}'  ";
                    SQL_ROW = string.Format(SQL_ROW, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), drx["ID"].ToString());
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = SQL_ROW;
                        cmd.Connection = myConnections;
                        cmd.ExecuteNonQuery();
                    }
                }
                DATA_LOAD();
            }
        }
    }
}