﻿using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    public class DiverRepository : IRepository<IDiver>
    {
        private List<IDiver> models;
        public IReadOnlyCollection<IDiver> Models => models.AsReadOnly();

        public void AddModel(IDiver model)
        {
            models.Add(model);
        }

        public IDiver GetModel(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}
