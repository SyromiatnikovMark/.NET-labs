using System;
using System.Linq;
using syromiatnikov01;

namespace syromiatnikov07
{
    class Program
    {
        static void Main(string[] args)
        {
            var customStudent = new Student("Momot", "Roman", "Evegenievich", DateTime.Parse("10-8-2001"), DateTime.Parse("16-05-2019"), "119b", "CIT", "Computer engineering", 80);
            var students = new Student[] { new Student("Bily", "Vadim", "Ivanovich", DateTime.Parse("12-6-2001"), DateTime.Parse("16-05-2019"), "119a", "CIT", "Computer engineering", 100),
                new Student("Menshakov", "Dmytro", "Olegovich", DateTime.Parse("16-11-2000"), DateTime.Parse("23-8-2019"), "119b", "CIT", "Computer engineering", 90)};
            var list = new Container(students);
            list.Students.CountAverage();
            list.Add(customStudent);
          

            var query = from element in list.Students
                        where element.Faculty.Equals("CIT")
                        select element;
            var printService = new PrintService();
            printService.ShowFormattedData(list.Students);
            var stud = list.Students.Find(customStudent);
          //  list.RemoveByCriteria();
            list.Clear();
            Console.ReadLine();
        }
    }
}