using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Module13.Final1
{
    internal class Program
    {
        static string filePath = Environment.CurrentDirectory + "\\Text1.txt";
        static List<string> strings = new List<string>();
        static Stopwatch sw = new Stopwatch();

        static void Main(string[] args)
        {
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                Console.WriteLine("File in directory: ");
                Console.WriteLine(file.DirectoryName + "\n");

                Console.WriteLine("Creating new List<string>");
                sw.Start();
                CreateList();
                sw.Stop();
                Console.WriteLine($"Created List with { strings.Count } elements");
                Console.WriteLine($"Elapsed time: {sw.Elapsed};  Elapsed milliseconds: {sw.ElapsedMilliseconds}");

                Console.WriteLine("Let's insert some promo strings into  List<string>");
                sw.Start();
                CreateList();
                sw.Stop();
                Console.WriteLine($"Created List with {strings.Count} elements");
            }
        }

        static void CreateList()
        {
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                string aString = sr.ReadLine();
                if (!string.IsNullOrEmpty(aString))
                {
                    strings.Add(aString);
                }
            }
        }

        static void InsertAdv(ref ICollection<string> collection)
        {
            string promo = "Получите подписку и качайте книги на нашем сайте с выгодой до 70%!!!";
            if (collection is List<string>)
            {
                
            }
        }
    }
}
