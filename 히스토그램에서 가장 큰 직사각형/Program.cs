using System;
using System.Linq;
using System.Text;

namespace 히스토그램에서_가장_큰_직사각형
{
    class Program
    {
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
                {
                    return tree[node] = end;
                }

                int mid = (start + end) / 2;

                int L = init(start, mid, node * 2);
                int R = init(mid + 1, end, node * 2 + 1);

                return tree[node] = arr[L] > arr[R] ? R : L;
            }

            public int sum(int start, int end, int node, int left, int right)
            {

                if (left > end || right < start)
                {
                    return INF;
                }
                if (left <= start && end <= right)
                {
                    return tree[node];
                }
                int mid = (start + end) / 2;
                int L = sum(start, mid, node * 2, left, right);
                int R = sum(mid + 1, end, node * 2 + 1, left, right);

                if (L == INF) return R;
                else if (R == INF) return L;
                else return arr[L] < arr[R] ? L : R;
            }

            static int INF = 1000000001;
            public long divide(int l, int r)
            {
                int index = sum(1, arr.Length - 1, 1, l, r);
                long S = (long) arr[index] * (long)(r - l + 1);
                long S2;
                if (l <= index - 1)
                {
                    S2 = divide(l, index - 1);
                    S = Math.Max(S, S2);
                }
                if (index + 1 <= r)
                {
                    S2 = divide(index + 1, r);
                    S = Math.Max(S, S2);
                }

                return S;
            }
        }
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                int[] Arr = Console.ReadLine().Trim().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

                if (Arr.Length == 1 && Arr[0] == 0)
                    break;

                int N = Arr.Length;
                int[] tree = new int[100001*4];

                Tree T = new Tree(Arr, tree);

                T.init(1, N - 1, 1);
                sb.Append($"{T.divide(1, N - 1)}\n");
            }
            Console.Write($"{sb}");

        }
    }
}
