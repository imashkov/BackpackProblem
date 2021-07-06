using System;
using System.Diagnostics;

namespace Spec_laba_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] test_file_paths = {
                @"task_3_01_n5.txt",
                @"task_3_02_n5.txt",
                @"task_3_03_n10.txt",
                @"task_3_04_n10.txt",
                @"task_3_05_n50.txt",
                @"task_3_06_n50.txt",
                @"task_3_07_n100.txt",
                @"task_3_08_n100.txt",
                @"task_3_09_n1000.txt",
                @"task_3_10_n1000.txt" 
            };

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("|{0, 11}{0, 11}{0, 11}{0, 11}{0, 11}{0, 11}{0, 11}{0, 11}{0, 11}", "|".PadLeft(11, '-'));
            Console.WriteLine("|{0, 10}|{1, 10}|{2, 10}|{3, 10}|{4, 10}|{5, 10}|{6, 10}|{7, 10}|{8, 10}|",
                "Test", "Table", "Table time", "Recursion", "Rec. time",
                "Base Sort", "Deviation", "My sort", "Deviation");
            Console.WriteLine("|{0, 11}{0, 11}{0, 11}{0, 11}{0, 11}{0, 11}{0, 11}{0, 11}{0, 11}", "|".PadLeft(11, '-'));

            for (int i = 0; i < 10; i++)
            {
                Console.Write("|{0, 10}|", i + 1);
                Stopwatch timer = new Stopwatch();
                Stopwatch timer2 = new Stopwatch();
                BackPackTask task1 = new BackPackTask(test_file_paths[i]);
                Algorithms alg = new Algorithms();

                timer.Start();
                int Q = alg.Table(task1, task1.N);
                timer.Stop();
                Console.Write("{0, 10}|", Q);
                TimeSpan span = timer.Elapsed;
                Console.Write(string.Format("{0,7} ms|", span.Milliseconds ));

                timer2.Start();
                Q = alg.Recursion(task1, task1.N, task1.A);
                timer2.Stop();
                TimeSpan span2 = timer2.Elapsed;
                Console.Write("{0, 10}|", Q);
                Console.Write(string.Format("{0,7} ms|", span2.Milliseconds));

                alg.BaseSort(task1);
                int Q1 = alg.Table(task1, (int)(Math.Ceiling(task1.N / 2.0)));
                Console.Write("{0, 10}|", Q1);
                Console.Write("{0, 8} %|", Math.Round((Q - Q1) / (double)Q * 100));

                alg.MySort(task1);
                Q1 = alg.Table(task1, (int)(Math.Ceiling(task1.N / 2.0)));
                Console.Write("{0, 10}|", Q1);
                Console.Write("{0, 8} %|", Math.Round((Q - Q1) / (double)Q * 100));
                Console.WriteLine();
            }
            Console.WriteLine("|{0, 11}{0, 11}{0, 11}{0, 11}{0, 11}{0, 11}{0, 11}{0, 11}{0, 11}", "|".PadLeft(11, '-'));
            Console.ReadKey();
        }
    }
}
