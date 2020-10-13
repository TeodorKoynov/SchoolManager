namespace SchoolManager
{
    using System;
    using System.Collections.Generic;
    using SchoolManager.Models;
    using SchoolManager.Repositories;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            DateTime dateTime1 = new DateTime(1965, 12, 12);
            Human human1 = new Human("Veselina", "Nqkoq", "Karapeeve", Gender.Female, 60, dateTime1, "0983849209", "08771728942");
            Human human2 = new Human("Mariq", "Nqkoq", "Peeve", Gender.Female, 50, dateTime1, "0983849209", "08771728942");
            Human human3 = new Human("Milka", "Nqkoq", "Karapeeve", Gender.Female, 20, dateTime1, "0983849209", "08771728942");
            Human human4 = new Human("Goshko", "Nqkoi", "Ivanov", Gender.Female, 52, dateTime1, "0983849209", "08771728942");

            Subject subject1 = new Subject("Biololgy", 12);
            Subject subject2 = new Subject("Chemestry", 12);
            Subject subject3 = new Subject("English", 12);

            List<Subject> subjects1 = new List<Subject>();
            subjects1.Add(subject1);
            subjects1.Add(subject2);


            Teacher teacher1 = new Teacher(human2, subjects1, 1000);
            Teacher teacher2 = new Teacher(human3, subjects1, 1000);
            subjects1.Add(subject3);

            Teacher teacher3 = new Teacher(human4, subjects1, 1000);

            List<Teacher> teacherStaff = new List<Teacher>();
            teacherStaff.Add(teacher2);
            teacherStaff.Add(teacher3);


            List<Teacher> viseDirectors1 = new List<Teacher>();
            viseDirectors1.Add(teacher1);


            Human human11 = new Human("Goshko", "Nqkoq", "Dadev", Gender.Male, 13, dateTime1, "23412341233", "08771724442");
            Human human12 = new Human("Penka", "Nqkoq", "Karanova", Gender.Female, 14, dateTime1, "1235123545", "0877452728942");

            Student student1 = new Student(human11, "0875474712"); // Number in class and subjects will be got from schoolClass
            Student student2 = new Student(human12, "0875235712");

            List<Student> students = new List<Student>();
            students.Add(student1);
            students.Add(student2);

            StudentClass studentClass1 = new StudentClass(ClassGrade.Forth, GradeChar.A, students, teacher1);

            List<StudentClass> studentClasses = new List<StudentClass>();
            studentClasses.Add(studentClass1);

            Human human21 = new Human("Milko", "Nqkoq", "Kenova", Gender.Female, 60, dateTime1, "0983849209", "08771728942");
            Human human22 = new Human("Lina", "Nqkoq", "Peeva", Gender.Female, 60, dateTime1, "0983849209", "08771728942");
            Human human23 = new Human("Vesi", "Nqkoq", "Kareve", Gender.Female, 60, dateTime1, "0983849209", "08771728942");

            Worker worker1 = new Worker(human21, WorkPosition.Cleaner, 1324);
            Worker worker2 = new Worker(human22, WorkPosition.BodyGuard, 1234);
            Worker worker3 = new Worker(human23, WorkPosition.Technician, 1234);

            List<Worker> staff1 = new List<Worker>();
            staff1.Add(worker1);
            staff1.Add(worker2);
            staff1.Add(worker3);

            Director director1 = new Director(human1, 1700);

            School school1 = new School("Mg", SchoolType.HighSchool, director1, viseDirectors1, studentClasses, staff1, teacherStaff);
            

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
    // + First, Middle, Last Name //
    // + Birthdate //
    // + Phone number //
    // + Parent phone number 
    // + Number in class
    // + ЕГН //
    // + Gender //
    // + Collection of (Subject + Grades)

    // Teacher
    // ...

    // Subjects
    // ...