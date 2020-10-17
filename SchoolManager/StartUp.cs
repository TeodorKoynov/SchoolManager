namespace SchoolManager
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Tracing;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Xml;
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

            List<StudentClass> studentClasses1 = new List<StudentClass>();
            studentClasses1.Add(studentClass1);

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

            School school1 = new School("Mg", SchoolType.HighSchool, director1, viseDirectors1, studentClasses1, staff1, teacherStaff);

            List<Teacher> viseDirectors = new List<Teacher>();

            List<StudentClass> studentClasses = new List<StudentClass>();

            List<Worker> workers = new List<Worker>();

            List<Teacher> teachers = new List<Teacher>();

            School school2 = new School("Turgovska", SchoolType.HighSchool, director1, viseDirectors, studentClasses, workers, teacherStaff);
            School school3 = new School("Humanitarna", SchoolType.HighSchool, director1, viseDirectors, studentClasses, workers, teacherStaff);
            School school4 = new School("Angliiska", SchoolType.HighSchool, director1, viseDirectors, studentClasses, workers, teacherStaff);


            SchoolRepository schoolRepository1 = new SchoolRepository();
            schoolRepository1.Save(school1);
            ///////////////////////////////////////////////////////////////////////////////////////////////

            SchoolRepository schoolRepository = new SchoolRepository();

            schoolRepository.Save(school1); // REMOVE
            schoolRepository.Save(school2); // REMOVE
            schoolRepository.Save(school3); // REMOVE
            schoolRepository.Save(school4); // REMOVE

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
                Console.WriteLine($"------->Id= {school.Id} Name: {school.Name}");
            }

            Console.WriteLine("\nSelect a School Id:");

            string line = Console.ReadLine().Trim();
            
            int id = 0;

            while (!int.TryParse(line, out id) || (schoolRepository.Find(id) == null))
            {
                if (line == "`")
                {
                    return;
                }
                Console.WriteLine("Invalid Id!");
                line = Console.ReadLine();

            }

            School schoolToEdit = schoolRepository.Find(id);
            
            EditSchool(schoolToEdit, schoolRepository, id);
        }

        private static void EditSchool(School schoolToEdit, SchoolRepository schoolRepository, int id) // may remove id
        {
            Console.Clear();
            Console.WriteLine($"1 Name:{schoolToEdit.Name}");

            Console.Write("\n2 School Type: ");
            switch (schoolToEdit.SchoolType)
            {
                case SchoolType.PrimarySchool:
                    Console.Write("Primary School\n");
                    break;
                case SchoolType.SecondarySchool:
                    Console.Write("Secondary School\n");
                    break;
                case SchoolType.MiddleSchool:
                    Console.Write("Middle School\n");
                    break;
                case SchoolType.HighSchool:
                    Console.Write("High School\n");
                    break;
                case SchoolType.University:
                    Console.Write("University\n");
                    break;
                default:
                    break;
            }

            Console.WriteLine($"\n3 Director: {schoolToEdit.Director.FirstName} {schoolToEdit.Director.MiddleName} {schoolToEdit.Director.LastName}");

            Console.WriteLine("\n4 Vise Directors:");
            if (schoolToEdit.ViseDirectors.Count() != 0)
            {
                foreach (Teacher viseDirector in schoolToEdit.ViseDirectors)
                {
                    Console.WriteLine($" --- {viseDirector}");
                }
            }
            else
            {
                Console.WriteLine(" ----------- Empty ------------");
            }
          
            Console.WriteLine("\n5 Teachers:");
            if (schoolToEdit.TeachersStaff.Count() != 0)
            {
                foreach (Teacher teacher in schoolToEdit.TeachersStaff)
                {
                    Console.WriteLine($" --- {teacher}");
                }
            }
            else
            {
                Console.WriteLine(" ----------- Empty ------------");
            }

            Console.WriteLine($"\n6 Student Classes:");
           
            if (schoolToEdit.StudentClasses.Count() != 0)
            {
                foreach (StudentClass studentClass in schoolToEdit.StudentClasses)
                {
                    Console.WriteLine($" --- {studentClass}");
                }
            }
            else
            {
                Console.WriteLine(" ----------- Empty ------------");
            }

            Console.WriteLine("\n7 School Saff:");
            if (schoolToEdit.Staff.Count() != 0)
            {
                foreach (Worker worker in schoolToEdit.Staff)
                {
                    Console.WriteLine($" --- {worker}");
                }
            }
            else
            {
                Console.WriteLine(" ----------- Empty ------------");
            }

            Console.WriteLine("\nTo edit enter component number:");
            string line = Console.ReadLine().Trim().ToLower();

            if (line == "`")
            {
                SelectSchool(schoolRepository);
                return;
            }
            else
            {
                switch (line)
                {
                    case "1":
                        EditSchoolName(schoolToEdit, schoolRepository, id);
                        break;

                    case "2":
                        EditSchoolType(schoolToEdit, schoolRepository, id);
                        break;

                    case "3":
                        EditSchoolDirector(schoolToEdit, schoolRepository, id);
                        break;

                    case "4":
                        EditSchoolViseDirectors(schoolToEdit, schoolRepository, id);
                        break;
                    case "5":

                        break;
                    case "6":

                        break;
                    case "7":

                        break;
                    default:
                        break;
                }
            }
        }

        private static void EditSchoolViseDirectors(School schoolToEdit, SchoolRepository schoolRepository, int id)
        {
            Console.Clear();

            Console.WriteLine("Current Vise Directors:");

            if (schoolToEdit.ViseDirectors.Count() != 0)
            {
                foreach (Teacher viseDirector in schoolToEdit.ViseDirectors)
                {
                    Console.WriteLine($" - {viseDirector}");
                }

                Console.WriteLine("\n=== Available operation ===");
                Console.WriteLine("  1.Add new Vise Director");
                Console.WriteLine("  2.Edit Vise Director");

                Console.WriteLine("\nEnter a number of the wish operation or '`' to return:");
                
                string line = Console.ReadLine().Trim();

                if (line == "`")
                {
                    EditSchool(schoolToEdit, schoolRepository, id);
                    return;
                }
                switch (line)
                {
                    case "1":
                        AddViseDirector(schoolToEdit, schoolRepository, id);
                        break;

                    case "2":
                        break;
                    
                    default:
                        Console.WriteLine("Incorrect Number!");
                        Console.WriteLine("Click Enter...");
                        Console.ReadLine();
                        EditSchoolViseDirectors(schoolToEdit, schoolRepository, id);
                        return;
                        break;
                }
            }
            else
            {
                Console.WriteLine(" ----------- Empty ------------");

                Console.WriteLine("\n=== Available operation ===");
                Console.WriteLine("  1.Add new Vise Director");

                Console.WriteLine("\nEnter a number of the wish operation or '`' to return::");
                
                string line = Console.ReadLine().Trim();

                if (line == "`")
                {
                    EditSchool(schoolToEdit, schoolRepository, id);
                    return;
                }

                switch (line)
                {
                    case "1":
                        AddViseDirector(schoolToEdit, schoolRepository, id);
                        break;

                    default:
                        Console.WriteLine("Incorrect Number!");
                        Console.WriteLine("Click Enter...");
                        Console.ReadLine();
                        EditSchoolViseDirectors(schoolToEdit, schoolRepository, id);
                        return;
                        break;
                }
            }
        }

        private static void AddViseDirector(School schoolToEdit, SchoolRepository schoolRepository, int id)
        {

        }

        private static void EditSchoolDirector(School schoolToEdit, SchoolRepository schoolRepository, int id)
        {
            Console.Clear();

            Console.WriteLine($"=== {schoolToEdit.Name}'s Director ===");

            Console.WriteLine($" 1.{schoolToEdit.Director.FirstName} {schoolToEdit.Director.MiddleName} {schoolToEdit.Director.LastName}");
           
            Console.WriteLine($" 2.Phone number: {schoolToEdit.Director.PhoneNumber}");
            
            Console.WriteLine($" 3.Salary: {schoolToEdit.Director.Salary}");

            Console.WriteLine($" 4.Gender {schoolToEdit.Director.Gender}");

            Console.WriteLine($" 5.Identity number: {schoolToEdit.Director.IdentityNumber}");

            Console.WriteLine($" 6.Birth date: {schoolToEdit.Director.BirthDate}");

            Console.WriteLine("\nEnter the number of the component to edit:");

            string line = Console.ReadLine();

            switch (line)
            {
                case "1":
                    ChangeDirectorName(schoolToEdit, schoolRepository, id);
                    break;
                
                case "2":
                    ChangeDirectorPhoneNumber(schoolToEdit, schoolRepository, id);
                    break;
                
                case "3":
                    ChangeDirectorSalary(schoolToEdit, schoolRepository, id);
                    break;
                
                case "4":
                    ChangeDirectorGender(schoolToEdit, schoolRepository, id);
                    break;
                case "5":
                    ChangeDirectorIdentityNumber(schoolToEdit, schoolRepository, id);
                    break;
                case "6":
                    ChangeDirectorBirthDate(schoolToEdit, schoolRepository, id);
                    break;
                default:
                    break;
            }
        }

        private static void ChangeDirectorBirthDate(School schoolToEdit, SchoolRepository schoolRepository, int id)
        {
            Console.Clear();

            Console.WriteLine($"Current Birth Date: {schoolToEdit.Director.BirthDate.Date}");

            Console.WriteLine($" 1.Day {schoolToEdit.Director.BirthDate.Day}");

            Console.WriteLine($" 2.Month {schoolToEdit.Director.BirthDate.Month}");

            Console.WriteLine($" 3.Year {schoolToEdit.Director.BirthDate.Year}");


            Console.WriteLine("To edit component select the number of the component:");

            Console.WriteLine("\nEnter number or '`' to return:");

            string line = Console.ReadLine().Trim();

            if (line == "`")
            {
                EditSchoolDirector(schoolToEdit, schoolRepository, id);
                return;
            }

            switch (line)
            {
                case "1":
                    Console.WriteLine("\nEnter new Day or '`' to return");

                    line = Console.ReadLine().Trim();

                    if (line == "`")
                    {
                        ChangeDirectorBirthDate(schoolToEdit, schoolRepository, id);
                        return;
                    }
                    else
                    {
                        int day;
                        while (!int.TryParse(line, out day) || !(day < 31 && day > 0))
                        {
                            Console.WriteLine("Incorrect Day!");

                            Console.WriteLine("\nEnter new Day or '`' to return");

                            line = Console.ReadLine();

                            if (line == "`")
                            {
                                ChangeDirectorBirthDate(schoolToEdit, schoolRepository, id);
                                return;
                            }
                        }
                        day = int.Parse(line);

                        int month = schoolToEdit.Director.BirthDate.Month;

                        int year = schoolToEdit.Director.BirthDate.Year;

                        schoolToEdit.Director.BirthDate = new DateTime(year, month, day);

                        schoolRepository.Save(schoolToEdit);

                        ChangeDirectorBirthDate(schoolToEdit, schoolRepository, id);
                    }
                    break;

                case "2":
                    Console.WriteLine("\nEnter new Month or '`' to return");

                    line = Console.ReadLine().Trim();

                    if (line == "`")
                    {
                        ChangeDirectorBirthDate(schoolToEdit, schoolRepository, id);
                        return;
                    }
                    else
                    {
                        int month;
                        while (!int.TryParse(line, out month) || !(month < 13 && month > 0))
                        {
                            Console.WriteLine("Incorrect Month!");

                            Console.WriteLine("\nEnter new Month or '`' to return");

                            line = Console.ReadLine();

                            if (line == "`")
                            {
                                ChangeDirectorBirthDate(schoolToEdit, schoolRepository, id);
                                return;
                            }
                        }
                        month = int.Parse(line);

                        int day = schoolToEdit.Director.BirthDate.Day;

                        int year = schoolToEdit.Director.BirthDate.Year;

                        schoolToEdit.Director.BirthDate = new DateTime(year, month, day);

                        schoolRepository.Save(schoolToEdit);

                        ChangeDirectorBirthDate(schoolToEdit, schoolRepository, id);
                    }
                    break;

                case "3":
                    Console.WriteLine("\nEnter new Year or '`' to return");

                    line = Console.ReadLine().Trim();

                    if (line == "`")
                    {
                        ChangeDirectorBirthDate(schoolToEdit, schoolRepository, id);
                        return;
                    }
                    else
                    {
                        int year;
                        while (!int.TryParse(line, out year) || !(year < 3000 && year > 1500))
                        {
                            Console.WriteLine("Incorrect Year!");

                            Console.WriteLine("\nEnter new Year or '`' to return");

                            line = Console.ReadLine();

                            if (line == "`")
                            {
                                ChangeDirectorBirthDate(schoolToEdit, schoolRepository, id);
                                return;
                            }
                        }
                        year = int.Parse(line);

                        int month = schoolToEdit.Director.BirthDate.Month;

                        int day = schoolToEdit.Director.BirthDate.Day;

                        schoolToEdit.Director.BirthDate = new DateTime(year, month, day);

                        schoolRepository.Save(schoolToEdit);

                        ChangeDirectorBirthDate(schoolToEdit, schoolRepository, id);
                    }
                    break;
                default:
                    if (line == "`")
                    {
                        EditSchoolDirector(schoolToEdit, schoolRepository, id);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect number!");

                        Console.WriteLine("\nClick Enter...");

                        Console.ReadLine();

                        ChangeDirectorBirthDate(schoolToEdit, schoolRepository, id);
                    }
                    break;
            }
        }

        private static void ChangeDirectorIdentityNumber(School schoolToEdit, SchoolRepository schoolRepository, int id)
        {
            Console.Clear();

            Console.WriteLine($"Current Identity Number: {schoolToEdit.Director.IdentityNumber}");

            Console.WriteLine("\nEnter new Identity Number or '`' to return:");

            string line = Console.ReadLine().Trim();

            if (line == "`")
            {
                EditSchoolDirector(schoolToEdit, schoolRepository, id);
                return;
            }
            else 
            {                 
                while (!int.TryParse(line, out _) || line.Length != 10)
                {
                    Console.WriteLine("Invalid Identity Number!");

                    Console.WriteLine("\nEnter new Identity Number or '`' to return:");

                    line = Console.ReadLine();
                    
                    if (line == "`")
                    {
                        EditSchoolDirector(schoolToEdit, schoolRepository, id);
                        return;
                    }
                }
                schoolToEdit.Director.IdentityNumber = line;

                schoolRepository.Save(schoolToEdit);

                EditSchoolDirector(schoolToEdit, schoolRepository, id);
            }
        }

        private static void ChangeDirectorGender(School schoolToEdit, SchoolRepository schoolRepository, int id)
        {
            Console.Clear();

            Console.WriteLine($"Current Gender: {schoolToEdit.Director.Gender}");

            Console.WriteLine("\nEnter Male or Female or '`' to return:");

            string line = Console.ReadLine().Trim().ToLower();

            if (line == "`")
            {
                EditSchoolDirector(schoolToEdit, schoolRepository, id);
                return;
            }
            else
            {
                switch (line)
                {
                    case "male":
                        schoolToEdit.Director.Gender = Gender.Male;

                        schoolRepository.Save(schoolToEdit);

                        EditSchoolDirector(schoolToEdit, schoolRepository, id);
                        break;

                    case "female":
                        schoolToEdit.Director.Gender = Gender.Female;

                        schoolRepository.Save(schoolToEdit);

                        EditSchoolDirector(schoolToEdit, schoolRepository, id);
                        break;

                    default:
                        Console.WriteLine("Incorrect Gender!");

                        Console.WriteLine("\nClick Enter to continue...");

                        Console.ReadLine();

                        ChangeDirectorGender(schoolToEdit, schoolRepository, id);
                        break;
                }
            }
        }

        private static void ChangeDirectorSalary(School schoolToEdit, SchoolRepository schoolRepository, int id)
        {
            Console.Clear();

            Console.WriteLine($"Current Salary: {schoolToEdit.Director.Salary}");

            Console.WriteLine("\nEnter new Salary or '`' to return:");

            string line = Console.ReadLine().Trim();

            int salary;

            if (line == "`")
            {
                EditSchoolDirector(schoolToEdit, schoolRepository, id);
                return;
            }
            else
            {
                while (!int.TryParse(line, out salary) || line == "" || salary <= 0)
                {
                    Console.WriteLine("Incorrect Salary!");

                    Console.WriteLine("\nEnter new Salary or '`' to return:");
                    line = Console.ReadLine();

                    if (line == "`")
                    {
                        EditSchoolDirector(schoolToEdit, schoolRepository, id);
                        return;
                    }
                }

                salary = int.Parse(line);

                schoolToEdit.Director.Salary = salary;

                schoolRepository.Save(schoolToEdit);

                EditSchoolDirector(schoolToEdit, schoolRepository, id);
            }
        }

        private static void ChangeDirectorPhoneNumber(School schoolToEdit, SchoolRepository schoolRepository, int id)
        {
            Console.Clear();

            Console.WriteLine($"Current Director Phone Number: {schoolToEdit.Director.PhoneNumber}");

            Console.WriteLine("\nEnter new Phone Number or '`' to return:");

            string line = Console.ReadLine().Trim();

            if (line == "`")
            {
                EditSchoolDirector(schoolToEdit, schoolRepository, id);
                return;
            }
            else
            {
                while (!int.TryParse(line, out _) || line.Length != 10)
                {
                    Console.WriteLine("Incorrect Phone Number!");

                    Console.WriteLine("\nEnter new Phone Number or '`' to return:");
                    line = Console.ReadLine();
                    if (line == "`")
                    {
                        EditSchoolDirector(schoolToEdit, schoolRepository, id);
                        return;
                    }
                }

                schoolToEdit.Director.PhoneNumber = line;

                schoolRepository.Save(schoolToEdit);

                EditSchoolDirector(schoolToEdit, schoolRepository, id);
            }
        }

        private static void ChangeDirectorName(School schoolToEdit, SchoolRepository schoolRepository, int id)
        {
            Console.Clear();

            Console.WriteLine($"Current Director's Name: {schoolToEdit.Director.FirstName} {schoolToEdit.Director.MiddleName} {schoolToEdit.Director.LastName}");

            Console.WriteLine("\nEnter new First Name:");

            string line = Console.ReadLine().Trim();
           
            while (int.TryParse(line, out _))
            {
                Console.WriteLine("Incorrect Name!");
                Console.WriteLine("\nEnter new First Name:");
                line = Console.ReadLine().Trim();
            }

            schoolToEdit.Director.FirstName = line;

            Console.WriteLine("\nEnter new Middle Name:");

            line = Console.ReadLine().Trim();
            
            while (int.TryParse(line, out _))
            {
                Console.WriteLine("Incorrect Name!");
                Console.WriteLine("\nEnter new Middle Name:");
                line = Console.ReadLine().Trim();
            }

            schoolToEdit.Director.MiddleName = line;

            Console.WriteLine("\nEnter new Last Name:");
            
            line = Console.ReadLine().Trim();
            
            while (int.TryParse(line, out _))
            {
                Console.WriteLine("Incorrect Name!");
                Console.WriteLine("\nEnter new Last Name:");
                line = Console.ReadLine().Trim();
            }

            schoolToEdit.Director.LastName = line;

            schoolRepository.Save(schoolToEdit);

            EditSchoolDirector(schoolToEdit, schoolRepository, id);
        }

        private static void EditSchoolType(School schoolToEdit, SchoolRepository schoolRepository, int id)
        {
            Console.Clear();

            Console.WriteLine($"Current School Type: {schoolToEdit.SchoolType}");
            
            Console.WriteLine("\nPrimary School, Secondary School, Middle School, High School, University" +
                "\nType new type from the above or '`' to return...");

            string line = Console.ReadLine().Trim().ToLower();

            if (line == "`")
            {
                EditSchool(schoolToEdit, schoolRepository, id);
            }
            else switch (line)
            {
                case "primary school":
                    schoolToEdit.SchoolType = SchoolType.PrimarySchool;
                    schoolRepository.Save(schoolToEdit);
                    EditSchool(schoolToEdit, schoolRepository, id);
                    break;
                case "secondary school":
                    schoolToEdit.SchoolType = SchoolType.SecondarySchool;
                    schoolRepository.Save(schoolToEdit);
                    EditSchool(schoolToEdit, schoolRepository, id);
                    break;
                case "middle school":
                    schoolToEdit.SchoolType = SchoolType.MiddleSchool;
                    schoolRepository.Save(schoolToEdit);
                    EditSchool(schoolToEdit, schoolRepository, id);
                    break;
                case "high school":
                    schoolToEdit.SchoolType = SchoolType.HighSchool;
                    schoolRepository.Save(schoolToEdit);
                    EditSchool(schoolToEdit, schoolRepository, id);
                    break;
                case "university":
                    schoolToEdit.SchoolType = SchoolType.University;
                    schoolRepository.Save(schoolToEdit);
                    EditSchool(schoolToEdit, schoolRepository, id);
                    break;
                default:
                    Console.WriteLine("Incorrect school type!");

                    Console.WriteLine("\nClick Enter to continue...");

                    Console.ReadLine();

                    EditSchoolType(schoolToEdit, schoolRepository, id);
                    break;
            }
        }

        private static void EditSchoolName(School schoolToEdit, SchoolRepository schoolRepository, int id)
        {
            Console.Clear();
            
            Console.WriteLine($"Current School Name: {schoolToEdit.Name}");

            Console.WriteLine("\nEnter new name or '`' to return");

            string line = Console.ReadLine().Trim();

            if (line == "`")
            {
                EditSchool(schoolToEdit, schoolRepository, id);
            }
            else
            {
                schoolToEdit.Name = line;
                schoolRepository.Save(schoolToEdit);
                EditSchool(schoolToEdit, schoolRepository, id);
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