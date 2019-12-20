using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace day6
{
    class Program
    {
        // Nice solution: https://gist.github.com/sduvick/a6fd8e793e508bbb4389cb3ae17ec47d

        public static int orbit_count(string orb, Dictionary<string, string> map)
        {
            if (map[orb] == "COM")
                return 1;
            else
                return 1 + orbit_count(map[orb], map);
        }


        public static List<string> pathToCOM(string orig, Dictionary<string, string> map)
        {
            List<string> result = new List<string>();

            var temp = orig;
            while (map.ContainsKey(temp))
            {
                result.Add(temp);
                temp = map[temp];
            }

            return result;
        }
        
        static void Main(string[] args)
        {
            // Dictionary<string, string> map = new Dictionary<string, string>();

            // foreach (string line in File.ReadAllLines("day6.txt"))
            // {
            //     var o = line.Split(')');
            //     map.Add(o.Last(), o.First());
            // }
            
            Dictionary<string, string> map = File.ReadAllLines("day6.txt").ToDictionary(x => x.Split(')')[1], x=>x.Split(')')[0]);

            //Challenge 1
            //int checksum = map.Keys.Select(x => orbit_count(x, map)).Sum();
            int checksum = map.Keys.Select(x => pathToCOM(x, map).Count).Sum();
            Console.WriteLine("Total checksum: {0}", checksum);


            //Challenge 2
            List<string> YOU = pathToCOM(map["YOU"], map);
            List<string> SAN = pathToCOM(map["SAN"], map);

            // foreach (string o in YOU)
            // {
            //     if (SAN.IndexOf(o) != -1)
            //     {
            //         Console.WriteLine("Min orbit transfer: {0}", SAN.IndexOf(o) + YOU.IndexOf(o));
            //         break;
            //     }
            // }
            
            var matchStep = YOU.Intersect(SAN).First();
            Console.WriteLine("Min orbit transfer: {0}", SAN.IndexOf(matchStep) + YOU.IndexOf(matchStep));



        }
    }
}
