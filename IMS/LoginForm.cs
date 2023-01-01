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
    public partial class LoginForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8EVFSCK\SQLEXPRESS;Initial Catalog=IMS;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        SqlDataReader reader;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtUserName.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
                txtPassword.UseSystemPasswordChar = true;
            else
                txtPassword.UseSystemPasswordChar = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                command = new SqlCommand("SELECT * FROM tblUsers WHERE username=@username AND password=@pass", connection);
                connection.Open();
                command.Parameters.AddWithValue("@username", txtUserName.Text);
                command.Parameters.AddWithValue("@pass", Convert.ToInt16(txtPassword.Text));
                reader = command.ExecuteReader();
                if(reader != null )
                {
            
                    MessageBox.Show("user found must login");
                    reader.Close();
                    connection.Close();
                    MainForm main = new MainForm();
                    main.loadWelcomPage(txtUserName.Text);
                    main.ShowDialog();
                    this.Dispose();

                }
                else
                {
                    MessageBox.Show("Invalid username or password!");
                    reader.Close();
                    connection.Close();
                }
                
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            

        }
    }
}
