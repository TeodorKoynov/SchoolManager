using System;

namespace SchoolManager.Models.Contracts
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
    }
}
