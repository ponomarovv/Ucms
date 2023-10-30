namespace Ucms.DAL.Impl.SQL;

public class CreateDatabaseSql
{
    public static string CreateDatabase { get; set; } = $"";
    public static string CreateTables { get; set; } = $"";
    public static string SeedData { get; set; } = $"SELECT * FROM USERS";
}
