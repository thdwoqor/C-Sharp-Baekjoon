using System;
using System.Linq;
using System.Text;

namespace Maximum_Subarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int V = Convert.ToInt32(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < V; k++)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                var S = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

                int[] Arr = new int[1001];
                int Max = 0;
                int Sum = -1001;

                for (int i = 0; i < N; i++)
                {
                    if (Sum < Max + S[i])
                        Sum = Max + S[i];
                    if (Max + S[i] < 0)
                    {
                        Max = 0;
                    }
                    else
                    {
                        Max += S[i];
                    }
                    
                }
                sb.Append($"{Sum}\n");
            }
            Console.Write($"{sb}");
        }
    }
}
