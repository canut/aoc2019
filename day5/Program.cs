using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace day5
{
    class Program
    {
        public static int read_param(int pos, int eip, int modes, int[] program)
        {
            //Console.WriteLine("div {0}", modes/Math.Pow(10, pos-1));
            return (modes/(int)Math.Pow(10, pos-1)) % 2 == 0 ? program[program[eip+pos]] : program[eip+pos];
        }
        public static void run(int[] program)
        {
           
            int eip = 0;
            while (program[eip] != 99)
            {
                int opcode = program[eip] % 10;
                int modes = program[eip] / 100;
                int p1, p2, p3, p4;

                switch (opcode)
                {
                    case 1:
                        // Console.WriteLine("Running {0} with params {1}, {2}, {3}", program[eip], program[eip+1], program[eip+2], program[eip+3] );
                        // Console.WriteLine("Opcode {0} with modes {1}", opcode, modes);

                        p1 = read_param(1, eip, modes, program);
                        p2 = read_param(2, eip, modes, program);
                        program[program[eip+3]] = p1 + p2;
                        eip += 4;
                        break;
                    
                    case 2:
                        // Console.WriteLine("Running {0} with params {1}, {2}, {3}", program[eip], program[eip+1], program[eip+2], program[eip+3] );
                        // Console.WriteLine("Opcode {0} with modes {1}", opcode, modes);

                        p1 = read_param(1, eip, modes, program);
                        p2 = read_param(2, eip, modes, program);
                        program[program[eip+3]] = p1 * p2;
                        eip += 4;
                        break;
                    
                    case 3:
                        Console.WriteLine("Input ?");
                        program[program[eip+1]] = int.Parse(Console.ReadKey().KeyChar.ToString());
                        eip += 2;
                        break;
                    
                    case 4:
                        Console.WriteLine("Output: {0}", modes % 2 == 0 ? program[program[eip+1]] : program[eip+1]);
                        eip += 2;
                        break;
                    
                    case 5:
                        p1 = read_param(1, eip, modes, program);
                        p2 = read_param(2, eip, modes, program);
                        eip = (p1 != 0) ? p2 : (eip + 3);
                        break;

                    case 6:
                        p1 = read_param(1, eip, modes, program);
                        p2 = read_param(2, eip, modes, program);
                        eip = (p1 == 0) ? p2 : (eip + 3);
                        break;

                    case 7:
                        p1 = read_param(1, eip, modes, program);
                        p2 = read_param(2, eip, modes, program);
                        program[program[eip+3]] = (p1 < p2) ? 1 : 0;
                        eip += 4;
                        break;

                    case 8:
                        p1 = read_param(1, eip, modes, program);
                        p2 = read_param(2, eip, modes, program);
                        program[program[eip+3]] = (p1 == p2) ? 1 : 0;
                        eip += 4;
                        break;
                    
                    default:
                        Console.WriteLine("ERROR - Unknown opcode");
                        eip = program.Length;
                        break;
                }
            }
        }
        
        static void Main(string[] args)
        {
            int[] program = File.ReadAllText("day5.txt").Split(',').Select(int.Parse).ToArray();
           
            // Challenge 1: input is 1
            // Challenge 2: input is 5
            run(program);
        }
    }
}
