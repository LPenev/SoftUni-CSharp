namespace _107._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var companys = new Dictionary<string, List<string>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                var inputArray = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string companyName = inputArray[0];
                string employeeId = inputArray[1];

                if (!companys.ContainsKey(companyName))
                {
                    companys.Add(companyName, new List<string>());
                }
                if (!companys[companyName].Contains(employeeId))
                {
                    companys[companyName].Add(employeeId);
                }
            }

            foreach (var company in companys)
            {
                string companyName = company.Key;
                Console.WriteLine($"{companyName}");

                foreach (var employeeId in company.Value)
                {
                    Console.WriteLine($"-- {employeeId}");
                }
            }
        }
    }
}