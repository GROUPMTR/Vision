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

namespace VISION._LOCAL_ADMIN.KULLANICI
{
    public partial class KULLANICI_LISTESI : DevExpress.XtraEditors.XtraForm
    {

        public string _KULLANICI_KODU;
        public int _KULLANICI_ID;
        DataView dv;
        public KULLANICI_LISTESI()
        {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            DATA_LOAD();
        }
        private void DATA_LOAD()
        {
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter("SELECT * FROM  dbo.ADM_KULLANICI ", myConnection);
                DataSet MyDataSet = new DataSet();
                MySqlDataAdapter.Fill(MyDataSet, "dbo_USER");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                gridCntrl_LIST.DataSource = dv;
            }
        }

        private void BTN_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
        DataRow dr;
        private void gridCntrl_LIST_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi =
                      GRD_VIEW_LISTE.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));
            dr = GRD_VIEW_LISTE.GetDataRow(hi.RowHandle);
            if (dr != null)
            { 
                _KULLANICI_KODU = (string)dr["MAIL_ADRESI"];
                _KULLANICI_ID = (int)dr["ID"]; 
            }
            Close();
        }

        private void BTN_GUNCELLE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            myConnection.Open();
            for (int XS = 0; XS <= GRD_VIEW_LISTE.RowCount - 1; XS++)
            {
                string UPDATE_NAME = "";
                DataRow DR = GRD_VIEW_LISTE.GetDataRow(XS);
                if ((string)DR["MAIL_ADRESI"] != string.Empty)
                {
                    string[] Ones = DR["MAIL_ADRESI"].ToString().Split('@');
                    string NEWSADI = ""; string NEWSOYADI = "";
                    for (int X = 0; X <= Ones.Length - 1; X++)
                    {

                        string[] METIN = Ones[0].ToString().Split('.');

                        char[] ADI = METIN[0].Trim().ToString().ToCharArray();
                          NEWSADI = "";
                        for (int i = 0; i <= ADI.Length - 1; i++)
                        {
                            if (i == 0) NEWSADI += ADI[i].ToString().ToUpper ();
                            else
                            NEWSADI += ADI[i].ToString();

                        }
                        char[] SOYADI = METIN[1].Trim().ToString().ToCharArray();
                          NEWSOYADI= "";
                        for (int i = 0; i <= SOYADI.Length - 1; i++)
                        {
                            if (i == 0) NEWSOYADI += SOYADI[i].ToString().ToUpper();
                            else
                            NEWSOYADI += SOYADI[i].ToString(); 
                        } 
                       
                    }
                     UPDATE_NAME= NEWSADI + "." +NEWSOYADI +"@"+ Ones[1].ToString();
                }

                SqlCommand myCmd = new SqlCommand();
                myCmd.CommandText = "UPDATE  dbo.ADM_KULLANICI SET    MAIL_ADRESI=@MAIL_ADRESI   where  ID=@ID ";
                myCmd.Parameters.AddWithValue("@ID", DR["ID"]);
                myCmd.Parameters.AddWithValue("@MAIL_ADRESI", UPDATE_NAME);
                myCmd.Connection = myConnection;
                myCmd.ExecuteNonQuery();


                SqlCommand mCmd = new SqlCommand();
                mCmd.CommandText = "UPDATE  dbo.TODO_TIME_SHEET SET    MAIL_ADRESI=@MAIL_ADRESI,Location=@MAIL_ADRESI   where  MAIL_ADRESI=@MAIL_ADRESI ";
                mCmd.Parameters.AddWithValue("@MAIL_ADRESI", UPDATE_NAME);
                mCmd.Connection = myConnection;
                mCmd.ExecuteNonQuery();     



            }


          
        }

    }
}