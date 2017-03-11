using System.Collections.Generic;

namespace CSharpPractice.Code.Sorting
{
    public static class Methods
    {

        public static bool IsFirstBigger<T>(T e1, T e2)
        {
            return (Comparer<T>.Default.Compare(e1, e2) > 0);
        }

        public static void Swap<T>(ref T e1, ref T e2)
        {
            T temp = e1;
            e1 = e2;
            e2 = temp;
        }
    }
}
