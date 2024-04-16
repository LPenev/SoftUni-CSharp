namespace InfluencerManagerApp.Models
{
    public class BloggerInfluencer : Influencer
    {
        private const double EngagementRate = 2.0;
        private const double Factor = 0.2;

        public BloggerInfluencer(string username, int followers) : base(username, followers, EngagementRate)
        {
        }

        public override int CalculateCampaignPrice()
            => Convert.ToInt32(Math.Floor(Followers * EngagementRate * Factor));
    }
}
