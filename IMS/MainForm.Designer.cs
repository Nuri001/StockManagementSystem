namespace IMS
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOrders = new IMS.CustomerButton();
            this.btnUsers = new IMS.CustomerButton();
            this.btnCategories = new IMS.CustomerButton();
            this.btnCustomers = new IMS.CustomerButton();
            this.lblo = new System.Windows.Forms.Label();
            this.lblu = new System.Windows.Forms.Label();
            this.lblc2 = new System.Windows.Forms.Label();
            this.lblc1 = new System.Windows.Forms.Label();
            this.lblp = new System.Windows.Forms.Label();
            this.btnProducts = new IMS.CustomerButton();
            this.label3 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btnOrders);
            this.panel1.Controls.Add(this.btnUsers);
            this.panel1.Controls.Add(this.btnCategories);
            this.panel1.Controls.Add(this.btnCustomers);
            this.panel1.Controls.Add(this.lblo);
            this.panel1.Controls.Add(this.lblu);
            this.panel1.Controls.Add(this.lblc2);
            this.panel1.Controls.Add(this.lblc1);
            this.panel1.Controls.Add(this.lblp);
            this.panel1.Controls.Add(this.btnProducts);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1139, 140);
            this.panel1.TabIndex = 0;
            // 
            // btnOrders
            // 
            this.btnOrders.Image = ((System.Drawing.Image)(resources.GetObject("btnOrders.Image")));
            this.btnOrders.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnOrders.ImageHover")));
            this.btnOrders.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnOrders.ImageNormal")));
            this.btnOrders.Location = new System.Drawing.Point(779, 64);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(53, 40);
            this.btnOrders.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnOrders.TabIndex = 13;
            this.btnOrders.TabStop = false;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Image = ((System.Drawing.Image)(resources.GetObject("btnUsers.Image")));
            this.btnUsers.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnUsers.ImageHover")));
            this.btnUsers.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnUsers.ImageNormal")));
            this.btnUsers.Location = new System.Drawing.Point(655, 64);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(53, 40);
            this.btnUsers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnUsers.TabIndex = 13;
            this.btnUsers.TabStop = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.Image = ((System.Drawing.Image)(resources.GetObject("btnCategories.Image")));
            this.btnCategories.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnCategories.ImageHover")));
            this.btnCategories.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnCategories.ImageNormal")));
            this.btnCategories.Location = new System.Drawing.Point(529, 64);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(53, 40);
            this.btnCategories.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCategories.TabIndex = 13;
            this.btnCategories.TabStop = false;
            this.btnCategories.Click += new System.EventHandler(this.ntmCategories_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomers.Image")));
            this.btnCustomers.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnCustomers.ImageHover")));
            this.btnCustomers.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnCustomers.ImageNormal")));
            this.btnCustomers.Location = new System.Drawing.Point(410, 64);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(53, 40);
            this.btnCustomers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCustomers.TabIndex = 13;
            this.btnCustomers.TabStop = false;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // lblo
            // 
            this.lblo.AutoSize = true;
            this.lblo.Font = new System.Drawing.Font("Narkisim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblo.ForeColor = System.Drawing.Color.White;
            this.lblo.Location = new System.Drawing.Point(779, 112);
            this.lblo.Name = "lblo";
            this.lblo.Size = new System.Drawing.Size(58, 13);
            this.lblo.TabIndex = 3;
            this.lblo.Text = "ORDERS";
            // 
            // lblu
            // 
            this.lblu.AutoSize = true;
            this.lblu.Font = new System.Drawing.Font("Narkisim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblu.ForeColor = System.Drawing.Color.White;
            this.lblu.Location = new System.Drawing.Point(658, 112);
            this.lblu.Name = "lblu";
            this.lblu.Size = new System.Drawing.Size(47, 13);
            this.lblu.TabIndex = 3;
            this.lblu.Text = "USERS";
            // 
            // lblc2
            // 
            this.lblc2.AutoSize = true;
            this.lblc2.Font = new System.Drawing.Font("Narkisim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblc2.ForeColor = System.Drawing.Color.White;
            this.lblc2.Location = new System.Drawing.Point(514, 112);
            this.lblc2.Name = "lblc2";
            this.lblc2.Size = new System.Drawing.Size(91, 13);
            this.lblc2.TabIndex = 3;
            this.lblc2.Text = "CATEGORIES";
            // 
            // lblc1
            // 
            this.lblc1.AutoSize = true;
            this.lblc1.Font = new System.Drawing.Font("Narkisim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblc1.ForeColor = System.Drawing.Color.White;
            this.lblc1.Location = new System.Drawing.Point(391, 112);
            this.lblc1.Name = "lblc1";
            this.lblc1.Size = new System.Drawing.Size(87, 13);
            this.lblc1.TabIndex = 2;
            this.lblc1.Text = "CUSTOMERS";
            // 
            // lblp
            // 
            this.lblp.AutoSize = true;
            this.lblp.Font = new System.Drawing.Font("Narkisim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblp.ForeColor = System.Drawing.Color.White;
            this.lblp.Location = new System.Drawing.Point(278, 112);
            this.lblp.Name = "lblp";
            this.lblp.Size = new System.Drawing.Size(76, 13);
            this.lblp.TabIndex = 1;
            this.lblp.Text = "PRODUCTS";
            // 
            // btnProducts
            // 
            this.btnProducts.Image = ((System.Drawing.Image)(resources.GetObject("btnProducts.Image")));
            this.btnProducts.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnProducts.ImageHover")));
            this.btnProducts.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnProducts.ImageNormal")));
            this.btnProducts.Location = new System.Drawing.Point(291, 64);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(53, 40);
            this.btnProducts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnProducts.TabIndex = 12;
            this.btnProducts.TabStop = false;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(391, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(323, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "STOCK MANAGEMENT SYSTEM";
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 140);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1139, 569);
            this.mainPanel.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1098, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 709);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label3;
        private CustomerButton btnProducts;
        private Label lblo;
        private Label lblu;
        private Label lblc2;
        private Label lblc1;
        private Label lblp;
        private CustomerButton btnOrders;
        private CustomerButton btnUsers;
        private CustomerButton btnCategories;
        private CustomerButton btnCustomers;
        private Panel mainPanel;
        private PictureBox pictureBox2;
    }
}