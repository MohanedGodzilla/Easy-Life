namespace EasyLife
{
    partial class viewOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ordersData = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.newClassRoomBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.deleteClassRoomBTN = new System.Windows.Forms.Button();
            this.editClassRoomBTN = new System.Windows.Forms.Button();
            this.deleteAllBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ordersData)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ordersData
            // 
            this.ordersData.AllowUserToAddRows = false;
            this.ordersData.AllowUserToDeleteRows = false;
            this.ordersData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ordersData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ordersData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ordersData.Location = new System.Drawing.Point(0, 62);
            this.ordersData.Name = "ordersData";
            this.ordersData.ReadOnly = true;
            this.ordersData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ordersData.Size = new System.Drawing.Size(611, 382);
            this.ordersData.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ordersData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 444);
            this.panel1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(82, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(308, 24);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search";
            // 
            // newClassRoomBTN
            // 
            this.newClassRoomBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.newClassRoomBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newClassRoomBTN.Location = new System.Drawing.Point(3, 26);
            this.newClassRoomBTN.Name = "newClassRoomBTN";
            this.newClassRoomBTN.Size = new System.Drawing.Size(171, 37);
            this.newClassRoomBTN.TabIndex = 0;
            this.newClassRoomBTN.Text = "أضافه";
            this.newClassRoomBTN.UseVisualStyleBackColor = true;
            this.newClassRoomBTN.Click += new System.EventHandler(this.newClassRoomBTN_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.125F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.875F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.deleteClassRoomBTN, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.editClassRoomBTN, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.newClassRoomBTN, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.deleteAllBTN, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(620, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.86F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(177, 444);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // deleteClassRoomBTN
            // 
            this.deleteClassRoomBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.deleteClassRoomBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteClassRoomBTN.Location = new System.Drawing.Point(3, 158);
            this.deleteClassRoomBTN.Name = "deleteClassRoomBTN";
            this.deleteClassRoomBTN.Size = new System.Drawing.Size(171, 37);
            this.deleteClassRoomBTN.TabIndex = 2;
            this.deleteClassRoomBTN.Text = "مسح";
            this.deleteClassRoomBTN.UseVisualStyleBackColor = true;
            this.deleteClassRoomBTN.Click += new System.EventHandler(this.deleteClassRoomBTN_Click);
            // 
            // editClassRoomBTN
            // 
            this.editClassRoomBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.editClassRoomBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editClassRoomBTN.Location = new System.Drawing.Point(3, 92);
            this.editClassRoomBTN.Name = "editClassRoomBTN";
            this.editClassRoomBTN.Size = new System.Drawing.Size(171, 37);
            this.editClassRoomBTN.TabIndex = 1;
            this.editClassRoomBTN.Text = "تعديل";
            this.editClassRoomBTN.UseVisualStyleBackColor = true;
            this.editClassRoomBTN.Click += new System.EventHandler(this.editClassRoomBTN_Click);
            // 
            // deleteAllBTN
            // 
            this.deleteAllBTN.BackColor = System.Drawing.Color.Red;
            this.deleteAllBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.deleteAllBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteAllBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAllBTN.ForeColor = System.Drawing.SystemColors.Window;
            this.deleteAllBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteAllBTN.Location = new System.Drawing.Point(3, 293);
            this.deleteAllBTN.Name = "deleteAllBTN";
            this.deleteAllBTN.Size = new System.Drawing.Size(171, 45);
            this.deleteAllBTN.TabIndex = 3;
            this.deleteAllBTN.Text = "مسح الكل";
            this.deleteAllBTN.UseVisualStyleBackColor = false;
            this.deleteAllBTN.Click += new System.EventHandler(this.deleteAllBTN_Click);
            // 
            // viewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "viewOrder";
            this.Text = "viewOrder";
            ((System.ComponentModel.ISupportInitialize)(this.ordersData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView ordersData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button newClassRoomBTN;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button deleteClassRoomBTN;
        private System.Windows.Forms.Button editClassRoomBTN;
        public System.Windows.Forms.Button deleteAllBTN;
    }
}