using System.Numerics;

namespace _102._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, BigInteger> resources = new Dictionary<string, BigInteger>();
            string name = string.Empty;
            int counter = 0;

            while((name = Console.ReadLine()) != "stop")
            {
                BigInteger value = BigInteger.Parse(Console.ReadLine());
                if (resources.ContainsKey(name))
                {
                    resources[name] += value;
                } 
                else
                {
                    resources.Add(name, value);
                }
            }

            foreach(var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}