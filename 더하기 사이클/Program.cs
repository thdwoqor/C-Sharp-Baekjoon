using System;

namespace 더하기_사이클
{
    class Program
    {
        static void Solve(int N)
        {
            if (N == M && num>0) 
                return;
            
            int b;
            int c;
            if (N >= 10)
            {
                c = (N/10 + N%10)%10;
                b = (N%10) * 10 + c;
                num++;
                Solve(b);
            }
            else
            {
                b = N * 10 + N;
                num++;
                Solve(b);
            }
        }
        static int M;
        static int num = 0;
        static void Main(string[] args)
        {
            M = int.Parse(Console.ReadLine());
            Solve(M);
            Console.Write(num);

        }
    }
}
