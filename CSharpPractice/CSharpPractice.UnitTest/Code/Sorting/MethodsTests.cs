using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpPractice.Code.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Code.Sorting.Tests
{
    [TestClass()]
    public class MethodsTests
    {
        const string CATEGORY = "Sorting methods";

        #region IsFirstBigger()
        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void IsFirstBigger_Int_FirstSmaller()
        {
            int smaller = 5, bigger = 10;
            bool result = Methods.IsFirstBigger(smaller, bigger);
            Assert.AreEqual(result, false);
        }

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void IsFirstBigger_Int_FirstBigger()
        {
            int smaller = 5, bigger = 10;
            bool result = Methods.IsFirstBigger(bigger, smaller);
            Assert.AreEqual(result, true);
        }

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void IsFirstBigger_Int_AreEquals()
        {
            int smaller, bigger;
            smaller = bigger = 5;
            bool result = Methods.IsFirstBigger(bigger, smaller);
            Assert.AreEqual(result, false);
        }

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void IsFirstBigger_Double_FirstSmaller()
        {
            double smaller = 5, bigger = 10;
            bool result = Methods.IsFirstBigger(smaller, bigger);
            Assert.AreEqual(result, false);
        }

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void IsFirstBigger_Double_FirstBigger()
        {
            double smaller = 5, bigger = 10;
            bool result = Methods.IsFirstBigger(bigger, smaller);
            Assert.AreEqual(result, true);
        }

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void IsFirstBigger_Double_AreEquals()
        {
            double smaller, bigger;
            smaller = bigger = 5;
            bool result = Methods.IsFirstBigger(bigger, smaller);
            Assert.AreEqual(result, false);
        }

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void IsFirstBigger_TwoNulls_NotBigger()
        {
            object smaller = null, bigger = null;
            bool result = Methods.IsFirstBigger(bigger, smaller);
            Assert.AreEqual(result, false);
        }

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void IsFirstBigger_NullAndInt_IntBigger()
        {
            object smaller = null, bigger = 5;
            bool result = Methods.IsFirstBigger(bigger, smaller);
            Assert.AreEqual(result, true);
        }
        #endregion

        #region Swap()
        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void Swap_Common()
        {
            const int FIRST = 1, SECOND = 2;
            int e1 = FIRST, e2 = SECOND;
            Methods.Swap(ref e1, ref e2);
            Assert.IsTrue((e1 == SECOND) && (e2 == FIRST));
        }

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void Swap_OneNull()
        {
            const int SECOND = 2;

            int? e1 = null;
            int? e2 = SECOND;

            Methods.Swap(ref e1, ref e2);
            Assert.IsTrue((e1 == SECOND) && (e2 == null));
        }

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void Swap_TwoNull()
        {
            const object DEFAULT = null;
            object e1 = null, e2 = null;
            Methods.Swap(ref e1, ref e2);
            Assert.IsTrue((e1 == DEFAULT) && (e2 == DEFAULT));
        }
        #endregion
    }
}