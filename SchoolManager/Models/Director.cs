using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManager.Models
{
    [Serializable]

    public class Director : Human
    {
        private int salary = 0;

        public Director(Human human, int salary)
            : base(human.FirstName, human.MiddleName, human.LastName, human.Gender, human.Age, human.BirthDate, human.IdentityNumber, human.PhoneNumber)
        {
            this.salary = salary;
        }

        public int Salary
        {
            get { return this.salary; }
            set { this.salary = salary; }
        }
    }
}
