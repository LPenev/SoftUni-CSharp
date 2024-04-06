using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System.Text;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private IRepository<IInfluencer> influencers;
        private IRepository<ICampaign> campaigns;

        public Controller()
        {
            influencers = new InfluencerRepository();
            campaigns = new CampaignRepository();
        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var influencer in influencers.Models.OrderByDescending(i => i.Income).ThenByDescending(i => i.Followers))
            {
                sb.AppendLine(influencer.ToString());

                if (influencer.Participations.Any())
                {
                    sb.AppendLine("Active Campaigns:");

                    foreach (var campaign in campaigns.Models.Where(c => c.Contributors.Contains(influencer.Username)).OrderBy(c => c.Brand))
                    {
                        sb.AppendLine($"--{campaign.ToString()}");
                    }
                }
            }

            return sb.ToString().Trim();
        }

        public string AttractInfluencer(string brand, string username)
        {
            if (influencers.FindByName(username) == null)
            {
                return String.Format(OutputMessages.InfluencerNotFound, nameof(InfluencerRepository) ,username);
            }

            if (campaigns.FindByName(brand) == null)
            {
                return String.Format(OutputMessages.CampaignNotFound, brand);
            }

            IInfluencer influencer = influencers.FindByName(username);
            ICampaign campaign = campaigns.FindByName(brand);

            if (campaign.Contributors.Contains(influencer.Username))
            {
                return String.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            }

            if (campaign.GetType().Name == nameof(ProductCampaign))
            {
                if(influencer.GetType().Name != nameof(BusinessInfluencer) 
                    && influencer.GetType().Name != nameof(FashionInfluencer))
                {
                    return String.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
                }
            }

            if (campaign.GetType().Name == nameof(ServiceCampaign))
            {
                if (influencer.GetType().Name != nameof(BusinessInfluencer) 
                    && influencer.GetType().Name != nameof(BloggerInfluencer))
                {
                    return String.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
                }
            }

            double profit = influencer.CalculateCampaignPrice();

            if (campaign.Budget < profit)
            {
                return String.Format(OutputMessages.UnsufficientBudget, brand, username);
            }

            campaign.Engage(influencer);
            influencer.EarnFee(profit);
            influencer.EnrollCampaign(brand);

            return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
        }

        public string BeginCampaign(string typeName, string brand)
        {
            if(typeName != nameof(ProductCampaign) && typeName != nameof(ServiceCampaign)) 
            {
                return String.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
            }

            if(campaigns.FindByName(brand) != null)
            {
                return String.Format(OutputMessages.CampaignDuplicated, brand);
            }

            ICampaign currentCampaign;

            if(typeName == nameof(ProductCampaign))
            {
                currentCampaign = new ProductCampaign(brand);
            }
            else
            {
                currentCampaign = new ServiceCampaign(brand);
            }

            campaigns.AddModel(currentCampaign);
            return String.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
        }

        public string CloseCampaign(string brand)
        {
            ICampaign currentCampaign = campaigns.FindByName(brand);

            if (currentCampaign == null)
            {
                return String.Format(OutputMessages.InvalidCampaignToClose);
            }

            if(currentCampaign.Budget < 10000)
            {
                return String.Format(OutputMessages.NotPositiveFundingAmount, brand);
            }

            foreach (var influencer in currentCampaign.Contributors)
            {
                var currInfluencer = influencers.FindByName(influencer);
                currInfluencer.EarnFee(2000);
                currInfluencer.EndParticipation(currentCampaign.Brand);
            }

            campaigns.RemoveModel(currentCampaign);
            return String.Format(OutputMessages.CampaignClosedSuccessfully, brand);
        }

        public string ConcludeAppContract(string username)
        {
            IInfluencer influencer = influencers.FindByName(username);

            if (influencer == null) 
            {
                return String.Format(OutputMessages.InfluencerNotSigned, username);
            }

            if (influencer.Participations.Any())
            {
                return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);
            }

            influencers.RemoveModel(influencer);
            return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
        }

        public string FundCampaign(string brand, double amount)
        {
            ICampaign currentCampaign = campaigns.FindByName(brand);

            if (currentCampaign == null)
            {
                return String.Format(OutputMessages.InvalidCampaignToFund);
            }

            if(amount <= 0)
            {
                return String.Format(OutputMessages.NotPositiveFundingAmount);
            }

            currentCampaign.Gain(amount);
            return String.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
        }

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            if (typeName != "BusinessInfluencer"
                && typeName != "FashionInfluencer"
                && typeName != "BloggerInfluencer"
                )
            {
                return String.Format(OutputMessages.InfluencerInvalidType, typeName);
            }

            if (influencers.FindByName(username) != null)
            {
                return String.Format(OutputMessages.UsernameIsRegistered, username, nameof(InfluencerRepository));
            }

            IInfluencer influencer;

            if (typeName == "BusinessInfluencer")
            {
                influencer = new BusinessInfluencer(username, followers);
            }
            else if (typeName == "FashionInfluencer")
            {
                influencer = new FashionInfluencer(username, followers);
            }
            else
            {
                influencer = new BloggerInfluencer(username, followers);
            }

            influencers.AddModel(influencer);
            return String.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
        }
    }
}
