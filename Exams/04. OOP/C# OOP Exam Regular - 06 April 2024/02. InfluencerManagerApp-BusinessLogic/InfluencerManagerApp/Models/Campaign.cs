using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models
{
    public abstract class Campaign : ICampaign
    {
        private string brand;
        List<string> contributors;

        protected Campaign(string brand, double budget)
        {
            this.brand = brand;
            Budget = budget;
            contributors = new List<string>();
        }

        public string Brand
        {
            get => brand;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandIsrequired);
                }

                brand = value;
            }
        }

        public double Budget { get; private set; }

        public IReadOnlyCollection<string> Contributors => contributors.AsReadOnly();

        public void Engage(IInfluencer influencer)
        {
            contributors.Add(influencer.Username);
        }

        public void Gain(double amount)
        {
            Budget += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType()} - Brand: {Brand}, Budget: {Budget}, Contributors: {contributors.Count}";
        }
    }
}
