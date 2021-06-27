using System;

namespace SearchingSortingPagination.Utilities
{
    public static class Validator
    {
        /// <summary>
        /// Checks whether argument is bigger than or equal to the present.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>True if argument belongs to the past, otherwise true.</returns>
        public static bool IsPast(DateTime dt)
        {
            if (DateTime.Compare(dt, DateTime.Now) >= 0) return false;
            return true;
        }
        /// <summary>
        /// Compares two DateTime? values with the convention that null is always smaller than a non-null
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Compare(DateTime? a, DateTime? b)
        {
            if (a != null && b != null)
            {
                return DateTime.Compare(Converter.RemoveNull(a), Converter.RemoveNull(b));
            }
            else if (a!=null)
            {
                return 1;
            }
            else if (b!=null)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}