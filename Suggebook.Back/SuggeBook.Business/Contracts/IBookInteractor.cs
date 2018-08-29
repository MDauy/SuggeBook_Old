using SuggeBook.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Business.Contracts
{
    public interface IBookInteractor
    {
        BookDto GetBook(string bookId);
    }
}
