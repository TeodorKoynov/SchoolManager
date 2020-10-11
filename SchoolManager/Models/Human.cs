namespace SchoolManager.Models
{
    using System;

    [Serializable]

    public class Human
    {
        private string firstName = null;

        private string middleName = null;

        private string lastName = null;

        private Gender gender;

        private int age = 0;

        private DateTime birthDate;

        private string identityNumber = null;

        private string phoneNumber = null;
       
        
        public Human(string firstName, string middleName, string lastName, Gender gender, int age, DateTime birthDate, string identityNumber, string phoneNumber) // may change birthDate
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.gender = gender;
            this.age = age;
            this.birthDate = birthDate;
            this.identityNumber = identityNumber;
            this.phoneNumber = phoneNumber;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string MiddleName
        {
            get { return this.middleName; }
            set { this.middleName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public Gender Gender
        {
            get { return this.gender; }
            set { this.gender = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public DateTime BirthDate
        {
            get { return this.birthDate; }
            set { this.birthDate = value; }
        }

        public string IdentityNumber
        {
            get { return this.identityNumber; }
            set { this.identityNumber = value; }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }
    }
}
