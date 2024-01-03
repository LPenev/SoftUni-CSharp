using System.Data;

namespace _13._Monthly_Report
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Client> clients = new List<Client>();
            List<Distributor> distributors = new List<Distributor>();

            string input = string.Empty;
            while((input = Console.ReadLine()) != "End")
            {
                var inputArray = input.Split();
                string command = inputArray[0];
                string name = inputArray[1];

                switch (command)
                {
                    case "Deliver":
                        var currentDeliver = distributors.FirstOrDefault(c => c.Name == name);
                        var moneySpend = double.Parse(inputArray[2]);
                        
                        if(currentDeliver == null)
                        {
                            distributors.Add(new Distributor(name,moneySpend));
                            continue;
                        }

                        currentDeliver.Sum += moneySpend;
                        break;

                    case "Return":
                        double moneyReturn = double.Parse(inputArray[2]);

                        var currDeliver = distributors.FirstOrDefault(c => c.Name == name);
                        if((currDeliver == null)||(currDeliver.Sum - moneyReturn < 0))
                        {
                            continue;
                        }

                        if(currDeliver.Sum - moneyReturn == 0)
                        {
                            distributors.Remove(currDeliver);
                        }

                        currDeliver.Sum -= moneyReturn;

                        break;

                    case "Sell":
                        string clientName = name;
                        double moneyEarned = double.Parse(inputArray[2]);
                        var currentClient = clients.FirstOrDefault(c => c.Name == name);

                        if(currentClient == null)
                        {
                            clients.Add(new Client(name, moneyEarned));
                            continue;
                        }

                        currentClient.Sum += moneyEarned;
                        break;

                }
            }

            foreach(var client  in clients)
            {
                Console.WriteLine($"{client.Name}: {client.Sum:f2}");
            }

            Console.WriteLine("-----------");

            foreach (var distributor in distributors)
            {
                Console.WriteLine($"{distributor.Name}: {distributor.Sum:f2}");
            }

            Console.WriteLine("-----------");

            double totalIncome = clients.Sum(x => x.Sum);

            Console.WriteLine($"Total Income: {totalIncome:f2}");
        }
        public class Client
        {
            public Client(string name, double sum)
            {
                this.Name = name;
                this.Sum = sum;
            }
            public string Name { get; set; }
            public double Sum { get; set; }
        }

        public class Distributor
        {
            public Distributor(string name, double sum)
            {
                this.Name= name;
                this.Sum = sum;
            }
            public string Name { get; set; }
            public double Sum { get; set; }
        }
    }
}
