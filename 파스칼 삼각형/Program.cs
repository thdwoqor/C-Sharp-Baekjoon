using System;
using System.Linq;

namespace 파스칼_삼각형
{
    class Program
    {
        static int combination(int n, int r)
        {
            if (n == r || r == 0)
                return 1;
            else
                return combination(n - 1, r - 1) + combination(n - 1, r);
        }

        static void Main(string[] args)
        {
            int[] S = Console.ReadLine().Trim().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            
            Console.Write($"{combination(S[0]-1, S[1]-1)}");
        }
    }
}
