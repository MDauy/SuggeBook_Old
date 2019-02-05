using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Framework
{
   public static class ListHelper
    {
        public static bool ContainsAll<T> (this List<T> l1, List<T> l2)
        {
            foreach (var item in l2)
            {
                if (!l1.Contains(item))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
