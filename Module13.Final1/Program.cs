using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Xml;
using System.Xml.Linq;
using static ConsoleHelper_50.Helper_50;

namespace Module13.Final1
{
    internal class Program
    {
        static string filePath = Environment.CurrentDirectory + "\\Text1.txt";
        static string promo = "Получите подписку и качайте книги на нашем сайте с выгодой до 70%!!!";
        static int promoPeriodicity = 100;

        static List<string> strings = new List<string>();
        static LinkedList<string> linkedStrings = new LinkedList<string>();

        static List<string> words = new List<string>();
        static LinkedList<string> linkedWords = new LinkedList<string>();

        static Stopwatch sw = new Stopwatch();

        static void Main(string[] args)
        {
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                Write("File in directory: ");
                WriteLn($" { file.DirectoryName } \n");

                //                                                                             List of strings
                WriteLn("Let's work with STRINGS of our input file", ConsoleColor.Green);
                WriteLn("Creating new List<string>");
                sw.Start();
                CreateStringsList(filePath, out strings);
                sw.Stop();
                PrintSummary($"Created List with {strings.Count} elements", sw);

                WriteLn($"Let's insert some promo message (in every {promoPeriodicity} strings) into  List<string>");
                sw.Start();
                InsertPromoMessage(ref strings, promo, promoPeriodicity);
                sw.Stop();
                PrintSummary($"Finished. Now List<string> contains {strings.Count} elements", sw);

                //                                                                              LinkedList of strings
                WriteLn("Creating new List<string>");
                sw.Start();
                CreateStringsList(filePath, out linkedStrings);
                sw.Stop();
                PrintSummary($"Created List with {linkedStrings.Count} elements", sw);

                WriteLn($"Let's insert some promo message (in every {promoPeriodicity} strings) into  LinkedList<string>");
                sw.Start();
                InsertPromoMessage(ref linkedStrings, promo, promoPeriodicity);
                sw.Stop();
                PrintSummary($"Finished. Now LinkedList<string> contains {linkedStrings.Count} elements", sw);

                //                                                                             List of words
                WriteLn("Let's work with WORDS of our input file", ConsoleColor.Green);
                WriteLn("Creating new List<string>");
                sw.Start();
                CreateWordsList(filePath, out words);
                sw.Stop();
                PrintSummary($"Created List with {words.Count} elements", sw);

                WriteLn($"Let's insert some promo message (in every 1000 words) into  List<string>");
                sw.Start();
                InsertPromoMessage(ref words, "\"lexaisthebest.ya\"", 1000);
                sw.Stop();
                PrintSummary($"Finished. Now List<string> contains {words.Count} elements", sw);

                //                                                                              LinkedList of words
                WriteLn("Creating new List<string>");
                sw.Start();
                CreateWordsList(filePath, out linkedWords);
                sw.Stop();
                PrintSummary($"Created List with {linkedWords.Count} elements", sw);

                WriteLn($"Let's insert some promo message (in every 1000 words) into  LinkedList<string>");
                sw.Start();
                InsertPromoMessage(ref linkedWords, "\"lexaisthebest.ya\"", 1000);
                sw.Stop();
                PrintSummary($"Finished. Now LinkedList<string> contains {linkedWords.Count} elements", sw);

            }
        }

        static void PrintSummary(string title, Stopwatch sw)
        {
            WriteLn(title);
            Write($"Elapsed time: ");
            Write($"{sw.Elapsed}", ConsoleColor.White);
            Write($" Elapsed milliseconds: ");
            WriteLn($"{sw.ElapsedMilliseconds}\n", ConsoleColor.White);
        }

        static void CreateStringsList(string filePath, out List<string> list)
        {
            list = new List<string>();
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                string aString = sr.ReadLine();
                if (!string.IsNullOrEmpty(aString))
                {
                    list.Add(aString);
                }
            }
        }

        static void InsertPromoMessage(ref List<string> collection, string message, int periodicity)
        { 
            int stringsCount = collection.Count;
            for (int i = 0; i < stringsCount; i += periodicity)
            {
                    collection.Insert(i, message);
            }
        }

        static void CreateStringsList(string filePath, out LinkedList<string> list)
        {
            list = new LinkedList<string>();
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                string aString = sr.ReadLine();
                if (!string.IsNullOrEmpty(aString))
                {
                    list.AddLast(aString);
                }
            }
        }

        static void InsertPromoMessage(ref LinkedList<string> collection, string message, int periodicity)
        {
            LinkedListNode<string> node;
            var i = 0;

            for (node = collection.First; node != null; node = node.Next)
            {
                if (i % periodicity == 0)
                    collection.AddAfter(node, message);
                i++;
            }
        }

        static void CreateWordsList(string filePath, out List<string> list)
        {
            list = new List<string>();
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                string aString = sr.ReadLine();
                if (!string.IsNullOrEmpty(aString))
                {
                    string[] words = aString.Split(" ");
                    list.AddRange(words);
                }
            }
        }

        static void CreateWordsList(string filePath, out LinkedList<string> list)
        {
            list = new LinkedList<string>();
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                string aString = sr.ReadLine();
                if (!string.IsNullOrEmpty(aString))
                {
                    string[] words = aString.Split(" ");
                    foreach (string word in words)
                    {
                        list.AddLast(word);
                    }
                }
            }
        }
    }
}
