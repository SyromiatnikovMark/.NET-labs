﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using syromiatnikov01;

namespace syromiatnikov07
{
    /// <summary>
    /// Class Container
    /// class that implements class container
    /// for collection of students
    /// </summary>
    public class Container : IEnumerable
    {
        /// <summary>
        /// Private field students
        /// </summary>
        private Student[] _students;

        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        /// <param name="students"></param>
        public Container(Student[] students)
        {
            _students = new Student[students.Length];

            for (var i = 0; i < students.Length; i++)
            {
                _students[i] = students[i];
            }
        }

        /// <summary>
        /// Property that returns array of students
        /// </summary>
        public Student[] Students => _students;

        /// <summary>
        /// Method that adds student to collection
        /// </summary>
        /// <param name="student"></param>
        public void Add(Student student)
        {
            if (student == null)
            {
                Console.WriteLine("Student is null");
                return;
            }

            var position = _students.Length;
            Array.Resize(ref _students, _students.Length + 1);
            _students[position] = student;
        }

        /// <summary>
        /// Method that removes student from collection
        /// </summary>
        /// <param name="student"></param>
        /// <returns>True if student was removed otherwise false</returns>
        public bool Remove(Student student)
        {
            if (student == null)
            {
                return false;
            }

            var pos = -1;
            for (var i = 0; i < _students.Length; i++)
            {
                if (_students[i].Equals(student))
                {
                    pos = i;
                    break;
                }
            }

            if (pos == -1)
            {
                return false;
            }

            var students = new Student[_students.Length - 1];

            for (var i = 0; i < pos; i++)
            {
                students[i] = _students[i];
            }
            for (var i = pos + 1; i < _students.Length; i++)
            {
                students[i - 1] = _students[i];
            }

            _students = students;
            return true;
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
            Console.WriteLine("1) group index");
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
                foreach (var item in _students.Intersect(students))
                {
                    Remove(item);
                }

                if (previousSize != _students.Length)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Implemented GetEnumerator method
        /// </summary>
        /// <returns>ContainerEnum</returns>
        public IEnumerator GetEnumerator()
        {
            return new ContainerEnumerator(_students);
        }
    }
}