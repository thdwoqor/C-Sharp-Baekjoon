using System;

namespace 완전제곱수
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
           
            int sum = 0;
            int f = 0;
            bool ch =false;
            for(int k=0;k * k <= N;k++)
            {
                if (M <= k * k)
                {
                    sum += k * k;
                    if (!ch)
                    {
                        f = k * k;
                        ch = true;
                    }
                }
            }
            if (sum == 0)
            {
                sum = -1;
                Console.Write(sum);
            }
            else
            {
                Console.WriteLine(sum);
                Console.Write(f);

            }
        }
    }
}
