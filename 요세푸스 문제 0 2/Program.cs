using System;
using System.Collections.Generic;
using System.Text;

namespace 요세푸스_문제_0_2
{
    class Program
    {
        static List<int> list = new List<int>();
        static void Main(string[] args)
        {
            string v = Console.ReadLine();
            string[] vv = v.Split(' ');
            int a = int.Parse(vv[0].ToString());
            int b = int.Parse(vv[1].ToString());
            
            StringBuilder sb = new StringBuilder();
            sb.Append("<"); // stringbuilder 제일 앞에 "<" 저장

            for (int n = 1; n <= a; n++) //리스트에 값 추가
            {
                list.Add(n);
            }
            for (int n = 0; n < list.Count; n++)
            {
                if(n== list.Count - 1)
                {
                    sb.Append(list[0].ToString());
                    break;
                }
                for (int m = 0; m < b; m++)
                {
                    if (m == b-1)
                    {
                        sb.Append(list[m].ToString());
                        sb.Append(", ");
                    }
                    list.Add(list[m]);
                    list.RemoveAt(0);
                }
            }
            //list.Count
            sb.Append(">");
            Console.WriteLine(sb);
        }
    }
}
