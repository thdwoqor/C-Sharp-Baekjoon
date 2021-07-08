using System;

namespace 막대기
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int [] arr = new int[N];
            for (int i = 0; i < N; i++)
                arr[i] = int.Parse(Console.ReadLine());

            int temp = 0;
            int sum = 0;
            for(int i = N - 1; i >= 0; i--)
            {
                if (arr[i] > temp)
                {
                    temp = arr[i];
                    sum++;
                }
            }
            Console.WriteLine($"{sum}");

        }
    }
}
