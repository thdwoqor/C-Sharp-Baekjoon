using System;
using System.Linq;
using System.Text;

namespace Maximum_Subarray_2
{
    class Program
    {
        static int divideConquer(int[] arr,int start,int end)
        {
            if (start == end) return arr[start];


            int min = (start + end) / 2;
            int left = Int32.MinValue;
            int right = Int32.MinValue;

            int sum = 0;

            for(int i = min; i >= start; i--)
            {
                sum += arr[i];
                left = Math.Max(left, sum);
            }

            sum = 0;

            for (int i = min+1; i <= end; i++)
            {
                sum += arr[i];
                right = Math.Max(right, sum);
            }

            int single = Math.Max(divideConquer(arr,start,min), divideConquer(arr, min+1, end));

            return Math.Max(left+right, single);

        }

        static void Main(string[] args)
        {
            int T = Convert.ToInt32(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < T; i++)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                var S = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                sb.Append($"{divideConquer(S, 0, N - 1)}\n");
            }
            Console.Write($"{sb}");


        }
    }
}
