using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Inventory
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }




        /// <summary>
        /// 
        /// Create New User
        ///     By: Eric Ceballos
        ///     
        /// This will create a new user for the inventory system.
        ///     -This will require an RFID Scan
        ///     -Name
        ///     -Email
        ///     
        ///     Stored in each profile will be:
        ///     
        ///         -The items checked out under the user including
        ///             -Date checked out
        ///             -Email after 30 days of check out.
        ///             
        ///         -The history of items checked out and check in
        ///             -Date and Time stamped.
        ///             
        ///         -Traded Items will be saved for each indvidual.
        ///             -Items not properly checked in or checkout.
        ///             -Items lost by the individual.
        ///         
        ///
        /// 
        /// </summary>

        private void CreateNewValue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Open new form
           
            NewUser createUserForm = new NewUser();
            createUserForm.ShowDialog();
            
                //Request User to scan ID
                //Request users name
                //Request users password
                    //Double check password
                //Request Users email

            //Save the general data.

            //Start a datatable using the RFID ID.

            //Figure out data storage for this information
                //-Column 1: 

        }

        private void button1_Click(object sender, EventArgs e)
        {

        
            string UserName = this.UsernameInput.Text;
            string password = this.PasswordInput.Text;

            string[] userInfo = User.getUserLogin(UserName, password);
            if (userInfo != null)
            {
                User.UserName = userInfo[0];
                User.Admin = userInfo[1]; 
                User.FirstName = userInfo[2];
                User.LastName = userInfo[3];

                MainMenu Main = new MainMenu();
                Main.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.","Wrong!", MessageBoxButtons.OK);
            }
            //connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ceballose\source\repos\Inventory\Inventory\Inventory\3002Stock.mdf;Integrated Security=True;Connect Timeout=30";
            //using (con = new SqlConnection(connectionString))
            //{
                
            //    SqlCommand cmd = new SqlCommand("Select * from Person where Username= @Username", con);
            //    cmd.Parameters.AddWithValue("@Username", UserName);
            //    con.Open();

            //    Console.WriteLine("Connection Open!");
            //    dr = cmd.ExecuteReader();
            //    Console.WriteLine("ExecuteReader set!");
            //    dr.Read();
            //        Console.WriteLine("Waiting on Reader");
            //    if (dr.HasRows == true)
            //    {
            //        MessageBox.Show("Username =" + dr[0].ToString() + " exists, login sucessful.");

            //        string pass = dr[1].ToString();

            //        if (pass == password)
            //        {
            //            this.Hide();
            //            MessageBox.Show("Valid User! Continue!");
            //            //User information would be fill in from database

                        

            //            //Main Menu will be pull up from here.
            //            dr.Close();

            //            MainMenu main = new MainMenu();
            //            main.Show();

            //        }
            //        else
            //        {
            //            MessageBox.Show("Invalid Password please try again!");
            //            dr.Close();
            //        }

            //    }
            //    else
            //    {
            //        MessageBox.Show("UserName not found");
            //        dr.Close();
            //    }
                

            }
            
            }
        }
   

