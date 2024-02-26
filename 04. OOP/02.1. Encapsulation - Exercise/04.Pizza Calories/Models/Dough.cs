namespace PizzaCalories.Models
{
    public class Dough
    {
        private const string DefaultErrorMessage = "Invalid type of dough.";
        private const string DoughWeightErrorMessage = "Dough weight should be in the range[1..200].";
        private const double BaseModifier = 2;

        private readonly Dictionary<string, double> flourTypesCalories;
        private readonly Dictionary<string, double> bakingTechniquesCalories;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            flourTypesCalories = new() { { "white", 1.5 }, { "wholegrain", 1.0 } };
            bakingTechniquesCalories = new() { { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1.0 } };
            
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => flourType;

            private set
            {
                if (! flourTypesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(DefaultErrorMessage);
                }

                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;
            private set 
            {
                if(!bakingTechniquesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(DefaultErrorMessage);
                }

                bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => weight;
            private set
            {
                if(value < 1 || value > 200)
                {
                    throw new ArgumentException(DoughWeightErrorMessage);
                }

                weight = value;
            }
        }


        public double Calories
        {
            get
            {
                double calories
                    = Weight * BaseModifier * flourTypesCalories[FlourType.ToLower()] * bakingTechniquesCalories[BakingTechnique.ToLower()];
                return calories;
            }
        }

    }
}
