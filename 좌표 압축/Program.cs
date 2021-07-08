using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 좌표_압축
{
    class Program
    {
        //lower_bound
        private static int upperBound(List<int> data, int target)
        {
            int begin = 0;
            int end = data.Count()-1;

            while (begin < end)
            {
                int mid = (begin + end) / 2;

                if (data[mid] < target)
                    begin = mid + 1;
                else if (data[mid] >= target)
                    end = mid;
            }
            return end;
        }
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            var X = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            List<int> XX = new List<int>();
            foreach (int x in X)
            {
                XX.Add(x);
            }
            XX.Sort();
            XX= XX.Distinct().ToList();

            for (int i=0;i<X.Length;i++)
            {
                X[i] = upperBound(XX, X[i]);
            }

            StringBuilder sb = new StringBuilder();

            foreach (int x in X)
                sb.Append($"{x} ");

            Console.Write($"{sb}");
        }
    }
}
