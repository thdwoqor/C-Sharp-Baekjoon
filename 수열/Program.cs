using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        
        var nums = Console.ReadLine().Split(' ').Select(s => int.Parse(s));
        

        int len = 0;
        int incLen = 0;
        int decLen = 0;
        int? prev = null;

        foreach (var n in nums)
        {
            if (prev != null)
            {
                if (prev < n) decLen = 0;
                if (prev > n) incLen = 0;
            }

            incLen++;
            decLen++;
            prev = n;

            if (incLen > len) len = incLen;
            if (decLen > len) len = decLen;
        }

        Console.WriteLine(len);
    }
}