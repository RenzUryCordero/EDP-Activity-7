using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LibraryManagement
{
    public partial class AddAccountForm : Form
    {
        public AddAccountForm()
        {
            InitializeComponent();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddAccountForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Inside your login logic
            string enteredEmail = "example@example.com"; // Replace with the entered email
            string enteredPassword = "example_password"; // Replace with the entered password

            // Authenticate the user and update account status
            DatabaseHandler dbHandler = new DatabaseHandler("server = 127.0.0.1; port = 3307; uid = root; pwd = Cordero_2602; database = bookshelf");
            dbHandler.UpdateAccountStatusByEmail(enteredEmail, enteredPassword);

            string email = Emailbutton.Text;
            string password = Passwordbutton.Text;

            // Initialize DatabaseHandler with connection string
            string connStr = "server = 127.0.0.1; port = 3307; uid = root; pwd = Cordero_2602; database = bookshelf";
            MySqlConnection conn = new MySqlConnection(connStr);

            
            try
            {
                conn.Open();
                string query = "INSERT INTO accounts (email, password) VALUES (@email, @password)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                // Get the values from textboxes
                string Email = Emailbutton.Text;
                string Password = Passwordbutton.Text;

                // Check if both email and password are provided
                if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
                {
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@password", Password);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Data inserted successfully
                        Dashboard dashboard = new Dashboard();
                        dashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both email and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
