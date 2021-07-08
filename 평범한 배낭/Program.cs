using System;

namespace 평범한_배낭
{
    class Program
    {
        static void Main(string[] args)
        {
            string v = Console.ReadLine();
            string[] vv = v.Split(' ');
            int N = int.Parse(vv[0]);
            int K = int.Parse(vv[1]);

            int[] W = new int[N];
            int[] V = new int[N];

            for(int i=0;i<N;i++)
            {
                v = Console.ReadLine();
                vv = v.Split(' ');
                W[i] = int.Parse(vv[0]);
                V[i] = int.Parse(vv[1]);
            }



            int[,] Map = new int[N+1, K+1];
            int max = 0;
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= K; j++)
                {
                    if (W[i - 1] <= j)
                        Map[i,j] = Math.Max(V[i - 1] + Map[i - 1,j - W[i - 1]], Map[i - 1,j]);
                    else
                        Map[i,j] = Map[i - 1,j];
                    max = Math.Max(Map[i,j], max);
                }
            }

            Console.Write(max);
        }
    }
}
