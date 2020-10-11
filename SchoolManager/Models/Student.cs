using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManager.Models
{

    [Serializable]

    public class Student : Human
    {
        private IEnumerable<Subject> subjects = new List<Subject>(); // May change

        private int numberInGrade = 0;

        private string parentPhone = null;
        

        public Student(Human human, int numberInGrade, List<Subject> subjects, string parentPhone)
            :base(human.FirstName, human.MiddleName, human.LastName, human.Gender, human.Age, human.BirthDate, human.IdentityNumber, human.PhoneNumber)
        {
            this.numberInGrade = numberInGrade;
            this.subjects = subjects;
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
