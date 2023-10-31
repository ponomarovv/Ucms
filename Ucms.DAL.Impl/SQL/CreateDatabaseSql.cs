namespace Ucms.DAL.Impl.SQL;

public class CreateDatabaseSql
{
    public static string databaseName = "UcmsDB";

    public static string createDbQuery =
        $"IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = '{databaseName}')" +
        $"BEGIN" +
        $"   CREATE DATABASE {databaseName};" +
        $"END;";

    public static string CreateDatabase { get; set; } = $"";
    public static string CreateTables { get; set; } = $"";
    public static string SeedData { get; set; } = $"";
}
