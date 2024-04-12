using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    public class FishRepository : IRepository<IFish>
    {
        private List<IFish> fishs;
        public IReadOnlyCollection<IFish> Models => fishs.AsReadOnly();

        public void AddModel(IFish model)
        {
            fishs.Add(model);
        }

        public IFish GetModel(string name)
        {
            return fishs.FirstOrDefault(x => x.Name == name);
        }
    }
}
