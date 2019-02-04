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
using System.IO;

namespace VISION.FINANS.FATURA._SCAN
{
    public partial class SATIS_FATURASI_LISTE : DevExpress.XtraEditors.XtraForm
    {
        public SATIS_FATURASI_LISTE()
        {
            InitializeComponent();
            this.Tag = "MDIFORM";
            DATA_LOAD();
        }

        private void DATA_LOAD()
        {
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                myConnection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from dbo.FTR_GIB_TRANSFER WHERE FATURA_TIPI='P' and SIRKET_KODU=@SIRKET_KODU", myConnection))
                {
                    cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);  
                    SqlDataAdapter deMaster = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    deMaster.Fill(ds, "FTR_GELEN_FATURALAR");
                    gridCntrl_LIST.DataSource = ds.Tables["FTR_GELEN_FATURALAR"]; 
                }
            }
        
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void BTN_YENI_FATURA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SATIS_FATURASI FRM = new SATIS_FATURASI(0);
            FRM.ShowDialog();
        }

        private void BTN_SAVE_PDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BTN_EPOSTA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BTN_YAZDIR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void CMN_DOSYA_EKLE_Click(object sender, EventArgs e)
        {
            //OpenFileDialog opn = new OpenFileDialog();
            //opn.ShowDialog();


            //Guid g = Guid.NewGuid();
            //DateTime dtm = DateTime.Now;

            //SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            //myConnectionTable.Open();
            //SqlCommand myCmd = new SqlCommand();
            //myCmd.CommandText = " INSERT INTO dbo.ADM_MUSTERI_DOKUMANLARI (MUSTERI_KODU,SIRKET_KODU,GUID,DOKUMAN_TARIHI,DOSYA_TURU, ACIKLAMA,ISLEM_TARIHI,ISLEM_SAATI,ISLEMI_YAPAN) " +
            //                                                  " Values (@MUSTERI_KODU,@SIRKET_KODU,@GUID,@DOKUMAN_TARIHI,@DOSYA_TURU,@ACIKLAMA,@ISLEM_TARIHI,@ISLEM_SAATI,@ISLEMI_YAPAN) ";


            //myCmd.Parameters.Add("@MUSTERI_KODU", SqlDbType.NVarChar); myCmd.Parameters["@MUSTERI_KODU"].Value = MUSTERI_KODU;
            //myCmd.Parameters.Add("@SIRKET_KODU", SqlDbType.NVarChar); myCmd.Parameters["@SIRKET_KODU"].Value = _GLOBAL_PARAMETERS._SIRKET_KODU;
            //myCmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier); myCmd.Parameters["@GUID"].Value = g;
            //myCmd.Parameters.Add("@DOKUMAN_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@DOKUMAN_TARIHI"].Value = DATE_EDT_GELISTARIHI.Text;
            //myCmd.Parameters.Add("@DOSYA_TURU", SqlDbType.NVarChar); myCmd.Parameters["@DOSYA_TURU"].Value = COM_BX_DOSYA_TURU.Text;
            //myCmd.Parameters.Add("@ACIKLAMA", SqlDbType.NVarChar); myCmd.Parameters["@ACIKLAMA"].Value = TXT_NOTU.Text;


            //myCmd.Parameters.Add("@ISLEM_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@ISLEM_TARIHI"].Value = dtm;
            //myCmd.Parameters.Add("@ISLEM_SAATI", SqlDbType.DateTime); myCmd.Parameters["@ISLEM_SAATI"].Value = dtm;
            //myCmd.Parameters.Add("@ISLEMI_YAPAN", SqlDbType.NVarChar); myCmd.Parameters["@ISLEMI_YAPAN"].Value = _GLOBAL_PARAMETERS._KULLANICI_MAIL;



            //myCmd.Connection = myConnectionTable;
            //myCmd.ExecuteNonQuery();
            //myCmd.Connection.Close();

            //DateTime dt = Convert.ToDateTime(DATE_EDT_GELISTARIHI.Text);
            //File.Move(opn.FileName.ToString () , _GLOBAL_PARAMETERS._FILE_PATH + "_DOKUMAN\\" + _GLOBAL_PARAMETERS._SIRKET_KODU + "\\" + _GLOBAL_PARAMETERS._SIRKET_KODU + "_" + dt.Year.ToString() + "_" + g + ".jpg");
            //MessageBox.Show("Kayıt işlemi yapıldı", "UYARI");
        }

        private void re_BUTTON_FILE_SELECT_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        { 
            OpenFileDialog opn = new OpenFileDialog();
            opn.ShowDialog();
            if (!String.IsNullOrEmpty(opn.FileName.ToString()))
            {
                DataRow dr = gridView_MASTER.GetFocusedDataRow();
                if (dr == null) return;

                DateTime dt = Convert.ToDateTime(dr["FATURATARIH"]);
                string FILE_NAME = _GLOBAL_PARAMETERS._FILE_PATH + "_OUTBOX_PRINT\\" + _GLOBAL_PARAMETERS._SIRKET_KODU + "\\" + _GLOBAL_PARAMETERS._SIRKET_KODU + "_" + dt.Year.ToString() + "_" + dr["GUID"] + ".pdf";
                if (!File.Exists(FILE_NAME))
                {
                    File.Move(opn.FileName.ToString(), FILE_NAME);
                    MessageBox.Show("Kayıt işlemi yapıldı", "UYARI");
                }
                else
                {

                    DialogResult c = MessageBox.Show("Bu kod ile dosya mevcut Silmek istediğinizden eminmisiniz.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (c == DialogResult.Yes)
                    {

                        if (File.Exists(FILE_NAME))
                        {   
                            view.CloseDocument();
                            view.Dispose();
                            //view = null;
                            groupControl1.Visible = false;
                            groupControl1.Controls.Clear();                            
                            File.Delete(FILE_NAME);
                            File.Move(opn.FileName.ToString(), FILE_NAME);
                            MessageBox.Show("Kayıt işlemi yapıldı", "UYARI");
                        }
                    }


                }

            }

        }
        DevExpress.XtraPdfViewer.PdfViewer view;
        private void gridCntrl_LIST_Click(object sender, EventArgs e)
        {
            view = null;

            DataRow dr = gridView_MASTER.GetFocusedDataRow();
            if (dr == null) return;

            view = new DevExpress.XtraPdfViewer.PdfViewer();
            view.ZoomFactor = 60;
            groupControl1.Visible = false;
            groupControl1.Controls.Clear();
   
            DateTime dt = Convert.ToDateTime(dr["FATURATARIH"]);
            groupControl1.Controls.Add(view);
            view.Dock = DockStyle.Fill;



            try
            {
                view.DocumentFilePath = _GLOBAL_PARAMETERS._FILE_PATH + "_OUTBOX_PRINT\\" + _GLOBAL_PARAMETERS._SIRKET_KODU + "\\" + _GLOBAL_PARAMETERS._SIRKET_KODU + "_" + dt.Year.ToString() + "_" + dr["GUID"].ToString() + ".pdf";
                view.Refresh();

                groupControl1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}