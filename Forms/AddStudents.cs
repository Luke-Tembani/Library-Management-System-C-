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

namespace LIBSYS.Forms
{
    public partial class AddStudents : Form
    {
        public AddStudents()
        {
            InitializeComponent();
        }
        public void AddStudent()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LUKE\LUKE_SQLSERVER;Initial Catalog=LIBDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO students values('" + txtRegnum.Text + "','" + txtname.Text + "','" + txtsurname.Text + "','" + txtprogram.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Student Added");
            con.Close();
            txtRegnum.Clear();
            txtname.Clear();
            txtprogram.Clear();
            txtsurname.Clear();
        }

        private void AddStudents_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtRegnum.Text == "" || txtname.Text == "" || txtprogram.Text == "" || txtsurname.Text == "")
            {
                MessageBox.Show("Enter all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                AddStudent();
            }
        }
    }
}
