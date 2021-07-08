using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 고무오리_디버깅
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0;
            while (true)
            {
                string s = Console.ReadLine();
                if(s== "고무오리 디버깅 시작")
                {
                    while (true)
                    {
                        s = Console.ReadLine();
                        if (s == "고무오리" && N == 0)
                            N += 2;
                        else if (s == "고무오리")
                            N -= 1;
                        else if (s == "문제")
                            N += 1;
                        else if (s == "고무오리 디버깅 끝")
                            break;
                    }
                    break;
                }
            }
            if(N==0)
                Console.Write($"고무오리야 사랑해");
            else
                Console.Write($"힝구");

            //Console.ReadKey();
        }
    }
}
