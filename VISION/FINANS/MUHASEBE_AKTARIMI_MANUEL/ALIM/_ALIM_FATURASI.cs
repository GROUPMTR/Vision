using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityObjects;
namespace VISION.FINANS.MUHASEBE_AKTARIMI_MANUEL.ALIM
{ 

    public class _ALIM_FATURASI
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

        public string _FATURA_VAR_YOK_KONTROL(string NUMBER,string TAXNUMBER)
        {
            int LogicalRef = 0;
            string FATURA_KONTROL = string.Empty;
            //Yeni bir sql sorgusu çalıştırmak istediğimizi belirtiyoruz.                        
            Query Querys = _GLOBAL_PARAMETERS.Global.UnityApp.NewQuery();
            //string Query_String = "   SELECT FICHENO,LOGICALREF FROM LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_01_INVOICE  WHERE TRCODE='1'  AND FICHENO='" + NUMBER + "'";
            string Query_String = " SELEC * FROM   LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_01_INVOICE CRD LEFT JOIN  LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_01_INVOICE  ON  CRD.LOGICALREF=FTR.CLIENTREF   WHERE TRCODE='1' AND CRD.TAXNR='"+TAXNUMBER+"' AND FTR.DOCODE='" + NUMBER + "'";                 
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
            int _GLOBAL_CODE = 0;
            SqlConnection ConnLine_DEFAULT = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP);
            SqlCommand myCommand_DEFAULT = new SqlCommand();
            //string QueryString = " SELECT  *  FROM  dbo.LG_" +  _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD  WHERE (dbo.LG_" +  _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD.CODE='" + CODE + "') ";
            string QueryString = "SELECT     dbo.LG_XT003_" + _GLOBAL_PARAMETERS._SIRKET_NO + ".A_ODEMEARACI, dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD.CODE FROM  dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD INNER JOIN   dbo.LG_XT003_" + _GLOBAL_PARAMETERS._SIRKET_NO + " ON dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD.LOGICALREF = dbo.LG_XT003_" + _GLOBAL_PARAMETERS._SIRKET_NO + ".PARLOGREF WHERE    WHERE (dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD.CODE='" + CODE + "') ";

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
                    _GLOBAL_CODE = 20;
                }
            }
            return _GLOBAL_CODE;
        }


        public string _Insert(string FATURA_NUMARASI, int E_FATURA_TYPE, int TEMEL_TICARI, string FATURA_SERISI, string _CODE, string FIRMA_KODU)
        {
            string rReturn = string.Empty;
            rReturn = "AKTARILMADI";
            _GLOBAL_PARAMETERS.Parametler.RAKAMKONTROL Numeric = new _GLOBAL_PARAMETERS.Parametler.RAKAMKONTROL();
            CultureInfo culture = new CultureInfo("tr-TR");

            // Fatura tipi  alış 1  740.0
            // alış idade 6         740.0
            // satış 8              5 İse  601 Değilde 600                                  
            // satış iade 3          610     // ?
            // satır tipi 4 hizmet   602 610
            // 0 Malzeme 740 , 600 ,601 , 610
            // 2 indirim  611

            int lastLogicalRef;
            int INVOICE_REF_ID = 0;
            string DEFNFLD_LEVEL_ = "", DEFNFLD_MODULENR = "", DEFNFLD_DOC_TRACK_NR = "", DEFNFLD_PLAN_KODU = "", DEFNFLD_FATURA_BASKI_SEKLI = "", DEFNFLD_FAKTORING_SIRKETI_KODU = "", DEFNFLD_ILGILI_FATURA_NO = "", DEFNFLD_SIPARISI_VEREN = "", DEFNFLD_DEPARTMAN = "", DEFNFLD_BOLGE_KODU = "", DEFNFLD_ILGILI_IS_UNITESI = "", DEFNFLD_EFATURA_KODU = "",
                   DEFNFLD_FAC_CARI_KODU = "", DEFNFLD_FAC_MUHASEBE_KODU = "";
            if (_GLOBAL_PARAMETERS.Global.UnityApp.Connected)
            {
                string mySelectQuery = "  SELECT * FROM dbo.FTR_LG_INVOICE  WHERE SIRKET_KODU='" + _GLOBAL_PARAMETERS._SIRKET_KODU + "' AND  (AKTARIM_DURUMU =N'BEKLEMEDE' or AKTARIM_DURUMU =N'AKTARILMADI' ) AND (NUMBER='" + FATURA_NUMARASI + "') ";

                SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
                SqlCommand myCommandSub = new SqlCommand(mySelectQuery, Conn);
                Conn.Open();
                SqlDataReader doPrhINVOICEHDR = myCommandSub.ExecuteReader(CommandBehavior.CloseConnection);
                while (doPrhINVOICEHDR.Read())
                {
                    if (doPrhINVOICEHDR["CODE"].ToString() == "") return rReturn = "CARİ KOD BULUNAMADI";

                    INVOICE_REF_ID = Convert.ToInt32(doPrhINVOICEHDR["ID"]);
                    //Utilities utl = new Utilities();
                    _GLOBAL_PARAMETERS utl = new _GLOBAL_PARAMETERS();
                    //  string _createClientCode = utl.createClientCode( _GLOBAL_PARAMETERS._SIRKET_NO, doPrhINVOICEHDR["CODE"].ToString(), doPrhINVOICEHDR["TITLE"].ToString(), doPrhINVOICEHDR["ADDRESS1"].ToString(),
                    //                                                   doPrhINVOICEHDR["ADDRESS2"].ToString(), doPrhINVOICEHDR["CITY"].ToString(), doPrhINVOICEHDR["TAX_OFFICE"].ToString(), doPrhINVOICEHDR["TAX_ID"].ToString()).ToString();                  
                    // string _CreateGlCard = utl.CreateGlCard( _GLOBAL_PARAMETERS._SIRKET_NO, doPrhINVOICEHDR["GL_CODE"].ToString(), doPrhINVOICEHDR["TITLE"].ToString()).ToString();
                    UnityObjects.IData doPrhInvoice = default(UnityObjects.IData);
                    UnityObjects.Lines doPrhInvoiceLines = default(UnityObjects.Lines);
                    doPrhInvoice = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doPurchInvoice);
                    doPrhInvoice.New();
                    doPrhInvoice.DataFields.FieldByName("TYPE").Value = doPrhINVOICEHDR["TYPE"];

                    if (doPrhINVOICEHDR["TYPE"].ToString() == "1")
                    {
                        doPrhInvoice.DataFields.FieldByName("NUMBER").Value = "~";// doPrhINVOICEHDR["NUMBER"];
                    }
                    if (doPrhINVOICEHDR["TYPE"].ToString() == "6")
                    {
                        if (E_FATURA_TYPE == 1)
                        {
                            if (FATURA_SERISI == null) { doPrhInvoice.DataFields.FieldByName("NUMBER").Value = "~"; }
                            else
                            {
                                using (SqlConnection conn = new SqlConnection( _GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP))
                                {
                                    using (SqlCommand cmd = new SqlCommand())
                                    {
                                        string sql = "    SELECT REPLACE(MAX(FICHENO), '" + FATURA_SERISI + "', '') as FICHENO FROM  LG_" +  _GLOBAL_PARAMETERS._SIRKET_NO + "_01_INVOICE WHERE EINVOICE=1 and (TRCODE=8 or TRCODE=9 or TRCODE=6) and FICHENO LIKE '" + FATURA_SERISI + "%'";
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
                                            doPrhInvoice.DataFields.FieldByName("NUMBER").Value = FATURA_SERISI + Count.ToString();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            doPrhInvoice.DataFields.FieldByName("NUMBER").Value = "~";//doPrhINVOICEHDR["NUMBER"];
                        }
                    }


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
                    // Invoice.DataFields.FieldByName("ARP_CODE").Value = createClientCode(UnityApp, dg.Rows(i).Cells("CODE").Value.ToString,
                    // dg.Rows(i).Cells("DEFINITION").Value.ToString, sfirm, dg.Rows(i).Cells("ACC_CODE").Value.ToString, dg.Rows(i).Cells("ACC_DEFINITION").Value.ToString


                    doPrhInvoice.DataFields.FieldByName("EINVOICE").Value = E_FATURA_TYPE;// doSlsINVOICEHDR["EINVOICE"];  

                    // EK ALANLARI AL 

                    DEFNFLD_LEVEL_ = doPrhINVOICEHDR["DEFNFLD_LEVEL_"].ToString();
                    DEFNFLD_MODULENR = doPrhINVOICEHDR["DEFNFLD_MODULENR"].ToString();
                    DEFNFLD_PLAN_KODU = doPrhINVOICEHDR["DEFNFLD_PLAN_KODU"].ToString();
                    DEFNFLD_FATURA_BASKI_SEKLI = doPrhINVOICEHDR["DEFNFLD_FATURA_BASKI_SEKLI"].ToString();
                    DEFNFLD_FAKTORING_SIRKETI_KODU = doPrhINVOICEHDR["DEFNFLD_FAKTORING_SIRKETI_KODU"].ToString();
                    DEFNFLD_FAC_CARI_KODU = doPrhINVOICEHDR["DEFNFLD_FAC_CARI_KODU"].ToString();
                    DEFNFLD_FAC_MUHASEBE_KODU = doPrhINVOICEHDR["DEFNFLD_FAC_MUHASEBE_KODU"].ToString();
                    DEFNFLD_ILGILI_FATURA_NO = doPrhINVOICEHDR["DEFNFLD_ILGILI_FATURA_NO"].ToString();
                    DEFNFLD_SIPARISI_VEREN = doPrhINVOICEHDR["DEFNFLD_SIPARISI_VEREN"].ToString();
                    DEFNFLD_DEPARTMAN = doPrhINVOICEHDR["DEFNFLD_DEPARTMAN"].ToString();
                    DEFNFLD_BOLGE_KODU = doPrhINVOICEHDR["DEFNFLD_BOLGE_KODU"].ToString();
                    DEFNFLD_ILGILI_IS_UNITESI = doPrhINVOICEHDR["DEFNFLD_ILGILI_IS_UNITESI"].ToString();
                    DEFNFLD_EFATURA_KODU = doPrhINVOICEHDR["DEFNFLD_EFATURA_KODU"].ToString();
                    DEFNFLD_DOC_TRACK_NR = doPrhINVOICEHDR["DOC_TRACK_NR"].ToString();

                    doPrhInvoice.DataFields.FieldByName("PROFILE_ID").Value = TEMEL_TICARI.ToString();

                    DateTime DATE_ = Convert.ToDateTime(doPrhINVOICEHDR["DATE"].ToString());
                    doPrhInvoice.DataFields.FieldByName("DATE").Value = DATE_.ToString("dd/MM/yyyy");
                    doPrhInvoice.DataFields.FieldByName("DOC_TRACK_NR").Value = doPrhINVOICEHDR["DOC_TRACK_NR"];
                    doPrhInvoice.DataFields.FieldByName("DOC_NUMBER").Value = doPrhINVOICEHDR["DOC_NUMBER"];
                    doPrhInvoice.DataFields.FieldByName("ARP_CODE").Value = doPrhINVOICEHDR["ARP_CODE"];
                    doPrhInvoice.DataFields.FieldByName("GL_CODE").Value = doPrhINVOICEHDR["GL_CODE"];
                    doPrhInvoice.DataFields.FieldByName("VAT_RATE").Value = doPrhINVOICEHDR["VAT_RATE"];
                    doPrhInvoice.DataFields.FieldByName("ADD_DISCOUNTS").Value = doPrhINVOICEHDR["ADD_DISCOUNTS"];
                    doPrhInvoice.DataFields.FieldByName("TOTAL_DISCOUNTS").Value = doPrhINVOICEHDR["TOTAL_DISCOUNTS"];
                    doPrhInvoice.DataFields.FieldByName("TOTAL_VAT").Value = doPrhINVOICEHDR["TOTAL_VAT"];
                    doPrhInvoice.DataFields.FieldByName("TOTAL_GROSS").Value = doPrhINVOICEHDR["TOTAL_GROSS"];
                    doPrhInvoice.DataFields.FieldByName("TOTAL_NET").Value = doPrhINVOICEHDR["TOTAL_NET"];
                    doPrhInvoice.DataFields.FieldByName("NOTES1").Value = doPrhINVOICEHDR["NOTES1"] + ";" + doPrhINVOICEHDR["NUMBER"] + ";" + doPrhINVOICEHDR["DOC_TRACK_NR"];
                    doPrhInvoice.DataFields.FieldByName("NOTES2").Value = doPrhINVOICEHDR["NOTES2"];
                    doPrhInvoice.DataFields.FieldByName("NOTES3").Value = doPrhINVOICEHDR["NOTES3"];
                    doPrhInvoice.DataFields.FieldByName("NOTES4").Value = doPrhINVOICEHDR["NOTES4"];

                    doPrhInvoice.DataFields.FieldByName("TC_XRATE").Value = doPrhINVOICEHDR["TC_XRATE"];
                    doPrhInvoice.DataFields.FieldByName("RC_NET").Value = doPrhINVOICEHDR["RC_NET"];
                    doPrhInvoice.DataFields.FieldByName("RC_XRATE").Value = doPrhINVOICEHDR["RC_XRATE"];
                    doPrhInvoice.DataFields.FieldByName("CURRSEL_TOTALS").Value = doPrhINVOICEHDR["CURRSEL_TOTALS"];
                    doPrhInvoice.DataFields.FieldByName("CURRSEL_DETAILS").Value = doPrhINVOICEHDR["CURRSEL_DETAILS"];
                    doPrhInvoice.DataFields.FieldByName("DOC_DATE").Value = DATE_.ToString("dd/MM/yyyy");


                    //  doPrhInvoice.DataFields.FieldByName("EDITCURR_GLOBAL_CODE").Value = _GLOBAL_CODE_KONTROL( _GLOBAL_PARAMETERS._SIRKET_NO, _CODE);

                    if (doPrhINVOICEHDR["CURR_INVOICE"] != DBNull.Value)
                    {
                        doPrhInvoice.DataFields.FieldByName("CURR_INVOICE").Value = doPrhINVOICEHDR["CURR_INVOICE"];
                        doPrhInvoice.DataFields.FieldByName("TC_NET").Value = doPrhINVOICEHDR["TC_NET"];
                    }
                    else
                    {
                        doPrhInvoice.DataFields.FieldByName("TC_NET").Value = 0;
                        doPrhInvoice.DataFields.FieldByName("CURR_INVOICE").Value = 0;
                    }

                    doPrhInvoice.DataFields.FieldByName("DATA_REFERENCE").Value = "~";

                    string mySelectQueryLine = "  SELECT  *  FROM     dbo.FTR_LG_STLINE  where  SIRKET_KODU=@SIRKET_KODU AND  INVOICE_REF=@INVOICE_REF ";
                    SqlConnection ceConnLine = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
                    SqlCommand myCommandSubLine = new SqlCommand();
                    myCommandSubLine.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    myCommandSubLine.Parameters.AddWithValue("@INVOICE_REF", INVOICE_REF_ID);
                    //myCommandSubLine.Parameters.AddWithValue("@INVOICE_NUMBER", doPrhINVOICEHDR["NUMBER"]);
                    myCommandSubLine.CommandText = mySelectQueryLine;
                    myCommandSubLine.CommandType = System.Data.CommandType.Text;
                    myCommandSubLine.Connection = ceConnLine;
                    ceConnLine.Open();
                    SqlDataReader doPrhINVOICELine = myCommandSubLine.ExecuteReader(CommandBehavior.CloseConnection);
                    doPrhInvoiceLines = doPrhInvoice.DataFields.FieldByName("TRANSACTIONS").Lines;
                    int ODEMEVADESI = 0;
                    while (doPrhINVOICELine.Read())
                    {
                        if (doPrhInvoiceLines.AppendLine())
                        {

                            int STOPAJ_ROW = 0;
                            string doPrhINVOICELine_Control = "0";

                            if (doPrhINVOICELine["TYPE"].ToString() == "-1")
                            { doPrhINVOICELine_Control = "0"; STOPAJ_ROW = 1; }
                            else
                            { doPrhINVOICELine_Control = doPrhINVOICELine["TYPE"].ToString(); STOPAJ_ROW = 0; }

                            if (doPrhINVOICELine_Control == "0")
                            { 
                                string _CreateItems = utl.createItemCode(doPrhINVOICELine["MASTER_CODE"].ToString(), doPrhINVOICELine["NAME"].ToString(),  _GLOBAL_PARAMETERS._SIRKET_NO, "ADET", doPrhINVOICELine["VAT_RATE"].ToString(), doPrhINVOICEHDR["CODE"].ToString(), doPrhINVOICEHDR["TITLE"].ToString(),DATE_.Year.ToString(), STOPAJ_ROW.ToString() ).ToString();
                                doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("TYPE").Value = doPrhINVOICELine_Control;
                                doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("MASTER_CODE").Value = _CreateItems;
                                string[] OitemCode = _CreateItems.Split('-');
                                if (OitemCode[0].ToString() == ",") return rReturn = OitemCode[1].ToString();


                                int MecraType = Convert.ToInt32(OitemCode[0]);
                                if (MecraType >= 15)
                                { 
                                    string ITEM_CODE = OitemCode[0].Substring(0, 2);
                                    string ITEM_TYPE = OitemCode[0].Substring(2, OitemCode[0].Length - 2);  
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
                                    if (DATE_.Year.ToString() == "2019") ITEM_TYPE = ITEM_TYPE.Substring(1, ITEM_TYPE.Length - 1);

                                    if (ITEM_TYPE.Length < 3) ITEM_TYPE = "0" + ITEM_TYPE;
                                    if (ITEM_TYPE.Length < 3) ITEM_TYPE = "0" + ITEM_TYPE; 

                                    doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "740." + ITEM_CODE + "." + ITEM_TYPE + "." + OitemCode[2];
                                }
                                else
                                {
                                    doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "740.0" + OitemCode[0] + ".001." + OitemCode[2];
                                } 
                               
                                if (doPrhINVOICEHDR["TYPE"].ToString() == "1")
                                {
                                    doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("GL_CODE2").Value = "191.01.001.0001";
                                }
                                if (doPrhINVOICEHDR["TYPE"].ToString() == "6")
                                {
                                    doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("GL_CODE2").Value = "391.02.001.0001";
                                }
                            }
                            if (doPrhINVOICELine_Control == "4")
                            {
                                // dg.Rows(i).Cells("CODE").Value.ToString, dg.Rows(i).Cells("DEFINITION").Value.ToString
                                doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("TYPE").Value = doPrhINVOICELine_Control;
                                string _CreateItems = utl.createItemCode(doPrhINVOICELine["MASTER_CODE"].ToString(), doPrhINVOICELine["NAME"].ToString(),  _GLOBAL_PARAMETERS._SIRKET_NO, "ADET", doPrhINVOICELine["VAT_RATE"].ToString(), doPrhINVOICEHDR["CODE"].ToString(), doPrhINVOICEHDR["TITLE"].ToString(), DATE_.Year.ToString(), STOPAJ_ROW.ToString()).ToString();
                                //string _CreateItems = utl.createItemCode( _GLOBAL_PARAMETERS._SIRKET_NO,doPrhINVOICELine["MASTER_CODE"].ToString(), doPrhINVOICELine["VAT_RATE"].ToString(), doPrhINVOICELine["TYPE"].ToString(), doPrhINVOICELine["NAME"].ToString()).ToString();

                                //string _CreateItems = utl.createItemCode( _GLOBAL_PARAMETERS._SIRKET_NO, dg.Rows(i).Cells(j + 1).Value.ToString, dg.Rows(i).Cells(j + 2).Value.ToString, sfirm, dg.Rows(i).Cells(j + 5).Value.ToString, CDbl(dg.Rows(i).Cells(j + 6).Value.ToString), dg.Rows(i).Cells("CODE").Value.ToString, dg.Rows(i).Cells("DEFINITION").Value.ToString);

                                string[] OitemCode = _CreateItems.Split('-');
                                string _CreateSalesServiceCards = utl.createSalesServiceCards( _GLOBAL_PARAMETERS._SIRKET_NO, doPrhINVOICELine["AUXIL_CODE"].ToString(), doPrhINVOICELine["DESCRIPTION"].ToString(), doPrhINVOICELine["MASTER_CODE"].ToString(), doPrhINVOICELine["UNIT_CODE"].ToString(), doPrhINVOICELine["VAT_RATE"].ToString(), doPrhINVOICELine_Control).ToString();
                                string _CreateGlCards = utl.CreateGlCard( _GLOBAL_PARAMETERS._SIRKET_NO, doPrhINVOICELine["MASTER_CODE"].ToString(), doPrhINVOICELine["TITLE"].ToString()).ToString();
                                doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("MASTER_CODE").Value = doPrhINVOICELine["MASTER_CODE"];
                                  
                                int MecraType = Convert.ToInt32(OitemCode[0]);
                                if (MecraType >= 15)
                                { 
                                    string ITEM_CODE = OitemCode[0].Substring(0, 2);
                                    string ITEM_TYPE = OitemCode[0].Substring(2, OitemCode[0].Length - 2);  
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
                                    if (DATE_.Year.ToString() == "2019") ITEM_TYPE = ITEM_TYPE.Substring(1, ITEM_TYPE.Length - 1);

                                    if (ITEM_TYPE.Length < 3) ITEM_TYPE = "0" + ITEM_TYPE;
                                    if (ITEM_TYPE.Length < 3) ITEM_TYPE = "0" + ITEM_TYPE; 

                                    doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "740." + ITEM_CODE + "." + ITEM_TYPE + "." + OitemCode[2];
                                }
                                else
                                {
                                    doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("GL_CODE1").Value = "740.0" + OitemCode[0] + ".001." + OitemCode[2];
                                }  
                               
                                if (doPrhINVOICEHDR["TYPE"].ToString() == "1")
                                {
                                    doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("GL_CODE2").Value = "191.01.001.0001";
                                }
                                if (doPrhINVOICEHDR["TYPE"].ToString() == "6")
                                {
                                    doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("GL_CODE2").Value = "391.02.001.0001";
                                }
                            }
                            doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("AUXIL_CODE").Value = doPrhINVOICELine["AUXIL_CODE"];
                            doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("QUANTITY").Value = doPrhINVOICELine["QUANTITY"];
                            doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("PRICE").Value = doPrhINVOICELine["PRICE"];
                            doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("TOTAL").Value = doPrhINVOICELine["TOTAL"];
                            doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("EDT_PRICE").Value = doPrhINVOICELine["EDT_PRICE"];
                            doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("UNIT_CODE").Value = doPrhINVOICELine["UNIT_CODE"];
                            doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("UNIT_CONV1").Value = doPrhINVOICELine["UNIT_CONV1"];
                            doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("UNIT_CONV2").Value = doPrhINVOICELine["UNIT_CONV2"];
                            doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("VAT_RATE").Value = doPrhINVOICELine["VAT_RATE"];
                            doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("VAT_AMOUNT").Value = doPrhINVOICELine["VAT_AMOUNT"];
                            doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("DESCRIPTION").Value = doPrhINVOICELine["DESCRIPTION"];
                            doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("PC_PRICE").Value = doPrhINVOICELine["EDT_PRICE"];
                            doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("CURR_TRANSACTION").Value = doPrhINVOICEHDR["CURR_INVOICE"];
                            doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("TC_XRATE").Value = doPrhINVOICELine["TC_XRATE"]; 
                            if (doPrhINVOICELine["CURR_PRICE"].ToString() == "" || doPrhINVOICELine["CURR_PRICE"] == DBNull.Value)
                            {

                                if (doPrhINVOICEHDR["CURR_INVOICE"] != DBNull.Value)
                                {
                                    doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("CURR_PRICE").Value = doPrhINVOICEHDR["CURR_INVOICE"];
                                    doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("EDT_CURR").Value = doPrhINVOICEHDR["CURR_INVOICE"];
                                }
                                else
                                {
                                    doPrhInvoice.DataFields.FieldByName("TC_NET").Value = 0;
                                    doPrhInvoice.DataFields.FieldByName("CURR_INVOICE").Value = 0;
                                }
                            } 

                            // BU ALANLARA BAK 

                            doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("BILLED").Value = 1;
                            doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("GENIUSFLDSLIST").Value = "";
                            doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("DEFNFLDSLIST").Value = "";
                            doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("PREACCLINES").Value = "";
                            doPrhInvoiceLines[doPrhInvoiceLines.Count - 1].FieldByName("DATA_REFERENCE").Value = "~";
                        }
                    }

                    if (doPrhInvoice.Post())
                    {


                        UnityObjects.IData payment = default(UnityObjects.IData);
                        UnityObjects.Lines paymentLines = default(UnityObjects.Lines);
                        lastLogicalRef = doPrhInvoice.DataFields.FieldByName("INTERNAL_REFERENCE").Value;
                        
                        payment = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doPurchInvoice);
                        string LASTNUMBER = "";
                        if (payment.Read(lastLogicalRef))
                        {
                            LASTNUMBER = payment.DataFields.FieldByName("NUMBER").Value;
                            paymentLines = payment.DataFields.FieldByName("PAYMENT_LIST").Lines;
                            paymentLines.AppendLine();

                            DateTime PAYMENT_DATE_;
                            if (doPrhINVOICEHDR["PAYMENT_DATE"] != DBNull.Value) { PAYMENT_DATE_ = Convert.ToDateTime(doPrhINVOICEHDR["PAYMENT_DATE"].ToString()); } else { PAYMENT_DATE_ = DATE_; }

                            DateTime PAYMENT_DISCOUNT_DUEDATE_;
                            if (doPrhINVOICEHDR["PAYMENT_DISCOUNT_DUEDATE"] != DBNull.Value) { PAYMENT_DISCOUNT_DUEDATE_ = Convert.ToDateTime(doPrhINVOICEHDR["PAYMENT_DATE"].ToString()); } else { PAYMENT_DISCOUNT_DUEDATE_ = DATE_; }

                            paymentLines[0].FieldByName("DATE").Value = PAYMENT_DATE_.ToString("dd/MM/yyyy");  //paymentLines[0].FieldByName("PAYMENT_DATE").Value;  //DATE_.AddDays(ODEMEVADESI).ToString("dd/MM/yyyy");
                            paymentLines[0].FieldByName("MODULENR").Value = paymentLines[0].FieldByName("MODULENR").Value;
                            paymentLines[0].FieldByName("SIGN").Value = paymentLines[0].FieldByName("SIGN").Value;
                            paymentLines[0].FieldByName("TRCODE").Value = paymentLines[0].FieldByName("TRCODE").Value;// 1;
                            paymentLines[0].FieldByName("TOTAL").Value = paymentLines[0].FieldByName("TOTAL").Value;//VATMATRAH;  myReaderSubLine["VATMATRAH"];
                            paymentLines[0].FieldByName("TRCURR").Value = paymentLines[0].FieldByName("TRCURR").Value;//= KURNO;
                            paymentLines[0].FieldByName("TRRATE").Value = paymentLines[0].FieldByName("TRRATE").Value;
                            paymentLines[0].FieldByName("PROCDATE").Value = paymentLines[0].FieldByName("PROCDATE").Value;
                            paymentLines[0].FieldByName("DISCOUNT_DUEDATE").Value = PAYMENT_DISCOUNT_DUEDATE_.ToString("dd/MM/yyyy");  //paymentLines[0].FieldByName("PAYMENT_DISCOUNT_DUEDATE").Value; // DATE_.AddDays(ODEMEVADESI).ToString("dd/MM/yyyy");
                            paymentLines[0].FieldByName("OP_STATUS").Value = paymentLines[0].FieldByName("OP_STATUS").Value;//1;
                            paymentLines[0].FieldByName("PAY_NO").Value = paymentLines[0].FieldByName("PAY_NO").Value;//1;
                            paymentLines[0].FieldByName("DISCTRLIST").Value = paymentLines[0].FieldByName("DISCTRLIST").Value;
                            paymentLines[0].FieldByName("MODIFIED").Value = 1;
                            paymentLines[0].FieldByName("DISCTRDELLIST").Value = 0;
                            paymentLines[0].FieldByName("TRNET").Value = paymentLines[0].FieldByName("TRNET").Value; // VATMATRAH;  myReaderSubLine["VATMATRAH"];
                            payment.Post();
                        }


                        /// HEADER EXTENTION
                        using (SqlConnection myConnectionTable = new SqlConnection( _GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString()))
                        {
                            myConnectionTable.Open();
                            SqlCommand myCmd = new SqlCommand();
                            myCmd.CommandText = "INSERT INTO   dbo.LG_XT001001_" +  _GLOBAL_PARAMETERS._SIRKET_NO + " (PARLOGREF,PLAN_KODU,  FATURA_BASKI_SEKLI, FAKTORING_SIRKETI_KODU, ILGILI_FATURA_NO,  SIPARISI_VEREN,DEPARTMAN,  BOLGE_KODU ,ILGILI_IS_UNITESI,  EFATURA_KODU) VALUES" +
                                                                                 " ( @PARLOGREF,@PLAN_KODU,  @FATURA_BASKI_SEKLI, @FAKTORING_SIRKETI_KODU, @ILGILI_FATURA_NO,  @SIPARISI_VEREN,@DEPARTMAN,  @BOLGE_KODU ,@ILGILI_IS_UNITESI,  @EFATURA_KODU )  ";
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
                            {// (mySelectQueryLine, ceConnLine);

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
                        /// LINE EXTENTION
                        using (SqlConnection ConnLineEx = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                        {
                            using (SqlCommand myCommandSubLineEx = new SqlCommand())
                            {// (mySelectQueryLine, ceConnLine);

                                string mySelectQueryEx = "  SELECT  *  FROM     dbo.FTR_LG_STLINE  where  SIRKET_KODU=@SIRKET_KODU AND  INVOICE_REF=@INVOICE_REF";
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

                                        if (myReaderSubLineEx["PLAN_KODU"].ToString().Length > 251) { }

                                        myCmd.CommandText = "INSERT INTO   dbo.LG_XT002001_" +  _GLOBAL_PARAMETERS._SIRKET_NO + " (PARLOGREF,PLAN_KODU,  SEHIR, FILM_ADI, SURE,  TARIH,OLCU,  TARIFE) VALUES ( @PARLOGREF,@PLAN_KODU, @SEHIR,  @FILM_ADI,  @SURE,   @TARIH, @OLCU,   @TARIFE )  ";
                                        myCmd.Parameters.AddWithValue("@PARLOGREF", ArryLISTREF_ID[ARRYID]);
                                        myCmd.Parameters.AddWithValue("@PLAN_KODU", myReaderSubLineEx["PLAN_KODU"]);
                                        myCmd.Parameters.AddWithValue("@SEHIR", myReaderSubLineEx["SEHIR"]);
                                        myCmd.Parameters.AddWithValue("@FILM_ADI", myReaderSubLineEx["FILM_ADI"]);
                                        myCmd.Parameters.AddWithValue("@SURE", myReaderSubLineEx["SURE"]);
                                        myCmd.Parameters.AddWithValue("@TARIH", myReaderSubLineEx["TARIH"]);
                                        myCmd.Parameters.AddWithValue("@OLCU", myReaderSubLineEx["OLCU"]);
                                        myCmd.Parameters.AddWithValue("@TARIFE", myReaderSubLineEx["TARIFE"]);
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
                        //// AUTO VIRMAN    
                        if (DEFNFLD_FAKTORING_SIRKETI_KODU != "" && DEFNFLD_FAC_CARI_KODU != "" && DEFNFLD_FAC_MUHASEBE_KODU != "")
                            AUTO_VIRMAN( _GLOBAL_PARAMETERS._SIRKET_NO, DEFNFLD_FAKTORING_SIRKETI_KODU, FATURA_NUMARASI, doPrhINVOICEHDR["DATE"].ToString(), doPrhINVOICEHDR["ARP_CODE"].ToString(), doPrhINVOICEHDR["GL_CODE"].ToString(), DEFNFLD_FAC_CARI_KODU, DEFNFLD_FAC_MUHASEBE_KODU
                                , doPrhINVOICEHDR["TOTAL_NET"].ToString(), doPrhINVOICEHDR["NOTES1"].ToString(), doPrhINVOICEHDR["TYPE"].ToString(),
                                 DATE_.AddDays(ODEMEVADESI).ToString("dd/MM/yyyy").ToString());



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

                             string FATURA_TIPI=""; 
                             if (doPrhINVOICEHDR["TYPE"].ToString() == "1") FATURA_TIPI="ALIM"; 
                             if (doPrhINVOICEHDR["TYPE"].ToString() == "6") FATURA_TIPI="ALIM İADE"; 

                            _GLOBAL_PARAMETERS.LOG_ISLEMLERI LF = new _GLOBAL_PARAMETERS.LOG_ISLEMLERI();
                            LF.LOG_AKTARIMI(FATURA_TIPI, FATURA_NUMARASI, "KAYIT", doPrhINVOICEHDR["TOTAL_NET"].ToString(), doPrhINVOICEHDR["TITLE"].ToString(), "", DEFNFLD_PLAN_KODU, doPrhINVOICEHDR["NOTES1"].ToString(),"");
         
                        }  

                        rReturn = "AKTARILDI";
                    }
                    else
                    {
                        if (doPrhInvoice.ValidateErrors.Count > 0)
                        {
                            for (int i = 0; i <= doPrhInvoice.ValidateErrors.Count - 1; i++)
                            {
                                rReturn += "Error code : " + (doPrhInvoice.ValidateErrors[i].ID) + "Error code : " + (char)10 + doPrhInvoice.ValidateErrors[i].Error.ToString();
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
                             string FATURA_TIPI=""; 
                             if (doPrhINVOICEHDR["TYPE"].ToString() == "1") FATURA_TIPI="ALIM"; 
                             if (doPrhINVOICEHDR["TYPE"].ToString() == "6") FATURA_TIPI="ALIM İADE";

                      

                            _GLOBAL_PARAMETERS.LOG_ISLEMLERI LF = new _GLOBAL_PARAMETERS.LOG_ISLEMLERI();
                            LF.LOG_AKTARIMI(FATURA_TIPI, FATURA_NUMARASI, "KAYIT-HATALI", doPrhINVOICEHDR["TOTAL_NET"].ToString(), doPrhINVOICEHDR["TITLE"].ToString(), "", DEFNFLD_PLAN_KODU, doPrhINVOICEHDR["NOTES1"].ToString(), rReturn);

                        }
                    }
                }
                Conn.Dispose();
            }
            return rReturn;
        }


        public void _Update(string FIRMA_KODU, string STRMECRAFATURANUMARASI, int LogicalRef)
        {
           _GLOBAL_PARAMETERS.Parametler.RAKAMKONTROL Numeric = new _GLOBAL_PARAMETERS.Parametler.RAKAMKONTROL();
            CultureInfo culture = new CultureInfo("tr-TR");
            string mySelectQuery = "  SELECT  MECRAFATURANUMARASI,PARLOGREF, FICHENO,MECRAFATURATARIHI AS DATE_, MECRAHESAPKODU AS ARP_CODE, " +
                " MARKAADI,ODEMEVADESI,MECRAHESAPKODU AS GL_CODE, KDVORANI AS VAT_RATE, SUM(CAST(VATMATRAH AS float)) AS TOTAL_DISCOUNTED, SUM(CAST(VATMATRAH AS float) * CAST(KDVORANI as int) / 100) " +
                " AS TOTAL_VAT, SUM(CAST(VATMATRAH AS float)) AS TOTAL_GROSS, SUM(CAST(VATMATRAH AS float)) AS TOTAL_NET, SUM(CAST(VATMATRAH AS float)) AS TC_NET,  1 AS CURRSER_TOTALS, COUNT(*) AS LINES,PARABIRIMI,MUSTERIPROJEKODU,ACIKLAMA,BELGENO   " +
                " FROM  dbo.ALIMFATURASI " +
                " WHERE (MECRAFATURANUMARASI='" + STRMECRAFATURANUMARASI + "') " +
                " GROUP BY MECRAFATURANUMARASI,PARLOGREF,FICHENO, MECRAFATURATARIHI, MARKAADI,ODEMEVADESI,MECRAHESAPKODU,PARABIRIMI,KDVORANI,MUSTERIPROJEKODU,ACIKLAMA,BELGENO   ";
            SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
            SqlCommand myCommandSub = new SqlCommand(mySelectQuery, Conn);
            Conn.Open();
            SqlDataReader myReaderSub = myCommandSub.ExecuteReader(CommandBehavior.CloseConnection);
            while (myReaderSub.Read())
            {
                string mySelectQueryEx = "  SELECT  top 1 *  FROM  dbo.ALIMFATURASI  where  FICHENO='" + myReaderSub["FICHENO"] + "' ";
                SqlConnection ConnLineEx = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
                SqlCommand myCommandSubLineEx = new SqlCommand(mySelectQueryEx, ConnLineEx);
                ConnLineEx.Open();
                SqlDataReader myReaderSubLineEx = myCommandSubLineEx.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReaderSubLineEx.Read())
                {
                    string mySelectQueryExIns = "  SELECT  top 1 *  FROM  dbo.LG_XT1014001_" +  _GLOBAL_PARAMETERS._SIRKET_NO + "  where  PARLOGREF='" + LogicalRef + "' ";
                    SqlConnection ConnLineExIns = new SqlConnection( _GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP);
                    SqlCommand myCommandSubLineExIns = new SqlCommand(mySelectQueryExIns, ConnLineExIns);
                    ConnLineExIns.Open();
                    SqlDataReader myReaderSubLineExIns = myCommandSubLineExIns.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReaderSubLineExIns.HasRows)
                    {
                        SqlConnection myConnectionTable = new SqlConnection( _GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString());
                        myConnectionTable.Open();
                        SqlCommand myCmd = new SqlCommand();
                        myCmd.CommandText = "UPDATE  dbo.LG_XT1014001_" +  _GLOBAL_PARAMETERS._SIRKET_NO + "" +
                          "  SET MALZEMEKODU=@MALZEMEKODU," +
                          "  MVDORANI=@MVDORANI," +
                          "  MVDOZELTUTAR=@MVDOZELTUTAR," +
                          "  ODEMEVADESI=@ODEMEVADESI," +
                          "  MECRAFATURANO=@MECRAFATURANO," +
                          "  KINETICFATURANO=@KINETICFATURANO," +
                          "  PASSBACKORANI=@PASSBACKORANI," +
                          "  ALAN1=@ALAN1," +
                          "  ALAN2=@ALAN2," +
                          "  ALAN3=@ALAN3," +
                          "  ALAN4=@ALAN4," +
                          "  ALAN5=@ALAN5," +
                          "  FEEORANI=@FEEORANI," +
                          "  MUSTERIPROJEADI=@MUSTERIPROJEADI," +
                          "  MARKAADI=@MARKAADI," +
                          "  MUSTERITIPI=@MUSTERITIPI," +
                          "  SIPARISNO=@SIPARISNO," +
                          "  MMSFATURANO=@MMSFATURANO," +
                          "  MUSTERIPROJEKODU=@MUSTERIPROJEKODU," +
                          "  KAMPANYAADI=@KAMPANYAADI," +
                          "  ACIKHAVAURUNTIPI=@ACIKHAVAURUNTIPI," +
                          "  ADETYUZ=@ADETYUZ," +
                          "  BIRIMFIYAT=@BIRIMFIYAT," +
                          "  SEHIR=@SEHIR," +
                          "  BASLANGICTARIHI=@BASLANGICTARIHI," +
                          "  BITISTARIHI=@BITISTARIHI" +

                          " where   PARLOGREF=@PARLOGREF  ";
                        myCmd.Parameters.Add("@MALZEMEKODU", SqlDbType.NVarChar); myCmd.Parameters["@MALZEMEKODU"].Value = myReaderSubLineEx["MALZEMEKODU"];
                        myCmd.Parameters.Add("@MVDORANI", SqlDbType.NVarChar); myCmd.Parameters["@MVDORANI"].Value = myReaderSubLineEx["MVDORANI"];
                        myCmd.Parameters.Add("@MVDOZELTUTAR", SqlDbType.NVarChar); myCmd.Parameters["@MVDOZELTUTAR"].Value = myReaderSubLineEx["MVDOZELTUTAR"];
                        myCmd.Parameters.Add("@ODEMEVADESI", SqlDbType.NVarChar); myCmd.Parameters["@ODEMEVADESI"].Value = myReaderSubLineEx["ODEMEVADESI"];
                        myCmd.Parameters.Add("@MECRAFATURANO", SqlDbType.NVarChar); myCmd.Parameters["@MECRAFATURANO"].Value = myReaderSubLineEx["MECRAFATURANUMARASI"];
                        myCmd.Parameters.Add("@KINETICFATURANO", SqlDbType.NVarChar); myCmd.Parameters["@KINETICFATURANO"].Value = myReaderSubLineEx["KINETICFATURANO"];
                        myCmd.Parameters.Add("@PASSBACKORANI", SqlDbType.NVarChar); myCmd.Parameters["@PASSBACKORANI"].Value = myReaderSubLineEx["PASSBACKORANI"];
                        myCmd.Parameters.Add("@ALAN1", SqlDbType.NVarChar); myCmd.Parameters["@ALAN1"].Value = myReaderSubLineEx["ALAN1"];
                        myCmd.Parameters.Add("@ALAN2", SqlDbType.NVarChar); myCmd.Parameters["@ALAN2"].Value = myReaderSubLineEx["ALAN2"];
                        myCmd.Parameters.Add("@ALAN3", SqlDbType.NVarChar); myCmd.Parameters["@ALAN3"].Value = myReaderSubLineEx["ALAN3"];
                        myCmd.Parameters.Add("@ALAN4", SqlDbType.NVarChar); myCmd.Parameters["@ALAN4"].Value = myReaderSubLineEx["ALAN4"];
                        myCmd.Parameters.Add("@ALAN5", SqlDbType.NVarChar); myCmd.Parameters["@ALAN5"].Value = myReaderSubLineEx["ALAN5"];
                        myCmd.Parameters.Add("@FEEORANI", SqlDbType.NVarChar); myCmd.Parameters["@FEEORANI"].Value = myReaderSubLineEx["FEEORANI"];
                        myCmd.Parameters.Add("@MUSTERIPROJEADI", SqlDbType.NVarChar); myCmd.Parameters["@MUSTERIPROJEADI"].Value = myReaderSubLineEx["MUSTERIPROJEADI"];
                        myCmd.Parameters.Add("@MARKAADI", SqlDbType.NVarChar); myCmd.Parameters["@MARKAADI"].Value = myReaderSubLineEx["MARKAADI"];
                        myCmd.Parameters.Add("@MUSTERITIPI", SqlDbType.NVarChar); myCmd.Parameters["@MUSTERITIPI"].Value = myReaderSubLineEx["MUSTERITIPI"];
                        myCmd.Parameters.Add("@SIPARISNO", SqlDbType.NVarChar); myCmd.Parameters["@SIPARISNO"].Value = myReaderSubLineEx["SIPARISNUMARASI"];
                        myCmd.Parameters.Add("@MMSFATURANO", SqlDbType.NVarChar); myCmd.Parameters["@MMSFATURANO"].Value = myReaderSubLineEx["MMSFATURANUMARASI"];
                        myCmd.Parameters.Add("@MUSTERIPROJEKODU", SqlDbType.NVarChar); myCmd.Parameters["@MUSTERIPROJEKODU"].Value = myReaderSubLineEx["MUSTERIPROJEKODU"];
                        myCmd.Parameters.Add("@KAMPANYAADI", SqlDbType.NVarChar); myCmd.Parameters["@KAMPANYAADI"].Value = myReaderSubLineEx["KAMPANYAADI"];
                        myCmd.Parameters.Add("@ACIKHAVAURUNTIPI", SqlDbType.NVarChar); myCmd.Parameters["@ACIKHAVAURUNTIPI"].Value = myReaderSubLineEx["ACIKHAVAURUNTIPI"];
                        myCmd.Parameters.Add("@ADETYUZ", SqlDbType.NVarChar); myCmd.Parameters["@ADETYUZ"].Value = myReaderSubLineEx["ADETYUZ"];
                        myCmd.Parameters.Add("@BIRIMFIYAT", SqlDbType.NVarChar); myCmd.Parameters["@BIRIMFIYAT"].Value = myReaderSubLineEx["BIRIMFIYAT"];
                        myCmd.Parameters.Add("@SEHIR", SqlDbType.NVarChar); myCmd.Parameters["@SEHIR"].Value = myReaderSubLineEx["SEHIR"];
                        myCmd.Parameters.Add("@BASLANGICTARIHI", SqlDbType.DateTime); myCmd.Parameters["@BASLANGICTARIHI"].Value = myReaderSubLineEx["KAMPANYASTARTDATE"];
                        myCmd.Parameters.Add("@BITISTARIHI", SqlDbType.DateTime); myCmd.Parameters["@BITISTARIHI"].Value = myReaderSubLineEx["KAMPANYAENDDATE"];
                        myCmd.Parameters.Add("@PARLOGREF", SqlDbType.Int); myCmd.Parameters["@PARLOGREF"].Value = LogicalRef;
                        myCmd.Connection = myConnectionTable;
                        myCmd.ExecuteNonQuery();
                        myCmd.Connection.Close();


                        //LOG_UPDATE LOGUPDATE = new LOG_UPDATE();
                        //LOGUPDATE.LogUpdatesAlim(myReaderSub["FICHENO"].ToString(), Convert.ToInt16(LogicalRef), "TRUE", "GÜNCELLENDİ");

                        //AKTARIMDURUMUSET = "TRUE";
                        //AKTARIMACIKLAMASET = "GÜNCELLENDİ";

                    }
                }
            }
            Conn.Dispose();
            //if (dlg != null) dlg.Close();
        }

        public void _CreateGlCard_(string FIRMA_KODU, string STRMECRAFATURANUMARASI, int LogicalRef)
        {
            _GLOBAL_PARAMETERS.Parametler.RAKAMKONTROL Numeric = new _GLOBAL_PARAMETERS.Parametler.RAKAMKONTROL();
            CultureInfo culture = new CultureInfo("tr-TR");

            string mySelectQuery = "  SELECT  MECRAFATURANUMARASI,PARLOGREF, FICHENO,MECRAFATURATARIHI AS DATE_, MECRAHESAPKODU AS ARP_CODE, " +
                " MARKAADI,ODEMEVADESI,MECRAHESAPKODU AS GL_CODE, KDVORANI AS VAT_RATE, SUM(CAST(VATMATRAH AS float)) AS TOTAL_DISCOUNTED, SUM(CAST(VATMATRAH AS float) * CAST(KDVORANI as int) / 100) " +
                " AS TOTAL_VAT, SUM(CAST(VATMATRAH AS float)) AS TOTAL_GROSS, SUM(CAST(VATMATRAH AS float)) AS TOTAL_NET, SUM(CAST(VATMATRAH AS float)) AS TC_NET,  1 AS CURRSER_TOTALS, COUNT(*) AS LINES,PARABIRIMI,MUSTERIPROJEKODU,ACIKLAMA,BELGENO  " +
                " FROM         dbo.SATISFATURASI " +
                " WHERE     (MECRAFATURANUMARASI='" + STRMECRAFATURANUMARASI + "') " +
                " GROUP BY MECRAFATURANUMARASI,PARLOGREF,FICHENO, MECRAFATURATARIHI, MARKAADI,ODEMEVADESI,MECRAHESAPKODU,PARABIRIMI,KDVORANI,MUSTERIPROJEKODU,ACIKLAMA,BELGENO  ";

            SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
            SqlCommand myCommandSub = new SqlCommand(mySelectQuery, Conn);
            Conn.Open();
            SqlDataReader myReaderSub = myCommandSub.ExecuteReader(CommandBehavior.CloseConnection);
            while (myReaderSub.Read())
            {
                string mySelectQueryEx = "  SELECT  top 1 *  FROM  dbo.SATISFATURASI  where  FICHENO='" + myReaderSub["FICHENO"] + "' ";
                SqlConnection ConnLineEx = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
                SqlCommand myCommandSubLineEx = new SqlCommand(mySelectQueryEx, ConnLineEx);
                ConnLineEx.Open();
                SqlDataReader myReaderSubLineEx = myCommandSubLineEx.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReaderSubLineEx.Read())
                {
                    string mySelectQueryExIns = "  SELECT  top 1 *  FROM  dbo.LG_XT1014001_" +  _GLOBAL_PARAMETERS._SIRKET_NO + "  where  PARLOGREF='" + LogicalRef + "' ";
                    SqlConnection ConnLineExIns = new SqlConnection( _GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP);
                    SqlCommand myCommandSubLineExIns = new SqlCommand(mySelectQueryExIns, ConnLineExIns);
                    ConnLineExIns.Open();
                    SqlDataReader myReaderSubLineExIns = myCommandSubLineExIns.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReaderSubLineExIns.HasRows)
                    {
                        SqlConnection myConnectionTable = new SqlConnection( _GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString());
                        myConnectionTable.Open();
                        SqlCommand myCmd = new SqlCommand();
                        myCmd.CommandText = "UPDATE  dbo.LG_XT1014001_" +  _GLOBAL_PARAMETERS._SIRKET_NO + "" +
                          " SET MALZEMEKODU=@MALZEMEKODU," +
                          "  MVDORANI=@MVDORANI," +
                          "  MVDOZELTUTAR=@MVDOZELTUTAR," +
                          "  ODEMEVADESI=@ODEMEVADESI," +
                          "  MECRAFATURANO=@MECRAFATURANO," +
                          "  KINETICFATURANO=@KINETICFATURANO," +
                          "  PASSBACKORANI=@PASSBACKORANI," +
                          "  ALAN1=@ALAN1," +
                          "  ALAN2=@ALAN2," +
                          "  ALAN3=@ALAN3," +
                          "  ALAN4=@ALAN4," +
                          "  ALAN5=@ALAN5," +
                          "  FEEORANI=@FEEORANI," +
                          "  MUSTERIPROJEADI=@MUSTERIPROJEADI," +
                          "  MARKAADI=@MARKAADI," +
                          "  MUSTERITIPI=@MUSTERITIPI," +
                          "  SIPARISNO=@SIPARISNO," +
                          "  MMSFATURANO=@MMSFATURANO," +
                          "  MUSTERIPROJEKODU=@MUSTERIPROJEKODU," +
                          "  KAMPANYAADI=@KAMPANYAADI," +
                          "  ACIKHAVAURUNTIPI=@ACIKHAVAURUNTIPI," +
                          "  ADETYUZ=@ADETYUZ," +
                          "  BIRIMFIYAT=@BIRIMFIYAT," +
                          "  SEHIR=@SEHIR," +
                          "  BASLANGICTARIHI=@BASLANGICTARIHI," +
                          "  BITISTARIHI=@BITISTARIHI" +
                          " where   PARLOGREF=@PARLOGREF  ";
                        myCmd.Parameters.Add("@MALZEMEKODU", SqlDbType.NVarChar); myCmd.Parameters["@MALZEMEKODU"].Value = myReaderSubLineEx["MALZEMEKODU"];
                        myCmd.Parameters.Add("@MVDORANI", SqlDbType.NVarChar); myCmd.Parameters["@MVDORANI"].Value = myReaderSubLineEx["MVDORANI"];
                        myCmd.Parameters.Add("@MVDOZELTUTAR", SqlDbType.NVarChar); myCmd.Parameters["@MVDOZELTUTAR"].Value = myReaderSubLineEx["MVDOZELTUTAR"];
                        myCmd.Parameters.Add("@ODEMEVADESI", SqlDbType.NVarChar); myCmd.Parameters["@ODEMEVADESI"].Value = myReaderSubLineEx["ODEMEVADESI"];
                        myCmd.Parameters.Add("@MECRAFATURANO", SqlDbType.NVarChar); myCmd.Parameters["@MECRAFATURANO"].Value = myReaderSubLineEx["MECRAFATURANUMARASI"];
                        myCmd.Parameters.Add("@KINETICFATURANO", SqlDbType.NVarChar); myCmd.Parameters["@KINETICFATURANO"].Value = myReaderSubLineEx["KINETICFATURANO"];
                        myCmd.Parameters.Add("@PASSBACKORANI", SqlDbType.NVarChar); myCmd.Parameters["@PASSBACKORANI"].Value = myReaderSubLineEx["PASSBACKORANI"];
                        myCmd.Parameters.Add("@ALAN1", SqlDbType.NVarChar); myCmd.Parameters["@ALAN1"].Value = myReaderSubLineEx["ALAN1"];
                        myCmd.Parameters.Add("@ALAN2", SqlDbType.NVarChar); myCmd.Parameters["@ALAN2"].Value = myReaderSubLineEx["ALAN2"];
                        myCmd.Parameters.Add("@ALAN3", SqlDbType.NVarChar); myCmd.Parameters["@ALAN3"].Value = myReaderSubLineEx["ALAN3"];
                        myCmd.Parameters.Add("@ALAN4", SqlDbType.NVarChar); myCmd.Parameters["@ALAN4"].Value = myReaderSubLineEx["ALAN4"];
                        myCmd.Parameters.Add("@ALAN5", SqlDbType.NVarChar); myCmd.Parameters["@ALAN5"].Value = myReaderSubLineEx["ALAN5"];
                        myCmd.Parameters.Add("@FEEORANI", SqlDbType.NVarChar); myCmd.Parameters["@FEEORANI"].Value = myReaderSubLineEx["FEEORANI"];
                        myCmd.Parameters.Add("@MUSTERIPROJEADI", SqlDbType.NVarChar); myCmd.Parameters["@MUSTERIPROJEADI"].Value = myReaderSubLineEx["MUSTERIPROJEADI"];
                        myCmd.Parameters.Add("@MARKAADI", SqlDbType.NVarChar); myCmd.Parameters["@MARKAADI"].Value = myReaderSubLineEx["MARKAADI"];
                        myCmd.Parameters.Add("@MUSTERITIPI", SqlDbType.NVarChar); myCmd.Parameters["@MUSTERITIPI"].Value = myReaderSubLineEx["MUSTERITIPI"];
                        myCmd.Parameters.Add("@SIPARISNO", SqlDbType.NVarChar); myCmd.Parameters["@SIPARISNO"].Value = myReaderSubLineEx["SIPARISNUMARASI"];
                        myCmd.Parameters.Add("@MMSFATURANO", SqlDbType.NVarChar); myCmd.Parameters["@MMSFATURANO"].Value = myReaderSubLineEx["MMSFATURANUMARASI"];
                        myCmd.Parameters.Add("@MUSTERIPROJEKODU", SqlDbType.NVarChar); myCmd.Parameters["@MUSTERIPROJEKODU"].Value = myReaderSubLineEx["MUSTERIPROJEKODU"];
                        myCmd.Parameters.Add("@KAMPANYAADI", SqlDbType.NVarChar); myCmd.Parameters["@KAMPANYAADI"].Value = myReaderSubLineEx["KAMPANYAADI"];
                        myCmd.Parameters.Add("@ACIKHAVAURUNTIPI", SqlDbType.NVarChar); myCmd.Parameters["@ACIKHAVAURUNTIPI"].Value = myReaderSubLineEx["ACIKHAVAURUNTIPI"];
                        myCmd.Parameters.Add("@ADETYUZ", SqlDbType.NVarChar); myCmd.Parameters["@ADETYUZ"].Value = myReaderSubLineEx["ADETYUZ"];
                        myCmd.Parameters.Add("@BIRIMFIYAT", SqlDbType.NVarChar); myCmd.Parameters["@BIRIMFIYAT"].Value = myReaderSubLineEx["BIRIMFIYAT"];
                        myCmd.Parameters.Add("@SEHIR", SqlDbType.NVarChar); myCmd.Parameters["@SEHIR"].Value = myReaderSubLineEx["SEHIR"];
                        myCmd.Parameters.Add("@BASLANGICTARIHI", SqlDbType.DateTime); myCmd.Parameters["@BASLANGICTARIHI"].Value = myReaderSubLineEx["KAMPANYASTARTDATE"];
                        myCmd.Parameters.Add("@BITISTARIHI", SqlDbType.DateTime); myCmd.Parameters["@BITISTARIHI"].Value = myReaderSubLineEx["KAMPANYAENDDATE"];
                        myCmd.Parameters.Add("@PARLOGREF", SqlDbType.Int); myCmd.Parameters["@PARLOGREF"].Value = myReaderSub["PARLOGREF"];
                        myCmd.Connection = myConnectionTable;
                        myCmd.ExecuteNonQuery();
                        myCmd.Connection.Close();

                        //LOG_UPDATE LOGUPDATE = new LOG_UPDATE();
                        //LOGUPDATE.LogUpdatesSatis(myReaderSub["FICHENO"].ToString(), Convert.ToInt16(LogicalRef), "TRUE", "GÜNCELLENDİ");
                        ////myReaderSub["PARLOGREF"].ToString()
                        //AKTARIMDURUMUSET = "TRUE";
                        //AKTARIMACIKLAMASET = "GÜNCELLENDİ";
                    }
                }
            }
            Conn.Dispose();
        }

        public void AUTO_VIRMAN(string FIRMA_KODU, string DEFNFLD_FAKTORING_SIRKETI_KODU, string FATURA_NUMARASI, string FICHE_DATE, string _CARI_I, string GL_CODE_I, string _CARI_II, string _GL_CODE_II,
            string TOTAL, string NOTE, string TYPE, string DUEDATE
            )
        {

            UnityObjects.IData arpVoucher = default(UnityObjects.IData);
            UnityObjects.IData invObj = default(UnityObjects.IData);
            UnityObjects.Lines arpVoucherLines = default(UnityObjects.Lines);
            UnityObjects.Lines arpPaymentLines = default(UnityObjects.Lines);
            UnityObjects.Query UnityQuery = default(UnityObjects.Query);
            int i, m, k, cnt;
            int groupedRowCount = 0;
            int sign = 0;
            DateTime ficheDate;
            DateTime tempdate;
            if (_GLOBAL_PARAMETERS.Global.UnityApp.Connected)
            {
                ////Yeni bir sql sorgusu çalıştırmak istediğimizi belirtiyoruz.     
                string mySelectQuery = "  SELECT * FROM dbo.FTR_LG_INVOICE WHERE  SIRKET_KODU ='"+_GLOBAL_PARAMETERS._SIRKET_KODU+"' and  (NUMBER='" + FATURA_NUMARASI + "') ";
                SqlConnection Conn = new SqlConnection( _GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB );
                SqlCommand myCommandSub = new SqlCommand(mySelectQuery, Conn);
                Conn.Open();
                SqlDataReader INVHeader = myCommandSub.ExecuteReader(CommandBehavior.CloseConnection);
                while (INVHeader.Read())
                {
                    arpVoucher = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doARAPVoucher);
                    arpVoucher.New();
                    arpVoucher.DataFields.FieldByName("NUMBER").Value = FATURA_NUMARASI;// INVHeader["FICHENO"].ToString(); //"~";
                    ficheDate = Convert.ToDateTime(FICHE_DATE); //INVHeader["DATE_"];
                    arpVoucher.DataFields.FieldByName("DATE").Value = ficheDate;
                    arpVoucher.DataFields.FieldByName("TYPE").Value = 5;
                    arpVoucher.DataFields.FieldByName("CURRSEL_TOTALS").Value = 1;
                    arpVoucher.DataFields.FieldByName("CURRSEL_DETAILS").Value = 1;
                    arpVoucher.DataFields.FieldByName("DATE_CREATED").Value = DateTime.Now.ToShortDateString();
                    arpVoucher.DataFields.FieldByName("DATA_REFERENCE").Value = "~";
                    arpVoucherLines = arpVoucher.DataFields.FieldByName("TRANSACTIONS").Lines;
                    ///''''VİRMAN FİŞİ SATIR 1'''''''''''''''''''''''''''''''''''''''
                    ///
                    if (arpVoucherLines.AppendLine())
                    {
                        arpVoucherLines[0].FieldByName("ARP_CODE").Value = _CARI_II;
                        arpVoucherLines[0].FieldByName("GL_CODE1").Value = _GL_CODE_II;
                        arpVoucherLines[0].FieldByName("CURR_TRANS").Value = 0;
                        arpVoucherLines[0].FieldByName("CURRSEL_TRANS").Value = 1;
                        arpVoucherLines[0].FieldByName("TC_XRATE").Value = 1;
                        arpVoucherLines[0].FieldByName("TC_AMOUNT").Value = Convert.ToDouble(TOTAL);
                        arpVoucherLines[0].FieldByName("DESCRIPTION").Value = "FT-" + FATURA_NUMARASI + " " + NOTE.ToString();
                        arpVoucherLines[0].FieldByName("DATA_REFERENCE").Value = "~";

                        switch (INVHeader["TYPE"].ToString())
                        {
                            case "6":
                            case "7":
                            case "8":
                            case "9":
                            case "10":
                                arpVoucherLines[0].FieldByName("DEBIT").Value = Convert.ToDouble(TOTAL);
                                sign = 1;
                                break;

                            default:
                                arpVoucherLines[0].FieldByName("CREDIT").Value = Convert.ToDouble(TOTAL);
                                sign = 0; ;
                                break;
                        }
                    }
                    arpPaymentLines = arpVoucherLines._Item[0].FieldByName("PAYMENT_LIST").Lines;

                    if (arpPaymentLines.AppendLine())
                    {
                        if (DUEDATE.ToString() != "")
                        {
                            tempdate = Convert.ToDateTime(DUEDATE);
                            arpPaymentLines[0].FieldByName("MODULENR").Value = 5;
                            arpPaymentLines[0].FieldByName("DATE").Value = tempdate.ToShortDateString();
                            arpPaymentLines[0].FieldByName("TRCODE").Value = 5;
                            arpPaymentLines[0].FieldByName("SIGN").Value = sign;
                            arpPaymentLines[0].FieldByName("TOTAL").Value = Convert.ToDouble(TOTAL);
                            arpPaymentLines[0].FieldByName("DISCTRDELLIST").Value = 0;
                            arpPaymentLines[0].FieldByName("PAY_NO").Value = 1;
                            arpPaymentLines[0].FieldByName("MODIFIED").Value = 1;
                            arpPaymentLines[0].FieldByName("PROCDATE").Value = ficheDate;
                            arpPaymentLines[0].FieldByName("DISCOUNT_DUEDATE").Value = tempdate.ToShortDateString();
                            arpPaymentLines[0].FieldByName("TRCURR").Value = 0;
                            arpPaymentLines[0].FieldByName("TRRATE").Value = 1;
                        }
                    }

                    // ''''VİRMAN FİŞİ SATIR 2'''''''''''''''''''''''''''''''''''''''

                    if (arpVoucherLines.AppendLine())
                    {
                        arpVoucherLines[1].FieldByName("ARP_CODE").Value = _CARI_I;
                        arpVoucherLines[1].FieldByName("GL_CODE1").Value = GL_CODE_I;
                        arpVoucherLines[1].FieldByName("CURR_TRANS").Value = 0;
                        arpVoucherLines[1].FieldByName("CURRSEL_TRANS").Value = 1;
                        arpVoucherLines[1].FieldByName("TC_XRATE").Value = 1;
                        arpVoucherLines[1].FieldByName("TC_AMOUNT").Value = Convert.ToDouble(TOTAL);
                        arpVoucherLines[1].FieldByName("DESCRIPTION").Value = "FT-" + FATURA_NUMARASI + " " + NOTE.ToString();
                        switch (TYPE.ToString())
                        {
                            case "6":
                            case "7":
                            case "8":
                            case "9":
                            case "10":
                                arpVoucherLines[1].FieldByName("CREDIT").Value = Convert.ToDouble(TOTAL);
                                break;
                            default:
                                arpVoucherLines[1].FieldByName("DEBIT").Value = Convert.ToDouble(TOTAL);
                                break;
                        }
                        arpVoucherLines[1].FieldByName("DATA_REFERENCE").Value = "~";
                    }

                    arpPaymentLines = arpVoucherLines._Item[1].FieldByName("PAYMENT_LIST").Lines;
                    if (arpPaymentLines.AppendLine())
                    {
                        if (DUEDATE.ToString() != "")
                        {
                            tempdate = Convert.ToDateTime(DUEDATE.ToString());
                            arpPaymentLines[0].FieldByName("MODULENR").Value = 5;
                            arpPaymentLines[0].FieldByName("DATE").Value = tempdate.ToShortDateString();
                            arpPaymentLines[0].FieldByName("TRCODE").Value = 5;
                            arpPaymentLines[0].FieldByName("SIGN").Value = sign;
                            arpPaymentLines[0].FieldByName("TOTAL").Value = Convert.ToDouble(TOTAL);
                            arpPaymentLines[0].FieldByName("DISCTRDELLIST").Value = 0;
                            arpPaymentLines[0].FieldByName("PAY_NO").Value = 1;
                            arpPaymentLines[0].FieldByName("MODIFIED").Value = 1;
                            arpPaymentLines[0].FieldByName("PROCDATE").Value = ficheDate;
                            arpPaymentLines[0].FieldByName("DISCOUNT_DUEDATE").Value = tempdate.ToShortDateString();
                            arpPaymentLines[0].FieldByName("TRCURR").Value = 0;
                            arpPaymentLines[0].FieldByName("TRRATE").Value = 1;
                        }
                    }

                    if (arpVoucher.Post())
                    {
                        //  UnityObjects.IData invObj = default(UnityObjects.IData);
                        Query Querys = _GLOBAL_PARAMETERS.Global.UnityApp.NewQuery();
                        string Query_String = " SELECT  LOGICALREF  FROM  dbo.LG_" +  _GLOBAL_PARAMETERS._SIRKET_NO + "_01_INVOICE  where (FICHENO='" + FATURA_NUMARASI + "')";
                        Querys.Statement = Query_String;
                        if (Querys.OpenDirect())
                        {
                            Querys.First();
                            switch (TYPE.ToString())
                            {
                                case "6":
                                case "7":
                                case "8":
                                case "9":
                                case "10":
                                    invObj = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doSalesInvoice);
                                    break;
                                default:
                                    invObj = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doPurchInvoice);
                                    break;
                            }
                            if (invObj.Read(Querys.QueryFields[0].Value))
                            {
                                invObj.DataFields.FieldByName("TRADING_GRP").Value = "FAC";
                            }
                            invObj.Post();

                        }
                    }
                    else
                    {
                        if (arpVoucher.ValidateErrors.Count > 0)
                        {
                            for (int ix = 0; ix <= arpVoucher.ValidateErrors.Count - 1; ix++)
                            {
                                // MessageBox.Show("Error code : " + (arpVoucher.ValidateErrors[ix].ID) + "Error code : " + (char)10 + arpVoucher.ValidateErrors[ix].Error.ToString());
                            }
                        }
                    }

                }
            }

        }

    }
}
