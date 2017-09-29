#define DEBUG

using System;
using System.Collections.Generic;
using System.Linq;

using System.Runtime.CompilerServices;
[assembly: InternalsVisibleToAttribute("CSharpPractice.UnitTest")]

namespace CSharpPractice.Encryption
{
    static class Encryption
    {
        /// <summary>
        /// Commands dictionary
        /// </summary>
        private static Dictionary<string, Action<IEnumerable<string>>>
            algorithms = new Dictionary<string, Action<IEnumerable<string>>>()
        {
            { "encrypt caesar", Caesar.Encrypt },
            { "decrypt caesar", Caesar.Decrypt }
        };

        public static void ShowArgs(IEnumerable<string> args)
        {
            Console.Write("Args: ");
            foreach (var arg in args)
            {
                Console.Write("{0}   ", arg);
            }
            Console.Write('\n');
        }

        private static void Execute(string process, IEnumerable<string> args)
        {
            string alg = args.FirstOrDefault();
            if (alg == null) { return; }
            string algKey = string.Format("{0} {1}", process, alg);
            if (algorithms.ContainsKey(algKey))
            {
                try
                {
                    algorithms[algKey](args.Skip(1));
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                Console.WriteLine("Unrecognized algorithm: {0}", alg);
            }
        }

        public static void Decrypt(IEnumerable<string> args)
        {
            ShowArgs(args);
            Execute("decrypt", args);
        }

        public static void Encrypt(IEnumerable<string> args)
        {
            ShowArgs(args);
            Execute("encrypt", args);
        }
    }
}
