#define DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("CSharpPractice.UnitTest")]

namespace CSharpPractice.Code.Encryption
{
    public static class Caesar
    {
        #region STRINGS
        /// <summary>
        /// Command usage and parameters information
        /// </summary>
        public const string CommandUsageInfo =
            // 4 params:                                   0          1            2
            "Command usage: (enc)rypt/(dec)rypt caesar <offset> [input_file] [output_file]\n" +
            "Parameters: \n" +
            "   <offset>        Number. Key of encryption.\n" +
            "   input_file      Path to original file.\n" +
            "   output_file     Optional parameter. Path to result file.\n" +
            "                   If parameter is missing - use [input_file] as output.\n";

        private const byte PARAMETERS_INDEX_OFFSET = 0;
        private const byte PARAMETERS_INDEX_INPUT = 1;
        private const byte PARAMETERS_INDEX_OUTPUT = 2;
        private const byte ARGUMENTS_COUNT = 3;
        private const byte OPTIONAL_PARAMETERS_COUNT = 1;

        private const string EXCEPTION_MESSAGE_NOT_ENOUGH_PARAMETERS =
            "Not enough parameters.";
        private const string EXCEPTION_MESSAGE_INCORRECT_PARAMETERS =
            "Incorrect parameters.";
        private const string EXCEPTION_MESSAGE_TOO_MUCH_PARAMETERS =
            "Too much parameters.";
        #endregion STRINGS

        /// <summary>
        /// Checks received arguments for correctness
        /// </summary>
        /// <param name="args">Received arguments</param>
        /// <exception cref="ArgumentException"/>
        /// <returns></returns>
        private static bool isArgsCheckSuccessfull(IEnumerable<string> args)
        {
#if DEBUG
            Console.Write("Caesar with args: ");
            foreach (var arg in args)
            {
                Console.Write(arg + ' ');
            }
            Console.Write('\n');
#endif
            if (args.FirstOrDefault() == AppConsole.COMMAND_HELP || args.FirstOrDefault() == AppConsole.COMMAND_HELP_ARG)
            {
                Console.WriteLine(CommandUsageInfo);
                return false;
            }
            // Args can count 2 (offset, input_file) or 3 (..., output_file)
            if (args.Count() < ARGUMENTS_COUNT - OPTIONAL_PARAMETERS_COUNT) 
            {
                throw new ArgumentException(EXCEPTION_MESSAGE_NOT_ENOUGH_PARAMETERS);
            }
            else if (args.Count() > ARGUMENTS_COUNT)
            {
                throw new ArgumentException(EXCEPTION_MESSAGE_TOO_MUCH_PARAMETERS);
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <exception cref="ArgumentException"/>
        public static void Encrypt(IEnumerable<string> args)
        {
            try
            {
                Console.WriteLine("== Caesar Encrypt ==");
                throw new NotImplementedException();
                if (isArgsCheckSuccessfull(args))
                {
                    long offset = System.Convert.ToInt64(args.ElementAt(PARAMETERS_INDEX_OFFSET));
                    if (args.Count() > ARGUMENTS_COUNT)
                    {
                        ProcessFile(true, offset,
                            args.ElementAt(PARAMETERS_INDEX_INPUT),
                            args.ElementAt(PARAMETERS_INDEX_OUTPUT));
                    }
                    else // == 3
                    {
                        ProcessFile(true, offset,
                            args.ElementAt(PARAMETERS_INDEX_INPUT));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <exception cref="ArgumentException"/>
        public static void Decrypt(IEnumerable<string> args)
        {
            try
            {
                Console.WriteLine("== Caesar Decrypt ==");
                throw new NotImplementedException();
                if (isArgsCheckSuccessfull(args))
                {
                    long offset = System.Convert.ToInt64(args.ElementAt(PARAMETERS_INDEX_OFFSET));
                    if (args.Count() > ARGUMENTS_COUNT)
                    {
                        ProcessFile(false, offset,
                            args.ElementAt(PARAMETERS_INDEX_INPUT),
                            args.ElementAt(PARAMETERS_INDEX_OUTPUT));
                    }
                    else // == 3
                    {
                        ProcessFile(false, offset,
                            args.ElementAt(PARAMETERS_INDEX_INPUT));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Encrypt symbol
        /// </summary>
        /// <param name="offer"></param>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        internal static char Encrypt(char symbol, long offset)
        {
            return (char)((int)symbol + offset);
        }

        /// <summary>
        /// Decrypt symbol
        /// </summary>
        /// <param name="offer"></param>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        internal static char Decrypt(char symbol, long offset)
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
            throw new NotImplementedException();
        }
    }
}
