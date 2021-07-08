using System;
using System.Collections.Generic;
using System.Linq;

namespace N과_M__2_
{
    class Program
    {
        static List<int> f, arr;
        static void print(List<int> arr, List<int> visited, int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (visited[i]==1)
                {
                    Console.Write($"{arr[i]} ");
                }
            }
            Console.Write($"\n");
        }
        static void combination(List<int> arr, List<int> visited, int start, int n, int r)
        {
            if (r == 0)
            {
                print(arr, visited, n);
                return;
            }

            for (int i = start; i < n; i++)
            {
                visited[i] = 1;
                combination(arr, visited, i + 1, n, r - 1);
                visited[i] = 0;
            }
        }

        static void Main(string[] args)
        {
            arr = new List<int>();
            f = new List<int>();
            var S = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            for(int i = 1; i <= S[0]; i++)
            {
                arr.Add(i);
                f.Add(0);
            }
            combination(arr, f, 0, S[0], S[1]);
        }
    }
}
