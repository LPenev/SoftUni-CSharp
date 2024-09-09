using _02._Villain_Names;
using System.Data.SqlClient;
using System.Text;

using SqlConnection connection = new SqlConnection(Config.ConnectionString);
connection.Open();

string result = FindVillainsMinions(connection);
Console.WriteLine(result);

connection.Close();

static string FindVillainsMinions(SqlConnection connection) 
{
    StringBuilder result = new StringBuilder();

    string fullPath = Path.Combine(Config.Directory, "SQLVilliansMinionsCount.sql");
    string query = File.ReadAllText(fullPath);
    SqlCommand command = new SqlCommand(query, connection);
    using SqlDataReader reader = command.ExecuteReader();

    while (reader.Read())
    {
        result.Append($"{reader.GetString(0)} - {reader.GetValue(1)}");
    }

    return result.ToString().TrimEnd();
}
