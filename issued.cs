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
using ClosedXML.Excel;

namespace LibraryManagement
{
    public partial class issued : Form
    {
        public issued()
        {
            InitializeComponent();
            PopulateDataGridView();
        }

        private void PopulateDataGridView()
        {
            // Connection string and query
            string connectionString = "server=127.0.0.1; port=3307; uid=root; pwd=Cordero_2602; database=bookshelf";
            string query = "SELECT * FROM issued"; // Assuming "transactions" is the name of your table

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
                    dataGridView1.DataSource = dataTable;

                    // Make column headers not editable
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.ReadOnly = true;
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Aboutbutton_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction();
            transaction.Show();
            this.Hide();
        }

        private void issued_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            returned returned = new returned();
            returned.Show();
            this.Hide();
        }

        private void Dashboardbutton_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
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

        private void Reportbutton_Click(object sender, EventArgs e)
        {
            Members members = new Members();
            members.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Create a OpenFileDialog to select the existing Excel file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx";
            openFileDialog.Title = "Select Excel File";
            openFileDialog.ShowDialog();

            // If the user selects a file
            if (openFileDialog.FileName != "")
            {
                // Load existing Excel workbook
                using (XLWorkbook wb = new XLWorkbook(openFileDialog.FileName))
                {
                    // Get existing or add new worksheet
                    var ws = wb.Worksheets.FirstOrDefault(sheet => sheet.Name == "Sheet1");
                    if (ws == null)
                    {
                        ws = wb.Worksheets.Add("Sheet1");
                    }

                    // Define the starting cell for appending data (C8)
                    string startingCell = "C8";

                    // Get the data from DataGridView
                    DataTable dataTable = new DataTable();
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        dataTable.Columns.Add(column.HeaderText);
                    }
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        DataRow dataRow = dataTable.NewRow();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            dataRow[cell.ColumnIndex] = cell.Value;
                        }
                        dataTable.Rows.Add(dataRow);
                    }

                    // Add the data to Excel starting from the defined starting cell
                    ws.Cell(startingCell).InsertTable(dataTable);

                    // Auto fit columns
                    ws.Columns().AdjustToContents();

                    // Save the workbook back to the original file
                    wb.SaveAs(openFileDialog.FileName);
                }

                MessageBox.Show("Data appended to Excel file successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
