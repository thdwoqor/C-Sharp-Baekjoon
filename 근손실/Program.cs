using System;

namespace 근손실
{
    class Program
    {
        static void Solve(bool[] ch,int[] save,int n)
        {
            if (n == N)
            {
                int kg = 500;

                for (int i = 0; i < N; i++)
                {
                    kg = kg - K;
                    kg = kg + save[i];
                    if (kg < 500)
                        return;
                }
                sum++;
                /*
                for (int i=0;i<N;i++)
                    Console.Write($"{save[i]} ");
                Console.WriteLine("");
                */
                return;
            }
            for (int i = 0; i < N; i++)
            {
                int[] savec= (int[])save.Clone();
                bool[] chc = (bool[])ch.Clone(); 
                if (chc[i] == true)
                {
                    continue;
                }
                else
                {
                    savec[n] = Kit[i];
                    chc[i] = true;
                    Solve(chc, savec, n + 1);
                } 
            }
            return;
        }
        static int[] Kit;
        static int N;
        static int K;
        static int sum=0;
        static void Main(string[] args)
        {
            string S = Console.ReadLine();
            string[] SS = S.Split(' ');
            N = int.Parse(SS[0]);
            K = int.Parse(SS[1]);

            S = Console.ReadLine();
            SS = S.Split(' ');
            Kit = new int[N];
            for (int i = 0; i < N; i++)
            {
                Kit[i] = int.Parse(SS[i]);
            }
          
            Solve(new bool[N], new int[N], 0);

            Console.Write(sum);
        }
    }
}
