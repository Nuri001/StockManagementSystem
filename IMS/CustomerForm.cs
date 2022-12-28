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
    public partial class CustomerForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8EVFSCK\SQLEXPRESS;Initial Catalog=IMS;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        SqlDataReader reader;
        public CustomerForm()
        {
            InitializeComponent();
            LoadCustomer();
        }

        public void LoadCustomer()
        {
            int i = 0;
            dgvCustomer.Rows.Clear();
            command = new SqlCommand("SELECT * FROM tbCustomer", connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, reader[0].ToString(), reader[1].ToString(), reader[2].ToString());

            }
            reader.Close();
            connection.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            CustomerModuleForm customerModule = new CustomerModuleForm();

            customerModule.btnSave.Enabled = true;
            customerModule.btnUpdate.Enabled = false;

            customerModule.ShowDialog();
            LoadCustomer();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            String colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                CustomerModuleForm CustomerModule = new CustomerModuleForm();
                CustomerModule.txtName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                CustomerModule.txtPhone.Text = dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                CustomerModule.lblId.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                CustomerModule.lblId.Visible = true;
                CustomerModule.lbl01.Visible = true;
                CustomerModule.btnSave.Enabled = false;
                CustomerModule.btnUpdate.Enabled = true;

                CustomerModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("are you sure you want to delete this customer?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    connection.Open();
                    command = new SqlCommand("DELETE FROM tbCustomer WHERE id=@id", connection);
                    command.Parameters.AddWithValue("@id", dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString());
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Record has been successfully deleted");

                }

            }
            LoadCustomer();

        }
    }
}
