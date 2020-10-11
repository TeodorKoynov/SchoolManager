namespace SchoolManager.Repositories.Contracts
{
    using SchoolManager.Models.Contracts;
    using System.Collections.Generic;

    public interface IRepository<T, K> 
        where T : IEntity<K>
    {
        // create or update
        public T Save(T entity);

        // read
        public T Find(K id);

        public IEnumerable<T> GetAll();

        // delete
        public void Delete(K id);
        public void Delete(T entity);
    }
}
