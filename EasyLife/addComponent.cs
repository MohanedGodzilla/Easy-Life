using EasyLife.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyLife
{
    public partial class addComponent : Form
    {
        viewComponents comForm = (viewComponents)Application.OpenForms["viewComponents"];
        private int component_id;
        public addComponent()
        {
            InitializeComponent();
            addResourceBTN.Show();
            saveResourceBTN.Hide();
        }

        public addComponent(int Id) // constructor to get resourceName from (dataset)=>resourceData
        {
            InitializeComponent();
            addResourceBTN.Hide();
            saveResourceBTN.Show();
            this.component_id = Id;
            viewDataInEditForm(Id);
        }

        private void viewDataInEditForm(int id) {
            using (SqlConnection cn = new SqlConnection(env.connectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM component WHERE id=" + id, cn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        componentName.Text = reader.GetValue(1).ToString();
                        numericUpDown1.Value = (int)reader.GetValue(2);
                        richTextBox1.Text = reader.GetValue(3).ToString();
                        byte[] data = (byte[])reader.GetValue(4);
                        MemoryStream ms = new MemoryStream(data);
                        pictureBox1.Image = Image.FromStream(ms);
                        
                        
                    }
                    reader.Close();
                }
                cn.Close();
            }
            
        }

        private void addResourceBTN_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            component.insert(componentName.Text.ToString(), (int)numericUpDown1.Value, richTextBox1.Text.ToString(), img);
            this.Close();
            //--the following three lines is used to update the dataGridView and refresh it --//
            comForm.loaddata();
            comForm.componentData.Update();
            comForm.componentData.Refresh();
            //---//
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                if (ofd.ShowDialog() == DialogResult.OK) {
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void saveResourceBTN_Click(object sender, EventArgs e)
        {
            component.update(this.component_id, componentName.Text.ToString(), (int)numericUpDown1.Value, richTextBox1.Text.ToString(), pictureBox1.Image);
            MessageBox.Show("تم التعديل بنجاح");
            this.Close();
            //--the following three lines is used to update the dataGridView and refresh it --//
            comForm.loaddata();
            comForm.componentData.Update();
            comForm.componentData.Refresh();
            //---//
        }

        private void cancelResourceBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
