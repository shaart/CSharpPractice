﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpPractice.Code
{
    // Консоль в C# - Обработчик команд
    // http://ru.stackoverflow.com/questions/203720/%D0%9A%D0%BE%D0%BD%D1%81%D0%BE%D0%BB%D1%8C-%D0%B2-c-%D0%9E%D0%B1%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D1%87%D0%B8%D0%BA-%D0%BA%D0%BE%D0%BC%D0%B0%D0%BD%D0%B4
    // Cross Reference: getline.cs      xref: /mono/mcs/tools/csharp/getline.cs
    // http://code.metager.de/source/xref/mono/mcs/tools/csharp/getline.cs
    public static class AppConsole
    {
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
                App.Current.Shutdown(); }) },
            { "encrypt", Encryption.Encryption.Encrypt },
            { "enc", Encryption.Encryption.Encrypt },
            { "decrypt", Encryption.Encryption.Decrypt },
            { "dec", Encryption.Encryption.Decrypt }
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