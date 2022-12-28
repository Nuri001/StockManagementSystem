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
    public partial class CategoryModuleForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8EVFSCK\SQLEXPRESS;Initial Catalog=IMS;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        public CategoryModuleForm()
        {
            InitializeComponent();
        }

        
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("sure to save this Category?", "saving record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    command = new SqlCommand("INSERT INTO tblCategory(name)VALUES(@name)", connection);
                    command.Parameters.AddWithValue("@name", txtName.Text);
               

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Category successfully saved");
                    txtName.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("are you sure to update this Category with id=" + lblId.Text + " ??", "update record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    command = new SqlCommand("UPDATE tblCategory SET name=@name WHERE id=@id", connection);
                    command.Parameters.AddWithValue("@name", txtName.Text);
                   

                    command.Parameters.AddWithValue("@id", int.Parse(lblId.Text));
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Category successfully updaate");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
