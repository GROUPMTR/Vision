using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace VISION.DOKUMAN
{
    public partial class EVRAK_PRINT : DevExpress.XtraReports.UI.XtraReport
    {
        public static DataTable tbl;

        public static string T_FATURANO;
        public static string T_ILGILIKISI;
        public static string T_FIRMA;
        public static string T_GONDEREN;
        public static string T_NOTU;
        public static string T_TARIH;
        public EVRAK_PRINT()
        {
            InitializeComponent();

      

            TXT_FATURANO.Text = T_FATURANO.ToString();
            TXT_ILGILIKISI.Text = T_ILGILIKISI.ToString();
            TXT_FIRMA.Text = T_FIRMA.ToString();
            TXT_GONDEREN.Text = T_GONDEREN.ToString();
            TXT_NOTU.Text = T_NOTU.ToString();
            TXT_TARIH.Text = T_TARIH.ToString();


         
            int srno = 1;
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                xrTables.InsertRowBelow(xrTables.Rows[srno]);

                xrTables.Rows[i].Cells[0].Text = srno.ToString();
             //   xrTables.Rows[i].Cells[0].TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
                xrTables.Rows[i].Cells[1].Text = tbl.Rows[i][1].ToString().Replace(" 00:00:00", "");
                xrTables.Rows[i].Cells[2].Text = tbl.Rows[i][2].ToString();
                xrTables.Rows[i].Cells[3].Text = tbl.Rows[i][3].ToString(); 
                //xrTable_LIST.Rows[i].Cells[4].Text = reader["BIRIM"].ToString();
                //xrTable_LIST.Rows[i].Cells[4].TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
                //xrTable_LIST.Rows[i].Cells[5].Text = reader["KALAN_MIKTAR"].ToString();
                //xrTable_LIST.Rows[i].Cells[5].TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
                //xrTable_LIST.Rows[i].Cells[12].Text = reader["BIRIM_FIYAT"].ToString();
                //xrTable_LIST.Rows[i].Cells[13].Text = reader["TUTAR"].ToString();
           
                srno++;
               
            }


 


            //XtraReport report = new XtraReport();
            //PageHeaderBand ph = new PageHeaderBand();
            //DetailBand dt = new DetailBand();
            //ReportFooterBand pf = new ReportFooterBand();
            //report.Bands.Add(ph);
            //report.Bands.Add(dt);
            //report.Bands.Add(pf);

         //   XRTable table = new XRTable();
         ////   table.WidthF = report.PageWidth - report.Margins.Left - report.Margins.Right;
         //   XRTableRow row = new XRTableRow();
         //   table.Rows.Add(row);

         //   XRTableCell cell = new XRTableCell();
         //   row.Cells.Add(cell);
         //   cell = new XRTableCell();
         //   row.Cells.Add(cell);
            
         //   XRTableCell parentCell = new XRTableCell();
         //   row.Cells.Add(parentCell);

         // //  XRTable table1 = new XRTable();
         //   XRTableRow row1 = new XRTableRow();
         //   XRTableRow row2 = new XRTableRow();

         //   xrTables.Rows.AddRange(new XRTableRow[] { row1, row2 });
         //   cell = new XRTableCell();
         //   cell.Text = "1";
         //   row1.Cells.Add(cell);
         //   cell = new XRTableCell();
         //   cell.Text = "2";
         //   row1.Cells.Add(cell);

         //   cell = new XRTableCell();
         //   cell.Text = "3";
         //   row2.Cells.Add(cell);
         //   cell = new XRTableCell();
         //   cell.Text = "4";
         //   row2.Cells.Add(cell);
            
         //   xrTables.BorderColor = Color.Red;
         //   xrTables.Borders = DevExpress.XtraPrinting.BorderSide.All;
         //   xrTables.WidthF = parentCell.WidthF;


         //   for (int i = 0; i < tbl.Rows.Count; i++)
         //   {
         //       for (int j = 0; j < tbl.Columns.Count - 1; j++)
         //       {
         //           // Create a new table cell and set its text and width.
         //           XRTableCell cell = new XRTableCell();
         //           cell.Text = tbl.Columns[j].ColumnName;
         //           //    cell.Width = 100;

         //           // Suspend the table's layout.
         //           xrTables.SuspendLayout();

         //           cell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", tbl, "TARIHI", "") });

         //           // Change the table.
         //           xrTables.Width = xrTables.Width + cell.Width;
         //           ((XRTableRow)xrTables.Rows[0]).Cells.Add(cell);

         //           // Perform the table's layout.
         //           xrTables.PerformLayout();

         //       }
         //   }



            //DataSet dataSet1 = new DataSet();
            //dataSet1.DataSetName = "SeismicSurveys";
            //DataTable dataTable1 = new DataTable();

            //dataSet1.Tables.Add(dataTable1);

            //dataTable1.TableName = "Table";
            //dataTable1.Columns.Add("Name", typeof(string));
            //dataTable1.Columns.Add("Type", typeof(string));

           
            //xrTables.DataSource = dataSet1;
            //xrTables.DataMember = dataTable1.TableName;

            //xrTables.DataBindings.Add("Text", null, tbl.Columns[0].Caption);
            //xrTables.DataBindings.Add("Text", null, tbl.Columns[1].Caption);



            //for (int i = 0; i < 10; i++)
            //{
            //    int row_number = i + 1;
            //    dataTable1.Rows.Add(new Object[] { "Row " + row_number.ToString(), "Type 1" });
            //}

            //XtraReport1 report = new XtraReport1();

            //report.DataSource = dataSet1;
            //report.DataMember = dataTable1.TableName;
            //report.xrTableCell1.DataBindings.Add("Text", null, dataTable1.Columns[0].Caption);
            //report.xrTableCell2.DataBindings.Add("Text", null, dataTable1.Columns[1].Caption);





            //for (int i = 0; i < tbl.Rows.Count; i++)
            //{
            //    for (int j = 0; j < tbl.Columns.Count - 1; j++)
            //    {
            //        // Create a new table cell and set its text and width.
            //        XRTableCell cell = new XRTableCell();
            //        cell.Text = tbl.Columns[j].ColumnName;
            //        //    cell.Width = 100;

            //        // Suspend the table's layout.
            //        xrTables.SuspendLayout();

            //        cell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", tbl, "TARIHI", "") });

            //        // Change the table.
            //        xrTables.Width = xrTables.Width + cell.Width;
            //        ((XRTableRow)xrTables.Rows[0]).Cells.Add(cell);

            //        // Perform the table's layout.
            //        xrTables.PerformLayout();

            //    }
            //}

        }

    }
}
