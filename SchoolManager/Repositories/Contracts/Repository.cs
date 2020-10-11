namespace SchoolManager.Repositories.Contracts
{
    using System.Collections.Generic;
    using System.Linq;

    using SchoolManager.Models.Contracts;

    public abstract class Repository<T> : IRepository<T, int>
        where T : Entity
    {
        private ICollection<T> entities = new HashSet<T>();

        public virtual T Save(T entity)
        {
            if (entity.Id == 0)
            {
                entity.Id = GetNextId();
            }
            else
            {
                this.Delete(entity.Id);
            }

            this.entities.Add(entity.DeepClone());

            return entity;
        }

        public T Find(int id)
        {
            return this.entities.FirstOrDefault(x => x.Id == id)?.DeepClone();
        }

        public IEnumerable<T> GetAll()
        {
            return this.entities
                .Select(x => x.DeepClone())
                .ToList()
                .AsReadOnly();
        }

        public void Delete(int id)
        {
            T entity = this.Find(id);

            if (entity == null)
            {
                return;
            }

            this.entities.Remove(entity);
        }

        public void Delete(T entity)
        {
            this.Delete(entity.Id);
        }

        private int GetNextId()
        {
            if (this.entities.Count == 0)
            {
                return 1;
            }

            return this.entities.Max(x => x.Id) + 1;
        }
    }
}
