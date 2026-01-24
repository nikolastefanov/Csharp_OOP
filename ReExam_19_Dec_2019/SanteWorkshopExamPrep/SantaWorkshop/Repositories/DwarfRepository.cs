using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SantaWorkshop.Repositories
{
    class DwarfRepository : IRepository<IDwarf>
    {
        private readonly ICollection<IDwarf> models;

        public DwarfRepository()
        {
            this.models = new List<IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models 
            =>(IReadOnlyCollection<IDwarf>)this.models;

        public void Add(IDwarf model)
        {
            this.models.Add(model);
        }

        public IDwarf FindByName(string name)
        {
            return this.models.FirstOrDefault(x=>x.Name==name);
        }

        public bool Remove(IDwarf model)
        {
            return this.models.Remove(model);
        }
    }
}
