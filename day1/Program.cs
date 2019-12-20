using System;
using System.Linq;
using System.IO;

namespace day1
{
    class Program
    {
        public static int ComputeFuel(int mass)
        {
            return Math.Max( (int)Math.Floor((decimal)mass / 3) - 2, 0);
        }

        public static int addedFuelRecursive(int fuel, int acc)
        {
            if (fuel <= 0)
                return acc;
            else
                return addedFuelRecursive(ComputeFuel(fuel), acc + fuel);
        }
        
        static void Main(string[] args)
        {
            int[] masses = File.ReadAllText("day1.txt").Split('\n').Select(m=>int.Parse(m)).ToArray();
            
            int result = 0;

            foreach (int m in masses)
            {
                result += addedFuelRecursive(ComputeFuel(m), 0);
            }

            Console.WriteLine(result);
            
            // Functional way to do it with Linq
            var masses2 = File.ReadAllText("day1.txt").Split('\n').Select(m=>int.Parse(m));
            Console.WriteLine(masses2.Select(m => addedFuelRecursive(ComputeFuel(m), 0)).Sum());
        }
    }
}
