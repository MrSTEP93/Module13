using System;
using System.Collections.Generic;
using System.IO;
using static ConsoleHelper_50.Helper_50;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;
using System.Collections.Immutable;
using System.Text;

namespace Module13.Final2
{
    internal class Program
    {
        static string filePath = Environment.CurrentDirectory + "\\Text1.txt";
        static List<string> words = new List<string>();
        static Dictionary<string, int> wordsCount = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            FileInfo file = new FileInfo(filePath);
            if (!file.Exists)
            {
                return;
            }
            Write("File in directory: ");
            WriteLn($" {file.DirectoryName} \n");

            CreateWordsList(filePath, out words);
            WriteLn("List of words created");
            CountWords(out wordsCount);
        }

        static void CreateWordsList(string filePath, out List<string> list)
        {
            list = new List<string>();
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                string aString = sr.ReadLine();
                aString = new string(aString.Where(c => !char.IsPunctuation(c)).ToArray());
                //aString = aString.Trim();
                if (!string.IsNullOrEmpty(aString))
                {
                    string[] words = aString.Split(" ");
                    foreach (var word in words)
                    {
                        // когда я убираю из строки знаки пунктуации, получаются двойные пробелы, и Split(" ") выделяет в массив пустую строку между ними.
                        // наверно, это более быстрый способ убрать эти слова, нежели идти по строке и удалять повторяющиеся пробелы
                        if (word != "")
                        {
                            list.Add(word);
                        }
                    }
                    //list.AddRange(words);
                }
            }
        }

        static void CountWords(out Dictionary<string, int> wordsCount)
        {
            var signs = new[] { ',', ' ', '.', '!', '?', '(', ')', ':', ';' };
            wordsCount = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (wordsCount.ContainsKey(word))
                    wordsCount[word]++;
                else
                    wordsCount.Add(word, 1);
            }

            int i = 0;
            foreach (var pair in wordsCount.OrderByDescending(pair => pair.Value))
            {
                if (i > 9)
                    return;
                i++;
                WriteLn($"{i}. Word \"{pair.Key}\":  {pair.Value,7} times");

            }
        }
    }
}
