using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using UnityObjects;

namespace VISION
{ 
    public class _GLOBAL_PARAMETERS
    {
        readonly System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
        public static System.Threading.Thread thread = System.Threading.Thread.CurrentThread;
        public static System.Globalization.CultureInfo Culture = thread.CurrentCulture;
        public string _CULTURE = "tr-TR", _DIL = "tr-TR";


        public static IFormatProvider cultures = new System.Globalization.CultureInfo("tr-TR", true);

        // SERVER AYARLARI
        public static string _CONNECTIONSTRING_MDB, _CONNECTIONSTRING_ERP, _CONNECTIONSTRING_WEB, _DBONAME, _SERVERNAME, _IP, _DNS, _PLAN_SEC;
        // FIRMA BILGILERI
        public static string _SIRKET_KODU, _SIRKET_ADI, _SIRKET_NO, _TELEFON, _FAKS, _ADRES;
        // KULLANICI BILGILERI
        public static string  _MUSTERI_GROUP_KODU, _MUSTERI_KODU, _KULLANICI_KODU, _KULLANICI_DEPARTMANI, _KULLANICI_ADI_SOYADI, _KULLANICI_MAIL, _KULLANICI_MAKINASI, _KULLANICI_PASSWORD, _KULLANICI_GRUBU;
       // public static int _SIRKET_ID;

        public static bool _ERP_USER = false;
        public static bool _FATURA_SILME_YETKISI = false;

        //KULLANICI HAKLARI    
        public static bool _PROGRAM_KISITLAMASI, _MENU_KISITLAMASI, _MUSTERI_KISITLAMASI, _TOPLANTI_KISITLAMASI, _TRADING_ADMIN, _ENVANTER_ADMIN;

        //FATURA PARAMETRELERI
        public string _KDV_ORANI, _FATURA_KIME_KESILECEK;

        public static string _YEREL_PARA_BIRIMI,_FILE_PATH; 
     
        public ArrayList ARRAY_LIST_ACIK_PLANLAR;

         public class Global
        {
             
            private static Global GlobalVariableInstance = null;
            public Global()
            {
            }

            public Global GetGlobal()
            {
                if (GlobalVariableInstance == null)
                {
                    GlobalVariableInstance = new Global();
                }
                return GlobalVariableInstance;
            }


            public static UnityApplication UnityApp = new UnityApplication();

        }

        public class Parametler
        {
            public class RAKAMKONTROL
            {
                public string ReturnMoney = "";
                public string ReturnNumeric = "";
                public string _MoneyKontrol(string _Moneys)
                {
                    double _Money = Convert.ToDouble(_Moneys);
                    CultureInfo current = CultureInfo.CurrentCulture;
                    CultureInfo Turkiye = new CultureInfo("tr-TR");
                    //CultureInfo germany = new CultureInfo("de-DE");
                    //CultureInfo russian = new CultureInfo("ru-RU");   
                    ReturnMoney = _Money.ToString("C", Turkiye);
                    //string localMoney = _Numeric.ToString("C", current);
                    //Console.WriteLine(localMoney + " Local Money");   
                    //localMoney = money.ToString("C", russian);
                    //Console.WriteLine(localMoney + " Russian Money"); 
                    return ReturnMoney.ToString();
                }
                public string _NumericN2(string _Numerics)
                {
                    double _Numeric = Convert.ToDouble(_Numerics);
                    CultureInfo current = CultureInfo.CurrentCulture;
                    CultureInfo Turkiye = new CultureInfo("tr-TR");
                    //CultureInfo germany = new CultureInfo("de-DE");
                    //CultureInfo russian = new CultureInfo("ru-RU");   
                    ReturnNumeric = _Numeric.ToString("n2", Turkiye);
                    //string localMoney = _Numeric.ToString("C", current);
                    //Console.WriteLine(localMoney + " Local Money");   
                    //localMoney = money.ToString("C", russian);
                    //Console.WriteLine(localMoney + " Russian Money"); 
                    return ReturnNumeric.ToString();
                }
                public string _NumericN6(string _Numerics)
                {
                    double _Numeric = Convert.ToDouble(_Numerics);
                    CultureInfo current = CultureInfo.CurrentCulture;
                    CultureInfo Turkiye = new CultureInfo("tr-TR");
                    //CultureInfo germany = new CultureInfo("de-DE");
                    //CultureInfo russian = new CultureInfo("ru-RU");   
                    ReturnNumeric = _Numeric.ToString("n6", Turkiye);
                    //string localMoney = _Numeric.ToString("C", current);
                    //Console.WriteLine(localMoney + " Local Money");   
                    //localMoney = money.ToString("C", russian);
                    //Console.WriteLine(localMoney + " Russian Money"); 
                    return ReturnNumeric.ToString();
                }
                public string _NumericN9(string _Numerics)
                {
                    double _Numeric = Convert.ToDouble(_Numerics);
                    CultureInfo current = CultureInfo.CurrentCulture;
                    CultureInfo Turkiye = new CultureInfo("tr-TR");
                    ReturnNumeric = _Numeric.ToString("n9", Turkiye);
                    return ReturnNumeric.ToString();
                }
            }
        }




   

        public DataSet DEFAULT_MENU()
        {
            SqlConnection cnn = new SqlConnection(_CONNECTIONSTRING_MDB.ToString());
            string SQL = "select  * from  dbo.ADM_ANAMENULER where  _DEFAULT='True'";
            SqlDataAdapter da = new SqlDataAdapter(SQL, cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "ADM_ANAMENULER");
            cnn.Close();
            return ds;
        }
        public DataSet SIRKET_LISTESI(String GROUP, String FIRMA)
        {
            SqlConnection cnn = new SqlConnection(_CONNECTIONSTRING_MDB.ToString());
            SqlDataAdapter da = new SqlDataAdapter("", cnn);
            if (FIRMA == GROUP)
            {
                da.SelectCommand.CommandText = "select  * from  dbo.ADM_SIRKET  ";
            }
            else
            {
                da.SelectCommand.Parameters.Add(new SqlParameter("@SIRKET_KODU", SqlDbType.NVarChar));
                da.SelectCommand.Parameters["@SIRKET_KODU"].Value = FIRMA;
                da.SelectCommand.CommandText = "select  * from  dbo.ADM_SIRKET WHERE   (SIRKET_KODU = @SIRKET_KODU)   ";
            }
            DataSet ds = new DataSet();
            da.Fill(ds, "ADM_SIRKET");
            cnn.Close();
            return ds;
        }


        public DataSet IL()
        {
            SqlConnection cnn = new SqlConnection(_CONNECTIONSTRING_MDB.ToString());
            string SQL = "select  * from  dbo.ADM_SEHIR    ";
            SqlDataAdapter da = new SqlDataAdapter(SQL, cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "ADM_IL");
            cnn.Close();
            return ds;
        }


        public DataSet CREATIVE_AJANS(String FIRMA)
        {
            SqlConnection cnn = new SqlConnection(_CONNECTIONSTRING_MDB.ToString());
            string SQL = "select  * from  dbo.ADM_CREATIVE_AJANS WHERE   (SIRKET_KODU = @SIRKET_KODU)   ";
            SqlDataAdapter da = new SqlDataAdapter(SQL, cnn);
            da.SelectCommand.Parameters.Add(new SqlParameter("@SIRKET_KODU", SqlDbType.NVarChar));
            da.SelectCommand.Parameters["@SIRKET_KODU"].Value = _MUSTERI_KODU;
            DataSet ds = new DataSet();
            da.Fill(ds, "ADM_CREATIVE_AJANS");
            cnn.Close();
            return ds;
        }


        public DataSet ADEX_SEKTOR()
        {
            SqlConnection cnn = new SqlConnection(_CONNECTIONSTRING_MDB.ToString());
            string SQL = "select  * from  dbo.ADM_ADEX_SEKTOR    ";
            SqlDataAdapter da = new SqlDataAdapter(SQL, cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "ADM_ADEX_SEKTOR");
            cnn.Close();
            return ds;
        }

