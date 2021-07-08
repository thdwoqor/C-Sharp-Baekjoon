using System;

namespace 다이나믹이_뭐예요
{
    class Program
    {
        static int N, M;
        static ulong[,] Map;
        static ulong Solve(int A, int B)
        {
            if (A <= 1 || B <= 1)
            {
                Map[A, B] = 1;
                return Map[A, B];
            }
                

            if(Map[A, B]!=0) return Map[A,B] % 1000000007;

            Map[A, B]= ((Solve(A - 1, B) % 1000000007) + (Solve(A, B - 1) % 1000000007) + (Solve(A - 1, B - 1) % 1000000007)) % 1000000007;
            return Map[A, B] % 1000000007;
                
        }

        static void Main(string[] args)
        {
            string v = Console.ReadLine();
            string[] vv = v.Split(' ');
            N = int.Parse(vv[0]);
            M = int.Parse(vv[1]);
            Map = new ulong[1001, 1001];

            ulong S = Solve(N, M);

            Console.Write(S);
        }
    }
}
