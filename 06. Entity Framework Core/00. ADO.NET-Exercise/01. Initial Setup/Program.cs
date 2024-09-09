using _01._Initial_Setup;
using System.Data.SqlClient;

using SqlConnection connection = new SqlConnection(Config.ConnectionString);
connection.Open();

CreateDb(connection);
CreateDbTables(connection);
InsertDataInDb(connection);

connection.Close();


static void InsertDataInDb(SqlConnection connection)
{
    string fullPath = Path.Combine(Config.Directory, "InsertDataMinionsDb.sql");
    string query = File.ReadAllText(fullPath);
    SqlCommand command = new SqlCommand(query, connection);
    Console.WriteLine("Insert data into Db. Rows affected {0}.", command.ExecuteNonQuery());
}

static void CreateDbTables(SqlConnection connection)
{
    string fullPath = Path.Combine(Config.Directory, "CreateMinionsDbTables.sql");
    string query = File.ReadAllText(fullPath);
    SqlCommand command = new SqlCommand(query, connection);
    Console.WriteLine("Created tables.");
    command.ExecuteNonQuery();
}

static void CreateDb(SqlConnection connection)
{
    string query = @"CREATE DATABASE " + Config.Database;
    SqlCommand command = new SqlCommand(query, connection);
    command.ExecuteNonQuery();
    Console.WriteLine($"Created database {Config.Database}.");
}

