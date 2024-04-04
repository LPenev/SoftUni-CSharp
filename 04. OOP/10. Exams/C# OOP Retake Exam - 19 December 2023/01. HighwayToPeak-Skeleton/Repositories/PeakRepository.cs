using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    public class PeakRepository : IRepository<IPeak>
    {
        private List<IPeak> all;

        public PeakRepository()
        {
            all = new List<IPeak>();
        }

        public IReadOnlyCollection<IPeak> All => all.AsReadOnly();

        public void Add(IPeak model)
        {
            all.Add(model);
        }

        public IPeak Get(string name)
        {
            IPeak model = all.FirstOrDefault(x => x.Name == name);
            return model;
        }
    }
}
