using Microsoft.Extensions.Configuration;
using Npgsql;
namespace Fleet_Managment
{
    public class Connection
    {
        private readonly IConfiguration _configuration;
        public Connection(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public NpgsqlConnection OpenConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            return connection;
        }
        public void CloseConnection(NpgsqlConnection connection)
        {
            connection.Close();
        }
    }
}