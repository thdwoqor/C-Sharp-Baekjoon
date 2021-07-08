using System;
using System.Collections.Generic;

namespace 양
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
            if (x < 0 || y < 0 || x >= n || y >= m) return false;
            return true;
        }
        static void BFS(Pos STA)
        {
            Queue<Pos> q = new Queue<Pos>();
            int[] xdir = { -1, 1, 0, 0 };
            int[] ydir = { 0, 0, -1, 1 };

            q.Enqueue(STA);
            CH[STA.x, STA.y] = true;
            int v = 0;
            int o = 0;
            while (!(q.Count == 0))
            {
                Pos p = q.Dequeue();
                int px = p.x;
                int py = p.y;

                if (map[px, py] == 'v')
                    v++;
                else if (map[px, py] == 'o')
                    o++;

                for (int i = 0; i < 4; i++)
                {
                    int dx = px + xdir[i];
                    int dy = py + ydir[i];
                    // 유효한 위치 && 선택된 자리 && 방문하지 않은 자리
                    if (isValidPosition(dx, dy) && map[dx, dy] != '#' && !CH[dx, dy])
                    {
                        CH[dx, dy] = true;
                        q.Enqueue(new Pos(dx, dy));
                    }
                }
            }
            if (v >= o)
                wolf += v;
            else if (v < o)
                sheep += o;
            return;
        }



        static int n;
        static int m;
        static char[,] map;
        static bool[,] CH;
        static int sheep = 0;
        static int wolf = 0;
        static void Main(string[] args)
        {
            string v = Console.ReadLine();
            string[] vv = v.Split(' ');
            n = int.Parse(vv[0]);
            m = int.Parse(vv[1]);
            map = new char[n,m];
            CH = new bool[n, m];

            for (int i = 0; i < n; i++)
            {
                string k = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    map[i, j] = k[j];
                }
            }
            Pos STA;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (CH[i, j] == true || map[i, j] == '#')
                        continue;
                    STA=new Pos(i, j);
                    BFS(STA);
                }
            }
            Console.Write($"{sheep} {wolf}");
        }
    }
}
