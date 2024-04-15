using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models
{
    public abstract class Influencer : IInfluencer
    {
        private string username;
        private int followers;
        private double engagementRate;
        private double income;
        private List<string> participations;

        public Influencer(string username, int followers, double engagementRate)
        {
            Username = username;
            Followers = followers;
            EngagementRate = engagementRate;
            income = 0;
            participations = new List<string>();
        }

        public string Username 
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
                }

                this.username = value;
            }
        }

        public int Followers 
        {
            get => followers;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
                }

                followers = value;
            }
        }

        public double EngagementRate 
        {
            get => engagementRate;
            private set => engagementRate = value;
        }

        public double Income => income;

        public IReadOnlyCollection<string> Participations => participations.AsReadOnly();

        public abstract int CalculateCampaignPrice();

        public void EarnFee(double amount)=> income += amount;
        
        public void EndParticipation(string brand) => participations.Remove(brand);

        public void EnrollCampaign(string brand) => participations.Add(brand);
    }
}
