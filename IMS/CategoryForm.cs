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
    public partial class CategoryForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8EVFSCK\SQLEXPRESS;Initial Catalog=IMS;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        SqlDataReader reader;
        public CategoryForm()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            int i = 0;
            dgvCategory.Rows.Clear();
            command = new SqlCommand("SELECT * FROM tblCategory", connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                i++;
                dgvCategory.Rows.Add(i, reader[0].ToString(), reader[1].ToString());

            }
            reader.Close();
            connection.Close();
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String colName = dgvCategory.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
               CategoryModuleForm CategoryModule = new CategoryModuleForm();
                CategoryModule.txtName.Text = dgvCategory.Rows[e.RowIndex].Cells[2].Value.ToString();
                CategoryModule.lblId.Text = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                CategoryModule.lblId.Visible = true;
                CategoryModule.lbl01.Visible = true;
                CategoryModule.btnSave.Enabled = false;
                CategoryModule.btnUpdate.Enabled = true;

                CategoryModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("are you sure you want to delete this Category?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    connection.Open();
                    command = new SqlCommand("DELETE FROM tblCategory WHERE id=@id", connection);
                    command.Parameters.AddWithValue("@id", dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString());
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Record has been successfully deleted");

                }

            }
            LoadCategory();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            CategoryModuleForm categoryModule = new CategoryModuleForm();

            categoryModule.btnSave.Enabled = true;
            categoryModule.btnUpdate.Enabled = false;

            categoryModule.ShowDialog();
            LoadCategory();
        }
    }
}
