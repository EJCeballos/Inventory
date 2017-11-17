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

namespace Inventory
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
        

            InitializeComponent();
            this.Greeting.Text = "Hello, " + User.FirstName;
            UpdateDataGridView();
            Debug.WriteLine("The user is an Admin: "+User.Admin);
            Debug.WriteLine("The user Logged in is: " + User.UserName);
            Debug.WriteLine("The user's first name is: " + User.FirstName);
            Debug.WriteLine("The users last name is: " + User.LastName);
            Debug.WriteLine("The users email is:" + User.Email);
            //string AdminCheck = User.Admin;
            if (User.Admin!= "" )
            {
                //Debug.WriteLine("Make buttons visable");
                this.AdminButton1.Visible = true;
                this.AdminButton2.Visible = true;
            }
            else
            {
                this.AdminButton1.Visible = false;
                this.AdminButton2.Visible = false;
            }

          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //CheckIn Item
            CheckOut checkIn = new CheckOut(false);
            checkIn.ShowDialog();
            UpdateDataGridView();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            //CheckOut Item
            CheckOut checkOut = new CheckOut(true);
            checkOut.ShowDialog();
            UpdateDataGridView();
        }


        private void MainMenu_Activated(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }


        private void UpdateDataGridView()
        {
            string username = User.UserName;
            ModelID dataset = new ModelID();
            ModelIDTableAdapters.HistoryTableAdapter historyTableAdapter = new ModelIDTableAdapters.HistoryTableAdapter();
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            historyTableAdapter.FillHistoryCheckedOutMaterialInfobyUsername(dataset.History, username);
            DataTable table = historyTableAdapter.GetDataCheckedOutMaterialInfobyUsername(username);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = table;
            dataGridView1.AutoResizeColumn(1);
            dataGridView1.Refresh();

        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AdminButton1_Click(object sender, EventArgs e)
        {
            NewUser createUserForm = new NewUser();
            createUserForm.ShowDialog();
        }
    }
}
