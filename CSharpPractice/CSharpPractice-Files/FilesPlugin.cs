using System;
using System.Collections.Generic;
using PluginContracts;

namespace CSharpPractice.Encryption
{
    public class FilesPlugin : IPlugin
    {
        public string Name { get { return "Files"; } }
        public string Author { get { return "Shalaev Artur"; } }
        public string Description { get { return "Working with files"; } }
        
        public HashSet<ICommand> Commands
        {
            get
            {
                return null;
            }
        }
    }
}
