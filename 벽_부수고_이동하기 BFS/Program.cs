using System;
using System.Collections.Generic;
using System.Linq;

namespace 벽_부수고_이동하기_BFS
{
    class Program
    {
        public class Pos
        {
            public int x;
            public int y;
            public int depth;
            public bool Check;
            public Pos(int x, int y, int depth, bool Check)
            {
                this.x = x;
                this.y = y;
                this.depth = depth;
                this.Check = Check;

            }
        }
        private static bool isValidPosition(int x, int y)
        {
            if (x < 0 || y < 0 || x >= N || y >= M) return false;
            return true;
        }
        static void BFS(Pos S)
        {
            Queue<Pos> q = new Queue<Pos>();
            int[] xdir = { -1, 1, 0, 0 };
            int[] ydir = { 0, 0, -1, 1 };

            q.Enqueue(S);
            Check[S.x, S.y] = true;
            Check2[S.x, S.y] = true;
            while (!(q.Count == 0))
            {
                Pos p = q.Dequeue();
                int px = p.x;
                int py = p.y;
                int pdepth = p.depth;
                bool pCheck = p.Check;

                if(px == N - 1 && py == M - 1)
                {
                    if (solve > pdepth)
                        solve = pdepth;
                    return;
                }

                for (int i = 0; i < 4; i++)
                {
                    int dx = px + xdir[i];
                    int dy = py + ydir[i];

                    // 유효한 위치 && 선택된 자리 && 방문하지 않은 자리
                    if (isValidPosition(dx, dy)  && !Check[dx, dy] && !pCheck)
                    {
                        if (Map[dx, dy] == 1 && !pCheck)
                        {
                            Check2[dx, dy] = true;
                            q.Enqueue(new Pos(dx, dy, pdepth + 1,true));
                        }else if(Map[dx, dy] != 1)
                        {
                            Check[dx, dy] = true;
                            q.Enqueue(new Pos(dx, dy, pdepth + 1, pCheck));
                        }
                    }else if(isValidPosition(dx, dy) && !Check2[dx, dy] && pCheck && Map[dx, dy] != 1)
                    {
                        Check2[dx, dy] = true;
                        q.Enqueue(new Pos(dx, dy, pdepth + 1, pCheck));
                    }
                }
            }
            solve = -1;

        }

        static int solve = Int32.MaxValue;
        static int N, M;
        static int[,] Map;
        static bool[,] Check;
        static bool[,] Check2;
        static void Main(string[] args)
        {
            var S = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            N = S[0]; M = S[1];
            Map = new int[N, M];
            Check = new bool[N, M];
            Check2 = new bool[N, M];
            for (int i = 0; i < N; i++)
            {
                var T = Console.ReadLine();
                for (int j = 0; j < M; j++)
                {
                    Map[i, j] = int.Parse(T[j].ToString());
                }
            }

            bool Crack = false;

            BFS(new Pos(0, 0, 1,false));

            if (solve == Int32.MaxValue)
                Console.Write($"-1");
            else
                Console.Write($"{solve}");
        }
    }
}
