using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Framework
{
    public static class Constants
    {
        public static readonly int NUMBER_OF_BEST_BOOKS_TO_GET = 5;
        public static readonly int NUMBER_OF_LAST_SUGGESTIONS_TO_GET_FOR_BOOK = 10;
        public static readonly int NUMBER_OF_LAST_SUGGESTIONS_TO_GET_FOR_AUTHOR = 15;
        private static DateTime _minimalDate;
        private static DateTime _minimalDateForCategories;
        public static DateTime MINIMAL_DATE
        {
            get
            {
                if (_minimalDate == null)
                {
                    _minimalDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month - 3, DateTime.Today.Day);
                }
                return _minimalDate;
            }
        }


        public static DateTime MINIMAL_DATE_FOR_CATEGORIES
        {
            get
            {
                if (_minimalDateForCategories == null)
                {
                    _minimalDateForCategories = new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, DateTime.Today.Day);
                }
                return _minimalDateForCategories;
            }
        }
    }
}
