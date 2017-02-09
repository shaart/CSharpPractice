using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Code.Encryption
{
    abstract class EncryptionAlgorithm
    {
        public const string CommandUsageInfo;
        public abstract char Execute();
        private char Encrypt();
        private char Decrypt();

        EncryptionAlgorithm()
        {

        }
    }
}
