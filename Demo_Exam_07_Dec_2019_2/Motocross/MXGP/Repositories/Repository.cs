using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        private readonly ICollection<T> models;
        protected Repository()
        {
            this.models = new List<T>();
        }
        public void Add(T model)
        {
            this.models.Add( model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return (IReadOnlyCollection<T>)this.models;
        }

        public T GetByName(string name)
        {

            //TODO: NNO IMPLEMENTED!!!!!!!!!!!!!!!

            throw new NotImplementedException();
        }

        public bool Remove(T model)
        {
            return models.Remove(model);
        }
    }
}
