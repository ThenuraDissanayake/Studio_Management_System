using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Frame : Form
    {
        public Frame()
        {
            InitializeComponent();
        }

        private void Frame_Load(object sender, EventArgs e)
        {
            LoadImages();
        }
        private void LoadImages()
        {
            // Specify the folder path where the images are located
            string folderPath = @"E:\New folder\system\sys_frame";

            // Clear the existing images in the ImageList control
            imageList1.Images.Clear();

            // Get the image file paths from the folder
            string[] imageFiles = Directory.GetFiles(folderPath, "*.jpg");

            // Iterate through the image file paths and add them to the ImageList control
            foreach (string imagePath in imageFiles)
            {
                // Load the image from file
                Image image = Image.FromFile(imagePath);

                // Add the image to the ImageList control
                imageList1.Images.Add(image);
            }

            // Set the ImageList control as the image source for the ListView control
            listView1.LargeImageList = imageList1;

            // Populate the ListView control with the images
            for (int i = 0; i < imageList1.Images.Count; i++)
            {
                // Create a ListViewItem and associate it with the corresponding image index
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;

                // Add the ListViewItem to the ListView control
                listView1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmHome home = new frmHome();
            home.Show();
            this.Close();
        }
    }
}
