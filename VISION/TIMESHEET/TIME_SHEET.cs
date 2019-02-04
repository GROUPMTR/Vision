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
using System.Globalization;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Native;


namespace VISION.TIMESHEET
{
    public partial class TIME_SHEET : DevExpress.XtraEditors.XtraForm
    {
        DataSet DataSet_REZERVASYONLAR;
        public TIME_SHEET()
        {
            InitializeComponent();
            this.Tag = "MDIFORM";

         //   DATA_LOAD(Environment.UserName.ToString().Replace("I", "i").Replace("İ", "i").Replace("ı", "i").Replace(@"AD\", "").ToLower());
            // DATA_LOAD("murat.ozkan");  

            DATA_LOAD();

            //cntxtMnStp_Plan.Items.Add("Müşteri");
            //(cntxtMnStp_Plan.Items[0] as ToolStripMenuItem).DropDownItems.Add("Nestle");
            //cntxtMnStp_Plan.Items.Add("Sil");


        }
    
        private void DATA_LOAD()
        {


            DateTime _StartDate = Convert.ToDateTime(DateTime.Now.AddDays(-2));
            dateNavigators.DateTime = DateTime.Now;


            SqlConnection qcon = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            qcon.Open();
            SqlCommand qcommand = new SqlCommand("SELECT * FROM TODO_TIME_SHEET  WHERE    (SIRKET_KODU=@SIRKET_KODU)  and (MAIL_ADRESI=@MAIL_ADRESI) ", qcon);
            SqlDataAdapter qadapter = new SqlDataAdapter(qcommand.CommandText, qcon);
            DataTable qtbl = new System.Data.DataTable();
            qadapter.SelectCommand.Parameters.AddWithValue("@MAIL_ADRESI", _GLOBAL_PARAMETERS._KULLANICI_MAIL);
            qadapter.SelectCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
            qadapter.Fill(qtbl);
            qcon.Close();
            schedulerControls.Storage.Appointments.DataSource = qtbl;


            schedulerControls.Storage.Appointments.Mappings.AppointmentId = "UniqueID";
            //  schedulerControls.Storage.Appointments.Mappings.Description = "Description";
            schedulerControls.Storage.Appointments.Mappings.Start = "StartDate";
            schedulerControls.Storage.Appointments.Mappings.End = "EndDate";
            // schedulerControls.Storage.Appointments.Mappings.Label = "Label";
            //  schedulerControls.Storage.Appointments.Mappings.Status = "Status";
            schedulerControls.Storage.Appointments.Mappings.Location = "Location";
            dateNavigators.SchedulerControl.Views.DayView.DayCount = 14;
            //            SELECT     SUM(DATEDIFF(mi, StartDate, EndDate)) / 60 AS [Worked Time], Description
            //FROM         dbo.TODO_TIME_SHEET
            //GROUP BY Description


            //DataSet DataSet_TOPLANTI_ODALARI = new DataSet();
            //using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTION_STRING.ToString()))
            //{
            //    string mySelectQuery = " SELECT  * FROM  dbo.ADM_TOPLANTI_ODALARI WHERE  (SIRKETREF =" + _GLOBAL_PARAMETERS._SIRKET_ID + ")";
            //    SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(mySelectQuery, myConnection);
            //    MySqlDataAdapter.Fill(DataSet_TOPLANTI_ODALARI, "dbo_MecraList");
            //    DataViewManager dvManager = new DataViewManager(DataSet_TOPLANTI_ODALARI);
            //    DataView Schedules = dvManager.CreateDataView(DataSet_TOPLANTI_ODALARI.Tables[0]);
            //    this.schedulerControls.Storage.Resources.DataSource = DataSet_TOPLANTI_ODALARI.Tables[0];
            //}
            //this.schedulerStorages.Resources.CustomFieldMappings.Add(new DevExpress.XtraScheduler.ResourceCustomFieldMapping("OZEL", "OZEL", DevExpress.XtraScheduler.FieldValueType.String));

            //using (SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTION_STRING.ToString()))
            //{
            //    string mySelectQuery = " SELECT * FROM  dbo.TODO_TIME_SHEET  WHERE  (SIRKETREF =" + _GLOBAL_PARAMETERS._SIRKET_ID + ")  and  StartDate >=  '" + _StartDate.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo) + "'";
            //    SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(mySelectQuery, myConnection);
            //    DataSet_REZERVASYONLAR = new DataSet();
            //    MySqlDataAdapter.Fill(DataSet_REZERVASYONLAR, "dbo_MecraList");
            //    DataViewManager dvManager = new DataViewManager(DataSet_REZERVASYONLAR);
            //    DataView Schedules = dvManager.CreateDataView(DataSet_REZERVASYONLAR.Tables[0]);
            //    this.schedulerControls.Storage.Appointments.DataSource = DataSet_REZERVASYONLAR.Tables[0];
            //}
            //this.schedulerStorages.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("MAIL_ADRESI", "MAIL_ADRESI", DevExpress.XtraScheduler.FieldValueType.String));
            //dateNavigators.Refresh();

            //SqlConnection qcon = new SqlConnection("BAGLANTIDIZESİ");
            //qcon.Open();
            //SqlCommand qcommand = new SqlCommand("SELECT * FROM TABLO", qcon);
            //SqlDataAdapter qadapter = new SqlDataAdapter(qcommand.CommandText, qcon);
            //DataTable qtbl = new System.Data.DataTable();
            //qadapter.Fill(qtbl);
            //qcon.Close();

            //schedulerStorage1.Appointments.DataSource = qtbl;


        }
        private void TOPLANTI_EKLE(string _MUSTERI_KODU)
        {
            //Appointment apt = this.schedulerControls.Storage.CreateAppointment(AppointmentType.Normal);
            //apt.CustomFields["MAIL_ADRESI"] = "hasan";
            //this.schedulerControls.Storage.Appointments.Add(apt);  
            //this.schedulerControls.Storage.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("MAIL_ADRESI", "MAIL_ADRESI", DevExpress.XtraScheduler.FieldValueType.String));
            // Appointment apt = new Appointment();

            Appointment apt = this.schedulerControls.Storage.CreateAppointment(AppointmentType.Normal);
            SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
            myConnectionTable.Open();
            SqlCommand myCmd = new SqlCommand();
            myCmd.CommandText = " INSERT INTO  dbo.TODO_TIME_SHEET ( StartDate,EndDate , Subject, Location, Description, MAIL_ADRESI ,SIRKET_KODU )" +
                                                     " Values  (@StartDate,@EndDate , @Subject, @Location, @Description,@MAIL_ADRESI,@SIRKET_KODU)      ";
            DateTime _StartDate = Convert.ToDateTime(schedulerControls.SelectedInterval.Start.ToShortDateString() + " " + schedulerControls.SelectedInterval.Start.ToShortTimeString());
            DateTime _EndDate = Convert.ToDateTime(schedulerControls.SelectedInterval.End.ToShortDateString() + " " + schedulerControls.SelectedInterval.End.ToShortTimeString());
            myCmd.Parameters.AddWithValue("@StartDate", _StartDate.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo));
            myCmd.Parameters.AddWithValue("@EndDate", _EndDate.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo));
            myCmd.Parameters.AddWithValue("@Subject", _MUSTERI_KODU.ToString());
            myCmd.Parameters.AddWithValue("@Location", _GLOBAL_PARAMETERS._KULLANICI_MAIL);
            myCmd.Parameters.AddWithValue("@Description", _MUSTERI_KODU);
            // myCmd.Parameters.Add("@ResourceID", SqlDbType.NVarChar); myCmd.Parameters["@ResourceID"].Value = schedulerControls.SelectedResource.Id;
            myCmd.Parameters.AddWithValue("@MAIL_ADRESI", _GLOBAL_PARAMETERS._KULLANICI_MAIL);
            myCmd.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
            myCmd.Connection = myConnectionTable;
            myCmd.ExecuteNonQuery();
            myCmd.Connection.Close();

