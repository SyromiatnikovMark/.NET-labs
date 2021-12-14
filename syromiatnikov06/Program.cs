﻿using System;
using syromiatnikov01;

namespace syromiatnikov06
{
    class Program
    {
        static void Main(string[] args)
        {
            var customStudent = new Student("Momot", "Roman", "Evegenievich", DateTime.Parse("10-8-2001"), DateTime.Parse("16-05-2019"), "119b", "CIT", "Computer engineering", 80);
            var students = new Student[] { new Student("Bily", "Vadim", "Ivanovich", DateTime.Parse("12-6-2001"), DateTime.Parse("16-05-2019"), "119a", "CIT", "Computer engineering", 100),
                new Student("Menshakov", "Dmytro", "Olegovich", DateTime.Parse("16-11-2000"), DateTime.Parse("23-8-2019"), "119b", "CIT", "Computer engineering", 90)};
            var list = new ContainerLab06(students);
            list.Add(customStudent);
            list.RemoveByCriteria();
            /*list.WriteToFile();
            list.ReadFromFile();
            list.ShowData(customStudent);
            list.EditData(customStudent);*/
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }

            list.Remove(new Student("Menshakov", "Dmytro", "Olegovich", DateTime.Parse("16-11-2000"), DateTime.Parse("23-8-2019"), "119a", "CIT", "Computer engineering", 90));
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }

            var stud = list.Find(customStudent);
            list.RemoveByCriteria();
            list.Clear();
            Console.ReadLine();
        }
    }
}