using System;

namespace 다리_놓기
{
    class Program
    {
        
        private static ulong c(ulong x, ulong y)
        {
            ulong num = 1, denom = 1;
            ulong i;
            if (y > x - y)
                y = x - y;
            for (i = 0; i < y; ++i)
            {
                num *= (x - i);
                denom *= (y - i);
            }
            return num / denom;
        }
        static void Main(string[] args)
        {

            int Num = int.Parse(Console.ReadLine());
            int[,] N = new int[Num, 2];
            for (int n = 0; n < Num; n++)
            {
                string K = Console.ReadLine();
                string[] KK = K.Split(' ');
                N[n, 0] = int.Parse(KK[0]);
                N[n, 1] = int.Parse(KK[1]);
            }
            for (int n = 0; n < Num; n++)
            {
                Console.WriteLine(c((ulong)N[n, 1], (ulong)N[n, 0]));
            }
        }
    }
}
