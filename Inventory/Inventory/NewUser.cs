using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
  //Move to user class?
            string fullname = this.fullNameInput.Text;
            string validEmail = "@br-automation.com";
            string email = null;
            string password = null;
            string username = null;
            string firstName = null;
            string lastName = null;
            string Admin = null;


            //Split the name up into first and last;
            var names = fullname.Split(' ');
            if (names.Length > 0)
            {
                MessageBox.Show("First Name: " + names[0]);
               firstName = names[0];
                MessageBox.Show("Last Name: " + names[names.Length-1]);
                lastName = names[names.Length-1];
            }

            //Check email to make sure it's a valid Br-autmoations email.
            string temp = this.emailInput.Text;
            int tempIndex = temp.IndexOf('@');
            if (tempIndex >= 0)
            {
                int temp2 = temp.Length - tempIndex;
                string yes = temp.Substring(tempIndex, temp2 );
                MessageBox.Show(yes);
                int result = String.Compare(yes, validEmail);
                if (result == 0)
                {
                    MessageBox.Show("Email set");
                    email = this.emailInput.Text;
                }
            }

            //Username validation

            temp = this.usernameInput.Text;
            if(temp.IndexOf(" ") < 0)
            {
                MessageBox.Show("Username Set");
                username = temp;
            }

            //Password Validation
            temp = this.passwordInput.Text;
            if (temp.IndexOf(" ") < 0)
            {
                MessageBox.Show("Password Set");
                password = temp;
            }
            if (AdminCheckBox.Checked)
            {
                Admin = "Yes";
            }
            else
            {
                Admin = "";
            }
  
            //Make sure all the credentials are met.
            if (firstName != null && lastName != null && email != null && password != null && username != null)
            {
                MessageBox.Show("Create new user");
                User.createUser(firstName, lastName, email, password, username, Admin);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please ensure your filled out te form correctly.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }


            
        }
    }
}
