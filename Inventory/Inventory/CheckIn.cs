using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Inventory
{
    public partial class CheckIn : Form
    {

        private string location;
        private string SerialNumber;


        public CheckIn()
        {
            InitializeComponent();
            
        }

    


        //Change Validation process to 

          

        private void Submit_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Input Recieved");
            string input = InputCheckin.Text;
            if (input.IndexOf('%') >= 0)
            {

                location = input.Replace("%", "");
                CheckInLabel.Text = "Please enter serial number:";
                InputCheckin.Text = "";
                InputCheckin.Select();
                Debug.WriteLine("Location Set");
            }
            else if (location == null && SerialNumber == null)
            {
                Debug.WriteLine("Error Occured");
                MessageBox.Show("Please enter a valid location.", "Critical Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                InputCheckin.Text = "";
            }
            else if (location != null && SerialNumber == null)
            {
                Debug.WriteLine("Serial Number set");
                errorProvider1.SetError(InputCheckin, "");
                SerialNumber = input;
                InputCheckin.Text = "";
                InputCheckin.Select();
                if (Data.CheckIn3002Stock(SerialNumber, location))
                {
                    this.Close();

                }
                else
                {
                    this.Close();
                    MessageBox.Show("Try again");
                }

            }


        }
        //Able to collect seial number and location from the user.
        //The only thing let would be to compile that data and process it.




        //private void InputCheckin_TextChanged(object sender, EventArgs e)
        //{ 


        //    bool locationType;
        //    Debug.WriteLine("Input Recieved"); 


        //    //This is where the text with in the object will come in
        //    string input = this.Text;
        //    //If index is above 0 then it is a location type, delete the '%' sign.
        //    if (input.IndexOf('%') >= 0)
        //    {
        //        locationType = true;
        //       // input.Replace("%", "");
        //    }
        //    else
        //    {
        //        locationType = false;
        //    }

        //    //Compare the item to make sure it is a location
        //    //If not set warning window active and clear text box
        //    if (locationType)
        //    {
        //       // InputCheckin.Text = "";
        //        CheckInLabel.Text = "Please Enter Serial Number:";
        //    }
        //    else
        //    //If so save variable clear textbox and change label
        //    {
        //        warningWindow warning = new warningWindow();
        //        warning.Text = "Please Scan a valid location before proceeding";
        //        errorProvider1.SetError(InputCheckin, "Please enter in a valid location");
        //       // warning.Show();
        //       // InputCheckin.Text = "";
        //    }

        //    // Create a Serial number validation function to call to verfy every serial number inputed  is valid.                  

        //    //Done button should be available.
        //    //Add current table ID to the thing.

        //}
    }
}
