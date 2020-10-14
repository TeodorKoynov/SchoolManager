namespace SchoolManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
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

            SchoolRepository schoolRepository1 = new SchoolRepository();
            schoolRepository1.Save(school1);
            ///////////////////////////////////////////////////////////////////////////////////////////////

            SchoolRepository schoolRepository = new SchoolRepository();
            ShowMenu(schoolRepository);

        }
        private static void ShowMenu(SchoolRepository schoolRepository)
        {
            bool showMenu = true;

            while (showMenu)
            {
                showMenu = MainMenu(schoolRepository);
            }
        }

        private static bool MainMenu(SchoolRepository schoolRepository)
        {
            Console.Clear();
            Console.WriteLine("1) Create School");
            Console.WriteLine("2) Select School");
            Console.WriteLine("3) Exit");
            Console.WriteLine("\nSelect an option:");

            switch (Console.ReadLine())
            {
                case "1":
                    CreateSchool(schoolRepository);
                    return true;

                case "2":
                    SelectSchool(schoolRepository);
                    return true;

                case "3":
                    return false;

                default:
                    return true;
            }
        }

        private static void SelectSchool(SchoolRepository schoolRepository)
        {
            Console.Clear();
            Console.WriteLine("===== Select School =====");
            List<School> schools = schoolRepository.GetAll().ToList();
            
            foreach (School school in schools)
            {
                Console.WriteLine($"-------> {school.Name}");
            }

            Console.WriteLine("\nSelect a School:");

            string line = Console.ReadLine();

            foreach (School school in schools)
            {
                if (school.Name == line)
                {
                    Console.WriteLine("School selected!");
                }
            }
        }

        private static void CreateSchool(SchoolRepository schoolRepository)
        {
            Console.Clear();

            string name = SelectSchoolName();

            SchoolType type = SelectSchoolType();

            Director director = SelectDirector();

            List<Teacher> viseDirectors = new List<Teacher>();

            List<StudentClass> studentClasses = new List<StudentClass>();

            List<Worker> workers = new List<Worker>();

            List<Teacher> teachers = new List<Teacher>();

            School school = new School(name, type, director, viseDirectors, studentClasses, workers, teachers);

            schoolRepository.Save(school);
        }

        private static string SelectSchoolName()
        {
            Console.WriteLine("Plase, Enter a Name for The School:");
            string name = SelectName();
          
            return name;
        }

        private static Director SelectDirector()
        {
            Console.WriteLine("\nCreate Director for The School");

            Human human = SelectHuman();

            int salary = SelectSalary();

            Director director = new Director(human, salary);

            return director;
        }

        private static int SelectSalary()
        {
            Console.WriteLine("Please, Enter a Salary:");

            string line = Console.ReadLine().Trim();

            int salary;

            while (!int.TryParse(line, out salary) || !(salary > 0))
            {
                Console.WriteLine("Incorrect Salary!");
                Console.WriteLine("\nPlease, Enter Salary:");
               
                line = Console.ReadLine().Trim();
            }
           
            salary = int.Parse(line);

            return salary;
        }

        private static Human SelectHuman()
        {
            Console.WriteLine("Enter First Name:");
            string firstName = SelectName();

            Console.WriteLine("Enter Middle Name:");
            string middleName = SelectName();

            Console.WriteLine("Enter Last Name:");
            string lastName = SelectName();

            Gender gender = SelectGender();

            int age = SelectAge();

            DateTime birthDate = SelectBirthDate();

            string identityNumber = null;

            string phoneNumber = SelectPhoneNumber();

            Human human = new Human(firstName, middleName, lastName, gender, age, birthDate, identityNumber, phoneNumber);

            return human;
        }

        private static string SelectPhoneNumber()
        {
            Console.WriteLine("Please, Enter a Phone Number:");

            string line = Console.ReadLine().Trim();

            while (line.Length != 10 || !int.TryParse(line, out _))
            {
                Console.WriteLine("Please, Enter a Correct Phone Number!");
                
                line = Console.ReadLine().Trim();
            }
            
            return line;
        }

        private static DateTime SelectBirthDate()
        {
            Console.WriteLine("\nPlease, Enter a Birth Date:");

            Console.WriteLine("-----> Enter a Year:");

            int year = SelectYear();

            Console.WriteLine("-----> Enter a Month:");

            int month = SelectMonth();

            Console.WriteLine("-----> Enter a Day:");

            int day = SelectDay();

            DateTime birthDate = new DateTime(year, month, day);

            return birthDate;
        }

        private static int SelectDay()
        {
            string line = Console.ReadLine().Trim();

            int day;

            while (!int.TryParse(line, out day) || !(day >= 1 && day <= 30))
            {
                Console.WriteLine("         Incorrect Day!");
                Console.WriteLine("\nPlease, Enter an Correct Day:");

                line = Console.ReadLine().Trim();
            }

            day = int.Parse(line);
            
            return day;
        }

        private static int SelectMonth()
        {
            string line = Console.ReadLine().Trim();

            int month;

            while (!int.TryParse(line, out month) || !(month >= 1 && month <= 12))
            {
                Console.WriteLine("         Incorrect Month!");
                Console.WriteLine("\nPlease, Enter an Correct Month:");

                line = Console.ReadLine().Trim();
            }
            month = int.Parse(line);
            
            return month;
        }

        private static int SelectYear()
        {
            string line = Console.ReadLine().Trim();

            int year;
            
            while ((line.Length <= 2 && line.Length > 5) || !int.TryParse(line, out year) || !(year > 1500 && year <= 3000))
            {
                Console.WriteLine("         Incorrect Year!");
                Console.WriteLine("\nPlease, Enter an Correct Year:");

                line = Console.ReadLine().Trim();
            }
            year = int.Parse(line);
            
            return year;
        }

        private static int SelectAge()
        {
            int age;

            Console.WriteLine("Please, Enter an Age:");

            string line = Console.ReadLine().Trim();

            while (!(line.Length > 0 && line.Length <= 3) || !int.TryParse(line, out age) || !(age > 0 && age <= 160))
            {
                Console.WriteLine("Incorrect Age!");
                Console.WriteLine("\nPlease, Enter an Age:");

                line = Console.ReadLine().Trim();
            }
            age = int.Parse(line);
           
            return age;
        }

        private static Gender SelectGender()
        {
            Console.WriteLine("Please enter a gender");
            Console.WriteLine("===== Male ==== Female =====");
            switch (Console.ReadLine().ToLower().Trim())
            {
                case "male":
                    return Gender.Male;
                case "female":
                    return Gender.Female;
                default:
                    Console.WriteLine("Please, Enter a Correct Gender!");
                    break;
            }
            
            return SelectGender();
        }

        private static string SelectName()
        {
            Console.WriteLine("Plese enter a name from 3 to 60 characters:");

            string line = Console.ReadLine().Trim();
            while (line.Length < 2 || line.Length >= 60)
            {
                Console.WriteLine("Incorect name!");
                Console.WriteLine("\nPlese enter a name from 3 to 60 characters:");
                line = Console.ReadLine();
            }

            return line;
        }

        private static SchoolType SelectSchoolType()
        {
            Console.WriteLine("\nEnter School Type:");
            Console.WriteLine("Available Types -> Primary School, Secondary School, Middle School, High School, University");
            switch (Console.ReadLine().ToLower().Trim())
            {
                case "primary school":
                    return SchoolType.PrimarySchool;
               
                case "secondary school":
                    return SchoolType.SecondarySchool;
                
                case "middle school":
                    return SchoolType.MiddleSchool;
               
                case "high school":
                    return SchoolType.HighSchool;
               
                case "university":
                    return SchoolType.University;
               
                default:
                    Console.WriteLine("Please, Enter a Correct Type!");
                    break;
            }
         
            return SelectSchoolType();
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