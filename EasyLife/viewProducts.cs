using EasyLife.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyLife
{
    public partial class viewProducts : Form
    {
        public viewProducts()
        {
            InitializeComponent();
            loaddata();
        }

        public void loaddata()
        {
            this.productsData.DataSource = product.establishConnection();
        }

        private void newClassRoomBTN_Click(object sender, EventArgs e)
        {
            addProduct addProductPopup = new addProduct();
            DialogResult dialogResult = addProductPopup.ShowDialog();
        }

        private void editClassRoomBTN_Click(object sender, EventArgs e)
        {
            addProduct addProductPopup = new addProduct((int)productsData.SelectedRows[0].Cells[0].Value);
            addProductPopup.Text = "تعديل المنتج";
            addProductPopup.ShowDialog(this);
        }

        private void deleteClassRoomBTN_Click(object sender, EventArgs e)
        {
            int selected_id = (int)productsData.SelectedRows[0].Cells[0].Value;
            string message = "By clicking OK, this product will be permenantly DELETED\nmake sure from your choice";
            string title = "مسح المنتج نهائيا";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result != DialogResult.OK)
            {
                return;
            }
            else
            {
                product.delete(selected_id);
                this.loaddata();
                this.productsData.Update();
                this.productsData.Refresh();
                //---//
                MessageBox.Show("!!...تم مسح المكون بنجاح");
            }
        }

        private void deleteAllBTN_Click(object sender, EventArgs e)
        {
            string message = "By clicking OK, All products will be permenantly DELETED\nmake sure from your choice";
            string title = "مسح جميع المنتجات نهائيا";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result != DialogResult.OK)
            {
                return;
            }
            else
            {
                product.deleteAll();
                this.loaddata();
                this.productsData.Update();
                this.productsData.Refresh();
                //---//
                MessageBox.Show("!!...تم مسح المكون بنجاح");
            }
        }
    }
}
