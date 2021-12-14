using syromiatnikov01;
using System;
using System.Linq;

namespace syromiatnikov07
{
    public static class DataWorkingService
    {
        delegate int IsEqual(Student[] student);

        /// <summary>
        /// Method that finds student in collection
        /// </summary>
        /// <param name="student"></param>
        /// <returns>If such student exists returns it otherwise null</returns>
        public static Student Find(this Student[] _students, Student student)
        {
            for (var i = 0; i < _students.Length; i++)
            {
                if (_students[i].Equals(student))
                {
                    return _students[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Method that allows to edit data of chosen student
        /// </summary>
        /// <param name="student"></param>
        public static void EditData(this Student[] _students, Student student)
        {
            var pos = -1;

            for (var i = 0; i < _students.Length; i++)
            {
                if (_students[i].Equals(student))
                {
                    pos = i;
                    break;
                }
            }

            if (pos != -1)
            {
                Console.WriteLine("Enter what field you want to edit:\n1) First name\n2) Last name\n3) Patronymic\n4) Date of birth\n5) Date of admission\n" +
                    "6) Group\n7) Faculty\n8) Specialty\n9) Academic performance\n");
                var option = Console.ReadLine();
                try
                {
                    switch (option)
                    {
                        case "Name":
                            _students[pos].FirstName = Console.ReadLine();
                            break;
                        case "Surname":
                            _students[pos].LastName = Console.ReadLine();
                            break;
                        case "Patronymic":
                            _students[pos].Patronymic = Console.ReadLine();
                            break;
                        case "Date of birth":
                            _students[pos].DateOfBirth = DateTime.Parse(Console.ReadLine());
                            break;
                        case "Date of admission":
                            _students[pos].DateOfAdmission = DateTime.Parse(Console.ReadLine());
                            break;
                        case "Group":
                            _students[pos].Group = Console.ReadLine();
                            break;
                        case "Faculty":
                            _students[pos].Faculty = Console.ReadLine();
                            break;
                        case "Specialty":
                            _students[pos].Specialty = Console.ReadLine();
                            break;
                        case "Academic performance":
                            _students[pos].AcademicPerformance = int.Parse(Console.ReadLine());
                            break;
                        default:
                            Console.WriteLine("Invalid option\n");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("There is no such student in collection\n");
            }
        }

        /// <summary>
        /// Method that counts chosen average value of a given collection
        /// </summary>
        /// <returns>Returns average value of a chosen field</returns>
        public static int CountAverage(this Student[] _students)
        {
            IsEqual func = null;
            Console.WriteLine("Count avg age or academic performance:");
            Console.WriteLine("1) Age");
            Console.WriteLine("2) Performance");
            var input = Console.ReadLine();
            if (input == "Age")
            {
                func = CountAvgAge;
            }
            else if (input == "Performance")
            {
                func = CountAvgPerformance;
            }
            else
            {
                Console.WriteLine("Invalid option");
                return -1;
            }

            Console.WriteLine("Enter criteria of the counting:");
            Console.WriteLine("1) group index");
            Console.WriteLine("2) specialty");
            Console.WriteLine("3) faculty\n");
            Student[] students = null;
            input = Console.ReadLine();
            switch (input)
            {
                case "group index":
                    Console.WriteLine("Write group index:");
                    input = Console.ReadLine();
                    students = _students.Where(s => s.Group.Equals(input)).ToArray();
                    break;
                case "specialty":
                    Console.WriteLine("Write specialty:");
                    input = Console.ReadLine();
                    students = _students.Where(s => s.Specialty.Equals(input)).ToArray();
                    break;
                case "faculty":
                    Console.WriteLine("Write faculty:");
                    input = Console.ReadLine();
                    students = _students.Where(s => s.Faculty.Equals(input)).ToArray();
                    break;
                default:
                    input = string.Empty;
                    Console.WriteLine("Invalid option\n");
                    break;
            }

            return func(students);
        }

        /// <summary>
        /// Method that counts average students` age of a given collection
        /// </summary>
        /// <param name="students"></param>
        /// <returns>Returns average value of an age field</returns>
        private static int CountAvgAge(Student[] students)
        {
            var sumOfyears = (from student in students
                         select student.DateOfBirth.Year).Sum();
            var count = ((from student in students
                          select student).Count() * DateTime.Now.Year) - sumOfyears;
            return count / students.Length;
        }

        /// <summary>
        /// Method that counts average students` performance of a given collection
        /// </summary>
        /// <param name="students"></param>
        /// <returns>Returns average value of an performance field</returns>
        private static int CountAvgPerformance(Student[] students)
        {
            var count = 0;

            foreach (var student in students)
            {
                count += student.AcademicPerformance;
            }

            return count / students.Length;
        }
    }
}