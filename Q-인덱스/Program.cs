using System;
using System.Linq;

namespace Q_인덱스
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            var Q = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            Array.Sort(Q);
            int Solve=0;
            for(int K = N; K >= 0; K--)
            {
                int U = 0;
                int D = 0;
                foreach(int j in Q)
                {
                    if (j == K)
                    {
                        U++;
                        D++;
                    }
                    else if (j < K)
                        D++;
                    else
                        U++;
                }
                if (U >= K&& N-K<=D) 
                {
                    Solve = K;
                }
            }
                Console.Write(Solve);
        }
    }
}
