using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VISION.FINANS.UBL
{
    public class IZIBIZ_CLASS
    {
        public static DataRow Cfg = null;
        public static void Config()
        {
            DataSet CnfgDt = new DataSet();
            using (SqlConnection sqlConn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                sqlConn.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT  *  from dbo.ADM_SIRKET_DONEMLERI where  SIRKET_KODU='" + _GLOBAL_PARAMETERS._SIRKET_KODU + "' and SIRKET_NO='" + _GLOBAL_PARAMETERS._SIRKET_NO + "'", sqlConn);
                dataAdapter.Fill(CnfgDt);
                sqlConn.Close();
            }
            Cfg = CnfgDt.Tables[0].Rows[0];
        }
        static WebService.IziBizSrv.EFaturaOIB _EFaturaOIB = null;
  
        public static WebService.IziBizSrv.EFaturaOIB I2IEInv
        {
            get
            {
                if (_EFaturaOIB == null)
                {
                    _EFaturaOIB = new WebService.IziBizSrv.EFaturaOIB();
                    _EFaturaOIB.Url = Cfg["SRVAdress"].ToString();
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
        public static WebService.IziBizSrv.REQUEST_HEADERType htype { get; set; }
        public static WebService.IzibizSrvEFaturaArchive.REQUEST_HEADERType Erhtype { get; set; }
        bool Sonuc;
        string Mesaj = "";
        public static string SESSIONID = "";
        public static void izibiz_login()
        {
            Config();

            htype = new WebService.IziBizSrv.REQUEST_HEADERType();
            htype.SESSION_ID = "0";
            htype.CHANNEL_NAME = Cfg["ENTCHANNEL_NAME"].ToString();
            htype.REASON = Cfg["ENTREASON"].ToString();

            htype.HOSTNAME = System.Environment.MachineName;
            htype.APPLICATION_NAME = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

            WebService.IziBizSrv.LoginRequest lcont = new WebService.IziBizSrv.LoginRequest();
            lcont.REQUEST_HEADER = htype;
            lcont.USER_NAME = Cfg["ENTUSERNAME"].ToString();
            lcont.PASSWORD = Cfg["ENTPASS"].ToString();

            WebService.IziBizSrv.LoginResponse lres = I2IEInv.Login(lcont);
            if (lres == null || lres.SESSION_ID.Trim() == "" || lres.SESSION_ID.Trim() == "0")
            {
                throw new Exception("Session ID alınamadı result GIB..");
            }
            else
            {
                htype.SESSION_ID = FINANS.UBL.IZIBIZ_CLASS.SESSIONID = lres.SESSION_ID;
            } 
            //  return SESSIONID ; 
        }

 



        //private WebService.IzibizSrvEFaturaArchive.EFaturaArchive ArchiveClient = new WebService.IzibizSrvEFaturaArchive.EFaturaArchive();
        ////private EArsivWS_Izibiz.REQUEST_HEADERType RequestHeader;
        ////private EFaturaWS_Izibiz.EFaturaOIBPortClient service = new EFaturaWS_Izibiz.EFaturaOIBPortClient();
        ////private EFaturaWS_Izibiz.REQUEST_HEADERType requestHeader;

        //public void login(String userName, String password)
        //{
        //    System.Console.WriteLine("/****** LOGIN() *******/");

        //    WebService.IzibizSrvEFaturaArchive   loginRequest = new WebService.IzibizSrvEFaturaArchive

        //    loginRequest.USER_NAME = userName;
        //    loginRequest.PASSWORD = password;
        //    loginRequest.REQUEST_HEADER = requestHeader;

        //    EFaturaWS_Izibiz.LoginResponse loginResponse = service.Login(loginRequest);
        //    String sessionId = loginResponse.SESSION_ID;
        //    requestHeader.SESSION_ID = sessionId;
        //    RequestHeader.SESSION_ID = sessionId;
        //}

    }
    public class Response
    {
        public bool Sonuc { get; set; }
        public string Mesaj { get; set; }
        public string SESSIONID { get; set; }
        public WebService.IziBizSrv.GetInvoiceStatusResponse InvStatu { get; set; }
        public WebService.IziBizSrv.INVOICE[] Invs { get; set; }
        public string[] Texts = null;
    }
    public class Parameters
    {
        public ISLEMLER ISLEM { get; set; }
        public string FilePath { get; set; }
        public int INVID { get; set; }
        public string UUID { get; set; }
        public string[] Texts = null;
        public WebService.IziBizSrv.GetInvoiceRequestINVOICE_SEARCH_KEY keys { get; set; }
        public string INVNO { get; set; }
        public string VKN { get; set; }
        public string ALIALS { get; set; }
        // public System.Data.GIBGELEN GIB { get; set; }
        public bool Mark { get; set; }
        public string[] UUIDs { get; set; }
        public WebService.IziBizSrv.INVOICE[] INVS { get; set; }
        public List<SendInvParams> SendListInv { get; set; }
    }
    public class SendInvParams
    {
        public string NO { get; set; }
        public string FILE { get; set; }
        public string GUID { get; set; }
        public int INVID { get; set; }
        public string VKN { get; set; }
        public string SICILNO { get; set; }
        public string MUSTERI { get; set; }
        public string ACIKLAMA { get; set; }
        public DateTime FATURATARIH { get; set; }
        public string PROFILID { get; set; }
        public string TIP { get; set; }
        public decimal TOPLAMTUTAR { get; set; }
        public decimal HESAPLANANKDV { get; set; }
        public decimal TOPLAMINDIRIM { get; set; }
    }
    public enum ISLEMLER : byte
    {
        SendInvoice = 0,
        SendInvoiceStatus = 1,
        GetInvs = 2,
        GetUsers = 3,
        PrepareInvRes = 4,
        MarkInvoice = 5,
        ReadFromArchive = 6,
        LoadInvoice = 7,
        WriteArchive = 8
    }
}
