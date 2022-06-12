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
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }

        public void RefreshGrid()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LUKE\LUKE_SQLSERVER;Initial Catalog=LIBDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM borrowers", con);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        public void ReturnBk()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LUKE\LUKE_SQLSERVER;Initial Catalog=LIBDB;Integrated Security=True");
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM borrowers where RegNumber = '" + txtregnm.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                IncreaseStock();
                MessageBox.Show("Book Returned", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
                txtregnm.Clear();
                txtisbn.Clear();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
           
        }

        public void IncreaseStock()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LUKE\LUKE_SQLSERVER;Initial Catalog=LIBDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE books set Quantity = Quantity + 1 where ISBN = '" + txtisbn.Text  + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtregnm.Text == ""|| txtisbn.Text=="")
            {
                MessageBox.Show("Select Student to return book", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                ReturnBk();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                txtregnm.Text = row.Cells[0].Value.ToString();
                txtisbn.Text = row.Cells[4].Value.ToString();
                    
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Main().Show();
        }
    }
}
