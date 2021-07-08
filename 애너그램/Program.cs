using System;
using System.Collections.Generic;
using System.Linq;

namespace 애너그램
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            bool[] Check = new bool[N];
            string[,] K = new string[N,2];
            for (int i = 0; i < N; i++)
            {
                var S = Console.ReadLine().Split(' ').Select(x => x).ToArray();
                K[i, 0] = S[0]; K[i, 1] = S[1];
                if (S[0].Length != S[1].Length)
                {
                    continue;
                }
                else
                {
                    List<char> list = new List<char>();
                    for (int j = 0; j < S[0].Length; j++)
                    {
                        list.Add(S[0][j]);
                    }
                    for (int j = 0; j < S[0].Length; j++)
                    {
                        if (list.Contains(S[1][j]))
                            list.Remove(S[1][j]);
                        else
                            continue;
                    }
                    if (list.Count == 0)
                    {
                        Check[i] = true;
                    }
                }
            }
            for (int i = 0; i < N; i++)
            {
                if(Check[i])
                    Console.WriteLine($"{K[i,0]} & {K[i,1]} are anagrams.");
                else
                    Console.WriteLine($"{K[i, 0]} & {K[i, 1]} are NOT anagrams.");
            }

        }
    }
}
