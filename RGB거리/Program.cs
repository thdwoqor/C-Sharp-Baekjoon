using System;

namespace RGB거리
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[,] Map = new int[N, 3];
            int[,] Solve = new int[N, 3];

            for (int i = 0; i < N; i++)
            {
                string v = Console.ReadLine();
                string[] vv = v.Split(' ');
                int R = int.Parse(vv[0]);
                int G = int.Parse(vv[1]);
                int B = int.Parse(vv[2]);

                Map[i, 0] = R;
                Map[i, 1] = G;
                Map[i, 2] = B;
            }

            for (int i = 0; i < N; i++)
            {
                Solve[i, 0] += Map[i, 0];
                Solve[i, 1] += Map[i, 1];
                Solve[i, 2] += Map[i, 2];

                if (i == N - 1)
                    break;

                int Min = Math.Min(Solve[i, 0], Math.Min(Solve[i, 1], Solve[i, 2]));
                
                if (Solve[i, 0] == Min)
                {
                    Solve[i + 1, 0] = 1000001;
                    Solve[i + 1, 1] = Min;
                    Solve[i + 1, 2] = Min;
                }
                if (Solve[i, 1] == Min)
                {
                    Solve[i + 1, 0] = Min;
                    Solve[i + 1, 1] = 1000001;
                    Solve[i + 1, 2] = Min;
                }
                if (Solve[i, 2] == Min)
                {
                    Solve[i + 1, 0] = Min;
                    Solve[i + 1, 1] = Min;
                    Solve[i + 1, 2] = 1000001;
                }
            }
            /*
            Console.WriteLine($"");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"{Solve[i, 0]} {Solve[i, 1]} {Solve[i, 2]}");
            }
            */
            Console.WriteLine(Math.Min(Solve[N-1, 0], Math.Min(Solve[N - 1, 1], Solve[N - 1, 2])));

        }
    }
}
