using System;
using System.Collections.Generic;

namespace 감시
{
    class Program
    {
        public class Pos
        {
            public int x;
            public int y;
            public int lv;
            public Pos(int x, int y,int lv)
            {
                this.x = x;
                this.y = y;
                this.lv = lv;
            }
        }
        private static bool isValidPosition(int x, int y)
        {
            if (x < 0 || y < 0 || x >= n || y >= m) return false;
            if(map[x,y]==6) return false;
            return true;
        }

        private static void solve(int[,] Map, int current)
        {
            if (cctv.Count == current)
            {
                int CH = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (Map[i, j] == 0)
                            CH++;
                    }
                }
                if (CH < sum)
                    sum = CH;
                return;
            }

            if (cctv[current].lv == 1)
            {
                int[] xdir = { -1, 0, 1, 0 };
                int[] ydir = { 0, 1,  0, -1 };
                for (int i = 0; i < 4; i++)
                {
                    int[,] Save= (int[,])Map.Clone();
                    
                    int x = cctv[current].x + xdir[i];
                    int y = cctv[current].y + ydir[i];
                    while (isValidPosition(x, y))
                    {
                        if (Save[x, y] == 0)
                            Save[x, y] = 9;
                        x += xdir[i];
                        y += ydir[i];
                    }
                    solve(Save,current+1);
                }
            }

            if (cctv[current].lv == 2)
            {
                int[] xdir = { 0, 0, 1, -1 };
                int[] ydir = { -1, 1, 0, 0 };
                for (int i = 0; i < 4;)
                {
                    int[,] Save = (int[,])Map.Clone();
                    for(int j = 0; j < 2; j++)
                    {
                        int x = cctv[current].x + xdir[i];
                        int y = cctv[current].y + ydir[i];
                        while (isValidPosition(x, y))
                        {
                            if (Save[x, y] == 0)
                                Save[x, y] = 9;
                            x += xdir[i];
                            y += ydir[i];
                        }
                        i++;
                    }
                    solve(Save, current + 1);
                }
            }

            if (cctv[current].lv == 3)
            {
                int[] xdir = { -1, 0, 0, 1, 1,  0,  0, -1 };
                int[] ydir = { 0,  1, 1, 0, 0, -1, -1, 0 };
                for (int i = 0; i < 8;)
                {
                    int[,] Save = (int[,])Map.Clone();
                    for(int j = 0; j < 2; j++)
                    {
                        int x = cctv[current].x + xdir[i];
                        int y = cctv[current].y + ydir[i];
                        while (isValidPosition(x, y))
                        {
                            if (Save[x, y] == 0)
                                Save[x, y] = 9;
                            x += xdir[i];
                            y += ydir[i];
                        }
                        i++;
                    }
                    solve(Save, current + 1);
                }
            }

            if (cctv[current].lv == 4)
            {
                int[] xdir = { -1, 0, 0, -1, 0, 1, 1, 0,  0, -1,  0, 1 };
                int[] ydir = { 0, 1, -1,  0, 1, 0, 0, 1, -1,  0, -1, 0 };
                for (int i = 0; i < 12;)
                {
                    int[,] Save = (int[,])Map.Clone();
                    for(int j = 0; j < 3; j++)
                    {
                        int x = cctv[current].x + xdir[i];
                        int y = cctv[current].y + ydir[i];
                        while (isValidPosition(x, y))
                        {
                            if (Save[x, y] == 0)
                                Save[x, y] = 9;
                            x += xdir[i];
                            y += ydir[i];
                        }
                        i++;
                    }
                    solve(Save, current + 1);
                }
            }

            if (cctv[current].lv == 5)
            {
                int[] xdir = { -1, 0, 1, 0 };
                int[] ydir = { 0, 1, 0, -1 };
                int[,] Save = (int[,])Map.Clone();
                for (int i = 0; i < 4; i++)
                {
                    int x = cctv[current].x + xdir[i];
                    int y = cctv[current].y + ydir[i];
                    while (isValidPosition(x, y))
                    {
                        if (Save[x, y] == 0)
                            Save[x, y] = 9;
                        x += xdir[i];
                        y += ydir[i];
                    }
                }
                solve(Save, current + 1);
            }
            return;
        }
        static int sum = 9999;
        static int n;
        static int m;
        static int[,] map;
        static List<Pos> cctv = new List<Pos>();
        static void Main(string[] args)
        {
            string v = Console.ReadLine();
            string[] vv = v.Split(' ');
            n = int.Parse(vv[0]);
            m = int.Parse(vv[1]);
            map = new int[n, m];

            for(int i=0;i<n;i++)
            {
                string k = Console.ReadLine();
                string[] kk = k.Split(' ');
                for (int j = 0; j < m; j++)
                {
                    map[i, j] = int.Parse(kk[j]);
                    if(map[i, j]>0&& map[i, j] < 6)
                        cctv.Add(new Pos(i, j, map[i, j]));
                }
            }

            solve(map,0);
            Console.Write(sum);

            /*
            Console.WriteLine("");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{Map[i, j]} ");
                }
                Console.WriteLine("");
            }
            */
        }
    }
}
