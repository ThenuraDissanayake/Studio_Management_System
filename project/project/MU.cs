using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project
{
    public partial class MU : Form
    {
        public MU()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\New folder\Studio Management System.mdf"";Integrated Security=True;Connect Timeout=30");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            
           
                Con.Open();
                SqlCommand cmd = Con.CreateCommand();
                cmd.CommandType= CommandType.Text;
                cmd.CommandText = "insert into users values('" + unameTb.Text + "','" + PasswordTb.Text + "','" + FnameTb.Text + "','" + PhoneTb.Text + "')";
                cmd.ExecuteNonQuery();
                Con.Close();
            MessageBox.Show("Add User successfully");
            disp_data();
            clearFields();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmHome home = new frmHome();
            home.Show();
            this.Close();
        }

        public void disp_data()
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from users";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            Con.Close();
        }

        private void MU_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a valid row is clicked (excluding header row)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Access the cell values from the selected row
                string id = selectedRow.Cells[0].Value.ToString();
                string username = selectedRow.Cells[1].Value.ToString();
                string fullname = selectedRow.Cells[3].Value.ToString();
                string password = selectedRow.Cells[2].Value.ToString();
                string telephone = selectedRow.Cells[4].Value.ToString();

                // Perform further processing with the values
                clearFields();

                txtPK.Text = id;
                unameTb.Text= username;
                FnameTb.Text= fullname;
                PasswordTb.Text= password;
                PhoneTb.Text= telephone;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete FROM users WHERE id='"+ txtPK.Text +"' ";
            cmd.ExecuteNonQuery();
            Con.Close();
            MessageBox.Show("Delete User successfully");
            disp_data();
            clearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE users SET username='"+ unameTb.Text +"', password='"+ PasswordTb.Text +"', fullname='"+ FnameTb.Text +"', telephone='"+ PhoneTb.Text +"' WHERE id='"+ txtPK.Text +"' ";
            cmd.ExecuteNonQuery();
            Con.Close();
            MessageBox.Show("Update User successfully");
            disp_data();
            clearFields();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
            unameTb.Focus();
        }

        public void clearFields()
        {
            txtPK.Text = null;
            unameTb.Text = null;
            FnameTb.Text = null;
            PasswordTb.Text = null;
            PhoneTb.Text = null;
        }
    }
}
