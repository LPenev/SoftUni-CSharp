using PizzaCalories.Models;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaName = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] doughType = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Dough dough = new(doughType[1], doughType[2], double.Parse(doughType[3]));
                Pizza pizza = new(pizzaName[1], dough);

                string input = string.Empty;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingArray = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Topping topping = new(toppingArray[1], double.Parse(toppingArray[2]));
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
