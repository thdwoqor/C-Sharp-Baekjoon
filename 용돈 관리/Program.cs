using System;

namespace 용돈_관리
{
    class Program
    {
        static void Solve(int A,int B)
        {
            
            if (A > B)
            {
                Console.Write($"{Save}");
                return;
            }
                

            int Money = (A + B) / 2;
            int Count = 1;

            for(int i = 0; i < N; i++)
            {
                if (Money - Day[i] < 0)
                {
                    Money = (A + B) / 2;
                    Count++;
                    Money -= Day[i];
                }
                else
                {
                    Money -= Day[i];
                }
            }
            if (Count > M)
            {
                Solve((A + B) / 2 + 1, B);
            }
            else
            {
                Save = (A + B) / 2;
                Solve(A, (A + B) / 2 - 1);
            }

        }
        static int Save = 0;
        static int Max = 0;
        static int N,M;
        static int[] Day;
        static void Main(string[] args)
        {
            string v = Console.ReadLine();
            string[] vv = v.Split(' ');
            N = int.Parse(vv[0]);
            M = int.Parse(vv[1]);

            Day = new int[N];
            for(int i = 0; i < N; i++)
            {
                Day[i] = int.Parse(Console.ReadLine());
                if (Day[i] > Max)
                    Max = Day[i];
            }

            Solve(Max, 1000000000);
        }
    }
}
