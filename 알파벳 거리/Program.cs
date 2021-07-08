using System;
using System.Linq;
using System.Text;

namespace 알파벳_거리
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < N; i++)
            {
                var S = Console.ReadLine().Split(' ').Select(x => x).ToArray();
                sb.Append("Distances:");
                for (int j = 0; j < S[0].Length; j++)
                {
                    if (S[0][j] <= S[1][j])
                    {
                        sb.Append($" {(int)(S[1][j]- S[0][j])}");
                    }
                    else
                    {
                        sb.Append($" {(int)(26-S[0][j]+S[1][j])}");
                    }
                }
                sb.Append("\n");
            }

            Console.Write($"{sb}");
        }
    }
}