            apt.Start = schedulerControls.SelectedInterval.Start;
            apt.End = schedulerControls.SelectedInterval.End;
            apt.ResourceId = schedulerControls.SelectedResource.Id;
            apt.Subject = _MUSTERI_KODU;
            //apt.Description = _MUSTERI_KODU;
            //apt.Location = _GLOBAL_PARAMETERS._KULLANICI_MAIL;
            //apt.CustomFields["MAIL_ADRESI"] = _GLOBAL_PARAMETERS._KULLANICI_MAIL;
            schedulerControls.Storage.Appointments.Add(apt);
        }
        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void cntxtMnStp_Plan_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //  e.ClickedItem.Text;
        }

        private void CNTXT_MUSTERI_SEC_Click(object sender, EventArgs e)
        {

            MUSTERI_LISTESI frm = new MUSTERI_LISTESI();
            frm.ShowDialog();
            if (frm._SLCT_MUSTERI_KODU != null && frm._SLCT_MUSTERI_KODU.Length != 0) TOPLANTI_EKLE(frm._SLCT_MUSTERI_KODU);
        }

        private void schedulerControls_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            for (int i = 0; i < e.Menu.Items.Count; i++)
            {
                e.Menu.Items[i].Visible = false;
            }
        }

        private void CNTXT_DIGER_SEC_Click(object sender, EventArgs e)
        {

            if (CMBX_DIREKTOR_LIST.EditValue != null)
            {
               
                //Appointment app = new Appointment(AppointmentType.Normal, schedulerControls.SelectedInterval.Start, schedulerControls.SelectedInterval.End, "app in question");

                //AppointmentConflictsCalculator acCalculator = new AppointmentConflictsCalculator(
                //    schedulerControls.Storage.Appointments.Items);
                //AppointmentBaseCollection appsConflict = acCalculator.CalculateConflicts(app,
                //    new TimeInterval(app.Start, app.End));
                //if (appsConflict.Count != 0)
                //{
                //    MessageBox.Show("Çakışma tesbit edildi.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                //AppointmentBaseCollection apts = (AppointmentBaseCollection)schedulerControls.SelectedAppointments;
                //DateTime _StartDate = Convert.ToDateTime(schedulerControls.SelectedInterval.Start.ToShortDateString() + " " + schedulerControls.SelectedInterval.Start.ToShortTimeString());

                //if (_StartDate.DayOfWeek.ToString() == "Sunday" || _StartDate.DayOfWeek.ToString() == "Saturday")
                //{
                //    MessageBox.Show("Hafta sonu Tatili", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{

                //    string myInsertQuery = "";
                //    SqlConnection myConnection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                //    SqlConnection myConnectionUp = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                //    myInsertQuery = String.Format(" SELECT * FROM      dbo.TODO_TIME_SHEET_DIRECTOR_LISTESI  WHERE    (SIRKET_KODU = N'{0}') AND  (MAIL_ADRESI = '{1}') AND (DIRECTOR_KODU = N'{2}')", _GLOBAL_PARAMETERS._SIRKET_KODU, _GLOBAL_PARAMETERS._KULLANICI_MAIL, CMBX_DIREKTOR_LIST.EditValue.ToString());
                //    using (SqlCommand myCommandUp = new SqlCommand(myInsertQuery))
                //    {
                //        myCommandUp.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                //        myCommandUp.Parameters.AddWithValue("@MAIL_ADRESI", _GLOBAL_PARAMETERS._KULLANICI_MAIL);
                //        myCommandUp.Parameters.AddWithValue("@DIRECTOR_KODU", CMBX_DIREKTOR_LIST.EditValue.ToString());
                //        myCommandUp.Connection = myConnectionUp;
                //        myConnectionUp.Open();
                //        SqlDataReader myReaderUp = myCommandUp.ExecuteReader(CommandBehavior.CloseConnection);
                //        if (myReaderUp.HasRows == false)
                //        {
                //            myInsertQuery = "INSERT INTO dbo.TODO_TIME_SHEET_DIRECTOR_LISTESI(SIRKET_KODU, MAIL_ADRESI, DIRECTOR_KODU)  Values(@SIRKET_KODU,@MAIL_ADRESI,@DIRECTOR_KODU)";
                //            SqlCommand myCommand = new SqlCommand(myInsertQuery);
                //            myCommand.Parameters.AddWithValue("@SIRKET_KODU", _GLOBAL_PARAMETERS._SIRKET_KODU);
                //            myCommand.Parameters.AddWithValue("@MAIL_ADRESI", _GLOBAL_PARAMETERS._KULLANICI_MAIL);
                //            myCommand.Parameters.AddWithValue("@DIRECTOR_KODU", CMBX_DIREKTOR_LIST.EditValue.ToString());
                //            myCommand.Connection = myConnection;
                //            myConnection.Open();
                //            myCommand.ExecuteNonQuery();
                //            myCommand.Connection.Close();
                //        }
                //        myCommandUp.Connection.Close();
                //    }

                //    DIGER_LISTE frm = new DIGER_LISTE();
                //    frm.TopMost = true;
                //    frm.ShowDialog();
                //    if (frm._DIGER_SECENEKLER != null && frm._DIGER_SECENEKLER.Length != 0)
                //    {

                //        if (frm._TAKVIM_SOR)
                //        {

                //            TARIH_ARALIGI fm = new TARIH_ARALIGI();
                //            fm.TopMost = true;
                //            fm.ShowDialog();



                //            if (fm._BUTTON_TYPE == "TAMAM") TIME_SHEET_ROBOT_EKLE(frm._DIGER_SECENEKLER, fm._BAS_TARIHI, fm._BITIS_TARIHI, fm._OGLEN_TATILI);


                //        }
                //        else
                //        {
                //            TIME_SHEET_EKLE(frm._DIGER_SECENEKLER);
                //        }

                //    }

                //}
            }
            else
            {
                MessageBox.Show("Lütfen Önce director seçiniz.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void TIME_SHEET_EKLE(string _MUSTERI_KODU)
        {
            DateTime _StartDate = Convert.ToDateTime(schedulerControls.SelectedInterval.Start.ToShortDateString() + " " + schedulerControls.SelectedInterval.Start.ToShortTimeString());
            if (_StartDate.DayOfWeek.ToString() == "Sunday" || _StartDate.DayOfWeek.ToString() == "Saturday")
            {
                MessageBox.Show("Haftasonu tatili");
                return;
            }
            else
            {

                AppointmentBaseCollection selectedApts = schedulerControls.SelectedAppointments;
                Appointment apt = this.schedulerControls.Storage.CreateAppointment(AppointmentType.Normal);
                SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                myConnectionTable.Open();
                SqlCommand myCmd = new SqlCommand();
                myCmd.CommandText = " INSERT INTO  dbo.TODO_TIME_SHEET ( StartDate,EndDate , Subject, Location, Description, MAIL_ADRESI ,SIRKET_KODU,ONAY_DIREKTOR )" +
                                                         " Values  (@StartDate,@EndDate , @Subject, @Location, @Description,@MAIL_ADRESI,@SIRKET_KODU,@ONAY_DIREKTOR)      ";
                // DateTime _StartDate = Convert.ToDateTime(schedulerControls.SelectedInterval.Start.ToShortDateString() + " " + schedulerControls.SelectedInterval.Start.ToShortTimeString());
                DateTime _EndDate = Convert.ToDateTime(schedulerControls.SelectedInterval.End.ToShortDateString() + " " + schedulerControls.SelectedInterval.End.ToShortTimeString());
                myCmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime); myCmd.Parameters["@StartDate"].Value = _StartDate.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                myCmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime); myCmd.Parameters["@EndDate"].Value = _EndDate.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                myCmd.Parameters.Add("@Subject", SqlDbType.NVarChar); myCmd.Parameters["@Subject"].Value = _MUSTERI_KODU.ToString();
                myCmd.Parameters.Add("@Location", SqlDbType.NVarChar); myCmd.Parameters["@Location"].Value = _GLOBAL_PARAMETERS._KULLANICI_MAIL;
                myCmd.Parameters.Add("@Description", SqlDbType.NVarChar); myCmd.Parameters["@Description"].Value = _MUSTERI_KODU;
                // myCmd.Parameters.Add("@ResourceID", SqlDbType.NVarChar); myCmd.Parameters["@ResourceID"].Value = schedulerControls.SelectedResource.Id;
                myCmd.Parameters.Add("@MAIL_ADRESI", SqlDbType.NVarChar); myCmd.Parameters["@MAIL_ADRESI"].Value = _GLOBAL_PARAMETERS._KULLANICI_MAIL;
                myCmd.Parameters.Add("@SIRKET_KODU", SqlDbType.NVarChar); myCmd.Parameters["@SIRKET_KODU"].Value = _GLOBAL_PARAMETERS._SIRKET_KODU;
                myCmd.Parameters.Add("@ONAY_DIREKTOR", SqlDbType.NVarChar); myCmd.Parameters["@ONAY_DIREKTOR"].Value = CMBX_DIREKTOR_LIST.EditValue.ToString();
                myCmd.Connection = myConnectionTable;
                myCmd.ExecuteNonQuery();
                myCmd.Connection.Close();
                apt.Start = schedulerControls.SelectedInterval.Start;
                apt.End = schedulerControls.SelectedInterval.End;
                apt.ResourceId = schedulerControls.SelectedResource.Id;
                apt.Subject = _MUSTERI_KODU;
                //apt.Description = _MUSTERI_KODU;
                //apt.Location = _GLOBAL_PARAMETERS._KULLANICI_MAIL;
                //apt.CustomFields["MAIL_ADRESI"] = _GLOBAL_PARAMETERS._KULLANICI_MAIL;
                schedulerControls.Storage.Appointments.Add(apt);
            }
        }

        private void TIME_SHEET_ROBOT_EKLE(string _MUSTERI_KODU, DateTime myDTStart, DateTime myDTEnd, bool _OGLEN_TATILI)
        {

            TimeSpan ixt = myDTEnd - myDTStart;
            DateTime DTStart = myDTStart;
            if (_OGLEN_TATILI)
            {
                SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                myConnectionTable.Open();
                for (int i = 1; i <= ixt.Days; i++)
                {
                    DateTime dt = DTStart;
                    if (DTStart == myDTEnd) break;
                    if (dt.DayOfWeek == DayOfWeek.Saturday) { dt = DTStart = DTStart.AddDays(1); i++; }
                    if (dt.DayOfWeek == DayOfWeek.Sunday) { dt = DTStart = DTStart.AddDays(1); i++; }
                    AppointmentBaseCollection selectedApts = schedulerControls.SelectedAppointments;
                    Appointment apt = this.schedulerControls.Storage.CreateAppointment(AppointmentType.Normal);



                    using (SqlCommand myCmd = new SqlCommand())
                    {
                        string SQL = " SELECT     *  FROM     dbo.ADM_TATILER   WHERE     (StartDate >= CONVERT(DATETIME, @StartDate, 102)) AND (EndDate <= CONVERT(DATETIME, @EndDate, 102)) ";

                        myCmd.Parameters.Add("@StartDate", dt.ToString("yyyy-MM-dd 09:00:00", DateTimeFormatInfo.InvariantInfo));
                        myCmd.Parameters.Add("@EndDate", dt.ToString("yyyy-MM-dd 18:00:00", DateTimeFormatInfo.InvariantInfo));
                        myCmd.CommandText = SQL.ToString();
                        myCmd.Connection = myConnectionTable;
                        SqlDataReader myReader = myCmd.ExecuteReader();
                        while (myReader.Read())
                        {
                            dt = DTStart = DTStart.AddDays(1); i++;
                        }
                        myReader.Close();

                    }

                    using (SqlCommand myCmd = new SqlCommand())
                    {
                        myCmd.CommandText = " INSERT INTO  dbo.TODO_TIME_SHEET ( StartDate,EndDate , Subject, Location, Description, MAIL_ADRESI ,SIRKET_KODU,ONAY_DIREKTOR )" +
                                                                 " Values  (@StartDate,@EndDate , @Subject, @Location, @Description,@MAIL_ADRESI,@SIRKET_KODU,@ONAY_DIREKTOR)  ";
                        myCmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime); myCmd.Parameters["@StartDate"].Value = dt.ToString("yyyy-MM-dd 09:00:00", DateTimeFormatInfo.InvariantInfo);
                        myCmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime); myCmd.Parameters["@EndDate"].Value = dt.ToString("yyyy-MM-dd 12:00:00", DateTimeFormatInfo.InvariantInfo);
                        myCmd.Parameters.Add("@Subject", SqlDbType.NVarChar); myCmd.Parameters["@Subject"].Value = _MUSTERI_KODU.ToString();
                        myCmd.Parameters.Add("@Location", SqlDbType.NVarChar); myCmd.Parameters["@Location"].Value = _GLOBAL_PARAMETERS._KULLANICI_MAIL;
                        myCmd.Parameters.Add("@Description", SqlDbType.NVarChar); myCmd.Parameters["@Description"].Value = _MUSTERI_KODU;
                        myCmd.Parameters.Add("@MAIL_ADRESI", SqlDbType.NVarChar); myCmd.Parameters["@MAIL_ADRESI"].Value = _GLOBAL_PARAMETERS._KULLANICI_MAIL;
                        myCmd.Parameters.Add("@SIRKET_KODU", SqlDbType.NVarChar); myCmd.Parameters["@SIRKET_KODU"].Value = _GLOBAL_PARAMETERS._SIRKET_KODU;
                        myCmd.Parameters.Add("@ONAY_DIREKTOR", SqlDbType.NVarChar); myCmd.Parameters["@ONAY_DIREKTOR"].Value = CMBX_DIREKTOR_LIST.EditValue.ToString();
                        myCmd.Connection = myConnectionTable;
                        myCmd.ExecuteNonQuery();

                    }
                    using (SqlCommand myCmd = new SqlCommand())
                    {
                        myCmd.CommandText = " INSERT INTO  dbo.TODO_TIME_SHEET ( StartDate,EndDate , Subject, Location, Description, MAIL_ADRESI ,SIRKET_KODU,ONAY_DIREKTOR )" +
                                                                 " Values  (@StartDate,@EndDate , @Subject, @Location, @Description,@MAIL_ADRESI,@SIRKET_KODU,@ONAY_DIREKTOR)  ";
                        myCmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime); myCmd.Parameters["@StartDate"].Value = dt.ToString("yyyy-MM-dd 12:00:00", DateTimeFormatInfo.InvariantInfo);
                        myCmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime); myCmd.Parameters["@EndDate"].Value = dt.ToString("yyyy-MM-dd 13:00:00", DateTimeFormatInfo.InvariantInfo);
                        myCmd.Parameters.Add("@Subject", SqlDbType.NVarChar); myCmd.Parameters["@Subject"].Value = "Öğlen Tatili";
                        myCmd.Parameters.Add("@Location", SqlDbType.NVarChar); myCmd.Parameters["@Location"].Value = _GLOBAL_PARAMETERS._KULLANICI_MAIL;
                        myCmd.Parameters.Add("@Description", SqlDbType.NVarChar); myCmd.Parameters["@Description"].Value = "Öğlen Tatili";
                        myCmd.Parameters.Add("@MAIL_ADRESI", SqlDbType.NVarChar); myCmd.Parameters["@MAIL_ADRESI"].Value = _GLOBAL_PARAMETERS._KULLANICI_MAIL;
                        myCmd.Parameters.Add("@SIRKET_KODU", SqlDbType.NVarChar); myCmd.Parameters["@SIRKET_KODU"].Value = _GLOBAL_PARAMETERS._SIRKET_KODU;
                        myCmd.Parameters.Add("@ONAY_DIREKTOR", SqlDbType.NVarChar); myCmd.Parameters["@ONAY_DIREKTOR"].Value = CMBX_DIREKTOR_LIST.EditValue.ToString();
                        myCmd.Connection = myConnectionTable;
                        myCmd.ExecuteNonQuery();

                    }
                    using (SqlCommand myCmd = new SqlCommand())
                    {
                        myCmd.CommandText = " INSERT INTO  dbo.TODO_TIME_SHEET ( StartDate,EndDate , Subject, Location, Description, MAIL_ADRESI ,SIRKET_KODU,ONAY_DIREKTOR )" +
                                                                 " Values  (@StartDate,@EndDate , @Subject, @Location, @Description,@MAIL_ADRESI,@SIRKET_KODU,@ONAY_DIREKTOR)  ";
                        myCmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime); myCmd.Parameters["@StartDate"].Value = dt.ToString("yyyy-MM-dd 13:00:00", DateTimeFormatInfo.InvariantInfo);
                        myCmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime); myCmd.Parameters["@EndDate"].Value = dt.ToString("yyyy-MM-dd 18:00:00", DateTimeFormatInfo.InvariantInfo);
                        myCmd.Parameters.Add("@Subject", SqlDbType.NVarChar); myCmd.Parameters["@Subject"].Value = _MUSTERI_KODU.ToString();
                        myCmd.Parameters.Add("@Location", SqlDbType.NVarChar); myCmd.Parameters["@Location"].Value = _GLOBAL_PARAMETERS._KULLANICI_MAIL;
                        myCmd.Parameters.Add("@Description", SqlDbType.NVarChar); myCmd.Parameters["@Description"].Value = _MUSTERI_KODU;
                        myCmd.Parameters.Add("@MAIL_ADRESI", SqlDbType.NVarChar); myCmd.Parameters["@MAIL_ADRESI"].Value = _GLOBAL_PARAMETERS._KULLANICI_MAIL;
                        myCmd.Parameters.Add("@SIRKET_KODU", SqlDbType.NVarChar); myCmd.Parameters["@SIRKET_KODU"].Value = _GLOBAL_PARAMETERS._SIRKET_KODU;
                        myCmd.Parameters.Add("@ONAY_DIREKTOR", SqlDbType.NVarChar); myCmd.Parameters["@ONAY_DIREKTOR"].Value = CMBX_DIREKTOR_LIST.EditValue.ToString();
                        myCmd.Connection = myConnectionTable;
                        myCmd.ExecuteNonQuery();

                    }

                    dt = DTStart = DTStart.AddDays(1);
                }
                myConnectionTable.Close();

            }
            else
            {
                for (int i = 1; i <= ixt.Days; i++)
                {
                    DateTime dt = DTStart;
                    if (DTStart == myDTEnd) break;
                    if (dt.DayOfWeek == DayOfWeek.Saturday) { dt = DTStart = DTStart.AddDays(1); i++; }
                    if (dt.DayOfWeek == DayOfWeek.Sunday) { dt = DTStart = DTStart.AddDays(1); i++; }
                    AppointmentBaseCollection selectedApts = schedulerControls.SelectedAppointments;
                    Appointment apt = this.schedulerControls.Storage.CreateAppointment(AppointmentType.Normal);
                    SqlConnection myConnectionTable = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString());
                    myConnectionTable.Open();
                    SqlCommand myCmd = new SqlCommand();
                    myCmd.CommandText = " INSERT INTO  dbo.TODO_TIME_SHEET ( StartDate,EndDate , Subject, Location, Description, MAIL_ADRESI ,SIRKET_KODU,ONAY_DIREKTOR )" +
                                                             " Values  (@StartDate,@EndDate , @Subject, @Location, @Description,@MAIL_ADRESI,@SIRKET_KODU,@ONAY_DIREKTOR)  ";
                    myCmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime); myCmd.Parameters["@StartDate"].Value = dt.ToString("yyyy-MM-dd 09:00:00", DateTimeFormatInfo.InvariantInfo);
                    myCmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime); myCmd.Parameters["@EndDate"].Value = dt.ToString("yyyy-MM-dd 18:00:00", DateTimeFormatInfo.InvariantInfo);
                    myCmd.Parameters.Add("@Subject", SqlDbType.NVarChar); myCmd.Parameters["@Subject"].Value = _MUSTERI_KODU.ToString();
                    myCmd.Parameters.Add("@Location", SqlDbType.NVarChar); myCmd.Parameters["@Location"].Value = _GLOBAL_PARAMETERS._KULLANICI_MAIL;
                    myCmd.Parameters.Add("@Description", SqlDbType.NVarChar); myCmd.Parameters["@Description"].Value = _MUSTERI_KODU;
                    myCmd.Parameters.Add("@MAIL_ADRESI", SqlDbType.NVarChar); myCmd.Parameters["@MAIL_ADRESI"].Value = _GLOBAL_PARAMETERS._KULLANICI_MAIL;
                    myCmd.Parameters.Add("@SIRKET_KODU", SqlDbType.NVarChar); myCmd.Parameters["@SIRKET_KODU"].Value = _GLOBAL_PARAMETERS._SIRKET_KODU;
                    myCmd.Parameters.Add("@ONAY_DIREKTOR", SqlDbType.NVarChar); myCmd.Parameters["@ONAY_DIREKTOR"].Value = CMBX_DIREKTOR_LIST.EditValue.ToString();
                    myCmd.Connection = myConnectionTable;
                    myCmd.ExecuteNonQuery();
                    myCmd.Connection.Close();
                    dt = DTStart = DTStart.AddDays(1);
                }
            }
        }

    }
}