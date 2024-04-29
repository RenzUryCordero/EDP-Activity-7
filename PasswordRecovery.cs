using System;
using System.Collections;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LibraryManagement
{
    public partial class PasswordRecovery : Form
    {
        public PasswordRecovery()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void submit_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
             
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

            private void textBox3_TextChanged(object sender, EventArgs e)
            {

            }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            string connStr = "server = 127.0.0.1; port = 3307; uid = root; pwd = Cordero_2602; database = bookshelf";
            MySqlConnection conn = new MySqlConnection(connStr);

            string email = textBoxEmail.Text;
            string query = "SELECT * FROM accounts WHERE email = @email";


            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@email", email);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    Verification verification = new Verification(email);
                    verification.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Non-existing email.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}
