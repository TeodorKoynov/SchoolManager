﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManager.Models
{
    [Serializable]

    public class Teacher : Human
    {
        private IEnumerable<Subject> specializedSubjects = null;

        private int salary = 0;

        public Teacher(Human human, IEnumerable<Subject> specializedSubjects, int salary)
            :base(human.FirstName, human.MiddleName, human.LastName, human.Gender, human.Age, human.BirthDate, human.IdentityNumber, human.PhoneNumber)
        {
            this.specializedSubjects = specializedSubjects;
            this.salary = salary;
        }

        public IEnumerable<Subject> SpecializedSubjects
        {
            get { return this.specializedSubjects; }
            set { this.specializedSubjects = value; }
        }

        public int Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }

    }
}