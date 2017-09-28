using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpPractice.PluginContracts;

namespace CSharpPractice.Encryption
{
    public class EncryptionPlugin : IPlugin
    {
        public string Name
        {
            get
            {
                return "encryption";
            }
        }

        public void Do(IEnumerable<string> args)
        {
            Console.WriteLine("Encryption Plugin Do() called");
        }
    }
}
