using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using UnityObjects;

namespace VISION.FINANS.ERP.ADMIN
{
    public partial class CL_CARD_ADD : DevExpress.XtraEditors.XtraForm
    {
        DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hiRow;
        DataRow TbSlctrow;
        public string _LREF, _CODE;
        public CL_CARD_ADD()
        {
            InitializeComponent();
            this.Tag = "MDIFORM"; 

            using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                myConnections.Open();
                SqlCommand myCommands = new SqlCommand();
                myCommands.Connection = myConnections;
                myCommands.CommandText = "SELECT ID, Cast('('+ cast(SIRKET_NO as nvarchar)+')'+ LOGIN_NAME   as nvarchar) as FIRMALAR from dbo.ADM_SIRKET_DONEMLERI";
                SqlDataReader sqlreaders = myCommands.ExecuteReader(CommandBehavior.CloseConnection);
                while (sqlreaders.Read())
                {
                    re_COMBO_LIST.Items.Add(sqlreaders["FIRMALAR"].ToString());
                }
                sqlreaders.Close();
                myCommands.Connection.Close();
                myConnections.Close();
            }
            DATA_READ();
        }


        private void DATA_READ()
        { 
            string SQLS = "";
            if (BAR_CMBX_DURUMU.EditValue.ToString() == "BEKLEMEDE")
            {
                SQLS = " select ID, SIRKET_KODU,cast('MECRA' as nvarchar)as TURU, SAHIS_SIRKETI,UNVANI AS TITLE, CARI_HESAP_KODU as CODE ,ADRESI,IBAN , VERGI_DAIRESI,VERGI_NO ,TC_KIMLIK_NO ,LOGO_DURUMU,YABANCI_UYRUKLU  from dbo.ADM_PAZARLAMA_SIRKETI WHERE (LOGO_DURUMU='AKTARILSIN')   " +
                       " UNION ALL " +
                       " select ID, SIRKET_KODU,cast('MÜŞTERİ' as nvarchar)as TURU,SAHIS_SIRKETI,ADI AS TITLE,CARI_HESAP_KODU as CODE, ADRESI,IBAN ,VERGI_DAIRESI,VERGI_NO ,TC_KIMLIK_NO  ,LOGO_DURUMU,YABANCI_UYRUKLU  from dbo.ADM_MUSTERI WHERE (LOGO_DURUMU='AKTARILSIN')  ";
            }
            if (BAR_CMBX_DURUMU.EditValue.ToString() == "TÜMÜ")
            {
                SQLS = " select ID, SIRKET_KODU,cast('MECRA' as nvarchar)as TURU,SAHIS_SIRKETI, UNVANI AS TITLE, CARI_HESAP_KODU as CODE ,ADRESI ,IBAN, VERGI_DAIRESI,VERGI_NO,TC_KIMLIK_NO  ,LOGO_DURUMU,YABANCI_UYRUKLU  from dbo.ADM_PAZARLAMA_SIRKETI    " +
                       " UNION ALL " +
                       " select ID, SIRKET_KODU,cast('MÜŞTERİ' as nvarchar)as TURU,SAHIS_SIRKETI,ADI AS TITLE,CARI_HESAP_KODU as CODE,ADRESI ,IBAN ,VERGI_DAIRESI,VERGI_NO ,TC_KIMLIK_NO  ,LOGO_DURUMU,YABANCI_UYRUKLU   from dbo.ADM_MUSTERI  ";
            }
            if (BAR_CMBX_DURUMU.EditValue.ToString() == "AÇILDI")
            {
                SQLS = " select ID, SIRKET_KODU,cast('MECRA' as nvarchar)as TURU, SAHIS_SIRKETI,UNVANI AS TITLE, CARI_HESAP_KODU as CODE ,ADRESI,IBAN, VERGI_DAIRESI,VERGI_NO ,TC_KIMLIK_NO ,LOGO_DURUMU,YABANCI_UYRUKLU  from dbo.ADM_PAZARLAMA_SIRKETI WHERE (LOGO_DURUMU='AÇILDI' )   " +
                       " UNION ALL " +
                       " select ID, SIRKET_KODU,cast('MÜŞTERİ' as nvarchar)as TURU,SAHIS_SIRKETI,ADI AS TITLE,CARI_HESAP_KODU as CODE,ADRESI,IBAN,VERGI_DAIRESI,VERGI_NO,TC_KIMLIK_NO   ,LOGO_DURUMU,YABANCI_UYRUKLU   from dbo.ADM_MUSTERI WHERE (LOGO_DURUMU='AÇILDI' ) "; 
            }
            if (BAR_CMBX_DURUMU.EditValue.ToString() == "RED")
            {
                SQLS = " select ID, SIRKET_KODU,cast('MECRA' as nvarchar)as TURU,SAHIS_SIRKETI, UNVANI AS TITLE, CARI_HESAP_KODU as CODE ,ADRESI ,IBAN, VERGI_DAIRESI , VERGI_NO,TC_KIMLIK_NO  ,LOGO_DURUMU ,YABANCI_UYRUKLU from dbo.ADM_PAZARLAMA_SIRKETI WHERE (LOGO_DURUMU='RED' )   " +
                       " UNION ALL " +
                       " select ID, SIRKET_KODU,cast('MÜŞTERİ' as nvarchar)as TURU,SAHIS_SIRKETI,ADI AS TITLE,CARI_HESAP_KODU as CODE,ADRESI  ,IBAN,VERGI_DAIRESI  ,VERGI_NO ,TC_KIMLIK_NO  ,LOGO_DURUMU,YABANCI_UYRUKLU   from dbo.ADM_MUSTERI WHERE (LOGO_DURUMU='RED' ) "; 
            }
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(SQLS, myConnection);
                DataSet MyDataSet = new DataSet();
                MySqlDataAdapter.Fill(MyDataSet, "dbo_MecraList");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                gridCntrl_LIST.DataSource = dv;
            }
        }

        private void BTN_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void BTN_LOGO_AKTAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //_GLOBAL_PARAMETERS.Global.UnityApp.CompanyLogout();

            //if (!_GLOBAL_PARAMETERS.Global.UnityApp.Connected)
            //{
            //    if (_GLOBAL_PARAMETERS.Global.UnityApp.Login(_GLOBAL_PARAMETERS._KULLANICI_KODU, _GLOBAL_PARAMETERS._KULLANICI_PASSWORD, intFirmNos, 1))
            //    {
            //    }
            //}

            int intFirmNos = Convert.ToInt32(_GLOBAL_PARAMETERS._SIRKET_NO);
            if (BAR_COMBOBOX_CHECKED_DATA.EditValue.ToString() != string.Empty)
            {
                //for (int XS = 0; XS <= gridView_LIST.GetSelectedRows - 1; XS++)
                //{
                    int intFirmNo = 0;
                    DataRow DR = gridView_LIST.GetDataRow(gridView_LIST.FocusedRowHandle);
                    if ((string)DR["CODE"] != string.Empty)
                    {
                        string[] Ones = BAR_COMBOBOX_CHECKED_DATA.EditValue.ToString().Split(',');
                        for (int X = 0; X <= Ones.Length - 1; X++)
                        { 
                            _GLOBAL_PARAMETERS.Global.UnityApp.CompanyLogout(); 
                            char[] karakterler = Ones[X].Trim().ToString().ToCharArray();
                            string Line1 = "";
                            for (int i = 1; i <= karakterler.Length - 1; i++)
                            {
                                if (karakterler[i].ToString() != ")")
                                { Line1 += karakterler[i].ToString(); }
                                else
                                { break; }
                            }
                       
                            //System.Threading.Thread.Sleep(9000);
                            //_GLOBAL_PARAMETERS.Global.UnityApp.Disconnect();
                            //System.Threading.Thread.Sleep(10000); 
                            //if (_GLOBAL_PARAMETERS.Global.UnityApp.Login(_GLOBAL_PARAMETERS._KULLANICI_KODU, _GLOBAL_PARAMETERS._KULLANICI_PASSWORD, intFirmNo, 1))


                                  intFirmNo = Convert.ToInt32(Line1);
                            if (_GLOBAL_PARAMETERS.Global.UnityApp.CompanyLogin(intFirmNo, 1))
                            {
                                if (DR["TURU"].ToString() == "MECRA")
                                {
                                    if (DR["SAHIS_SIRKETI"].ToString()=="TUZEL" ) PAZARLAMA_STI_EKLE((int)DR["ID"], (string)DR["CODE"], Line1, "TUZEL", DR["YABANCI_UYRUKLU"].ToString());

                                    if (DR["SAHIS_SIRKETI"].ToString()=="SAHIS" ) PAZARLAMA_STI_EKLE((int)DR["ID"], (string)DR["CODE"], Line1, "SAHIS", DR["YABANCI_UYRUKLU"].ToString());
                                }
                            }
                            else
                            {
                                switch (_GLOBAL_PARAMETERS.Global.UnityApp.GetLastError().ToString())
                                {
                                    case "-2":
                                        MessageBox.Show("Veri Kullanıcı Adı girdiniz!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                        break;
                                    case "-3":
                                        MessageBox.Show("Yanlış Kullanıcı Adı girdiniz!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                        break;
                                    case "-5":
                                        MessageBox.Show("Yanlış Şifre girdiniz!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                        break;
                                    case "-7":
                                        MessageBox.Show("Yanlış Firma Numarası!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                        break;
                                    case "-24":
                                        MessageBox.Show("Yanlış Firma Numarası!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                        break;
                                    default:
                                        MessageBox.Show("Yanlış bir uygulama!!! Hata Kodu: " + _GLOBAL_PARAMETERS.Global.UnityApp.GetLastError().ToString() + " Hata Açıklaması : ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                }
                              //  _GLOBAL_PARAMETERS.Global.UnityApp.Disconnect();
                            }
                        }

                        if (DR["TURU"].ToString() == "MÜŞTERİ")
                        {
                            if (DR["SAHIS_SIRKETI"].ToString()=="TUZEL") MUSTERI_EKLE((int)DR["ID"], (string)DR["CODE"]);

                            if (DR["SAHIS_SIRKETI"].ToString()=="SAHIS") MUSTERI_SAHIS_EKLE((int)DR["ID"], (string)DR["CODE"]); 
                        }
                         
                      
                    }
                //}
            }
            else
            { MessageBox.Show(" FİRMA SEÇİNİZ. "); }

            DATA_READ();
        }

        private void BTN_DELETE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] ROWS = gridView_LIST.GetSelectedRows();

            for (int XS = 0; XS <= ROWS.Length - 1; XS++)
            {
                DataRow DR = gridView_LIST.GetDataRow(ROWS[XS]);

                if (DR["TURU"].ToString() == "MECRA")
                {
                    using (SqlConnection myConnectionUp = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                    {
                        myConnectionUp.Open();
                        SqlCommand myCommandUp = new SqlCommand();
                        myCommandUp.Connection = myConnectionUp;
                        myCommandUp.CommandText = "update  dbo.ADM_PAZARLAMA_SIRKETI set SOFT_DELETE='?' where  ID=@ID";
                        myCommandUp.Parameters.AddWithValue("@ID", DR["ID"]);
                        myCommandUp.ExecuteReader(CommandBehavior.CloseConnection);
                    }
                } 
                if (DR["TURU"].ToString() == "MÜŞTERİ")
                {
                    using (SqlConnection myConnectionUp = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                    {
                        myConnectionUp.Open();
                        SqlCommand myCommandUp = new SqlCommand();
                        myCommandUp.Connection = myConnectionUp;
                        myCommandUp.CommandText = "update dbo.ADM_MUSTERI set SOFT_DELETE='?' where  ID=@ID";
                        myCommandUp.Parameters.AddWithValue("@ID", DR["ID"]);
                        myCommandUp.ExecuteReader(CommandBehavior.CloseConnection);
                    }
                }
            }
            DATA_READ();
        }

        private void BTN_ARSIVE_GONDER_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] ROWS = gridView_LIST.GetSelectedRows();

            for (int XS = 0; XS <= ROWS.Length - 1; XS++)
            {
                DataRow DR = gridView_LIST.GetDataRow(ROWS[XS]);
                if (DR["TURU"].ToString() == "MECRA")
                {
                    using (SqlConnection myConnectionUp = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                    {
                        myConnectionUp.Open();
                        SqlCommand myCommandUp = new SqlCommand();
                        myCommandUp.Connection = myConnectionUp;
                        myCommandUp.CommandText = "update dbo.ADM_PAZARLAMA_SIRKETI set LOGO_DURUMU='AÇILDI' where  ID=@ID";
                        myCommandUp.Parameters.AddWithValue("@ID", DR["ID"]);
                        myCommandUp.ExecuteReader(CommandBehavior.CloseConnection);
                    }
                }
                if (DR["TURU"].ToString() == "MÜŞTERİ")
                {
                    using (SqlConnection myConnectionUp = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                    {
                        myConnectionUp.Open();
                        SqlCommand myCommandUp = new SqlCommand();
                        myCommandUp.Connection = myConnectionUp;
                        myCommandUp.CommandText = "update dbo.ADM_MUSTERI set LOGO_DURUMU='AÇILDI' where  ID=@ID";
                        myCommandUp.Parameters.AddWithValue("@ID", DR["ID"]);
                        myCommandUp.ExecuteReader(CommandBehavior.CloseConnection);
                    }
                }
            } 
            DATA_READ();
        }

        private void BTN_UPDATE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BTN_REFRESH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DATA_READ();
        }

        private void PAZARLAMA_STI_EKLE(int ID, string CODE, string _SIRKET_NO,string TYPE,string YERLI_YABANCI)
        {
            string unitSet = "ADET"; // FATURADAN OKU 
            string itemCodes = string.Empty;
            string EVRAK_MAIL = string.Empty;
            using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString())) 
            {
                myConnections.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnections;
                cmd.CommandTimeout = 0;
                cmd.CommandText = "SELECT  *  from dbo.ADM_PAZARLAMA_SIRKETI where  ID=@ID";
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader sqlreaders = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sqlreaders.Read())
                {
                    string BR_CARI_BILGI = string.Empty;
                    UnityObjects.IData Cari = default(UnityObjects.IData);
                    if (_GLOBAL_PARAMETERS.Global.UnityApp.Connected)
                    {
                        Query CARI_SORGULA = _GLOBAL_PARAMETERS.Global.UnityApp.NewQuery();
                        string CARI_KONTROL = string.Empty;
                        CARI_SORGULA.Statement = " SELECT  CODE  FROM  dbo.LG_" + _SIRKET_NO + "_CLCARD  WHERE (dbo.LG_" + _SIRKET_NO + "_CLCARD.CODE='" + CODE + "')";
                        if (CARI_SORGULA.OpenDirect())
                        {
                            Cari = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doAccountsRP);
                            Cari.New();
                            Cari.DataFields.FieldByName("ACCOUNT_TYPE").Value = 3;
                            Cari.DataFields.FieldByName("CODE").Value = CODE;
                            Cari.DataFields.FieldByName("TITLE").Value = sqlreaders["UNVANI"];
                            Cari.DataFields.FieldByName("ADDRESS1").Value = sqlreaders["ADRESI"];
                            Cari.DataFields.FieldByName("ADDRESS2").Value = sqlreaders["ADRESI_IKI"];  
                            Cari.DataFields.FieldByName("TOWN_CODE").Value = sqlreaders["ILCE_CODE"];// "İlçe";
                            Cari.DataFields.FieldByName("TOWN").Value = sqlreaders["ILCE"];// "İlçe";
                            Cari.DataFields.FieldByName("CITY_CODE").Value = sqlreaders["IL_CODE"]; ;
                            Cari.DataFields.FieldByName("CITY").Value = sqlreaders["IL"]; 
                            Cari.DataFields.FieldByName("COUNTRY_CODE").Value = sqlreaders["ULKE_CODE"];
                            Cari.DataFields.FieldByName("COUNTRY").Value = sqlreaders["ULKE"];
                            Cari.DataFields.FieldByName("POSTAL_CODE").Value = sqlreaders["POSTA_KODU"];//"Posta Kodu";
                            Cari.DataFields.FieldByName("TELEPHONE1_CODE").Value = sqlreaders["TELEFON_CODE"];  
                            Cari.DataFields.FieldByName("TELEPHONE1").Value = sqlreaders["TELEFON"]; 
                            Cari.DataFields.FieldByName("FAX_CODE").Value = sqlreaders["FAX_CODE"];
                            Cari.DataFields.FieldByName("FAX").Value = sqlreaders["FAX"];   
                           // Cari.DataFields.FieldByName("TAX_ID").Value = sqlreaders["VERGI_NO"];  // "Vergi No";
                            Cari.DataFields.FieldByName("TAX_OFFICE").Value = sqlreaders["VERGI_DAIRESI"];  //"Vergi Dairesi";  
                            Cari.DataFields.FieldByName("CONTACT").Value =  sqlreaders["CONTACT"];// "İsim Soyisim"; 
                            Cari.DataFields.FieldByName("E_MAIL").Value = sqlreaders["EMAIL"]; //"E- Posta";  
                            Cari.DataFields.FieldByName("GL_CODE").Value = CreateGlCard(_SIRKET_NO, CODE, sqlreaders["UNVANI"].ToString()); // CreateGlCard(FIRMA_KODU, CODE, TITLE);// "Muhasebe Numarası"; 
                            Cari.DataFields.FieldByName("BANK_NAME1").Value = sqlreaders["BANKA_ADI1"];
                            Cari.DataFields.FieldByName("BANK_ACCOUNT1").Value = sqlreaders["HESAP_NO"]; 

                            Cari.DataFields.FieldByName("EXT_SEND_EMAIL").Value = sqlreaders["EMAIL"];
                            Cari.DataFields.FieldByName("ITR_SEND_MAIL_ADR").Value = sqlreaders["EMAIL"];
                            EVRAK_MAIL = sqlreaders["EMAIL"].ToString();
                            if (TYPE == "SAHIS")
                            {
                                Cari.DataFields.FieldByName("PERSCOMPANY").Value = 1;
                                Cari.DataFields.FieldByName("TCKNO").Value = sqlreaders["TC_KIMLIK_NO"];
                            }
                            else
                            {
                               // Cari.DataFields.FieldByName("PERSCOMPANY").Value = 0;
                                Cari.DataFields.FieldByName("TAX_ID").Value = sqlreaders["VERGI_NO"];
                            }


                            if (YERLI_YABANCI == "YERLI")
                            {
                                Cari.DataFields.FieldByName("ISFOREIGN").Value = 0;

                                if (sqlreaders["IBAN"].ToString().Length >= 26)
                                {
                                    Cari.DataFields.FieldByName("BANK_IBAN1").Value = sqlreaders["IBAN"];
                                }


                            }
                            else
                            {
                                string BANK_NAME1 = "";
                                if (sqlreaders["BANKA_ADI1"].ToString().Length < 20) BANK_NAME1 = sqlreaders["BANKA_ADI1"].ToString(); else BANK_NAME1 = sqlreaders["BANKA_ADI1"].ToString().Substring(0,19); 
                                if (sqlreaders["SWIFT_CODE"].ToString().Length < 28) BANK_NAME1 += sqlreaders["SWIFT_CODE"].ToString(); else BANK_NAME1 += sqlreaders["SWIFT_CODE"].ToString().Substring(0, 19);


                                string BANK_ACCOUNT1 = "";
                                if (sqlreaders["HESAP_NO"].ToString().Length < 20) BANK_ACCOUNT1 = sqlreaders["HESAP_NO"].ToString(); else BANK_ACCOUNT1 = sqlreaders["HESAP_NO"].ToString().Substring(0, 19);
                                if (sqlreaders["ABA"].ToString().Length < 28) BANK_ACCOUNT1 += sqlreaders["ABA"].ToString(); else BANK_ACCOUNT1 += sqlreaders["ABA"].ToString().Substring(0, 19);

                                 

                                Cari.DataFields.FieldByName("BANK_NAME1").Value= BANK_NAME1;
                                Cari.DataFields.FieldByName("BANK_ACCOUNT1").Value = BANK_ACCOUNT1; 

                                Cari.DataFields.FieldByName("ISFOREIGN").Value = 1;
                            }


                            //Cari.DataFields.FieldByName("SUBSCRIBER_EXT").Value = "Ekstra bilgi";
                            //Cari.DataFields.FieldByName("LOGOID").Value = "Firma Kodu";
                            // Cari.DataFields.FieldByName("WEB_URL").Value = sqlreaders["CONTACT"];// "www web sitesi";
                            // Cari.DataFields.FieldByName("DISTRICT").Value = sqlreaders["TITLE"];
                            // Cari.DataFields.FieldByName("TELEPHONE2").Value =  sqlreaders["TELEPHONE2"];
                            //   Cari.DataFields.FieldByName("TAX_OFFICE_CODE").Value =  sqlreaders["TAX_OFFICE_CODE"];;// "Veri Dairesi Kodu";
                            //  Cari.DataFields.FieldByName("BANK_NAMES1").Value = sqlreaders["BANKAADI"];//= "BANK_ID1";

                            //= "BANK_TITLE1";
                            //Cari.DataFields.FieldByName("BANK_TITLE1").Value = sqlreaders["VERGI_NO"];//= "BANK_TITLE1";
                            //Cari.DataFields.FieldByName("BANK_ID2").Value = sqlreaders["VERGI_NO"];//= "BANK_ID2";
                            //Cari.DataFields.FieldByName("BANK_TITLE2").Value = sqlreaders["VERGI_NO"];//= "BANK_TITLE2";

                            //Cari.DataFields.FieldByName("BANK_ACCOUNT1").Value = "BANK_ACCOUNT1";
                            //Cari.DataFields.FieldByName("BANK_ACCOUNT2").Value = "BANK_ACCOUNT2";




                            //if (sqlreaders["SAHIS_SIRKETI"].ToString() == "")
                            //{
                            //    Cari.DataFields.FieldByName("PERSCOMPANY").Value = 1;
                            //    Cari.DataFields.FieldByName("TCKNO").Value = sqlreaders["TC_KIMLIK_NO"];
                            //}

                            Cari.DataFields.FieldByName("PURCHBRWS").Value = 1;
                            Cari.DataFields.FieldByName("SALESBRWS").Value = 1;
                            Cari.DataFields.FieldByName("IMPBRWS").Value = 1;
                            Cari.DataFields.FieldByName("EXPBRWS").Value = 1;
                            Cari.DataFields.FieldByName("FINBRWS").Value = 1;
                            Cari.DataFields.FieldByName("DATA_REFERENCE").Value = "~";

                            ValidateErrors err = Cari.ValidateErrors;
                            if (Cari.Post())
                            {

                              int  lastLogicalRef = Cari.DataFields.FieldByName("INTERNAL_REFERENCE").Value;
                                DateTime dt = Convert.ToDateTime(DateTime.Now.ToShortDateString()); 

                                using (SqlConnection myConnectionUp = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString()))
                                {
                                    myConnectionUp.Open();
                                    SqlCommand myCommandUp = new SqlCommand();
                                    myCommandUp.Connection = myConnectionUp;
                                    myCommandUp.CommandText = "update dbo.LG_XT1015_" + _SIRKET_NO + " set EvrakAciklama='İŞLEM OK',YeniTedarikciFormu=1,WPPisahlaki=1,VergiLevhasi=1 ,TicaretSicilGazetesi=1,imzaSirkuleri=1,BankaBilgileri=1,EvrakTamTarihi=@EvrakTamTarihi,EvrakMail=@EvrakMail  where  PARLOGREF=@PARLOGREF";
                                    myCommandUp.Parameters.AddWithValue("@PARLOGREF", lastLogicalRef);
                                    myCommandUp.Parameters.AddWithValue("@EvrakTamTarihi", dt.ToString("yyyy.MM.dd").ToString());
                                    myCommandUp.Parameters.AddWithValue("@EvrakMail", EVRAK_MAIL);

                                    myCommandUp.ExecuteReader(CommandBehavior.CloseConnection);
                                }

                                EVRAK_MAIL = "";

                                //string itemCode = sqlreaders["CODE"].ToString ();
                                //string[] OitemCode = itemCode.Split('-');
                                //if (OitemCode[2].Length != 4) OitemCode[2] = OitemCode[2].ToString().Substring(0, 4).ToString();
                                //if (OitemCode[2] != null && OitemCode[2].Length == 4)
                                //{
                                //    itemCodes += OitemCode[0] + "-" + OitemCode[1] + "-" + OitemCode[2];
                                //}
                                //   CreateGlCard(_firmNo,  CODE , sqlreaders["UNVANI"].ToString());

                                BR_CARI_BILGI = "FİRMA EKLENDİ";
                                using (SqlConnection myConnectionUp = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))  
                                {
                                    myConnectionUp.Open();
                                    SqlCommand myCommandUp = new SqlCommand();
                                    myCommandUp.Connection = myConnectionUp;
                                    myCommandUp.CommandText = "update dbo.ADM_PAZARLAMA_SIRKETI set LOGO_DURUMU='AÇILDI' where  ID=@ID";
                                    myCommandUp.Parameters.AddWithValue("@ID", ID);
                                    myCommandUp.ExecuteReader(CommandBehavior.CloseConnection);
                                } 

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
                    Cari = null;
                }
                sqlreaders.Close();
                cmd.Connection.Close(); 
            }
        }
         
        private void MUSTERI_EKLE(int ID, string CODE)
        {
            string itemCodes = string.Empty;
            using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))  
            {
                myConnections.Open();
                SqlCommand myCommands = new SqlCommand();
                myCommands.Connection = myConnections;
                myCommands.CommandText = "SELECT  *  from dbo.ADM_MUSTERI where  ID=@ID";
                myCommands.Parameters.AddWithValue("@ID", ID);
                SqlDataReader sqlreaders = myCommands.ExecuteReader(CommandBehavior.CloseConnection);
                while (sqlreaders.Read())
                {
                    string BR_CARI_BILGI = string.Empty;
                    UnityObjects.IData Cari = default(UnityObjects.IData);
                    if (_GLOBAL_PARAMETERS.Global.UnityApp.Connected)
                    {
                        Query CARI_SORGULA = _GLOBAL_PARAMETERS.Global.UnityApp.NewQuery();
                        string CARI_KONTROL = string.Empty;
                        CARI_SORGULA.Statement = " SELECT  TAXNR  FROM  dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD  WHERE (dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD.CODE='" + sqlreaders["VERGI_NO"] + "')";
                        if (CARI_SORGULA.OpenDirect())
                        {

                            Cari = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doAccountsRP);
                            Cari.New();
                            Cari.DataFields.FieldByName("ACCOUNT_TYPE").Value = 3;
                            Cari.DataFields.FieldByName("CODE").Value = CODE;
                            Cari.DataFields.FieldByName("TITLE").Value = sqlreaders["M_UNVANI"];
                            Cari.DataFields.FieldByName("ADDRESS1").Value = sqlreaders["M_ADRESI"];
                            //Cari.DataFields.FieldByName("ADDRESS2").Value = sqlreaders["ADDRESS2"]; 
                            // Cari.DataFields.FieldByName("DISTRICT").Value = sqlreaders["TITLE"];
                            Cari.DataFields.FieldByName("TOWN").Value = sqlreaders["M_ILCE"];// "İlçe";
                            Cari.DataFields.FieldByName("CITY").Value = sqlreaders["M_IL"]; ;
                            Cari.DataFields.FieldByName("COUNTRY").Value = sqlreaders["M_ULKE"]; ;
                            //Cari.DataFields.FieldByName("POSTAL_CODE").Value = sqlreaders["POSTAL_CODE"]; ;//"Posta Kodu";
                            Cari.DataFields.FieldByName("TELEPHONE1").Value = sqlreaders["M_TELEFON"];
                            // Cari.DataFields.FieldByName("TELEPHONE2").Value =  sqlreaders["TELEPHONE2"];
                            Cari.DataFields.FieldByName("FAX").Value = sqlreaders["M_FAX"];
                            Cari.DataFields.FieldByName("TAX_ID").Value = sqlreaders["VERGI_NO"].ToString().Replace(" ", ""); ;// "Vergi No";
                            Cari.DataFields.FieldByName("TAX_OFFICE").Value = sqlreaders["VERGI_DAIRESI"]; ;//"Vergi Dairesi";
                            // Cari.DataFields.FieldByName("TAX_OFFICE_CODE").Value =  sqlreaders["TAX_OFFICE_CODE"];;// "Veri Dairesi Kodu";
                            // Cari.DataFields.FieldByName("CONTACT").Value =  sqlreaders["CONTACT"];// "İsim Soyisim";
                            Cari.DataFields.FieldByName("E_MAIL").Value = sqlreaders["M_EMAIL"]; //"E- Posta";
                            // Cari.DataFields.FieldByName("WEB_URL").Value = sqlreaders["CONTACT"];// "www web sitesi";
                            // Cari.DataFields.FieldByName("GL_CODE").Value = sqlreaders["CONTACT"];// CreateGlCard(FIRMA_KODU, CODE, TITLE);// "Muhasebe Numarası";
                            //Cari.DataFields.FieldByName("SUBSCRIBER_EXT").Value = "Ekstra bilgi";
                            //Cari.DataFields.FieldByName("LOGOID").Value = "Firma Kodu";



                            //if (sqlreaders["SAHIS_SIRKETI"].ToString() == "")
                            //{
                            //    Cari.DataFields.FieldByName("PERSCOMPANY").Value = 1;
                            //    Cari.DataFields.FieldByName("TCKNO").Value = sqlreaders["TC_KIMLIK_NO"];
                            //}



                            Cari.DataFields.FieldByName("PURCHBRWS").Value = 1;
                            Cari.DataFields.FieldByName("SALESBRWS").Value = 1;
                            Cari.DataFields.FieldByName("IMPBRWS").Value = 1;
                            Cari.DataFields.FieldByName("EXPBRWS").Value = 1;
                            Cari.DataFields.FieldByName("FINBRWS").Value = 1;
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
                                using (SqlConnection myConnectionUp = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))   
                                {
                                    myConnectionUp.Open();
                                    SqlCommand myCommandUp = new SqlCommand();
                                    myCommandUp.Connection = myConnectionUp;
                                    myCommandUp.CommandText = "update dbo.ADM_MUSTERI set LOGO_DURUMU='AÇILDI' where  ID=@ID";
                                    myCommandUp.Parameters.AddWithValue("@ID", ID);
                                    myCommandUp.ExecuteReader(CommandBehavior.CloseConnection);
                                }

                                string itemCode = CODE;// sqlreaders["CODE"].ToString();
                                string[] OitemCode = itemCode.Split('-');
                                if (OitemCode[2].Length != 4) OitemCode[2] = OitemCode[2].ToString().Substring(0, 4).ToString();
                                if (OitemCode[2] != null && OitemCode[2].Length == 4)
                                {
                                    itemCodes += OitemCode[0] + "-" + OitemCode[1] + "-" + OitemCode[2];
                                }

                                CreateGlCard(_GLOBAL_PARAMETERS._SIRKET_NO, "740.0" + OitemCode[0] + ".001." + OitemCode[2], sqlreaders["UNVANI"].ToString()); // 120  son 4 hanesini araştır   
                                CreateGlCard(_GLOBAL_PARAMETERS._SIRKET_NO, "601.0" + OitemCode[0] + ".001." + OitemCode[2], sqlreaders["UNVANI"].ToString());
                                CreateGlCard(_GLOBAL_PARAMETERS._SIRKET_NO, "600.0" + OitemCode[0] + ".001." + OitemCode[2], sqlreaders["UNVANI"].ToString());
                                CreateGlCard(_GLOBAL_PARAMETERS._SIRKET_NO, "610.0" + OitemCode[0] + ".001." + OitemCode[2], sqlreaders["UNVANI"].ToString());
                                CreateGlCard(_GLOBAL_PARAMETERS._SIRKET_NO, "611.0" + OitemCode[0] + ".001." + OitemCode[2], sqlreaders["UNVANI"].ToString());

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
                    Cari = null; 
                }
                sqlreaders.Close();
                myCommands.Connection.Close();
                myConnections.Close();
            }
        }
          


        private void MUSTERI_SAHIS_EKLE(int ID, string CODE)
        {
            string itemCodes = string.Empty;
            using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                myConnections.Open();
                SqlCommand myCommands = new SqlCommand();
                myCommands.Connection = myConnections;
                myCommands.CommandText = "SELECT  *  from dbo.ADM_MUSTERI where  ID=@ID";
                myCommands.Parameters.AddWithValue("@ID", ID);
                SqlDataReader sqlreaders = myCommands.ExecuteReader(CommandBehavior.CloseConnection);
                while (sqlreaders.Read())
                {
                    string BR_CARI_BILGI = string.Empty;
                    UnityObjects.IData Cari = default(UnityObjects.IData);
                    if (_GLOBAL_PARAMETERS.Global.UnityApp.Connected)
                    {
                        Query CARI_SORGULA = _GLOBAL_PARAMETERS.Global.UnityApp.NewQuery();
                        string CARI_KONTROL = string.Empty;
                        CARI_SORGULA.Statement = " SELECT  TAXNR  FROM  dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD  WHERE (dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD.CODE='" + sqlreaders["VERGI_NO"] + "')";
                        if (CARI_SORGULA.OpenDirect())
                        {

                            Cari = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doAccountsRP);
                            Cari.New();
                            Cari.DataFields.FieldByName("ACCOUNT_TYPE").Value = 3;
                            Cari.DataFields.FieldByName("CODE").Value = CODE;
                            Cari.DataFields.FieldByName("TITLE").Value = sqlreaders["M_UNVANI"];
                            Cari.DataFields.FieldByName("ADDRESS1").Value = sqlreaders["M_ADRESI"];
                            //Cari.DataFields.FieldByName("ADDRESS2").Value = sqlreaders["ADDRESS2"]; 
                            // Cari.DataFields.FieldByName("DISTRICT").Value = sqlreaders["TITLE"];
                            Cari.DataFields.FieldByName("TOWN").Value = sqlreaders["M_ILCE"];// "İlçe";
                            Cari.DataFields.FieldByName("CITY").Value = sqlreaders["M_IL"]; ;
                            Cari.DataFields.FieldByName("COUNTRY").Value = sqlreaders["M_ULKE"]; ;
                            //Cari.DataFields.FieldByName("POSTAL_CODE").Value = sqlreaders["POSTAL_CODE"]; ;//"Posta Kodu";
                            Cari.DataFields.FieldByName("TELEPHONE1").Value = sqlreaders["M_TELEFON"];
                            // Cari.DataFields.FieldByName("TELEPHONE2").Value =  sqlreaders["TELEPHONE2"];
                            Cari.DataFields.FieldByName("FAX").Value = sqlreaders["M_FAX"];
                            Cari.DataFields.FieldByName("TAX_ID").Value = sqlreaders["VERGI_NO"].ToString().Replace(" ", ""); ;// "Vergi No";
                            Cari.DataFields.FieldByName("TAX_OFFICE").Value = sqlreaders["VERGI_DAIRESI"]; ;//"Vergi Dairesi";
                            // Cari.DataFields.FieldByName("TAX_OFFICE_CODE").Value =  sqlreaders["TAX_OFFICE_CODE"];;// "Veri Dairesi Kodu";
                            // Cari.DataFields.FieldByName("CONTACT").Value =  sqlreaders["CONTACT"];// "İsim Soyisim";
                            Cari.DataFields.FieldByName("E_MAIL").Value = sqlreaders["M_EMAIL"]; //"E- Posta";
                            // Cari.DataFields.FieldByName("WEB_URL").Value = sqlreaders["CONTACT"];// "www web sitesi";
                            // Cari.DataFields.FieldByName("GL_CODE").Value = sqlreaders["CONTACT"];// CreateGlCard(FIRMA_KODU, CODE, TITLE);// "Muhasebe Numarası";
                            //Cari.DataFields.FieldByName("SUBSCRIBER_EXT").Value = "Ekstra bilgi";
                            //Cari.DataFields.FieldByName("LOGOID").Value = "Firma Kodu"; 
 
                            Cari.DataFields.FieldByName("PERSCOMPANY").Value = 1;
                            Cari.DataFields.FieldByName("TCKNO").Value = sqlreaders["TC_KIMLIK_NO"];  
                            Cari.DataFields.FieldByName("PURCHBRWS").Value = 1;
                            Cari.DataFields.FieldByName("SALESBRWS").Value = 1;
                            Cari.DataFields.FieldByName("IMPBRWS").Value = 1;
                            Cari.DataFields.FieldByName("EXPBRWS").Value = 1;
                            Cari.DataFields.FieldByName("FINBRWS").Value = 1;
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
                                using (SqlConnection myConnectionUp = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                                {
                                    myConnectionUp.Open();
                                    SqlCommand myCommandUp = new SqlCommand();
                                    myCommandUp.Connection = myConnectionUp;
                                    myCommandUp.CommandText = "update dbo.ADM_MUSTERI set LOGO_DURUMU='AÇILDI' where  ID=@ID";
                                    myCommandUp.Parameters.AddWithValue("@ID", ID);
                                    myCommandUp.ExecuteReader(CommandBehavior.CloseConnection);
                                }

                                string itemCode = CODE;// sqlreaders["CODE"].ToString();
                                string[] OitemCode = itemCode.Split('-');
                                if (OitemCode[2].Length != 4) OitemCode[2] = OitemCode[2].ToString().Substring(0, 4).ToString();
                                if (OitemCode[2] != null && OitemCode[2].Length == 4)
                                {
                                    itemCodes += OitemCode[0] + "-" + OitemCode[1] + "-" + OitemCode[2];
                                } 
                                CreateGlCard(_GLOBAL_PARAMETERS._SIRKET_NO, "740.0" + OitemCode[0] + ".001." + OitemCode[2], sqlreaders["UNVANI"].ToString()); // 120  son 4 hanesini araştır   
                                CreateGlCard(_GLOBAL_PARAMETERS._SIRKET_NO, "601.0" + OitemCode[0] + ".001." + OitemCode[2], sqlreaders["UNVANI"].ToString());
                                CreateGlCard(_GLOBAL_PARAMETERS._SIRKET_NO, "600.0" + OitemCode[0] + ".001." + OitemCode[2], sqlreaders["UNVANI"].ToString());
                                CreateGlCard(_GLOBAL_PARAMETERS._SIRKET_NO, "610.0" + OitemCode[0] + ".001." + OitemCode[2], sqlreaders["UNVANI"].ToString());
                                CreateGlCard(_GLOBAL_PARAMETERS._SIRKET_NO, "611.0" + OitemCode[0] + ".001." + OitemCode[2], sqlreaders["UNVANI"].ToString());

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
                    Cari = null;
                }
                sqlreaders.Close();
                myCommands.Connection.Close();
                myConnections.Close();
            }
        }

        public string CreateGlCard(string FIRMA_KODU, string ophCode, string description)
        {
            UnityObjects.IData itemCodeObj = default(UnityObjects.IData);
            UnityObjects.Query UnityQuery = default(UnityObjects.Query);

            if (_GLOBAL_PARAMETERS.Global.UnityApp.Connected)
            {
                string[] OCODE = ophCode.Split('.');
                if (OCODE[3].Length != 4) OCODE[3] = OCODE[3].ToString().Substring(0, 4).ToString();
                ophCode = OCODE[0] + "." + OCODE[1] + "." + OCODE[2] + "." + OCODE[3];

                UnityQuery = _GLOBAL_PARAMETERS.Global.UnityApp.NewQuery();
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
                        itemCodeObj = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doGLAccount);
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
                                ophCode = err[i].Error + "," + err[i].ID;
                            }
                        }
                    }
                }
            }
            return ophCode;
        }

        private void re_CMB_DURUMU_EditValueChanged(object sender, EventArgs e)
        {
            DATA_READ();
        }

        private void gridCntrl_LIST_Click(object sender, EventArgs e)
        {

        }

        private void BTN_MEDPLAN_UPDATE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime dt = Convert.ToDateTime(DateTime.Now.ToShortDateString()); 
            int[] ROWS = gridView_LIST.GetSelectedRows(); 
            for (int XS = 0; XS <= ROWS.Length - 1; XS++)
            {
                DataRow DR = gridView_LIST.GetDataRow(ROWS[XS]);
                 
                    using (SqlConnection myConnectionUp = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                    {
                        myConnectionUp.Open();
                        SqlCommand myCommandUp = new SqlCommand();
                        myCommandUp.Connection = myConnectionUp;
                        myCommandUp.CommandText = "update  dbo.ADM_PAZARLAMA_SIRKETI set MEDPLAN_AKTARIM_TARIHI=@MEDPLAN_AKTARIM_TARIHI where  ID=@ID"; 
                        myCommandUp.Parameters.AddWithValue("@ID", DR["ID"]);
                        myCommandUp.Parameters.AddWithValue("@MEDPLAN_AKTARIM_TARIHI", dt.ToString("yyyy.MM.dd").ToString());
                        myCommandUp.ExecuteReader(CommandBehavior.CloseConnection);
                    } 
            }
            DATA_READ();
        }

        private void BNT_LOGODAN_AL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CL_CARD_UPDATE_ALL frm = new CL_CARD_UPDATE_ALL(Convert.ToInt16(0));
            frm.ShowDialog();
        }

        private void gridView_LIST_DoubleClick(object sender, EventArgs e)
        {
           // hiRow = gridView_LIST;// gridView_LIST.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));


            TbSlctrow = gridView_LIST.GetDataRow(gridView_LIST.FocusedRowHandle);

            //TbSlctrow = gridView_LIST.GetDataRow(hiRow.RowHandle);
            if (TbSlctrow != null)
            {
                _LREF = TbSlctrow["ID"].ToString(); 
                if (_LREF != null || _LREF != "")
                {

                    CL_CARD_UPDATE_ALL frm = new CL_CARD_UPDATE_ALL(Convert.ToInt16(_LREF));
                    frm.ShowDialog();
                    //int itemRef = Convert.ToInt16(_LREF);
                    //try
                    //{
                    //    UnityObjects.Data Itm = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doAccountsRP);
                    //    if (Itm.Read(itemRef))
                    //    {
                    //        CARI_GL_CODE = Itm.DataFields.FieldByName("GL_CODE").Value;
                    //    }
                    //}
                    //catch
                    //{
                    //    string aaa = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doAccountsRP).ErrorCode.ToString();
                    //    //UnityObjects.IValidateError
                    //    MessageBox.Show(aaa, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //}

                }
            }
      
        }
    }
}