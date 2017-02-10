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
                        separator);                                     // separator

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Creates file with random data
        /// </summary>
        /// <param name="filename">File name with extension (example: file.txt)</param>
        /// <param name="canRewrite">Can rewrite file if exists</param>
        /// <param name="arrayType"></param>
        /// <param name="arrayLength"></param>
        /// <param name="separator"></param>
        /// <example>
        /// <code>
        /// OperationResult res = Generate(
        ///     args.ElementAtOrDefault(0),                     // filename 
        ///     Convert.ToBoolean(args.ElementAtOrDefault(1)),  // canRewrite
        ///     Convert.ToUInt32(args.ElementAtOrDefault(2)),   // arrayLength
        ///     separator);                                     // separator
        /// </code>
        /// </example>
        /// <returns>Operation result</returns>
        public static OperationResult Generate(string filename, bool canRewrite,
            UInt32 arrayLength, string separator = " ")
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
                using (FileStream fs = File.Create(filename))
                {
                    Random rand = new Random();
                    byte[] buffer = new byte[4];
                    byte[] separatorBytes = new UTF8Encoding(true).GetBytes(separator);
                    for (int i = 0; i < arrayLength; i++)
                    {
                        rand.NextBytes(buffer);
                        fs.Write(buffer, 0, buffer.Length);
                        fs.Write(separatorBytes, 0, separatorBytes.Length);
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

        public static OperationResult GenerateTxt(string filename, bool canRewrite,
            UInt32 arrayLength, string separator = " ")
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
                        sw.Write(rand.Next().ToString() + separator);
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
