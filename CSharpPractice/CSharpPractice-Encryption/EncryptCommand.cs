﻿using PluginContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Encryption
{
    internal class EncryptCommand : ICommand
    {
        public string Name
        {
            get
            {
                return "encrypt";
            }
        }

        public string CommandUsageInfo
        {
            get
            {
                return "";
            }
        }

        public string Description
        {
            get
            {
                return "Encrypts file using one of algorithms";
            }
        }

        public void Run(IEnumerable<string> args)
        {
            Encryption.Encrypt(args);
        }
    }
}