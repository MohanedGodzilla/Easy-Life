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
using EasyLife.model;

namespace EasyLife
{
    public partial class viewComponents : Form
    {
        public viewComponents()
        {
            InitializeComponent();
            loaddata();
        }

        public void loaddata()
        {
            this.componentData.DataSource = component.establishConnection();
        }

        private void newClassRoomBTN_Click(object sender, EventArgs e)
        {
            addComponent addComponentPopup = new addComponent();
            DialogResult dialogResult = addComponentPopup.ShowDialog();
        }

        private void editClassRoomBTN_Click(object sender, EventArgs e)
        {
            addComponent addComponentPopup = new addComponent((int)componentData.SelectedRows[0].Cells[0].Value);
            addComponentPopup.Text = "تعديل المكون";
            addComponentPopup.ShowDialog(this);
        }

        private void deleteClassRoomBTN_Click(object sender, EventArgs e)
        {
            int selected_id = (int)componentData.SelectedRows[0].Cells[0].Value;
            string message = "By clicking OK, this component will be permenantly DELETED\nmake sure from your choice";
            string title = "مسح المكون نهائيا";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result != DialogResult.OK)
            {
                return;
            }
            else
            {
                component.delete(selected_id);
                this.loaddata();
                this.componentData.Update();
                this.componentData.Refresh();
                //---//
                MessageBox.Show("!!...تم مسح المكون بنجاح");
            } 
        }

        private void deleteAllBTN_Click(object sender, EventArgs e)
        {
            string message = "By clicking OK, All Components will be permenantly DELETED\nmake sure from your choice";
            string title = "مسح جميع المكونات نهائيا";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result != DialogResult.OK)
            {
                return;
            }
            else
            {
                component.deleteAll();
                this.loaddata();
                this.componentData.Update();
                this.componentData.Refresh();
                MessageBox.Show("!!...تم مسح المكونات بنجاح");
            }
        }
    }
}
