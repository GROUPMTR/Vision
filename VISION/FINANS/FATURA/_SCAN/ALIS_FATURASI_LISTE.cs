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
using UnityObjects;
namespace VISION.FINANS.FATURA._SCAN
{
    public partial class ALIS_FATURASI_LISTE : DevExpress.XtraEditors.XtraForm
    {
        public ALIS_FATURASI_LISTE()
        {
            InitializeComponent();
            this.Tag = "MDIFORM";
            DATA_LOAD(Convert.ToUInt16(CMB_YIL.EditValue));
        }

        private void BTN_LISTE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DATA_LOAD(Convert.ToUInt16(CMB_YIL.EditValue));
        }


        private void DATA_LOAD(int YIL)
        {
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                myConnection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from dbo.FTR_GELEN_FATURALAR WHERE FATURA_TIPI='P'  AND YEAR(IssueDate)=@YIL  order by OID desc ", myConnection))
                {
                    cmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    cmd.Parameters.AddWithValue("@YIL", YIL);
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
            ALIS_FATURASI FRM = new ALIS_FATURASI(0);
            FRM.ShowDialog();


            DATA_LOAD(Convert.ToUInt16(CMB_YIL.EditValue));
        }

        private void BTN_SAVE_PDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FolderBrowserDialog brwsr = new FolderBrowserDialog();
            if (brwsr.ShowDialog() == DialogResult.Cancel)
                return;
            else
            {
                int[] selectedRows = gridView_MASTER.GetSelectedRows();
                for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
                {

                    DataRow dr = gridView_MASTER.GetFocusedDataRow();
                    if (dr == null) return;
                    DateTime dt = Convert.ToDateTime(dr["IssueDate"]);


                    File.Copy(_GLOBAL_PARAMETERS._FILE_PATH + "_INBOX_PRINT\\" + dr["SIRKET_KODU"].ToString() + "\\" + dr["SIRKET_KODU"].ToString() + "_" + dt.Year.ToString() + "_" + dr["GUID"].ToString() + ".pdf", brwsr.SelectedPath + "\\" + dr["SIRKET_KODU"].ToString() + "_" + dt.Year.ToString() + "_" + dr["GUID"].ToString() + ".pdf");

                  
                }

                
                MessageBox.Show(selectedRows.Length + " Adet Dosya Kaydedildi");
            }
        }

        private void BTN_EPOSTA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BTN_YAZDIR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {   
              YAZDIR();
        }

