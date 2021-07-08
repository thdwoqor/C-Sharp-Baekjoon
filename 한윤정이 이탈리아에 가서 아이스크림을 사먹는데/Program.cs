using System;
using System.Linq;

namespace 한윤정이_이탈리아에_가서_아이스크림을_사먹는데
{
    class Program
    {
        static int f(int n, int k)
        {
            if (k == n) return 1;
            else if (k == 1) return n;
            else return f(n - 1, k - 1) + f(n - 1, k);
        }

        static void Main(string[] args)
        {
            int[] NM = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            int N = NM[0];
            int M = NM[1];
            bool[,] Map = new bool[201,201];
            for(int i = 0; i < M; i++)
            {
                NM = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
                int A = NM[0];
                int B = NM[1];
                Map[A, B] = true; Map[B, A] = true;
            }
            int sum = 0;
            for(int i = 1; i <= N-2; i++)
            {
                for (int j = i+1; j <= N-1; j++)
                {
                    if (Map[i, j])
                        continue;
                    for(int k = j + 1; k <= N; k++)
                    {
                        if (Map[i, k] || Map[j, k])
                            continue;
                        else
                            sum++;
                    }
                }
            }
            Console.WriteLine($"{sum}");
        }
     }
}
