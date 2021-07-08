using System;
using System.Collections.Generic;
using System.Text;

namespace 시리얼_번호
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int N = int.Parse(Console.ReadLine());
            List<List<string>> C = new List<List<string>>();

            for (int i = 0; i < N; i++)
            {
                string S = Console.ReadLine().Trim();
                C.Add(new List<string>());
                C[i].Add(S);
                int sum = 0;
                for(int j = 0; j < C[i][0].Length; j++)
                {
                    if (C[i][0][j] >= '0' && C[i][0][j] <= '9')
                        sum += int.Parse(C[i][0][j].ToString());
                }
                C[i].Add(sum.ToString());
            }

            C.Sort((a, b) => (a[0].Length == b[0].Length) ? (int.Parse(a[1]) == int.Parse(b[1])) ? (String.Compare(a[0], b[0])) : (int.Parse(a[1]) > int.Parse(b[1])) ? 1 : -1 : (a[0].Length > b[0].Length) ? 1 : -1);


            //C.Sort((a, b) => (a[0].Length > b[0].Length) ? 1 : -1);
            //C.Sort((a, b) => (a[0].Length == b[0].Length) ?  (int.Parse(a[1]) > int.Parse(b[1])) ? 1:-1 : 0);
            //C.Sort((a, b) => (a[0].Length == b[0].Length) ? (int.Parse(a[1]) == int.Parse(b[1])) ? (String.Compare(a[0], b[0])) : 0 : 0);
            
            foreach (List<string> s in C)
                sb.Append($"{s[0]}\n");
            Console.Write(sb);
        }
    }
}
