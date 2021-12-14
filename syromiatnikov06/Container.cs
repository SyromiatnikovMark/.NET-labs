using System;
using System.Collections;
using System.Linq;
using syromiatnikov01;
using syromiatnikov03;

namespace syromiatnikov06
{
    /// <summary>
    /// Class Container
    /// class that implements class container
    /// for collection of students
    /// </summary>
    public class ContainerLab06 : ContainerLab03
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="students"></param>
        public ContainerLab06(Student[] students) : base(students)
        {
        }

        /// <summary>
        /// Method that clears the collection
        /// </summary>
        public void Clear()
        {
            _students = null;
        }

        /// <summary>
        /// Method that removes student by chosen criteria
        /// </summary>
        /// <returns>True if student was removed otherwise false</returns>
        public bool RemoveByCriteria()
        {
            Console.WriteLine("Enter criteria of the deletion:");
            Console.WriteLine("1) group");
            Console.WriteLine("2) specialty");
            Console.WriteLine("3) faculty\n");
            Student[] students = null;
            var input = Console.ReadLine();
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

            if (!string.IsNullOrEmpty(input))
            {
                var previousSize = _students.Length;

                for (int i = 0, j = 0; i < _students.Length; i++)
                {
                    if (_students[i].Equals(students[j]))
                    {
                        Remove(_students[i]);
                        i--;
                        j++;
                    }
                }

                if (previousSize != _students.Length)
                {
                    return true;
                }
            }

            return false;
        }
    }
}