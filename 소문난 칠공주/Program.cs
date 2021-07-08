using System;
using System.Collections.Generic;

namespace 소문난_칠공주
{
    class Program
    {
        static int[] Arr=new int[25];
        static bool[] Select=new bool[25];

        static int cnt = 0;
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
        static void Print()
        {
            Queue<Pos> q = new Queue<Pos>();
            int[] xdir = { -1, 1, 0, 0 };
            int[] ydir = { 0, 0, -1, 1 };
            bool[,] visited = new bool[5,5];
            int[,] map = new int[5,5];
            int x = 0;
            int y = 0;
            int fx = 0;
            int fy = 0;
            int frist = 0;
            int sum = 0;
            for (int i = 0; i < 25; i++)
            {
                x = i / 5;
                y = i % 5;
                if (Select[i] == true)
                {
                    sum += Arr[i];
                    if (frist == 0)
                    {
                        fx = i / 5;
                        fy = i % 5;
                        frist++;
                    }
                    map[x, y] = 1;
                }
                else
                    map[x, y] = 0;
            }
            if (sum < 4)
                return;
            /*
            if (map[1, 0] == 1 && map[1, 1] == 1 && map[1, 2] == 1 && map[1, 3] == 1 && map[1, 4] == 1)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write($"{map[i, j]} ");
                    }
                    Console.WriteLine($"");
                }
                Console.WriteLine($"");
                Console.WriteLine($"{fx} {fy}");
                Console.WriteLine($"");
            }
            */

            q.Enqueue(new Pos(fx, fy));
            visited[fx, fy] = true;
            int num = 1;

            while (!(q.Count==0))
            {
                Pos p=q.Dequeue();
                int px = p.x;
                int py = p.y;
                for (int i = 0; i < 4; i++)
                {
                    int dx = px + xdir[i];
                    int dy = py + ydir[i];
                    // 유효한 위치 && 선택된 자리 && 방문하지 않은 자리
                    if (isValidPosition(dx, dy) && map[dx,dy] == 1 && !visited[dx,dy])
                    {
                        q.Enqueue(new Pos(dx, dy));
                        visited[dx,dy] = true;
                        num++;
                    }
                }
            }
            if (num == 7)
                cnt++;
        }
        private static bool isValidPosition(int x, int y)
        {
            if (x < 0 || y < 0 || x >= 5 || y >= 5) return false;
            return true;
        }
        static void DFS(int Idx, int Cnt)
        {
            if (Cnt == 7)
            {
                Print();
                return;
            }

            for (int i = Idx; i < 25; i++)
            {
                if (Select[i] == true) continue;
                Select[i] = true;

                DFS(i, Cnt + 1);
                Select[i] = false;
            }
        }
        static void Main(string[] args)
        {
            for(int n = 0; n < 25; n++)
            {
                Arr[n] = 0;
            }
            Arr[5] = 1;
            Arr[7] = 1;
            Arr[9] = 1;
            Arr[16] = 1;
            Arr[19] = 1;

            DFS(0, 0);

            Console.WriteLine(cnt);
        }
    }
}
