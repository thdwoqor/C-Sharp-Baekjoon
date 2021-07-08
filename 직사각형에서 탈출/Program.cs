using System;

namespace 직사각형에서_탈출
{
    class Program
    {
        static void Main(string[] args)
        {
            string v = Console.ReadLine();
            string[] vv = v.Split(' ');
            int A = int.Parse(vv[0]);
            int B = int.Parse(vv[1]);
            int C = int.Parse(vv[2]);
            int D = int.Parse(vv[3]);
            int R = Math.Min(A, Math.Min(B,Math.Min(C - A, D-B)));
            Console.Write($"{R}");
        }
    }
}
