using System;

namespace RGB거리_2
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

            for (int i = 0; i < N-1; i++)
            {
                int R = 1000001;
                int G = 1000001;
                int B = 1000001;
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                    {
                        if (G > Map[i + 1, 1] + Map[i, j])
                            G = Map[i + 1, 1] + Map[i, j];
                        if (B > Map[i + 1, 2] + Map[i, j])
                            B = Map[i + 1, 2] + Map[i, j];
                    }
                    if (j == 1)
                    {
                        if (R > Map[i + 1, 0] + Map[i, j])
                            R = Map[i + 1, 0] + Map[i, j];
                        if (B > Map[i + 1, 2] + Map[i, j])
                            B = Map[i + 1, 2] + Map[i, j];
                    }
                    if (j == 2)
                    {
                        if (R > Map[i + 1, 0] + Map[i, j])
                            R = Map[i + 1, 0] + Map[i, j];
                        if (G > Map[i + 1, 1] + Map[i, j])
                            G = Map[i + 1, 1] + Map[i, j];
                    }
                }
                Map[i + 1, 0] = R;
                Map[i + 1, 1] = G;
                Map[i + 1, 2] = B;

            }

            Console.Write(Math.Min(Map[N - 1, 0], Math.Min(Map[N - 1, 1], Map[N - 1, 2])));

        }
    }
}
