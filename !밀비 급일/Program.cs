using System;
using System.Linq;
using System.Text;

namespace _밀비_급일
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                string S = Console.ReadLine();
                char[] reverse;
                if (S == "END")
                    break;
                reverse= S.ToCharArray().Reverse().ToArray();
                sb.Append($"{new string(reverse)}\n");
            }
            Console.Write($"{sb}");
        }
    }
}
