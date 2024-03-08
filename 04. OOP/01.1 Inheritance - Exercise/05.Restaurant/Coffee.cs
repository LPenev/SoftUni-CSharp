namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal CofeePrice = 3.50m;
        private const double CoffeMilliliters = 50;

        public Coffee(string name, double caffeine) : base(name, CofeePrice, CoffeMilliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine {  get; set; }
    }
}
