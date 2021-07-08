using System;

namespace 파일_옮기기
{
    class Program
    {
        static void Main(string[] args)
        {
            string v = Console.ReadLine();
            string[] vv = v.Split(' ');
            int A = int.Parse(vv[0]);
            int B = int.Parse(vv[1]);
            v = Console.ReadLine();
            vv = v.Split(' ');
            int C = int.Parse(vv[0]);
            int D = int.Parse(vv[1]);

            if(A+D<B+C)
                Console.Write($"{A+D}");
            else
                Console.Write($"{B+C}");
        }
    }
}
