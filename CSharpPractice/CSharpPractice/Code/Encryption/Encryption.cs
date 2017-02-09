#define DEBUG

using System;
using System.Collections.Generic;

namespace CSharpPractice.Code.Encryption
{
    static class Encryption
    {
        /// <summary>
        /// Commands dictionary
        /// </summary>
        private static Dictionary<string, Action<IEnumerable<string>>>
            algorithms = new Dictionary<string, Action<IEnumerable<string>>>()
        {
            { "caesar", Code.Encryption.Caesar.Execute }
        };

        public static void ShowArgs(IEnumerable<string> args)
        {
            Console.Write("Args: ");
            foreach (var arg in args)
            {
                Console.Write("{0} | ", arg);
            }
            Console.Write('\n');
        }

        public static void Decrypt(IEnumerable<string> args)
        {
            ShowArgs(args);
            throw new NotImplementedException();
        }

        public static void Encrypt(IEnumerable<string> args)
        {
            ShowArgs(args);
            throw new NotImplementedException();
        }
    }
}
