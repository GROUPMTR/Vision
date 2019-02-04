using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.XtraTreeList.Nodes;
using System.Globalization;
using UnityObjects;
using System.Xml;
using System.Data.SqlClient;
using System.Threading;
using DevExpress.XtraBars.Alerter;
namespace VISION.FINANS.MUHASEBE_AKTARIMI_MANUEL.ALIM
{
    public partial class ALIM_FATURASI_AKTARIM : DevExpress.XtraEditors.XtraForm
    {
        AlertInfo info = new AlertInfo("Fatura İndirme Bilgisi", "");
        public string _DATE, BTN_TYPE;
        public int _E_FATURA_TYPE = 0;
        int _TEMEL_TICARI;
        string _FATURA_SERISI;
        DataSet dataSet;
        DataTable table = new DataTable();
        DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hiRow;
        DataRow dr;
        string BUTTON = "";
        string AKTARIM_DURUMU;
        public ALIM_FATURASI_AKTARIM()
        {
            InitializeComponent();
            this.Tag = "MDIFORM";
            BTM_FIRMA_KODU.Caption = _GLOBAL_PARAMETERS._SIRKET_NO;
            BTM_FIRMA_NAME.Caption = _GLOBAL_PARAMETERS._SIRKET_KODU;
            DATA_LOAD_BEKLEMEDE();
        }

