using EasyLife.model;
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
    public partial class addNewOrder : Form
    {
        viewOrder orderForm = (viewOrder)Application.OpenForms["viewOrder"];
        private int order_id;
        private int current_id;
        public List<int> checkedProducts;
        Dictionary<int, int> idIndexMap = new Dictionary<int, int>();
        Dictionary<int, int> indexIdMap = new Dictionary<int, int>();
        public addNewOrder()
        {
            InitializeComponent();
            addResourceBTN.Show();
            saveResourceBTN.Hide();
            loadData(false);
        }

        public addNewOrder(int Id)
        {
            InitializeComponent();
            addResourceBTN.Hide();
            saveResourceBTN.Show();
            this.order_id = Id;
            viewDataInEditForm(Id);
            loadData(true);
        }

        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                checkedProducts.Add(indexIdMap[e.Index]);
            else
                checkedProducts.Remove(indexIdMap[e.Index]);
        }

        void loadData(bool isEdit)
        {
            if (checkedProducts == null)
            {
                checkedProducts = new List<int>();
            }
            using (SqlConnection cn = new SqlConnection(env.connectionString))
            {
                cn.Open();
                getProducts(cn);
                if (isEdit)
                {
                    checkedProducts = new List<int>();
                    loadSelected(cn);
                }
                checkSelected();
                checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;
            }
        }

        void getProducts(SqlConnection cn)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM product", cn))
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int productId = (int)dt.Rows[i]["id"];
                    this.idIndexMap[productId] = i;
                    this.indexIdMap[i] = productId;
                    checkedListBox1.Items.Add(dt.Rows[i]["name"].ToString());
                }
            }
        }

        private void viewDataInEditForm(int id)
        {
            using (SqlConnection cn = new SqlConnection(env.connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM client WHERE id=" + id, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clientName.Text = reader.GetValue(1).ToString();
                    richTextBox2.Text = reader.GetValue(2).ToString();
                    richTextBox1.Text = reader.GetValue(3).ToString();
                    richTextBox3.Text = reader.GetValue(4).ToString();
                }
                reader.Close();
                
                cmd.CommandText = "SELECT * FROM client_orders_product WHERE client_id = "+ id;
                SqlDataReader reader2 = cmd.ExecuteReader();
                while (reader2.Read())
                {
                    richTextBox4.Text = reader2.GetValue(3).ToString();
                    richTextBox5.Text = reader2.GetValue(4).ToString();
                    richTextBox6.Text = reader2.GetValue(5).ToString();
                }
                reader2.Close();
                cn.Close();
            }

        }

        void loadSelected(SqlConnection cn)
        {
            string query = "SELECT product_id FROM client_orders_product WHERE client_id = " + this.order_id;
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader.GetValue(0);
                    checkedProducts.Add(id);
                }
                reader.Close();
            }
        }


        void checkSelected()
        {
            for (int i = 0; i < checkedProducts.Count(); i++)
            {
                checkedListBox1.SetItemChecked(this.idIndexMap[checkedProducts[i]], true);
            }
        }

        private void addResourceBTN_Click(object sender, EventArgs e)
        {
            client.insert(clientName.Text.ToString(), richTextBox2.Text.ToString(), richTextBox1.Text.ToString(), richTextBox3.Text.ToString());
            this.current_id = client.getTheMaxId();
            for (int i = 0; i < checkedProducts.Count(); i++)
            {
                clientOrderProduct.insert(this.current_id, checkedProducts[i],richTextBox4.Text.ToString(),richTextBox5.Text.ToString(),richTextBox6.Text.ToString());
            }
            this.Close();
            orderForm.loaddata();
            orderForm.ordersData.Update();
            orderForm.ordersData.Refresh();
        }

        private void saveResourceBTN_Click(object sender, EventArgs e)
        {
            client.update(this.order_id,clientName.Text.ToString(), richTextBox2.Text.ToString(), richTextBox1.Text.ToString(), richTextBox3.Text.ToString());
            clientOrderProduct.delete(this.order_id);
            for (int i = 0; i < checkedProducts.Count(); i++)
            {
                clientOrderProduct.insert(this.order_id, checkedProducts[i], richTextBox4.Text.ToString(), richTextBox5.Text.ToString(), richTextBox6.Text.ToString());
            }
            MessageBox.Show("تم التعديل بنجاح");
            this.Close();
            orderForm.loaddata();
            orderForm.ordersData.Update();
            orderForm.ordersData.Refresh();
        }

        private void cancelResourceBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