        public DataSet MUSTERI_GRUBU(String GROUP, String FIRMA)
        {
            SqlConnection cnn = new SqlConnection(_CONNECTIONSTRING_MDB.ToString());
            SqlDataAdapter da = new SqlDataAdapter("", cnn);
            if (FIRMA == GROUP)
            {
                da.SelectCommand.CommandText = "select  * from  dbo.ADM_MUSTERI_GRUBU  ";
            }
            else
            {
                da.SelectCommand.Parameters.Add(new SqlParameter("@SIRKET_KODU", SqlDbType.NVarChar));
                da.SelectCommand.Parameters["@SIRKET_KODU"].Value = FIRMA;
                da.SelectCommand.CommandText = "select  * from  dbo.ADM_MUSTERI_GRUBU WHERE   (SIRKET_KODU = @SIRKET_KODU)   ";
            }
            DataSet ds = new DataSet();
            da.Fill(ds, "MUSTERI_GRUBU");
            cnn.Close();
            return ds;
        }

        public DataSet MUSTERI_LISTESI()
        {

            SqlConnection cnn = new SqlConnection(_CONNECTIONSTRING_MDB.ToString());
            SqlDataAdapter da = new SqlDataAdapter("", cnn);
            //if (FIRMA == GROUP)
            //{
            //    da.SelectCommand.CommandText = "select  * from  dbo.ADM_MUSTERI  ";
            //}
            //else
            //{
                da.SelectCommand.Parameters.Add(new SqlParameter("@SIRKET_KODU", SqlDbType.NVarChar));
                da.SelectCommand.Parameters.Add(new SqlParameter("@MAIL_ADRESI", SqlDbType.NVarChar));
                da.SelectCommand.Parameters["@SIRKET_KODU"].Value = _SIRKET_KODU;
                da.SelectCommand.Parameters["@MAIL_ADRESI"].Value = _KULLANICI_MAIL ;
                //da.SelectCommand.CommandText = "select  * from  dbo.ADM_MUSTERI WHERE   (SIRKET_KODU = @SIRKET_KODU)   ";
                da.SelectCommand.CommandText = "SELECT     dbo.ADM_MUSTERI.MUSTERI_KODU, dbo.ADM_MUSTERI.ADI FROM         dbo.ADM_MUSTERI INNER JOIN dbo.ADM_KULLANICI_MUSTERILERI ON dbo.ADM_MUSTERI.MUSTERI_KODU = dbo.ADM_KULLANICI_MUSTERILERI.MUSTERI_KODU AND  dbo.ADM_MUSTERI.SIRKET_KODU = dbo.ADM_KULLANICI_MUSTERILERI.SIRKET_KODU WHERE     (dbo.ADM_KULLANICI_MUSTERILERI.MAIL_ADRESI = @MAIL_ADRESI ) AND    (dbo.ADM_MUSTERI.SIRKET_KODU = @SIRKET_KODU) ";

            //}
            DataSet ds = new DataSet();
            da.Fill(ds, "MUSTERI_LISTESI");
            cnn.Close();
            return ds;
        }

        public DataSet SATIN_ALMA_SIRKETI(String FIRMA)
        {
            SqlConnection cnn = new SqlConnection(_CONNECTIONSTRING_MDB.ToString());
            string SQL = "select  * from  dbo.ADM_SATIN_ALMA_SIRKETI WHERE   (SIRKET_KODU = @SIRKET_KODU)   ";
            SqlDataAdapter da = new SqlDataAdapter(SQL, cnn);
            da.SelectCommand.Parameters.Add(new SqlParameter("@SIRKET_KODU", SqlDbType.NVarChar));
            da.SelectCommand.Parameters["@SIRKET_KODU"].Value = FIRMA;
            DataSet ds = new DataSet();
            da.Fill(ds, "SATIN_ALMA_SIRKETI");
            cnn.Close();
            return ds;
        }


        public DataSet MECRA_TURLERI()
        {
            SqlConnection cnn = new SqlConnection(_CONNECTIONSTRING_MDB.ToString());
            string SQL = "select  * from  dbo.ADM_MECRA_TURLERI     ";
            SqlDataAdapter da = new SqlDataAdapter(SQL, cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "ADM_MECRA_TURLERI");
            cnn.Close();
            return ds;
        }

        public DataSet ALIM_SEKILLERI()
        {
            SqlConnection cnn = new SqlConnection(_CONNECTIONSTRING_MDB.ToString());
            string SQL = "select  * from  dbo.ADM_SPOT_ALIM_SEKILLERI     ";
            SqlDataAdapter da = new SqlDataAdapter(SQL, cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "ADM_SPOT_ALIM_SEKILLERI");
            cnn.Close();
            return ds;
        }

        public DataSet MECRA_LISTESI(String MECRA_TURU)
        { 
            SqlConnection cnn = new SqlConnection(_CONNECTIONSTRING_MDB.ToString());
            string SQL = null;
            if (MECRA_TURU == "TELEVİZYON") SQL = "select  * from  dbo.ADM_MECRA_TELEVIZYON";
            if (MECRA_TURU == "GAZETE") SQL = "select  * from  dbo.ADM_MECRA_GAZETE";
            if (MECRA_TURU == "DERGİ") SQL = "select  * from  dbo.ADM_MECRA_DERGI";
            if (MECRA_TURU == "RADYO") SQL = "select  * from  dbo.ADM_MECRA_RADYO";
            if (MECRA_TURU == "SİNEMA") SQL = "select  * from  dbo.ADM_MECRA_SINEMA";
            if (MECRA_TURU == "OUTDOOR") SQL = "select  * from  dbo.ADM_MECRA_OUTDOOR";
            if (MECRA_TURU == "İNTERNET") SQL = "select  * from  dbo.ADM_MECRA_INTERNET";


            SqlDataAdapter da = new SqlDataAdapter(SQL, cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "ADM_MECRA_LISTESI");
            cnn.Close();
            return ds;
        }

        public DataSet PAZARLAMA_SIRKETI_LISTESI(String GROUP, String FIRMA, String MECRA_TURU)
        {
            SqlConnection cnn = new SqlConnection(_CONNECTIONSTRING_MDB.ToString());
            SqlDataAdapter da = new SqlDataAdapter("", cnn);
            //if (FIRMA == GROUP)
            //{
            da.SelectCommand.CommandText = "select  * from  dbo.ADM_PAZARLAMA_SIRKETI  ";
            //}
            //else
            //{
            //    da.SelectCommand.Parameters.Add(new SqlParameter("@TELEVIZYON", SqlDbType.NVarChar));
            //    da.SelectCommand.Parameters["@TELEVIZYON"].Value = FIRMA;
            //    da.SelectCommand.CommandText = "select  * from  dbo.ADM_PAZARLAMA_SIRKETI WHERE   (TELEVIZYON = @TELEVIZYON)   ";
            //}
            DataSet ds = new DataSet();
            da.Fill(ds, "MUSTERI_GRUBU");
            cnn.Close();
            return ds;
        }

        public class CustomSummaryHelper
        {

            public static object GetWeightedAverage(GridView view, string weightField)
            {
                const decimal undefined = 0;
                if (view == null) return undefined;
                GridColumn weightCol = view.Columns[weightField];
                //GridColumn valueCol = view.Columns[valueField];
                if (weightCol == null) return undefined;

                try
                {
                    decimal totalWeight = 0;//, totalValue = 0;
                    for (int i = 0; i < view.DataRowCount; i++)
                    {
                        if (view.IsNewItemRow(i)) continue;
                        object temp;
                        decimal weight;//, val;
                        temp = view.GetRowCellValue(i, weightCol);
                        if (temp.ToString() == "") temp = null;
                        weight = (temp == DBNull.Value || temp == null) ? 0 : Convert.ToDecimal(1);
                        //temp = view.GetRowCellValue(i, valueCol);
                        //val = (temp == DBNull.Value || temp == null) ? 0 : Convert.ToDecimal(1);

                        totalWeight += weight;
                        //totalValue += weight * val;
                    }
                    if (totalWeight == 0) return undefined;
                    // return totalValue / totalWeight;
                    return totalWeight;
                }
                catch
                {
                    return undefined;
                }
            }
        }
  

