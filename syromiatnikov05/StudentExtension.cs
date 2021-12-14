﻿using System;
using System.Collections;
using syromiatnikov01;
using syromiatnikov05.Comparators;

namespace menshakov05
{
    public static class StudentExtension
    {
        delegate int IsEqual(Student[] student);

        /// <summary>
        /// Method that counts chosen average value of a given collection
        /// </summary>
        /// <returns>Returns average value of a chosen field</returns>
        public static int CountAverage(this Student[] _students)
        {
            IComparer comparator = null;
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
            input = Console.ReadLine();
            switch (input)
            {
                case "group index":
                    Console.WriteLine("Write group index:");
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
                var size = 0;
                for (var i = 0; i < _students.Length; i++)
                {
                    if (comparator.Compare(_students[i], input) == 0)
                    {
                        size++;
                    }
                }

                var students = new Student[size];
                size = 0;

                for (var i = 0; i < _students.Length; i++)
                {
                    if (comparator.Compare(_students[i], input) == 0)
                    {
                        students[size] = _students[i];
                        size++;
                    }
                }

                return func(students);
            }

            return -1;
        }

        /// <summary>
        /// Method that counts average students` age of a given collection
        /// </summary>
        /// <param name="students"></param>
        /// <returns>Returns average value of an age field</returns>
        private static int CountAvgAge(Student[] students)
        {
            var count = 0;

            foreach (var student in students)
            {
                count += DateTime.Now.Year - student.DateOfBirth.Year;
            }

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
