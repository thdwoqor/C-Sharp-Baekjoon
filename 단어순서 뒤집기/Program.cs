using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 단어순서_뒤집기
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            for(int i = 0; i < N; i++)
            {
                string str = Console.ReadLine();
                string[] result = str.Split(' ');
                string s = "";
                for (int j = result.Length - 1; j >= 0; j--)
                    s += result[j]+' ';
                Console.WriteLine($"Case #{i+1}: {s}");
            }
            
        }
    }
}
