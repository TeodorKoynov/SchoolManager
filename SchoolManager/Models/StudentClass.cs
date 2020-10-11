namespace SchoolManager.Models
{
    using SchoolManager.Models.Contracts;
    using System;
    using System.Collections.Generic;

    [Serializable]

    public class StudentClass : Entity
    {
        private ClassGrade grade;

        private GradeChar gradeChar;

        private IEnumerable<Student> students = null;

        private Teacher mainTeacher = null;

        public StudentClass(ClassGrade grade, GradeChar gradeChar, List<Student> students, Teacher mainTeacher)
        {
            this.grade = grade;
            this.gradeChar = gradeChar;
            this.students = students;
            this.mainTeacher = mainTeacher;
        }

        public ClassGrade Grade
        {
            get { return this.grade; }
            set { this.grade = value; }
        }

        public GradeChar GradeChar
        {
            get { return this.gradeChar; }
            set { this.gradeChar = value; }
        }

        public IEnumerable<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public Teacher MainTeacher
        { 
            get { return this.mainTeacher; }
            set { this.mainTeacher = value; }
        }

    }
}
