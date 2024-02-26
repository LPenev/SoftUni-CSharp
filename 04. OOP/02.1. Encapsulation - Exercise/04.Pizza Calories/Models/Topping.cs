namespace PizzaCalories.Models
{
    public class Topping
    {
        private const double BaseModifier = 2;
        private readonly Dictionary<string, double> toppingTypesCalories;
        
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            toppingTypesCalories = new() { { "meat", 1.2 },{ "veggies", 0.8 },{ "cheese",1.1 },{ "sauce", 0.9} };
            
            this.Type = type;
            this.Weight = weight;
        }

        public string Type 
        { 
            get => type;
            private set
            {
                if (!toppingTypesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                type = value;
            }
        }
        public double Weight
        { 
            get => weight;
            private set 
            {
                if (value < 0 || value > 50)
                {
                    throw new ArgumentException($"{type} weight should be in the range [1..50].");
                }

                weight = value; 
            } 
        }

        public double Calories
        {
            get => BaseModifier * Weight * toppingTypesCalories[Type.ToLower()];
        }
    }
}
