using System;
using System.Collections.Generic;

namespace 치킨_배달
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
        private static void solve(Pos[] C, int current, int start)
        {
            if (M == current)
            {
                int Sum = 0;
                for (int j = 0; j < home.Count; j++)
                {
                    int CH = 9999;
                    for (int i = 0; i < M; i++)
                    {
                        int Len= Math.Abs(home[j].x - C[i].x) + Math.Abs(home[j].y - C[i].y);
                        if (CH > Len)
                            CH = Len;
                    }
                    Sum += CH;
                        //Console.Write($"{C[i].x},{C[i].y} ");
                }
                //Console.WriteLine("");
                if (Max > Sum)
                    Max = Sum;

            }
            else
            {
                for (int i = start; i < chicken.Count; i++)
                {
                    C[current] = chicken[i];
                    solve(C, current + 1, i + 1);
                }
            }
        }


        static int Max=9999;
        static int N;
        static int M;
        static Pos[] C;
        static List<Pos> chicken = new List<Pos>();
        static List<Pos> home = new List<Pos>();
        static void Main(string[] args)
        {
            string v = Console.ReadLine();
            string[] vv = v.Split(' ');
            N = int.Parse(vv[0]);
            M = int.Parse(vv[1]);
            int[,] Map = new int[N+1, N+1];
            C = new Pos[M];
            

            for (int i=1;i< N + 1; i++)
            {
                string k = Console.ReadLine();
                string[] kk = k.Split(' ');
                for (int j = 0; j < N ; j++)
                {
                    Map[i, j+1] = int.Parse(kk[j]);
                    if (Map[i, j + 1]==1)
                        home.Add(new Pos(i,j+1));
                    if (Map[i, j + 1] == 2)
                        chicken.Add(new Pos(i, j + 1));
                }
            }

            solve(C,0,0);
            Console.Write(Max);
            /*
            Console.WriteLine("");
            for (int i = 1; i < N + 1; i++)
            {
                for (int j = 1; j < N + 1; j++)
                {
                    Console.Write($"{Map[i, j]} ");  
                }
                Console.WriteLine("");
            }
            */
        }
    }
}
