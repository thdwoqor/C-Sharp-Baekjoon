using System;
using System.Linq;

namespace 사이클_게임
{
    class Program
    {
        static int getParent(int x)
        {
            if (Arr[x] == x) return x;
            return Arr[x] = getParent(Arr[x]);
        }
        static void unionParent(int a, int b)
        {
            a = getParent(a);
            b = getParent(b);
            if (a < b) Arr[b] = a;
            else Arr[a] = b;
        }

        static int[] Arr;
        static void Main(string[] args)
        {
            int[] S = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
            int N = S[0]; int M = S[1];
            Arr = new int[N];
            for (int i = 0; i < N; i++)
                Arr[i] = i;

            bool Z = false;

            for (int i = 0; i < M; i++)
            {
                S = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();

                if (getParent(S[1]) == getParent(S[0]))
                {
                    Z = true;
                    Console.Write($"{i + 1}");
                    break;
                }
                unionParent(S[0], S[1]);
            }
            if(!Z)
                Console.Write($"{0}");
        }
    }
}
