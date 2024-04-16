namespace InfluencerManagerApp.Models
{
    public class BusinessInfluencer : Influencer
    {
        private const double EngagementRate = 3.0;
        private const double Factor = 0.15;

        public BusinessInfluencer(string username, int followers) : base(username, followers, EngagementRate)
        {
        }

        public override int CalculateCampaignPrice()
            => Convert.ToInt32(Math.Floor(Followers * EngagementRate * Factor));
    }
}
