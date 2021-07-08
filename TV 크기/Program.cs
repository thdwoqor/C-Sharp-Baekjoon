using System;
using System.Linq;

namespace TV_크기
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Arr = Console.ReadLine().Trim().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            double line = Math.Sqrt(Math.Pow(Arr[0], 2)/(Math.Pow(Arr[1], 2)+ Math.Pow(Arr[2], 2)));

            Console.Write($"{(int)(Arr[1]* line)} {(int)(Arr[2] * line)}");
        }
    }
}
