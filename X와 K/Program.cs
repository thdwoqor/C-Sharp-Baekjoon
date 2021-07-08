using System;
using System.Collections;

namespace X와_K
{

    class Program
    {
        static void Main(string[] args)
        {
            string k = Console.ReadLine();
            string[] kk = k.Split(' ');
            long kk1 = Convert.ToInt64(kk[0].ToString());
            long kk2 = Convert.ToInt64(kk[1].ToString());
            string strBase2_2 = Convert.ToString(kk2, 2);

            byte[] akc = BitConverter.GetBytes(kk1);
            BitArray ba1=new BitArray(akc);
            byte[] akd = BitConverter.GetBytes(kk2);
            BitArray ba2 = new BitArray(akd);
            /*
            for (int i = 0; i < ba1.Count; i++)
            {
                Console.Write(ba1[i] ? "1" : "0");
            }
            */
            long sum=0;
            long kc = 1;
            for(int n=0, m=0; m< strBase2_2.Length; n++)
            {
                if (!ba1[n])
                {
                    if (ba2[m])
                    {
                        sum += kc;
                        m++;
                    }
                    else
                    {
                        m++;
                    }
                }
                    kc = kc << 1;
            }
            Console.Write(sum);
        }
    }
}
