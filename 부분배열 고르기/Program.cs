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
            int[] tree = new int[N * 4];

            Tree T = new Tree(arr, tree);
            T.init(0, N-1, 1);

            int M = int.MinValue;

            for(int i = 0; i < N; i++)
            {
                if (M < T.min(i))
                    M = T.min(i);
            }
            Console.Write($"{M}");

        }
        class Tree
        {
            public int[] arr;
            public int[] tree;
            public Tree(int[] arr, int[] tree)
            {
                this.arr = arr;
                this.tree = tree;
            }

            public int init(int start, int end, int node)
            {
                if (start == end)
                    return tree[node] = arr[start];
                int mid = (start + end) / 2;
                return tree[node] = init(start, mid, node * 2) + init(mid + 1, end, node * 2 + 1);
            }
            public int Max = int.MinValue;

            public int sum(int start, int end, int node, int left, int right)
            {
                if (left > end || right < start)
                {
                    return 0;
                }
                if (left <= start && end <= right)
                {
                    return tree[node];
                }
                /* 필요한 구간마다 밑에서부터 구간합을 가지고 올라온다 */
                int mid = (start + end) / 2;
                return sum(start, mid, node * 2, left, right) + sum(mid + 1, end, node * 2 + 1, left, right);
            }

            public int min(int m)
            {
                int Min = arr[m];
                int s=0;
                int e=0;
                for (int i = m; i <arr.Length; i++)
                {
                    if (arr[i] < Min)
                    {
                        break;
                    }
                    e = i;
                }
                for (int i = m; i >= 0; i--)
                {
                    if (arr[i] < Min)
                    {
                        break;
                    }
                    s = i;
                }

                //Console.WriteLine($"{s} {e}");

                return sum(0, arr.Length-1, 1, s, e)*arr[m];

            }
        }
    }
}
