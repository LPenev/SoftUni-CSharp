using BorderControl.Models;
using BorderControl.Models.Intrefaces;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentitable> list = new List<IIdentitable>();

            Citizen citizen = null;
            Robot robot = null;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (inputArray.Length == 3)
                {
                    string name = inputArray[0];
                    int age = int.Parse(inputArray[1]);
                    string id = inputArray[2];

                    citizen = new Citizen(name, age, id);
                    list.Add(citizen);
                }
                else
                {
                    string model = inputArray[0];
                    string id = inputArray[1];

                    robot = new Robot(model, id);
                    list.Add(robot);
                }
            }

            string invalidSufix = Console.ReadLine();

            foreach (var currentElement in list)
            {
                if (currentElement.Id.EndsWith(invalidSufix))
                {
                    Console.WriteLine(currentElement.Id);
                }
            }
        }
    }
}
