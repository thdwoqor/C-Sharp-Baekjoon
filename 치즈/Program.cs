using System;
using System.Collections.Generic;

namespace 치즈
{
    class Program
    {
        public class Pos
        {
            public int x;
            public int y;
            public Pos(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        private static bool isValidPosition(int x, int y)
        {
            if (x < 0 || y < 0 || x >= N || y >= M) return false;
            return true;
        }
        private static bool cheese(int x, int y)
        {
            if (x < 0 || y < 0 || x >= N || y >= M) return false;
            else if (Map[x, y] == 9) return true;
            else return false;
        }
        static void BFS()
        {
            bool[,] Check=new bool[N,M];
            Queue<Pos> q = new Queue<Pos>();
            int[] xdir = { -1, 1, 0, 0 };
            int[] ydir = { 0, 0, -1, 1 };

            q.Enqueue(new Pos(0,0));

            Check[0, 0] = true;
            Map[0, 0] = 9;
            while (!(q.Count == 0))
            {
                Pos p = q.Dequeue();
                int px = p.x;
                int py = p.y;

                for (int i = 0; i < 4; i++)
                {
                    int dx = px + xdir[i];
                    int dy = py + ydir[i];
                    // 유효한 위치 && 선택된 자리 && 방문하지 않은 자리
                    if (isValidPosition(dx, dy) && Map[dx, dy] != 1 && !Check[dx, dy])
                    {
                        Check[dx, dy] = true;
                        Map[dx, dy] = 9;
                        q.Enqueue(new Pos(dx, dy));
                    }
                }
            }

            Check = new bool[N, M];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if(Map[i, j] == 1)
                    {
                        int sum = 0;
                        for (int k = 0; k < 4; k++)
                        {
                            int dx = i + xdir[k];
                            int dy = j + ydir[k];
                            if (cheese(dx, dy))
                                sum++;
                        }
                        if (sum >= 2)
                            Check[i, j] = true;
                    }
                }
            }
            bool C = false;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (Map[i, j] == 9)
                        Map[i, j] = 0;
                    if (Check[i, j] == true && Map[i, j] == 1)
                    {
                        Map[i, j] = 0;
                        C = true;
                    }
                }
            }
            if (C == false)
                return;
            else
            {
                SS++;
                BFS();
            }
        }
        static int SS = 0;
        static int N;
        static int M;
        static int[,] Map;
        static void Main(string[] args)
        {
            string v = Console.ReadLine();
            string[] vv = v.Split(' ');
            N = int.Parse(vv[0]);
            M = int.Parse(vv[1]);

            Map = new int[N , M];

            for (int i = 0; i < N; i++)
            {
                string k = Console.ReadLine();
                string[] kk = k.Split(' ');
                for (int j = 0; j < M; j++)
                {
                    Map[i, j] = int.Parse(kk[j]);
                }
            }

            BFS();

            /*
            Console.WriteLine($"");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write($"{Map[i, j]} ");
                }
                Console.WriteLine($"");
            }
            */

            Console.Write(SS);
        }
    }
}
