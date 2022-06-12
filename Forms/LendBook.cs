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
    public partial class LendBook : Form
    {
        public LendBook()
        {
            InitializeComponent();
        }

        public void RefreshGrid()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LUKE\LUKE_SQLSERVER;Initial Catalog=LIBDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM students", con);
            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT * FROM books", con);
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();

            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            sda1.Fill(dt1);
            dataGridView2.DataSource = dt1;


        }

        public void DecreaseStock()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LUKE\LUKE_SQLSERVER;Initial Catalog=LIBDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE books set Quantity = Quantity - 1 where ISBN = '"+txtISBN.Text+"'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void LendBk()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LUKE\LUKE_SQLSERVER;Initial Catalog=LIBDB;Integrated Security=True");
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT into borrowers values('" + txtRegnum.Text + "','" + txtname.Text + "','" + txtsurname.Text + "','" + txtprogram.Text + "','" + txtISBN.Text + "','" + txtBookName.Text + "','" + txtCategory.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                DecreaseStock();
                MessageBox.Show("Book Borrowed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRegnum.Clear();
                txtname.Clear();
                txtsurname.Clear();
                txtprogram.Clear();
                txtISBN.Clear();
                txtBookName.Clear();
                txtCategory.Clear();
                txtQuantity.Clear();

              
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


           
            

        }

        private void LendBook_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                txtRegnum.Text = row.Cells[0].Value.ToString();
                txtname.Text = row.Cells[1].Value.ToString();
                txtsurname.Text = row.Cells[2].Value.ToString();
                txtprogram.Text = row.Cells[3].Value.ToString();


            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                txtISBN.Text = row.Cells[0].Value.ToString();
                txtBookName.Text = row.Cells[1].Value.ToString();
                txtCategory.Text = row.Cells[2].Value.ToString();
                txtQuantity.Text = row.Cells[3].Value.ToString();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtRegnum.Text == "" || txtISBN.Text == "")
            {
                MessageBox.Show("Please Select Both Student and Book", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LendBk();
                RefreshGrid();

            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Main().Show();
        }
    }
}
