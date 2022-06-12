using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBSYS
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public void StripForm(Form frm)
        {
            frm.ShowInTaskbar = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.ControlBox = false;
            frm.TopLevel = false;
            frm.Text = "";
            frm.WindowState = FormWindowState.Maximized;
            frm.Visible = true;
            splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        public void SignOut()
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Are you sure you want to Sign Out?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(dr == DialogResult.Yes)
            {
                this.Hide();
                new Form1().Show();
                MessageBox.Show("Signed Out", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                //Do Nothing
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            StripForm(new Forms.AddBooks());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StripForm(new Forms.AddStudents());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //StripForm(new Forms.LendBook());
            this.Close();
            new Forms.LendBook().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //StripForm(new Forms.ReturnBook());
            this.Close();
            new Forms.ReturnBook().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StripForm(new Forms.Reports());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StripForm(new Forms.Settings());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StripForm(new Forms.BackupDB());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SignOut();
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }
    }
}
