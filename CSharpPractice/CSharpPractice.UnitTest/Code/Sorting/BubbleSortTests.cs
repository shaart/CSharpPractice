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
    public class BubbleSortTests
    {
        #region INT TEST
        [TestMethod()]
        public void SortTest_Int_Ascending()
        {
            int[] sorted = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[]      a = new int[] { 1, 2, 10, 3, 5, 4, 8, 7, 9, 0, 6 };
            BubbleSort.Sort(ref a, SortingOrder.Ascending);

            bool successfulSorting = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != sorted[i])
                {
                    successfulSorting = false;
                    break;
                }
            }
            Assert.IsTrue(successfulSorting);
        }

        [TestMethod()]
        public void SortTest_Int_Descending()
        {
            int[] sorted = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            int[]      a = new int[] { 1, 2, 10, 3, 5, 4, 8, 7, 9, 0, 6 };
            BubbleSort.Sort(ref a, SortingOrder.Descending);

            bool successfulSorting = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != sorted[i])
                {
                    successfulSorting = false;
                    break;
                }
            }
            Assert.IsTrue(successfulSorting);
        }
        #endregion

        #region DOUBLE TEST
        [TestMethod()]
        public void SortTest_Double_Ascending()
        {
            double[] sorted = new double[] { 0.0001, 0.001, 0.01, 0.1, 0.2, 1.0 };
            double[] a = new double[] { 0.1, 0.0001, 0.2, 0.001, 1.0, 0.01 };
            BubbleSort.Sort(ref a, SortingOrder.Ascending);

            bool successfulSorting = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != sorted[i])
                {
                    successfulSorting = false;
                    break;
                }
            }
            Assert.IsTrue(successfulSorting);
        }

        [TestMethod()]
        public void SortTest_Double_Descending()
        {
            double[] sorted = new double[] { 1.0, 0.2, 0.1, 0.01, 0.001, 0.0001 };
            double[] a = new double[] { 0.1, 0.0001, 0.2, 0.001, 1.0, 0.01 };
            BubbleSort.Sort(ref a, SortingOrder.Descending);

            bool successfulSorting = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != sorted[i])
                {
                    successfulSorting = false;
                    break;
                }
            }
            Assert.IsTrue(successfulSorting);
        }
        #endregion
    }
}