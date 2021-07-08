using System;

namespace ACM_호텔
{
    class Program
    {
        //static int[,] k ;
        static int Solve(int a, int b, int c)
        {
            //k=new int[a, b];
            int h = 0;
            for (int m = 1; m <= b; m++)
            {
                for (int n = 1; n <= a; n++)
                {
                    h++;
                    if (h == c)
                    {
                        return n * 100 + m;

                    }

                }
            }
            return 0;
        }
        static string[,] k;
        static void Main(string[] args)
        {
            int v = Convert.ToInt32(Console.ReadLine());
            k = new string[v, 3];
            for (int n = 0; n < v; n++)
            {
                string k3 = Console.ReadLine();
                string[] k2 = k3.Split(' ');
                for(int m = 0; m < 3; m++)
                {
                    k[n, m] = k2[m];
                }
                //Console.WriteLine(Solve(int.Parse(k2[0]), int.Parse(k2[1]), int.Parse(k2[2])));
            }
            for (int n = 0; n < v; n++)
            {
                Console.WriteLine(Solve(int.Parse(k[n,0]), int.Parse(k[n,1]), int.Parse(k[n,2])));
            }
        }
    }
}
