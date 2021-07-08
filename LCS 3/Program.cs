using System;
using System.Collections.Generic;

namespace LCS_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string A = Console.ReadLine();
            string B = Console.ReadLine();
            string C = Console.ReadLine();
            int[,,] LCS = new int[A.Length + 1, B.Length + 1, C.Length + 1];
            
            for (int i = 1; i <= A.Length; i++)
            {
                for (int j = 1; j <= B.Length; j++)
                {
                    for (int k = 1; k <= C.Length; k++)
                    {
                        if (A[i - 1] == B[j - 1]&& A[i - 1] == C[k - 1])
                        {
                            LCS[i, j,k] = LCS[i - 1, j - 1,k-1] + 1;
                        }
                        else
                        {
                           
                            LCS[i, j,k] = Math.Max(LCS[i, j - 1,k], Math.Max(LCS[i-1, j, k], LCS[i, j, k - 1]));
                        }
                    }
                }
            }

            Console.Write(LCS[A.Length, B.Length, C.Length]);

        }
    }
}
