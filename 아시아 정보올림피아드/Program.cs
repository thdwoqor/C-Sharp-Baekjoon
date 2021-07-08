using System;
using System.Collections.Generic;
using System.Linq;

namespace 아시아_정보올림피아드
{
    class Program
    {
        struct student
        {
            public int v1;
            public int v2;
            public int v3;

            public student(int v1, int v2, int v3) : this()
            {
                this.v1 = v1;
                this.v2 = v2;
                this.v3 = v3;
            }
        }

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            //student[] solve = new student[N];
            List<student> solve = new List<student>();

            for (int i = 0; i < N; i++)
            {
                int[] s = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                //solve[i] = new student(s[0], s[1], s[2]);
                solve.Add(new student(s[0], s[1], s[2]));
            }
            //aList.Sort((x, y) => x.Age.CompareTo(y.Age));
            solve.Sort((x, y) => y.v3.CompareTo(x.v3));
            
            Console.WriteLine($"{solve[0].v1} {solve[0].v2}");
            Console.WriteLine($"{solve[1].v1} {solve[1].v2}");
            if (solve[0].v1 == solve[1].v1)
            {
                for (int i = 2; i < solve.Count; i++)
                    if (solve[1].v1 != solve[i].v1)
                    {
                        Console.WriteLine($"{solve[i].v1} {solve[i].v2}");
                        break;
                    }
            }else
                Console.WriteLine($"{solve[2].v1} {solve[2].v2}");
        }
    }
}
