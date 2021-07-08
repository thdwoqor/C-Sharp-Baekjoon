using System;

namespace 미세먼지_안녕_
{
    class Program
    {
        static int R,C,T;
        static int[,] Map, Map2;
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
            if (x < 0 || y < 0 || x >= R || y >= C) return false;
            return true;
        }
        static void Main(string[] args)
        {
            int[] xdir = { -1, 1, 0, 0 };
            int[] ydir = { 0, 0, -1, 1 };

            string v = Console.ReadLine();
            string[] vv = v.Split(' ');
            R = int.Parse(vv[0]);
            C = int.Parse(vv[1]);
            T = int.Parse(vv[2]);
            Map = new int[R, C];
            
            Pos[] Air=new Pos[2];
            int AirC = 0;
            for(int i = 0; i < R; i++)
            {
                string w = Console.ReadLine();
                string[] ww = w.Split(' ');
                for (int j = 0; j < C; j++)
                {
                    Map[i, j] = int.Parse(ww[j]);
                    if(Map[i, j] == -1)
                    {
                        Air[AirC] = new Pos(i, j);
                        AirC++;
                    }
                }
            }
            
            for (int RE = 0; RE < T; RE++)
            {
                Map2 = new int[R, C];
                for (int i = 0; i < R; i++)
                {
                    for (int j = 0; j < C; j++)
                    {
                        if (Map[i, j] == 0 || Map[i, j] == -1)
                            continue;
                        else
                        {
                            int CH = 0;
                            for (int k = 0; k < 4; k++)
                            {
                                int dx = i + xdir[k];
                                int dy = j + ydir[k];
                                // 유효한 위치 && 선택된 자리 && 방문하지 않은 자리
                                if (isValidPosition(dx, dy) && Map[dx, dy] != -1)
                                {
                                    CH++;
                                    Map2[dx, dy] += Map[i, j] / 5;
                                }
                            }
                            Map[i, j] -= (Map[i, j] / 5) * CH;
                        }
                    }
                }
                for (int i = 0; i < R; i++)
                {
                    for (int j = 0; j < C; j++)
                    {
                        if (Map2[i, j] == 0 || Map[i, j] == -1)
                            continue;
                        else
                            Map[i, j] += Map2[i, j];
                    }
                }

                int[] xdir1 = { 0, -1, 0, 1, 0, 1, 0, -1 };
                int[] ydir1 = { 1, 0, -1, 0, 1, 0, -1, 0 };
                int c = 0;

                for (int i = 0; i < 2; i++)
                {
                    int sx = Air[i].x;
                    int sy = Air[i].y + 1;
                    while (true)
                    {
                        if (isValidPosition(sx + xdir1[c], sy + ydir1[c]))
                        {
                            //Console.WriteLine($"{sx} {sy}");
                            int save = Map[Air[i].x, Air[i].y + 1];
                            Map[Air[i].x, Air[i].y + 1] = Map[sx + xdir1[c], sy + ydir1[c]];
                            Map[sx + xdir1[c], sy + ydir1[c]] = save;
                            sx = sx + xdir1[c];
                            sy = sy + ydir1[c];
                            if (sx + xdir1[c] == Air[i].x && sy + ydir1[c] == Air[i].y)
                                break;
                        }
                        else
                        {
                            c++;
                        }
                    }
                    Map[Air[i].x, Air[i].y + 1] = 0;
                    c++;
                }
            }

            int sum = 2;
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    sum += Map[i, j];
                }
            }
            Console.Write(sum);

        }
    }
}
