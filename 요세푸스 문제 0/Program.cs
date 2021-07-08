using System;
using System.Collections.Generic;

namespace 요세푸스_문제_0
{
    class Program
    {
        static void Solve(int a, int b)
        {
            for(int n = 1; n <= a; n++) //리스트에 값 추가
            {
                list.Add(n);
            }
            int sum = 0;
            for (int n = a; n>0; n--)
            {
                if (n == 1)
                {
                    list2.Add(list[0]);
                    return;
                }
                sum += b - 1;
                //12**3**4567 list[2] sum=2
                //1245**6**7 list[4] sum=4
                //1**2**457 list[1] sum=6 sum>list.Count sum-list.Count=1 
                //145**7** list[3] sum=3
                //14**5** list[2] sum=5 sum>list.Count sum-list.Count=2 
                //**1**4 list[0] sum=4 sum>list.Count sum-list.Count=2 sum>list.Count sum-list.Count=0 
                while (true)
                {
                    if ((list.Count-1)>=sum)
                    {
                        break;
                    }
                    sum -= list.Count;
                }
                list2.Add(list[sum]);
                list.RemoveAt(sum);
            }
        }
        static List<int> list = new List<int>();
        static List<int> list2 = new List<int>();

        static void Main(string[] args)
        {
            string v = Console.ReadLine();
            string[] v2 = v.Split(' ');
            Solve(int.Parse(v2[0].ToString()),int.Parse(v2[1].ToString()));
            Console.Write("<"+ list2[0]);
            for (int n = 1; n < list2.Count; n++)
            {
                Console.Write(", "+list2[n]);
            }
            Console.WriteLine(">");
        }
    }
}
//https://loadofprogrammer.tistory.com/145