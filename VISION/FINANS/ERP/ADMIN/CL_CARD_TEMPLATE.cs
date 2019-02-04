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

namespace VISION.FINANS.ERP.ADMIN
{
    public partial class CL_CARD_TEMPLATE : DevExpress.XtraEditors.XtraForm
    {
        DataRow dr;
        DataView dv;
        DataView dv_TEMP;
        DataView dv_DEFAULT;
        public CL_CARD_TEMPLATE()
        {
            InitializeComponent();
            this.Tag = "MDIFORM";
            CLIENT_LIST();
        }
        private void CLIENT_LIST()
        {
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string mySelectQuery = "  SELECT * FROM    dbo.ADM_MUSTERI  ";
                SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(mySelectQuery, myConnection);
                DataSet MyDataSet = new DataSet();
                MySqlDataAdapter.Fill(MyDataSet, "dbo_MecraList");
                DataViewManager dvManager = new DataViewManager(MyDataSet);
                dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
                gridCntrl_LIST.DataSource = dv;
            }
        }

        private void BTN_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridCntrl_LIST_DoubleClick(object sender, EventArgs e)
        {
            dr = gridView_LIST.GetFocusedDataRow();
            if (dr != null)
            {
                BR_SELECT_ROW_MUSTERI_KODU.Caption = dr["MUSTERI_KODU"].ToString();
                BR_ID.Caption = dr["ID"].ToString();
                //textBox_DEFAULT.Text = dr["DEFAULT_TEXT"].ToString();
                //textBox_TEMP.Text = dr["TEMP_TEXT"].ToString();
                COMBOBX_KONTROL_ALANI.Text = dr["KONTROL_ALANI"].ToString();
                CHK_DURUMU.Text = dr["DURUMU"].ToString();
                STLINE_DEFAULT(dr["MUSTERI_KODU"].ToString());
                STLINE_TEMP(dr["MUSTERI_KODU"].ToString());
            }
        }

        private void STLINE_DEFAULT(string MUSTERI_KODU)
        {
            if (MUSTERI_KODU != "")
            { 
                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                {
                    string mySelectQuery = " SELECT  *  FROM  dbo.ADM_MUSTERI_PARAMETRE_DEFAULT  WHERE  MUSTERI_KODU=@MUSTERI_KODU";
                    SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(mySelectQuery, myConnection);
                    MySqlDataAdapter.SelectCommand.Parameters.AddWithValue("@MUSTERI_KODU", MUSTERI_KODU);
                    DataSet MyDataSet = new DataSet();
                    MySqlDataAdapter.Fill(MyDataSet, "dbo_MecraList");
                    DataViewManager dvManager = new DataViewManager(MyDataSet);
                    dv_DEFAULT = dvManager.CreateDataView(MyDataSet.Tables[0]);
                    gridCntrl_DEFAULT.DataSource = dv_DEFAULT;
                    myConnection.Close();
                } 
                for (int i = 0; i < 10; i++)
                    gridView_DEFAULT.AddNewRow(); 
            }

            gridView_DEFAULT.RefreshData ();
        }

        private void STLINE_TEMP(string MUSTERI_KODU)
        {
            if (MUSTERI_KODU != "")
            { 
                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                {
                    string mySelectQuery = " SELECT  *  FROM  dbo.ADM_MUSTERI_PARAMETRE_TEMP  WHERE  MUSTERI_KODU=@MUSTERI_KODU";
                    SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(mySelectQuery, myConnection);
                    MySqlDataAdapter.SelectCommand.Parameters.AddWithValue("@MUSTERI_KODU", MUSTERI_KODU);
                    DataSet MyDataSet = new DataSet();
                    MySqlDataAdapter.Fill(MyDataSet, "dbo_MecraList");
                    DataViewManager dvManager = new DataViewManager(MyDataSet);
                    dv_TEMP = dvManager.CreateDataView(MyDataSet.Tables[0]);
                    gridCntrl_TEMP.DataSource = dv_TEMP;
                    myConnection.Close();
                }
                for (int i = 0; i < 10; i++)
                    gridView_TEMP.AddNewRow();

            }

            gridView_TEMP.RefreshData(); 
        }

