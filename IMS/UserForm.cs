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
    public partial class UserForm : Form
    {

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8EVFSCK\SQLEXPRESS;Initial Catalog=IMS;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        SqlDataReader reader;

        public UserForm()
        {
            InitializeComponent();
            LoadUser();
        }

        void LoadUser()
        {
            int i = 0;
            dgvUser.Rows.Clear();
            command = new SqlCommand("SELECT * FROM tblUsers", connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                i++;
                dgvUser.Rows.Add(i, reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString());

            }
            reader.Close();
            connection.Close();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String colName = dgvUser.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                UserModuleForm userModule = new UserModuleForm();
                userModule.txtUserName.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                userModule.txtFullName.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                userModule.txtPassword.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                userModule.txtPhone.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();

                userModule.btnSave.Enabled = false;
                userModule.btnUpdate.Enabled = true;
                userModule.txtPhone.Enabled = false;
                userModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("are you sure you want to delete this user?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    connection.Open();
                    command = new SqlCommand("DELETE FROM tblUsers WHERE phone=@phone", connection);
                    command.Parameters.AddWithValue("@phone", dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString());
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Record has been successfully deleted");

                }

            }
            LoadUser();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            UserModuleForm userModule = new UserModuleForm();

            userModule.btnSave.Enabled = true;
            userModule.btnUpdate.Enabled = false;

            userModule.ShowDialog();
            LoadUser();

        }
    }
}
