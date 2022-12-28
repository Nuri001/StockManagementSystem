using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS
{
    public partial class MainForm : Form
    {

        Font bigFont= new Font("Narkisim", 12, FontStyle.Bold);
        Font normalFont = new Font("Narkisim", 10, FontStyle.Bold);
        public MainForm()
        {
            InitializeComponent();
        }

        //to show subForm in MainForm
        private Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(childForm);
            mainPanel.Tag = childForm;
            childForm.BringToFront();



            childForm.Show();

        }

        public void MakeAllNotCurrent()
        {
            btnUsers.makeNoteCurrent();
            btnOrders.makeNoteCurrent();
            btnCustomers.makeNoteCurrent();
            btnProducts.makeNoteCurrent();
            btnCategories.makeNoteCurrent();
            lblp.Font = normalFont;
            lblo.Font = normalFont;
            lblu.Font = normalFont;
            lblc1.Font = normalFont;
            lblc2.Font = normalFont;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            openChildForm(new UserForm());
            MakeAllNotCurrent();
            btnUsers.makeCurrent();
            lblu.Font = bigFont;
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            openChildForm(new CustomerForm());
            MakeAllNotCurrent();
            btnCustomers.makeCurrent();
            lblc1.Font = bigFont;
        }

        private void ntmCategories_Click(object sender, EventArgs e)
        {
            openChildForm(new CategoryForm());
            MakeAllNotCurrent();
            btnCategories.makeCurrent();
            lblc2.Font = bigFont;

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
           
            openChildForm(new ProductForm());
            MakeAllNotCurrent();
            btnProducts.makeCurrent();
            lblp.Font = bigFont;

        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderForm());
            MakeAllNotCurrent();
            btnOrders.makeCurrent();
            lblo.Font = bigFont;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
