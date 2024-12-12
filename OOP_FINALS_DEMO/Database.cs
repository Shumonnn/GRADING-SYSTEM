using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace OOP_FINALS_DEMO
{
    public class Database
    {
        private readonly string connectionString = "Server=localhost;Database=gradestudentcalculator;Uid=root;Pwd=;";

        // Get database connection
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // Generic method to execute non-query commands (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            int affectedRows = 0;
            using (MySqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);

                    affectedRows = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Database Error: " + ex.Message);
                }
            }
            return affectedRows;

        }

        // Generic method to execute scalar commands (e.g., COUNT, MAX, etc.)
        public object ExecuteScalar(string query, MySqlParameter[] parameters = null)
        {
            object result = null;
            using (MySqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);

                    result = command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Database Error: " + ex.Message);
                }
            }
            return result;
        }

        // Generic method to fetch data (SELECT queries)
        public DataTable ExecuteQuery(string query, MySqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTablee = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Database Error: " + ex.Message);
                }
            }
            return dataTable;
        }
        public bool TestConnection()
        {
            try
            {
                using MySqlConnection connection = GetConnection();
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // Example specific method: Validate Login
        public bool ValidateLogin(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM professor WHERE Username = @username AND Password = @password";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@username", username),
                new MySqlParameter("@password", password)
            };

            object result = ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }
    }
}
