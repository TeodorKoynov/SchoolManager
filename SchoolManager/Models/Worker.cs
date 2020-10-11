using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManager.Models
{
    [Serializable]

    public class Worker : Human
    {
        private WorkPosition position;

        private int salary = 0;

        public Worker(Human human, WorkPosition position, int salary)
            : base(human.FirstName, human.MiddleName, human.LastName, human.Gender, human.Age, human.BirthDate, human.IdentityNumber, human.PhoneNumber)
        {
            this.position = position;
            this.salary = salary;
        }
    }
}
