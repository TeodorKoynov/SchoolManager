namespace SchoolManager.Models
{
    using System;

    using SchoolManager.Models.Contracts;

    [Serializable]

    public class Subject : Entity
    {
        private string name = null;

        private int lessonsCount = 0;

        public Subject(string name, int lessonsCount)
        {
            this.name = name;
            this.lessonsCount = lessonsCount;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int LessonsCount
        {
            get { return this.lessonsCount; }
            set { this.lessonsCount = value; }
        }
    }
}
