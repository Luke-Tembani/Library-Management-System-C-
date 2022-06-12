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
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        public void AddBook()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LUKE\LUKE_SQLSERVER;Initial Catalog=LIBDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO books values('" + txtISBN.Text + "','" + txtBookName.Text + "','" + txtCategory.Text + "','" + txtQuantity.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Book Added");
            con.Close();
            txtISBN.Clear();
            txtBookName.Clear();
            txtCategory.Clear();
            txtQuantity.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AddBooks_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtISBN.Text == "" || txtBookName.Text == "" || txtCategory.Text == "" || txtQuantity.Text == "")
            {
                MessageBox.Show("Enter all Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                AddBook();
            }
        }
    }
}
