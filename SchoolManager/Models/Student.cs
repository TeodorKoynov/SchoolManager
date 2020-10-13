namespace SchoolManager.Models
{
    using System;
    using System.Collections.Generic;

    [Serializable]

    public class Student : Human
    {
        private IEnumerable<Subject> subjects = new List<Subject>(); // May change

        private int numberInGrade = 0;

        private string parentPhone = null;
        

        public Student(Human human, string parentPhone)
            :base(human.FirstName, human.MiddleName, human.LastName, human.Gender, human.Age, human.BirthDate, human.IdentityNumber, human.PhoneNumber)
        {
            this.numberInGrade = 0;
            this.subjects = null;
            this.parentPhone = parentPhone;
        }

        public IEnumerable<Subject> Subjects
        {
            get { return this.subjects; }
            set { this.subjects = value; }
        }

        public int NumberInGrade
        {
            get { return this.numberInGrade; }
            set { this.numberInGrade = value; }
        }

        public string ParentPhone
        { 
            get { return this.parentPhone; }
            set { this.parentPhone = value; }
        }
    }
}
