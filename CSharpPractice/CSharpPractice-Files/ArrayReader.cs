using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using System.Runtime.CompilerServices;
[assembly: InternalsVisibleToAttribute("CSharpPractice.UnitTest")]

namespace CSharpPractice.Files
{
    public static class ArrayReader
    {
        public static int[] ReadFromFileTxt(string filename)
        {
            List<int> resultList = new List<int>();
            try
            {
                using (StreamReader file = new StreamReader(filename))
                {
                    while (!file.EndOfStream)
                    {
                        resultList.Add(file.Read());
                    }
                }
                return resultList.ToArray<int>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
