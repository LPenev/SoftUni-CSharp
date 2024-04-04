using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    public class ClimberRepository : IRepository<IClimber>
    {
        private List<IClimber> all;

        public ClimberRepository()
        {
            all = new List<IClimber>();
        }

        public IReadOnlyCollection<IClimber> All => all.AsReadOnly();

        public void Add(IClimber model)
        {
            all.Add(model);
        }

        public IClimber Get(string name)
        {
            IClimber model = all.FirstOrDefault(x => x.Name == name);
            return model;
        }
    }
}
