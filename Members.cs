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
    public partial class Members : Form
    {
        public Members()
        {
            InitializeComponent();
            PopulateDataGridView();
        }

        private void PopulateDataGridView()
        {
            // Connection string and query
            string connectionString = "server=127.0.0.1; port=3307; uid=root; pwd=Cordero_2602; database=bookshelf";
            string query = "SELECT * FROM member";

            // Creating MySqlConnection and MySqlCommand objects
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                // Creating MySqlDataAdapter and DataTable objects
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();

                    // Fill the DataTable with data from the database
                    adapter.Fill(dataTable);

                    // Set the DataGridView's DataSource to the DataTable
                    dataGridView2.DataSource = dataTable;
                }
            }
        }
        private void Dashboardheader_Click(object sender, EventArgs e)
        {

        }

        private void Dashboardbutton_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            issued issued = new issued();
            issued.Show();
            this.Hide();
        }

        private void Aboutbutton_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction();
            transaction.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            returned returned = new returned();
            returned.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
            this.Hide();
        }

        private void Members_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboardbutton_Click_1(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
            this.Hide();
        }

        private void Aboutbutton_Click_1(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction();
            transaction.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            issued issued = new issued();
            issued.Show();
            this.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            returned returned = new returned();
            returned.Show();
            this.Hide();
        }
    }
}
