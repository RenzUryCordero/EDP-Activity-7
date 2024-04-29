using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LibraryManagement
{
    public partial class Login : Form
    {
        //string id;
        public Login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;" + "pwd=Cordero_2602;database=test";

            myConnectionString = "server=127.0.0.1;uid=root;pwd=Cordero_2602;database=bookshelf";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MessageBox.Show("Connected");
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_MouseClick(object sender, MouseEventArgs e) { }

        private void button1_Click_2(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            // Inside your login logic
            string enteredEmail = "example@example.com"; // Replace with the entered email
            string enteredPassword = "example_password"; // Replace with the entered password

            // Authenticate the user and update account status
            DatabaseHandler dbHandler = new DatabaseHandler(
                "server = 127.0.0.1; port = 3307; uid = root; pwd = Cordero_2602; database = bookshelf"
            );
            dbHandler.UpdateAccountStatusByEmail(enteredEmail, enteredPassword);

            string email = Username.Text;
            string password = Password.Text;

            // Check if email and password fields are empty
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter both email and password.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return; // Exit the method without proceeding further
            }

            // Query to check if email and password exist in the database
            string query = "SELECT * FROM accounts WHERE email = @email AND password = @password";

            // Initialize DatabaseHandler with connection string
            string connStr =
                "server = 127.0.0.1; port = 3307; uid = root; pwd = Cordero_2602; database = bookshelf";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                /* MySqlCommand cmd = new MySqlCommand(query, conn);

                 cmd.Parameters.AddWithValue("@email", email);
                 cmd.Parameters.AddWithValue("@password", password);

                 object result = cmd.ExecuteScalar();
                 if (result != null)
                 {

                     Dashboard dashboard = new Dashboard();
                     dashboard.Show();
                     this.Hide();
                 }
                 else
                 {
                     MessageBox.Show("Incorrect email or password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }*/

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read(); // Move to the first row
                    id = reader.GetInt32("id").ToString(); // Assuming 'id' is an integer column
                    reader.Close();

                    query = "UPDATE accounts " + "SET status = 'active' " + "WHERE id = @id";

                    dbHandler.Update(query, new string[] { "@id", id });

                    Dashboard dashboard = new Dashboard(id);
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(
                        "Incorrect email or password.",
                        "Authentication Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PasswordRecovery passwordRecovery = new PasswordRecovery();
            passwordRecovery.Show();
            this.Hide();
        }
    }
}
