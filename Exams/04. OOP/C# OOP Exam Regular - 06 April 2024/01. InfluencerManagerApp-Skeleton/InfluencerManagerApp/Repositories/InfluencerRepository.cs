using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories
{
    public class InfluencerRepository : IRepository<IInfluencer>
    {
        private List<IInfluencer> models;

        public InfluencerRepository()
        {
            models = new List<IInfluencer>();
        }

        public IReadOnlyCollection<IInfluencer> Models => models.AsReadOnly();

        public void AddModel(IInfluencer model) => models.Add(model);
        
        public IInfluencer FindByName(string name) => models.FirstOrDefault(x => x.Username == name);

        public bool RemoveModel(IInfluencer model) => models.Remove(model);
    }
}
