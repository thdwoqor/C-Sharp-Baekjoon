using System;

namespace 설탕_배달
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[] NN = new int[5001];
            NN[0] = -1;
            NN[1] = -1;
            NN[2] = -1;
            NN[3] = 1;
            NN[4] = -1;
            NN[5] = 1;
            int Max = 99999;
            for(int K = 6; K <=N; K++)
            {
                for(int J = 1;J<=K-J;J++)
                {
                    if (Max > NN[J] + NN[K - J]&& NN[J] >0 && NN[K - J]>0)
                        Max = NN[J] + NN[K - J];
                }
                NN[K] = Max;
                if (Max == 99999)
                    NN[K] = -1;
                Max = 99999;
            }
                Console.Write(NN[N]);
        }
    }
}
