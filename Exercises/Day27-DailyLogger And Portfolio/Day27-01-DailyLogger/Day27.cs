using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStreamDemo
{
    internal class Day27
    {
        static void Main(string[] args)
        {
            string dir = @"..\..\..\";

            if (!Directory.Exists(dir))
            {
                Console.WriteLine("directory doesnt exist");
                return;
            }
            string file = "journal.txt";
            string path = dir + file;

            //if (!File.Exists(path))
            //{
            //    Console.WriteLine("file doesnt exist");
            //    return;
            //}

            Console.WriteLine("!DAILY REFLECTION!");
            string reflection = Console.ReadLine();
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(reflection);
                sw.WriteLine("------------------------------");
            }
        }
    }
}
