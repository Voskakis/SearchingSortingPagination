using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchingSortingPagination.Utilities
{
    public static class Converter
    {
        /// <summary>
        /// Converts a non-null DateTime? value to DateTime.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>Argument dt cast into DateTime type.</returns>
        /// <exception cref="ArgumentNullException"></exception>
       public static DateTime RemoveNull(DateTime? dt)
        {
            if (dt == null) throw new ArgumentNullException("Method 'DateTime RemoveNull()' only accepts DateTime? non-null values.");
            return (DateTime)dt;
        }
    }
}