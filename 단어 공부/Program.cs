using System;

namespace 단어_공부
{
    class Program
    {
        static void Main(string[] args)
        {
            string v = Console.ReadLine();
            int[] alphabet = new int[26];
            int max=0;
            string maxs="";

            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] == 'a' || v[i] == 'A')
                    alphabet[0]++;
                if (v[i] == 'b' || v[i] == 'B')
                    alphabet[1]++;
                if (v[i] == 'c' || v[i] == 'C')
                    alphabet[2]++;
                if (v[i] == 'd' || v[i] == 'D')
                    alphabet[3]++;
                if (v[i] == 'e' || v[i] == 'E')
                    alphabet[4]++;
                if (v[i] == 'f' || v[i] == 'F')
                    alphabet[5]++;
                if (v[i] == 'g' || v[i] == 'G')
                    alphabet[6]++;
                if (v[i] == 'h' || v[i] == 'H')
                    alphabet[7]++;
                if (v[i] == 'i' || v[i] == 'I')
                    alphabet[8]++;
                if (v[i] == 'j' || v[i] == 'J')
                    alphabet[9]++;
                if (v[i] == 'k' || v[i] == 'K')
                    alphabet[10]++;
                if (v[i] == 'l' || v[i] == 'L')
                    alphabet[11]++;
                if (v[i] == 'm' || v[i] == 'M')
                    alphabet[12]++;
                if (v[i] == 'n' || v[i] == 'N')
                    alphabet[13]++;
                if (v[i] == 'o' || v[i] == 'O')
                    alphabet[14]++;
                if (v[i] == 'p' || v[i] == 'P')
                    alphabet[15]++;
                if (v[i] == 'q' || v[i] == 'Q')
                    alphabet[16]++;
                if (v[i] == 'r' || v[i] == 'R')
                    alphabet[17]++;
                if (v[i] == 's' || v[i] == 'S')
                    alphabet[18]++;
                if (v[i] == 't' || v[i] == 'T')
                    alphabet[19]++;
                if (v[i] == 'u' || v[i] == 'U')
                    alphabet[20]++;
                if (v[i] == 'v' || v[i] == 'V')
                    alphabet[21]++;
                if (v[i] == 'w' || v[i] == 'W')
                    alphabet[22]++;
                if (v[i] == 'x' || v[i] == 'X')
                    alphabet[23]++;
                if (v[i] == 'y' || v[i] == 'Y')
                    alphabet[24]++;
                if (v[i] == 'z' || v[i] == 'Z')
                    alphabet[25]++;
            }
            for (int i = 0; i < 26; i++)
            {
                if (max < alphabet[i])
                {
                    max = alphabet[i];
                    maxs = i.ToString();
                }else if(max == alphabet[i])
                {
                    maxs = "?";
                }
            }
            if (maxs == "?")
            {
                Console.Write(maxs);
            }
            else
            {
                char a = (char)(65 + int.Parse(maxs));
                Console.Write(a);
            }
        }
    }
}
