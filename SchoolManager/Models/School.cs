
namespace SchoolManager.Models
{
    using System;
    using System.Collections.Generic;
    using SchoolManager.Models.Contracts;

    [Serializable]
    public class School : Entity
    {
        private string name = null;

        private SchoolType schoolType;

        private Director director = null;

        private IEnumerable<Teacher> viseDirectors = null;

        private IEnumerable<StudentClass> studentClasses = null;

        private IEnumerable<Worker> staff = null;

        private IEnumerable<Teacher> teachersStaff = null;


        public School(string name, 
            SchoolType schoolType, 
            Director director, 
            IEnumerable<Teacher> viseDirectors,
            IEnumerable<StudentClass> studentClasses, 
            IEnumerable<Worker> staff, 
            IEnumerable<Teacher> teachersStaff)
        {
            this.name = name;
            this.director = director;
            this.viseDirectors = viseDirectors;
            this.studentClasses = studentClasses;
            this.staff = staff;
            this.teachersStaff = teachersStaff;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public SchoolType SchoolType
        {
            get { return this.schoolType; }
            set { this.schoolType = value; }
        }

        public Director Director
        {
            get { return this.director; }
            set { this.director = value; }
        }
        public IEnumerable<Teacher> ViseDirectors
        {
            get { return this.viseDirectors; }
            set { this.viseDirectors = value; }
        }

        public IEnumerable<StudentClass> StudentClasses
        {
            get { return this.studentClasses; }
            set { this.studentClasses = value; }
        }
        
        public IEnumerable<Worker> Staff
        {
            get { return this.staff; }
            set { this.staff = value; }
        }
        public IEnumerable<Teacher> TeachersStaff
        {
            get { return this.teachersStaff; }
            set { this.teachersStaff = value; }
        }
    }
}
