using FoodShortage.Models;
using FoodShortage.Models.Interfaces;

namespace FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new();

            int peopleCount = int.Parse(Console.ReadLine());

            Citizen citizen = null;
            Rabel rabel = null;

            for (int i = 0; i < peopleCount; i++)
            {
                string[] peopleArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = peopleArray[0];
                int age = int.Parse(peopleArray[1]);

                if (peopleArray.Length == 4)
                {
                    string id = peopleArray[2];
                    string birthday = peopleArray[3];
                    citizen = new(name, age, id, birthday);
                    
                    buyers.Add(citizen);
                }
                else
                {
                    string group = peopleArray[2];
                    rabel = new(name, age, group);

                    buyers.Add(rabel);
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string name = input;
                buyers.FirstOrDefault(x => x.Name == name)?.BuyFood();
            }

            Console.WriteLine(buyers.Sum(x => x.Food));
        }
    }
}
