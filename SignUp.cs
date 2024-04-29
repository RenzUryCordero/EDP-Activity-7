using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
                    }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if email and password fields are empty
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Please enter both email and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method without proceeding further
            }

            string connectionString = "server=127.0.0.1;port=3307;uid=root;pwd=Cordero_2602;database=bookshelf";
            DatabaseHandler dbHandler = new DatabaseHandler(connectionString);

            // Example of CRUD operations
            // Insert

            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;

            // Insert user data into the database
            string query = $"INSERT INTO accounts (email, password) VALUES ('{email}', '{password}')";
            dbHandler.Create(query);

            //message box
            Login login = new Login();
            login.Show();
            this.Hide();
        }


        private void Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
