using System;
using System.Text;

namespace 크리스_마틴
{
    class Program
    {
        static void Main(string[] args)
        {
            int A = int.Parse(Console.ReadLine());
            string B = Console.ReadLine();
            int[] ACGT = new int[4];

            for(int i = 0; i < A; i++)
            {
                if (B[i] == 'A')
                    ACGT[0]++;
                else if (B[i] == 'C')
                    ACGT[1]++;
                else if (B[i] == 'G')
                    ACGT[2]++;
                else if (B[i] == 'T')
                    ACGT[3]++;
            }
            int? low = null;
            int n=0;
            for(int i = 0; i < 4; i++)
            {
                if (low == null)
                    low = ACGT[i];
                else
                {
                    if (low > ACGT[i])
                    {
                        low = ACGT[i];
                        n = i;
                    }
                }
            }
            Console.WriteLine(low);
            StringBuilder sb = new StringBuilder();
            Char[] acgt = new Char[4];
            acgt[0] = 'A';
            acgt[1] = 'C';
            acgt[2] = 'G';
            acgt[3] = 'T';
            for(int i=0;i<A;i++)
                sb.Append(acgt[n]);
            Console.Write(sb);
        }
    }
}
