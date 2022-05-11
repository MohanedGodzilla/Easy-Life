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
    public partial class viewOrder : Form
    {
        public viewOrder()
        {
            InitializeComponent();
            loaddata();
        }

        public void loaddata()
        {
            this.ordersData.DataSource = client.establishConnection();
        }

        private void newClassRoomBTN_Click(object sender, EventArgs e)
        {
            addNewOrder addNewOrderPopup = new addNewOrder();
            DialogResult dialogResult = addNewOrderPopup.ShowDialog();
        }

        private void editClassRoomBTN_Click(object sender, EventArgs e)
        {
            addNewOrder addNewOrderPopup = new addNewOrder((int)ordersData.SelectedRows[0].Cells[0].Value);
            addNewOrderPopup.Text = "تعديل الطلب";
            addNewOrderPopup.ShowDialog(this);
        }

        private void deleteClassRoomBTN_Click(object sender, EventArgs e)
        {
            int selected_id = (int)ordersData.SelectedRows[0].Cells[0].Value;
            string message = "By clicking OK, this order will be permenantly DELETED\nmake sure from your choice";
            string title = "مسح الطلب نهائيا";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result != DialogResult.OK)
            {
                return;
            }
            else
            {
                client.delete(selected_id);
                this.loaddata();
                this.ordersData.Update();
                this.ordersData.Refresh();
                //---//
                MessageBox.Show("!!...تم مسح الطلب بنجاح");
            }
        }

        private void deleteAllBTN_Click(object sender, EventArgs e)
        {
            string message = "By clicking OK, All orders will be permenantly DELETED\nmake sure from your choice";
            string title = "مسح جميع الطلبات نهائيا";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result != DialogResult.OK)
            {
                return;
            }
            else
            {
                client.deleteAll();
                this.loaddata();
                this.ordersData.Update();
                this.ordersData.Refresh();
                //---//
                MessageBox.Show("!!...تم مسح الطلبات بنجاح");
            }
        }
    }
}
