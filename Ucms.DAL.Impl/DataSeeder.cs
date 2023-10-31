using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ucms.DAL.Impl;

public class DatabaseSeeder
{
    private readonly IConfiguration _configuration;

    public DatabaseSeeder(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void SeedDatabase()
    {
        string createDbConnectionString = _configuration.GetConnectionString("CreateDBConnection");

        CreateDatabase(createDbConnectionString);
    }


    private void CreateDatabase(string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string databaseName = "UcmsDB";
            string createDbQuery =
                $"IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = '{databaseName}')" +
                $"BEGIN" +
                $"   CREATE DATABASE {databaseName};" +
                $"END;";

            using (SqlCommand command = new SqlCommand(createDbQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
