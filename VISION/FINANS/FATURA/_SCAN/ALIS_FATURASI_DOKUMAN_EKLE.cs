using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VISION.FINANS.FATURA._SCAN
{
    public partial class ALIS_FATURASI_DOKUMAN_EKLE : Form
    {
        string MUSTERI_KODU;
        public ALIS_FATURASI_DOKUMAN_EKLE(string _MUSTERI_KODU)
        {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent; 

            DateTime dt = DateTime.Now;
            DATE_EDT_GELISTARIHI.EditValue = dt.ToString("dd.MM.yyyy").ToString();
            MUSTERI_KODU = _MUSTERI_KODU;
            COM_BX_DOSYA_TURU.Text = "";
            BTN_ADRESS.Text = "";
            TXT_NOTU.Text = "";

        }

        private void BTN_ADRESS_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Application.ExecutablePath.ToString();
            openFile.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                this.BTN_ADRESS.Text = openFile.FileName.ToString();
            }
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void BR_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guid g = Guid.NewGuid();
            DateTime dtm = DateTime.Now ; 

            SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            myConnectionTable.Open();
            SqlCommand myCmd = new SqlCommand();
            myCmd.CommandText = " INSERT INTO dbo.ADM_MUSTERI_DOKUMANLARI (MUSTERI_KODU,SIRKET_KODU,GUID,DOKUMAN_TARIHI,DOSYA_TURU, ACIKLAMA,ISLEM_TARIHI,ISLEM_SAATI,ISLEMI_YAPAN) " +
                                                              " Values (@MUSTERI_KODU,@SIRKET_KODU,@GUID,@DOKUMAN_TARIHI,@DOSYA_TURU,@ACIKLAMA,@ISLEM_TARIHI,@ISLEM_SAATI,@ISLEMI_YAPAN) ";
            

            myCmd.Parameters.Add("@MUSTERI_KODU", SqlDbType.NVarChar); myCmd.Parameters["@MUSTERI_KODU"].Value = MUSTERI_KODU;
            myCmd.Parameters.Add("@SIRKET_KODU", SqlDbType.NVarChar); myCmd.Parameters["@SIRKET_KODU"].Value = _GLOBAL_PARAMETERS._SIRKET_KODU;
            myCmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier); myCmd.Parameters["@GUID"].Value = g;
            myCmd.Parameters.Add("@DOKUMAN_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@DOKUMAN_TARIHI"].Value = DATE_EDT_GELISTARIHI.Text;
            myCmd.Parameters.Add("@DOSYA_TURU", SqlDbType.NVarChar); myCmd.Parameters["@DOSYA_TURU"].Value = COM_BX_DOSYA_TURU.Text;            
            myCmd.Parameters.Add("@ACIKLAMA", SqlDbType.NVarChar); myCmd.Parameters["@ACIKLAMA"].Value = TXT_NOTU.Text;


            myCmd.Parameters.Add("@ISLEM_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@ISLEM_TARIHI"].Value = dtm;
            myCmd.Parameters.Add("@ISLEM_SAATI", SqlDbType.DateTime); myCmd.Parameters["@ISLEM_SAATI"].Value = dtm;
            myCmd.Parameters.Add("@ISLEMI_YAPAN", SqlDbType.NVarChar); myCmd.Parameters["@ISLEMI_YAPAN"].Value = _GLOBAL_PARAMETERS._KULLANICI_MAIL;



            myCmd.Connection = myConnectionTable;
            myCmd.ExecuteNonQuery();
            myCmd.Connection.Close(); 

            DateTime dt = Convert.ToDateTime(DATE_EDT_GELISTARIHI.Text);
            File.Move(BTN_ADRESS.Text, _GLOBAL_PARAMETERS._FILE_PATH +"_DOKUMAN\\"+ _GLOBAL_PARAMETERS._SIRKET_KODU +"\\"+ _GLOBAL_PARAMETERS._SIRKET_KODU +"_"+dt.Year.ToString() +"_"+ g+".jpg");  
            MessageBox.Show("Kayıt işlemi yapıldı", "UYARI");
        }
    }
}
