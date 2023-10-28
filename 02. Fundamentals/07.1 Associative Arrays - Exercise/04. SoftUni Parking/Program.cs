namespace _104._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] inputArray = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = inputArray[0];
                string username = inputArray[1];

                if (command == "register")
                {
                    string licensePlateNumber = inputArray[2];

                    if (users.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                        continue;
                    }
                    users.Add(username, licensePlateNumber);
                    Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                }
                else if(command == "unregister")
                {
                    if (!users.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                        continue;
                    }
                    users.Remove(username);
                    Console.WriteLine($"{username} unregistered successfully");
                }
            }
            foreach(var user in users)
            {
                string username = user.Key;
                string licensePlateNumber = user.Value;
                Console.WriteLine($"{username} => {licensePlateNumber}");
            }
        }
    }
}