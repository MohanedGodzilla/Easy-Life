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
    public partial class viewMaintenance : Form
    {
        public viewMaintenance()
        {
            InitializeComponent();
            loaddata();
        }

        public void loaddata()
        {
            this.maintenanceData.DataSource = maintenance.establishConnection();
        }

        private void newClassRoomBTN_Click(object sender, EventArgs e)
        {
            addMaintenance addMaintenacePopup = new addMaintenance();
            DialogResult dialogResult = addMaintenacePopup.ShowDialog();
        }

        private void editClassRoomBTN_Click(object sender, EventArgs e)
        {
            addMaintenance addMaintenacePopup = new addMaintenance((int)maintenanceData.SelectedRows[0].Cells[0].Value);
            addMaintenacePopup.Text = "تعديل ملف الصيانه";
            addMaintenacePopup.ShowDialog(this);
        }

        private void deleteClassRoomBTN_Click(object sender, EventArgs e)
        {
            int selected_id = (int)maintenanceData.SelectedRows[0].Cells[0].Value;
            string message = "By clicking OK, this maintenance will be permenantly DELETED\nmake sure from your choice";
            string title = "مسح ملف الصيانه نهائيا";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result != DialogResult.OK)
            {
                return;
            }
            else
            {
                maintenance.delete(selected_id);
                this.loaddata();
                this.maintenanceData.Update();
                this.maintenanceData.Refresh();
                //---//
                MessageBox.Show("!!...تم مسح ملف الصيانه بنجاح");
            }
        }

        private void deleteAllBTN_Click(object sender, EventArgs e)
        {
            string message = "By clicking OK, All maintenances will be permenantly DELETED\nmake sure from your choice";
            string title = "مسح جميع ملفات الصيانه نهائيا";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result != DialogResult.OK)
            {
                return;
            }
            else
            {
                maintenance.deleteAll();
                this.loaddata();
                this.maintenanceData.Update();
                this.maintenanceData.Refresh();
                MessageBox.Show("!!...تم مسح ملفات الصيانه بنجاح");
            }
        }
    }
}
