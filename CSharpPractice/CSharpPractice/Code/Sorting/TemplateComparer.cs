using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Code.Sorting
{
    public static class TemplateComparer
    {
        public static bool IsFirstBigger<T>(T e1, T e2)
        {
            return (Comparer<T>.Default.Compare(e1, e2) > 0);
        }
    }
}
