using System.Text;

namespace DataCenter
{
    public class Rack
    {
        public Rack(int slots)
        {
            Slots = slots;
            Servers = new List<Server>();
        }

        public int Slots { get; set; }
        public List<Server> Servers { get; set; }
        public int GetCount => Servers.Count;


        public void AddServer(Server server)
        {   
            if (Slots > GetCount)
            {
                Server seached = Servers.FirstOrDefault(s => s.SerialNumber == server.SerialNumber);

                if (seached == null)
                {
                    Servers.Add(server);
                }
            }
        }

        public bool RemoveServer(string serialNumber)
        {
            var seached = Servers.FirstOrDefault(s => s.SerialNumber == serialNumber);
            return Servers.Remove(seached);
        }

        public string GetHighestPowerUsage()
        {
            var sortedByPowerUsage = Servers.OrderByDescending(s => s.PowerUsage).ToList();
            var largest = sortedByPowerUsage.First();

            //string result = $"{largest.Kind} shark: {largest.Length}m long.";

            return largest.ToString();
        }

        public int GetTotalCapacity()
        {
            var totalCapacity = Servers.Sum(s => s.Capacity);
            return totalCapacity;
        }

        public string DeviceManager()
        {
            StringBuilder listOfServers = new StringBuilder();

            Console.WriteLine($"{Servers.Count} servers operating:");
            foreach (var server in Servers)
            {
                listOfServers.AppendLine(server.ToString());
            }

            return listOfServers.ToString().TrimEnd();
        }
    }
}
