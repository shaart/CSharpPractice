using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace CSharpPractice.Code.Files
{
    static class FileGenerator
    {
        /// <summary>
        /// Command usage and parameters information
        /// </summary>
        public const string CommandUsageInfo =
            // 4 params:                       0                1             2               3           4           5
            //"Command usage: (gen)erate [output_file.<ext>] [canRewrite] [elements_count] [min_value] [max_value] [separator]\n" +
            "Command usage: (gen)erate [output_file.<ext>] [canRewrite] [elements_count] [separator]\n" +
            "Parameters: \n" +
            "   [output_file.<ext>]     Output file path with file extension. Example: t.txt.\n" +
            "   [canRewrite]            'true' or 'false' - can rewrite file is exists.\n" +
            "   elements_count          Number of generating elements.\n" +
            //"   min_value               Minimal value of generating elements. Default: 0.\n" +
            //"   max_value               Maximal value of generating elements. Default: 1000.\n" +
            "   separator               Optional parameter. Separator between elements.\n" +
            "                           Default: \" \" (space).\n";

        private enum Indexes {
            Output_file = 0,
            CanRewrite = 1,
            Elements_count = 2,
            Min_value = 3,
            Max_value = 4,
            Separator = 5 };

        //private const byte index_output_file = 0;
        //private const byte index_canRewrite = 1;
        //private const byte index_elements_count = 2;
        //private const byte index_min_value = 3;
        //private const byte index_max_value = 4;
        //private const byte index_separator = 5;

        public enum OperationResult { Completed, AbortedByCondition, Failed };

        private static void ShowElapsedTime(Stopwatch timer)
        {
            Console.WriteLine("Operation elapsed: {0} ms",
                timer.Elapsed.ToString());
        }

        /// <summary>
        /// Creates file with random data
        /// </summary>
        /// <param name="args">filename | canRewrite | arrayLength | (optional) serapator</param>
        public static void Generation(IEnumerable<string> args)
        {
            if ((args.Count() == 0) ||
                (args.FirstOrDefault() == Code.AppConsole.COMMAND_HELP) || 
                (args.FirstOrDefault() == Code.AppConsole.COMMAND_HELP_ARG))
            {
                Console.WriteLine(CommandUsageInfo);
                return;
            }

            try
            {
                string separator = args.ElementAtOrDefault(3);

                if ((separator == "")||(separator == null))
                {
                    OperationResult res = GenerateTxt(
                        args.ElementAtOrDefault(0),                     // filename 
                        Convert.ToBoolean(args.ElementAtOrDefault(1)),  // canRewrite
                        Convert.ToUInt32(args.ElementAtOrDefault(2)));  // arrayLength
                }
                else
                {
                    OperationResult res = GenerateTxt(
                        args.ElementAtOrDefault(0),                     // filename 
                        Convert.ToBoolean(args.ElementAtOrDefault(1)),  // canRewrite
                        Convert.ToUInt32(args.ElementAtOrDefault(2)),   // arrayLength
                        separator: separator);                          // separator

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///// <summary>
        ///// Creates file with random data
        ///// </summary>
        ///// <param name="filename">File name with extension (example: file.txt)</param>
        ///// <param name="canRewrite">Can rewrite file if exists</param>
        ///// <param name="arrayType"></param>
        ///// <param name="arrayLength"></param>
        ///// <param name="separator"></param>
        ///// <example>
        ///// <code>
        ///// OperationResult res = Generate(
        /////     args.ElementAtOrDefault(0),                     // filename 
        /////     Convert.ToBoolean(args.ElementAtOrDefault(1)),  // canRewrite
        /////     Convert.ToUInt32(args.ElementAtOrDefault(2)),   // arrayLength
        /////     0,                                              // minValue
        /////     1000,                                           // maxValue
        /////     separator);                                     // separator
        ///// </code>
        ///// </example>
        ///// <returns>Operation result</returns>
        //public static OperationResult Generate(string filename, bool canRewrite,
        //    UInt32 arrayLength, string separator = " ")
        //{
        //    try
        //    {
        //        Stopwatch timer = new Stopwatch();
        //        timer.Start();
        //        if (File.Exists(filename) && !canRewrite)
        //        {
        //            timer.Stop();
        //            ShowElapsedTime(timer);
        //            return OperationResult.AbortedByCondition;
        //        }
        //        using (FileStream fs = File.Create(filename))
        //        {
        //            Random rand = new Random();
        //            byte[] buffer = new byte[4];
        //            byte[] separatorBytes = new UTF8Encoding(true).GetBytes(separator);
        //            for (int i = 0; i < arrayLength; i++)
        //            {
        //                rand.NextBytes(buffer);
        //                fs.Write(buffer, 0, buffer.Length);
        //                fs.Write(separatorBytes, 0, separatorBytes.Length);
        //            }
        //        }

        //        timer.Stop();
        //        ShowElapsedTime(timer);
        //        return OperationResult.Completed;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static OperationResult GenerateTxt(string filename, bool canRewrite,
            UInt32 arrayLength, int minValue = 0, int maxValue = 1000, string separator = " ")
        {
            try
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                if (File.Exists(filename) && !canRewrite)
                {
                    timer.Stop();
                    ShowElapsedTime(timer);
                    return OperationResult.AbortedByCondition;
                }
                using (StreamWriter sw = new StreamWriter(filename, false)) // false = rewrite
                {
                    Random rand = new Random();
                    for (int i = 0; i < arrayLength; i++)
                    {
                        sw.Write(rand.Next(minValue, maxValue).ToString() + separator);
                    }
                }

                timer.Stop();
                ShowElapsedTime(timer);
                return OperationResult.Completed;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
