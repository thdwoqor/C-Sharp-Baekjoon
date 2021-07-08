using System;
using System.Text;

namespace 트리의_순회
{
    class Program
    {
        static void Solve(int S ,int E,int SS,int EE)
        {
            if (S > E || SS > EE)
                return;

            int root = postorder[EE];
            sb.Append(root.ToString());
            sb.Append(" ");
            Solve(S, idx[root] - 1, SS, SS + (idx[root] - S) - 1);
            Solve(idx[root] + 1, E, SS + (idx[root] - S), EE - 1);

        }
        static int[] inorder;
        static int[] postorder;
        static int[] idx = new int[100001];
        static int N;
        static StringBuilder sb;
        static void Main(string[] args)
        {
            sb = new StringBuilder();
            N = int.Parse(Console.ReadLine());
            inorder = new int[100001];
            postorder = new int[100001];

            string v = Console.ReadLine();
            string[] vv = v.Split(' ');
            for (int i = 0; i < vv.Length; i++)
                inorder[i] = int.Parse(vv[i]);
            v = Console.ReadLine();
            vv = v.Split(' ');
            for (int i = 0; i < vv.Length; i++)
                postorder[i] = int.Parse(vv[i]);
            
            for (int i = 0; i < N; i++)
                idx[inorder[i]] = i;
            
            Solve(0, N - 1, 0, N - 1);
            
            Console.Write(sb);

        }
    }
}
