using System.Collections.Generic;

namespace SuggeBook.Framework
{
    public static class ListExtensions
    {
        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            var enumerator = list?.GetEnumerator();
            if (enumerator == null)
            {
                return true;
            };
            enumerator.MoveNext();
            if (enumerator.Current == null)
            {
                return true;
            }
            return false;
        }
    }
}
