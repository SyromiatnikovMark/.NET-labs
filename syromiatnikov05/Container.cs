using System;
using System.Collections;
using syromiatnikov01;
using syromiatnikov03;
using syromiatnikov05.Comparators;

namespace syromiatnikov05
{
    /// <summary>
    /// Class Container
    /// class that implements class container
    /// for collection of students
    /// </summary>
    public class ContainerLab05 : ContainerLab03
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="students"></param>
        public ContainerLab05(Student[] students) : base(students)
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
            IComparer comparator = null;
            Console.WriteLine("Enter criteria of the deletion:");
            Console.WriteLine("1) group");
            Console.WriteLine("2) specialty");
            Console.WriteLine("3) faculty\n");
            var input = Console.ReadLine();
            switch (input)
            {
                case "group":
                    Console.WriteLine("Write group:");
                    input = Console.ReadLine();
                    comparator = new CompareGroup();
                    break;
                case "specialty":
                    Console.WriteLine("Write specialty:");
                    input = Console.ReadLine();
                    comparator = new CompareSpecialty();
                    break;
                case "faculty":
                    Console.WriteLine("Write faculty:");
                    input = Console.ReadLine();
                    comparator = new CompareFaculty();
                    break;
                default:
                    input = string.Empty;
                    Console.WriteLine("Invalid option\n");
                    break;
            }

            if (!string.IsNullOrEmpty(input))
            {
                var previousSize = _students.Length;

                for (var i = 0; i < _students.Length; i++)
                {
                    if (comparator.Compare(_students[i], input) == 0)
                    {
                        Remove(_students[i]);
                        i--;
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