using System;
using System.Linq;
using System.Text;

namespace 다음수
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                var S = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                int a1 = S[0]; int a2 = S[1]; int a3 = S[2];
                if (a1 == a2)
                    break;

                if (a3 - a2 == a2 - a1)
                    sb.Append($"AP {a3*2-a2}\n");
                else
                    sb.Append($"GP {a3*a3/a2}\n");
            }
            Console.Write($"{sb}");
        }
    }
}
