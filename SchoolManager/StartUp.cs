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

            StudentClass studentClass1 = new StudentClass(ClassGrade.Eigth, GradeChar.A, students, teacher1);
            StudentClass studentClass2 = new StudentClass(ClassGrade.Forth, GradeChar.A, students, teacher1);
            StudentClass studentClass3 = new StudentClass(ClassGrade.Eigth, GradeChar.B, students, teacher1);
            StudentClass studentClass4 = new StudentClass(ClassGrade.Forth, GradeChar.E, students, teacher1);
            StudentClass studentClass5 = new StudentClass(ClassGrade.Twelfth, GradeChar.A, students, teacher1);


            List<StudentClass> studentClasses1 = new List<StudentClass>();
            studentClasses1.Add(studentClass1);
            studentClasses1.Add(studentClass2);
            studentClasses1.Add(studentClass3);
            studentClasses1.Add(studentClass4);
            studentClasses1.Add(studentClass5);


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

            Console.WriteLine("\nSelect a School Id or enter '`' to retun:");

            string line = Console.ReadLine().Trim();

            if (line == "`")
            {
                return;
            }

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
                var sortedClasses =
                                from studentClass in schoolToEdit.StudentClasses
                                orderby studentClass.Grade, studentClass.GradeChar ascending
                                select studentClass;

                int number = 0;

                foreach (StudentClass studentClass in sortedClasses)
                {
                    number++;
                    Console.WriteLine($"{number}.{studentClass.Grade} {studentClass.GradeChar} ");
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

            Console.WriteLine("\nTo edit enter component number or '`' to return:");
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
                        EditSchoolTeachers(schoolToEdit, schoolRepository, id);
                        break;
                    case "6":
                        EditSchoolClasses(schoolToEdit, schoolRepository, id);
                        break;
                    case "7":

                        break;
                    default:
                        Console.WriteLine("Incorrect component number!");

                        Console.WriteLine("Click Enter...");

                        Console.ReadLine();

                        EditSchool(schoolToEdit, schoolRepository, id);
                        return;
                }
            }
        }

        private static void EditSchoolClasses(School schoolToEdit, SchoolRepository schoolRepository, int id)
        {
            Console.Clear();

            Console.WriteLine("Current Classes:");

            schoolToEdit.StudentClasses.ToList();

            int number = 0;

            var sortedClasses =
                from studentClass in schoolToEdit.StudentClasses
                orderby studentClass.Grade, studentClass.GradeChar ascending
                select studentClass;

            foreach (StudentClass studentClass in sortedClasses)
            {
                number++;
                Console.WriteLine($"{number}.{studentClass.Grade} {studentClass.GradeChar} ");
            }
            
            if (schoolToEdit.StudentClasses.Count() != 0)
            {
                Console.WriteLine("\nAvailable operation:");

                Console.WriteLine("1.Add new Grade");

                Console.WriteLine("2.Select Grade");

                Console.WriteLine("3.Delete Grade");

                Console.WriteLine("\nEnter the number of the operation or '`' to return:");

                string line = Console.ReadLine();

                if (line == "`")
                {
                    EditSchool(schoolToEdit, schoolRepository, id);
                    return;
                }

                switch (line)
                {
                    case "1":
                        AddGrade(schoolToEdit, schoolRepository, id);
                        break;

                    case "2":
                        Console.WriteLine("\nEnter the number of the grade to select or '`' to return:");

                        string lineNew = Console.ReadLine().Trim();

                        if (lineNew == "`")
                        {
                            EditSchoolClasses(schoolToEdit, schoolRepository, id);
                            return;
                        }

                        int schoolClassNumber;

                        while (!int.TryParse(lineNew, out schoolClassNumber) || !(schoolClassNumber > 0 && schoolClassNumber <= schoolToEdit.StudentClasses.Count()))
                        {
                            Console.WriteLine("/nInvalid number!");

                            Console.WriteLine("\nEnter the number of the grade to select or '`' to return:");

                            lineNew = Console.ReadLine();

                            if (lineNew == "`")
                            {
                                EditSchoolClasses(schoolToEdit, schoolRepository, id);
                                return;
                            }
                        }

                        int schoolClassInex = schoolClassNumber - 1;

                        SelectGradeFromGrages(schoolToEdit, schoolRepository, id, schoolClassNumber);
                        
                        return;

                        break;

                    case "3":
                        break;

                    default:
                        Console.WriteLine("\nInvalid Number!");

                        Console.WriteLine("Click Enter...");

                        Console.ReadLine();

                        EditSchoolClasses(schoolToEdit, schoolRepository, id);
                        return;
                        break;
                }
            }
            else
            {
                Console.WriteLine(" ----------- Empty ------------");

                Console.WriteLine("\nAvailable operation:");

                Console.WriteLine("1.Add new Grade");

                Console.WriteLine("\nEnter the number of the operation or '`' to return:");

                string line = Console.ReadLine();

                if (line == "`")
                {
                    EditSchool(schoolToEdit, schoolRepository, id);
                    return;
                }

                switch (line)
                {
                    case "1":
                        AddGrade(schoolToEdit, schoolRepository, id);
                        break;

                    default:
                        Console.WriteLine("\nInvalid Number!");

                        Console.WriteLine("Click Enter...");

                        Console.ReadLine();

                        EditSchoolClasses(schoolToEdit, schoolRepository, id);
                        return;
                        break;
                }
            }
        }

        private static void SelectGradeFromGrages(School schoolToEdit, SchoolRepository schoolRepository, int id, int schoolClassNumber)
        {
            Console.Clear();

            Console.WriteLine($"Grade: {schoolToEdit.StudentClasses.ToList()[schoolClassNumber].Grade} {schoolToEdit.StudentClasses.ToList()[schoolClassNumber].GradeChar}");

            Console.WriteLine($"1.Main Teacher: {schoolToEdit.StudentClasses.ToList()[schoolClassNumber].MainTeacher.FirstName} {schoolToEdit.StudentClasses.ToList()[schoolClassNumber].MainTeacher.MiddleName} {schoolToEdit.StudentClasses.ToList()[schoolClassNumber].MainTeacher.LastName}");

            Console.WriteLine($"2.Students:");

            if (schoolToEdit.StudentClasses.ToList()[schoolClassNumber].Students.Count() != 0)
            {
                var sortedStudents =
                    from student in schoolToEdit.StudentClasses.ToList()[schoolClassNumber].Students.ToList()
                    orderby student.FirstName, student.MiddleName, student.LastName
                    select student;

                int number = 0;

                foreach (Student student in sortedStudents)
                {
                    number++;
                    Console.WriteLine($" {number} {student.FirstName} {student.MiddleName} {student.LastName}");
                }
            }
            else
            {
                Console.WriteLine(" ----------- Empty ------------");
            }

            Console.WriteLine("Enter the number of the component or '`' to return:");

            string line = Console.ReadLine().Trim();

            if (line == "`")
            {
                EditSchoolClasses(schoolToEdit, schoolRepository, id);
                return;
            }

            switch (line)
            {
                case "1":
                    SelectHeadTeacher(schoolToEdit, schoolRepository, id, schoolClassNumber);
                    break;
                case "2":
                    break;
                default:
                    break;
            }
        }

        private static void SelectHeadTeacher(School schoolToEdit, SchoolRepository schoolRepository, int id, int schoolClassNumber)
        {
            Console.Clear();

            Teacher teacher = schoolToEdit.StudentClasses.ToList()[schoolClassNumber].MainTeacher;

            Console.WriteLine($"=== {schoolToEdit.StudentClasses.ToList()[schoolClassNumber].Grade} {schoolToEdit.StudentClasses.ToList()[schoolClassNumber].GradeChar}'s Teacher ===");

            Console.WriteLine($" 1.{teacher.FirstName} {teacher.MiddleName} {teacher.LastName}");

            Console.WriteLine($" 2.Phone number: {teacher.PhoneNumber}");

            Console.WriteLine($" 3.Salary: {teacher.Salary}");

            Console.WriteLine($" 4.Gender: {teacher.Gender}");

            Console.WriteLine($" 5.Identity number: {teacher.IdentityNumber}");

            Console.WriteLine($" 6.Birth date: {teacher.BirthDate}");

            Console.WriteLine($" 7.Specialized Subjects:");
            foreach (Subject subject in teacher.SpecializedSubjects)
            {
                Console.WriteLine($" -{subject.Name} lessons count: {subject.LessonsCount}");
            }
            if (teacher.SpecializedSubjects.ToList().Count == 0)
            {
                Console.WriteLine(" ----------- Empty ------------");
            }

            Console.WriteLine("\nEnter the number of the component to edit or '`' to return:");

            string line = Console.ReadLine().Trim();

            if (line == "`")
            {
                SelectGradeFromGrages(schoolToEdit, schoolRepository, id, schoolClassNumber);
                return;
            }

            switch (line)
            {
                case "1":
                    ChangeHeadTeacherName(schoolToEdit, schoolRepository, id, schoolClassNumber);
                    break;

                case "2":
                  //  ChangeTeacherPhoneNumber(schoolToEdit, schoolRepository, id, index);
                    break;

                case "3":
                   // ChangeTeacherSalary(schoolToEdit, schoolRepository, id, index);
                    break;

                case "4":
                  //  ChangeTeacherGender(schoolToEdit, schoolRepository, id, index);
                    break;

                case "5":
                  //  ChangeTeacherIdentityNumber(schoolToEdit, schoolRepository, id, index);
                    break;

                case "6":
                 //   ChangeTeacherBirthDate(schoolToEdit, schoolRepository, id, index);
                    break;

                case "7":
                  //  EditSpecialisedSubjects(schoolToEdit, schoolRepository, id, index);
                    break;

                default:
                    Console.WriteLine("\nIncorrect Component Number!");

                    Console.WriteLine("Click Enter...");

                    Console.ReadLine();

                    SelectHeadTeacher(schoolToEdit, schoolRepository, id, schoolClassNumber);

                    return;
            }
        }

        private static void ChangeHeadTeacherName(School schoolToEdit, SchoolRepository schoolRepository, int id, int schoolClassNumber)
        {
            Console.Clear();

            Teacher teacher = schoolToEdit.StudentClasses.ToList()[schoolClassNumber].MainTeacher;

            Console.WriteLine($"Current Teacher's Name: {teacher.FirstName} {teacher.MiddleName} {teacher.LastName}");

            Console.WriteLine("\nEnter new First Name:");

            string line = Console.ReadLine().Trim();

            while (int.TryParse(line, out _))
            {
                Console.WriteLine("Incorrect Name!");
                Console.WriteLine("\nEnter new First Name:");
                line = Console.ReadLine().Trim();
            }

            teacher.FirstName = line;

            Console.WriteLine("\nEnter new Middle Name:");

            line = Console.ReadLine().Trim();

            while (int.TryParse(line, out _))
            {
                Console.WriteLine("Incorrect Name!");
                Console.WriteLine("\nEnter new Middle Name:");
                line = Console.ReadLine().Trim();
            }

            teacher.MiddleName = line;

            Console.WriteLine("\nEnter new Last Name:");

            line = Console.ReadLine().Trim();

            while (int.TryParse(line, out _))
            {
                Console.WriteLine("Incorrect Name!");
                Console.WriteLine("\nEnter new Last Name:");
                line = Console.ReadLine().Trim();
            }

            teacher.LastName = line;

            schoolToEdit.StudentClasses.ToList()[schoolClassNumber].MainTeacher = teacher;

            schoolRepository.Save(schoolToEdit);

            SelectHeadTeacher(schoolToEdit, schoolRepository, id, schoolClassNumber);
            return;
        }

        private static void AddGrade(School schoolToEdit, SchoolRepository schoolRepository, int id)
        {
            Console.Clear();

            ClassGrade classGrade = SelectGrade();

            GradeChar gradeChar = SelectGradeChar();

            List<Student> students = new List<Student>();

            StudentClass studentClass = new StudentClass(classGrade, gradeChar, students, null);

            List<StudentClass> studentClasses = schoolToEdit.StudentClasses.ToList();

            studentClasses.Add(studentClass);

            schoolToEdit.StudentClasses = studentClasses;

            schoolRepository.Save(schoolToEdit);

            EditSchoolClasses(schoolToEdit, schoolRepository, id);
            return;
        }

        private static GradeChar SelectGradeChar()
        {
            Console.WriteLine("Enter the Grade:");

            Console.WriteLine("A, B, V, G, D, E, J, Z");

            GradeChar gradeChar = GradeChar.A;

            string line = Console.ReadLine().Trim().ToLower();

            bool loop = true;

            while (loop)
            {
                switch (line)
                {
                    case "a":
                        gradeChar = GradeChar.A;
                        loop = false;
                        break;

                    case "b":
                        gradeChar = GradeChar.B;
                        loop = false;
                        break;

                    case "v":
                        gradeChar = GradeChar.V;
                        loop = false;
                        break
                            ;
                    case "g":
                        gradeChar = GradeChar.G;
                        loop = false;
                        break;

                    case "d":
                        gradeChar = GradeChar.D;
                        loop = false;
                        break;

                    case "e":
                        gradeChar = GradeChar.E;
                        loop = false;
                        break;

                    case "j":
                        gradeChar = GradeChar.J;
                        loop = false;
                        break;

                    case "z":
                        gradeChar = GradeChar.Z;
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("\nInvalid Grade!");

                        Console.WriteLine("\nEnter the Grade:");

                        Console.WriteLine("A, B, V, G, D, E, J, Z");

                        line = Console.ReadLine().Trim().ToLower();
                        break;
                }
            }
            return gradeChar;
        }

        private static ClassGrade SelectGrade()
        {
            Console.WriteLine("Enter the Grade:");
            Console.WriteLine("First, Second, Third,\nForth, Fifth, Sixth,\nSeventh, Eigth, Ninth,\nTenth, Eleven, Twelfth");

            string line = Console.ReadLine().Trim().ToLower();

            ClassGrade classGrade = ClassGrade.First;

            bool loop = true;

            while (loop)
            {
                switch (line)
                {
                    case "first":
                        classGrade = ClassGrade.First;
                        loop = false;
                        break;

                    case "second":
                        classGrade = ClassGrade.Second;
                        loop = false;
                        break;
                    case "third":
                        classGrade = ClassGrade.Third;
                        loop = false;
                        break;

                    case "forth":
                        classGrade = ClassGrade.Forth;
                        loop = false;
                        break;

                    case "fifth":
                        classGrade = ClassGrade.Fifth;
                        loop = false;
                        break;

                    case "sixth":
                        classGrade = ClassGrade.Sixth;
                        loop = false;
                        break;

                    case "seventh":
                        classGrade = ClassGrade.Seventh;
                        loop = false;
                        break;

                    case "eigth":
                        classGrade = ClassGrade.Eigth;
                        loop = false;
                        break;

                    case "ninth":
                        classGrade = ClassGrade.Ninth;
                        loop = false;
                        break;

                    case "tenth":
                        classGrade = ClassGrade.Tenth;
                        loop = false;
                        break;

                    case "eleven":
                        classGrade = ClassGrade.Eleven;
                        loop = false;
                        break;

                    case "twelfth":
                        classGrade = ClassGrade.Twelfth;
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("\nInvalid Grade!");

                        Console.WriteLine("\nEnter the Grade:");

                        Console.WriteLine("First, Second, Third,\nForth, Fifth, Sixth,\nSeventh, Eigth, Ninth,\nTenth, Eleven, Twelfth");

                        line = Console.ReadLine().Trim().ToLower();
                        break;
                }
            }
            return classGrade;
        }

        private static void EditSchoolTeachers(School schoolToEdit, SchoolRepository schoolRepository, int id)
        {
            Console.Clear();

            Console.WriteLine("Current Teachers:");

            if (schoolToEdit.TeachersStaff.Count() != 0)
            {
                int count = 0;
                foreach (Teacher teacher in schoolToEdit.TeachersStaff)
                {
                    count++;
                    Console.WriteLine($"{count} - {teacher}");
                }

                Console.WriteLine("\n=== Available operation ===");
                Console.WriteLine("  1.Add new Teacher");
                Console.WriteLine("  2.Select Teacher");
                Console.WriteLine("  3.Delete Teacher");

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
                        AddTeacher(schoolToEdit, schoolRepository, id);
                        break;

                    case "2":
                        Console.WriteLine("\nEnter Teacher Number or '`' to return:");

                        string newLine = Console.ReadLine().Trim();

                        if (newLine == "`")
                        {
                            EditSchoolTeachers(schoolToEdit, schoolRepository, id);
                            return;
                        }

                        int number;

                        while (!int.TryParse(newLine, out number) || !(number > 0 && number <= schoolToEdit.TeachersStaff.Count()))
                        {
                            Console.WriteLine("Incorrect Teacher Number!");

                            Console.WriteLine("\nEnter Teacher Number or '`' to return:");

                            newLine = Console.ReadLine().Trim();

                            if (newLine == "`")
                            {
                                EditSchoolTeachers(schoolToEdit, schoolRepository, id);
                                return;
                            }
                        }

                        number = int.Parse(newLine);

                        int index = number - 1;

                        SelectTeacherFromStaff(schoolToEdit, schoolRepository, id, index);
                        return;
                        break;

                    case "3":
                        Console.WriteLine("\nEnter Teacher Number or '`' to return:");

                        newLine = Console.ReadLine().Trim();

                        if (newLine == "`")
                        {
                            EditSchoolTeachers(schoolToEdit, schoolRepository, id);
                            return;
                        }

                        while (!int.TryParse(newLine, out number) || !(number > 0 && number <= schoolToEdit.TeachersStaff.Count()))
                        {
                            Console.WriteLine("Incorrect Teacher Number!");

                            Console.WriteLine("\nEnter Teacher Number or '`' to return");

                            newLine = Console.ReadLine().Trim();

                            if (newLine == "`")
                            {
                                EditSchoolTeachers(schoolToEdit, schoolRepository, id);
                                return;
                            }

                        }

                        number = int.Parse(newLine);

                        index = number - 1;

                        DeleteTeacher(schoolToEdit, schoolRepository, id, index);
                        break;

                    default:
                        Console.WriteLine("\nIncorrect Number!");

                        Console.WriteLine("Click Enter...");

                        Console.ReadLine();

                        EditSchoolTeachers(schoolToEdit, schoolRepository, id);
                        return;
                }
            }
            else
            {
                Console.WriteLine(" ----------- Empty ------------");

                Console.WriteLine("\n=== Available operation ===");
                Console.WriteLine("  1.Add new Teacher");

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
                        AddTeacher(schoolToEdit, schoolRepository, id);
                        break;

                    default:
                        Console.WriteLine("Incorrect Number!");
                        Console.WriteLine("Click Enter...");
                        Console.ReadLine();
                        EditSchoolTeachers(schoolToEdit, schoolRepository, id);
                        return;
                }
            }
        }

        private static void DeleteTeacher(School schoolToEdit, SchoolRepository schoolRepository, int id, int index)
        {
            List<Teacher> teachers = schoolToEdit.TeachersStaff.ToList();

            teachers.RemoveAt(index);

            schoolToEdit.TeachersStaff = teachers;

            schoolRepository.Save(schoolToEdit);

            EditSchoolTeachers(schoolToEdit, schoolRepository, id);
            return;
        }

        private static void SelectTeacherFromStaff(School schoolToEdit, SchoolRepository schoolRepository, int id, int index)
        {
            Console.Clear();

            Teacher teacher = schoolToEdit.TeachersStaff.ToList()[index];

            Console.WriteLine($"=== {schoolToEdit.Name}'s Teacher ===");

            Console.WriteLine($" 1.{teacher.FirstName} {teacher.MiddleName} {teacher.LastName}");

            Console.WriteLine($" 2.Phone number: {teacher.PhoneNumber}");

            Console.WriteLine($" 3.Salary: {teacher.Salary}");

            Console.WriteLine($" 4.Gender: {teacher.Gender}");

            Console.WriteLine($" 5.Identity number: {teacher.IdentityNumber}");

            Console.WriteLine($" 6.Birth date: {teacher.BirthDate}");

            Console.WriteLine($" 7.Specialized Subjects:");
            foreach (Subject subject in teacher.SpecializedSubjects)
            {
                Console.WriteLine($" -{subject.Name} lessons count: {subject.LessonsCount}");
            }
            if (teacher.SpecializedSubjects.ToList().Count == 0)
            {
                Console.WriteLine(" ----------- Empty ------------");
            }

            Console.WriteLine("\nEnter the number of the component to edit or '`' to return:");

            string line = Console.ReadLine().Trim();

            if (line == "`")
            {
                EditSchoolTeachers(schoolToEdit, schoolRepository, id);
                return;
            }

            switch (line)
            {
                case "1":
                    ChangeTeacherName(schoolToEdit, schoolRepository, id, index);
                    break;

                case "2":
                    ChangeTeacherPhoneNumber(schoolToEdit, schoolRepository, id, index);
                    break;

                case "3":
                    ChangeTeacherSalary(schoolToEdit, schoolRepository, id, index);
                    break;

                case "4":
                    ChangeTeacherGender(schoolToEdit, schoolRepository, id, index);
                    break;

                case "5":
                    ChangeTeacherIdentityNumber(schoolToEdit, schoolRepository, id, index);
                    break;

                case "6":
                    ChangeTeacherBirthDate(schoolToEdit, schoolRepository, id, index);
                    break;

                case "7":
                    EditSpecialisedSubjects(schoolToEdit, schoolRepository, id, index);
                    break;

                default:
                    Console.WriteLine("\nIncorrect Component Number!");

                    Console.WriteLine("Click Enter...");

                    Console.ReadLine();

                    SelectTeacherFromStaff(schoolToEdit, schoolRepository, id, index);

                    return;
            }
        }

        private static void EditSpecialisedSubjects(School schoolToEdit, SchoolRepository schoolRepository, int id, int index)
        {
            Console.Clear();

            Console.WriteLine($"== {schoolToEdit.TeachersStaff.ToList()[index].FirstName} {schoolToEdit.TeachersStaff.ToList()[index].MiddleName} {schoolToEdit.TeachersStaff.ToList()[index].LastName}'s Subjects ==");

            int subjectIndex = 0;
            foreach (Subject subject in schoolToEdit.TeachersStaff.ToList()[index].SpecializedSubjects)
            {
                subjectIndex++;
                Console.WriteLine($"  {subjectIndex}. {subject.Name}, lessons count: {subject.LessonsCount}");
            }

            if (schoolToEdit.TeachersStaff.ToList()[index].SpecializedSubjects.ToList().Count == 0)
            {
                Console.WriteLine(" ----------- Empty ------------");
            }

            if (schoolToEdit.TeachersStaff.ToList()[index].SpecializedSubjects.Count() != 0)
            {
                Console.WriteLine("\n== Available operations ==");

                Console.WriteLine(" 1.Add new Subject");

                Console.WriteLine(" 2.Edit Subject");

                Console.WriteLine(" 3.Delete Subject");

                Console.WriteLine("\nEnter a number of the operation or '`' to return");

                string line = Console.ReadLine().Trim();

                if (line == "`")
                {
                    SelectTeacherFromStaff(schoolToEdit, schoolRepository, id, index);
                    return;
                }

                switch (line)
                {
                    case "1":
                        AddSubject(schoolToEdit, schoolRepository, id, index);
                        break;
                    case "2":
                        Console.WriteLine("\nEnter Subject Number or '`' to return:");

                        string newLine = Console.ReadLine().Trim();

                        if (newLine == "`")
                        {
                            EditSpecialisedSubjects(schoolToEdit, schoolRepository, id, index);
                            return;
                        }

                        int number;

                        while (!int.TryParse(newLine, out number) || !(number > 0 && number <= schoolToEdit.ViseDirectors.ToList()[index].SpecializedSubjects.Count()))
                        {
                            Console.WriteLine("Incorrect Subject Number!");

                            Console.WriteLine("\nEnter Subject Number or '`' to return:");

                            newLine = Console.ReadLine().Trim();

                            if (newLine == "`")
                            {
                                EditSpecialisedSubjects(schoolToEdit, schoolRepository, id, index);
                                return;
                            }
                        }

                        number = int.Parse(newLine);

                        int indexSubject = number - 1;

                        SelectSubjectSpecialised(schoolToEdit, schoolRepository, id, index, indexSubject);
                        break;
                    case "3":
                        Console.WriteLine("\nEnter Subject Number or '`' to return:");

                        string newLine1 = Console.ReadLine().Trim();

                        if (newLine1 == "`")
                        {
                            EditSpecialisedSubjects(schoolToEdit, schoolRepository, id, index);
                            return;
                        }

                        int number1;

                        while (!int.TryParse(newLine1, out number1) || !(number1 > 0 && number1 <= schoolToEdit.ViseDirectors.ToList()[index].SpecializedSubjects.Count()))
                        {
                            Console.WriteLine("Incorrect Subject Number!");

                            Console.WriteLine("\nEnter Subject Number or '`' to return:");

                            newLine1 = Console.ReadLine().Trim();

                            if (newLine1 == "`")
                            {
                                EditSpecialisedSubjects(schoolToEdit, schoolRepository, id, index);
                                return;
                            }
                        }

                        number1 = int.Parse(newLine1);

                        int indexSubjectRemove = number1 - 1;

                        RemoveSubject(schoolToEdit, schoolRepository, id, index, indexSubjectRemove);
                        break;
                    default:
                        Console.WriteLine("\nIncorrect Number of operation!");
                        Console.WriteLine("Click Enter...");
                        Console.ReadLine();
                        EditSpecialisedSubjects(schoolToEdit, schoolRepository, id, index);
                        return;
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n== Available operations ==");

                Console.WriteLine(" 1.Add new Subject");

                Console.WriteLine("\nEnter a number of the operation or '`' to return");

                string line = Console.ReadLine().Trim();

                if (line == "`")
                {
                    SelectTeacherFromStaff(schoolToEdit, schoolRepository, id, index);
                    return;
                }

                switch (line)
                {
                    case "1":
                        AddSubject(schoolToEdit, schoolRepository, id, index);
                        return;
                        break;
                    default:
                        Console.WriteLine("\nIncorrect Number of operation!");
                        Console.WriteLine("Click Enter...");
                        Console.ReadLine();
                        EditSpecialisedSubjects(schoolToEdit, schoolRepository, id, index);
                        return;
                        break;
                }
            }
        }

        private static void RemoveSubject(School schoolToEdit, SchoolRepository schoolRepository, int id, int index, int indexSubjectRemove)
        {
            List<Subject> subjects = schoolToEdit.TeachersStaff.ToList()[index].SpecializedSubjects.ToList();

            subjects.RemoveAt(indexSubjectRemove);

            schoolToEdit.TeachersStaff.ToList()[index].SpecializedSubjects = subjects;

            schoolRepository.Save(schoolToEdit);

            EditSpecialisedSubjects(schoolToEdit, schoolRepository, id, index);
            return;
        }

        private static void SelectSubjectSpecialised(School schoolToEdit, SchoolRepository schoolRepository, int id, int index, int indexSubject)
        {
            Console.Clear();

            Console.WriteLine($"1.Name: {schoolToEdit.TeachersStaff.ToList()[index].SpecializedSubjects.ToList()[indexSubject].Name}");
            
            Console.WriteLine($"2.Lessons Count: {schoolToEdit.TeachersStaff.ToList()[index].SpecializedSubjects.ToList()[indexSubject].LessonsCount}");

            Console.WriteLine("\nEnter the number of the component to edit or '`' to return:");

            string line = Console.ReadLine().Trim();

            if (line == "`")
            {
                EditSpecialisedSubjects(schoolToEdit, schoolRepository, id, index);
                return;
            }

            switch (line)
            {
                case "1":
                    ChangeSubjectName(schoolToEdit, schoolRepository, id, index, indexSubject);
                    break;
                case "2":
                    ChangeSubjectLessonsCount(schoolToEdit, schoolRepository, id, index, indexSubject);
                    break;
                
                default:
                    Console.WriteLine("\nInvalid Number!");

                    Console.WriteLine("Click Enter...");

                    Console.ReadLine();

                    SelectSubjectSpecialised(schoolToEdit, schoolRepository, id, index, indexSubject);
                    return;
                    break;
            }
        }

        private static void ChangeSubjectLessonsCount(School schoolToEdit, SchoolRepository schoolRepository, int id, int index, int indexSubject)
        {
            Console.WriteLine("\nEnter a new Count for the Lesson from 0 to 100 or '`' to return:");

            string line = Console.ReadLine().Trim();

            if (line == "`")
            {
                SelectSubjectSpecialised(schoolToEdit, schoolRepository, id, index, indexSubject);
                return;
            }

            int lessonCount;

            while (!int.TryParse(line, out lessonCount) || !(lessonCount >= 0 && lessonCount <= 100))
            {
                Console.WriteLine("\nInvalid Count for the Lessons!");
                
                Console.WriteLine("Enter a new Count for the Lesson from 0 to 100 or '`' to return:");
                
                line = Console.ReadLine().Trim();

                if (line == "`")
                {
                    SelectSubjectSpecialised(schoolToEdit, schoolRepository, id, index, indexSubject);
                    return;
                }
            }

            lessonCount = int.Parse(line);

            schoolToEdit.TeachersStaff.ToList()[index].SpecializedSubjects.ToList()[indexSubject].LessonsCount = lessonCount;

            schoolRepository.Save(schoolToEdit);

            SelectSubjectSpecialised(schoolToEdit, schoolRepository, id, index, indexSubject);
            return;
        }

        private static void ChangeSubjectName(School schoolToEdit, SchoolRepository schoolRepository, int id, int index, int indexSubject)
        {
            Console.WriteLine("\nEnter a new Name or '`' to return:");

            string line = Console.ReadLine().Trim();

            if (line == "`")
            {
                SelectSubjectSpecialised(schoolToEdit, schoolRepository, id, index, indexSubject);
                return;
            }

            schoolToEdit.TeachersStaff.ToList()[index].SpecializedSubjects.ToList()[indexSubject].Name = line;

            schoolRepository.Save(schoolToEdit);

            SelectSubjectSpecialised(schoolToEdit, schoolRepository, id, index, indexSubject);
            return;
        }

        private static void AddSubject(School schoolToEdit, SchoolRepository schoolRepository, int id, int index)
        {
            Console.Clear();

            Console.WriteLine("Create new Subject:");

            Subject subject = SelectSubject();

            List<Subject> subjects = schoolToEdit.TeachersStaff.ToList()[index].SpecializedSubjects.ToList();

            subjects.Add(subject);

            schoolToEdit.TeachersStaff.ToList()[index].SpecializedSubjects = subjects;

            schoolRepository.Save(schoolToEdit);

            EditSpecialisedSubjects(schoolToEdit, schoolRepository, id, index);
            return;
        }

        private static void ChangeTeacherBirthDate(School schoolToEdit, SchoolRepository schoolRepository, int id, int index)
        {
            Console.Clear();

            Console.WriteLine($"Current Birth Date: {schoolToEdit.TeachersStaff.ToList()[index].BirthDate.Date}");

            Console.WriteLine($" 1.Day {schoolToEdit.TeachersStaff.ToList()[index].BirthDate.Day}");

            Console.WriteLine($" 2.Month {schoolToEdit.TeachersStaff.ToList()[index].BirthDate.Month}");

            Console.WriteLine($" 3.Year {schoolToEdit.TeachersStaff.ToList()[index].BirthDate.Year}");


            Console.WriteLine("To edit component select the number of the component:");

            Console.WriteLine("\nEnter number or '`' to return:");

            string line = Console.ReadLine().Trim();

            if (line == "`")
            {
                SelectTeacherFromStaff(schoolToEdit, schoolRepository, id, index);
                return;
            }

            switch (line)
            {
                case "1":
                    Console.WriteLine("\nEnter new Day or '`' to return");

                    line = Console.ReadLine().Trim();

                    if (line == "`")
                    {
                        ChangeTeacherBirthDate(schoolToEdit, schoolRepository, id, index);
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
                                ChangeTeacherBirthDate(schoolToEdit, schoolRepository, id, index);
                                return;
                            }
                        }
                        day = int.Parse(line);

                        int month = schoolToEdit.TeachersStaff.ToList()[index].BirthDate.Month;

                        int year = schoolToEdit.TeachersStaff.ToList()[index].BirthDate.Year;

                        schoolToEdit.TeachersStaff.ToList()[index].BirthDate = new DateTime(year, month, day);

                        schoolRepository.Save(schoolToEdit);

                        ChangeTeacherBirthDate(schoolToEdit, schoolRepository, id, index);
                        return;
                    }
                    break;

                case "2":
                    Console.WriteLine("\nEnter new Month or '`' to return");

                    line = Console.ReadLine().Trim();

                    if (line == "`")
                    {
                        ChangeTeacherBirthDate(schoolToEdit, schoolRepository, id, index);
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
                                ChangeTeacherBirthDate(schoolToEdit, schoolRepository, id, index);
                                return;
                            }
                        }
                        month = int.Parse(line);

                        int day = schoolToEdit.TeachersStaff.ToList()[index].BirthDate.Day;

                        int year = schoolToEdit.TeachersStaff.ToList()[index].BirthDate.Year;

                        schoolToEdit.TeachersStaff.ToList()[index].BirthDate = new DateTime(year, month, day);

                        schoolRepository.Save(schoolToEdit);

                        ChangeTeacherBirthDate(schoolToEdit, schoolRepository, id, index);
                        return;
                    }
                    break;

                case "3":
                    Console.WriteLine("\nEnter new Year or '`' to return");

                    line = Console.ReadLine().Trim();

                    if (line == "`")
                    {
                        ChangeTeacherBirthDate(schoolToEdit, schoolRepository, id, index);
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
                                ChangeTeacherBirthDate(schoolToEdit, schoolRepository, id, index);
                                return;
                            }
                        }
                        year = int.Parse(line);

                        int month = schoolToEdit.TeachersStaff.ToList()[index].BirthDate.Month;

                        int day = schoolToEdit.TeachersStaff.ToList()[index].BirthDate.Day;

                        schoolToEdit.ViseDirectors.ToList()[index].BirthDate = new DateTime(year, month, day);

                        schoolRepository.Save(schoolToEdit);

                        ChangeTeacherBirthDate(schoolToEdit, schoolRepository, id, index);
                        return;
                    }
                    break;
                default:
                    if (line == "`")
                    {
                        SelectTeacherFromStaff(schoolToEdit, schoolRepository, id, index);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect number!");

                        Console.WriteLine("\nClick Enter...");

                        Console.ReadLine();

                        ChangeTeacherBirthDate(schoolToEdit, schoolRepository, id, index);
                        return;
                    }
                    break;
            }
        }

        private static void ChangeTeacherIdentityNumber(School schoolToEdit, SchoolRepository schoolRepository, int id, int index)
        {
            Console.Clear();

            Console.WriteLine($"Current Identity Number: {schoolToEdit.TeachersStaff.ToList()[index].IdentityNumber}");

            Console.WriteLine("\nEnter new Identity Number or '`' to return:");

            string line = Console.ReadLine().Trim();

            if (line == "`")
            {
                SelectTeacherFromStaff(schoolToEdit, schoolRepository, id, index);
                return;
            }
            else
            {
                while (!int.TryParse(line, out int number) || line.Length != 10)
                {
                    Console.WriteLine("Invalid Identity Number!");

                    Console.WriteLine("\nEnter new Identity Number or '`' to return:");

                    line = Console.ReadLine();

                    if (line == "`")
                    {
                        SelectTeacherFromStaff(schoolToEdit, schoolRepository, id, index);
                        return;
                    }
                }
                schoolToEdit.TeachersStaff.ToList()[index].IdentityNumber = line;

                schoolRepository.Save(schoolToEdit);

                SelectTeacherFromStaff(schoolToEdit, schoolRepository, id, index);
                return;
            }
        }

        private static void ChangeTeacherGender(School schoolToEdit, SchoolRepository schoolRepository, int id, int index)
        {
            Console.Clear();

            Console.WriteLine($"Current Gender: {schoolToEdit.TeachersStaff.ToList()[index].Gender}");

            Console.WriteLine("\nEnter Male or Female or '`' to return:");

            string line = Console.ReadLine().Trim().ToLower();

            if (line == "`")
            {
                SelectTeacherFromStaff(schoolToEdit, schoolRepository, id, index);
                return;
            }
            else
            {
                switch (line)
                {
                    case "male":
                        schoolToEdit.TeachersStaff.ToList()[index].Gender = Gender.Male;

                        schoolRepository.Save(schoolToEdit);

                        SelectTeacherFromStaff(schoolToEdit, schoolRepository, id, index);
                        return;
                        break;

                    case "female":
                        schoolToEdit.TeachersStaff.ToList()[index].Gender = Gender.Female;

                        schoolRepository.Save(schoolToEdit);

                        SelectTeacherFromStaff(schoolToEdit, schoolRepository, id, index);
                        return;
                        break;

                    default:
                        Console.WriteLine("Incorrect Gender!");

                        Console.WriteLine("\nClick Enter to continue...");

                        Console.ReadLine();

                        ChangeTeacherGender(schoolToEdit, schoolRepository, id, index);
                        return;
                }
            }
        }

        private static void ChangeTeacherSalary(School schoolToEdit, SchoolRepository schoolRepository, int id, int index)
        {
            Console.Clear();

            Console.WriteLine($"Current Salary: {schoolToEdit.TeachersStaff.ToList()[index].Salary}");

            Console.WriteLine("\nEnter new Salary or '`' to return:");

            string line = Console.ReadLine().Trim();

            int salary;

            if (line == "`")
            {
                SelectTeacherFromStaff(schoolToEdit, schoolRepository, id, index);
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
                        SelectTeacherFromStaff(schoolToEdit, schoolRepository, id, index);
                        return;
                    }
                }

                salary = int.Parse(line);

                schoolToEdit.TeachersStaff.ToList()[index].Salary = salary;

                schoolRepository.Save(schoolToEdit);

                SelectTeacherFromStaff(schoolToEdit, schoolRepository, id, index);
                return;
            }
        }

        private static void ChangeTeacherPhoneNumber(School schoolToEdit, SchoolRepository schoolRepository, int id, int index)
        {
            Console.Clear();

            Console.WriteLine($"Current Teacher Phone Number: {schoolToEdit.TeachersStaff.ToList()[index].PhoneNumber}");

            Console.WriteLine("\nEnter new Phone Number or '`' to return:");

            string line = Console.ReadLine().Trim();

            if (line == "`")
            {
                SelectTeacherFromStaff(schoolToEdit, schoolRepository, id, index);
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
                        SelectTeacherFromStaff(schoolToEdit, schoolRepository, id, index);
                        return;
                    }
                }

                schoolToEdit.TeachersStaff.ToList()[index].PhoneNumber = line;

                schoolRepository.Save(schoolToEdit);

                SelectTeacherFromStaff(schoolToEdit, schoolRepository, id, index);
            }
        }

        private static void ChangeTeacherName(School schoolToEdit, SchoolRepository schoolRepository, int id, int index)
        {
            Console.Clear();

            Console.WriteLine($"Current Teacher's Name: {schoolToEdit.TeachersStaff.ToList()[index].FirstName} {schoolToEdit.TeachersStaff.ToList()[index].MiddleName} {schoolToEdit.TeachersStaff.ToList()[index].LastName}");

            Console.WriteLine("\nEnter new First Name:");

            string line = Console.ReadLine().Trim();

            while (int.TryParse(line, out _))
            {
                Console.WriteLine("Incorrect Name!");
                Console.WriteLine("\nEnter new First Name:");
                line = Console.ReadLine().Trim();
            }

            schoolToEdit.TeachersStaff.ToList()[index].FirstName = line;

            Console.WriteLine("\nEnter new Middle Name:");

            line = Console.ReadLine().Trim();

            while (int.TryParse(line, out _))
            {
                Console.WriteLine("Incorrect Name!");
                Console.WriteLine("\nEnter new Middle Name:");
                line = Console.ReadLine().Trim();
            }

            schoolToEdit.TeachersStaff.ToList()[index].MiddleName = line;

            Console.WriteLine("\nEnter new Last Name:");

            line = Console.ReadLine().Trim();

            while (int.TryParse(line, out _))
            {
                Console.WriteLine("Incorrect Name!");
                Console.WriteLine("\nEnter new Last Name:");
                line = Console.ReadLine().Trim();
            }

            schoolToEdit.TeachersStaff.ToList()[index].LastName = line;

            schoolRepository.Save(schoolToEdit);

            SelectTeacherFromStaff(schoolToEdit, schoolRepository, id, index);
            return;
        }

        private static void AddTeacher(School schoolToEdit, SchoolRepository schoolRepository, int id)
        {
            Console.Clear();

            Console.WriteLine("Create new Teacher:");

            Teacher teacher = SelectTeacher();

            List<Teacher> teachers = schoolToEdit.TeachersStaff.ToList();

            teachers.Add(teacher);

            schoolToEdit.TeachersStaff = teachers;

            schoolRepository.Save(schoolToEdit);

            EditSchoolTeachers(schoolToEdit, schoolRepository, id);

            return;
        }

        private static void EditSchoolViseDirectors(School schoolToEdit, SchoolRepository schoolRepository, int id)
        {
            Console.Clear();

            Console.WriteLine("Current Vise Directors:");

            if (schoolToEdit.ViseDirectors.Count() != 0)
            {
                int count = 0;
                foreach (Teacher viseDirector in schoolToEdit.ViseDirectors)
                {
                    count++;
                    Console.WriteLine($"{count} - {viseDirector}");
                }

                Console.WriteLine("\n=== Available operation ===");
                Console.WriteLine("  1.Add new Vise Director");
                Console.WriteLine("  2.Select Vise Director");
                Console.WriteLine("  3.Delete Vise Director");

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
                        Console.WriteLine("\nEnter Vise Director Number or '`' to return:");

                        string newLine = Console.ReadLine().Trim();
                        
                        if (newLine == "`")
                        {
                            EditSchoolViseDirectors(schoolToEdit, schoolRepository, id);
                            return;
                        }

                        int number;

                        while (!int.TryParse(newLine, out number) || !(number > 0 && number <= schoolToEdit.ViseDirectors.Count()))
                        {
                            Console.WriteLine("Incorrect Vise Director Number!");

                            Console.WriteLine("\nEnter Vise Director Number or '`' to return:");

                            newLine = Console.ReadLine().Trim();

                            if (newLine == "`")
                            {
                                EditSchoolViseDirectors(schoolToEdit, schoolRepository, id);
                                return;
                            }
                        }

                        number = int.Parse(newLine);

                        int index = number - 1;

                        SelectViseDirector(schoolToEdit, schoolRepository, id, index);
                        break;

                    case "3":
                        Console.WriteLine("\nEnter Vise Director Number or '`' to return:");

                        newLine = Console.ReadLine().Trim();

                        if (newLine == "`")
                        {
                            EditSchoolViseDirectors(schoolToEdit, schoolRepository, id);
                            return;
                        }

                        while (!int.TryParse(newLine, out number) || !(number > 0 && number <= schoolToEdit.ViseDirectors.Count()))
                        {
                            Console.WriteLine("Incorrect Vise Director Number!");

                            Console.WriteLine("\nEnter Vise Director Number or '`' to return");

                            newLine = Console.ReadLine().Trim();

                            if (newLine == "`")
                            {
                                EditSchoolViseDirectors(schoolToEdit, schoolRepository, id);
                                return;
                            }

                        }

                        number = int.Parse(newLine);

                        index = number - 1;

                        DeleteViseDirector(schoolToEdit, schoolRepository, id, index);
                        break;
                    
                    default:
                        Console.WriteLine("\nIncorrect Number!");

                        Console.WriteLine("Click Enter...");

                        Console.ReadLine();

                        EditSchoolViseDirectors(schoolToEdit, schoolRepository, id);
                        return;
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
                }
            }
        }

        private static void DeleteViseDirector(School schoolToEdit, SchoolRepository schoolRepository, int id, int index)
        {
            List<Teacher> viseDirectors = schoolToEdit.ViseDirectors.ToList();

            viseDirectors.RemoveAt(index);

            schoolToEdit.ViseDirectors = viseDirectors;

            schoolRepository.Save(schoolToEdit);

            EditSchoolViseDirectors(schoolToEdit, schoolRepository, id);
            return;
        }

        private static void SelectViseDirector(School schoolToEdit, SchoolRepository schoolRepository, int id, int index)
        {
            Console.Clear();

            Teacher viseDirector = schoolToEdit.ViseDirectors.ToList()[index];

            Console.WriteLine($"=== {schoolToEdit.Name}'s Vise Director ===");

            Console.WriteLine($" 1.{viseDirector.FirstName} {viseDirector.MiddleName} {viseDirector.LastName}");

            Console.WriteLine($" 2.Phone number: {viseDirector.PhoneNumber}");

            Console.WriteLine($" 3.Salary: {viseDirector.Salary}");

            Console.WriteLine($" 4.Gender: {viseDirector.Gender}");

            Console.WriteLine($" 5.Identity number: {viseDirector.IdentityNumber}");

            Console.WriteLine($" 6.Birth date: {viseDirector.BirthDate}");

            Console.WriteLine("\nEnter the number of the component to edit or '`' to return:");

            string line = Console.ReadLine();

            if (line == "`")
            {
                EditSchoolViseDirectors(schoolToEdit, schoolRepository, id);
                return;
            }

            switch (line)
            {
                case "1":
                    ChangeViseDirectorName(schoolToEdit, schoolRepository, id, index);
                    break;

                case "2":
                    ChangeViseDirectorPhoneNumber(schoolToEdit, schoolRepository, id, index);
                    break;

                case "3":
                    ChangeViseDirectorSalary(schoolToEdit, schoolRepository, id, index);
                    break;

                case "4":
                    ChangeViseDirectorGender(schoolToEdit, schoolRepository, id, index);
                    break;

                case "5":
                    ChangeViseDirectorIdentityNumber(schoolToEdit, schoolRepository, id, index);
                    break;

                case "6":
                    ChangeViseDirectorBirthDate(schoolToEdit, schoolRepository, id, index);
                    break;
        
                default:
                    Console.WriteLine("\nIncorrect Component Number!");

                    Console.WriteLine("Click Enter...");

                    Console.ReadLine();

                    SelectViseDirector(schoolToEdit, schoolRepository, id, index);

                    return;
            }
        }

        private static void ChangeViseDirectorBirthDate(School schoolToEdit, SchoolRepository schoolRepository, int id, int index)
        {
            Console.Clear();

            Console.WriteLine($"Current Birth Date: {schoolToEdit.ViseDirectors.ToList()[index].BirthDate.Date}");

            Console.WriteLine($" 1.Day {schoolToEdit.ViseDirectors.ToList()[index].BirthDate.Day}");

            Console.WriteLine($" 2.Month {schoolToEdit.ViseDirectors.ToList()[index].BirthDate.Month}");

            Console.WriteLine($" 3.Year {schoolToEdit.ViseDirectors.ToList()[index].BirthDate.Year}");


            Console.WriteLine("To edit component select the number of the component:");

            Console.WriteLine("\nEnter number or '`' to return:");

            string line = Console.ReadLine().Trim();

            if (line == "`")
            {
                SelectViseDirector(schoolToEdit, schoolRepository, id, index);
                return;
            }

            switch (line)
            {
                case "1":
                    Console.WriteLine("\nEnter new Day or '`' to return");

                    line = Console.ReadLine().Trim();

                    if (line == "`")
                    {
                        ChangeViseDirectorBirthDate(schoolToEdit, schoolRepository, id, index);
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
                                ChangeViseDirectorBirthDate(schoolToEdit, schoolRepository, id, index);
                                return;
                            }
                        }
                        day = int.Parse(line);

                        int month = schoolToEdit.ViseDirectors.ToList()[index].BirthDate.Month;

                        int year = schoolToEdit.ViseDirectors.ToList()[index].BirthDate.Year;

                        schoolToEdit.ViseDirectors.ToList()[index].BirthDate = new DateTime(year, month, day);

                        schoolRepository.Save(schoolToEdit);

                        ChangeViseDirectorBirthDate(schoolToEdit, schoolRepository, id, index);
                        return;
                    }
                    break;

                case "2":
                    Console.WriteLine("\nEnter new Month or '`' to return");

                    line = Console.ReadLine().Trim();

                    if (line == "`")
                    {
                        ChangeViseDirectorBirthDate(schoolToEdit, schoolRepository, id, index);
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
                                ChangeViseDirectorBirthDate(schoolToEdit, schoolRepository, id, index);
                                return;
                            }
                        }
                        month = int.Parse(line);

                        int day = schoolToEdit.ViseDirectors.ToList()[index].BirthDate.Day;

                        int year = schoolToEdit.ViseDirectors.ToList()[index].BirthDate.Year;

                        schoolToEdit.ViseDirectors.ToList()[index].BirthDate = new DateTime(year, month, day);

                        schoolRepository.Save(schoolToEdit);

                        ChangeViseDirectorBirthDate(schoolToEdit, schoolRepository, id, index);
                        return;
                    }
                    break;

                case "3":
                    Console.WriteLine("\nEnter new Year or '`' to return");

                    line = Console.ReadLine().Trim();

                    if (line == "`")
                    {
                        ChangeViseDirectorBirthDate(schoolToEdit, schoolRepository, id, index);
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
                                ChangeViseDirectorBirthDate(schoolToEdit, schoolRepository, id, index);
                                return;
                            }
                        }
                        year = int.Parse(line);

                        int month = schoolToEdit.ViseDirectors.ToList()[index].BirthDate.Month;

                        int day = schoolToEdit.ViseDirectors.ToList()[index].BirthDate.Day;

                        schoolToEdit.ViseDirectors.ToList()[index].BirthDate = new DateTime(year, month, day);

                        schoolRepository.Save(schoolToEdit);

                        ChangeViseDirectorBirthDate(schoolToEdit, schoolRepository, id, index);
                        return;
                    }
                    break;
                default:
                    if (line == "`")
                    {
                        SelectViseDirector(schoolToEdit, schoolRepository, id, index);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect number!");

                        Console.WriteLine("\nClick Enter...");

                        Console.ReadLine();

                        ChangeViseDirectorBirthDate(schoolToEdit, schoolRepository, id, index);
                        return;
                    }
                    break;
            }
        }
        
        private static void ChangeViseDirectorIdentityNumber(School schoolToEdit, SchoolRepository schoolRepository, int id, int index)
        {
            Console.Clear();

            Console.WriteLine($"Current Identity Number: {schoolToEdit.ViseDirectors.ToList()[index].IdentityNumber}");

            Console.WriteLine("\nEnter new Identity Number or '`' to return:");

            string line = Console.ReadLine().Trim();

            if (line == "`")
            {
                SelectViseDirector(schoolToEdit, schoolRepository, id, index);
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
                        SelectViseDirector(schoolToEdit, schoolRepository, id, index);
                        return;
                    }
                }
                schoolToEdit.ViseDirectors.ToList()[index].IdentityNumber = line;

                schoolRepository.Save(schoolToEdit);

                SelectViseDirector(schoolToEdit, schoolRepository, id, index);
                return;
            }
        }

        private static void ChangeViseDirectorGender(School schoolToEdit, SchoolRepository schoolRepository, int id, int index)
        {
            Console.Clear();

            Console.WriteLine($"Current Gender: {schoolToEdit.ViseDirectors.ToList()[index].Gender}");

            Console.WriteLine("\nEnter Male or Female or '`' to return:");

            string line = Console.ReadLine().Trim().ToLower();

            if (line == "`")
            {
                SelectViseDirector(schoolToEdit, schoolRepository, id, index);
                return;
            }
            else
            {
                switch (line)
                {
                    case "male":
                        schoolToEdit.ViseDirectors.ToList()[index].Gender = Gender.Male;

                        schoolRepository.Save(schoolToEdit);

                        SelectViseDirector(schoolToEdit, schoolRepository, id, index);
                        return;
                        break;

                    case "female":
                        schoolToEdit.ViseDirectors.ToList()[index].Gender = Gender.Female;

                        schoolRepository.Save(schoolToEdit);

                        SelectViseDirector(schoolToEdit, schoolRepository, id, index);
                        return;
                        break;

                    default:
                        Console.WriteLine("Incorrect Gender!");

                        Console.WriteLine("\nClick Enter to continue...");

                        Console.ReadLine();

                        ChangeViseDirectorGender(schoolToEdit, schoolRepository, id, index);
                        return;
                }
            }
        }

        private static void ChangeViseDirectorSalary(School schoolToEdit, SchoolRepository schoolRepository, int id, int index)
        {
            Console.Clear();

            Console.WriteLine($"Current Salary: {schoolToEdit.ViseDirectors.ToList()[index].Salary}");

            Console.WriteLine("\nEnter new Salary or '`' to return:");

            string line = Console.ReadLine().Trim();

            int salary;

            if (line == "`")
            {
                SelectViseDirector(schoolToEdit, schoolRepository, id, index);
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
                        SelectViseDirector(schoolToEdit, schoolRepository, id, index);
                        return;
                    }
                }

                salary = int.Parse(line);

                schoolToEdit.ViseDirectors.ToList()[index].Salary = salary;

                schoolRepository.Save(schoolToEdit);

                SelectViseDirector(schoolToEdit, schoolRepository, id, index);
                return;
            }
        }

        private static void ChangeViseDirectorPhoneNumber(School schoolToEdit, SchoolRepository schoolRepository, int id, int index)
        {
            Console.Clear();

            Console.WriteLine($"Current Vise Director Phone Number: {schoolToEdit.ViseDirectors.ToList()[index].PhoneNumber}");

            Console.WriteLine("\nEnter new Phone Number or '`' to return:");

            string line = Console.ReadLine().Trim();

            if (line == "`")
            {
                SelectViseDirector(schoolToEdit, schoolRepository, id, index);
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
                        SelectViseDirector(schoolToEdit, schoolRepository, id, index);
                        return;
                    }
                }

                schoolToEdit.ViseDirectors.ToList()[index].PhoneNumber = line;

                schoolRepository.Save(schoolToEdit);

                SelectViseDirector(schoolToEdit, schoolRepository, id, index);
            }
        }

        private static void ChangeViseDirectorName(School schoolToEdit, SchoolRepository schoolRepository, int id, int index)
        {
            Console.Clear();

            Console.WriteLine($"Current Vise Director's Name: {schoolToEdit.ViseDirectors.ToList()[index].FirstName} {schoolToEdit.ViseDirectors.ToList()[index].MiddleName} {schoolToEdit.ViseDirectors.ToList()[index].LastName}");

            Console.WriteLine("\nEnter new First Name:");

            string line = Console.ReadLine().Trim();

            while (int.TryParse(line, out _))
            {
                Console.WriteLine("Incorrect Name!");
                Console.WriteLine("\nEnter new First Name:");
                line = Console.ReadLine().Trim();
            }

            schoolToEdit.ViseDirectors.ToList()[index].FirstName = line;

            Console.WriteLine("\nEnter new Middle Name:");

            line = Console.ReadLine().Trim();

            while (int.TryParse(line, out _))
            {
                Console.WriteLine("Incorrect Name!");
                Console.WriteLine("\nEnter new Middle Name:");
                line = Console.ReadLine().Trim();
            }

            schoolToEdit.ViseDirectors.ToList()[index].MiddleName = line;

            Console.WriteLine("\nEnter new Last Name:");

            line = Console.ReadLine().Trim();

            while (int.TryParse(line, out _))
            {
                Console.WriteLine("Incorrect Name!");
                Console.WriteLine("\nEnter new Last Name:");
                line = Console.ReadLine().Trim();
            }

            schoolToEdit.ViseDirectors.ToList()[index].LastName = line;

            schoolRepository.Save(schoolToEdit);

            SelectViseDirector(schoolToEdit, schoolRepository, id, index);
            return;
        }

        private static void AddViseDirector(School schoolToEdit, SchoolRepository schoolRepository, int id)
        {
            Console.Clear();

            Console.WriteLine("Create new Vise Director:");

            Teacher viseDirector = SelectTeacher();

            List<Teacher> viseDirectors = schoolToEdit.ViseDirectors.ToList();

            viseDirectors.Add(viseDirector);

            schoolToEdit.ViseDirectors = viseDirectors;

            schoolRepository.Save(schoolToEdit);

            EditSchoolViseDirectors(schoolToEdit, schoolRepository, id);
            
            return;
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

            Console.WriteLine("\nEnter the number of the component to edit or '`' to return:");

            string line = Console.ReadLine();

            if (line == "`")
            {
                EditSchool(schoolToEdit, schoolRepository, id);
                return;
            }

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
                    Console.WriteLine("\nIncorrect Component Number!");
                    Console.WriteLine("Click Enter...");

                    Console.ReadLine();

                    EditSchoolDirector(schoolToEdit, schoolRepository, id);
                    return;
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
                        return;
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
                        return;
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
                        return;
                    }
                    break;
                default:
                    if (line == "`")
                    {
                        EditSchoolDirector(schoolToEdit, schoolRepository, id);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect number!");

                        Console.WriteLine("\nClick Enter...");

                        Console.ReadLine();

                        ChangeDirectorBirthDate(schoolToEdit, schoolRepository, id);
                        return;
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
                        return;
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

        private static Teacher SelectTeacher()
        {
            Human human = SelectHuman();

            int salary = SelectSalary();

            Teacher teacher = new Teacher(human, new List<Subject>(), salary);

            return teacher;
        }

        private static Subject SelectSubject()
        {
            Console.WriteLine("Enter Subject Name:");

            string name = Console.ReadLine().Trim();

            Console.WriteLine("Enter Subject Lessons Count:");

            string line = Console.ReadLine().Trim();

            int count;
            while (!int.TryParse(line, out count))
            {
                Console.WriteLine("Incorrect Lessons Count!");

                Console.WriteLine("Enter Subject Lessons Count or '`' to return:");

                line = Console.ReadLine();

                if (line == "`")
                {
                    Console.WriteLine("Enter Subject Name or '`' to return:");

                    name = Console.ReadLine().Trim();

                    Console.WriteLine("Enter Subject Lessons Count or '`' to return:");
                }
            }
            Subject subject = new Subject(name, count);
            return subject;
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