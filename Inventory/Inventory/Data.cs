using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Inventory
{
    class Data
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

        public static bool CheckIn3002Stock(string serialNumber, string location)
        {
            string connectionString;
            SqlConnection con;
            string ModelID = null;
            try
            {

                ModelID = serialNumber.Substring(0, 4);
            }
            catch
            {
                MessageBox.Show("Please enter a valid serial number");
                return false;
            }


            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ceballose\source\repos\Inventory\Inventory\Inventory\3002Stock.mdf;Integrated Security=True;Connect Timeout=30";
            using (con = new SqlConnection(connectionString))
            {
               
            //SQL Checks

                //Check Mainstock to make sure the Item is in there.
                SqlCommand checkMainStock = new SqlCommand("Select * from MainStock where SerialNumber= @serialNumber", con);
                checkMainStock.Parameters.AddWithValue("serialNumber", serialNumber);


            //SQL Updates

                //Update history check in: Status
                SqlCommand updateHistory = new SqlCommand("Update History SET Status = @status WHERE (SerialNumber = @serialNumber) AND (Status IS Null)", con);
                updateHistory.Parameters.AddWithValue("status", "In");
                updateHistory.Parameters.AddWithValue("serialNumber", serialNumber);


                //Update Mainstock check in: Location
                SqlCommand updateLocationInMainStock = new SqlCommand("UPDATE MainStock SET Location =  @location WHERE SerialNumber = @serialNumber", con);
                updateLocationInMainStock.Parameters.AddWithValue("location", location);
                updateLocationInMainStock.Parameters.AddWithValue("serialNumber", serialNumber);
               
               
                con.Open();
                //Check Mainstack for Item
                SqlDataReader dr = checkMainStock.ExecuteReader();
                dr.Read();

                if (dr.HasRows == true)
                {
                    dr.Close();
                    //Update Stock and History
                    try
                    {
                        updateLocationInMainStock.ExecuteNonQuery();
    //Split these and ensure to add to history if not present already
                        updateHistory.ExecuteNonQuery();
                        Console.WriteLine("Update Line in command.");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not connect to server!");
                        throw ex;
                    }

                }
                else
                {
                    dr.Close();
                    //SQL ADD command to add item to stock

                    SqlCommand addToStock = new SqlCommand("INSERT into MainStock VALUES(@serialNumber, @ModelId, @Location)", con);
                    addToStock.Parameters.AddWithValue("serialNumber", serialNumber);
                    addToStock.Parameters.AddWithValue("ModelId", ModelID);
                    addToStock.Parameters.AddWithValue("Location", location);

                    Console.WriteLine("Connection Open!");
                    
                    try
                    {

                        addToStock.ExecuteNonQuery();

                        con.Close();
                        Console.WriteLine("Database updated");
                        Console.WriteLine("Database sucessfully updated");

                        //This is where a new item would be present and Email support can be updated from here informing the Stock manager
                        //making sure it is in Stock.
                        //User that checked Item in.
                        MessageBox.Show("This is a new Item! This is where we an email notification will be sent out to the stock manager to add stock to SAP");
                        return true;



                    }
                    catch
                    {
                        Console.WriteLine("Database could not be updated");
                        con.Close();
                        return false;


                    }
                }

            }
        }

        public static bool CheckOut3002Stock(string serialNumber, string Person)
        {
            string connectionString;
            SqlConnection con;
            DateTime date = DateTime.Now;
            string sqlDate = date.ToString("yyy-MM-dd HH:mm:ss");
            //Get ModelID out of SerialNumber
            string ModelID = null;
            try
            {

                ModelID = serialNumber.Substring(0, 4);
            }
            catch
            {
                MessageBox.Show("Please enter a valid serial number");
                return false;
            }

            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ceballose\source\repos\Inventory\Inventory\Inventory\3002Stock.mdf;Integrated Security=True;Connect Timeout=30";
            using (con = new SqlConnection(connectionString))
            {
             //SQL check commands
                
                //MainStock: Ensure it's in stock
                SqlCommand checkMainStock = new SqlCommand("Select * from MainStock where SerialNumber= @serialNumber", con);
                checkMainStock.Parameters.AddWithValue("serialNumber", serialNumber);

                //Check ModelID: Ensure it's a valid serial number
                SqlCommand checkModelID = new SqlCommand("Select * From MaterialID Where MaterialID = @ModelID", con);
                checkModelID.Parameters.AddWithValue("ModelId", ModelID);

                //Check History: Incase it's checked out already
                SqlCommand checkHistory = new SqlCommand("SELECT * FROM History WHERE (SerialNumber = @serialNumber) AND (Status IS NULL)", con);
                checkHistory.Parameters.AddWithValue("serialNumber", serialNumber);

            //SQL Update Commands

                //Update History if already check out: "Trade" where status is NULL username is not the same.
                SqlCommand MarkItemAsTradedInHistory = new SqlCommand("UPDATE History SET Status = @Traded WHERE (serialNumber = @serialNumber) AND (Status IS Null) AND (Person <> @username)", con);
                MarkItemAsTradedInHistory.Parameters.AddWithValue("serialNumber", serialNumber);
                MarkItemAsTradedInHistory.Parameters.AddWithValue("Traded", "Traded");
                MarkItemAsTradedInHistory.Parameters.AddWithValue("userName", Person);

                //Update History: DATETIME, Username, serialNumber, MaterialID, Status
                SqlCommand inputIntoHistory = new SqlCommand("Insert INTO History Values( @dateTime, @Person, @serialNumber, @MaterialID, @status)", con);
                inputIntoHistory.Parameters.AddWithValue("Person", Person);
                inputIntoHistory.Parameters.AddWithValue("serialNumber", serialNumber);
                inputIntoHistory.Parameters.AddWithValue("MaterialID", ModelID);
                inputIntoHistory.Parameters.AddWithValue("Status", DBNull.Value);
                inputIntoHistory.Parameters.AddWithValue("dateTime", sqlDate);

                //Update MainSTock: Set Location to Username
                SqlCommand UpdateMainStock = new SqlCommand("UPDATE MainStock SET Location = @user  WHERE serialNumber = @serialNumber", con);
                UpdateMainStock.Parameters.AddWithValue("user", Person);
                UpdateMainStock.Parameters.AddWithValue("serialNumber", serialNumber);


                con.Open();
                SqlDataReader dr = checkModelID.ExecuteReader();
                dr.Read();
                //If there is a ModelID
                if (dr.HasRows == true)
                {
                    dr.Close();
                    dr = checkMainStock.ExecuteReader();
                    dr.Read();
                    //If the item is in Stock
                   if(dr.HasRows == true)
                    {
                        dr.Close();
                        dr = checkHistory.ExecuteReader();
                        dr.Read();
                        //This checks if the item is in History
                        if (dr.HasRows == true)
                        {
                            dr.Close();
                            //If it is already checked out do you want to trade
                            DialogResult result = MessageBox.Show("Already Checked Out. Do you want to trade items or cancel ", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if (result == System.Windows.Forms.DialogResult.Yes)
                            {
                                //Mark Item and and insert new history check out
                                try
                                {
                                    //Potential Logic error here
                                    MarkItemAsTradedInHistory.ExecuteNonQuery();
                                    dr = checkHistory.ExecuteReader();
                                    dr.Read();
                                    if (dr.HasRows == true)
                                    {
                                        dr.Close();
                                        MessageBox.Show("Item already checked out.");
                                    }
                                    else
                                    {
                                        dr.Close();
                                        //Combine in one try catch?
                                        try
                                        {
                                            inputIntoHistory.ExecuteNonQuery();
                                            try
                                            {
                                                UpdateMainStock.ExecuteNonQuery();
                                            }
                                            catch
                                            {
                                                MessageBox.Show("Could not update MainStock for some reason.");
                                            }
                                        }
                                        catch
                                        {
                                            MessageBox.Show("Could not update in history");
                                        }

                                    }

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Could not mark the item as a trade in history. Please make sure the Item is not already checked out to you.\n" + ex);

                                }
                            }
                            else
                            {
                                MessageBox.Show("You didn't accomplish anything. Please try again");
                            }
                        }
                        else
                        {
                            dr.Close();

                            try
                            {
                                inputIntoHistory.ExecuteNonQuery();
                                try
                                {
                                    UpdateMainStock.ExecuteNonQuery();
                                }
                                catch
                                {
                                    MessageBox.Show("Could not update MainStock for some reason.");
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Could not record action");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Does not exist in MainStock. Emailing Administrator to check stock, and adding to MainStock");

                    }
                    //If there it is in stock already
                }
                else
                {
                    MessageBox.Show("This is an unknown item please make sure to scan the correct serial number or update the modelID list.");
                   
                }
                MessageBox.Show("This worked");
                dr.Close();
                con.Close();
                return false;
            }
        }

        public static void UpdateMaterialID()
        {

        }
        

    


        

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
