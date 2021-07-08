using System;
using System.Linq;

namespace 정사각형_만들기
{
    class Program
    {
        static int DP(int x, int y)
        {
            if (Map[x, y] != int.MaxValue) 
                return Map[x, y];
            if (y > x) { int t = x; x = y; y = t; }
            if (x % y == 0)
                return x / y;

            int ret = int.MaxValue;
            if (x >= 3 * y)
            {
                Map[x, y] = Math.Min(ret, DP(x - y, y) + 1); ;
                return Map[x, y];
            }
            else
            {
                for (int i = 1; i <= x - i; i++)
                {
                    Map[x, y] = Math.Min(Map[x, y], DP(i, y) + DP(x - i, y));
                }
                for (int i = 1; i <= y - i; i++)
                {
                    Map[x, y] = Math.Min(Map[x, y], DP(x, i) + DP(x, y - i));
                }
                if (x <= 100)
                    Map[y, x] = Map[x, y];
                return Map[x, y];
            }
        }

        static int[,] Map;
        static int N, M;
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
            N = input[0]; M = input[1];
            Map = new int[10001, 101];
            
            for (int i = 1; i <= 10000; i++)
                for (int j = 1; j <= 100; j++)
                    Map[i,j] = int.MaxValue;

            Console.Write($"{DP(N, M)}");
        }
    }
}
