using System.Collections.Generic;

namespace SuggeBook.Framework
{
    public static class ListExtensions
    {
        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            var enumerator = list?.GetEnumerator();
            return enumerator == null || enumerator.Current == null;
        }
    }
}
