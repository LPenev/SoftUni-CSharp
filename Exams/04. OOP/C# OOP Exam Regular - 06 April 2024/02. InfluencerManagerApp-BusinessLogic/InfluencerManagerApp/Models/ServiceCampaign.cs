namespace InfluencerManagerApp.Models
{
    public class ServiceCampaign : Campaign
    {
        private const double Budget = 30000;

        public ServiceCampaign(string brand) : base(brand, Budget)
        {
        }
    }
}
