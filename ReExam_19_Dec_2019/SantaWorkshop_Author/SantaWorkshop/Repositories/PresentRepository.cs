using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {
        private readonly ICollection<IPresent> models;

        //should not be List !!!!!!!!

        //i don't need any specific functionality of the list for this repository
        public PresentRepository()
        {
            this.models = new List<IPresent>();
        }
        public IReadOnlyCollection<IPresent> Models =>
            (IReadOnlyCollection < IPresent >) this.models;

        public void Add(IPresent model)
        {
            this.models.Add(model);
        }

        public IPresent FindByName(string name)
        {
            return this.models.FirstOrDefault(p => p.Name == name);
        }

        public bool Remove(IPresent model)
        {
            return this.models.Remove(model);
        }
    }
}
