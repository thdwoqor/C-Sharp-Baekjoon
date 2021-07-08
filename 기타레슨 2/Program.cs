using System;
using System.Linq;

namespace 기타레슨_2
{
    class Program
    {
        static void Solve(int A, int B)
        {
            //Console.WriteLine($"{A} {B}");
            if (A >= B)
            {
                Console.Write($"{B}");
                return;
            }

            int Mid = (A+B) / 2;
            int Save = 0;
            int Count = 1;
            foreach(int i in inputs)
            {
                if (Save + i <= Mid)
                    Save += i;
                else
                {
                    Count++;
                    Save = i;
                }
            }
            if (Count <= M && inputs.Max() <= Mid)
            {
                Solve(A, Mid);
            }
            else
                Solve(Mid + 1, B);

        }
        static int N, M;
        static int[] inputs;
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            inputs = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            N = input[0];
            M = input[1];

            //Console.Write($"{inputs.Max()}");

            Solve(0, inputs.Sum());
        }
    }
}
