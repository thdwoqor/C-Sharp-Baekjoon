using System;
using System.Collections.Generic;

namespace 아기_상어
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
            if (x < 0 || y < 0 || x >= N || y >= N) return false;
            return true;
        }
        static int CH2 = 0;
        static int CH3 = 0;
        static Pos DT;
        static bool RE;
        static int nk=0;
        static void Print(Pos STA)
        {
            CH2 = 0;
            RE = false;
            DT = new Pos(98, 98);
            Queue<Pos> q = new Queue<Pos>();
            int[] xdir = { -1, 0, 0, 1 };
            int[] ydir = { 0, -1, 1, 0 };
            bool[,] visited = new bool[N, N];

            q.Enqueue(STA);
            visited[STA.x, STA.y] = true;

            q.Enqueue(new Pos(99, 99));

            while (!(q.Count == 0))
            {
                Pos p = q.Dequeue();
                int px = p.x;
                int py = p.y;
                //Console.WriteLine($"{CH2} {px} {py}");

                    if (px == 99 && py == 99)
                    {
                        if (RE)
                        {
                            NN[DT.x, DT.y] = 0;
                            EX++;
                            if (EX == LV)
                            {
                                EX = 0;
                                LV++;
                            }
                            CH3 += CH2;
                            Print(new Pos(DT.x, DT.y));
                            break;
                        }
                        else
                        {
                            if (q.Count == 0)
                            {
                                break;
                            }
                            else
                            {
                            q.Enqueue(new Pos(99, 99));
                            CH2++;
                            continue;
                            }
                        }
                    }

                    if (NN[px, py] < LV && NN[px, py] > 0)
                    {
                        RE = true;
                        if ((DT.x == 98 )&&( DT.y == 98))
                        {
                            DT.x = px;
                            DT.y = py;
                        }
                        else
                        {
                            if(DT.x> px)
                            {
                                DT.x = px;
                                DT.y = py;
                            }
                            else if((DT.x == px)&&(DT.y > py))
                            {
                                DT.x = px;
                                DT.y = py;
                            }
                        }
                    continue;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        int dx = px + xdir[i];
                        int dy = py + ydir[i];
                        // 유효한 위치 && 선택된 자리 && 방문하지 않은 자리
                        if (isValidPosition(dx, dy) && NN[dx, dy] <= LV && !visited[dx, dy])
                        {
                        visited[dx, dy] = true;
                        q.Enqueue(new Pos(dx,dy));
                        }
                    }
            }
            return;
        }
        static Pos STA;
        static int[,] NN;
        static int LV=2;
        static int EX=0;
        static int N;
        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            NN = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                string S = Console.ReadLine();
                string[] SS = S.Split(' ');
                for (int j = 0; j < N; j++)
                {
                    if (int.Parse(SS[j]) == 9)
                    {
                        STA = new Pos(i,j);
                    }
                    NN[i, j] = int.Parse(SS[j]);
                }
            }
            NN[STA.x, STA.y] = 0;
            Print(STA);
            Console.Write(CH3);
        }
    }
}
