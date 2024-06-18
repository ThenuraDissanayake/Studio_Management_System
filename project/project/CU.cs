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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Remoting.Contexts;

namespace project
{
    public partial class CU : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\New folder\Studio Management System.mdf"";Integrated Security=True;Connect Timeout=30");
        public CU()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CU_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into customers values('" + textBox2.Text + "','" + textBox3.Text + "')";
            cmd.ExecuteNonQuery();
            Con.Close();
            MessageBox.Show("Add Customer successfully");
            CU_Load(sender, e);
        }
        public void disp_data()
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from customers";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            Con.Close();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmHome home = new frmHome();
            home.Show();
            this.Close();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a valid row is clicked (excluding header row)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Access the cell values from the selected row
                string id = selectedRow.Cells[0].Value.ToString();
                string customername = selectedRow.Cells[1].Value.ToString();
                string tel = selectedRow.Cells[2].Value.ToString();

                // Perform further processing with the values
                clearFields();

                txtPK.Text = id;
                textBox2.Text = customername;
                textBox3.Text = tel;
            }
        }

        public void clearFields()
        {
            txtPK.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE customers SET customer_name='" + textBox2.Text + "', phone_no='" + textBox3.Text + "' WHERE id='" + txtPK.Text + "' ";
            cmd.ExecuteNonQuery();
            Con.Close();
            MessageBox.Show("Update Customer successfully");
            disp_data();
            clearFields();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete FROM customers WHERE id='" + txtPK.Text + "' ";
            cmd.ExecuteNonQuery();
            Con.Close();
            MessageBox.Show("Delete Customer successfully");
            disp_data();
            clearFields();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            {
                clearFields();
                textBox2.Focus();
            }
        }
    }
}





