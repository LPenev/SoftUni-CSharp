namespace ShoppingSpree.Models
{
    public class Person
    {
        private const string ArgumentExceptionNameText = "Name cannot be empty";
        private const string ArgumentExceptionMoneyText = "Money cannot be negative";

        private string name;
        private decimal money;
        private List<string> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ArgumentExceptionNameText);
                }

                name = value;
            }
        }
        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ArgumentExceptionMoneyText);
                }

                money = value;
            }

        }

        public string Add(Product product)
        {
            if (Money < product.Cost)
            {
                return $"{Name} can't afford {product.Name}";
            }

            products.Add(product.Name);
            Money -= product.Cost;

            return $"{Name} bought {product}";
        }

        public override string ToString()
        {
            string result = string.Empty;

            if (products.Any())
            {
                result = $"{Name} - {string.Join(", ", products)}";
            }
            else
            {
                result = $"{Name} - Nothing bought";
            }
            return result;
        }
    }
}
