namespace CSharpPractice.UnitTest.Code.Sorting
{
    public static class SortingTestData
    {
        #region INT TEST DATA
        public static int[] GetIntBlankArray()
        {
            return new int[] { };
        }

        public static int[] GetIntSortedAscend()
        {
            return new int[]
            {
                0, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
        }

        public static int[] GetIntSortedDescend()
        {
            return new int[]
            {
                10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 1, 1, 0
            };
        }

        public static int[] GetIntUnsortedArray()
        {
            return new int[]
            {
                1, 2, 10, 3, 5, 4, 1, 8, 7, 9, 1, 0, 6
            };
        }
        #endregion
        #region DOUBLE TEST DATA
        public static double[] GetDoubleBlankArray()
        {
            return new double[] { };
        }

        public static double[] GetDoubleSortedAscend()
        {
            return new double[] 
            {
                0.0001,
                0.001,
                0.01,
                0.1,
                0.1,
                0.1,
                0.2,
                1.0
            };
        }

        public static double[] GetDoubleSortedDescend()
        {
            return new double[] 
            {
                1.0,
                0.2,
                0.1,
                0.1,
                0.1,
                0.01,
                0.001,
                0.0001
            };
        }

        public static double[] GetDoubleUnsortedArray()
        {
            return new double[] 
            {
                0.1,
                0.0001,
                0.2,
                0.1,
                0.001,
                1.0,
                0.1,
                0.01
            };
        }
        #endregion
    }
}
