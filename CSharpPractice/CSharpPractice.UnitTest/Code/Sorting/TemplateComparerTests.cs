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
    public class TemplateComparerTests
    {
        [TestMethod()]
        public void IsFirstBiggerTest_Int_FirstSmaller()
        {
            int smaller = 5, bigger = 10;
            bool result = TemplateComparer.IsFirstBigger(smaller, bigger);
            Assert.AreEqual(result, false);
        }

        [TestMethod()]
        public void IsFirstBiggerTest_Int_FirstBigger()
        {
            int smaller = 5, bigger = 10;
            bool result = TemplateComparer.IsFirstBigger(bigger, smaller);
            Assert.AreEqual(result, true);
        }

        [TestMethod()]
        public void IsFirstBiggerTest_Int_AreEquals()
        {
            int smaller, bigger;
            smaller = bigger = 5;
            bool result = TemplateComparer.IsFirstBigger(bigger, smaller);
            Assert.AreEqual(result, false);
        }

        [TestMethod()]
        public void IsFirstBiggerTest_Double_FirstSmaller()
        {
            double smaller = 5, bigger = 10;
            bool result = TemplateComparer.IsFirstBigger(smaller, bigger);
            Assert.AreEqual(result, false);
        }

        [TestMethod()]
        public void IsFirstBiggerTest_Double_FirstBigger()
        {
            double smaller = 5, bigger = 10;
            bool result = TemplateComparer.IsFirstBigger(bigger, smaller);
            Assert.AreEqual(result, true);
        }

        [TestMethod()]
        public void IsFirstBiggerTest_Double_AreEquals()
        {
            double smaller, bigger;
            smaller = bigger = 5;
            bool result = TemplateComparer.IsFirstBigger(bigger, smaller);
            Assert.AreEqual(result, false);
        }
    }
}