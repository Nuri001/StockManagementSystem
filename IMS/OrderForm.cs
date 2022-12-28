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
    public partial class OrderForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8EVFSCK\SQLEXPRESS;Initial Catalog=IMS;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        SqlDataReader reader;
        public OrderForm()
        {
            InitializeComponent();
            LoadOrders();
        }

      public void  LoadOrders() {
            int i = 0;
            dgvOrder.Rows.Clear();
            command = new SqlCommand("SELECT * FROM tblOrder", connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                i++;
                dgvOrder.Rows.Add(i, reader[0].ToString(), reader[1].ToString().Substring(0,10), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString());

            }
            reader.Close();
            connection.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            OrderModuleForm productModule = new OrderModuleForm();


            productModule.btnUpdate.Enabled = false;
            productModule.btnSave.Enabled = true;
            productModule.ShowDialog();
           
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String colName = dgvOrder.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
               OrderModuleForm OrderModule = new OrderModuleForm();

                OrderModule.orderId.Text = dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString();
                OrderModule.orderId.Enabled = true;
                OrderModule.labid1.Enabled = true;
                OrderModule.txtcId.Text = dgvOrder.Rows[e.RowIndex].Cells[4].Value.ToString();
                OrderModule.txtpId.Text = dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString();
                OrderModule.txtPrice.Text= dgvOrder.Rows[e.RowIndex].Cells[6].Value.ToString();
                OrderModule.txtTotal.Text = dgvOrder.Rows[e.RowIndex].Cells[7].Value.ToString();
                OrderModule.UpdateQtyValue(Convert.ToInt16(dgvOrder.Rows[e.RowIndex].Cells[5].Value.ToString()));
                OrderModule.btnSave.Enabled = false;
                OrderModule.btnUpdate.Enabled = true;


                command = new SqlCommand("SELECT * FROM tbCustomer WHERE id=@cid", connection);
                connection.Open();
                command.Parameters.AddWithValue("@cid", Convert.ToInt16(dgvOrder.Rows[e.RowIndex].Cells[4].Value.ToString()));
                reader = command.ExecuteReader();
                while (reader.Read())
                {


                    OrderModule.txtcName.Text = reader[1].ToString();

                }
                reader.Close();
                connection.Close();

                command = new SqlCommand("SELECT * FROM tblProduct WHERE id=@pid", connection);
                connection.Open();
                command.Parameters.AddWithValue("@pid", Convert.ToInt16(dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString()));
                reader = command.ExecuteReader();
                while (reader.Read())
                {


                    OrderModule.txtpName.Text = reader[1].ToString();

                }
                reader.Close();
                connection.Close();


                OrderModule.ShowDialog();
                
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("are you sure you want to delete this Order?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    connection.Open();
                    command = new SqlCommand("DELETE FROM tblOrder WHERE oid=@id", connection);
                    command.Parameters.AddWithValue("@id", dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString());
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Record has been successfully deleted");

                }

            }


            LoadOrders();
        }
    }
}
