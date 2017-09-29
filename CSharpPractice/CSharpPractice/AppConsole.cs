using System;
using System.Collections.Generic;
using System.Linq;
using PluginContracts;

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
        public static Dictionary<string, IPlugin> _Plugins;

        /// <summary>
        /// "help"
        /// </summary>
        public const string COMMAND_HELP = "help";
        /// <summary>
        /// "/?"
        /// </summary>
        public const string COMMAND_HELP_ARG = "/?";

        public static void LoadPlugins(string path)
        {
            _Plugins = new Dictionary<string, IPlugin>();
            //ICollection<IPlugin> plugins = PluginLoader.LoadPlugins("Plugins");
            ICollection<IPlugin> plugins = GenericPluginLoader<IPlugin>.LoadFrom(path);
            foreach (var plugin in plugins)
            {
                _Plugins.Add(plugin.Name, plugin);
                System.Console.WriteLine("| Plugin '{0}' loading", plugin.Name);
                if (plugin.Commands != null)
                {
                    foreach (var command in plugin.Commands)
                    {
                        if (commands != null)
                        {
                            commands.Add(command.Name, command);
                            System.Console.WriteLine("Loaded command: {0}", command.Name);
                        }
                    }
                }
            }
            System.Console.WriteLine("| Plugins loaded\n");
        }

        /// <summary>
        /// Commands dictionary
        /// </summary>
        private static Dictionary<string, ICommand>
            commands = new Dictionary<string, ICommand>()
        {
            { "hello", new Command("hello", (args) => {
                Console.WriteLine("Hello, user!"); })
            },
            { "exit", new Command("exit", (args) => {
                Console.WriteLine("Bye, user!");
                App.Current.Shutdown(); })
            }//,
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
            // help || /?
            if (command == COMMAND_HELP)
            {
                if (tokens.Count() < 2)
                {
                    foreach (var comPair in commands)
                    {
                        Console.WriteLine("{0}    {1}", comPair.Value.Name, comPair.Value.Description);
                    }
                }
                else
                {
                    string currCommand = tokens.ElementAt(1);
                    if (commands.ContainsKey(currCommand))
                    {
                        Console.WriteLine(commands[currCommand].CommandUsageInfo != "" ?
                            commands[currCommand].CommandUsageInfo
                            : "No description");
                    }
                    else
                    {
                        Console.WriteLine("Unrecognized command: {0}", currCommand);
                    }
                }
            }
            else if (commands.ContainsKey(command))
            {
                if (tokens.LastOrDefault() == COMMAND_HELP_ARG)
                {
                    Console.WriteLine(commands[command].CommandUsageInfo != "" ?
                        commands[command].CommandUsageInfo 
                        : "No description");

                    return;
                }

                try
                {
                    commands[command].Run(tokens.Skip(1));
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
