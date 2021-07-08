using System;
using System.Linq;

namespace 기타_레슨
{
    class Program
    {
        static void combination(int[] arr, bool[] visited, int start, int n, int r)
        {
            if (r == 0)
            {
                int[] Save = new int[M];
                int Num = 0;
                for(int i = 0; i < N; i++)
                {
                    Save[Num] += inputs[i];
                    if (visited[i])
                        Num++;
                }
                int Max = 0;
                for (int i = 0; i < M; i++) 
                {
                    //Console.Write($"{Save[i]} ");
                    if (Max < Save[i])
                        Max = Save[i];
                }

                if (Max < Min)
                {
                    Min = Max;
                }

                    /*
                    for (int i = 0; i < n; i++)
                    {
                        if (visited[i])
                        {
                            Console.Write($"{arr[i]} ");
                        }
                    }
                    Console.WriteLine($"");
                    */

                    return;
            }

            for (int i = start; i < n; i++)
            {
                visited[i] = true;
                combination(arr, visited, i + 1, n, r - 1);
                visited[i] = false;
            }
        }
        static int N,M;
        static int[] inputs;
        static int Min = 10001;
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            inputs = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            
            N = input[0];
            M = input[1];

            int[] arr = new int[N];

            for (int i = 0; i < N; i++)
                arr[i] = i;

            bool[] visited = new bool[N];

            combination(arr, visited, 0, N, M-1);

            Console.Write($"{Min}");
        }
    }
}
