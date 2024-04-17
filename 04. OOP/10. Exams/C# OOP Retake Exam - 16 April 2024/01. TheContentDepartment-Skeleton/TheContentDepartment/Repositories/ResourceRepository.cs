using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories
{
    public class ResourceRepository : IRepository<IResource>
    {
        private List<IResource> models;

        public ResourceRepository()
        {
            ResourceRepository resource = new ResourceRepository();
            models = new List<IResource>();
        }

        public IReadOnlyCollection<IResource> Models => models.AsReadOnly();

        public void Add(IResource model) => models.Add(model);

        public IResource TakeOne(string modelName) => models.FirstOrDefault(x => x.Name == modelName);
    }
}
