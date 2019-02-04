using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;


namespace VISION._ADMIN
{
    public partial class SIRKET_PARAMETRELERI : DevExpress.XtraEditors.XtraForm
    {
        public SIRKET_PARAMETRELERI()
        {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;


            DATA_LOAD(_GLOBAL_PARAMETERS._SIRKET_KODU);

        }


        private void DATA_LOAD(string FIRMA_ID)
        {
            using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                myConnections.Open();
                SqlCommand myCommands = new SqlCommand();
                myCommands.Connection = myConnections;
                myCommands.CommandText = "SELECT  *  from dbo.ADM_LGN_CAPIFIRM where  FIRMAID='" + FIRMA_ID + "'";
                SqlDataReader sqlreaders = myCommands.ExecuteReader(CommandBehavior.CloseConnection);
                while (sqlreaders.Read())
                {

                    TXT_ENTUSERNAME.Text = sqlreaders["ENTUSERNAME"].ToString();
                    TXT_ENTPASS.Text = sqlreaders["ENTPASS"].ToString();
                    TXT_ENTREASON.Text = sqlreaders["ENTREASON"].ToString();
                    TXT_ENTCHANNEL_NAME.Text = sqlreaders["ENTCHANNEL_NAME"].ToString();

                    TXT_FIRMAID.Text = sqlreaders["FIRMAID"].ToString();
                    TXT_VKN.Text = sqlreaders["VKN"].ToString();
                    TXT_TaxScheme.Text = sqlreaders["TaxScheme"].ToString();
                    TXT_PartyName.Text = sqlreaders["PartyName"].ToString();
                    TXT_ROOM.Text = sqlreaders["ROOM"].ToString();
                    TXT_StreetName.Text = sqlreaders["StreetName"].ToString();
                    TXT_BuildingName.Text = sqlreaders["BuildingName"].ToString();
                    TXT_BuildingNumber.Text = sqlreaders["BuildingNumber"].ToString();
                    TXT_CitySubdivisionName.Text = sqlreaders["CitySubdivisionName"].ToString();
                    TXT_CityName.Text = sqlreaders["CityName"].ToString();
                    TXT_Country.Text = sqlreaders["Country"].ToString();
                    TXT_Telephone.Text = sqlreaders["Telephone"].ToString();
                    TXT_WebsiteURI.Text = sqlreaders["WebsiteURI"].ToString();
                    TXT_ElectronicMail.Text = sqlreaders["ElectronicMail"].ToString();
                    TXT_TCN.Text = sqlreaders["TCN"].ToString();
                    TXT_SCN.Text = sqlreaders["SCN"].ToString();
                    TXT_EkNot.Text = sqlreaders["EkNot"].ToString();
                    TXT_EkNotTabloAdi.Text = sqlreaders["EkNotTabloAdi"].ToString();
                    TXT_EkNotAlanAdi.Text = sqlreaders["EkNotAlanAdi"].ToString();
                    txtKdvKod.Text = sqlreaders["GIBKdvCode"].ToString();
                    txtKdvAd.Text = sqlreaders["GIBKdvName"].ToString();
                    txtVergiKod1.Text = sqlreaders["GIBVergiKod1"].ToString();
                    txtVergiAd1.Text = sqlreaders["GIBVergiAd1"].ToString();
                    txtPref.Text = sqlreaders["PREF"].ToString();
                    txtSiraNo.Text = sqlreaders["FSIRANO"].ToString();
                    cmbArcAdres.Text = sqlreaders["SRVAdress"].ToString();
                    txtEntSrvAdress.Text = sqlreaders["SRVTestAdress"].ToString();
                    txtePostaHostAdres.Text = sqlreaders["EPostaAdres"].ToString();
                    txtePostaGonderenAdres.Text = sqlreaders["EPOSTHOST"].ToString();
                    txtEpostaPort.Text = sqlreaders["EPOSTPORT"].ToString();
                    txtePostaSifre.Text = sqlreaders["EPostaPwd"].ToString();
                    CHK_PROXY_KULLAN.Checked = (bool)sqlreaders["IsProxy"];
                    txtProxyDomain.Text = sqlreaders["ProxyDomain"].ToString();
                    txtProxyKullanici.Text = sqlreaders["ProxyUser"].ToString();
                    txtProxySifre.Text = sqlreaders["ProxyPass"].ToString();
                    txtProxyUrl.Text = sqlreaders["ProxyUrl"].ToString();
                    txtProxyPort.Text = sqlreaders["ProxyPort"].ToString();
                    chcOzelTasarim.Checked = (bool)sqlreaders["OzelTasarim"];
                    chckArayuzOlma.Checked = (bool)sqlreaders["ArayuzYok"];
                    txtEntSrvAdress.Text = sqlreaders["SRVAdress"].ToString();
                }
                sqlreaders.Close();
                myCommands.Connection.Close();
                myConnections.Close();
            }
        }

