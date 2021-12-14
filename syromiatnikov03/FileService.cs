using System;
using System.IO;
using syromiatnikov01;
using System.Runtime.Serialization.Json;

namespace syromiatnikov03
{
    public class FileService
    {
        /// <summary>
        /// Method that writes students' data to JSON file
        /// </summary>
        public void WriteToFile(Student[] students)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(Student[]));

            try
            {
                using (var file = new FileStream("students.json", FileMode.Create))
                {
                    try
                    {
                        jsonFormatter.WriteObject(file, students);
                        Console.WriteLine("Data were successfully written to file\n");
                    }
                    catch (System.Runtime.Serialization.SerializationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Method that reads students' data from JSON file
        /// </summary>
        public Student[] ReadFromFile()
        {
            Student[] students = null;
            var jsonFormatter = new DataContractJsonSerializer(typeof(Student[]));
            try
            {
                using (var file = new FileStream("students.json", FileMode.Open))
                {
                    try
                    {
                        students = jsonFormatter.ReadObject(file) as Student[]; // null
                    }
                    catch (System.Runtime.Serialization.SerializationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return students;
        }
    }
}