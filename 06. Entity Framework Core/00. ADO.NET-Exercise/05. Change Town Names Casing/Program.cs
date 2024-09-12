using _05._Change_Town_Names_Casing;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

string country = Console.ReadLine();

SqlConnection connection = new SqlConnection(Config.ConnectionString);
connection.Open();

List<string> towns = GetTownByCountry(connection, country);
PrintTowns(towns);

connection.Close();

static void PrintTowns(List<string> towns)
{
    if(towns.Count < 1)
    {
        Console.WriteLine("No town names were affected.");
        return; 
    }

    Console.WriteLine($"{towns.Count} town names were affected.");
    Console.Write('[');
    Console.Write(String.Join(", ", towns.ToArray()));
    Console.WriteLine(']');
}
static List<string> GetTownByCountry(SqlConnection connection, string country)
{
    string fullPath = Path.Combine(Config.Directory, "SelectTownsByCountry.sql");
    string query = File.ReadAllText(fullPath);
    SqlCommand command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("country", country);
    using SqlDataReader reader = command.ExecuteReader();
    
    List<string> towns = new();

    while (reader.Read())
    {
        towns.Add(reader.GetString(0));
    }

    return towns;
}

