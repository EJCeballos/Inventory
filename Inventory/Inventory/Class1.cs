using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Inventory
{
    class Stock
    { 
       // private string Location;
       // private string SerialNumber;
       // private DataSet newStock;
       // private DataTable Current;
       //// private stockDataSet.MainStockDataTable stockTable;
       // private DataTable History;
       // private DataTable Archieve;
       // private DataTable ModelIDLookup;

       // /// <summary>
       // ///     Stock Constructor
       // ///             by: Eric Ceballos
       // ///             
       // ///     This will filter in the input and out put as needed.
       // /// 
       // /// 
       // /// </summary>
       // /// <param name="SerialNumberInput"></param>
       // /// <param name="LocationName"></param>
       // /// 

       // public Stock()
       // {

       //    // stockDataSet stock = new stockDataSet();
       //     Current = stock.MainStock;
       //     newStock = stock;
       //     Archieve = stock.Archive;
       //     ModelIDLookup = stock.IDModelNumber;

       // }

       // public void AchieveAndClearStock()
       // {
       //     //Build a New WorkBook
       //     string excelName;
       //     excelName = DateTime.Now.ToString("yyyyMM");

       //     Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

       //     if (xlApp == null)
       //     {
       //         MessageBox.Show("Excel is not properly installed!");
       //         return;
       //     }

       //     Excel.Workbook xlWorkBook;
       //     Excel.Worksheet xlWorksheet;
       //     object misValue = System.Reflection.Missing.Value;

       //     xlWorkBook = xlApp.Workbooks.Add(misValue);
       //     xlWorksheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

       //     xlWorksheet.Cells[1, 1] = "Serial Number";
       //     xlWorksheet.Cells[1, 2] = "Locaiton";
       //     xlWorksheet.Cells[1, 3] = "4-Digit ID";
       //     xlWorksheet.Cells[1, 4] = "Model Number";

       //     Excel.Range formatRange;

       //     formatRange = xlWorksheet.get_Range("A1", "D1");
       //     formatRange.Font.Size = 10;
       //     formatRange.Style = "Heading 1";

       //     int RowCount = Current.Rows.Count;
       //     object[,] Cells = new object[RowCount, 4];

       //     for(int j=1; j < RowCount; j++)
       //     {
       //         for(int i=1; i<4; i++)
       //         {
       //             Cells[j, i] = Current.Rows[j][i];
       //         }
       //     }



       //     //Try to save the new work book
       //     try
       //     {
       //         xlWorkBook.SaveAs(@"C:\Users\Ceballose\Documents\Inventory\"+ excelName +".xlsx" , misValue, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlNoChange,
       //             misValue, misValue, misValue, misValue, misValue);
       //         MessageBox.Show("An Excel File was created");
       //     }

       //     //Catch to a messagebox which will then close and quit the Excel file
       //     //Also close all COM Objects
       //     catch
       //     {

       //         MessageBox.Show("The Workbook is potentially open", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
       //         xlWorkBook.Close(true, misValue, misValue);
       //         xlApp.Quit();
       //         Marshal.ReleaseComObject(xlWorksheet);
       //         Marshal.ReleaseComObject(xlWorkBook);
       //         Marshal.ReleaseComObject(xlApp);
       //     }

       // }




       // /// <summary>
       // /// FilterSerialNumber()
       // ///         by:Eric Ceballos
       // ///         
       // ///     This will filter the serial number to meet any general requirement needed
       // ///             so far:
       // ///                 -Make sure all are upper case.
       // ///                 
       // /// 
       // /// </summary>
       // /// <returns></returns>
       // private string FilterSerialNumber()
       // {
       //     string filterNumber;
       //     filterNumber = SerialNumber.ToUpper();

       //     return filterNumber;
       // }


       // public void addToStock(DataTable Stock)
       // {
       //     if(Location == null)
       //     {
       //         Debug.WriteLine("Location Empty Please fill");
       //     }
       //     else
       //     {

       //         DataRow newStockRow = Stock.NewRow();
       //         newStockRow["serialNumber"] = SerialNumber;
       //         newStockRow["Location"] = Location;
       //         try
       //         {
       //             Stock.Rows.Add(newStockRow);
       //         }
       //         catch
       //         {
       //             MessageBox.Show("Please ensure location name 10 characters or less",
       //                 "Warning",
       //                 MessageBoxButtons.OK,
       //                 MessageBoxIcon.Error);
       //         }
       //     }

            //Email Portion to Email Cindy.


       // }
        
    }
}
