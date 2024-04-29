using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LibraryManagement
{
    public partial class Verification : Form
    {
        string email = string.Empty;
        public Verification(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseHandler dbHandler = new DatabaseHandler("server = 127.0.0.1; port = 3307; uid = root; pwd = Cordero_2602; database = bookshelf");

            string password = textBoxNewPass.Text;
            string confirmPass = textBoxConfirmPass.Text;

            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPass))
            {
                MessageBox.Show("Please enter both new password and confirm password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method without proceeding further
            }

            if(password != confirmPass)
            {
                MessageBox.Show("Password do not match.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "UPDATE accounts SET password = @password WHERE email = @email";

            try
            {
                dbHandler.Update(query, new string[] { "@password", password, "@email", email });
         
                Success success = new Success();
                success.Show();
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Verification_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
