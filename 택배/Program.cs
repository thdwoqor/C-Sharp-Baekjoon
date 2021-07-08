using System;
using System.Collections.Generic;
using System.Linq;

namespace 택배
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
            int N = input[0]; int C = input[1];
            int M = int.Parse(Console.ReadLine());
            List<List<int>> Village = new List<List<int>>();

            for (int i = 0; i < M; i++)
            {
                input = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
                Village.Add(new List<int>());
                Village[i].Add(input[0]);
                Village[i].Add(input[1]);
                Village[i].Add(input[2]);
            }
            Village.Sort((a, b) => (a[0] == b[0]) ? (a[1] > b[1]) ? -1 : 1 : (a[0] > b[0]) ? -1 : 1);

            int[] Arr = new int[10002];
            ulong Sum = 0;

            foreach (List<int> j in Village)
            {
                int get = 0;
                int s = j[0];int e = j[1];
                int k = j[2];
                for (int i = s; i < e; i++)
                {
                    get = Math.Max(get, Arr[i]);
                }
                get = Math.Min(C - get, k);

                for(int i = s; i < e; i++)
                {
                    Arr[i] += get;
                }
                Sum += (ulong)get;
            }

            /*
            foreach(int i in Arr)
            {
                Console.WriteLine($"{i}*");
            }
            */
            Console.Write($"{Sum}");
        }
    }
}


/*
4 10
3
1 4 10
2 3 10
3 4 10
*/
