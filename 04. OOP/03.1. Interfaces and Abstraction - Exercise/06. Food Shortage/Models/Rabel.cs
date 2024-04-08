using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models
{
    public class Rabel : IBuyer
    {
        private const int DefaultFoodBuy = 5;
        public Rabel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Group { get; private set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += DefaultFoodBuy;
        }
    }
}
