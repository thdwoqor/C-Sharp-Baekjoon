using System;
using System.Linq;

namespace 벽_부수고_이동하기
{
    class Program
    {
        public class Pos
        {
            public int x;
            public int y;
            public int depth;
            public Pos(int x, int y, int depth)
            {
                this.x = x;
                this.y = y;
                this.depth = depth;
            }
        }
        private static bool isValidPosition(int x, int y)
        {
            if (x < 0 || y < 0 || x >= N || y >= M) return false;
            return true;
        }
        static void DFS(Pos C ,bool Crack, bool[,] Check)
        {
            if(C.x==N-1&& C.y == M - 1)
            {
                if (solve > C.depth)
                    solve = C.depth;
                return;
            }

            int[] xdir = { -1, 1, 0, 0 };
            int[] ydir = { 0, 0, -1, 1 };

            bool[,] CC = (bool[,])Check.Clone();
            CC[C.x, C.y] = true;

                for (int i = 0; i < 4; i++)
                {
                    int dx = C.x + xdir[i];
                    int dy = C.y + ydir[i];

                    // 유효한 위치 && 선택된 자리 && 방문하지 않은 자리
                    if (isValidPosition(dx, dy) && Map[dx, dy] != 1 && !CC[dx, dy])
                    {
                        DFS(new Pos(dx, dy, C.depth+1), Crack, CC);
                    }
                    if (isValidPosition(dx, dy) && Map[dx, dy] == 1 && !Crack && !CC[dx, dy])
                    {
                        Crack = true;
                        DFS(new Pos(dx, dy, C.depth + 1), Crack, CC);
                        Crack = false;
                    }
            }
        }

        static int solve = Int32.MaxValue;
        static int N, M;
        static int[,] Map;
        static void Main(string[] args)
        {
            var S = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            N = S[0]; M = S[1];
            Map = new int[N, M];
            bool[,] Check = new bool[N, M];

            for (int i = 0; i < N; i++)
            {
                var T = Console.ReadLine();
                for(int j = 0; j < M; j++)
                {
                    Map[i, j] = int.Parse(T[j].ToString());
                }
            }

            bool Crack = false;

            DFS(new Pos(0, 0, 1), Crack, Check);

            if(solve== Int32.MaxValue)
                Console.Write($"-1");
            else
                Console.Write($"{solve}");
        }
    }
}
