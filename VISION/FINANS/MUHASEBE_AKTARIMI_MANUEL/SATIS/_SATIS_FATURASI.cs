using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityObjects;
namespace VISION.FINANS.MUHASEBE_AKTARIMI_MANUEL.SATIS
{ 
    public class _SATIS_FATURASI
    {
        System.Collections.ArrayList ArryLISTREF_ID; 
        public int _E_FATURA_KONTROL(string CODE)
        {
            int E_FATURA_KONTROL = 0;
            SqlConnection ConnLine_DEFAULT = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP);
            SqlCommand myCommand_DEFAULT = new SqlCommand();
            string QueryString = " SELECT  *  FROM  dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD  WHERE (dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD.CODE='" + CODE + "')";
            myCommand_DEFAULT.CommandText = QueryString;
            myCommand_DEFAULT.CommandType = System.Data.CommandType.Text;
            myCommand_DEFAULT.Connection = ConnLine_DEFAULT;
            ConnLine_DEFAULT.Open();
            SqlDataReader drd = myCommand_DEFAULT.ExecuteReader(CommandBehavior.CloseConnection);
            while (drd.Read())
            {
                if (drd["ACCEPTEINV"] == DBNull.Value)
                {
                    E_FATURA_KONTROL = 0;
                }
                else
                {
                    if (drd["ACCEPTEINV"].ToString() != "")
                    { E_FATURA_KONTROL = Convert.ToInt16(drd["ACCEPTEINV"].ToString()); }
                    else
                    { E_FATURA_KONTROL = 0; }
                }
            }
            return E_FATURA_KONTROL;
        }

        public string _FATURA_VAR_YOK_KONTROL(string NUMBER)
        {
            int LogicalRef = 0;
            string FATURA_KONTROL = string.Empty;
            //Yeni bir sql sorgusu çalıştırmak istediğimizi belirtiyoruz.                        
            Query Querys = _GLOBAL_PARAMETERS.Global.UnityApp.NewQuery();
            string Query_String = "   SELECT FICHENO,LOGICALREF FROM LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_01_INVOICE  WHERE TRCODE='1'  AND FICHENO='" + NUMBER + "'";
            Querys.Statement = Query_String;
            // Sorguyu çalıştırıyoruz.
            if (Querys.OpenDirect())
            {
                bool eof = Querys.First(); //İlk kayıt isteniyor. Yoksa false döner;
                if (eof)
                {
                    FATURA_KONTROL = Querys.QueryFields[0].Value;
                    LogicalRef = Querys.QueryFields[1].Value;
                }
            }
            return FATURA_KONTROL;
        }

