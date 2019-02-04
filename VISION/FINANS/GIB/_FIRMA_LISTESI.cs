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

namespace VISION.FINANS.GIB
{
    public partial class _FIRMA_LISTESI : DevExpress.XtraEditors.XtraForm
    {
        private DevExpress.Utils.WaitDialogForm dlg; 
        public _FIRMA_LISTESI()
        {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            this.TopMost = true;

            DATA_LOAD();

        }

        private void DATA_LOAD()
        {
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter("SELECT * FROM  dbo.FTR_GIB_FIRMA_LISTESI ", myConnection);
                DataSet MyDataSet = new DataSet();
                MySqlDataAdapter.Fill(MyDataSet, "dbo_USER");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                gridCntrl_LIST.DataSource = dv;
            }

        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
        public void CreateWaitDialog()
        {
            dlg = new DevExpress.Utils.WaitDialogForm("Loading Components...");
        }
        public void SetWaitDialogCaption(string fCaption)
        {
            if (dlg != null)
                dlg.Caption = fCaption;
        }
        private void BR_GIB_VERILERI_INDIR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID == "") VISION.FINANS.UBL.IZIBIZ_CLASS.izibiz_login();

            if (VISION.FINANS.UBL.IZIBIZ_CLASS.SESSIONID != "")
            {
                CreateWaitDialog();
                WebService.IziBizSrv.GetUserListRequest girq = new WebService.IziBizSrv.GetUserListRequest();
                girq.REQUEST_HEADER = VISION.FINANS.UBL.IZIBIZ_CLASS.htype;

                WebService.IziBizSrv.GetUserListResponse cv = VISION.FINANS.UBL.IZIBIZ_CLASS.I2IEInv.GetUserList(girq);
                SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                myConnectionTable.Open();


                if (cv.Items.Length > 0)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string HEADER_TABLE_SQL = " TRUNCATE TABLE dbo.FTR_GIB_FIRMA_LISTESI ;  ";
                        cmd.CommandText = HEADER_TABLE_SQL;
                        cmd.Connection = myConnectionTable;
                        cmd.ExecuteNonQuery();
                    }
                }

                re_Progress.Maximum = cv.Items.Length - 1;
                re_Progress.Minimum = 0;
                re_Progress.Step = 1;
                for (int i = 0; i < cv.Items.Length - 1; i++)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string HEADER_TABLE_SQL = @" INSERT INTO dbo.FTR_GIB_FIRMA_LISTESI (ALIAS, IDENTIFIER, REGISTER_TIME, TITLE, TYPE)  Values (@ALIAS, @IDENTIFIER, @REGISTER_TIME, @TITLE, @TYPE) ";
                        cmd.CommandText = HEADER_TABLE_SQL;
                        cmd.Parameters.AddWithValue("@ALIAS", cv.Items[i].ALIAS.ToString());
                        cmd.Parameters.AddWithValue("@IDENTIFIER", cv.Items[i].IDENTIFIER.ToString());
                        cmd.Parameters.AddWithValue("@REGISTER_TIME", cv.Items[i].REGISTER_TIME.ToString());
                        cmd.Parameters.AddWithValue("@TITLE", cv.Items[i].TITLE.ToString());
                        cmd.Parameters.AddWithValue("@TYPE", cv.Items[i].TYPE.ToString());
                        cmd.Connection = myConnectionTable;
                        cmd.ExecuteNonQuery();
                    }
                    br_Progress.EditValue = i;
                    br_Progress.Refresh();
                    SetWaitDialogCaption(cv.Items.Length.ToString () +"/"+  br_Progress.EditValue.ToString());
                }
                myConnectionTable.Close();

                DATA_LOAD();
                if (dlg != null) dlg.Close();
                //  MessageBox.Show("İşlem Tamamlandı");


                TAXNR_UPDATE();
                TCK_NO_UPDATE();

                MessageBox.Show("ERP verileriniz güncellendi");
            }
            else
            {
                if (dlg != null) dlg.Close();
                MessageBox.Show("izibiz sisteminden session alınamadı.");
            } 
        }


        private void TAXNR_UPDATE()
        {

            SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB); myConnections.Open();
            SqlConnection ConUpdate = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP); ConUpdate.Open();

            using (SqlConnection SqlConFrm = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                SqlConFrm.Open();
                string SQLS = @"select  *  from dbo.ADM_SIRKET_DONEMLERI where DEFAULT_='True' ";
                using (SqlCommand CmndFrm = new SqlCommand(SQLS, SqlConFrm))
                {
                    SqlDataReader RdrFrm = CmndFrm.ExecuteReader();
                    while (RdrFrm.Read())
                    {
                        string FIRMA_NO = RdrFrm["SIRKET_NO"].ToString(); 

                        using (SqlConnection SqlCon = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP))
                        {
                            SqlCon.Open();
                            string SQL = @"select TAXNR,TCKNO,POSTLABELCODE ,SENDERLABELCODE ,ACCEPTEINV ,EINVOICETYPE  from dbo.LG_" + FIRMA_NO + "_CLCARD  WHERE  (CARDTYPE <> 22) and  (TAXNR NOT LIKE '1111111%') AND (LEN(TAXNR)=10)AND (TAXNR NOT LIKE '33333333%') AND LEN(TCKNO)=0";
                            using (SqlCommand myCommand = new SqlCommand(SQL, SqlCon))
                            {
                                SqlDataReader myRdrERP = myCommand.ExecuteReader();
                                while (myRdrERP.Read())
                                {
                                    string Kontrol = " SELECT IDENTIFIER, ALIAS  FROM  dbo.FTR_GIBUSERS_LIST where IDENTIFIER='" + myRdrERP["TAXNR"] + "' GROUP BY IDENTIFIER, ALIAS ";
                                    using (SqlCommand myCmd = new SqlCommand(Kontrol, myConnections))
                                    {
                                        SqlDataReader rdr = myCmd.ExecuteReader();
                                        while (rdr.Read())
                                        {
                                            int gb = rdr["ALIAS"].ToString().IndexOf("gb@");
                                            int pk = rdr["ALIAS"].ToString().IndexOf("pk@");

                                            if (gb > 0)
                                            { 
                                                if (rdr["ALIAS"].ToString() != myRdrERP["SENDERLABELCODE"].ToString())
                                                {
                                                    using (SqlCommand cmd = new SqlCommand())
                                                    {
                                                        cmd.CommandText += "  UPDATE  dbo.LG_" + FIRMA_NO + "_CLCARD SET  SENDERLABELCODE='" + rdr["ALIAS"].ToString() + "' WHERE  (TAXNR='" + myRdrERP["TAXNR"].ToString() + "')";
                                                        cmd.Connection = ConUpdate;
                                                        cmd.ExecuteNonQuery();
                                                    }
                                                } 
                                            }

                                            if (pk > 0)
                                            {

                                                if (rdr["ALIAS"].ToString() != myRdrERP["POSTLABELCODE"].ToString())
                                                {
                                                    using (SqlCommand cmd = new SqlCommand())
                                                    {
                                                        cmd.CommandText += "  UPDATE  dbo.LG_" + FIRMA_NO + "_CLCARD SET POSTLABELCODE='" + rdr["ALIAS"].ToString() + "'  WHERE  (TAXNR='" + myRdrERP["TAXNR"].ToString() + "')";
                                                        cmd.Connection = ConUpdate;
                                                        cmd.ExecuteNonQuery();
                                                    }
                                                }
                                            }
                                        }
                                        rdr.Close();
                                    }
                                }
                                myRdrERP.Close();
                            }
                        }
                    }
                }
            } 
        }

        private void TCK_NO_UPDATE()
        { 

            SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB); myConnections.Open();
            SqlConnection ConUpdate = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP); ConUpdate.Open();

            using (SqlConnection SqlConFrm = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            {
                SqlConFrm.Open();
                string SQLS = @"select  *  from dbo.ADM_SIRKET_DONEMLERI where DEFAULT_='True' ";
                using (SqlCommand CmndFrm = new SqlCommand(SQLS, SqlConFrm))
                {
                    SqlDataReader RdrFrm = CmndFrm.ExecuteReader();
                    while (RdrFrm.Read())
                    {
                        string FIRMA_NO = RdrFrm["SIRKET_NO"].ToString(); 
                        using (SqlConnection SqlCon = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP))
                        {
                            SqlCon.Open();
                            //string SQL = @"select TAXNR,TCKNO,POSTLABELCODE ,SENDERLABELCODE ,ACCEPTEINV ,EINVOICETYPE  from dbo.LG_" + FIRMA_NO + "_CLCARD  WHERE  (CARDTYPE <> 22) and  (TAXNR NOT LIKE '1111111%') AND (LEN(TAXNR)=10)AND (TAXNR NOT LIKE '33333333%') AND LEN(TCKNO)=0";
                            string SQL = "select TAXNR,TCKNO,POSTLABELCODE ,SENDERLABELCODE ,ACCEPTEINV ,EINVOICETYPE from dbo.LG_" + FIRMA_NO + "_CLCARD WHERE  (CARDTYPE <> 22) and  (TCKNO NOT LIKE '1111111%') AND (LEN(TCKNO)=11)AND (TCKNO NOT LIKE '33333333%') AND LEN(TAXNR)=0";
                            using (SqlCommand myCommand = new SqlCommand(SQL, SqlCon))
                            {
                                SqlDataReader myRdrERP = myCommand.ExecuteReader();
                                while (myRdrERP.Read())
                                {
                                    string Kontrol = " SELECT IDENTIFIER, ALIAS  FROM  dbo.FTR_GIBUSERS_LIST where IDENTIFIER='" + myRdrERP["TCKNO"] + "' GROUP BY IDENTIFIER, ALIAS ";
                                    using (SqlCommand myCmd = new SqlCommand(Kontrol, myConnections))
                                    {
                                        SqlDataReader rdr = myCmd.ExecuteReader();
                                        while (rdr.Read())
                                        {
                                            int gb = rdr["ALIAS"].ToString().IndexOf("gb@");
                                            int pk = rdr["ALIAS"].ToString().IndexOf("pk@");

                                            if (gb > 0)
                                            { 
                                                if (rdr["ALIAS"].ToString() != myRdrERP["SENDERLABELCODE"].ToString())
                                                {
                                                    using (SqlCommand cmd = new SqlCommand())
                                                    {
                                                        cmd.CommandText += "  UPDATE  dbo.LG_" + FIRMA_NO + "_CLCARD SET  SENDERLABELCODE='" + rdr["ALIAS"].ToString() + "' WHERE  (TCKNO='" + myRdrERP["TCKNO"].ToString() + "')";
                                                        cmd.Connection = ConUpdate;
                                                        cmd.ExecuteNonQuery();
                                                    }
                                                } 
                                            } 
                                            if (pk > 0)
                                            { 
                                                if (rdr["ALIAS"].ToString() != myRdrERP["POSTLABELCODE"].ToString())
                                                {
                                                    using (SqlCommand cmd = new SqlCommand())
                                                    {
                                                        cmd.CommandText += "  UPDATE  dbo.LG_" + FIRMA_NO + "_CLCARD SET POSTLABELCODE='" + rdr["ALIAS"].ToString() + "'  WHERE  (TCKNO='" + myRdrERP["TCKNO"].ToString() + "')";
                                                        cmd.Connection = ConUpdate;
                                                        cmd.ExecuteNonQuery();
                                                    }
                                                }
                                            }
                                        }
                                        rdr.Close();
                                    }
                                }
                                myRdrERP.Close();
                            }
                        }
                    }
                }
            }   
        } 
    }
}