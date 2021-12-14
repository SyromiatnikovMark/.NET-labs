using System;
using syromiatnikov01;
using syromiatnikov02;

namespace syromiatnikov03
{
    /// <summary>
    /// Class Container
    /// class that implements class container
    /// for collection of students
    /// </summary>
    public class ContainerLab03 : Container
    {
        /// <summary>
        /// Конструктор класса наследника
        /// </summary>
        /// <param name="students"></param>
        public ContainerLab03(Student[] students) : base(students)
        {
        }

        /// <summary>
        /// Method that allows to edit data of chosen student
        /// </summary>
        /// <param name="student"></param>
        public void EditData(Student student)
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
    }
}

