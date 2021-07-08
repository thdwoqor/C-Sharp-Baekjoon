using System;
using System.Collections.Generic;
using System.Linq;

namespace 구슬_탈출_2
{
    class Program
    {
        public class Pos
        {
            public int x;
            public int y;
            public int x2;
            public int y2;
            public int d;

            public Pos(int x, int y , int x2, int y2, int d)
            {
                this.x = x;
                this.y = y;
                this.x2 = x2;
                this.y2 = y2;
                this.d = d;
            }
        }
        private static bool isValidPosition(int x, int y)
        {
            if (x < 0 || y < 0 || x >= N || y >= M) return false;
            return true;
        }

        static void BFS(Pos RB)
        {
            Queue<Pos> q = new Queue<Pos>();
            int[] xdir = { -1, 1, 0, 0 };
            int[] ydir = { 0, 0, -1, 1 };

            q.Enqueue(RB);

            bool[,,,] visit = new bool[N,M, N, M];

            while (!(q.Count == 0))
            {
                Pos p = q.Dequeue();
                int px = p.x;
                int py = p.y;

                int px2 = p.x2;
                int py2 = p.y2;

                visit[px, py, px2, py2] = true;

                int pd = p.d;

                if (pd == 10)
                {
                    Console.Write(-1);
                    return;
                }
                //Console.WriteLine($"{px} {py} {px2} {py2} *");

                for (int i = 0; i < 4; i++)
                {
                    int dx = px + xdir[i];
                    int dy = py + ydir[i];
                    int dd = 0;
                    while (true) //빨간공 이동
                    {
                        if (Map[dx, dy] == '#' )
                        {
                            dx = dx - xdir[i];
                            dy = dy - ydir[i];
                            break;
                        }
                        if (Map[dx,dy] == 'O')
                        {
                            break;
                        }
                        dx += xdir[i];
                        dy += ydir[i];
                        dd++;
                    }
                    
                    int dx2 = px2 + xdir[i];
                    int dy2 = py2 + ydir[i];
                    int dd2 = 0;
                    while (true) //파란공 이동
                    {
                        if (Map[dx2, dy2] == '#')
                        {
                            dx2 = dx2 - xdir[i];
                            dy2 = dy2 - ydir[i];
                            break;
                        }
                        if (Map[dx2, dy2] == 'O')
                        {
                            break;
                        }
                        dx2 += xdir[i];
                        dy2 += ydir[i];
                        dd2++;
                    }

                    

                    if (Map[dx2, dy2] == 'O')
                        continue;
                    if (Map[dx, dy] == 'O')
                    {
                        Console.Write(pd + 1);
                        return;
                    }

                    if(dx == dx2 && dy == dy2)
                    {
                        if (dd < dd2)
                        {
                            dx2 = dx2 - xdir[i];
                            dy2 = dy2 - ydir[i];
                        }
                        else
                        {
                            dx = dx - xdir[i];
                            dy = dy - ydir[i];
                        }
                    }
                    //Console.WriteLine($"{dx} {dy} {dx2} {dy2} **");
                    if (!visit[dx, dy, dx2, dy2])
                    {
                        //Console.WriteLine($"{dx} {dy} {dx2} {dy2} ***");
                        q.Enqueue(new Pos(dx, dy, dx2, dy2, pd + 1));
                    }
                }
            }
            Console.Write(-1);

        }

        static int N, M;
        static char[,] Map;
        static void Main(string[] args)
        {
            var S = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            N = S[0]; M = S[1];
            Map = new char[N, M];
            Pos RB=new Pos(0,0,0,0,0);
            
            for (int i = 0; i < N; i++)
            {
                var input = Console.ReadLine();
                for (int j = 0; j < M; j++)
                {
                    Map[i, j] = input[j];
                    if (Map[i, j] == 'R')
                    {
                        RB.x = i;
                        RB.y = j;
                    }
                    if (Map[i, j] == 'B')
                    {
                        RB.x2 = i;
                        RB.y2 = j;
                    }
                }
            }
            BFS(RB);

        }
    }
}
