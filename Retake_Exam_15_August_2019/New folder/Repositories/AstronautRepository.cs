namespace SpaceStation.Repositories
{
    using SpaceStation.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class AstronautRepository<T> : IRepository<T>
    {
        public IReadOnlyCollection<T> Models => throw new NotImplementedException();

        public void Add(T model)
        {
            throw new NotImplementedException();
        }

        public T FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T model)
        {
            throw new NotImplementedException();
        }
    }


}
