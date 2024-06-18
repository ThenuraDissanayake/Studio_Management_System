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

namespace project
{
    public partial class Login : Form
    {
        private frmHome homeForm;

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\New folder\Studio Management System.mdf"";Integrated Security=True;Connect Timeout=30");
        public Login()
        {
            InitializeComponent();
            this.homeForm = homeForm;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String username = txtUname.Text;
            String password = txtPassword.Text;

            if(username == "" || password == "")
            {
                MessageBox.Show("Please enter values...");
            } else
            {
                Con.Open();
               

                using (SqlCommand command = new SqlCommand("select * from users where username = '"+ username +"'", Con))
                {
                    // Execute the query and obtain a SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if the reader has any rows
                        if (reader.HasRows)
                        {
                            // Read the data and assign it to variables
                            while (reader.Read())
                            {
                                // Read values from the reader and assign them to variables
                                int userID = reader.GetInt32(0);
                                string userName = reader.GetString(1);
                                string pass = reader.GetString(2);
                                string fullName = reader.GetString(3);
                                string tel = reader.GetString(4);

                                // Perform further processing with the retrieved values
                                if(password == pass)
                                {
                                    MessageBox.Show(userID+", "+username + ", " + pass + ", " + fullName + ", " + tel);
                                    frmHome home = new frmHome();
                                    this.Hide();
                                    home.Show();

                                   
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Password");
                                    txtPassword.Text = "";
                                    txtPassword.Focus();
                                }
                            }
                        } else
                        {
                            MessageBox.Show("Inavalid Username");
                            txtUname.Text = string.Empty;
                            txtUname.Focus();
                        }
                    }
                }
                Con.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUname.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
    }
}
