#define DEBUG

using System;
using System.Collections.Generic;
using System.Linq;

namespace ISaPI.Code.Encrypting
{
    public static class Caesar
    {
        #region STRINGS
        public const string CommandUsageInfo = 
            // 4 params:                    0               1           2           3
            "Command usage: caesar [(e)ncrypt/(d)ecrypt] <offset> [input_file] [output_file]\n" +
            "Parameters: \n" +
            "   encrypt (e)     Encryption parameter.\n" +
            "   decrypt (d)     Decryption parameter.\n" +
            "   <offset>        Number. Key of encryption.\n" +
            "   input_file      Path to original file.\n" +
            "   output_file     Optional parameter. Path to result file.\n" +
            "                   If parameter is missing - use [input_file] as output.\n";

        private const ushort PARAMETERS_INDEX_OFFSET = 1;
        private const ushort PARAMETERS_INDEX_INPUT = 2;
        private const ushort PARAMETERS_INDEX_OUTPUT = 3;

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
        public static void Execute(IEnumerable<string> args)
        {
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
                    throw new Exception(EXCEPTION_MESSAGE_NOT_ENOUGH_PARAMETERS);
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
                    throw new Exception(EXCEPTION_MESSAGE_INCORRECT_PARAMETERS);
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
    }
}
