using System;
using System.Collections.Generic;
using System.Linq;
using CSharpPractice.PluginContracts;

namespace CSharpPractice
{
    // Консоль в C# - Обработчик команд
    // http://ru.stackoverflow.com/questions/203720/Консоль-в-c-Обработчик-команд
    // Cross Reference: getline.cs      xref: /mono/mcs/tools/csharp/getline.cs
    // http://code.metager.de/source/xref/mono/mcs/tools/csharp/getline.cs
    // Design patterns for console commands
    // https://codereview.stackexchange.com/questions/105675/design-patterns-for-console-commands
    public static class AppConsole
    {
        /// <summary>
        /// "help"
        /// </summary>
        public const string COMMAND_HELP = "help";
        /// <summary>
        /// "/?"
        /// </summary>
        public const string COMMAND_HELP_ARG = "/?";

        /// <summary>
        /// Commands dictionary
        /// </summary>
        private static Dictionary<string, Action<IEnumerable<string>>>
            commands = new Dictionary<string, Action<IEnumerable<string>>>()
        {
            { "hello", RunSimpleCommand( () =>
                Console.WriteLine("Hello, user!")) },
            { "exit", RunSimpleCommand( () => {
                Console.WriteLine("Bye, user!");
                App.Current.Shutdown(); }) }//,
            //// Encryption
            //{ "encrypt", Encryption.Encryption.Encrypt },
            //{ "enc", Encryption.Encryption.Encrypt },
            //// Decryption
            //{ "decrypt", Encryption.Encryption.Decrypt },
            //{ "dec", Encryption.Encryption.Decrypt },
            //// File generation
            //{ "generate", Files.FileGenerator.Generation },
            //{ "gen", Files.FileGenerator.Generation }
        };

        public static void RunCommand(string input)
        {
            Console.WriteLine('>' + input);

            IEnumerable<string> tokens = SplitIntoTokens(input);
            string command = tokens.FirstOrDefault();
            if (command == null) { return; }
            if (commands.ContainsKey(command))
            {
                try
                {
                    commands[command](tokens.Skip(1));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Execution failed: {0}", e.Message);
                }
            }
            else
            {
                Console.WriteLine("Unrecognized command: {0}", command);
            }
        }

        /// <summary>
        /// Run command without arguments
        /// </summary>
        /// <param name="a">Delegate action</param>
        /// <example>() => Console.WriteLine("Hello, user!")</example>
        /// <returns></returns>
        private static Action<IEnumerable<string>> RunSimpleCommand(Action a)
        {
            return args =>
            {
                if (args.Any())
                    throw new ArgumentException("This command doesn't support args");
                a();
            };
        }

        private static IEnumerable<string> SplitIntoTokens(string input)
        {
            return input.Split(null as char[], StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
