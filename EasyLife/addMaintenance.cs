using System;
using EasyLife.model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyLife
{
    public partial class addMaintenance : Form
    {
        viewMaintenance maintenanceForm = (viewMaintenance)Application.OpenForms["viewMaintenance"];
        private int maintenance_id;
        public addMaintenance()
        {
            InitializeComponent();
            addResourceBTN.Show();
            saveResourceBTN.Hide();
        }
        public addMaintenance(int Id)
        {
            InitializeComponent();
            addResourceBTN.Hide();
            saveResourceBTN.Show();
            this.maintenance_id = Id;
            viewDataInEditForm(Id);
        }

        private void viewDataInEditForm(int id)
        {
            using (SqlConnection cn = new SqlConnection(env.connectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM maintenance WHERE id=" + id, cn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        maintenanceName.Text = reader.GetValue(1).ToString();
                        phoneBox.Text = reader.GetValue(2).ToString();
                        richTextBox1.Text = reader.GetValue(3).ToString();
                    }
                    reader.Close();
                }
                cn.Close();
            }

        }

        private void addResourceBTN_Click(object sender, EventArgs e)
        {
            maintenance.insert(maintenanceName.Text.ToString(),phoneBox.Text.ToString(), richTextBox1.Text.ToString());
            this.Close();
            //--the following three lines is used to update the dataGridView and refresh it --//
            maintenanceForm.loaddata();
            maintenanceForm.maintenanceData.Update();
            maintenanceForm.maintenanceData.Refresh();
            //---//
        }
        private void saveResourceBTN_Click(object sender, EventArgs e)
        {
            maintenance.update(this.maintenance_id, maintenanceName.Text.ToString(), phoneBox.Text.ToString(), richTextBox1.Text.ToString());
            MessageBox.Show("تم التعديل بنجاح");
            this.Close();
            //--the following three lines is used to update the dataGridView and refresh it --//
            maintenanceForm.loaddata();
            maintenanceForm.maintenanceData.Update();
            maintenanceForm.maintenanceData.Refresh();
            //---//
        }

        private void cancelResourceBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
