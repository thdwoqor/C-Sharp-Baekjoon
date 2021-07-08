using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DFS와_BFS
{
    class Program
    {

        class ListGraph
        {
            public List<List<int>> listGraph;

            // 그래프 초기화
            public ListGraph(int initSize)
            {
                listGraph = new List<List<int>>(); // 그래프 생성

                for (int i = 0; i < initSize + 1; i++)
                {
                    listGraph.Add(new List<int>());
                }
            }

            // 그래프 return
            public List<List<int>> getGraph()
            {
                return this.listGraph;
            }

            // 그래프의 특정 노드 return
            public List<int> getNode(int i)
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

            public void list_Sort()
            {
                for(int i = 0; i < listGraph.Count; i++)
                {
                    listGraph[i].Sort();
                }
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
                foreach (int i in listGraph[Node])
                {
                    if (!Check[i])
                    {
                        Console.Write($"{i} ");
                        Solve(i);
                    }
                }
            }

            public void Solve2(int Node)
            {
                Check[Node] = true;

                Queue<int> q = new Queue<int>();
                q.Enqueue(Node);

                while (q.Count > 0)
                {
                    int current = q.Dequeue();
                    if(!Check[current])
                        Console.Write($"{current} ");
                    Check[current] = true;
                    foreach (int i in listGraph[current])
                    {
                        if (!Check[i])
                        {
                            q.Enqueue(i);
                        }
                    }
                }
            }

        }
        static bool[] Check;
        static void Main(string[] args)
        {

            var inputs = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            ListGraph adjList = new ListGraph(inputs[0]);

            for (int i = 0; i < inputs[1]; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                adjList.put(input[0], input[1]);
            }
            adjList.list_Sort();
            //adjList.printGraphToAdjList();
            Check = new bool[inputs[0]+1];
            Console.Write($"{inputs[2]} ");
            adjList.Solve(inputs[2]);
            Console.Write($"\n");
            Check = new bool[inputs[0] + 1];
            Console.Write($"{inputs[2]} ");
            adjList.Solve2(inputs[2]);
            //Console.Write($"{earlyA[1, 0]} {earlyA[1, 1]}");
            //Console.Write($"{Math.Max(earlyA[1, 0], earlyA[1, 1])}");
        }
    }
}
