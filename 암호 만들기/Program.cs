using System;
using System.Text;

namespace 암호_만들기
{
    class Program
    {
        static void combination(char[] arr, bool[] visited, int start, int n, int r)
        {
            if (r == 0)
            {
                print(arr, visited, n);
                return;
            }

            for (int i = start; i < n; i++)
            {
                visited[i] = true;
                combination(arr, visited, i + 1, n, r - 1);
                visited[i] = false;
            }
        }
        static void print(char[] arr, bool[] visited, int n)
        {
            StringBuilder sb = new StringBuilder();
            bool aeiou = false;
            int X = 0;
            for (int i = 0; i < n; i++)
            {
                if (visited[i])
                {
                    if (arr[i] == 'a' || arr[i] == 'e' || arr[i] == 'i' || arr[i] == 'o' || arr[i] == 'u')
                        aeiou = true;
                    else
                        X++;
                    sb.Append(arr[i]);
                }
            }
            if (aeiou&&X>=2)
            {
                sb.Append("\n");
                Answer.Append(sb);
            }
            
        }
        static StringBuilder Answer = new StringBuilder();
        static int L, C;
        static void Main(string[] args)
        {
            string v = Console.ReadLine();
            string[] vv = v.Split(' ');
            L = int.Parse(vv[0]);
            C = int.Parse(vv[1]);

            char[] Alphabet = new char[C];

            v = Console.ReadLine();
            vv = v.Split(' ');

            for (int i = 0; i < C; i++)
                Alphabet[i] = vv[i][0];

            Array.Sort(Alphabet);

            bool[] visited = new bool[C];

            combination(Alphabet, visited, 0, C, L);

            Console.Write(Answer);
        }
    }
}
