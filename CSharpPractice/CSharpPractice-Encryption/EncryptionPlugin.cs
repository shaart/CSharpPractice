using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginContracts;

namespace CSharpPractice.Encryption
{
    public class EncryptionPlugin : IPlugin
    {
        public string Name { get { return "Encryption"; } }
        public string Author { get { return "Shalaev Artur"; } }
        public string Description { get { return "Encrypt and decrypt library"; } }
        
        public HashSet<ICommand> Commands
        {
            get
            {
                return new HashSet<ICommand>()
                {
                    new EncryptCommand(),
                    new DecryptCommand()
                };
            }
        }
    }
}
