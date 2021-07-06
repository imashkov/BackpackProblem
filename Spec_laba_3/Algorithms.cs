using System;

namespace Spec_laba_3
{
    class Algorithms
    {
        public int Table(BackPackTask task, int k)
        {
            int[] previous = new int[task.A + 1];
            int[] current = new int[task.A + 1];
            current[0] = previous[0] = 0;
            for (int i = 1; i <= task.A; i++)
            {
                if (task.items[0].weight <= i)
                    previous[i] = task.items[0].cost;
                else previous[i] = 0;
            }
            for (int i = 1; i < k; i++)
            {
                for (int j = 1; j <= task.A; j++)
                {
                    if (task.items[i].weight <= j)
                        current[j] = Math.Max(previous[j], previous[j - task.items[i].weight] + task.items[i].cost);
                    else
                        current[j] = previous[j];
                }
                current.CopyTo(previous, 0);
            }
            return current[task.A];
        }

        public int Recursion(BackPackTask task, int k, int w)
        {
            if (task.database.ContainsKey(new Tuple<int, int>(k, w)))
                return task.database[new Tuple<int, int>(k, w)];
            if (w < 1) return 0;
            if (k == 1 && task.items[0].weight <= w)
            {
                task.database.Add(new Tuple<int, int>(k, w), task.items[0].cost);
                return task.items[0].cost;
            }
            else if (k == 1)
            {
                task.database.Add(new Tuple<int, int>(k, w), 0);
                return 0;
            }

            int result;
            if (task.items[k - 1].weight <= w)
                result = Math.Max(Recursion(task, k - 1, w),
                    Recursion(task, k - 1, w - task.items[k - 1].weight) + task.items[k - 1].cost);
            else 
                result = Recursion(task, k - 1, w);
            task.database.Add(new Tuple<int, int>(k, w), result);
            return result;
        }

        public void BaseSort(BackPackTask task)
        {
            Array.Sort(task.items, (a, b) => ((double)b.cost / b.weight).CompareTo((double)a.cost / a.weight));
        }
        public void MySort(BackPackTask task)
        {
            Array.Sort(task.items, (a, b) => a.cost.CompareTo(b.cost));
            Array.Sort(task.items, (a, b) => (b.cost / (double)b.weight).CompareTo(a.cost / (double)a.weight));
        }
    }
}
