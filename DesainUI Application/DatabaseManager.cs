using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesainUI_Application
{
    internal class DatabaseManager
    {
        private static DatabaseManager instance;
        private SQLiteConnection connection;
        private string dbName = @"D:\PUTRA\KULIAH\Semester 3\Pemmrog\aplikasi\aplikasi\DBbank.db";

        private DatabaseManager()
        {
            string connectionString = $"Data Source={dbName};Version=3;";
            connection = new SQLiteConnection(connectionString);
        }
        public DataTable ExecuteQuery(string query)
{
    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
    DataTable dataTable = new DataTable();
    adapter.Fill(dataTable);
    return dataTable;
}

        public static DatabaseManager GetInstance()
        {
            if (instance == null)
            {
                instance = new DatabaseManager();
            }
            return instance;
        }

        public SQLiteConnection GetConnection()
        {
            return connection;
        }

        public void OpenConnection()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

      /*  public DataTable ExecuteQuery(string query)
        {
            try
            {
                OpenConnection();

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                Console.WriteLine("Error executing query: " + ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }*/
    }
}
