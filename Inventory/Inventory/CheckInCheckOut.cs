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
    public partial class CheckInCheckOut : Form
    {
        private bool command;
        private string location;
        private string FilteredSerialNumber;

        public CheckInCheckOut(bool checkInOrCheckOut)
        {
            InitializeComponent();
            command = checkInOrCheckOut;
            //Setup for Check out
            if(command == true)
            {
                this.DirectionLabel.Text = "Please enter Serial Number:";
                this.Text = "Checking Out";
            }
            else
            {
                this.DirectionLabel.Text = "Please Enter Location:";
                this.Text = "Checking in";
            }

        }

        private void submitCheckOut_Click(object sender, EventArgs e)
        {
            string username = User.UserName;
            string serialNumber = this.CheckOutInput.Text;
            if (command == true)
            {
                if (Data.CheckOut3002Stock(serialNumber, username))
                     MessageBox.Show("Sucessful");
                CheckOutInput.Text = "";
                CheckOutInput.Select();
            }
            else
            {
                
                if (serialNumber.IndexOf('%') >= 0)
                {

                    location = serialNumber.Replace("%", "");
                    DirectionLabel.Text = "Please enter serial number:";
                    CheckOutInput.Text = "";
                    CheckOutInput.Select();
                    Debug.WriteLine("Location Set");
                }
                else if (location == null && FilteredSerialNumber == null)
                {
                    Debug.WriteLine("Error Occured");
                    MessageBox.Show("Please enter a valid location.", "Critical Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    CheckOutInput.Text = "";
                }
                else if (location != null && FilteredSerialNumber == null)
                {
                    Debug.WriteLine("Serial Number set");
                    FilteredSerialNumber = serialNumber;
                    CheckOutInput.Text = "";
                    CheckOutInput.Select();
                    if (Data.CheckIn3002Stock(FilteredSerialNumber, location))
                    {
                        this.Close();
                        location = null;
                        FilteredSerialNumber = null;
                        MessageBox.Show("Success");
                    }
                    else
                    {
                        location = null;
                        FilteredSerialNumber = null;
                        this.Close();
                        MessageBox.Show("Try again");
                    }

                }
            }
            

           
        }
    }
}
