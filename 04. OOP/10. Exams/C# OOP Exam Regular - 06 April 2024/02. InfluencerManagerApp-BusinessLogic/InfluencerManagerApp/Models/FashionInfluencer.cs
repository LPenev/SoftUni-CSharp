namespace InfluencerManagerApp.Models
{
    public class FashionInfluencer : Influencer
    {
        private const double EngagementRate = 4.0;
        private const double Factor = 0.1;

        public FashionInfluencer(string username, int followers) : base(username, followers, EngagementRate)
        {
        }

        public override int CalculateCampaignPrice()
            => Convert.ToInt32(Math.Floor(Followers * EngagementRate * Factor));
    }
}
