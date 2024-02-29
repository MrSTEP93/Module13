using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Module13.WordsCount
{
    internal class Program
    {
        static string filePath = Environment.CurrentDirectory + "\\cdev_Text.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //FileInfo file = new FileInfo(filePath);
            //if (file.Exists)
            //{
            //    Console.WriteLine("File in directory: ");
            //    Console.WriteLine(file.DirectoryName);
            //    Console.WriteLine("Amount of words in this file is " + CountWords(filePath));
            //}

            while (true)
            {
                CountUniqueChars();
            }

            //Console.WriteLine();
        }

        static int CountWords(string filePath)
        {
            int count = 0;
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                string aString = sr.ReadLine();
                if (!string.IsNullOrEmpty(aString))
                {
                    //count++;
                    string[] words = aString.Split(" ");
                    count += words.Length;
                }

            }
            return count;
        }

        static void CountUniqueChars()
        {
            Console.WriteLine("Введите текст:");

            string sentence = Console.ReadLine();
            char[] characters = sentence.ToCharArray();

            var symbols = new HashSet<char>();

            // добавляем во множество. Сохраняются только неповторяющиеся символы
            foreach (var symbol in characters)
                symbols.Add(symbol);

            Console.WriteLine($"Всего {symbols.Count} уникальных символов");

            var signs = new[] { ',', ' ', '.', '!', '?', '(' ,')', ':', ';' };
            var numbers = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            bool containsNumbers = symbols.Overlaps(numbers);
            Console.WriteLine($"Коллекция содержит цифры: {containsNumbers}");

            symbols.ExceptWith(signs);
            Console.WriteLine($"Символов без знаков препинания:: {symbols.Count}");

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
