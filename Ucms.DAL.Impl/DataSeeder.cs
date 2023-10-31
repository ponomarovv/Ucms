using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ucms.DAL.Impl.SQL;

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

            string createDbQuery = CreateDatabaseSql.createDbQuery;

            using (SqlCommand command = new SqlCommand(createDbQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
