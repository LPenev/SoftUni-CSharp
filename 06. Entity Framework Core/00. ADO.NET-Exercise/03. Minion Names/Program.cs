using _03._Minion_Names;
using System.Data.SqlClient;

using SqlConnection connection = new SqlConnection(Config.ConnectionString);
connection.Open();

int VillianId = ReadVillianId();
object villianName = GetVillianNameById(connection, VillianId);

if (villianName != null)
{
    PrintVillianName((string)villianName);
    PrintMinionsByVillianID(connection, VillianId);
}

connection.Close();

static void PrintMinionsByVillianID(SqlConnection connection, int Id)
{
    string FindMinionsByVillianID =
    @"SELECT M.Name, M.Age FROM MinionsVillains AS MV JOIN Minions AS M ON M.Id = MV.MinionId WHERE MV.VillainId = @Id ORDER BY M.Name";
    SqlCommand cmd = new SqlCommand(FindMinionsByVillianID, connection);
    cmd.Parameters.AddWithValue("Id", Id);
    using SqlDataReader reader = cmd.ExecuteReader();

    int Num = 0;
    while (reader.Read())
    {
        Num++;
        Console.WriteLine($"{Num}. {reader.GetString(0)} {reader.GetValue(1)}");
    }
}
static void PrintVillianName(string name)
{
    Console.WriteLine($"Villain: {name}");
}
static object GetVillianNameById(SqlConnection connection, int Id)
{
    string findVillianByIdQuery = @"SELECT Name FROM Villains WHERE ID = @VillianId";
    SqlCommand cmd = new SqlCommand(findVillianByIdQuery, connection);
    cmd.Parameters.AddWithValue("VillianId", Id);
    using SqlDataReader reader = cmd.ExecuteReader();

    if (!reader.Read())
    {
        Console.WriteLine($"No villain with ID {Id} exists in the database.");
        return null;
    }

    return (object)reader.GetString(0).TrimEnd();
}
static int ReadVillianId() 
{
    Console.Write("Enter Villians Id -> ");
    int VilliansId = int.Parse(Console.ReadLine());
    return VilliansId;
}
