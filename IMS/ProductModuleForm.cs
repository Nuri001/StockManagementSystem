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
    public partial class ProductModuleForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8EVFSCK\SQLEXPRESS;Initial Catalog=IMS;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        SqlDataReader reader;
        public ProductModuleForm()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            comboQ.Items.Clear();
            command = new SqlCommand("SELECT name FROM tblCategory", connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboQ.Items.Add(reader[0].ToString());

            }
            reader.Close();
            connection.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Clear()
        {
            txtName.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtDes.Clear();
            comboQ.Text = "";        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        
            try
            {
                if (MessageBox.Show("sure to save?", "saving record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    command = new SqlCommand("INSERT INTO tblProduct(name,quantity,price,category,description)VALUES(@name,@quantity,@price,@category,@description)", connection);
                    command.Parameters.AddWithValue("@name", txtName.Text);
                    command.Parameters.AddWithValue("@quantity", Convert.ToInt16(txtQuantity.Text));
                    command.Parameters.AddWithValue("@price", Convert.ToInt16( txtPrice.Text));
                    command.Parameters.AddWithValue("@category", comboQ.Text);
                    command.Parameters.AddWithValue("@description",txtDes.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("user successfully saved");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("are you sure to update this product??", "update record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    command = new SqlCommand("UPDATE tblProduct SET name=@n ,quantity=@q,price=@p,category=@c,description=@d WHERE id=@id", connection);
    
                    command.Parameters.AddWithValue("@n", txtName.Text);
                    command.Parameters.AddWithValue("@q", Convert.ToInt16(txtQuantity.Text));
                    command.Parameters.AddWithValue("@p", Convert.ToInt16(txtPrice.Text));
                    command.Parameters.AddWithValue("@c", comboQ.Text);
                    command.Parameters.AddWithValue("@d", txtDes.Text);
                    command.Parameters.AddWithValue("@id", Convert.ToInt16(lblId.Text));

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("user successfully updaate");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