        public int _GLOBAL_CODE_KONTROL(string CODE)
        {
            int _GLOBAL_CODE = 42;
            SqlConnection ConnLine_DEFAULT = new SqlConnection( _GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP);
            SqlCommand myCommand_DEFAULT = new SqlCommand();
            //string QueryString = " SELECT  *  FROM  dbo.LG_" +  _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD  WHERE (dbo.LG_" +  _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD.CODE='" + CODE + "') ";
            string QueryString = "SELECT     dbo.LG_XT003_" +  _GLOBAL_PARAMETERS._SIRKET_NO + ".A_ODEMEARACI, dbo.LG_" +  _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD.CODE FROM  dbo.LG_" +  _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD INNER JOIN   dbo.LG_XT003_" +  _GLOBAL_PARAMETERS._SIRKET_NO + " ON dbo.LG_" +  _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD.LOGICALREF = dbo.LG_XT003_" +  _GLOBAL_PARAMETERS._SIRKET_NO + ".PARLOGREF WHERE (dbo.LG_" +  _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD.CODE='" + CODE + "') ";

            myCommand_DEFAULT.CommandText = QueryString;
            myCommand_DEFAULT.CommandType = System.Data.CommandType.Text;
            myCommand_DEFAULT.Connection = ConnLine_DEFAULT;
            ConnLine_DEFAULT.Open();
            SqlDataReader drd = myCommand_DEFAULT.ExecuteReader(CommandBehavior.CloseConnection);
            while (drd.Read())
            {
                if (drd["A_ODEMEARACI"] == DBNull.Value)
                {
                    _GLOBAL_CODE = 42;
                }
                else
                {
                    if (drd["A_ODEMEARACI"].ToString() == "1")
                    {
                        _GLOBAL_CODE = 20;
                    }
                    else
                    {
                        _GLOBAL_CODE = 42;
                    }
                }
            }
            return _GLOBAL_CODE;
        }

        public string _Insert(int E_FATURA_TYPE, string FATURA_NUMARASI, string FATURA_DATE, int TEMEL_TICARI, string FATURA_SERISI, String _CODE, string FIRMA_KODU)
        {
            string rReturn = string.Empty;
            UnityObjects.IData doSlsInvoice = default(UnityObjects.IData);
            UnityObjects.Lines doSlsInvoiceLines = default(UnityObjects.Lines);

            //  Fatura tipi  alış 1  740.0
            //  alış idade 6         740.0
            //  satış 8              5 İse  601 Değilde 600                                  
            //  satış iade 3          610     // ?
            //  satır tipi 4 hizmet   602 610
            //  0 Malzeme 740 , 600 ,601 , 610
            //  2 indirim  611  

            _GLOBAL_PARAMETERS.Parametler.RAKAMKONTROL Numeric = new _GLOBAL_PARAMETERS.Parametler.RAKAMKONTROL();
            CultureInfo culture = new CultureInfo("tr-TR");
            int lastLogicalRef;
            string DEFNFLD_LEVEL_ = "", DEFNFLD_MODULENR = "", DEFNFLD_PLAN_KODU = "", DEFNFLD_MECRA_TURU = "", DEFNFLD_DOC_TRACK_NR = "", DEFNFLD_FATURA_BASKI_SEKLI = "",
                    DEFNFLD_FAKTORING_SIRKETI_KODU = "", DEFNFLD_ILGILI_FATURA_NO = "", DEFNFLD_SIPARISI_VEREN = "", DEFNFLD_DEPARTMAN = "", DEFNFLD_BOLGE_KODU = "",
                    DEFNFLD_ILGILI_IS_UNITESI = "", DEFNFLD_EFATURA_KODU = "", DEFNFLD_NOTES = "", MUSTERI_VAR = "";
            int INVOICE_REF_ID = 0;
            if (_GLOBAL_PARAMETERS.Global.UnityApp.Connected)
            {
                ////Yeni bir sql sorgusu çalıştırmak istediğimizi belirtiyoruz.     
                // mySelectQuery = "  SELECT * FROM dbo.FTR_LG_INVOICE  WHERE SIRKET_KODU='" + _GLOBAL_PARAMETERS._SIRKET_KODU + "' AND  (AKTARIM_DURUMU =N'BEKLEMEDE' or AKTARIM_DURUMU =N'AKTARILMADI' )  AND (NUMBER='" + FATURA_NUMARASI + "') ";
                string sqlControl = "  SELECT * FROM dbo.FTR_LG_INVOICE WHERE SIRKET_KODU='" + _GLOBAL_PARAMETERS._SIRKET_KODU + "' AND (NUMBER='" + FATURA_NUMARASI + "') ";
                SqlConnection Conn = new SqlConnection( _GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
                SqlCommand myCommandSub = new SqlCommand(sqlControl, Conn);
                Conn.Open();
                SqlDataReader doSlsINVOICEHDR = myCommandSub.ExecuteReader(CommandBehavior.CloseConnection);
                while (doSlsINVOICEHDR.Read())
                {
                    if (doSlsINVOICEHDR["CODE"].ToString() == "") return rReturn = "CARİ KOD BULUNAMADI"; 

                    //string GIB_KONTROL = "";
                    //using (SqlConnection cngib = new SqlConnection( _GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                    //{
                    //    string sql = " select * from   GIBUSERS_LIST Where  IDENTIFIER=@TAX_ID ";
                    //    SqlCommand cmdgib = new SqlCommand();
                    //    cmdgib.Parameters.AddWithValue("@TAX_ID", doSlsINVOICEHDR["TAX_ID"]);
                    //    cmdgib.CommandText = sql;
                    //    cmdgib.CommandType = System.Data.CommandType.Text;
                    //    cmdgib.Connection = cngib;
                    //    cngib.Open();
                    //    SqlDataReader rdgib = cmdgib.ExecuteReader(CommandBehavior.CloseConnection); 
                    //    while (rdgib.Read())
                    //    {
                    //        GIB_KONTROL = "ONAYLANDI";
                    //    }
                    //}
                    //if (GIB_KONTROL == "") return rReturn = "GİB KULLANICISI BULUNAMADI";

                    INVOICE_REF_ID = Convert.ToInt32(doSlsINVOICEHDR["ID"]);
                    // _GLOBAL_PARAMETERS.Utilities utl = new _GLOBAL_PARAMETERS.Utilities();
                     _GLOBAL_PARAMETERS utl = new _GLOBAL_PARAMETERS();

                    doSlsInvoice = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doSalesInvoice);
                    doSlsInvoice.New();
                    doSlsInvoice.DataFields.FieldByName("TYPE").Value = doSlsINVOICEHDR["TYPE"];  
                    if (E_FATURA_TYPE == 1)
                    {
                        if (FATURA_SERISI == null) { doSlsInvoice.DataFields.FieldByName("NUMBER").Value = "~"; }
                        else
                        {
                            using (SqlConnection conn = new SqlConnection( _GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP))
                            {
                                using (SqlCommand cmd = new SqlCommand())
                                {
                                    string sql = "    SELECT REPLACE(MAX(FICHENO), '" + FATURA_SERISI + "', '') as FICHENO FROM  LG_" +  _GLOBAL_PARAMETERS._SIRKET_NO + "_01_INVOICE  WHERE EINVOICE=1 and (TRCODE=8 or TRCODE=9 or TRCODE=6) and FICHENO LIKE '" + FATURA_SERISI + "%'";
                                    cmd.CommandText = sql;
                                    cmd.CommandType = System.Data.CommandType.Text;
                                    cmd.Connection = conn;
                                    conn.Open();
                                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection); 
                                    while (rdr.Read())
                                    {
                                        int Count = 0;
                                        if (rdr["FICHENO"] != DBNull.Value)
                                        { Count = Int16.Parse(rdr["FICHENO"].ToString()); } 
                                        Count++;
                                        string FATURA_NO = FATURA_SERISI + Count.ToString();
                                        for (int i = 0; i <= 16; i++)
                                        {
                                            if (FATURA_NO.ToString().Length < 16)
                                            {
                                                FATURA_SERISI += "0";
                                                FATURA_NO = FATURA_SERISI + Count.ToString();
                                            }
                                        }
                                        doSlsInvoice.DataFields.FieldByName("NUMBER").Value = FATURA_SERISI + Count.ToString();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        doSlsInvoice.DataFields.FieldByName("NUMBER").Value = doSlsINVOICEHDR["NUMBER"];
                    }

                    doSlsInvoice.DataFields.FieldByName("EINVOICE").Value = E_FATURA_TYPE;// doSlsINVOICEHDR["EINVOICE"];       
                    doSlsInvoice.DataFields.FieldByName("PROFILE_ID").Value = TEMEL_TICARI.ToString();
                    DateTime DATE_;
                    if (FATURA_DATE != null) { DATE_ = Convert.ToDateTime(FATURA_DATE); } else { DATE_ = Convert.ToDateTime(doSlsINVOICEHDR["DATE"].ToString()); } 

                    doSlsInvoice.DataFields.FieldByName("DATE").Value = DATE_.ToString("dd/MM/yyyy");
                    doSlsInvoice.DataFields.FieldByName("DOC_TRACK_NR").Value = doSlsINVOICEHDR["DOC_TRACK_NR"];
                    doSlsInvoice.DataFields.FieldByName("DOC_NUMBER").Value = doSlsINVOICEHDR["DOC_NUMBER"];
                    doSlsInvoice.DataFields.FieldByName("ARP_CODE").Value = doSlsINVOICEHDR["ARP_CODE"];
                    doSlsInvoice.DataFields.FieldByName("GL_CODE").Value = doSlsINVOICEHDR["GL_CODE"];

                    string _createClientCode = utl.createClientCode( _GLOBAL_PARAMETERS._SIRKET_NO, doSlsINVOICEHDR["CODE"].ToString(), doSlsINVOICEHDR["TITLE"].ToString(), doSlsINVOICEHDR["ADDRESS1"].ToString(), doSlsINVOICEHDR["ADDRESS2"].ToString(), doSlsINVOICEHDR["CITY"].ToString(), doSlsINVOICEHDR["TAX_OFFICE"].ToString(), doSlsINVOICEHDR["TAX_ID"].ToString()).ToString();
                    string _CreateGlCard = utl.CreateGlCard( _GLOBAL_PARAMETERS._SIRKET_NO, doSlsINVOICEHDR["GL_CODE"].ToString(), doSlsINVOICEHDR["TITLE"].ToString()).ToString();

                    doSlsInvoice.DataFields.FieldByName("ARP_CODE").Value = _createClientCode;
                    doSlsInvoice.DataFields.FieldByName("GL_CODE").Value = _CreateGlCard;
                    doSlsInvoice.DataFields.FieldByName("VAT_RATE").Value = doSlsINVOICEHDR["VAT_RATE"];
                    doSlsInvoice.DataFields.FieldByName("ADD_DISCOUNTS").Value = doSlsINVOICEHDR["ADD_DISCOUNTS"];
                    doSlsInvoice.DataFields.FieldByName("TOTAL_DISCOUNTS").Value = doSlsINVOICEHDR["TOTAL_DISCOUNTS"];
                    doSlsInvoice.DataFields.FieldByName("TOTAL_VAT").Value = doSlsINVOICEHDR["TOTAL_VAT"];
                    doSlsInvoice.DataFields.FieldByName("TOTAL_GROSS").Value = doSlsINVOICEHDR["TOTAL_GROSS"];
                    doSlsInvoice.DataFields.FieldByName("TOTAL_NET").Value = doSlsINVOICEHDR["TOTAL_NET"];
                    doSlsInvoice.DataFields.FieldByName("PAYPLAN_GLOBAL_CODE").Value = _GLOBAL_CODE_KONTROL(_CODE); 
                    doSlsInvoice.DataFields.FieldByName("TC_XRATE").Value = doSlsINVOICEHDR["TC_XRATE"];
                    doSlsInvoice.DataFields.FieldByName("RC_NET").Value = doSlsINVOICEHDR["RC_NET"];
                    doSlsInvoice.DataFields.FieldByName("RC_XRATE").Value = doSlsINVOICEHDR["RC_XRATE"];
                    doSlsInvoice.DataFields.FieldByName("CURRSEL_TOTALS").Value = doSlsINVOICEHDR["CURRSEL_TOTALS"];
                    doSlsInvoice.DataFields.FieldByName("CURRSEL_DETAILS").Value = doSlsINVOICEHDR["CURRSEL_DETAILS"]; 

                    //Invoice.DataFields.FieldByName("ACCOUNT_TYPE").Value =  myReaderSub["ACCOUNT_TYPE"]; 
                    /// BUNLARI SOR 
                    //Invoice.DataFields.FieldByName("CODE").Value = myReaderSub["CODE"];
                    //Invoice.DataFields.FieldByName("TITLE").Value = myReaderSub["TITLE"];
                    //Invoice.DataFields.FieldByName("ADDRESS1").Value = myReaderSub["ADDRESS1"];
                    //Invoice.DataFields.FieldByName("ADDRESS2").Value = myReaderSub["ADDRESS2"];
                    //Invoice.DataFields.FieldByName("CITY").Value = myReaderSub["CITY"];
                    //Invoice.DataFields.FieldByName("POSTAL_CODE").Value = myReaderSub["POSTAL_CODE"];
                    //Invoice.DataFields.FieldByName("TELEPHONE1").Value = myReaderSub["TELEPHONE1"];
                    //Invoice.DataFields.FieldByName("FAX").Value = myReaderSub["FAX"];
                    //Invoice.DataFields.FieldByName("TAX_OFFICE").Value = myReaderSub["TAX_OFFICE"];
                    //Invoice.DataFields.FieldByName("TAX_ID").Value = myReaderSub["TAX_ID"];                    
                    //Yeni bir sql sorgusu çalıştırmak istediğimizi belirtiyoruz.    ACCEPTEINV        

                    if (doSlsINVOICEHDR["CURR_INVOICE"] != DBNull.Value)
                    {
                        doSlsInvoice.DataFields.FieldByName("CURR_INVOICE").Value = doSlsINVOICEHDR["CURR_INVOICE"];
                        doSlsInvoice.DataFields.FieldByName("TC_NET").Value = doSlsINVOICEHDR["TC_NET"];
                    }
                    else
                    {
                        doSlsInvoice.DataFields.FieldByName("TC_NET").Value = 0;
                        doSlsInvoice.DataFields.FieldByName("CURR_INVOICE").Value = 0;
                    } 

                    /// LINE EXTENTION COLUMS READ  
                    //DEFNFLD_LEVEL_ = doSlsINVOICEHDR["DEFNFLD_LEVEL_"].ToString();
                    //DEFNFLD_MODULENR = doSlsINVOICEHDR["DEFNFLD_MODULENR"].ToString();
                    DEFNFLD_PLAN_KODU = doSlsINVOICEHDR["DEFNFLD_PLAN_KODU"].ToString();
                    DEFNFLD_MECRA_TURU = doSlsINVOICEHDR["DEFNFLD_MECRA_TURU"].ToString();
                    DEFNFLD_DOC_TRACK_NR = doSlsINVOICEHDR["DOC_TRACK_NR"].ToString(); 
                    DEFNFLD_FATURA_BASKI_SEKLI = doSlsINVOICEHDR["DEFNFLD_FATURA_BASKI_SEKLI"].ToString();
                    DEFNFLD_FAKTORING_SIRKETI_KODU = doSlsINVOICEHDR["DEFNFLD_FAKTORING_SIRKETI_KODU"].ToString();
                    DEFNFLD_ILGILI_FATURA_NO = doSlsINVOICEHDR["DEFNFLD_ILGILI_FATURA_NO"].ToString();
                    DEFNFLD_SIPARISI_VEREN = doSlsINVOICEHDR["DEFNFLD_SIPARISI_VEREN"].ToString();
                    DEFNFLD_DEPARTMAN = doSlsINVOICEHDR["DEFNFLD_DEPARTMAN"].ToString();
                    DEFNFLD_BOLGE_KODU = doSlsINVOICEHDR["DEFNFLD_BOLGE_KODU"].ToString();
                    DEFNFLD_ILGILI_IS_UNITESI = doSlsINVOICEHDR["DEFNFLD_ILGILI_IS_UNITESI"].ToString();
                    DEFNFLD_EFATURA_KODU = doSlsINVOICEHDR["DEFNFLD_EFATURA_KODU"].ToString(); 

                    /// LINE EXTENTION NOTES READ
                    using (SqlConnection ConnLineEx = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                    {
                        using (SqlCommand myCommandSubLineEx = new SqlCommand())
                        {
                            string mySelectQueryEx = "  SELECT  * FROM   dbo.ADM_MUSTERI  where    MUSTERI_KODU=@MUSTERI_KODU  ";
                            myCommandSubLineEx.Parameters.AddWithValue("@MUSTERI_KODU", doSlsINVOICEHDR["DEFNFLD_MUSTERI_KODU"]);
                            myCommandSubLineEx.CommandText = mySelectQueryEx;
                            myCommandSubLineEx.CommandType = System.Data.CommandType.Text;
                            myCommandSubLineEx.Connection = ConnLineEx;
                            ConnLineEx.Open();
                            SqlDataReader myReaderSubLineEx = myCommandSubLineEx.ExecuteReader(CommandBehavior.CloseConnection);
                            while (myReaderSubLineEx.Read())
                            {
                                MUSTERI_VAR = "VAR";
                                if (Convert.ToBoolean(myReaderSubLineEx["OZEL_DURUM"]))
                                {
                                    string VERI = doSlsINVOICEHDR[myReaderSubLineEx["KONTROL_ALANI"].ToString()].ToString();
                                    string DURUM_TYPE = myReaderSubLineEx["DURUMU"].ToString();
                                    if (DURUM_TYPE == "BOŞ")
                                    {
                                        if (VERI == "")
                                        {
                                            SqlConnection ConnLine_DEFAULT = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
                                            SqlCommand myCommand_DEFAULT = new SqlCommand();
                                            string YAPI_STRING = myReaderSubLineEx["DEFAULT_TEXT"].ToString();
                                            myCommand_DEFAULT.Parameters.AddWithValue("@MUSTERI_KODU", myReaderSubLineEx["MUSTERI_KODU"]);
                                            myCommand_DEFAULT.CommandText = "SELECT  * FROM     dbo.ADM_MUSTERI_PARAMETRE_DEFAULT  where    MUSTERI_KODU=@MUSTERI_KODU  ";
                                            myCommand_DEFAULT.CommandType = System.Data.CommandType.Text;
                                            myCommand_DEFAULT.Connection = ConnLine_DEFAULT;
                                            ConnLine_DEFAULT.Open();
                                            SqlDataReader myReader_DEFAULT = myCommand_DEFAULT.ExecuteReader(CommandBehavior.CloseConnection);
                                            while (myReader_DEFAULT.Read())
                                            {
                                                bool BASLIKKONTROL = true;
                                                if (myReader_DEFAULT["BASLIK"] == DBNull.Value) { BASLIKKONTROL = false; }
                                                else { if ((bool)myReader_DEFAULT["BASLIK"])   BASLIKKONTROL = true; else   BASLIKKONTROL = false; }

                                                if (BASLIKKONTROL)
                                                {
                                                    YAPI_STRING = YAPI_STRING.Replace(myReader_DEFAULT["DEFAULT_TEXT"].ToString(), myReader_DEFAULT["DEFAULT_TEXT"].ToString() + doSlsINVOICEHDR[myReader_DEFAULT["DEFAULT_FIELD"].ToString()].ToString());
                                                }
                                                else
                                                {
                                                    YAPI_STRING = YAPI_STRING.Replace(myReader_DEFAULT["DEFAULT_TEXT"].ToString(), doSlsINVOICEHDR[myReader_DEFAULT["DEFAULT_FIELD"].ToString()].ToString());
                                                }
                                            }
                                            DEFNFLD_NOTES = YAPI_STRING;
                                        }
                                        else
                                        {
                                            SqlConnection ConnLine_DEFAULT = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
                                            SqlCommand myCommand_DEFAULT = new SqlCommand();
                                            string YAPI_STRING = myReaderSubLineEx["TEMP_TEXT"].ToString();
                                            myCommand_DEFAULT.Parameters.AddWithValue("@MUSTERI_KODU", myReaderSubLineEx["MUSTERI_KODU"]);
                                            myCommand_DEFAULT.CommandText = "SELECT  * FROM     dbo.ADM_MUSTERI_PARAMETRE_TEMP  where    MUSTERI_KODU=@MUSTERI_KODU  ";
                                            myCommand_DEFAULT.CommandType = System.Data.CommandType.Text;
                                            myCommand_DEFAULT.Connection = ConnLine_DEFAULT;
                                            ConnLine_DEFAULT.Open();
                                            SqlDataReader myReader_DEFAULT = myCommand_DEFAULT.ExecuteReader(CommandBehavior.CloseConnection);
                                            while (myReader_DEFAULT.Read())
                                            {
                                                bool BASLIKKONTROL = true;
                                                if (myReader_DEFAULT["BASLIK"] == DBNull.Value) { BASLIKKONTROL = false; }
                                                else { if ((bool)myReader_DEFAULT["BASLIK"])   BASLIKKONTROL = true; else   BASLIKKONTROL = false; }

                                                if (BASLIKKONTROL)
                                                {
                                                    YAPI_STRING = YAPI_STRING.Replace(myReader_DEFAULT["TEMP_TEXT"].ToString(), myReader_DEFAULT["TEMP_TEXT"].ToString() + doSlsINVOICEHDR[myReader_DEFAULT["TEMP_FIELD"].ToString()].ToString());
                                                }
                                                else
                                                {
                                                    YAPI_STRING = YAPI_STRING.Replace(myReader_DEFAULT["TEMP_TEXT"].ToString(), doSlsINVOICEHDR[myReader_DEFAULT["TEMP_FIELD"].ToString()].ToString());
                                                }
                                            }
                                            DEFNFLD_NOTES = YAPI_STRING;
                                        }
                                    }
                                    if (DURUM_TYPE == "DOLU")
                                    {
                                        if (VERI != "")
                                        {
                                            SqlConnection ConnLine_DEFAULT = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
                                            SqlCommand myCommand_DEFAULT = new SqlCommand();
                                            string YAPI_STRING = myReaderSubLineEx["DEFAULT_TEXT"].ToString();
                                            myCommand_DEFAULT.Parameters.AddWithValue("@MUSTERI_KODU", myReaderSubLineEx["MUSTERI_KODU"]);
                                            myCommand_DEFAULT.CommandText = "SELECT  * FROM     dbo.ADM_MUSTERI_PARAMETRE_DEFAULT  where    MUSTERI_KODU=@MUSTERI_KODU  ";
                                            myCommand_DEFAULT.CommandType = System.Data.CommandType.Text;
                                            myCommand_DEFAULT.Connection = ConnLine_DEFAULT;
                                            ConnLine_DEFAULT.Open();
                                            SqlDataReader myReader_DEFAULT = myCommand_DEFAULT.ExecuteReader(CommandBehavior.CloseConnection);
                                            while (myReader_DEFAULT.Read())
                                            {
                                                bool BASLIKKONTROL = true;
                                                if (myReader_DEFAULT["BASLIK"] == DBNull.Value) { BASLIKKONTROL = false; }
                                                else { if ((bool)myReader_DEFAULT["BASLIK"])   BASLIKKONTROL = true; else   BASLIKKONTROL = false; }

                                                if (BASLIKKONTROL)
                                                {
                                                    YAPI_STRING = YAPI_STRING.Replace(myReader_DEFAULT["DEFAULT_TEXT"].ToString(), myReader_DEFAULT["DEFAULT_TEXT"].ToString() + doSlsINVOICEHDR[myReader_DEFAULT["DEFAULT_FIELD"].ToString()].ToString());
                                                }
                                                else
                                                {
                                                    YAPI_STRING = YAPI_STRING.Replace(myReader_DEFAULT["DEFAULT_TEXT"].ToString(), doSlsINVOICEHDR[myReader_DEFAULT["DEFAULT_FIELD"].ToString()].ToString());
                                                }
                                            }
                                            DEFNFLD_NOTES = YAPI_STRING;
                                        }
                                        else
                                        {
                                            SqlConnection ConnLine_DEFAULT = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
                                            SqlCommand myCommand_DEFAULT = new SqlCommand();
                                            string YAPI_STRING = myReaderSubLineEx["TEMP_TEXT"].ToString();
                                            myCommand_DEFAULT.Parameters.AddWithValue("@MUSTERI_KODU", myReaderSubLineEx["MUSTERI_KODU"]);
                                            myCommand_DEFAULT.CommandText = "SELECT  * FROM     dbo.ADM_MUSTERI_PARAMETRE_TEMP  where    MUSTERI_KODU=@MUSTERI_KODU  ";
                                            myCommand_DEFAULT.CommandType = System.Data.CommandType.Text;
                                            myCommand_DEFAULT.Connection = ConnLine_DEFAULT;
                                            ConnLine_DEFAULT.Open();
                                            SqlDataReader myReader_DEFAULT = myCommand_DEFAULT.ExecuteReader(CommandBehavior.CloseConnection);
                                            while (myReader_DEFAULT.Read())
                                            {
                                                bool BASLIKKONTROL = true;
                                                if (myReader_DEFAULT["BASLIK"] == DBNull.Value) { BASLIKKONTROL = false; }
                                                else { if ((bool)myReader_DEFAULT["BASLIK"])   BASLIKKONTROL = true; else   BASLIKKONTROL = false; }

                                                if (BASLIKKONTROL)
                                                {
                                                    YAPI_STRING = YAPI_STRING.Replace(myReader_DEFAULT["TEMP_TEXT"].ToString(), myReader_DEFAULT["TEMP_TEXT"].ToString() + doSlsINVOICEHDR[myReader_DEFAULT["TEMP_FIELD"].ToString()].ToString());
                                                }
                                                else
                                                {
                                                    YAPI_STRING = YAPI_STRING.Replace(myReader_DEFAULT["TEMP_TEXT"].ToString(), doSlsINVOICEHDR[myReader_DEFAULT["TEMP_FIELD"].ToString()].ToString());
                                                }
                                            }
                                            DEFNFLD_NOTES = YAPI_STRING;
                                        }
                                    }
                                }

                            }
                        }
                    }

                    string PO_TEXT = "";
                    if (doSlsINVOICEHDR["DOC_TRACK_NR"].ToString() != "") PO_TEXT = ";PO:" + doSlsINVOICEHDR["DOC_TRACK_NR"].ToString();
                    if (doSlsINVOICEHDR["DEFNFLD_PO_DETAILS"].ToString() != "") PO_TEXT = ";EXT:" + doSlsINVOICEHDR["DEFNFLD_PO_DETAILS"].ToString();

                    char[] karakterler = Convert.ToString(doSlsINVOICEHDR["DEFNFLD_MECRA_TURU"].ToString() + ":" + doSlsINVOICEHDR["NUMBER"].ToString() + PO_TEXT + doSlsINVOICEHDR["NOTES1"].ToString() + ";" + doSlsINVOICEHDR["NOTES1"].ToString() + ";" + doSlsINVOICEHDR["NOTES2"].ToString() + ";" + doSlsINVOICEHDR["NOTES4"].ToString()).ToString().ToCharArray();
                    string Line1 = "";
                    string Line2 = "";
                    string Line3 = "";
                    string Line4 = "";
                    for (int i = 0; i <= karakterler.Length - 1; i++)
                    {
                        if (i <= 49) Line1 += karakterler[i].ToString();
                        if (i > 49 && i <= 99) Line2 += karakterler[i].ToString();
                        if (i > 99 && i <= 149) Line3 += karakterler[i].ToString();
                        if (i > 149 && i <= 199) Line4 += karakterler[i].ToString();
                    }
                    doSlsInvoice.DataFields.FieldByName("NOTES1").Value = Line1;
                    doSlsInvoice.DataFields.FieldByName("NOTES2").Value = Line2;
                    doSlsInvoice.DataFields.FieldByName("NOTES3").Value = Line3;
                    doSlsInvoice.DataFields.FieldByName("NOTES4").Value = Line4;

                    if (DEFNFLD_NOTES == "")
                    {
                        for (int i = 0; i <= karakterler.Length - 1; i++)
                        {
                            DEFNFLD_NOTES += karakterler[i].ToString();
                        }
                    }
                    // DateTime DOC_DATE_ = Convert.ToDateTime(doSlsINVOICEHDR["DOC_DATE"].ToString());
                    doSlsInvoice.DataFields.FieldByName("DOC_DATE").Value = DATE_.ToString("dd/MM/yyyy");
                    doSlsInvoice.DataFields.FieldByName("DATA_REFERENCE").Value = "~";

                    string mySelectQueryLine = "  SELECT  *  FROM     dbo.FTR_LG_STLINE  where  SIRKET_KODU=@SIRKET_KODU AND   INVOICE_REF=@INVOICE_REF";
                    SqlConnection ceConnLine = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
                    SqlCommand myCommandSubLine = new SqlCommand();
                    myCommandSubLine.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    myCommandSubLine.Parameters.AddWithValue("@INVOICE_REF", INVOICE_REF_ID);
                    myCommandSubLine.CommandText = mySelectQueryLine;
                    myCommandSubLine.CommandType = System.Data.CommandType.Text;
                    myCommandSubLine.Connection = ceConnLine;
                    ceConnLine.Open();
                    SqlDataReader doSlsINVOICELine = myCommandSubLine.ExecuteReader(CommandBehavior.CloseConnection);
                    doSlsInvoiceLines = doSlsInvoice.DataFields.FieldByName("TRANSACTIONS").Lines;
                    int ODEMEVADESI = 0;
                    while (doSlsINVOICELine.Read())
                    {
                        if (doSlsInvoiceLines.AppendLine())
                        {

                            string YONLENDIRME_CODE = "";
                            using (SqlConnection ConnLineEx = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                            {
                                using (SqlCommand myCommandSubLineEx = new SqlCommand())
                                {
                                    string mySelectQueryEx = "  SELECT  CAR_HESAP_KODU FROM     dbo.FTR_CARI_AKTARIM_LISTESI  where    CAR_HESAP_KODU=@AUXIL_CODE ";
                                    myCommandSubLineEx.Parameters.AddWithValue("@AUXIL_CODE", doSlsINVOICELine["AUXIL_CODE"]);
                                    myCommandSubLineEx.CommandText = mySelectQueryEx;
                                    myCommandSubLineEx.CommandType = System.Data.CommandType.Text;
                                    myCommandSubLineEx.Connection = ConnLineEx;
                                    ConnLineEx.Open();
                                    SqlDataReader myReaderSubLineEx = myCommandSubLineEx.ExecuteReader(CommandBehavior.CloseConnection);
                                    while (myReaderSubLineEx.Read())
                                    {
                                        YONLENDIRME_CODE=myReaderSubLineEx["CAR_HESAP_KODU"].ToString ();
                                    }
                                }
                            }

                            int STOPAJ_ROW = 0;
                            string doSlsINVOICELine_Control = "0";

                            if (doSlsINVOICELine["TYPE"].ToString() == "-1")
                            { doSlsINVOICELine_Control = "0"; STOPAJ_ROW = 1; }
                            else
                            {
                                { doSlsINVOICELine_Control = doSlsINVOICELine["TYPE"].ToString() ; STOPAJ_ROW = 0; }
                            }

                            if (doSlsINVOICELine_Control == "0")
                            {
                                string _CreateItems = utl.createItemCode(doSlsINVOICELine["MASTER_CODE"].ToString(), doSlsINVOICELine["NAME"].ToString(),  _GLOBAL_PARAMETERS._SIRKET_NO, "ADET", doSlsINVOICELine["VAT_RATE"].ToString(), doSlsINVOICEHDR["CODE"].ToString(), doSlsINVOICEHDR["TITLE"].ToString(), DATE_.Year.ToString(), STOPAJ_ROW.ToString() ).ToString();

                                int XC= _CreateItems.IndexOf("HATA;");
                                if (XC > 1) 
                                {

                                    using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                                    {
                                        myConnections.Open();
                                        DateTime dtm = DateTime.Now;
                                        using (SqlCommand myCmd = new SqlCommand())
                                        {
                                            myCmd.CommandText = "  UPDATE dbo.FTR_LG_INVOICE   SET AKTARIM_DURUMU='AKTARILMADI', AKTARIM_SORUMLUSU=@AKTARIM_SORUMLUSU,AKTARIM_TARIHI=@AKTARIM_TARIHI,AKTARIM_NOTU=@AKTARIM_NOTU  WHERE  SIRKET_KODU=@SIRKET_KODU AND (NUMBER=@FATURA_NUMARASI) ";

                                            myCmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                                            myCmd.Parameters.AddWithValue("@FATURA_NUMARASI", FATURA_NUMARASI);
                                            myCmd.Parameters.AddWithValue("@AKTARIM_SORUMLUSU", _GLOBAL_PARAMETERS._KULLANICI_MAIL);
                                            myCmd.Parameters.AddWithValue("@AKTARIM_TARIHI", dtm.ToString("yyyy-MM-dd hh:mm:ss"));
                                            myCmd.Parameters.AddWithValue("@AKTARIM_NOTU", _CreateItems);
                                            myCmd.Connection = myConnections;
                                            myCmd.ExecuteNonQuery();
                                        }
                                    }
                                         break; 
                                }  
                                doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("TYPE").Value = doSlsINVOICELine_Control;
                                doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("MASTER_CODE").Value = _CreateItems;
                                string[] OitemCode = _CreateItems.Split('-');
                                if (OitemCode[0].ToString() == ",") return rReturn = OitemCode[1].ToString();  
                                if (doSlsINVOICEHDR["TYPE"].ToString() == "8")
                                {
                                    if (OitemCode[2].Substring(0, 1).ToString() == "5") // DOVİZ HESABINA AKTAR
                                    {                                       
                                        if (Convert.ToInt32(OitemCode[0]) >= 15)
                                        {                                       
                                            string ITEM_CODE = OitemCode[0].Substring(0, 2);
                                            string ITEM_TYPE = OitemCode[0].Substring(2, OitemCode[0].Length - 2);
                                            if (STOPAJ_ROW == 0)
                                            {
                                                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                                                {
                                                    string SQL = " SELECT * from dbo.FTR_INTERNET_KATEGORI_LISTESI WHERE YIL='" + DATE_.Year + "'";
                                                    SqlCommand myCommand = new SqlCommand(SQL, myConnection);
                                                    myCommand.CommandText = SQL.ToString();
                                                    myConnection.Open();
                                                    SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                                                    while (myReader.Read())
                                                    {
                                                        if (Convert.ToInt32(ITEM_TYPE) >= Convert.ToInt32(myReader["MUHASEBE_KODU_BAS"].ToString()) && Convert.ToInt32(ITEM_TYPE) <= Convert.ToInt32(myReader["MUHASEBE_KODU_BIT"].ToString()))
                                                        {
                                                            ITEM_CODE = myReader["TRANSFER_KODU"].ToString();
                                                            break;
                                                        }
                                                    }
                                                    myReader.Close();
                                                    myCommand.Connection.Close();
                                                }
                                            }

                                            if (DATE_.Year.ToString() == "2019") ITEM_TYPE = ITEM_TYPE.Substring(1, ITEM_TYPE.Length - 1); 


                                            if (ITEM_TYPE.Length < 3) ITEM_TYPE = "0" + ITEM_TYPE;
                                            if (ITEM_TYPE.Length < 3) ITEM_TYPE = "0" + ITEM_TYPE; 
                                            string _CARDID = utl.createItemCode(doSlsINVOICELine["MASTER_CODE"].ToString(), doSlsINVOICELine["NAME"].ToString(), _GLOBAL_PARAMETERS._SIRKET_NO, "ADET", doSlsINVOICELine["VAT_RATE"].ToString(), doSlsINVOICEHDR["CODE"].ToString(), doSlsINVOICEHDR["TITLE"].ToString(), DATE_.Year.ToString(), STOPAJ_ROW.ToString() ).ToString();


                                            if (STOPAJ_ROW==0)
                                            {
                                                doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "600." + ITEM_CODE + "." + ITEM_TYPE + "." + OitemCode[2];
                                            }
                                            else
                                            {
                                                doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "600.50.001."+ OitemCode[2];
                                            }
                                            

                                            // doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "601." + ITEM_CODE + "." + ITEM_TYPE + "." + OitemCode[2]; 
                                            // doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "601.0" + OitemCode[0] + ".001." + OitemCode[2];
                                        }
                                        else
                                        {
                                             doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "601.0" + OitemCode[0] + ".001." + OitemCode[2];
                                        }
                                    }
                                    else
                                    {          
                                        if (Convert.ToInt32(OitemCode[0]) >= 15)
                                        { 
                                            string ITEM_CODE = OitemCode[0].Substring(0, 2);
                                            string ITEM_TYPE = OitemCode[0].Substring(2, OitemCode[0].Length - 2);

                                            if (STOPAJ_ROW ==0)
                                            {
                                                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                                                {
                                                    string SQL = " SELECT * from dbo.FTR_INTERNET_KATEGORI_LISTESI WHERE YIL='" + DATE_.Year + "'";
                                                    SqlCommand myCommand = new SqlCommand(SQL, myConnection);
                                                    myCommand.CommandText = SQL.ToString();
                                                    myConnection.Open();
                                                    SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                                                    while (myReader.Read())
                                                    {
                                                        if (Convert.ToInt32(ITEM_TYPE) >= Convert.ToInt32(myReader["MUHASEBE_KODU_BAS"].ToString()) && Convert.ToInt32(ITEM_TYPE) <= Convert.ToInt32(myReader["MUHASEBE_KODU_BIT"].ToString()))
                                                        {
                                                            ITEM_CODE = myReader["TRANSFER_KODU"].ToString();
                                                            break;
                                                        }
                                                    }
                                                    myReader.Close();
                                                    myCommand.Connection.Close();
                                                }
                                            }
                                            if (DATE_.Year.ToString() == "2019") ITEM_TYPE = ITEM_TYPE.Substring(1, ITEM_TYPE.Length - 1);

 
                                            if (ITEM_TYPE.Length < 3) ITEM_TYPE = "0" + ITEM_TYPE;
                                            if (ITEM_TYPE.Length < 3) ITEM_TYPE = "0" + ITEM_TYPE;

                                            if (YONLENDIRME_CODE == "")
                                            { 
                                                if (STOPAJ_ROW == 0)
                                                {
                                                    doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "600." + ITEM_CODE + "." + ITEM_TYPE + "." + OitemCode[2];
                                                }
                                                else
                                                {
                                                    doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "600.50.001." + OitemCode[2];
                                                } 

                                            }
                                            else
                                            {
                                                //doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "602." + ITEM_CODE + "." + ITEM_TYPE + "." + OitemCode[2];


                                                if (STOPAJ_ROW == 0)
                                                {
                                                    doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "602." + ITEM_CODE + "." + ITEM_TYPE + "." + OitemCode[2];
                                                }
                                                else
                                                {
                                                    doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "602.50.001." + OitemCode[2];
                                                }

                                            }
                                        }
                                        else
                                        {
                                            if (YONLENDIRME_CODE == "")
                                            {
                                                doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "600.0" + OitemCode[0] + ".001." + OitemCode[2];
                                            }
                                           else
                                            {
                                                doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "602.0" + OitemCode[0] + ".001." + OitemCode[2];
                                            }
                                        }
                                    }
                                  doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE2").Value = "391.01.001.0001";
                                } 
                                if (doSlsINVOICEHDR["TYPE"].ToString() == "3")
                                {
                                    if (Convert.ToInt32(OitemCode[0]) >= 15)
                                    { 
                                        string ITEM_CODE = OitemCode[0].Substring(0, 2);
                                        string ITEM_TYPE = OitemCode[0].Substring(2, OitemCode[0].Length - 2);
                                        if (STOPAJ_ROW == 0)
                                        {
                                            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                                            {
                                                string SQL = " SELECT * from dbo.FTR_INTERNET_KATEGORI_LISTESI WHERE YIL='" + DATE_.Year + "'";
                                                SqlCommand myCommand = new SqlCommand(SQL, myConnection);
                                                myCommand.CommandText = SQL.ToString();
                                                myConnection.Open();
                                                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                                                while (myReader.Read())
                                                {
                                                    if (Convert.ToInt16(ITEM_TYPE) >= Convert.ToInt16(myReader["MUHASEBE_KODU_BAS"].ToString()) && Convert.ToInt16(ITEM_TYPE) <= Convert.ToInt16(myReader["MUHASEBE_KODU_BIT"].ToString()))
                                                    {
                                                        ITEM_CODE = myReader["TRANSFER_KODU"].ToString();
                                                        break;
                                                    }
                                                }
                                                myReader.Close();
                                                myCommand.Connection.Close();
                                            }
                                        }
                                        if (DATE_.Year.ToString() == "2019") ITEM_TYPE = ITEM_TYPE.Substring(1, ITEM_TYPE.Length - 1); 

                                        if (ITEM_TYPE.Length < 3) ITEM_TYPE = "0" + ITEM_TYPE;
                                        if (ITEM_TYPE.Length < 3) ITEM_TYPE = "0" + ITEM_TYPE;

                                   //     doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "610." + ITEM_CODE + "." + ITEM_TYPE + "." + ".001." + OitemCode[2];

                                        if (STOPAJ_ROW == 0)
                                        {
                                            doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "610." + ITEM_CODE + "." + ITEM_TYPE + "." + ".001." + OitemCode[2];
                                        }
                                        else
                                        {
                                            doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "610.50.001." + OitemCode[2];
                                        }

                                    }
                                    else
                                    {
                                        doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "610.0" + OitemCode[0] + ".001." + OitemCode[2];
                                    }                                  
                                    doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE2").Value = "191.02.001.0001";
                                }
                            }




                            if (doSlsINVOICELine_Control.ToString() == "4") // AHB %
                            {                                 
                                doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("TYPE").Value = doSlsINVOICELine_Control;
                                string[] OitemCodes = doSlsINVOICELine["MASTER_CODE"].ToString().Split('.');                      
                                if (Convert.ToInt32(OitemCodes[2]) >= 15)
                                {
                                    string ITEM_CODE = OitemCodes[2].Substring(0, 3);
                                    string ITEM_TYPE = OitemCodes[2].Substring(0, 3);
                                    //string ITEM_CODE = OitemCodes[2].Substring(0, 3);
                                    //string ITEM_TYPE = OitemCodes[2].Substring(0, OitemCodes[0].Length - 3);

                                    if (STOPAJ_ROW == 0)
                                    {
                                        using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                                        {
                                            string SQL = " SELECT * from dbo.FTR_INTERNET_KATEGORI_LISTESI WHERE YIL='" + DATE_.Year + "'";
                                            SqlCommand myCommand = new SqlCommand(SQL, myConnection);
                                            myCommand.CommandText = SQL.ToString();
                                            myConnection.Open();
                                            SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                                            while (myReader.Read())
                                            {
                                                if (Convert.ToInt16(ITEM_TYPE) >= Convert.ToInt16(myReader["MUHASEBE_KODU_BAS"].ToString()) && Convert.ToInt16(ITEM_TYPE) <= Convert.ToInt16(myReader["MUHASEBE_KODU_BIT"].ToString()))
                                                {
                                                    ITEM_CODE = myReader["TRANSFER_KODU"].ToString();
                                                    break;
                                                }
                                            }
                                            myReader.Close();
                                            myCommand.Connection.Close();
                                        }
                                    }
                                    if (DATE_.Year.ToString() == "2019") ITEM_TYPE = ITEM_TYPE.Substring(1, ITEM_TYPE.Length - 1);


                                    if (ITEM_TYPE.Length < 3) ITEM_TYPE = "0" + ITEM_TYPE;
                                    if (ITEM_TYPE.Length < 3) ITEM_TYPE = "0" + ITEM_TYPE; 

                                    string _CreateSalesServiceCards = utl.createSalesServiceCards(_GLOBAL_PARAMETERS._SIRKET_NO, OitemCodes[0] + "." + ITEM_CODE + "." + ITEM_TYPE + "." + OitemCodes[3], doSlsINVOICELine["NAME"].ToString(), doSlsINVOICELine["DESCRIPTION"].ToString(), doSlsINVOICELine["UNIT_CODE"].ToString(), doSlsINVOICELine["VAT_RATE"].ToString(), doSlsINVOICEHDR["TYPE"].ToString()).ToString();
                                    doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("MASTER_CODE").Value = OitemCodes[0] + "." + ITEM_CODE + "." + ITEM_TYPE + "." + OitemCodes[3];

                                }
                                else
                                {
                                    string _CreateSalesServiceCards = utl.createSalesServiceCards(_GLOBAL_PARAMETERS._SIRKET_NO, doSlsINVOICELine["MASTER_CODE"].ToString(), doSlsINVOICELine["NAME"].ToString(), doSlsINVOICELine["DESCRIPTION"].ToString(), doSlsINVOICELine["UNIT_CODE"].ToString(), doSlsINVOICELine["VAT_RATE"].ToString(), doSlsINVOICEHDR["TYPE"].ToString()).ToString();
                                    doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("MASTER_CODE").Value = doSlsINVOICELine["MASTER_CODE"];                                    
                                }

                                if (doSlsINVOICEHDR["TYPE"].ToString() == "8") // ??
                                { 
                                    if (Convert.ToInt32(OitemCodes[2]) >= 15)
                                    {
                                        string ITEM_CODE = OitemCodes[2].Substring(0, 3);
                                        string ITEM_TYPE = OitemCodes[2].Substring(0, 3);
                                        if (STOPAJ_ROW == 0)
                                        {
                                            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                                            {
                                                string SQL = " SELECT * from dbo.FTR_INTERNET_KATEGORI_LISTESI WHERE YIL='" + DATE_.Year + "'";
                                                SqlCommand myCommand = new SqlCommand(SQL, myConnection);
                                                myCommand.CommandText = SQL.ToString();
                                                myConnection.Open();
                                                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                                                while (myReader.Read())
                                                {
                                                    if (Convert.ToInt32(ITEM_TYPE) >= Convert.ToInt32(myReader["MUHASEBE_KODU_BAS"].ToString()) && Convert.ToInt32(ITEM_TYPE) <= Convert.ToInt32(myReader["MUHASEBE_KODU_BIT"].ToString()))
                                                    {
                                                        ITEM_CODE = myReader["TRANSFER_KODU"].ToString();
                                                        break;
                                                    }
                                                }
                                                myReader.Close();
                                                myCommand.Connection.Close();
                                            }
                                        }

                                        if (DATE_.Year.ToString() == "2019") ITEM_TYPE = ITEM_TYPE.Substring(1, ITEM_TYPE.Length - 1);


                                        if (ITEM_TYPE.Length < 3) ITEM_TYPE = "0" + ITEM_TYPE;
                                        if (ITEM_TYPE.Length < 3) ITEM_TYPE = "0" + ITEM_TYPE; 
                  
                                        string _CreateGlCards = utl.CreateGlCard(_GLOBAL_PARAMETERS._SIRKET_NO, OitemCodes[0] + "." + ITEM_CODE + "." + ITEM_TYPE + "." + OitemCodes[3], doSlsINVOICEHDR["TITLE"].ToString()).ToString();
                                        doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = _CreateGlCards; 
                                        doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE2").Value = "391.01.001.0001"; 
                                    }
                                    else
                                    {
                                        string _CreateGlCards = utl.CreateGlCard(_GLOBAL_PARAMETERS._SIRKET_NO, doSlsINVOICELine["MASTER_CODE"].ToString(), doSlsINVOICEHDR["TITLE"].ToString()).ToString();
                                        doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = _CreateGlCards; 
                                        doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE2").Value = "391.01.001.0001";
                                    }
                                }
                                if (doSlsINVOICEHDR["TYPE"].ToString() == "3") // İade
                                { 
                                    if (Convert.ToInt32(OitemCodes[1]) >= 15)
                                    {
                                        string ITEM_CODE = OitemCodes[2].Substring(0, 3);
                                        string ITEM_TYPE = OitemCodes[2].Substring(0, 3);  
                                        doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "610.0" + OitemCodes[0] + ".001." + OitemCodes[2];
                                        doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE2").Value = "191.02.001.0001";
                                    }
                                    else
                                    { 
                                        doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "610.0" + OitemCodes[0] + ".001." + OitemCodes[2];
                                        doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GL_CODE2").Value = "191.02.001.0001";
                                    }
                                }
                            }  

                            doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("AUXIL_CODE").Value = doSlsINVOICELine["AUXIL_CODE"];
                            doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("QUANTITY").Value = doSlsINVOICELine["QUANTITY"];
                            doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("PRICE").Value = doSlsINVOICELine["PRICE"];
                            doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("TOTAL").Value = doSlsINVOICELine["TOTAL"];
                            doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("EDT_PRICE").Value = doSlsINVOICELine["EDT_PRICE"];
                            doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("UNIT_CODE").Value = doSlsINVOICELine["UNIT_CODE"];
                            doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("UNIT_CONV1").Value = doSlsINVOICELine["UNIT_CONV1"];
                            doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("UNIT_CONV2").Value = doSlsINVOICELine["UNIT_CONV2"];
                            doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("VAT_RATE").Value = doSlsINVOICELine["VAT_RATE"];
                            doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("VAT_AMOUNT").Value = doSlsINVOICELine["VAT_AMOUNT"]; 

                            if (doSlsINVOICELine["PC_PRICE"] == DBNull.Value)
                            {
                                doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("PC_PRICE").Value = doSlsINVOICELine["EDT_PRICE"];
                            }
                            else
                            {
                                doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("PC_PRICE").Value = doSlsINVOICELine["PC_PRICE"];
                            }

                            doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("CURR_TRANSACTION").Value = doSlsINVOICEHDR["CURR_INVOICE"];
                            doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("TC_XRATE").Value = doSlsINVOICELine["TC_XRATE"]; 

                            //  doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("DESCRIPTION").Value = doSlsINVOICELine["DESCRIPTION"];
                            string LINES = "";
                            if (doSlsINVOICELine["PO_CODE"] != DBNull.Value) LINES += "PO:" + doSlsINVOICELine["PO_CODE"].ToString() + "|";
                            if (doSlsINVOICELine["LINE_CODE"] != DBNull.Value) LINES += "LINE:" + doSlsINVOICELine["LINE_CODE"].ToString() + "|";
                            LINES += doSlsINVOICELine["DESCRIPTION"].ToString();
                            if (doSlsINVOICELine["TARIH"] != DBNull.Value) LINES += "|" + doSlsINVOICELine["TARIH"].ToString();
                            if (doSlsINVOICELine["OLCU"] != DBNull.Value) LINES += "|" + doSlsINVOICELine["OLCU"].ToString();
                            if (doSlsINVOICELine["TARIFE"] != DBNull.Value) LINES += "|" + doSlsINVOICELine["TARIFE"].ToString();

                            if (LINES.ToString().Length > 150)
                            {
                                string sub = LINES.Substring(0, 149);
                                doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("DESCRIPTION").Value = sub;
                            }
                            else
                            {
                                doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("DESCRIPTION").Value = LINES;
                            }

                            if (doSlsINVOICELine["CURR_PRICE"].ToString() == "" || doSlsINVOICELine["CURR_PRICE"] == DBNull.Value)
                            {

                                if (doSlsINVOICEHDR["CURR_INVOICE"] != DBNull.Value)
                                {
                                    doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("CURR_PRICE").Value = doSlsINVOICEHDR["CURR_INVOICE"];
                                    doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("EDT_CURR").Value = doSlsINVOICEHDR["CURR_INVOICE"];
                                }
                                else
                                {
                                    doSlsInvoice.DataFields.FieldByName("TC_NET").Value = 0;
                                    doSlsInvoice.DataFields.FieldByName("CURR_INVOICE").Value = 0;
                                }
                            } 

                            //int CURR_PRICE = 0;
                            //if (doSlsINVOICELine["CURR_PRICE"].ToString() == "" && doSlsINVOICELine["CURR_PRICE"] != DBNull.Value) CURR_PRICE = 0;
                            //if (doSlsINVOICELine["CURR_PRICE"].ToString() == "0") CURR_PRICE = 0;
                            //if (doSlsINVOICELine["CURR_PRICE"].ToString() == "20") CURR_PRICE = 20;
                            //if (doSlsINVOICELine["CURR_PRICE"].ToString() == "1") CURR_PRICE = 1;
                            //if (doSlsINVOICELine["CURR_PRICE"].ToString() == "17") CURR_PRICE = 17;
                            //if (doSlsINVOICELine["CURR_PRICE"].ToString() == "11") CURR_PRICE = 11;


                            //doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("CURR_PRICE").Value = CURR_PRICE;
                            //doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("EDT_CURR").Value = CURR_PRICE;

                            doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("BILLED").Value = 1;
                            doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("GENIUSFLDSLIST").Value = "";
                            doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("DEFNFLDSLIST").Value = "";
                            doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("PREACCLINES").Value = "";
                            doSlsInvoiceLines[doSlsInvoiceLines.Count - 1].FieldByName("DATA_REFERENCE").Value = "~";
                        }
                    }
                    if (doSlsInvoice.Post())
                    {
                        doSlsInvoice.ExportToXML("","C:\\temp\\FATURA.XML") ;
                           
                        UnityObjects.IData payment = default(UnityObjects.IData);
                        UnityObjects.Lines paymentLines = default(UnityObjects.Lines);
                        lastLogicalRef = doSlsInvoice.DataFields.FieldByName("INTERNAL_REFERENCE").Value;
                        payment = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doSalesInvoice);
                        string LASTNUMBER = "";
                        if (payment.Read(lastLogicalRef))
                        {
                            LASTNUMBER = payment.DataFields.FieldByName("NUMBER").Value;
                            paymentLines = payment.DataFields.FieldByName("PAYMENT_LIST").Lines;
                            paymentLines.AppendLine();

                            DateTime PAYMENT_DATE_;
                            if (doSlsINVOICEHDR["PAYMENT_DATE"] != DBNull.Value) { PAYMENT_DATE_ = Convert.ToDateTime(doSlsINVOICEHDR["PAYMENT_DATE"].ToString()); } else { PAYMENT_DATE_ = DATE_; }

                            DateTime PAYMENT_DISCOUNT_DUEDATE_;
                            if (doSlsINVOICEHDR["PAYMENT_DISCOUNT_DUEDATE"] != DBNull.Value) { PAYMENT_DISCOUNT_DUEDATE_ = Convert.ToDateTime(doSlsINVOICEHDR["PAYMENT_DATE"].ToString()); } else { PAYMENT_DISCOUNT_DUEDATE_ = DATE_; }

                            paymentLines[0].FieldByName("DATE").Value = PAYMENT_DATE_.ToString("dd/MM/yyyy");
                            paymentLines[0].FieldByName("SIGN").Value = paymentLines[0].FieldByName("SIGN").Value;
                            paymentLines[0].FieldByName("MODULENR").Value = paymentLines[0].FieldByName("MODULENR").Value;
                            paymentLines[0].FieldByName("TRCODE").Value = paymentLines[0].FieldByName("TRCODE").Value;
                            paymentLines[0].FieldByName("TOTAL").Value = paymentLines[0].FieldByName("TOTAL").Value;
                            paymentLines[0].FieldByName("TRCURR").Value = paymentLines[0].FieldByName("TRCURR").Value;
                            paymentLines[0].FieldByName("TRRATE").Value = paymentLines[0].FieldByName("TRRATE").Value;
                            paymentLines[0].FieldByName("OP_STATUS").Value = paymentLines[0].FieldByName("OP_STATUS").Value;
                            paymentLines[0].FieldByName("PROCDATE").Value = paymentLines[0].FieldByName("PROCDATE").Value;
                            paymentLines[0].FieldByName("DISCOUNT_DUEDATE").Value = PAYMENT_DISCOUNT_DUEDATE_.ToString("dd/MM/yyyy");
                            paymentLines[0].FieldByName("PAY_NO").Value = paymentLines[0].FieldByName("PAY_NO").Value;
                            paymentLines[0].FieldByName("DISCTRLIST").Value = paymentLines[0].FieldByName("DISCTRLIST").Value;
                            paymentLines[0].FieldByName("GLOBAL_CODE").Value = _GLOBAL_CODE_KONTROL(_CODE);
                            paymentLines[0].FieldByName("MODIFIED").Value = 1;
                            paymentLines[0].FieldByName("DISCTRDELLIST").Value = 0;
                            paymentLines[0].FieldByName("TRNET").Value = paymentLines[0].FieldByName("TRNET").Value;
                            payment.Post();
                        }


                        /// HEADER EXTENTION
                        using (SqlConnection myConnectionTable = new SqlConnection( _GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString()))
                        {
                            myConnectionTable.Open();
                            SqlCommand myCmd = new SqlCommand();
                            myCmd.CommandText = "INSERT INTO   dbo.LG_XT001001_" +  _GLOBAL_PARAMETERS._SIRKET_NO + " (PARLOGREF,PLAN_KODU,  FATURA_BASKI_SEKLI, FAKTORING_SIRKETI_KODU, ILGILI_FATURA_NO,  SIPARISI_VEREN,DEPARTMAN,  BOLGE_KODU ,ILGILI_IS_UNITESI,  EFATURA_KODU,NOTE99,MECRA_TURU) VALUES" +
                                                                                 " ( @PARLOGREF,@PLAN_KODU,  @FATURA_BASKI_SEKLI, @FAKTORING_SIRKETI_KODU, @ILGILI_FATURA_NO,  @SIPARISI_VEREN,@DEPARTMAN,  @BOLGE_KODU ,@ILGILI_IS_UNITESI,  @EFATURA_KODU,@DEFNFLD_NOTES,@MECRA_TURU )  SELECT @@IDENTITY AS ID ";
                            myCmd.Parameters.AddWithValue("@PARLOGREF", lastLogicalRef);
                            myCmd.Parameters.AddWithValue("@PLAN_KODU", DEFNFLD_PLAN_KODU);
                            myCmd.Parameters.AddWithValue("@FATURA_BASKI_SEKLI", DEFNFLD_FATURA_BASKI_SEKLI);
                            myCmd.Parameters.AddWithValue("@FAKTORING_SIRKETI_KODU", DEFNFLD_FAKTORING_SIRKETI_KODU);
                            myCmd.Parameters.AddWithValue("@ILGILI_FATURA_NO", DEFNFLD_ILGILI_FATURA_NO);
                            myCmd.Parameters.AddWithValue("@SIPARISI_VEREN", DEFNFLD_SIPARISI_VEREN);
                            myCmd.Parameters.AddWithValue("@DEPARTMAN", DEFNFLD_DEPARTMAN);
                            myCmd.Parameters.AddWithValue("@BOLGE_KODU", DEFNFLD_BOLGE_KODU);
                            myCmd.Parameters.AddWithValue("@ILGILI_IS_UNITESI", DEFNFLD_ILGILI_IS_UNITESI);
                            myCmd.Parameters.AddWithValue("@EFATURA_KODU", DEFNFLD_EFATURA_KODU);
                            myCmd.Parameters.AddWithValue("@DEFNFLD_NOTES", DEFNFLD_NOTES);
                            myCmd.Parameters.AddWithValue("@MECRA_TURU", DEFNFLD_MECRA_TURU);
                            myCmd.Connection = myConnectionTable;
                            foreach (SqlParameter parameter in myCmd.Parameters)
                            {
                                if (parameter.Value == null)
                                {
                                    parameter.Value = DBNull.Value;
                                }
                            }
                            myCmd.ExecuteNonQuery();
                        }

                        ArryLISTREF_ID = new System.Collections.ArrayList();
                        /// LINE EXTENTION READ
                        using (SqlConnection ConnLineEx = new SqlConnection( _GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP))
                        {
                            using (SqlCommand myCommandSubLineEx = new SqlCommand())
                            {
                                string mySelectQueryEx = "  SELECT  LOGICALREF FROM     dbo.LG_" +  _GLOBAL_PARAMETERS._SIRKET_NO + "_01_STLINE  where    INVOICEREF=@INVOICE_REF ORDER BY INVOICELNNO";
                                myCommandSubLineEx.Parameters.AddWithValue("@INVOICE_REF", lastLogicalRef);
                                myCommandSubLineEx.CommandText = mySelectQueryEx;
                                myCommandSubLineEx.CommandType = System.Data.CommandType.Text;
                                myCommandSubLineEx.Connection = ConnLineEx;
                                ConnLineEx.Open();
                                SqlDataReader myReaderSubLineEx = myCommandSubLineEx.ExecuteReader(CommandBehavior.CloseConnection);
                                while (myReaderSubLineEx.Read())
                                {
                                    ArryLISTREF_ID.Add(myReaderSubLineEx["LOGICALREF"]);
                                }
                            }
                        }

                        /// STLINE EXTENTION
                        using (SqlConnection ConnLineEx = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                        {
                            using (SqlCommand myCommandSubLineEx = new SqlCommand())
                            {
                                string mySelectQueryEx = "  SELECT  *  FROM     dbo.FTR_LG_STLINE  where  SIRKET_KODU=@SIRKET_KODU and  INVOICE_REF=@INVOICE_REF";
                                myCommandSubLineEx.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                                myCommandSubLineEx.Parameters.AddWithValue("@INVOICE_REF", INVOICE_REF_ID);
                                myCommandSubLineEx.CommandText = mySelectQueryEx;
                                myCommandSubLineEx.CommandType = System.Data.CommandType.Text;
                                myCommandSubLineEx.Connection = ConnLineEx;
                                ConnLineEx.Open();
                                SqlDataReader myReaderSubLineEx = myCommandSubLineEx.ExecuteReader(CommandBehavior.CloseConnection);
                                int ARRYID = -1;
                                while (myReaderSubLineEx.Read())
                                {
                                    ARRYID++;
                                    using (SqlConnection myConnectionTable = new SqlConnection( _GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString()))
                                    {
                                        myConnectionTable.Open();
                                        SqlCommand myCmd = new SqlCommand();
                                        myCmd.CommandText = "INSERT INTO   dbo.LG_XT002001_" +  _GLOBAL_PARAMETERS._SIRKET_NO + " (PARLOGREF,PLAN_KODU,  SEHIR, FILM_ADI, SURE,  TARIH,OLCU,  TARIFE) VALUES ( @PARLOGREF,@PLAN_KODU, @SEHIR,  @FILM_ADI,  @SURE,   @TARIH, @OLCU,   @TARIFE )  ";
                                        myCmd.Parameters.AddWithValue("@PARLOGREF", ArryLISTREF_ID[ARRYID]);
                                        myCmd.Parameters.AddWithValue("@PLAN_KODU", myReaderSubLineEx["PLAN_KODU"].ToString());
                                        myCmd.Parameters.AddWithValue("@SEHIR", myReaderSubLineEx["SEHIR"].ToString());
                                        myCmd.Parameters.AddWithValue("@FILM_ADI", myReaderSubLineEx["FILM_ADI"].ToString());
                                        myCmd.Parameters.AddWithValue("@SURE", myReaderSubLineEx["SURE"].ToString());
                                        myCmd.Parameters.AddWithValue("@TARIH", myReaderSubLineEx["TARIH"].ToString());
                                        myCmd.Parameters.AddWithValue("@OLCU", myReaderSubLineEx["OLCU"].ToString());
                                        myCmd.Parameters.AddWithValue("@TARIFE", myReaderSubLineEx["TARIFE"].ToString());
                                        myCmd.Connection = myConnectionTable;
                                        foreach (SqlParameter parameter in myCmd.Parameters)
                                        {
                                            if (parameter.Value == null)
                                            {
                                                parameter.Value = DBNull.Value;
                                            }
                                        }
                                        myCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        } 

                        DateTime dtm=DateTime.Now; 
                        using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                        {
                            myConnections.Open();
                            using (SqlCommand myCmd = new SqlCommand())
                            {
                                myCmd.CommandText = "  UPDATE dbo.FTR_LG_INVOICE   SET AKTARIM_DURUMU='AKTARILDI', AKTARIM_SORUMLUSU=@AKTARIM_SORUMLUSU,AKTARIM_TARIHI=@AKTARIM_TARIHI,AKTARIM_NOTU=@AKTARIM_NOTU  WHERE  SIRKET_KODU=@SIRKET_KODU AND (ID=@INVOICE_REF_ID) ";
                             
                                myCmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                                myCmd.Parameters.AddWithValue("@INVOICE_REF_ID", INVOICE_REF_ID);
                                myCmd.Parameters.AddWithValue("@AKTARIM_SORUMLUSU", _GLOBAL_PARAMETERS._KULLANICI_MAIL);
                                myCmd.Parameters.AddWithValue("@AKTARIM_TARIHI", dtm.ToString("yyyy-MM-dd hh:mm:ss"));
                                myCmd.Parameters.AddWithValue("@AKTARIM_NOTU", "BASARILI");
                                myCmd.Connection = myConnections;
                                myCmd.ExecuteNonQuery();
                            }
                            using (SqlCommand myCmd = new SqlCommand())
                            { 
                                myCmd.CommandText = " UPDATE dbo.FTR_LG_STLINE   SET AKTARIM_DURUMU='AKTARILDI'  WHERE  SIRKET_KODU=@SIRKET_KODU AND (INVOICE_REF=@INVOICE_REF_ID) ";
                                myCmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                                myCmd.Parameters.AddWithValue("@INVOICE_REF_ID", INVOICE_REF_ID);
                                myCmd.Connection = myConnections;
                                myCmd.ExecuteNonQuery();
                            }
                            using (SqlCommand myCmd = new SqlCommand())
                            {
                                myCmd.CommandText = "  UPDATE dbo.FTR_GELEN_FATURALAR   SET  ERP_AKTARILDI='True'   WHERE     (SIRKET_KODU=@SIRKET_KODU) and (ID=@FATURA_NUMARASI)";
                                myCmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                                myCmd.Parameters.AddWithValue("@FATURA_NUMARASI", FATURA_NUMARASI);
                                myCmd.Connection = myConnections;
                                myCmd.ExecuteNonQuery();
                            } 

                            string FATURA_TIPI = "";
                            if (doSlsINVOICEHDR["TYPE"].ToString() == "3") FATURA_TIPI = "SATIŞ İADE";
                            if (doSlsINVOICEHDR["TYPE"].ToString() == "8") FATURA_TIPI = "SATIŞ";
                            _GLOBAL_PARAMETERS.LOG_ISLEMLERI LF = new _GLOBAL_PARAMETERS.LOG_ISLEMLERI();
                            LF.LOG_AKTARIMI(FATURA_TIPI, FATURA_NUMARASI, "KAYIT", doSlsINVOICEHDR["TOTAL_NET"].ToString(), doSlsINVOICEHDR["TITLE"].ToString(), "", DEFNFLD_PLAN_KODU, doSlsINVOICEHDR["NOTES1"].ToString(), "");
                     
                            myConnections.Close();
                        }
                        
                        rReturn = "AKTARILDI";
                    }
                    else
                    {
                       //doSlsInvoice.ExportToXML("C:\\temp","Fatura.xml"); 
                        doSlsInvoice.ExportToXML("", "C:\\temp\\FATURA.XML"); 
                        if (doSlsInvoice.ValidateErrors.Count > 0)
                        { 

                            for (int i = 0; i <= doSlsInvoice.ValidateErrors.Count - 1; i++)
                            {
                                rReturn += "Error code : " + (doSlsInvoice.ValidateErrors[i].ID) + "Error code : " + (char)10 + doSlsInvoice.ValidateErrors[i].Error.ToString();
                            }
                            using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                            {
                                myConnections.Open();
                                DateTime dtm = DateTime.Now;
                                using (SqlCommand myCmd = new SqlCommand())
                                {
                                    myCmd.CommandText = "  UPDATE dbo.FTR_LG_INVOICE   SET AKTARIM_DURUMU='AKTARILMADI', AKTARIM_SORUMLUSU=@AKTARIM_SORUMLUSU,AKTARIM_TARIHI=@AKTARIM_TARIHI,AKTARIM_NOTU=@AKTARIM_NOTU  WHERE  SIRKET_KODU=@SIRKET_KODU AND (NUMBER=@FATURA_NUMARASI) ";

                                    myCmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                                    myCmd.Parameters.AddWithValue("@FATURA_NUMARASI", FATURA_NUMARASI);
                                    myCmd.Parameters.AddWithValue("@AKTARIM_SORUMLUSU", _GLOBAL_PARAMETERS._KULLANICI_MAIL);
                                    myCmd.Parameters.AddWithValue("@AKTARIM_TARIHI", dtm.ToString("yyyy-MM-dd hh:mm:ss"));
                                    myCmd.Parameters.AddWithValue("@AKTARIM_NOTU", rReturn);
                                    myCmd.Connection = myConnections;
                                    myCmd.ExecuteNonQuery();
                                }
                            }
                            string FATURA_TIPI = "";
                            if (doSlsINVOICEHDR["TYPE"].ToString() == "1") FATURA_TIPI = "ALIM";
                            if (doSlsINVOICEHDR["TYPE"].ToString() == "6") FATURA_TIPI = "ALIM İADE"; 

                            _GLOBAL_PARAMETERS.LOG_ISLEMLERI LF = new _GLOBAL_PARAMETERS.LOG_ISLEMLERI();
                            LF.LOG_AKTARIMI(FATURA_TIPI, FATURA_NUMARASI, "KAYIT-HATALI", doSlsINVOICEHDR["TOTAL_NET"].ToString(), doSlsINVOICEHDR["TITLE"].ToString(), "", DEFNFLD_PLAN_KODU, doSlsINVOICEHDR["NOTES1"].ToString(), rReturn);
                        }
                    }
                }
                Conn.Dispose();
            }
            return rReturn;
        }
    }
}
