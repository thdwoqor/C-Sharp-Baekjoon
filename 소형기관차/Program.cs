using System;
using System.Linq;

namespace 소형기관차
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int Big = int.Parse(Console.ReadLine());
            var T = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int Small = int.Parse(Console.ReadLine());
            int[,] Map = new int[50001, 4];
            int[] Add = new int[50001];
            
            for(int i = 1; i <= Big; i++)
            {
                Add[i] += T[i - 1]+ Add[i-1];
            }

            for(int i= 1;i<= Big; i++)
            {
                for(int j = 1; j <= 3; j++)
                {
                    int A;
                    if (i - Small > 0)
                        A = Add[i] - Add[i - Small]+ Map[i - Small, j - 1];
                    else
                        A = Add[i];

                    
                    Map[i, j] = Math.Max(A, Map[i - 1, j] );


                }
            }

            Console.Write($"{Map[Big,3]}");

            /*
            for (int i = 1; i <= Big; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Console.Write($"{Map[i, j]} ");
                }
                Console.WriteLine($"");
            }
            */
        }
    }
}
