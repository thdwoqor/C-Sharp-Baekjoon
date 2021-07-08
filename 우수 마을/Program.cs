using System;
using System.Collections.Generic;
using System.Linq;

namespace 우수_마을
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

            public void Solve(int Node)
            {
                Check[Node] = true;
                earlyA[Node, 1] += people[Node - 1];
                foreach (int i in listGraph[Node])
                {
                    if (!Check[i])
                    {
                        Solve(i);
                        earlyA[Node, 1] += earlyA[i, 0];
                        earlyA[Node, 0] += Math.Max(earlyA[i, 0], earlyA[i, 1]);
                        //Console.WriteLine($"{Node} {i} ** {earlyA[Node, 0]} {earlyA[Node, 1]}");
                    }
                }
            }
        }

        static bool[] Check;
        static int[,] earlyA;
        static int[] people;

        static void Main(string[] args)
        {
            int initSize = int.Parse(Console.ReadLine());

            ListGraph adjList = new ListGraph(initSize);

            people = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            for (int i = 0; i < initSize - 1; i++)
            {
                var Node = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                adjList.put(Node[0], Node[1]);
            }

            Check = new bool[10001];
            earlyA = new int[10001, 2];

            adjList.Solve(1);

            //Console.Write($"{earlyA[1, 0]} {earlyA[1, 1]}");
            Console.Write($"{Math.Max(earlyA[1, 0], earlyA[1, 1])}");

        }
    }
}
