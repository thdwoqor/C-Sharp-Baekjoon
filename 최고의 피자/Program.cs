using System;

namespace 최고의_피자
{
    class Program
    {
        static void Main(string[] args)
        {
            int topping = int.Parse(Console.ReadLine());
            string k = Console.ReadLine();
            string[] kk = k.Split(' ');
            int doughM = int.Parse(kk[0]);
            int toppingM = int.Parse(kk[1]);
            int doughK = int.Parse(Console.ReadLine());
            int[] toppingK = new int[topping];
            for(int i = 0; i < topping; i++)
            {
                toppingK[i]=int.Parse(Console.ReadLine());
            }
            Array.Sort(toppingK);
            Array.Reverse(toppingK);
            /*
            for (int i = 0; i < topping; i++)
            {
                Console.WriteLine(toppingK[i]);
            }
            */
            int sum = doughK;
            int best= doughK/doughM;
            for(int i=0; i< topping; i++)
            {
                int sumM = doughM+ toppingM*(i+1);
                sum += toppingK[i];
                if (best < sum / sumM)
                    best = sum / sumM;
            }
            Console.Write(best);

        }
    }
}
