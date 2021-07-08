using System;
using System.Linq;

namespace 발전소
{
    class Program
    {
        static int DP(int start, int Y)
        {
            if (Y >= P)
            {
                return 0;
            }
            if (Solve[start] >= 0)
            {
                return Solve[start];
            }

            Solve[start] = 1000000000;

            for (int i = 0; i < N; i++)
            {
                if ((start & (1 << i)) == (1 << i))
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (i == j || (start & (1 << j)) == (1 << j)) // j도 켜져있으면 스킵
                            continue;

                        Solve[start] = Math.Min(Solve[start], DP(start | (1 << j), Y + 1) + Map[i, j]);
                    }
                }
            }

            return Solve[start];
        }

        static int P, N, Y;
        static int[] Solve;
        static int[,] Map;
        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            Map = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                for (int j = 0; j < N; j++)
                {
                    Map[i, j] = input[j];
                }
            }
            string bit = Console.ReadLine();
            Y = 0;
            int start = 0;
            for (int i = 0; i < N; i++)
            {
                start += (bit[i] == 'Y') ? 1 << i : 0;
                _ = bit[i] == 'Y' ? Y++ : 0;
            }
            P = int.Parse(Console.ReadLine());

            //Solve = new int[1 << N];
            Solve = Enumerable.Repeat<int>(-1, 1 << N).ToArray<int>();

            if (start == 0 && P == 0) Console.WriteLine($"{0}");
            else if (start == 0 && P > 0) Console.WriteLine($"{-1}");
            else if (Y >= P) Console.WriteLine($"{0}");
            else
            {
                int ans = DP(start, Y);
                Console.Write($"{(ans == int.MaxValue ? -1 : ans)}");
            }

            //foreach (int i in Solve)
                //Console.WriteLine($"{i}");
        }
    }
}
