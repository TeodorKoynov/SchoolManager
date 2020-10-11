
namespace SchoolManager.Models
{
    using System;

    using SchoolManager.Models.Contracts;

    [Serializable]
    public class School : Entity
    {
        public string Name { get; set; }
    }
}