        private void BTN_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lbID.Caption != "")
            {

                GUNCELLE();
            }
            //else
            //{

            //    KAYDET();
            //}

        }

        private void KAYDET()
        {

            using (SqlConnection sqlconnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                sqlconnection.Open();
                string myInsertQuery = @"INSERT INTO dbo.ADM_LGN_CAPIFIRM (ENTUSERNAME,ENTPASS,ENTREASON,ENTCHANNEL_NAME,WebsiteURI,VKN,PartyName,Room,StreetName,BuildingName,BuildingNumber,CitySubdivisionName,CityName,TaxScheme,Country,Telephone,ElectronicMail,ACTIVE,FIRMAID,TCN,SCN,EkNot,EkNotTabloAdi,EkNotAlanAdi,EPOSTHOST,EPOSTPORT,PREF,FSIRANO,MalHizmetSecenegi,IRSALIYE,OzelTasarim,DEFAMBAR,Satis,Iade,GIBVergiKod1,GIBVergiAd1,EPostaAdres,EPostaPwd,GIBKdvCode,GIBKdvName,SRVAdress,SRVTestAdress,IsProxy,ProxyDomain,ProxyUser,ProxyPass,ProxyUrl,ProxyPort,ArayuzYok,DOSYA_ADRESI) 
                                                                   VALUES (@ENTUSERNAME,@ENTPASS,@ENTREASON,@ENTCHANNEL_NAME,@WebsiteURI,@VKN,@PartyName,@Room,@StreetName,@BuildingName,@BuildingNumber,@CitySubdivisionName,@CityName,@TaxScheme,@Country,@Telephone,@ElectronicMail,@ACTIVE,@FIRMAID,@TCN,@SCN,@EkNot,@EkNotTabloAdi,@EkNotAlanAdi,@EPOSTHOST,@EPOSTPORT,@PREF,@FSIRANO,@MalHizmetSecenegi,@IRSALIYE,@OzelTasarim,@DEFAMBAR,@Satis,@Iade,@GIBVergiKod1,@GIBVergiAd1,@EPostaAdres,@EPostaPwd,@GIBKdvCode,@GIBKdvName,@SRVAdress,@SRVTestAdress,@IsProxy,@ProxyDomain,@ProxyUser,@ProxyPass,@ProxyUrl,@ProxyPort,@ArayuzYok,@DOSYA_ADRESI)";

                //  //  @SRVAdress,@SRVTestAdress,@GIBKdvCode ,@GIBKdvName,@CARI_TABLE,@DEFAMBAR,@Satis,@Iade,@vSIP_TABLE,@ReRun,@GIBVergiKod1,@GIBVergiAd1,@EPostaAdres,@EPostaPwd,@LastGibUser,@GibUserCheckTime,@AkisVknBirimId,@AkisGenelId,@AkisZorunluBirimId,@EPOSTHOST,@EPOSTPORT,@PREF,@FSIRANO,@IsProxy,@ProxyDomain,@ProxyUser,@ProxyPass,@ProxyUrl,@ProxyPort,@MalHizmetSecenegi,@ArchiveAdress,@IRSALIYE,@OzelTasarim,@LastDownInvDate,@OKUNMUSLARIAL,@MARK,@DwnLimit,@DbVersion,@ArayuzYok,@TTNET,@FATURAGIRIS,@RAPOR,@SOLMENU,@SonGetInv 
                //    SRVAdress,SRVTestAdress,GIBKdvCode,FIRMA_TABLE,ITEM_TABLE,ERP_USERS_TABLE,INVOICE_TABLE,LINE_TABLE,GIBKdvName,CARI_TABLE,DEFAMBAR,Satis,Iade,ERP_DB,vSIP_TABLE,PROGRAMTIP,ERP_USERS_SQL,FIRMA_TABLE_SQL,ITEM_TABLE_SQL,INVOICE_TABLE_SQL,LINE_TABLE_SQL,PAY_SQL,CARI_KART_SQL,vCURRSQL,vSIP_SQL,ReRun,HOST,USER,PWD,GIBVergiKod1,GIBVergiAd1,EPostaAdres,EPostaPwd,LastGibUser,GibUserCheckTime,AkisVknBirimId,AkisGenelId,AkisZorunluBirimId,EPOSTHOST,EPOSTPORT,PREF,FSIRANO,IsProxy,ProxyDomain,ProxyUser,ProxyPass,ProxyUrl,ProxyPort,MalHizmetSecenegi,ArchiveAdress,IRSALIYE,OzelTasarim,LastDownInvDate,OKUNMUSLARIAL,MARK,DwnLimit,DbVersion,ArayuzYok,TTNET,FATURAGIRIS,RAPOR,SOLMENU,SonGetInv

                using (SqlCommand cmd = new SqlCommand(myInsertQuery))
                {
                    cmd.Parameters.AddWithValue("@ENTUSERNAME", TXT_ENTUSERNAME.Text);
                    cmd.Parameters.AddWithValue("@ENTPASS", TXT_ENTUSERNAME.Text);
                    cmd.Parameters.AddWithValue("@ENTREASON", TXT_ENTREASON.Text);
                    cmd.Parameters.AddWithValue("@ENTCHANNEL_NAME", TXT_ENTCHANNEL_NAME.Text);
                    cmd.Parameters.AddWithValue("@FIRMAID", TXT_FIRMAID.Text);
                    cmd.Parameters.AddWithValue("@VKN", TXT_VKN.Text);
                    cmd.Parameters.AddWithValue("@TaxScheme", TXT_TaxScheme.Text);
                    cmd.Parameters.AddWithValue("@PartyName", TXT_PartyName.Text);
                    cmd.Parameters.AddWithValue("@ROOM", TXT_ROOM.Text);
                    cmd.Parameters.AddWithValue("@StreetName", TXT_StreetName.Text);
                    cmd.Parameters.AddWithValue("@BuildingName", TXT_BuildingName.Text);
                    cmd.Parameters.AddWithValue("@BuildingNumber", TXT_BuildingNumber.Text);
                    cmd.Parameters.AddWithValue("@CitySubdivisionName", TXT_CitySubdivisionName.Text);
                    cmd.Parameters.AddWithValue("@CityName", TXT_CityName.Text);
                    cmd.Parameters.AddWithValue("@Country", TXT_Country.Text);
                    cmd.Parameters.AddWithValue("@Telephone", TXT_Telephone.Text);
                    cmd.Parameters.AddWithValue("@WebsiteURI", TXT_WebsiteURI.Text);
                    cmd.Parameters.AddWithValue("@ElectronicMail", TXT_ElectronicMail.Text);
                    cmd.Parameters.AddWithValue("@TCN", TXT_TCN.Text);
                    cmd.Parameters.AddWithValue("@SCN", TXT_SCN.Text);
                    cmd.Parameters.AddWithValue("@EkNot", TXT_EkNot.Text);
                    cmd.Parameters.AddWithValue("@EkNotTabloAdi", TXT_EkNotTabloAdi.Text);
                    cmd.Parameters.AddWithValue("@EkNotAlanAdi", TXT_EkNotAlanAdi.Text);
                    cmd.Parameters.AddWithValue("@GIBKdvCode", txtKdvKod.Text);
                    cmd.Parameters.AddWithValue("@GIBKdvName", txtKdvAd.Text);
                    cmd.Parameters.AddWithValue("@GIBVergiKod1", txtVergiKod1.Text);
                    cmd.Parameters.AddWithValue("@GIBVergiAd1", txtVergiAd1.Text);
                    cmd.Parameters.AddWithValue("@PREF", txtPref.Text);
                    cmd.Parameters.AddWithValue("@FSIRANO", txtSiraNo.Text);
                    cmd.Parameters.AddWithValue("@SRVAdress", cmbArcAdres.Text);
                    cmd.Parameters.AddWithValue("@SRVTestAdress", txtEntSrvAdress.Text);
                    cmd.Parameters.AddWithValue("@EPostaAdres", txtePostaHostAdres.Text);
                    cmd.Parameters.AddWithValue("@EPOSTHOST", txtePostaGonderenAdres.Text);
                    cmd.Parameters.AddWithValue("@EPOSTPORT", txtEpostaPort.Text);
                    cmd.Parameters.AddWithValue("@EPostaPwd", txtePostaSifre.Text);
                    cmd.Parameters.AddWithValue("@IsProxy", CHK_PROXY_KULLAN.Text);
                    cmd.Parameters.AddWithValue("@ProxyDomain", txtProxyDomain.Text);
                    cmd.Parameters.AddWithValue("@ProxyUser", txtProxyKullanici.Text);
                    cmd.Parameters.AddWithValue("@ProxyPass", txtProxySifre.Text);
                    cmd.Parameters.AddWithValue("@ProxyUrl", txtProxyUrl.Text);
                    cmd.Parameters.AddWithValue("@ProxyPort", txtProxyPort.Text);
                    cmd.Parameters.AddWithValue("@OzelTasarim", chcOzelTasarim.Checked);
                    cmd.Parameters.AddWithValue("@ArayuzYok", chckArayuzOlma.Checked);
                    cmd.Parameters.AddWithValue("@DOSYA_ADRESI", TXT_DOSYA_ADRESI.Text);

                    cmd.Connection = sqlconnection;
                    SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (myReader.Read())
                    {
                        lbID.Caption = myReader["ID"].ToString();
                    }
                }
            }


        }

        private void GUNCELLE()
        {
            using (SqlConnection sqlconnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                sqlconnection.Open();
                using (SqlCommand cmd = new SqlCommand
                {
                    CommandText = String.Format(@" UPDATE dbo.ADM_LGN_CAPIFIRM SET ENTUSERNAME=@ENTUSERNAME,ENTPASS=@ENTPASS,ENTREASON=@ENTREASON,ENTCHANNEL_NAME=@ENTCHANNEL_NAME,WebsiteURI=@WebsiteURI,VKN=@VKN,PartyName=@PartyName,Room=@Room,StreetName=@StreetName,BuildingName=@BuildingName,BuildingNumber=@BuildingNumber,CitySubdivisionName=@CitySubdivisionName,
                                                        CityName=@CityName,TaxScheme=@TaxScheme,Country=@Country,Telephone=@Telephone,ElectronicMail=@ElectronicMail,ACTIVE=@ACTIVE,FIRMAID=@FIRMAID,TCN=@TCN,SCN=@SCN,EkNot=@EkNot,EkNotTabloAdi=@EkNotTabloAdi,EkNotAlanAdi=@EkNotAlanAdi,EPOSTHOST=@EPOSTHOST,EPOSTPORT=@EPOSTPORT,
                                                        PREF=@PREF,FSIRANO=@FSIRANO,MalHizmetSecenegi=@MalHizmetSecenegi,IRSALIYE=@IRSALIYE,OzelTasarim=@OzelTasarim,DEFAMBAR=@DEFAMBAR,Satis=@Satis,Iade=@Iade,GIBVergiKod1=@GIBVergiKod1,GIBVergiAd1=@GIBVergiAd1,EPostaAdres=@EPostaAdres,EPostaPwd=@EPostaPwd,GIBKdvCode=@GIBKdvCode,GIBKdvName=@GIBKdvName,
                                                        SRVAdress=@SRVAdress,SRVTestAdress=@SRVTestAdress,IsProxy=@IsProxy,ProxyDomain=@ProxyDomain,ProxyUser=@ProxyUser,ProxyPass=@ProxyPass,ProxyUrl=@ProxyUrl,ProxyPort=@ProxyPort,ArayuzYok=@ArayuzYok,DOSYA_ADRESI=@DOSYA_ADRESI
                                                    WHERE (ID = '{0}')", lbID.Caption)
                })
                {
                    cmd.Parameters.AddWithValue("@ENTUSERNAME", TXT_ENTUSERNAME.Text);
                    cmd.Parameters.AddWithValue("@ENTPASS", TXT_ENTUSERNAME.Text);
                    cmd.Parameters.AddWithValue("@ENTREASON", TXT_ENTREASON.Text);
                    cmd.Parameters.AddWithValue("@ENTCHANNEL_NAME", TXT_ENTCHANNEL_NAME.Text);
                    cmd.Parameters.AddWithValue("@FIRMAID", TXT_FIRMAID.Text);
                    cmd.Parameters.AddWithValue("@VKN", TXT_VKN.Text);
                    cmd.Parameters.AddWithValue("@TaxScheme", TXT_TaxScheme.Text);
                    cmd.Parameters.AddWithValue("@PartyName", TXT_PartyName.Text);
                    cmd.Parameters.AddWithValue("@ROOM", TXT_ROOM.Text);
                    cmd.Parameters.AddWithValue("@StreetName", TXT_StreetName.Text);
                    cmd.Parameters.AddWithValue("@BuildingName", TXT_BuildingName.Text);
                    cmd.Parameters.AddWithValue("@BuildingNumber", TXT_BuildingNumber.Text);
                    cmd.Parameters.AddWithValue("@CitySubdivisionName", TXT_CitySubdivisionName.Text);
                    cmd.Parameters.AddWithValue("@CityName", TXT_CityName.Text);
                    cmd.Parameters.AddWithValue("@Country", TXT_Country.Text);
                    cmd.Parameters.AddWithValue("@Telephone", TXT_Telephone.Text);
                    cmd.Parameters.AddWithValue("@WebsiteURI", TXT_WebsiteURI.Text);
                    cmd.Parameters.AddWithValue("@ElectronicMail", TXT_ElectronicMail.Text);
                    cmd.Parameters.AddWithValue("@TCN", TXT_TCN.Text);
                    cmd.Parameters.AddWithValue("@SCN", TXT_SCN.Text);
                    cmd.Parameters.AddWithValue("@EkNot", TXT_EkNot.Text);
                    cmd.Parameters.AddWithValue("@EkNotTabloAdi", TXT_EkNotTabloAdi.Text);
                    cmd.Parameters.AddWithValue("@EkNotAlanAdi", TXT_EkNotAlanAdi.Text);
                    cmd.Parameters.AddWithValue("@GIBKdvCode", txtKdvKod.Text);
                    cmd.Parameters.AddWithValue("@GIBKdvName", txtKdvAd.Text);
                    cmd.Parameters.AddWithValue("@GIBVergiKod1", txtVergiKod1.Text);
                    cmd.Parameters.AddWithValue("@GIBVergiAd1", txtVergiAd1.Text);
                    cmd.Parameters.AddWithValue("@PREF", txtPref.Text);
                    cmd.Parameters.AddWithValue("@FSIRANO", txtSiraNo.Text);
                    cmd.Parameters.AddWithValue("@SRVAdress", cmbArcAdres.Text);
                    cmd.Parameters.AddWithValue("@SRVTestAdress", txtEntSrvAdress.Text);
                    cmd.Parameters.AddWithValue("@EPostaAdres", txtePostaHostAdres.Text);
                    cmd.Parameters.AddWithValue("@EPOSTHOST", txtePostaGonderenAdres.Text);
                    cmd.Parameters.AddWithValue("@EPOSTPORT", txtEpostaPort.Text);
                    cmd.Parameters.AddWithValue("@EPostaPwd", txtePostaSifre.Text);
                    cmd.Parameters.AddWithValue("@IsProxy", CHK_PROXY_KULLAN.Text);
                    cmd.Parameters.AddWithValue("@ProxyDomain", txtProxyDomain.Text);
                    cmd.Parameters.AddWithValue("@ProxyUser", txtProxyKullanici.Text);
                    cmd.Parameters.AddWithValue("@ProxyPass", txtProxySifre.Text);
                    cmd.Parameters.AddWithValue("@ProxyUrl", txtProxyUrl.Text);
                    cmd.Parameters.AddWithValue("@ProxyPort", txtProxyPort.Text);
                    cmd.Parameters.AddWithValue("@OzelTasarim", chcOzelTasarim.Checked);
                    cmd.Parameters.AddWithValue("@ArayuzYok", chckArayuzOlma.Checked);
                    cmd.Parameters.AddWithValue("@DOSYA_ADRESI", TXT_DOSYA_ADRESI.Text);
                    cmd.Connection = sqlconnection;
                    cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    cmd.Connection.Close();


                    //                        SRVAdress=@SRVAdress,SRVTestAdress=@SRVTestAdress,GIBKdvCode=@GIBKdvCode,FIRMA_TABLE=@FIRMA_TABLE,ITEM_TABLE=@ITEM_TABLE,ERP_USERS_TABLE=@ERP_USERS_TABLE,
                    //INVOICE_TABLE=@INVOICE_TABLE,LINE_TABLE=@LINE_TABLE,GIBKdvName=@GIBKdvName,CARI_TABLE=@CARI_TABLE,DEFAMBAR=@DEFAMBAR,Satis=@Satis,Iade=@Iade,
                    //ERP_DB=@ERP_DB,vSIP_TABLE=@vSIP_TABLE,PROGRAMTIP=@PROGRAMTIP,ERP_USERS_SQL=@ERP_USERS_SQL,FIRMA_TABLE_SQL=@FIRMA_TABLE_SQL,ITEM_TABLE_SQL=@ITEM_TABLE_SQL,
                    //INVOICE_TABLE_SQL=@INVOICE_TABLE_SQL,LINE_TABLE_SQL=@LINE_TABLE_SQL,PAY_SQL=@PAY_SQL,CARI_KART_SQL=@CARI_KART_SQL,vCURRSQL=@vCURRSQL,vSIP_SQL=@vSIP_SQL,
                    //ReRun= @ReRun,HOST=@HOST,USER=@USER,PWD=@PWD,GIBVergiKod1=@GIBVergiKod1,GIBVergiAd1=@GIBVergiAd1,EPostaAdres=@EPostaAdres,EPostaPwd=@EPostaPwd,
                    //LastGibUser=@LastGibUser,GibUserCheckTime=@GibUserCheckTime,AkisVknBirimId=@AkisVknBirimId,AkisGenelId=@AkisGenelId,AkisZorunluBirimId=@AkisZorunluBirimId,EPOSTHOST=@EPOSTHOST,EPOSTPORT=@EPOSTPORT,PREF=@PREF,FSIRANO=@FSIRANO,IsProxy=@IsProxy,ProxyDomain=@ProxyDomain,
                    //ProxyUser=@ProxyUser,ProxyPass=@ProxyPass,ProxyUrl=@ProxyUrl,ProxyPort=@ProxyPort,MalHizmetSecenegi=@MalHizmetSecenegi,ArchiveAdress=@ArchiveAdress,IRSALIYE=@IRSALIYE,OzelTasarim=@OzelTasarim,LastDownInvDate=@LastDownInvDate,OKUNMUSLARIAL=@OKUNMUSLARIAL,MARK=@MARK,DwnLimit=@DwnLimit,
                    //DbVersion=@DbVersion,ArayuzYok=@ArayuzYok,TTNET=@TTNET,FATURAGIRIS=@FATURAGIRIS,RAPOR=@RAPOR,SOLMENU=@SOLMENU,SonGetInv=@SonGetInv




                }
            }

        }

        private void BTN_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void BTN_LISTE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SIRKET_LISTESI frm = new SIRKET_LISTESI();
            frm.TopMost = true;
            frm.ShowDialog();
            DATA_LOAD(frm.SELECT_ID.ToString());
        }
    }
}