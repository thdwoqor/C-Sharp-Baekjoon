using System;

namespace 음계
{
    class Program
    {
        static void Main(string[] args)
        {
            string v = Console.ReadLine();
            if(v== "1 2 3 4 5 6 7 8") 
                Console.Write("ascending");
            else if(v == "8 7 6 5 4 3 2 1")
                Console.Write("descending");
            else
                Console.Write("mixed");
        }
    }
}
