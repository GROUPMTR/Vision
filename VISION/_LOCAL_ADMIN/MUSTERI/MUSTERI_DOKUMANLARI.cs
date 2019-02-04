using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VISION._LOCAL_ADMIN.MUSTERI
{
    public partial class MUSTERI_DOKUMANLARI : Form
    {
        public MUSTERI_DOKUMANLARI()
        {
            InitializeComponent();

            this.Tag = "MDIFORM"; 
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;


            using (SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string Sql = " SELECT * FROM dbo.ADM_MUSTERI  WHERE    (SIRKET_KODU=@SIRKET_KODU) ORDER BY SIRKET_KODU,MUSTERI_KODU";
                using (SqlDataAdapter da = new SqlDataAdapter(Sql, Conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    using (DataSet dtSet = new DataSet())
                    {
                        da.Fill(dtSet, "ADM_MUSTERI");
                        using (DataViewManager dvManager = new DataViewManager(dtSet))
                        {
                            DataView dv = dvManager.CreateDataView(dtSet.Tables[0]);
                            GRD_LISTE.DataSource = dv;
                        }
                    }
                }
            }
            
        }

     

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void BR_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BR_YENI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dr = GRD_VIEW_LISTE.GetFocusedDataRow();
            if (dr != null)
            {
                MUSTERI_DOKUMANLARI_EKLE frm = new MUSTERI_DOKUMANLARI_EKLE(dr["MUSTERI_KODU"].ToString());
                frm.ShowDialog();
                DOKUMANLARI_LISTELE(dr);
            }
        }

        private void GRD_LISTE_Click(object sender, EventArgs e)
        {
      
        }
        DevExpress.XtraPdfViewer.PdfViewer view;
        private void gridCtrl_EKDOSYALAR_Click(object sender, EventArgs e)
        {
            view = null;
            
            view = new DevExpress.XtraPdfViewer.PdfViewer();
            
            groupControl1.Visible = false;
            groupControl1.Controls.Clear(); 
            DataRow dr = gridView_EKDOSYALAR.GetFocusedDataRow(); 
            DateTime dt = Convert.ToDateTime(dr["DOKUMAN_TARIHI"]);
            groupControl1.Controls.Add(view);
            view.Dock = DockStyle.Fill;

         
            
            try
            {
                view.DocumentFilePath = _GLOBAL_PARAMETERS._FILE_PATH + "_DOKUMAN\\" + _GLOBAL_PARAMETERS._SIRKET_KODU + "\\" + _GLOBAL_PARAMETERS._SIRKET_KODU + "_" + dt.Year.ToString() + "_" +dr["GUID"].ToString() + ".pdf";
                view.Refresh();
        
                groupControl1.Visible = true ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GRD_VIEW_LISTE_Click(object sender, EventArgs e)
        {
            DataRow dr = GRD_VIEW_LISTE.GetFocusedDataRow();

            if (dr == null) return;

            DOKUMANLARI_LISTELE(dr);
        }


        private void DOKUMANLARI_LISTELE(DataRow dr)
        { 

            using (SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string Sql = " SELECT * FROM dbo.ADM_MUSTERI_DOKUMANLARI  WHERE    (SIRKET_KODU=@SIRKET_KODU) and (MUSTERI_KODU=@MUSTERI_KODU) ORDER BY SIRKET_KODU,MUSTERI_KODU";
                using (SqlDataAdapter da = new SqlDataAdapter(Sql, Conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    da.SelectCommand.Parameters.AddWithValue("@MUSTERI_KODU", dr["MUSTERI_KODU"].ToString());
                    using (DataSet dtSet = new DataSet())
                    {
                        da.Fill(dtSet, "ADM_MUSTERI_DOKUMANLARI");
                        using (DataViewManager dvManager = new DataViewManager(dtSet))
                        {
                            DataView dv = dvManager.CreateDataView(dtSet.Tables[0]);
                            gridCtrl_EKDOSYALAR.DataSource = dv;
                        }
                    }
                }
            }
        
        }
    }
}
