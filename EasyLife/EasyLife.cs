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

namespace EasyLife
{
    public partial class EasyLife : Form
    {
        public EasyLife()
        {
            InitializeComponent();
            orders_view();
            maintenance_view();
            products_view();
            components_view();
            numOFOrders();
        }

        public void numOFOrders()
        {
            using (SqlConnection cn = new SqlConnection(env.connectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT count(id) from client_orders_product", cn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        label3.Text = reader.GetValue(0).ToString();
                    }
                    reader.Close();
                    cmd.CommandText = "Select count(id) from maintenance";
                    SqlDataReader reader2 = cmd.ExecuteReader();
                    while (reader2.Read())
                    {
                        label5.Text = reader2.GetValue(0).ToString();
                    }
                }
                cn.Close();
            }

        }

        private void orders_view()
        {
            viewOrder frm = new viewOrder() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.tabPage1.Controls.Add(frm);
            frm.Show();
        }
        private void maintenance_view()
        {
            viewMaintenance frm = new viewMaintenance() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.tabPage2.Controls.Add(frm);
            frm.Show();
        }
        private void products_view()
        {
            viewProducts frm = new viewProducts() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.tabPage3.Controls.Add(frm);
            frm.Show();
        }
        private void components_view()
        {
            viewComponents frm = new viewComponents() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.tabPage4.Controls.Add(frm);
            frm.Show();
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(env.connectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT count(id) from client_orders_product", cn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        label3.Text = reader.GetValue(0).ToString();
                    }
                    reader.Close();
                    cmd.CommandText = "Select count(id) from maintenance";
                    SqlDataReader reader2 = cmd.ExecuteReader();
                    while (reader2.Read())
                    {
                        label5.Text = reader2.GetValue(0).ToString();
                    }
                }
                cn.Close();
            }
        }
    }
}
