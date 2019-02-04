using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using UnityObjects;

namespace VISION.FINANS.ERP.ADMIN
{
    public partial class CL_CARD_UPDATE_ALL : DevExpress.XtraEditors.XtraForm
    {
        int _ID = 0;


        string TXT_PAZARLAMA_SIRKETI_ADI_OLD = "";
        string TXT_ADRES_OLD = "";
        string TXT_TELNO_OLD = "";
        string TXT_FAX_OLD = "";
        string TXT_VERGIDAIRESI_OLD = "";
        string TXT_VERGINO_OLD = "";
        string TXT_TCKNO_OLD = "";
        string TXT_ACIKLAMA_OLD = "";
        string TXT_SEMT_OLD = "";
        string CMB_ULKE_OLD = "";
        string TXT_ULKE_CODE_OLD = "";
        string CMB_ILLER_OLD = "";
        string TXT_IL_CODE_OLD = "";
        string CMB_ILCE_OLD = "";
        string TXT_ILCE_CODE_OLD = "";
        string txtBxPk_OLD = ""; 
        string TXT_HESAP_NO_OLD = "";
        string BANKA_ADI1_OLD = "";
        string TXT_IBAN_OLD = "";
        string TXT_EMAIL_OLD = "";
        string TXT_CARI_HESAP_KODU_OLD = "";
        string TXT_MUHASEBE_HESAP_KODU_OLD = "";
        string TXT_LOGO_DURUMU_OLD = "";


