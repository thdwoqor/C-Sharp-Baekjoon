using System;

namespace Hashing
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            ulong[] b = new ulong[a];
            ulong c = 0;
            ulong d = 1;
            for (int n = 0; n < a; n++)
            {
                b[n] = (ulong)(Console.Read() - 96);
            }
            for (int n = 0; n < a; n++)
            {
                c += ((b[n] % 1234567891) * (d))%1234567891;
                d = d*31%1234567891;
            }
            Console.WriteLine(c%1234567891);
        }
    }
}
