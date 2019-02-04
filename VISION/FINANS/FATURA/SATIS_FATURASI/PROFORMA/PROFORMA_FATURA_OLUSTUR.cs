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

namespace VISION.FINANS.FATURA.SATIS_FATRASI.PROFORMA
{
    public partial class PROFORMA_FATURA_OLUSTUR : DevExpress.XtraEditors.XtraForm
    {
        public PROFORMA_FATURA_OLUSTUR()
        {
            InitializeComponent();

            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent; 
        }

        private void BR_YAZDIR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string SQLControl = " SELECT  * From dbo.ADM_SAYAC_TASLAK_FATURA  WHERE SIRKET_KODU=@SIRKET_KODU AND YIL=@YIL ";
                SqlCommand cmd = new SqlCommand(SQLControl, con);
                cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                cmd.Parameters.AddWithValue("@YIL", DateTime.Now.Year);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    int Count = Convert.ToInt32(rdr["SAYAC"]) + 1;
                    TXT_FATURA_NO.Text = String.Format("T-{0}-{1}", rdr["YIL"], Convert.ToString(Count));
                    using (SqlConnection conUpdate = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                    {
                        string SQLUpdate = " UPDATE dbo.ADM_SAYAC_TASLAK_FATURA SET SAYAC=@SAYAC WHERE SIRKET_KODU=@SIRKET_KODU AND YIL=@YIL ";
                        SqlCommand cmdUpdt = new SqlCommand(SQLUpdate, conUpdate);
                        cmdUpdt.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                        cmdUpdt.Parameters.AddWithValue("@YIL", DateTime.Now.Year);
                        cmdUpdt.Parameters.AddWithValue("@SAYAC", Count);
                        conUpdate.Open();
                        cmdUpdt.ExecuteNonQuery();
                        cmdUpdt.Connection.Close();
                    }
                }
                rdr.Close();
            } 
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void TXT_MUSTERI_ADI_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                using (_LOCAL_ADMIN.MUSTERI.MUSTERI_LISTESI LST = new _LOCAL_ADMIN.MUSTERI.MUSTERI_LISTESI())
                {
                    //_FaturaKimeKesilecek = "Müşteriye Kesilecek";
                    //MUSTERILISTESI.initform(this);
                    //MUSTERILISTESI.ShowDialog();
                    LST.ShowDialog();

                }
            }
            if (e.Button.Index == 1)
            {
                //using (Agency.ADMIN.CREATIVE_AJANS.CREATIVE_AJANS_LISTESI Ajanslistesi = new Agency.ADMIN.CREATIVE_AJANS.CREATIVE_AJANS_LISTESI())
                //{
                //    _FaturaKimeKesilecek = "Ajansa Kesilecek";
                //    Ajanslistesi.initform(this);
                //    Ajanslistesi.ShowDialog();
                //}
            }
        }
    }
}