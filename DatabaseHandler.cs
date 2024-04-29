using System;
using System.Data;
using MySql.Data.MySqlClient;

public class DatabaseHandler
{
    private string connectionString;

    public DatabaseHandler(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void Create(string query)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
    }

    public DataTable Read(string query)
    {
        DataTable dataTable = new DataTable();
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            adapter.Fill(dataTable);
        }
        return dataTable;
    }

    public void Update(string query, string[] values = null)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            if (values != null)
            {
                for (int i = 0; i < values.Length; i = i + 2)
                {
                    command.Parameters.AddWithValue(values[i], values[i + 1]);
                }
            }
            command.ExecuteNonQuery();
        }
    }

    public void Delete(string query)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
    }

    // Method to update account status based on email and password
    public void UpdateAccountStatusByEmail(string email, string password)
    {
        // SQL query to update account status
        string query =
            $"UPDATE accounts SET status = CASE WHEN email = '{email}' AND password = '{password}' THEN 'active' ELSE 'inactive' END";

        // Call the Update method with the query
        Update(query);
    }

    // Add Account
    public void AddAccount(string email, string password, string profileInfo)
    {
        string query =
            $"INSERT INTO accounts (email, password, profile_info, status) VALUES ('{email}', '{password}', '{profileInfo}', 'active')";
        Create(query);
    }

    // Update Account Profile
    public void UpdateAccountProfile(string email, string newProfileInfo)
    {
        string query =
            $"UPDATE accounts SET profile_info = '{newProfileInfo}' WHERE email = '{email}'";
        Update(query);
    }

    // Activate Account
    public void ActivateAccount(string email)
    {
        string query = $"UPDATE accounts SET status = 'active' WHERE email = '{email}'";
        Update(query);
    }

    // Deactivate Account
    public void DeactivateAccount(string email)
    {
        string query = $"UPDATE accounts SET status = 'inactive' WHERE email = '{email}'";
        Update(query);
    }

    // Get Account List
    public DataTable GetAccountList()
    {
        string query = "SELECT * FROM accounts";
        return Read(query);
    }

    // Search Account by Email
    public DataTable SearchAccountByEmail(string email)
    {
        string query = $"SELECT * FROM accounts WHERE email LIKE '%{email}%'";
        return Read(query);
    }
}
