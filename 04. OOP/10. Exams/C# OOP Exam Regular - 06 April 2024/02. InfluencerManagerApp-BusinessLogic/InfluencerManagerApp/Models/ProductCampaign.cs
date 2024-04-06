namespace InfluencerManagerApp.Models
{
    public class ProductCampaign : Campaign
    {
        private const double Budget = 60000;
        public ProductCampaign(string brand) : base(brand, Budget)
        {
        }
    }
}
