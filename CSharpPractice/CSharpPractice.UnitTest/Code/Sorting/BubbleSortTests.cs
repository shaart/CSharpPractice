using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpPractice.Code.Sorting;
using System;
using CSharpPractice.UnitTest.Code.Sorting;

namespace CSharpPractice.Code.Sorting.Tests
{
    [TestClass()]
    public class BubbleSortTests
    {
        const string CATEGORY = "Bubble sorting";

        #region Exception Test
        [TestMethod()]
        [TestCategory(CATEGORY)]
        [ExpectedException(typeof(ArgumentException), "Unknown sorting order")]
        public void Sort_Unknown_Order()
        {
            int[] a = new int[] { 1, 2, 10, 3, 5, 4, 8, 7, 9, 0, 6 };

            BubbleSort.Sort(ref a, (SortingOrder)int.MaxValue);

            Assert.Fail();           
        }
        #endregion

        #region INT TEST
        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void Sort_Int_Ascending()
        {
            int[] sorted = SortingTestData.GetIntSortedAscend();
            int[] a      = SortingTestData.GetIntUnsortedArray();

            BubbleSort.Sort(ref a, SortingOrder.Ascending);
            
            for (int i = 0; i < a.Length; i++)
            {
                Assert.AreEqual(sorted[i], a[i]);
            }
        }

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void Sort_Int_Descending()
        {
            int[] sorted = SortingTestData.GetIntSortedDescend();
            int[]      a = SortingTestData.GetIntUnsortedArray();

            BubbleSort.Sort(ref a, SortingOrder.Descending);
            
            for (int i = 0; i < a.Length; i++)
            {
                Assert.AreEqual(sorted[i], a[i]);
            }
        }

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void Sort_Blank_Int_Descending()
        {
            int[] sorted = SortingTestData.GetIntBlankArray();
            int[] a      = SortingTestData.GetIntBlankArray();

            BubbleSort.Sort(ref a, SortingOrder.Descending);
            
            for (int i = 0; i < a.Length; i++)
            {
                Assert.AreEqual(sorted[i], a[i]);
            }
        }
        #endregion

        #region DOUBLE TEST
        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void Sort_Double_Ascending()
        {
            double[] sorted = SortingTestData.GetDoubleSortedAscend();
            double[] a = SortingTestData.GetDoubleUnsortedArray();

            BubbleSort.Sort(ref a, SortingOrder.Ascending);
            
            for (int i = 0; i < a.Length; i++)
            {
                Assert.AreEqual(sorted[i], a[i]);
            }
        }

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void Sort_Double_Descending()
        {
            double[] sorted = SortingTestData.GetDoubleSortedDescend();
            double[] a = SortingTestData.GetDoubleUnsortedArray();

            BubbleSort.Sort(ref a, SortingOrder.Descending);
            
            for (int i = 0; i < a.Length; i++)
            {
                Assert.AreEqual(sorted[i], a[i]);
            }
        }
        #endregion
    }
}