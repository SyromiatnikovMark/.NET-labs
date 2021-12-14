using System;
using System.Text;
using syromiatnikov01;

namespace syromiatnikov04
{
    public static class PrintService
    {
        /// <summary>
        /// Method that prints chosen data about student
        /// </summary>
        /// <param name="student"></param>
        public static void ShowData(this Student[] students, Student student)
        {
            var pos = -1;

            for (var i = 0; i < students.Length; i++)
            {
                if (students[i].Equals(student))
                {
                    pos = i;
                    break;
                }
            }

            if (pos != -1)
            {
                var dataForPrint = new StringBuilder();
                Console.WriteLine("Enter what data you want to get:\n1) group index\n2) course\n3) age\n");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "group index":
                        dataForPrint.AppendFormat("\nFaculty: {0}\nSpecialty: {1}\nDate of admission: {2}\nGroup: {3}", student.Faculty,
                            student.Specialty, student.DateOfAdmission.Year, student.Group);
                        Console.WriteLine(dataForPrint.ToString());
                        dataForPrint.Clear();
                        break;
                    case "course":
                        dataForPrint.AppendFormat("\nCourse: {0}\nSemester: {1}\n", (DateTime.Now.Year - student.DateOfAdmission.Year) + 1,
                            Math.Ceiling((double)((12 * (DateTime.Now.Year - student.DateOfAdmission.Year) + DateTime.Now.Month - student.DateOfAdmission.Month)
                           - 2 * (DateTime.Now.Year - student.DateOfAdmission.Year))) / 5);
                        Console.WriteLine(dataForPrint.ToString());
                        dataForPrint.Clear();
                        break;
                    case "age":
                        dataForPrint.AppendFormat("\nYears: {0}\nMonth: {1}\nDays: {2}\n", DateTime.Now.Year - student.DateOfBirth.Year,
                            (Math.Abs(DateTime.Now.Month - student.DateOfBirth.Month)) - 1, DateTime.Now.Day);
                        Console.WriteLine(dataForPrint.ToString());
                        dataForPrint.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid option\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("There is no such student in collection\n");
            }
        }
    }
}