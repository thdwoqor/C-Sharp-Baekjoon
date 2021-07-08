using System;
using System.Collections.Generic;

namespace 트리의_지름_2
{
    class Program
    {
        class ListGraph
        {
            private List<Dictionary<int, int>> listGraph;

            // 그래프 초기화
            public ListGraph(int initSize)
            {
                listGraph = new List<Dictionary<int, int>>(); // 그래프 생성

                for (int i = 0; i < initSize + 1; i++)
                {
                    listGraph.Add(new Dictionary<int, int>());
                }
            }

            // 그래프 return
            public List<Dictionary<int, int>> getGraph()
            {
                return this.listGraph;
            }

            // 그래프의 특정 노드 return
            public Dictionary<int, int> getNode(int i)
            {
                return this.listGraph[i];
            }

            // 그래프 추가 (양방향)
            public void put(int x, int y, int depth)
            {
                listGraph[x].Add(y, depth);
                listGraph[y].Add(x, depth);
            }

            // 그래프 추가 (단방향)
            public void putSingle(int x, int y, int depth)
            {
                listGraph[x].Add(y, depth);
            }

            // 그래프 출력 (인접리스트)
            public void printGraphToAdjList()
            {
                for (int i = 1; i < listGraph.Count; i++)
                {
                    Console.Write($"정점 {i} 의 인접리스트");
                    foreach (KeyValuePair<int, int> item in listGraph[i])
                    {
                        //item.Value;
                        Console.Write($"-> {item.Key}");
                    }
                    Console.WriteLine($"");
                }
            }

            public void Solve(int i, bool[] Check,int d)
            {
                Check[i] = true;
                if (listGraph[i].Count == 1&&d!=0)
                {
                    if (Maxd < d)
                    {
                        Max = i;
                        Maxd = d;
                    }
                    return;
                }
                foreach (KeyValuePair<int, int> item in listGraph[i])
                {
                    if (!Check[item.Key])
                        Solve(item.Key, Check,d+item.Value);
                }
            }
        }
        static int Max=0;
        static int Maxd = 0;
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
                int C = int.Parse(vv[2]);
                adjList.put(A, B, C);
            }
            bool[] Check = new bool[10001];

            adjList.Solve(1,Check,0);
            Maxd = 0;
            Check = new bool[10001];
            adjList.Solve(Max, Check, 0);

            Console.WriteLine($"{Maxd}");
            //adjList.printGraphToAdjList();

        }
    }
}