        private void YAZDIR()
        {
            int[] selectedRows = gridView_MASTER.GetSelectedRows();
            for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
            {

                DataRow dr = gridView_MASTER.GetFocusedDataRow();
                if (dr == null) return;
                DateTime dt = Convert.ToDateTime(dr["IssueDate"]);
                view.ZoomFactor = 60;
                view.CloseDocument();
                groupControl1.Visible = false;
                groupControl1.Controls.Clear();
                groupControl1.Controls.Add(view);
                view.Dock = DockStyle.Fill;
                try
                {
                    view.DocumentFilePath = @"" + _GLOBAL_PARAMETERS._FILE_PATH + "_INBOX_PRINT\\" + dr["SIRKET_KODU"].ToString() + "\\" + dr["SIRKET_KODU"].ToString() + "_" + dt.Year.ToString() + "_" + dr["GUID"].ToString() + ".pdf";
                    view.Refresh();
                    
                    groupControl1.Visible = true;
                    view.Print(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void re_FILE_SELECT_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog opn = new OpenFileDialog();
            opn.ShowDialog();
            if (!String.IsNullOrEmpty(opn.FileName.ToString()))
            {
                DataRow dr = gridView_MASTER.GetFocusedDataRow();
                if (dr == null) return;

                DateTime dt = Convert.ToDateTime(dr["IssueDate"]);
                string FILE_NAME = @"" + _GLOBAL_PARAMETERS._FILE_PATH + "_INBOX_PRINT\\" + dr["SIRKET_KODU"].ToString() + "\\" + dr["SIRKET_KODU"].ToString() + "_" + dt.Year.ToString() + "_" + dr["GUID"] + ".pdf";
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

        DevExpress.XtraPdfViewer.PdfViewer view = new DevExpress.XtraPdfViewer.PdfViewer();
        private void gridCntrl_LIST_Click(object sender, EventArgs e)
        { 
        
            DataRow dr = gridView_MASTER.GetFocusedDataRow();
            if (dr == null) return;
            view = new DevExpress.XtraPdfViewer.PdfViewer();
            DateTime dt = Convert.ToDateTime(dr["IssueDate"]);            
            view.ZoomFactor = 60;
            view.CloseDocument();
            groupControl1.Visible = false;
            groupControl1.Controls.Clear();  
            groupControl1.Controls.Add(view);
            view.Dock = DockStyle.Fill; 
            try
            {
                view.DocumentFilePath = _GLOBAL_PARAMETERS._FILE_PATH + "_INBOX_PRINT\\" + dr["SIRKET_KODU"].ToString() + "\\" + dr["SIRKET_KODU"].ToString() + "_" + dt.Year.ToString() + "_" + dr["GUID"].ToString() + ".pdf";
                view.Refresh();
                BR_FILE.Caption = _GLOBAL_PARAMETERS._FILE_PATH + "_INBOX_PRINT\\" + dr["SIRKET_KODU"].ToString() + "\\" + dr["SIRKET_KODU"].ToString() + "_" + dt.Year.ToString() + "_" + dr["GUID"].ToString() + ".pdf";

                groupControl1.Visible = true;
            }
            catch (Exception ex)
            {
               BR_FILE.Caption = ex.Message.ToString ();
            }
        }

        private void gridCntrl_LIST_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView_MASTER.GetFocusedDataRow();
            if (dr == null) return;

            ALIS_FATURASI FRM = new ALIS_FATURASI(Convert.ToInt32(dr["OID"].ToString ()) );
            FRM.ShowDialog();
            DATA_LOAD(Convert.ToUInt16(CMB_YIL.EditValue));

        }

        private void gridCntrl_LIST_DockChanged(object sender, EventArgs e)
        {

        }

        private void BTN_DELETE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dr = gridView_MASTER.GetFocusedDataRow();
            if (dr == null) return;

                    DialogResult c = MessageBox.Show("Silmek istediğinizden eminmisiniz.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (c == DialogResult.Yes)
                    {
                        using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                        {
                            using (SqlCommand myCommand = new SqlCommand())
                            {
                                myCommand.Parameters.AddWithValue("@OID", dr["OID"]);
                                myCommand.Connection = myConnection;
                                myCommand.CommandText = " DELETE  dbo.FTR_GELEN_FATURALAR  WHERE OID=" + dr["OID"];
                                myConnection.Open();
                                myCommand.ExecuteNonQuery();
                                myCommand.Connection.Close();
                            }
                        }
                        dr.Delete();
                    }
         }

        private void BTN_LOGO_SET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);

            myConnections.Open();
            int[] selectedRows = gridView_MASTER.GetSelectedRows();

            for (int ix = selectedRows.Length - 1; ix >= 0; ix--)
            {

                DataRow drx = gridView_MASTER.GetDataRow(selectedRows[ix]);
                if (drx == null) return;
                string DURUM_BILGISI = string.Empty;
                int _LOGICALREF = 0;
                Query Querys = _GLOBAL_PARAMETERS.Global.UnityApp.NewQuery();



                string Query_String = "SELECT CRD.LOGICALREF , CRD.TAXNR,FTR.FICHENO  FROM  dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_CLCARD CRD LEFT JOIN dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_01_INVOICE FTR ON  CRD.LOGICALREF=FTR.CLIENTREF   WHERE  CRD.TAXNR='" + drx["AccSupplierPartyIdentificationSchemeID"].ToString() + "' AND  FTR.FICHENO='" + drx["ID"].ToString() + "'";

                //= "   select  LOGICALREF FROM LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_01_INVOICE  WHERE   FICHENO='" + drx["ID"].ToString() + "'";
                Querys.Statement = Query_String;
                if (Querys.OpenDirect())
                {
                    bool eof = Querys.First();
                    if (eof)
                    {
                        while (eof)
                        {
                            _LOGICALREF = Querys.QueryFields[0].Value;
                            string SQL_ROW = @" UPDATE dbo.FTR_GELEN_FATURALAR SET ERP_AKTARILDI='True' Where SIRKET_KODU='{0}'  and ID='{1}' and OID='{2}'  ";
                            SQL_ROW = string.Format(SQL_ROW, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), drx["ID"].ToString(), drx["OID"].ToString());
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.CommandText = SQL_ROW;
                                cmd.Connection = myConnections;
                                cmd.ExecuteNonQuery();
                            }
                            drx["ERP_AKTARILDI"] = true;
                            eof = Querys.Next();
                        }
                    }
                    else
                    {
                        string SQL_ROW = @" UPDATE dbo.FTR_GELEN_FATURALAR SET ERP_AKTARILDI='False' Where SIRKET_KODU='{0}'  and ID='{1}' and OID='{2}'  ";
                        SQL_ROW = string.Format(SQL_ROW, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString(), drx["ID"].ToString(), drx["OID"].ToString());
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = SQL_ROW;
                            cmd.Connection = myConnections;
                            cmd.ExecuteNonQuery();
                        }
                        drx["ERP_AKTARILDI"] = false;
                    }
                }

            }
        }

        private void BTN_EXCEL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = ".xlsx (*.xlsx)|*.xlsx";
            sfd.FileName = "EXPORT_FATURA.xlsx";
            DialogResult res = sfd.ShowDialog();
            if (res == DialogResult.OK)
            {
                gridView_MASTER.ExportToXlsx(sfd.FileName);
            }
        }
    }
}