        private void BTN_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlConnection sql = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            sql.Open();

       
            using (SqlCommand myCmd = new SqlCommand())
            {
                //myCmd.Parameters.AddWithValue("@DEFAULT_TEXT", textBox_DEFAULT.Text);
                //myCmd.Parameters.AddWithValue("@TEMP_TEXT", textBox_TEMP.Text); [DEFAULT_TEXT]=@DEFAULT_TEXT ,[TEMP_TEXT]=@TEMP_TEXT,
                myCmd.Parameters.AddWithValue("@DURUMU", CHK_DURUMU.Text);
                myCmd.Parameters.AddWithValue("@KONTROL_ALANI", COMBOBX_KONTROL_ALANI.Text);
                myCmd.Parameters.AddWithValue("@OZEL_DURUM", dr["OZEL_DURUM"]);
                myCmd.Parameters.AddWithValue("@ID", BR_ID.Caption); 
                myCmd.CommandText = " UPDATE dbo.[ADM_MUSTERI] SET DURUMU=@DURUMU,KONTROL_ALANI=@KONTROL_ALANI,OZEL_DURUM=@OZEL_DURUM WHERE  ID=@ID";
                myCmd.Connection = sql;
                myCmd.CommandTimeout = 0;
                myCmd.ExecuteNonQuery();
            } 

            // Show only deleted rows. 
            dv_TEMP.RowStateFilter = DataViewRowState.Deleted;
            foreach (DataRowView DtRowView in dv_TEMP)
            {
                SqlCommand myCmd = new SqlCommand();
                myCmd.Parameters.AddWithValue("@ID", DtRowView["ID"]);
                myCmd.CommandText = " DELETE dbo.[ADM_MUSTERI_PARAMETRE_TEMP]  WHERE  ID=@ID";
                myCmd.Connection = sql;
                myCmd.CommandTimeout = 0;
                myCmd.ExecuteNonQuery();
            }

            // SATIR EKLE
            dv_TEMP.RowStateFilter = DataViewRowState.Added;
            if (dv_TEMP.Count != 0)
            {
                foreach (DataRowView dr in dv_TEMP)
                {
                    if (dr.Row["TEMP_TEXT"].ToString() != string.Empty)
                    {
                        SqlCommand myCmd = new SqlCommand();

                        myCmd.Parameters.AddWithValue("@TEMP_TEXT", dr.Row["TEMP_TEXT"]);
                        myCmd.Parameters.AddWithValue("@TEMP_FIELD", dr.Row["TEMP_FIELD"]);
                        myCmd.Parameters.AddWithValue("@BASLIK", dr.Row["BASLIK"]);
                        //myCmd.Parameters.AddWithValue("@MUSTERI_KODU", dr.Row["MUSTERI_KODU"]);
                        myCmd.Parameters.AddWithValue("@MUSTERI_KODU", BR_SELECT_ROW_MUSTERI_KODU.Caption);
                        myCmd.CommandText = " INSERT INTO dbo.[ADM_MUSTERI_PARAMETRE_TEMP] ([MUSTERI_KODU],[BASLIK],[TEMP_TEXT],[TEMP_FIELD] ) VALUES (@MUSTERI_KODU,@BASLIK,@TEMP_TEXT,@TEMP_FIELD )  ";
                        myCmd.Connection = sql;
                        myCmd.CommandTimeout = 0;
                        myCmd.ExecuteNonQuery();
                    }
                }
            }

            // SATIR GUNCELLE
            dv_TEMP.RowStateFilter = DataViewRowState.ModifiedOriginal;
            if (dv.Count != 0)
            {
                foreach (DataRowView dr in dv_TEMP)
                {
                    SqlCommand myCmd = new SqlCommand();

                    myCmd.Parameters.AddWithValue("@TEMP_TEXT", dr.Row["TEMP_TEXT"]);
                    myCmd.Parameters.AddWithValue("@TEMP_FIELD", dr.Row["TEMP_FIELD"]);
                    myCmd.Parameters.AddWithValue("@BASLIK", dr.Row["BASLIK"]);
                    myCmd.Parameters.AddWithValue("@ID", dr.Row["ID"]);
                    myCmd.CommandText = " UPDATE dbo.[ADM_MUSTERI_PARAMETRE_TEMP] SET [BASLIK]=@BASLIK, [TEMP_TEXT]=@TEMP_TEXT ,[TEMP_FIELD]=@TEMP_FIELD  WHERE  ID=@ID";
                    myCmd.Connection = sql;
                    myCmd.CommandTimeout = 0;
                    myCmd.ExecuteNonQuery();
                }
            }

