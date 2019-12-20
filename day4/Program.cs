using System;
using System.Linq;
using System.Collections.Generic;

namespace day4
{
    class Program
    {
        
        static bool checkDouble(string n)
        {
            for (int i=0; i<(n.Length-1);i++)
            {
                var ss = n.Substring(i, 2);
                if (ss[0] == ss[1])
                    return true;
            }

            return false;
        }

        // Other solution is to group by elements and check that one group has a size of 2
        static bool checkAtLeastADouble(string n)
        {
            int i = 0;
            int len = 1;
            int j;
            while (i < (n.Length-1))
            {
                len = 1;
                j = i+1;
                while (j < n.Length && n[j] == n[i])
                {
                    len++;
                    j++;
                }

                if (len == 2)
                    return true;
                else
                    i = j;
            }
            return false;
        }
        
        // Better method is to sort the string and compare to original
        static bool checkIncrement(string n)
        {
            for (int i=0; i<(n.Length-1);i++)
            {
                if (n[i] > n[i+1])
                    return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            int start = 138241;
            int end = 674034;

            //Challenge 1
            Console.WriteLine("{0}", Enumerable.Range(start, end-start+1).Where(s => checkIncrement(s.ToString()) && checkDouble(s.ToString())).Count());

            //Challenge 2
            Console.WriteLine("{0}", Enumerable.Range(start, end-start+1).Where(s => checkIncrement(s.ToString()) && checkAtLeastADouble(s.ToString())).Count());
            
        }
    }
}
