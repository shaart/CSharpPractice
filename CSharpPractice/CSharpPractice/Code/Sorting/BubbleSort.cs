using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CSharpPractice.Code.Sorting
{
    static class BubbleSort
    {
        public enum SortingOrder { Ascending, Descending  }

        private static bool IsFirstBigger<T>(T e1, T e2)
        {
            return (Comparer<T>.Default.Compare(e1, e2) >= 0);
        }

        public static void Sort<T>(ref T[] a, SortingOrder order) where T : IComparable
        {
            T dump;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    switch (order)
                    {
                        case SortingOrder.Ascending:
                            if (a[j].CompareTo(a[i]) >= 0)
                            {
                                dump = a[j];
                                a[j] = a[i];
                                a[i] = dump;
                            }
                            break;
                        case SortingOrder.Descending:
                            if (a[j] > a[i])
                            {
                                dump = a[j];
                                a[j] = a[i];
                                a[i] = dump;
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
