using System;

namespace 단어_공부2
{
    class Program
    {
        static void Main(string[] args)
        {
            string v = Console.ReadLine();
            int[] alphabet = new int[26];

            for (int i = 0; i < v.Length; i++)
            {
                int a = v[i];
                if(v[i]>='a'&& v[i] <= 'z')
                    alphabet[a-97]++;
                else
                    alphabet[a-65]++;
            }

            int max = 0;
            char maxs = '0';

            for (int i = 0; i < 26; i++)
            {
                if (max < alphabet[i])
                {
                    max = alphabet[i];
                    maxs = (char)(65+i);
                }
                else if (max == alphabet[i])
                {
                    maxs = '?';
                }
            }
            Console.Write(maxs);
        }
    }
}
