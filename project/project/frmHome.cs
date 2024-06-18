using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            MU mu = new MU();
            mu.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCM_Click(object sender, EventArgs e)
        {
            CU cu = new CU();
            cu.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Locations lo = new Locations();
            lo.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frame frame = new Frame(); 
            frame.Show(); 
            this.Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
