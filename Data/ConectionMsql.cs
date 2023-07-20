using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Backrest.Data
{
    public class ConectionMsql
    {
        private MySqlConnection connection;
        private string connectionString;

        public ConectionMsql()
        {             
            connectionString = $"server={Environment.GetEnvironmentVariable("HOST_DB")};port={Environment.GetEnvironmentVariable("PORT_DB")};user={Environment.GetEnvironmentVariable("USER_DB")};password={Environment.GetEnvironmentVariable("PASSWORD")};database={Environment.GetEnvironmentVariable("DB_NAMEV")};";
        }

        public void OpenConnection()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
