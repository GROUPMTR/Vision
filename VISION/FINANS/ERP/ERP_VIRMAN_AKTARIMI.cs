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
using UnityObjects;
using System.Data.SqlClient;
namespace VISION.FINANS.ERP
{
    public partial class ERP_VIRMAN_AKTARIMI : DevExpress.XtraEditors.XtraForm
    {
        string GL_CODE_I = "";
        string GL_CODE_II = "";

        ADMIN.CL_CARD_LIST cl;
        public ERP_VIRMAN_AKTARIMI()
        {
            InitializeComponent();
            this.Tag = "MDIFORM";
            DateTime myDTStart = Convert.ToDateTime(DateTime.Now);
            dtBAS_TARIHI.EditValue = myDTStart.AddDays(-10).ToString("dd.MM.yyyy").ToString();
            dtBIT_TARIHI.EditValue = myDTStart.ToString("dd.MM.yyyy").ToString(); 
        }
        private void BTN_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
        DataTable workTable;
        private void btn_CARI_I_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            btn_CARI_I.Text = null;
            cl = new ADMIN.CL_CARD_LIST();
            cl.ShowDialog();

            FATURA_LIST();

            
        }

        private void btn_CARI_II_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GL_CODE_II = "";
            ADMIN.CL_CARD_LIST cl = new ADMIN.CL_CARD_LIST();
            cl.ShowDialog();
            btn_CARI_II.EditValue = cl.CARI_CODE;
            GL_CODE_II = cl.CARI_GL_CODE;
            LBL_UNVAN.Text = cl.CARI_UNVAN ;

        }
        private void BTN_LOGO_SECILENLERI_AKATAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UnityObjects.IData arpVoucher = default(UnityObjects.IData);
            UnityObjects.IData invObj = default(UnityObjects.IData);
            UnityObjects.Lines arpVoucherLines = default(UnityObjects.Lines);
            UnityObjects.Lines arpPaymentLines = default(UnityObjects.Lines);
            UnityObjects.Query UnityQuery = default(UnityObjects.Query);
            int i, m, k, cnt;
            int groupedRowCount = 0;
            int sign = 0;
            DateTime ficheDate;
            DateTime tempdate;


            for (int j = 0; j <= workTable.Rows.Count -1 ; j++)
            {

                if ((bool)workTable.Rows[j]["DECPRDIFF"] == true)
                {

                    arpVoucher = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doARAPVoucher);
                    arpVoucher.New();
                    arpVoucher.DataFields.FieldByName("NUMBER").Value = "~"; //workTable.Rows[j]["DOCODE"].ToString();  logo numara çakışmasından dolayı bu alanı düzelttik
                    ficheDate = (DateTime)workTable.Rows[j]["DATE_"];
                    arpVoucher.DataFields.FieldByName("DATE").Value = ficheDate;
                    arpVoucher.DataFields.FieldByName("TYPE").Value = 5;
                    arpVoucher.DataFields.FieldByName("CURRSEL_TOTALS").Value = 1;
                    arpVoucher.DataFields.FieldByName("CURRSEL_DETAILS").Value = 1;
                    arpVoucher.DataFields.FieldByName("DATE_CREATED").Value = DateTime.Now.ToShortDateString();
                    arpVoucher.DataFields.FieldByName("NOTES1").Value = workTable.Rows[j]["DOCODE"].ToString();//= "FT-" + workTable.Rows[j]["DOCODE"].ToString() + " " + workTable.Rows[j]["NOTES1"].ToString();
                    arpVoucher.DataFields.FieldByName("DATA_REFERENCE").Value = "~";
                    arpVoucherLines = arpVoucher.DataFields.FieldByName("TRANSACTIONS").Lines;
                    ///''''VİRMAN FİŞİ SATIR 1'''''''''''''''''''''''''''''''''''''''
                    ///
                    if (arpVoucherLines.AppendLine())
                    {
                        arpVoucherLines[0].FieldByName("ARP_CODE").Value = btn_CARI_II.EditValue;
                        arpVoucherLines[0].FieldByName("GL_CODE1").Value = GL_CODE_II;//clientAcc_2;
                        arpVoucherLines[0].FieldByName("CURR_TRANS").Value = 0;
                        arpVoucherLines[0].FieldByName("CURRSEL_TRANS").Value = 1;
                        arpVoucherLines[0].FieldByName("TC_XRATE").Value = 1;
                        arpVoucherLines[0].FieldByName("TC_AMOUNT").Value = Convert.ToDouble(workTable.Rows[j]["TOTAL"].ToString());
                        arpVoucherLines[0].FieldByName("DESCRIPTION").Value = "FT-" + workTable.Rows[j]["DOCODE"].ToString() + " " + workTable.Rows[j]["NOTES1"].ToString();
                        arpVoucherLines[0].FieldByName("DATA_REFERENCE").Value = "~";

                        switch (workTable.Rows[j]["TYPE"].ToString())
                        {
                            case "6":
                            case "7":
                            case "8":
                            case "9":
                            case "10":
                                arpVoucherLines[0].FieldByName("DEBIT").Value = Convert.ToDouble(workTable.Rows[j]["TOTAL"].ToString());
                                sign = 1;
                                break;

                            default:
                                arpVoucherLines[0].FieldByName("CREDIT").Value = Convert.ToDouble(workTable.Rows[j]["TOTAL"].ToString());
                                sign = 0; ;
                                break;
                        }

                    }
                    arpPaymentLines = arpVoucherLines._Item[0].FieldByName("PAYMENT_LIST").Lines;

                    if (arpPaymentLines.AppendLine())
                    {
                        if (workTable.Rows[j]["DUEDATE"].ToString() != "")
                        {
                            tempdate = Convert.ToDateTime(workTable.Rows[j]["DUEDATE"].ToString());
                            arpPaymentLines[0].FieldByName("MODULENR").Value = 5;
                            arpPaymentLines[0].FieldByName("DATE").Value = tempdate.ToShortDateString();
                            arpPaymentLines[0].FieldByName("TRCODE").Value = 5;
                            arpPaymentLines[0].FieldByName("SIGN").Value = sign;
                            arpPaymentLines[0].FieldByName("TOTAL").Value = Convert.ToDouble(workTable.Rows[j]["TOTAL"].ToString());
                            arpPaymentLines[0].FieldByName("DISCTRDELLIST").Value = 0;
                            arpPaymentLines[0].FieldByName("PAY_NO").Value = 1;
                            arpPaymentLines[0].FieldByName("MODIFIED").Value = 1;
                            arpPaymentLines[0].FieldByName("PROCDATE").Value = ficheDate;
                            arpPaymentLines[0].FieldByName("DISCOUNT_DUEDATE").Value = tempdate.ToShortDateString();
                            arpPaymentLines[0].FieldByName("TRCURR").Value = 0;
                            arpPaymentLines[0].FieldByName("TRRATE").Value = 1;
                        }
                    }

                    // ''''VİRMAN FİŞİ SATIR 2'''''''''''''''''''''''''''''''''''''''

                    if (arpVoucherLines.AppendLine())
                    {
                        arpVoucherLines[1].FieldByName("ARP_CODE").Value = btn_CARI_I.EditValue;
                        arpVoucherLines[1].FieldByName("GL_CODE1").Value = GL_CODE_I;// clientAcc_1;
                        arpVoucherLines[1].FieldByName("CURR_TRANS").Value = 0;
                        arpVoucherLines[1].FieldByName("CURRSEL_TRANS").Value = 1;
                        arpVoucherLines[1].FieldByName("TC_XRATE").Value = 1;
                        arpVoucherLines[1].FieldByName("TC_AMOUNT").Value = Convert.ToDouble(workTable.Rows[j]["TOTAL"].ToString());
                        arpVoucherLines[1].FieldByName("DESCRIPTION").Value = "FT-" + workTable.Rows[j]["DOCODE"].ToString() + " " + workTable.Rows[j]["NOTES1"].ToString();
                        switch (workTable.Rows[j]["TYPE"].ToString())
                        {
                            case "6":
                            case "7":
                            case "8":
                            case "9":
                            case "10":
                                arpVoucherLines[1].FieldByName("CREDIT").Value = Convert.ToDouble(workTable.Rows[j]["TOTAL"].ToString());
                                break;
                            default:
                                arpVoucherLines[1].FieldByName("DEBIT").Value = Convert.ToDouble(workTable.Rows[j]["TOTAL"].ToString());
                                break;
                        }
                        arpVoucherLines[1].FieldByName("DATA_REFERENCE").Value = "~";
                    }

                    arpPaymentLines = arpVoucherLines._Item[1].FieldByName("PAYMENT_LIST").Lines;
                    if (arpPaymentLines.AppendLine())
                    {
                        if (workTable.Rows[j]["DUEDATE"].ToString() != "")
                        {
                            tempdate = Convert.ToDateTime(workTable.Rows[j]["DUEDATE"].ToString());
                            arpPaymentLines[0].FieldByName("MODULENR").Value = 5;
                            arpPaymentLines[0].FieldByName("DATE").Value = tempdate.ToShortDateString();
                            arpPaymentLines[0].FieldByName("TRCODE").Value = 5;
                            arpPaymentLines[0].FieldByName("SIGN").Value = sign;
                            arpPaymentLines[0].FieldByName("TOTAL").Value = Convert.ToDouble(workTable.Rows[j]["TOTAL"].ToString());
                            arpPaymentLines[0].FieldByName("DISCTRDELLIST").Value = 0;
                            arpPaymentLines[0].FieldByName("PAY_NO").Value = 1;
                            arpPaymentLines[0].FieldByName("MODIFIED").Value = 1;
                            arpPaymentLines[0].FieldByName("PROCDATE").Value = ficheDate;
                            arpPaymentLines[0].FieldByName("DISCOUNT_DUEDATE").Value = tempdate.ToShortDateString();
                            arpPaymentLines[0].FieldByName("TRCURR").Value = 0;
                            arpPaymentLines[0].FieldByName("TRRATE").Value = 1;
                        }
                    }

                   // arpVoucher.ExportToXML("","c:\temp\aa.xml");
                    if (arpVoucher.Post())
                    {
                        //  UnityObjects.IData invObj = default(UnityObjects.IData);
                        Query Querys = _GLOBAL_PARAMETERS.Global.UnityApp.NewQuery();
                        string Query_String = " SELECT  LOGICALREF  FROM  dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO + "_01_INVOICE  where (FICHENO='" + workTable.Rows[j]["FICHENO"].ToString() + "')";
                        Querys.Statement = Query_String;
                        if (Querys.OpenDirect())
                        {
                            Querys.First();
                            switch (workTable.Rows[j]["TYPE"].ToString())
                            {
                                case "6":
                                case "7":
                                case "8":
                                case "9":
                                case "10":
                                    invObj = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doSalesInvoice);
                                    break;
                                default:
                                    invObj = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doPurchInvoice);
                                    break;
                            }
                            if (invObj.Read(Querys.QueryFields[0].Value))
                            {
                                invObj.DataFields.FieldByName("TRADING_GRP").Value = "FAC";

                                workTable.Rows[j]["DURUMU"] = "AKTARILDI";
                                 
                            }
                            invObj.Post();

                        }
                    }
                    else
                    {
                        if (arpVoucher.ValidateErrors.Count > 0)
                        {
                            for (int ix = 0; ix <= arpVoucher.ValidateErrors.Count - 1; ix++)
                            {
                                MessageBox.Show("Error code : " + (arpVoucher.ValidateErrors[ix].ID) + "Error code : " + (char)10 + arpVoucher.ValidateErrors[ix].Error.ToString());
                            }
                        }
                    }

                }
            }

        }

        private void BTN_LOGO_TUMUNU_SEC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int j = 0; j <= workTable.Rows.Count-1; j++)
            {
                
                if (workTable.Rows[j]["DECPRDIFF"].ToString()  == "True") workTable.Rows[j]["DECPRDIFF"] = false; else workTable.Rows[j]["DECPRDIFF"] = true;
                workTable.AcceptChanges();
            }

        }

        private void gridCntrl_LIST_Click(object sender, EventArgs e)
        {

        }

        private void BTN_EXPORT_EXCEL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = ".xlsx (*.xlsx)|*.xlsx";
            sfd.FileName = "EXPORT_FATURA.xlsx";
            DialogResult res = sfd.ShowDialog();
            if (res == DialogResult.OK)
            {
                gridView_LIST.ExportToXlsx(sfd.FileName);
            }
        }
          int CARI_CARIREF = 0;
        private void BTN_GUNCELLE_Click(object sender, EventArgs e)
        { 

            FATURA_LIST();
        }

        private void FATURA_LIST()
        {

            if (cl.CARI_LOGICALREF != null)
            {
                btn_CARI_I.EditValue = cl.CARI_CODE;
                GL_CODE_I = cl.CARI_GL_CODE;
                CARI_CARIREF = Convert.ToInt32(cl.CARI_LOGICALREF);

                gridCntrl_LIST.DataSource = null;
                workTable = null;
                workTable = new DataTable("Customers");//   DataColumn workCol = 
                workTable.Columns.Add("DECPRDIFF", typeof(Boolean));
                workTable.Columns.Add("DATE_", typeof(DateTime));
                workTable.Columns.Add("FICHENO", typeof(String));
                workTable.Columns.Add("DOCODE", typeof(String));
                workTable.Columns.Add("TRCODE", typeof(String));
                workTable.Columns.Add("TOTAL", typeof(Double));
                workTable.Columns.Add("DUEDATE", typeof(DateTime));
                workTable.Columns.Add("NOTES1", typeof(String));
                workTable.Columns.Add("TYPE", typeof(String));

                workTable.Columns.Add("DURUMU", typeof(String));
                //UnityObjects.IData doSlsInvoice = default(UnityObjects.IData);
                UnityObjects.Lines invLines = default(UnityObjects.Lines);

                DateTime BAS_TARIHI = Convert.ToDateTime(dtBAS_TARIHI.EditValue);
                DateTime BIT_TARIHI = Convert.ToDateTime(dtBIT_TARIHI.EditValue);
                string Querys = "";
                if (CMB_DURUMU.EditValue.ToString() == "AKTARILMAMIŞ") Querys = " SELECT LOGICALREF FROM dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_01_INVOICE  where (TRADINGGRP<>'FAC') AND (CLIENTREF='" + CARI_CARIREF + "') AND (DATE_ >=CONVERT(DATETIME, '" + BAS_TARIHI.ToString("yyyy-MM-dd 00:00:00") + "', 102))  AND (DATE_ <= CONVERT(DATETIME, '" + BIT_TARIHI.ToString("yyyy-MM-dd 00:00:00") + "', 102))";
                if (CMB_DURUMU.EditValue.ToString() == "AKTARILMIŞ") Querys = " SELECT LOGICALREF FROM dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO.ToString() + "_01_INVOICE  where (TRADINGGRP='FAC') AND (CLIENTREF='" + CARI_CARIREF + "') AND (DATE_ >=CONVERT(DATETIME, '" + BAS_TARIHI.ToString("yyyy-MM-dd 00:00:00") + "', 102))  AND (DATE_ <= CONVERT(DATETIME, '" + BIT_TARIHI.ToString("yyyy-MM-dd 00:00:00") + "', 102))";


                SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP);
                SqlCommand myCommandSub = new SqlCommand(Querys, Conn);
                Conn.Open();
                SqlDataReader doSl = myCommandSub.ExecuteReader(CommandBehavior.CloseConnection);
                while (doSl.Read())
                {
                    int itemRef = Convert.ToInt32(doSl["LOGICALREF"]);
                    UnityObjects.Data Itm = _GLOBAL_PARAMETERS.Global.UnityApp.NewDataObject(UnityObjects.DataObjectType.doPurchInvoice);
                    if (Itm.Read(itemRef))
                    {
                        DataRow row = workTable.NewRow();
                        row["DECPRDIFF"] = false;
                        row["DATE_"] = Itm.DataFields.FieldByName("DATE").Value;
                        row["FICHENO"] = Itm.DataFields.FieldByName("NUMBER").Value;
                        row["DOCODE"] = Itm.DataFields.FieldByName("DOC_NUMBER").Value;
                        row["TYPE"] = Itm.DataFields.FieldByName("TYPE").Value;
                        int ITEM = Convert.ToInt16(Itm.DataFields.FieldByName("TYPE").Value);

                        switch (ITEM)
                        {
                            case 1:
                                row["TRCODE"] = "MAL ALIM FATURASI";
                                break;
                            case 2:
                                row["TRCODE"] = "PERAKENDE S.İADE FATURASI";
                                break;
                            case 3:
                                row["TRCODE"] = "TOPTAN S. İADE FATURASI";
                                break;
                            case 4:
                                row["TRCODE"] = "ALINAN HİZMET FATURASI";
                                break;
                            case 5:
                                row["TRCODE"] = "ALINAN PROFORMA FATURA";
                                break;
                            case 6:
                                row["TRCODE"] = "ALIM İADE FATURASI";
                                break;
                            case 7:
                                row["TRCODE"] = "PERAKENDE SATIŞ FATURASI";
                                break;
                            case 8:
                                row["TRCODE"] = "TOPTAN SATIŞ FATURASI";
                                break;
                            case 9:
                                row["TRCODE"] = "VERİLEN HİZMET FATURASI";
                                break;
                            case 10:
                                row["TRCODE"] = "VERİLEN PROFORMA FATURA";
                                break;
                            //        case 13:
                            //   row["TRCODE"]="ALINAN FİYAT FARKI FAT.";
                            //break;
                            //        case 14:
                            //   row["TRCODE"]="VERİLEN FİYAT FARKI FATURASI";
                            //break;
                            //case 26:
                            //      row["TRCODE"]="MÜSTAHSİL MAKBUZU";
                            //   break;  
                        }
                        /// row["TRCODE"] = Itm.DataFields.FieldByName("TYPE").Value;
                        row["TOTAL"] = Itm.DataFields.FieldByName("TOTAL_NET").Value;
                        row["NOTES1"] = Itm.DataFields.FieldByName("NOTES1").Value;
                        //invLines = Itm.DataFields.FieldByName("PAYMENT_LIST").Lines;
                        //row["DUEDATE"] = invLines[0].FieldByName("DATE").Value;
                        workTable.Rows.Add(row);
                    }

                }
                gridCntrl_LIST.DataSource = workTable;
            }
        
        }
    }
}