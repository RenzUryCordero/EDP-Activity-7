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

namespace LibraryManagement
{
    public partial class Update : Form
    {
        string userId;
        public Update(string id)
        {
            InitializeComponent();
            this.userId = id;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = Emailbutton.Text;
            string password = Passwordbutton.Text;

            // Initialize DatabaseHandler with connection string
            string connStr = "server = 127.0.0.1; port = 3307; uid = root; pwd = Cordero_2602; database = bookshelf";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();

                // Construct the UPDATE query
                string query = "UPDATE accounts SET email = @email, password = @password WHERE id = @userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                // Get the new values from textboxes
                string newEmail = Emailbutton.Text;
                string newPassword = Passwordbutton.Text;

                // Check if both email and password are provided
                if (!string.IsNullOrEmpty(newEmail) && !string.IsNullOrEmpty(newPassword))
                {
                    cmd.Parameters.AddWithValue("@userId", userId); // Assuming userId is a field or variable containing the user's ID
                    cmd.Parameters.AddWithValue("@email", newEmail);
                    cmd.Parameters.AddWithValue("@password", newPassword);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Data updated successfully
                        MessageBox.Show("Account updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both email and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

        }

        private void Update_Load(object sender, EventArgs e)
        {

        }
    }

}
