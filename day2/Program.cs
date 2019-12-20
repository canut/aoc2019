using System;
using System.Linq;
using System.IO;

namespace day2
{
    class Program
    {
        private const int V = 0;

        public static int compute(int noun, int verb, int[] memory)
        {
            memory[1] = noun;    
            memory[2] = verb;

            int i = 0;
            while (memory[i] != 99 && (i+3) < memory.Length)
            {
                switch (memory[i])
                {
                    case 1:
                        memory[memory[i+3]] = memory[memory[i+1]] + memory[memory[i+2]];
                        i +=4;
                        break;
                    case 2:
                        memory[memory[i+3]] = memory[memory[i+1]] * memory[memory[i+2]];
                        i +=4;
                        break;
                    default:
                        Console.WriteLine("ERROR - Unknown opcode");
                        i = memory.Length;
                        return -1;
                }
            }
            //Console.WriteLine("Value for noun {0} and verb {1} is {2}", noun, verb, memory[0]);
            return memory[0];
        }
        
        static void Main(string[] args)
        {
            //var program = new int[] {1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,13,1,19,1,19,10,23,1,23,13,27,1,6,27,31,1,9,31,35,2,10,35,39,1,39,6,43,1,6,43,47,2,13,47,51,1,51,6,55,2,6,55,59,2,59,6,63,2,63,13,67,1,5,67,71,2,9,71,75,1,5,75,79,1,5,79,83,1,83,6,87,1,87,6,91,1,91,5,95,2,10,95,99,1,5,99,103,1,10,103,107,1,107,9,111,2,111,10,115,1,115,9,119,1,13,119,123,1,123,9,127,1,5,127,131,2,13,131,135,1,9,135,139,1,2,139,143,1,13,143,0,99,2,0,14,0};
            int[] program = File.ReadAllText("day2.txt").Split(',').Select(int.Parse).ToArray();
           
            int[] memory = new int[program.Length];
            
            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    program.CopyTo(memory, 0);
                    if (compute(noun, verb, memory) == 19690720)
                    {
                       Console.WriteLine("Noun: {0} and Verb: {1}. Answer is {2}", noun, verb, 100*noun+verb);
                       return;
                    }
                }
            }   
        }
    }
}