            // Show only deleted rows. 
            dv_DEFAULT.RowStateFilter = DataViewRowState.Deleted;
            foreach (DataRowView DtRowView in dv_DEFAULT)
            {
                SqlCommand myCmd = new SqlCommand();
                myCmd.Parameters.AddWithValue("@ID", DtRowView["ID"]);
                myCmd.CommandText = " DELETE dbo.[ADM_MUSTERI_PARAMETRE_DEFAULT]  WHERE  ID=@ID";
                myCmd.Connection = sql;
                myCmd.CommandTimeout = 0;
                myCmd.ExecuteNonQuery();
            }

            // SATIR EKLE
            dv_DEFAULT.RowStateFilter = DataViewRowState.Added;
            if (dv_DEFAULT.Count != 0)
            {
                foreach (DataRowView dr in dv_DEFAULT)
                {
                    if (dr.Row["DEFAULT_TEXT"].ToString() != string.Empty)
                    {
                        SqlCommand myCmd = new SqlCommand();
                        myCmd.Parameters.AddWithValue("@DEFAULT_TEXT", dr.Row["DEFAULT_TEXT"]);
                        myCmd.Parameters.AddWithValue("@DEFAULT_FIELD", dr.Row["DEFAULT_FIELD"]);
                        myCmd.Parameters.AddWithValue("@BASLIK", dr.Row["BASLIK"]);
                        //myCmd.Parameters.AddWithValue("@MUSTERI_KODU", dr.Row["MUSTERI_KODU"]);
                        myCmd.Parameters.AddWithValue("@MUSTERI_KODU", BR_SELECT_ROW_MUSTERI_KODU.Caption);
                        myCmd.CommandText = " INSERT INTO dbo.[ADM_MUSTERI_PARAMETRE_DEFAULT] ([MUSTERI_KODU],[BASLIK],[DEFAULT_TEXT],[DEFAULT_FIELD]) VALUES (@MUSTERI_KODU,@BASLIK,@DEFAULT_TEXT,@DEFAULT_FIELD)  ";
                        myCmd.Connection = sql;
                        myCmd.CommandTimeout = 0;
                        myCmd.ExecuteNonQuery();
                    }
                }
            }

            // SATIR GUNCELLE
            dv_DEFAULT.RowStateFilter = DataViewRowState.ModifiedOriginal;
            if (dv_DEFAULT.Count != 0)
            {
                foreach (DataRowView dr in dv_DEFAULT)
                {
                    SqlCommand myCmd = new SqlCommand();
                    myCmd.Parameters.AddWithValue("@DEFAULT_TEXT", dr.Row["DEFAULT_TEXT"]);
                    myCmd.Parameters.AddWithValue("@DEFAULT_FIELD", dr.Row["DEFAULT_FIELD"]);
                    myCmd.Parameters.AddWithValue("@BASLIK", dr.Row["BASLIK"]);
                    myCmd.Parameters.AddWithValue("@ID", dr.Row["ID"]);
                    myCmd.CommandText = " UPDATE dbo.[ADM_MUSTERI_PARAMETRE_DEFAULT] SET  [BASLIK]=@BASLIK, [DEFAULT_TEXT]=@DEFAULT_TEXT ,[DEFAULT_FIELD]=@DEFAULT_FIELD  WHERE  ID=@ID";
                    myCmd.Connection = sql;
                    myCmd.CommandTimeout = 0;
                    myCmd.ExecuteNonQuery();
                }
            } sql.Close();

            CLIENT_LIST();
            STLINE_DEFAULT(BR_ID.Caption);
            STLINE_TEMP(BR_ID.Caption);
        }
    }
}