using System;
using System.Text;

namespace 별_찍기___10
{
    class Program
    {
        static void Solve(int N,int M)
        {
            if (N == M)
                return;
            for(int i = M;i<N;i++)
            {
                for (int j = M; j < N; j++)
                {
                    if((i/M) % 3 == 1 && (j / M) % 3 == 1)
                        Map[i, j] = 1;
                }
            }
            Solve(N, M*3);
        }
        static int[,] Map;
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Map = new int[N, N];
            Solve(N,1);

            for (int i = 0; i < N ; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < N; j++)
                {
                    if(Map[i, j]==0)
                        sb.Append('*');
                    else
                        sb.Append(' ');
                }
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
