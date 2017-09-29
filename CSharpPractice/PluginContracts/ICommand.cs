using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginContracts
{
    public interface ICommand
    {
        string Name { get; }
        string Description { get; }
        string CommandUsageInfo { get; }
        void Run(IEnumerable<string> args);
    }
}
