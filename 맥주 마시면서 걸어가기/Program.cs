using System;

namespace 맥주_마시면서_걸어가기
{
    class Program
    {
        static void Solution(int m, int n, int[] array)
        {
            /*
            1
            5
            0 0       c[0,0,0],c[0,0,1]
            2000 1000 c[0,1,0],c[0,1,1]
            900 0    c[0,2,0],c[0,2,1]
            500 500   c[0,3,0],c[0,3,1]
            1500 1500 c[0,4,0],c[0,4,1]
            1000 1000 c[0,5,0],c[0,5,1] 
            2000 2000 c[0,6,0],c[0,6,1] 

            Solution(0, 2, array) array[1,2,3,4,5] 
            Solution(0, 3, array) array[1,2,3,4,5] > Solution(0, 5, array) array[1,2,4,5] > Solution(0, 4, array) array[1,2,4]
            DFS 재귀
            */

            
            array[n] = 1;
            
            if (Math.Abs(c[m, array.Length, 0] - c[m, n, 0]) + Math.Abs(c[m, array.Length, 1] - c[m, n, 1]) <= 1000)
            {
                sum[m] = "happy";
                return;
            }
            for (int k = 0; k < array.Length; k++)
            {
                if (array[k] == 1)
                    continue;
                if (Math.Abs(c[m, n, 0] - c[m, k, 0]) + Math.Abs(c[m, n, 1] - c[m, k, 1]) <= 1000)
                {
                    if (Math.Abs(c[m, array.Length, 0] - c[m, k, 0]) + Math.Abs(c[m, array.Length, 1] - c[m, k, 1]) <= 1000)
                    {
                        sum[m] = "happy";
                        return;
                    }
                    else
                    {
                        Solution(m, k, array);
                    }
                }
            }
            return;
        }
        static string[] sum;
        static int[] b;
        static int[,,] c;
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            b = new int[101];
            c = new int[a, 150, 2];
            sum = new string[a];

            for (int n = 0; n < a; n++)
            {
                b[n] = Convert.ToInt32(Console.ReadLine());
                for (int m = 0; m < b[n] + 2; m++)
                {
                    string d = Console.ReadLine();
                    string[] dd = d.Split(' ');
                    c[n, m, 0] = Convert.ToInt32(dd[0]);
                    c[n, m, 1] = Convert.ToInt32(dd[1]);
                }
            }
            for (int n = 0; n < a; n++)
            {
                sum[n] = "sad";
            }
            for (int n = 0; n < a; n++)
            {
                int[] array = new int[b[n] + 1];
                Solution(n, 0, array);
            }
            for (int n = 0; n < a; n++)
            {
                Console.WriteLine(sum[n]);
            }
        }
    }
}