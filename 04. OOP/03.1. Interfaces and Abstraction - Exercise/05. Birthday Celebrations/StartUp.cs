using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;
using BorderControl.Models;

namespace BirthdayCelebrations
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> list = new List<IBirthable>();

            Pet pet;
            Citizen citizen;

            string input = string.Empty;
            while((input = Console.ReadLine()) != "End")
            {
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = inputArray[0];

                if(command == "Citizen")
                {
                    string name = inputArray[1];
                    int age = int.Parse(inputArray[2]);
                    string id = inputArray[3];
                    string birthday = inputArray[4];

                    citizen = new(name, age, id, birthday);
                    list.Add(citizen);
                }
                else if(command == "Pet")
                {
                    string name = inputArray[1];
                    string bithday = inputArray[2];

                    pet = new(name, bithday);
                    list.Add(pet);
                }
            }

            string year = Console.ReadLine();

            foreach(var currentElement  in list)
            {
                if(currentElement.Birthday.EndsWith(year))
                {
                    Console.WriteLine(currentElement.Birthday);
                }
            }
        }
    }
}
