using System;
using System.Linq;
using System.IO;

namespace day8
{
    class Program
    {
        static void Main(string[] args)
        {
            int w = 25, t = 6;
            string input = File.ReadAllText("day8.txt");
            string[] layers = Enumerable.Range(0, input.Length/(w*t)).Select(i => input.Substring(i*w*t, w*t)).ToArray();
           
            var layers_count0 = layers.Select(s => s.Count(c => c == '0'));
            var index = layers_count0.ToList().IndexOf(layers_count0.Min());
            
            //Challenge 1
            Console.WriteLine("Digit 1 x Digit 2 = {0}", layers[index].Count(c => c == '1') * layers[index].Count(c => c == '2'));

            // Challenge 2
            var result = string.Concat(Enumerable.Range(0, w*t).Select(i => layers.Select(s => s[i]).First(c => c != '2')));
            
            var res = Enumerable.Range(0, t).Select(i => result.Substring(i*w, w) ).ToArray();
            foreach ( var r in res)
            {
                Console.WriteLine("{0}", r.Replace('0', ' '));
            }

        }
    }
}
