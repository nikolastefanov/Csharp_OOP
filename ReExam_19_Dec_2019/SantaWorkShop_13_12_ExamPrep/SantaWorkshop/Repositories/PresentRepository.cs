using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {

        private readonly List<IPresent> models;

        public PresentRepository()
        {
            this.models = new List<IPresent>();
        }

        public IReadOnlyCollection<IPresent> Models 
            => this.models.AsReadOnly();

        public void Add(IPresent model)
        {
            models.Add(model);
        }

        public IPresent FindByName(string name)
        {
            return models.FirstOrDefault(x=>x.Name==name);
        }

        public bool Remove(IPresent model)
        {
            return models.Remove(model);
        }
    }
}
