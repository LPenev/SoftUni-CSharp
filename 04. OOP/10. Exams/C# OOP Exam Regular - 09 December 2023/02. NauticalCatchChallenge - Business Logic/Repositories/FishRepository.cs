﻿using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    public class FishRepository : IRepository<IFish>
    {
        private List<IFish> models;
        public IReadOnlyCollection<IFish> Models => models.AsReadOnly();

        public FishRepository()
        {
            models = new List<IFish>();
        }

        public void AddModel(IFish model)
        {
            models.Add(model);
        }

        public IFish GetModel(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}
