using SuggeBook.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Domain.Repositories
{
    public interface IShowRepository
    {
        IEnumerable<Show> GetShowsAccordingToCategory(List<Category> categories, ShowType showType);

        void Create(Show show);

        Show Get(int id);


    }
}
