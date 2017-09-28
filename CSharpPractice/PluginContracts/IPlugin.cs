using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.PluginContracts
{
    public interface IPlugin
    {
        string Name { get; }
        void Do(IEnumerable<string> args);
    }
}
