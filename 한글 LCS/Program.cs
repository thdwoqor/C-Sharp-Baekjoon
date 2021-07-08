using System;

namespace 한글_LCS
{
    class Program
    {
        static void Main(string[] args)
        {
            string A = Console.ReadLine();
            string B = Console.ReadLine();

            int[,] LCS = new int[A.Length + 1, B.Length + 1];

            for (int i = 1; i <= A.Length; i++)
            {
                for (int j = 1; j <= B.Length; j++)
                {
                    
                        if (A[i - 1] == B[j - 1] )
                        {
                            LCS[i, j] = LCS[i - 1, j - 1] + 1;
                        }
                        else
                        {
                            LCS[i, j] = Math.Max(LCS[i, j - 1], LCS[i - 1, j]);
                        }
                }
            }

            Console.Write(LCS[A.Length, B.Length]);
            
        }
    }
}
