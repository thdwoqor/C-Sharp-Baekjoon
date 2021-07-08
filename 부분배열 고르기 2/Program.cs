using System;
using System.Linq;

namespace 부분배열_고르기
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            ulong[][] tree = new ulong[N * 4][];

            Tree T = new Tree(arr, tree);
            T.init(0, N - 1, 1);
            T.divide(0, N - 1);
            Console.Write($"{T.Max}\n{T.s+1} {T.e+1}");

        }
        class Tree
        {
            public int[] arr;
            public ulong[][] tree;
            public ulong Max = ulong.MinValue;
            public int s, e;
            public Tree(int[] arr, ulong[][] tree)
            {
                this.arr = arr;
                this.tree = tree;
            }

            public ulong[][] init(int start, int end, int node)
            {
                if (start == end)
                {
                    tree[node] = new ulong[2];
                    tree[node][0] = (ulong)start;
                    tree[node][1] = (ulong)arr[start];
                    return tree;
                }

                int mid = (start + end) / 2;

                ulong[][] first = init(start, mid, node * 2);
                ulong[][] second = init(mid + 1, end, node * 2 + 1);


                tree[node] = new ulong[2];

                tree[node][0] = arr[first[node * 2][0]] > arr[second[node * 2 + 1][0]] ? second[node * 2 + 1][0] : first[node * 2][0];
                tree[node][1] = first[node * 2][1] + second[node * 2+1][1];

                return tree;

            }


            public ulong sum(int start, int end, int node, int left, int right)
            {
                
                if (left > end || right < start)
                {
                    return 0;
                }
                if (left <= start && end <= right)
                {
                    if (Min[1] >(ulong) arr[tree[node][0]])
                    {
                        Min[0] = tree[node][0];
                        Min[1] = (ulong)arr[tree[node][0]];
                    }
                    return tree[node][1];
                }
                /* 필요한 구간마다 밑에서부터 구간합을 가지고 올라온다 */
                int mid = (start + end) / 2;
                return sum(start, mid, node * 2, left, right) + sum(mid + 1, end, node * 2 + 1, left, right);
            }
            static ulong[] Min = new ulong[2];

            public void divide(int l, int r)
            {
                if (l > r) return;
                Min[0] = 0;
                Min[1] = 1000001;
                ulong S = sum(0, arr.Length - 1, 1, l, r)* Min[1];

                if (Max < S) 
                { 
                    Max = S;
                    s = l;
                    e = r;
                }

                //Console.WriteLine($"{l} {r} {S}");

                divide(l, (int)Min[0]-1);
                divide((int)Min[0]+1, r);
            }

        }
    }
}
