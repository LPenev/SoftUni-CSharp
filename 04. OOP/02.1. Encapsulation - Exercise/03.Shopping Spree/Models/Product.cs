namespace ShoppingSpree.Models
{
    public class Product
    {
        private const string ArgumentExceptionNameText = "Name cannot be empty";
        private const string ArgumentExceptionMoneyText = "Money cannot be negative";

        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ArgumentExceptionNameText);
                }

                name = value;
            }
        }
        public decimal Cost
        {
            get { return cost; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ArgumentExceptionMoneyText);
                }

                cost = value;
            }
        }
        public override string ToString() => Name;
    }
}
