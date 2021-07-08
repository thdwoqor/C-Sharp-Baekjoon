using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pen_Pineapple_Apple_Pen2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string M = Console.ReadLine();
            int Sum = 0;
            
            for(int i = 0; i < N-3; i++)
            {
                if (M[i] == 'p' && M[i+1] == 'P' && M[i + 2] == 'A' && M[i + 3] == 'p')
                {
                    Sum++;
                    i += 3;
                }
            }
            
            Console.Write($"{Sum}");
            
        }
    }
    
}
