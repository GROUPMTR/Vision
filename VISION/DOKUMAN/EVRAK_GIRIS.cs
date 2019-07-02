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
using DevExpress.XtraPrinting;

namespace VISION.DOKUMAN
{
    public partial class EVRAK_GIRIS : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbl;
        int id = 0;
        public string SELECT_BUTTON = "CANCEL";
        public EVRAK_GIRIS(int ID)
        {
            InitializeComponent();

          
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
             ControlBox = false;
            DATE_EDT_GONDERIM_TARIHI.Text = DateTime.Now.ToShortDateString();
            DATE_EDT_KAPANIS_TARIHI.Text = DateTime.Now.ToShortDateString();  

            id = ID;
            _DATA_LOAD(ID);

            if (TXT_GONDEREN.Text.Length < 1) TXT_GONDEREN.Text = _GLOBAL_PARAMETERS._KULLANICI_MAIL;

            tbl.Rows.Add(new object[] { "", "", "", "" });
            tbl.Rows.Add(new object[] { "", "", "", "" });
            tbl.Rows.Add(new object[] { "", "", "", "" });
            tbl.Rows.Add(new object[] { "", "", "", "" });
            tbl.Rows.Add(new object[] { "", "", "", "" });
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void _DATA_LOAD(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string mySelectQuery = "  SELECT  * from  dbo.EVR_EVRAK_TAKIBI  WHERE SIRKET_KODU=@SIRKET_KODU and ID=" + ID;

                SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
                myCommand.Parameters.Add("@SIRKET_KODU", SqlDbType.NVarChar); myCommand.Parameters["@SIRKET_KODU"].Value = _GLOBAL_PARAMETERS._SIRKET_KODU;
                myCommand.CommandText = mySelectQuery.ToString();
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                myConnections.Open();
                while (myReader.Read())
                {
                    DATE_EDT_GONDERIM_TARIHI.Text = myReader["GONDERIM_TARIHI"].ToString();
                    TXT_BELGENO.Text = myReader["DOKUMAN_NO"].ToString();
                    COM_BX_MUSTERI_AJANS.Text = myReader["MUSTERI_AJANS"].ToString();
                    COM_BX_GIDECEGI_YER.Text = myReader["GIDECEGI_YER"].ToString();
                    TXT_ILGILIKISI.Text = myReader["ILGILI_KISI"].ToString();
                    DATE_EDT_KAPANIS_TARIHI.Text = myReader["KAPANIS_TARIHI"].ToString();
                    TXT_GONDEREN.Text = myReader["GONDEREN"].ToString();
                    TXT_NOTU.Text = myReader["DOKUMAN_NOTU"].ToString();
                }

            }

            tbl = new DataTable();
            tbl = new DataTable("tbl_GIDEN_EVRAK_EKLERI");
            tbl.Columns.Add("ID", typeof(string));
            tbl.Columns.Add("DOKUMAN_TARIHI", typeof(string));
            tbl.Columns.Add("DOKUMAN_NO", typeof(string));
            tbl.Columns.Add("DOKUMAN_NOTU", typeof(string));

            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                SqlCommand myCommand = new SqlCommand("  SELECT  * from dbo.EVR_EVRAK_TAKIBI_SATIRLAR   WHERE SIRKET_KODU=@SIRKET_KODU  and  EVRAK_REF=" + ID, myConnection);
                myCommand.Parameters.Add("@SIRKET_KODU", SqlDbType.NVarChar); myCommand.Parameters["@SIRKET_KODU"].Value = _GLOBAL_PARAMETERS._SIRKET_KODU;
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                SqlConnection myConnections = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                myConnections.Open();
                while (myReader.Read())
                {
                    tbl.Rows.Add(new object[] { myReader["ID"], myReader["DOKUMAN_TARIHI"], myReader["DOKUMAN_NO"], myReader["DOKUMAN_NOTU"] });
                }
            }
            grd_FIELD.DataSource = tbl;
        }

        private void barBTN_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            SELECT_BUTTON = "OK";
            if (id == 0)
            {
                __Kaydet();
            }
            else
            {
                __Guncelle(id);

            }
        }

        private void __Kaydet()
        {
            string EVRAK_REF = "";
            using (SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {

                myConnectionTable.Open();
                SqlCommand myCmd = new SqlCommand();
                myCmd.CommandText = " INSERT INTO dbo.EVR_EVRAK_TAKIBI  (SIRKET_KODU,ISLEM_TARIHI, GONDERIM_TARIHI, DOKUMAN_NO, MUSTERI_AJANS, GIDECEGI_YER, ILGILI_KISI, KAPANIS_TARIHI, DOKUMAN_DURUMU, GONDEREN, DOKUMAN_NOTU) " +
                                                        " Values (@SIRKET_KODU,@ISLEM_TARIHI, @GONDERIM_TARIHI, @DOKUMAN_NO, @MUSTERI_AJANS, @GIDECEGI_YER, @ILGILI_KISI, @KAPANIS_TARIHI, @DOKUMAN_DURUMU, @GONDEREN, @DOKUMAN_NOTU)  SELECT @@IDENTITY AS ID  ";

                myCmd.Parameters.Add("@SIRKET_KODU", SqlDbType.NVarChar); myCmd.Parameters["@SIRKET_KODU"].Value = _GLOBAL_PARAMETERS._SIRKET_KODU;
                myCmd.Parameters.Add("@ISLEM_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@ISLEM_TARIHI"].Value = DateTime.Now.ToShortDateString();
                myCmd.Parameters.Add("@GONDERIM_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@GONDERIM_TARIHI"].Value = DATE_EDT_GONDERIM_TARIHI.Text;
                myCmd.Parameters.Add("@DOKUMAN_NO", SqlDbType.NVarChar); myCmd.Parameters["@DOKUMAN_NO"].Value = TXT_BELGENO.Text;
                myCmd.Parameters.Add("@MUSTERI_AJANS", SqlDbType.NVarChar); myCmd.Parameters["@MUSTERI_AJANS"].Value = COM_BX_MUSTERI_AJANS.Text;
                myCmd.Parameters.Add("@GIDECEGI_YER", SqlDbType.NVarChar); myCmd.Parameters["@GIDECEGI_YER"].Value = COM_BX_GIDECEGI_YER.Text;
                myCmd.Parameters.Add("@ILGILI_KISI", SqlDbType.NVarChar); myCmd.Parameters["@ILGILI_KISI"].Value = TXT_ILGILIKISI.Text;
                myCmd.Parameters.Add("@KAPANIS_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@KAPANIS_TARIHI"].Value = DATE_EDT_KAPANIS_TARIHI.Text;
                myCmd.Parameters.Add("@DOKUMAN_DURUMU", SqlDbType.NVarChar); myCmd.Parameters["@DOKUMAN_DURUMU"].Value = "KAPALI";
                myCmd.Parameters.Add("@GONDEREN", SqlDbType.NVarChar); myCmd.Parameters["@GONDEREN"].Value = TXT_GONDEREN.Text;
                myCmd.Parameters.Add("@DOKUMAN_NOTU", SqlDbType.NVarChar); myCmd.Parameters["@DOKUMAN_NOTU"].Value = TXT_NOTU.Text; 
                myCmd.Connection = myConnectionTable;
                SqlDataReader myReader = myCmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                    EVRAK_REF = (string)myReader.GetValue(0).ToString();
                myReader.Close();
                myCmd.Connection.Close();
            }

            for (int i = 0; i < gridView_FIELD.RowCount - 1; i++)
            {

                DataRow DR = gridView_FIELD.GetDataRow(i);



                if (DR["ID"].ToString() == "")
                {
                    if (DR["DOKUMAN_TARIHI"] != "")
                    {
                        using (SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                        {

                            myConnectionTable.Open();
                            SqlCommand myCmd = new SqlCommand();
                            myCmd.CommandText = " INSERT INTO dbo.EVR_EVRAK_TAKIBI_SATIRLAR (SIRKET_KODU,ISLEM_TARIHI,  EVRAK_REF,DOKUMAN_TARIHI,DOKUMAN_NO,DOKUMAN_NOTU) " +
                                                                                " Values (@SIRKET_KODU,@ISLEM_TARIHI, @EVRAK_REF,@DOKUMAN_TARIHI,@DOKUMAN_NO,@DOKUMAN_NOTU)   ";
                            myCmd.Parameters.Add("@SIRKET_KODU", SqlDbType.NVarChar); myCmd.Parameters["@SIRKET_KODU"].Value = _GLOBAL_PARAMETERS._SIRKET_KODU;
                            myCmd.Parameters.Add("@ISLEM_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@ISLEM_TARIHI"].Value = DateTime.Now.ToShortDateString();  
                            myCmd.Parameters.Add("@EVRAK_REF", SqlDbType.Int); myCmd.Parameters["@EVRAK_REF"].Value = EVRAK_REF;
                            myCmd.Parameters.Add("@DOKUMAN_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@DOKUMAN_TARIHI"].Value = Convert.ToDateTime(DR["DOKUMAN_TARIHI"]);
                            myCmd.Parameters.Add("@DOKUMAN_NO", SqlDbType.NVarChar); myCmd.Parameters["@DOKUMAN_NO"].Value = DR["DOKUMAN_NO"];
                            myCmd.Parameters.Add("@DOKUMAN_NOTU", SqlDbType.NVarChar); myCmd.Parameters["@DOKUMAN_NOTU"].Value = DR["DOKUMAN_NOTU"];
                            myCmd.Connection = myConnectionTable;
                            myCmd.ExecuteNonQuery();
                            myCmd.Connection.Close();
                        }
                    }
                }
                else
                {
                    if (DR["DOKUMAN_TARIHI"] != "")
                    {
                        using (SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                        {

                            myConnectionTable.Open();
                            SqlCommand myCmd = new SqlCommand();
                            myCmd.CommandText = " UPDATE dbo.EVR_EVRAK_TAKIBI_SATIRLAR " +
                                                  " SET  ISLEM_TARIHI=@ISLEM_TARIHI,  EVRAK_REF=@EVRAK_REF,DOKUMAN_TARIHI=@DOKUMAN_TARIHI,DOKUMAN_NO=@DOKUMAN_NO,DOKUMAN_NOTU=@DOKUMAN_NOTU " +
                                                  " WHERE ID=@ID ";
                            myCmd.Parameters.Add("@ID", SqlDbType.Int); myCmd.Parameters["@ID"].Value = DR["ID"].ToString();
                            myCmd.Parameters.Add("@ISLEM_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@ISLEM_TARIHI"].Value = DateTime.Now.ToShortDateString();

                            myCmd.Parameters.Add("@EVRAK_REF", SqlDbType.Int); myCmd.Parameters["@EVRAK_REF"].Value = EVRAK_REF;
                            myCmd.Parameters.Add("@DOKUMAN_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@DOKUMAN_TARIHI"].Value = Convert.ToDateTime(DR["DOKUMAN_TARIHI"]);
                            myCmd.Parameters.Add("@DOKUMAN_NO", SqlDbType.NVarChar); myCmd.Parameters["@DOKUMAN_NO"].Value = DR["DOKUMAN_NO"];
                            myCmd.Parameters.Add("@DOKUMAN_NOTU", SqlDbType.NVarChar); myCmd.Parameters["@DOKUMAN_NOTU"].Value = DR["DOKUMAN_NOTU"];
                            myCmd.Connection = myConnectionTable;
                            myCmd.ExecuteNonQuery();
                            myCmd.Connection.Close();
                        }
                    }

                }

            }


            MessageBox.Show("Kayıt işlemi yapıldı", "UYARI");
        }
        private void __Guncelle(int ID)
        {
            using (SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {

                myConnectionTable.Open();
                SqlCommand myCmd = new SqlCommand();
                myCmd.CommandText =
                " UPDATE  dbo.GIDEN_EVRAK_TAKIBI "+
                         " SET ISLEM_TARIHI=@ISLEM_TARIHI,GONDERIM_TARIHI=@GONDERIM_TARIHI,DOKUMAN_NO=@DOKUMAN_NO,MUSTERI_AJANS=@MUSTERI_AJANS,GIDECEGI_YER=@GIDECEGI_YER,ILGILI_KISI=@ILGILI_KISI," +
                         " KAPANIS_TARIHI=@KAPANIS_TARIHI, DOKUMAN_DURUMU=@DOKUMAN_DURUMU, GONDEREN=@GONDEREN,DOKUMAN_NOTU=@DOKUMAN_NOTU WHERE (ID = '" + ID + "')";



                myCmd.Parameters.Add("@ISLEM_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@ISLEM_TARIHI"].Value = DateTime.Now.ToShortDateString(); 
     
                myCmd.Parameters.Add("@GONDERIM_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@GONDERIM_TARIHI"].Value = DATE_EDT_GONDERIM_TARIHI.Text;
                myCmd.Parameters.Add("@DOKUMAN_NO", SqlDbType.NVarChar); myCmd.Parameters["@DOKUMAN_NO"].Value = TXT_BELGENO.Text;
                myCmd.Parameters.Add("@MUSTERI_AJANS", SqlDbType.NVarChar); myCmd.Parameters["@MUSTERI_AJANS"].Value = COM_BX_MUSTERI_AJANS.Text;
                myCmd.Parameters.Add("@GIDECEGI_YER", SqlDbType.NVarChar); myCmd.Parameters["@GIDECEGI_YER"].Value = COM_BX_GIDECEGI_YER.Text;
                myCmd.Parameters.Add("@ILGILI_KISI", SqlDbType.NVarChar); myCmd.Parameters["@ILGILI_KISI"].Value = TXT_ILGILIKISI.Text;
                myCmd.Parameters.Add("@KAPANIS_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@KAPANIS_TARIHI"].Value = DATE_EDT_KAPANIS_TARIHI.Text;
                myCmd.Parameters.Add("@DOKUMAN_DURUMU", SqlDbType.NVarChar); myCmd.Parameters["@DOKUMAN_DURUMU"].Value = "KAPALI";
                myCmd.Parameters.Add("@GONDEREN", SqlDbType.NVarChar); myCmd.Parameters["@GONDEREN"].Value = TXT_GONDEREN.Text;
                myCmd.Parameters.Add("@DOKUMAN_NOTU", SqlDbType.NVarChar); myCmd.Parameters["@DOKUMAN_NOTU"].Value = TXT_NOTU.Text;




                myCmd.Connection = myConnectionTable;
                myCmd.ExecuteNonQuery();
                myCmd.Connection.Close();

            }

            for (int i = 0; i < gridView_FIELD.RowCount - 1; i++)
            {

                DataRow DR = gridView_FIELD.GetDataRow(i);



                if (DR["ID"].ToString() == "")
                {
                    if (DR["DOKUMAN_TARIHI"] != "")
                    {
                        using (SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                        {

                            myConnectionTable.Open();
                            SqlCommand myCmd = new SqlCommand();
                            myCmd.CommandText = " INSERT INTO dbo.EVR_EVRAK_TAKIBI_SATIRLAR (ISLEM_TARIHI, EVRAK_REF,DOKUMAN_TARIHI,DOKUMAN_NO,DOKUMAN_NOTU) " +
                                                                      " Values (@ISLEM_TARIHI,  @EVRAK_REF,@DOKUMAN_TARIHI,@DOKUMAN_NO,@DOKUMAN_NOTU)   "; 
                            myCmd.Parameters.Add("@ISLEM_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@ISLEM_TARIHI"].Value = DateTime.Now.ToShortDateString(); 
                            myCmd.Parameters.Add("@EVRAK_REF", SqlDbType.Int); myCmd.Parameters["@EVRAK_REF"].Value = ID;
                            myCmd.Parameters.Add("@DOKUMAN_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@DOKUMAN_TARIHI"].Value = Convert.ToDateTime(DR["DOKUMAN_TARIHI"]);
                            myCmd.Parameters.Add("@DOKUMAN_NO", SqlDbType.NVarChar); myCmd.Parameters["@DOKUMAN_NO"].Value = DR["DOKUMAN_NO"];
                            myCmd.Parameters.Add("@DOKUMAN_NOTU", SqlDbType.NVarChar); myCmd.Parameters["@DOKUMAN_NOTU"].Value = DR["DOKUMAN_NOTU"];
                            myCmd.Connection = myConnectionTable;
                            myCmd.ExecuteNonQuery();
                            myCmd.Connection.Close();
                        }
                    }
                }
                else
                {
                    if (DR["DOKUMAN_TARIHI"] != "")
                    {
                        using (SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                        {

                            myConnectionTable.Open();
                            SqlCommand myCmd = new SqlCommand();
                            myCmd.CommandText = " UPDATE dbo.EVR_EVRAK_TAKIBI_SATIRLAR " +
                                                  " SET  ISLEM_TARIHI=@ISLEM_TARIHI, EVRAK_REF=@EVRAK_REF,DOKUMAN_TARIHI=@DOKUMAN_TARIHI,DOKUMAN_NO=@DOKUMAN_NO,DOKUMAN_NOTU=@DOKUMAN_NOTU " +
                                                  " WHERE ID=@ID ";
                            myCmd.Parameters.Add("@ID", SqlDbType.Int); myCmd.Parameters["@ID"].Value = DR["ID"].ToString();
                            myCmd.Parameters.Add("@ISLEM_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@ISLEM_TARIHI"].Value = DateTime.Now.ToShortDateString();


                            myCmd.Parameters.Add("@EVRAK_REF", SqlDbType.Int); myCmd.Parameters["@EVRAK_REF"].Value = ID;
                            myCmd.Parameters.Add("@DOKUMAN_TARIHI", SqlDbType.DateTime); myCmd.Parameters["@DOKUMAN_TARIHI"].Value = Convert.ToDateTime(DR["DOKUMAN_TARIHI"]);
                            myCmd.Parameters.Add("@DOKUMAN_NO", SqlDbType.NVarChar); myCmd.Parameters["@DOKUMAN_NO"].Value = DR["DOKUMAN_NO"];
                            myCmd.Parameters.Add("@DOKUMAN_NOTU", SqlDbType.NVarChar); myCmd.Parameters["@DOKUMAN_NOTU"].Value = DR["DOKUMAN_NOTU"];
                            myCmd.Connection = myConnectionTable;
                            myCmd.ExecuteNonQuery();
                            myCmd.Connection.Close();
                        }
                    }

                }

            }


            MessageBox.Show("Güncelleme işlemi yapıldı", "UYARI");

        }

        private void barBTN_YAZDIR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           EVRAK_PRINT.tbl = tbl;
           EVRAK_PRINT.T_FATURANO = TXT_BELGENO.Text;
           EVRAK_PRINT.T_ILGILIKISI = TXT_ILGILIKISI.Text;
           EVRAK_PRINT.T_FIRMA = COM_BX_GIDECEGI_YER.Text;
           EVRAK_PRINT.T_GONDEREN = TXT_GONDEREN.Text;
           EVRAK_PRINT.T_NOTU = TXT_NOTU.Text;
           EVRAK_PRINT.T_TARIH = DATE_EDT_GONDERIM_TARIHI.Text;



           EVRAK_PRINT prnt = new EVRAK_PRINT();


            ///
            /// Printer Formuna veri aktar.
            /// 
            PRINTS print = new PRINTS();
            print.printControls.PrintingSystem = prnt.PrintingSystem;
            prnt.CreateDocument();
            print.printControls.ExecCommand(PrintingSystemCommand.View);
            print.printControls.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.Scale, new object[] { 1 });
            print.printControls.PrintingSystem.PageSettings.Landscape = false;
            print.ShowDialog();  

        }

        private void COM_BX_MUSTERI_AJANS_SelectedIndexChanged(object sender, EventArgs e)
        {
            COM_BX_GIDECEGI_YER.Properties.Items.Clear();
            COM_BX_GIDECEGI_YER.Text =string.Empty;
            if (COM_BX_MUSTERI_AJANS.Text == "Müşteri")
            {
                
                using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                { 
                    SqlCommand myCommand = new SqlCommand(" SELECT  * from ADM_PAZARLAMA_SIRKETI ", myConnection); 
                    myConnection.Open();
                    SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    while (myReader.Read())
                    {
                        COM_BX_GIDECEGI_YER.Properties.Items.Add(myReader["UNVANI"].ToString());
                    } 
                }
            }

        if (COM_BX_MUSTERI_AJANS.Text == "Pazarlama Şirketi")
        {
            using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
            {
                string mySelectQuery = "  SELECT  * from dbo.ADM_MUSTERI WHERE SIRKET_KODU='" + _GLOBAL_PARAMETERS._SIRKET_KODU + "'";
                SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
                myCommand.CommandText = mySelectQuery.ToString();
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    COM_BX_GIDECEGI_YER.Properties.Items.Add(myReader["ADI"].ToString());
                }

            }
        }

 
        }

        private void BTN_EKLE_Click(object sender, EventArgs e)
        {
                   tbl.Rows.Add(new object[] {"","","","" });
            tbl.Rows.Add(new object[] { "", "", "", "" });
            tbl.Rows.Add(new object[] { "", "", "", "" });
            tbl.Rows.Add(new object[] { "", "", "", "" });
            tbl.Rows.Add(new object[] { "", "", "", "" });
        }
    }
}