using System;

namespace 이진수_변환
{
    class Program
    {
        static void Main(string[] args)
        {
            long N = Convert.ToInt64(Console.ReadLine());
            Console.Write($"{Convert.ToString(N, 2)}"); 
        }
    }
}
