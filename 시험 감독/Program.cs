using System;
using System.Linq;

namespace 시험_감독
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            int[] input;
            ulong Sum;
            if (N > 1) 
            {
                input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                Sum = (ulong)N;
            }
            else
            {
                input = new int[1] { int.Parse(Console.ReadLine()) };
                Sum = 1;
            }

            var inputs = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            var B = inputs[0];
            var C = inputs[1];

            foreach (var i in input)
            {
                if (i - B < 0)
                    continue;
                int Student = i-B;
                if (Student % C == 0)
                {
                    Student /= C;
                }
                else
                {
                    Student /= C;
                    Student++;
                }
                Sum += (ulong)Student;
            }

            Console.Write($"{Sum}");
        }
    }
}