        public string createClientCode(string FIRMA_KODU, string CODE, string TITLE, string ADDRESS1, string ADDRESS2, string CITY, string TAX_OFFICE_CODE, string TAX_ID)
        {

            if (CODE == "") return CODE = "FIRMA KODU BULUNAMADI";
            string BR_CARI_BILGI = string.Empty;
            UnityObjects.IData Cari = default(UnityObjects.IData);
            if (Global.UnityApp.Connected)
            {
                //string[] OCODE = CODE.Split('.');
                //if (OCODE[3].Length != 4) OCODE[3] = OCODE[3].ToString().Substring(0, 4).ToString();             
                //   CODE = OCODE[0] + "." + OCODE[1] + "." + OCODE[2] + "." + OCODE[3];   

                Query CARI_SORGULA = Global.UnityApp.NewQuery();
                string CARI_KONTROL = string.Empty;
                CARI_SORGULA.Statement = " SELECT  CODE  FROM  dbo.LG_" + FIRMA_KODU + "_CLCARD  WHERE (dbo.LG_" + FIRMA_KODU + "_CLCARD.CODE='" + CODE + "')";
                if (CARI_SORGULA.OpenDirect())
                {
                    if (CARI_SORGULA.First())
                    {
                        return CODE;
                    }
                    else
                    {
                        Cari = Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doAccountsRP);
                        Cari.New();
                        Cari.DataFields.FieldByName("ACCOUNT_TYPE").Value = 3;
                        Cari.DataFields.FieldByName("CODE").Value = CODE;
                        Cari.DataFields.FieldByName("TITLE").Value = TITLE;
                        Cari.DataFields.FieldByName("ADDRESS1").Value = ADDRESS1;
                        Cari.DataFields.FieldByName("ADDRESS2").Value = ADDRESS2;
                        //Cari.DataFields.FieldByName("DISTRICT").Value = "Mahalle";
                        //Cari.DataFields.FieldByName("TOWN").Value = "İlçe";
                        Cari.DataFields.FieldByName("CITY").Value = CITY;
                        //Cari.DataFields.FieldByName("COUNTRY").Value = COUNTRY;
                        //Cari.DataFields.FieldByName("POSTAL_CODE").Value = "Posta Kodu";
                        //Cari.DataFields.FieldByName("TELEPHONE1").Value = "Telefon 1";
                        //Cari.DataFields.FieldByName("TELEPHONE2").Value = "Telefon 2";
                        //Cari.DataFields.FieldByName("FAX").Value = "Fax";
                        Cari.DataFields.FieldByName("TAX_ID").Value = TAX_ID;// "Vergi No";
                        Cari.DataFields.FieldByName("TAX_OFFICE").Value = TAX_OFFICE_CODE;//"Vergi Dairesi";
                        // Cari.DataFields.FieldByName("TAX_OFFICE_CODE").Value = TAX_ID;// "Veri Dairesi Kodu";
                        //Cari.DataFields.FieldByName("CONTACT").Value = "İsim Soyisim";
                        //Cari.DataFields.FieldByName("E_MAIL").Value = "E- Posta";
                        //Cari.DataFields.FieldByName("WEB_URL").Value = "www web sitesi";     

                        Cari.DataFields.FieldByName("GL_CODE").Value = CreateGlCard(FIRMA_KODU, CODE, TITLE);// "Muhasebe Numarası";
                        //Cari.DataFields.FieldByName("SUBSCRIBER_EXT").Value = "Ekstra bilgi";
                        //Cari.DataFields.FieldByName("LOGOID").Value = "Firma Kodu";

                        Cari.DataFields.FieldByName("PURCHBRWS").Value = 1;
                        Cari.DataFields.FieldByName("SALESBRWS").Value = 1;
                        Cari.DataFields.FieldByName("IMPBRWS").Value = 1;
                        Cari.DataFields.FieldByName("EXPBRWS").Value = 1;
                        Cari.DataFields.FieldByName("FINBRWS").Value = 1;
                        Cari.DataFields.FieldByName("DATA_REFERENCE").Value = "~";

                        ValidateErrors err = Cari.ValidateErrors;
                        if (Cari.Post())
                        {
                            BR_CARI_BILGI = "FİRMA EKLENDİ";
                            //  Console.WriteLine("{0} firması eklendi.", "Firma Adı"); 

                        }
                        else
                        {
                            // Console.WriteLine("{0} firması eklenemedi.", "Firma Adı");
                            BR_CARI_BILGI = "FİRMA EKLENEMEDİ";
                            for (int i = 0; i < err.Count; i++)
                            {
                                Console.WriteLine("{0} – {1};", err[i].Error, err[i].ID);
                            }
                        }
                    }
                }
            }

            Cari = null;
            return BR_CARI_BILGI;
        }

