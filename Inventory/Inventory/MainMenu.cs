using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Inventory
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {


            InitializeComponent();
            this.Greeting.Text = "Hello, " + User.FirstName;
            //UpdateDataGridView();
            Debug.WriteLine("The user is an Admin: " + User.Admin);
            Debug.WriteLine("The user Logged in is: " + User.UserName);
            Debug.WriteLine("The user's first name is: " + User.FirstName);
            Debug.WriteLine("The users last name is: " + User.LastName);
            Debug.WriteLine("The users email is:" + User.Email);
            //string AdminCheck = User.Admin;
            if (User.Admin != "")
            {
                //Debug.WriteLine("Make buttons visable");
                this.menuStrip1.Visible = true;

            }
            else
            {
                this.menuStrip1.Visible = false;
            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //CheckIn Item
            CheckInCheckOut checkIn = new CheckInCheckOut(false);
            checkIn.ShowDialog();
            //UpdateDataGridView();
            checkIn.Dispose();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            //CheckOut Item
            CheckInCheckOut checkOut = new CheckInCheckOut(true);
            checkOut.ShowDialog();
            //UpdateDataGridView();
            checkOut.Dispose();
        }


        private void MainMenu_Activated(object sender, EventArgs e)
        {
            //UpdateDataGridView();
        }

        public struct checkedoutByUser
        {
            public string dateTime;
            public string UserName;
            public string Status;
            public string MaterialName;
        }



        public void InitcheckoutByUserStruct(string dateTime, string UserName, string Status, string MaterialName)
        {
            List<checkedoutByUser> items = new List<checkedoutByUser>();
            var cd = new checkedoutByUser();
           
        }       

            //string username = User.UserName;
            //SqlCommand getMainStock = new SqlCommand("SELECT MainStock.SerialNumber, MainStock.Location, MaterialID.MaterialName, MaterialID.MaterialDescription, MaterialID.Valuable FROM MainStock INNER JOIN  MaterialID ON MainStock.MaterialID = MaterialID.MaterialID");
            //SqlDataReader dr = getMainStock.ExecuteReader();
            //dr.Read();


            //this.Validate();
            //this.historyBindingSource.EndEdit();

            //this.historyTableAdapter.FillHistoryCheckedOutMaterialInfobyUsername(this.modelID.History, username);


            //DataTable table = historyTableAdapter.GetDataCheckedOutMaterialInfobyUsername(username);
            //dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.DataSource = null;
            //dataGridView1.DataSource = table;
            //dataGridView1.AllowUserToAddRows = false;
            //dataGridView1.AllowUserToDeleteRows = false;
            //dataGridView1.AutoGenerateColumns = true;
            //dataGridView1.AllowUserToOrderColumns = false;
            //dataGridView1.AllowDrop = false;
            //dataGridView1.AutoResizeColumn(1);
            //dataGridView1.Refresh();
            //dataGridView1.ClearSelection();



       
        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void createNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUser createUserForm = new NewUser();
            createUserForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchDataBase search = new SearchDataBase();
            search.ShowDialog();
            search.Dispose();

        }

        private void updateModelIDSpreadsheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if(file.ShowDialog() == DialogResult.OK)
            {
                string FilePath = file.FileName;
                MessageBox.Show(FilePath);
            }


            

        }

        private void MainMenu_Deactivate(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }
    }
}
