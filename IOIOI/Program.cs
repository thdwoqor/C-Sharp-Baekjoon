using System;
using System.Collections.Generic;
using System.Text;

namespace IOIOI
{
    class Program
    {
        static int sum = 0;
        public static void KMP(String S, String sb)
        {
            //List<int> collection = new List<int>();
            
            int SL = S.Length;
            int sbL = sb.Length;
            int[] collection = new int[SL];
            int j = 0;

            for (int i = 1; i < sb.Length; i++)
            {
                while (j > 0 && sb[i] != sb[j])
                {
                    j = collection[j - 1];
                }
                if (sb[i] == sb[j])
                {
                    collection[i] = ++j;
                }
            }

            for (int i = 1; i < sb.Length; i++)
            {
                Console.WriteLine(collection[i]);
            }
            /*
            j = 0;
            for (int i=0;i< SL; i++)
            {
                while ((j>0)&&(S[i]!=sb[j]))
                {
                    j = collection[j - 1];
                }
                if(S[i] == sb[j])
                {
                    if (j == sbL-1)
                    {
                        sum++;
                        j = collection[j];
                    }
                    else
                    {
                        j++;
                    }
                }
            }
            */
        }
            static void Main(string[] args)
        {
            
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            string S = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            
            sb.Append("I");
            for (int n = 0; n < N ; n++)
            {
                    sb.Append("OI");
            }
            KMP(S, "abacaabad");
            //KMP(S, sb.ToString());
            //Console.Write(sum);
        }
    }
}
