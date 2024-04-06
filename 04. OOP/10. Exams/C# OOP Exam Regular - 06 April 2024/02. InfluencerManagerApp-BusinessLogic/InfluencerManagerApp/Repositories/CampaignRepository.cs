﻿using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories
{
    public class CampaignRepository : IRepository<ICampaign>
    {
        private List<ICampaign> models;

        public CampaignRepository()
        {
            models = new List<ICampaign>();
        }

        public IReadOnlyCollection<ICampaign> Models => models.AsReadOnly();

        public void AddModel(ICampaign model) => models.Add(model);

        public ICampaign FindByName(string name) => models.FirstOrDefault(x => x.Brand == name);

        public bool RemoveModel(ICampaign model) => models.Remove(model);
    }
}
