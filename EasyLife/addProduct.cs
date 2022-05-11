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
    public partial class addProduct : Form
    {
        viewProducts productForm = (viewProducts)Application.OpenForms["viewProducts"];
        private int product_id;
        private int current_id;
        public List<int> checkedComponents;
        Dictionary<int, int> idIndexMap = new Dictionary<int, int>();
        Dictionary<int, int> indexIdMap = new Dictionary<int, int>();

        public addProduct()
        {
            InitializeComponent();
            addResourceBTN.Show();
            saveResourceBTN.Hide();
            loadData(false);
        }

        public addProduct(int Id)
        {
            InitializeComponent();
            addResourceBTN.Hide();
            saveResourceBTN.Show();
            this.product_id = Id;
            viewDataInEditForm(Id);
            loadData(true);
        }
        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                checkedComponents.Add(indexIdMap[e.Index]);
            else
                checkedComponents.Remove(indexIdMap[e.Index]);
        }

        void loadData(bool isEdit)
        {
            if (checkedComponents == null)
            {
                checkedComponents = new List<int>();
            }
            using (SqlConnection cn = new SqlConnection(env.connectionString))
            {
                cn.Open();
                getComponents(cn);
                if (isEdit)
                {
                    checkedComponents = new List<int>();
                    loadSelected(cn);
                }
                checkSelected();
                checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;
            }
        }

        void getComponents(SqlConnection cn)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM component", cn))
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int progId = (int)dt.Rows[i]["id"];
                    this.idIndexMap[progId] = i;
                    this.indexIdMap[i] = progId;
                    checkedListBox1.Items.Add(dt.Rows[i]["name"].ToString());
                }
            }
        }

        private void viewDataInEditForm(int id)
        {
            using (SqlConnection cn = new SqlConnection(env.connectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM product WHERE Id=" + id, cn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        productName.Text = reader.GetValue(1).ToString();
                        numericUpDown1.Value = (int)reader.GetValue(2);
                        richTextBox6.Text = reader.GetValue(3).ToString();
                    }
                    reader.Close();
                }
                cn.Close();
            }

        }

        void loadSelected(SqlConnection cn)
        {
            string query = "SELECT component_id FROM product_has_component WHERE product_id = " + this.product_id;
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader.GetValue(0);
                    checkedComponents.Add(id);
                }
                reader.Close();
            }
        }
        

        void checkSelected()
        {
            for (int i = 0; i < checkedComponents.Count(); i++)
            {
                checkedListBox1.SetItemChecked(this.idIndexMap[checkedComponents[i]], true);
            }
        }

        private void addResourceBTN_Click(object sender, EventArgs e)
        {
            product.insert(productName.Text.ToString(), (int)numericUpDown1.Value, richTextBox6.Text.ToString());
            this.current_id = product.getTheMaxId();
            for (int i = 0; i < checkedComponents.Count(); i++)
            {
                productHasComponent.insert(this.current_id, checkedComponents[i]);
            }
            this.Close();
            productForm.loaddata();
            productForm.productsData.Update();
            productForm.productsData.Refresh();
        }

        private void saveResourceBTN_Click(object sender, EventArgs e)
        {
            product.update(this.product_id, productName.Text.ToString(), (int)numericUpDown1.Value, richTextBox6.Text.ToString());
            productHasComponent.delete(this.product_id);
            for (int i = 0; i < checkedComponents.Count(); i++)
            {
                productHasComponent.insert(this.product_id, checkedComponents[i]);
            }
            MessageBox.Show("تم التعديل بنجاح");
            this.Close();
            //--the following three lines is used to update the dataGridView and refresh it --//
            productForm.loaddata();
            productForm.productsData.Update();
            productForm.productsData.Refresh();
        }

        private void cancelResourceBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}