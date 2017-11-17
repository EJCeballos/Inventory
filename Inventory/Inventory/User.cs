using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Inventory
{
    public class User
    {
        public static int UserID;
        public static string UserName;
        public static string Password;
        public static string Email;
        public static string FirstName;
        public static string LastName;
        public static string Admin;


        public User(string User, string admin, string firstName, string lastName)
        {

            UserName = User;
            Admin = admin;
            FirstName = firstName;
            LastName = lastName;

        }

        public static bool createUser(string first, string last, string email, string password, string userName, string admin)
        {
            string connectionString;
            SqlConnection con;

            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ceballose\source\repos\Inventory\Inventory\Inventory\3002Stock.mdf;Integrated Security=True;Connect Timeout=30";
            using (con = new SqlConnection(connectionString))
            {
                SqlCommand addUser = new SqlCommand("INSERT INTO Person VALUES(@userName, @password, @RFID, @email, @Admin, @first, @last)",con);

                addUser.Parameters.AddWithValue("userName", userName);
                addUser.Parameters.AddWithValue("password", password);
                addUser.Parameters.AddWithValue("RFID", DBNull.Value);
                addUser.Parameters.AddWithValue("email", email);
                addUser.Parameters.AddWithValue("Admin", admin);
                            
                addUser.Parameters.AddWithValue("first", first);
                addUser.Parameters.AddWithValue("last", last);

                con.Open();

                try
                {
                    addUser.ExecuteNonQuery();
                    MessageBox.Show("Database Successfully Updated");
                    con.Close();
                    return true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Issue connecting to Database");
                    throw ex;
                }
                

            }
        }

        public static string[] getUserLogin(string UserName, string password)
        {
            string connectionString;
            SqlConnection con;
            SqlDataReader dr;


            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ceballose\source\repos\Inventory\Inventory\Inventory\3002Stock.mdf;Integrated Security=True;Connect Timeout=30";
            using (con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("Select * from Person where Username= @Username", con);
                cmd.Parameters.AddWithValue("@Username", UserName);
                con.Open();

                Console.WriteLine("Connection Open!");
                dr = cmd.ExecuteReader();
                dr.Read();
                Console.WriteLine("Waiting on Reader");
                if (dr.HasRows == true)
                {
                    // MessageBox.Show("Username =" + dr[0].ToString() + " exists, login sucessful.");

                    string pass = dr[1].ToString();

                    if (pass == password)
                    {
                        // MessageBox.Show("Valid User! Continue!");
                        string[] user = new string[4];
                        user[0] = UserName;
                        user[1] = dr[4].ToString();
                        user[2] = dr[5].ToString();
                        user[3] = dr[6].ToString();
                      
                       
                        dr.Close();
                        return user;

                    }
                    else
                    {
                        dr.Close();
                        return null;

                    }

                }
                else
                {
                    //MessageBox.Show("UserName not found");
                    dr.Close();
                    return null;
                }
            }

        }
    }
}

