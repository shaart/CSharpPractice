﻿using PluginContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginContracts
{
    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }
        string Author { get; }
        HashSet<ICommand> Commands { get; }
    }
}
