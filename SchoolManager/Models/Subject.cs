using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManager.Models
{
    [Serializable]

    public class Subject
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
