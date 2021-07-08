using System;
using System.Collections.Generic;
using System.Text;

namespace 전생했더니_슬라임_연구자였던_건에_대하여__Hard_
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            long[] TT = new long[T];
            for (int k = 0; k < T; k++)
            {
                int N = int.Parse(Console.ReadLine());
                if (N != 1)
                {

                    long[] Num = new long[N];
                    string v = Console.ReadLine();
                    string[] vv = v.Split(' ');
                    int rest = 1000000007;

                    for (int i = 0; i < N; i++)
                        Num[i] = long.Parse(vv[i]);

                    var list = new List<long>();
                    list.AddRange(Num);
                    list.Sort();

                    long Sum = 1;

                    while (list.Count > 1)
                    {
                        long A = list[0];
                        long B = list[1];

                        list.RemoveAt(0);
                        list.RemoveAt(0);
                        Sum = Sum*((A* B) % rest) % rest;
                        list.Add(A * B);
                        list.Sort();
                    }

                    TT[k] = Sum;
                }
                else
                {
                    string v = Console.ReadLine();
                    TT[k] = 1;
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < T; i++)
            {
                sb.Append(TT[i]);
                if(i!=T-1)
                    sb.Append("\n");
            }
                Console.Write(sb);
        }
    }
}
