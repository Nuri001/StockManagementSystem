using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;

namespace IMS
{
    public partial class OrderModuleForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8EVFSCK\SQLEXPRESS;Initial Catalog=IMS;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        SqlDataReader reader;
        int qty = 1;
        bool qtyChange = false;
        public OrderModuleForm()
        {
            InitializeComponent();
            LoadCustomer();
            LoadProduct();
        }
        void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            command = new SqlCommand("SELECT * FROM tblProduct WHERE CONCAT(name, price, category, description) LIKE '%" + txtSP.Text + "%'", connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, reader[0].ToString(), reader[1].ToString(), reader[4].ToString(), reader[3].ToString(), reader[2].ToString(), reader[5].ToString());

            }
            reader.Close();
            connection.Close();
        }

        public void LoadCustomer()
        {
            int i = 0;
            dgvCustomer.Rows.Clear();
            command = new SqlCommand("SELECT * FROM tbCustomer WHERE CONCAT(id,name) LIKE '%" + txtSC.Text + "%'", connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, reader[0].ToString(), reader[1].ToString());

            }
            reader.Close();
            connection.Close();
        }

        public void UpdatProductQty(int Pid)
        {
            command = new SqlCommand("UPDATE tblProduct SET quantity=@qty WHERE id=@pid", connection);
            command.Parameters.AddWithValue("@qty", qty);
            command.Parameters.AddWithValue("@pid", Pid);
        

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("product quantity successfully inserted");
        }

        public void UpdateQtyValue(int val) {
            qtyChange = true;
            numericUpDown1.Value = val;
            qtyChange = false;

        }
        public void Clear() {
            qty = 1;
            Debug.WriteLine("in Clear method");
            txtcName.Clear();
             txtcId.Clear();
             txtpId.Clear();
             txtpName.Clear();
             txtPrice.Clear();
            Debug.WriteLine("##1");
            UpdateQtyValue(0);
            Debug.WriteLine("##2");
            Odate.Value=DateTime.Now;
            Debug.WriteLine("##3");




        }

        private void txtSC_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void txtSP_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

   
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (qtyChange) return;
            int pQ = Convert.ToInt16(numericUpDown1.Value);
            if (pQ>qty)
            {
                MessageBox.Show("Instock quantity is not enoth!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                numericUpDown1.Value = numericUpDown1.Value - 1;
                return;

            }
            int price = Convert.ToInt16(txtPrice.Text);
            int total =price * pQ;
            txtTotal.Text = total.ToString();
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtcId.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtpId.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtpName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
            qty = Convert.ToInt16(dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        
            try
            {
                if (MessageBox.Show("sure to insert this order?", "saving record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    command = new SqlCommand("INSERT INTO tblOrder(odate,pid,cid,qty,price,total)VALUES(@odate,@pid,@cid,@qty,@price,@total)", connection);
                    command.Parameters.AddWithValue("@odate",Odate.Value);
                    command.Parameters.AddWithValue("@pid", Convert.ToInt16(txtpId.Text));
                    command.Parameters.AddWithValue("@cid", Convert.ToInt16(txtcId.Text));
                    command.Parameters.AddWithValue("@qty", Convert.ToInt16(numericUpDown1.Value));
                    command.Parameters.AddWithValue("@price", Convert.ToInt16(txtPrice.Text));
                    command.Parameters.AddWithValue("@total", Convert.ToInt16(txtTotal.Text));
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Order successfully inserted");
                    qty = qty - Convert.ToInt16(numericUpDown1.Value);

                    UpdatProductQty(Convert.ToInt16(txtpId.Text));

                    Clear();
                    LoadProduct();
                    
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("are you sure to update this product??", "update record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    command = new SqlCommand("UPDATE tblOrder SET odate=@odate,pid=@pid,cid=@cid,qty=@qty,price =@price,tota=@total WHERE id=@id", connection);
                    command.Parameters.AddWithValue("@odate", Odate.Value);
                    command.Parameters.AddWithValue("@pid", Convert.ToInt16(txtpId.Text));
                    command.Parameters.AddWithValue("@cid", Convert.ToInt16(txtcId.Text));
                    command.Parameters.AddWithValue("@qty", Convert.ToInt16(numericUpDown1.Value));
                    command.Parameters.AddWithValue("@price", Convert.ToInt16(txtPrice.Text));
                    command.Parameters.AddWithValue("@total", Convert.ToInt16(txtTotal.Text));
                    command.Parameters.AddWithValue("@id", Convert.ToInt16(orderId.Text));

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
    }
}