        private void BTN_FATURA_DURUMU_EditValueChanged(object sender, EventArgs e)
        {
            if (BTN_FATURA_DURUMU.EditValue.ToString ()=="Aktarılmamış Faturalar" ) DATA_LOAD_BEKLEMEDE();

            if (BTN_FATURA_DURUMU.EditValue.ToString() == "Aktarılmış Faturalar") DATA_LOAD_AKTARILDI();          
        }
        private void DATA_LOAD_BEKLEMEDE()
        {
            BR_BUG.Caption = "";
            BR_INFO.Caption = "";
            BR_SELECT_ROW_FATURA_GUID.Caption = "";
            BR_SELECT_ROW_FATURA_NO.Caption = ""; 
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string SlctQu = "";
                if (BTN_YIL.EditValue.ToString() == "TÜMÜ") //CASE WHEN fat.EINVOICE = 1 THEN 'e-fatura' else  'e-arşiv' END AS FATURANIN_TURU ,
                { SlctQu = " SELECT CASE WHEN EINVOICE = 1 THEN 'e-fatura' else  'e-arşiv' END AS FATURANIN_TURU , CASE WHEN TYPE = 1 THEN 'ALIM' WHEN TYPE = 6 THEN 'ALIM İADE'  END AS TIPI ,* FROM  dbo.FTR_LG_INVOICE  where (SIRKET_KODU=@SIRKET_KODU) AND (TYPE = 1 or TYPE = 6) and   (AKTARIM_DURUMU ='BEKLEMEDE' or AKTARIM_DURUMU ='AKTARILMADI')  "; }

                else

                { SlctQu = " SELECT CASE WHEN EINVOICE = 1 THEN 'e-fatura' else  'e-arşiv' END AS FATURANIN_TURU , CASE WHEN TYPE = 1 THEN 'ALIM' WHEN TYPE = 6 THEN 'ALIM İADE'  END AS TIPI ,* FROM  dbo.FTR_LG_INVOICE  where (SIRKET_KODU=@SIRKET_KODU) AND (TYPE = 1 or TYPE = 6) and   (AKTARIM_DURUMU ='BEKLEMEDE' or AKTARIM_DURUMU ='AKTARILMADI')  AND (YEAR(DATE) = '" + BTN_YIL.EditValue.ToString() + "') "; }

                SqlDataAdapter da = new SqlDataAdapter(SlctQu, myConnection);
                da.SelectCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                dataSet = new DataSet();
                da.Fill(dataSet, "dbo_MecraList");
                DataViewManager dvManager = new DataViewManager(dataSet);
                DataView dv = dvManager.CreateDataView(dataSet.Tables[0]);
                gridCntrl_LIST.DataSource = dv;
                myConnection.Close();
            }
        }
        private void DATA_LOAD_AKTARILDI()
        {
            BR_BUG.Caption = "";
            BR_INFO.Caption = "";
            BR_SELECT_ROW_FATURA_GUID.Caption = "";
            BR_SELECT_ROW_FATURA_NO.Caption = "";
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {

                string SlctQu = "";
                if (BTN_YIL.EditValue.ToString() == "TÜMÜ")
                { SlctQu = " SELECT CASE WHEN EINVOICE = 1 THEN 'e-fatura' else  'e-arşiv' END AS FATURANIN_TURU , CASE WHEN TYPE = 1 THEN 'ALIM' WHEN TYPE = 6 THEN 'ALIM İADE'  END AS TIPI ,* FROM  dbo.FTR_LG_INVOICE where (SIRKET_KODU=@SIRKET_KODU) AND (TYPE = 1 or TYPE = 6) and   (AKTARIM_DURUMU = 'AKTARILDI' or AKTARIM_DURUMU ='ARŞİVEATILDI') "; }

                else

                { SlctQu = " SELECT CASE WHEN EINVOICE = 1 THEN 'e-fatura' else  'e-arşiv' END AS FATURANIN_TURU , CASE WHEN TYPE = 1 THEN 'ALIM' WHEN TYPE = 6 THEN 'ALIM İADE'  END AS TIPI ,* FROM  dbo.FTR_LG_INVOICE where (SIRKET_KODU=@SIRKET_KODU) AND (TYPE = 1 or TYPE = 6) and   (AKTARIM_DURUMU = 'AKTARILDI' or AKTARIM_DURUMU ='ARŞİVEATILDI')  AND (YEAR(DATE) = '" + BTN_YIL.EditValue.ToString() + "') "; }
                 

                SqlDataAdapter da = new SqlDataAdapter(SlctQu, myConnection);
                da.SelectCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                dataSet = new DataSet();
                da.Fill(dataSet, "dbo_MecraList");
                DataViewManager dvManager = new DataViewManager(dataSet);
                DataView dv = dvManager.CreateDataView(dataSet.Tables[0]);
                gridCntrl_LIST.DataSource = dv;
                myConnection.Close();
            }
        }
        private void BTN_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
        private void _ERP_AKTARIMINA_BASLA()
        {
            re_PROGRESS_BAR.Maximum = gridView_LIST.SelectedRowsCount - 1;
            BTN_ERP_AKTARIM.Enabled = false;
            backgroundWorkers.RunWorkerAsync();//this invokes the DoWork event 
        }
        private void BTN_EDIT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dr == null) return;
            ALIM_FATURASI_EDIT edt = new ALIM_FATURASI_EDIT(dr["GUID"].ToString(), dr["ID"].ToString());
            edt.ShowDialog();

            if (BTN_FATURA_DURUMU.EditValue.ToString() == "Aktarılmamış Faturalar") DATA_LOAD_BEKLEMEDE();
            if (BTN_FATURA_DURUMU.EditValue.ToString() == "Aktarılmış Faturalar") DATA_LOAD_AKTARILDI();
        }
        private void BTN_DELETE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (_GLOBAL_PARAMETERS._FATURA_SILME_YETKISI)
            //{
                DialogResult c = MessageBox.Show("Silmek istediğinizden eminmisiniz.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (c == DialogResult.Yes)
                {
                    int[] selectedRows = gridView_LIST.GetSelectedRows();
                    for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
                    {
                        DateTime dtm = DateTime.Now;
                        DataRow dr = gridView_LIST.GetDataRow(selectedRows[ix]);

                        SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB); 
                        myConnections.Open();
                        using (SqlCommand myCmd = new SqlCommand())
                        {
                            myCmd.CommandText += "  delete dbo.FTR_LG_INVOICE WHERE SIRKET_KODU=@SIRKET_KODU and  TASLAK_FATURA_NO=@TASLAK_FATURA_NO ";
                            myCmd.CommandText += "  delete dbo.FTR_LG_STLINE  WHERE SIRKET_KODU=@SIRKET_KODU and  TASLAK_FATURA_NO=@TASLAK_FATURA_NO "; 
                            myCmd.Parameters.AddWithValue("@TASLAK_FATURA_NO", dr["NUMBER"].ToString());
                            myCmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU); 
                            myCmd.Connection = myConnections;
                            myCmd.ExecuteNonQuery();
                            myCmd.Connection.Close();
                            myConnections.Close();
                        }

                        _GLOBAL_PARAMETERS.LOG_ISLEMLERI LF = new _GLOBAL_PARAMETERS.LOG_ISLEMLERI();
                        LF.LOG_AKTARIMI(dr["TIPI"].ToString(), dr["NUMBER"].ToString(), "SİL", dr["TOTAL_NET"].ToString(), dr["TITLE"].ToString(), "", dr["DEFNFLD_PLAN_KODU"].ToString(), dr["NOTES1"].ToString(), "");

                  

                    }
                    BR_SELECT_ROW_FATURA_NO.Caption = "";
                    DATA_LOAD_BEKLEMEDE();
                }
            //}
            //else
            //{
            //    MessageBox.Show("Yetkiniz yok", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void BTN_EXPORT_EXCEL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = ".xlsx (*.xlsx)|*.xlsx";
            sfd.FileName = "ALIM_BEKLEMEDE.xlsx";
            DialogResult res = sfd.ShowDialog();
            if (res == DialogResult.OK)
            {
                gridView_LIST.ExportToXlsx(sfd.FileName);
            } 
        }

        private void BTN_LOGO_AKTARIMI_DURDUR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            backgroundWorkers.CancelAsync();//makes the backgroundworker stop 

            while (backgroundWorkers.IsBusy) //Stays busy ==> UI freezes here
            {
                backgroundWorkers.CancelAsync();
                System.Threading.Thread.Sleep(20);
            }

            BTN_LOGO_SECILENLERI_AKATAR.Enabled = true;
            BTN_ERP_AKTARIM.Enabled = true; 
        }

        private void BTN_ERP_AKTARIM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int intFirmNo = Convert.ToInt32(_GLOBAL_PARAMETERS._SIRKET_NO);
            if (!_GLOBAL_PARAMETERS.Global.UnityApp.Connected)
            {
                _GLOBAL_PARAMETERS.Global.UnityApp.Login(_GLOBAL_PARAMETERS._KULLANICI_ADI_SOYADI, _GLOBAL_PARAMETERS._KULLANICI_PASSWORD, intFirmNo, 1); 
            }
            _ERP_AKTARIMINA_BASLA(); 
        }

        private void BTN_LOGO_SECILENLERI_AKATAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView_LIST.SelectAll();  
        }

        private void BTN_REFRESH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (BTN_FATURA_DURUMU.EditValue.ToString() == "Aktarılmamış Faturalar") DATA_LOAD_BEKLEMEDE();

            if (BTN_FATURA_DURUMU.EditValue.ToString() == "Aktarılmış Faturalar") DATA_LOAD_AKTARILDI(); 
         
        }

        private void gridCntrl_LIST_Click(object sender, EventArgs e)
        {

            BR_BUG.Caption = "";
            BR_INFO.Caption = "";
            BR_SELECT_ROW_FATURA_GUID.Caption = "";
            BR_SELECT_ROW_FATURA_NO.Caption = ""; 
            dr = gridView_LIST.GetFocusedDataRow(); 
            if (dr != null)
            {

                BR_BUG.Caption = dr["AKTARIM_NOTU"].ToString();
                BR_INFO.Caption = "";
                BR_SELECT_ROW_FATURA_GUID.Caption = dr["GUID"].ToString();
                BR_SELECT_ROW_FATURA_NO.Caption = dr["NUMBER"].ToString();
                STLINE(BR_SELECT_ROW_FATURA_NO.Caption, dr["GUID"].ToString(), dr["ID"].ToString());
            } 
        }

        private void STLINE(string BR_SELECT_ROW_FATURA_NO, string GUID, string ID)
        {
            if (BR_SELECT_ROW_FATURA_NO != "" && ID != "")
            {
                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                {
                    string mySelectQuery = " SELECT   * FROM  dbo.FTR_LG_STLINE  WHERE INVOICE_REF=@INVOICE_REF";
                    SqlDataAdapter da = new SqlDataAdapter(mySelectQuery, myConnection); 
                    da.SelectCommand.Parameters.AddWithValue("@INVOICE_REF", ID);
                    da.SelectCommand.Parameters.AddWithValue("@GUID", GUID);
                    da.SelectCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                    DataSet MyDataSet = new DataSet();
                    da.Fill(MyDataSet, "FTR_LG_STLINE");
                    DataViewManager dvManager = new DataViewManager(MyDataSet);
                    DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                    gridCntrl_LINE.DataSource = dv;
                    myConnection.Close();
                }
            }
        } 

        private void gridCntrl_LIST_DoubleClick(object sender, EventArgs e)
        {

        }


        private void LOGO_AKATARIMI_BASLAT()
        {
            string _RULE_SELECT = "PENCERE_SOR";
            AKTARIM_PARAMETRESI rd = new AKTARIM_PARAMETRESI();
            _ALIM_FATURASI Pdp = new _ALIM_FATURASI();

            int[] selectedRows = gridView_LIST.GetSelectedRows();
            for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
            { 
                 DataRow dr = gridView_LIST.GetDataRow(selectedRows[ix]);
                _E_FATURA_TYPE = Pdp._E_FATURA_KONTROL(dr["CODE"].ToString());

                if (dr["TIPI"].ToString() == "ALIM İADE")
                {
                    if (_RULE_SELECT == "PENCERE_SOR")
                    {
                        rd.FATURANIN_TURU = dr["FATURANIN_TURU"].ToString();
                        rd.ShowDialog();
                        _DATE = rd._DATE;
                                         // dr["NUMBER"].ToString()
                        _FATURA_SERISI = rd.FATURA_SERISI;
                        _RULE_SELECT = "PENCERE_SORULDU";
                        //if (rd.FATURA_TIPI_EFATURA) _E_FATURA_TYPE = 1; else _E_FATURA_TYPE = 0;
                    }
                    if (rd.BTN_TYPE == "VAZGEC") return;


                    //if (_E_FATURA_TYPE == 1)
                    //{
                    //    if (_E_FATURA_TYPE != Pdp._E_FATURA_KONTROL(dr["CODE"].ToString()))
                    //    {
                    //        if (MessageBox.Show("Müşteri e-fatura kapsamında değil? e-fatura göndermek istediğinize eminmisiniz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    //        {
                    //            _E_FATURA_TYPE = 1;
                    //        }
                    //        else
                    //        {
                    //            break;
                    //        }
                    //    }
                    //}
                }

                //_E_FATURA_TYPE = (int)dr["EINVOICE"];

                string FATURA_VARYOK_KONTROL = Pdp._FATURA_VAR_YOK_KONTROL(dr["NUMBER"].ToString(), dr["TAX_ID"].ToString());
                string FATURA_AKTARIM_DURUMU = "";
                if (FATURA_VARYOK_KONTROL == string.Empty)
                {
                    FATURA_AKTARIM_DURUMU = Pdp._Insert(dr["NUMBER"].ToString(), _E_FATURA_TYPE, _TEMEL_TICARI, _FATURA_SERISI, dr["CODE"].ToString(), _GLOBAL_PARAMETERS._SIRKET_NO);
                } 
                backgroundWorkers.ReportProgress((ix));
            }
        }
        private void backgroundWorkers_DoWork(object sender, DoWorkEventArgs e)
        {
            if ((backgroundWorkers.CancellationPending == true))
            {
                e.Cancel = true;
            }
            else
            {
                // Perform a time consuming operation and report progress.
                System.Threading.Thread.Sleep(500);
                LOGO_AKATARIMI_BASLAT();
            } 
        }

        private void backgroundWorkers_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            BR_PROGRESS_BAR.EditValue = e.ProgressPercentage; 
        }

        private void backgroundWorkers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("You've cancelled the backgroundworker!");
            }
            else
            {
                BR_INFO.Caption = "İŞLEM TAMAMLANDI";  
                BR_SELECT_ROW_FATURA_NO.Caption = ""; 
                DATA_LOAD_BEKLEMEDE( );
                STLINE("0", "00000000-0000-0000-0000-000000000000", "0");
            } 
            if (BTN_AUTO_UPDATE.EditValue.ToString() == "True")
            {
           
                BR_SELECT_ROW_FATURA_NO.Caption = "";
                DATA_LOAD_BEKLEMEDE( ); 
                re_PROGRESS_BAR.Maximum = dataSet.Tables[0].Rows.Count - 1;
                backgroundWorkers.RunWorkerAsync();//this invokes the DoWork event   

            }
            else
            {
                BTN_LOGO_SECILENLERI_AKATAR.Enabled = true;
                BTN_ERP_AKTARIM.Enabled = true;
                BR_SELECT_ROW_FATURA_NO.Caption = "";
                DATA_LOAD_BEKLEMEDE();
                STLINE("0", "00000000-0000-0000-0000-000000000000", "0");
            }
        }

        private void MN_LOGOYA_AKTAR_Click(object sender, EventArgs e)
        {
            int intFirmNo = Convert.ToInt32(_GLOBAL_PARAMETERS._SIRKET_NO);
            if (!_GLOBAL_PARAMETERS.Global.UnityApp.Connected)
            {
                _GLOBAL_PARAMETERS.Global.UnityApp.Login(_GLOBAL_PARAMETERS._KULLANICI_ADI_SOYADI, _GLOBAL_PARAMETERS._KULLANICI_PASSWORD, intFirmNo, 1); 
            }

            _ERP_AKTARIMINA_BASLA();  
        }

        private void MN_TUMUNU_SEC_Click(object sender, EventArgs e)
        {
            gridView_LIST.SelectAll();

        }

        private void MN_ARSIVE_AKTAR_Click(object sender, EventArgs e)
        {
            DialogResult c = MessageBox.Show("Arşive Göndermek istediğinizden eminmisiniz.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (c == DialogResult.Yes)
            {
                SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
                myConnections.Open();
                int[] selectedRows = gridView_LIST.GetSelectedRows();
                for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
                {
                    DateTime dtm = DateTime.Now;
                    DataRow dr = gridView_LIST.GetDataRow(selectedRows[ix]);

                    using (SqlCommand myCmd = new SqlCommand())
                    {
                        myCmd.CommandText += "  UPDATE dbo.FTR_LG_INVOICE  SET AKTARIM_DURUMU='ARŞİVEATILDI', AKTARIM_SORUMLUSU=@AKTARIM_SORUMLUSU ,AKTARIM_TARIHI=@AKTARIM_TARIHI ,AKTARIM_NOTU=@AKTARIM_NOTU  WHERE SIRKET_KODU=@SIRKET_KODU and  NUMBER=@TASLAK_FATURA_NO ";
                        //myCmd.CommandText += "  UPDATE dbo.FTR_LG_STLINE  WHERE SIRKET_KODU=@SIRKET_KODU and  NUMBER=@TASLAK_FATURA_NO ";
                        myCmd.Parameters.AddWithValue("@TASLAK_FATURA_NO", dr["NUMBER"].ToString());
                        myCmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                        myCmd.Parameters.AddWithValue("@AKTARIM_SORUMLUSU", _GLOBAL_PARAMETERS._KULLANICI_MAKINASI);
                        myCmd.Parameters.AddWithValue("@AKTARIM_TARIHI", dtm.ToString("yyyy-MM-dd"));
                        myCmd.Parameters.AddWithValue("@AKTARIM_NOTU", "MANUEL ARŞİVE ATILDI");
                        myCmd.Connection = myConnections;
                        myCmd.ExecuteNonQuery();
                        myCmd.Connection.Close();
                        myConnections.Close();
                    }
                    _GLOBAL_PARAMETERS.LOG_ISLEMLERI LF = new _GLOBAL_PARAMETERS.LOG_ISLEMLERI();
                    LF.LOG_AKTARIMI(dr["TIPI"].ToString(), dr["NUMBER"].ToString(), "ARŞİVE ATILDI", dr["TOTAL_NET"].ToString(), dr["TITLE"].ToString(), "", dr["DEFNFLD_PLAN_KODU"].ToString(), dr["NOTES1"].ToString(), "");
                }
                BR_SELECT_ROW_FATURA_NO.Caption = "";
                DATA_LOAD_BEKLEMEDE();
                STLINE("0", "00000000-0000-0000-0000-000000000000", "0");
            }
        }

        private void MN_ARSIVDEN_GERIAL_Click(object sender, EventArgs e)
        {
          
             DialogResult c = MessageBox.Show("Arşivden geri almak istediğinize eminmisiniz.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
             if (c == DialogResult.Yes)
             {
                 SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB);
                 myConnections.Open();
                 int[] selectedRows = gridView_LIST.GetSelectedRows();
                 for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
                 {
                     DateTime dtm = DateTime.Now;
                     DataRow dr = gridView_LIST.GetDataRow(selectedRows[ix]);


                     using (SqlCommand myCmd = new SqlCommand())
                     {
                         myCmd.CommandText = "  UPDATE dbo.FTR_LG_INVOICE  SET AKTARIM_DURUMU='BEKLEMEDE', AKTARIM_SORUMLUSU=@AKTARIM_SORUMLUSU ,AKTARIM_TARIHI=@AKTARIM_TARIHI ,AKTARIM_NOTU=@AKTARIM_NOTU  WHERE SIRKET_KODU=@SIRKET_KODU and  NUMBER=@TASLAK_FATURA_NO ";
                         //myCmd.CommandText += "  UPDATE dbo.FTR_LG_STLINE  WHERE SIRKET_KODU=@SIRKET_KODU and  NUMBER=@TASLAK_FATURA_NO ";
                         myCmd.Parameters.AddWithValue("@TASLAK_FATURA_NO", dr["NUMBER"].ToString());
                         myCmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                         myCmd.Parameters.AddWithValue("@AKTARIM_SORUMLUSU", _GLOBAL_PARAMETERS._KULLANICI_MAKINASI);
                         myCmd.Parameters.AddWithValue("@AKTARIM_TARIHI", dtm.ToString("yyyy-MM-dd"));
                         myCmd.Parameters.AddWithValue("@AKTARIM_NOTU", "MANUEL ARŞİVDEN ALINDI");
                         myCmd.Connection = myConnections;
                         myCmd.ExecuteNonQuery();
                         myCmd.Connection.Close();
                         myConnections.Close();
                     }

                     _GLOBAL_PARAMETERS.LOG_ISLEMLERI LF = new _GLOBAL_PARAMETERS.LOG_ISLEMLERI();
                     LF.LOG_AKTARIMI(dr["TIPI"].ToString(), dr["NUMBER"].ToString(), "ARŞİVDEN GERİ ALINDI", dr["TOTAL_NET"].ToString(), dr["TITLE"].ToString(), "", dr["DEFNFLD_PLAN_KODU"].ToString(), dr["NOTES1"].ToString(), "");


                 }
                 BR_SELECT_ROW_FATURA_NO.Caption = "";
                 DATA_LOAD_BEKLEMEDE();
                 STLINE("0", "00000000-0000-0000-0000-000000000000", "0");
             }
        }

        private void MN_FIRMA_DEGISTIR_Click(object sender, EventArgs e)
        {
               DialogResult c = MessageBox.Show("Faturayı farklı bir firmaya aktrmak istediğinize eminmisiniz.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
               if (c == DialogResult.Yes)
               {

                   string OLD_FIRMA = _GLOBAL_PARAMETERS._SIRKET_KODU.ToString();
                   LOGIN frm = new LOGIN();
                   frm.ShowDialog();

                   if (frm.BTN_SELECT != "VAZGEC")
                   {
                       FIRMAYA_AKTAR(OLD_FIRMA, _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                       BTM_FIRMA_ID.Caption = _GLOBAL_PARAMETERS._SIRKET_NO;
                       BTM_FIRMA_NAME.Caption = _GLOBAL_PARAMETERS._SIRKET_ADI;
                       BTM_FIRMA_KODU.Caption = _GLOBAL_PARAMETERS._SIRKET_KODU;
                       for (int i = this.MdiChildren.Length - 1; 0 <= i; i--)
                       {
                           this.MdiChildren[i].Close();
                       }

                       //int a=((Form)this.MdiParent).Controls["ribbonControl"].Controls.Count;                
                       //Masters.BTM_USER_NAME.Caption = Masters._username;
                       //((Masters)this.Owner).Controls["BTM_FIRMA_KODU"].Text = Masters._username;
                       //((Masters)this.Owner).BTM_FIRMA_KODU.Caption = Masters._firmNo;
                       //((Masters)this.Owner).BTM_FIRMA_NAME.Caption = Masters._firName;                  
                       //this.Show();
                       //Masters._CONTROL.Controls.Clear();
                       //Sales.Inbox Inbx = new Sales.Inbox();
                       //Inbx.Dock = DockStyle.Fill;
                       //Inbx.Text = " Purchase / Inbox ( Satınalma ) - " + 10;
                       //Masters._CONTROL.Controls.Add(Inbx);
                       //Inbx.Show();
                       //BTM_USER_NAME.Caption = Masters._username;
                       //BTM_FIRMA_KODU.Caption = Masters._firmNo;
                       //BTM_FIRMA_NAME.Caption = Masters._firName;
                   }
                   BR_SELECT_ROW_FATURA_NO.Caption = "";
                   DATA_LOAD_BEKLEMEDE();
                   STLINE("0", "00000000-0000-0000-0000-000000000000", "0");
               }
        }

        private void FIRMAYA_AKTAR(string OLD_FIRMA, string NEW_FIRMA_KODU)
        {
            int[] selectedRows = gridView_LIST.GetSelectedRows();
            for (int ix = 0; ix <= selectedRows.Length - 1; ix++)
            {
                DataRow dr = gridView_LIST.GetDataRow(selectedRows[ix]);

                string V_RETURN = "FATURA YOK";
                using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                {
                    myConnections.Open();
                    SqlCommand myCommands = new SqlCommand();
                    myCommands.Connection = myConnections;
                    myCommands.CommandText = "SELECT  NUMBER  from dbo.FTR_LG_INVOICE   WHERE SIRKET_KODU=@SIRKET_KODU  AND TASLAK_FATURA_NO=@TASLAK_FATURA_NO  ";
                    myCommands.Parameters.AddWithValue("@TASLAK_FATURA_NO", dr["TASLAK_FATURA_NO"].ToString().Replace(" ", "").Trim());
                    myCommands.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU.ToString());
                    SqlDataReader sqlreaders = myCommands.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sqlreaders.Read())
                    {
                        V_RETURN = String.Format("BU NUMARA İLE FATURA VAR ({0})", dr["TASLAK_FATURA_NO"]);
                    }
                    sqlreaders.Close();
                    myCommands.Connection.Close();
                }

                if (V_RETURN == "FATURA YOK")
                {

                    using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                    {
                        using (SqlCommand myCommandSubLineEx = new SqlCommand())
                        {
                            myCommandSubLineEx.CommandText += "INSERT INTO FTR_LG_INVOICE   ( AKTARIM_DURUMU, SIRKET_KODU, SIPARISI_VEREN, DEPARTMAN, BELGE_TYPE, TYPE, TASLAK_FATURA_NO, NUMBER, DOC_TRACK_NR, EINVOICE, ACCOUNT_TYPE, DEFNFLD_MUSTERI_KODU, CODE, TITLE, ADDRESS1, ADDRESS2, CITY, POSTAL_CODE, TELEPHONE1, FAX, TAX_OFFICE, TAX_ID, DATE, DOC_DATE, DOC_NUMBER, AUXIL_CODE, ARP_CODE, GL_CODE, VAT_RATE, ADD_DISCOUNTS, TOTAL_DISCOUNTS, TOTAL_VAT, TOTAL_GROSS, TOTAL_NET, TOTAL_DISCOUNTED, NOTES1, NOTES2, NOTES3, NOTES4, CURR_INVOICE, TC_NET, RC_XRATE, RC_NET, TC_XRATE, CURRSEL_TOTALS, CURRSEL_DETAILS, DEFNFLD_PAZARLAMA_SIRKETI_KODU, DEFNFLD_LEVEL_, DEFNFLD_MODULENR, DEFNFLD_PLAN_KODU,DEFNFLD_MECRA_TURU, DEFNFLD_FATURA_BASKI_SEKLI, DEFNFLD_FAKTORING_SIRKETI_KODU, DEFNFLD_ILGILI_FATURA_NO, DEFNFLD_SIPARISI_VEREN, DEFNFLD_DEPARTMAN, DEFNFLD_BOLGE_KODU, DEFNFLD_ILGILI_IS_UNITESI, DEFNFLD_EFATURA_KODU, DEFNFLD_PO_DETAILS, DEFNFLD_IS_KODU, DEFNFLD_ILGILI_KISI_ADI_SOYADI, DEFNFLD_ILGILI_KISI_MAIL_ADRESI, DEFNFLD_NOTES, DEFNFLD_XML_ATTRIBUTE, PAYMENT_DATE, PAYMENT_MODULENR, PAYMENT_TRCODE, PAYMENT_TOTAL, PAYMENT_PROCDATE, PAYMENT_DISCOUNT_DUEDATE, TRCURR, TRRATE, PAYMENT_MODIFIED, PAYMENT_PAY_NO, TRNET, PAYTR_CURR, PAYTR_RATE, PAYTR_NET, GLOBAL_CODE, PAYMENT_DISCTRLIST, PAYMENT_DISCTRDELLIST, INVOICE_Id, DEDUCTIONPART1, DEDUCTIONPART2, PROJECT_CODE, AKTARIM_SORUMLUSU, AKTARIM_TARIHI, AKTARIM_NOTU)  ";
                            myCommandSubLineEx.CommandText += " select  AKTARIM_DURUMU, '" + _GLOBAL_PARAMETERS._SIRKET_KODU.ToString() + "', SIPARISI_VEREN, DEPARTMAN, BELGE_TYPE, TYPE, TASLAK_FATURA_NO, NUMBER, DOC_TRACK_NR, EINVOICE, ACCOUNT_TYPE, DEFNFLD_MUSTERI_KODU, CODE, TITLE, ADDRESS1, ADDRESS2, CITY, POSTAL_CODE, TELEPHONE1, FAX, TAX_OFFICE, TAX_ID, DATE, DOC_DATE, DOC_NUMBER, AUXIL_CODE, ARP_CODE, GL_CODE, VAT_RATE, ADD_DISCOUNTS, TOTAL_DISCOUNTS, TOTAL_VAT, TOTAL_GROSS, TOTAL_NET, TOTAL_DISCOUNTED, NOTES1, NOTES2, NOTES3, NOTES4, CURR_INVOICE, TC_NET, RC_XRATE, RC_NET, TC_XRATE, CURRSEL_TOTALS, CURRSEL_DETAILS, DEFNFLD_PAZARLAMA_SIRKETI_KODU, DEFNFLD_LEVEL_, DEFNFLD_MODULENR, DEFNFLD_PLAN_KODU,DEFNFLD_MECRA_TURU, DEFNFLD_FATURA_BASKI_SEKLI, DEFNFLD_FAKTORING_SIRKETI_KODU, DEFNFLD_ILGILI_FATURA_NO, DEFNFLD_SIPARISI_VEREN, DEFNFLD_DEPARTMAN, DEFNFLD_BOLGE_KODU, DEFNFLD_ILGILI_IS_UNITESI, DEFNFLD_EFATURA_KODU, DEFNFLD_PO_DETAILS, DEFNFLD_IS_KODU, DEFNFLD_ILGILI_KISI_ADI_SOYADI, DEFNFLD_ILGILI_KISI_MAIL_ADRESI, DEFNFLD_NOTES, DEFNFLD_XML_ATTRIBUTE, PAYMENT_DATE, PAYMENT_MODULENR, PAYMENT_TRCODE, PAYMENT_TOTAL, PAYMENT_PROCDATE, PAYMENT_DISCOUNT_DUEDATE, TRCURR, TRRATE, PAYMENT_MODIFIED, PAYMENT_PAY_NO, TRNET, PAYTR_CURR, PAYTR_RATE, PAYTR_NET, GLOBAL_CODE, PAYMENT_DISCTRLIST, PAYMENT_DISCTRDELLIST, INVOICE_Id, DEDUCTIONPART1, DEDUCTIONPART2, PROJECT_CODE, AKTARIM_SORUMLUSU, AKTARIM_TARIHI, AKTARIM_NOTU from FTR_LG_INVOICE WHERE SIRKET_KODU='" + OLD_FIRMA + "' AND TASLAK_FATURA_NO='" + dr["NUMBER"].ToString() + "'";
                            myCommandSubLineEx.CommandText += " select ID from FTR_LG_INVOICE   WHERE   (TASLAK_FATURA_NO='" + dr["NUMBER"].ToString() + "')";
                            myCommandSubLineEx.CommandType = System.Data.CommandType.Text;
                            myCommandSubLineEx.Connection = myConnections;
                            myConnections.Open();
                            SqlDataReader myReaderSubLineEx = myCommandSubLineEx.ExecuteReader(CommandBehavior.CloseConnection);
                            while (myReaderSubLineEx.Read())
                            {
                                using (SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                                {
                                    myConnectionTable.Open();
                                    SqlCommand myCmd = new SqlCommand();
                                    myCmd.CommandText += "INSERT INTO FTR_LG_STLINE   ( SIRKET_KODU, INVOICE_REF, INVOICE_NUMBER, TASLAK_FATURA_NO, TYPE, MASTER_CODE, NAME, GL_CODE1, GL_CODE2, AUXIL_CODE, QUANTITY, PRICE, TOTAL, CURR_PRICE, PC_PRICE, CURR_TRANSACTION, TC_XRATE, DISCOUNT_DISTR, DESCRIPTION, UNIT_GLOBAL_CODE, UNIT_CODE, UNIT_CONV1, UNIT_CONV2, VAT_RATE, VAT_AMOUNT, VAT_BASE, TOTAL_NET, EDT_CURR, EDT_PRICE, PROJECT_CODE, TRANSACTION_REF, STLINE_REF, MODULENR, LEVEL_, PLAN_KODU, SEHIR, FILM_ADI, SURE, TARIH, OLCU, TARIFE, CANDEDUCT, DEDUCTIONPART1, DEDUCTION_PART2, XML_ATTRIBUTE, TRANSACTION_Id, DETAIL_LEVEL, DISCOUNT_RATE) ";
                                    myCmd.CommandText += " select '" + _GLOBAL_PARAMETERS._SIRKET_KODU.ToString() + "','" + myReaderSubLineEx["ID"] + "', INVOICE_NUMBER, TASLAK_FATURA_NO, TYPE, MASTER_CODE, NAME, GL_CODE1, GL_CODE2, AUXIL_CODE, QUANTITY, PRICE, TOTAL, CURR_PRICE, PC_PRICE, CURR_TRANSACTION, TC_XRATE, DISCOUNT_DISTR, DESCRIPTION, UNIT_GLOBAL_CODE, UNIT_CODE, UNIT_CONV1, UNIT_CONV2, VAT_RATE, VAT_AMOUNT, VAT_BASE, TOTAL_NET, EDT_CURR, EDT_PRICE, PROJECT_CODE, TRANSACTION_REF, STLINE_REF, MODULENR, LEVEL_,  PLAN_KODU, SEHIR, FILM_ADI, SURE, TARIH, OLCU, TARIFE, CANDEDUCT, DEDUCTIONPART1, DEDUCTION_PART2, XML_ATTRIBUTE, TRANSACTION_Id, DETAIL_LEVEL, DISCOUNT_RATE from FTR_LG_STLINE    WHERE SIRKET_KODU= '" + OLD_FIRMA + "' AND   (INVOICE_NUMBER='" + dr["NUMBER"].ToString() + "') ";

                                    myCmd.Connection = myConnectionTable;
                                    myCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }




                    DateTime dtm = DateTime.Now;
                    using (SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
                    {
                        myConnections.Open();
                        using (SqlCommand myCmd = new SqlCommand())
                        {
                            myCmd.CommandText = "  UPDATE dbo.FTR_LG_INVOICE   SET AKTARIM_DURUMU='AKTARILDI', AKTARIM_SORUMLUSU=@AKTARIM_SORUMLUSU,AKTARIM_TARIHI=@AKTARIM_TARIHI,AKTARIM_NOTU=@AKTARIM_NOTU  WHERE  SIRKET_KODU=@SIRKET_KODU AND (TASLAK_FATURA_NO=@TASLAK_FATURA_NO) ";

                            myCmd.Parameters.AddWithValue("@SIRKET_KODU", OLD_FIRMA);
                            myCmd.Parameters.AddWithValue("@TASLAK_FATURA_NO", dr["TASLAK_FATURA_NO"]);
                            myCmd.Parameters.AddWithValue("@AKTARIM_SORUMLUSU", _GLOBAL_PARAMETERS._KULLANICI_MAIL);
                            myCmd.Parameters.AddWithValue("@AKTARIM_TARIHI", dtm.ToString("yyyy-MM-dd hh:mm:ss"));
                            myCmd.Parameters.AddWithValue("@AKTARIM_NOTU", "BASARILI");
                            myCmd.Connection = myConnections;
                            myCmd.ExecuteNonQuery();
                        }
                        using (SqlCommand myCmd = new SqlCommand())
                        {
                            myCmd.CommandText = " UPDATE dbo.FTR_LG_STLINE   SET AKTARIM_DURUMU='AKTARILDI'  WHERE  SIRKET_KODU=@SIRKET_KODU AND (TASLAK_FATURA_NO=@TASLAK_FATURA_NO) ";
                            myCmd.Parameters.AddWithValue("@SIRKET_KODU", OLD_FIRMA);
                            myCmd.Parameters.AddWithValue("@TASLAK_FATURA_NO", dr["TASLAK_FATURA_NO"]);
                            myCmd.Connection = myConnections;
                            myCmd.ExecuteNonQuery();
                        }

                        _GLOBAL_PARAMETERS.LOG_ISLEMLERI LF = new _GLOBAL_PARAMETERS.LOG_ISLEMLERI();
                        LF.LOG_AKTARIMI(dr["TIPI"].ToString(), dr["NUMBER"].ToString(), "KAYIT", dr["TOTAL_NET"].ToString(), dr["TITLE"].ToString(), "", dr["DEFNFLD_PLAN_KODU"].ToString(), dr["NOTES1"].ToString(), "");
                        myConnections.Close();
                    }
                }
                else
                { MessageBox.Show(V_RETURN); }
            }

        }

        private void timers_Tick(object sender, EventArgs e)
        {
            BR_SELECT_ROW_FATURA_NO.Caption = "";
            DATA_LOAD_BEKLEMEDE();
            STLINE("0", "00000000-0000-0000-0000-000000000000", "0");


            info.Text = "Son İndirme : " + DateTime.Now.ToShortTimeString() + Environment.NewLine;
            info.Text += "Fatura Sayısı : " + gridView_LIST.RowCount.ToString() + Environment.NewLine;
            alertControls.Show(this, info);

        }

        private void ALIM_FATURASI_AKTARIM_Deactivate(object sender, EventArgs e)
        {
            timers.Start();
        }

        private void ALIM_FATURASI_AKTARIM_Activated(object sender, EventArgs e)
        {
            timers.Stop ();
        }

        private void BTN_NEW_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            ALIM_FATURASI_BIRLESTIR edt = new ALIM_FATURASI_BIRLESTIR("","");
            edt.ShowDialog();

            if (BTN_FATURA_DURUMU.EditValue.ToString() == "Aktarılmamış Faturalar") DATA_LOAD_BEKLEMEDE();
            if (BTN_FATURA_DURUMU.EditValue.ToString() == "Aktarılmış Faturalar") DATA_LOAD_AKTARILDI();
        }

        private void ALIM_FATURASI_AKTARIM_FormClosing(object sender, FormClosingEventArgs e)
        {
            timers.Stop();
        } 

       
    }
}