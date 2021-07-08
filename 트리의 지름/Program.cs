using System;
using System.Collections.Generic;
using System.Linq;

namespace 트리의_지름
{
    class Program
    {
        public class Node
        {
            public int x;
            public int y;
            public int depth;
            public Node(int x, int y, int depth)
            {
                this.x = x;
                this.y = y;
                this.depth = depth;
            }
        }

        static void Solve(int n, bool[] v, int d)
        {
            if (d != 0 && Check[n])
            {
                if (Max < d)
                    Max = d;
                return;
            }

            int Num = 0;
            foreach (Node i in mylist)
            {
                if (v[Num])
                {
                    Num++;
                    continue;
                }

                if (i.x == n)
                {
                    v[Num] = true;
                    Solve(i.y, v, d + i.depth);
                    v[Num] = false;
                }
                if (i.y == n)
                {
                    v[Num] = true;
                    Solve(i.x, v, d + i.depth);
                    v[Num] = false;
                }

                Num++;
            }

            /*
                    for(int i = 0; i < N - 1; i++)
                    {
                        if (v[i])
                            continue;

                        if (mylist[i].x == n)
                        {
                            v[i] = true;
                            Solve(mylist[i].y, v, d + mylist[i].depth);
                            v[i] = false;
                        }
                        if (mylist[i].y == n)
                        {
                            v[i] = true;
                            Solve(mylist[i].x, v, d + mylist[i].depth);
                            v[i] = false;
                        }
                    }
            */

        }
        static int Max = 0;
        static bool[] Check;
        static int N;
        //static List<Node> mylist = new List<Node>();
        static HashSet<Node> mylist = new HashSet<Node>();
        static void Main(string[] args)
        {

            N = int.Parse(Console.ReadLine());


            HashSet<int> parent = new HashSet<int>();
            HashSet<int> child = new HashSet<int>();
            HashSet<int> child2 = new HashSet<int>();

            bool[] visit = new bool[N + 1];
            Check = new bool[10001];
            int[] Check2 = new int[10001];

            for (int i = 0; i < N - 1; i++)
            {
                string v = Console.ReadLine();
                string[] vv = v.Split(' ');
                int A = int.Parse(vv[0]);
                int B = int.Parse(vv[1]);
                int C = int.Parse(vv[2]);

                Check2[A]++;
                parent.Add(A);
                child.Add(B);

                Check[B] = true;

                if (child.Contains(A))
                {
                    child2.Add(A);
                    child.Remove(A);
                    Check[A] = false;
                }
                mylist.Add(new Node(A, B, C));
            }

            foreach (int i in parent)
            {
                if (!child2.Contains(i))
                {
                    if (Check2[i] == 1)
                    {
                        child.Add(i);
                        Check[i] = true;
                        break;
                    }
                }
            }

            foreach (int i in child)
            {
                Solve(i, visit, 0);
                //Console.WriteLine($"{i}");
            }
            Console.Write($"{Max}");
        }
    }
}
