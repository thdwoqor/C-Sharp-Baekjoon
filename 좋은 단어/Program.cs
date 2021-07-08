using System;
using System.Collections.Generic;

namespace 좋은_단어
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int Sum = 0;
            int N = int.Parse(Console.ReadLine());
            for(int i = 0; i < N; i++)
            {
                Stack<Char> stack = new Stack<char>();
                Stack<Char> save = new Stack<char>();
                char C = ' ';
                string S = Console.ReadLine();
                for (int j = 0; j < S.Length; j++)
                    stack.Push(S[j]);
                
                while (true) 
                {
                    char C2 = stack.Pop();
                    if (C == C2)
                    {
                        save.Pop();
                        if (save.Count > 0)
                            C = save.Peek();
                        else
                            C = ' ';
                    }
                    else
                    {
                        save.Push(C2);
                        C = C2;
                    }

                    if (stack.Count == 0) 
                    {
                        if (save.Count == 0)
                            Sum++;
                        break;
                    }
                }

            }
                
                Console.Write(Sum);
        }
    }
}