        public CL_CARD_UPDATE_ALL(int ID)
        {
            InitializeComponent(); 
            _ID = ID; 
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            RD_PRM_ID.Visible = false;
            ValidateFields();
            using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                myConnections.Open();
                SqlCommand myCommands = new SqlCommand();
                myCommands.Connection = myConnections;
                myCommands.CommandText = "SELECT ID, Cast('('+ cast(SIRKET_NO as nvarchar)+')'+ LOGIN_NAME   as nvarchar) as FIRMALAR from dbo.ADM_SIRKET_DONEMLERI";
                SqlDataReader sqlreaders = myCommands.ExecuteReader(CommandBehavior.CloseConnection);
                while (sqlreaders.Read())
                {
                    CMB_FIRMALAR.Properties.Items.Add(sqlreaders["FIRMALAR"].ToString());
                }
                sqlreaders.Close();
                myCommands.Connection.Close();

            } 
            CMB_ULKE.Properties.Items.Add("");
            using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                SqlCommand myCommand = new SqlCommand(" SELECT  * from dbo.L_COUNTRY ", con); con.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    CMB_ULKE.Properties.Items.Add(myReader["NAME"].ToString());                    
                }
            } 
            if (_ID!=0) _DATA_LOAD(_ID); 
            ValidateFields();
        }

        private void ValidateFields()
        {
            if (RD_PRG_VISION.Checked) Validate_EmptyStringZero(CMB_FIRMALAR); else Validate_EmptyStringRule(CMB_FIRMALAR);   
            Validate_EmptyStringRule(TXT_CARI_HESAP_KODU); 
            if (RD_PRM_TCK_NO.Checked) Validate_EmptyStringRule(TXT_TCKNO); else Validate_EmptyStringZero(TXT_TCKNO); 
            if (RD_PRM_TAX_NO.Checked) Validate_EmptyStringRule(TXT_VERGINO); else Validate_EmptyStringZero(TXT_VERGINO);
            if (RD_PRM_CARI_KOD.Checked) Validate_EmptyStringRule(TXT_CARI_HESAP_KODU); else Validate_EmptyStringZero(TXT_CARI_HESAP_KODU); 
            if (RD_TUZEL.Checked && RD_YERLI.Checked) Validate_EmptyStringRule(TXT_VERGINO);else Validate_EmptyStringZero(TXT_VERGINO); 
            if (RD_SAHIS.Checked && RD_YERLI.Checked) Validate_EmptyStringRule(TXT_TCKNO);  else Validate_EmptyStringZero(TXT_TCKNO); 
        }
        private void Validate_EmptyStringRule(BaseEdit control)
        { 
            if (control.Text == null || control.Text.Trim().Length == 0 || control.Text.Trim() == "___.__.___.____") dxErrorProviderS.SetError(control, "Bu alan boş BırakİLamaz.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            else dxErrorProviderS.SetError(control, "");
        } 
        private void Validate_EmptyStringZero(BaseEdit control)
        {
              dxErrorProviderS.SetError(control, "");
        }
        private void _DATA_LOAD(int ID)
        {

            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string mySelectQuery = "  SELECT  * from  dbo.ADM_PAZARLAMA_SIRKETI WHERE  ID=" + ID;
                SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);

                myCommand.CommandText = mySelectQuery.ToString();
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                myConnections.Open();
                while (myReader.Read())
                {
                    TXT_LOGO_GELDI.Text = "TALEPDEN_GELDI";

                    lbID.Caption = myReader["ID"].ToString(); 
                    //   CHK_E_FATURA  
                    if (myReader["SAHIS_SIRKETI"].ToString() == "TUZEL") RD_TUZEL.Checked = true;
                    if (myReader["SAHIS_SIRKETI"].ToString() == "SAHIS") RD_SAHIS.Checked = true; 
                    if (myReader["YABANCI_UYRUKLU"].ToString() == "YERLI") RD_YERLI.Checked = true;
                    if (myReader["YABANCI_UYRUKLU"].ToString() == "YABANCI") RD_YABANCI.Checked = true;
                    //RD_SAHIS.Text = myReader["ISPERSCOMP"].ToString();
                    //RD_YABANCI.Text = myReader["ISFOREIGN"].ToString();

                    //TXT_CARI_HESAP_KODU.Text = myReader["CODE"].ToString();




                    TXT_PAZARLAMA_SIRKETI_ADI_OLD = myReader["UNVANI"].ToString();
                    TXT_ADRES_OLD = myReader["ADRESI"].ToString();
                    TXT_TELNO_OLD = myReader["TELEFON"].ToString();
                    TXT_FAX_OLD = myReader["FAX"].ToString();
                    TXT_VERGIDAIRESI_OLD = myReader["VERGI_DAIRESI"].ToString();
                    TXT_VERGINO_OLD = myReader["VERGI_NO"].ToString();
                    TXT_TCKNO_OLD = myReader["TC_KIMLIK_NO"].ToString();
                    TXT_ACIKLAMA_OLD = myReader["ACIKLAMA"].ToString();
                    TXT_SEMT_OLD = myReader["SEMT"].ToString();
                    CMB_ULKE_OLD = myReader["ULKE"].ToString();
                    TXT_ULKE_CODE_OLD = myReader["ULKE_CODE"].ToString();
                    CMB_ILLER_OLD = myReader["IL"].ToString();
                    TXT_IL_CODE_OLD = myReader["IL_CODE"].ToString();
                    CMB_ILCE_OLD = myReader["ILCE"].ToString();
                    TXT_ILCE_CODE_OLD = myReader["ILCE_CODE"].ToString();
                    txtBxPk_OLD = myReader["POSTA_KODU"].ToString(); 
                    TXT_HESAP_NO_OLD = myReader["HESAP_NO"].ToString();
                    BANKA_ADI1_OLD = myReader["BANKA_ADI1"].ToString();
                    TXT_IBAN_OLD = myReader["IBAN"].ToString();
                    TXT_EMAIL_OLD = myReader["EMAIL"].ToString();
                    TXT_CARI_HESAP_KODU_OLD = myReader["CARI_HESAP_KODU"].ToString();
                    TXT_MUHASEBE_HESAP_KODU_OLD = myReader["MUHASEBE_HESAP_KODU"].ToString(); 




                    TXT_PAZARLAMA_SIRKETI_ADI.Text = myReader["UNVANI"].ToString();
                    TXT_ADRES.Text = myReader["ADRESI"].ToString();
                    TXT_TELNO.Text = myReader["TELEFON"].ToString();
                    TXT_FAX.Text = myReader["FAX"].ToString();
                    TXT_VERGIDAIRESI.Text = myReader["VERGI_DAIRESI"].ToString();
                    TXT_VERGINO.Text = myReader["VERGI_NO"].ToString();
                    TXT_TCKNO.Text = myReader["TC_KIMLIK_NO"].ToString();
                    TXT_ACIKLAMA.Text = myReader["ACIKLAMA"].ToString();
                    TXT_SEMT.Text = myReader["SEMT"].ToString();
                    CMB_ULKE.Text = myReader["ULKE"].ToString();
                    TXT_ULKE_CODE.Text = myReader["ULKE_CODE"].ToString();
                    CMB_ILLER.Text = myReader["IL"].ToString();
                    TXT_IL_CODE.Text = myReader["IL_CODE"].ToString();
                    CMB_ILCE.Text = myReader["ILCE"].ToString();
                    TXT_ILCE_CODE.Text = myReader["ILCE_CODE"].ToString();
                    txtBxPk.Text = myReader["POSTA_KODU"].ToString(); 
                    TXT_HESAP_NO.Text = myReader["HESAP_NO"].ToString();
                    BANKA_ADI1.Text = myReader["BANKA_ADI1"].ToString();
                    TXT_IBAN.Text = myReader["IBAN"].ToString();
                    TXT_EMAIL.Text = myReader["EMAIL"].ToString();
                    TXT_CARI_HESAP_KODU.Text = myReader["CARI_HESAP_KODU"].ToString();
                    TXT_MUHASEBE_HESAP_KODU.Text = myReader["MUHASEBE_HESAP_KODU"].ToString();
                    TXT_LOGO_DURUMU.Text = myReader["LOGO_DURUMU"].ToString();

                  //  LOGO_DURUMU = 'AÇILDI'


                  //  if (myReader["EFATURA"].ToString() == "E") CHK_E_FATURA.Checked = true; else CHK_E_FATURA.Checked = false;

                    //BR_GUID.Caption = myReader["GUID"].ToString();
                    //CMB_SIRKET_KODU.Text = myReader["SIRKET_KODU"].ToString();
                    //CMB_SIRKET_KODU.Text = myReader["SIRKET_KODU"].ToString();
                    //TXT_FATURANO.Text = myReader["ID"].ToString();
                    //TXT_NOTU.Text = myReader["Note"].ToString();
                    //DATE_FATURA_TARIHI.Text = myReader["IssueDate"].ToString();
                    //DATE_GELISTARIHI.Text = myReader["UBLExtensionObjectSigningTime"].ToString();
                    ////IssueDate", dt.ToString("yyyy.MM.dd").ToString());
                    ////UBLExtensionObjectSigningTime", dtGelis.ToString("yyyy.MM.dd").ToString());
                    //// AdditionalDocumentIssueDate", dt.ToString("yyyy.MM.dd").ToString());
                    //COM_BX_PB.Text = myReader["DocumentCurrencyCode"].ToString();
                    //// CMB_MECRA_KODU.Text = myReader["MECRA_ADI"].ToString();

                }

            }
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            DialogResult c = MessageBox.Show("Güncellemek istediğinizden eminmisiniz.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (c == DialogResult.Yes)
            {
                string[] Ones = CMB_FIRMALAR.Text.ToString().Split(',');
                for (int X = 0; X <= Ones.Length - 1; X++)
                {
                    char[] karakterler = Ones[X].Trim().ToString().ToCharArray();
                    string SELECT_FIRMA_KODU = "";
                    for (int i = 1; i <= karakterler.Length - 1; i++)
                    {
                        if (karakterler[i].ToString() != ")")
                        { SELECT_FIRMA_KODU += karakterler[i].ToString(); }
                        else
                        { break; }
                    } 
                    using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP))
                    {
                        myConnections.Open();
                        SqlCommand myCmd = new SqlCommand();
                        myCmd.CommandText = "  UPDATE  dbo.LG_" + SELECT_FIRMA_KODU + "_CLCARD   SET   " + CMB_FIELD.Text + "=@BILGI   WHERE (CODE=@CODE) ;"; 

                        if (CMB_FIELD.Text == "DEFINITION_") myCmd.CommandText += "  UPDATE  dbo.LG_" + SELECT_FIRMA_KODU + "_EMUHACC     SET   " + CMB_FIELD.Text + "=@BILGI   WHERE (CODE=@CODE) ";
                        myCmd.Parameters.AddWithValue("@CODE", TXT_CODE.Text);
                        myCmd.Parameters.AddWithValue("@BILGI", TXT_BILGI.Text);
                        myCmd.Connection = myConnections;
                        myCmd.ExecuteNonQuery();
                        myCmd.Connection.Close();
                        myConnections.Close();
                    }
                }
            }
            Close();
        }

        private void BTN_VAZGEC_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CMB_FIELD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMB_FIELD.Text == "DEFINITION_") LB_ACIKLAMA.Text = "FİRMA AÇIKLAMASI";
            if (CMB_FIELD.Text == "CODE") LB_ACIKLAMA.Text = "FİRMA KODU";
            if (CMB_FIELD.Text == "ADDR1") LB_ACIKLAMA.Text = "ADRESS 1";
            if (CMB_FIELD.Text == "ADDR2") LB_ACIKLAMA.Text = "ADRESS 2";
            if (CMB_FIELD.Text == "CITY") LB_ACIKLAMA.Text = "Şehir";
            if (CMB_FIELD.Text == "COUNTRY") LB_ACIKLAMA.Text = "İlçe";
            if (CMB_FIELD.Text == "TELNRS1") LB_ACIKLAMA.Text = "TELEFON";
            if (CMB_FIELD.Text == "TELNRS2") LB_ACIKLAMA.Text = "TELEFON";
            if (CMB_FIELD.Text == "TAXNR") LB_ACIKLAMA.Text = "Verigi No";
            if (CMB_FIELD.Text == "TAXOFFICE") LB_ACIKLAMA.Text = "vergi Dairesi";
            if (CMB_FIELD.Text == "EMAILADDR") LB_ACIKLAMA.Text = "E-MAİL";
        }

        private void BR_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (TXT_LOGO_GELDI.Text == "LOGODAN_GELDI")
            {
                string YABANCI_UYRUKLU = "YERLI";
                string SAHIS_SIRKETI = "TUZEL";
                if (RD_TUZEL.Checked) SAHIS_SIRKETI = "TUZEL";
                if (RD_SAHIS.Checked) SAHIS_SIRKETI = "SAHIS";
                if (RD_YERLI.Checked) YABANCI_UYRUKLU = "YERLI";
                if (RD_YABANCI.Checked) YABANCI_UYRUKLU = "YABANCI";

                DateTime myDT = Convert.ToDateTime(string.Format("{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()));
                using (SqlConnection myCon = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                {
                    myCon.Open();

                    string myInsertQuery = @" INSERT INTO  dbo.ADM_PAZARLAMA_SIRKETI (ISTEKTE_BULUNAN_MAIL_ADRESI,TALEBIN_TURU,UNVANI, ADRESI, TELEFON, FAX, VERGI_DAIRESI, VERGI_NO,TC_KIMLIK_NO,  ACIKLAMA, YABANCI_UYRUKLU,SAHIS_SIRKETI,SEMT, ILCE_CODE, ILCE,IL_CODE,IL,ULKE_CODE,ULKE,HESAP_NO,BANKA_ADI1,IBAN, EMAIL, CARI_HESAP_KODU,MUHASEBE_HESAP_KODU,LOGO_DURUMU )
                                                                               VALUES(@ISTEKTE_BULUNAN_MAIL_ADRESI,@TALEBIN_TURU,@UNVANI, @ADRESI, @TELEFON, @FAX, @VERGI_DAIRESI, @VERGI_NO,@TC_KIMLIK_NO,  @ACIKLAMA, @YABANCI_UYRUKLU,@SAHIS_SIRKETI,@SEMT, @ILCE_CODE, @ILCE,@IL_CODE,@IL,@ULKE_CODE,@ULKE,@HESAP_NO,@BANKA_ADI1,@IBAN, @EMAIL, @CARI_HESAP_KODU,@MUHASEBE_HESAP_KODU,@LOGO_DURUMU   )";

                    SqlCommand cmd = new SqlCommand(myInsertQuery);
                    cmd.Parameters.AddWithValue("@ID", lbID.Caption);

                    cmd.Parameters.AddWithValue("@ISTEKTE_BULUNAN_MAIL_ADRESI", _GLOBAL_PARAMETERS._KULLANICI_MAIL);
                    cmd.Parameters.AddWithValue("@TALEBIN_TURU", "PAZARLAMAŞTİ");

                    cmd.Parameters.AddWithValue("@UNVANI", TXT_PAZARLAMA_SIRKETI_ADI.Text);
                    cmd.Parameters.AddWithValue("@ADRESI", TXT_ADRES.Text);
                    cmd.Parameters.AddWithValue("@TELEFON", TXT_TELNO.Text);
                    cmd.Parameters.AddWithValue("@FAX", TXT_FAX.Text);
                    cmd.Parameters.AddWithValue("@VERGI_DAIRESI", TXT_VERGIDAIRESI.Text);
                    cmd.Parameters.AddWithValue("@VERGI_NO", TXT_VERGINO.Text);
                    cmd.Parameters.AddWithValue("@TC_KIMLIK_NO", TXT_TCKNO.Text);
                    cmd.Parameters.AddWithValue("@ACIKLAMA", TXT_ACIKLAMA.Text);
                    cmd.Parameters.AddWithValue("@YABANCI_UYRUKLU", YABANCI_UYRUKLU);
                    cmd.Parameters.AddWithValue("@SAHIS_SIRKETI", SAHIS_SIRKETI);
                    cmd.Parameters.AddWithValue("@SEMT", TXT_SEMT.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@ILCE_CODE", TXT_ILCE_CODE.Text.Trim());
                    cmd.Parameters.AddWithValue("@ILCE", CMB_ILCE.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@IL_CODE", TXT_IL_CODE.Text.Trim());
                    cmd.Parameters.AddWithValue("@IL", CMB_ILLER.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@ULKE_CODE", TXT_ULKE_CODE.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@ULKE", CMB_ULKE.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@HESAP_NO", TXT_HESAP_NO.Text);
                    cmd.Parameters.AddWithValue("@BANKA_ADI1", BANKA_ADI1.Text);
                    cmd.Parameters.AddWithValue("@IBAN", TXT_IBAN.Text);
                    cmd.Parameters.AddWithValue("@EMAIL", TXT_EMAIL.Text);
                    cmd.Parameters.AddWithValue("@CARI_HESAP_KODU", TXT_CARI_HESAP_KODU.Text);
                    cmd.Parameters.AddWithValue("@MUHASEBE_HESAP_KODU", TXT_MUHASEBE_HESAP_KODU.Text);
                    cmd.Parameters.AddWithValue("@EFATURA", TXT_MUHASEBE_HESAP_KODU.Text);
                    cmd.Parameters.AddWithValue("@LOGO_DURUMU", "AÇILDI");

                    //  if (CHK_E_FATURA.Checked) cmd.Parameters.AddWithValue("@EFATURA", "E"); else cmd.Parameters.AddWithValue("@EFATURA", "P");  
                    foreach (SqlParameter parameter in cmd.Parameters)
                    {
                        if (parameter.Value == null)
                        {
                            parameter.Value = DBNull.Value;
                        }
                    }

                    cmd.Connection = myCon;
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }







            if (TXT_LOGO_DURUMU.Text == "AÇILDI" && TXT_LOGO_GELDI.Text== "TALEPDEN_GELDI")
            {
                if (dxErrorProviderS.HasErrors != true)
                {
                    DialogResult c = MessageBox.Show("Güncellemek istediğinizden eminmisiniz.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (c == DialogResult.Yes)
                    {
                        if (RD_PRG_VISION_LOGO.Checked)
                        {
                            string[] Ones = CMB_FIRMALAR.Text.ToString().Split(',');

                            if (Ones[0] == "") { MessageBox.Show("Güncellemek istediğiniz Firmaları seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }

                            for (int X = 0; X <= Ones.Length - 1; X++)
                            {
                                char[] karakterler = Ones[X].Trim().ToString().ToCharArray();
                                string SELECT_FIRMA_KODU = "";
                                for (int i = 1; i <= karakterler.Length - 1; i++)
                                {
                                    if (karakterler[i].ToString() != ")")
                                    { SELECT_FIRMA_KODU += karakterler[i].ToString(); }
                                    else
                                    { break; }
                                }


                                using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP))
                                {
                                    myConnections.Open();
                                    SqlCommand myCmd = new SqlCommand();

                                    if (RD_PRM_CARI_KOD.Checked)
                                    {
                                        string DEGER = TXT_CARI_HESAP_KODU.Text.ToString().Replace("_", "").Replace(".", "");
                                        if (DEGER.ToString().Length > 0)
                                        {
                                            myCmd.CommandText = "  UPDATE  dbo.LG_" + SELECT_FIRMA_KODU + "_CLCARD   SET  ISPERSCOMP=@ISPERSCOMP,ISFOREIGN=@ISFOREIGN,DEFINITION_=@DEFINITION_,ADDR1=@ADDR1,TOWNCODE=@TOWNCODE,TOWN=@TOWN,CITYCODE=@CITYCODE,CITY=@CITY,COUNTRYCODE=@COUNTRYCODE   ,COUNTRY=@COUNTRY,POSTCODE=@POSTCODE,FAXCODE=@FAXCODE,FAXNR=@FAXNR, TELCODES1=@TELCODES1,TELNRS1=@TELNRS1,TAXNR=@TAXNR,TAXOFFICE=@TAXOFFICE,TCKNO=@TCKNO,EMAILADDR=@EMAILADDR, BANKNAMES1=@BANKNAMES1,BANKIBANS1=@BANKIBANS1 ,LTRSENDEMAILADDR=@LTRSENDEMAILADDR,EXTSENDEMAILADDR=@EXTSENDEMAILADDR WHERE(CODE=@CODE) ; UPDATE  dbo.LG_" + SELECT_FIRMA_KODU + "_EMUHACC     SET   DEFINITION_=@EDEFINITION_   WHERE (CODE=@CODE)";
                                        } //  
                                        else
                                        {
                                            MessageBox.Show("CARİ KODU BOŞ OLAMAZ");
                                            return;
                                        }
                                    } 
                                    if (RD_PRM_TAX_NO.Checked)
                                    {
                                        string DEGER = TXT_VERGINO.Text.ToString().Replace("_", "").Replace(".", "");
                                        if (DEGER.Length > 0)
                                        {
                                            myCmd.CommandText = "  UPDATE  dbo.LG_" + SELECT_FIRMA_KODU + "_CLCARD   SET  ISPERSCOMP=@ISPERSCOMP,ISFOREIGN=@ISFOREIGN,DEFINITION_=@DEFINITION_,ADDR1=@ADDR1,TOWNCODE=@TOWNCODE,TOWN=@TOWN,CITYCODE=@CITYCODE,CITY=@CITY,COUNTRYCODE=@COUNTRYCODE   ,COUNTRY=@COUNTRY,POSTCODE=@POSTCODE,FAXCODE=@FAXCODE,FAXNR=@FAXNR, TELCODES1=@TELCODES1,TELNRS1=@TELNRS1,TAXNR=@TAXNR,TAXOFFICE=@TAXOFFICE,TCKNO=@TCKNO,EMAILADDR=@EMAILADDR, BANKNAMES1=@BANKNAMES1,BANKIBANS1=@BANKIBANS1 ,LTRSENDEMAILADDR=@LTRSENDEMAILADDR,EXTSENDEMAILADDR=@EXTSENDEMAILADDR WHERE(TAXNR=@TAXNR); UPDATE dbo.LG_" + SELECT_FIRMA_KODU + "_EMUHACC SET   DEFINITION_ = @EDEFINITION_   WHERE(TAXNR = @TAXNR)  ";
                                        }
                                        else
                                        {
                                            MessageBox.Show("TAX NO BOŞ OLAMAZ");
                                            return;
                                        }
                                    } 
                                    if (RD_PRM_TCK_NO.Checked)
                                    {
                                        string DEGER = TXT_TCKNO.Text.ToString().Replace("_", "").Replace(".", "");
                                        if (DEGER.Length > 0)
                                        {
                                            myCmd.CommandText = "  UPDATE  dbo.LG_" + SELECT_FIRMA_KODU + "_CLCARD   SET  ISPERSCOMP=@ISPERSCOMP,ISFOREIGN=@ISFOREIGN,DEFINITION_=@DEFINITION_,ADDR1=@ADDR1,TOWNCODE=@TOWNCODE,TOWN=@TOWN,CITYCODE=@CITYCODE,CITY=@CITY,COUNTRYCODE=@COUNTRYCODE   ,COUNTRY=@COUNTRY,POSTCODE=@POSTCODE,FAXCODE=@FAXCODE,FAXNR=@FAXNR, TELCODES1=@TELCODES1,TELNRS1=@TELNRS1,TAXNR=@TAXNR,TAXOFFICE=@TAXOFFICE,TCKNO=@TCKNO,EMAILADDR=@EMAILADDR, BANKNAMES1=@BANKNAMES1,BANKIBANS1=@BANKIBANS1 ,LTRSENDEMAILADDR=@LTRSENDEMAILADDR,EXTSENDEMAILADDR=@EXTSENDEMAILADDR WHERE(TAXNR=@TCKNO); UPDATE dbo.LG_" + SELECT_FIRMA_KODU + "_EMUHACC SET   DEFINITION_ = @EDEFINITION_   WHERE(TAXNR = @TCKNO)  ";
                                        }
                                        else
                                        {
                                            MessageBox.Show("TCK NO BOŞ OLAMAZ");
                                            return;
                                        }
                                    } 

                                    if (RD_TUZEL.Checked) { myCmd.Parameters.AddWithValue("@ISPERSCOMP", 0); }
                                    if (RD_SAHIS.Checked) { myCmd.Parameters.AddWithValue("@ISPERSCOMP", 1); }  
                                    if (RD_YERLI.Checked) { myCmd.Parameters.AddWithValue("@ISFOREIGN", 0); }
                                    if (RD_YABANCI.Checked) { myCmd.Parameters.AddWithValue("@ISFOREIGN", 1); } 
                                    //if (RD_YABANCI.Text == "Yabancı") { myCmd.Parameters.AddWithValue("@ISFOREIGN", true); } 
                                    //if (RD_SAHIS.Text == "Şahıs") { myCmd.Parameters.AddWithValue("@ISPERSCOMP", true); myCmd.Parameters.AddWithValue("@ISFOREIGN", false); }  
                                    //if (RD_YABANCI.Text == "Yabancı") { myCmd.Parameters.AddWithValue("@ISFOREIGN", true); myCmd.Parameters.AddWithValue("@ISPERSCOMP", false); } 

                                    myCmd.Parameters.AddWithValue("@CODE", TXT_CARI_HESAP_KODU.Text.Trim());
                                    myCmd.Parameters.AddWithValue("@DEFINITION_", TXT_PAZARLAMA_SIRKETI_ADI.Text.Trim());

                                    if (TXT_PAZARLAMA_SIRKETI_ADI.Text.ToString().Length > 49)
                                    {
                                        myCmd.Parameters.AddWithValue("@EDEFINITION_", TXT_PAZARLAMA_SIRKETI_ADI.Text.ToString().Substring(0, 49));
                                    }
                                    else
                                    { myCmd.Parameters.AddWithValue("@EDEFINITION_", TXT_PAZARLAMA_SIRKETI_ADI.Text); } 
                                        myCmd.Parameters.AddWithValue("@ADDR1", TXT_ADRES.Text.Trim());
                                        myCmd.Parameters.AddWithValue("@TOWNCODE", TXT_ILCE_CODE.Text.Trim());
                                        myCmd.Parameters.AddWithValue("@TOWN", CMB_ILCE.Text.Trim());
                                        myCmd.Parameters.AddWithValue("@CITYCODE", TXT_IL_CODE.Text.Trim());
                                        myCmd.Parameters.AddWithValue("@CITY", CMB_ILLER.Text.Trim());
                                        myCmd.Parameters.AddWithValue("@COUNTRYCODE", TXT_ULKE_CODE.Text.Trim());
                                        myCmd.Parameters.AddWithValue("@COUNTRY", CMB_ULKE.Text.Trim());
                                        myCmd.Parameters.AddWithValue("@POSTCODE", txtBxPk.Text.Trim()); 
                                    if (TXT_FAX.EditValue.ToString().Length > 4) { myCmd.Parameters.AddWithValue("@FAXCODE", TXT_FAX.EditValue.ToString().Substring(0, 3)); }
                                    else
                                    { myCmd.Parameters.AddWithValue("@FAXCODE", ""); }

                                    myCmd.Parameters.AddWithValue("@FAXNR", TXT_FAX.EditValue.ToString().Replace("-", "").Replace("(", "").Replace(")", "")); 

                                    if (TXT_TELNO.EditValue.ToString().Length > 4) { myCmd.Parameters.AddWithValue("@TELCODES1", TXT_TELNO.EditValue.ToString().Substring(0, 3)); }
                                    else
                                    { myCmd.Parameters.AddWithValue("@TELCODES1", ""); }

                                        myCmd.Parameters.AddWithValue("@TELNRS1", TXT_TELNO.EditValue.ToString().Replace("-", "").Replace("(", "").Replace(")", ""));
                                        myCmd.Parameters.AddWithValue("@TAXNR", TXT_VERGINO.Text.Trim());
                                        myCmd.Parameters.AddWithValue("@TAXOFFICE", TXT_VERGIDAIRESI.Text.Trim());
                                        myCmd.Parameters.AddWithValue("@TCKNO", TXT_TCKNO.Text.Trim());
                                        myCmd.Parameters.AddWithValue("@CONTACT", TXT_EMAIL.Text.Trim());
                                        myCmd.Parameters.AddWithValue("@EMAILADDR", TXT_EMAIL.Text.Trim());
                                        myCmd.Parameters.AddWithValue("@BANKNAMES1", BANKA_ADI1.Text.Trim());
                                        myCmd.Parameters.AddWithValue("@BANKIBANS1", TXT_IBAN.Text);
                                        myCmd.Parameters.AddWithValue("@LTRSENDEMAILADDR", TXT_EMAIL.Text);
                                        myCmd.Parameters.AddWithValue("@EXTSENDEMAILADDR", TXT_EMAIL.Text);

                                    //if (CHK_E_FATURA.Checked) { myCmd.Parameters.AddWithValue("@ACCEPTEINV", 1); }
                                    //else { myCmd.Parameters.AddWithValue("@ACCEPTEINV", 0); } 
                                    //myCmd.Parameters.AddWithValue("@EXT_SEND_EMAIL", TXT_EMAIL.Text);
                                    //myCmd.Parameters.AddWithValue("@TELEPHONE_EXTENSION1", TXT_PAZARLAMA_SIRKETI_ADI.Text);
                                    //myCmd.Parameters.AddWithValue("@NOTES", TXT_PAZARLAMA_SIRKETI_ADI.Text); 
                                    myCmd.Connection = myConnections;
                                    myCmd.ExecuteNonQuery();
                                    myCmd.Connection.Close();
                                    myConnections.Close();
                                } 
                                CARI_CARD_READ(SELECT_FIRMA_KODU, TXT_VERGINO.Text.Trim()); 
                            }
                        }

                        if (RD_PRG_VISION.Checked || RD_PRG_VISION_LOGO.Checked)
                        { 
                            string YABANCI_UYRUKLU = "YERLI";
                            string SAHIS_SIRKETI = "TUZEL"; 
                            if (RD_TUZEL.Checked) SAHIS_SIRKETI = "TUZEL";
                            if (RD_SAHIS.Checked) SAHIS_SIRKETI = "SAHIS"; 
                            if (RD_YERLI.Checked) YABANCI_UYRUKLU = "YERLI";
                            if (RD_YABANCI.Checked) YABANCI_UYRUKLU = "YABANCI";

                            DateTime myDT = Convert.ToDateTime(string.Format("{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()));
                            using (SqlConnection myCon = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                            {
                                myCon.Open();

                                string myInsertQuery = @" Update  dbo.ADM_PAZARLAMA_SIRKETI set  UNVANI=@UNVANI, ADRESI=@ADRESI, TELEFON=@TELEFON, FAX=@FAX, VERGI_DAIRESI=@VERGI_DAIRESI, VERGI_NO=@VERGI_NO,TC_KIMLIK_NO=@TC_KIMLIK_NO,
                                      ACIKLAMA=@ACIKLAMA, YABANCI_UYRUKLU=@YABANCI_UYRUKLU,SAHIS_SIRKETI=@SAHIS_SIRKETI,SEMT=@SEMT, ILCE_CODE=@ILCE_CODE, ILCE=@ILCE,IL_CODE=@IL_CODE,IL=@IL,ULKE_CODE=@ULKE_CODE,ULKE=@ULKE,HESAP_NO=@HESAP_NO,BANKA_ADI1=@BANKA_ADI1,IBAN=@IBAN,
                                      EMAIL=@EMAIL, CARI_HESAP_KODU=@CARI_HESAP_KODU,MUHASEBE_HESAP_KODU=@MUHASEBE_HESAP_KODU 
                                      where ID=@ID  ";

                                SqlCommand cmd = new SqlCommand(myInsertQuery);
                                cmd.Parameters.AddWithValue("@ID", lbID.Caption);
                                cmd.Parameters.AddWithValue("@UNVANI", TXT_PAZARLAMA_SIRKETI_ADI.Text);
                                cmd.Parameters.AddWithValue("@ADRESI", TXT_ADRES.Text);
                                cmd.Parameters.AddWithValue("@TELEFON", TXT_TELNO.Text);
                                cmd.Parameters.AddWithValue("@FAX", TXT_FAX.Text);
                                cmd.Parameters.AddWithValue("@VERGI_DAIRESI", TXT_VERGIDAIRESI.Text);
                                cmd.Parameters.AddWithValue("@VERGI_NO", TXT_VERGINO.Text);
                                cmd.Parameters.AddWithValue("@TC_KIMLIK_NO", TXT_TCKNO.Text);
                                cmd.Parameters.AddWithValue("@ACIKLAMA", TXT_ACIKLAMA.Text);
                                cmd.Parameters.AddWithValue("@YABANCI_UYRUKLU", YABANCI_UYRUKLU);
                                cmd.Parameters.AddWithValue("@SAHIS_SIRKETI", SAHIS_SIRKETI);
                                cmd.Parameters.AddWithValue("@SEMT", TXT_SEMT.Text.ToUpper());
                                cmd.Parameters.AddWithValue("@ILCE_CODE", TXT_ILCE_CODE.Text.Trim());
                                cmd.Parameters.AddWithValue("@ILCE", CMB_ILCE.Text.ToUpper());
                                cmd.Parameters.AddWithValue("@IL_CODE", TXT_IL_CODE.Text.Trim());
                                cmd.Parameters.AddWithValue("@IL", CMB_ILLER.Text.ToUpper());
                                cmd.Parameters.AddWithValue("@ULKE_CODE", TXT_ULKE_CODE.Text.ToUpper());
                                cmd.Parameters.AddWithValue("@ULKE", CMB_ULKE.Text.ToUpper());
                                cmd.Parameters.AddWithValue("@HESAP_NO", TXT_HESAP_NO.Text);
                                cmd.Parameters.AddWithValue("@BANKA_ADI1", BANKA_ADI1.Text);
                                cmd.Parameters.AddWithValue("@IBAN", TXT_IBAN.Text);
                                cmd.Parameters.AddWithValue("@EMAIL", TXT_EMAIL.Text);
                                cmd.Parameters.AddWithValue("@CARI_HESAP_KODU", TXT_CARI_HESAP_KODU.Text);
                                cmd.Parameters.AddWithValue("@MUHASEBE_HESAP_KODU", TXT_MUHASEBE_HESAP_KODU.Text);
                                cmd.Parameters.AddWithValue("@EFATURA", TXT_MUHASEBE_HESAP_KODU.Text);
                                //  if (CHK_E_FATURA.Checked) cmd.Parameters.AddWithValue("@EFATURA", "E"); else cmd.Parameters.AddWithValue("@EFATURA", "P");  
                                foreach (SqlParameter parameter in cmd.Parameters)
                                {
                                    if (parameter.Value == null)
                                    {
                                        parameter.Value = DBNull.Value;
                                    }
                                }

                                cmd.Connection = myCon;
                                cmd.ExecuteNonQuery();
                                cmd.Connection.Close();
                            }
                        }

                        LOG_KAYDI(lbID.Caption);
                        Close();
                    }
                }
                else
                { MessageBox.Show("ilgili alanları doldurunuz.", "Uyarı"); }
            }
            else
            { 
                MessageBox.Show("Aktarım yapılmamış veri güncellenemez", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
       }

        private void LOG_KAYDI(string BILGI)
        {
            string UPDATE_VERI = "";   
           
          //  txtBxPk_OLD = myReader["POSTA_KODU"].ToString();  

            if (TXT_PAZARLAMA_SIRKETI_ADI_OLD.ToString() != TXT_PAZARLAMA_SIRKETI_ADI.Text.ToString())UPDATE_VERI += TXT_PAZARLAMA_SIRKETI_ADI_OLD.ToString () + " > " + TXT_PAZARLAMA_SIRKETI_ADI.Text.ToString(); 
            if (TXT_ADRES_OLD.ToString() != TXT_ADRES.Text.ToString())UPDATE_VERI += TXT_ADRES_OLD.ToString()  + " > " + TXT_ADRES.Text.ToString();
            if (TXT_TELNO_OLD.ToString() != TXT_TELNO.Text.ToString())UPDATE_VERI += TXT_TELNO_OLD.ToString() + " > " + TXT_TELNO.Text.ToString();
            if (TXT_FAX_OLD.ToString() != TXT_FAX.Text.ToString())UPDATE_VERI += TXT_FAX_OLD.ToString() + " > " + TXT_FAX.Text.ToString();
            if (TXT_VERGIDAIRESI_OLD.ToString() != TXT_VERGIDAIRESI.Text.ToString())UPDATE_VERI += TXT_VERGIDAIRESI_OLD.ToString() + " > " + TXT_VERGIDAIRESI.Text.ToString();
            if (TXT_VERGINO_OLD.ToString() != TXT_VERGINO.Text.ToString())UPDATE_VERI += TXT_VERGINO_OLD.ToString() + " > " + TXT_VERGINO.Text.ToString();
            if (TXT_TCKNO_OLD.ToString() != TXT_TCKNO.Text.ToString())UPDATE_VERI += TXT_TCKNO_OLD.ToString() + " > " + TXT_TCKNO.Text.ToString();
            if (TXT_ACIKLAMA_OLD.ToString() != TXT_ACIKLAMA.Text.ToString())UPDATE_VERI += TXT_ACIKLAMA_OLD.ToString() + " > " + TXT_ACIKLAMA.Text.ToString();

            if (TXT_TELNO.OldEditValue.ToString() != TXT_TELNO.Text.ToString())UPDATE_VERI += TXT_TELNO.OldEditValue.ToString() + " > " + TXT_TELNO.Text.ToString();
            if (TXT_SEMT_OLD.ToString() != TXT_SEMT.Text.ToString())UPDATE_VERI += TXT_SEMT_OLD.ToString() + " > " + TXT_SEMT.Text.ToString();


            if (TXT_ILCE_CODE_OLD.ToString() != TXT_ILCE_CODE.Text.ToString())UPDATE_VERI += TXT_ILCE_CODE_OLD.ToString() + " > " + TXT_ILCE_CODE.Text.ToString();
            if (CMB_ILCE_OLD.ToString() != CMB_ILCE.Text.ToString())UPDATE_VERI += CMB_ILCE_OLD.ToString() + " > " + CMB_ILCE.Text.ToString();

            if (TXT_IL_CODE_OLD.ToString() != TXT_IL_CODE.Text.ToString())UPDATE_VERI += TXT_IL_CODE_OLD.ToString() + " > " + TXT_IL_CODE.Text.ToString();
            if (CMB_ILLER_OLD.ToString() != CMB_ILLER.Text.ToString())UPDATE_VERI += CMB_ILLER_OLD.ToString() + " > " + CMB_ILLER.Text.ToString();

            if (TXT_ULKE_CODE_OLD.ToString() != TXT_ULKE_CODE.Text.ToString())UPDATE_VERI += TXT_ULKE_CODE_OLD.ToString() + " > " + TXT_ULKE_CODE.Text.ToString();
            if (CMB_ULKE_OLD.ToString() != CMB_ULKE.Text.ToString())UPDATE_VERI += CMB_ULKE_OLD.ToString() + " > " + CMB_ULKE.Text.ToString(); 

            if (TXT_HESAP_NO_OLD.ToString() != TXT_HESAP_NO.Text.ToString())UPDATE_VERI += TXT_HESAP_NO_OLD.ToString() + " > " + TXT_HESAP_NO.Text.ToString(); 
            if (BANKA_ADI1_OLD.ToString() != BANKA_ADI1.Text.ToString())UPDATE_VERI += BANKA_ADI1_OLD.ToString() + " > " + BANKA_ADI1.Text.ToString();
            if (TXT_IBAN_OLD.ToString() != TXT_IBAN.Text.ToString())UPDATE_VERI += TXT_IBAN_OLD.ToString() + " > " + TXT_IBAN.Text.ToString();
            if (TXT_EMAIL_OLD.ToString() != TXT_EMAIL.Text.ToString())UPDATE_VERI += TXT_EMAIL_OLD.ToString() + " > " + TXT_EMAIL.Text.ToString();
            if (TXT_CARI_HESAP_KODU_OLD.ToString() != TXT_CARI_HESAP_KODU.Text.ToString())UPDATE_VERI += TXT_CARI_HESAP_KODU_OLD.ToString() + " > " + TXT_CARI_HESAP_KODU.Text.ToString();
            if (TXT_MUHASEBE_HESAP_KODU_OLD.ToString() != TXT_MUHASEBE_HESAP_KODU.Text.ToString())UPDATE_VERI += TXT_MUHASEBE_HESAP_KODU_OLD.ToString() + " > " + TXT_MUHASEBE_HESAP_KODU.Text.ToString();
 


            //cmd.Parameters.AddWithValue("@YABANCI_UYRUKLU", YABANCI_UYRUKLU);
            //cmd.Parameters.AddWithValue("@SAHIS_SIRKETI", SAHIS_SIRKETI); 



            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Connection_VISION"].ToString()))
            {
                DateTime RUN_DATE = DateTime.Now;
                string SQL = " INSERT INTO [dbo].[XLG_HAREKET_KAYITLARI] (SIRKET_KODU,ISLEM_TARIHI,ISLEM_SAATI,YAPILAN_ISLEM,ISLEMI_YAPAN,YAPILAN_ISLEM_DETAYI) VALUES ('" + _GLOBAL_PARAMETERS._SIRKET_KODU + "','" + RUN_DATE.ToString("yyyy.MM.dd") + "','" + RUN_DATE.ToString("HH:mm:ss") + "','"+UPDATE_VERI+"','" + _GLOBAL_PARAMETERS._KULLANICI_MAIL + "','EK DOSYALARA GÖZ ATILDI. " + BILGI + "')";
                SqlCommand command = new SqlCommand(SQL, conn);
                conn.Open();
                command.CommandTimeout = 0;
                command.ExecuteReader(CommandBehavior.CloseConnection);
                conn.Close();
            }
        }


          public string CARI_CARD_READ(string NUMBER, string TAXNUMBER)
        {
            int LogicalRef = 0;
            string FATURA_KONTROL = string.Empty;
            //Yeni bir sql sorgusu çalıştırmak istediğimizi belirtiyoruz.                        
            Query Querys = _GLOBAL_PARAMETERS.Global.UnityApp.NewQuery();
 
            string Query_String = " SELEC * FROM   LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_CLCARD    WHERE TAXNR='" + TAXNUMBER + "'";
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
        private void CL_CARD_UPDATE_ALL_Load(object sender, EventArgs e)
        {

        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void CMB_ULKE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CMB_ULKE.Text.ToString())) return;
            CMB_ILLER.Properties.Items.Clear(); CMB_ILLER.Text = "";
            CMB_ILLER.Refresh();
            CMB_ILLER.Focus();
            CMB_ILLER.Properties.Items.Add("");

            //  SELECT dbo.L_COUNTRY.NAME , dbo.L_COUNTRY.CODE, dbo.L_CITY.NAME, dbo.L_CITY.CODE FROM  dbo.L_COUNTRY INNER JOIN dbo.L_CITY ON dbo.L_COUNTRY.LOGICALREF = dbo.L_CITY.COUNTRY

            //  SELECT dbo.L_CITY.NAME, dbo.L_CITY.CODE FROM  dbo.L_COUNTRY INNER JOIN  dbo.L_CITY ON dbo.L_COUNTRY.LOGICALREF = dbo.L_CITY.COUNTRY

        
            using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                SqlCommand myCommand = new SqlCommand(" SELECT  * from dbo.L_COUNTRY where  (NAME = N'" + CMB_ULKE.Text.ToString() + "') ", con); con.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                { 
                    TXT_ULKE_CODE.Text = myReader["CODE"].ToString();
                    TXT_ULKE_CODE.Tag = myReader["LOGICALREF"].ToString();
                }
            }

            if (TXT_ULKE_CODE.Tag != null)
            {
                int IDS = Convert.ToUInt16(TXT_ULKE_CODE.Tag.ToString());
                using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                {
                    SqlCommand myCommand = new SqlCommand("  SELECT dbo.L_CITY.NAME, dbo.L_CITY.CODE FROM  dbo.L_COUNTRY INNER JOIN  dbo.L_CITY ON dbo.L_COUNTRY.LOGICALREF = dbo.L_CITY.COUNTRY  where  (dbo.L_COUNTRY.LOGICALREF = N'" + IDS + "') ", con);
                    con.Open();
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        CMB_ILLER.Properties.Items.Add(myReader["NAME"].ToString());
                    }
                    con.Dispose();
                }
            }
        }

        private void CMB_ILLER_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CMB_ILLER.Text.ToString())) return;
            CMB_ILCE.Properties.Items.Clear(); CMB_ILCE.Text = "";
            CMB_ILCE.Refresh();
            CMB_ILCE.Focus();
            CMB_ILCE.Properties.Items.Add("");

            //  SELECT dbo.L_COUNTRY.NAME , dbo.L_COUNTRY.CODE, dbo.L_CITY.NAME, dbo.L_CITY.CODE FROM  dbo.L_COUNTRY INNER JOIN dbo.L_CITY ON dbo.L_COUNTRY.LOGICALREF = dbo.L_CITY.COUNTRY

            //  SELECT dbo.L_CITY.NAME, dbo.L_CITY.CODE FROM  dbo.L_COUNTRY INNER JOIN  dbo.L_CITY ON dbo.L_COUNTRY.LOGICALREF = dbo.L_CITY.COUNTRY

            int REF = 0;
            using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                SqlCommand myCommand = new SqlCommand(" SELECT  * from dbo.L_CITY where  (NAME = N'" + CMB_ILLER.Text.ToString() + "') ", con); con.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    REF = (int)myReader["LOGICALREF"];
                    TXT_IL_CODE.Text = myReader["CODE"].ToString();
                }
            }


            using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                SqlCommand myCommand = new SqlCommand("  SELECT     dbo.L_TOWN.NAME, dbo.L_TOWN.CODE FROM    dbo.L_CITY INNER JOIN    dbo.L_TOWN ON dbo.L_CITY.LOGICALREF = dbo.L_TOWN.CTYREF  where  (dbo.L_CITY.LOGICALREF = N'" + REF + "') ", con);
                con.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    CMB_ILCE.Properties.Items.Add(myReader["NAME"].ToString());
                }
                con.Dispose();
            }
        }

        private void CMB_ILCE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CMB_ILCE.Text.ToString())) return;
            //CMB_ILCE.Properties.Items.Clear(); CMB_ILCE.Text = "";
            //CMB_ILCE.Refresh();
            //CMB_ILCE.Focus();
            //CMB_ILCE.Properties.Items.Add("");

            //  SELECT dbo.L_COUNTRY.NAME , dbo.L_COUNTRY.CODE, dbo.L_CITY.NAME, dbo.L_CITY.CODE FROM  dbo.L_COUNTRY INNER JOIN dbo.L_CITY ON dbo.L_COUNTRY.LOGICALREF = dbo.L_CITY.COUNTRY

            //  SELECT dbo.L_CITY.NAME, dbo.L_CITY.CODE FROM  dbo.L_COUNTRY INNER JOIN  dbo.L_CITY ON dbo.L_COUNTRY.LOGICALREF = dbo.L_CITY.COUNTRY
             
            using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                SqlCommand myCommand = new SqlCommand(" SELECT  * from dbo.L_TOWN where  (NAME = N'" + CMB_ILCE.Text.ToString() + "') ", con); con.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    TXT_ILCE_CODE.Text = myReader["CODE"].ToString();
                }
            } 
        } 

        private void BR_LOGO_LOAD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

           

            using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString()))
            {
                SqlCommand myCommand = new SqlCommand(" SELECT  top 1 *  From LG_" + _GLOBAL_PARAMETERS._SIRKET_NO + "_CLCARD where   (CODE = N'" + TXT_CARI_HESAP_KODU.Text.ToString() + "')  ", con); con.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    TXT_LOGO_GELDI.Text = "LOGODAN_GELDI";


                    TXT_ADRES.Text = myReader["ISPERSCOMP"].ToString();


                    if (myReader["ISPERSCOMP"].ToString()=="0") { RD_TUZEL.Checked = false; }
                    if (myReader["ISPERSCOMP"].ToString() == "1") { RD_SAHIS.Checked = true; }

                    if (myReader["ISFOREIGN"].ToString() == "0") { RD_YERLI.Checked = false; }
                    if (myReader["ISFOREIGN"].ToString() == "1") { RD_YABANCI.Checked = true; } 

                    TXT_CARI_HESAP_KODU.Text = myReader["CODE"].ToString(); 
                    TXT_PAZARLAMA_SIRKETI_ADI.Text = myReader["DEFINITION_"].ToString(); 
                    TXT_ADRES.Text = myReader["ADDR1"].ToString(); 
                    TXT_TELNO.Text = myReader["TELNRS1"].ToString();
                    TXT_FAX.Text = myReader["FAXCODE"].ToString();
                    TXT_VERGIDAIRESI.Text = myReader["TAXOFFICE"].ToString();   
                    TXT_ILCE_CODE.Text = myReader["TOWNCODE"].ToString();
                    CMB_ILCE.Text = myReader["TOWN"].ToString();
                    TXT_IL_CODE.Text = myReader["CITYCODE"].ToString();
                    CMB_ILLER.Text = myReader["CITY"].ToString();
                    TXT_ULKE_CODE.Text = myReader["COUNTRYCODE"].ToString();
                    CMB_ULKE.Text = myReader["COUNTRY"].ToString(); 
                    txtBxPk.Text = myReader["POSTCODE"].ToString();
                    TXT_HESAP_NO.Text = myReader["BANKACCOUNTS1"].ToString();
                    TXT_CARI_HESAP_KODU.Text = myReader["CODE"].ToString();
                    TXT_MUHASEBE_HESAP_KODU.Text = myReader["DEFINITION2"].ToString(); 

                    BANKA_ADI1.Text = myReader["BANKNAMES1"].ToString();
                    TXT_IBAN.Text = myReader["BANKIBANS1"].ToString();
                    TXT_EMAIL.Text = myReader["EMAILADDR"].ToString();  

                }
            }


        }
        private void RD_PRG_VISION_CheckedChanged(object sender, EventArgs e)
        {
            if (RD_PRG_VISION.Checked)
            {
                //RD_PRM_CARI_KOD.Enabled = false;
                //RD_PRM_TAX_NO.Enabled = false;
                //RD_PRM_TCK_NO.Enabled = false;

                RD_PRM_CARI_KOD.Enabled = false;
                RD_PRM_TAX_NO.Enabled = false;
                RD_PRM_TCK_NO.Enabled = false;
                RD_PRM_ID.Enabled = false;
                RD_PRM_ID.Checked = true;
                RD_PRM_ID.Visible = true;
            }
            if (RD_PRG_VISION.Checked==false)
            {
                RD_PRM_CARI_KOD.Enabled = true;
                RD_PRM_TAX_NO.Enabled = true;
                RD_PRM_TCK_NO.Enabled = true;
                RD_PRM_ID.Enabled = true;
                RD_PRM_ID.Checked = false;
                RD_PRM_ID.Visible = false;
                RD_PRM_CARI_KOD.Checked = true; 
            }

        } 

        private void RD_SAHIS_CheckedChanged(object sender, EventArgs e)
        {
            ValidateFields(); 
        }

        private void RD_TUZEL_CheckedChanged(object sender, EventArgs e)
        {
            ValidateFields();  
        } 
        private void RD_YERLI_CheckedChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void GENEL_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateFields();
        }

        private void RD_YABANCI_CheckedChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void RD_PRM_TCK_NO_CheckedChanged(object sender, EventArgs e)
        {
            RD_SAHIS.Checked = true;
            ValidateFields();
        }

        private void RD_PRM_TAX_NO_CheckedChanged(object sender, EventArgs e)
        {
            RD_TUZEL.Checked = true;
            ValidateFields();
        }

        private void RD_PRM_CARI_KOD_CheckedChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

      
    }
}