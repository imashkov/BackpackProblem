using System;
using System.Collections.Generic;
using System.IO;

namespace Spec_laba_3
{
    public class BackPackTask
    {
        public int N { get; set; }
        public int A { get; set; }
        public Item[] items;
        public int[] max_values;
        public Dictionary<Tuple<int, int>, int> database;

        public BackPackTask(string file_path)
        {
            using StreamReader file = new StreamReader(file_path);
            database = new Dictionary<Tuple<int, int>, int>();
            if (file == null)
                Console.WriteLine("There is a problem with file");
                this.A = int.Parse(file.ReadLine());
                this.N = int.Parse(file.ReadLine());

                string[] s;
                s = file.ReadLine().Trim().Split(' ');
                int i = 0;
                this.items = new Item[N];
                foreach (string item in s)
                {
                    items[i].weight = int.Parse(item);
                    i++;
                }
                s = file.ReadLine().Trim().Split(' ');
                i = 0;
                foreach (string item in s)
                {
                    items[i].cost = int.Parse(item);
                    i++;
                }
            max_values = new int[A];
        }

        public int Q(int[] solution)
        {
            int result = 0;
            for (int i = 0; i < N; i++)
                if (solution[i] == 1)
                    result += items[i].cost;
            return result;
        }
    }
    public struct Item
    {
        public int weight;
        public int cost;
        public Item(int w, int c)
        {
            weight = w;
            cost = c;
        }
    }
}
