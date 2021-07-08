using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 배부른_마라토너
{
    class Program
    {
        static void Main(string[] args)
        {
            var myTable = new Dictionary<string, int>();
            //Dictionary 키값은 중복될 수 없기 때문에 주의해야 합니다.
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N+N-1; i++)
            {
                string S = Console.ReadLine();
                if (myTable.ContainsKey(S))
                {
                    int V = myTable[S]+1;
                    myTable.Remove(S);
                    myTable.Add(S,V);
                }
                else
                {
                    myTable.Add(S, 1);
                }
            }
            foreach (var key in myTable.Keys.ToList())
            {
                if (myTable[key] % 2 != 0)
                {
                    Console.Write(key);
                    break;
                }
            }
        }
    }
}
