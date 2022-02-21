using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuggeBook.Domain.UseCases
{
    internal class GetCategories : IGetCategories
    {
        public IEnumerable<Category> Get()
        {
            return Enum.GetValues(typeof(Category)).Cast<Category>();
        }

    }
}
