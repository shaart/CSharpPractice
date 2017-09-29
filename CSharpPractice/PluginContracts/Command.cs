using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginContracts
{
    public class Command : ICommand
    {
        public readonly string CommandUsageInfo;
        public readonly string Name;
        public readonly string Description;
        public readonly Action<IEnumerable<string>> Run;

        public Command(string name, Action<IEnumerable<string>> action, string description = "", string commandUsageInfo = "")
        {
            Name = name;
            Run = action;
            Description = description;
            CommandUsageInfo = commandUsageInfo;
        }

        string ICommand.Description
        {
            get
            {
                return Description;
            }
        }

        string ICommand.CommandUsageInfo
        {
            get
            {
                return CommandUsageInfo;
            }
        }

        string ICommand.Name
        {
            get
            {
                return Name;
            }
        }

        void ICommand.Run(IEnumerable<string> args)
        {
            Run(args);
        }
    }
}
