using syromiatnikov01;
using System;
using System.Collections;

namespace syromiatnikov05.Comparators
{
    /// <summary>
    /// Class CompareGroups
    /// class that implements IComparer interface
    /// for the group of a student
    /// </summary>
    public class CompareGroup : IComparer
    {
        public int Compare(object x, object y)
        {
            var student = (Student)x;
            var criteria = (string)y;

            return student.Group.CompareTo(criteria);
        }
    }
}