using System;
using System.Text;

namespace 히든_넘버
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int N = int.Parse(Console.ReadLine());
            string S = Console.ReadLine();
            ulong sum = 0;
            for(int i = 0; i < N; i++)
            {
                if (S[i] >= '0' && S[i] <= '9')
                    sb.Append(S[i]);
                else if ((S[i] >= 'a' && S[i] <= 'z')||( S[i] >= 'A' && S[i] <= 'Z'))
                {
                    if (sb.Length > 0)
                    {
                        //Console.WriteLine($"{sb}");
                        sum += (ulong)int.Parse(sb.ToString());
                        sb.Length = 0;
                    }
                }
            }
            if (sb.Length > 0)
                sum += (ulong)int.Parse(sb.ToString());

            Console.Write($"{sum}");
        }
    }
}
