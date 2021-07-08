using System;
using System.Collections.Generic;

namespace 탈출
{
    class Program
    {
        public class Pos
        {
            public int x;
            public int y;
            public int depth;
            public Pos(int x, int y,int depth)
            {
                this.x = x;
                this.y = y;
                this.depth = depth;
        }
        }
        
        static void BFS(Queue<Pos> W)
        {
            //Queue<Pos> q = new Queue<Pos>();
            int[] xdir = { -1, 1, 0, 0 };
            int[] ydir = { 0, 0, -1, 1 };

            W.Enqueue(S);
            
            while (!(W.Count == 0))
            {
                Pos p = W.Dequeue();
                int px = p.x;
                int py = p.y;
                int pdepth = p.depth;

                for (int i = 0; i < 4; i++)
                {
                    int dx = px + xdir[i];
                    int dy = py + ydir[i];

                    // 유효한 위치 && 선택된 자리 && 방문하지 않은 자리
                    if (isValidPosition(dx, dy) && Map[dx, dy] != 'X' && !Check[dx, dy])
                    {

                        if (Map[px, py] == '*')
                        {
                            if (Map[dx, dy] == 'D')
                            {
                                continue;
                            }
                            Map[dx, dy] = '*';
                        }
                        if (Map[px, py] == 'S')
                        {
                            if (Map[dx, dy] == 'D')
                            {
                                Console.Write(pdepth + 1);
                                return;
                            }
                            Map[dx, dy] = 'S';
                        }
                        Check[dx, dy] = true;
                        W.Enqueue(new Pos(dx, dy, pdepth+1));
                    }
                }
            }

            Console.Write("KAKTUS");
            return;
        }

        private static bool isValidPosition(int x, int y)
        {
            if (x < 0 || y < 0 || x >= N || y >= M) return false;
            return true;
        }

        static int N, M;
        static char[,] Map;
        static bool[,] Check;
        static Pos S;
        //static Queue<Pos> Water = new Queue<Pos> ();

      
        static void Main(string[] args)
        {

            Queue<Pos> Water = new Queue<Pos>();

            string v = Console.ReadLine();
            string[] vv = v.Split(' ');
            N = int.Parse(vv[0]);
            M = int.Parse(vv[1]);

            Map=new char[N,M];
            Check = new bool[N, M];

            for (int i = 0; i < N; i++)
            {
                v = Console.ReadLine();
                for (int j = 0; j < M; j++)
                {
                    Map[i, j] = v[j];
                    if (Map[i, j] == 'S')
                    {
                        S = new Pos(i, j, 0);
                        Check[i, j] = true;
                    }
                    if (Map[i, j] == '*')
                    {
                        Water.Enqueue(new Pos(i, j, 0));
                        Check[i, j] = true;
                    }
                }
            }

            BFS(Water);


            /*
            Console.WriteLine($"");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write($"{Map[i, j]}");
                }
                Console.WriteLine($"");
            }
            */
        }
    }
}
