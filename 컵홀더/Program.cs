using System;

namespace 컵홀더
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string M = Console.ReadLine();
            int S = 0;
            int L = 0;
            for(int i = 0; i < N; i++)
            {
                if (M[i] == 'S')
                    S++;
                else
                    L++;
            }
            if(S + L / 2 + 1<N)
                Console.Write(S+L/2+1);
            else
                Console.Write(N);
        }
    }
}
