using System;
using System.Text;

namespace Java_vs_C__
{
    class Program
    {
        static void C(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= 'a'&& s[i] <= 'z')
                {
                    sum.Append(s[i]);
                }
                else
                {
                    sum.Append('_');
                    sum.Append((char)((int)s[i] + 32));
                }
            }
        }
        static void JA(string s)
        {
            string[] C = s.Split('_');
            sum.Append(C[0]);
            for (int i = 1; i < C.Length; i++)
            {
                sb.Append(C[i]);
                sb.Replace(sb[0], (char)((int)sb[0] - 32), 0, 1);
                sum.Append(sb);
                sb.Remove(0, sb.Length);
            }
        }
        static StringBuilder sb;
        static StringBuilder sum;
        static void Main(string[] args)
        {
            bool CC = false;
            bool JJ = false;
            bool so = true;
            sb = new StringBuilder();
            sum = new StringBuilder();
            string s = Console.ReadLine();
            for(int i=0; i < s.Length; i++)
            {
                if (s[i] == '_') 
                {
                    JJ = true;
                    so = false;
                }
                if (s[i] <= 'Z'&& s[i] >= 'A')
                {
                    CC = true;
                    so = false;
                }
                if((i+1< s.Length && s[i]=='_'&& s[i+1] == '_')||(s[s.Length-1]=='_')|| (s[0] == '_'))
                {
                    CC = false;
                    JJ = false;
                    so = false;
                    break;
                }
                
            }

            if(s[0]>='A'&& s[0] <= 'Z')
                sum.Append("Error!");
            else if (so == true)
                sum.Append(s);
            else if(JJ == true&& CC == false)
                JA(s);
            else if (JJ == false && CC == true)
                C(s);
            else
                sum.Append("Error!");

            Console.Write(sum.ToString());
        }
    }
}
