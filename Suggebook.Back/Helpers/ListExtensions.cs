using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public static class ListExtensions
    {
        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            if (list == null)
            {
                return true;
            }

            var enumerator = list.GetEnumerator();
            if (enumerator == null || enumerator.Current == null)
            {
                return true;
            }

            return false;
        }
    }
}
