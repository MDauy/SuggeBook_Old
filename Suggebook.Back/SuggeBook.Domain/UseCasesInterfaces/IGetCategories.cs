using SuggeBook.Domain.Model;
using System.Collections.Generic;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface IGetCategories
    {
        IEnumerable<Category> Get();
    }
}
