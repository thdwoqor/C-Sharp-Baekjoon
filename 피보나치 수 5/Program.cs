using System;

namespace 피보나치_수_5
{
    class Program
    {
        static void Solve(ulong S,ulong E)
        {
            if (S > E)
                return;
            P[S] = P[S - 1] + P[S - 2];
            Solve(S + 1, E);
        }
        static ulong[] P;
        static void Main(string[] args)
        {
            ulong N = ulong.Parse(Console.ReadLine());
            P = new ulong[91];
            P[0] = 0;
            P[1] = 1;
            Solve(2, N);
            Console.Write(P[N]);
        }
    }
}
