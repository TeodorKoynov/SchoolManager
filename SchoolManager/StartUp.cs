namespace SchoolManager
{
    using System;

    using SchoolManager.Models;
    using SchoolManager.Repositories;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            SchoolRepository schoolRepository = new SchoolRepository();

            var school = new School() { Name = "Test" };
            schoolRepository.Save(school);

            school.Name = "new name";

            schoolRepository.Save(school);

            Console.WriteLine(schoolRepository.Find(school.Id).Name);
        }
    }
}


    // Data Models

    // School
    // + Collection of StudentClasses
    // + Collection of Technical Staff
    // + Collection of Teachers
    // + Director
    // + Vice Director
    // + SchoolType
    // + Name

    // StudentClasse
    // + Grade
    // + GradeChar
    // + Collection of Students
    // + (Main) Teacher

    // Student
    // + First, Middle, Last Name
    // + Birthdate
    // + Phone number
    // + Parent phone number
    // + Number in class
    // + ЕГН
    // + Gender
    // + Collection of (Subject + Grades)

    // Teacher
    // ...

    // Subjects
    // ...