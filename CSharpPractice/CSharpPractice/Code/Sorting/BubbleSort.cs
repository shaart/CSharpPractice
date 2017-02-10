using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CSharpPractice.Code.Sorting
{
    public static class BubbleSort
    {
        public enum SortingOrder { Ascending, Descending  }

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
                            if (TemplateComparer.IsFirstBigger(a[j], a[i]))
                            {
                                dump = a[j];
                                a[j] = a[i];
                                a[i] = dump;
                            }
                            break;
                        case SortingOrder.Descending:
                            if (TemplateComparer.IsFirstBigger(a[j], a[i]))
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
