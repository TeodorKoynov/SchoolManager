namespace SchoolManager.Models
{
    using System;

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

        public int Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                this.salary = value;
            }
        }

        public WorkPosition WorkPosition
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.MiddleName} {this.LastName} is {this.position}";
        }
    }
}
