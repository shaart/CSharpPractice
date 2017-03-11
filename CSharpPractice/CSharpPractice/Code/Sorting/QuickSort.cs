using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Code.Sorting
{
    public static class QuickSort
    {
        public static void Sort<T>(ref T[] a, SortingOrder order) where T : IComparable
        {
            if (a.Length < 2)
            {
                return;
            }
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

        private static int GetIndexOfPivotElement<T>(T[] a) where T : IComparable
        {
            int pivotIndex = -1;
            T minValue = a[0];
            T maxValue = a[0];
            // Find max and min values
            for (int i = 1; i < a.Length; i++)
            {
                if (Methods.IsFirstBigger(minValue, a[i]))
                {
                    minValue = a[i];
                }
                if (Methods.IsFirstBigger(a[i], maxValue))
                {
                    maxValue = a[i];
                }
            }
            // Values found


            return pivotIndex;
        }


        private static void SortAscending<T>(ref T[] a) where T : IComparable
        {

        }

        private static void SortDescending<T>(ref T[] a) where T : IComparable
        {

        }
    }
}
