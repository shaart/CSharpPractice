using System;
using CSharpPractice.Code.Sorting;

namespace CSharpPractice.Code.Sorting
{
    public static class BubbleSort
    {
        public static void Sort<T>(ref T[] a, SortingOrder order) where T : IComparable
        {
            for (int outC = 0; outC < a.Length - 1; outC++)
            {
                for (int inC = 0; inC < a.Length - 1 - outC; inC++)
                {
                    switch (order)
                    {
                        case SortingOrder.Ascending:
                            if (Methods.IsFirstBigger(a[inC], a[inC + 1]))
                            {
                                Sorting.Methods.Swap(ref a[inC], ref a[inC + 1]);
                            }
                            break;
                        case SortingOrder.Descending:
                            if (!Methods.IsFirstBigger(a[inC], a[inC + 1]))
                            {
                                Sorting.Methods.Swap(ref a[inC], ref a[inC + 1]);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
