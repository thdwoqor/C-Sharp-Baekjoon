using System;

namespace 가위_바위_보
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int T = int.Parse(Console.ReadLine());

            string[,] RSP = new string[T, 10];
            bool[,] Check = new bool[T, 10];
            int[] Answer = new int[T];
            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(Console.ReadLine());
                for(int j = 0; j < N; j++)
                {
                    RSP[i, j] = Console.ReadLine();
                }
            }
            

            for (int i = 0; i < T; i++)
            {

                for(int j=0;j< RSP[i, 0].Length;j++)
                {
                    bool[] Draw = new bool[4];
                    for(int k = 0; k < 10; k++)
                    {
                        if (RSP[i, k] == null)
                            break;
                        if (Check[i, k] == true)
                            continue;

                        string S = RSP[i, k];
                        

                        if (S[j] == 'R')
                            Draw[0] = true;
                        else if(S[j] == 'S')
                            Draw[1] = true;
                        else if(S[j] == 'P')
                            Draw[2] = true;

                        if (Draw[0] && Draw[1] && Draw[2])
                        {
                            Draw[3] = true;
                            break;
                        }
                    }

                    if (Draw[3] == false)
                    {
                        if (Draw[0] && Draw[1])
                        {
                            for (int k = 0; k < 10; k++)
                            {
                                if (RSP[i, k] == null)
                                    break;
                                if (Check[i, k] == true)
                                    continue;

                                string S = RSP[i, k];

                                if (S[j] == 'S')
                                    Check[i, k] = true;
                            }
                        }
                        if (Draw[0] && Draw[2])
                        {
                            for (int k = 0; k < 10; k++)
                            {
                                if (RSP[i, k] == null)
                                    break;
                                if (Check[i, k] == true)
                                    continue;

                                string S = RSP[i, k];

                                if (S[j] == 'R')
                                    Check[i, k] = true;
                            }
                        }
                        if (Draw[1] && Draw[2])
                        {
                            for (int k = 0; k < 10; k++)
                            {
                                if (RSP[i, k] == null)
                                    break;
                                if (Check[i, k] == true)
                                    continue;

                                string S = RSP[i, k];

                                if (S[j] == 'P')
                                    Check[i, k] = true;
                            }
                        }
                    }

                    int sum = 0;
                    int Y=0;
                        for (int k = 0; k < 10; k++)
                        {
                        if (RSP[i, k] == null)
                            break;
                        if (Check[i, k] == false)
                            {
                                sum++;
                                Y = k+1;
                            }
                        }
                     if(sum==1)
                        Answer[i] = Y;
                     else
                        Answer[i] = 0;
                }
            }

            for (int i = 0; i < T; i++)
            {
                Console.WriteLine(Answer[i]);
            }

        }
    }
}
