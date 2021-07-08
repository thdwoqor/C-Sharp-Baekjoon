using System;

namespace 계단_수
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int N = int.Parse(Console.ReadLine());
            long[,,] Map = new long[101, 10 , 1024]; //2^10-1


            for (int i = 1; i <= N; i++)
            {
                if (i == 1)
                {
                    for (int j = 1; j <= 9; j++)
                    {
                        Map[i, j,1<<j] = 1;
                    }
                }
                else
                {
                    for (int j = 0; j <= 9; j++)
                    {
                        for (int k = 0; k < 1<<10; k++)
                        {
                            int bit = k | (1 << j);

                            Map[i, j, bit] += (0 < j ? Map[i - 1, j - 1, k] : 0) % 1000000000 + (j < 9 ? Map[i - 1, j + 1, k] : 0) % 1000000000;

                        }
                    }
                }
            }
            long Sum = 0;
            for (int i = 0; i <= 9; i++)
                Sum += Map[N, i,1023] % 1000000000;
            Console.Write($"{Sum % 1000000000}");
        }
    }
}
