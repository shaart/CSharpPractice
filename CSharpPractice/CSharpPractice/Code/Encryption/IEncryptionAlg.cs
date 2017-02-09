using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Code.Encryption
{
    interface IEncryptionAlg
    {
        void Encrypt(IEnumerable<string> args);

        void Decrypt(IEnumerable<string> args);
    }
}
