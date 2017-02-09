#define DEBUG

using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpPractice.Code.Encryption
{
    public class Caesar
    {
        #region STRINGS
        /// <summary>
        /// Command usage and parameters information
        /// </summary>
        public const string CommandUsageInfo =
            // 4 params:                            0        1           2           3
            "Command usage: [(e)ncrypt/(d)ecrypt] caesar <offset> [input_file] [output_file]\n" +
            "Parameters: \n" +
            "   <offset>        Number. Key of encryption.\n" +
            "   input_file      Path to original file.\n" +
            "   output_file     Optional parameter. Path to result file.\n" +
            "                   If parameter is missing - use [input_file] as output.\n";

        private const byte PARAMETERS_INDEX_OFFSET = 1;
        private const byte PARAMETERS_INDEX_INPUT = 2;
        private const byte PARAMETERS_INDEX_OUTPUT = 3;

        private const string EXCEPTION_MESSAGE_NOT_ENOUGH_PARAMETERS = 
            "Not enough parameters. \n\n" + CommandUsageInfo;
        private const string EXCEPTION_MESSAGE_INCORRECT_PARAMETERS = 
            "Incorrect parameters. \n\n" + CommandUsageInfo;
        #endregion STRINGS

        /// <summary>
        /// Encrypt symbol
        /// </summary>
        /// <param name="offer"></param>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        private static char Encrypt(char symbol, long offset)
        {
            return (char)((int)symbol + offset);
        }

        /// <summary>
        /// Decrypt symbol
        /// </summary>
        /// <param name="offer"></param>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        private static char Decrypt(char symbol, long offset)
        {
            return (char)((int)symbol - offset);
        }

        /// <summary>
        /// Check files, starts algorithm
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        private static void ProcessFile(bool isEncrypt, long offset, 
            string inputFile, string outputFile = "")
        {
            return;
        }

        /// <summary>
        /// Processing command arguments and starts appropriate process
        /// </summary>
        /// <param name="args">command arguments</param>
        /// <exception cref="ArgumentException">Thrown "Not enough parameters", "Incorrect parameters"</exception>
        public static void Execute(IEnumerable<string> args)
        {
            throw new Exception("Doesn't work. In developing");

            #if DEBUG
            Console.Write("Caesar with args: ");
            foreach (var arg in args)
            {
                Console.Write(arg + ' ');
            }
            Console.Write('\n');
            #endif
            if (args.Count() < 3)
            {
                if (args.FirstOrDefault() == "/?")
                {
                    Console.WriteLine(CommandUsageInfo);
                    return;
                }
                else
                {
                    throw new ArgumentException(EXCEPTION_MESSAGE_NOT_ENOUGH_PARAMETERS);
                }
            }

            bool isEncrypt = false;
            switch (args.FirstOrDefault())
            {
                case "encrypt":
                case "e":
                    isEncrypt = true;
                    break;
                case "decrypt":
                case "d":
                    isEncrypt = false;
                    break;
                default:
                    throw new ArgumentException(EXCEPTION_MESSAGE_INCORRECT_PARAMETERS);
            }
            long offset = System.Convert.ToInt64(args.ElementAt(PARAMETERS_INDEX_OFFSET));
            if (args.Count() > 3)
            {
                ProcessFile(isEncrypt, offset, 
                    args.ElementAt(PARAMETERS_INDEX_INPUT), 
                    args.ElementAt(PARAMETERS_INDEX_OUTPUT));
            }
            else // == 3
            {
                ProcessFile(isEncrypt, offset,
                    args.ElementAt(PARAMETERS_INDEX_INPUT));
            }
        }

        public static void Encrypt(IEnumerable<string> args)
        {
            throw new NotImplementedException();
        }

        public static void Decrypt(IEnumerable<string> args)
        {
            throw new NotImplementedException();
        }
    }
}
