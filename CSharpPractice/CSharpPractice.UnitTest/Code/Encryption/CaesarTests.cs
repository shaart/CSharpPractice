using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpPractice.Code.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Code.Encryption.Tests
{
    [TestClass()]
    public class CaesarTests
    {
        const string CATEGORY = "Encryption Caesar";

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void Encrypt_Symbol()
        {
            char result = Caesar.Encrypt('б', 1);
            Assert.AreEqual(result, 'в');

            result = Caesar.Encrypt('Г', 2);
            Assert.AreEqual(result, 'Е');

            result = Caesar.Encrypt('D', 2);
            Assert.AreEqual(result, 'F');
        }

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void Decrypt_Symbol()
        {
            char result = Caesar.Decrypt('в', 1);
            Assert.AreEqual(result, 'б');

            result = Caesar.Decrypt('Е', 2);
            Assert.AreEqual(result, 'Г');

            result = Caesar.Decrypt('F', 2);
            Assert.AreEqual(result, 'D');
        }
    }
}