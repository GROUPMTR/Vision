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

namespace VISION._LOCAL_ADMIN.MECRALAR
{
    public partial class DERGI : DevExpress.XtraEditors.XtraForm
    {
        public DERGI()
        {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            PAZARLAMA_SIRKETI_LISTESI();
        }
        private void PAZARLAMA_SIRKETI_LISTESI()
        {
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string mySelectQuery = "SELECT * FROM dbo.ADM_PAZARLAMA_SIRKETI order by KODU";
                SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
                myCommand.CommandText = mySelectQuery.ToString();
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    TX_CMB_PAZARLAMA_STI_KODU.Properties.Items.Add(myReader["KODU"].ToString());
                }
            }
        }

        private void BR_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }



        private void __Kaydet()
        {
            SqlConnection myConnectionKontrol = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            string myInsertQueryKontrol = " SELECT * FROM dbo.ADM_MECRA_DERGI WHERE (Kodu = @Kodu)";
            SqlCommand myCommandKontrol = new SqlCommand(myInsertQueryKontrol);
            myCommandKontrol.Parameters.Add("@Kodu", SqlDbType.NVarChar); myCommandKontrol.Parameters["@Kodu"].Value = T_Kodu.Text;
            myCommandKontrol.Connection = myConnectionKontrol;
            myConnectionKontrol.Open();
            SqlDataReader myReaderKontrol = myCommandKontrol.ExecuteReader(CommandBehavior.CloseConnection);
            if (myReaderKontrol.HasRows == false)
            {
                SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                myConnectionTable.Open();
                SqlCommand myCmd = new SqlCommand();
                myCmd.CommandText = " INSERT INTO dbo.ADM_MECRA_DERGI (PAZARLAMA_SIREKETI_KODU, YayinGrubu, YerelUlusal, AnaYayinKodu, YayinPeriyodu, RaporGrubu, Kodu, Adi, Adresi, SirketUnvani, PK, IL, Ilce, Telefon, Fax, VD, VNo, Mail, Notum, Tiraj, IMSKodu, CariHesapKodu, MuhasebeKodu, StokKodu,  AcilisiYapan, AcilisiYapanMakinaIP, AcilisiYapanMakinaName, AcilisTarihi,Logosu) " +
                                                                      " Values (@PAZARLAMA_SIREKETI_KODU, @YayinGrubu, @YerelUlusal, @AnaYayinKodu, @YayinPeriyodu, @RaporGrubu, @Kodu, @Adi, @Adresi, @SirketUnvani, @PK, @IL, @Ilce, @Telefon, @Fax, @VD, @VNo, @Mail, @Notum, @Tiraj, @IMSKodu, @CariHesapKodu, @MuhasebeKodu, @StokKodu, @AcilisiYapan, @AcilisiYapanMakinaIP, @AcilisiYapanMakinaName, @AcilisTarihi, @Logosu)  SELECT ID,UniqueID,Kodu from AgencyMaster.dbo.AnaMecraGazete where ID=@@IDENTITY  ";
                myCmd.Parameters.Add("@PAZARLAMA_SIREKETI_KODU", SqlDbType.NVarChar); myCmd.Parameters["@PAZARLAMA_SIREKETI_KODU"].Value = TX_CMB_PAZARLAMA_STI_KODU.Text;
                myCmd.Parameters.Add("@YayinGrubu", SqlDbType.NVarChar); myCmd.Parameters["@YayinGrubu"].Value = T_C_YayinGrubu.Text;
                myCmd.Parameters.Add("@RaporGrubu", SqlDbType.NVarChar); myCmd.Parameters["@RaporGrubu"].Value = T_C_RaporGrubu.Text;
                myCmd.Parameters.Add("@YerelUlusal", SqlDbType.NVarChar); myCmd.Parameters["@YerelUlusal"].Value = T_C_YerelUlusal.Text;
                myCmd.Parameters.Add("@AnaYayinKodu", SqlDbType.NVarChar); myCmd.Parameters["@AnaYayinKodu"].Value = T_C_AnaYayinKodu.Text;
                myCmd.Parameters.Add("@YayinPeriyodu", SqlDbType.NVarChar); myCmd.Parameters["@YayinPeriyodu"].Value = T_C_YayinPeriyod.Text;
                myCmd.Parameters.Add("@Kodu", SqlDbType.NVarChar); myCmd.Parameters["@Kodu"].Value = T_Kodu.Text;
                myCmd.Parameters.Add("@Adi", SqlDbType.NVarChar); myCmd.Parameters["@Adi"].Value = T_Adi.Text;
                myCmd.Parameters.Add("@SirketUnvani", SqlDbType.NVarChar); myCmd.Parameters["@SirketUnvani"].Value = T_SirketUnvani.Text;
                myCmd.Parameters.Add("@Adresi", SqlDbType.NVarChar); myCmd.Parameters["@Adresi"].Value = T_Adresi.Text;
                myCmd.Parameters.Add("@PK", SqlDbType.NVarChar); myCmd.Parameters["@PK"].Value = T_Pk.Text;
                myCmd.Parameters.Add("@IL", SqlDbType.NVarChar); myCmd.Parameters["@IL"].Value = T_C_IL.Text;
                myCmd.Parameters.Add("@Ilce", SqlDbType.NVarChar); myCmd.Parameters["@Ilce"].Value = T_C_Ilce.Text;
                myCmd.Parameters.Add("@Telefon", SqlDbType.NVarChar); myCmd.Parameters["@Telefon"].Value = T_msk_Telefon.Text;
                myCmd.Parameters.Add("@Fax", SqlDbType.NVarChar); myCmd.Parameters["@Fax"].Value = T_msk_Fax.Text;
                myCmd.Parameters.Add("@VD", SqlDbType.NVarChar); myCmd.Parameters["@VD"].Value = T_VergiDairesi.Text;
                myCmd.Parameters.Add("@VNo", SqlDbType.NVarChar); myCmd.Parameters["@VNo"].Value = T_VergiNO.Text;
                myCmd.Parameters.Add("@Mail", SqlDbType.NVarChar); myCmd.Parameters["@Mail"].Value = T_Mail.Text;
                myCmd.Parameters.Add("@Notum", SqlDbType.NVarChar); myCmd.Parameters["@Notum"].Value = T_Notu.Text;
                myCmd.Parameters.Add("@Tiraj", SqlDbType.NVarChar); myCmd.Parameters["@Tiraj"].Value = T_Tiraji.Text;
                myCmd.Parameters.Add("@IMSKodu", SqlDbType.NVarChar); myCmd.Parameters["@IMSKodu"].Value = T_ImsKodu.Text;
                myCmd.Parameters.Add("@CariHesapKodu", SqlDbType.NVarChar); myCmd.Parameters["@CariHesapKodu"].Value = txtBxCariHesapKodu.Text;
                myCmd.Parameters.Add("@MuhasebeKodu", SqlDbType.NVarChar); myCmd.Parameters["@MuhasebeKodu"].Value = txtBxMuhasebeKodu.Text;
                //myCmd.Parameters.Add("@StokKodu", SqlDbType.NVarChar); myCmd.Parameters["@StokKodu"].Value = __StokKoduUret("").ToString();


                //myCmd.Parameters.Add("@AcilisiYapan", SqlDbType.NVarChar); myCmd.Parameters["@AcilisiYapan"].Value = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
                //myCmd.Parameters.Add("@AcilisiYapanMakinaIP", SqlDbType.NVarChar); myCmd.Parameters["@AcilisiYapanMakinaIP"].Value = GLOBAL_PARAMETRELER._IP.ToString();
                //myCmd.Parameters.Add("@AcilisiYapanMakinaName", SqlDbType.NVarChar); myCmd.Parameters["@AcilisiYapanMakinaName"].Value = GLOBAL_PARAMETRELER._DNS.ToString();
                //myCmd.Parameters.Add("@AcilisTarihi", SqlDbType.DateTime); myCmd.Parameters["@AcilisTarihi"].Value = DateTime.Now.ToShortDateString();
                //myCmd.Parameters.Add("@Logosu", SqlDbType.Image); myCmd.Parameters["@Logosu"].Value = arrImage;
                myCmd.Connection = myConnectionTable;
                SqlDataReader myReader = myCmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {

                    lbID.Caption = myReader["ID"].ToString();        
                }
                myReader.Close();
                myCmd.Connection.Close();
            }
            else
            {
                MessageBox.Show(T_Kodu.Text.ToString() + " Bu kod daha önce kullanılmış." + (char)13 + " Lütfen farklı bir kod kullanın.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            myCommandKontrol.Connection.Close();
        }
        private void __Guncelle()
        {
            //MemoryStream mstr = new MemoryStream();
            //pictureBoxLogo.Image.Save(mstr, pictureBoxLogo.Image.RawFormat);
            //byte[] arrImage = mstr.GetBuffer();
            SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            myConnectionTable.Open();
            SqlCommand myCmd = new SqlCommand();
            myCmd.CommandText =
            " UPDATE AgencyMaster.dbo.AnaMecraGazete  " +
                     " SET PAZARLAMA_SIREKETI_KODU=@PAZARLAMA_SIREKETI_KODU,YayinGrubu=@YayinGrubu,RaporGrubu=@RaporGrubu,YerelUlusal=@YerelUlusal,AnaYayinKodu=@AnaYayinKodu,YayinPeriyodu=@YayinPeriyodu," +
                     " Adi=@Adi, SirketUnvani=@SirketUnvani, Adresi=@Adresi, PK=@PK, IL=@IL, Ilce=@Ilce, Telefon=@Telefon, Fax=@Fax, " +
                     " VD=@VD, VNo=@VNo, Mail=@Mail, Notum=@Notum, Tiraj=@Tiraj, IMSKodu=@IMSKodu, DuzeltmeYapan=@DuzeltmeYapan, DuzeltmeYapanMakinaIP=@DuzeltmeYapanMakinaIP, " +
                     " DuzeltmeYapanMakinaName=@DuzeltmeYapanMakinaName, DuzeltmeTarihi=@DuzeltmeTarihi, Logosu=@Logosu " +
                     " WHERE (ID = '" + lbID.Caption + "')";



            myCmd.Parameters.Add("@PAZARLAMA_SIREKETI_KODU", SqlDbType.NVarChar); myCmd.Parameters["@PAZARLAMA_SIREKETI_KODU"].Value = TX_CMB_PAZARLAMA_STI_KODU.Text;
            myCmd.Parameters.Add("@YayinGrubu", SqlDbType.NVarChar); myCmd.Parameters["@YayinGrubu"].Value = T_C_YayinGrubu.Text;
            myCmd.Parameters.Add("@RaporGrubu", SqlDbType.NVarChar); myCmd.Parameters["@RaporGrubu"].Value = T_C_RaporGrubu.Text;
            myCmd.Parameters.Add("@YerelUlusal", SqlDbType.NVarChar); myCmd.Parameters["@YerelUlusal"].Value = T_C_YerelUlusal.Text;
            myCmd.Parameters.Add("@AnaYayinKodu", SqlDbType.NVarChar); myCmd.Parameters["@AnaYayinKodu"].Value = T_C_AnaYayinKodu.Text;
            myCmd.Parameters.Add("@YayinPeriyodu", SqlDbType.NVarChar); myCmd.Parameters["@YayinPeriyodu"].Value = T_C_YayinPeriyod.Text;


            myCmd.Parameters.Add("@Adi", SqlDbType.NVarChar); myCmd.Parameters["@Adi"].Value = T_Adi.Text;
            myCmd.Parameters.Add("@SirketUnvani", SqlDbType.NVarChar); myCmd.Parameters["@SirketUnvani"].Value = T_SirketUnvani.Text;
            myCmd.Parameters.Add("@Adresi", SqlDbType.NVarChar); myCmd.Parameters["@Adresi"].Value = T_Adresi.Text;
            myCmd.Parameters.Add("@PK", SqlDbType.NVarChar); myCmd.Parameters["@PK"].Value = T_Pk.Text;
            myCmd.Parameters.Add("@IL", SqlDbType.NVarChar); myCmd.Parameters["@IL"].Value = T_C_IL.Text;

            myCmd.Parameters.Add("@Ilce", SqlDbType.NVarChar); myCmd.Parameters["@Ilce"].Value = T_C_Ilce.Text;
            myCmd.Parameters.Add("@Telefon", SqlDbType.NVarChar); myCmd.Parameters["@Telefon"].Value = T_msk_Telefon.Text;
            myCmd.Parameters.Add("@Fax", SqlDbType.NVarChar); myCmd.Parameters["@Fax"].Value = T_msk_Fax.Text;
            myCmd.Parameters.Add("@VD", SqlDbType.NVarChar); myCmd.Parameters["@VD"].Value = T_VergiDairesi.Text;
            myCmd.Parameters.Add("@VNo", SqlDbType.NVarChar); myCmd.Parameters["@VNo"].Value = T_VergiNO.Text;
            myCmd.Parameters.Add("@Mail", SqlDbType.NVarChar); myCmd.Parameters["@Mail"].Value = T_Mail.Text;
            myCmd.Parameters.Add("@Notum", SqlDbType.NVarChar); myCmd.Parameters["@Notum"].Value = T_Notu.Text;
            myCmd.Parameters.Add("@Tiraj", SqlDbType.NVarChar); myCmd.Parameters["@Tiraj"].Value = T_Tiraji.Text;
            myCmd.Parameters.Add("@IMSKodu", SqlDbType.NVarChar); myCmd.Parameters["@IMSKodu"].Value = T_ImsKodu.Text;

            //myCmd.Parameters.Add("@DuzeltmeYapan", SqlDbType.NVarChar); myCmd.Parameters["@DuzeltmeYapan"].Value = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
            //myCmd.Parameters.Add("@DuzeltmeYapanMakinaIP", SqlDbType.NVarChar); myCmd.Parameters["@DuzeltmeYapanMakinaIP"].Value = GLOBAL_PARAMETRELER._IP.ToString();
            //myCmd.Parameters.Add("@DuzeltmeYapanMakinaName", SqlDbType.NVarChar); myCmd.Parameters["@DuzeltmeYapanMakinaName"].Value = GLOBAL_PARAMETRELER._DNS.ToString();
            //myCmd.Parameters.Add("@DuzeltmeTarihi", SqlDbType.DateTime); myCmd.Parameters["@DuzeltmeTarihi"].Value = DateTime.Now.ToShortDateString();
            //myCmd.Parameters.Add("@Logosu", SqlDbType.Image); myCmd.Parameters["@Logosu"].Value = arrImage;
            myCmd.Connection = myConnectionTable;
            myCmd.ExecuteNonQuery();
            myCmd.Connection.Close();
      
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}