using System;

namespace CSharpPractice.Code.Sorting
{
    public static class BubbleSort
    {
        public static void Sort<T>(ref T[] a, SortingOrder order) where T : IComparable
        {
            switch (order)
            {
                case SortingOrder.Ascending:
                    SortAscending(ref a);
                    break;
                case SortingOrder.Descending:
                    SortDescending(ref a);
                    break;
                default:
                    throw new ArgumentException("Unknown sorting order");
            }
        }

        private static void SortAscending<T>(ref T[] a) where T : IComparable
        {
            for (int outC = 0; outC < a.Length - 1; outC++)
            {
                for (int inC = 0; inC < a.Length - 1 - outC; inC++)
                {
                    if (Methods.IsFirstBigger(a[inC], a[inC + 1]))
                    {
                        Sorting.Methods.Swap(ref a[inC], ref a[inC + 1]);
                    }
                }
            }
        }

        private static void SortDescending<T>(ref T[] a) where T : IComparable
        {
            for (int outC = 0; outC < a.Length - 1; outC++)
            {
                for (int inC = 0; inC < a.Length - 1 - outC; inC++)
                {
                    if (!Methods.IsFirstBigger(a[inC], a[inC + 1]))
                    {
                        Sorting.Methods.Swap(ref a[inC], ref a[inC + 1]);
                    }
                }
            }
        }
    }
}
