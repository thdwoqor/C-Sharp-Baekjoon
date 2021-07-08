using System;

namespace 평균
{
    class Program
    {
        static void Main(string[] args)
        {
            int v = int.Parse(Console.ReadLine());
            
            string s = Console.ReadLine();
            string[] Score = s.Split(' ');
            int max = 0;
            for(int i = 0; i < v; i++)
            {
                if (int.Parse(Score[i]) > max)
                    max = int.Parse(Score[i]);
            }
            double sum = 0;
            for (int i = 0; i < v; i++)
            {
                sum += (double.Parse(Score[i]) / max) * 100;
            }
            sum= sum / v;
            Console.Write(sum);
            }
    }
}
