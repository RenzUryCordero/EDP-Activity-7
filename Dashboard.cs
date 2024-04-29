using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LibraryManagement
{
    public partial class Dashboard : Form
    {
        private string userId;
        public Dashboard(string id)
        {
            InitializeComponent();
            userId = id;
            userLoad();
        }

        public Dashboard()
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
        }

        private void userLoad(string id = null)
        {
            DatabaseHandler dbhandler = new DatabaseHandler("server = 127.0.0.1; port = 3307; uid = root; pwd = Cordero_2602; database = bookshelf");

            string query = "select * from accounts";

            DataTable result = dbhandler.Read(query);
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    //column id, email, password, created_at
                    table.Rows.Add(row["id"], row["email"], row["password"], row["created_at"], row["status"]);
                }

            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sd_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Reportbutton_Click(object sender, EventArgs e)
        {
            Members members = new Members();
            members.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
            this.Hide();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {   
            table.Dock = DockStyle.Fill;

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            AddAccountForm addAccountForm = new AddAccountForm();
            addAccountForm.Show();
            this.Hide();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Update update = new Update(userId);
            update.Show();
            this.Hide();

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            string email = Searchbox.Text;  
            string query = "SELECT * FROM accounts WHERE email= @Email";
            string connectionString = "server = 127.0.0.1; port = 3307; uid = root; pwd = Cordero_2602; database = bookshelf";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        table.Rows.Clear(); // Clear the existing rows
                        while (reader.Read())
                        {
                            // Add the row to the table
                            table.Rows.Add(reader["id"], reader["email"], reader["password"], reader["created_at"], reader["status"]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email Not Found");
                    }

                }
            }
        }

        private void Aboutbutton_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction();
            transaction.Show();
            this.Hide();
        }

        private void Dashboardbutton_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            issued issued = new issued();
            issued.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            returned returned = new returned();
            returned.Show();
            this.Hide();
        }
    }

}