using System.Collections.Generic;
using System.Linq;

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


        public static List<T> GetMatches<T> (this List<T> list1, List<T> list2)
        {
            return list2.Except(list1).ToList();
        }

        public static bool HasMatches<T> (this List<T> list1, List<T> list2)
        {
            return !list1.GetMatches(list2).IsNullOrEmpty();
        }
    }
}
