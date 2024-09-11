using _03._Minion_Names;
using System.Data.SqlClient;

const string Evilness = "evil";

using SqlConnection connection = new SqlConnection(Config.ConnectionString);
connection.Open();

string[] readMinionInfoArray = ReadMinionInformation();
string minionName = readMinionInfoArray[0];
int minionAge = int.Parse(readMinionInfoArray[1]);
string minionTown = readMinionInfoArray[2];

string villainName = ReadVillainName();

using var sqlTransaction = connection.BeginTransaction();

try
{
    // check if town exist, if not add town into database
    bool isTownExist = GetTownIdByName(connection, sqlTransaction, minionTown) != null;

    if (!isTownExist)
    {
        InsertTown(connection, sqlTransaction, minionTown);
    }

    int minionTownId = (int)GetTownIdByName(connection, sqlTransaction, minionTown);

    // check if minion exist, if not add minion into database
    bool isMinionExist = GetMinionId(connection, sqlTransaction, minionName, minionAge, minionTownId) != null;

    if (!isMinionExist)
    {
        AddMinion(connection, sqlTransaction, minionName, minionAge, minionTownId);
    }

    int minionId = (int)GetMinionId(connection, sqlTransaction, minionName, minionAge, minionTownId);

    // check if villain exist, if not add villain into database
    bool isVillainExist = GetVillainId(connection, sqlTransaction, villainName) != null;

    if (!isVillainExist)
    {
        int evilnessId = GetEvilnessId(connection, sqlTransaction, Evilness);
        AddVillain(connection, sqlTransaction, villainName, evilnessId);
    }

    int villainId = (int)GetVillainId(connection, sqlTransaction, villainName);

    if (isVillainExist)
    {
        Console.WriteLine($"Minion: {minionName} is already servant of the villain: {villainName}");
    }
    else
    {
        AddMinionIdAndVillainIdIntoMinionsVillains(connection, sqlTransaction, minionId, villainId);
        Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
    }
}
catch (Exception e)
{
    sqlTransaction.Rollback();
    Console.WriteLine("Error, try again...");
}

sqlTransaction.Commit();

static bool IsMinionServantOfVillain(SqlConnection connection, SqlTransaction sqlTransaction, int minionId, int VillainId)
{
    string fullPath = Path.Combine(Config.Directory, "IsMinionServantOfVillain.sql");
    string query = File.ReadAllText(fullPath);
    SqlCommand command = new SqlCommand(query, connection, sqlTransaction);
    object result = command.ExecuteScalar();
    if (result == null)
    {
        return false;
    }
    else
    {
        return true;
    }
}
static void AddMinionIdAndVillainIdIntoMinionsVillains(SqlConnection connection, SqlTransaction sqlTransaction, int minionId, int villainId)
{
    string fullPath = Path.Combine(Config.Directory, "InsertMinionIdVillainIdIntoMinionsVillains.sql");
    string query = File.ReadAllText(fullPath);
    SqlCommand command = new SqlCommand(query, connection, sqlTransaction);
    command.Parameters.AddWithValue("minionId", minionId);
    command.Parameters.AddWithValue("villainId", villainId);
    command.ExecuteNonQuery();
}
static void AddVillain(SqlConnection connection, SqlTransaction sqlTransaction, string name, int evilnessFactorId)
{
    string fullPath = Path.Combine(Config.Directory, "InsertVillain.sql");
    string query = File.ReadAllText(fullPath);
    SqlCommand command = new SqlCommand(query, connection, sqlTransaction);
    command.Parameters.AddWithValue("name", name);
    command.Parameters.AddWithValue("evilnessFactorId", evilnessFactorId);
    command.ExecuteNonQuery();
    Console.WriteLine($"Villain {name} was added to the database.");
}
static int GetEvilnessId(SqlConnection connection, SqlTransaction sqlTransaction, string evilness)
{
    string FullPath = Path.Combine(Config.Directory, "GetEvilnessIdByName.sql");
    string query = File.ReadAllText(FullPath);
    SqlCommand command = new SqlCommand(query, connection, sqlTransaction);
    command.Parameters.AddWithValue("name", evilness);
    int evilnessId = (int)command.ExecuteScalar();
    return evilnessId;
}
static object GetVillainId(SqlConnection connection, SqlTransaction sqlTransaction, string name)
{
    string fullPath = Path.Combine(Config.Directory, "GetVillainIdByName.sql");
    string query = File.ReadAllText(fullPath);
    SqlCommand command = new SqlCommand(query, connection, sqlTransaction);
    command.Parameters.AddWithValue("name", name);
    object result = command.ExecuteScalar();
    return result;
}
static void AddMinion(SqlConnection connection, SqlTransaction sqlTransaction, string name, int age, int townId)
{
    string fullPath = Path.Combine(Config.Directory, "AddMinion.sql");
    string query = File.ReadAllText(fullPath);
    SqlCommand command = new SqlCommand(query, connection, sqlTransaction);
    command.Parameters.AddWithValue("name", name);
    command.Parameters.AddWithValue("age", age);
    command.Parameters.AddWithValue("townId", townId);
    command.ExecuteNonQuery();
    Console.WriteLine($"Minion {name} was added to the database.");
}
static object GetMinionId(SqlConnection connection, SqlTransaction sqlTransaction, string Name, int Age, int townId)
{
    string fullPath = Path.Combine(Config.Directory, "GetMinionIdByNameAgeTownId.sql");
    string query = File.ReadAllText(fullPath);
    SqlCommand command = new SqlCommand(query, connection, sqlTransaction);
    command.Parameters.AddWithValue("name", Name);
    command.Parameters.AddWithValue("Age", Age);
    command.Parameters.AddWithValue("TownId", townId);
    object result = command.ExecuteScalar();
    return result;
}
static void InsertTown(SqlConnection connection, SqlTransaction sqlTransaction, string town)
{
    string fullPath = Path.Combine(Config.Directory, "InsertTown.sql");
    string query = File.ReadAllText(fullPath);
    SqlCommand command = new SqlCommand(query, connection, sqlTransaction);
    command.Parameters.AddWithValue("Town", town);
    command.ExecuteNonQuery();
    Console.WriteLine($"Town {town} was added to the database.");
}
static object GetTownIdByName(SqlConnection connection, SqlTransaction sqlTransaction, string town)
{
    string fullPath = Path.Combine(Config.Directory, "GetTownIdByName.sql");
    string query = File.ReadAllText(fullPath);
    SqlCommand command = new SqlCommand(query, connection, sqlTransaction);
    command.Parameters.AddWithValue("town", town);
    object result = command.ExecuteScalar();
    return result;
}
static string ReadVillainName()
{
    string villainName = Console.ReadLine().Split(": ")[1];
    return villainName;
}
static string[] ReadMinionInformation()
{
    string[] minionInfoArray = Console.ReadLine().Split(": ")[1].Split(" ");
    return minionInfoArray;
}