        public string createSalesServiceCards(string FIRMA_KODU, string salesServiceCode, string salesServiceName, string description, string unitSet, string vat, string type)
        {
            string itemCodes = string.Empty;
            UnityObjects.IData itemCodeObj = default(UnityObjects.IData);
            UnityObjects.Query UnityQuery = default(UnityObjects.Query);

            if (Global.UnityApp.Connected)
            {
                UnityQuery = Global.UnityApp.NewQuery();
                string CARI_KONTROL = string.Empty;
                UnityQuery.Statement = "Select CODE From LG_" + FIRMA_KODU + "_SRVCARD where CODE='" + salesServiceCode + "'";
                if (UnityQuery.OpenDirect())
                {
                    if (UnityQuery.First())
                    {
                        return salesServiceCode;
                    }
                    else
                    {
                        int SrvCard_type = 0;
                        if (type == "1") // ALIM
                        {
                            itemCodeObj = Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doPurchService);
                            SrvCard_type = 1;
                        }
                        if (type == "8") // ŞATIŞ
                        {
                            itemCodeObj = Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doSalesService);
                            SrvCard_type = 2;
                        }
                        itemCodeObj.New();

                        itemCodeObj.DataFields.FieldByName("CARD_TYPE").Value = SrvCard_type;
                        itemCodeObj.DataFields.FieldByName("CODE").Value = salesServiceCode;
                        itemCodeObj.DataFields.FieldByName("DESCRIPTION").Value = salesServiceName;
                        itemCodeObj.DataFields.FieldByName("UNITSET_CODE").Value = unitSet;
                        itemCodeObj.DataFields.FieldByName("VAT_PERC").Value = vat;
                        itemCodeObj.DataFields.FieldByName("DATA_REFERENCE").Value = "~";

                        ValidateErrors err = itemCodeObj.ValidateErrors;
                        if (itemCodeObj.Post())
                        {
                            return itemCodes;
                        }
                        else
                        {
                            for (int i = 0; i < err.Count; i++)
                            {
                                itemCodes = err[i].Error + "," + err[i].ID;

                            }
                        }
                    }
                }
            }
            itemCodeObj = null;
            return itemCodes;
        }

        public string createItemCode(string itemCode, string itemName, string firmNo, string unitSet, string vat, string clientCode, string clientDesc,string Year, string STOPAJ_ROW)
        {

            unitSet = "ADET"; // FATURADAN OKU 
            string itemCodes = string.Empty;
            UnityObjects.IData itemCodeObj = default(UnityObjects.IData);
            UnityObjects.ILines itemlines = default(UnityObjects.ILines);
            UnityObjects.ILines itemUlines = default(UnityObjects.ILines);
            UnityObjects.Query UnityQuery = default(UnityObjects.Query);
            if (Global.UnityApp.Connected)
            {
                string[] OitemCode = itemCode.Split('-');
                if (OitemCode[2].Length != 4) OitemCode[2] = OitemCode[2].ToString().Substring(0, 4).ToString();
                if (OitemCode[2] != null && OitemCode[2].Length == 4)
                {
                    int MecraType = Convert.ToInt32(OitemCode[0]);
                    if (MecraType >= 15)
                    { 
                        string ITEM_CODE = OitemCode[0].Substring(0, 2);
                        string ITEM_TYPE = OitemCode[0].Substring(2, OitemCode[0].Length - 2);

                        if (STOPAJ_ROW == "0")
                        {
                            using (SqlConnection myConnection = new SqlConnection(_CONNECTIONSTRING_MDB.ToString()))
                            {
                                string SQL = " SELECT * from dbo.FTR_INTERNET_KATEGORI_LISTESI WHERE YIL='" + Year + "'";
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

                        if (Year.ToString() == "2019") ITEM_TYPE = ITEM_TYPE.Substring(1, ITEM_TYPE.Length - 1);


                        if (ITEM_TYPE.Length < 3) ITEM_TYPE = "0" + ITEM_TYPE;
                        if (ITEM_TYPE.Length < 3) ITEM_TYPE = "0" + ITEM_TYPE; 

                        itemCodes += ITEM_CODE + ITEM_TYPE + "-" + OitemCode[1] + "-" + OitemCode[2]; 
                    }
                    else
                    {
                        itemCodes += OitemCode[0] + "-" + OitemCode[1] + "-" + OitemCode[2];
                    } 
                
                }
                  Query CARI_SORGULA = Global.UnityApp.NewQuery();
                  string CARI_CODE = string.Empty;
                  string CARI_NAME = string.Empty; 
                  CARI_SORGULA.Statement = " SELECT CODE,DEFINITION_  FROM  dbo.LG_" + firmNo + "_CLCARD  WHERE (dbo.LG_" + firmNo + "_CLCARD.CODE='" + clientCode + "')";
                if (CARI_SORGULA.OpenDirect())
                {
                    bool eof = CARI_SORGULA.First(); //İlk kayıt isteniyor. Yoksa false döner;
                    if (eof)
                    {
                        CARI_CODE = Convert.ToString(CARI_SORGULA.QueryFields[0].Value);
                        CARI_NAME = CARI_SORGULA.QueryFields[1].Value;
                    }
                }

                UnityQuery = Global.UnityApp.NewQuery();
                string CARI_KONTROL = string.Empty;
                UnityQuery.Statement = " SELECT dbo.LG_" + firmNo + "_ITEMS.CODE  FROM  dbo.LG_" + firmNo + "_ITEMS  WHERE (dbo.LG_" + firmNo + "_ITEMS.CODE='" + itemCodes + "')";
                if (UnityQuery.OpenDirect())
                {
                    if (UnityQuery.First())
                    {
                        return itemCodes;
                    }
                    else
                    {
                        itemCodeObj = Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doMaterial);
                        itemCodeObj.New();
                        itemCodeObj.DataFields.FieldByName("CARD_TYPE").Value = 1;
                        itemCodeObj.DataFields.FieldByName("CODE").Value = itemCodes;
                        itemCodeObj.DataFields.FieldByName("NAME").Value = itemName;// "";// IIf(itemName = "", dt.Rows(2).Item("VALUE").ToString, itemName);
                        itemCodeObj.DataFields.FieldByName("UNITSET_CODE").Value = unitSet;
                        itemCodeObj.DataFields.FieldByName("VAT").Value = vat;
                        itemCodeObj.DataFields.FieldByName("DATA_REFERENCE").Value = "~";
                        itemCodeObj.DataFields.FieldByName("USEF_PURCHASING").Value = 1;
                        itemCodeObj.DataFields.FieldByName("USEF_SALES").Value = 1;
                        itemCodeObj.DataFields.FieldByName("USEF_MM").Value = 1;
                        itemlines = itemCodeObj.DataFields.FieldByName("GL_LINKS").Lines; 
                        itemlines.AppendLine();
                        itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 1; 
                        int MecraType=Convert.ToInt32(OitemCode[0]);  
                        if (MecraType>= 15)
                        { 
                            string ITEM_CODE = OitemCode[0].Substring(0, 2);
                            string ITEM_TYPE = OitemCode[0].Substring(2, OitemCode[0].Length - 2);
                            if (STOPAJ_ROW == "0")
                            {
                                using (SqlConnection myConnection = new SqlConnection(_CONNECTIONSTRING_MDB.ToString()))
                                {
                                    string SQL = " SELECT * from dbo.FTR_INTERNET_KATEGORI_LISTESI WHERE YIL='" + Year + "'";
                                    SqlCommand myCommand = new SqlCommand(SQL, myConnection);
                                    myCommand.CommandText = SQL.ToString();
                                    myConnection.Open();
                                    SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                                    while (myReader.Read())
                                    {
                                        if (Convert.ToInt32(ITEM_TYPE) >= Convert.ToInt32(myReader["MUHASEBE_KODU_BAS"].ToString()) && Convert.ToInt32(ITEM_TYPE) <= Convert.ToInt16(myReader["MUHASEBE_KODU_BIT"].ToString()))
                                        {
                                            ITEM_CODE = myReader["TRANSFER_KODU"].ToString();
                                            break;
                                        }
                                    }
                                    myReader.Close();
                                    myCommand.Connection.Close();
                                }
                            }
                            if (Year.ToString() == "2019") ITEM_TYPE = ITEM_TYPE.Substring(1, ITEM_TYPE.Length - 1);

                            if (ITEM_TYPE.Length < 3) ITEM_TYPE = "0" + ITEM_TYPE;
                            if (ITEM_TYPE.Length < 3) ITEM_TYPE = "0" + ITEM_TYPE;

                            if (STOPAJ_ROW == "0")
                            {
                                itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(firmNo, "740." + ITEM_CODE + "." + ITEM_TYPE + "." + OitemCode[2], CARI_NAME);
                            }
                            else
                            {
                                itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(firmNo, "740.50.001." + OitemCode[2], CARI_NAME);
                            }
                            // 120  son 4 hanesini araştır 
                            itemlines.AppendLine();
                            if (OitemCode[2].Substring(0, 1).ToString() == "5")
                            {
                                itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 3;
                                itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(firmNo, "601." + ITEM_CODE + "." + ITEM_TYPE + "." + OitemCode[2], CARI_NAME);
                            }
                            else
                            {
                                itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 3;
                                // itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(firmNo, "600." + ITEM_CODE + "." + ITEM_TYPE + "." + OitemCode[2], CARI_NAME);


                                if (STOPAJ_ROW == "0")
                                {
                                    itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(firmNo, "600." + ITEM_CODE + "." + ITEM_TYPE + "." + OitemCode[2], CARI_NAME);
                                }
                                else
                                {
                                    itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(firmNo, "600.50.001." + OitemCode[2], CARI_NAME);
                                }


                            }

                            itemlines.AppendLine();
                            itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 10;
                            ///      itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(firmNo, "740." + ITEM_CODE + "." + ITEM_TYPE + "." + OitemCode[2], CARI_NAME);



                            if (STOPAJ_ROW == "0")
                            {
                                itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(firmNo, "740." + ITEM_CODE + "." + ITEM_TYPE + "." + OitemCode[2], CARI_NAME);
                            }
                            else
                            {
                                itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(firmNo, "740.50.001." + OitemCode[2], CARI_NAME); 
                            } 
                        }
                        else
                        { 
                            itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(firmNo, "740.0" + OitemCode[0] + ".001." + OitemCode[2], clientDesc); // 120  son 4 hanesini araştır 
                            itemlines.AppendLine();
                            if (OitemCode[2].Substring(0, 1).ToString() == "5")
                            {
                                itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 3;
                                itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(firmNo, "601.0" + OitemCode[0] + ".001." + OitemCode[2], clientDesc);
                            }
                            else
                            {
                                itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 3;
                                itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(firmNo, "600.0" + OitemCode[0] + ".001." + OitemCode[2], clientDesc);
                            }

                            itemlines.AppendLine();
                            itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 10;
                            itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(firmNo, "740.0" + OitemCode[0] + ".001." + OitemCode[2], clientDesc);
                             
                        }

                        //itemlines.AppendLine();
                        //itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 11;
                        //itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(firmNo, "610.0" + OitemCode[0] + ".001." + OitemCode[2], clientDesc);

                        //itemlines.AppendLine();
                        //itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 13;
                        //itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(firmNo, "611.0" + OitemCode[0] + ".001." + OitemCode[2], clientDesc);
                        
                        itemUlines = itemCodeObj.DataFields.FieldByName("UNITS").Lines;
                        itemUlines.AppendLine();
                        itemUlines[itemUlines.Count - 1].FieldByName("UNIT_CODE").Value = unitSet;
                        itemUlines[itemUlines.Count - 1].FieldByName("USEF_MTRLCLASS").Value = 1;
                        itemUlines[itemUlines.Count - 1].FieldByName("USEF_PURCHCLAS").Value = 1;
                        itemUlines[itemUlines.Count - 1].FieldByName("USEF_SALESCLAS").Value = 1;
                        itemUlines[itemUlines.Count - 1].FieldByName("CONV_FACT1").Value = 1;
                        itemUlines[itemUlines.Count - 1].FieldByName("CONV_FACT2").Value = 1;
                        itemUlines[itemUlines.Count - 1].FieldByName("DATA_REFERENCE").Value = "~";

                        ValidateErrors err = itemCodeObj.ValidateErrors;
                        if (itemCodeObj.Post())
                        {
                            return itemCodes;
                        }
                        else
                        {
                            // Console.WriteLine("{0} firması eklenemedi.", "Firma Adı");
                            //itemCodes = "FİRMA EKLENEMEDİ";
                            for (int i = 0; i < err.Count; i++)
                            {
                                itemCodes += " HATA; " + err[i].Error;//+ "," + err[i].ID;
                                // Console.WriteLine("{0} – {itemCodes};", err[i].Error, err[i].ID);
                            }
                        }
                    }
                }
            }
            itemCodeObj = null;
            return itemCodes;
        }

        //public string createItemCode(string FIRMA_KODU, string itemCode, string vat, string TYPE, string DEFINITION_)
        //{
        //    string unitSet = "ADET"; // FATURADAN OKU 
        //    string itemCodes = string.Empty;             
        //    UnityObjects.IData itemCodeObj = default(UnityObjects.IData);
        //    UnityObjects.ILines itemlines = default(UnityObjects.ILines);
        //    UnityObjects.ILines itemUlines = default(UnityObjects.ILines);
        //    UnityObjects.Query UnityQuery = default(UnityObjects.Query);
        //    if (Global.UnityApp.Connected)
        //    {   
        //        string[] OitemCode = itemCode.Split('-');
        //        if (OitemCode[2].Length != 4) OitemCode[2] = OitemCode[2].ToString().Substring(0, 4).ToString();
        //        if (OitemCode[2] != null && OitemCode[2].Length == 4)
        //        { 
        //            itemCodes += OitemCode[0] + "-" + OitemCode[1] + "-" + OitemCode[2];
        //        }  
        //        Query CARI_SORGULA = Global.UnityApp.NewQuery();
        //        string CARI_CODE = string.Empty;
        //        string CARI_NAME = string.Empty;
        //        CARI_SORGULA.Statement = " SELECT CODE,DEFINITION_  FROM  dbo.LG_" + FIRMA_KODU + "_CLCARD  WHERE (dbo.LG_" + FIRMA_KODU + "_CLCARD.CODE='120.01.001." + OitemCode[2] + "')";

        //        if (CARI_SORGULA.OpenDirect())
        //        {
        //            bool eof = CARI_SORGULA.First(); //İlk kayıt isteniyor. Yoksa false döner;
        //            if (eof)
        //            {
        //                //while (eof)
        //                //{
        //                    CARI_CODE = Convert.ToString(CARI_SORGULA.QueryFields[0].Value);
        //                    CARI_NAME = CARI_SORGULA.QueryFields[1].Value;
        //                //    eof = CARI_SORGULA.Next(); // Sonraki kayıt isteniyor. Yoksa false döner;
        //                //}
        //            }
        //        } 

        //        UnityQuery = Global.UnityApp.NewQuery();
        //        string CARI_KONTROL = string.Empty;
        //        UnityQuery.Statement = " SELECT dbo.LG_" + FIRMA_KODU + "_ITEMS.CODE  FROM  dbo.LG_" + FIRMA_KODU + "_ITEMS  WHERE (dbo.LG_" + FIRMA_KODU + "_ITEMS.CODE='" + itemCodes + "')";
        //        if (UnityQuery.OpenDirect())
        //        {
        //            if (UnityQuery.First())
        //            {
        //                return itemCodes;
        //            }
        //            else
        //            {
        //                itemCodeObj = Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doMaterial);
        //                itemCodeObj.New();
        //                itemCodeObj.DataFields.FieldByName("CARD_TYPE").Value = 1;
        //                itemCodeObj.DataFields.FieldByName("CODE").Value = itemCodes;
        //                itemCodeObj.DataFields.FieldByName("NAME").Value = CARI_NAME;// "";// IIf(itemName = "", dt.Rows(2).Item("VALUE").ToString, itemName);
        //                itemCodeObj.DataFields.FieldByName("UNITSET_CODE").Value = unitSet;
        //                itemCodeObj.DataFields.FieldByName("VAT").Value = vat;
        //                itemCodeObj.DataFields.FieldByName("DATA_REFERENCE").Value = "~";
        //                itemCodeObj.DataFields.FieldByName("USEF_PURCHASING").Value = 1;
        //                itemCodeObj.DataFields.FieldByName("USEF_SALES").Value = 1;
        //                itemCodeObj.DataFields.FieldByName("USEF_MM").Value = 1;
        //                itemlines = itemCodeObj.DataFields.FieldByName("GL_LINKS").Lines;

        //                    itemlines.AppendLine();
        //                    itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 1;
        //                    itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(FIRMA_KODU, "740.0" + OitemCode[0] + ".001." + OitemCode[2], DEFINITION_); // 120  son 4 hanesini araştır                  

        //                        itemlines.AppendLine();
        //                        if(OitemCode[2].Substring(0,1).ToString()=="5")
        //                        {                            
        //                          itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 3;
        //                          itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(FIRMA_KODU, "601.0" + OitemCode[0] + ".001." + OitemCode[2], DEFINITION_);  
        //                        }
        //                          else
        //                        {
        //                           itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 3;
        //                           itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(FIRMA_KODU, "600.0" + OitemCode[0] + ".001." + OitemCode[2], DEFINITION_);  
        //                        } 

        //                    itemlines.AppendLine();
        //                    itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 10;
        //                    itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(FIRMA_KODU, "740.0" + OitemCode[0] + ".001." + OitemCode[2], DEFINITION_);  

        //                    itemlines.AppendLine();
        //                    itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 11;
        //                    itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(FIRMA_KODU, "610.0" + OitemCode[0] + ".001." + OitemCode[2], DEFINITION_);   


        //                    itemlines.AppendLine();
        //                    itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 13;
        //                    itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(FIRMA_KODU, "611.0" + OitemCode[0] + ".001." + OitemCode[2], DEFINITION_);     



        //                itemUlines = itemCodeObj.DataFields.FieldByName("UNITS").Lines;
        //                itemUlines.AppendLine();
        //                itemUlines[itemUlines.Count - 1].FieldByName("UNIT_CODE").Value = unitSet;
        //                itemUlines[itemUlines.Count - 1].FieldByName("USEF_MTRLCLASS").Value = 1;
        //                itemUlines[itemUlines.Count - 1].FieldByName("USEF_PURCHCLAS").Value = 1;
        //                itemUlines[itemUlines.Count - 1].FieldByName("USEF_SALESCLAS").Value = 1;
        //                itemUlines[itemUlines.Count - 1].FieldByName("CONV_FACT1").Value = 1;
        //                itemUlines[itemUlines.Count - 1].FieldByName("CONV_FACT2").Value = 1;
        //                itemUlines[itemUlines.Count - 1].FieldByName("DATA_REFERENCE").Value = "~";

        //                ValidateErrors err = itemCodeObj.ValidateErrors;
        //                if (itemCodeObj.Post())
        //                {
        //                    return itemCodes;
        //                }
        //                else
        //                {
        //                    // Console.WriteLine("{0} firması eklenemedi.", "Firma Adı");
        //                    //itemCodes = "FİRMA EKLENEMEDİ";
        //                    for (int i = 0; i < err.Count; i++)
        //                    {
        //                        itemCodes = err[i].Error + "," + err[i].ID;
        //                        // Console.WriteLine("{0} – {1};", err[i].Error, err[i].ID);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    itemCodeObj = null;
        //    return itemCodes;
        //}

        //public string createItemCode_Clinet(string FIRMA_KODU, string itemCode, string vat, string TYPE, string DEFINITION_)
        //{
        //    string unitSet = "ADET"; // FATURADAN OKU 
        //    string itemCodes = string.Empty;
        //    UnityObjects.IData itemCodeObj = default(UnityObjects.IData);
        //    UnityObjects.ILines itemlines = default(UnityObjects.ILines);
        //    UnityObjects.ILines itemUlines = default(UnityObjects.ILines);
        //    UnityObjects.Query UnityQuery = default(UnityObjects.Query);
        //    if (Global.UnityApp.Connected)
        //    {
        //        string[] OitemCode = itemCode.Split('-');
        //        if (OitemCode[2].Length != 4) OitemCode[2] = OitemCode[2].ToString().Substring(0, 4).ToString();
        //        if (OitemCode[2] != null && OitemCode[2].Length == 4)
        //        {
        //            itemCodes += OitemCode[0] + "-" + OitemCode[1] + "-" + OitemCode[2];
        //        }
        //        Query CARI_SORGULA = Global.UnityApp.NewQuery();
        //        string CARI_CODE = string.Empty;
        //        string CARI_NAME = string.Empty;
        //        CARI_SORGULA.Statement = " SELECT CODE,DEFINITION_  FROM  dbo.LG_" + FIRMA_KODU + "_CLCARD  WHERE (dbo.LG_" + FIRMA_KODU + "_CLCARD.CODE='120.01.001." + OitemCode[2] + "')";

        //        if (CARI_SORGULA.OpenDirect())
        //        {
        //            bool eof = CARI_SORGULA.First(); //İlk kayıt isteniyor. Yoksa false döner;
        //            if (eof)
        //            {
        //                //while (eof)
        //                //{
        //                CARI_CODE = Convert.ToString(CARI_SORGULA.QueryFields[0].Value);
        //                CARI_NAME = CARI_SORGULA.QueryFields[1].Value;
        //                //    eof = CARI_SORGULA.Next(); // Sonraki kayıt isteniyor. Yoksa false döner;
        //                //}
        //            }
        //        }

        //        UnityQuery = Global.UnityApp.NewQuery();
        //        string CARI_KONTROL = string.Empty;
        //        UnityQuery.Statement = " SELECT dbo.LG_" + FIRMA_KODU + "_ITEMS.CODE  FROM  dbo.LG_" + FIRMA_KODU + "_ITEMS  WHERE (dbo.LG_" + FIRMA_KODU + "_ITEMS.CODE='" + itemCodes + "')";
        //        if (UnityQuery.OpenDirect())
        //        {
        //            if (UnityQuery.First())
        //            {
        //                return itemCodes;
        //            }
        //            else
        //            {
        //                itemCodeObj = Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doMaterial);
        //                itemCodeObj.New();
        //                itemCodeObj.DataFields.FieldByName("CARD_TYPE").Value = 1;
        //                itemCodeObj.DataFields.FieldByName("CODE").Value = itemCodes;
        //                itemCodeObj.DataFields.FieldByName("NAME").Value = CARI_NAME;// "";// IIf(itemName = "", dt.Rows(2).Item("VALUE").ToString, itemName);
        //                itemCodeObj.DataFields.FieldByName("UNITSET_CODE").Value = unitSet;
        //                itemCodeObj.DataFields.FieldByName("VAT").Value = vat;
        //                itemCodeObj.DataFields.FieldByName("DATA_REFERENCE").Value = "~";
        //                itemCodeObj.DataFields.FieldByName("USEF_PURCHASING").Value = 1;
        //                itemCodeObj.DataFields.FieldByName("USEF_SALES").Value = 1;
        //                itemCodeObj.DataFields.FieldByName("USEF_MM").Value = 1;
        //                itemlines = itemCodeObj.DataFields.FieldByName("GL_LINKS").Lines;

        //                itemlines.AppendLine();
        //                itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 1;
        //                itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(FIRMA_KODU, "740.0" + OitemCode[0] + ".001." + OitemCode[2], DEFINITION_); // 120  son 4 hanesini araştır                  

        //                itemlines.AppendLine();
        //                if (OitemCode[2].Substring(0, 1).ToString() == "5")
        //                {
        //                    itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 3;
        //                    itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(FIRMA_KODU, "601.0" + OitemCode[0] + ".001." + OitemCode[2], DEFINITION_);
        //                }
        //                else
        //                {
        //                    itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 3;
        //                    itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(FIRMA_KODU, "600.0" + OitemCode[0] + ".001." + OitemCode[2], DEFINITION_);
        //                }

        //                itemlines.AppendLine();
        //                itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 10;
        //                itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(FIRMA_KODU, "740.0" + OitemCode[0] + ".001." + OitemCode[2], DEFINITION_);

        //                itemlines.AppendLine();
        //                itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 11;
        //                itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(FIRMA_KODU, "610.0" + OitemCode[0] + ".001." + OitemCode[2], DEFINITION_);


        //                itemlines.AppendLine();
        //                itemlines[itemlines.Count - 1].FieldByName("INFO_TYPE").Value = 13;
        //                itemlines[itemlines.Count - 1].FieldByName("GLACC_CODE").Value = CreateGlCard(FIRMA_KODU, "611.0" + OitemCode[0] + ".001." + OitemCode[2], DEFINITION_);



        //                itemUlines = itemCodeObj.DataFields.FieldByName("UNITS").Lines;
        //                itemUlines.AppendLine();
        //                itemUlines[itemUlines.Count - 1].FieldByName("UNIT_CODE").Value = unitSet;
        //                itemUlines[itemUlines.Count - 1].FieldByName("USEF_MTRLCLASS").Value = 1;
        //                itemUlines[itemUlines.Count - 1].FieldByName("USEF_PURCHCLAS").Value = 1;
        //                itemUlines[itemUlines.Count - 1].FieldByName("USEF_SALESCLAS").Value = 1;
        //                itemUlines[itemUlines.Count - 1].FieldByName("CONV_FACT1").Value = 1;
        //                itemUlines[itemUlines.Count - 1].FieldByName("CONV_FACT2").Value = 1;
        //                itemUlines[itemUlines.Count - 1].FieldByName("DATA_REFERENCE").Value = "~";

        //                ValidateErrors err = itemCodeObj.ValidateErrors;
        //                if (itemCodeObj.Post())
        //                {
        //                    return itemCodes;
        //                }
        //                else
        //                {
        //                    // Console.WriteLine("{0} firması eklenemedi.", "Firma Adı");
        //                    //itemCodes = "FİRMA EKLENEMEDİ";
        //                    for (int i = 0; i < err.Count; i++)
        //                    {
        //                        itemCodes = err[i].Error + "," + err[i].ID;
        //                        // Console.WriteLine("{0} – {1};", err[i].Error, err[i].ID);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    itemCodeObj = null;
        //    return itemCodes;
        //} 

        public string CreateGlCard(string FIRMA_KODU, string ophCode, string description)
        {
            UnityObjects.IData itemCodeObj = default(UnityObjects.IData);
            UnityObjects.Query UnityQuery = default(UnityObjects.Query);
            if (Global.UnityApp.Connected)
            {
                string[] OCODE = ophCode.Split('.');
                if (OCODE[3].Length != 4) OCODE[3] = OCODE[3].ToString().Substring(0, 4).ToString();
                ophCode = OCODE[0] + "." + OCODE[1] + "." + OCODE[2] + "." + OCODE[3];

                UnityQuery = Global.UnityApp.NewQuery();
                string CARI_KONTROL = string.Empty;
                UnityQuery.Statement = "Select CODE From LG_" + FIRMA_KODU + "_EMUHACC where CODE='" + ophCode + "'";
                if (UnityQuery.OpenDirect())
                {
                    if (UnityQuery.First())
                    {
                        return ophCode;
                    }
                    else
                    {
                        itemCodeObj = Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doGLAccount);
                        itemCodeObj.New();
                        itemCodeObj.DataFields.FieldByName("CODE").Value = ophCode;
                        itemCodeObj.DataFields.FieldByName("DESCRIPTION").Value = description;
                        itemCodeObj.DataFields.FieldByName("ACCOUNT_TYPE").Value = 2;
                        itemCodeObj.DataFields.FieldByName("DATA_REFERENCE").Value = "~";
                        ValidateErrors err = itemCodeObj.ValidateErrors;
                        if (itemCodeObj.Post())
                        {
                            return ophCode;
                        }
                        else
                        {
                            for (int i = 0; i < err.Count; i++)
                            {
                              //  ophCode += "  HATA;  " + ophCode;
                                ophCode += " HATA; " + err[i].Error;
                                //  ophCode += "  HATA; "+ ophCode;//err[i].Error + "," + err[i].ID;
                                //ophCode = "";
                            }
                        }
                    }
                }
            }
            return ophCode;
        }

        public string _UpdateClcard(string FIRMA_KODU, string CODE)
        {
            string BR_CARI_BILGI = string.Empty;
            UnityObjects.IData Cari = default(UnityObjects.IData);
            if (Global.UnityApp.Connected)
            {
                Cari = Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doAccountsRP);
                Cari.New();

                Cari.DataFields.FieldByName("ACCOUNT_TYPE").Value = 3;
                Cari.DataFields.FieldByName("CODE").Value = CODE;
                Cari.DataFields.FieldByName("TITLE").Value = "Firma Adı";
                Cari.DataFields.FieldByName("ADDRESS1").Value = "Adres 1";
                Cari.DataFields.FieldByName("ADDRESS2").Value = "Adres 2";
                Cari.DataFields.FieldByName("DISTRICT").Value = "Mahalle";
                Cari.DataFields.FieldByName("TOWN").Value = "İlçe";
                Cari.DataFields.FieldByName("CITY").Value = "Şehir";
                Cari.DataFields.FieldByName("COUNTRY").Value = "Ülke";
                Cari.DataFields.FieldByName("POSTAL_CODE").Value = "Posta Kodu";
                Cari.DataFields.FieldByName("TELEPHONE1").Value = "Telefon 1";
                Cari.DataFields.FieldByName("TELEPHONE2").Value = "Telefon 2";
                Cari.DataFields.FieldByName("FAX").Value = "Fax";
                Cari.DataFields.FieldByName("TAX_ID").Value = "Vergi No";
                Cari.DataFields.FieldByName("TAX_OFFICE").Value = "Vergi Dairesi";
                Cari.DataFields.FieldByName("TAX_OFFICE_CODE").Value = "Veri Dairesi Kodu";
                Cari.DataFields.FieldByName("CONTACT").Value = "İsim Soyisim";
                Cari.DataFields.FieldByName("E_MAIL").Value = "E- Posta";
                Cari.DataFields.FieldByName("WEB_URL").Value = "www web sitesi";
                Cari.DataFields.FieldByName("GL_CODE").Value = "Muhasebe Numarası";
                Cari.DataFields.FieldByName("SUBSCRIBER_EXT").Value = "Ekstra bilgi";
                Cari.DataFields.FieldByName("LOGOID").Value = "Firma Kodu";
                Cari.DataFields.FieldByName("PURCHBRWS").Value = 1;
                Cari.DataFields.FieldByName("SALESBRWS").Value = 1;
                Cari.DataFields.FieldByName("IMPBRWS").Value = 1;
                Cari.DataFields.FieldByName("EXPBRWS").Value = 1;
                Cari.DataFields.FieldByName("FINBRWS").Value = 1;
                Cari.DataFields.FieldByName("DATA_REFERENCE").Value = "~";

                ValidateErrors err = Cari.ValidateErrors;
                if (Cari.Post())
                {
                    BR_CARI_BILGI = "FİRMA EKLENDİ";
                    //  Console.WriteLine("{0} firması eklendi.", "Firma Adı"); 

                }
                else
                {
                    // Console.WriteLine("{0} firması eklenemedi.", "Firma Adı");
                    BR_CARI_BILGI = "FİRMA EKLENEMEDİ";
                    for (int i = 0; i < err.Count; i++)
                    {
                        Console.WriteLine("{0} – {1};", err[i].Error, err[i].ID);
                    }
                }
            } 
            Cari = null;
            return BR_CARI_BILGI;
        } 

        public class PARAYI_YAZIYA_CEVIR
        {
            private static readonly String[] enSmallNumber = {"","bir","iki","üç","dört","beş","altı","yedi","sekiz","dokuz","on","onbir","oniki","onüç","ondört","onbeş","onaltı","onyedi","onsekiz","ondokuz"};
            private static readonly String[] enLargeNumber = {"yirmi","otuz","kırk","elli","altmış","yetmiş","seksen","doksan"};
            private static readonly String[] enUnit = { "", "bin", "milyon", "yüzmilyon", "tirilyon" };

            public static String Para2Yazi(String MoneyString, string Cur, string underCur)
            {
                String[] tmpString = MoneyString.Split(',');
                String intString = MoneyString;
                String decString = "";
                String engCapital = "";
                String strBuff1;
                String strBuff2;
                String strBuff3;

                int curPoint;
                int i1;
                int i2;
                int i3;
                int k;
                int n;

                if (tmpString.Length > 1)
                {
                    intString = tmpString[0];
                    decString = tmpString[1];
                }

                decString += "00";
                decString = decString.Substring(0, 2);

                try
                {
                    curPoint = intString.Length - 1;

                    if (curPoint >= 0 && curPoint < 15)
                    {
                        k = 0;

                        while (curPoint >= 0)
                        {

                            strBuff1 = "";
                            strBuff2 = "";
                            strBuff3 = "";

                            if (curPoint >= 2)
                            {
                                n = int.Parse(intString.Substring(curPoint - 2, 3));
                                if (n != 0)
                                {
                                    i1 = n / 100;
                                    i2 = (n - i1 * 100) / 10;
                                    i3 = n - i1 * 100 - i2 * 10;

                                    if (i1 != 0)
                                        strBuff1 = enSmallNumber[i1] + " yüz ";

                                    if (i2 != 0)
                                    {
                                        if (i2 == 1)
                                            strBuff2 = enSmallNumber[i2 * 10 + i3] + " ";

                                        else
                                        {
                                            strBuff2 = enLargeNumber[i2 - 2] + " ";

                                            if (i3 != 0)
                                                strBuff3 = enSmallNumber[i3] + " ";
                                        }
                                    }
                                    else
                                    {
                                        if (i3 != 0)
                                            strBuff3 = enSmallNumber[i3] + " ";
                                    }

                                    engCapital = strBuff1 + strBuff2 + strBuff3 + enUnit[k] + " " + engCapital;
                                }
                            }
                            else
                            {
                                n = int.Parse(intString.Substring(0, curPoint + 1));

                                if (n != 0)
                                {
                                    i2 = n / 10;
                                    i3 = n - i2 * 10;

                                    if (i2 != 0)
                                    {
                                        if (i2 == 1)
                                            strBuff2 = enSmallNumber[i2 * 10 + i3] + " ";
                                        else
                                        {
                                            strBuff2 = enLargeNumber[i2 - 2] + " ";

                                            if (i3 != 0)
                                                strBuff3 = enSmallNumber[i3] + " ";
                                        }
                                    }
                                    else
                                    {
                                        if (i3 != 0)
                                            strBuff3 = enSmallNumber[i3] + " ";
                                    }

                                    engCapital = strBuff2 + strBuff3 + enUnit[k] + " " + engCapital;
                                }
                            }

                            ++k;

                            curPoint -= 3;

                        }
                        engCapital = engCapital.TrimEnd();
                    }

                    strBuff2 = "";
                    strBuff3 = "";

                    n = int.Parse(decString);

                    if (n != 0)
                    {
                        i2 = n / 10;
                        i3 = n - i2 * 10;

                        if (i2 != 0)
                        {
                            if (i2 == 1)
                            {
                                strBuff2 = enSmallNumber[i2 * 10 + i3] + " ";
                            }
                            else
                            {
                                strBuff2 = enLargeNumber[i2 - 2] + " ";

                                if (i3 != 0)
                                {
                                    strBuff3 = enSmallNumber[i3] + " ";
                                }
                            }
                        }
                        else
                        {

                            if (i3 != 0)
                                strBuff3 = enSmallNumber[i3] + " ";
                        }

                        if (engCapital.Length > 0)
                            engCapital = engCapital + " " + Cur + " " + strBuff2 + strBuff3 + " " + underCur;
                        else
                            engCapital = strBuff2 + strBuff3 + " " + underCur;
                    }
                    else engCapital = engCapital + " " + Cur;
                    engCapital = engCapital.TrimEnd();
                    return engCapital;
                }
                catch
                {
                    return "";
                }
            }

            public static string yaziyaCevir_TRL(decimal tutar, string BIRIMI, string KURUS)
            {
                string sTutar = tutar.ToString("F2").Replace('.', ','); // Replace('.',',') ondalık ayracının . olma durumu için            
                string lira = sTutar.Substring(0, sTutar.IndexOf(',')); //tutarın tam kısmı
                string kurus = sTutar.Substring(sTutar.IndexOf(',') + 1, 2);
                string yazi = "";

                string[] birler = { "", "BİR", "İKİ", "Üç", "DÖRT", "BEŞ", "ALTI", "YEDİ", "SEKİZ", "DOKUZ" };
                string[] onlar = { "", "ON", "YİRMİ", "OTUZ", "KIRK", "ELLİ", "ALTMIŞ", "YETMİŞ", "SEKSEN", "DOKSAN" };
                string[] binler = { "KATRİLYON", "TRİLYON", "MİLYAR", "MİLYON", "BİN", "" }; //KATRİLYON'un önüne ekleme yapılarak artırabilir.

                int grupSayisi = 6; //sayıdaki 3'lü grup sayısı. katrilyon içi 6. (1.234,00 daki grup sayısı 2'dir.)
                //KATRİLYON'un başına ekleyeceğiniz her değer için grup sayısını artırınız.

                lira = lira.PadLeft(grupSayisi * 3, '0'); //sayının soluna '0' eklenerek sayı 'grup sayısı x 3' basakmaklı yapılıyor.            

                string grupDegeri;

                for (int i = 0; i < grupSayisi * 3; i += 3) //sayı 3'erli gruplar halinde ele alınıyor.
                {
                    grupDegeri = "";

                    if (lira.Substring(i, 1) != "0")
                        grupDegeri += birler[Convert.ToInt32(lira.Substring(i, 1))] + "YÜZ"; //yüzler                

                    if (grupDegeri == "BİRYÜZ") //biryüz düzeltiliyor.
                        grupDegeri = "YÜZ";

                    grupDegeri += onlar[Convert.ToInt32(lira.Substring(i + 1, 1))]; //onlar

                    grupDegeri += birler[Convert.ToInt32(lira.Substring(i + 2, 1))]; //birler                

                    if (grupDegeri != "") //binler
                        grupDegeri += binler[i / 3];

                    if (grupDegeri == "BİRBİN") //birbin düzeltiliyor.
                        grupDegeri = "BİN";

                    yazi += grupDegeri;
                }

                if (yazi != "")
                    yazi += " " + BIRIMI + " ";

                int yaziUzunlugu = yazi.Length;

                if (kurus.Substring(0, 1) != "0") //kuruş onlar
                    yazi += onlar[Convert.ToInt32(kurus.Substring(0, 1))];

                if (kurus.Substring(1, 1) != "0") //kuruş birler
                    yazi += birler[Convert.ToInt32(kurus.Substring(1, 1))];

                if (yazi.Length > yaziUzunlugu)
                    yazi += " " + KURUS + ".";
                else
                    yazi += "SIFIR " + KURUS + ".";

                return yazi;
            }



            public static string yaziyaCevir_Usd(decimal tutar, string BIRIMI, string KURUS)
            {
                string sTutar = tutar.ToString("F2").Replace('.', ','); // Replace('.',',') ondalık ayracının . olma durumu için            
                string lira = sTutar.Substring(0, sTutar.IndexOf(',')); //tutarın tam kısmı
                string kurus = sTutar.Substring(sTutar.IndexOf(',') + 1, 2);
                string yazi = "";

                string[] birler = { "", "One", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                string[] onlar = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
                string[] binler = {  "","", "billion", "million", "A thousand", "" }; //KATRİLYON'un önüne ekleme yapılarak artırabilir.

                int grupSayisi = 6; //sayıdaki 3'lü grup sayısı. katrilyon içi 6. (1.234,00 daki grup sayısı 2'dir.)
                //KATRİLYON'un başına ekleyeceğiniz her değer için grup sayısını artırınız.

                lira = lira.PadLeft(grupSayisi * 3, '0'); //sayının soluna '0' eklenerek sayı 'grup sayısı x 3' basakmaklı yapılıyor.            

                string grupDegeri;

                for (int i = 0; i < grupSayisi * 3; i += 3) //sayı 3'erli gruplar halinde ele alınıyor.
                {
                    grupDegeri = "";

                    if (lira.Substring(i, 1) != "0")
                        grupDegeri += birler[Convert.ToInt32(lira.Substring(i, 1))] + "A hundred"; //yüzler                

                    if (grupDegeri == "OneA hundred") //biryüz düzeltiliyor.
                        grupDegeri = "A hundred";

                    grupDegeri += onlar[Convert.ToInt32(lira.Substring(i + 1, 1))]; //onlar

                    grupDegeri += birler[Convert.ToInt32(lira.Substring(i + 2, 1))]; //birler                

                    if (grupDegeri != "") //binler
                        grupDegeri += binler[i / 3];

                    if (grupDegeri == "OneA thousand") //birbin düzeltiliyor.
                        grupDegeri = "A thousand";

                    yazi += grupDegeri;
                }

                if (yazi != "")
                    yazi += " " + BIRIMI + " ";

                int yaziUzunlugu = yazi.Length;

                if (kurus.Substring(0, 1) != "0") //kuruş onlar
                    yazi += onlar[Convert.ToInt32(kurus.Substring(0, 1))];

                if (kurus.Substring(1, 1) != "0") //kuruş birler
                    yazi += birler[Convert.ToInt32(kurus.Substring(1, 1))];

                if (yazi.Length > yaziUzunlugu)
                    yazi += " " + KURUS + ".";
                else
                    yazi += "zero " + KURUS + ".";

                return yazi;
            }
        }

        //public static string _SIKET_KODU { get; set; }




     public class LOG_ISLEMLERI 
     {
         public string LOG_AKTARIMI(string YAPILAN_ISLEM, string FATURA_NO, string KAYIT_IPTAL, string KDV_DAHIL_TUTAR, string MUSTERI, string URUN_KODU, string PLAN_KODLARI, string FATURA_ACIKLAMASI, string HATA_MESAJI)
        {
            string BR_CARI_BILGI = string.Empty;
            DateTime dtm = DateTime.Now;
            SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
            myConnections.Open();

            using (SqlCommand myCmd = new SqlCommand())
            {
                myCmd.CommandText = "  INSERT INTO  dbo.XLG_FATURA_HAREKETLERI ( SIRKET_KODU, ISLEM_TARIHI, ISLEM_SAATI, YAPILAN_ISLEM, FATURA_NO, KAYIT_IPTAL, KDV_DAHIL_TUTAR, MUSTERI, URUN_KODU, PLAN_KODLARI, FATURA_ACIKLAMASI, ISLEMI_YAPAN, ISLEMI_YAPAN_MAKINA ,HATA_MESAJI)    VALUES   ( @SIRKET_KODU, @ISLEM_TARIHI, @ISLEM_SAATI, @YAPILAN_ISLEM, @FATURA_NO, @KAYIT_IPTAL, @KDV_DAHIL_TUTAR, @MUSTERI, @URUN_KODU, @PLAN_KODLARI, @FATURA_ACIKLAMASI, @ISLEMI_YAPAN, @ISLEMI_YAPAN_MAKINA,@HATA_MESAJI) ";

                myCmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                myCmd.Parameters.AddWithValue("@ISLEM_TARIHI", dtm.ToString("yyyy-MM-dd"));
                myCmd.Parameters.AddWithValue("@ISLEM_SAATI", dtm.ToString("hh:mm:ss"));
                myCmd.Parameters.AddWithValue("@YAPILAN_ISLEM", YAPILAN_ISLEM);
                myCmd.Parameters.AddWithValue("@FATURA_NO", FATURA_NO); 
                myCmd.Parameters.AddWithValue("@KAYIT_IPTAL", KAYIT_IPTAL);
                myCmd.Parameters.AddWithValue("@KDV_DAHIL_TUTAR", KDV_DAHIL_TUTAR);
                myCmd.Parameters.AddWithValue("@MUSTERI",MUSTERI);
                myCmd.Parameters.AddWithValue("@URUN_KODU", URUN_KODU);
                myCmd.Parameters.AddWithValue("@PLAN_KODLARI", PLAN_KODLARI);
                myCmd.Parameters.AddWithValue("@FATURA_ACIKLAMASI", FATURA_ACIKLAMASI);
                myCmd.Parameters.AddWithValue("@ISLEMI_YAPAN", _GLOBAL_PARAMETERS._KULLANICI_MAIL);
                myCmd.Parameters.AddWithValue("@ISLEMI_YAPAN_MAKINA", _GLOBAL_PARAMETERS._KULLANICI_MAKINASI);
                myCmd.Parameters.AddWithValue("@HATA_MESAJI", HATA_MESAJI);
                myCmd.Connection = myConnections;
                myCmd.ExecuteNonQuery();
            } 
            
            return BR_CARI_BILGI;
        }
     }
    }
}
