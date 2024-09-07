using System.Data.SqlClient;

namespace ADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            sqlConnection.Open();

            // first query
            string countOfProjectsQuery = "SELECT COUNT(*) FROM Projects";
            
            SqlCommand countOfProjectsCmd = new SqlCommand(countOfProjectsQuery, sqlConnection );
            int countOfProjects = (int)countOfProjectsCmd.ExecuteScalar();
            Console.WriteLine($"Number of projects is: {countOfProjects}\n");

            // second query
            string infoProjectsQuery = @"SELECT ProjectID,[Name] FROM Projects";
            SqlCommand infoProjectsCmd = new SqlCommand(infoProjectsQuery, sqlConnection);
            using SqlDataReader infoProjectsReader = infoProjectsCmd.ExecuteReader();

            Console.WriteLine("ID - Project Name\n");

            while (infoProjectsReader.Read())
            {
                int projectId = (int)infoProjectsReader["ProjectID"];
                string projectName = (string)infoProjectsReader["Name"];

                Console.WriteLine($"{projectId} - {projectName}");
            }

            sqlConnection.Close();

        }
    }
}
