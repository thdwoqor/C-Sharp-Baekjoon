using System;

namespace 쉬운_계단_수
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            long[,] Map = new long[101, 10];


            for(int i = 1; i <= N; i++)
            {
                if (i == 1)
                {
                    Map[1, 0] = 0;
                    for (int j = 1; j <= 9; j++)
                    {
                        Map[i, j] = 1;
                    }
                }
                else
                {
                    for (int j = 0; j <= 9; j++)
                    {
                        if (j == 9)
                            Map[i, j] = Map[i - 1, j - 1]% 1000000000;
                        else if (j == 0)
                            Map[i, j] = Map[i - 1, j + 1] % 1000000000;
                        else
                            Map[i, j] = Map[i - 1, j - 1] % 1000000000 + Map[i - 1, j + 1] % 1000000000;
                    }
                }
            }
            long Sum = 0;
            for (int i = 0; i <= 9; i++)
                Sum += Map[N, i];
            Console.Write($"{Sum % 1000000000}");
        }
    }
}
