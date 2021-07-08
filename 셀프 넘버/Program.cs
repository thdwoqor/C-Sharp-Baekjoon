using System;
using System.Collections.Generic;
using System.Text;

namespace 셀프_넘버
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            List<int> num = new List<int>();

            for (int i = 1; i <= 10000; i++)
            {
                num.Add(i);
            }

            for (int j = 1; j <= 10000; j++)
            {
                string NN = j.ToString();
                int Sum = j;
                for (int i = 0; i < NN.Length; i++)
                {
                    Sum += int.Parse(NN[i].ToString());
                }
                num.Remove(Sum);
            }

            for (int j = 0; j < num.Count; j++)
            {
                sb.Append(num[j]);
                sb.Append("\n");
            }
            Console.Write(sb);

        }
    }
}
