using System;
using System.Linq;

namespace 발전소_1
{
    class Program
    {
        static int P, N, Y;
        static int[] Solve;
        static int[,] Map;
        static void Main(string[] args)
        {
            //Console.WriteLine($"{(1 << 3) - (1 << (3 - 2))}");

            N = int.Parse(Console.ReadLine());
            Map = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                for (int j = 0; j < N; j++)
                {
                    Map[i, j] = input[j];
                }
            }
            string bit = Console.ReadLine();
            Y = 0;
            int start = 0;
            for (int i = 0; i < N; i++)
            {
                if ((bit[i] == 'Y'))
                {
                    start += 1 << i; //켜져있는 발전소
                    Y++;
                }
            }
            P = int.Parse(Console.ReadLine());

            Solve = Enumerable.Repeat<int>(-1, 1 << N).ToArray<int>(); //비용 최소값 배열

            Solve[start] = 0;

            for(int i = 0; i < (1 << N); i++)
            {
                if (Solve[i] == -1) continue; //초기값을 찾는다.
                for(int j = 0; j < N; j++)
                {
                    if ((i & (1 << j)) == 0) continue; //고장나지 않은 발전소를 찾는다.
                        
                    for(int k = 0; k < N; k++)
                    {
                        if (k == j) continue;

                        Solve[i | (1 << k)] = Solve[i | (1 << k)]>-1? Math.Min(Solve[i | (1 << k)],Solve[i] + Map[j,k]): Solve[i] + Map[j, k];
                    }
                }
            }

            /*
            int ans = -1;
            for (int i = 0; i < (1 << N); i++)
            {
                if (Solve[i] == -1) continue;
                int count = 0;
                for (int j = 0; j < N; j++)
                {
                    if ((i & (1 << j))!=0) count++;
                }
                if (count >= P)
                {
                    if (ans == -1 || ans > Solve[i]) ans = Solve[i]; // ans를 -1로 했기 때문에 처음에 scope들어오기 위해 조건 추가
                }
            }

            Console.Write($"{ans}");
            */


        }
    }
}
