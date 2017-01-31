using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISaPI.Code.Encrypting
{
    public static class Caesar
    {
        public static string CommandInfo = "Command usage: caesar [input_file] [output_file]";

        public static void Execute(IEnumerable<string> args)
        {
            Console.Write("Caesar with args: ");
            foreach (var arg in args)
            {
                Console.Write(arg + ' ');
            }
            Console.Write('\n');
        }
    }
}
