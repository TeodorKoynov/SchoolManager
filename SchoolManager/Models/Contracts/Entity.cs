namespace SchoolManager.Models.Contracts
{
    using System;
    using System.Diagnostics.CodeAnalysis;


    [Serializable]
    public abstract class Entity : IEntity<int>, IEquatable<Entity>, IComparable<Entity>
    {
        public int Id { get; set; }

        public int CompareTo([AllowNull] Entity other)
        {
            return this.Id - other.Id;
        }

        public bool Equals([AllowNull] Entity other)
        {
            if (this.Id == 0 && other.Id == 0)
            {
                return false;
            }


            return this.Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (obj is Entity entity)
            {
                return this.Equals(entity);
            }

            return false;
        }

        public override int GetHashCode()
        { 
            return this.Id.GetHashCode();
        }
    }
}
