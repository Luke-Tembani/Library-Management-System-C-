using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LIBSYS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Login Method
        public void Login()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LUKE\LUKE_SQLSERVER;Initial Catalog=LIBDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM login where username = '"+txtusername.Text+"' AND password = '"+txtpassword.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (txtusername.Text == "" || txtpassword.Text == "")
            {
                MessageBox.Show("Please Fill in All Fields", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            } else if (dt.Rows.Count == 1)
            {
                this.Hide();
                Main mn = new Main();
                mn.Show();
                mn.label1.Text = "Admin:" + " " + "" + txtusername.Text.ToUpper() + "";

                MessageBox.Show("Welcome" + " " + txtusername.Text.ToUpper() + "!");       
                txtusername.Clear();
                txtpassword.Clear();
            }
            else if (dt.Rows.Count == 0) {
                MessageBox.Show("Wrong Credentials", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("Login Failed", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                txtusername.Clear();
                txtpassword.Clear();
                txtusername.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Loggin in to system
            Login();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Closing the application
            Application.Exit();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
