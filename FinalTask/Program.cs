using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string txtFile = ("/Users/dima/Desktop/Students/File.txt");

            try
            {
                if (Directory.Exists("/Users/dima/Desktop/Students"))
                {
                    Console.WriteLine("Папка для студентов уже существует.");
                    GetText();
                }
                else
                {
                    Directory.CreateDirectory("/Users/dima/Desktop/Students");
                    GetText();
                }
                Console.WriteLine("Файл в папке.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка доступа.{ex}");
            }

            void GetText()
            {

                string str = "/Users/dima/Desktop/Students.dat";
                //BinaryFormatter bf = new BinaryFormatter();
                // using (var i = new FileStream(str, FileMode.Open))
                {
                    //var f = (Students)bf.Deserialize(i);
                    using (StreamReader sr = File.OpenText(str))
                    {
                        string Str = "";
                        while ((Str = sr.ReadLine()) != null)
                        {
                            if (!File.Exists(txtFile))
                            {
                                using (StreamWriter sw = File.CreateText(txtFile))
                                {
                                    sw.WriteLine(Str);
                                }
                            }
                            else
                            {
                                using (StreamWriter sw = File.AppendText(txtFile))
                                {
                                    sw.WriteLine(Str);
                                }
                            }
                        }

                    }
                }
            }
        }
        [Serializable]
        public class Students
        {
            public string Name;
            public string Group;
            public DateTime date;

            public Students(string name, string group, DateTime date)
            {
                Name = name;
                Group = group;
                this.date = date;
            }
        }
    }
}
