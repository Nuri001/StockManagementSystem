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

namespace IMS
{
    public partial class ProductForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8EVFSCK\SQLEXPRESS;Initial Catalog=IMS;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        SqlDataReader reader;
        public ProductForm()
        {
            InitializeComponent();
            LoadProduct();
            
        }


        void checkUnstockProducts()
        {

            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                if (Convert.ToInt16(row.Cells[5].Value) <= 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }

        }


        void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            command = new SqlCommand("SELECT * FROM tblProduct WHERE CONCAT(name, price, category, description) LIKE '%"+txtSearch.Text+"%'", connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, reader[0].ToString(), reader[1].ToString(), reader[4].ToString(), reader[3].ToString(), reader[2].ToString(), reader[5].ToString());

            }
            reader.Close();
            connection.Close();
            checkUnstockProducts();
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ProductModuleForm productModule = new ProductModuleForm();

            productModule.btnSave.Enabled = true;
            productModule.btnUpdate.Enabled = false;

            productModule.ShowDialog();
            LoadProduct();

        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                ProductModuleForm productModule = new ProductModuleForm();
                productModule.txtName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                productModule.txtDes.Text= dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
                productModule.txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                productModule.txtQuantity.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                productModule.comboQ.Text= dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                productModule.lblId.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                productModule.lblId.Visible = true;
                productModule.lbl01.Visible = true;
                productModule.btnSave.Enabled = false;
                productModule.btnUpdate.Enabled = true;
       
                productModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("are you sure you want to delete this product?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    connection.Open();
                    command = new SqlCommand("DELETE FROM tblProduct WHERE id=@id", connection);
                    command.Parameters.AddWithValue("@id", dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString());
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Record has been successfully deleted");

                }

            }
            LoadProduct();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
    }
}
