using System;
using System.Collections.Generic;

namespace 사회망_서비스_SNS_
{
    class Program
    {
        class ListGraph
        {
            public List<HashSet<int>> listGraph;

            // 그래프 초기화
            public ListGraph(int initSize)
            {
                listGraph = new List<HashSet<int>>(); // 그래프 생성

                for (int i = 0; i < initSize + 1; i++)
                {
                    listGraph.Add(new HashSet<int>());
                }
            }

            // 그래프 return
            public List<HashSet<int>> getGraph()
            {
                return this.listGraph;
            }

            // 그래프의 특정 노드 return
            public HashSet<int> getNode(int i)
            {
                return this.listGraph[i];
            }

            // 그래프 추가 (양방향)
            public void put(int x, int y)
            {
                listGraph[x].Add(y);
                listGraph[y].Add(x);
            }

            // 그래프 추가 (단방향)
            public void putSingle(int x, int y)
            {
                listGraph[x].Add(y);
            }

            // 그래프 출력 (인접리스트)
            public void printGraphToAdjList()
            {
                for (int i = 1; i < listGraph.Count; i++)
                {
                    Console.Write($"정점 {i} 의 인접리스트");
                    foreach (var item in listGraph[i])
                    {
                        //item.Value;
                        Console.Write($"-> {item}");
                    }
                    Console.WriteLine($"");
                }
            }

            public void Solve(int i, bool[] Check)
            {
                Check[i] = true;
                s.Push(i);
                foreach (var item in listGraph[i])
                {
                    if (!Check[item])
                    {
                        Solve(item, Check);
                    }

                }
            }
        }
        static bool[] Check;
        static int[,] earlyA;
        static Stack<int> s;
        static void Main(string[] args)
        {
            int initSize = int.Parse(Console.ReadLine());

            ListGraph adjList = new ListGraph(initSize);

            for (int i = 0; i < initSize - 1; i++)
            {
                string v = Console.ReadLine();
                string[] vv = v.Split(' ');
                int A = int.Parse(vv[0]);
                int B = int.Parse(vv[1]);
                adjList.put(A, B);
            }
            Check = new bool[1000001];
            earlyA = new int[1000001, 2];

            s = new Stack<int>();
            adjList.Solve(1, Check);

            int C = s.Count;

            Check = new bool[1000001];

            for (int i = 0; i < C; i++)
            {
                int P = s.Pop();
                earlyA[P, 0] = 0; earlyA[P, 1] = 1;
                Check[P] = true;
                foreach (var item in adjList.listGraph[P])
                {
                    if (Check[item])
                    {
                        earlyA[P, 0] += earlyA[item, 1];
                        earlyA[P, 1] += Math.Min(earlyA[item, 0], earlyA[item, 1]);
                    }
                }
            }

            Console.Write($"{Math.Min(earlyA[1, 0], earlyA[1, 1])}");
            //adjList.printGraphToAdjList();
        }
    }
}
