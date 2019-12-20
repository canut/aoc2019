using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace day3
{
    class Program
    {        
        public static List<(int, int)> get_positions((int x, int y) position, string move)
        {
            List<(int, int)> path = new List<(int, int)>();
            int nbr = int.Parse(move.Substring(1));

            switch (move[0])
            {
                case 'U':
                    for (int i=0; i<nbr ; i++)
                    {
                        path.Add((position.x, position.y + (i + 1)));
                    }
                    break;

                case 'D':
                    for (int i=0; i<nbr ; i++)
                    {
                        path.Add((position.x, position.y - (i + 1)));
                    }
                    break;

                case 'R':
                    for (int i=0; i<nbr ; i++)
                    {
                        path.Add((position.x + (i+1), position.y));
                    }
                    break;

                case 'L':
                    for (int i=0; i<nbr ; i++)
                    {
                        path.Add((position.x - (i+1), position.y));
                    }
                    break;

                default:
                    break;
            }
            //Console.WriteLine("Path length: {0}", path.Count);
            return path;
        }
        
        public static List<(int, int)> get_full_path((int x, int y) position, string[] moves)
        {
            List<(int, int)> path = new List<(int, int)> {position};
            
            foreach (string move in moves)
            {
                var start = path.Last();
                path.AddRange(get_positions(start, move));
            }
            return path;
        }

        public static int stepsToReach((int x, int y) position, List<(int, int)> path)
        {
            return path.IndexOf(position);
        }

        static void Main(string[] args)
        {
            string[] wire_moves = File.ReadAllLines("day3.txt");
            var central_port = (0, 0);
            var path1 = get_full_path(central_port, wire_moves[0].Split(','));
            var path2 = get_full_path(central_port, wire_moves[1].Split(','));
            var intersections = path1.Intersect(path2);

            
            // Challenge 1
            List<int> distances = new List<int>();

            foreach ((int x, int y) position in intersections)
                distances.Add(Math.Abs(position.x) + Math.Abs(position.y));
                
            distances.Sort();
            
            Console.WriteLine("{0}", distances.Where(d => d>0).First());


            // Challenge 2
            List<int> combined_steps = new List<int>();
            foreach (var position in intersections)
                combined_steps.Add(stepsToReach(position, path1) + stepsToReach(position, path2));
 
            combined_steps.Sort();
            
            Console.WriteLine("{0}", combined_steps.Where(d => d>0).First());
        }
    }
}
