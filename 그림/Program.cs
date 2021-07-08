using System;
using System.Collections.Generic;
using System.Linq;

namespace 그림
{
    class Program
    {
        class Pos
        {
            public int x,y,d;
            public Pos(int x,int y,int d)
            {
                this.x = x;
                this.y = y;
                this.d = d;
            }
        }

        static void BFS(Pos n)
        {
            int[] xdir = { -1, 1, 0, 0 };
            int[] ydir = { 0, 0, -1, 1 };
            Queue<Pos> q = new Queue<Pos>();
            q.Enqueue(n);
            Check[n.x, n.y] = true;
            sum = 1;
            while (!(q.Count == 0))
            {
                Pos p = q.Dequeue();
                int pd = p.d;
                for (int i = 0; i < 4; i++)
                {
                    int px = p.x + xdir[i];
                    int py = p.y + ydir[i];
                    if (px < 0 || py < 0 || px >= N || py >= M)
                        continue;
                    if (!Check[px, py] && Map[px, py] == 1)
                    {
                        Check[px, py] = true;
                        sum++;
                        q.Enqueue(new Pos(px, py,pd+1));
                    }
                }
            }

        }
        static int[,] Map;
        static bool[,] Check;
        static int N, M;
        static int sum;
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
            N = input[0]; M = input[1];
            Map = new int[N, M];
            Check = new bool[N, M];
            for (int i = 0; i < N; i++)
            {
                input = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
                for(int j = 0; j < M; j++)
                {
                    Map[i, j] = input[j];
                }
            }
            int max = 0;
            int time = 0;
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < M; j++)
                {
                    if(Map[i,j]==1&& !Check[i, j])
                    {
                        BFS(new Pos(i, j, 1));
                        time++;
                        max=Math.Max(max, sum);
                    }
                }
            }
            Console.Write($"{time}\n{max}");
        }
    }
}
